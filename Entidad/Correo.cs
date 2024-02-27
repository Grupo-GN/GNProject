using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capas.Portal.Entidad
{
    public class Correo
    {
        public Int32 id_correo { get; set; }
        public String co_correo { get; set; }
        public String no_asunto { get; set; }
        public String no_para { get; set; }
        public String no_cc { get; set; }
        public String no_bcc { get; set; }
        public String tx_body { get; set; }
        public String no_images { get; set; }
        public String co_usuario { get; set; }
    }
}
