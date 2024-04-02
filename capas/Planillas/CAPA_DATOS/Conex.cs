using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace CAPA_DATOS
{
    public static class Conex
    {
        //public static Conex oControllerInstance = null;
        //public Conex() { 

        //}

        //public Conex GetInstance() {
        //    return oControllerInstance == null ? oControllerInstance = new Conex() : oControllerInstance;
        //}
        public static String getRUCEmpresa()
        {
            String[] arr_Usuario_Perfil = System.Web.HttpContext.Current.User.Identity.Name.Split('|');
            String rucEmpresa = String.Empty;
            if (arr_Usuario_Perfil != null && arr_Usuario_Perfil.Length > 0) { rucEmpresa = arr_Usuario_Perfil[5].ToString(); }
            return rucEmpresa;
        }

        private static String getCodEmpresaConnection()
        {
            String codEmpresaConnection = String.Empty;
            String rucEmpresa = getRUCEmpresa();
            if (!String.IsNullOrEmpty(rucEmpresa)) { codEmpresaConnection = "conexion_" + rucEmpresa; }
            return codEmpresaConnection;
        }

        public static SqlConnection CadCon()
        {
            string codEmpresaConnection = getCodEmpresaConnection();
            //return new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
            return new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[codEmpresaConnection].ConnectionString);
        }

        public static string CadCon_String()
        {
            string codEmpresaConnection = getCodEmpresaConnection();
            string conexion;
            //conexion = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            conexion = System.Configuration.ConfigurationManager.ConnectionStrings[codEmpresaConnection].ConnectionString;
            return conexion;
        }

        public static string CadCon_String(String rucEmpresa)
        {
            string codEmpresaConnection = "conexion_" + rucEmpresa;
            string conexion;
            //conexion = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            conexion = System.Configuration.ConfigurationManager.ConnectionStrings[codEmpresaConnection].ConnectionString;
            return conexion;
        }
    }    
}
