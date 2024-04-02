using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using Microsoft.ApplicationBlocks.Data;

namespace CAPA_DATOS
{
    public static class Dao_Cuotas_Estado_Pago
    {
        /*FPS*/
        public static DataTable Lista_Cuotas_Estado_Pago()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Cuotas_Estado_Pago");
        }
    }
}
