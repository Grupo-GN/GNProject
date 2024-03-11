using BusinessLogic.oConfigReporte;
using BusinessLogic.oPersonal;
using BusinessLogic.oReporteIncidente;
using Persistence;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.Indicendia01.Server.pReporteIncidente
{

    public partial class sReporteIncidente : System.Web.UI.Page
    {
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    String[] arr_Usuario_Perfil = System.Web.HttpContext.Current.User.Identity.Name.Split('|');
        //    String no_usuario = arr_Usuario_Perfil[1].ToString();
        //    lblUsuarioReg.InnerText = no_usuario;
        //}
        [WebMethod]
        public static string Get_Codigo_Generado()
        {
            return controller_ReporteIncidente.Get_Instance().Get_Codigo_Generado();
        }

        [WebMethod]
        public static List<Personal> Get_DataList_Responsable(string Nombres, string Usuario, string Area_Id)
        {
            return controller_ReporteIncidente.Get_Instance().Get_DataList_Responsable(Nombres, Usuario, Area_Id);
        }

        [WebMethod]
        public static string Registrar_ReporteIncidencia(
        string Personal_Registro, string Area_Id, string Categoria_Auxiliar_Id
        , string Categoria_Auxiliar2_Id, string Actividad_Propia, string Actividad_Rutinaria
         , string Intensidad_Id, string Descripcion
        , string Informar_Gerencia, string Informar_Osigermin, DateTime FechaHora_Incidente
        , string Lugar_Incidente, string Tipo, string Origen, string Severidad_Id, string LesionesPerdidas, string PosiblesCausas
        , string AccionInmediata, string Generado_Id, string TipoI_Id, string Afec_Id)
        {
            string proceso = controller_ReporteIncidente.Get_Instance().Registrar_ReporteIncidencia(Personal_Registro,
                Area_Id, Categoria_Auxiliar_Id, Categoria_Auxiliar2_Id, Actividad_Propia, Actividad_Rutinaria
                , Intensidad_Id, Descripcion, Informar_Gerencia, Informar_Osigermin, FechaHora_Incidente
        , Lugar_Incidente, Tipo, Origen, Severidad_Id, LesionesPerdidas, PosiblesCausas, AccionInmediata, Generado_Id, TipoI_Id, Afec_Id);

            if (bool.Parse(proceso.Split('#')[0].ToString()) == true)
            {
                string IncidenciaId = proceso.Split('#')[2].ToString();
                string rutaDel = HttpContext.Current.Server.MapPath("../../ArchivosIncidentes" + "/" + Generado_Id);
                string rutaSave = HttpContext.Current.Server.MapPath("../../ArchivosIncidentes" + "/" + IncidenciaId);
                if (System.IO.Directory.Exists(rutaDel))
                {
                    System.IO.Directory.Move(rutaDel, rutaSave);
                }
            }
            return proceso;
        }

        //ADD ACCION CORRECTIVA
        [WebMethod]
        public static bool Add_Accion_Correctiva(string Incidente_Id, string Descripcion, string Tipo_Responsable
            , string Responsable_Id, DateTime FechaIni, DateTime FechaFin)
        {
            return controller_ReporteIncidente.Get_Instance().Add_Accion_Correctiva(Incidente_Id, Descripcion, Tipo_Responsable
            , Responsable_Id, FechaIni, FechaFin);
        }

        [WebMethod]
        public static string EnviarCorreoGerencia_RegistroReporte(string Intensidad_Id)
        {
            return controller_ReporteIncidente.Get_Instance().EnviarCorreoGerencia_RegistroReporte(Intensidad_Id);
        }

        [WebMethod]
        public static string Get_SendCorreo_Administradores(string Intensidad_Id)
        {
            return controller_ReporteIncidente.Get_Instance().Get_SendCorreo_Administradores(Intensidad_Id);
        }

        [WebMethod]
        public static bool Get_Informar_Gerencia(string Intensidad_Id)
        {
            return controller_ReporteIncidente.Get_Instance().Get_Informar_Gerencia(Intensidad_Id);
        }

        [WebMethod]
        public static bool Get_Correos_Gerencia(string Area_Id)
        {
            return controller_ReporteIncidente.Get_Instance().Get_Correos_Gerencia(Area_Id);
        }



        #region DATOS DEL USUARIO

        [WebMethod]
        public static string Get_LocalidadyArea(string Area_Id, string Area_Id2)
        {
            return controller_ReporteIncidente.Get_Instance().Get_LocalidadyArea(Area_Id, Area_Id2);
        }

        #endregion

        //ELIMINAR TODOS LOS DATOS AL CANCELAR 
        [WebMethod]
        public static bool Eliminar_Datos_Generados_Cancel(string Generado_Id)
        {

            if (controller_ReporteIncidente.Get_Instance().Eliminar_Datos_Logicos(Generado_Id) == true)
            {
                //ELIMINAR DATOS FISICOS
                string rutaDel = HttpContext.Current.Server.MapPath("../../ArchivosIncidentes" + "/" + Generado_Id);
                if (System.IO.Directory.Exists(rutaDel))
                {
                    System.IO.Directory.Delete(rutaDel, true);
                }
                return true;

            }
            return false;

        }

        #region DATOS AUXILIARES

        [WebMethod]
        public static List<RH_Area> Get_Localidad_Combo()
        {
            return controller_DatosPersonal.Get_Instance().Get_Localidad_Combo();
        }
        //INTENSIDAD
        [WebMethod]
        public static List<Intensidad> Get_Intensidad_List()
        {
            return controller_CofigReporte.Get_Instance().Get_Intensidad_List();
        }
        //SEVERIDAD
        [WebMethod]
        public static List<Severidad> Get_Severidad_List()
        {
            return controller_CofigReporte.Get_Instance().Get_Severidad_List();
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


        [WebMethod]
        public static List<Tipo> Get_Tipo_List()
        {
            return controller_CofigReporte.Get_Instance().Get_Tipo_List();
        }
        [WebMethod]
        public static List<Origen> Get_Origen_List()
        {
            return controller_CofigReporte.Get_Instance().Get_Origen_List();
        }

        //TIPO DEL INCIDENTE
        [WebMethod]
        public static List<TipoIncidente> Get_TipoIncidente_List()
        {
            return controller_CofigReporte.Get_Instance().Get_TipoIncidente_List();
        }
        //TIPO DE AFECTADOS
        [WebMethod]
        public static List<AfectadoInc> Get_AfectadoInc_List()
        {
            return controller_CofigReporte.Get_Instance().Get_AfectadoInc_List();
        }


        //CAUSAS
        [WebMethod]
        public static List<CausaIncidente> Get_CausasTipo_Report(string Tipo)
        {
            return controller_CofigReporte.Get_Instance().Get_CausasTipo_Report(Tipo);
        }
        #endregion


        //CAUSAS

        [WebMethod]
        public static string Get_Add_CausaReporte_Detalle(string Incidente_Id, string Causa_Id, string Tipo)
        {
            return controller_ReporteIncidente.Get_Instance().Get_Add_CausaReporte_Detalle(Incidente_Id, Causa_Id, Tipo);
        }

        [WebMethod]
        public static string Get_Delete_CausaReporte_Detalle(string Incidente_Id, string Causa_Id)
        {
            return controller_ReporteIncidente.Get_Instance().Get_Delete_CausaReporte_Detalle(Incidente_Id, Causa_Id);
        }


        [WebMethod]
        public static ArrayList Get_Reg_CausaReporte_Detalle_List(string Incidente_Id, string Tipo)
        {
            return controller_ReporteIncidente.Get_Instance().Get_Reg_CausaReporte_Detalle_List(Incidente_Id, Tipo);
        }
    }
}