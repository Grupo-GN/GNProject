using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Ocupacion
    {
        /*FPS*/
        public static DataTable Lista_Ocupacion(Ent_Ocupacion objE)
        {
            try
            {
                return Dao_Ocupacion.Lista_Ocupacion(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Ocupacion(Ent_Ocupacion objE)
        {
            try
            {
                return Dao_Ocupacion.Inserta_Ocupacion(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Ocupacion(Ent_Ocupacion objE)
        {
            try
            {
                return Dao_Ocupacion.Actualiza_Ocupacion(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Ocupacion(Ent_Ocupacion objE)
        {
            try
            {
                return Dao_Ocupacion.Elimina_Ocupacion(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
