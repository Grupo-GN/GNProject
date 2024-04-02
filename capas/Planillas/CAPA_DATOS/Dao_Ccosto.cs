using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using Microsoft.ApplicationBlocks.Data;

namespace CAPA_DATOS
{
    public static class Dao_Ccosto
    {
        /*FPS*/
        public static DataTable Lista_Ccosto(Ent_Ccosto objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Ccosto", objE.Ccosto_Id, objE.Descripcion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Ccosto(Ent_Ccosto objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_Ccosto", objE.Ccosto_Id, objE.Descripcion, objE.Estado_Id, objE.Dpto, objE.Prov, objE.Dist, objE.Codigo_Auxiliar);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Ccosto(Ent_Ccosto objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spu_Ccosto", objE.Ccosto_Id, objE.Descripcion, objE.Estado_Id, objE.Dpto, objE.Prov, objE.Dist, objE.Codigo_Auxiliar);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Ccosto(Ent_Ccosto objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spd_Ccosto", objE.Ccosto_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
