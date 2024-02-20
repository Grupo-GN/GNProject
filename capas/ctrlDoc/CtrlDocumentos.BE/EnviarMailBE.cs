using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;

namespace CtrlDocumentos.BE
{
    [Serializable]
    public class EnviarMailBE
    {
        public String no_para { get; set; }
        public String no_copia { get; set; }
        public String no_copia_oculta { get; set; }
        public String no_asunto { get; set; }
        public String no_cuerpo { get; set; }
    }

    [Serializable]
    public class EnviarMailBEList : List<EnviarMailBE>
    {
        public void Ordenar(string propertyName, direccionOrden Direction)
        {
            EnviarMailBEComparer dc = new EnviarMailBEComparer(propertyName, Direction);
            this.Sort(dc);
        }
    }

    class EnviarMailBEComparer : IComparer<EnviarMailBE>
    {
        string _prop = "";
        direccionOrden _dir;

        public EnviarMailBEComparer(string propertyName, direccionOrden Direction)
        {
            _prop = propertyName;
            _dir = Direction;
        }

        public int Compare(EnviarMailBE x, EnviarMailBE y)
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