using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAPA_DATOS;
using System.Data;

namespace CAPA_LOGICO
{
    public class ConceptosBL
    {
        public DataTable GetConceptosFormulas()
        {
            return ConceptosDA.Create().GetConceptosFormulas();
        }

        public DataTable GetConceptosPorTipo(string Tipo_Dato)
        {
            return ConceptosDA.Create().GetConceptosPorTipo(Tipo_Dato);
        }

        public DataTable GetConceptos()
        {
            return ConceptosDA.Create().GetConceptos();
        }

        public DataTable GetConceptosPorPersona(string Personal_Id, string Periodo_Id, string Proceso_Id)
        {
            return ConceptosDA.Create().GetConceptosPorPersona(Personal_Id, Periodo_Id, Proceso_Id);
        }

        public DataTable GetConceptosPorPersona(string Personal_Id, string Periodo_Id, string Proceso_Id, string Proceso_Fuente_Id)
        {
            return ConceptosDA.Create().GetConceptosPorPersona(Personal_Id, Periodo_Id, Proceso_Id, Proceso_Fuente_Id);
        }

        public DataTable GetConcepto(string Concepto_Id)
        {
            return ConceptosDA.Create().GetConcepto(Concepto_Id);
        }

        public DataTable GetConceptoDirecto(string Personal_Id, string Periodo_Id, string Concepto_Id)
        {
            return ConceptosDA.Create().GetConceptoDirecto(Personal_Id, Periodo_Id, Concepto_Id);
        }
    }
}
