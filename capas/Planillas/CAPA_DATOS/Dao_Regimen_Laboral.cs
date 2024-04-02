using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using Microsoft.ApplicationBlocks.Data;

namespace CAPA_DATOS
{
    public static class Dao_Regimen_Laboral
    {
        /*FPS*/
        public static DataTable Lista_Regimen_Laboral(Ent_Regimen_Laboral objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Regimen_Laboral", objE.Regimen_Laboral_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Regimen_Laboral(Ent_Regimen_Laboral objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_Regimen_Laboral", objE.Descripcion, objE.Abreviatura, objE.Sector_Privado, objE.Sector_Publico, objE.Otras_Entidades);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Regimen_Laboral(Ent_Regimen_Laboral objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spu_Regimen_Laboral", objE.Regimen_Laboral_Id, objE.Descripcion, objE.Abreviatura, objE.Sector_Privado, objE.Sector_Publico, objE.Otras_Entidades);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Regimen_Laboral(Ent_Regimen_Laboral objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spd_Regimen_Laboral", objE.Regimen_Laboral_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
