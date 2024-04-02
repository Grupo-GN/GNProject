using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using CAPA_DATOS;

namespace CAPA_LOGICO
{
    public static class Log_Nivel_Educativo
    {
        /*FPS*/
        public static DataTable Lista_Nivel_Educativo(Ent_Nivel_Educativo objE)
        {
            try
            {
                return Dao_Nivel_Educativo.Lista_Nivel_Educativo(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Nivel_Educativo(Ent_Nivel_Educativo objE)
        {
            try
            {
                return Dao_Nivel_Educativo.Inserta_Nivel_Educativo(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Nivel_Educativo(Ent_Nivel_Educativo objE)
        {
            try
            {
                return Dao_Nivel_Educativo.Actualiza_Nivel_Educativo(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Nivel_Educativo(Ent_Nivel_Educativo objE)
        {
            try
            {
                return Dao_Nivel_Educativo.Elimina_Nivel_Educativo(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
