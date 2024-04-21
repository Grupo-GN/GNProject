using CAPA_ENTIDAD;
using CAPA_LOGICO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.Procesos
{
    public partial class FrmAperturaCierrePeriodo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            //if (!Utils.fc_ValidaFiltros(this.Page))
            //{
            //    if (Request.QueryString["block"] == null)
            //        Response.Redirect("~/Default.aspx?block=1");
            //}

            if (!IsPostBack)
            {
                Session["Planilla_Id"] = Utils.fc_obtiene_Planilla_Id(this);
                string namePlani = "";
                if (Session["Planilla_Id"] != null)
                {
                    if (Session["Planilla_Id"].ToString() == "01")
                        namePlani = "Mensual Empleados";
                    else if (Session["Planilla_Id"].ToString() == "04")
                        namePlani = "Mensual Obreros";
                    else if (Session["Planilla_Id"].ToString() == "06")
                        namePlani = "Practicantes";
                }

                //if (Session["Planilla_Id_Nombre"] != null)
                //{
                //lblPlanilla.Text = Session["Planilla_Id_Nombre"].ToString().ToUpper();
                lblPlanilla.Text = namePlani.ToUpper();
                //}
                btn_name_AperturaPeriodo("01", Session["Planilla_Id"].ToString());
                btn_name_CierrePeriodo("01", Session["Planilla_Id"].ToString());
                btnActualizarAcum.Text = "Actualizar Acumulados";
                btnConfigAsientos.Text = "Generar Configuración de Asientos " + Utils.fc_obtiene_Ejercicio_Id(this).ToString();
                if (Session["NamePeriodo_Id"] != null)
                {
                    btnActualizarAcum.Text = "Actualizar Acumulados en " + Session["NamePeriodo_Id"].ToString();
                    btnLimpiarPeriodo.Text = "Limpiar Periodo " + Session["NamePeriodo_Id"].ToString();
                    btnLimpiarPeriodo.Attributes.Add("onclick", "return confirm('Está Apunto de Borrar Toda La Información del Periodo " + Session["NamePeriodo_Id"].ToString() + "\\n¿Está Seguro de Continuar?');");
                }

                if (Request.QueryString["msj"] != null && Page.IsPostBack == false) /*Si tiene Valor y es la primera vez que ingresa a la página*/
                {
                    string msj;
                    msj = Request.QueryString["msj"].ToString();
                    Utils.fc_DisplayAlert(this, msj);
                }
            }
        }

        void btn_name_AperturaPeriodo(string compania_Id, string planilla_Id)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            DataTable dt = new DataTable();
            dt = Log_AperturaCierrePeriodo.btn_name_AperturaPeriodo(compania_Id, planilla_Id);
            if (dt.Rows.Count > 0)
            {
                hdPeriodoApertura.Value = dt.Rows[0]["Periodo_Id"].ToString();
                btnApertura.Text = "Apertura de " + dt.Rows[0]["Periodo"].ToString() + " " + dt.Rows[0]["Rango"].ToString();
            }
        }

        void btn_name_CierrePeriodo(string compania_Id, string planilla_Id)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            DataTable dt = new DataTable();
            dt = Log_AperturaCierrePeriodo.btn_name_CierrePeriodo(compania_Id, planilla_Id);
            if (dt.Rows.Count > 0)
            {
                hdPeriodoCierre.Value = dt.Rows[0]["Periodo_Id"].ToString();
                btnCierre.Text = "Cierre de " + dt.Rows[0]["Periodo"].ToString() + " " + dt.Rows[0]["Rango"].ToString();
            }
        }

        protected void btnApertura_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            //try
            //{
            Ent_Periodo objEPeriodo = new Ent_Periodo();
            objEPeriodo.Periodo_Id = hdPeriodoApertura.Value;

            string dtRpta = Log_AperturaCierrePeriodo.Apertura_Periodo(objEPeriodo);
            if (dtRpta.Split('#')[0] == "true")
            {
                Response.Redirect("FrmAperturaCierrePeriodo.aspx?msj=Periodo Aperturado con Exito");
            }
            else
            {
                Utils.fc_DisplayAlert(this, dtRpta.Split('#')[1].ToString());
            }
            //}
            //catch (Exception ex)
            //{
            //    Utils.fc_DisplayAlert(this, "Error al Procesar: " + ex.Message);
            //}        
        }

        protected void btnCierre_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                Ent_Periodo objEPeriodo = new Ent_Periodo();
                objEPeriodo.Periodo_Id = hdPeriodoCierre.Value;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_AperturaCierrePeriodo.Cierre_Periodo(objEPeriodo);
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) == 1)
                {
                    Response.Redirect("FrmAperturaCierrePeriodo.aspx?msj=Cierre de Periodo con Exito");
                }
                else
                {
                    Utils.fc_DisplayAlert(this, "No Se Proceso Correctamente.");
                }
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, "Error al Procesar: " + ex.Message);
            }
        }

        protected void btnActualizarAcum_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            string Periodo_Id = "";
            Periodo_Id = Utils.fc_obtiene_Periodo_Id(this);
            Log_AperturaCierrePeriodo.ActualizarAcumulados(Periodo_Id);
            Utils.fc_DisplayAlert(this, "Acumulados Actualizados Correctamente.");
        }

        protected void btnLimpiarPeriodo_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                Ent_Periodo objEPeriodo = new Ent_Periodo();
                objEPeriodo.Periodo_Id = Utils.fc_obtiene_Periodo_Id(this);
                DataTable dtRpta = new DataTable();
                dtRpta = Log_AperturaCierrePeriodo.Limpiar_Periodo(objEPeriodo);
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) == 1)
                {
                    Response.Redirect("FrmAperturaCierrePeriodo.aspx?msj=Se Borro Correctamente el Periodo");
                }
                else if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) == 0)
                {
                    Utils.fc_DisplayAlert(this, "El Periodo se encuentra en estado CERRADO.");
                }
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, "Error al Procesar: " + ex.Message);
            }

        }


        protected void btnConfigAsientos_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string planilla = Utils.fc_obtiene_Planilla_Id(this).ToString(), ejercicio = Utils.fc_obtiene_Ejercicio_Id(this).ToString();
                string resultado = Log_AperturaCierrePeriodo.GenerarConfiguracionAsientos(planilla, ejercicio);
                string mensaje = resultado.Split('#')[1];
                Utils.fc_DisplayAlert(this, mensaje);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, "Error al Procesar: " + ex.Message);
            }
        }
    }
}