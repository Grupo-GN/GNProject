using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using Microsoft.ApplicationBlocks.Data;

namespace CAPA_DATOS
{
    public static class Dao_Tipo_Establecimiento
    {
        /*FPS*/
        public static DataTable Lista_Tipo_Establecimiento(Ent_Tipo_Establecimiento objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Tipo_Establecimiento", objE.Tipo_Establecimiento_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Tipo_Establecimiento(Ent_Tipo_Establecimiento objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_Tipo_Establecimiento", objE.Descripcion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Tipo_Establecimiento(Ent_Tipo_Establecimiento objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spu_Tipo_Establecimiento", objE.Tipo_Establecimiento_Id, objE.Descripcion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Tipo_Establecimiento(Ent_Tipo_Establecimiento objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spd_Tipo_Establecimiento", objE.Tipo_Establecimiento_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
