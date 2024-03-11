using BusinessLogic.oInformeGerencia;
using BusinessLogic.oListReportes;
using PersistenceI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.Indicendia01.Server.pInformeGerencia
{
    public partial class sInformeGerencia : System.Web.UI.Page
    {
        [WebMethod]
        public static ArrayList Get_Gerentes_List(string Nombres, string Estado, int inicio)
        {
            return controller_InformeGerencia.Get_Instance().Get_Gerentes_List(Nombres, Estado, inicio);
        }
        [WebMethod]
        public static int Get_Gerentes_List_MaxRows(string Nombres, string Estado)
        {
            return controller_InformeGerencia.Get_Instance().Get_Gerentes_List_MaxRows(Nombres, Estado);
        }
        [WebMethod]
        public static string Get_Add_Gerente(string Apellido_Paterno, string Apellido_Materno
            , string Nombres, string GerenciaDes, string Correo, string Area_Id, string Informar, string Codigo_LG, string Estado)
        {
            return controller_InformeGerencia.Get_Instance().Get_Add_Gerente(Apellido_Paterno, Apellido_Materno
            , Nombres, GerenciaDes, Correo, Area_Id, Informar, Codigo_LG, Estado);
        }

        [WebMethod]
        public static string Get_Update_Gerente(string Gerente_Id, string Apellido_Paterno, string Apellido_Materno
            , string Nombres, string GerenciaDes, string Correo, string Area_Id, string Informar, string Codigo_LG, string Estado)
        {
            return controller_InformeGerencia.Get_Instance().Get_Update_Gerente(Gerente_Id, Apellido_Paterno, Apellido_Materno
            , Nombres, GerenciaDes, Correo, Area_Id, Informar, Codigo_LG, Estado);
        }

        [WebMethod]
        public static string Get_Delete_Estado_Gerente(string Gerente_Id, string Estado)
        {
            return controller_InformeGerencia.Get_Instance().Get_Delete_Estado_Gerente(Gerente_Id, Estado);
        }

        [WebMethod]
        public static Gerentes Get_Find_Gerente(string Gerente_Id)
        {
            return controller_InformeGerencia.Get_Instance().Get_Find_Gerente(Gerente_Id);
        }

        [WebMethod]
        public static List<RH_Area> Get_Localidad_List()
        {
            return controller_ListarReporte.Get_Instance().Get_Licalidad_List();
        }
    }
}