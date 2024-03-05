using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Capas.Portal.Datos;
using Capas.Portal.Entidad;


namespace Capas.Portal.Negocio
{
    public class BUSBlog
    {
        DAOBlog objDatos = new DAOBlog();

        public DataTable ListaBlogFotosAll()
        {
            return objDatos.ListaBlogFotosAll();
        }

        public DataTable ListaBlogAll()
        {
            return objDatos.ListaBlogAll();
        }
        public DataTable ListaBlogxId(Blog objE)
        {
            return objDatos.ListaBlogxId(objE);
        }

        public Int32 InsertBlog(Blog objE)
        {
            return objDatos.InsertBlog(objE);
        }

        public Int32 UpdateBlog(Blog objE)
        {
            return objDatos.UpdateBlog(objE);
        }

        public Int32 DeleteBlog(Blog objE)
        {
            return objDatos.DeleteBlog(objE);
        }


    }
}

