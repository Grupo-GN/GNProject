using CAPA_ENTIDAD;
using CAPA_LOGICO;
using GNProject.Views.sistemaPlanillas.code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.Mantenimientos
{
    public partial class FrmConfigCtaCte : BasePage
    {
        Ent_Personal objEPersonal;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                txtNroCuotas.Attributes.Add("OnKeyPress", "return SoloNumeros(event)");
                txtMontoCtaCte.Attributes.Add("OnKeyPress", "return SoloDecimales(event)");

                CargaOperacion();
                CargaMotivos();
                CargaMoneda();
                CargaEstado();
                lblelErrorMs.Text = "";
                TabContainer1.ActiveTabIndex = 0;

            }

            HighlightGridLine();

        }



        void CargaOperacion()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            cboOperacion.DataSource = Log_Ctacte_Operacion.Lista_Ctacte_Operacion();
            cboOperacion.DataTextField = "Descripcion";
            cboOperacion.DataValueField = "Ctacte_Operacion_id";
            cboOperacion.DataBind();
        }
        void CargaMotivos()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            cboMotivoCtaCte.DataSource = Log_Ctacte_Motivo.Lista_CtaCte_Motivo();
            cboMotivoCtaCte.DataTextField = "Descripcion";
            cboMotivoCtaCte.DataValueField = "Motivo_CtaCte_Id";
            cboMotivoCtaCte.DataBind();
        }
        void CargaMoneda()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            cboMoneda.DataSource = Log_General.Lista_Moneda();
            cboMoneda.DataTextField = "Descripcion";
            cboMoneda.DataValueField = "Moneda_Id";
            cboMoneda.DataBind();

        }
        void CargaEstado()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            cboEstado.DataSource = Log_General.Lista_Estados();
            cboEstado.DataTextField = "Descripcion";
            cboEstado.DataValueField = "Codigo";
            cboEstado.DataBind();
        }

        private void Lista_Personal(String Periodo_Id, String Apellidos_y_Nombres)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (Utils.fc_obtiene_Periodo_Id(this) == "")
            {
                lblelErrorMs.Text = "Elegir Un Periodo";
                return;
            }


            objEPersonal = new Ent_Personal();
            objEPersonal._Periodo_Id = Periodo_Id;
            if (Apellidos_y_Nombres.Trim() != "")
                objEPersonal._Nombres = Apellidos_y_Nombres;

            DataTable dtPersonal = new DataTable();
            dtPersonal = Log_Personal.Lista_Personal(objEPersonal);
            grvPersonal.DataSource = dtPersonal;
            grvPersonal.DataBind();


            if (dtPersonal.Rows.Count <= 0)
            {
                Utils.fc_DisplayAlert(this, "No se Encontraron Registros.");
            }
        }

        protected void grvPersonal_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.CommandName == "Select")
            {
                try
                {
                    /*Muestra las Ctas. Ctes. del Personal Seleccionado*/
                    //btnGrabarCtaCte.Visible = false;
                    //btnActualizarCtaCte.Visible = false;

                    string Personal_Id;
                    string nombre_Personal;
                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    Personal_Id = grvPersonal.DataKeys[row.RowIndex].Values["Personal_Id"].ToString();
                    nombre_Personal = grvPersonal.DataKeys[row.RowIndex].Values["Nombre_Completo"].ToString();

                    txtNombrePersonal.Text = nombre_Personal;
                    hdnPersonal_Id.Value = Personal_Id;

                    LimpiaCajasTextoCtaCte();
                    TabContainer1.Visible = true;
                    TabContainer1.ActiveTabIndex = 1;
                    lblelErrorMs.Text = "";
                    Lista_Ctas_Ctes(Personal_Id);
                    if (lblelErrorMs.Text == "No Se Encontraron Registros.")
                    {
                        txtNombrePersonal.Text = "";
                        return;
                    }
                    hdnCta_Cte_Id.Value = "";
                    lblCta_Cte.Text = "";

                    enableCancel(true);
                    btnNew.Enabled = true;
                    enableUpdate(false);
                }
                catch (Exception ex)
                {
                    //  Utils.fc_DisplayAlert(this, ex.Message);
                    lblelErrorMs.Text = "";
                    TabContainer1.ActiveTabIndex = 0;
                }
            }
            else if (e.CommandName == "Neww")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;

                TabContainer1.ActiveTabIndex = 2;
                LimpiaCajasTextoCtaCte();
                string nombre_Personal;
                string Personal_Id;
                nombre_Personal = grvPersonal.DataKeys[row.RowIndex].Values["Nombre_Completo"].ToString();
                txtNombrePersonal.Text = nombre_Personal;
                Personal_Id = grvPersonal.DataKeys[row.RowIndex].Values["Personal_Id"].ToString();
                txtNombrePersonal.Text = nombre_Personal;
                hdnPersonal_Id.Value = Personal_Id;

                grvCuotas.DataBind();
                grvCuotas2.DataSource = null;
                grvCuotas2.DataBind();
                hdnCta_Cte_Id.Value = "";
                lblCta_Cte.Text = "";
                txtFecha_Final.Text = DateTime.Now.Date.ToString();
                txtFecha_Inicio.Text = DateTime.Now.Date.ToString();
                cboMoneda.SelectedIndex = 1;
                enableCancel(true);
                enableGrabar(true);
                rbAsignacionList.SelectedValue = "M";
            }
        }

        private void enableCancel(bool opcion)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            btnCancel.Enabled = opcion;
        }

        void LimpiaCajasTextoCtaCte()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            lblNroCta.Text = "";
            cboOperacion.SelectedIndex = 0;
            cboMotivoCtaCte.SelectedIndex = 0;
            txtNroCuotas.Text = "";
            txtFecha_Inicio.Text = "";
            txtFecha_Final.Text = "";
            txtMontoCtaCte.Text = "";
            txtDescripcion.Text = "";
            cboMoneda.SelectedIndex = 0;
            cboEstado.SelectedIndex = 0;
        }

        private void Lista_Ctas_Ctes(String Personal_Id)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            DataTable dtCtas_Ctes = new DataTable();
            Ent_Ctas_Ctes objECtaCte = new Ent_Ctas_Ctes();
            objECtaCte.Personal_Id = Personal_Id;

            dtCtas_Ctes = Log_Ctas_Ctes.Lista_Ctas_Ctes(objECtaCte).Tables[0];
            grvCta_Cte.DataSource = dtCtas_Ctes;
            grvCta_Cte.DataBind();
            if (dtCtas_Ctes.Rows.Count <= 0)
            {
                lblelErrorMs.Text = "No Se Encontraron Registros.";
                TabContainer1.ActiveTabIndex = 0;
            }
        }

        protected void grvCta_Cte_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.CommandName == "Select")
            {
                try
                {
                    /*Muestra las Cuotas de la Cta. Cte.*/


                    string Cta_Cte_Id;
                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    Cta_Cte_Id = grvCta_Cte.DataKeys[row.RowIndex].Values["Cta_Cte_Id"].ToString();

                    hdnCta_Cte_Id.Value = Cta_Cte_Id;

                    lblCta_Cte.Text = "Nro. de Cta. Cte.: " + Cta_Cte_Id.ToString();

                    Carga_DataCta_Cte(hdnPersonal_Id.Value, Cta_Cte_Id);
                    Lista_Cuotas(Cta_Cte_Id);
                    enableGrabar(false);
                    enableUpdate(true);
                    enableCancel(true);
                    TabContainer1.ActiveTabIndex = 2;
                }
                catch (Exception ex)
                {
                    Utils.fc_DisplayAlert(this, ex.Message);
                }
            }
            if (e.CommandName == "Detail")
            {
                try
                {
                    /*Muestra las Cuotas de la Cta. Cte.*/
                    //btnGrabarCtaCte.Visible = false;
                    //btnActualizarCtaCte.Visible = true;

                    string Cta_Cte_Id;
                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    Cta_Cte_Id = grvCta_Cte.DataKeys[row.RowIndex].Values["Cta_Cte_Id"].ToString();

                    hdnCta_Cte_Id.Value = Cta_Cte_Id;

                    lblCta_Cte.Text = "Nro. de Cta. Cte.: " + Cta_Cte_Id.ToString();

                    Carga_DataCta_Cte(hdnPersonal_Id.Value, Cta_Cte_Id);
                    Lista_Cuotas(Cta_Cte_Id);
                    enableGrabar(false);
                    enableUpdate(false);
                    TabContainer1.ActiveTabIndex = 1;
                }
                catch (Exception ex)
                {
                    Utils.fc_DisplayAlert(this, ex.Message);
                }
            }
        }

        private void Carga_DataCta_Cte(String Personal_Id, String Cta_Cte_Id)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                Ent_Ctas_Ctes objECtaCte = new Ent_Ctas_Ctes();
                objECtaCte.Personal_Id = Personal_Id;
                objECtaCte.Cta_Cte_Id = Cta_Cte_Id;
                DataTable dtCtaCte = new DataTable();
                dtCtaCte = Log_Ctas_Ctes.Lista_Ctas_Ctes(objECtaCte).Tables[0];

                rbAsignacionList.SelectedValue = (dtCtaCte.Rows[0]["fl_quincenal"].ToString() == "0" ? "M" : "Q");
                lblNroCta.Text = Cta_Cte_Id;
                cboOperacion.SelectedValue = dtCtaCte.Rows[0]["Operacion_Id"].ToString();
                cboMotivoCtaCte.SelectedValue = dtCtaCte.Rows[0]["Motivo_Id"].ToString();
                txtNroCuotas.Text = dtCtaCte.Rows[0]["Nro_Cuotas"].ToString();
                txtFecha_Inicio.Text = Convert.ToDateTime(dtCtaCte.Rows[0]["Fecha_Ini"]).ToString("dd/MM/yyyy");
                txtFecha_Final.Text = Convert.ToDateTime(dtCtaCte.Rows[0]["Fecha_Fin"]).ToString("dd/MM/yyyy");
                txtMontoCtaCte.Text = Convert.ToDecimal(dtCtaCte.Rows[0]["Monto"]).ToString();
                txtDescripcion.Text = dtCtaCte.Rows[0]["Observaciones"].ToString();
                cboMoneda.SelectedValue = dtCtaCte.Rows[0]["Moneda_Id"].ToString();
                cboEstado.SelectedValue = dtCtaCte.Rows[0]["Estado_Id"].ToString();
                dtCtaCte.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        private void Lista_Cuotas(String Cta_Cte_Id)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                DataTable dtCuotas = new DataTable();
                Ent_Cuotas objECuotas = new Ent_Cuotas();
                objECuotas.Cta_Cte_Id = Cta_Cte_Id;
                dtCuotas = Log_Cuotas.Lista_Cuotas(objECuotas).Tables[0];
                grvCuotas.DataSource = dtCuotas;
                grvCuotas.DataBind();
                if (dtCuotas.Rows.Count <= 0)
                {
                    Utils.fc_DisplayAlert(this, "No Se Encontraron Registros.");


                }
                else
                    dtCuotas.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        private void Lista_Cuotas_W(String Cta_Cte_Id)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                DataTable dtCuotas = new DataTable();
                Ent_Cuotas objECuotas = new Ent_Cuotas();
                objECuotas.Cta_Cte_Id = Cta_Cte_Id;
                dtCuotas = Log_Cuotas.Lista_Cuotas(objECuotas).Tables[0];
                grvCuotas2.DataSource = dtCuotas;
                grvCuotas2.DataBind();
                if (dtCuotas.Rows.Count <= 0)
                {
                    Utils.fc_DisplayAlert(this, "No Se Encontraron Registros.");

                }
                else
                    dtCuotas.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvCta_Cte_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            string Cta_Cte_Id;
            Cta_Cte_Id = grvCta_Cte.DataKeys[e.RowIndex].Value.ToString();

            Ent_Ctas_Ctes objECtaCte = new Ent_Ctas_Ctes();
            objECtaCte.Cta_Cte_Id = Cta_Cte_Id;

            DataTable dtRpta = new DataTable();
            dtRpta = Log_Ctas_Ctes.Elimina_Ctas_Ctes(objECtaCte).Tables[0];

            string msj_rpta;
            msj_rpta = dtRpta.Rows[0][1].ToString();
            Utils.fc_DisplayAlert(this, msj_rpta);

            Lista_Ctas_Ctes(hdnPersonal_Id.Value);
            LimpiaCajasTextoCtaCte();

            if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
            {
                hdnCta_Cte_Id.Value = "";
                lblCta_Cte.Text = "";


            }
        }

        protected void grvCuotas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                    e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

                    Label Valor = (Label)e.Row.Cells[4].FindControl("lblMonto");
                    if (Valor != null)
                    {
                        decimal algo = decimal.Parse(Valor.Text);
                        Valor.Text = algo.ToString("F", CultureInfo.InvariantCulture);
                    }


                    TextBox txtMonto = (TextBox)e.Row.FindControl("txtMonto");
                    if (txtMonto != null)
                    {
                        txtMonto.Attributes.Add("OnKeyPress", "return SoloDecimales(event)");
                        decimal algo = decimal.Parse(txtMonto.Text);
                        txtMonto.Text = algo.ToString("F", CultureInfo.InvariantCulture);
                    }


                    DropDownList cboProcesoCuota = (DropDownList)e.Row.FindControl("cboProcesoCuota");
                    if (cboProcesoCuota != null)
                    {
                        /*Carga Combo de Procesos*/
                        DataTable dtProcesoCuota = new DataTable();
                        Ent_Procesos objEProcesos2 = new Ent_Procesos();
                        objEProcesos2.Estado_Id = "01";/*Solo Activos*/
                        dtProcesoCuota = Log_Procesos.Lista_Procesos(objEProcesos2);

                        cboProcesoCuota.DataSource = dtProcesoCuota;
                        cboProcesoCuota.DataTextField = "Proceso";
                        cboProcesoCuota.DataValueField = "Proceso_Id";
                        cboProcesoCuota.DataBind();

                        string Proceso_Id;
                        Proceso_Id = grvCuotas.DataKeys[e.Row.RowIndex].Values["Proceso_Id"].ToString();

                        if (Proceso_Id.Trim() != "" || Proceso_Id != null)
                        {
                            Boolean rpta1 = false;
                            foreach (ListItem list in cboProcesoCuota.Items)
                            {
                                if (Proceso_Id == list.Value.ToString())
                                {
                                    rpta1 = true;
                                    break;
                                }
                            }
                            if (rpta1 == true)
                            {
                                cboProcesoCuota.SelectedValue = Proceso_Id;
                            }
                            else
                            {
                                cboProcesoCuota.SelectedIndex = 0;
                            }
                        }
                        dtProcesoCuota.Dispose();

                        /*Carga Combo de Periodo*/
                        DropDownList cboPeriodoCuota = (DropDownList)e.Row.FindControl("cboPeriodoCuota");

                        DataTable dtPeriodoCuota = new DataTable();
                        Ent_Periodo objEPeriodo = new Ent_Periodo();
                        objEPeriodo.Compania_Id = Utils.fc_obtiene_Compania_Id(this);
                        objEPeriodo.Ejercicio_Id = Utils.fc_obtiene_Ejercicio_Id(this);
                        objEPeriodo.Planilla_Id = Utils.fc_obtiene_Planilla_Id(this);
                        dtPeriodoCuota = Log_Periodo.Lista_Periodo(objEPeriodo);

                        cboPeriodoCuota.DataSource = dtPeriodoCuota;
                        cboPeriodoCuota.DataTextField = "Descripcion";
                        cboPeriodoCuota.DataValueField = "Periodo_Id";
                        cboPeriodoCuota.DataBind();

                        string Periodo_Id_Seleccionado;
                        Periodo_Id_Seleccionado = grvCuotas.DataKeys[e.Row.RowIndex].Values["Periodo_Id"].ToString();

                        if (Periodo_Id_Seleccionado.Trim() != "" || Periodo_Id_Seleccionado != null)
                        {
                            Boolean rpta2 = false;
                            foreach (ListItem list in cboPeriodoCuota.Items)
                            {
                                if (Periodo_Id_Seleccionado == list.Value.ToString())
                                {
                                    rpta2 = true;
                                    break;
                                }
                            }
                            if (rpta2 == true)
                            {
                                cboPeriodoCuota.SelectedValue = Periodo_Id_Seleccionado;
                            }
                            else
                            {
                                cboPeriodoCuota.SelectedIndex = 0;
                            }
                        }
                        dtPeriodoCuota.Dispose();

                        /*Carga Combo de Estados de Pago*/
                        DropDownList cboEstado_Pago = (DropDownList)e.Row.FindControl("cboEstado_Pago");
                        DataTable dtEstado_Pago = new DataTable();
                        dtEstado_Pago = Log_Cuotas_Estado_Pago.Lista_Cuotas_Estado_Pago();
                        cboEstado_Pago.DataSource = dtEstado_Pago;
                        cboEstado_Pago.DataTextField = "Descripcion";
                        cboEstado_Pago.DataValueField = "Cuotas_Estado_Pago_Id";
                        cboEstado_Pago.DataBind();
                        string Estado_Pago_Id;
                        Estado_Pago_Id = grvCuotas.DataKeys[e.Row.RowIndex].Values["Estado_Pago_Id"].ToString();

                        if (Estado_Pago_Id.Trim() != "" || Estado_Pago_Id != null)
                        {
                            Boolean rpta3 = false;
                            foreach (ListItem list in cboEstado_Pago.Items)
                            {
                                if (Estado_Pago_Id == list.Value.ToString())
                                {
                                    rpta3 = true;
                                    break;
                                }
                            }
                            if (rpta3 == true)
                            {
                                cboEstado_Pago.SelectedValue = Estado_Pago_Id;
                            }
                            else
                            {
                                cboEstado_Pago.SelectedIndex = 0;
                            }
                        }
                        dtEstado_Pago.Dispose();

                    }
                }
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void grvCuotas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.CommandName == "Insert")
            {


                try
                {
                    Ent_Cuotas objECuotas = new Ent_Cuotas();

                    objECuotas.Cta_Cte_Id = hdnCta_Cte_Id.Value;
                    objECuotas.Proceso_Id = ((DropDownList)grvCuotas.FooterRow.FindControl("cboProcesoCuotaNew")).SelectedValue;
                    objECuotas.Periodo_Id = ((DropDownList)grvCuotas.FooterRow.FindControl("cboPeriodoCuotaNew")).SelectedValue;
                    objECuotas.Monto = Convert.ToDecimal(((TextBox)grvCuotas.FooterRow.FindControl("txtMontoNew")).Text);
                    objECuotas.Estado_Pago_Id = ((DropDownList)grvCuotas.FooterRow.FindControl("cboEstado_PagoNew")).SelectedValue;
                    objECuotas.Estado_Id = ((TextBox)grvCuotas.FooterRow.FindControl("txtEstadoNew")).Text;

                    DataTable dtRpta = new DataTable();
                    dtRpta = Log_Cuotas.Inserta_Cuotas(objECuotas).Tables[0];

                    string msj_rpta;
                    msj_rpta = dtRpta.Rows[0][1].ToString();
                    Utils.fc_DisplayAlert(this, msj_rpta);

                    //////Lista_Ctas_Ctes(hdnPersonal_Id.Value);
                    Lista_Cuotas(hdnCta_Cte_Id.Value);
                }
                catch (Exception ex)
                {
                    Utils.fc_DisplayAlert(this, ex.Message);
                }
            }
        }

        protected void grvCuotas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Cuotas_Id;
                Cuotas_Id = grvCuotas.DataKeys[e.RowIndex].Value.ToString();

                Ent_Cuotas objECuotas = new Ent_Cuotas();
                objECuotas.Cuotas_Id = Cuotas_Id;
                objECuotas.Proceso_Id = ((DropDownList)grvCuotas.Rows[e.RowIndex].FindControl("cboProcesoCuota")).SelectedValue;
                objECuotas.Periodo_Id = ((DropDownList)grvCuotas.Rows[e.RowIndex].FindControl("cboPeriodoCuota")).SelectedValue;
                objECuotas.Monto = Convert.ToDecimal(((TextBox)grvCuotas.Rows[e.RowIndex].FindControl("txtMonto")).Text);
                objECuotas.Estado_Pago_Id = ((DropDownList)grvCuotas.Rows[e.RowIndex].FindControl("cboEstado_Pago")).SelectedValue;
                objECuotas.Estado_Id = ((TextBox)grvCuotas.Rows[e.RowIndex].FindControl("txtEstado")).Text;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Cuotas.Actualiza_Cuotas(objECuotas).Tables[0];

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                Utils.fc_DisplayAlert(this, msj_rpta);

                grvCuotas.EditIndex = -1;
                //////Lista_Ctas_Ctes(hdnPersonal_Id.Value);
                Lista_Cuotas(hdnCta_Cte_Id.Value);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void ibtnNueva_Cuota_Click(object sender, ImageClickEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                Ent_Cuotas objECuota = new Ent_Cuotas();

                objECuota.Cta_Cte_Id = hdnCta_Cte_Id.Value;
                //objECuota.Proceso_Id = cboProceso.SelectedValue;
                //objECuota.Periodo_Id = cboPeriodo.SelectedValue;
                //objECuota.Monto = Convert.ToDecimal(txtMontoCuota.Text);

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Cuotas.Inserta_Cuotas(objECuota).Tables[0];

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                Utils.fc_DisplayAlert(this, msj_rpta);




                dtRpta.Dispose();
                //////Lista_Ctas_Ctes(hdnPersonal_Id.Value);
                Lista_Cuotas(hdnCta_Cte_Id.Value);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void btnGrabarCtaCte_Click(object sender, EventArgs e)
        {

        }

        protected void btnActualizarCtaCte_Click(object sender, EventArgs e)
        {

        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (hdnPersonal_Id.Value.Trim() == "")
            {
                lblelErrorMs.Text = "Por Favor Volver A Seleccionar El Personal.";
                return;
            }
            LimpiaCajasTextoCtaCte();
            txtFecha_Inicio.Text = DateTime.Now.Date.ToString();
            txtFecha_Final.Text = DateTime.Now.Date.ToString();
            cboMoneda.SelectedIndex = 1;
            btnAdd.Enabled = true;
            enableUpdate(false);
            rbAsignacionList.SelectedValue = "M";
            TabContainer1.ActiveTabIndex = 2;
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (lblNroCta.Text != "")
            {
                lblelErrorMs.Text = "Por Favor Dar Click En El Botón Nuevo";
                return;
            }
            try
            {
                if (hdnPersonal_Id.Value.Trim() == "")
                {
                    lblelErrorMs.Text = "Por Favor Volver A Seleccionar El Personal.";
                    return;
                }

                String fl_quincenal = (rbAsignacionList.SelectedValue == "M" ? "0" : "1");

                string Next = Log_Ctas_Ctes.Valida_Nro_Cuotas(int.Parse(txtNroCuotas.Text), Convert.ToDateTime(txtFecha_Inicio.Text), hdnPersonal_Id.Value
                    , fl_quincenal).ToString();
                if (Next == "ERROR")
                {
                    lblelErrorMs.Text = "Error.. No existen los periodos para las primeras cuotas";
                    txtNroCuotas.Focus();
                    return;

                }
                else
                {
                    lblelErrorMs.Text = "";
                }
                Ent_Ctas_Ctes objECtaCte = new Ent_Ctas_Ctes();
                objECtaCte.Personal_Id = hdnPersonal_Id.Value;
                objECtaCte.Operacion_Id = cboOperacion.SelectedValue;
                objECtaCte.Motivo_Id = cboMotivoCtaCte.SelectedValue;
                objECtaCte.Nro_Cuotas = Convert.ToInt32(txtNroCuotas.Text);

                //20181217
                //objECtaCte.Monto = Convert.ToDecimal(txtMontoCtaCte.Text.Replace(".",","));
                objECtaCte.Monto = Convert.ToDecimal(txtMontoCtaCte.Text);
                objECtaCte.Moneda_Id = cboMoneda.SelectedValue;


                objECtaCte.Fecha_Sistema = Convert.ToDateTime(DateTime.Now.Date);

                objECtaCte.Fecha_Ini = Convert.ToDateTime(txtFecha_Inicio.Text);
                objECtaCte.Fecha_Fin = Convert.ToDateTime(txtFecha_Final.Text);

                objECtaCte.Observaciones = txtDescripcion.Text;
                objECtaCte.Estado_Id = cboEstado.SelectedValue;
                objECtaCte.Interes_Anual = 0;
                objECtaCte.Interes_Cantidad_Periodos = 0;
                objECtaCte.fl_quincenal = fl_quincenal;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Ctas_Ctes.Graba_Ctas_Ctes(objECtaCte).Tables[0];

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();

                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_Ctas_Ctes(hdnPersonal_Id.Value);

                    string cta_cte_id;
                    cta_cte_id = dtRpta.Rows[0][0].ToString();
                    lblNroCta.Text = cta_cte_id;

                    hdnCta_Cte_Id.Value = cta_cte_id;
                    lblCta_Cte.Text = "Nro. de Cta. Cte.: " + cta_cte_id;
                    Lista_Cuotas(cta_cte_id);
                    Utils.fc_DisplayAlert(this, "Grabado Correctamente");

                    enableGrabar(false);
                    enableCancel(false);
                    LimpiaCajasTextoCtaCte();
                    grvCuotas.DataSource = null;
                    grvCuotas.DataBind();
                    Lista_Cuotas_W(cta_cte_id);
                    Lista_Cuotas(cta_cte_id);
                    TabContainer1.ActiveTabIndex = 2;

                }
                else
                {
                    lblelErrorMs.Text = msj_rpta;
                    txtNroCuotas.Focus();
                }
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            enableCancel(false);
            enableGrabar(false);
            enableUpdate(false);
            btnNew.Enabled = false;
            TabContainer1.ActiveTabIndex = 0;
            LimpiaCajasTextoCtaCte();

            grvCta_Cte.DataSource = null;
            grvCta_Cte.DataBind();
            grvCuotas.DataSource = null;
            grvCuotas.DataBind();
            grvCuotas2.DataSource = null;
            grvCuotas2.DataBind();
            lblNomPersonal.Text = "";
            hdnPersonal_Id.Value = "";
            lblCta_Cte.Text = "";
            txtNombrePersonal.Text = "";
            lblelErrorMs.Text = "";
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (hdnCta_Cte_Id.Value == "")
            {
                Utils.fc_DisplayAlert(this, "Por Favor Seleccionar Una Cta. Cte");
                return;
            }
            try
            {
                if (hdnPersonal_Id.Value.Trim() == "")
                {
                    Utils.fc_DisplayAlert(this, "Por Favor Volver A Seleccionar El Personal.");
                    return;
                }

                String fl_quincenal = (rbAsignacionList.SelectedValue == "M" ? "0" : "1");

                string Next = Log_Ctas_Ctes.Valida_Nro_Cuotas(int.Parse(txtNroCuotas.Text), Convert.ToDateTime(txtFecha_Inicio.Text), hdnPersonal_Id.Value
                    , fl_quincenal).ToString();
                if (Next == "ERROR")
                {
                    lblelErrorMs.Text = "Error.. No existen los periodos para las primeras cuotas";
                    txtNroCuotas.Focus();
                    return;
                }
                else
                {
                    lblelErrorMs.Text = "";
                }
                Ent_Ctas_Ctes objECtaCte = new Ent_Ctas_Ctes();
                objECtaCte.Cta_Cte_Id = hdnCta_Cte_Id.Value;
                objECtaCte.Personal_Id = hdnPersonal_Id.Value;
                objECtaCte.Operacion_Id = cboOperacion.SelectedValue;
                objECtaCte.Motivo_Id = cboMotivoCtaCte.SelectedValue;
                objECtaCte.Nro_Cuotas = Convert.ToInt32(txtNroCuotas.Text);
                objECtaCte.Monto = Convert.ToDecimal(txtMontoCtaCte.Text);
                objECtaCte.Moneda_Id = cboMoneda.SelectedValue;
                objECtaCte.Fecha_Sistema = Convert.ToDateTime(DateTime.Now.Date);

                objECtaCte.Fecha_Ini = Convert.ToDateTime(txtFecha_Inicio.Text);
                objECtaCte.Fecha_Fin = Convert.ToDateTime(txtFecha_Final.Text);

                objECtaCte.Observaciones = txtDescripcion.Text;
                objECtaCte.Estado_Id = cboEstado.SelectedValue;
                objECtaCte.Interes_Anual = 0;
                objECtaCte.Interes_Cantidad_Periodos = 0;
                objECtaCte.fl_quincenal = fl_quincenal;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Ctas_Ctes.Actualiza_Ctas_Ctes(objECtaCte).Tables[0];

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                Utils.fc_DisplayAlert(this, msj_rpta);

                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_Ctas_Ctes(hdnPersonal_Id.Value);

                    string cta_cte_id;
                    cta_cte_id = dtRpta.Rows[0][0].ToString();
                    lblNroCta.Text = cta_cte_id;
                    hdnCta_Cte_Id.Value = cta_cte_id;
                    lblCta_Cte.Text = "Nro. de Cta. Cte.: " + cta_cte_id;
                    Lista_Cuotas(cta_cte_id);
                    enableUpdate(true);
                    btnNew.Enabled = true;
                    Lista_Cuotas_W(cta_cte_id);
                    Lista_Cuotas(cta_cte_id);
                    TabContainer1.ActiveTabIndex = 2;
                }
                else
                {
                    lblelErrorMs.Text = msj_rpta;
                    txtNroCuotas.Focus();
                }
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        private void enableGrabar(bool opcion)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            btnAdd.Enabled = opcion;
        }

        private void enableUpdate(bool opcion)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            btnUpdate.Enabled = opcion;
        }


        protected void btnBuscarr_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (TabContainer1.ActiveTabIndex == 0)
                Lista_Personal(Utils.fc_obtiene_Periodo_Id(this), txtNombrePersonal.Text);
        }
        protected void grvPersonal_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            }
        }
        protected void grvCta_Cte_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

                string txtValor = e.Row.Cells[3].Text;
                double algo = double.Parse(txtValor);
                e.Row.Cells[3].Text = algo.ToString("F", CultureInfo.InvariantCulture);
            }
        }
        protected void grvPersonal_PreRender(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Personal(Utils.fc_obtiene_Periodo_Id(this), txtNombrePersonal.Text);
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }
        protected void IbtnSelect_Click(object sender, ImageClickEventArgs e)
        {

        }
        protected void ibtnSCuotas_Click(object sender, ImageClickEventArgs e)
        {

        }


        protected void grvCoutas2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvCuotas2.EditIndex = e.NewEditIndex;
            Lista_Cuotas_W(hdnCta_Cte_Id.Value);
            Lista_Cuotas(hdnCta_Cte_Id.Value);
        }
        protected void grvCoutas2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Cuotas_Id;
                Cuotas_Id = grvCuotas2.DataKeys[e.RowIndex].Value.ToString();

                Ent_Cuotas objECuotas = new Ent_Cuotas();
                objECuotas.Cuotas_Id = Cuotas_Id;
                objECuotas.Proceso_Id = ((DropDownList)grvCuotas2.Rows[e.RowIndex].FindControl("cboProcesoCuota")).SelectedValue;
                objECuotas.Periodo_Id = ((DropDownList)grvCuotas2.Rows[e.RowIndex].FindControl("cboPeriodoCuota")).SelectedValue;
                objECuotas.Monto = Convert.ToDecimal(((TextBox)grvCuotas2.Rows[e.RowIndex].FindControl("txtMonto")).Text);
                objECuotas.Estado_Pago_Id = ((DropDownList)grvCuotas2.Rows[e.RowIndex].FindControl("cboEstado_Pago")).SelectedValue;
                objECuotas.Estado_Id = ((TextBox)grvCuotas2.Rows[e.RowIndex].FindControl("txtEstado")).Text;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Cuotas.Actualiza_Cuotas(objECuotas).Tables[0];

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                Utils.fc_DisplayAlert(this, msj_rpta);

                grvCuotas2.EditIndex = -1;
                Lista_Cuotas_W(hdnCta_Cte_Id.Value);
                Lista_Cuotas(hdnCta_Cte_Id.Value);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void grvCuotas2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.CommandName == "Insert")
            {


                try
                {
                    Ent_Cuotas objECuotas = new Ent_Cuotas();

                    objECuotas.Cta_Cte_Id = hdnCta_Cte_Id.Value;
                    objECuotas.Proceso_Id = ((DropDownList)grvCuotas2.FooterRow.FindControl("cboProcesoCuotaNew")).SelectedValue;
                    objECuotas.Periodo_Id = ((DropDownList)grvCuotas2.FooterRow.FindControl("cboPeriodoCuotaNew")).SelectedValue;
                    objECuotas.Monto = Convert.ToDecimal(((TextBox)grvCuotas2.FooterRow.FindControl("txtMontoNew")).Text);
                    objECuotas.Estado_Pago_Id = ((DropDownList)grvCuotas2.FooterRow.FindControl("cboEstado_PagoNew")).SelectedValue;
                    objECuotas.Estado_Id = ((TextBox)grvCuotas2.FooterRow.FindControl("txtEstadoNew")).Text;

                    DataTable dtRpta = new DataTable();
                    dtRpta = Log_Cuotas.Inserta_Cuotas(objECuotas).Tables[0];

                    string msj_rpta;
                    msj_rpta = dtRpta.Rows[0][1].ToString();
                    Utils.fc_DisplayAlert(this, msj_rpta);

                    //////Lista_Ctas_Ctes(hdnPersonal_Id.Value);
                    Lista_Cuotas_W(hdnCta_Cte_Id.Value);
                }
                catch (Exception ex)
                {
                    Utils.fc_DisplayAlert(this, ex.Message);
                }
            }
        }


        protected void grvCuotas2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvCuotas2.EditIndex = -1;
            Lista_Cuotas_W(hdnCta_Cte_Id.Value);
        }
        protected void grvCuotas2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                    e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

                    Label Valor = (Label)e.Row.Cells[4].FindControl("lblMonto");
                    if (Valor != null)
                    {
                        decimal algo = decimal.Parse(Valor.Text);
                        Valor.Text = algo.ToString("F", CultureInfo.InvariantCulture);
                    }


                    TextBox txtMonto = (TextBox)e.Row.FindControl("txtMonto");
                    if (txtMonto != null)
                    {
                        txtMonto.Attributes.Add("OnKeyPress", "return SoloDecimales(event)");
                        decimal algo = decimal.Parse(txtMonto.Text);
                        txtMonto.Text = algo.ToString("F", CultureInfo.InvariantCulture);
                    }



                    DropDownList cboProcesoCuota = (DropDownList)e.Row.FindControl("cboProcesoCuota");
                    if (cboProcesoCuota != null)
                    {
                        /*Carga Combo de Procesos*/
                        DataTable dtProcesoCuota = new DataTable();
                        Ent_Procesos objEProcesos2 = new Ent_Procesos();
                        objEProcesos2.Estado_Id = "01";/*Solo Activos*/
                        dtProcesoCuota = Log_Procesos.Lista_Procesos(objEProcesos2);

                        cboProcesoCuota.DataSource = dtProcesoCuota;
                        cboProcesoCuota.DataTextField = "Proceso";
                        cboProcesoCuota.DataValueField = "Proceso_Id";
                        cboProcesoCuota.DataBind();

                        string Proceso_Id;
                        Proceso_Id = grvCuotas2.DataKeys[e.Row.RowIndex].Values["Proceso_Id"].ToString();

                        if (Proceso_Id.Trim() != "" || Proceso_Id != null)
                        {
                            Boolean rpta1 = false;
                            foreach (ListItem list in cboProcesoCuota.Items)
                            {
                                if (Proceso_Id == list.Value.ToString())
                                {
                                    rpta1 = true;
                                    break;
                                }
                            }
                            if (rpta1 == true)
                            {
                                cboProcesoCuota.SelectedValue = Proceso_Id;
                            }
                            else
                            {
                                cboProcesoCuota.SelectedIndex = 0;
                            }
                        }
                        dtProcesoCuota.Dispose();

                        /*Carga Combo de Periodo*/
                        DropDownList cboPeriodoCuota = (DropDownList)e.Row.FindControl("cboPeriodoCuota");

                        DataTable dtPeriodoCuota = new DataTable();
                        Ent_Periodo objEPeriodo = new Ent_Periodo();
                        objEPeriodo.Compania_Id = Utils.fc_obtiene_Compania_Id(this);
                        objEPeriodo.Ejercicio_Id = Utils.fc_obtiene_Ejercicio_Id(this);
                        objEPeriodo.Planilla_Id = Utils.fc_obtiene_Planilla_Id(this);
                        dtPeriodoCuota = Log_Periodo.Lista_Periodo(objEPeriodo);

                        cboPeriodoCuota.DataSource = dtPeriodoCuota;
                        cboPeriodoCuota.DataTextField = "Descripcion";
                        cboPeriodoCuota.DataValueField = "Periodo_Id";
                        cboPeriodoCuota.DataBind();

                        string Periodo_Id_Seleccionado;
                        Periodo_Id_Seleccionado = grvCuotas2.DataKeys[e.Row.RowIndex].Values["Periodo_Id"].ToString();

                        if (Periodo_Id_Seleccionado.Trim() != "" || Periodo_Id_Seleccionado != null)
                        {
                            Boolean rpta2 = false;
                            foreach (ListItem list in cboPeriodoCuota.Items)
                            {
                                if (Periodo_Id_Seleccionado == list.Value.ToString())
                                {
                                    rpta2 = true;
                                    break;
                                }
                            }
                            if (rpta2 == true)
                            {
                                cboPeriodoCuota.SelectedValue = Periodo_Id_Seleccionado;
                            }
                            else
                            {
                                cboPeriodoCuota.SelectedIndex = 0;
                            }
                        }
                        dtPeriodoCuota.Dispose();

                        /*Carga Combo de Estados de Pago*/
                        DropDownList cboEstado_Pago = (DropDownList)e.Row.FindControl("cboEstado_Pago");
                        DataTable dtEstado_Pago = new DataTable();
                        dtEstado_Pago = Log_Cuotas_Estado_Pago.Lista_Cuotas_Estado_Pago();
                        cboEstado_Pago.DataSource = dtEstado_Pago;
                        cboEstado_Pago.DataTextField = "Descripcion";
                        cboEstado_Pago.DataValueField = "Cuotas_Estado_Pago_Id";
                        cboEstado_Pago.DataBind();
                        string Estado_Pago_Id;
                        Estado_Pago_Id = grvCuotas2.DataKeys[e.Row.RowIndex].Values["Estado_Pago_Id"].ToString();

                        if (Estado_Pago_Id.Trim() != "" || Estado_Pago_Id != null)
                        {
                            Boolean rpta3 = false;
                            foreach (ListItem list in cboEstado_Pago.Items)
                            {
                                if (Estado_Pago_Id == list.Value.ToString())
                                {
                                    rpta3 = true;
                                    break;
                                }
                            }
                            if (rpta3 == true)
                            {
                                cboEstado_Pago.SelectedValue = Estado_Pago_Id;
                            }
                            else
                            {
                                cboEstado_Pago.SelectedIndex = 0;
                            }
                        }
                        dtEstado_Pago.Dispose();

                    }
                }
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void grvCuotas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvCuotas.EditIndex = -1;
            Lista_Cuotas(hdnCta_Cte_Id.Value);
        }
        protected void grvCuotas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            string Cuota_Id;
            Cuota_Id = grvCuotas.DataKeys[e.RowIndex].Value.ToString();

            Ent_Ctas_Ctes objECtaCte = new Ent_Ctas_Ctes();
            objECtaCte.Cuota_Id = Cuota_Id;

            String dtRpta;
            dtRpta = Log_Ctas_Ctes.Elimina_Cuotas(objECtaCte).ToString();

            string msj_rpta;
            msj_rpta = dtRpta;
            Utils.fc_DisplayAlert(this, msj_rpta);

            Lista_Cuotas(hdnCta_Cte_Id.Value);
            Lista_Cuotas_W(hdnCta_Cte_Id.Value);
            //LimpiaCajasTextoCtaCte();

            //if (msj_rpta.Length > 0)
            //{
            //    hdnCta_Cte_Id.Value = "";
            //    lblCta_Cte.Text = "";
            //}
        }
        protected void grvCuotas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvCuotas.EditIndex = e.NewEditIndex;
            Lista_Cuotas(hdnCta_Cte_Id.Value);
        }
        protected void grvCuotas2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            string Cuota_Id;
            Cuota_Id = grvCuotas2.DataKeys[e.RowIndex].Value.ToString();

            Ent_Ctas_Ctes objECtaCte = new Ent_Ctas_Ctes();
            objECtaCte.Cuota_Id = Cuota_Id;

            String dtRpta;
            dtRpta = Log_Ctas_Ctes.Elimina_Cuotas(objECtaCte).ToString();

            string msj_rpta;
            msj_rpta = dtRpta;
            Utils.fc_DisplayAlert(this, msj_rpta);

            Lista_Cuotas(hdnCta_Cte_Id.Value);
            Lista_Cuotas_W(hdnCta_Cte_Id.Value);
            // LimpiaCajasTextoCtaCte();

            //if (msj_rpta.Length > 0)
            //{
            //    hdnCta_Cte_Id.Value = "";
            //    lblCta_Cte.Text = "";
            //}
        }
    }
}