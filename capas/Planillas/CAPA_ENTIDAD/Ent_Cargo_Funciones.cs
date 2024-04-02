using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Cargo_Funciones
    {

         Int32 _Cargo_Funcion_Id;

        public Int32 Cargo_Funcion_Id
        {
            get { return _Cargo_Funcion_Id; }
            set { _Cargo_Funcion_Id = value; }
        }

        string _Cargo_Id;

        public string Cargo_Id
        {
            get { return _Cargo_Id; }
            set { _Cargo_Id = value; }
        }

        string _Funcion;

        public string Funcion
        {
            get { return _Funcion; }
            set { _Funcion = value; }
        }

     

     }
}
