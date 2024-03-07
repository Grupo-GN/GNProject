using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;

namespace CtrlDocumentos.BE.Seguridad
{
    [Serializable]
    public class JobBE
    {
        public Int32 id_proceso { get; set; }
        public String no_proceso { get; set; }
        public String no_detalle { get; set; }
        public String fl_proceso { get; set; }
        //
        public String no_estacion_red { get; set; }
        public String no_usuario_red { get; set; }
        public String co_usuario { get; set; }
    }

    [Serializable]
    public class JobBEList : List<JobBE>
    {
        public void Ordenar(string propertyName, direccionOrden Direction)
        {
            JobBEComparer dc = new JobBEComparer(propertyName, Direction);
            this.Sort(dc);
        }
    }

    class JobBEComparer : IComparer<JobBE>
    {
        string _prop = "";
        direccionOrden _dir;

        public JobBEComparer(string propertyName, direccionOrden Direction)
        {
            _prop = propertyName;
            _dir = Direction;
        }

        public int Compare(JobBE x, JobBE y)
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