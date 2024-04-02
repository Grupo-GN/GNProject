using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAPA_DATOS;
using System.Data;

namespace CAPA_LOGICO
{
    public class ProcesosBL
    {
        public DataTable GetProcesos()
        {
            return ProcesosDA.Create().GetProcesos();
        }
    }
}
