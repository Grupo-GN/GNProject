using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_ReporteAsientoSap
    {
        public string Proceso { get; set; }
        public string CodigoSap { get; set; }
        public string NPersonal { get; set; }
        public string Cuenta { get; set; }
        public string CCosto { get; set; }
        public string Codigo { get; set; }
        public string Glosa { get; set; }
        public decimal Cargo { get; set; }
        public decimal Abono { get; set; }
    }

    public class Ent_ReporteAsientoStarSoft
    {
        public string Periodo_Id { get; set; }
        public string Planilla { get; set; }
        public string Proceso { get; set; }
        public string Personal_Id { get; set; }
        public string Trabajador { get; set; }
        public string CuentaContable { get; set; }
        public string CentroCosto { get; set; }
        public string Dni { get; set; }
        public string Glosa { get; set; }
        public double Cargo { get; set; }
        public double Abono { get; set; }
        /* 20180731 */
        public string EJERCICIO { get; set; }
        public string SUBDIARIO { get; set; }
        public string COMPROBANTE { get; set; }
        public string FECHADOC { get; set; }
        public string TIPO_ANEXO { get; set; }
        public string CODIGO_ANEXO { get; set; }
        public string TIPO_DOC { get; set; }
        public string NRO_DOC { get; set; }
        public string FECHA_VENC { get; set; }
        public string MONEDA { get; set; }
        public string CONV { get; set; }
        public string FECHA_REG { get; set; }
        public string TC { get; set; }
        public string GLOSA2 { get; set; }
        public string DOC_ANULADO { get; set; }
        public string DH { get; set; }
        public string MED_PAGO { get; set; }
        public string NRO_FILE { get; set; }
        public string FLUJO_EFEC { get; set; }
        public double MONTO { get; set; }
    }
}
