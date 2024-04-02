using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_AperturaCierrePeriodo
    {
        /*FPS*/
        public static DataTable btn_name_AperturaPeriodo(string Compania_Id, string Planilla_Id)
        {
            try
            {
                return Dao_AperturaCierrePeriodo.btn_name_AperturaPeriodo(Compania_Id, Planilla_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable btn_name_CierrePeriodo(string Compania_Id, string Planilla_Id)
        {
            try
            {
                return Dao_AperturaCierrePeriodo.btn_name_CierrePeriodo(Compania_Id, Planilla_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string Apertura_Periodo(Ent_Periodo objE)
        {
      
                return Dao_AperturaCierrePeriodo.Apertura_Periodo(objE);
     
        }

        public static DataTable Cierre_Periodo(Ent_Periodo objE)
        {
            try
            {
                return Dao_AperturaCierrePeriodo.Cierre_Periodo(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Limpiar_Periodo(Ent_Periodo objE)
        {
            try
            {
                return Dao_AperturaCierrePeriodo.Limpiar_Periodo(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int ActualizarAcumulados(string Periodo_Id)
        {
            try
            {
                return Dao_AperturaCierrePeriodo.ActualizarAcumulados(Periodo_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //20190228
        public static string GenerarConfiguracionAsientos(string PlanillaId, string EjercicioId)
        {
            return Dao_AperturaCierrePeriodo.GenerarConfiguracionAsientos(PlanillaId, EjercicioId);
        }
    }
}
