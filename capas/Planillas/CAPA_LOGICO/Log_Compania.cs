using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Compania
    {
        /*FPS*/
        public static DataTable Lista_Compania(Ent_Compania objE)
        {
            try
            {
                return Dao_Compania.Lista_Compania(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Compania(Ent_Compania objE)
        {
            try
            {
                return Dao_Compania.Inserta_Compania(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Compania(Ent_Compania objE)
        {
            try
            {
                return Dao_Compania.Actualiza_Compania(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Compania(Ent_Compania objE)
        {
            try
            {
                return Dao_Compania.Elimina_Compania(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
