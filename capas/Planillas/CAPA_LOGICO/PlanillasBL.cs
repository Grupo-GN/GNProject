using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAPA_DATOS;
using System.Data;

namespace CAPA_LOGICO
{
    public class PlanillasBL
    {
        public DataTable GetPlanillas()
        {
            return PlanillasDA.Create().GetPlanillas();
        }

        public DataTable GetPlanillas(string _Compania_Id)
        {
            return PlanillasDA.Create().GetPlanillas(_Compania_Id);
        }
    }
}
