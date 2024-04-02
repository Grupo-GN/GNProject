using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using Microsoft.ApplicationBlocks.Data;

namespace CAPA_DATOS
{
    public static class Dao_Compania_Establecimiento
    {
        /*FPS*/
        public static DataTable Lista_Compania_Establecimiento(Ent_Compania_Establecimiento objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Compania_Establecimiento", objE.Establecimiento_Id, objE.Compania_Id, objE.Denominacion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Compania_Establecimiento(Ent_Compania_Establecimiento objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_Compania_Establecimiento", objE.Compania_Id, objE.Tipo_Establecimiento_Id, objE.Codigo_Establecimiento, objE.Denominacion, objE.CentroRiesgo, objE.Tasa, objE.Estado_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Compania_Establecimiento(Ent_Compania_Establecimiento objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spu_Compania_Establecimiento", objE.Establecimiento_Id, objE.Compania_Id, objE.Tipo_Establecimiento_Id, objE.Codigo_Establecimiento, objE.Denominacion, objE.CentroRiesgo, objE.Tasa, objE.Estado_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Compania_Establecimiento(Ent_Compania_Establecimiento objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spd_Compania_Establecimiento", objE.Establecimiento_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
