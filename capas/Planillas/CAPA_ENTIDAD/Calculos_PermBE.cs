using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Calculos_PermBE
    {
        private string planilla_id;

        public string Planilla_id
        {
            get { return planilla_id; }
            set { planilla_id = value; }
        }
        private string periodo_Id;

        public string Periodo_Id
        {
            get { return periodo_Id; }
            set { periodo_Id = value; }
        }
        private string personal_Id;

        public string Personal_Id
        {
            get { return personal_Id; }
            set { personal_Id = value; }
        }
        private string concepto_Id;

        public string Concepto_Id
        {
            get { return concepto_Id; }
            set { concepto_Id = value; }
        }
        private string proceso_Id;

        public string Proceso_Id
        {
            get { return proceso_Id; }
            set { proceso_Id = value; }
        }
        private double valor;

        public double Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        private double valor_Anterior;

        public double Valor_Anterior
        {
            get { return valor_Anterior; }
            set { valor_Anterior = value; }
        }
    }
}
