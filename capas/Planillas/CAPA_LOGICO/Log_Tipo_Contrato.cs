using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Tipo_Contrato
    {
        /*FPS*/
        public static DataTable Lista_Tipo_Contrato(Ent_Tipo_Contrato objE)
        {
            try
            {
                return Dao_Tipo_Contrato.Lista_Tipo_Contrato(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Tipo_Contrato(Ent_Tipo_Contrato objE)
        {
            try
            {
                return Dao_Tipo_Contrato.Inserta_Tipo_Contrato(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Tipo_Contrato(Ent_Tipo_Contrato objE)
        {
            try
            {
                return Dao_Tipo_Contrato.Actualiza_Tipo_Contrato(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Tipo_Contrato(Ent_Tipo_Contrato objE)
        {
            try
            {
                return Dao_Tipo_Contrato.Elimina_Tipo_Contrato(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
