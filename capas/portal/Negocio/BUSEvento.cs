using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Capas.Portal.Datos;
using Capas.Portal.Entidad;
using System.Data;

namespace Capas.Portal.Negocio
{
    public class BUSEvento
    {
        Datos.DAOEvento objDatos = new DAOEvento();
        public Int32 MaxEventoId()
        {
            try
            {
                return objDatos.MaxEventoId();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Evento> GetEventosAll()
        {
            return objDatos.GetEventosAll();
        }
        public DataTable ListaEventoAll()
        {
            return objDatos.ListaEventoAll();
        }       
        public DataTable ListaEventoxEventoId(Evento objE)
        {
            return objDatos.ListaEventoxEventoId(objE);
        }
        public Int32 InsertEvento(Evento objE)
        {
            return objDatos.InsertEvento(objE);
        }
        public Int32 UpdateEvento(Evento objE)
        {
            return objDatos.UpdateEvento(objE);
        }
        public Int32 DeleteEvento(Evento objE)
        {
            return objDatos.DeleteEvento(objE);
        }

    }
}
