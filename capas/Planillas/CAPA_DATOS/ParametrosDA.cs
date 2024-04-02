using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;

namespace CAPA_DATOS
{
    public class CompaniaSMTP
    {
        public String Host { get; set; }
        public Int32 Port { get; set; }
        public Boolean SSL { get; set; }
        public String MailAddress { get; set; }
        public String DisplayName { get; set; }
        public String Usuario { get; set; }
        public String Clave { get; set; }
    }

    public static class ParametrosDA
    {
        public static CompaniaSMTP getCompania_SMTP()
        {
            CAPA_ENTIDAD.Ent_Compania CompaniaBE = new CAPA_ENTIDAD.Ent_Compania();
            CompaniaBE.Compania_Id = "01";
            System.Data.DataTable dtCompania = Dao_Compania.Lista_Compania(CompaniaBE);

            CompaniaSMTP oCompaniaSMTP = new CompaniaSMTP();
            oCompaniaSMTP.Host = dtCompania.Rows[0]["smtp_host"].ToString();
            oCompaniaSMTP.Port = Convert.ToInt32(dtCompania.Rows[0]["smtp_port"]);
            oCompaniaSMTP.SSL = Convert.ToBoolean(dtCompania.Rows[0]["smtp_ssl"]);
            oCompaniaSMTP.MailAddress = dtCompania.Rows[0]["smtp_mail_address"].ToString();
            oCompaniaSMTP.DisplayName = dtCompania.Rows[0]["smtp_display_name"].ToString();
            oCompaniaSMTP.Usuario = dtCompania.Rows[0]["smtp_user"].ToString();
            oCompaniaSMTP.Clave = dtCompania.Rows[0]["smtp_pwd"].ToString();

            return oCompaniaSMTP;
        }

        //public static string Host { get { return System.Configuration.ConfigurationManager.AppSettings["Host"].ToString(); } }
        //public static int Port { get { return int.Parse(System.Configuration.ConfigurationManager.AppSettings["Port"].ToString()); } }
        //public static Boolean SSL { get { return Convert.ToBoolean(Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SSL"].ToString())); } }
        //public static string MailAddress { get { return System.Configuration.ConfigurationManager.AppSettings["MailAddress"].ToString(); } }
        //public static string DisplayName { get { return System.Configuration.ConfigurationManager.AppSettings["DisplayName"].ToString(); } }
        //public static string Usuario { get { return System.Configuration.ConfigurationManager.AppSettings["Usuario"].ToString(); } }
        //public static string Clave { get { return System.Configuration.ConfigurationManager.AppSettings["Clave"].ToString(); } }
        //public static string FileServerPath { get => HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["FileServerPath"].ToString()); }

        private static string getFileServerPath_RUC()
        {
            return ConfigurationManager.AppSettings["FileServerPath"].ToString().Replace("{RUC}", Conex.getRUCEmpresa());
        }
        public static string FileServerPath
        {
            get
            {
                String path = getFileServerPath_RUC();
                if (path.Substring(0, 1) == "~") { path = HttpContext.Current.Server.MapPath(path); } //Si la ruta es virtual, se obtiene ruta física
                return path;
            }
        }

        internal static string GetDbConnectionString()
        {
            throw new NotImplementedException();
        }

        public static string FileServerPath_Plantilas { get { return HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["FileServerPath_Plantillas"].ToString()); } }
        public static string FileServer_RutaPlantillas { get { return FileServerPath_Plantilas + ConfigurationManager.AppSettings["RutaPlantillas"].ToString(); } }

        public static string FileServer_RutaDocumentos { get { return FileServerPath + ConfigurationManager.AppSettings["RutaDocumentos"].ToString(); } }
        public static string VirtualServer_RutaDocumentos
        {
            get
            {
                return ConfigurationManager.AppSettings["RutaServidor"].ToString()
                      + getFileServerPath_RUC().Replace("~/", "")
                      + ConfigurationManager.AppSettings["RutaDocumentos"].ToString();
            }
        }

    }
}
