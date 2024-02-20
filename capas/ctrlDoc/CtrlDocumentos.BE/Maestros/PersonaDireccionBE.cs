using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CtrlDocumentos.BE.Maestros
{
    [Serializable]
    public class PersonaDireccionBE
    {
        public Int32 id_persona_direccion { get; set; }
        public Int32 id_persona { get; set; }
        public String co_dpto { get; set; }
        public String co_prov { get; set; }
        public String co_dist { get; set; }
        public String no_direccion { get; set; }
        public String fl_activo { get; set; }
        public String co_usuario_crea { get; set; }
        public DateTime fe_crea { get; set; }
        public String co_usuario_cambio { get; set; }
        public DateTime fe_cambio { get; set; }
        public String no_estacion_red { get; set; }
        public String no_usuario_red { get; set; }

        public String no_contacto { get; set; }
        public String nu_telefono { get; set; }
        public String nu_celular { get; set; }
        public String no_correo { get; set; }


        /*Adicionales*/
        public String no_estado { get; set; }
        public String no_dpto { get; set; }
        public String no_prov { get; set; }
        public String no_dist { get; set; }
        public String co_usuario { get; set; }
    }

    [Serializable]
    public class PersonaDireccionBEList : List<PersonaDireccionBE>
    {
        public void Ordenar(string propertyName, direccionOrden Direction)
        {
            PersonaDireccionBEComparer dc = new PersonaDireccionBEComparer(propertyName, Direction);
            this.Sort(dc);
        }
    }

    class PersonaDireccionBEComparer : IComparer<PersonaDireccionBE>
    {
        string _prop = "";
        direccionOrden _dir;

        public PersonaDireccionBEComparer(string propertyName, direccionOrden Direction)
        {
            _prop = propertyName;
            _dir = Direction;
        }

        public int Compare(PersonaDireccionBE x, PersonaDireccionBE y)
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