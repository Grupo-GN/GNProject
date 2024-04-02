using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Sexos
    {
        string _Sexo_Id;

        public string Sexo_Id
        {
            get { return _Sexo_Id; }
            set { _Sexo_Id = value; }
        }

        string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
    }
}
