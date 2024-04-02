using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Prm_Afp
    {
        string _Afp_Id;

        public string Afp_Id
        {
            get { return _Afp_Id; }
            set { _Afp_Id = value; }
        }

        string _Periodo_Id;

        public string Periodo_Id
        {
            get { return _Periodo_Id; }
            set { _Periodo_Id = value; }
        }

        string _Concepto_Id;

        public string Concepto_Id
        {
            get { return _Concepto_Id; }
            set { _Concepto_Id = value; }
        }

        Decimal _Valor;

        public Decimal Valor
        {
            get { return _Valor; }
            set { _Valor = value; }
        }

        /*Valores para realizar operaciones Masiva*/
        string _Concepto_Id_Masivo;

        public string Concepto_Id_Masivo
        {
            get { return _Concepto_Id_Masivo; }
            set { _Concepto_Id_Masivo = value; }
        }

        string _Valor_Masivo;

        public string Valor_Masivo
        {
            get { return _Valor_Masivo; }
            set { _Valor_Masivo = value; }
        }

    }
}
