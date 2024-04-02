using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Categoria_Auxiliar
    {
        /*FPS*/
        public static DataTable Lista_Categoria_Auxiliar(Ent_Categoria_Auxiliar objE)
        {
            try
            {
                return Dao_Categoria_Auxiliar.Lista_Categoria_Auxiliar(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Categoria_Auxiliar(Ent_Categoria_Auxiliar objE)
        {
            try
            {
                return Dao_Categoria_Auxiliar.Inserta_Categoria_Auxiliar(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Categoria_Auxiliar(Ent_Categoria_Auxiliar objE)
        {
            try
            {
                return Dao_Categoria_Auxiliar.Actualiza_Categoria_Auxiliar(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Categoria_Auxiliar(Ent_Categoria_Auxiliar objE)
        {
            try
            {
                return Dao_Categoria_Auxiliar.Elimina_Categoria_Auxiliar(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
