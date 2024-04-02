using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_GenerarArchivoEstado
    {
        public string Planilla_Id { get; set; }
        public string Periodo_Id { get; set; }
        public string Personal_Id { get; set; }
        public int Codigo_Id { get; set; }
        public string Estado_Id { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechReg { get; set; }
        public string UsuarioReg { get; set; }
        public DateTime FechaAct { get; set; }
        public string UsuarioAct { get; set; }
    }
}
