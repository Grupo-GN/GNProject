using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using Microsoft.ApplicationBlocks.Data;

namespace CAPA_DATOS
{
    public static class Dao_Planilla
    {
        /*FPS*/
        public static DataTable Lista_Planilla(Ent_Planilla objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Planilla", objE.Planilla_Id, objE.Descripcion, objE.Compania_Id, objE.Estado_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Planilla(Ent_Planilla objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_Planilla", objE.Descripcion, objE.Compania_Id, objE.Periodicidad_Id, objE.Estado_Id, objE.Planilla_Master_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Planilla(Ent_Planilla objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spu_Planilla", objE.Planilla_Id, objE.Descripcion, objE.Compania_Id, objE.Periodicidad_Id, objE.Estado_Id, objE.Planilla_Master_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Planilla(Ent_Planilla objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spd_Planilla", objE.Planilla_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
