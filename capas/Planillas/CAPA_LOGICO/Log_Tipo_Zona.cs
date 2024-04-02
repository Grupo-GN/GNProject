using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Tipo_Zona
    {
        /*FPS*/
        public static DataTable Lista_Tipo_Zona(Ent_Tipo_Zona objE)
        {
            try
            {
                return Dao_Tipo_Zona.Lista_Tipo_Zona(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Tipo_Zona(Ent_Tipo_Zona objE)
        {
            try
            {
                return Dao_Tipo_Zona.Inserta_Tipo_Zona(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Tipo_Zona(Ent_Tipo_Zona objE)
        {
            try
            {
                return Dao_Tipo_Zona.Actualiza_Tipo_Zona(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Tipo_Zona(Ent_Tipo_Zona objE)
        {
            try
            {
                return Dao_Tipo_Zona.Elimina_Tipo_Zona(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
