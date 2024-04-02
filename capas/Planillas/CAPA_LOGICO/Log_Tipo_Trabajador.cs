using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Tipo_Trabajador
    {
        /*FPS*/
        public static DataTable Lista_Tipo_Trabajador(Ent_Tipo_Trabajador objE)
        {
            try
            {
                return Dao_Tipo_Trabajador.Lista_Tipo_Trabajador(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Tipo_Trabajador(Ent_Tipo_Trabajador objE)
        {
            try
            {
                return Dao_Tipo_Trabajador.Inserta_Tipo_Trabajador(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Tipo_Trabajador(Ent_Tipo_Trabajador objE)
        {
            try
            {
                return Dao_Tipo_Trabajador.Actualiza_Tipo_Trabajador(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Tipo_Trabajador(Ent_Tipo_Trabajador objE)
        {
            try
            {
                return Dao_Tipo_Trabajador.Elimina_Tipo_Trabajador(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
