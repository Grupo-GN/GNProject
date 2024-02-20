using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CtrlDocumentos.BE
{
    [Serializable]
    public class TreeViewBE
    {
        public String id { get; set; }
        public String text { get; set; }
        public String icon { get; set; }
        public arrayState state { get; set; }
        public TreeViewBEList children { get; set; }
    }

    [Serializable]
    public class TreeViewBEList : List<TreeViewBE>
    {
        public void Ordenar(string propertyName, direccionOrden Direction)
        {
            TreeViewBEComparer dc = new TreeViewBEComparer(propertyName, Direction);
            this.Sort(dc);
        }
    }

    class TreeViewBEComparer : IComparer<TreeViewBE>
    {
        string _prop = "";
        direccionOrden _dir;

        public TreeViewBEComparer(string propertyName, direccionOrden Direction)
        {
            _prop = propertyName;
            _dir = Direction;
        }

        public int Compare(TreeViewBE x, TreeViewBE y)
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

    public class arrayState
    {
        public Boolean opened { get; set; }
        public Boolean disabled { get; set; }
        public Boolean selected { get; set; }
    }
}
