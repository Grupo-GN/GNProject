using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capas.Portal.Entidad
{
    public class CommentBlog
    {
        private String _CommentBlog_Id;

        public String CommentBlog_Id
        {
            get { return _CommentBlog_Id; }
            set { _CommentBlog_Id = value; }
        }
        private String _Blog_Id;

        public String Blog_Id
        {
            get { return _Blog_Id; }
            set { _Blog_Id = value; }
        }
        private String _User_Name;

        public String User_Name
        {
            get { return _User_Name; }
            set { _User_Name = value; }
        }
        private String _Descripcion;

        public String Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        private DateTime _Fecha;

        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        //Zona de Constructores
        public CommentBlog()
        {
        }
        //para insertar
        public CommentBlog(String Blog_Id, String User_Name, String Descripcion, DateTime Fecha)
        {
            _Blog_Id = Blog_Id; _User_Name = User_Name; _Descripcion = Descripcion; _Fecha = Fecha;
        }
        //para actualizar
        public CommentBlog(String CommentBlog_Id, String Blog_Id, String User_Name, String Descripcion, DateTime Fecha)
        {
            _CommentBlog_Id = CommentBlog_Id; _Blog_Id = Blog_Id; _User_Name = User_Name; _Descripcion = Descripcion; _Fecha = Fecha;
        }
        //para eliminar
        public CommentBlog(String CommentBlog_Id)
        {
            _CommentBlog_Id = CommentBlog_Id;
        }


    }
}

