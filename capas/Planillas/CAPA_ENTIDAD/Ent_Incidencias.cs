using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Incidencias
    {
        string _Tabla;

        public string Tabla
        {
            get { return _Tabla; }
            set { _Tabla = value; }
        }
        string _campos;

        public string campos
        {
            get { return _campos; }
            set { _campos = value; }
        }
    }
}
