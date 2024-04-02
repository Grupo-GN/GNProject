using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Calculos_Perm
    {
        /*FPS*/
        public static DataTable Lista_Calculos_Perm(Ent_Calculos_Perm objE)
        {
            try
            {
                return Dao_Calculos_Perm.Lista_Calculos_Perm(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Calculos_Perm(Ent_Calculos_Perm objE)
        {
            try
            {
                return Dao_Calculos_Perm.Inserta_Calculos_Perm(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Calculos_Perm_Genera(Ent_Calculos_Perm objE)
        {
            try
            {
                return Dao_Calculos_Perm.Inserta_Calculos_Perm_Genera(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Calculos_Perm(Ent_Calculos_Perm objE)
        {
            try
            {
                return Dao_Calculos_Perm.Actualiza_Calculos_Perm(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Calculos_Perm_Masivo(Ent_Calculos_Perm objE, string delimitador, int cant_registros)
        {
            try
            {
                return Dao_Calculos_Perm.Actualiza_Calculos_Perm_Masivo(objE, delimitador, cant_registros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Calculos_Perm(Ent_Calculos_Perm objE)
        {
            try
            {
                return Dao_Calculos_Perm.Elimina_Calculos_Perm(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
