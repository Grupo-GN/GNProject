using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Capas.Portal.Datos;
using Capas.Portal.Entidad;

namespace Capas.Portal.Negocio
{
    public class BUSEncuestaOpciones
    {
        Datos.DAOEncuestaOpciones objDatos = new DAOEncuestaOpciones();
        public DataTable ListaEncuestaOpcionesAll()
        {
            return objDatos.ListaEncuestaOpcionesAll();
        }

        public DataTable ListaEncuestaOpcionesxEncuestaId(EncuestaOpciones objE)
        {
            return objDatos.ListaEncuestaOpcionesxEncuestaId(objE);
        }

        public Int32 InsertEncuestaOpciones(EncuestaOpciones objE)
        {
            return objDatos.InsertEncuestaOpciones(objE);
        }

        public Int32 UpdateEncuestaOpciones(EncuestaOpciones objE)
        {
            return objDatos.UpdateEncuestaOpciones(objE);
        }

        public Int32 DeleteEncuestaOpciones(EncuestaOpciones objE)
        {
            return objDatos.DeleteEncuestaOpciones(objE);
        }

    }
}
