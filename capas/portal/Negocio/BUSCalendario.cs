using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Capas.Portal.Datos;
using Capas.Portal.Entidad;

namespace Capas.Portal.Negocio
{
    public class BUSCalendario
    {
        DAOCalendario objDatos = new DAOCalendario();
        public List<Calendario> GetCalendarioAll()
        {
            return objDatos.GetCalendarioAll();
        }
        public DataTable ListaCalendarioAll()
        {
            return objDatos.ListaCalendarioAll();
        }
        public DataTable ListaCalendarioxId(Calendario objE)
        {
            return objDatos.ListaCalendarioxId(objE);
        }

        public Int32 InsertCalendario(Calendario objE)
        {
            return objDatos.InsertCalendario(objE);
        }

        public Int32 UpdateCalendario(Calendario objE)
        {
            return objDatos.UpdateCalendario(objE);
        }

        public Int32 DeleteCalendario(Calendario objE)
        {
            return objDatos.DeleteCalendario(objE);
        }

        public DataTable ListaCalendarioxArea(Calendario objE)
        {
            return objDatos.ListaCalendarioxArea(objE);
        }

    }
}
