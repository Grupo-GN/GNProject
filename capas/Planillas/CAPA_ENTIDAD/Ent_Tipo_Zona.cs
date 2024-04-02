using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Tipo_Zona
    {
        string _Tipo_Zona_Id;

        public string Tipo_Zona_Id
        {
            get { return _Tipo_Zona_Id; }
            set { _Tipo_Zona_Id = value; }
        }

        string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
    }
}
