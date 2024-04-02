using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Microsoft.ApplicationBlocks.Data;
using CAPA_ENTIDAD;

namespace CAPA_DATOS
{
    public static class Dao_Personal_Establecimientos
    {
        /*FPS*/
        public static DataTable Lista_Personal_Establecimientos(Ent_Personal_Establecimientos objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Personal_Establecimientos", objE.Establecimiento_Id, objE.Personal_Id, objE.Periodo_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable Inserta_Personal_Establecimientos(Ent_Personal_Establecimientos objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_Personal_Establecimientos", objE.Personal_Id, objE.Periodo_Id, objE.Establecimiento_Id, objE.Tasa, objE.Destacado_Enviado, objE.Destacado_Recibido);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable Actualiza_Personal_Establecimientos(Ent_Personal_Establecimientos objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spu_Personal_Establecimientos", objE.Personal_Id, objE.Periodo_Id, objE.Establecimiento_Id, objE.Tasa, objE.Destacado_Enviado, objE.Destacado_Recibido);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable Elimina_Personal_Establecimientos(Ent_Personal_Establecimientos objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spd_Personal_Establecimientos", objE.Personal_Id, objE.Periodo_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable Inserta_Masivo_Personal_Establecimientos(Ent_Personal_Establecimientos objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_Personal_Establecimientos_Masivo", objE.Personal_Id, objE.Periodo_Id, objE.Establecimiento_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
