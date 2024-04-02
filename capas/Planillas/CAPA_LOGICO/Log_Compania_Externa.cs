using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Compania_Externa
    {
        /*FPS*/
        public static DataTable Lista_Compania_Externa(Ent_Compania_Externa objE)
        {
            try
            {
                return Dao_Compania_Externa.Lista_Compania_Externa(objE);
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
                return Dao_Compania_Externa.Inserta_Compania_Externa(objE);
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
                return Dao_Compania_Externa.Actualiza_Compania_Externa(objE);
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
                return Dao_Compania_Externa.Elimina_Compania_Externa(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
