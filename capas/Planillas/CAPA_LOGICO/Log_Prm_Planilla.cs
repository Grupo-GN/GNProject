using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Prm_Planilla
    {
        /*FPS*/
        public static DataTable Lista_Prm_Planilla(Ent_Prm_Planilla objE)
        {
            try
            {
                return Dao_Prm_Planilla.Lista_Prm_Planilla(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Prm_Planilla(Ent_Prm_Planilla objE)
        {
            try
            {
                return Dao_Prm_Planilla.Inserta_Prm_Planilla(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Prm_Planilla_Genera(Ent_Prm_Planilla objE)
        {
            try
            {
                return Dao_Prm_Planilla.Inserta_Prm_Planilla_Genera(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Prm_Planilla(Ent_Prm_Planilla objE)
        {
            try
            {
                return Dao_Prm_Planilla.Actualiza_Prm_Planilla(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Prm_Planilla_Masivo(Ent_Prm_Planilla objE, string delimitador, int cant_registros)
        {
            try
            {
                return Dao_Prm_Planilla.Actualiza_Prm_Planilla_Masivo(objE, delimitador, cant_registros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Prm_Planilla(Ent_Prm_Planilla objE)
        {
            try
            {
                return Dao_Prm_Planilla.Elimina_Prm_Planilla(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
