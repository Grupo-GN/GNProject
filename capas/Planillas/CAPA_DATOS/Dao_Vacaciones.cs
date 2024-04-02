using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using Microsoft.ApplicationBlocks.Data;

namespace CAPA_DATOS
{
    public static class Dao_Vacaciones
    {
        /*FPS*/
        public static DataTable Lista_Vacaciones(Ent_Vacaciones objE)
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Vacaciones", objE.Personal_Id);
        }

        public static DataSet Elimina_Vacaciones(Ent_Vacaciones objE)
        {
            return SqlHelper.ExecuteDataset(Conex.CadCon(), "fps_spd_Vacaciones", objE.Vacaciones_Id);
        }

        public static DataSet Genera_Vacaciones_Masivo(Ent_Vacaciones objE)
        {
            return SqlHelper.ExecuteDataset(Conex.CadCon(), "fps_spi_Vacaciones_Masivo", objE.Compania_Id, objE.Planilla_Id, objE.Personal_Id);
        }

        public static DataTable getProgVacaciones(Ent_Vacaciones objE)
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ProgramacionVacaciones", objE.Planilla_Id, objE.Periodo_Id, objE.Area_Id, objE.CatAuxiliar_Id, objE.fe_fin_desde, objE.fe_fin_hasta);
        }

        public static DataTable getVacacionesxId(String Personal_Id)
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaVacacionxPersonalId", Personal_Id);
        }

        public static DataTable ListaVacacionCantDias(String Vacacion_Id, DateTime FechaProceso)
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaVacacionCantDias", Vacacion_Id, FechaProceso);
        }

        public static DataTable ListaVacacionIndemnizacion(String Vacacion_Id)
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaVacacionIndemnizacion", Vacacion_Id);
        }

        public static DataTable ListaIndemnizacionCancelada(String Personal_Id)
        {
            String cmdText = "select * from Personal_IndemnizacionCancelada WHERE Personal_Id='" + Personal_Id + "'";
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), CommandType.Text, cmdText);
        }

        public static DataTable ListaIndemnizacionCanceladaDetalle(String Vacacion_Id)
        {
            String cmdText = "select * from Personal_IndemnizacionCanceladaDetalle WHERE Vacaciones_id='" + Vacacion_Id + "'";
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), CommandType.Text, cmdText);
        }

        public static DataTable ListaVacacionDet(String Vacacion_Id)
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaVacacionDet", Vacacion_Id);
        }

        public static DataTable DiasTruncaxPersonalId_UltimaFechaIngreso(String Personal_Id, DateTime FechaProceso, String Anio, String Anio_Anterior)
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_DiasTruncaxPersonalId_UltimaFechaIngreso", Personal_Id, FechaProceso, Anio, Anio_Anterior);
        }

        public static DataTable SaldoVacacionxPeriodo(String Planilla_Id, String Periodo_Id, String Area_Id, String CatAuxiliar_Id, DateTime FechaProceso)
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "pla_sps_vacaciones_saldo_periodo", Planilla_Id, Periodo_Id, Area_Id, CatAuxiliar_Id, FechaProceso);
        }
        

    }
}
