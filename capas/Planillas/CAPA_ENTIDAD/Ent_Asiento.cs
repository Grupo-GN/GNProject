using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Asiento
    {
        string _Asiento_Id;

        public string Asiento_Id
        {
            get { return _Asiento_Id; }
            set { _Asiento_Id = value; }
        }

        string _Compania_Id;

        public string Compania_Id
        {
            get { return _Compania_Id; }
            set { _Compania_Id = value; }
        }

        string _Ejercicio_Id;

        public string Ejercicio_Id
        {
            get { return _Ejercicio_Id; }
            set { _Ejercicio_Id = value; }
        }

        string _Planilla_Id;

        public string Planilla_Id
        {
            get { return _Planilla_Id; }
            set { _Planilla_Id = value; }
        }

        string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        string _Glosa;

        public string Glosa
        {
            get { return _Glosa; }
            set { _Glosa = value; }
        }

        string _Libro;

        public string Libro
        {
            get { return _Libro; }
            set { _Libro = value; }
        }

        string _Estado_Id;

        public string Estado_Id
        {
            get { return _Estado_Id; }
            set { _Estado_Id = value; }
        }
    }
}
