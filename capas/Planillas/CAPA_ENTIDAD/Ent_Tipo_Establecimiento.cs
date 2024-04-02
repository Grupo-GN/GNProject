using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Tipo_Establecimiento
    {
        string _Tipo_Establecimiento_Id;

        public string Tipo_Establecimiento_Id
        {
            get { return _Tipo_Establecimiento_Id; }
            set { _Tipo_Establecimiento_Id = value; }
        }

        string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
    }
}
