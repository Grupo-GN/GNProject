using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Collections;
using BusienssLogic.CA.oFiltros;
using Presistence;
using BusienssLogic.CA.oReporteGeneral;

namespace GNProject.Views.ControlAsisten.CA.caReporteGeneral
{
    public partial class cReporteGeneral : System.Web.UI.Page
    {
        #region FILTROS
        [WebMethod]
        public static ArrayList Get_Planilla_List()
        {
            return controller_FiltrosCA.Get_Instance().Get_Planilla_List();
        }
        [WebMethod]
        public static ArrayList Get_Periodo_Activo_By_CA(string Planilla_Id)
        {
            return controller_FiltrosCA.Get_Instance().Get_Periodo_Activo_By_CA(Planilla_Id);
        }
        [WebMethod]
        public static List<RH_Area> Get_Localidad_List(string Personal_Id)
        {
            return controller_FiltrosCA.Get_Instance().Get_Localidad_List(Personal_Id);
        }
        //30.09.2020 nuewvo
        [WebMethod]
        public static ArrayList Get_Localidad_List_New(string Personal_Id)
        {
            return controller_FiltrosCA.Get_Instance().Get_Localidad_List_New(Personal_Id);
        }
        // 30.09.2020 antiguo

        [WebMethod]
        public static List<areas_planillas_sofya> Get_Localidad_List_OL(string Personal_Id)
        {
            return controller_FiltrosCA.Get_Instance().Get_Localidad_List_OLD(Personal_Id);
        }
        [WebMethod]
        public static ArrayList Get_Categoria_Auxiliar_List(string Personal_Id)
        {
            return controller_FiltrosCA.Get_Instance().Get_Categoria_Auxiliar_List(Personal_Id);
        }
        [WebMethod]
        public static ArrayList Get_Categoria_Auxiliar2_List(string Cat_Aux, string Personal_Id)
        {
            return controller_FiltrosCA.Get_Instance().Get_Categoria_Auxiliar2_List(Cat_Aux, Personal_Id);
        }
        [WebMethod]
        public static ArrayList Get_Categoria_List()
        {
            return controller_FiltrosCA.Get_Instance().Get_Categoria_List();
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
        #endregion



        [WebMethod]
        public static List<tblReporteGeneral> Get_ReporteGeneral_By_Personal(string Planilla_Id, string Periodo_Id, string Localidad_Id, string[] Personal_Id, string FechaIni, string FechaFin)
        {
            return controller_ReporteGeneral.Get_Instance().Get_ReporteGeneral_By_Personal(Planilla_Id, Periodo_Id, Localidad_Id, Personal_Id, FechaIni, FechaFin);
        }
    }
}