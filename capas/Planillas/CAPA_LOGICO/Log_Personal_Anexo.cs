using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using CAPA_DATOS;

namespace CAPA_LOGICO
{
    public static class Log_Personal_Anexo
    {
        /*FPS*/
        public static DataTable Lista_Personal_Anexo(Ent_Personal_Anexo objE)
        {
            try
            {
                return Dao_Personal_Anexo.Lista_Personal_Anexo(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Personal_Anexo(Ent_Personal_Anexo objE)
        {
            try
            {
                return Dao_Personal_Anexo.Inserta_Personal_Anexo(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Personal_Anexo(Ent_Personal_Anexo objE)
        {
            try
            {
                return Dao_Personal_Anexo.Actualiza_Personal_Anexo(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Personal_Anexo(Ent_Personal_Anexo objE)
        {
            try
            {
                return Dao_Personal_Anexo.Elimina_Personal_Anexo(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
