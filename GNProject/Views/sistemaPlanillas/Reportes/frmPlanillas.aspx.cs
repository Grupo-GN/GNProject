using CAPA_LOGICO;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.Reportes
{
    public partial class frmPlanillas : System.Web.UI.Page
    {
        ReportDocument rptSource;
        protected void Page_Load(object sender, EventArgs e)
        {

            string tipoReporte = Request.QueryString["Reporte_Id"].ToString();
            string periodo = Request.QueryString["Periodo_Id"].ToString();
            string personal = Request.QueryString["Personal_Id"].ToString();

            //  string tipoReporte = "0010";

            DataTable tabla = new DataTable();
            if (tipoReporte == "0010")
                tabla = Log_Reportes.Lista_rpt_Reportes("0010", "000138", periodo, "01", "%"); //Gratificacion
            else if (tipoReporte == "0007")
                tabla = Log_Reportes.Lista_rpt_Reportes("0007", "000138", periodo, "01", "%"); //Kincena
            else if (tipoReporte == "0001")
                tabla = Log_Reportes.Lista_rpt_Reportes("0001", "000138", periodo, "01", "%"); //General
            else if (tipoReporte == "0008")
                tabla = Log_Reportes.Lista_rpt_Reportes("0008", "000138", periodo, "01", "%"); //Cts

            //tabla = Log_Reportes.Lista_rpt_Reportes("0009", "000138", "0140", "01", "%"); //vacaciones

            rptSource = new ReportDocument();
            rptSource.Load(Server.MapPath(GetNameReporte(tipoReporte)));

            rptSource.SetDatabaseLogon("", "", ".", "SISGNRS_WEB_LG3");
            rptSource.SetDataSource(tabla);
            rpt.DisplayGroupTree = false;
            rpt.ReportSource = rptSource;
            rpt.Visible = true;
            //rpt.Dispose();

        }


        Func<string, string> GetNameReporte = (a) =>
        {
            string retorno = "";
            if (a.Equals("0010"))
                retorno = "Planilla_Gratificacion2.rpt";
            else if (a.Equals("0007"))
                retorno = "Planilla_Quincena2.rpt";
            else if (a.Equals("0001"))
                retorno = "Planilla_General.rpt";
            else if (a.Equals("0008"))
                retorno = "Planilla_CTS2.rpt";
            return retorno;
        };
    }
}