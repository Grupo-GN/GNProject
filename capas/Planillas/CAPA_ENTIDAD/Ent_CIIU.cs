using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_CIIU
    {
        string _CIIU_Id;

        public string CIIU_Id
        {
            get { return _CIIU_Id; }
            set { _CIIU_Id = value; }
        }

        string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
    }
}
