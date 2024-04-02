using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Mes
    {
        string _Mes_Id;

        public string Mes_Id
        {
            get { return _Mes_Id; }
            set { _Mes_Id = value; }
        }

        string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        string _Ejercicio_Id;

        public string Ejercicio_Id
        {
            get { return _Ejercicio_Id; }
            set { _Ejercicio_Id = value; }
        }

        Int32 _nMes;

        public Int32 NMes
        {
            get { return _nMes; }
            set { _nMes = value; }
        }

        Int32 _nSemanas;

        public Int32 NSemanas
        {
            get { return _nSemanas; }
            set { _nSemanas = value; }
        }
    }
}
