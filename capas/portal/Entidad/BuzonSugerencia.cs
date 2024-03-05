using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capas.Portal.Entidad
{
    public class BuzonSugerencia
    {
        private Int32 _BuzonSugerencia_Id;

        public Int32 BuzonSugerencia_Id
        {
            get { return _BuzonSugerencia_Id; }
            set { _BuzonSugerencia_Id = value; }
        }
        private String _Titulo;

        public String Titulo
        {
            get { return _Titulo; }
            set { _Titulo = value; }
        }
        private String _Sugerencia;

        public String Sugerencia
        {
            get { return _Sugerencia; }
            set { _Sugerencia = value; }
        }
        private DateTime _Fecha;

        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }
        private String _User_Name;

        public String User_Name
        {
            get { return _User_Name; }
            set { _User_Name = value; }
        }
        
        //----Zona de Constructores
        public BuzonSugerencia()
        {
        }
        public BuzonSugerencia(String Titulo, String Sugerencia, DateTime Fecha, String User_Name)
        {
            _Titulo = Titulo; _Sugerencia = Sugerencia; _Fecha = Fecha; _User_Name = User_Name;
        }
        public BuzonSugerencia(Int32 BuzonSugerencia_Id, String Titulo, String Sugerencia, DateTime Fecha, String User_Name)
        {
            _BuzonSugerencia_Id = BuzonSugerencia_Id; _Titulo = Titulo; _Sugerencia = Sugerencia; _Fecha = Fecha; _User_Name = User_Name;
        }

    }
}
