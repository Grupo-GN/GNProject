using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Planilla
    {
        /*FPS*/
        public static DataTable Lista_Planilla(Ent_Planilla objE)
        {
            try
            {
                return Dao_Planilla.Lista_Planilla(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Planilla(Ent_Planilla objE)
        {
            try
            {
                return Dao_Planilla.Inserta_Planilla(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Planilla(Ent_Planilla objE)
        {
            try
            {
                return Dao_Planilla.Actualiza_Planilla(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Planilla(Ent_Planilla objE)
        {
            try
            {
                return Dao_Planilla.Elimina_Planilla(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
