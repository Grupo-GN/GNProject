using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Capas.Portal.Datos;
using Capas.Portal.Entidad;

namespace Capas.Portal.Negocio
{
    public class BUSInducCategoria
    {
        Datos.DAOInducCategoria objDatos = new DAOInducCategoria();
        public Int32 InsertInducCategoria(InducCategoria objE)
        {
            return objDatos.InsertInducCategoria(objE);
        }

        public Int32 UpdateInducCategoria(InducCategoria objE)
        {
            return objDatos.UpdateInducCategoria(objE);
        }

        public Int32 DeleteInducCategoria(InducCategoria objE)
        {
            return objDatos.DeleteInducCategoria(objE);
        }

        public DataTable ListaInducCategoriaAll()
        {
            return objDatos.ListaInducCategoriaAll();
        }

        public DataTable ListaInducCategoriaxArea(InducCategoria objE)
        {
            return objDatos.ListaInducCategoriaxArea(objE);
        }

    }
}
