using BusinessLogic.oAlertas;
using BusinessLogic.oLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersistenceI;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.Indicendia01.MasterPage
{
    public partial class HelpASP : System.Web.UI.Page
    {
        [WebMethod]
        public static Personal Get_PersonalLogin_Datos(string Personal_id)
        {
            
            return controller_Login.Get_Instance().Get_PersonalLogin_Datos(Personal_id);
        }

        [WebMethod]
        public static List<int> Get_Alertas_By_Rol(string Usuario_Id, string Rol_Id)
        {
            return controller_Alertas.Get_Instance().Get_Alertas_By_Rol(Usuario_Id, Rol_Id);
        }
    }
}