using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using CAPA_DATOS;

namespace CAPA_LOGICO
{
    public static class Log_Motivo_Fin_Per_Lab
    {
        /*FPS*/
        public static DataTable Lista_Motivo_Fin_Per_Lab(Ent_Motivo_Fin_Per_Lab objE)
        {
            try
            {
                return Dao_Motivo_Fin_Per_Lab.Lista_Motivo_Fin_Per_Lab(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Motivo_Fin_Per_Lab(Ent_Motivo_Fin_Per_Lab objE)
        {
            try
            {
                return Dao_Motivo_Fin_Per_Lab.Inserta_Motivo_Fin_Per_Lab(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Motivo_Fin_Per_Lab(Ent_Motivo_Fin_Per_Lab objE)
        {
            try
            {
                return Dao_Motivo_Fin_Per_Lab.Actualiza_Motivo_Fin_Per_Lab(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Motivo_Fin_Per_Lab(Ent_Motivo_Fin_Per_Lab objE)
        {
            try
            {
                return Dao_Motivo_Fin_Per_Lab.Elimina_Motivo_Fin_Per_Lab(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
