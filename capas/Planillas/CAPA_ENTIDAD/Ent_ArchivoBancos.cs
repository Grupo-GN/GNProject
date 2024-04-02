using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// =================================================================
/// @001 FPS 07/04/2020 - Se agrega Tipo de Cta Ahorro
/// =================================================================

namespace CAPA_ENTIDAD
{
    public class Ent_ArchivoBancos
    {
        public string PersonalId { get; set; }
        public string NroDoc { get; set; }
        public string APaterno { get; set; }
        public string AMaterno { get; set; }
        public string Nombres { get; set; }
        public string ApellidosNombres { get { return (APaterno + " " + AMaterno + ", " + Nombres); } }
        public string Banco { get; set; }
        public string Cta { get; set; }
        public decimal Valor { get; set; }
        public bool Estado { get; set; }
        public string NEstado { get { return Estado == true ? "ACTIVO" : "INACTIVO"; } }

        public string CatAuxiliar { get; set; }
        public string Area { get; set; }
        public string Proyecto { get; set; }
        public string Tipo_Cta_Ahorro { get; set; } //@001 I/F
    }
}
