using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Categoria
    {
        string _Categoria_Id;

        public string Categoria_Id
        {
            get { return _Categoria_Id; }
            set { _Categoria_Id = value; }
        }
        string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
    }
}
