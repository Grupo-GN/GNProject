using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using CAPA_DATOS;

namespace CAPA_LOGICO
{
    public static class Log_Personal_Establecimientos
    {
        /*FPS*/
        public static DataTable Lista_Personal_Establecimientos(Ent_Personal_Establecimientos objE)
        {
            try
            {
                return Dao_Personal_Establecimientos.Lista_Personal_Establecimientos(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable Inserta_Personal_Establecimientos(Ent_Personal_Establecimientos objE)
        {
            try
            {
                return Dao_Personal_Establecimientos.Inserta_Personal_Establecimientos(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable Actualiza_Personal_Establecimientos(Ent_Personal_Establecimientos objE)
        {
            try
            {
                return Dao_Personal_Establecimientos.Actualiza_Personal_Establecimientos(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable Elimina_Personal_Establecimientos(Ent_Personal_Establecimientos objE)
        {
            try
            {
                return Dao_Personal_Establecimientos.Elimina_Personal_Establecimientos(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable Inserta_Masivo_Personal_Establecimientos(Ent_Personal_Establecimientos objE)
        {
            try
            {
                return Dao_Personal_Establecimientos.Inserta_Masivo_Personal_Establecimientos(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
