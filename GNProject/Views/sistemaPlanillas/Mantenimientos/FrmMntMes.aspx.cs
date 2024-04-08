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
    public partial class FrmMntMes : BasePage
    {
        Ent_Mes objEMes;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                txtNroMes.Attributes.Add("OnKeyPress", "return SoloNumeros(event)");
                txtCant_Semanas.Attributes.Add("OnKeyPress", "return SoloNumeros(event)");
                Carga_Ejercicio();
                Lista_Mes(txtDescripcionBuscar.Text);
                btnActualizar.Visible = false;
                cboEjercicio.SelectedValue = Utils.fc_obtiene_Ejercicio_Id(this);
            }
            HighlightGridLine();
        }

        void Carga_Ejercicio()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Ent_Ejercicio objEEjercicio = new Ent_Ejercicio();
            cboEjercicio.DataSource = Log_Ejercicio.Lista_Ejercicio(objEEjercicio);
            cboEjercicio.DataTextField = "Descripcion";
            cboEjercicio.DataValueField = "Ejercicio_Id";
            cboEjercicio.DataBind();
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Mes(txtDescripcionBuscar.Text);
        }

        void Lista_Mes(String no_Mes)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objEMes = new Ent_Mes();
                if (no_Mes.Trim() != String.Empty)
                    objEMes.Descripcion = no_Mes;
                objEMes.Ejercicio_Id = Utils.fc_obtiene_Ejercicio_Id(this);
                DataTable dtMes = new DataTable();
                dtMes = Log_Mes.Lista_Mes(objEMes);
                Utils.fc_Adecua_GridView(grvMes, dtMes.Rows.Count);
                grvMes.DataSource = dtMes;
                grvMes.DataBind();
                dtMes.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvMes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvMes.PageIndex = e.NewPageIndex;
            Lista_Mes(txtDescripcionBuscar.Text);
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            LimpiarCajasTexto();
            TabContainer1.ActiveTabIndex = 1;
            cboEjercicio.SelectedValue = Utils.fc_obtiene_Ejercicio_Id(this);
            txtDescripcion.Focus();
            btnActualizar.Visible = false;
            btnGrabar.Visible = true;
        }

        void LimpiarCajasTexto()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            lblMes_Id.Text = String.Empty;
            cboEjercicio.SelectedValue = Utils.fc_obtiene_Ejercicio_Id(this);
            txtDescripcion.Text = String.Empty;
            txtNroMes.Text = String.Empty;
            txtCant_Semanas.Text = String.Empty;
        }

        protected void grvMes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.CommandName == "Select")
            {
                try
                {
                    string Mes_Id;
                    string descripcion;
                    string ejercicio_Id;
                    Int32 nMes;
                    Int32 nSemanas;

                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    Mes_Id = grvMes.DataKeys[row.RowIndex].Values["Mes_Id"].ToString();
                    descripcion = grvMes.DataKeys[row.RowIndex].Values["Descripcion"].ToString();
                    ejercicio_Id = grvMes.DataKeys[row.RowIndex].Values["Ejercicio_Id"].ToString();
                    nMes = Convert.ToInt32(grvMes.DataKeys[row.RowIndex].Values["nMes"].ToString());
                    nSemanas = Convert.ToInt32(grvMes.DataKeys[row.RowIndex].Values["nSemanas"].ToString());
                    LimpiarCajasTexto();
                    lblMes_Id.Text = Mes_Id;
                    txtDescripcion.Text = descripcion;
                    cboEjercicio.SelectedValue = ejercicio_Id;
                    txtNroMes.Text = nMes.ToString();
                    txtCant_Semanas.Text = nSemanas.ToString();

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
        protected void grvMes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Mes_Id;
                Mes_Id = grvMes.DataKeys[e.RowIndex].Values["Mes_Id"].ToString();
                objEMes = new Ent_Mes();
                objEMes.Mes_Id = Mes_Id;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Mes.Elimina_Mes(objEMes);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    LimpiarCajasTexto();
                    Lista_Mes(txtDescripcionBuscar.Text);

                    btnActualizar.Visible = false;
                    btnGrabar.Visible = true;
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
                objEMes = new Ent_Mes();
                objEMes.Descripcion = txtDescripcion.Text.ToUpper();
                objEMes.Ejercicio_Id = cboEjercicio.SelectedValue;
                objEMes.NMes = Convert.ToInt32(txtNroMes.Text);
                objEMes.NSemanas = Convert.ToInt32(txtCant_Semanas.Text);

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Mes.Inserta_Mes(objEMes);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    lblMes_Id.Text = dtRpta.Rows[0][2].ToString();
                    Lista_Mes(txtDescripcionBuscar.Text);

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
            if (lblMes_Id.Text.Trim() == String.Empty)
            {
                Utils.fc_DisplayAlert(this, "Elegir Un Mes.");
                return;
            }
            try
            {
                objEMes = new Ent_Mes();
                objEMes.Mes_Id = lblMes_Id.Text;
                objEMes.Descripcion = txtDescripcion.Text.ToUpper();
                objEMes.Ejercicio_Id = cboEjercicio.SelectedValue;
                objEMes.NMes = Convert.ToInt32(txtNroMes.Text);
                objEMes.NSemanas = Convert.ToInt32(txtCant_Semanas.Text);

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Mes.Actualiza_Mes(objEMes);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_Mes(txtDescripcionBuscar.Text);
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void btnCrearMeses_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objEMes = new Ent_Mes();
                objEMes.Ejercicio_Id = Utils.fc_obtiene_Ejercicio_Id(this);
                DataTable dtRpta = new DataTable();
                dtRpta = Log_Mes.Inserta_Mes_Masivo(objEMes);
                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_Mes(txtDescripcionBuscar.Text);
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);

            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void grvMes_RowDataBound(object sender, GridViewRowEventArgs e)
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