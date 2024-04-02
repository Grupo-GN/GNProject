using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Categoria
    {
        /*FPS*/
        public static DataTable Lista_Categoria(Ent_Categoria objE)
        {
            try
            {
                return Dao_Categoria.Lista_Categoria(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Categoria(Ent_Categoria objE)
        {
            try
            {
                return Dao_Categoria.Inserta_Categoria(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Categoria(Ent_Categoria objE)
        {
            try
            {
                return Dao_Categoria.Actualiza_Categoria(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Categoria(Ent_Categoria objE)
        {
            try
            {
                return Dao_Categoria.Elimina_Categoria(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
