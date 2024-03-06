using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using BusienssLogic.CA.oReporteGeneral;
using static BusienssLogic.CA.oReporteGeneral.ControllerReporteAsistenciaDiario;
using static BusienssLogic.CA.oParametros.Controller_MantParametroxConcepto;
using BusienssLogic.CA.oParametros;


namespace GNProject.Views.ControlAsisten.CA.caReporteGeneral
{
    public partial class CaReporteDiario : System.Web.UI.Page
    {
        [WebMethod]
        public static List<ReporteDiario> ListaReporteDiario(string Planilla_Id, string Periodo_Id, string Localidad_Id, string[] Personal_Id)
        {
            return ControllerReporteAsistenciaDiario.Get_Instance().ListaReporteDiario(Planilla_Id, Periodo_Id, Localidad_Id, Personal_Id);
        }
        [WebMethod]
        public static List<ReporteDiario> ListaReporteDiario2(string Planilla_Id, string Periodo_Id, string Localidad_Id, string[] Personal_Id, string FechaIni, string FechaFin)
        {
            return ControllerReporteAsistenciaDiario.Get_Instance().ListaReporteDiario2(Planilla_Id, Periodo_Id, Localidad_Id, Personal_Id, FechaIni, FechaFin);
        }
        [WebMethod]
        public static List<qsemana> ListaSemana()
        {
            return Controller_MantParametroxConcepto.GetInstance().ListaSemana();
        }
    }
}