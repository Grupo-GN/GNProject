using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Capas.Portal.Datos;
using Capas.Portal.Entidad;
using System.Data;

namespace Capas.Portal.Negocio
{
    public class BUSContenidos
    {
        Datos.DAOContenidos objDatos = new DAOContenidos();
        public DataTable ListaContenidos()
        {
            return objDatos.ListaContenidos();
        }

        public DataTable ListaContenidosxId(Contenidos objE)
        {
            return objDatos.ListaContenidosxId(objE);
        }

        public Int32 UpdateContenidosxId(Contenidos objE)
        {
            return objDatos.UpdateContenidosxId(objE);
        }
    }
}
