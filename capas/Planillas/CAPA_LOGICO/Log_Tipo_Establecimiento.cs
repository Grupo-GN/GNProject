using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using CAPA_DATOS;

namespace CAPA_LOGICO
{
    public static class Log_Tipo_Establecimiento
    {
        /*FPS*/
        public static DataTable Lista_Tipo_Establecimiento(Ent_Tipo_Establecimiento objE)
        {
            try
            {
                return Dao_Tipo_Establecimiento.Lista_Tipo_Establecimiento(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Tipo_Establecimiento(Ent_Tipo_Establecimiento objE)
        {
            try
            {
                return Dao_Tipo_Establecimiento.Inserta_Tipo_Establecimiento(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Tipo_Establecimiento(Ent_Tipo_Establecimiento objE)
        {
            try
            {
                return Dao_Tipo_Establecimiento.Actualiza_Tipo_Establecimiento(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Tipo_Establecimiento(Ent_Tipo_Establecimiento objE)
        {
            try
            {
                return Dao_Tipo_Establecimiento.Elimina_Tipo_Establecimiento(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
