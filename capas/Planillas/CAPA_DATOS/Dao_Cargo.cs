using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using Microsoft.ApplicationBlocks.Data;

namespace CAPA_DATOS
{
    public static class Dao_Cargo
    {
        /*FPS*/
        public static DataTable Lista_Cargo(Ent_Cargo objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Cargo", objE.Cargo_Id, objE.Descripcion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Cargo(Ent_Cargo objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_Cargo", objE.Descripcion, objE.Estado_Id, objE.Flag_Tareaje, objE.Flag_Confianza, objE.Ocupacion_Id, objE.Regimen_Laboral_Id, objE.Ejecutivo, objE.Empleado, objE.Obrero);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Cargo(Ent_Cargo objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spu_Cargo", objE.Cargo_Id, objE.Descripcion, objE.Estado_Id, objE.Flag_Tareaje, objE.Flag_Confianza, objE.Ocupacion_Id, objE.Regimen_Laboral_Id, objE.Ejecutivo, objE.Empleado, objE.Obrero);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Cargo(Ent_Cargo objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spd_Cargo", objE.Cargo_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        ///*mily*/
        //public static DataTable Lista_CargoF()
        //{
        //    try
        //    {
        //        return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Lista_CargoF");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

    }
}
