using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using Microsoft.ApplicationBlocks.Data;

namespace CAPA_DATOS
{
    public static class Dao_Sexos
    {
        /*FPS*/
        public static DataTable ListaSexos()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Sexos");
        }
    }
}
