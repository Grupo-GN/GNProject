using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Microsoft.ApplicationBlocks.Data;
using CAPA_ENTIDAD;

namespace CAPA_DATOS
{
    public static class Dao_Bancos
    {
        /*FPS*/
        public static DataTable Lista_Bancos(Ent_Bancos objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Bancos", objE.Banco_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Bancos(Ent_Bancos objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_Bancos", objE.Descripcion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Bancos(Ent_Bancos objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spu_Bancos", objE.Banco_Id, objE.Descripcion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Bancos(Ent_Bancos objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spd_Bancos", objE.Banco_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
