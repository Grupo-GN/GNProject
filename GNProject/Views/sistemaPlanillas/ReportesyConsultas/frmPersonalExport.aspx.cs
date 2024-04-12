using CAPA_DATOS.oFormulas;
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
    public partial class frmPersonalExport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static ArrayList ListaPlanilla()
        {
            return controller_RepGeneral.Get_Instance().ListaPlanilla();
        }
        [WebMethod]
        public static ArrayList ListaEjercicio()
        {
            return controller_RepGeneral.Get_Instance().ListaEjercicio();
        }
        [WebMethod]
        public static ArrayList ListaArea()
        {
            return controller_RepGeneral.Get_Instance().ListaArea();
        }
        [WebMethod]
        public static ArrayList ListaCatAuxiliar()
        {
            return controller_RepGeneral.Get_Instance().ListaCatAuxiliar();
        }
        [WebMethod]
        public static ArrayList Get_Periodo_Combo(string Compania_Id, string Anio, string Planilla_Id)
        {
            return controller_RepGeneral.Get_Instance().Get_Periodo_Combo(Compania_Id, Anio, Planilla_Id);
        }

        [WebMethod]
        public static ArrayList ListaPersonalActivoReporteGeneral(string PlanillaId, string PeriodoIni, string PeriodoFin)
        {
            return controller_RepGeneral.Get_Instance().ListaPersonalActivoReporteGeneral(PlanillaId, PeriodoIni, PeriodoFin);
        }
    }
}