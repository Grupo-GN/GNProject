using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAPA_DATOS;
using System.Data;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public class Reporte_DetalleBL
    {
        public DataTable GetReporteDetalle(int ReporteID)
        {
            return Reporte_DetalleDA.Create().GetReporteDetalle(ReporteID);
        }
        public int InsertReporteDetalle(Reporte_DetalleBE reporte_DetalleBE)
        {
            return Reporte_DetalleDA.Create().InsertReporteDetalle(reporte_DetalleBE);
        }
        public int UpdateReporteDetalle(Reporte_DetalleBE reporte_DetalleBE)
        {
            return Reporte_DetalleDA.Create().UpdateReporteDetalle(reporte_DetalleBE);
        }
        public int UpDownReporteDetalle(int Reporte_DetalleID, int Valor)
        {
            return Reporte_DetalleDA.Create().UpDownReporteDetalle(Reporte_DetalleID, Valor);
        }
        public int DeleteReporteDetalle(int Reporte_DetalleID)
        {
            return Reporte_DetalleDA.Create().DeleteReporteDetalle(Reporte_DetalleID);
        }
    }
}
