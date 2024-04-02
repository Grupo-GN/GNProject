using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Cargo
    {
        /*FPS*/
        public static DataTable Lista_Cargo(Ent_Cargo objE)
        {
            try
            {
                return Dao_Cargo.Lista_Cargo(objE);
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
                return Dao_Cargo.Inserta_Cargo(objE);
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
                return Dao_Cargo.Actualiza_Cargo(objE);
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
                return Dao_Cargo.Elimina_Cargo(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        ///*AGREGADO ULTIMO mily*/
        //public static DataTable Lista_CargoF()
        //{
        //    try
        //    {
        //        return Dao_Cargo.Lista_CargoF();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
    }
}
