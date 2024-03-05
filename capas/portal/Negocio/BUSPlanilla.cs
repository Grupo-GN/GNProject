using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Capas.Portal.Datos;
using Capas.Portal.Entidad;

namespace Capas.Portal.Negocio
{
    public class BUSPlanilla
    {
        Datos.DAOPlanilla objDatos = new DAOPlanilla();
        public DataSet BUSListaPlanilla()
        {
            return objDatos.ListaPlanilla();
        }

        public DataSet BUSListaPlanillaActivos()
        {
            return objDatos.ListaPlanillaActivos();
        }

    }
}
