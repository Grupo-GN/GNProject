using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using Microsoft.ApplicationBlocks.Data;

namespace CAPA_DATOS
{
    public static class Dao_Provincias
    {
        /*FPS*/
        public static DataTable Lista_Provincias(Ent_Provincias objE)
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Provincias", objE.Sub_Filtro);
        }
    }
}
