using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    [Serializable]
    public class EjecucionScriptBE
    {        
        public Int32 nid_script { get; set; }
        public String tx_comentario { get; set; }
        public String no_query { get; set; }
        public String no_query_html { get; set; }
        public Boolean fl_aprobado { get; set; }
        public String co_token { get; set; }

        public String fl_inactivo { get; set; }
        public DateTime fe_crea { get; set; }
        public String co_usuario_crea { get; set; }
        public DateTime fe_cambio { get; set; }
        public String co_usuario_cambio { get; set; }
        public String no_estacion_red { get; set; }
        public String no_usuario_red { get; set; }
    }
}
