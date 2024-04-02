using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using CAPA_DATOS;

namespace CAPA_LOGICO
{
    public static class Log_Situacion
    {
        /*FPS*/
        public static DataTable Lista_Situacion(Ent_Situacion objE)
        {
            try
            {
                return Dao_Situacion.Lista_Situacion(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Situacion(Ent_Situacion objE)
        {
            try
            {
                return Dao_Situacion.Inserta_Situacion(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Situacion(Ent_Situacion objE)
        {
            try
            {
                return Dao_Situacion.Actualiza_Situacion(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Situacion(Ent_Situacion objE)
        {
            try
            {
                return Dao_Situacion.Elimina_Situacion(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
