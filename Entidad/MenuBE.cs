using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;

namespace Capas.Portal.Entidad
{
    [Serializable]
    public class MenuBE
    {
        public Int32 id_menu { get; set; }
        public String tx_descripcion { get; set; }
        public String url_pagina { get; set; }
        public Int32 id_padre { get; set; }
        public String fl_boton { get; set; }
        public Int32 nu_orden { get; set; }
        public String fl_activo { get; set; }
        public String usu_crea { get; set; }
        public DateTime fe_crea { get; set; }
        public String usu_cambio { get; set; }
        public DateTime fe_cambio { get; set; }
    }

    [Serializable]
    public class MenuBEList : List<MenuBE>
    {
        public void Ordenar(string propertyName, direccionOrden Direction)
        {
            MenuBEComparer dc = new MenuBEComparer(propertyName, Direction);
            this.Sort(dc);
        }
    }

    class MenuBEComparer : IComparer<MenuBE>
    {
        string _prop = "";
        direccionOrden _dir;

        public MenuBEComparer(string propertyName, direccionOrden Direction)
        {
            _prop = propertyName;
            _dir = Direction;
        }

        public int Compare(MenuBE x, MenuBE y)
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