using BusinessLogic.oConfigReporte;
using BusinessLogic.oEditReporteIncidente;
using BusinessLogic.oEditReporteIncidentePlanta;
using BusinessLogic.oPersonal;
using BusinessLogic.oReporteIncidente;
using Presistence;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.Indicendia01.Server.pEditRepPlanta
{
    public partial class sEditRepPlanta : System.Web.UI.Page
    {
        [WebMethod]
        public static ArrayList Get_Find_ReporteIncidente(string Incidente_Id)
        {
            return controller_EditReportePlanta.Get_Instance().Get_Find_ReporteIncidente(Incidente_Id);
        }

        [WebMethod]
        public static ArrayList Get_AccionCorrectiva_List(string Incidente_Id)
        {
            return controller_EditReporteIncidente.Get_Instance().Get_AccionCorrectiva_List(Incidente_Id);
        }

        [WebMethod]
        public static List<File_Incidencia> Get_Files_Incidencia_List(string Incidente_Id)
        {
            return controller_EditReporteIncidente.Get_Instance().Get_Files_Incidencia_List(Incidente_Id);
        }

        [WebMethod]
        public static AccionCorrectiva Get_Find_AccionCorrectiva(string Incidente_Id, string Accion_Id)
        {
            return controller_EditReporteIncidente.Get_Instance().Get_Find_AccionCorrectiva(Incidente_Id, Accion_Id);
        }


        [WebMethod]
        public static List<Personal> Get_DataList_Responsable(string Nombres, string Usuario, string Area_Id)
        {
            return controller_EditReporteIncidente.Get_Instance().Get_DataList_Responsable(Nombres, Usuario, Area_Id);
        }



        [WebMethod]
        public static string Add_Accion_Correctiva(string Incidente_Id, string Descripcion, string Tipo_Responsable
            , string Responsable_Id, DateTime FechaIni, DateTime FechaFin)
        {
            return controller_EditReporteIncidente.Get_Instance().Add_Accion_Correctiva(Incidente_Id, Descripcion, Tipo_Responsable
            , Responsable_Id, FechaIni, FechaFin);
        }

        [WebMethod]
        public static string Get_Update_AccionCorrectiva(string Incidente_Id, string Accion_Id, string Descripcion, string Tipo_Responsable
            , string Responsable_Id, DateTime FechaIni, DateTime FechaFin)
        {
            return controller_EditReportePlanta.Get_Instance().Get_Update_AccionCorrectiva(Incidente_Id
                , Accion_Id, Descripcion, Tipo_Responsable
               , Responsable_Id, FechaIni, FechaFin);
        }

        [WebMethod]
        public static string Get_Desechar_Accion(string Incidente_Id, string Accion_Id)
        {
            return controller_EditReportePlanta.Get_Instance().Get_Desechar_Accion(Incidente_Id, Accion_Id);
        }


        [WebMethod]
        public static string Actualizar_ReporteIncidencia(
        string Incidente_Id, string Categoria_Auxiliar_Id
        , string Categoria_Auxiliar2_Id, string Actividad_Propia, string Actividad_Rutinaria
         , string Intensidad_Id, string Descripcion
        , string Informar_Gerencia, string Informar_Osigermin, string FechaHora_Incidente
        , string Lugar_Incidente, string Tipo, string Origen, string Severidad_Id, string LesionesPerdidas, string PosiblesCausas
        , string AccionInmediata, string TipoInc, string AfecInc)
        {
            string proceso = controller_EditReportePlanta.Get_Instance().Actualizar_ReporteIncidencia(Incidente_Id,
                 Categoria_Auxiliar_Id, Categoria_Auxiliar2_Id, Actividad_Propia, Actividad_Rutinaria
                , Intensidad_Id, Descripcion, Informar_Gerencia, Informar_Osigermin, FechaHora_Incidente
        , Lugar_Incidente, Tipo, Origen, Severidad_Id, LesionesPerdidas, PosiblesCausas, AccionInmediata, TipoInc, AfecInc);


            return proceso;
        }



        #region DATOS AUXILIARES
        [WebMethod]
        public static List<RH_Area> Get_Localidad_Combo()
        {
            return controller_DatosPersonal.Get_Instance().Get_Localidad_Combo();
        }

        [WebMethod]
        public static bool Get_Informar_Gerencia(string Intensidad_Id)
        {
            return controller_ReporteIncidente.Get_Instance().Get_Informar_Gerencia(Intensidad_Id);
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
        public static string Get_LocalidadyArea(string Area_Id, string Area_Id2)
        {
            return controller_ReporteIncidente.Get_Instance().Get_LocalidadyArea(Area_Id, Area_Id2);
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