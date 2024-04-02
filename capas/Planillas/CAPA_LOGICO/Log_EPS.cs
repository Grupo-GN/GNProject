using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_EPS
    {
        /*FPS*/
        public static DataTable Lista_EPS(Ent_EPS objE)
        {
            try
            {
                return Dao_EPS.Lista_EPS(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_EPS(Ent_EPS objE)
        {
            try
            {
                return Dao_EPS.Inserta_EPS(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_EPS(Ent_EPS objE)
        {
            try
            {
                return Dao_EPS.Actualiza_EPS(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_EPS(Ent_EPS objE)
        {
            try
            {
                return Dao_EPS.Elimina_EPS(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
