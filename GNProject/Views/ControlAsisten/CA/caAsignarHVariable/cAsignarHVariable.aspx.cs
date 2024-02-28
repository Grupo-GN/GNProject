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
using BusienssLogic.CA.oAsignarHVariable;

namespace GNProject.Views.ControlAsisten.CA.caAsignarHVariable
{
    public partial class cAsignarHVariable : System.Web.UI.Page
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
        //nuevo 30.09.2020
        [WebMethod]
        public static ArrayList Get_Localidad_List_New(string Personal_Id)
        {
            return controller_FiltrosCA.Get_Instance().Get_Localidad_List_New(Personal_Id);
        }
        //30.09.2020 antiguo
        [WebMethod]
        public static List<areas_planillas_sofya> Get_Localidad_List_OLD(string Personal_Id)
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

        #endregion

        [WebMethod]
        public static List<tblPersonalHV> Get_Personal_HorarioVariable(string Periodo_Id, string Localidad_Id, string CategoriaAux, string CategoriaAux2, string Categoria)
        {
            return controller_AsignarHVariable.Get_Instance().Get_Personal_HorarioVariable(Periodo_Id, Localidad_Id, CategoriaAux, CategoriaAux2, Categoria);
        }


        [WebMethod]
        public static string Get_AsignarHorarioVariable(List<PersonalHV> PersonalVariable, string Periodo_Id)
        {
            return controller_AsignarHVariable.Get_Instance().Get_AsignarHorarioVariable(PersonalVariable, Periodo_Id);
        }
    }
}