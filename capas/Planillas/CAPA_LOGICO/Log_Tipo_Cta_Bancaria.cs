using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using CAPA_DATOS;

namespace CAPA_LOGICO
{
    public static class Log_Tipo_Cta_Bancaria
    {
        /*FPS*/
        public static DataTable Lista_Tipo_Cta_Bancaria(Ent_Tipo_Cta_Bancaria objE)
        {
            try
            {
                return Dao_Tipo_Cta_Bancaria.Lista_Tipo_Cta_Bancaria(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Tipo_Cta_Bancaria(Ent_Tipo_Cta_Bancaria objE)
        {
            try
            {
                return Dao_Tipo_Cta_Bancaria.Inserta_Tipo_Cta_Bancaria(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Tipo_Cta_Bancaria(Ent_Tipo_Cta_Bancaria objE)
        {
            try
            {
                return Dao_Tipo_Cta_Bancaria.Actualiza_Tipo_Cta_Bancaria(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Tipo_Cta_Bancaria(Ent_Tipo_Cta_Bancaria objE)
        {
            try
            {
                return Dao_Tipo_Cta_Bancaria.Elimina_Tipo_Cta_Bancaria(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
