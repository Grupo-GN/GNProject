using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PersistenceInci;
using BusinessLogic.oPersonal;
using System.Web.Services;
using System.Collections;

namespace GNProject.Views.Indicendia01.Server.pPersonal
{
    public partial class sPersonal : System.Web.UI.Page
    {
        #region DATOS AUXILIAR DEL PERSONAL

        [WebMethod]
        public static List<Planilla> Get_Planilla_Combo()
        {
            return controller_DatosPersonal.Get_Instance().Get_Planilla_Combo();
        }

        [WebMethod]
        public static List<Cargo> Get_Cargo_Combo()
        {
            return controller_DatosPersonal.Get_Instance().Get_Cargo_Combo();
        }

        [WebMethod]
        public static List<RH_Area> Get_Localidad_Combo()
        {
            return controller_DatosPersonal.Get_Instance().Get_Localidad_Combo();
        }

        [WebMethod]
        public static List<Categoria_Auxiliar> Get_Categoria_Auxiliar_Combo()
        {
            return controller_DatosPersonal.Get_Instance().Get_Categoria_Auxiliar_Combo();
        }

        [WebMethod]
        public static List<Categoria_Auxiliar2> Get_Categoria_Auxiliar2_Combo(string Categoria_Auxiliar_id)
        {
            return controller_DatosPersonal.Get_Instance().Get_Categoria_Auxiliar2_Combo(Categoria_Auxiliar_id);
        }
        #endregion

        #region PERSONAL

        [WebMethod]
        public static ArrayList Get_Personal_List(string Nombres, string Area_Id, string Estado_Id, int inicio)
        {
            return controller_Personal.Get_Instance().Get_Personal_List(Nombres, Area_Id, Estado_Id, inicio);
        }
        [WebMethod]
        public static int Get_Personal_List_MaxRows(string Nombres, string Area_Id, string Estado_Id)
        {
            return controller_Personal.Get_Instance().Get_Personal_List_MaxRows(Nombres, Area_Id, Estado_Id);
        }

        [WebMethod]
        public static Personal Get_Personal_Find(string Personal_id)
        {
            return controller_Personal.Get_Instance().Get_Personal_Find(Personal_id);
        }

        [WebMethod]
        public static string Get_Foto_By_Personal(string Personal_id)
        {
            return controller_Personal.Get_Instance().Get_Foto_By_Personal(Personal_id);
        }

        [WebMethod]
        public static string Get_Add_Personal(string Planilla_Id, string Apellido_Paterno, string Apellido_Materno, string Nombres, DateTime Fecha_Nacimiento, string Nro_Doc,
            string email, string Cargo_Id
      , string Area_Id, string Categoria_Auxiliar_Id, string Categoria_Auxiliar2_Id, string CodigoLG, string Estado_Id, string RolSistema)
        {
            return controller_Personal.Get_Instance().Get_Add_Personal(Planilla_Id, Apellido_Paterno, Apellido_Materno, Nombres, Fecha_Nacimiento, Nro_Doc, email, Cargo_Id
                , Area_Id, Categoria_Auxiliar_Id, Categoria_Auxiliar2_Id, CodigoLG, Estado_Id, RolSistema);
        }

        [WebMethod]
        public static string Get_Update_Personal(string Personal_Id, string Planilla_Id, string Apellido_Paterno, string Apellido_Materno, string Nombres, DateTime Fecha_Nacimiento, string Nro_Doc, string email, string Cargo_Id
      , string Area_Id, string Categoria_Auxiliar_Id, string Categoria_Auxiliar2_Id, string CodigoLG, string Estado_Id, string RolSistema
            , string Name, string Password, string Estado_Usuario)
        {
            return controller_Personal.Get_Instance().Get_Update_Personal(Personal_Id, Planilla_Id, Apellido_Paterno, Apellido_Materno, Nombres, Fecha_Nacimiento, Nro_Doc, email, Cargo_Id
                , Area_Id, Categoria_Auxiliar_Id, Categoria_Auxiliar2_Id, CodigoLG, Estado_Id, RolSistema
                , Name, Password, Estado_Usuario);
        }

        [WebMethod]
        public static bool Get_DeleteEstado_Personal(string Personal_Id, string Estado_Id)
        {
            return controller_Personal.Get_Instance().Get_DeleteEstado_Personal(Personal_Id, Estado_Id);
        }
        //usuario 
        [WebMethod]
        public static Usuario Get_Usuario_Personal(string Personal_id)
        {
            return controller_Personal.Get_Instance().Get_Usuario_Personal(Personal_id);
        }

        #endregion
    }
}