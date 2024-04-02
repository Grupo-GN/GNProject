using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using Microsoft.ApplicationBlocks.Data;

namespace CAPA_DATOS
{
    public static class Dao_TDoc_Identidad
    {
        /*FPS*/
        public static DataTable Lista_TDoc_Identidad(Ent_TDoc_Identidad objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_TDoc_Identidad", objE.Tipo_Doc_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_TDoc_Identidad(Ent_TDoc_Identidad objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_TDoc_Identidad", objE.Descripcion, objE.Abreviatura);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_TDoc_Identidad(Ent_TDoc_Identidad objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spu_TDoc_Identidad", objE.Tipo_Doc_Id, objE.Descripcion, objE.Abreviatura);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_TDoc_Identidad(Ent_TDoc_Identidad objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spd_TDoc_Identidad", objE.Tipo_Doc_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
