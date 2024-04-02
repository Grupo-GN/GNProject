using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Prm_Cia
    {
        /*FPS*/
        public static DataTable Lista_Prm_Cia(Ent_Prm_Cia objE)
        {
            try
            {
                return Dao_Prm_Cia.Lista_Prm_Cia(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Prm_Cia(Ent_Prm_Cia objE)
        {
            try
            {
                return Dao_Prm_Cia.Inserta_Prm_Cia(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Prm_Cia_Genera(Ent_Prm_Cia objE)
        {
            try
            {
                return Dao_Prm_Cia.Inserta_Prm_Cia_Genera(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Prm_Cia(Ent_Prm_Cia objE)
        {
            try
            {
                return Dao_Prm_Cia.Actualiza_Prm_Cia(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Prm_Cia_Masivo(Ent_Prm_Cia objE, string delimitador, int cant_registros)
        {
            try
            {
                return Dao_Prm_Cia.Actualiza_Prm_Cia_Masivo(objE, delimitador, cant_registros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Prm_Cia(Ent_Prm_Cia objE)
        {
            try
            {
                return Dao_Prm_Cia.Elimina_Prm_Cia(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
