using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using CAPA_DATOS;

namespace CAPA_LOGICO
{
    public static class Log_Compania_Establecimiento
    {
        /*FPS*/
        public static DataTable Lista_Compania_Establecimiento(Ent_Compania_Establecimiento objE)
        {
            try
            {
                return Dao_Compania_Establecimiento.Lista_Compania_Establecimiento(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Compania_Establecimiento(Ent_Compania_Establecimiento objE)
        {
            try
            {
                return Dao_Compania_Establecimiento.Inserta_Compania_Establecimiento(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Compania_Establecimiento(Ent_Compania_Establecimiento objE)
        {
            try
            {
                return Dao_Compania_Establecimiento.Actualiza_Compania_Establecimiento(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Compania_Establecimiento(Ent_Compania_Establecimiento objE)
        {
            try
            {
                return Dao_Compania_Establecimiento.Elimina_Compania_Establecimiento(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
