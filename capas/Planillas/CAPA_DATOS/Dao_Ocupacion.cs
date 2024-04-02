using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using Microsoft.ApplicationBlocks.Data;

namespace CAPA_DATOS
{
    public static class Dao_Ocupacion
    {
        /*FPS*/
        public static DataTable Lista_Ocupacion(Ent_Ocupacion objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Ocupacion", objE.Ocupacion_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Ocupacion(Ent_Ocupacion objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_Ocupacion", objE.Ocupacion_Id, objE.Descripcion, objE.Regimen_Laboral_Id, objE.Ejecutivo, objE.Empleado, objE.Obrero);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Ocupacion(Ent_Ocupacion objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spu_Ocupacion", objE.Ocupacion_Id, objE.Descripcion, objE.Regimen_Laboral_Id, objE.Ejecutivo, objE.Empleado, objE.Obrero);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Ocupacion(Ent_Ocupacion objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spd_Ocupacion", objE.Ocupacion_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
