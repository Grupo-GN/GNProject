using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capas.Portal.Entidad
{
    public class Blog
    {
        private String _Blog_Id;

        public String Blog_Id
        {
            get { return _Blog_Id; }
            set { _Blog_Id = value; }
        }
        private String _Titulo;

        public String Titulo
        {
            get { return _Titulo; }
            set { _Titulo = value; }
        }
        private String _Descripcion;

        public String Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        private String _Nombre_Foto;

        public String Nombre_Foto
        {
            get { return _Nombre_Foto; }
            set { _Nombre_Foto = value; }
        }
        private String _User_Name;

        public String User_Name
        {
            get { return _User_Name; }
            set { _User_Name = value; }
        }
        private DateTime _Fecha;

        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        //Zona de Constructores
        public Blog()
        {
        }
        //para insertar
        public Blog(String Titulo, String Descripcion, String Nombre_Foto, String User_Name, DateTime Fecha)
        {
            _Titulo = Titulo; _Descripcion = Descripcion; _Nombre_Foto = Nombre_Foto; _User_Name = User_Name; _Fecha = Fecha;
        }
        //para actualizar
        public Blog(String Blog_Id, String Titulo, String Descripcion, String Nombre_Foto, String User_Name, DateTime Fecha)
        {
            _Blog_Id = Blog_Id; _Titulo = Titulo; _Descripcion = Descripcion; _Nombre_Foto = Nombre_Foto; _User_Name = User_Name; _Fecha = Fecha;
        }
        //para eliminar
        public Blog(String Blog_Id)
        {
            _Blog_Id = Blog_Id;
        }
    }
}

