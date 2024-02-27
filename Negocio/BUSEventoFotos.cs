using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Capas.Portal.Datos;
using Capas.Portal.Entidad;
using System.Data;

namespace Capas.Portal.Negocio
{
    public class BUSEventoFotos
    {
        Datos.DAOEventoFotos objDatos = new DAOEventoFotos();
        public List<EventoFotos> GetEventoFotosxEventoID(Int32 Evento_Id)
        {
            return objDatos.GetEventoFotosxEventoID(Evento_Id);
        }
        public DataTable ListaEventoFotosxEventoId(EventoFotos objE)
        {
            return objDatos.ListaEventoFotosxEventoId(objE);
        }
        public Int32 InsertEventoFotos(EventoFotos objE)
        {
            return objDatos.InsertEventoFotos(objE);
        }
        public Int32 DeleteEventoFotos(EventoFotos objE)
        {
            return objDatos.DeleteEventoFotos(objE);
        }
    }
}
