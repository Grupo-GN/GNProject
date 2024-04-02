using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Distritos
    {
        string _Codigo;

        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        string _Sub_Filtro; /*Departamento_Id + Provincia_Id*/

        public string Sub_Filtro
        {
            get { return _Sub_Filtro; }
            set { _Sub_Filtro = value; }
        }
    }
}
