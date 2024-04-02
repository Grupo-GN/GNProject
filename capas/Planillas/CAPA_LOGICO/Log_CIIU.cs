using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_CIIU
    {
        /*FPS*/
        public static DataTable Lista_CIIU()
        {
            try
            {
                return Dao_CIIU.Lista_CIIU();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
