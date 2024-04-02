using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Ccosto
    {
        string _Ccosto_Id;

        public string Ccosto_Id
        {
            get { return _Ccosto_Id; }
            set { _Ccosto_Id = value; }
        }

        string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        string _Estado_Id;

        public string Estado_Id
        {
            get { return _Estado_Id; }
            set { _Estado_Id = value; }
        }

        string _Dpto;

        public string Dpto
        {
            get { return _Dpto; }
            set { _Dpto = value; }
        }

        string _Prov;

        public string Prov
        {
            get { return _Prov; }
            set { _Prov = value; }
        }

        string _Dist;

        public string Dist
        {
            get { return _Dist; }
            set { _Dist = value; }
        }

        string _Codigo_Auxiliar;

        public string Codigo_Auxiliar
        {
            get { return _Codigo_Auxiliar; }
            set { _Codigo_Auxiliar = value; }
        }
    }
}
