using CAPA_ENTIDAD;
using CAPA_LOGICO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.Mantenimientos
{
    public partial class FrmMntCcosto : System.Web.UI.Page
    {
        Ent_Provincias objEProvincia;
        Ent_Distritos objEDistrito;
        Ent_Ccosto objECcosto;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                Carga_Departamentos();
                Lista_Ccosto(txtCcostoBuscar.Text);
                lblCcosto_Id.Visible = false;
                btnActualizar.Visible = false;
            }
        }

        void Carga_Departamentos()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            cboDepartamento.DataSource = Log_Departamentos.Lista_Departamentos();
            cboDepartamento.DataTextField = "Descripcion";
            cboDepartamento.DataValueField = "Codigo";
            cboDepartamento.DataBind();
            cboDepartamento.Items.Insert(0, new ListItem("--Seleccione--"));
        }
        void Carga_Provincias(String Departamento_Id)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            objEProvincia = new Ent_Provincias();
            objEProvincia.Sub_Filtro = Departamento_Id;
            cboProvincia.DataSource = Log_Provincias.Lista_Provincias(objEProvincia);
            cboProvincia.DataTextField = "Descripcion";
            cboProvincia.DataValueField = "Codigo";
            cboProvincia.DataBind();
            cboProvincia.Items.Insert(0, new ListItem("--Seleccione--"));
        }
        void Carga_Distritos(String Departamento_Id, String Provincia_Id)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            objEDistrito = new Ent_Distritos();
            objEDistrito.Sub_Filtro = Departamento_Id + Provincia_Id;
            cboDistrito.DataSource = Log_Distritos.Lista_Distritos(objEDistrito);
            cboDistrito.DataTextField = "Descripcion";
            cboDistrito.DataValueField = "Codigo";
            cboDistrito.DataBind();
            cboDistrito.Items.Insert(0, new ListItem("--Seleccione--"));
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Ccosto(txtCcostoBuscar.Text);
        }

        void Lista_Ccosto(String no_Ccosto)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objECcosto = new Ent_Ccosto();
                if (no_Ccosto.Trim() != String.Empty)
                    objECcosto.Descripcion = no_Ccosto;
                DataTable dtCcosto = new DataTable();
                dtCcosto = Log_Ccosto.Lista_Ccosto(objECcosto);
                Utils.fc_Adecua_GridView(grvCcosto, dtCcosto.Rows.Count);
                grvCcosto.DataSource = dtCcosto;
                grvCcosto.DataBind();
                dtCcosto.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvCcosto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvCcosto.PageIndex = e.NewPageIndex;
            Lista_Ccosto(txtCcostoBuscar.Text);
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            LimpiarCajasTexto();
            TabContainer1.ActiveTabIndex = 1;
            txtDescripcion.Focus();
            lblCcosto_Id.Visible = false;
            txtCcosto_Id.Visible = true;
            btnActualizar.Visible = false;
            btnGrabar.Visible = true;
        }

        void LimpiarCajasTexto()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            lblCcosto_Id.Text = String.Empty;
            txtCcosto_Id.Text = String.Empty;
            txtDescripcion.Text = String.Empty;
            cboDistrito.Items.Clear();
            cboProvincia.Items.Clear();
            cboDepartamento.SelectedIndex = 0;
            txtCodigo_Auxiliar.Text = String.Empty;
        }

        protected void grvCcosto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.CommandName == "Select")
            {
                try
                {
                    string Ccosto_Id;
                    string no_Ccosto;
                    string departamento_Id;
                    string provincia_Id;
                    string distrito_Id;
                    string codigo_Auxiliar;

                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;

                    Ccosto_Id = grvCcosto.DataKeys[row.RowIndex].Values["Ccosto_Id"].ToString();
                    no_Ccosto = grvCcosto.DataKeys[row.RowIndex].Values["no_Ccosto"].ToString();
                    departamento_Id = grvCcosto.DataKeys[row.RowIndex].Values["dpto"].ToString();
                    provincia_Id = grvCcosto.DataKeys[row.RowIndex].Values["prov"].ToString();
                    distrito_Id = grvCcosto.DataKeys[row.RowIndex].Values["dist"].ToString();
                    codigo_Auxiliar = grvCcosto.DataKeys[row.RowIndex].Values["Codigo_Auxiliar"].ToString();
                    LimpiarCajasTexto();

                    lblCcosto_Id.Text = Ccosto_Id;
                    txtCcosto_Id.Text = Ccosto_Id;
                    txtDescripcion.Text = no_Ccosto;
                    /*Carga Departamento*/
                    if (departamento_Id != String.Empty)
                    {
                        cboDepartamento.SelectedValue = departamento_Id;

                        /*Carga Provincia*/
                        if (cboDepartamento.SelectedIndex != 0 && provincia_Id != String.Empty)
                        {
                            Carga_Provincias(departamento_Id);
                            cboProvincia.SelectedValue = provincia_Id;

                            /*Carga Distrito*/
                            if (cboDepartamento.SelectedIndex != 0 && cboProvincia.SelectedIndex != 0 && distrito_Id != String.Empty)
                            {
                                Carga_Distritos(departamento_Id, provincia_Id);
                                cboDistrito.SelectedValue = distrito_Id;
                            }
                            else
                            {
                                Carga_Distritos(departamento_Id, provincia_Id);
                                cboDistrito.SelectedIndex = 0;
                            }
                        }
                        else
                        {
                            Carga_Provincias(departamento_Id);
                            cboProvincia.SelectedIndex = 0;
                        }
                    }
                    else
                        cboDepartamento.SelectedIndex = 0;

                    txtCodigo_Auxiliar.Text = codigo_Auxiliar;
                    lblCcosto_Id.Visible = true;
                    txtCcosto_Id.Visible = false;
                    btnGrabar.Visible = false;
                    btnActualizar.Visible = true;
                    TabContainer1.ActiveTabIndex = 1;
                    txtDescripcion.Focus();
                }
                catch (Exception ex)
                {
                    Utils.fc_DisplayAlert(this, ex.Message);
                }
            }
        }
        protected void grvCcosto_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Ccosto_Id;
                Ccosto_Id = grvCcosto.DataKeys[e.RowIndex].Values["Ccosto_Id"].ToString();
                objECcosto = new Ent_Ccosto();
                objECcosto.Ccosto_Id = Ccosto_Id;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Ccosto.Elimina_Ccosto(objECcosto);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    LimpiarCajasTexto();
                    Lista_Ccosto(txtCcostoBuscar.Text);
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objECcosto = new Ent_Ccosto();
                objECcosto.Ccosto_Id = txtCcosto_Id.Text.Trim();
                objECcosto.Descripcion = txtDescripcion.Text.ToUpper();
                objECcosto.Estado_Id = "01"; /*Por defecto Activo*/
                objECcosto.Dpto = cboDepartamento.SelectedValue;
                objECcosto.Prov = cboProvincia.SelectedValue;
                objECcosto.Dist = cboDistrito.SelectedValue;
                objECcosto.Codigo_Auxiliar = txtCodigo_Auxiliar.Text;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Ccosto.Inserta_Ccosto(objECcosto);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    lblCcosto_Id.Text = txtCcosto_Id.Text;
                    Lista_Ccosto(txtCcostoBuscar.Text);
                    txtCcosto_Id.Visible = false;
                    lblCcosto_Id.Visible = true;
                    btnGrabar.Visible = false;
                    btnActualizar.Visible = true;
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (lblCcosto_Id.Text.Trim() == String.Empty)
            {
                Utils.fc_DisplayAlert(this, "Elegir Un Centro de Costo.");
                return;
            }
            try
            {
                objECcosto = new Ent_Ccosto();
                objECcosto.Ccosto_Id = lblCcosto_Id.Text;
                objECcosto.Descripcion = txtDescripcion.Text.ToUpper();
                objECcosto.Estado_Id = "01"; /*Por defecto Activo*/
                objECcosto.Dpto = cboDepartamento.SelectedValue;
                objECcosto.Prov = cboProvincia.SelectedValue;
                objECcosto.Dist = cboDistrito.SelectedValue;
                objECcosto.Codigo_Auxiliar = txtCodigo_Auxiliar.Text;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Ccosto.Actualiza_Ccosto(objECcosto);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_Ccosto(txtCcostoBuscar.Text);
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }


        protected void cboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                if (cboDepartamento.SelectedIndex != 0)
                    Carga_Provincias(cboDepartamento.SelectedValue);
                else
                    cboProvincia.Items.Clear();
                cboDistrito.Items.Clear();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                if (cboProvincia.SelectedIndex != 0)
                    Carga_Distritos(cboDepartamento.SelectedValue, cboProvincia.SelectedValue);
                else
                    cboDistrito.Items.Clear();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

    }
}