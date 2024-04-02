using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Nacionalidad
    {
        string _Nacionalidad_Id;

        public string Nacionalidad_Id
        {
            get { return _Nacionalidad_Id; }
            set { _Nacionalidad_Id = value; }
        }
        string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
    }
}
