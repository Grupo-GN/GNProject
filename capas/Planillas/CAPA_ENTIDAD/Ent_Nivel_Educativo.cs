using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Nivel_Educativo
    {
        string _Nivel_Educativo_Id;

        public string Nivel_Educativo_Id
        {
            get { return _Nivel_Educativo_Id; }
            set { _Nivel_Educativo_Id = value; }
        }

        string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
    }
}
