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
using BusienssLogic.CA.oInfoMarcaciones;

namespace GNProject.Views.ControlAsisten.CA.caInfoMarcaciones
{
    public partial class cInfoMarcacion : System.Web.UI.Page
    {
        #region FILTROS
        [WebMethod]
        public static ArrayList Get_Planilla_List()
        {
            return controller_FiltrosCA.Get_Instance().Get_Planilla_List();
        }
        [WebMethod]
        public static ArrayList Get_Periodos_Planilla(string Planilla_Id)
        {
            return controller_FiltrosCA.Get_Instance().Get_Periodos_Planilla(Planilla_Id);
        }
        [WebMethod]
        public static ArrayList Get_Localidad_List(string Personal_Id)
        {
            return controller_FiltrosCA.Get_Instance().Get_Localidad_List_New(Personal_Id);
        }
        // antiguo 30.09.2020.
        [WebMethod]
        public static List<areas_planillas_sofya> Get_Localidad_Lis_OLD(string Personal_Id)
        {
            return controller_FiltrosCA.Get_Instance().Get_Localidad_List_OLD(Personal_Id);
        }

        [WebMethod]
        public static ArrayList Get_Categoria_Auxiliar_List()
        {
            return controller_FiltrosCA.Get_Instance().Get_Categoria_Auxiliar_List();
        }
        [WebMethod]
        public static ArrayList Get_Categoria_Auxiliar2_List(string Cat_Aux)
        {
            return controller_FiltrosCA.Get_Instance().Get_Categoria_Auxiliar2_List(Cat_Aux);
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
        public static ArrayList Get_Personal_By_Filtros(string Periodo_Id, string Localidad_Id, string CategoriaAux, string CategoriaAux2, string Categoria, string PersonalFind, string Jefe_Id = "")
        {
            return controller_InfoMarcaciones.Get_Instance().Get_Personal_By_Filtros(Periodo_Id, Localidad_Id, CategoriaAux, CategoriaAux2, Categoria, PersonalFind, Jefe_Id);
        }

        #endregion


        [WebMethod]
        public static string Get_SendMarcaciones_Informacion(string[] Personal_Cods)
        {
            return controller_InfoMarcaciones.Get_Instance().Get_SendMarcaciones_Informacion(Personal_Cods);
        }
    }
}