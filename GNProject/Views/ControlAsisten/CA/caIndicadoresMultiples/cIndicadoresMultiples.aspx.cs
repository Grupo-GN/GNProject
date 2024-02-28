using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Collections;
using BusienssLogic.CA.oIndicadoresMultiples;
using Presistence;

namespace GNProject.Views.ControlAsisten.CA.caIndicadoresMultiples
{
    public partial class cIndicadoresMultiples : System.Web.UI.Page
    {
        [WebMethod]
        public static ArrayList Get_IndicesMultiplesControlAsistencia(string[] Dimensiones, string[] Sumas, string FechaInicio, string FechaFinal)
        {
            return controller_IndicadoresMultiples.Get_Instance().Get_IndicesMultiplesControlAsistencia(Dimensiones, Sumas, FechaInicio, FechaFinal);
        }


        [WebMethod]
        public static ArrayList Get_Dimensiones()
        {
            return controller_IndicadoresMultiples.Get_Instance().Get_Dimensiones();
        }
        [WebMethod]
        public static ArrayList Get_SumaCamposCA()
        {
            return controller_IndicadoresMultiples.Get_Instance().Get_SumaCamposCA();
        }
        #region FILTROS
        [WebMethod]
        public static ArrayList Get_Planilla_List()
        {
            return controller_IndicadoresMultiples.Get_Instance().Get_Planilla_List();
        }
        [WebMethod]
        public static List<string> Get_Anios()
        {
            return controller_IndicadoresMultiples.Get_Instance().Get_Anios();
        }

        [WebMethod]
        public static ArrayList Get_Periodo_Activo_By_CA(string Planilla_Id)
        {
            return controller_IndicadoresMultiples.Get_Instance().Get_Periodo_Activo_By_CA(Planilla_Id);
        }
        [WebMethod]
        public static ArrayList Get_Localidad_List()
        {
            return controller_IndicadoresMultiples.Get_Instance().Get_Localidad_List();
        }
        [WebMethod]
        public static ArrayList Get_Categoria_Auxiliar_List()
        {
            return controller_IndicadoresMultiples.Get_Instance().Get_Categoria_Auxiliar_List();
        }
        [WebMethod]
        public static ArrayList Get_Categoria_Auxiliar2_List(string Cat_Aux)
        {
            return controller_IndicadoresMultiples.Get_Instance().Get_Categoria_Auxiliar2_List(Cat_Aux);
        }
        [WebMethod]
        public static ArrayList Get_Categoria_List()
        {
            return controller_IndicadoresMultiples.Get_Instance().Get_Categoria_List();
        }
        [WebMethod]
        public static ArrayList Get_PeriodoCA_By_Planilla(string Periodo_Id)
        {
            return controller_IndicadoresMultiples.Get_Instance().Get_PeriodoCA_By_Planilla(Periodo_Id);
        }

        [WebMethod]
        public static ArrayList Get_Personal_By_Filtros(string Periodo_Id, string Localidad_Id, string CategoriaAux, string CategoriaAux2, string Categoria)
        {
            return controller_IndicadoresMultiples.Get_Instance().Get_Personal_By_Filtros(Periodo_Id, Localidad_Id, CategoriaAux, CategoriaAux2, Categoria);
        }
        #endregion
    }
}