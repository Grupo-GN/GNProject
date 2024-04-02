using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Microsoft.ApplicationBlocks.Data;
using CAPA_ENTIDAD;

namespace CAPA_DATOS
{
    public static class Dao_AFP
    {
        /*FPS*/
        public static DataTable Lista_Afp(Ent_AFP objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Afp", objE.Afp_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Afp(Ent_AFP objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_Afp", objE.Descripcion, objE.Estado_id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Afp(Ent_AFP objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spu_Afp", objE.Afp_Id, objE.Descripcion, objE.Estado_id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Afp(Ent_AFP objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spd_Afp", objE.Afp_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
