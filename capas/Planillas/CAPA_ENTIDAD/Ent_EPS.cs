using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_EPS
    {
        string _EPS_Id;

        public string EPS_Id
        {
            get { return _EPS_Id; }
            set { _EPS_Id = value; }
        }
        string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        string _Ruc;

        public string Ruc
        {
            get { return _Ruc; }
            set { _Ruc = value; }
        }
    }
}
