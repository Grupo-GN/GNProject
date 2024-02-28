using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presistence;
using BusienssLogic.CA.oAsignarTurnoPersona;
using System.Web.Services;
using System.Collections;

namespace GNProject.Views.ControlAsisten.CA.Matenimientos
{
    public partial class MAsignarTurnoPersona : System.Web.UI.Page
    {

        [WebMethod]
        public static ArrayList Get_Planillas_List(int inicio)
        {
            return Controller_MantAsignarTurnoPersona.GetInstance().Get_Planillas_List();
        }
        [WebMethod]
        public static ArrayList Get_Localidades_List(int inicio)
        {
            return Controller_MantAsignarTurnoPersona.GetInstance().Get_Localidades_List();
        }
        [WebMethod]
        public static ArrayList Get_Periodos_List(string Planilla)
        {
            return Controller_MantAsignarTurnoPersona.GetInstance().Get_Periodos_List(Planilla);
        }
        [WebMethod]
        public static ArrayList Get_Areas_List(int inicio)
        {
            return Controller_MantAsignarTurnoPersona.GetInstance().Get_Areas_List();
        }

        [WebMethod]
        public static ArrayList Get_AsignarTurnoPersonas_List(string Periodo_id, string seccion, string area_id, int inicio)
        {
            return Controller_MantAsignarTurnoPersona.GetInstance().Get_AsignarTurnoPersonas_List(Periodo_id, seccion, area_id, inicio);
        }

        [WebMethod]
        public static bool Get_AsignarTurnoPersonas_Update(string codigo, string localidad, string seccion, string nombres, string horarios)
        {
            return Controller_MantAsignarTurnoPersona.GetInstance().Get_AsignarTurnoPersonas_Update(codigo, localidad, seccion, nombres, horarios);
        }

        [WebMethod]
        public static int Get_AsignarTurnoPersonas_MaximoRegistros()
        {
            return Controller_MantAsignarTurnoPersona.GetInstance()
                .Get_AsignarTurnoPersonas_MaximoRegistros();
        }

        [WebMethod]
        public static bool Get_AsignarTurnoPersonas_Add(string localidad, string seccion, string nombres, string horarios)
        {
            return Controller_MantAsignarTurnoPersona.GetInstance().Get_AsignarTurnoPersonas_Add(localidad, seccion, nombres, horarios);
        }

        [WebMethod]
        public static Personal Get_AsignarTurnoPersonas_Find(string codigo)
        {
            return Controller_MantAsignarTurnoPersona.GetInstance().Get_AsignarTurnoPersonas_Find(codigo);
        }
        [WebMethod]
        public static ArrayList Get_Personal_List(int inicio)
        {
            return Controller_MantAsignarTurnoPersona.GetInstance().Get_Personal_List(inicio);
        }
        [WebMethod]
        public static ArrayList Get_Periodos2_List(string Planilla)
        {
            return Controller_MantAsignarTurnoPersona.GetInstance().Get_Periodos2_List(Planilla);
        }

    }
}