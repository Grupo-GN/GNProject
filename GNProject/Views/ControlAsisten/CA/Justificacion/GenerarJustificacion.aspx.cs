using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presistence;
using BusienssLogic.CA.oGenerarJustificacion;
using BusienssLogic.CA.oCompensaciones;
using System.Web.Services;
using System.Collections;
using BusienssLogic.CA.oGenerarPermisos;
using System.Data;

namespace GNProject.Views.ControlAsisten.CA.Justificacion
{
    public partial class GenerarJustificacion : System.Web.UI.Page
    {
        [WebMethod]
        public static Periodo_Asistencia Get_Periodo_Activo_Asistencia()
        {
            return controller_GenerarJustificacion.Get_Instance().Get_Periodo_Activo_Asistencia();
        }

        [WebMethod]
        public static string Get_Periodo_Planilla(string Periodo, string Personal_Id)
        {
            return controller_GenerarJustificacion.Get_Instance().Get_Periodo_Planilla(Periodo, Personal_Id);
        }

        #region PERSONAL

        [WebMethod]
        public static ArrayList Get_DatosPersonal(string Personal_Id, string Periodo_Id)
        {
            return controller_GenerarJustificacion.Get_Instance().Get_DatosPersonal(Personal_Id, Periodo_Id);
        }
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
        #region JUSTIFICACION
        [WebMethod]
        public static JustificacionEdit Get_Justificacion_Find(int Asistencia_Id)
        {
            return controller_GenerarJustificacion.Get_Instance().Get_Justificacion_Find(Asistencia_Id);
        }

        [WebMethod]
        public static string Get_AM_Justificacion(DateTime Fecha, string Tipo, string Personal_Id, string NewHora, string TipoRegistro, string Motivo, string PersoModif)
        {
            return controller_GenerarJustificacion.Get_Instance().Get_AM_Justificacion(Fecha, Tipo, Personal_Id, NewHora, TipoRegistro, Motivo, PersoModif);
        }

        [WebMethod]
        public static List<string> Get_Files_Jusitificacion(int Asistencia_Id)
        {
            return controller_GenerarJustificacion.Get_Instance().Get_Files_Jusitificacion(Asistencia_Id);
        }
        #endregion
        #region PERMISOS

        [WebMethod]
        public static ArrayList Get_Tipo_Permisos()
        {
            return controller_GenerarPermisos.Get_Instance().Get_Tipo_Permisos();
        }
        [WebMethod]
        public static ArrayList Get_Permisos_Fecha_By_Personal(string Personal_Id, DateTime FechaIni, DateTime FechaFin)
        {
            return controller_GenerarPermisos.Get_Instance().Get_Permisos_Fecha_By_Personal(Personal_Id, FechaIni, FechaFin);
        }
        [WebMethod]
        public static string Get_AM_Permisos_Fechas(int PermisoD_Id, int TPermiso_Id, string Personal_ID, DateTime FechaIni, DateTime FechaFin, string Descuento, string TipoReg, string Motivo, string NroDoc, string PersoModif)
        {
            return controller_GenerarPermisos.Get_Instance().Get_AM_Permisos_Fechas(PermisoD_Id, TPermiso_Id, Personal_ID, FechaIni, FechaFin, Descuento, TipoReg, Motivo, NroDoc, PersoModif);
        }
        [WebMethod]
        public static ArrayList Get_Permiso_Fechas_Find(int PermisoD_Id)
        {
            return controller_GenerarPermisos.Get_Instance().Get_Permiso_Fechas_Find(PermisoD_Id);
        }

        [WebMethod]
        public static string Get_Aplica_Descuento_By_TPermiso(int TPermiso_Id)
        {
            return controller_GenerarPermisos.Get_Instance().Get_Aplica_Descuento_By_TPermiso(TPermiso_Id);
        }

        [WebMethod]
        public static string Get_Cancelar_SolicitudPermisoDias(int PermisoD_Id, string PersoModif)
        {
            return controller_GenerarPermisos.Get_Instance().Get_Cancelar_SolicitudPermisoDias(PermisoD_Id, PersoModif);
        }



        [WebMethod]
        public static List<VacacionesPropuesta> Get_DetalleVacaciones(string Personal_Id, DateTime FechaIni, DateTime FechaFin)
        {
            return controller_GenerarPermisos.Get_Instance().Get_DetalleVacaciones(Personal_Id, FechaIni, FechaFin);
        }

        #endregion
        #region PERMISOS HORAS

        [WebMethod]
        public static ArrayList Get_Permisos_Horas_By_Personal(string Personal_Id, DateTime FechaIni, DateTime FechaFin)
        {
            return controller_GenerarPermisos.Get_Instance().Get_Permisos_Horas_By_Personal(Personal_Id, FechaIni, FechaFin);
        }
        [WebMethod]
        public static string Get_AM_Permisos_Horas(int PermisoH_Id, int TPermiso_Id, string Personal_ID, DateTime Fecha, DateTime HoraIni, DateTime HoraFin, string Descuento, string TipoReg, string Motivo, string PersoModif, int AplicarIngSal)
        {
            return controller_GenerarPermisos.Get_Instance().Get_AM_Permisos_Horas(PermisoH_Id, TPermiso_Id, Personal_ID, Fecha, HoraIni, HoraFin, Descuento, TipoReg, Motivo, PersoModif, AplicarIngSal);
        }
        [WebMethod]
        public static ArrayList Get_Permiso_Horas_Find(int PermisoH_Id)
        {
            return controller_GenerarPermisos.Get_Instance().Get_Permiso_Horas_Find(PermisoH_Id);
        }
        [WebMethod]
        public static string Get_Cancelar_SolicitudPermisoHoras(int PermisoH_Id, string PersoModif)
        {
            return controller_GenerarPermisos.Get_Instance().Get_Cancelar_SolicitudPermisoHoras(PermisoH_Id, PersoModif);
        }

        #endregion
        #region Compensaciones

        [WebMethod]
        public static ArrayList Get_Lista_Tardanza(string Personal_ID)
        {
            return ControllerCompensaciones.Get_Instance().Lista_PersonalTardanza(Personal_ID);
        }

        [WebMethod]
        public static ArrayList Get_Lista_Falta(string Personal_ID)
        {
            return ControllerCompensaciones.Get_Instance().Lista_PersonalFaltas(Personal_ID);
        }
        [WebMethod]
        public static ArrayList Get_Lista_HorasLab(string Personal_ID)
        {
            return ControllerCompensaciones.Get_Instance().Lista_HorasLab(Personal_ID);
        }

        [WebMethod]
        public static DataTable getdt(List<string> Rlist)
        {
            return ControllerCompensaciones.Get_Instance().FunDT(Rlist);
        }
        [WebMethod]
        public static string Insert_Compensacion(string id_personal, string fecha_compensacion, string mod_conpensacion, int can_compensadas, string motivo, string estado, List<string> Rlist)
        {
            return ControllerCompensaciones.Get_Instance().Insert_Compensacion(id_personal, fecha_compensacion, mod_conpensacion, can_compensadas, motivo, estado, Rlist);
        }

        [WebMethod]
        public static ArrayList ListaCompCab(string Personal_ID)
        {


            return ControllerCompensaciones.Get_Instance().ListaCompCab(Personal_ID);

        }

        [WebMethod]
        public static ArrayList ListaCompdet(int id_comp)
        {


            return ControllerCompensaciones.Get_Instance().ListaCompdet(id_comp);

        }
        [WebMethod]

        public static string UpdateEstado(int id_comp, string estado)
        {
            return ControllerCompensaciones.Get_Instance().UpdateEstado(id_comp, estado);
        }
        [WebMethod]
        public static ArrayList ListHETotal(string Personal_Id)
        {
            return ControllerCompensaciones.Get_Instance().ListHETotal(Personal_Id);
        }
        [WebMethod]
        public static ArrayList getListBolDetHE(string Personal_Id)
        {
            return ControllerCompensaciones.Get_Instance().ListBolDetHE(Personal_Id);
        }
        [WebMethod]
        public static string Update_Bolsa_HE(List<string> Rlist)
        {
            return ControllerCompensaciones.Get_Instance().Update_Bolsa_HE(Rlist);

        }
        [WebMethod]
        public static string Get_Variables(string flat)
        {
            return ControllerCompensaciones.Get_Instance().Get_Variables(flat);

        }

        #endregion    
    }
}