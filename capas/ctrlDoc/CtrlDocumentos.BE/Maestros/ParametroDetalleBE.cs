using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;

namespace CtrlDocumentos.BE.Maestros
{
    [Serializable]
    public class ParametroDetalleBE
    {
        public Int32 id_parametro_detalle { get; set; }
        public Int32 id_parametro { get; set; }
        public String no_valor1 { get; set; }
        public String no_valor2 { get; set; }
        public String no_valor3 { get; set; }
        public String no_valor4 { get; set; }
        public String no_valor5 { get; set; }
        public String fl_activo { get; set; }
        public String no_estacion_red { get; set; }
        public String no_usuario_red { get; set; }

        /*Adicionales*/
        public String no_estado { get; set; }
        public String co_usuario { get; set; }

        public String ids_plantilla_doc { get; set; }
        public String noms_plantilla_doc { get; set; }
    }

    [Serializable]
    public class ParametroDetalleBEList : List<ParametroDetalleBE>
    {
        public void Ordenar(string propertyName, direccionOrden Direction)
        {
            ParametroDetalleBEComparer dc = new ParametroDetalleBEComparer(propertyName, Direction);
            this.Sort(dc);
        }
    }

    class ParametroDetalleBEComparer : IComparer<ParametroDetalleBE>
    {
        string _prop = "";
        direccionOrden _dir;

        public ParametroDetalleBEComparer(string propertyName, direccionOrden Direction)
        {
            _prop = propertyName;
            _dir = Direction;
        }

        public int Compare(ParametroDetalleBE x, ParametroDetalleBE y)
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