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
    public partial class FrmMntCargo : System.Web.UI.Page
    {
        Ent_Ocupacion objEOcupacion;
        Ent_Cargo objECargo;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                Carga_Ocupacion();
                Lista_Cargo(txtCargoBuscar.Text);
                btnActualizar.Visible = false;
            }
        }

        void Carga_Ocupacion()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            objEOcupacion = new Ent_Ocupacion();
            cboOcupacion.DataSource = Log_Ocupacion.Lista_Ocupacion(objEOcupacion);
            cboOcupacion.DataTextField = "Descripcion";
            cboOcupacion.DataValueField = "Ocupacion_Id";
            cboOcupacion.DataBind();
        }
        protected void btnListar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Cargo(txtCargoBuscar.Text);
        }

        void Lista_Cargo(String no_Cargo)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objECargo = new Ent_Cargo();
                if (no_Cargo.Trim() != String.Empty)
                    objECargo.Descripcion = no_Cargo;
                DataTable dtCargo = new DataTable();
                dtCargo = Log_Cargo.Lista_Cargo(objECargo);
                Utils.fc_Adecua_GridView(grvCargo, dtCargo.Rows.Count);
                grvCargo.DataSource = dtCargo;
                grvCargo.DataBind();
                dtCargo.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvCargo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvCargo.PageIndex = e.NewPageIndex;
            Lista_Cargo(txtCargoBuscar.Text);
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            LimpiarCajasTexto();
            TabContainer1.ActiveTabIndex = 1;
            txtDescripcion.Focus();
            btnActualizar.Visible = false;
            btnGrabar.Visible = true;
        }

        void LimpiarCajasTexto()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            lblCargo_Id.Text = String.Empty;
            txtDescripcion.Text = String.Empty;
            cboOcupacion.SelectedIndex = 0;
            ckTareaje.Checked = false;
            ckConfianza.Checked = false;
        }

        protected void grvCargo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.CommandName == "Select")
            {
                try
                {
                    string cargo_Id;
                    string no_Cargo;
                    string ocupacion_Id;
                    Boolean fl_Tareaje;
                    Boolean fl_Confianza;

                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    cargo_Id = grvCargo.DataKeys[row.RowIndex].Values["Cargo_Id"].ToString();
                    no_Cargo = grvCargo.DataKeys[row.RowIndex].Values["no_Cargo"].ToString();
                    ocupacion_Id = grvCargo.DataKeys[row.RowIndex].Values["Ocupacion_Id"].ToString();
                    fl_Tareaje = Convert.ToBoolean(grvCargo.DataKeys[row.RowIndex].Values["Flag_Tareaje"]);
                    fl_Confianza = Convert.ToBoolean(grvCargo.DataKeys[row.RowIndex].Values["Flag_Confianza"]);
                    LimpiarCajasTexto();
                    lblCargo_Id.Text = cargo_Id;
                    txtDescripcion.Text = no_Cargo;
                    cboOcupacion.SelectedValue = ocupacion_Id;
                    ckTareaje.Checked = fl_Tareaje;
                    ckConfianza.Checked = fl_Confianza;
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
        protected void grvCargo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Cargo_Id;
                Cargo_Id = grvCargo.DataKeys[e.RowIndex].Values["Cargo_Id"].ToString();
                objECargo = new Ent_Cargo();
                objECargo.Cargo_Id = Cargo_Id;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Cargo.Elimina_Cargo(objECargo);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    LimpiarCajasTexto();
                    Lista_Cargo(txtCargoBuscar.Text);
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
                objECargo = new Ent_Cargo();
                objECargo.Descripcion = txtDescripcion.Text.ToUpper();
                objECargo.Ocupacion_Id = cboOcupacion.SelectedValue;
                objECargo.Estado_Id = "01"; /*Por defecto Activo*/
                objECargo.Flag_Tareaje = ckTareaje.Checked;
                objECargo.Flag_Confianza = ckConfianza.Checked;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Cargo.Inserta_Cargo(objECargo);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    lblCargo_Id.Text = dtRpta.Rows[0][0].ToString();
                    Lista_Cargo(txtCargoBuscar.Text);
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
            if (lblCargo_Id.Text.Trim() == String.Empty)
            {
                Utils.fc_DisplayAlert(this, "Elegir Un Cargo.");
                return;
            }
            try
            {
                string Cargo_Id;
                Cargo_Id = lblCargo_Id.Text;
                objECargo = new Ent_Cargo();
                objECargo.Cargo_Id = Cargo_Id;
                objECargo.Descripcion = txtDescripcion.Text.ToUpper();
                objECargo.Ocupacion_Id = cboOcupacion.SelectedValue;
                objECargo.Estado_Id = "01"; /*Por defecto Activo*/
                objECargo.Flag_Tareaje = ckTareaje.Checked;
                objECargo.Flag_Confianza = ckConfianza.Checked;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Cargo.Actualiza_Cargo(objECargo);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_Cargo(txtCargoBuscar.Text);
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

    }
}