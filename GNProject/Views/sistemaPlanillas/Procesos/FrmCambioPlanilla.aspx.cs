using CAPA_DATOS;
using CAPA_ENTIDAD.EntMs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.Procesos
{
    public partial class FrmCambioPlanilla : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //GET COLUMNAS FILTRO PERSONAL
        [WebMethod]
        public static ArrayList ListaColumnPersonal()
        {
            return ControllerMaestroPersonal.GetInstance().ListaColumnPersonal();
        }
        //GET PERSONAL X FILTRO
        //public static List<ListaPersonal> Lista_Personal_x_Filtro_Columna(string Compania_Id, string Periodo_Id, string NomColumna, string Param, int inicio)
        //{
        //    return ControllerMaestroPersonal.GetInstance().Lista_Personal_x_Filtro_Columna(Compania_Id, Periodo_Id, NomColumna, Param, inicio);
        //}
        [WebMethod]
        public static object Lista_Personal_x_Filtro_Columna(string Compania_Id, string Periodo_Id, string NomColumna, string Param, int inicio)
        {
            //return ControllerMaestroPersonal.GetInstance().Lista_Personal_x_Filtro_Columna(Compania_Id,Periodo_Id,NomColumna,Param,inicio);
            Int32 qt_registros;
            List<ListaPersonal> oBandeja = ControllerMaestroPersonal.GetInstance().Lista_Personal_x_Filtro_Columna(Compania_Id, Periodo_Id, NomColumna, Param, inicio, out qt_registros);
            object response = new { oBandeja = oBandeja, qt_registros = qt_registros };
            return response;
        }
        //GET  MAX ROWS
        [WebMethod]
        public static int Lista_Personal_x_Filtro_Columna_MaxRows(string Compania_Id, string Periodo_Id, string NomColumna, string Param)
        {
            return ControllerMaestroPersonal.GetInstance().Lista_Personal_x_Filtro_Columna_MaxRows(Compania_Id, Periodo_Id, NomColumna, Param);
        }

        //PERIODOS
        [WebMethod]
        public static ArrayList ListaTipoPlanilla()
        {
            return controller_CambiarPlanilla.getInstance().ListaTipoPlanilla();
        }
        [WebMethod]
        public static ArrayList ListaEjercicio()
        {
            return controller_CambiarPlanilla.getInstance().ListaEjercicio();
        }
        [WebMethod]
        public static ArrayList ListaMes(string EjercicioId)
        {
            return controller_CambiarPlanilla.getInstance().ListaMes(EjercicioId);
        }
        [WebMethod]
        public static ArrayList ListaPeriodo(string EjercicioId, string Planilla_Id, string MesId)
        {
            return controller_CambiarPlanilla.getInstance().ListaPeriodo(EjercicioId, Planilla_Id, MesId);
        }

        //Listado
        [WebMethod]
        public static ArrayList ListaPersonalCambioPlanilla(string[] PersonalId)
        {
            return controller_CambiarPlanilla.getInstance().ListaPersonalCambioPlanilla(PersonalId);
        }
        [WebMethod]
        public static string ProcesarCambioPlanilla(string PersonalId, string PlanillaIdAct, string PlanillaIdNew, string PeriodoIdAct, string PeriodoIdNew)
        {
            return controller_CambiarPlanilla.getInstance().ProcesarCambioPlanilla(PersonalId, PlanillaIdAct, PlanillaIdNew, PeriodoIdAct, PeriodoIdNew);
        }
    }
}