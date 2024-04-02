using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using Microsoft.ApplicationBlocks.Data;

namespace CAPA_DATOS
{
    public static class Dao_Vacaciones_Pagadas
    {
        /*FPS*/
        public static DataTable Lista_Vacaciones_Pagadas(Ent_Vacaciones_Pagadas objE)
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Vacaciones_Pagadas", objE.Vacaciones_pagadas_id, objE.Vacaciones_id);
        }

        public static DataSet Actualiza_Vacaciones_Pagadas(Ent_Vacaciones_Pagadas objE)
        {
            return SqlHelper.ExecuteDataset(Conex.CadCon(), "fps_spu_Vacaciones_Pagadas", objE.Vacaciones_pagadas_id, objE.Periodo_id, objE.Fecha_Ini, objE.Fecha_Fin, objE.Lvendido);
        }

        public static DataSet Elimina_Vacaciones_Pagadas(Ent_Vacaciones_Pagadas objE)
        {
            return SqlHelper.ExecuteDataset(Conex.CadCon(), "fps_spd_Vacaciones_Pagadas", objE.Vacaciones_pagadas_id);
        }

        public static DataSet Inserta_Vacaciones_Pagadas(Ent_Vacaciones_Pagadas objE)
        {
            return SqlHelper.ExecuteDataset(Conex.CadCon(), "fps_spi_Vacaciones_Pagadas", objE.Vacaciones_id, objE.Periodo_id, objE.Fecha_Ini, objE.Fecha_Fin, objE.Lvendido);
        }

    }
}
