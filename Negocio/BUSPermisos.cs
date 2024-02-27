using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Capas.Portal.Datos;

namespace Capas.Portal.Negocio
{
    public class BUSPermisos
    {
        Datos.DAOPermisos objDatos = new DAOPermisos();
        public DataTable ListaPermisos()
        {
            return objDatos.ListaPermisos();
        }
    }
}
