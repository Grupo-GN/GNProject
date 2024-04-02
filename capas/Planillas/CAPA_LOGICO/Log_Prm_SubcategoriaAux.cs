using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Prm_SubcategoriaAux
    {
        /*FPS*/
        public static DataTable Lista_Prm_SubcategoriaAux(Ent_Prm_SubcategoriaAux objE)
        {
            try
            {
                return Dao_Prm_SubcategoriaAux.Lista_Prm_SubcategoriaAux(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Prm_SubcategoriaAux(Ent_Prm_SubcategoriaAux objE)
        {
            try
            {
                return Dao_Prm_SubcategoriaAux.Inserta_Prm_SubcategoriaAux(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Prm_SubcategoriaAux_Genera(Ent_Prm_SubcategoriaAux objE)
        {
            try
            {
                return Dao_Prm_SubcategoriaAux.Inserta_Prm_SubcategoriaAux_Genera(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Prm_SubcategoriaAux(Ent_Prm_SubcategoriaAux objE)
        {
            try
            {
                return Dao_Prm_SubcategoriaAux.Actualiza_Prm_SubcategoriaAux(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Prm_SubcategoriaAux_Masivo(Ent_Prm_SubcategoriaAux objE, string delimitador, int cant_registros)
        {
            try
            {
                return Dao_Prm_SubcategoriaAux.Actualiza_Prm_SubcategoriaAux_Masivo(objE, delimitador, cant_registros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Prm_SubcategoriaAux(Ent_Prm_SubcategoriaAux objE)
        {
            try
            {
                return Dao_Prm_SubcategoriaAux.Elimina_Prm_SubcategoriaAux(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
