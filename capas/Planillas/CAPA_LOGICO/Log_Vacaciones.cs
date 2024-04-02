using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Vacaciones
    {
        /*FPS*/
        public static DataTable Lista_Vacaciones(Ent_Vacaciones objE)
        {
            return Dao_Vacaciones.Lista_Vacaciones(objE);
        }

        public static DataSet Elimina_Vacaciones(Ent_Vacaciones objE)
        {
            return Dao_Vacaciones.Elimina_Vacaciones(objE);
        }

        public static DataSet Genera_Vacaciones_Masivo(Ent_Vacaciones objE)
        {
            return Dao_Vacaciones.Genera_Vacaciones_Masivo(objE);
        }

        public static DataTable getProgVacaciones(Ent_Vacaciones objE)
        {
            return Dao_Vacaciones.getProgVacaciones(objE);
        }

        public static DataTable getVacacionesxId(String Personal_Id)
        {
            return Dao_Vacaciones.getVacacionesxId(Personal_Id);
        }

        public static DataTable ListaVacacionCantDias(String Vacacion_Id, DateTime FechaProceso)
        {
            return Dao_Vacaciones.ListaVacacionCantDias(Vacacion_Id, FechaProceso);
        }

        public static DataTable ListaVacacionIndemnizacion(String Vacacion_Id)
        {
            return Dao_Vacaciones.ListaVacacionIndemnizacion(Vacacion_Id);
        }

        public static DataTable ListaIndemnizacionCancelada(String Personal_Id)
        {
            return Dao_Vacaciones.ListaIndemnizacionCancelada(Personal_Id);
        }

        public static DataTable ListaIndemnizacionCanceladaDetalle(String Vacacion_Id)
        {
            return Dao_Vacaciones.ListaIndemnizacionCanceladaDetalle(Vacacion_Id);
        }

        public static DataTable ListaVacacionDet(String Vacacion_Id)
        {
            return Dao_Vacaciones.ListaVacacionDet(Vacacion_Id);
        }

        public static DataTable DiasTruncaxPersonalId_UltimaFechaIngreso(String Personal_Id, DateTime FechaProceso, String Anio, String Anio_Anterior)
        {
            return Dao_Vacaciones.DiasTruncaxPersonalId_UltimaFechaIngreso(Personal_Id, FechaProceso, Anio, Anio_Anterior);
        }

        public static DataTable SaldoVacacionxPeriodo(String Planilla_Id, String Periodo_Id, String Area_Id, String CatAuxiliar_Id, DateTime FechaProceso)
        {
            return Dao_Vacaciones.SaldoVacacionxPeriodo(Planilla_Id, Periodo_Id, Area_Id, CatAuxiliar_Id, FechaProceso);
        }

    }
}
