using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Categoria_Auxiliar
    {
        string _Categoria_Auxiliar_Id;

        public string Categoria_Auxiliar_Id
        {
            get { return _Categoria_Auxiliar_Id; }
            set { _Categoria_Auxiliar_Id = value; }
        }

        string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
    }
}
