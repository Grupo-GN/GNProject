using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Familiares
    {
        /*FPS*/
        public static DataTable Lista_Vinculo_Familiar()
        {
            try
            {
                return Dao_Familiares.Lista_Vinculo_Familiar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Lista_Tipo_Doc_Paternidad()
        {
            try
            {
                return Dao_Familiares.Lista_Tipo_Doc_Paternidad();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Lista_Familiares(Ent_Familiares objE)
        {
            try
            {
                return Dao_Familiares.Lista_Familiares(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Familiares(Ent_Familiares objE)
        {
            try
            {
                return Dao_Familiares.Inserta_Familiares(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Familiares(Ent_Familiares objE)
        {
            try
            {
                return Dao_Familiares.Actualiza_Familiares(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Familiares(Ent_Familiares objE)
        {
            try
            {
                return Dao_Familiares.Elimina_Familiares(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
