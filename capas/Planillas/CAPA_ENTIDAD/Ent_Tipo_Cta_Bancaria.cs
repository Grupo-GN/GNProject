using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Tipo_Cta_Bancaria
    {
        string _TCB_Id;

        public string TCB_Id
        {
            get { return _TCB_Id; }
            set { _TCB_Id = value; }
        }

        string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
    }
}
