using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Prm_Afp
    {
        /*FPS*/
        public static DataTable Lista_Prm_Afp(Ent_Prm_Afp objE)
        {
            try
            {
                return Dao_Prm_Afp.Lista_Prm_Afp(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Prm_Afp(Ent_Prm_Afp objE)
        {
            try
            {
                return Dao_Prm_Afp.Inserta_Prm_Afp(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Prm_Afp_Genera(Ent_Prm_Afp objE)
        {
            try
            {
                return Dao_Prm_Afp.Inserta_Prm_Afp_Genera(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Prm_Afp(Ent_Prm_Afp objE)
        {
            try
            {
                return Dao_Prm_Afp.Actualiza_Prm_Afp(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Prm_Afp_Masivo(Ent_Prm_Afp objE, string delimitador, int cant_registros)
        {
            try
            {
                return Dao_Prm_Afp.Actualiza_Prm_Afp_Masivo(objE, delimitador, cant_registros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Prm_Afp(Ent_Prm_Afp objE)
        {
            try
            {
                return Dao_Prm_Afp.Elimina_Prm_Afp(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
