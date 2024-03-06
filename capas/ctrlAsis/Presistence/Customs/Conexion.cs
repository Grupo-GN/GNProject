using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.Configuration;

namespace Presistence.Customs
{
    public class Conexion
    {
        private static string Mid(string param, int startIndex, int length)
        {
            if ((startIndex + length) > param.Length)
            {
                return "";
            }

            string result = param.Substring(startIndex, length);
            return result;
        }

        public static String getRUCEmpresa()
        {
            String[] arr_Usuario_Perfil = System.Web.HttpContext.Current.User.Identity.Name.Split('|');
            String rucEmpresa = String.Empty;
            if (arr_Usuario_Perfil != null && arr_Usuario_Perfil.Length > 0) { rucEmpresa = arr_Usuario_Perfil[5].ToString(); }
            return rucEmpresa;
        }
        public static String getCodEmpresaConnection()
        {
            String codEmpresaConnection = String.Empty;
            String rucEmpresa = getRUCEmpresa();
            if (!String.IsNullOrEmpty(rucEmpresa)) { codEmpresaConnection = "ContextMaestro_" + rucEmpresa; }
            return codEmpresaConnection;
        }
        private static string buscaConexion()
        {
            String rucEmpresa = getRUCEmpresa();
            String codEmpresaConnection = "ContextMaestro_" + rucEmpresa;
            string cadena = System.Configuration.ConfigurationManager.ConnectionStrings[codEmpresaConnection].ConnectionString;
            int extraer = cadena.IndexOf("Data Source", 0);
            string nuevaCadena = Mid(cadena, extraer, cadena.Length - extraer);
            nuevaCadena = nuevaCadena.Replace(";App=EntityFramework", "");
            nuevaCadena = nuevaCadena.Replace("MultipleActiveResultSets=True" + '"', "");
            nuevaCadena = nuevaCadena.Replace("&quot", "");
            nuevaCadena = nuevaCadena.Replace("'", "");
            return nuevaCadena;
        }
        private static string buscaConexion(String rucEmpresa)
        {
            String codEmpresaConnection = "ContextMaestro_" + rucEmpresa;
            string cadena = System.Configuration.ConfigurationManager.ConnectionStrings[codEmpresaConnection].ConnectionString;
            int extraer = cadena.IndexOf("Data Source", 0);
            string nuevaCadena = Mid(cadena, extraer, cadena.Length - extraer);
            nuevaCadena = nuevaCadena.Replace(";App=EntityFramework", "");
            nuevaCadena = nuevaCadena.Replace("MultipleActiveResultSets=True" + '"', "");
            nuevaCadena = nuevaCadena.Replace("&quot", "");
            nuevaCadena = nuevaCadena.Replace("'", "");
            return nuevaCadena;
        }

        public static void cambiarConf(string cadenann)
        {
            string cadena = System.Configuration.ConfigurationManager.ConnectionStrings["ContextMaestro"].ConnectionString;
            int extraer = cadena.IndexOf("Data Source", 0);
            string nuevaCadena = Mid(cadena, 0, extraer);
            //nuevaCadena = nuevaCadena.Replace(";App=EntityFramework", "");
            //nuevaCadena = nuevaCadena.Replace("MultipleActiveResultSets=True" + '"', "");
            //nuevaCadena = nuevaCadena.Replace("&quot", "");
            //nuevaCadena = nuevaCadena.Replace("'", "");
            nuevaCadena = nuevaCadena + cadenann +"'";
            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //ConnectionStringsSection css = config.ConnectionStrings;
            //css.ConnectionStrings["ContextMaestro"].ConnectionString = nuevaCadena;
            //config.Save();

            var configuration = WebConfigurationManager.OpenWebConfiguration("~");
            var section = (ConnectionStringsSection)configuration.GetSection("connectionStrings");
            section.ConnectionStrings["ContextMaestro"].ConnectionString = nuevaCadena;
            configuration.Save();
        }

        public static string getConexion()
        {
            return buscaConexion();
        }
        public static string getConexion(String rucEmpresa)
        {
            return buscaConexion(rucEmpresa);
        }

        public class DatosSql
        {
            public string razon { set; get; }
            public string cadena { set; get; }
        }

        public static List<DatosSql> ListData(string ruc)
        {
            List<DatosSql> rlist = new List<DatosSql>();
            string SPnom = string.Empty;
            SPnom = "Sp_Conexion";
            using (SqlConnection cn = new SqlConnection(Conexion.getConexion(ruc)))
            {
                using (SqlCommand cmd = new SqlCommand(SPnom, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                     
                        cmd.Parameters.AddWithValue("@ruc", ruc);

                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                        DatosSql nov = new DatosSql();
                            nov.razon = dr.GetValue(0).ToString();
                            nov.cadena = dr.GetValue(1).ToString();
                        if (nov.cadena !="")
                        {
                            cambiarConf(nov.cadena);
                        }
                            rlist.Add(nov);
                        }
                        dr.Close();
                        cmd.Parameters.Clear();
                        cn.Close();
                }
            }
            
            return rlist.OrderBy(o => o.razon).ToList();
        }

        public class DatoEmpresa
        {
            public string RazonSocial { set; get; }
            public string Ruc { set; get; }
            public byte[] Image { set; get; }
            public string Estado { set; get; }
        }

        public static List<DatoEmpresa> ListDatoEmpresa(string ruc)
        {
            List<DatoEmpresa> rlist = new List<DatoEmpresa>();
            string SPnom = string.Empty;
            SPnom = "Sp_ListarDatos";
            using (SqlConnection cn = new SqlConnection(Conexion.getConexion(ruc)))
            {
                using (SqlCommand cmd = new SqlCommand(SPnom, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ruc", ruc);

                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DatoEmpresa nov = new DatoEmpresa();
                        nov.RazonSocial = dr.GetValue(0).ToString();
                        nov.Ruc = dr.GetValue(1).ToString();
                        byte[] imgData = (byte[])dr.GetValue(2);
                        nov.Image = imgData;
                        nov.Estado= dr.GetValue(3).ToString();
                        rlist.Add(nov);
                    }
                    dr.Close();
                    cmd.Parameters.Clear();
                    cn.Close();
                 }
            }
            
            return rlist.OrderBy(o => o.RazonSocial).ToList();
        }

    }
}
