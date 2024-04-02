using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CAPA_DATOS;

namespace CAPA_LOGICO
{
    public class Log_D_Fijos_2
    {
        private static Log_D_Fijos_2 instance = null;
        public static Log_D_Fijos_2 getinstance() {
            return instance == null ? instance = new Log_D_Fijos_2() : instance;        
        }
        public DataTable ActualizarDatoPorPersonaV2(string PeriodoId, string PersonalId, string ConceptoId, decimal Valor)
        {
            return Dao_D_Fijos_2.getinstance().ActualizarDatoPorPersonaV2(PeriodoId, PersonalId, ConceptoId, Valor);
        }
    }
}
