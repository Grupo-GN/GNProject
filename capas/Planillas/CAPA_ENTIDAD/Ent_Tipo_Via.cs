using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Tipo_Via
    {
        string _Tipo_Via_Id;

        public string Tipo_Via_Id
        {
            get { return _Tipo_Via_Id; }
            set { _Tipo_Via_Id = value; }
        }

        string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
    }
}
