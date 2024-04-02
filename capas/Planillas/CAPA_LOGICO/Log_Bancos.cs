using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Bancos
    {
        /*FPS*/
        public static DataTable Lista_Bancos(Ent_Bancos objE)
        {
            try
            {
                return Dao_Bancos.Lista_Bancos(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Bancos(Ent_Bancos objE)
        {
            try
            {
                return Dao_Bancos.Inserta_Bancos(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Bancos(Ent_Bancos objE)
        {
            try
            {
                return Dao_Bancos.Actualiza_Bancos(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Bancos(Ent_Bancos objE)
        {
            try
            {
                return Dao_Bancos.Elimina_Bancos(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
