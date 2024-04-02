using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using CAPA_DATOS;

namespace CAPA_LOGICO
{
    public static class Log_Procesos
    {
        /*FPS*/
        public static DataTable Lista_Procesos(Ent_Procesos objE)
        {
            try
            {
                return Dao_Procesos.Lista_Procesos(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Buscar_Procesos_ById(string idProceso)
        {
            try
            {
                return Dao_Procesos.Buscar_Procesos_ById(idProceso);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Lista_Procesos(string proceso)
        {
            try
            {
                return Dao_Procesos.Lista_Procesos(proceso);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Procesos(Ent_Procesos objE)
        {
            try
            {
                return Dao_Procesos.Inserta_Procesos(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Procesos(Ent_Procesos objE)
        {
            try
            {
                return Dao_Procesos.Actualiza_Procesos(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Procesos(Ent_Procesos objE)
        {
            try
            {
                return Dao_Procesos.Elimina_Procesos(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
