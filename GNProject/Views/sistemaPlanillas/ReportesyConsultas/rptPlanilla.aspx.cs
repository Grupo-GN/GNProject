using CAPA_DATOS.oRepPlanillaGeneral;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.ReportesyConsultas
{
    public partial class rptPlanilla : System.Web.UI.Page
    {
        [WebMethod]
        public static List<dtPeriodo> Get_Periodo_Combo(string Compania_Id, string Anio, string Planilla_Id)
        {
            return controller_RepPlanillageneral.GetInstance().Get_Periodo_Combo(Compania_Id, Anio, Planilla_Id);
        }
        [WebMethod]
        public static ArrayList SISGNRSReporteGeneralPlanilla(string PlanillaId, string Proceso, string PeriodoIni, string PeriodoFin)
        {
            return controller_RepPlanillageneral.GetInstance().SISGNRSReporteGeneralPlanilla(PlanillaId, Proceso, PeriodoIni, PeriodoFin);
        }
        [WebMethod]
        public static ArrayList SISGNRSReportePrueba()
        {
            return controller_RepPlanillageneral.GetInstance().SISGNRSReportePrueba();
        }
    }
}