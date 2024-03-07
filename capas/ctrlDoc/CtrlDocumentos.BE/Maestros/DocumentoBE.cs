using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CtrlDocumentos.BE.Maestros
{
    [Serializable]
    public class DocumentoBE
    {
        public Int32 id_documento { get; set; }
        public Int32 id_plantilla_doc { get; set; }
        public String no_documento { get; set; }
        public String co_tipo_asignacion { get; set; }
        public Int32 id_persona { get; set; }
        public Int32 id_empresa { get; set; }
        public DateTime fe_inicio { get; set; }
        public DateTime fe_vencimiento { get; set; }
        public String ids_usuarios_responsables { get; set; }
        public Int32 qt_dias_ant_venc_alerta { get; set; }
        public String co_estado { get; set; }
        public String fl_activo { get; set; }
        public String usu_crea { get; set; }
        public DateTime fe_crea { get; set; }
        public String usu_cambio { get; set; }
        public DateTime fe_cambio { get; set; }
        public String no_estacion_red { get; set; }
        public String no_usuario_red { get; set; }

        public Int32 id_documento_ori { get; set; }
        public Boolean fl_reservado { get; set; }

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
        public Int32 qt_dias_para_vencimiento { get; set; }

        public String sfe_vencimiento_desde { get; set; }
        public String sfe_vencimiento_hasta { get; set; }

        public String cods_estado { get; set; }
        public String ids_persona_empresa { get; set; }

        public Int32 id_area { get; set; }
        public Int32 id_seccion { get; set; }
        public String cods_tipo_doc_file { get; set; }
    }

    [Serializable]
    public class DocumentoBEList : List<DocumentoBE>
    {
        public void Ordenar(string propertyName, direccionOrden Direction)
        {
            DocumentoBEComparer dc = new DocumentoBEComparer(propertyName, Direction);
            this.Sort(dc);
        }
    }

    class DocumentoBEComparer : IComparer<DocumentoBE>
    {
        string _prop = "";
        direccionOrden _dir;

        public DocumentoBEComparer(string propertyName, direccionOrden Direction)
        {
            _prop = propertyName;
            _dir = Direction;
        }

        public int Compare(DocumentoBE x, DocumentoBE y)
        {

            PropertyInfo propertyX = x.GetType().GetProperty(_prop);
            PropertyInfo propertyY = y.GetType().GetProperty(_prop);

            object px = propertyX.GetValue(x, null);
            object py = propertyY.GetValue(y, null);

            if (px == null && py == null)
            {
                return 0;
            }
            else if (px != null && py == null)
            {
                if (_dir == direccionOrden.Ascending)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            else if (px == null && py != null)
            {
                if (_dir == direccionOrden.Ascending)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            else if (px.GetType().GetInterface("IComparable") != null)
            {
                if (_dir == direccionOrden.Ascending)
                {
                    return ((IComparable)px).CompareTo(py);
                }
                else
                {
                    return ((IComparable)py).CompareTo(px);
                }
            }
            else
            {
                return 0;
            }
        }
    }
}