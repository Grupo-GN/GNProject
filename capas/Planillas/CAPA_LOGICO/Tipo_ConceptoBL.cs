using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAPA_DATOS;
using System.Data;

namespace CAPA_LOGICO
{
    public class Tipo_ConceptoBL
    {
        public DataTable GetTipo_Conceptos()
        {
            return Tipo_ConceptoDA.Create().GetTipo_Conceptos();
        }
    }
}
