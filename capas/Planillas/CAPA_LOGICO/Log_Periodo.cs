using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Periodo
    {
        /*FPS*/
        public static DataTable Lista_Periodo(Ent_Periodo objE)
        {
            try
            {
                return Dao_Periodo.Lista_Periodo(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Periodo(Ent_Periodo objE)
        {
            try
            {
                return Dao_Periodo.Inserta_Periodo(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Periodo_Masivo(Ent_Periodo objE)
        {
            try
            {
                return Dao_Periodo.Inserta_Periodo_Masivo(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Periodo(Ent_Periodo objE)
        {
            try
            {
                return Dao_Periodo.Actualiza_Periodo(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Periodo(Ent_Periodo objE)
        {
            try
            {
                return Dao_Periodo.Elimina_Periodo(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
