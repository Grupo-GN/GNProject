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
    public partial class FrmMntCompania_Externa_Establecimientos : System.Web.UI.Page
    {
        Ent_Provincias objEProvincia;
        Ent_Distritos objEDistrito;
        Ent_Compania_Externa_Establecimientos objECompania_Externa_Establecimientos;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                txtTasa.Attributes.Add("OnKeyPress", "return SoloDecimales(event)");
                Carga_Compania_Externa();
                Lista_Compania_Externa_Establecimientos(txtEstablecimientoBuscar.Text);
                btnActualizar.Visible = false;
            }
        }

        void Carga_Compania_Externa()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Ent_Compania_Externa objECompania_Externa = new Ent_Compania_Externa();
            cboCompania_Externa.DataSource = Log_Compania_Externa.Lista_Compania_Externa(objECompania_Externa);
            cboCompania_Externa.DataTextField = "Razon_Social";
            cboCompania_Externa.DataValueField = "Compania_Externa_Id";
            cboCompania_Externa.DataBind();
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Compania_Externa_Establecimientos(txtEstablecimientoBuscar.Text);
        }

        void Lista_Compania_Externa_Establecimientos(String no_Establecimiento_externo)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objECompania_Externa_Establecimientos = new Ent_Compania_Externa_Establecimientos();
                if (no_Establecimiento_externo.Trim() != String.Empty)
                    objECompania_Externa_Establecimientos.Descripcion = no_Establecimiento_externo;
                DataTable dtCompania_Externa_Establecimientos = new DataTable();
                dtCompania_Externa_Establecimientos = Log_Compania_Externa_Establecimientos.Lista_Compania_Externa_Establecimientos(objECompania_Externa_Establecimientos);
                Utils.fc_Adecua_GridView(grvCompania_Externa_Establecimientos, dtCompania_Externa_Establecimientos.Rows.Count);
                grvCompania_Externa_Establecimientos.DataSource = dtCompania_Externa_Establecimientos;
                grvCompania_Externa_Establecimientos.DataBind();
                dtCompania_Externa_Establecimientos.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvCompania_Externa_Establecimientos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvCompania_Externa_Establecimientos.PageIndex = e.NewPageIndex;
            Lista_Compania_Externa_Establecimientos(txtEstablecimientoBuscar.Text);
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
            lblCia_Ext_Establec_Id.Text = String.Empty;
            cboCompania_Externa.SelectedIndex = 0;
            txtDescripcion.Text = String.Empty;
            ckCentroRiesgo.Checked = false;
            txtCodigo_Auxiliar.Text = String.Empty;
            txtTasa.Text = String.Empty;
        }

        protected void grvCompania_Externa_Establecimientos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.CommandName == "Select")
            {
                try
                {
                    string Cia_Ext_Establec_Id;
                    string Compania_Externa_Id;
                    string Descripcion;
                    Boolean fl_centroRiesgo;
                    string codigo_Establecimiento;
                    Decimal tasa;

                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    Cia_Ext_Establec_Id = grvCompania_Externa_Establecimientos.DataKeys[row.RowIndex].Values["Cia_Ext_Establec_Id"].ToString();
                    Compania_Externa_Id = grvCompania_Externa_Establecimientos.DataKeys[row.RowIndex].Values["Compania_Externa_Id"].ToString();
                    Descripcion = grvCompania_Externa_Establecimientos.DataKeys[row.RowIndex].Values["Descripcion"].ToString();
                    fl_centroRiesgo = Convert.ToBoolean(grvCompania_Externa_Establecimientos.DataKeys[row.RowIndex].Values["CentroRiesgo"]);
                    codigo_Establecimiento = grvCompania_Externa_Establecimientos.DataKeys[row.RowIndex].Values["Codigo_Establecimiento"].ToString();
                    tasa = Convert.ToDecimal(grvCompania_Externa_Establecimientos.DataKeys[row.RowIndex].Values["Tasa"]);
                    LimpiarCajasTexto();

                    lblCia_Ext_Establec_Id.Text = Cia_Ext_Establec_Id;
                    cboCompania_Externa.SelectedValue = Compania_Externa_Id;
                    txtDescripcion.Text = Descripcion;
                    ckCentroRiesgo.Checked = fl_centroRiesgo;
                    txtCodigo_Auxiliar.Text = codigo_Establecimiento;
                    txtTasa.Text = tasa.ToString();

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
        protected void grvCompania_Externa_Establecimientos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Cia_Ext_Establec_Id;
                Cia_Ext_Establec_Id = grvCompania_Externa_Establecimientos.DataKeys[e.RowIndex].Values["Cia_Ext_Establec_Id"].ToString();
                objECompania_Externa_Establecimientos = new Ent_Compania_Externa_Establecimientos();
                objECompania_Externa_Establecimientos.Cia_Ext_Establec_Id = Cia_Ext_Establec_Id;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Compania_Externa_Establecimientos.Elimina_Compania_Externa_Establecimientos(objECompania_Externa_Establecimientos);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    LimpiarCajasTexto();
                    Lista_Compania_Externa_Establecimientos(txtEstablecimientoBuscar.Text);
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
                objECompania_Externa_Establecimientos = new Ent_Compania_Externa_Establecimientos();
                objECompania_Externa_Establecimientos.Compania_Externa_Id = cboCompania_Externa.SelectedValue;
                objECompania_Externa_Establecimientos.Descripcion = txtDescripcion.Text.ToUpper();
                objECompania_Externa_Establecimientos.CentroRiesgo = ckCentroRiesgo.Checked;
                objECompania_Externa_Establecimientos.Codigo_Establecimiento = txtCodigo_Auxiliar.Text;
                objECompania_Externa_Establecimientos.Tasa = Convert.ToDecimal(txtTasa.Text);

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Compania_Externa_Establecimientos.Inserta_Compania_Externa_Establecimientos(objECompania_Externa_Establecimientos);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    lblCia_Ext_Establec_Id.Text = dtRpta.Rows[0][2].ToString();
                    Lista_Compania_Externa_Establecimientos(txtEstablecimientoBuscar.Text);
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
            if (lblCia_Ext_Establec_Id.Text.Trim() == String.Empty)
            {
                Utils.fc_DisplayAlert(this, "Elegir Un Establecimiento.");
                return;
            }
            try
            {
                objECompania_Externa_Establecimientos = new Ent_Compania_Externa_Establecimientos();
                objECompania_Externa_Establecimientos.Cia_Ext_Establec_Id = lblCia_Ext_Establec_Id.Text;
                objECompania_Externa_Establecimientos.Compania_Externa_Id = cboCompania_Externa.SelectedValue;
                objECompania_Externa_Establecimientos.Descripcion = txtDescripcion.Text.ToUpper();
                objECompania_Externa_Establecimientos.CentroRiesgo = ckCentroRiesgo.Checked;
                objECompania_Externa_Establecimientos.Codigo_Establecimiento = txtCodigo_Auxiliar.Text;
                objECompania_Externa_Establecimientos.Tasa = Convert.ToDecimal(txtTasa.Text);

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Compania_Externa_Establecimientos.Actualiza_Compania_Externa_Establecimientos(objECompania_Externa_Establecimientos);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_Compania_Externa_Establecimientos(txtEstablecimientoBuscar.Text);
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