using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Calculos_Perm
    {
        string _Planilla_Id;

        public string Planilla_Id
        {
            get { return _Planilla_Id; }
            set { _Planilla_Id = value; }
        }

        string _Periodo_Id;

        public string Periodo_Id
        {
            get { return _Periodo_Id; }
            set { _Periodo_Id = value; }
        }

        string _Personal_Id;

        public string Personal_Id
        {
            get { return _Personal_Id; }
            set { _Personal_Id = value; }
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

        Decimal _Valor;

        public Decimal Valor
        {
            get { return _Valor; }
            set { _Valor = value; }
        }

        Decimal _Valor_Anterior;

        public Decimal Valor_Anterior
        {
            get { return _Valor_Anterior; }
            set { _Valor_Anterior = value; }
        }

        /*Valores para realizar operaciones Masiva*/
        string _Concepto_Id_Masivo;

        public string Concepto_Id_Masivo
        {
            get { return _Concepto_Id_Masivo; }
            set { _Concepto_Id_Masivo = value; }
        }

        string _Proceso_Id_Masivo;

        public string Proceso_Id_Masivo
        {
            get { return _Proceso_Id_Masivo; }
            set { _Proceso_Id_Masivo = value; }
        }

        string _Valor_Masivo;

        public string Valor_Masivo
        {
            get { return _Valor_Masivo; }
            set { _Valor_Masivo = value; }
        }

        string _Valor_Anterior_Masivo;

        public string Valor_Anterior_Masivo
        {
            get { return _Valor_Anterior_Masivo; }
            set { _Valor_Anterior_Masivo = value; }
        }

    }
}
