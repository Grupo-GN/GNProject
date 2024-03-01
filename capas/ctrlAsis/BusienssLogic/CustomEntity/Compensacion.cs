using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusienssLogic.CustomEntity
{
   public class Compensacion
    {
        public int id_compensacion { get; set; }
        public string  id_personal { get; set; }
        public string cod_trabajador_id { get; set; }
        public string mod_conpensacion { get; set; }
        public DateTime fecha_crea { get; set; }
        public DateTime fecha_mod { get; set; }
        public string estado { get; set; }

    }
}
