using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_AFP
    {
        string _Afp_Id;

        public string Afp_Id
        {
            get { return _Afp_Id; }
            set { _Afp_Id = value; }
        }

        
        string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        string _Estado_id;

        public string Estado_id
        {
            get { return _Estado_id; }
            set { _Estado_id = value; }
        }

    }
}
