using CAPA_ENTIDAD;
using CAPA_LOGICO;
using GNProject.Views.sistemaPlanillas.code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.Mantenimientos
{
    public partial class FrmMntPlanilla : BasePage
    {
        Ent_Planilla objEPlanilla;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                Carga_Compania();
                Carga_Periodicidad();
                Carga_Estados();
                cboCompania.SelectedValue = Utils.fc_obtiene_Compania_Id(this);
                Carga_Planilla_Master(cboCompania.SelectedValue);
                Lista_Planilla(txtPlanillaBuscar.Text);
                btnActualizar.Visible = false;
            }
            HighlightGridLine();
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
        void Carga_Periodicidad()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            cboPeriodicidad.DataSource = Log_Periodicidad.Lista_Periodicidad();
            cboPeriodicidad.DataTextField = "Descripcion";
            cboPeriodicidad.DataValueField = "Periodicidad_Id";
            cboPeriodicidad.DataBind();
        }
        void Carga_Estados()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            cboEstado.DataSource = Log_General.Lista_Estados();
            cboEstado.DataTextField = "Descripcion";
            cboEstado.DataValueField = "Codigo";
            cboEstado.DataBind();
        }
        void Carga_Planilla_Master(String compania_Id)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            objEPlanilla = new Ent_Planilla();
            objEPlanilla.Compania_Id = compania_Id;
            cboPlanilla_Master.DataSource = Log_Planilla.Lista_Planilla(objEPlanilla);
            cboPlanilla_Master.DataTextField = "Descripcion";
            cboPlanilla_Master.DataValueField = "Planilla_Id";
            cboPlanilla_Master.DataBind();
            cboPlanilla_Master.Items.Insert(0, new ListItem("--Ninguno--"));
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Planilla(txtPlanillaBuscar.Text);
        }

        void Lista_Planilla(String no_Planilla)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objEPlanilla = new Ent_Planilla();
                if (no_Planilla.Trim() != String.Empty)
                    objEPlanilla.Descripcion = no_Planilla;
                DataTable dtPlanilla = new DataTable();
                dtPlanilla = Log_Planilla.Lista_Planilla(objEPlanilla);
                Utils.fc_Adecua_GridView(grvPlanilla, dtPlanilla.Rows.Count);
                grvPlanilla.DataSource = dtPlanilla;
                grvPlanilla.DataBind();
                dtPlanilla.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvPlanilla_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvPlanilla.PageIndex = e.NewPageIndex;
            Lista_Planilla(txtPlanillaBuscar.Text);
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
            lblPlanilla_Id.Text = String.Empty;
            cboCompania.SelectedValue = Utils.fc_obtiene_Compania_Id(this);
            txtDescripcion.Text = String.Empty;
            cboPeriodicidad.SelectedIndex = 0;
            cboEstado.SelectedIndex = 0;
            cboPlanilla_Master.SelectedIndex = 0;
        }

        protected void grvPlanilla_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.CommandName == "Select")
            {
                try
                {
                    string planilla_Id;

                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    planilla_Id = grvPlanilla.DataKeys[row.RowIndex].Values["Planilla_Id"].ToString();

                    DataTable dtPlanilla = new DataTable();
                    objEPlanilla = new Ent_Planilla();
                    objEPlanilla.Planilla_Id = planilla_Id;
                    dtPlanilla = Log_Planilla.Lista_Planilla(objEPlanilla);

                    LimpiarCajasTexto();

                    lblPlanilla_Id.Text = planilla_Id;
                    txtDescripcion.Text = dtPlanilla.Rows[0]["Descripcion"].ToString();
                    cboCompania.SelectedValue = dtPlanilla.Rows[0]["Compania_Id"].ToString();
                    cboPeriodicidad.SelectedValue = dtPlanilla.Rows[0]["Periodicidad_Id"].ToString();
                    cboEstado.SelectedValue = dtPlanilla.Rows[0]["Estado_Id"].ToString();

                    Carga_Planilla_Master(dtPlanilla.Rows[0]["Compania_Id"].ToString());
                    string Planilla_Master_Id = dtPlanilla.Rows[0]["Planilla_Master_Id"].ToString();
                    if (Planilla_Master_Id.Trim() != String.Empty)
                        cboPlanilla_Master.SelectedValue = Planilla_Master_Id;
                    else
                        cboPlanilla_Master.SelectedIndex = 0;

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
        protected void grvPlanilla_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Planilla_Id;
                Planilla_Id = grvPlanilla.DataKeys[e.RowIndex].Values["Planilla_Id"].ToString();
                objEPlanilla = new Ent_Planilla();
                objEPlanilla.Planilla_Id = Planilla_Id;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Planilla.Elimina_Planilla(objEPlanilla);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    LimpiarCajasTexto();
                    Lista_Planilla(txtPlanillaBuscar.Text);
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
                objEPlanilla = new Ent_Planilla();
                objEPlanilla.Descripcion = txtDescripcion.Text.ToUpper();
                objEPlanilla.Compania_Id = cboCompania.SelectedValue;
                objEPlanilla.Periodicidad_Id = cboPeriodicidad.SelectedValue;
                objEPlanilla.Estado_Id = cboEstado.SelectedValue;
                string Planilla_Master_Id = cboPlanilla_Master.SelectedValue;
                if (Planilla_Master_Id == "--Ninguno--")
                    objEPlanilla.Planilla_Master_Id = "";
                else
                    objEPlanilla.Planilla_Master_Id = cboPlanilla_Master.SelectedValue;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Planilla.Inserta_Planilla(objEPlanilla);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    lblPlanilla_Id.Text = dtRpta.Rows[0][2].ToString();
                    Lista_Planilla(txtPlanillaBuscar.Text);
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
            if (lblPlanilla_Id.Text.Trim() == String.Empty)
            {
                Utils.fc_DisplayAlert(this, "Elegir Un Planilla.");
                return;
            }
            try
            {
                string Planilla_Id;
                Planilla_Id = lblPlanilla_Id.Text;
                objEPlanilla = new Ent_Planilla();
                objEPlanilla.Planilla_Id = Planilla_Id;
                objEPlanilla.Descripcion = txtDescripcion.Text.ToUpper();
                objEPlanilla.Compania_Id = cboCompania.SelectedValue;
                objEPlanilla.Periodicidad_Id = cboPeriodicidad.SelectedValue;
                objEPlanilla.Estado_Id = cboEstado.SelectedValue;
                string Planilla_Master_Id = cboPlanilla_Master.SelectedValue;
                if (Planilla_Master_Id == "--Ninguno--")
                    objEPlanilla.Planilla_Master_Id = "";
                else
                    objEPlanilla.Planilla_Master_Id = cboPlanilla_Master.SelectedValue;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Planilla.Actualiza_Planilla(objEPlanilla);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_Planilla(txtPlanillaBuscar.Text);
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void cboCompania_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Carga_Planilla_Master(cboCompania.SelectedValue);
        }

        protected void grvPlanilla_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            }
        }
    }
}