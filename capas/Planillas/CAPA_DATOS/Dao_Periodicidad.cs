using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using Microsoft.ApplicationBlocks.Data;

namespace CAPA_DATOS
{
    public static class Dao_Periodicidad
    {
        /*FPS*/
        public static DataTable Lista_Periodicidad()
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Periodicidad");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
