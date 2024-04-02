using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Tipo_Contrato
    {
        string _Tipo_Contrato_Id;

        public string Tipo_Contrato_Id
        {
            get { return _Tipo_Contrato_Id; }
            set { _Tipo_Contrato_Id = value; }
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
