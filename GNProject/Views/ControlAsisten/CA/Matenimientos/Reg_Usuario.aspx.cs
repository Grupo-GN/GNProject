using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusienssLogic.Acceso;


namespace GNProject.Views.ControlAsisten.CA.Matenimientos
{
    public partial class Reg_Usuario : System.Web.UI.Page
    {
        [WebMethod]
        public static List<UsuariosNN> ListUsuariosNN(string Planilla_Id, string Periodo_Id, string Localidad_Id, string Personal_Id)
        {
            return controller_AccesoSistema.Get_Instance().ListUsuariosNN(Planilla_Id, Periodo_Id, Localidad_Id, Personal_Id);

        }

        [WebMethod]

        public static List<UsuariosNN> ListaUsuariosFind(string codigo)
        {
            return controller_AccesoSistema.Get_Instance().ListaUsuariosFind(codigo);

        }

        [WebMethod]
        public static string Insert_Usuarios(string id_personal, List<string> Rlist)
        {
            return controller_AccesoSistema.Get_Instance().Insert_Usuarios(id_personal, Rlist);
        }

        [WebMethod]
        public static string UpdateUsuarios(string Personal_Id, string Usuario, string Clave, string Acceso)
        {
            return controller_AccesoSistema.Get_Instance().UpdateUsuarios(Personal_Id, Usuario, Clave, Acceso);
        }
    }
}