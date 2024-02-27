using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capas.Portal.Entidad
{
    public class Boletines
    {
        private String _Boletin_Id;

        public String Boletin_Id
        {
            get { return _Boletin_Id; }
            set { _Boletin_Id = value; }
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
        private String _Img_Mostrar;

        public String Img_Mostrar
        {
            get { return _Img_Mostrar; }
            set { _Img_Mostrar = value; }
        }
        private String _Ruta_Doc;

        public String Ruta_Doc
        {
            get { return _Ruta_Doc; }
            set { _Ruta_Doc = value; }
        }
        private String _Tipo_Doc;

        public String Tipo_Doc
        {
            get { return _Tipo_Doc; }
            set { _Tipo_Doc = value; }
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
        public String Ruta_Foto { get; set; }
        public String sFecha { get; set; }

        //Zona de Constructores
        public Boletines()
        {
        }
        //para insertar
        public Boletines(String Titulo, String Descripcion, String Categoria_Auxiliar_Id, String Img_Mostrar, String Ruta_Doc, String Tipo_Doc, String User_Name, DateTime Fecha)
        {
            _Titulo = Titulo; _Descripcion = Descripcion; _Categoria_Auxiliar_Id = Categoria_Auxiliar_Id; _Img_Mostrar = Img_Mostrar; _Ruta_Doc = Ruta_Doc; _Tipo_Doc = Tipo_Doc; _User_Name = User_Name; _Fecha = Fecha;
        }
        //para actualizar
        public Boletines(String Boletin_Id, String Titulo, String Descripcion, String Categoria_Auxiliar_Id, String Img_Mostrar, String Ruta_Doc, String Tipo_Doc, String User_Name, DateTime Fecha)
        {
            _Boletin_Id = Boletin_Id; _Titulo = Titulo; _Descripcion = Descripcion; _Categoria_Auxiliar_Id = Categoria_Auxiliar_Id; _Img_Mostrar = Img_Mostrar; _Ruta_Doc = Ruta_Doc; _Tipo_Doc = Tipo_Doc; _User_Name = User_Name; _Fecha = Fecha;
        }
        //para eliminar
        public Boletines(String Boletin_Id)
        {
            _Boletin_Id = Boletin_Id;
        }
    }
}
