using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capas.Portal.Entidad
{
    public class Normativas
    {

        private String _Normativa_Id;

        public String Normativa_Id
        {
            get { return _Normativa_Id; }
            set { _Normativa_Id = value; }
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
        private String _Nombre_Doc;

        public String Nombre_Doc
        {
            get { return _Nombre_Doc; }
            set { _Nombre_Doc = value; }
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
        public Normativas()
        {
        }
        //para insertar
        public Normativas(String Titulo, String Descripcion, String Categoria_Auxiliar_Id, String Nombre_Doc, String User_Name, DateTime Fecha)
        {
            _Titulo = Titulo; _Descripcion = Descripcion; _Categoria_Auxiliar_Id = Categoria_Auxiliar_Id; _Nombre_Doc = Nombre_Doc; _User_Name = User_Name; _Fecha = Fecha;
        }
        //para actualizar
        public Normativas(String Normativa_Id, String Titulo, String Descripcion, String Categoria_Auxiliar_Id, String Nombre_Doc, String User_Name, DateTime Fecha)
        {
            _Normativa_Id = Normativa_Id; _Titulo = Titulo; _Descripcion = Descripcion; _Categoria_Auxiliar_Id = Categoria_Auxiliar_Id; _Nombre_Doc = Nombre_Doc; _User_Name = User_Name; _Fecha = Fecha;
        }
        //para eliminar
        public Normativas(String Normativa_Id)
        {
            _Normativa_Id = Normativa_Id;
        }

    }
}
