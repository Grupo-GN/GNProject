using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Bancos
    {
        string _Banco_Id;

        public string Banco_Id
        {
            get { return _Banco_Id; }
            set { _Banco_Id = value; }
        }
        string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
    }
}
