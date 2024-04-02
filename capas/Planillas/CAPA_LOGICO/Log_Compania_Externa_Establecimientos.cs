using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Compania_Externa_Establecimientos
    {
        /*FPS*/
        public static DataTable Lista_Compania_Externa_Establecimientos(Ent_Compania_Externa_Establecimientos objE)
        {
            try
            {
                return Dao_Compania_Externa_Establecimientos.Lista_Compania_Externa_Establecimientos(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Compania_Externa_Establecimientos(Ent_Compania_Externa_Establecimientos objE)
        {
            try
            {
                return Dao_Compania_Externa_Establecimientos.Inserta_Compania_Externa_Establecimientos(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Compania_Externa_Establecimientos(Ent_Compania_Externa_Establecimientos objE)
        {
            try
            {
                return Dao_Compania_Externa_Establecimientos.Actualiza_Compania_Externa_Establecimientos(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Compania_Externa_Establecimientos(Ent_Compania_Externa_Establecimientos objE)
        {
            try
            {
                return Dao_Compania_Externa_Establecimientos.Elimina_Compania_Externa_Establecimientos(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
