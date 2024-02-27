using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.ApplicationBlocks.Data;
using System.Data;

namespace Capas.Portal.Datos
{
    public class DAOPlanilla : ClsConexion
    {
        public DataSet ListaPlanilla()
        {
            return SqlHelper.ExecuteDataset(Conexion(), "usp_ListaPlanilla", "01");
        }
        public DataSet ListaPlanillaActivos()
        {
            return SqlHelper.ExecuteDataset(Conexion(), "usp_ListaPlanillaActivos", "01");
        }
    }
}
