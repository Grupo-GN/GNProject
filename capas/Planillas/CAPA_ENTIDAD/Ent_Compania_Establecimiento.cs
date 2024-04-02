using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Compania_Establecimiento
    {
        string _Establecimiento_Id;

        public string Establecimiento_Id
        {
            get { return _Establecimiento_Id; }
            set { _Establecimiento_Id = value; }
        }

        string _Compania_Id;

        public string Compania_Id
        {
            get { return _Compania_Id; }
            set { _Compania_Id = value; }
        }

        string _Tipo_Establecimiento_Id;

        public string Tipo_Establecimiento_Id
        {
            get { return _Tipo_Establecimiento_Id; }
            set { _Tipo_Establecimiento_Id = value; }
        }

        string _Codigo_Establecimiento;

        public string Codigo_Establecimiento
        {
            get { return _Codigo_Establecimiento; }
            set { _Codigo_Establecimiento = value; }
        }

        string _Denominacion;

        public string Denominacion
        {
            get { return _Denominacion; }
            set { _Denominacion = value; }
        }

        Boolean _CentroRiesgo;

        public Boolean CentroRiesgo
        {
            get { return _CentroRiesgo; }
            set { _CentroRiesgo = value; }
        }

        Decimal _Tasa;

        public Decimal Tasa
        {
            get { return _Tasa; }
            set { _Tasa = value; }
        }

        string _Estado_Id;

        public string Estado_Id
        {
            get { return _Estado_Id; }
            set { _Estado_Id = value; }
        }
    }
}
