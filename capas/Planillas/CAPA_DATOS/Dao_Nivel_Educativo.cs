using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Microsoft.ApplicationBlocks.Data;
using CAPA_ENTIDAD;

namespace CAPA_DATOS
{
    public static class Dao_Nivel_Educativo
    {
        /*FPS*/
        public static DataTable Lista_Nivel_Educativo(Ent_Nivel_Educativo objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Nivel_Educativo", objE.Nivel_Educativo_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Nivel_Educativo(Ent_Nivel_Educativo objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_Nivel_Educativo", objE.Descripcion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Nivel_Educativo(Ent_Nivel_Educativo objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spu_Nivel_Educativo", objE.Nivel_Educativo_Id, objE.Descripcion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Nivel_Educativo(Ent_Nivel_Educativo objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spd_Nivel_Educativo", objE.Nivel_Educativo_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
