using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using CAPA_DATOS;

namespace CAPA_LOGICO
{
    public static class Log_Proyecto
    {
        /*FPS*/
        public static DataTable Lista_Proyecto(Ent_Proyecto objE)
        {
            try
            {
                return Dao_Proyecto.Lista_Proyecto(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Proyecto(Ent_Proyecto objE)
        {
            try
            {
                return Dao_Proyecto.Inserta_Proyecto(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Proyecto(Ent_Proyecto objE)
        {
            try
            {
                return Dao_Proyecto.Actualiza_Proyecto(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Proyecto(Ent_Proyecto objE)
        {
            try
            {
                return Dao_Proyecto.Elimina_Proyecto(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
