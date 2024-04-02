using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
     public class Ent_TipoCtaBancaria
    {
        string TCB_Id;

        public string _TCB_Id
        {
            get { return TCB_Id; }
            set { TCB_Id = value; }
        }
        string Descripcion;

        public string _Descripcion
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }
    }
}
