using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CtrlDocumentos.BE.Maestros
{
    [Serializable]
    public class PersonaFileBE
    {
        public Int32 id_persona_File { get; set; }
        public Int32 id_persona { get; set; }

        public String no_documento { get; set; }
        public String no_file { get; set; }
        public String no_folder { get; set; }
        public String no_file_all { get; set; }
        public Int32 qt_peso { get; set; }

        public String no_estacion_red { get; set; }
        public String no_usuario_red { get; set; }

        public String no_ruta { get; set; }

        /*Adicionales*/
        public String no_estado { get; set; }
        public String co_usuario { get; set; }

    }

    [Serializable]
    public class PersonaFileBEList : List<PersonaFileBE>
    {
        public void Ordenar(string propertyName, direccionOrden Direction)
        {
            PersonaFileBEComparer dc = new PersonaFileBEComparer(propertyName, Direction);
            this.Sort(dc);
        }
    }

    class PersonaFileBEComparer : IComparer<PersonaFileBE>
    {
        string _prop = "";
        direccionOrden _dir;

        public PersonaFileBEComparer(string propertyName, direccionOrden Direction)
        {
            _prop = propertyName;
            _dir = Direction;
        }

        public int Compare(PersonaFileBE x, PersonaFileBE y)
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