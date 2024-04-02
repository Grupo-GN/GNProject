using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using Microsoft.ApplicationBlocks.Data;

namespace CAPA_DATOS
{
    public static class Dao_Departamentos
    {
        /*FPS*/
        public static DataTable Lista_Departamentos()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Departamentos");
        }
    }
}
