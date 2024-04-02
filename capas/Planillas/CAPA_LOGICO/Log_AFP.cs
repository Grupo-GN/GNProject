using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_AFP
    {
        /*FPS*/
        public static DataTable Lista_Afp(Ent_AFP objE)
        {
            try
            {
                return Dao_AFP.Lista_Afp(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Afp(Ent_AFP objE)
        {
            try
            {
                return Dao_AFP.Inserta_Afp(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Afp(Ent_AFP objE)
        {
            try
            {
                return Dao_AFP.Actualiza_Afp(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Afp(Ent_AFP objE)
        {
            try
            {
                return Dao_AFP.Elimina_Afp(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
