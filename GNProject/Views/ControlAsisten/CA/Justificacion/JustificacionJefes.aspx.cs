using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presistence;
using BusienssLogic.CA.oAprobarJustandPerm;
using System.Web.Services;
using System.Collections;
using BusienssLogic.CA.oGenerarJustificacion;
using BusienssLogic.CA.oGenerarPermisos;

namespace GNProject.Views.ControlAsisten.CA.Justificacion
{
    public partial class JustificacionJefes : System.Web.UI.Page
    {
        [WebMethod]
        public static ArrayList Get_Planilla_List()
        {
            return controller_AprobarJustanPerm.Get_Instace().Get_Planilla_List();
        }
        //antiguo
        [WebMethod]
        public static List<areas_planillas_sofya> Get_Localidades_List()
        {
            return controller_AprobarJustanPerm.Get_Instace().Get_Localidades_List();
        }
        //nuevo 02.10.2020
        [WebMethod]
        public static ArrayList Get_Localidad_List()
        {
            return controller_AprobarJustanPerm.Get_Instace().Get_Localidad_List();
        }

        [WebMethod]
        public static ArrayList Get_Categoria_List()
        {
            return controller_AprobarJustanPerm.Get_Instace().Get_Categoria_List();
        }
        [WebMethod]
        public static ArrayList Get_Personal_List(string Planilla_Id, string Periodo, string Localidad_Id, string Categoria_Id, string Jefe_Id)
        {
            return controller_AprobarJustanPerm.Get_Instace().Get_Personal_List(Planilla_Id, Periodo, Localidad_Id, Categoria_Id, Jefe_Id);
        }
        [WebMethod]
        public static Periodo_Asistencia Get_Periodo_Activo_Asistencia()
        {
            return controller_AprobarJustanPerm.Get_Instace().Get_Periodo_Activo_Asistencia();
        }
        [WebMethod]
        public static ArrayList Get_DatosPersonal(string Personal_Id)
        {
            return controller_AprobarJustanPerm.Get_Instace().Get_DatosPersonal(Personal_Id);
        }
        #region JUSTIFICACIONES PENDIENTES
        [WebMethod]
        public static List<Justif> Get_Justificaciones_Pendientes_Jefe(string Personal_Id, DateTime FechaIni, DateTime FechaFin, string Jefe_Id)
        {
            return controller_AprobarJustanPerm.Get_Instace().Get_Justificaciones_Pendientes_Jefe(Personal_Id, FechaIni, FechaFin, Jefe_Id);
        }
        [WebMethod]
        public static ArrayList Get_Justiticacion_Find(int Asistencia_Id)
        {
            return controller_AprobarJustanPerm.Get_Instace().Get_Justiticacion_Find(Asistencia_Id);
        }

        [WebMethod]
        public static string Get_AA_Justificacion(int Justificacion_Id, string NewHora, string PersoModif)
        {
            return controller_AprobarJustanPerm.Get_Instace().Get_AA_Justificacion(Justificacion_Id, NewHora, PersoModif);
        }

        [WebMethod]
        public static string Get_AprobarDesaprobar_Justificacion(int Justificacion_Id, string Estado, string PersoModif)
        {
            return controller_AprobarJustanPerm.Get_Instace().Get_AprobarDesaprobar_Justificacion(Justificacion_Id, Estado, PersoModif);
        }
        [WebMethod]
        public static string Proc_AprobarJustificacion(int[] Asistencia_Id, string PersoModif)
        {
            return controller_AprobarJustanPerm.Get_Instace().Proc_AprobarJustificacion(Asistencia_Id, PersoModif);
        }
        #endregion

        #region PERMISOS FECHAS

        [WebMethod]
        public static ArrayList Get_Permisos_Pendientes_Personal(string Personal_Id, DateTime FechaIni, DateTime FechaFin, string Jefe_Id)
        {
            return controller_AprobarJustanPerm.Get_Instace().Get_Permisos_Pendientes_Personal(Personal_Id, FechaIni, FechaFin, Jefe_Id);
        }
        [WebMethod]
        public static string Get_AprobarDesaprobar_Permiso_Fechas(int PermisoD_Id, string Comentarios, string Estado, string PersoModif)
        {
            return controller_AprobarJustanPerm.Get_Instace().Get_AprobarDesaprobar_Permiso_Fechas(PermisoD_Id, Comentarios, Estado, PersoModif);
        }
        [WebMethod]
        public static string Get_AA_Permiso_Fechas(int PermisoD_Id, int TPermiso_Id, DateTime FechaIni, DateTime FechaFin, string Descuento, string NroDoc, string Comentarios, string PersoModif)
        {
            return controller_AprobarJustanPerm.Get_Instace().Get_AA_Permiso_Fechas(PermisoD_Id, TPermiso_Id, FechaIni, FechaFin, Descuento, NroDoc, Comentarios, PersoModif);
        }
        #endregion

        #region PERMISOS HORAS

        [WebMethod]
        public static ArrayList Get_Permisos_Horas_Pendientes_Personal(string Personal_Id, DateTime FechaIni, DateTime FechaFin, string Jefe_Id)
        {
            return controller_AprobarJustanPerm.Get_Instace().Get_Permisos_Horas_Pendientes_Personal(Personal_Id, FechaIni, FechaFin, Jefe_Id);
        }
        [WebMethod]
        public static string Get_AprobarDesaprobar_Permiso_Horas(int PermisoH_Id, string Comentarios, string Estado, string PersoModif)
        {
            return controller_AprobarJustanPerm.Get_Instace().Get_AprobarDesaprobar_Permiso_Horas(PermisoH_Id, Comentarios, Estado, PersoModif);
        }
        [WebMethod]
        public static string Get_AA_Permisos_Horas(int PermisoH_Id, int TPermiso_Id, DateTime Fecha, DateTime HoraIni, DateTime HoraFin, string Descuento, string Comentario, string PersoModif, int AplicarIngSal)
        {
            return controller_AprobarJustanPerm.Get_Instace().Get_AA_Permisos_Horas(PermisoH_Id, TPermiso_Id, Fecha, HoraIni, HoraFin, Descuento, Comentario, PersoModif, AplicarIngSal);
        }
        #endregion
        #region PERSONAL

        /*[WebMethod]
        public static ArrayList Get_DatosPersonal(string Personal_Id, string Periodo_Id)
        {
            return controller_GenerarJustificacion.Get_Instance().Get_DatosPersonal(Personal_Id, Periodo_Id);
        }*/
        [WebMethod]
        public static List<MarcacionesMalPersonal> Get_Marcaciones_Malas_Personal(string Personal_Id, DateTime FechaIni, DateTime FechaFin)
        {
            return controller_GenerarJustificacion.Get_Instance().Get_Marcaciones_Malas_Personal(Personal_Id, FechaIni, FechaFin);
        }
        [WebMethod]
        public static List<MarcacionesCorPersonal> Get_Marcaciones_Correctas_Personal(string Personal_Id, DateTime FechaIni, DateTime FechaFin)
        {
            return controller_GenerarJustificacion.Get_Instance().Get_Marcaciones_Correctas_Personal(Personal_Id, FechaIni, FechaFin);
        }
        #endregion


        #region GENERARA JUSTIFICACIONES


        [WebMethod]
        public static string Get_AM_Justificacion_Otros(DateTime Fecha, string Tipo, string Personal_Id, string NewHora, string TipoRegistro, string Motivo, string TipoModif, string PersoModif, string Estado)
        {
            return controller_GenerarJustificacion.Get_Instance().Get_AM_Justificacion_Otros(Fecha, Tipo, Personal_Id, NewHora, TipoRegistro, Motivo, TipoModif, PersoModif, Estado);
        }

        [WebMethod]
        public static string Get_AM_Permisos_Fechas_Otros(int PermisoD_Id, int TPermiso_Id, string Personal_ID, DateTime FechaIni, DateTime FechaFin
            , string Descuento, string TipoReg, string Motivo, string NroDoc, string AproJefe, string ComentariosJefe
            , string AproRRHH, string ComentariosRRHH, string TipoModif, string PersoModif, string Estado)
        {
            return controller_GenerarPermisos.Get_Instance().Get_AM_Permisos_Fechas_Otros(PermisoD_Id, TPermiso_Id, Personal_ID, FechaIni, FechaFin, Descuento, TipoReg, Motivo, NroDoc, AproJefe, ComentariosJefe
            , AproRRHH, ComentariosRRHH, TipoModif, PersoModif, Estado);
        }



        [WebMethod]
        public static string Get_AM_Permisos_Horas_Otros(int PermisoH_Id, int TPermiso_Id, string Personal_ID, DateTime Fecha, DateTime HoraIni
            , DateTime HoraFin, string Descuento, string TipoReg, string AproJefe, string ComentariosJefe
            , string AproRRHH, string ComentariosRRHH, string Motivo, string PersoModif, string TipoModif, string Estado
            , int AplicarIngSal)
        {
            return controller_GenerarPermisos.Get_Instance().Get_AM_Permisos_Horas_Otros(PermisoH_Id, TPermiso_Id, Personal_ID, Fecha, HoraIni
            , HoraFin, Descuento, TipoReg, AproJefe, ComentariosJefe, AproRRHH, ComentariosRRHH, Motivo, PersoModif, TipoModif, Estado, AplicarIngSal);
        }


        #endregion      
    }
}