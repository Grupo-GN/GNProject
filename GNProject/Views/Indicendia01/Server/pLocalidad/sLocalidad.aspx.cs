using BusinessLogic.oLocalidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Persistence;
namespace GNProject.Views.Indicendia01.Server.pLocalidad
{
    public partial class sLocalidad : System.Web.UI.Page
    {
        [WebMethod]
        public static List<RH_Area> Get_Localidad_List(/*string descripcion,*/int inicio)
        {
            return controller_Localidad.Get_Instance().Get_Localidad_List(/*descripcion,*/ inicio);
        }
        [WebMethod]
        public static int Get_Localidad_List_MaxRows()
        {
            return controller_Localidad.Get_Instance().Get_Localidad_List_MaxRows();
        }

        [WebMethod]
        public static RH_Area Get_Localidad_Find(string Area_Id)
        {
            return controller_Localidad.Get_Instance().Get_Localidad_Find(Area_Id);
        }

        [WebMethod]
        public static string Get_Localidad_Add(string Descripcion, string Direccion)
        {
            return controller_Localidad.Get_Instance().Get_Localidad_Add(Descripcion, Direccion);
        }

        [WebMethod]
        public static string Get_Localidad_Update(string Area_Id, string Descripcion, string Direccion)
        {
            return controller_Localidad.Get_Instance().Get_Localidad_Update(Area_Id, Descripcion, Direccion);
        }

        [WebMethod]
        public static string Get_Localidad_Delete(string Area_Id)
        {
            return controller_Localidad.Get_Instance().Get_Localidad_Delete(Area_Id);
        }
    }
}