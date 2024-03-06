using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presistence;
using BusienssLogic.CA.oPeriodoAsistencia;
using System.Web.Services;
using System.Collections;

namespace GNProject.Views.ControlAsisten.CA.Matenimientos
{
    public partial class MPeriodoAsistencia : System.Web.UI.Page
    {
        [WebMethod]
        public static ArrayList Get_Periodos_List(int inicio)
        {
            return Controller_MantPeriodoAsistencia.GetInstance().Get_Periodos_List();
        }
        [WebMethod]
        public static List<Periodo_Asistencia> Get_PeriodoAsistencia_List(int inicio)
        {
            return Controller_MantPeriodoAsistencia.GetInstance().Get_PeriodoAsistencia_List(inicio);
        }
        [WebMethod]
        public static bool Get_Activos_PorId_Update(int Periodo_Asistencia_Id, bool Estado)
        {
            return Controller_MantPeriodoAsistencia.GetInstance().Get_Activos_PorId_Update(Periodo_Asistencia_Id, Estado);
        }
        [WebMethod]
        public static bool Get_PeriodoAsistencia_Update(int codigo, bool activo)
        {
            return Controller_MantPeriodoAsistencia.GetInstance().Get_PeriodoAsistencia_Update(codigo, activo);
        }
        [WebMethod]
        public static int Get_PeriodoAsistencia_MaxRegistro()
        {
            return Controller_MantPeriodoAsistencia.GetInstance()
                .Get_PeriodoAsistencia_MaxRegistro();
        }
        [WebMethod]
        public static bool Get_PeriodoAsistencia_Delete(int Periodo_Asistencia_Id)
        {
            return Controller_MantPeriodoAsistencia.GetInstance().Get_PeriodoAsistencia_Delete(Periodo_Asistencia_Id);
        }
        [WebMethod]
        public static bool Get_PeriodoAsistencia_Add(DateTime fechainicio2, string periodo, DateTime fechafin2, bool estado)
        {
            return Controller_MantPeriodoAsistencia.GetInstance().Get_PeriodoAsistencia_Add(fechainicio2, periodo, fechafin2, estado);
        }
    }
}