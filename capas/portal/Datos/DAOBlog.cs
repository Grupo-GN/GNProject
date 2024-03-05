using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Microsoft.ApplicationBlocks.Data;
using Capas.Portal.Entidad;

using System.Transactions;

namespace Capas.Portal.Datos
{
    public class DAOBlog:ClsConexion
    {
        public DataTable ListaBlogFotosAll()
        {
            return SqlHelper.ExecuteDataTable(Conexion(), CommandType.Text, "select Blog_Id,Titulo,Nombre_Foto,fecha from I_Blog where ltrim(rtrim(Nombre_Foto))!='' order by fecha desc");
        }
        public DataTable ListaBlogAll()
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListBlogAll");
        }
        public DataTable ListaBlogxId(Blog objE)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListBlogxId", objE.Blog_Id);
        }

        public Int32 InsertBlog(Blog objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IInsertBlog", objE.Titulo, objE.Descripcion, objE.Nombre_Foto, objE.User_Name, objE.Fecha);
        }

        public Int32 UpdateBlog(Blog objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IUpdateBlog", objE.Blog_Id, objE.Titulo, objE.Descripcion, objE.Nombre_Foto, objE.User_Name, objE.Fecha);
        }

        public Int32 DeleteBlog(Blog objE)
        {
            TransactionScope trans = new TransactionScope();
            try
            {
                Datos.DAOCommentBlog objDCB = new DAOCommentBlog();
                objDCB.DeleteCommentBlogxBlog_Id(objE.Blog_Id);
                
                Int32 rpta;
                rpta = SqlHelper.ExecuteNonQuery(Conexion(), "usp_IDeleteBlog", objE.Blog_Id);
                trans.Complete();
                trans.Dispose();
                return rpta;
            }
            catch (Exception ex) 
            {
                trans.Dispose();
                //throw new Exception(ex.Message); 
                throw ex;
            }
            
        }

        
    }
}

