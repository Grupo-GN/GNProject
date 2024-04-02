using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Tipo_Via
    {
        /*FPS*/
        public static DataTable Lista_Tipo_Via(Ent_Tipo_Via objE)
        {
            try
            {
                return Dao_Tipo_Via.Lista_Tipo_Via(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Tipo_Via(Ent_Tipo_Via objE)
        {
            try
            {
                return Dao_Tipo_Via.Inserta_Tipo_Via(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Tipo_Via(Ent_Tipo_Via objE)
        {
            try
            {
                return Dao_Tipo_Via.Actualiza_Tipo_Via(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Tipo_Via(Ent_Tipo_Via objE)
        {
            try
            {
                return Dao_Tipo_Via.Elimina_Tipo_Via(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
