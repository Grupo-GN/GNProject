using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capas.Portal.Entidad
{
    public class OHSAS_Detalle
    {
        public Int32 id_ohsas_detalle { get; set; }
        public Int32 id_ohsas { get; set; }
        public String no_ohsas { get; set; }
        public String no_titulo { get; set; }
        public String tx_descripcion { get; set; }
        public String no_archivo { get; set; }
        public DateTime fe_registro { get; set; }
        public String sfe_registro { get; set; }
        public String Categoria_Auxiliar_Id { get; set; }
        public String no_area { get; set; }
        public String co_usuario { get; set; }
    }
}
