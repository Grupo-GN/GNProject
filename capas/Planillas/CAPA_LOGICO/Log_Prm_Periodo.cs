using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Prm_Periodo
    {
        /*FPS*/
        public static DataTable Lista_Prm_Periodo(Ent_Prm_Periodo objE)
        {
            try
            {
                return Dao_Prm_Periodo.Lista_Prm_Periodo(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Prm_Periodo(Ent_Prm_Periodo objE)
        {
            try
            {
                return Dao_Prm_Periodo.Inserta_Prm_Periodo(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Prm_Periodo_Genera(Ent_Prm_Periodo objE)
        {
            try
            {
                return Dao_Prm_Periodo.Inserta_Prm_Periodo_Genera(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Prm_Periodo(Ent_Prm_Periodo objE)
        {
            try
            {
                return Dao_Prm_Periodo.Actualiza_Prm_Periodo(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Prm_Periodo_Masivo(Ent_Prm_Periodo objE, string delimitador, int cant_registros)
        {
            try
            {
                return Dao_Prm_Periodo.Actualiza_Prm_Periodo_Masivo(objE, delimitador, cant_registros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Prm_Periodo(Ent_Prm_Periodo objE)
        {
            try
            {
                return Dao_Prm_Periodo.Elimina_Prm_Periodo(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
