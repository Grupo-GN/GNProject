using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusienssLogic.CA.oAsignarHorarioPersona;
using BusienssLogic.CA.oPasarPlanilla;
using BusienssLogic.CA.oRegistrarMarcaciones;
using Presistence;
using System.Collections;
using System.Web.Services;
using static BusienssLogic.CA.oRegistrarMarcaciones.Controller_RegistrarMarcaciones;


namespace GNProject.Views.ControlAsisten.CA.Matenimientos
{
    public partial class CAImportarMarcaciones : System.Web.UI.Page
    {
        [WebMethod]
        public static List<BusienssLogic.ServRef_Marcaciones.eMarcacion> ImportarMarcaciones(string i_FechaIni, string i_FechaFin, string i_Personal)
        {
            return Controller_RegistrarMarcaciones.GetInstance().ImportarMarcaciones(DateTime.Parse(i_FechaIni), DateTime.Parse(i_FechaFin), i_Personal);
        }
        [WebMethod]
        public static List<MarcasN> ImportarMarcaciones2(string i_FechaIni, string i_FechaFin, string i_Personal)
        {
            return Controller_RegistrarMarcaciones.GetInstance().ImportarMarcaciones2(DateTime.Parse(i_FechaIni), DateTime.Parse(i_FechaFin), i_Personal);
        }

        //[WebMethod]
        //public static string ImportarMarcaciones(string i_FechaIni, string i_FechaFin, string i_Personal)
        //{
        //    try
        //    {
        //        List<BusienssLogic.ServRef_Marcaciones.eMarcacion> rlire = new List<BusienssLogic.ServRef_Marcaciones.eMarcacion>();
        //        rlire = Controller_RegistrarMarcaciones.GetInstance().ImportarMarcaciones(DateTime.Parse(i_FechaIni), DateTime.Parse(i_FechaFin), i_Personal);
        //        return "pasooooo";
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message + " " + ex.InnerException.Message + " " + ex.InnerException.ToString();
        //    }
        //}
        [WebMethod]
        public static Periodo_Asistencia Get_Periodo_Asistencia_List()
        {
            return Controller_RegistrarMarcaciones.GetInstance().Get_Periodo_Asistencia_List();
        }


        //PROCESAR MARCACIONES
        [WebMethod]
        public static List<string> RegistrarMarcaciones(List<string> i_list)
        {
            return Controller_RegistrarMarcaciones.GetInstance().RegistrarMarcaciones(i_list);
        }


        [WebMethod]
        public static ArrayList Get_Planilla_List()
        {
            return controller_PasarPlanilla.Get_Instance().Get_Planilla_List();
        }
        [WebMethod]
        public static ArrayList Get_Periodo_List(string Planilla_Id, string Fecha)
        {
            DateTime nfecha = DateTime.Parse(Fecha);
            return Controller_RegistrarMarcaciones.GetInstance().Get_Periodo_List(Planilla_Id, nfecha);
        }
        [WebMethod]
        //nueva
        public static ArrayList Get_Localidad_List()
        {
            //return controller_PasarPlanilla.Get_Instance().Get_Localidad_List();
            return Controller_MantAsignarHorarioPersona.GetInstance().Get_Localidades_List();
        }
        //antigua
        [WebMethod]

        public static List<areas_planillas_sofya> Get_Localidad_List_OLD()
        {
            return controller_PasarPlanilla.Get_Instance().Get_Localidad_List_OLD();
        }
        [WebMethod]
        public static ArrayList Get_Categoria_List()
        {
            return controller_PasarPlanilla.Get_Instance().Get_Categoria_List();
        }
        [WebMethod]
        public static ArrayList Get_CategoriaAux_List()
        {
            return controller_PasarPlanilla.Get_Instance().Get_CategoriaAux_List();
        }
        [WebMethod]
        public static ArrayList Get_Personal_List(string Periodo_Id, string Localidad_Id, string CateAux, string Categoria)
        {
            return controller_PasarPlanilla.Get_Instance().Get_Personal_List(Periodo_Id, Localidad_Id, CateAux, Categoria);
        }
    }
}