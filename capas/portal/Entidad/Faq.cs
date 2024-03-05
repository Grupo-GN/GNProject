using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capas.Portal.Entidad
{
    public class Faq
    {
        private String _Faq_Id;

        public String Faq_Id
        {
            get { return _Faq_Id; }
            set { _Faq_Id = value; }
        }
        private String _Pregunta;

        public String Pregunta
        {
            get { return _Pregunta; }
            set { _Pregunta = value; }
        }
        private String _Respuesta;

        public String Respuesta
        {
            get { return _Respuesta; }
            set { _Respuesta = value; }
        }
        private String _Categoria_Auxiliar_Id;

        public String Categoria_Auxiliar_Id
        {
            get { return _Categoria_Auxiliar_Id; }
            set { _Categoria_Auxiliar_Id = value; }
        }

        private DateTime _Fecha;

        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }
        private Int32 _SortOrder;

        public Int32 SortOrder
        {
            get { return _SortOrder; }
            set { _SortOrder = value; }
        }

        public String Area{ get; set; }
        public String sFecha { get; set; }


        //------- Zona de Constructores 
        public Faq()
        {
        }
        //Para Insertar
        public Faq(String Pregunta, String Respuesta, String Categoria_Auxiliar_Id, DateTime Fecha)
        {
            _Pregunta = Pregunta; _Respuesta = Respuesta; _Categoria_Auxiliar_Id = Categoria_Auxiliar_Id; _Fecha = Fecha;
        }
        //Para Actualizar
        public Faq(String Faq_Id, String Pregunta, String Respuesta, String Categoria_Auxiliar_Id, DateTime Fecha)
        {
            _Faq_Id = Faq_Id; _Pregunta = Pregunta; _Respuesta = Respuesta; _Categoria_Auxiliar_Id = Categoria_Auxiliar_Id; _Fecha = Fecha;
        }

        public Faq(String Faq_Id)
        {
            _Faq_Id = Faq_Id;
        }

    }
}
