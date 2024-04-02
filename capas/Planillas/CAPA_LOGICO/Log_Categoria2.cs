using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Categoria2
    {
        /*FPS*/
        public static DataTable Lista_Categoria2(Ent_Categoria2 objE)
        {
            try
            {
                return Dao_Categoria2.Lista_Categoria2(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Categoria2(Ent_Categoria2 objE)
        {
            try
            {
                return Dao_Categoria2.Inserta_Categoria2(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Categoria2(Ent_Categoria2 objE)
        {
            try
            {
                return Dao_Categoria2.Actualiza_Categoria2(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Categoria2(Ent_Categoria2 objE)
        {
            try
            {
                return Dao_Categoria2.Elimina_Categoria2(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
