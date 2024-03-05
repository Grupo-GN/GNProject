using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Capas.Portal.Entidad
{
    public class Contenidos
    {
        private Int32 _Contenido_Id;

        public Int32 Contenido_Id
        {
            get { return _Contenido_Id; }
            set { _Contenido_Id = value; }
        }
        private String _Categoria;

        public String Categoria
        {
            get { return _Categoria; }
            set { _Categoria = value; }
        }
        private String _Descripcion;

        public String Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        private String _Ruta_Img;

        public String Ruta_Img
        {
            get { return _Ruta_Img; }
            set { _Ruta_Img = value; }
        }

        //------- Zona de Constructores 
        public Contenidos()
        {
        }

        public Contenidos(Int32 Contenido_Id, String Categoria, String Descripcion, String Ruta_Img)
        {
            _Contenido_Id = Contenido_Id; _Categoria = Categoria; _Descripcion = Descripcion; _Ruta_Img = Ruta_Img;
        }

    }
}
