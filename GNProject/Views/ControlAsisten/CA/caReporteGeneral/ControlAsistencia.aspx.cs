using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusienssLogic.CA.oAsignarCodigo;
using BusienssLogic.CA.oAsignarHorarioPersona;
using BusienssLogic.CA.oFiltros;
using BusienssLogic.CA.oReporteGeneral;
using System.Collections;
using System.Web.Services;
using static BusienssLogic.CA.oReporteGeneral.ControllerReporteAsistenciaDiario;

namespace GNProject.Views.ControlAsisten.CA.caReporteGeneral
{
    public partial class ControlAsistencia : System.Web.UI.Page
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
        public static ArrayList Get_Personal_By_Filtros(string Periodo_Id, string Localidad_Id, string CategoriaAux, string CategoriaAux2, string Categoria
                 , string Personal_Id)
        {
            return controller_FiltrosCA.Get_Instance().Get_Personal_By_Filtros(Periodo_Id, Localidad_Id, CategoriaAux, CategoriaAux2, Categoria
                , Personal_Id);
        }
        [WebMethod]
        public static List<ControlAsistencias> ListaControlAsistencia(string Planilla_Id, string Periodo_Id, string Localidad_Id, string Personal_Id, string FechaIni, string FechaFin)
        {
            return ControllerReporteAsistenciaDiario.Get_Instance().ListaControlAsistencia(Planilla_Id, Periodo_Id, Localidad_Id, Personal_Id, FechaIni, FechaFin);
        }

    }
}