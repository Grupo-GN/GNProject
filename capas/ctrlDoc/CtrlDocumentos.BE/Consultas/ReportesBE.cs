using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CtrlDocumentos.BE.Consultas
{
    public class ReportesBE
    {
    }

    [Serializable]
    public class RptSegDocumentosBE
    {
        public Int32 id_documento { get; set; }
        public Int32 id_plantilla_doc { get; set; }
        public String no_documento { get; set; }
        public String co_tipo_asignacion { get; set; }
        public Int32 id_persona { get; set; }
        public Int32 id_empresa { get; set; }
        public DateTime fe_inicio { get; set; }
        public DateTime fe_vencimiento { get; set; }
        public String sfe_vencimiento { get; set; }
        public Int32 qt_dias_para_vencimiento { get; set; }
        public String co_estado { get; set; }
        public String usu_crea { get; set; }
        public DateTime fe_crea { get; set; }
        public String usu_cambio { get; set; }
        public DateTime fe_cambio { get; set; }
        public String no_estacion_red { get; set; }
        public String no_usuario_red { get; set; }

        /*Adicionales*/
        public Int32 id_usuario { get; set; }
        public String no_estado { get; set; }
        public String co_usuario { get; set; }

        public Int32 cont_ids_caracteristica { get; set; }
        public String ids_documento_caracteristica { get; set; }
        public String cad_no_caracteristica { get; set; }
        public String cad_co_tipo_dato_caracteristica { get; set; }
        public String cad_no_valor_dato_caracteristica { get; set; }
        public String cad_fl_obligatorio_caracteristica { get; set; }
        public String cad_nu_orden_caracteristica { get; set; }
        public String cad_no_archivo_caracteristica { get; set; }

        public String no_plantilla_doc { get; set; }
        public String no_persona { get; set; }
        public String no_empresa { get; set; }
        public String co_grupo_doc { get; set; }
        public String no_grupo_doc { get; set; }
        public String co_sub_grupo_doc { get; set; }
        public String no_sub_grupo_doc { get; set; }
        public String no_tipo_asignacion { get; set; }
        public Int32 id_persona_empresa { get; set; }
        public String no_persona_empresa { get; set; }

        public String sfe_vencimiento_desde { get; set; }
        public String sfe_vencimiento_hasta { get; set; }

        public String cods_estado { get; set; }
        public String ids_persona_empresa { get; set; }

        public String co_tipo_doc { get; set; }
        public Int32 id_area { get; set; }
        public Int32 id_seccion { get; set; }
    }

}
