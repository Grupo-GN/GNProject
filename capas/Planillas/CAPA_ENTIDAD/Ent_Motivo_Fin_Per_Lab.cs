using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Motivo_Fin_Per_Lab
    {
        string _Motivo_Fin_Per_Lab_Id;

        public string Motivo_Fin_Per_Lab_Id
        {
            get { return _Motivo_Fin_Per_Lab_Id; }
            set { _Motivo_Fin_Per_Lab_Id = value; }
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
