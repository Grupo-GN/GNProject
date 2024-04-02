using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Microsoft.ApplicationBlocks.Data;
using CAPA_ENTIDAD;

namespace CAPA_DATOS
{
    public static class Dao_Ctacte_Operacion
    {
        /*FPS*/
        public static DataTable Lista_Ctacte_Operacion()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Ctacte_Operacion");
        }
    }
}
