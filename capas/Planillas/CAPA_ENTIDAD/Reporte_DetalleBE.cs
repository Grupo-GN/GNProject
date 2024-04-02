using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Reporte_DetalleBE
    {
        public int Reporte_DetalleID { get; set; }
        public int ReporteID { get; set; }
        public int Orden { get; set; }
        public string Columna { get; set; }
        public string Alias { get; set; }
        public bool Tipo { get; set; }
    }
}
