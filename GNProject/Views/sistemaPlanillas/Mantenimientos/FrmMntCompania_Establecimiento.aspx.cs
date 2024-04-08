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
    public partial class FrmMntCompania_Establecimiento : System.Web.UI.Page
    {
        Ent_Provincias objEProvincia;
        Ent_Distritos objEDistrito;
        Ent_Compania_Establecimiento objECompania_Establecimiento;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                txtTasa.Attributes.Add("OnKeyPress", "return SoloDecimales(event)");
                Carga_Compania();
                Carga_Tipo_Establecimiento();
                Carga_Estados();
                Lista_Compania_Establecimiento(txtEstablecimientoBuscar.Text);
                btnActualizar.Visible = false;
            }
        }

        void Carga_Compania()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Ent_Compania objECompania = new Ent_Compania();
            cboCompania.DataSource = Log_Compania.Lista_Compania(objECompania);
            cboCompania.DataTextField = "Descripcion";
            cboCompania.DataValueField = "Compania_Id";
            cboCompania.DataBind();
        }
        void Carga_Tipo_Establecimiento()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Ent_Tipo_Establecimiento objETip_Establecimiento = new Ent_Tipo_Establecimiento();
            cboTipo_Establecimiento.DataSource = Log_Tipo_Establecimiento.Lista_Tipo_Establecimiento(objETip_Establecimiento);
            cboTipo_Establecimiento.DataTextField = "Descripcion";
            cboTipo_Establecimiento.DataValueField = "Tipo_Establecimiento_Id";
            cboTipo_Establecimiento.DataBind();
        }
        void Carga_Estados()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            cboEstado.DataSource = Log_General.Lista_Estados();
            cboEstado.DataTextField = "Descripcion";
            cboEstado.DataValueField = "Codigo";
            cboEstado.DataBind();
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Compania_Establecimiento(txtEstablecimientoBuscar.Text);
        }

        void Lista_Compania_Establecimiento(String no_Establecimiento)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objECompania_Establecimiento = new Ent_Compania_Establecimiento();
                objECompania_Establecimiento.Compania_Id = Utils.fc_obtiene_Compania_Id(this);
                if (no_Establecimiento.Trim() != String.Empty)
                    objECompania_Establecimiento.Denominacion = no_Establecimiento;
                DataTable dtCompania_Establecimiento = new DataTable();
                dtCompania_Establecimiento = Log_Compania_Establecimiento.Lista_Compania_Establecimiento(objECompania_Establecimiento);
                Utils.fc_Adecua_GridView(grvCompania_Establecimiento, dtCompania_Establecimiento.Rows.Count);
                grvCompania_Establecimiento.DataSource = dtCompania_Establecimiento;
                grvCompania_Establecimiento.DataBind();
                dtCompania_Establecimiento.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvCompania_Establecimiento_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvCompania_Establecimiento.PageIndex = e.NewPageIndex;
            Lista_Compania_Establecimiento(txtEstablecimientoBuscar.Text);
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            LimpiarCajasTexto();
            TabContainer1.ActiveTabIndex = 1;
            txtCodigo_Establecimiento.Focus();
            btnActualizar.Visible = false;
            btnGrabar.Visible = true;
        }

        void LimpiarCajasTexto()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            lblEstablecimiento_Id.Text = String.Empty;
            cboCompania.SelectedValue = Utils.fc_obtiene_Compania_Id(this);
            cboTipo_Establecimiento.SelectedIndex = 0;
            txtCodigo_Establecimiento.Text = String.Empty;
            txtDenominacion.Text = String.Empty;
            ckCentroRiesgo.Checked = false;
            txtTasa.Text = String.Empty;
            cboEstado.SelectedIndex = 0;
        }

        protected void grvCompania_Establecimiento_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.CommandName == "Select")
            {
                try
                {
                    string establecimiento_Id;
                    string compania_Id;
                    string tipo_Establecimiento_Id;
                    string codigo_Establecimiento;
                    string no_Establecimiento;
                    Boolean fl_centroRiesgo;
                    Decimal tasa;
                    string estado_Id;

                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;

                    establecimiento_Id = grvCompania_Establecimiento.DataKeys[row.RowIndex].Values["Establecimiento_Id"].ToString();
                    compania_Id = grvCompania_Establecimiento.DataKeys[row.RowIndex].Values["Compania_Id"].ToString();
                    tipo_Establecimiento_Id = grvCompania_Establecimiento.DataKeys[row.RowIndex].Values["Tipo_Establecimiento_Id"].ToString();
                    codigo_Establecimiento = grvCompania_Establecimiento.DataKeys[row.RowIndex].Values["Codigo_Establecimiento"].ToString();
                    no_Establecimiento = grvCompania_Establecimiento.DataKeys[row.RowIndex].Values["Denominacion"].ToString();
                    fl_centroRiesgo = Convert.ToBoolean(grvCompania_Establecimiento.DataKeys[row.RowIndex].Values["CentroRiesgo"]);
                    tasa = Convert.ToDecimal(grvCompania_Establecimiento.DataKeys[row.RowIndex].Values["Tasa"]);
                    estado_Id = grvCompania_Establecimiento.DataKeys[row.RowIndex].Values["Estado_Id"].ToString();
                    LimpiarCajasTexto();

                    lblEstablecimiento_Id.Text = establecimiento_Id;
                    cboCompania.SelectedValue = compania_Id;
                    cboTipo_Establecimiento.SelectedValue = tipo_Establecimiento_Id;
                    txtCodigo_Establecimiento.Text = codigo_Establecimiento;
                    txtDenominacion.Text = no_Establecimiento;
                    ckCentroRiesgo.Checked = fl_centroRiesgo;
                    txtTasa.Text = tasa.ToString();
                    cboEstado.SelectedValue = estado_Id;

                    btnGrabar.Visible = false;
                    btnActualizar.Visible = true;
                    TabContainer1.ActiveTabIndex = 1;
                    txtCodigo_Establecimiento.Focus();
                }
                catch (Exception ex)
                {
                    Utils.fc_DisplayAlert(this, ex.Message);
                }
            }
        }
        protected void grvCompania_Establecimiento_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Compania_Establecimiento_Id;
                Compania_Establecimiento_Id = grvCompania_Establecimiento.DataKeys[e.RowIndex].Values["Establecimiento_Id"].ToString();
                objECompania_Establecimiento = new Ent_Compania_Establecimiento();
                objECompania_Establecimiento.Establecimiento_Id = Compania_Establecimiento_Id;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Compania_Establecimiento.Elimina_Compania_Establecimiento(objECompania_Establecimiento);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    LimpiarCajasTexto();
                    Lista_Compania_Establecimiento(txtEstablecimientoBuscar.Text);
                    btnActualizar.Visible = false;
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
                objECompania_Establecimiento = new Ent_Compania_Establecimiento();
                objECompania_Establecimiento.Compania_Id = cboCompania.SelectedValue;
                objECompania_Establecimiento.Tipo_Establecimiento_Id = cboTipo_Establecimiento.SelectedValue;
                objECompania_Establecimiento.Codigo_Establecimiento = txtCodigo_Establecimiento.Text;
                objECompania_Establecimiento.Denominacion = txtDenominacion.Text.ToUpper();
                objECompania_Establecimiento.CentroRiesgo = ckCentroRiesgo.Checked;
                objECompania_Establecimiento.Tasa = Convert.ToDecimal(txtTasa.Text);
                objECompania_Establecimiento.Estado_Id = cboEstado.SelectedValue;


                DataTable dtRpta = new DataTable();
                dtRpta = Log_Compania_Establecimiento.Inserta_Compania_Establecimiento(objECompania_Establecimiento);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    lblEstablecimiento_Id.Text = dtRpta.Rows[0][2].ToString();
                    Lista_Compania_Establecimiento(txtEstablecimientoBuscar.Text);
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
            if (lblEstablecimiento_Id.Text.Trim() == String.Empty)
            {
                Utils.fc_DisplayAlert(this, "Elegir Un Establecimiento.");
                return;
            }
            try
            {
                objECompania_Establecimiento = new Ent_Compania_Establecimiento();
                objECompania_Establecimiento.Establecimiento_Id = lblEstablecimiento_Id.Text;
                objECompania_Establecimiento.Compania_Id = cboCompania.SelectedValue;
                objECompania_Establecimiento.Tipo_Establecimiento_Id = cboTipo_Establecimiento.SelectedValue;
                objECompania_Establecimiento.Codigo_Establecimiento = txtCodigo_Establecimiento.Text;
                objECompania_Establecimiento.Denominacion = txtDenominacion.Text.ToUpper();
                objECompania_Establecimiento.CentroRiesgo = ckCentroRiesgo.Checked;
                objECompania_Establecimiento.Tasa = Convert.ToDecimal(txtTasa.Text);
                objECompania_Establecimiento.Estado_Id = cboEstado.SelectedValue;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Compania_Establecimiento.Actualiza_Compania_Establecimiento(objECompania_Establecimiento);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_Compania_Establecimiento(txtEstablecimientoBuscar.Text);
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