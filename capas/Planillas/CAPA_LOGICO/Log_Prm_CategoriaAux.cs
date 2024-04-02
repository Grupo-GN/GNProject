using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Prm_CategoriaAux
    {
        /*FPS*/
        public static DataTable Lista_Prm_CategoriaAux(Ent_Prm_CategoriaAux objE)
        {
            try
            {
                return Dao_Prm_CategoriaAux.Lista_Prm_CategoriaAux(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Prm_CategoriaAux(Ent_Prm_CategoriaAux objE)
        {
            try
            {
                return Dao_Prm_CategoriaAux.Inserta_Prm_CategoriaAux(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Prm_CategoriaAux_Genera(Ent_Prm_CategoriaAux objE)
        {
            try
            {
                return Dao_Prm_CategoriaAux.Inserta_Prm_CategoriaAux_Genera(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Prm_CategoriaAux(Ent_Prm_CategoriaAux objE)
        {
            try
            {
                return Dao_Prm_CategoriaAux.Actualiza_Prm_CategoriaAux(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Prm_CategoriaAux_Masivo(Ent_Prm_CategoriaAux objE, string delimitador, int cant_registros)
        {
            try
            {
                return Dao_Prm_CategoriaAux.Actualiza_Prm_CategoriaAux_Masivo(objE, delimitador, cant_registros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Prm_CategoriaAux(Ent_Prm_CategoriaAux objE)
        {
            try
            {
                return Dao_Prm_CategoriaAux.Elimina_Prm_CategoriaAux(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
