using BusinessLogic.oChangePass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using PersistenceI;

namespace GNProject.Views.Indicendia01.Server.pChangePass
{
    public partial class sChangePass : System.Web.UI.Page
    {
        [WebMethod]
        public static ArrayList Get_UsuarioPersonal(string Personal_Id, string PersonalFind, int inicio)
        {
            return controller_ChangePass.Get_Instance().Get_UsuarioPersonal(Personal_Id, PersonalFind, inicio);
        }

        [WebMethod]
        public static int Get_UsuarioPersonal_MaxRows(string Personal_Id, string PersonalFind)
        {
            return controller_ChangePass.Get_Instance().Get_UsuarioPersonal_MaxRows(Personal_Id, PersonalFind);
        }

        [WebMethod]
        public static Personal Get_Personal_Find(string Personal_Id)
        {
            return controller_ChangePass.Get_Instance().Get_Personal_Find(Personal_Id);
        }
        [WebMethod]
        public static string Get_Change_Pass(string Personal_Id, string NewPass)
        {
            return controller_ChangePass.Get_Instance().Get_Change_Pass(Personal_Id, NewPass);
        }
    }
}