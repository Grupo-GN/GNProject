using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using Microsoft.ApplicationBlocks.Data;

namespace CAPA_DATOS
{
    public static class Dao_Tipo_Trabajador
    {
        /*FPS*/
        public static DataTable Lista_Tipo_Trabajador(Ent_Tipo_Trabajador objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Tipo_Trabajador", objE.Tipo_Trabajador_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Tipo_Trabajador(Ent_Tipo_Trabajador objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_Tipo_Trabajador", objE.Descripcion, objE.Abreviatura, objE.Sector_Privado, objE.Sector_Publico, objE.Otras_Entidades);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Tipo_Trabajador(Ent_Tipo_Trabajador objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spu_Tipo_Trabajador", objE.Tipo_Trabajador_Id, objE.Descripcion, objE.Abreviatura, objE.Sector_Privado, objE.Sector_Publico, objE.Otras_Entidades);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Tipo_Trabajador(Ent_Tipo_Trabajador objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spd_Tipo_Trabajador", objE.Tipo_Trabajador_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
