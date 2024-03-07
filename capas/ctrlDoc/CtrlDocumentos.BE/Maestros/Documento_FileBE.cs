using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CtrlDocumentos.BE.Maestros
{
    [Serializable]
    public class Documento_FileBE
    {
        public Int32 id_documento_file { get; set; }
        public Int32 id_documento { get; set; }

        public String no_documento { get; set; }
        public String no_file { get; set; }
        public String no_folder { get; set; }
        public String no_file_all { get; set; }
        public Int32 qt_peso { get; set; }

        public String fl_principal { get; set; }
        public String fl_activar_alerta { get; set; }
        public String tx_principal
        {
            get
            {
                return (fl_principal == "1" ? "SI" : "NO");
            }
        }
        public String tx_activar_alerta
        {
            get
            {
                return (fl_activar_alerta == "1" ? "SI" : "NO");
            }
        }

        public DateTime fe_inicio { get; set; }
        public DateTime fe_vencimiento { get; set; }
        public String sfe_inicio { get; set; }
        public String sfe_vencimiento { get; set; }
        public String ids_usuarios_responsables { get; set; }
        public Int32 qt_dias_ant_venc_alerta { get; set; }
        public String fl_reservado { get; set; }
        public String co_estado { get; set; }
        public String co_tipo_doc { get; set; }
        public Int32 id_documento_file_ori { get; set; }

        public String no_estacion_red { get; set; }
        public String no_usuario_red { get; set; }

        /*Adicionales*/
        public String no_estado { get; set; }
        public String no_tipo_doc { get; set; }
        public String co_usuario { get; set; }
    }

    [Serializable]
    public class Documento_FileBEList : List<Documento_FileBE>
    {
        public void Ordenar(string propertyName, direccionOrden Direction)
        {
            Documento_FileBEComparer dc = new Documento_FileBEComparer(propertyName, Direction);
            this.Sort(dc);
        }
    }

    class Documento_FileBEComparer : IComparer<Documento_FileBE>
    {
        string _prop = "";
        direccionOrden _dir;

        public Documento_FileBEComparer(string propertyName, direccionOrden Direction)
        {
            _prop = propertyName;
            _dir = Direction;
        }

        public int Compare(Documento_FileBE x, Documento_FileBE y)
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