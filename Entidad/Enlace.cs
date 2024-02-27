using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capas.Portal.Entidad
{
    public class Enlace
    {
        public Int32 Enlace_Id { get; set; }
        public String Nom_Enlace { get; set; }
        public String Direccion { get; set; }
        public Boolean fl_visible_admin { get; set; }
    }
}
