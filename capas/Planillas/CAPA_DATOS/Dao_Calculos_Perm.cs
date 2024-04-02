using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Microsoft.ApplicationBlocks.Data;
using CAPA_ENTIDAD;

namespace CAPA_DATOS
{
    public static class Dao_Calculos_Perm
    {
        /*FPS*/
        public static DataTable Lista_Calculos_Perm(Ent_Calculos_Perm objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Calculos_Perm", objE.Periodo_Id, objE.Personal_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Calculos_Perm(Ent_Calculos_Perm objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_Calculos_Perm", objE.Planilla_Id, objE.Periodo_Id, objE.Concepto_Id, objE.Proceso_Id, objE.Valor, objE.Valor_Anterior);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Calculos_Perm_Genera(Ent_Calculos_Perm objE)
        {
            try
            {   
                /*Genera los calculos permanentes para todo el personal*/
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_Calculos_Perm_Genera", objE.Periodo_Id, objE.Personal_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Calculos_Perm(Ent_Calculos_Perm objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spu_Calculos_Perm", objE.Periodo_Id, objE.Personal_Id, objE.Concepto_Id, objE.Proceso_Id, objE.Valor, objE.Valor_Anterior);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Calculos_Perm_Masivo(Ent_Calculos_Perm objE, string delimitador, Int32 cant_registros)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spu_Calculos_Perm_Masivo", objE.Periodo_Id, objE.Personal_Id, objE.Concepto_Id_Masivo, objE.Proceso_Id_Masivo, objE.Valor_Masivo, objE.Valor_Anterior_Masivo, delimitador, cant_registros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Calculos_Perm(Ent_Calculos_Perm objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spd_Calculos_Perm", objE.Periodo_Id, objE.Personal_Id, objE.Concepto_Id, objE.Proceso_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
