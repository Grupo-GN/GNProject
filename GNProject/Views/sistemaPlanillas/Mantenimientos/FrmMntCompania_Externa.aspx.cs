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
    public partial class FrmMntCompania_Externa : System.Web.UI.Page
    {
        Ent_Compania_Externa objECompania_Externa;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                Carga_CIUU();
                Lista_Compania_Externa(txtRazonSocialBuscar.Text);

                btnActualizar.Visible = false;
            }
        }

        void Carga_CIUU()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            cboCIIU.DataSource = Log_CIIU.Lista_CIIU();
            cboCIIU.DataTextField = "Descripcion";
            cboCIIU.DataValueField = "CIIU_Id";
            cboCIIU.DataBind();
        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Compania_Externa(txtRazonSocialBuscar.Text);
        }

        void Lista_Compania_Externa(String no_Razon_Social)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objECompania_Externa = new Ent_Compania_Externa();
                if (no_Razon_Social.Trim() != String.Empty)
                    objECompania_Externa.Razon_Social = no_Razon_Social;
                DataTable dtCompania_Externa = new DataTable();
                dtCompania_Externa = Log_Compania_Externa.Lista_Compania_Externa(objECompania_Externa);
                Utils.fc_Adecua_GridView(grvCompania_Externa, dtCompania_Externa.Rows.Count);
                grvCompania_Externa.DataSource = dtCompania_Externa;
                grvCompania_Externa.DataBind();
                dtCompania_Externa.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvCompania_Externa_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvCompania_Externa.PageIndex = e.NewPageIndex;
            Lista_Compania_Externa(txtRazonSocialBuscar.Text);
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            LimpiarCajasTexto();
            TabContainer1.ActiveTabIndex = 1;
            txtRazon_Social.Focus();
            btnActualizar.Visible = false;
            btnGrabar.Visible = true;
        }

        void LimpiarCajasTexto()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            lblCompania_Externa_Id.Text = String.Empty;
            txtRazon_Social.Text = String.Empty;
            txtRUC.Text = String.Empty;
            cboCIIU.SelectedIndex = 0;
            ckCompaniaEnvia.Checked = false;
            ckCompaniaRecibe.Checked = false;
        }

        protected void grvCompania_Externa_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.CommandName == "Select")
            {
                try
                {
                    string Compania_Externa_Id;

                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    Compania_Externa_Id = grvCompania_Externa.DataKeys[row.RowIndex].Values["Compania_Externa_Id"].ToString();

                    LimpiarCajasTexto();

                    lblCompania_Externa_Id.Text = Compania_Externa_Id;

                    objECompania_Externa = new Ent_Compania_Externa();
                    objECompania_Externa.Compania_Externa_Id = Compania_Externa_Id;
                    DataTable dtCompania_Externa = new DataTable();
                    dtCompania_Externa = Log_Compania_Externa.Lista_Compania_Externa(objECompania_Externa);

                    txtRazon_Social.Text = dtCompania_Externa.Rows[0]["Razon_Social"].ToString();
                    txtRUC.Text = dtCompania_Externa.Rows[0]["RUC"].ToString();
                    cboCIIU.SelectedValue = dtCompania_Externa.Rows[0]["CIIU_Id"].ToString();
                    ckCompaniaEnvia.Checked = Convert.ToBoolean(dtCompania_Externa.Rows[0]["Destaque_Envio"]);
                    ckCompaniaRecibe.Checked = Convert.ToBoolean(dtCompania_Externa.Rows[0]["Destaque_Recibo"]);

                    btnGrabar.Visible = false;
                    btnActualizar.Visible = true;
                    TabContainer1.ActiveTabIndex = 1;
                    txtRazon_Social.Focus();
                }
                catch (Exception ex)
                {
                    Utils.fc_DisplayAlert(this, ex.Message);
                }
            }
        }
        protected void grvCompania_Externa_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Compania_Externa_Id;
                Compania_Externa_Id = grvCompania_Externa.DataKeys[e.RowIndex].Values["Compania_Externa_Id"].ToString();
                objECompania_Externa = new Ent_Compania_Externa();
                objECompania_Externa.Compania_Externa_Id = Compania_Externa_Id;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Compania_Externa.Elimina_Compania_Externa(objECompania_Externa);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    LimpiarCajasTexto();
                    btnActualizar.Visible = false;
                    Lista_Compania_Externa(txtRazonSocialBuscar.Text);
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
                objECompania_Externa = new Ent_Compania_Externa();
                objECompania_Externa.Razon_Social = txtRazon_Social.Text.ToUpper();
                objECompania_Externa.RUC = txtRUC.Text;
                objECompania_Externa.CIIU_Id = cboCIIU.SelectedValue;
                objECompania_Externa.Destaque_Envio = ckCompaniaEnvia.Checked;
                objECompania_Externa.Destaque_Recibo = ckCompaniaRecibe.Checked;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Compania_Externa.Inserta_Compania_Externa(objECompania_Externa);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    lblCompania_Externa_Id.Text = dtRpta.Rows[0][2].ToString();
                    Lista_Compania_Externa(txtRazonSocialBuscar.Text);
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
            if (lblCompania_Externa_Id.Text.Trim() == String.Empty)
            {
                Utils.fc_DisplayAlert(this, "Seleccionar Una Compañia Externa.");
                TabContainer1.ActiveTabIndex = 0;
                return;
            }
            try
            {
                objECompania_Externa = new Ent_Compania_Externa();
                objECompania_Externa.Compania_Externa_Id = lblCompania_Externa_Id.Text;
                objECompania_Externa.Razon_Social = txtRazon_Social.Text.ToUpper();
                objECompania_Externa.RUC = txtRUC.Text;
                objECompania_Externa.CIIU_Id = cboCIIU.SelectedValue;
                objECompania_Externa.Destaque_Envio = ckCompaniaEnvia.Checked;
                objECompania_Externa.Destaque_Recibo = ckCompaniaRecibe.Checked;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Compania_Externa.Actualiza_Compania_Externa(objECompania_Externa);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_Compania_Externa(txtRazonSocialBuscar.Text);
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