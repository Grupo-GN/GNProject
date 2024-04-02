using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_RH_Area
    {
        /*FPS*/
        public static DataTable Lista_RH_Area(Ent_RH_Area objE)
        {
            try
            {
                return Dao_RH_Area.Lista_RH_Area(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_RH_Area(Ent_RH_Area objE)
        {
            try
            {
                return Dao_RH_Area.Inserta_RH_Area(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_RH_Area(Ent_RH_Area objE)
        {
            try
            {
                return Dao_RH_Area.Actualiza_RH_Area(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_RH_Area(Ent_RH_Area objE)
        {
            try
            {
                return Dao_RH_Area.Elimina_RH_Area(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
