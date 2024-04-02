using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using CAPA_DATOS;

namespace CAPA_LOGICO
{
    public static class Log_TDoc_Identidad
    {
        /*FPS*/
        public static DataTable Lista_TDoc_Identidad(Ent_TDoc_Identidad objE)
        {
            try
            {
                return Dao_TDoc_Identidad.Lista_TDoc_Identidad(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_TDoc_Identidad(Ent_TDoc_Identidad objE)
        {
            try
            {
                return Dao_TDoc_Identidad.Inserta_TDoc_Identidad(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_TDoc_Identidad(Ent_TDoc_Identidad objE)
        {
            try
            {
                return Dao_TDoc_Identidad.Actualiza_TDoc_Identidad(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_TDoc_Identidad(Ent_TDoc_Identidad objE)
        {
            try
            {
                return Dao_TDoc_Identidad.Elimina_TDoc_Identidad(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
