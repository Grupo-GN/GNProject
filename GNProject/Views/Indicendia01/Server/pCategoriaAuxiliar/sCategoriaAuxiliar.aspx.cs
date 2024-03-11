using BusinessLogic.oCategoriaAuxiliar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using PersistenceI;


namespace GNProject.Views.Indicendia01.Server.pCategoriaAuxiliar
{
    public partial class sCategoriaAuxiliar : System.Web.UI.Page
    {
        [WebMethod]
        public static List<Categoria_Auxiliar> Get_CategoriaAuxliar_List(string Descripcion, int inicio)
        {
            return controller_CategoriaAuxiliar.Get_Instance().Get_CategoriaAuxliar_List(Descripcion, inicio);
        }

        [WebMethod]
        public static int Get_CategoriaAuxliar_List_MaxRows(string Descripcion)
        {
            return controller_CategoriaAuxiliar.Get_Instance().Get_CategoriaAuxliar_List_MaxRows(Descripcion);
        }

        [WebMethod]
        public static Categoria_Auxiliar Get_CategoriaAuxliar_Find(string Categoria_Id)
        {
            return controller_CategoriaAuxiliar.Get_Instance().Get_CategoriaAuxliar_Find(Categoria_Id);
        }

        [WebMethod]
        public static bool Get_Add_CategoriaAuxliar(string Descripcion)
        {
            return controller_CategoriaAuxiliar.Get_Instance().Get_Add_CategoriaAuxliar(Descripcion);
        }

        [WebMethod]
        public static bool Get_Update_CategoriaAuxliar(string Categoria_Id, string Descripcion)
        {
            return controller_CategoriaAuxiliar.Get_Instance().Get_Update_CategoriaAuxliar(Categoria_Id, Descripcion);
        }
    }
}