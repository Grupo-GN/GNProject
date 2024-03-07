using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace GNProject.Acceso
{
    public class Parametros
    {
        public Parametros()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }
        public static String emailAdminSistema = ConfigurationManager.AppSettings["emailAdminSistema"].ToString();
        public static String CDOC_Ruta_LogoEmpresa = HttpContext.Current.Server.MapPath("~") + "\\img\\logo_empresa.png";
        public static String CDOC_FileServerPath = ConfigurationManager.AppSettings["CDOC_FileServerPath"].ToString();
        public static String CDOC_FileServer_RutaPersonas = CDOC_FileServerPath + ConfigurationManager.AppSettings["CDOC_Ruta_Personas"].ToString();
        public static String CDOC_VirtualServer_Personas = ConfigurationManager.AppSettings["RutaServidor"].ToString() + CDOC_FileServerPath.Replace("~/", "") + ConfigurationManager.AppSettings["CDOC_Ruta_Personas"].ToString();
        public static String CDOC_FileServer_RutaImgPersonas = CDOC_FileServerPath + ConfigurationManager.AppSettings["CDOC_Ruta_ImgPersonas"].ToString();
        public static String CDOC_VirtualServer_ImgPersonas = ConfigurationManager.AppSettings["RutaServidor"].ToString() + CDOC_FileServerPath.Replace("~/", "") + ConfigurationManager.AppSettings["CDOC_Ruta_ImgPersonas"].ToString();
        public static String CDOC_FileServer_RutaDocumentos = CDOC_FileServerPath + ConfigurationManager.AppSettings["CDOC_Ruta_Documentos"].ToString() +"_" + ClaseGlobal.Get_RUC_usuario()+"/";
        public static String CDOC_VirtualServer_Documentos = ConfigurationManager.AppSettings["RutaServidor"].ToString() + CDOC_FileServerPath.Replace("~/", "") + ConfigurationManager.AppSettings["CDOC_Ruta_Documentos"].ToString();

        public static Int32 CDOC_Max_Upload_File = Convert.ToInt32(ConfigurationManager.AppSettings["CDOC_Max_Upload_File"].ToString());
        public static String CDOC_Texto_Area = ConfigurationManager.AppSettings["CDOC_Texto_Area"].ToString();
        public static String CDOC_Texto_Seccion = ConfigurationManager.AppSettings["CDOC_Texto_Seccion"].ToString();
        public static String CDOC_MODO_RRHH = ConfigurationManager.AppSettings["CDOC_MODO_RRHH"].ToString();

        public const string OBJECTO_TODOS = "--Todos--";
        public const string OBJECTO_SELECCIONE = "--Seleccione--";
        public const string OBJECTO_NINGUNO = "--Ninguno--";

        public const string OBJECTO_ACTIVO = "Activo";
        public const string OBJECTO_INACTIVO = "Inactivo";

        public const string OBJETO_DNI = "01";
        public const string OBJETO_RUC = "02";

        public static class EstadosDocumento
        {
            public const string Vigente = "01";
            public const string VencidoPorRenovar = "02";
            public const string Renovadp = "03";
            public const string Anulado = "04";
            public const string Archivado = "05";
        }

        public static class Combo
        {
            public const string USUARIOS = "USUARIOS";
            public const string UBIGEO = "UBIGEO";
            public const string SEXO = "SEXO";
            public const string CARGO = "CARGO";
            public const string PLANILLA = "PLANILLA";
            public const string TIPO_CONTRATO = "TIPO_CONTRATO";
            public const string LOCALIDAD = "LOCALIDAD";
            public const string AREAS = "AREAS";
            public const string SECCION = "SECCION";
            public const string PERFIL = "PERFIL";
            public const string JEFE = "JEFE";
            public const string PERSONAS_JEFE = "PERSONAS_JEFE";
            public const string PLANTILLA_DOCUMENTOS = "PLANTILLA_DOCUMENTOS";
            public const string TIPO_ASIGNACION = "TIPO_ASIGNACION";
            public const string PERSONA_EMPRESA = "PERSONA_EMPRESA";
            public const string PERSONA = "PERSONA";
            public const string ESTADOS_DOC_REP = "ESTADOS_DOC_REP";

            public const string CDOC_TipoDocumentos = "CDOC_00001";
            public const string CDOC_TipoDatos = "CDOC_00002";
            public const string CDOC_TipoEmpresas = "CDOC_00003";
            public const string CDOC_MotivosCese = "CDOC_00005";
            public const string CDOC_GruposDocumento = "CDOC_00006";
            public const string CDOC_EstadosDocumento = "CDOC_00007";
            public const string CDOC_SubGruposDocumento = "CDOC_00008";
            public const string CDOC_TipoDoc_Archivos = "CDOC_00009";
        }

        public static class CDOC_Reportes
        {
            public const string RepSegDocumentos = "BandejaListaPrecios";
            public const string RepSegDocumentos_Det = "BandejaListaPrecios_Det";
            //public const string BandejaListaPrecios_Temporal = "BandejaListaPrecios_Temporal";
        }
    }
}