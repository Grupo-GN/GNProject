using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_D_Variables
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

        Decimal _Valor;

        public Decimal Valor
        {
            get { return _Valor; }
            set { _Valor = value; }
        }

        DateTime _Fecha_Modif;

        public DateTime Fecha_Modif
        {
            get { return _Fecha_Modif; }
            set { _Fecha_Modif = value; }
        }

        /*Valores para realizar operaciones Masivas*/
        string _Personal_Id_Masivo;

        public string Personal_Id_Masivo
        {
            get { return _Personal_Id_Masivo; }
            set { _Personal_Id_Masivo = value; }
        }

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

        public String ComentarioValor_Masivo { get; set; }

    }
}