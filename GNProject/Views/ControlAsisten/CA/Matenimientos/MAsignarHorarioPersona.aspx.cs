using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presistence;
using BusienssLogic.CA.oAsignarHorarioPersona;
using System.Web.Services;
using System.Collections;

namespace GNProject.Views.ControlAsisten.CA.Matenimientos
{
    public partial class MAsignarHorarioPersona : System.Web.UI.Page
    {
        [WebMethod]
        public static ArrayList Get_Planillas_List(int inicio)
        {
            return Controller_MantAsignarHorarioPersona.GetInstance().Get_Planillas_List();
        }
        [WebMethod]
        public static ArrayList Get_Localidades_List(int inicio)
        {
            return Controller_MantAsignarHorarioPersona.GetInstance().Get_Localidades_List();
        }
        [WebMethod]
        public static ArrayList Get_Periodos_List(string Planilla)
        {
            return Controller_MantAsignarHorarioPersona.GetInstance().Get_Periodos_List(Planilla);
        }
        [WebMethod]
        public static ArrayList Get_Areas_List(int inicio)
        {
            return Controller_MantAsignarHorarioPersona.GetInstance().Get_Areas_List();
        }

        [WebMethod]
        public static ArrayList Get_AsignarHorarioPersonas_List(string Periodo_id, string seccion, string area_id, int inicio)
        {
            return Controller_MantAsignarHorarioPersona.GetInstance().Get_AsignarHorarioPersonas_List(Periodo_id, seccion, area_id, inicio);
        }
        [WebMethod]
        public static int Get_AsignarHorarioPersonas_MaxRegistro(string Periodo_id, string seccion, string area_id)
        {
            return Controller_MantAsignarHorarioPersona.GetInstance().Get_AsignarHorarioPersonas_MaxRegistro(Periodo_id, seccion, area_id);
        }
        [WebMethod]
        public static bool Get_AsignarHorarioPersonas_Update(string Personal_Id, int Horario_Id)
        {
            return Controller_MantAsignarHorarioPersona.GetInstance().Get_AsignarHorarioPersonas_Update(Personal_Id, Horario_Id);
        }

        [WebMethod]
        public static int Get_AsignarHorarioPersonas_MaximoRegistros()
        {
            return Controller_MantAsignarHorarioPersona.GetInstance()
                .Get_AsignarHorarioPersonas_MaximoRegistros();
        }

        [WebMethod]
        public static bool Get_AsignarHorarioPersonas_Add(string localidad, string seccion, string nombres, string horarios)
        {
            return Controller_MantAsignarHorarioPersona.GetInstance().Get_AsignarHorarioPersonas_Add(localidad, seccion, nombres, horarios);
        }

        [WebMethod]
        public static string Get_AsignarHorarioPersonas_Find(string codigo)
        {
            return Controller_MantAsignarHorarioPersona.GetInstance().Get_AsignarHorarioPersonas_Find(codigo);
        }
        [WebMethod]
        public static ArrayList Get_Horarios_List(int inicio)
        {
            return Controller_MantAsignarHorarioPersona.GetInstance().Get_Horarios_List();
        }
    }
}