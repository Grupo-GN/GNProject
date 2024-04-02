using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using Microsoft.ApplicationBlocks.Data;

namespace CAPA_DATOS
{
    public static class Dao_Procesos
    {
        /*FPS*/
        public static DataTable Lista_Procesos(Ent_Procesos objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Procesos", objE.Proceso_Id, objE.Estado_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Buscar_Procesos_ById(string idProceso)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Procesos_MS_Buscar_ById", idProceso);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Lista_Procesos(string proceso)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Procesos_MS_Buscar", proceso );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Procesos(Ent_Procesos objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_Procesos", objE.Proceso, objE.Estado_Id, objE.Proc_Reintegro_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Procesos(Ent_Procesos objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spu_Procesos", objE.Proceso_Id, objE.Proceso, objE.Estado_Id, objE.Proc_Reintegro_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Procesos(Ent_Procesos objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spd_Procesos", objE.Proceso_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
