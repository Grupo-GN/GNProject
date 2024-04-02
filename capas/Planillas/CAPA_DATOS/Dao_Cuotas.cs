using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using Microsoft.ApplicationBlocks.Data;

namespace CAPA_DATOS
{
    public static class Dao_Cuotas
    {
        /*FPS*/
        public static DataSet Lista_Cuotas(Ent_Cuotas objE)
        {
            return SqlHelper.ExecuteDataset(Conex.CadCon(), "fps_sps_Cuotas", objE.Cuotas_Id, objE.Cta_Cte_Id);
        }
        public static DataSet Inserta_Cuotas(Ent_Cuotas objE)
        {
            return SqlHelper.ExecuteDataset(Conex.CadCon(), "fps_spi_Cuotas", objE.Cta_Cte_Id, objE.Proceso_Id, objE.Periodo_Id, objE.Monto, objE.Estado_Pago_Id, objE.Estado_Id);
        }
        public static DataSet Actualiza_Cuotas(Ent_Cuotas objE)
        {
            return SqlHelper.ExecuteDataset(Conex.CadCon(), "fps_spu_Cuotas", objE.Cuotas_Id, objE.Proceso_Id, objE.Periodo_Id, objE.Monto, objE.Estado_Pago_Id, objE.Estado_Id);
        }
        public static DataSet Elimina_Cuotas(Ent_Cuotas objE)
        {
            return SqlHelper.ExecuteDataset(Conex.CadCon(), "fps_spd_Cuotas", objE.Cuotas_Id);
        }

    }
}
