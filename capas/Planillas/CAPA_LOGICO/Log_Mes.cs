using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Mes
    {
        /*FPS*/
        public static DataTable Lista_Mes(Ent_Mes objE)
        {
            try
            {
                return Dao_Mes.Lista_Mes(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Mes(Ent_Mes objE)
        {
            try
            {
                return Dao_Mes.Inserta_Mes(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Mes_Masivo(Ent_Mes objE)
        {
            try
            {
                return Dao_Mes.Inserta_Mes_Masivo(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Mes(Ent_Mes objE)
        {
            try
            {
                return Dao_Mes.Actualiza_Mes(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Mes(Ent_Mes objE)
        {
            try
            {
                return Dao_Mes.Elimina_Mes(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
