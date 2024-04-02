using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Ejercicio
    {
        /*FPS*/
        public static DataTable Lista_Ejercicio(Ent_Ejercicio objE)
        {
            try
            {
                return Dao_Ejercicio.Lista_Ejercicio(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Ejercicio(Ent_Ejercicio objE)
        {
            try
            {
                return Dao_Ejercicio.Inserta_Ejercicio(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Ejercicio(Ent_Ejercicio objE)
        {
            try
            {
                return Dao_Ejercicio.Actualiza_Ejercicio(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Ejercicio(Ent_Ejercicio objE)
        {
            try
            {
                return Dao_Ejercicio.Elimina_Ejercicio(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
