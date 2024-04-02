using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_TDoc_Identidad
    {
        string _Tipo_Doc_Id;

        public string Tipo_Doc_Id
        {
            get { return _Tipo_Doc_Id; }
            set { _Tipo_Doc_Id = value; }
        }

        string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        string _Abreviatura;

        public string Abreviatura
        {
            get { return _Abreviatura; }
            set { _Abreviatura = value; }
        }

    }
}
