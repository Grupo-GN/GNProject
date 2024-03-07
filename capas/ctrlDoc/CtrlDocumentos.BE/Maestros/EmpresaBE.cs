using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CtrlDocumentos.BE.Maestros
{
    [Serializable]
    public class EmpresaBE
    {
        public Int32 id_empresa { get; set; }
        public String nu_ruc { get; set; }
        public String no_razon_social { get; set; }
        public String de_empresa { get; set; }
        public String no_contacto { get; set; }
        public String nu_telefono { get; set; }
        public String nu_celular { get; set; }
        public String no_correo { get; set; }
        public String no_logo { get; set; }
        public String co_tipo_empresa { get; set; }
        public String fl_activo { get; set; }
        public String co_usuario_crea { get; set; }
        public DateTime fe_crea { get; set; }
        public String co_usuario_cambio { get; set; }
        public DateTime fe_cambio { get; set; }
        public String no_usuario_red { get; set; }
        public String no_estacion_red { get; set; }

        /*Adicionales*/
        public String no_estado { get; set; }
        public String co_usuario { get; set; }
        public String no_tipo_empresa { get; set; }
    }
}
