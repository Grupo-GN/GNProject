using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using CAPA_DATOS;

namespace CAPA_LOGICO
{
    public static class Log_Personal_Anexo2
    {
        /*FPS*/
        public static DataTable Lista_Personal_Anexo2(Ent_Personal_Anexo2 objE)
        {
            try
            {
                return Dao_Personal_Anexo2.Lista_Personal_Anexo2(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Personal_Anexo2(Ent_Personal_Anexo2 objE)
        {
            try
            {
                return Dao_Personal_Anexo2.Inserta_Personal_Anexo2(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Personal_Anexo2(Ent_Personal_Anexo2 objE)
        {
            try
            {
                return Dao_Personal_Anexo2.Actualiza_Personal_Anexo2(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Personal_Anexo2(Ent_Personal_Anexo2 objE)
        {
            try
            {
                return Dao_Personal_Anexo2.Elimina_Personal_Anexo2(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
