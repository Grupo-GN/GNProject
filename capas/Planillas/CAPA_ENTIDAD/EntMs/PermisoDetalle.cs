using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD.EntMs
{
    public class PermisoDetalle
    {
        public int PDetalle_Id { get; set; }
        public string Nombres { get; set; }
        //public DateTime FechaDiaria { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string TipoPermiso { get; set; }
        public string Nro_Documento { get; set; }
        public int DiasDiferencia { get; set; }
        public int SaldoActual { get; set; }
        public int SaldoAnterior { get; set; }
        public string Periodo { get; set; }
    }
}
