using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;

/// <summary>
/// Summary description for Parametros
/// </summary>

namespace GNProject.Acceso.App_code_portal
{
    public class Parametros
    {
        public Parametros()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static String I_RutaServidor = ConfigurationManager.AppSettings["RutaServidor"].ToString();
        public static String I_Ruta_LogoEmpresa = HttpContext.Current.Server.MapPath("~") + "\\img\\logo_empresa.png";
        public static String I_emailAdminSistema = ConfigurationManager.AppSettings["emailAdminSistema"].ToString();
        public static String I_FileServerPath = ConfigurationManager.AppSettings["I_FileServerPath"].ToString();
        public static String I_FileServer_RutaImgUsers = I_FileServerPath + ConfigurationManager.AppSettings["I_Ruta_ImgUsers"].ToString();
        public static String I_FileServer_RutaContenidos = I_FileServerPath + ConfigurationManager.AppSettings["I_Ruta_Contenidos"].ToString();
        public static String I_FileServer_RutaCronogramaMes = I_FileServerPath + ConfigurationManager.AppSettings["I_Ruta_CronogramaMes"].ToString();
        public static String I_FileServer_RutaAnuncios = I_FileServerPath + ConfigurationManager.AppSettings["I_Ruta_Anuncios"].ToString();
        public static String I_FileServer_RutaBoletines = I_FileServerPath + ConfigurationManager.AppSettings["I_Ruta_Boletines"].ToString();
        public static String I_FileServer_RutaDocumentos = I_FileServerPath + ConfigurationManager.AppSettings["I_Ruta_Documentos"].ToString();
        public static String I_FileServer_RutaProcedimientos = I_FileServerPath + ConfigurationManager.AppSettings["I_Ruta_Procedimientos"].ToString();
        public static String I_FileServer_RutaFormatos = I_FileServerPath + ConfigurationManager.AppSettings["I_Ruta_Formatos"].ToString();
        public static String I_FileServer_RutaEventos = I_FileServerPath + ConfigurationManager.AppSettings["I_Ruta_Eventos"].ToString();
        public static String I_FileServer_RutaBeneficios = I_FileServerPath + ConfigurationManager.AppSettings["I_Ruta_Beneficios"].ToString();
        public static String I_FileServer_RutaVideos = I_FileServerPath + ConfigurationManager.AppSettings["I_Ruta_Videos"].ToString();
        public static String I_FileServer_RutaOHSAS = I_FileServerPath + ConfigurationManager.AppSettings["I_Ruta_OHSAS"].ToString();
        public static String I_FileServer_RutaPlantillaCorreo = I_FileServerPath + ConfigurationManager.AppSettings["I_Ruta_PlantillaCorreo"].ToString();

        public static String I_VirtualServer_ImgUsers = ConfigurationManager.AppSettings["RutaServidor"].ToString() + I_FileServerPath.Replace("~/", "") + ConfigurationManager.AppSettings["I_Ruta_ImgUsers"].ToString();
        public static String I_VirtualServer_Contenidos = ConfigurationManager.AppSettings["RutaServidor"].ToString() + I_FileServerPath.Replace("~/", "") + ConfigurationManager.AppSettings["I_Ruta_Contenidos"].ToString();
        public static String I_VirtualServer_CronogramaMes = ConfigurationManager.AppSettings["RutaServidor"].ToString() + I_FileServerPath.Replace("~/", "") + ConfigurationManager.AppSettings["I_Ruta_CronogramaMes"].ToString();
        public static String I_VirtualServer_Anuncios = ConfigurationManager.AppSettings["RutaServidor"].ToString() + I_FileServerPath.Replace("~/", "") + ConfigurationManager.AppSettings["I_Ruta_Anuncios"].ToString();
        public static String I_VirtualServer_Boletines = ConfigurationManager.AppSettings["RutaServidor"].ToString() + I_FileServerPath.Replace("~/", "") + ConfigurationManager.AppSettings["I_Ruta_Boletines"].ToString();
        public static String I_VirtualServer_Documentos = ConfigurationManager.AppSettings["RutaServidor"].ToString() + I_FileServerPath.Replace("~/", "") + ConfigurationManager.AppSettings["I_Ruta_Documentos"].ToString();
        public static String I_VirtualServer_Procedimientos = ConfigurationManager.AppSettings["RutaServidor"].ToString() + I_FileServerPath.Replace("~/", "") + ConfigurationManager.AppSettings["I_Ruta_Procedimientos"].ToString();
        public static String I_VirtualServer_Formatos = ConfigurationManager.AppSettings["RutaServidor"].ToString() + I_FileServerPath.Replace("~/", "") + ConfigurationManager.AppSettings["I_Ruta_Formatos"].ToString();
        public static String I_VirtualServer_Eventos = ConfigurationManager.AppSettings["RutaServidor"].ToString() + I_FileServerPath.Replace("~/", "") + ConfigurationManager.AppSettings["I_Ruta_Eventos"].ToString();
        public static String I_VirtualServer_Beneficios = ConfigurationManager.AppSettings["RutaServidor"].ToString() + I_FileServerPath.Replace("~/", "") + ConfigurationManager.AppSettings["I_Ruta_Beneficios"].ToString();
        public static String I_VirtualServer_Videos = ConfigurationManager.AppSettings["RutaServidor"].ToString() + I_FileServerPath.Replace("~/", "") + ConfigurationManager.AppSettings["I_Ruta_Videos"].ToString();
        public static String I_VirtualServer_OHSAS = ConfigurationManager.AppSettings["RutaServidor"].ToString() + I_FileServerPath.Replace("~/", "") + ConfigurationManager.AppSettings["I_Ruta_OHSAS"].ToString();
        public static String I_VirtualServer_PlantillaCorreo = ConfigurationManager.AppSettings["RutaServidor"].ToString() + I_FileServerPath.Replace("~/", "") + ConfigurationManager.AppSettings["I_Ruta_PlantillaCorreo"].ToString();

        public static Int32 I_Max_Upload_File = Convert.ToInt32(ConfigurationManager.AppSettings["I_Max_Upload_File"].ToString());
        public static Int32 I_Max_Upload_Imagen = Convert.ToInt32(ConfigurationManager.AppSettings["I_Max_Upload_Imagen"].ToString());
        public static String I_Texto_Localidad = ConfigurationManager.AppSettings["I_Texto_Localidad"].ToString();
        public static String I_Texto_CategoriaAuxiliar = ConfigurationManager.AppSettings["I_Texto_CategoriaAuxiliar"].ToString();
        public static String I_Texto_CategoriaAuxiliar2 = ConfigurationManager.AppSettings["I_Texto_CategoriaAuxiliar2"].ToString();
        public static String I_NombreEmpresa = ConfigurationManager.AppSettings["I_NombreEmpresa"].ToString();
        public static String I_NombreProyecto = ConfigurationManager.AppSettings["I_NombreProyecto"].ToString();

        public const string OBJECTO_TODOS = "--Todos--";
        public const string OBJECTO_SELECCIONE = "--Seleccione--";
        public const string OBJECTO_NINGUNO = "--Ninguno--";

        public const string OBJECTO_ACTIVO = "Activo";
        public const string OBJECTO_INACTIVO = "Inactivo";

        public static class opcCodMaestroCombo
        {
            public const string CATEGORIA_AUXILIAR = "CATEGORIA_AUXILIAR";
            public const string OHSAS = "OHSAS";
        }

    }
}
