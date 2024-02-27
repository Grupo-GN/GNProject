using BusinessLogic.oCategoriaAuxiliar2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using PersistenceInci;

namespace GNProject.Views.Indicendia01.Server.pCategoriaAuxiliar2
{
    public partial class sCategoriaAuxiliar2 : System.Web.UI.Page
    {
        [WebMethod]
        public static ArrayList Get_CategoriaAuxliar2_List(string CateAux1, string Descripcion, int inicio)
        {
            return controller_CategoriaAuxiliar2.Get_Instance().Get_CategoriaAuxliar2_List(CateAux1, Descripcion, inicio);
        }


        [WebMethod]
        public static List<Categoria_Auxiliar> Get_CategoriaAuxliar_Combo()
        {
            return controller_CategoriaAuxiliar2.Get_Instance().Get_CategoriaAuxliar_Combo();
        }

        [WebMethod]
        public static int Get_CategoriaAuxliar2_List_MaxRows(string CateAux1, string Descripcion)
        {
            return controller_CategoriaAuxiliar2.Get_Instance().Get_CategoriaAuxliar2_List_MaxRows(CateAux1, Descripcion);
        }

        [WebMethod]
        public static Categoria_Auxiliar2 Get_CategoriaAuxliar2_Find(string Categoria2_Id)
        {
            return controller_CategoriaAuxiliar2.Get_Instance().Get_CategoriaAuxliar2_Find(Categoria2_Id);
        }

        [WebMethod]
        public static bool Get_Add_CategoriaAuxliar2(string Categoria_Id, string Descripcion)
        {
            return controller_CategoriaAuxiliar2.Get_Instance().Get_Add_CategoriaAuxliar2(Categoria_Id, Descripcion);
        }

        [WebMethod]
        public static bool Get_Update_CategoriaAuxliar2(string Categoria2_Id, string Categoria_Id, string Descripcion)
        {
            return controller_CategoriaAuxiliar2.Get_Instance().Get_Update_CategoriaAuxliar2(Categoria2_Id, Categoria_Id, Descripcion);
        }
    }
}