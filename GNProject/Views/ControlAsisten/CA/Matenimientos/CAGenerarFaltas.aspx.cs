using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Collections;
using BusienssLogic.CA.oAsignarHorarioPersona;
using BusienssLogic.CA.oAsignarCodigo;
using BusienssLogic.CA.oGenerarFaltas;
using Presistence;
using System.Data;
using BusienssLogic.CA.oFiltros;

namespace GNProject.Views.ControlAsisten.CA.Matenimientos
{
    public partial class CAGenerarFaltas : System.Web.UI.Page
    {
        [WebMethod]
        public static ArrayList Get_Planillas_List()
        {
            return Controller_MantAsignarHorarioPersona.GetInstance().Get_Planillas_List();
        }
        [WebMethod]
        public static ArrayList Get_Localidades_List()
        {
            return Controller_MantAsignarHorarioPersona.GetInstance().Get_Localidades_List();
        }

        [WebMethod]
        public static ArrayList List_Periodo(string Plantilla)
        {
            if (Plantilla == null)
            {
                Plantilla = "01";
            }
            return Controller_AsignarCodigo.GetInstance().List_Periodo(Plantilla);

        }
        [WebMethod]
        public static ArrayList Get_PeriodoCA_By_Planilla(string Periodo_Id)
        {
            return controller_FiltrosCA.Get_Instance().Get_PeriodoCA_By_Planilla(Periodo_Id);
        }

        [WebMethod]
        public static ArrayList listaPersonalSinMarcaciones(string Periodo_Id, string Area_Id, DateTime vi_fecha_inicio
           , DateTime vi_fecha_fin)
        {
            return Controller_CAGenerarFaltas.GetInstance().listaPersonalSinMarcaciones(Periodo_Id, Area_Id, vi_fecha_inicio,
                vi_fecha_fin);
        }

        [WebMethod]
        public static ArrayList listaPersonalSinMarcaciones2(string Periodo_Id, string Area_Id, DateTime vi_fecha_inicio
        , DateTime vi_fecha_fin, string Planilla_Id)
        {
            return Controller_CAGenerarFaltas.GetInstance().listaPersonalSinMarcaciones2(Periodo_Id, Area_Id, vi_fecha_inicio,
                vi_fecha_fin, Planilla_Id);
        }


        [WebMethod]
        public static string Set_GenerarFaltas(string Planilla_Id, string Periodo_Id, string Area_Id, string FechaInicio, string FechaFinal)
        {
            return Controller_CAGenerarFaltas.GetInstance().Set_GenerarFaltas(Planilla_Id, Periodo_Id, Area_Id, FechaInicio, FechaFinal);
        }
    }
}