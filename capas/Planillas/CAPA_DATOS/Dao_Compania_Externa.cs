using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using Microsoft.ApplicationBlocks.Data;

namespace CAPA_DATOS
{
    public static class Dao_Compania_Externa
    {
        /*FPS*/
        public static DataTable Lista_Compania_Externa(Ent_Compania_Externa objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Compania_Externa", objE.Compania_Externa_Id, objE.Razon_Social);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Compania_Externa(Ent_Compania_Externa objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_Compania_Externa", objE.Razon_Social, objE.RUC, objE.CIIU_Id, objE.Destaque_Envio, objE.Destaque_Recibo, objE.Fecha_Ini, objE.Fecha_Fin);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Compania_Externa(Ent_Compania_Externa objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spu_Compania_Externa", objE.Compania_Externa_Id, objE.Razon_Social, objE.RUC, objE.CIIU_Id, objE.Destaque_Envio, objE.Destaque_Recibo, objE.Fecha_Ini, objE.Fecha_Fin);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Compania_Externa(Ent_Compania_Externa objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spd_Compania_Externa", objE.Compania_Externa_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
