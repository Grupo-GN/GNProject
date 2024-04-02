using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Ejercicio
    {
        string _Ejercicio_Id;

        public string Ejercicio_Id
        {
            get { return _Ejercicio_Id; }
            set { _Ejercicio_Id = value; }
        }

        string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        Int32 _Ano;

        public Int32 Ano
        {
            get { return _Ano; }
            set { _Ano = value; }
        }

        string _Estado_Id;

        public string Estado_Id
        {
            get { return _Estado_Id; }
            set { _Estado_Id = value; }
        }
    }
}
