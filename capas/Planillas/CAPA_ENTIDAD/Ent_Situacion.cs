using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Situacion
    {
        string _Situacion_Id;

        public string Situacion_Id
        {
            get { return _Situacion_Id; }
            set { _Situacion_Id = value; }
        }

        string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
    }
}
