using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capas.Portal.Entidad
{
    public class Beneficios
    {
        private String _Beneficio_Id;

        public String Beneficio_Id
        {
            get { return _Beneficio_Id; }
            set { _Beneficio_Id = value; }
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
        
        private String _Nombre_Archivo;

        public String Nombre_Archivo
        {
            get { return _Nombre_Archivo; }
            set { _Nombre_Archivo = value; }
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
        public String sFecha { get; set; }

        //Zona de Constructores
        public Beneficios()
        {
        }
        //para insertar
        public Beneficios(String Titulo, String Descripcion, String Nombre_Archivo, String User_Name, DateTime Fecha)
        {
            _Titulo = Titulo; _Descripcion = Descripcion; _Nombre_Archivo = Nombre_Archivo; _User_Name = User_Name; _Fecha = Fecha;
        }
        //para actualizar
        public Beneficios(String Beneficio_Id, String Titulo, String Descripcion, String Nombre_Archivo, String User_Name, DateTime Fecha)
        {
            _Beneficio_Id = Beneficio_Id; _Titulo = Titulo; _Descripcion = Descripcion; _Nombre_Archivo = Nombre_Archivo; _User_Name = User_Name; _Fecha = Fecha;
        }
        //para eliminar
        public Beneficios(String Beneficio_Id)
        {
            _Beneficio_Id = Beneficio_Id;
        }

    }
}
