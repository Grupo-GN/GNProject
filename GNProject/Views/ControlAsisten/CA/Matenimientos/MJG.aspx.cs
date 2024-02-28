using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using BusienssLogic.CA.oFiltros;
using System.Collections;
using BusienssLogic.CA.oJefePersonal;
using Presistence;

namespace GNProject.Views.ControlAsisten.CA.Matenimientos
{
    public partial class MJG : System.Web.UI.Page
    {
        [WebMethod]
        public static List<areas_planillas_sofya> Get_Localidad_List_OLD(string Personal_Id)
        {
            return controller_FiltrosCA.Get_Instance().Get_Localidad_List_OLD(Personal_Id);
        }

        [WebMethod]
        public static List<RH_Area> Get_Localidad_List(string Personal_Id)
        {
            return controller_FiltrosCA.Get_Instance().Get_Localidad_List(Personal_Id);
        }
        //nuevo
        [WebMethod]
        public static ArrayList Get_Localidad_List_New(string Personal_Id)
        {
            return controller_FiltrosCA.Get_Instance().Get_Localidad_List_New(Personal_Id);
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
        public static ArrayList getGerentesJefesByLocalidad(string pr1)
        {
            return controller_jg.getinstance().getGerentesJefesByLocalidad(pr1);
        }
        [WebMethod]
        public static ArrayList getPersonalAdd(string pr1, string pr2, string pr3, string pr4)
        {
            return controller_jg.getinstance().getPersonalAdd(pr1, pr2, pr3, pr4);
        }
        [WebMethod]
        public static string addPersonalGJ(string pr1, string pr2, string pr3, string pr4, string pr5, string pr6)
        {
            return controller_jg.getinstance().addPersonalGJ(pr1, pr2, pr3, pr4, pr5, pr6);
        }
        [WebMethod]
        public static string Procesar(string pr1)
        {
            return controller_jg.getinstance().Procesar(pr1);
        }
    }
}