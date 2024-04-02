using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Nacionalidad
    {
        /*FPS*/
        public static DataTable Lista_Nacionalidad(Ent_Nacionalidad objE)
        {
            try
            {
                return Dao_Nacionalidad.Lista_Nacionalidad(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Nacionalidad(Ent_Nacionalidad objE)
        {
            try
            {
                return Dao_Nacionalidad.Inserta_Nacionalidad(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Nacionalidad(Ent_Nacionalidad objE)
        {
            try
            {
                return Dao_Nacionalidad.Actualiza_Nacionalidad(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Nacionalidad(Ent_Nacionalidad objE)
        {
            try
            {
                return Dao_Nacionalidad.Elimina_Nacionalidad(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
