using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;

namespace CtrlDocumentos.BE.Seguridad
{
    [Serializable]
    public class PerfilBE
    {
        public Int32 id_perfil { get; set; }
        public String no_perfil { get; set; }
        public String tx_descripcion { get; set; }
        public String fl_activo { get; set; }
        public String usu_crea { get; set; }
        public DateTime fe_crea { get; set; }
        public String usu_cambio { get; set; }
        public DateTime fe_cambio { get; set; }
        public String no_estacion_red { get; set; }
        public String no_usuario_red { get; set; }
        public Int32 nu_usuarios { get; set; }

        /*Adicionales*/
        public String no_estado { get; set; }
        public String co_usuario { get; set; }
        public Int32 cont_ids_menu { get; set; }
        public String ids_menu { get; set; }
        public String fl_interno { get; set; }
        public String fl_proveedor { get; set; }

        public String ids_plantilla_doc { get; set; }
    }

    [Serializable]
    public class PerfilBEList : List<PerfilBE>
    {
        public void Ordenar(string propertyName, direccionOrden Direction)
        {
            PerfilBEComparer dc = new PerfilBEComparer(propertyName, Direction);
            this.Sort(dc);
        }
    }

    class PerfilBEComparer : IComparer<PerfilBE>
    {
        string _prop = "";
        direccionOrden _dir;

        public PerfilBEComparer(string propertyName, direccionOrden Direction)
        {
            _prop = propertyName;
            _dir = Direction;
        }

        public int Compare(PerfilBE x, PerfilBE y)
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