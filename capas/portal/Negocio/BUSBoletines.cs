using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Capas.Portal.Datos;
using Capas.Portal.Entidad;

namespace Capas.Portal.Negocio
{
    public class BUSBoletines
    {
        Datos.DAOBoletines objDatos = new DAOBoletines();

        public List<Boletines> GetBoletinesAll()
        {
            return objDatos.GetBoletinesAll();
        }
        public DataTable ListaBoletinesAll()
        {
            return objDatos.ListaBoletinesAll();
        }

        public DataTable ListaBoletinesxId(Boletines objE)
        {
            return objDatos.ListaBoletinesxId(objE);
        }

        public DataTable ListaBoletinesxArea(Boletines objE)
        {
            return objDatos.ListaBoletinesxArea(objE);
        }

        public Int32 InsertBoletines(Boletines objE)
        {
            return objDatos.InsertBoletines(objE);
        }

        public Int32 UpdateBoletines(Boletines objE)
        {
            return objDatos.UpdateBoletines(objE);
        }

        public Int32 DeleteBoletines(Boletines objE)
        {
            return objDatos.DeleteBoletines(objE);
        }

    }
}
