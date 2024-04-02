using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Compania_Externa_Establecimientos
    {
        string _Cia_Ext_Establec_Id;

        public string Cia_Ext_Establec_Id
        {
            get { return _Cia_Ext_Establec_Id; }
            set { _Cia_Ext_Establec_Id = value; }
        }

        string _Compania_Externa_Id;

        public string Compania_Externa_Id
        {
            get { return _Compania_Externa_Id; }
            set { _Compania_Externa_Id = value; }
        }

        string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        Boolean _CentroRiesgo;

        public Boolean CentroRiesgo
        {
            get { return _CentroRiesgo; }
            set { _CentroRiesgo = value; }
        }

        string _Codigo_Establecimiento;

        public string Codigo_Establecimiento
        {
            get { return _Codigo_Establecimiento; }
            set { _Codigo_Establecimiento = value; }
        }

        Decimal _Tasa;

        public Decimal Tasa
        {
            get { return _Tasa; }
            set { _Tasa = value; }
        }
    }
}
