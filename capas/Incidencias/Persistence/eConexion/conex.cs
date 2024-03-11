using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
namespace Persistence.eConexion
{
    public class conex
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

        private static string buscaConexion()
        {
            String[] arr_Usuario_Perfil = System.Web.HttpContext.Current.User.Identity.Name.Split('|');
            String no_ruc = arr_Usuario_Perfil[5].ToString();
            no_ruc = "ContextEntityDiagram_" + no_ruc;
            string cadena = System.Configuration.ConfigurationManager.ConnectionStrings[no_ruc].ConnectionString;
            int extraer = cadena.IndexOf("data source", 0);
            string nuevaCadena = Mid(cadena, extraer, cadena.Length - extraer);
            nuevaCadena = nuevaCadena.Replace(";App=EntityFramework", "");
            nuevaCadena = nuevaCadena.Replace("multipleactiveresultsets=True" + '"', "");
            nuevaCadena = nuevaCadena.Replace("&quot", "");
            return nuevaCadena;
        }

        public static string getConexion()
        {
            //string server = "Data source=lUIs-VAIO;";
            //string bd = " Database=GN_GestionTalento;";
            //string seguridad = " Integrated Security=true";
            //return server + bd + seguridad;
            return buscaConexion();
        }
    }
}
