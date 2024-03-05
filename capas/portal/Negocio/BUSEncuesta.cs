using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Capas.Portal.Datos;
using Capas.Portal.Entidad;

namespace Capas.Portal.Negocio
{
    public class BUSEncuesta
    {
        Datos.DAOEncuesta objDatos = new DAOEncuesta();
        public DataTable ListaEncuestaActivas()
        {
            return objDatos.ListaEncuestaActivas();
        }

        public DataTable ListaEncuestaCerradas()
        {
            return objDatos.ListaEncuestaCerradas();
        }

        public List<Encuesta> GetEncuestasVigentesyCerradas()
        {
            return objDatos.GetEncuestasVigentesyCerradas();
        }
        public List<Encuesta> GetEncuestasAll()
        {
            return objDatos.GetEncuestasAll();
        }
        public DataTable ListaEncuestaAll()
        {
            return objDatos.ListaEncuestaAll();
        }

        public DataTable ListaEncuestaxEncuestaId(Encuesta objE)
        {
            return objDatos.ListaEncuestaxEncuestaId(objE);
        }

        public Int32 InsertEncuesta(Encuesta objE)
        {
            return objDatos.InsertEncuesta(objE);
        }

        public Int32 InsertEncuesta(Encuesta objE, DataTable dtOpciones)
        {
            return objDatos.InsertEncuesta(objE, dtOpciones);
        }

        public Int32 UpdateEncuesta(Encuesta objE)
        {
            return objDatos.UpdateEncuesta(objE);
        }

        public Int32 DeleteEncuesta(Encuesta objE)
        {
            return objDatos.DeleteEncuesta(objE);
        }

    }
}
