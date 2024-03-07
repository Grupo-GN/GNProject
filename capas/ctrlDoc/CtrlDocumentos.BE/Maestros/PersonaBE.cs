using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CtrlDocumentos.BE.Maestros
{
    [Serializable]
    public class PersonaBE
    {
        public Int32 id_persona { get; set; }
        public String co_tipo_documento { get; set; }
        public String nu_documento { get; set; }
        public String ape_paterno { get; set; }
        public String ape_materno { get; set; }
        public String no_persona { get; set; }
        public String no_razon_social { get; set; }
        public String no_contacto { get; set; }
        public String nu_telefono { get; set; }
        public String nu_celular { get; set; }
        public String no_correo { get; set; }
        public String no_foto { get; set; }
        public String fl_activo { get; set; }
        public String co_usuario_crea { get; set; }
        public DateTime fe_crea { get; set; }
        public String co_usuario_cambio { get; set; }
        public DateTime fe_cambio { get; set; }
        public String no_estacion_red { get; set; }
        public String no_usuario_red { get; set; }
        public String fl_aprobar { get; set; }
        public String tx_comentario { get; set; }

        /*Adicionales*/
        public String no_estado { get; set; }
        public String co_usuario { get; set; }
        public String no_busqueda { get; set; }
        public String no_documento { get; set; }
        public String no_localidad { get; set; }
        public String no_area { get; set; }
        public String no_seccion { get; set; }

        public Int32 id_cargo { get; set; }
        public Int32 id_planilla { get; set; }
        public Int32 id_tipo_contrato { get; set; }

        public String fe_ingreso { get; set; }
        public String fe_cese { get; set; }

        public String fe_ini_contrato { get; set; }
        public String fe_fin_contrato { get; set; }
        public String co_tipo_cese { get; set; }

        public Int32 id_area { get; set; }
        public Int32 id_seccion { get; set; }
        public Int32 id_localidad { get; set; }

        public Int32 id_jefe { get; set; }

        public String no_usuario { get; set; }
        public String no_clave { get; set; }
        public Int32 id_perfil { get; set; }
        /*Direccion*/
        public PersonaDireccionBEList oDireccionBEList { get; set; }

    }

    [Serializable]
    public class PersonaBEList : List<PersonaBE>
    {
        public void Ordenar(string propertyName, direccionOrden Direction)
        {
            PersonaBEComparer dc = new PersonaBEComparer(propertyName, Direction);
            this.Sort(dc);
        }
    }

    class PersonaBEComparer : IComparer<PersonaBE>
    {
        string _prop = "";
        direccionOrden _dir;

        public PersonaBEComparer(string propertyName, direccionOrden Direction)
        {
            _prop = propertyName;
            _dir = Direction;
        }

        public int Compare(PersonaBE x, PersonaBE y)
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