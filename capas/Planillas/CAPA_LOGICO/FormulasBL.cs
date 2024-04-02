using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAPA_ENTIDAD;
using CAPA_DATOS;
using System.Data;

namespace CAPA_LOGICO
{
    public class FormulasBL
    {
        public DataTable GetFormulas(string PlanillaID, string Proceso_Id)
        {
            return FormulasDA.Create().GetFormulas(PlanillaID, Proceso_Id);
        }

        public int InsertFormula(FormulasBE formulasBE, bool ChangeLastNro, string Proceso_Id)
        {
            return FormulasDA.Create().InsertFormula(formulasBE, ChangeLastNro, Proceso_Id);
        }

        public int UpdateFormula(FormulasBE formulasBE, string Proceso_Id)
        {
            return FormulasDA.Create().UpdateFormula(formulasBE, Proceso_Id);
        }

        public DataTable GetFormula(string FormulaID)
        {
            return FormulasDA.Create().GetFormula(FormulaID);
        }

        public int GetLastNro(string PlanillaID)
        {
            return FormulasDA.Create().GetLastNro(PlanillaID);
        }

        public int DeleteFormula(string FormulaID)
        {
            return FormulasDA.Create().DeleteFormula(FormulaID);
        }

        public DataTable GetFormulasPorProceso(string Proceso_Id, string Planilla_Id)
        {
            return FormulasDA.Create().GetFormulasPorProceso(Proceso_Id,Planilla_Id);
        }

        public DataTable GetProcesoPorFormula(string Formula_Id)
        {
            return FormulasDA.Create().GetProcesoPorFormula(Formula_Id);
        }        
    }
}
