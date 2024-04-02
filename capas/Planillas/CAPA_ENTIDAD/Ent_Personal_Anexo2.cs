using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    [Serializable]
    public class Ent_Personal_Anexo2
    {
        string _Personal_Anexo2_Id;

        public string Personal_Anexo2_Id
        {
            get { return _Personal_Anexo2_Id; }
            set { _Personal_Anexo2_Id = value; }
        }

        string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
    }
}
