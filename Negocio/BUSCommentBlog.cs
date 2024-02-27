using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Capas.Portal.Datos;
using Capas.Portal.Entidad;

namespace Capas.Portal.Negocio
{
    public class BUSCommentBlog
    {
        DAOCommentBlog objDatos = new DAOCommentBlog();

        public String CommentporBlogId(String Blog_Id)
        {
            return objDatos.CommentporBlogId(Blog_Id);
        }

        public DataTable ListaCommentBlogAll()
        {
            return objDatos.ListaCommentBlogAll();
        }
        public DataTable ListaCommentBlogxCommentId(CommentBlog objE)
        {
            return objDatos.ListaCommentBlogxCommentId(objE);
        }

        public DataTable ListaCommentBlogxBlogId(CommentBlog objE)
        {
            return objDatos.ListaCommentBlogxBlogId(objE);
        }

        public Int32 InsertCommentBlog(CommentBlog objE)
        {
            return objDatos.InsertCommentBlog(objE);
        }

        public Int32 UpdateCommentBlog(CommentBlog objE)
        {
            return objDatos.UpdateCommentBlog(objE);
        }

        public Int32 DeleteCommentBlog(CommentBlog objE)
        {
            return objDatos.DeleteCommentBlog(objE);
        }



    }
}
