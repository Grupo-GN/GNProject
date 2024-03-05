using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Capas.Portal.Datos;

namespace Capas.Portal.Negocio
{
    public class BUSLocalidad
    {
        Datos.DAOLocalidad objDatos = new DAOLocalidad();
        public DataTable ListaLocalidad()
        {
            return objDatos.ListaLocalidad();
        }
    }
}
