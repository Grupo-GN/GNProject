using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capas.Portal.Entidad
{
    public class Anuncios
    {
        private String _Anuncio_Id;

        public String Anuncio_Id
        {
            get { return _Anuncio_Id; }
            set { _Anuncio_Id = value; }
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
        private String _Categoria_Auxiliar_Id;

        public String Categoria_Auxiliar_Id
        {
            get { return _Categoria_Auxiliar_Id; }
            set { _Categoria_Auxiliar_Id = value; }
        }
        private String _Ruta_Foto;

        public String Ruta_Foto
        {
            get { return _Ruta_Foto; }
            set { _Ruta_Foto = value; }
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

        public String Area { get; set; }
        public String sFecha { get; set; }

        //Zona de Constructores
        public Anuncios()
        {
        }
        //para insertar
        public Anuncios(String Titulo, String Descripcion, String Categoria_Auxiliar_Id, String Ruta_Foto, String User_Name, DateTime Fecha)
        {
            _Titulo = Titulo; _Descripcion = Descripcion; _Categoria_Auxiliar_Id = Categoria_Auxiliar_Id; _Ruta_Foto = Ruta_Foto; _User_Name = User_Name; _Fecha = Fecha;
        }
        //para actualizar
        public Anuncios(String Anuncio_Id, String Titulo, String Descripcion, String Categoria_Auxiliar_Id, String Ruta_Foto, String User_Name, DateTime Fecha)
        {
            _Anuncio_Id = Anuncio_Id; _Titulo = Titulo; _Descripcion = Descripcion; _Categoria_Auxiliar_Id = Categoria_Auxiliar_Id; _Ruta_Foto = Ruta_Foto; _User_Name = User_Name; _Fecha = Fecha;
        }
        //para eliminar
        public Anuncios(String Anuncio_Id)
        {
            _Anuncio_Id = Anuncio_Id;
        }
    }
}
