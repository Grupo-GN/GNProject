﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;

namespace CtrlDocumentos.BE.Maestros
{
    [Serializable]
    public class CargoBE
    {
        public Int32 id_cargo { get; set; }
        public String no_cargo { get; set; }
        public String de_cargo { get; set; }
        public String co_homologacion { get; set; }
        public String fl_activo { get; set; }
        public String usu_crea { get; set; }
        public DateTime fe_crea { get; set; }
        public String usu_cambio { get; set; }
        public DateTime fe_cambio { get; set; }
        public String no_estacion_red { get; set; }
        public String no_usuario_red { get; set; }

        /*Adicionales*/
        public String no_estado { get; set; }
        public String co_usuario { get; set; }
    }

    [Serializable]
    public class CargoBEList : List<CargoBE>
    {
        public void Ordenar(string propertyName, direccionOrden Direction)
        {
            CargoBEComparer dc = new CargoBEComparer(propertyName, Direction);
            this.Sort(dc);
        }
    }

    class CargoBEComparer : IComparer<CargoBE>
    {
        string _prop = "";
        direccionOrden _dir;

        public CargoBEComparer(string propertyName, direccionOrden Direction)
        {
            _prop = propertyName;
            _dir = Direction;
        }

        public int Compare(CargoBE x, CargoBE y)
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