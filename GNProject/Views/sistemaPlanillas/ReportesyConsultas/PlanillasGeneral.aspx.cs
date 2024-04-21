using CAPA_ENTIDAD;
using CAPA_LOGICO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.ReportesyConsultas
{
    public partial class PlanillasGeneral : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string compania = "01";
                string planillaId;
                string ejercicio;

                if (Session["Planilla_Id"] != null)
                    planillaId = Session["Planilla_Id"].ToString();
                else
                    planillaId = Utils.fc_obtiene_Planilla_Id(this);

                if (Session["Ejercicio_Id"] != null)
                    ejercicio = Session["Ejercicio_Id"].ToString();
                else
                    ejercicio = Utils.fc_obtiene_Ejercicio_Id(this);

                LlenarPeriodo(compania, ejercicio, planillaId);

            }
        }


        public object GetEval(object cadena)
        {
            if (cadena == null)
                return "PERIODO";
            else
                return "NOMPERIODO";
        }

        private void cargarPlanillas(GridView gv, string reporte, string personal, string periodo,
            string proceso, string personalId)
        {
            CAPA_DATOS.ControllerPlanillaGeneral pla = new CAPA_DATOS.ControllerPlanillaGeneral();
            gv.DataSource = pla.Get_ExportacionPlanilas_General_Ms(reporte,
                personal, periodo, proceso, personalId);
            gv.DataBind();
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            string proceso = "01";
            string personalId = "%";
            string personal = "000583";
            //string periodo = Utils.fc_obtiene_Periodo_Id(this);
            string periodo = cboPeriodoInicial.SelectedValue;
            Func<string, string> Get_ObtieneProceso = (a) => {
                string retorno = "";
                if (a == "04")   //Planilla Gratificcion
                    retorno = "0010";
                if (a == "05")   // Planilla Cts
                    retorno = "0008";
                if (a == "03")   // Planilla Vacacion
                    retorno = "0009";
                if (a == "02")   // Planilla Quincena
                    retorno = "0007";
                if (a == "01")       //Planilla General
                    retorno = "0001";
                return retorno;
            };

            string reporte = Get_ObtieneProceso(cboProceso.SelectedValue);

            if (cboProceso.SelectedValue == "01")
            {//General
                cargarPlanillas(gvPlanillaGeneral, reporte, personal, periodo, proceso, personalId);
                anulaGrilla(GrvPlanillaVacacion); anulaGrilla(GrvPlanillaGrati);
                anulaGrilla(GrvPlanillaQuincena); anulaGrilla(GrvPlanillaCTS);
                enableButonExportar(gvPlanillaGeneral);
            }
            else if (cboProceso.SelectedValue == "02")
            { //Kincena
                cargarPlanillas(GrvPlanillaQuincena, reporte, personal, periodo, proceso, personalId);
                anulaGrilla(gvPlanillaGeneral); anulaGrilla(GrvPlanillaVacacion);
                anulaGrilla(GrvPlanillaGrati); anulaGrilla(GrvPlanillaCTS);
                enableButonExportar(GrvPlanillaQuincena);
            }
            else if (cboProceso.SelectedValue == "03")
            { //Vacacion
                cargarPlanillas(GrvPlanillaVacacion, reporte, personal, periodo, proceso, personalId);
                anulaGrilla(gvPlanillaGeneral); anulaGrilla(GrvPlanillaGrati);
                anulaGrilla(GrvPlanillaQuincena); anulaGrilla(GrvPlanillaCTS);
                enableButonExportar(GrvPlanillaVacacion);
            }
            else if (cboProceso.SelectedValue == "04")
            {//Gratificacion
                cargarPlanillas(GrvPlanillaGrati, reporte, personal, periodo, proceso, personalId);
                anulaGrilla(gvPlanillaGeneral); anulaGrilla(GrvPlanillaVacacion);
                anulaGrilla(GrvPlanillaQuincena); anulaGrilla(GrvPlanillaCTS);
                enableButonExportar(GrvPlanillaGrati);
            }
            else if (cboProceso.SelectedValue == "05")
            { //cts
                cargarPlanillas(GrvPlanillaCTS, reporte, personal, periodo, proceso, personalId);
                anulaGrilla(gvPlanillaGeneral); anulaGrilla(GrvPlanillaVacacion);
                anulaGrilla(GrvPlanillaQuincena); anulaGrilla(GrvPlanillaGrati);
                enableButonExportar(GrvPlanillaCTS);
            }
            btnExportar.Enabled = true;
        }

        private void anulaGrilla(GridView gvr)
        {
            gvr.DataSource = null;
            gvr.DataBind();
        }

        private void enableButonExportar(GridView gv)
        {
            if (gv.Rows.Count > 0)
            {
                btnExportar.Enabled = true;
            }
            else
            {
                btnExportar.Enabled = false;
            }
        }

        private void LlenarPeriodo(String Compania_Id, String Ejercicio_Id, String Planilla_Id)
        {
            Ent_Periodo objEPeriodo = new Ent_Periodo();
            objEPeriodo.Compania_Id = Compania_Id;
            objEPeriodo.Ejercicio_Id = Ejercicio_Id;
            objEPeriodo.Planilla_Id = Planilla_Id;
            objEPeriodo.Estado_Id = "02";

            cboPeriodoInicial.DataSource = Log_Periodo.Lista_Periodo(objEPeriodo);
            cboPeriodoInicial.DataTextField = "Descripcion";
            cboPeriodoInicial.DataValueField = "Periodo_Id";
            cboPeriodoInicial.DataBind();
            cboPeriodoInicial.SelectedIndex = cboPeriodoInicial.Items.Count - 1;

        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            if (cboProceso.SelectedValue == "01")
                exportaExcel_n1(gvPlanillaGeneral);
            else if (cboProceso.SelectedValue == "02")
                exportaExcel_n1(GrvPlanillaQuincena);
            else if (cboProceso.SelectedValue == "03")
                exportaExcel_n1(GrvPlanillaVacacion);
            else if (cboProceso.SelectedValue == "04")
                exportaExcel_n1(GrvPlanillaGrati);
            else if (cboProceso.SelectedValue == "05")
                exportaExcel_n1(GrvPlanillaCTS);
        }

        #region exportarExcel
        void exportaExcel_n1(GridView migv)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            Page page = new Page();
            HtmlForm form = new HtmlForm();

            migv.EnableViewState = false;

            //// Deshabilitar la validación de eventos, sólo asp.net 2
            page.EnableEventValidation = false;

            //// Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
            page.DesignerInitialize();

            page.Controls.Add(form);
            form.Controls.Add(migv);

            page.RenderControl(htw);

            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=Planillas.xls");
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            Response.Write(sb.ToString());
            Response.End();

        }
        #endregion

        protected void elLink_Click(object sender, EventArgs e)
        {
            string compania = "01";
            string planillaId;
            string ejercicio;
            if (Session["Planilla_Id"] != null)
                planillaId = Session["Planilla_Id"].ToString();
            else
                planillaId = Utils.fc_obtiene_Planilla_Id(this);

            if (Session["Ejercicio_Id"] != null)
                ejercicio = Session["Ejercicio_Id"].ToString();
            else
                ejercicio = Utils.fc_obtiene_Ejercicio_Id(this);

            LlenarPeriodo(compania, ejercicio, planillaId);
        }
    }
}