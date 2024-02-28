using BusinessLogic.oConfigReporte;
using Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.Indicendia01.Server.pConfigReporte
{
    public partial class sConfigReporte : System.Web.UI.Page
    {
        //INTENSIDAD
        [WebMethod]
        public static List<Intensidad> Get_Intensidad_List()
        {
            return controller_CofigReporte.Get_Instance().Get_Intensidad_List();
        }
        [WebMethod]
        public static string Get_Update_Intensidad(string Intensidad_Id, string Descripcion)
        {
            return controller_CofigReporte.Get_Instance().Get_Update_Intensidad(Intensidad_Id, Descripcion);
        }

        [WebMethod]
        public static string Get_Add_Intensidad(string Descripcion)
        {
            return controller_CofigReporte.Get_Instance().Get_Add_Intensidad(Descripcion);
        }
        [WebMethod]
        public static string Get_Delete_Intensidad(string Intensidad_Id)
        {
            return controller_CofigReporte.Get_Instance().Get_Delete_Intensidad(Intensidad_Id);
        }

        //SEVERIDAD
        [WebMethod]
        public static List<Severidad> Get_Severidad_List()
        {
            return controller_CofigReporte.Get_Instance().Get_Severidad_List();
        }

        [WebMethod]
        public static string Get_Add_Severidad(string Descripcion)
        {
            return controller_CofigReporte.Get_Instance().Get_Add_Severidad(Descripcion);
        }
        [WebMethod]
        public static string Get_Update_Severidad(string Severidad_Id, string Descripcion)
        {
            return controller_CofigReporte.Get_Instance().Get_Update_Severidad(Severidad_Id, Descripcion);
        }
        [WebMethod]
        public static string Get_Delete_Severidad(string Severidad_Id)
        {
            return controller_CofigReporte.Get_Instance().Get_Delete_Severidad(Severidad_Id);
        }

        //ALERTA GERENCIA
        [WebMethod]
        public static List<Intensidad> Get_Intensidad_Out_List()
        {
            return controller_CofigReporte.Get_Instance().Get_Intensidad_Out_List();
        }

        [WebMethod]
        public static List<Intensidad> Get_Intensidad_In_List()
        {
            return controller_CofigReporte.Get_Instance().Get_Intensidad_In_List();
        }

        [WebMethod]
        public static void Get_Clear_AlertGeren()
        {
            controller_CofigReporte.Get_Instance().Get_Clear_AlertGeren();
        }

        [WebMethod]
        public static bool Get_Intensidad_Add_Alert(string Intensidad_Id)
        {
            return controller_CofigReporte.Get_Instance().Get_Intensidad_Add_Alert(Intensidad_Id);
        }

        //CORREO OSIGERMIN

        [WebMethod]
        public static string Get_GrabarCorreo_Osigermin(string Correo)
        {
            return controller_CofigReporte.Get_Instance().Get_GrabarCorreo_Osigermin(Correo);
        }
        //MI CORREO 
        [WebMethod]
        public static string Get_Grabar_MiCorreo(string Correo)
        {
            return controller_CofigReporte.Get_Instance().Get_Grabar_MiCorreo(Correo);
        }

        //TIPO 
        [WebMethod]
        public static List<Tipo> Get_Tipo_List()
        {
            return controller_CofigReporte.Get_Instance().Get_Tipo_List();
        }

        [WebMethod]
        public static string Get_Add_Tipo(string Descripcion)
        {
            return controller_CofigReporte.Get_Instance().Get_Add_Tipo(Descripcion);
        }

        [WebMethod]
        public static string Get_Update_Tipo(string Tipo_Id, string Descripcion)
        {
            return controller_CofigReporte.Get_Instance().Get_Update_Tipo(Tipo_Id, Descripcion);
        }
        [WebMethod]
        public static string Get_Delete_Tipo(string Tipo_Id)
        {
            return controller_CofigReporte.Get_Instance().Get_Delete_Tipo(Tipo_Id);
        }

        //ORIGEN
        [WebMethod]
        public static List<Origen> Get_Origen_List()
        {
            return controller_CofigReporte.Get_Instance().Get_Origen_List();
        }

        [WebMethod]
        public static string Get_Add_Origen(string Descripcion)
        {
            return controller_CofigReporte.Get_Instance().Get_Add_Origen(Descripcion);
        }

        [WebMethod]
        public static string Get_Update_Origen(string Origen_Id, string Descripcion)
        {
            return controller_CofigReporte.Get_Instance().Get_Update_Origen(Origen_Id, Descripcion);
        }
        [WebMethod]
        public static string Get_Delete_Origen(string Origen_Id)
        {
            return controller_CofigReporte.Get_Instance().Get_Delete_Origen(Origen_Id);
        }

        //PARAMENTROS
        [WebMethod]
        public static List<Parametros_Sistema> Get_Paramentros_All()
        {
            return controller_CofigReporte.Get_Instance().Get_Paramentros_All();
        }

        [WebMethod]
        public static string Get_Cofig_Cuenta_Correo(string Email, string Contraseña)
        {
            return controller_CofigReporte.Get_Instance().Get_Cofig_Cuenta_Correo(Email, Contraseña);
        }

        [WebMethod]
        public static string Get_ParaGerentes(string Contenido)
        {
            return controller_CofigReporte.Get_Instance().Get_ParaGerentes(Contenido);
        }

        [WebMethod]
        public static string Get_ParaResponsables(string Contenido)
        {
            return controller_CofigReporte.Get_Instance().Get_ParaResponsables(Contenido);
        }

        [WebMethod]
        public static string Get_ParaAdministracion(string Contenido)
        {
            return controller_CofigReporte.Get_Instance().Get_ParaAdministracion(Contenido);
        }
    }
}