using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presistence;
using BusienssLogic.CA.oAsignarHorarioMasivo;
using System.Web.Services;
using System.Collections;

namespace GNProject.Views.ControlAsisten.CA.Matenimientos
{
    public partial class MAsignarHorarioMasivo : System.Web.UI.Page
    {
        [WebMethod]
        public static ArrayList Get_Planillas_List(int inicio)
        {
            return Controller_MantAsignarHorarioMasivo.GetInstance().Get_Planillas_List();
        }
        [WebMethod]
        public static ArrayList Get_Localidades_List(string Personal_Id)
        {
            return Controller_MantAsignarHorarioMasivo.GetInstance().Get_Localidades_List(Personal_Id);
        }
        // 01.10.2020
        [WebMethod]
        public static List<RH_Area> Get_Localidades_List_2(string Personal_Id)
        {
            return Controller_MantAsignarHorarioMasivo.GetInstance().Get_Localidades_List_2(Personal_Id);
        }
        //antiguo
        [WebMethod]
        public static List<areas_planillas_sofya> Get_Localidades_List_OLD(string Personal_Id)
        {
            return Controller_MantAsignarHorarioMasivo.GetInstance().Get_Localidades_List_OLD(Personal_Id);
        }
        [WebMethod]
        public static ArrayList Get_Periodos_List(string Planilla)
        {
            return Controller_MantAsignarHorarioMasivo.GetInstance().Get_Periodos_List(Planilla);
        }
        [WebMethod]
        public static ArrayList Get_Areas_List(int inicio)
        {
            return Controller_MantAsignarHorarioMasivo.GetInstance().Get_Areas_List();
        }

        [WebMethod]
        public static ArrayList Get_AsignarHorarioMasivo_List(string Periodo_id, string seccion, string area_id, int inicio, string Jefe_Id)
        {
            return Controller_MantAsignarHorarioMasivo.GetInstance().Get_AsignarHorarioMasivo_List(Periodo_id, seccion, area_id, inicio, Jefe_Id);
        }

        [WebMethod]
        public static ArrayList Get_AsignarHorarioMasivo_ListAdmin(string Periodo_id, string seccion, string area_id, int inicio, string Jefe_Id)
        {
            return Controller_MantAsignarHorarioMasivo.GetInstance().Get_AsignarHorarioMasivo_ListAdmin(Periodo_id, seccion, area_id, inicio, Jefe_Id);
        }

        [WebMethod]
        public static bool Get_AsignarHorarioMasivo_Update(int idHorario, string idcknum)
        {
            return Controller_MantAsignarHorarioMasivo.GetInstance().Get_AsignarHorarioMasivo_Update(idHorario, idcknum);
        }

        [WebMethod]
        public static int Get_AsignarHorarioMasivo_MaximoRegistros()
        {
            return Controller_MantAsignarHorarioMasivo.GetInstance()
                .Get_AsignarHorarioMasivo_MaximoRegistros();
        }

        [WebMethod]
        public static bool Get_AsignarHorarioMasivo_Add(string localidad, string seccion, string nombres, string horarios)
        {
            return Controller_MantAsignarHorarioMasivo.GetInstance().Get_AsignarHorarioMasivo_Add(localidad, seccion, nombres, horarios);
        }

        [WebMethod]
        public static Personal Get_AsignarHorarioMasivo_Find(string codigo)
        {
            return Controller_MantAsignarHorarioMasivo.GetInstance().Get_AsignarHorarioMasivo_Find(codigo);
        }
        [WebMethod]
        public static ArrayList Get_Horarios_List(int inicio)
        {
            return Controller_MantAsignarHorarioMasivo.GetInstance().Get_Horarios_List();
        }
        //2
        [WebMethod]
        public static List<Horarios_Detalle> Get_DetalleHorarios_List(int Horario_Id)
        {
            return Controller_MantAsignarHorarioMasivo.GetInstance().Get_DetalleHorarios_List(Horario_Id);
        }
        //2
        [WebMethod]
        public static bool Get_DetalleHorarios_Add(DateTime HoraInicio, DateTime HoraInicioRefrigerio, DateTime HoraFinRefrigerio, DateTime HoraFin)
        {
            return Controller_MantAsignarHorarioMasivo.GetInstance().Get_DetalleHorarios_Add(HoraInicio, HoraInicioRefrigerio, HoraFinRefrigerio, HoraFin);
        }



        [WebMethod]
        public static bool Get_AsignarHorarioMasivo_UpdateHorario(string Personal_Id, int newHorario_Id)
        {
            return Controller_MantAsignarHorarioMasivo.GetInstance()
                .Get_AsignarHorarioMasivo_UpdateHorario(Personal_Id, newHorario_Id);
        }

    }
}