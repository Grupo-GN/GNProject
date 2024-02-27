using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capas.Portal.Entidad
{
    public class Evento
    {
        private Int32 _Evento_Id;

        public Int32 Evento_Id
        {
            get { return _Evento_Id; }
            set { _Evento_Id = value; }
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

        private String _NomFotoEvento;

        public String NomFotoEvento
        {
            get { return _NomFotoEvento; }
            set { _NomFotoEvento = value; }
        }
        public String sFecha { get; set; }

        //Zona de Constructores
        public Evento()
        {
        }
        //Para Insertar
        public Evento(String Titulo, String Descripcion, String User_Name, DateTime Fecha, String NomFotoEvento)
        {
            _Titulo = Titulo; _Descripcion = Descripcion; _User_Name = User_Name; _Fecha = Fecha; _NomFotoEvento = NomFotoEvento;
        }
        //Para Actualizar
        public Evento(Int32 Evento_Id,String Titulo, String Descripcion, String User_Name, DateTime Fecha, String NomFotoEvento)
        {
            _Evento_Id = Evento_Id; _Titulo = Titulo; _Descripcion = Descripcion; _User_Name = User_Name; _Fecha = Fecha; _NomFotoEvento = NomFotoEvento;
        }
        //Para Eliminar
        public Evento(Int32 Evento_Id)
        {
            _Evento_Id = Evento_Id;
        }


    }
}
