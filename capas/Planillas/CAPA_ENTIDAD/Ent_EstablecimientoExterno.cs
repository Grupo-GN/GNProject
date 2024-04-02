using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_EstablecimientoExterno
    {
        string Cia_Ext_Establec_Id;

        public string _Cia_Ext_Establec_Id
        {
            get { return Cia_Ext_Establec_Id; }
            set { Cia_Ext_Establec_Id = value; }
        }
        string Compania_Externa_Id;

        public string _Compania_Externa_Id
        {
            get { return Compania_Externa_Id; }
            set { Compania_Externa_Id = value; }
        }
        string Descripcion;

        public string _Descripcion
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }
        string CentroRiesgo;

        public string _CentroRiesgo
        {
            get { return CentroRiesgo; }
            set { CentroRiesgo = value; }
        }
        int Codigo_Establecimiento;

        public int _Codigo_Establecimiento
        {
            get { return Codigo_Establecimiento; }
            set { Codigo_Establecimiento = value; }
        }
        int Tasa;

        public int _Tasa
        {
            get { return Tasa; }
            set { Tasa = value; }
        }
    }
}
