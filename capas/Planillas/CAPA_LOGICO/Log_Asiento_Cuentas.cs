using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Asiento_Cuentas
    {
        /*FPS*/
        public static DataTable Lista_Asiento_Cuentas(Ent_Asiento_Cuentas objE)
        {
            try
            {
                return Dao_Asiento_Cuentas.Lista_Asiento_Cuentas(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Metodo Para Buscar ---Michael
        /// </summary>
        /// <param name="asientoId"></param>
        /// <param name="asientoCuentaId"></param>
        /// <returns></returns>
        public static DataRow Get_Buscar_Asiento_MS(string asientoCuentaId) {
            return Dao_Asiento_Cuentas.Get_Buscar_Asiento_MS(asientoCuentaId);
        }

        public static DataTable Inserta_Asiento_Cuentas(Ent_Asiento_Cuentas objE)
        {
            try
            {
                return Dao_Asiento_Cuentas.Inserta_Asiento_Cuentas(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Asiento_Cuentas(Ent_Asiento_Cuentas objE)
        {
            try
            {
                return Dao_Asiento_Cuentas.Actualiza_Asiento_Cuentas(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Asiento_Cuentas(Ent_Asiento_Cuentas objE)
        {
            try
            {
                return Dao_Asiento_Cuentas.Elimina_Asiento_Cuentas(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Lista_TipoAgrupacionAsientoCta()
        {
            try
            {
                return Dao_Asiento_Cuentas.Lista_TipoAgrupacionAsientoCta();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
