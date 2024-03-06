using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusienssLogic.CA.oFiltros;
using BusienssLogic.CA.oJefePersonal;
using System.Web.Services;
using Presistence;
using System.Collections;

namespace GNProject.Views.ControlAsisten.CA.Matenimientos
{
    public partial class MJefePersonal : System.Web.UI.Page
    {
        [WebMethod]
        public static List<RH_Area> Get_Localidad_List(string Personal_Id)
        {
            return controller_FiltrosCA.Get_Instance().Get_Localidad_List(Personal_Id);
        }
        [WebMethod]
        public static ArrayList Get_Localidad_List_New(string Personal_Id)
        {
            return controller_FiltrosCA.Get_Instance().Get_Localidad_List_New(Personal_Id);
        }
        // antiguo 30.09.2020
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
        public static ArrayList Get_Gerentes(string pr1)
        {
            return controller_JefePersonal.getInstance().Get_Gerentes(pr1);
        }
        [WebMethod]
        public static ArrayList Get_Jefes(string pr1)
        {
            return controller_JefePersonal.getInstance().Get_Jefes(pr1);
        }
        [WebMethod]
        public static ArrayList Get_Jef(string pr1, string gere)
        {
            return controller_JefePersonal.getInstance().Get_Jefes_Gerente(pr1, gere);
        }
        [WebMethod]
        public static ArrayList getPersonal(string pr1, string pr2, string pr3, string pr4, string local, string area, string seccion)
        {
            return controller_JefePersonal.getInstance().getPersonal(pr1, pr2, pr3, pr4, local, area, seccion);
        }


        [WebMethod]
        public static string AsignarGerente(string gereid, List<string> personal)
        {
            return controller_JefePersonal.getInstance().AsignarGerente(gereid, personal);
        }
        [WebMethod]
        public static string AsignarJefe(string jefeid, List<string> personal)
        {
            return controller_JefePersonal.getInstance().AsignarJefe(jefeid, personal);
        }
        [WebMethod]
        public static string AsignarPersonal(string jefeid, string gereid, List<string> personal)
        {
            return controller_JefePersonal.getInstance().AsignarGerenteJefe(jefeid, gereid, personal);
        }
    }
}