using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using Microsoft.ApplicationBlocks.Data;

namespace CAPA_DATOS
{
    public static class Dao_Tipo_Contrato
    {
        /*FPS*/
        public static DataTable Lista_Tipo_Contrato(Ent_Tipo_Contrato objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Tipo_Contrato", objE.Tipo_Contrato_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Tipo_Contrato(Ent_Tipo_Contrato objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_Tipo_Contrato", objE.Descripcion, objE.Abreviatura);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Tipo_Contrato(Ent_Tipo_Contrato objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spu_Tipo_Contrato", objE.Tipo_Contrato_Id, objE.Descripcion, objE.Abreviatura);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Tipo_Contrato(Ent_Tipo_Contrato objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spd_Tipo_Contrato", objE.Tipo_Contrato_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
