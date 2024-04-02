using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Periodicidad
    {
        /*FPS*/
        public static DataTable Lista_Periodicidad()
        {
            try
            {
                return Dao_Periodicidad.Lista_Periodicidad();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
