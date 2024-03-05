using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Capas.Portal.Datos;
using Capas.Portal.Entidad;

namespace Capas.Portal.Negocio
{
    public class BUSNormativas
    {
        Datos.DAONormativas objDatos = new DAONormativas();

        public List<Normativas> GetNormativasAll()
        {
            return objDatos.GetNormativasAll();
        }
        public DataTable ListaNormativaAll()
        {
            return objDatos.ListaNormativaAll();
        }
        public DataTable ListaNormativaxId(Normativas objE)
        {
            return objDatos.ListaNormativaxId(objE);
        }

        public DataTable ListaNormativaxArea(Normativas objE)
        {
            return objDatos.ListaNormativaxArea(objE);
        }

        public Int32 InsertNormativa(Normativas objE)
        {
            return objDatos.InsertNormativa(objE);
        }

        public Int32 UpdateNormativa(Normativas objE)
        {
            return objDatos.UpdateNormativa(objE);
        }

        public Int32 DeleteNormativa(Normativas objE)
        {
            return objDatos.DeleteNormativa(objE);
        }
    }
}

