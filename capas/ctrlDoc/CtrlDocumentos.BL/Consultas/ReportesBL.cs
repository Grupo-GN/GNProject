using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CtrlDocumentos.BE.Consultas;
using CtrlDocumentos.DA.Consultas;

namespace CtrlDocumentos.BL.Consultas
{
    public class ReportesBL
    {
        ReportesDA oReportesDA = new ReportesDA();
        #region "Reporte de Seguimiendo de Documentos"
        public List<RptSegDocumentosBE> getReporte_SegDocumentos(RptSegDocumentosBE oRptSegDocumentosBE)
        {
            try
            {
                return oReportesDA.getReporte_SegDocumentos(oRptSegDocumentosBE);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }
        #endregion
    }
}
