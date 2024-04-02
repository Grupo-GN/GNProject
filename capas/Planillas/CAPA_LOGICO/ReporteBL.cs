using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAPA_DATOS;
using System.Data;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public class ReporteBL
    {
        public int InsertReporte(ReporteBE reporteBE)
        {
            return ReporteDA.Create().InsertReporte(reporteBE);
        }
        public int UpdateReporte(ReporteBE reporteBE)
        {
            return ReporteDA.Create().UpdateReporte(reporteBE);
        }
        public DataTable GetReportes()
        {
            return ReporteDA.Create().GetReportes();
        }
        public DataTable GetReporte(int ReporteID)
        {
            return ReporteDA.Create().GetReporte(ReporteID);
        }
        public DataTable GenerateReporte(int ReporteID, string Periodo_Id)
        {
            return ReporteDA.Create().GenerateReporte(ReporteID, Periodo_Id);
        }
        public int UpdateReporteOrden(ReporteBE reporteBE)
        {
            return ReporteDA.Create().UpdateReporteOrden(reporteBE);
        }
    }
}
