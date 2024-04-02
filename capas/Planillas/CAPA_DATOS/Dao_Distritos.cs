using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using Microsoft.ApplicationBlocks.Data;

namespace CAPA_DATOS
{
    public static class Dao_Distritos
    {
        /*FPS*/
        public static DataTable Lista_Distritos(Ent_Distritos objE)
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Distritos", objE.Sub_Filtro);
        }
    }
}
