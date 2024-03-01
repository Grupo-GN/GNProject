using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GNProject.Acceso
{
    public class ClaseGlobal
    {
        public ClaseGlobal()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        public static String getPageName()
        {
            string[] arrResult = HttpContext.Current.Request.RawUrl.Split('/');
            String result = arrResult[arrResult.GetUpperBound(0)];

            /*Para obtener solo el nombre de la pagina sin la extensión [.aspx]*/
            //arrResult = result.Split('.');
            //result = arrResult[arrResult.GetLowerBound(0)];

            return result;
        }

        public static String getUsuarioRed()
        {
            String no_usuario_red = System.Web.HttpContext.Current.Request.ServerVariables["LOGON_USER"];
            return no_usuario_red;
        }
        public static String getEstacionRed()
        {
            /*
            System.Net.IPHostEntry host;
            host = System.Net.Dns.GetHostEntry(System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_HOST"]);
            String clientComputerName = host.HostName;
            return clientComputerName;
            */
            String no_estacion_red = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_HOST"];
            return no_estacion_red;
        }

        public static String Get_login_usuario()
        {
            String[] arr_Usuario_Perfil = System.Web.HttpContext.Current.User.Identity.Name.Split('|');
            String nu_dni = arr_Usuario_Perfil[0].ToString();
            return nu_dni;
        }
        public static String Get_nombrecompleto_usuario()
        {
            String[] arr_Usuario_Perfil = System.Web.HttpContext.Current.User.Identity.Name.Split('|');
            String no_usuario = arr_Usuario_Perfil[0].ToString();
            return no_usuario;
        }
        public static Int32 Get_IdPerfil_usuario()
        {
            String[] arr_Usuario_Perfil = System.Web.HttpContext.Current.User.Identity.Name.Split('|');
            Int32 id_perfil = Convert.ToInt32(arr_Usuario_Perfil[4]);
            return id_perfil;
        }
        public static String Get_NomPerfil_usuario()
        {
            String[] arr_Usuario_Perfil = System.Web.HttpContext.Current.User.Identity.Name.Split('|');
            String no_perfil = arr_Usuario_Perfil[3].ToString();
            return no_perfil;
        }
        public static Int32 Get_IdUsuario_usuario()
        {
            String[] arr_Usuario_Perfil = System.Web.HttpContext.Current.User.Identity.Name.Split('|');
            Int32 id_usuario = Convert.ToInt32(arr_Usuario_Perfil[4]);
            return id_usuario;
        }
        public static String Get_RUC_usuario()
        {
            String[] arr_Usuario_Perfil = System.Web.HttpContext.Current.User.Identity.Name.Split('|');
            String no_ruc = arr_Usuario_Perfil[5].ToString();
            return no_ruc;
        }

        //////private static String[] Get_CodsOpciones_usuario()
        //////{
        //////    String[] arr_Usuario_Perfil = System.Web.HttpContext.Current.User.Identity.Name.Split('|');
        //////    String[] codsOpciones = arr_Usuario_Perfil[5].Split('$');
        //////    return codsOpciones;
        //////}
        //////public static Boolean AccesoOpcion(String codOpcion)
        //////{
        //////    Boolean flAcceso = false;
        //////    String[] codsOpciones = Get_CodsOpciones_usuario();
        //////    String value = Array.Find(codsOpciones, opc => opc == codOpcion);
        //////    if (!String.IsNullOrEmpty(value))
        //////    {
        //////        flAcceso = true;
        //////    }

        //////    return flAcceso;
        //////}

        #region "Manejo de errores no controlados por aplicativo"
        public static System.Exception LastError;
        public static string getMensajeError()
        {
            while (LastError.InnerException != null)
            {
                LastError = LastError.InnerException;
            }
            return LastError.Message;
        }
        #endregion
    }

    public class JQGridJsonResponse
    {
        public int CurrentPage = 1;
        public int RecordCount = 0;
        public List<JQGridJsonResponseRow> Items;
        public int PageCount = 0;
        public Hashtable userData = null;

        public JQGridJsonResponse(Int32 pageCount, Int32 currentPage, Int32 recordCount)
        {
            CurrentPage = currentPage;
            RecordCount = recordCount;
            PageCount = pageCount;
            Items = new List<JQGridJsonResponseRow>();
        }
    }

    public class JQGridJsonResponseRow
    {
        public string ID;
        public object Row;
    }
}