using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Collections;
using BusienssLogic.CA.oAprobarJustandPermRRHH;
using BusienssLogic.CA.oFiltros;
using Presistence;
using BusienssLogic.CA.oGenerarPermisos;

namespace GNProject.Views.ControlAsisten.CA.Justificacion
{
    public partial class JustificacionRRHH : System.Web.UI.Page
    {
        [WebMethod]
        public static ArrayList Get_Planilla_List()
        {
            return controller_AprobarJustandPermRRHH.Get_Instance().Get_Planilla_List();
        }

        [WebMethod]
        public static ArrayList Get_Localidad_List()
        {
            //return controller_AprobarJustandPermRRHH.Get_Instance().Get_Localidad_List();
            return controller_FiltrosCA.Get_Instance().Get_Localidad_List_New("");
        }

        [WebMethod]
        public static ArrayList Get_Categoria_List()
        {
            return controller_AprobarJustandPermRRHH.Get_Instance().Get_Categoria_List();
        }

        [WebMethod]
        public static ArrayList Get_Personal_List(string Planilla_Id, string Periodo, string Localidad_Id, string Categoria_Id)
        {
            return controller_AprobarJustandPermRRHH.Get_Instance().Get_Personal_List(Planilla_Id, Periodo, Localidad_Id, Categoria_Id);
        }

        [WebMethod]
        public static Periodo_Asistencia Get_Periodo_Activo_Asistencia()
        {
            return controller_AprobarJustandPermRRHH.Get_Instance().Get_Periodo_Activo_Asistencia();
        }

        #region JUSTIFICACIONES PENDIENTES
        [WebMethod]
        public static List<Justif> Get_Justificaciones_Pendientes_Jefe(string Personal_Id, DateTime FechaIni, DateTime FechaFin)
        {
            return controller_AprobarJustandPermRRHH.Get_Instance().Get_Justificaciones_Pendientes_Jefe(Personal_Id, FechaIni, FechaFin);
        }
        [WebMethod]
        public static ArrayList Get_Justiticacion_Find(int Asistencia_Id)
        {
            return controller_AprobarJustandPermRRHH.Get_Instance().Get_Justiticacion_Find(Asistencia_Id);
        }

        [WebMethod]
        public static string Get_AA_Justificacion(int Justificacion_Id, string NewHora, string PersoModif)
        {
            return controller_AprobarJustandPermRRHH.Get_Instance().Get_AA_Justificacion(Justificacion_Id, NewHora, PersoModif);
        }

        [WebMethod]
        public static string Get_AprobarDesaprobar_Justificacion(int Justificacion_Id, string Estado, string PersoModif)
        {
            return controller_AprobarJustandPermRRHH.Get_Instance().Get_AprobarDesaprobar_Justificacion(Justificacion_Id, Estado, PersoModif);
        }
        [WebMethod]
        public static string Proc_AprobarJustificacion(int[] Asistencia_Id, string PersoModif)
        {
            return controller_AprobarJustandPermRRHH.Get_Instance().Proc_AprobarJustificacion(Asistencia_Id, PersoModif);
        }
        #endregion

        #region PERMISOS FECHAS

        [WebMethod]
        public static ArrayList Get_Permisos_Pendientes_Personal(string Personal_Id, DateTime FechaIni, DateTime FechaFin)
        {
            return controller_AprobarJustandPermRRHH.Get_Instance().Get_Permisos_Pendientes_Personal(Personal_Id, FechaIni, FechaFin);
        }
        [WebMethod]
        public static string Get_AprobarDesaprobar_Permiso_Fechas(int PermisoD_Id, string Comentarios, string Estado, string PersoModif)
        {
            return controller_AprobarJustandPermRRHH.Get_Instance().Get_AprobarDesaprobar_Permiso_Fechas(PermisoD_Id, Comentarios, Estado, PersoModif);
        }
        [WebMethod]
        public static string Get_AA_Permiso_Fechas(int PermisoD_Id, int TPermiso_Id, DateTime FechaIni, DateTime FechaFin, string Descuento, string NroDoc, string Comentarios, string PersoModif)
        {
            return controller_AprobarJustandPermRRHH.Get_Instance().Get_AA_Permiso_Fechas(PermisoD_Id, TPermiso_Id, FechaIni, FechaFin, Descuento, NroDoc, Comentarios, PersoModif);
        }
        #endregion

        #region PERMISOS HORAS

        [WebMethod]
        public static ArrayList Get_Permisos_Horas_Pendientes_Personal(string Personal_Id, DateTime FechaIni, DateTime FechaFin)
        {
            return controller_AprobarJustandPermRRHH.Get_Instance().Get_Permisos_Horas_Pendientes_Personal(Personal_Id, FechaIni, FechaFin);
        }
        [WebMethod]
        public static string Get_AprobarDesaprobar_Permiso_Horas(int PermisoH_Id, string Comentarios, string Estado, string PersoModif)
        {
            return controller_AprobarJustandPermRRHH.Get_Instance().Get_AprobarDesaprobar_Permiso_Horas(PermisoH_Id, Comentarios, Estado, PersoModif);
        }
        [WebMethod]
        public static string Get_AA_Permisos_Horas(int PermisoH_Id, int TPermiso_Id, DateTime Fecha, DateTime HoraIni, DateTime HoraFin, string Descuento, string Comentario, string PersoModif, int AplicarIngSal)
        {
            return controller_AprobarJustandPermRRHH.Get_Instance().Get_AA_Permisos_Horas(PermisoH_Id, TPermiso_Id, Fecha, HoraIni, HoraFin, Descuento, Comentario, PersoModif, AplicarIngSal);
        }

        [WebMethod]
        public static string Get_Cancelar_SolicitudPermisoDias(int PermisoD_Id, string PersoModif)
        {
            return controller_GenerarPermisos.Get_Instance().Get_Cancelar_SolicitudPermisoDias(PermisoD_Id, PersoModif);
        }

        #endregion
    }
}