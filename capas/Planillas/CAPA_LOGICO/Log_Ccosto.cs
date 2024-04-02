using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Ccosto
    {
        /*FPS*/
        public static DataTable Lista_Ccosto(Ent_Ccosto objE)
        {
            try
            {
                return Dao_Ccosto.Lista_Ccosto(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Ccosto(Ent_Ccosto objE)
        {
            try
            {
                return Dao_Ccosto.Inserta_Ccosto(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Ccosto(Ent_Ccosto objE)
        {
            try
            {
                return Dao_Ccosto.Actualiza_Ccosto(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Ccosto(Ent_Ccosto objE)
        {
            try
            {
                return Dao_Ccosto.Elimina_Ccosto(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
