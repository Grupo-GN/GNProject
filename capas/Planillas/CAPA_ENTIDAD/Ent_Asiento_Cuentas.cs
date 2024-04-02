using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Asiento_Cuentas
    {
        string _Asiento_Cuenta_Id;

        public string Asiento_Cuenta_Id
        {
            get { return _Asiento_Cuenta_Id; }
            set { _Asiento_Cuenta_Id = value; }
        }

        string _Asiento_Id;

        public string Asiento_Id
        {
            get { return _Asiento_Id; }
            set { _Asiento_Id = value; }
        }

        string _Concepto_Id;

        public string Concepto_Id
        {
            get { return _Concepto_Id; }
            set { _Concepto_Id = value; }
        }

        string _Proceso_Id;

        public string Proceso_Id
        {
            get { return _Proceso_Id; }
            set { _Proceso_Id = value; }
        }

        string _Cuenta_Id;

        public string Cuenta_Id
        {
            get { return _Cuenta_Id; }
            set { _Cuenta_Id = value; }
        }

        string _Cuenta_Tipo;

        public string Cuenta_Tipo
        {
            get { return _Cuenta_Tipo; }
            set { _Cuenta_Tipo = value; }
        }

        string _Glosa;

        public string Glosa
        {
            get { return _Glosa; }
            set { _Glosa = value; }
        }

        public String co_Tipo_agrupacion_asiento_cta { get; set; }
    }
}
