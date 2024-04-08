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
    public partial class FrmMntPeriodo : BasePage
    {
        Ent_Periodo objEPeriodo;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                txtNro_Semana.Attributes.Add("OnKeyPress", "return SoloNumeros(event)");
                txtTipo_Cambio.Attributes.Add("OnKeyPress", "return SoloDecimales(event)");
                Carga_Planilla(Utils.fc_obtiene_Compania_Id(this));
                Carga_Mes(Utils.fc_obtiene_Ejercicio_Id(this));
                Lista_Periodo(txtDescripcionBuscar.Text);
                btnActualizar.Visible = false;
            }
            HighlightGridLine();
        }

        void Carga_Planilla(String compania_Id)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Ent_Planilla objEPlanilla = new Ent_Planilla();
            objEPlanilla.Compania_Id = compania_Id;
            objEPlanilla.Estado_Id = "01"; /*Solo los Activos*/
            cboPlanilla.DataSource = Log_Planilla.Lista_Planilla(objEPlanilla);
            cboPlanilla.DataTextField = "Descripcion";
            cboPlanilla.DataValueField = "Planilla_Id";
            cboPlanilla.DataBind();
        }
        void Carga_Mes(String ejercicio_Id)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Ent_Mes objEMes = new Ent_Mes();
            objEMes.Ejercicio_Id = ejercicio_Id;
            cboMes.DataSource = Log_Mes.Lista_Mes(objEMes);
            cboMes.DataTextField = "Descripcion";
            cboMes.DataValueField = "Mes_Id";
            cboMes.DataBind();
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Periodo(txtDescripcionBuscar.Text);
        }

        void Lista_Periodo(String no_Periodo)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objEPeriodo = new Ent_Periodo();
                if (no_Periodo.Trim() != String.Empty)
                    objEPeriodo.Descripcion = no_Periodo;
                objEPeriodo.Planilla_Id = Utils.fc_obtiene_Planilla_Id(this);
                objEPeriodo.Ejercicio_Id = Utils.fc_obtiene_Ejercicio_Id(this);
                DataTable dtPeriodo = new DataTable();
                dtPeriodo = Log_Periodo.Lista_Periodo(objEPeriodo);
                Utils.fc_Adecua_GridView(grvPeriodo, dtPeriodo.Rows.Count);
                grvPeriodo.DataSource = dtPeriodo;
                grvPeriodo.DataBind();
                dtPeriodo.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvPeriodo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvPeriodo.PageIndex = e.NewPageIndex;
            Lista_Periodo(txtDescripcionBuscar.Text);
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            LimpiarCajasTexto();
            Carga_Planilla(Utils.fc_obtiene_Compania_Id(this));
            Carga_Mes(Utils.fc_obtiene_Ejercicio_Id(this));

            TabContainer1.ActiveTabIndex = 1;
            txtDescripcion.Focus();
            btnActualizar.Visible = false;
            btnGrabar.Visible = true;
        }

        void LimpiarCajasTexto()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            lblPeriodo_Id.Text = String.Empty;
            txtDescripcion.Text = String.Empty;
            cboPlanilla.SelectedValue = Utils.fc_obtiene_Planilla_Id(this);
            cboMes.SelectedIndex = 0;
            txtSemana.Text = String.Empty;
            txtNro_Semana.Text = String.Empty;
            txtFecha_Inicio.Text = String.Empty;
            txtFecha_Final.Text = String.Empty;
            txtTipo_Cambio.Text = String.Empty;
        }

        protected void grvPeriodo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.CommandName == "Select")
            {
                try
                {
                    string Periodo_Id;

                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    Periodo_Id = grvPeriodo.DataKeys[row.RowIndex].Values["Periodo_Id"].ToString();

                    LimpiarCajasTexto();

                    DataTable dtPeriodo = new DataTable();
                    objEPeriodo = new Ent_Periodo();
                    objEPeriodo.Periodo_Id = Periodo_Id;
                    dtPeriodo = Log_Periodo.Lista_Periodo(objEPeriodo);
                    lblPeriodo_Id.Text = Periodo_Id;
                    txtDescripcion.Text = dtPeriodo.Rows[0]["Descripcion"].ToString();
                    Carga_Planilla(dtPeriodo.Rows[0]["Compania_Id"].ToString());
                    cboPlanilla.SelectedValue = dtPeriodo.Rows[0]["Planilla_Id"].ToString();
                    Carga_Mes(Utils.fc_obtiene_Ejercicio_Id(this));
                    cboMes.SelectedValue = dtPeriodo.Rows[0]["Mes_Id"].ToString();
                    txtSemana.Text = dtPeriodo.Rows[0]["Semana_Id"].ToString();
                    txtNro_Semana.Text = dtPeriodo.Rows[0]["Semana_enMes"].ToString();
                    txtFecha_Inicio.Text = dtPeriodo.Rows[0]["no_Fecha_Ini"].ToString();
                    txtFecha_Final.Text = dtPeriodo.Rows[0]["no_Fecha_Fin"].ToString();
                    txtTipo_Cambio.Text = dtPeriodo.Rows[0]["Tipo_Cambio"].ToString();
                    chkLiqBenef.Checked = bool.Parse(dtPeriodo.Rows[0]["Flag_PagarLiqBenef"].ToString());

                    dtPeriodo.Dispose();
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
        protected void grvPeriodo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Periodo_Id;
                Periodo_Id = grvPeriodo.DataKeys[e.RowIndex].Values["Periodo_Id"].ToString();
                objEPeriodo = new Ent_Periodo();
                objEPeriodo.Periodo_Id = Periodo_Id;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Periodo.Elimina_Periodo(objEPeriodo);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    LimpiarCajasTexto();
                    Lista_Periodo(txtDescripcionBuscar.Text);

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
                objEPeriodo = new Ent_Periodo();
                objEPeriodo.Descripcion = txtDescripcion.Text.ToUpper();
                objEPeriodo.Planilla_Id = cboPlanilla.SelectedValue;
                objEPeriodo.Mes_Id = cboMes.SelectedValue;
                objEPeriodo.Semana_Id = txtSemana.Text;
                objEPeriodo.Semana_enMes = Convert.ToInt32(txtNro_Semana.Text);
                objEPeriodo.Fecha_Ini = Convert.ToDateTime(txtFecha_Inicio.Text);
                objEPeriodo.Fecha_Fin = Convert.ToDateTime(txtFecha_Final.Text);
                objEPeriodo.Tipo_Cambio = Convert.ToDecimal(txtTipo_Cambio.Text);
                objEPeriodo.Estado_Id = "01"; /*Por defecto Activo*/
                objEPeriodo.Compania_Id = Utils.fc_obtiene_Compania_Id(this);
                objEPeriodo.Flag_PagarLiqBenef = chkLiqBenef.Checked;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Periodo.Inserta_Periodo(objEPeriodo);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    lblPeriodo_Id.Text = dtRpta.Rows[0][2].ToString();
                    Lista_Periodo(txtDescripcionBuscar.Text);

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
            if (lblPeriodo_Id.Text.Trim() == String.Empty)
            {
                Utils.fc_DisplayAlert(this, "Seleccionar Un Periodo.");
                TabContainer1.ActiveTabIndex = 0;
                return;
            }
            try
            {
                objEPeriodo = new Ent_Periodo();
                objEPeriodo.Periodo_Id = lblPeriodo_Id.Text;
                objEPeriodo.Descripcion = txtDescripcion.Text.ToUpper();
                objEPeriodo.Planilla_Id = cboPlanilla.SelectedValue;
                objEPeriodo.Mes_Id = cboMes.SelectedValue;
                objEPeriodo.Semana_Id = txtSemana.Text;
                objEPeriodo.Semana_enMes = Convert.ToInt32(txtNro_Semana.Text);
                objEPeriodo.Fecha_Ini = Convert.ToDateTime(txtFecha_Inicio.Text);
                objEPeriodo.Fecha_Fin = Convert.ToDateTime(txtFecha_Final.Text);
                objEPeriodo.Tipo_Cambio = Convert.ToDecimal(txtTipo_Cambio.Text);
                //objEPeriodo.Estado_Id = "01"; /*Por defecto Activo*/
                objEPeriodo.Compania_Id = Utils.fc_obtiene_Compania_Id(this);
                objEPeriodo.Flag_PagarLiqBenef = chkLiqBenef.Checked;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Periodo.Actualiza_Periodo(objEPeriodo);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_Periodo(txtDescripcionBuscar.Text);
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void btnCrearPeriodos_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objEPeriodo = new Ent_Periodo();
                objEPeriodo.Compania_Id = Utils.fc_obtiene_Compania_Id(this);
                objEPeriodo.Mes_Id = Utils.fc_obtiene_Ejercicio_Id(this); /*Se guarda el Ejercicio_Id en Mes_Id*/
                objEPeriodo.Planilla_Id = cboPlanilla.SelectedValue;
                DataTable dtRpta = new DataTable();
                dtRpta = Log_Periodo.Inserta_Periodo_Masivo(objEPeriodo);
                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    TabContainer1.ActiveTabIndex = 0;
                    Lista_Periodo(txtDescripcionBuscar.Text);
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);

            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void ibtnFec_Final_Click(object sender, ImageClickEventArgs e)
        {

        }
        protected void grvPeriodo_RowDataBound(object sender, GridViewRowEventArgs e)
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