using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class FormulasBE
    {
        private string newFormula_Id;
        public string Formula_Id
        {
            get { return newFormula_Id; }
            set { newFormula_Id = value; }
        }

        private string newConcepto_Id;
        public string Concepto_Id
        {
            get { return newConcepto_Id; }
            set { newConcepto_Id = value; }
        }

        private string newPlanilla_Id;
        public string Planilla_Id
        {
            get { return newPlanilla_Id; }
            set { newPlanilla_Id = value; }
        }

        private Int32 newNro;
        public Int32 Nro
        {
            get { return newNro; }
            set { newNro = value; }
        }

        private string newFormula_texto;
        public string Formula_texto
        {
            get { return newFormula_texto; }
            set { newFormula_texto = value; }
        }

        private string newFormula_condicion;
        public string Formula_condicion
        {
            get { return newFormula_condicion; }
            set { newFormula_condicion = value; }
        }

        private string newFuente_Proceso_Id;
        public string Fuente_Proceso_Id
        {
            get { return newFuente_Proceso_Id; }
            set { newFuente_Proceso_Id = value; }
        }

        private string newEstado_Id;
        public string Estado_Id
        {
            get { return newEstado_Id; }
            set { newEstado_Id = value; }
        }

        private DateTime newFecha_Modif;
        public DateTime Fecha_Modif
        {
            get { return newFecha_Modif; }
            set { newFecha_Modif = value; }
        }

        private string newGRUPO_ID;
        public string GRUPO_ID
        {
            get { return newGRUPO_ID; }
            set { newGRUPO_ID = value; }
        }

    }
}
