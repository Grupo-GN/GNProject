using BusinessLogic.oCargo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Persistence;
using System.Collections;

namespace GNProject.Views.Indicendia01.Server.pCargo
{
    public partial class sCargo : System.Web.UI.Page
    {
        [WebMethod]
        public static List<Cargo> Get_Cargo_List(string Descripcion, string Estado, int inicio)
        {
            return controller_Cargo.Get_Instance().Get_Cargo_List(Descripcion, Estado, inicio);
        }
        [WebMethod]
        public static int Get_Cargo_List_MaxRows(string Descripcion, string Estado)
        {
            return controller_Cargo.Get_Instance().Get_Cargo_List_MaxRows(Descripcion, Estado);
        }


        [WebMethod]
        public static bool Get_Add_Cargo(string Descripcion, string Estado)
        {
            return controller_Cargo.Get_Instance().Get_Add_Cargo(Descripcion, Estado);
        }
        [WebMethod]
        public static bool Get_Update_Cargo(string Cargo_Id, string Descripcion, string Estado)
        {
            return controller_Cargo.Get_Instance().Get_Update_Cargo(Cargo_Id, Descripcion, Estado);
        }


        [WebMethod]
        public static bool Get_Delete_Estado_Cargo(string Cargo_Id, string Estado)
        {
            return controller_Cargo.Get_Instance().Get_Delete_Estado_Cargo(Cargo_Id, Estado);
        }
        [WebMethod]
        public static Cargo Get_Find_Cargo(string Cargo_Id)
        {
            return controller_Cargo.Get_Instance().Get_Find_Cargo(Cargo_Id);
        }
    }
}