using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presistence;
using BusienssLogic.CA.oAsignarTurnoMasivos;
using System.Web.Services;
using System.Collections;

namespace GNProject.Views.ControlAsisten.CA.Matenimientos
{
    public partial class MAsignarTurnoMasivos : System.Web.UI.Page
    {
        [WebMethod]
        public static ArrayList Get_Planillas_List(int inicio)
        {
            return Controller_MantAsignarTurnoMasivos.GetInstance().Get_Planillas_List();
        }
        //nuevo 1.10.2020
        [WebMethod]
        public static ArrayList Get_Localidades_List(string Personal_Id)
        {
            return Controller_MantAsignarTurnoMasivos.GetInstance().Get_Localidades_List(Personal_Id);
        }

        //antiguo
        [WebMethod]
        public static List<areas_planillas_sofya> Get_Localidades_List_02(string Personal_Id)
        {
            return Controller_MantAsignarTurnoMasivos.GetInstance().Get_Localidades_List_02(Personal_Id);
        }
        [WebMethod]
        public static ArrayList Get_Periodos_List(string Planilla)
        {
            return Controller_MantAsignarTurnoMasivos.GetInstance().Get_Periodos_List(Planilla);
        }
        [WebMethod]
        public static ArrayList Get_Areas_List(int inicio)
        {
            return Controller_MantAsignarTurnoMasivos.GetInstance().Get_Areas_List();
        }

        [WebMethod]
        public static ArrayList Get_AsignarTurnoMasivos_List(string Periodo_id, string seccion, string area_id, int inicio, string Personal_Id, string Jefe_Id)
        {
            Personal_Id = "000000";
            Jefe_Id = "000000";
            return Controller_MantAsignarTurnoMasivos.GetInstance().Get_AsignarTurnoMasivos_List(Periodo_id, seccion, area_id, inicio, Personal_Id, Jefe_Id);
        }
        [WebMethod]
        public static ArrayList Get_TurnoAsignar_List(int inicio)
        {
            return Controller_MantAsignarTurnoMasivos.GetInstance().Get_TurnoAsignar_List();
        }

        [WebMethod]
        public static List<Turnos> Get_TurnoAsignarLabel_List(int Turno_id)
        {
            return Controller_MantAsignarTurnoMasivos.GetInstance().Get_TurnoAsignarLabel_List(Turno_id);
        }
        [WebMethod]
        public static string Get_TurnoAsignar_Proceso(string Personal, int turno, int cant, string fechaini, string fechafin, int alter, int dias)
        {
            return Controller_MantAsignarTurnoMasivos.GetInstance().Get_TurnoAsignar_Proceso(Personal, turno, cant, fechaini, fechafin, alter, dias);
        }
    }
}