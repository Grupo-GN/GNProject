using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAPA_ENTIDAD;
using CAPA_DATOS;
using System.Data;

namespace CAPA_LOGICO
{
    public class PeriodoBL
    {
        public DataTable GetPeriodoPorPlanilla(string Planilla_Id)
        {
            return PeriodoDA.Create().GetPeriodoPorPlanilla(Planilla_Id);
        }
        public DataTable GetPeriodo(string Compania_Id, string Mes_Id, string Planilla_Id)
        {
            return PeriodoDA.Create().GetPeriodo(Compania_Id, Mes_Id, Planilla_Id);
        }
    }
}
