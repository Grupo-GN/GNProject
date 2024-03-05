using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Capas.Portal.Datos;
using Capas.Portal.Entidad;

namespace Capas.Portal.Negocio
{
    public class BUSInducAprob
    {
        Datos.DAOInducAprob objDatos = new DAOInducAprob();
        public Int32 InsertInducAprob(InducAprob objE)
        {
            return objDatos.InsertInducAprob(objE);
        }

        public Int32 UpdateInducAprob(InducAprob objE)
        {
            return objDatos.UpdateInducAprob(objE);
        }

        public Int32 DeleteInducAprob(InducAprob objE)
        {
            return objDatos.DeleteInducAprob(objE);
        }

        public DataTable ListaInducAprobAll()
        {
            return objDatos.ListaInducAprobAll();
        }

        public DataTable ListaInducAprobxArea(InducAprob objE)
        {
            return objDatos.ListaInducAprobxArea(objE);
        }

    }
}
