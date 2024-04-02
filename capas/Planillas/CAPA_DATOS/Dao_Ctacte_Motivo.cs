using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Microsoft.ApplicationBlocks.Data;
using CAPA_ENTIDAD;

namespace CAPA_DATOS
{
    public static class Dao_Ctacte_Motivo
    {
        /*FPS*/
        public static DataTable Lista_CtaCte_Motivo()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_CtaCte_Motivo");
        }
    }
}
