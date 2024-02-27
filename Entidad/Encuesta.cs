using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capas.Portal.Entidad
{
    public class Encuesta
    {
        private String _Encuesta_Id;

        public String Encuesta_Id
        {
            get { return _Encuesta_Id; }
            set { _Encuesta_Id = value; }
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
        private Boolean _SoloUnaOpcion;

        public Boolean SoloUnaOpcion
        {
            get { return _SoloUnaOpcion; }
            set { _SoloUnaOpcion = value; }
        }
        private DateTime _Fecha_Inicio;

        public DateTime Fecha_Inicio
        {
            get { return _Fecha_Inicio; }
            set { _Fecha_Inicio = value; }
        }
        private DateTime _Fecha_Cierre;

        public DateTime Fecha_Cierre
        {
            get { return _Fecha_Cierre; }
            set { _Fecha_Cierre = value; }
        }
        private String _User_Name;

        public String User_Name
        {
            get { return _User_Name; }
            set { _User_Name = value; }
        }
        public String sFecha_Inicio { get; set; }
        public String sFecha_Cierre { get; set; }
        public String no_estado { get; set; }

        //Zona de Constructores
        public Encuesta()
        {
        }
        //Para Insertar
        public Encuesta(String Titulo, String Descripcion, Boolean SoloUnaOpcion, DateTime Fecha_Inicio, DateTime Fecha_Cierre, String User_Name)
        {
            _Titulo = Titulo; _Descripcion = Descripcion; _SoloUnaOpcion = SoloUnaOpcion; _Fecha_Inicio = Fecha_Inicio; _Fecha_Cierre = Fecha_Cierre; _User_Name = User_Name;
        }
        //Para Actualizar
        public Encuesta(String Encuesta_Id, String Titulo, String Descripcion, Boolean SoloUnaOpcion, DateTime Fecha_Inicio, DateTime Fecha_Cierre, String User_Name)
        {
            _Encuesta_Id = Encuesta_Id; _Titulo = Titulo; _Descripcion = Descripcion; _SoloUnaOpcion = SoloUnaOpcion; _Fecha_Inicio = Fecha_Inicio; _Fecha_Cierre = Fecha_Cierre; _User_Name = User_Name;
        }
        //Para Eliminar
        public Encuesta(String Encuesta_Id)
        {
            _Encuesta_Id = Encuesta_Id;
        }


    }
}
