using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Regimen_Laboral
    {
        /*FPS*/
        public static DataTable Lista_Regimen_Laboral(Ent_Regimen_Laboral objE)
        {
            try
            {
                return Dao_Regimen_Laboral.Lista_Regimen_Laboral(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Regimen_Laboral(Ent_Regimen_Laboral objE)
        {
            try
            {
                return Dao_Regimen_Laboral.Inserta_Regimen_Laboral(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Regimen_Laboral(Ent_Regimen_Laboral objE)
        {
            try
            {
                return Dao_Regimen_Laboral.Actualiza_Regimen_Laboral(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Regimen_Laboral(Ent_Regimen_Laboral objE)
        {
            try
            {
                return Dao_Regimen_Laboral.Elimina_Regimen_Laboral(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
