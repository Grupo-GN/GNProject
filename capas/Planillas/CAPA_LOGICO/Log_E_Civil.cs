using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using CAPA_DATOS;

namespace CAPA_LOGICO
{
    public static class Log_E_Civil
    {
        /*FPS*/
        public static DataTable Lista_E_Civil(Ent_E_Civil objE)
        {
            try
            {
                return Dao_E_Civil.Lista_E_Civil(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_E_Civil(Ent_E_Civil objE)
        {
            try
            {
                return Dao_E_Civil.Inserta_E_Civil(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_E_Civil(Ent_E_Civil objE)
        {
            try
            {
                return Dao_E_Civil.Actualiza_E_Civil(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_E_Civil(Ent_E_Civil objE)
        {
            try
            {
                return Dao_E_Civil.Elimina_E_Civil(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
