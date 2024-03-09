using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            string cadena = System.Configuration.ConfigurationManager.ConnectionStrings["ContextEntityDiagram"].ConnectionString;
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
