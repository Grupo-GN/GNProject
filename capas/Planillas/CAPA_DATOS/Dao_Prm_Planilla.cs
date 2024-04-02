using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Microsoft.ApplicationBlocks.Data;
using CAPA_ENTIDAD;

namespace CAPA_DATOS
{
    public static class Dao_Prm_Planilla
    {
        /*FPS*/
        public static DataTable Lista_Prm_Planilla(Ent_Prm_Planilla objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Prm_Planilla", objE.Periodo_Id, objE.Planilla_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Prm_Planilla(Ent_Prm_Planilla objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_Prm_Planilla", objE.Periodo_Id, objE.Planilla_Id, objE.Concepto_Id, objE.Valor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Prm_Planilla_Genera(Ent_Prm_Planilla objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_Prm_Planilla_Genera", objE.Periodo_Id, objE.Planilla_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Prm_Planilla(Ent_Prm_Planilla objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spu_Prm_Planilla", objE.Periodo_Id, objE.Planilla_Id, objE.Concepto_Id, objE.Valor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Prm_Planilla_Masivo(Ent_Prm_Planilla objE, string delimitador, Int32 cant_registros)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spu_Prm_Planilla_Masivo", objE.Periodo_Id, objE.Planilla_Id, objE.Concepto_Id_Masivo, objE.Valor_Masivo, delimitador, cant_registros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Prm_Planilla(Ent_Prm_Planilla objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spd_Prm_Planilla", objE.Periodo_Id, objE.Planilla_Id, objE.Concepto_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
