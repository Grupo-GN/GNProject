using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using Microsoft.ApplicationBlocks.Data;

namespace CAPA_DATOS
{
    public static class Dao_Compania_Externa_Establecimientos
    {
        /*FPS*/
        public static DataTable Lista_Compania_Externa_Establecimientos(Ent_Compania_Externa_Establecimientos objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Compania_Externa_Establecimientos", objE.Cia_Ext_Establec_Id, objE.Compania_Externa_Id, objE.Descripcion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Compania_Externa_Establecimientos(Ent_Compania_Externa_Establecimientos objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_Compania_Externa_Establecimientos", objE.Compania_Externa_Id, objE.Descripcion, objE.CentroRiesgo, objE.Codigo_Establecimiento, objE.Tasa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Compania_Externa_Establecimientos(Ent_Compania_Externa_Establecimientos objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spu_Compania_Externa_Establecimientos", objE.Cia_Ext_Establec_Id, objE.Compania_Externa_Id, objE.Descripcion, objE.CentroRiesgo, objE.Codigo_Establecimiento, objE.Tasa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Compania_Externa_Establecimientos(Ent_Compania_Externa_Establecimientos objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spd_Compania_Externa_Establecimientos", objE.Cia_Ext_Establec_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
