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
    public partial class FrmMntEjercicio : BasePage
    {
        Ent_Ejercicio objEEjercicio;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                txtAnio.Attributes.Add("OnKeyPress", "return SoloNumeros(event)");
                txtEjercicio_Id.Visible = false;
                Lista_Ejercicio(txtDescripcionBuscar.Text);
                btnActualizar.Visible = false;
            }
            HighlightGridLine();
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Ejercicio(txtDescripcionBuscar.Text);
        }

        void Lista_Ejercicio(String no_Ejercicio)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objEEjercicio = new Ent_Ejercicio();
                if (no_Ejercicio.Trim() != String.Empty)
                    objEEjercicio.Descripcion = no_Ejercicio;
                DataTable dtEjercicio = new DataTable();
                dtEjercicio = Log_Ejercicio.Lista_Ejercicio(objEEjercicio);
                Utils.fc_Adecua_GridView(grvEjercicio, dtEjercicio.Rows.Count);
                grvEjercicio.DataSource = dtEjercicio;
                grvEjercicio.DataBind();
                dtEjercicio.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvEjercicio_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvEjercicio.PageIndex = e.NewPageIndex;
            Lista_Ejercicio(txtDescripcionBuscar.Text);
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            LimpiarCajasTexto();
            TabContainer1.ActiveTabIndex = 1;
            txtEjercicio_Id.Visible = true;
            lblEjercicio_Id.Visible = false;
            txtEjercicio_Id.Focus();
            btnActualizar.Visible = false;
            btnGrabar.Visible = true;
        }

        void LimpiarCajasTexto()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            lblEjercicio_Id.Text = String.Empty;
            txtEjercicio_Id.Text = String.Empty;
            txtDescripcion.Text = String.Empty;
            txtAnio.Text = String.Empty;
        }

        protected void grvEjercicio_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.CommandName == "Select")
            {
                try
                {
                    string ejercicio_Id;
                    string descripcion;
                    string Anio;

                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    ejercicio_Id = grvEjercicio.DataKeys[row.RowIndex].Values["Ejercicio_Id"].ToString();
                    descripcion = grvEjercicio.DataKeys[row.RowIndex].Values["Descripcion"].ToString();
                    Anio = grvEjercicio.DataKeys[row.RowIndex].Values["Ano"].ToString();
                    LimpiarCajasTexto();
                    lblEjercicio_Id.Text = ejercicio_Id;
                    txtEjercicio_Id.Text = ejercicio_Id;
                    txtDescripcion.Text = descripcion;
                    txtAnio.Text = Anio;

                    txtEjercicio_Id.Visible = false;
                    lblEjercicio_Id.Visible = true;
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
        protected void grvEjercicio_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Ejercicio_Id;
                Ejercicio_Id = grvEjercicio.DataKeys[e.RowIndex].Values["Ejercicio_Id"].ToString();
                objEEjercicio = new Ent_Ejercicio();
                objEEjercicio.Ejercicio_Id = Ejercicio_Id;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Ejercicio.Elimina_Ejercicio(objEEjercicio);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    LimpiarCajasTexto();
                    Lista_Ejercicio(txtDescripcionBuscar.Text);
                    txtEjercicio_Id.Visible = true;
                    lblEjercicio_Id.Visible = false;
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
                objEEjercicio = new Ent_Ejercicio();
                objEEjercicio.Ejercicio_Id = txtEjercicio_Id.Text;
                objEEjercicio.Descripcion = txtDescripcion.Text.ToUpper();
                objEEjercicio.Ano = Convert.ToInt32(txtAnio.Text);
                objEEjercicio.Estado_Id = "01"; /*Por defecto Activo*/

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Ejercicio.Inserta_Ejercicio(objEEjercicio);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    txtEjercicio_Id.Text = dtRpta.Rows[0][2].ToString();
                    lblEjercicio_Id.Text = dtRpta.Rows[0][2].ToString();
                    Lista_Ejercicio(txtDescripcionBuscar.Text);
                    txtEjercicio_Id.Visible = false;
                    lblEjercicio_Id.Visible = true;
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
            if (txtEjercicio_Id.Text.Trim() == String.Empty)
            {
                Utils.fc_DisplayAlert(this, "Elegir Un Ejercicio.");
                return;
            }
            try
            {
                string Ejercicio_Id;
                Ejercicio_Id = txtEjercicio_Id.Text;
                objEEjercicio = new Ent_Ejercicio();
                objEEjercicio.Ejercicio_Id = txtEjercicio_Id.Text;
                objEEjercicio.Descripcion = txtDescripcion.Text.ToUpper();
                objEEjercicio.Ano = Convert.ToInt32(txtAnio.Text);
                objEEjercicio.Estado_Id = "01"; /*Por defecto Activo*/

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Ejercicio.Actualiza_Ejercicio(objEEjercicio);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_Ejercicio(txtDescripcionBuscar.Text);
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvEjercicio_RowDataBound(object sender, GridViewRowEventArgs e)
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