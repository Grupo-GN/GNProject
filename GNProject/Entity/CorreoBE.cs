using GNProject.Entity.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace GNProject.Entity
{
    [Serializable]
    public class CorreoBE
    {
        public Int32 id_correo { get; set; }
        public String no_asunto { get; set; }
        public String no_para { get; set; }
        public String no_cc { get; set; }
        public String no_bcc { get; set; }
        public String no_detalle { get; set; }
        public String fl_activo { get; set; }
        public String no_estacion_red { get; set; }
        public String no_usuario_red { get; set; }

        /*Adicionales*/
        public String no_estado { get; set; }
        public String co_usuario { get; set; }
    }

    [Serializable]
    public class CorreoBEList : List<CorreoBE>
    {
        public void Ordenar(string propertyName, direccionOrden Direction)
        {
            CorreoBEComparer dc = new CorreoBEComparer(propertyName, Direction);
            this.Sort(dc);
        }
    }

    class CorreoBEComparer : IComparer<CorreoBE>
    {
        string _prop = "";
        direccionOrden _dir;

        public CorreoBEComparer(string propertyName, direccionOrden Direction)
        {
            _prop = propertyName;
            _dir = Direction;
        }

        public int Compare(CorreoBE x, CorreoBE y)
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