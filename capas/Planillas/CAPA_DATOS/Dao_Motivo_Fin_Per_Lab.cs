using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using Microsoft.ApplicationBlocks.Data;

namespace CAPA_DATOS
{
    public static class Dao_Motivo_Fin_Per_Lab
    {
        /*FPS*/
        public static DataTable Lista_Motivo_Fin_Per_Lab(Ent_Motivo_Fin_Per_Lab objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Motivo_Fin_Per_Lab", objE.Motivo_Fin_Per_Lab_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Motivo_Fin_Per_Lab(Ent_Motivo_Fin_Per_Lab objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_Motivo_Fin_Per_Lab", objE.Descripcion, objE.Abreviatura);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Motivo_Fin_Per_Lab(Ent_Motivo_Fin_Per_Lab objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spu_Motivo_Fin_Per_Lab", objE.Motivo_Fin_Per_Lab_Id, objE.Descripcion, objE.Abreviatura);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Motivo_Fin_Per_Lab(Ent_Motivo_Fin_Per_Lab objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spd_Motivo_Fin_Per_Lab", objE.Motivo_Fin_Per_Lab_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
