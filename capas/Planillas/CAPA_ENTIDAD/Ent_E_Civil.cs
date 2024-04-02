using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_E_Civil
    {
        string _E_Civil_Id;

        public string E_Civil_Id
        {
            get { return _E_Civil_Id; }
            set { _E_Civil_Id = value; }
        }

        string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
    }
}
