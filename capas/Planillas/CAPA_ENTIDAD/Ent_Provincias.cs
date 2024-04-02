using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Provincias
    {
        string _codigo;

        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        string _sub_Filtro;

        public string Sub_Filtro
        {
            get { return _sub_Filtro; }
            set { _sub_Filtro = value; }
        }
    }
}
