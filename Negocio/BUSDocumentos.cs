using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Capas.Portal.Datos;
using Capas.Portal.Entidad;

namespace Capas.Portal.Negocio
{
    
    public class BUSDocumentos
    {
        Datos.DAODocumentos objDatos = new DAODocumentos();

        public List<Documentos> GetDocumentosAll()
        {
            return objDatos.GetDocumentosAll();
        }
        public DataTable ListaDocumentoAll()
        {
            return objDatos.ListaDocumentoAll();
        }
        public DataTable ListaDocumentoxId(Documentos objE)
        {
            return objDatos.ListaDocumentoxId(objE);
        }

        public DataTable ListaDocumentoxArea(Documentos objE)
        {
            return objDatos.ListaDocumentoxArea(objE);
        }

        public Int32 InsertDocumento(Documentos objE)
        {
            return objDatos.InsertDocumento(objE);
        }

        public Int32 UpdateDocumento(Documentos objE)
        {
            return objDatos.UpdateDocumento(objE);
        }

        public Int32 DeleteDocumento(Documentos objE)
        {
            return objDatos.DeleteDocumento(objE);
        }
    }
}
