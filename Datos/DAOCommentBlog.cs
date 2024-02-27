using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Microsoft.ApplicationBlocks.Data;
using Capas.Portal.Entidad;

namespace Capas.Portal.Datos
{
    public class DAOCommentBlog:ClsConexion
    {

        public String CommentporBlogId(String Blog_Id)
        {
            String Comentarios = "";
            DataTable dt = new DataTable();
            dt = SqlHelper.ExecuteDataTable(Conexion(), CommandType.Text, "select case COUNT(*) when 0 then 'Sin Comentarios' when '1' then '1 Comentario' else cast(COUNT(*) as varchar(6))+ ' Comentarios' end as [Comentarios] from I_CommentBlog where Blog_Id='" + Blog_Id + "'");
            Comentarios = dt.Rows[0]["Comentarios"].ToString();
            dt.Dispose();
            return Comentarios;
        }

        public DataTable ListaCommentBlogAll()
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListCommentBlogAll");
        }
        public DataTable ListaCommentBlogxCommentId(CommentBlog objE)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListCommentBlogxCommentId", objE.CommentBlog_Id);
        }

        public DataTable ListaCommentBlogxBlogId(CommentBlog objE)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListCommentBlogxBlogId", objE.Blog_Id);
        }

        public Int32 InsertCommentBlog(CommentBlog objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IInsertCommentBlog", objE.Blog_Id, objE.User_Name, objE.Descripcion, objE.Fecha);
        }

        public Int32 UpdateCommentBlog(CommentBlog objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IUpdateCommentBlog", objE.CommentBlog_Id, objE.Blog_Id, objE.User_Name, objE.Descripcion, objE.Fecha);
        }

        public Int32 DeleteCommentBlog(CommentBlog objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IDeleteCommentBlog", objE.CommentBlog_Id);
        }

        public Int32 DeleteCommentBlogxBlog_Id(String Blog_Id)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), CommandType.Text, "delete from I_CommentBlog where Blog_Id='" + Blog_Id + "'");
        }

        

    }
}
