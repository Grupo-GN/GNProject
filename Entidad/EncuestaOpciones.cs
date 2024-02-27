using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capas.Portal.Entidad
{
    public class EncuestaOpciones
    {
        private String _Opcion_Id;

        public String Opcion_Id
        {
            get { return _Opcion_Id; }
            set { _Opcion_Id = value; }
        }
        private String _Nombre_Opcion;

        public String Nombre_Opcion
        {
            get { return _Nombre_Opcion; }
            set { _Nombre_Opcion = value; }
        }
        private String _Encuesta_Id;

        public String Encuesta_Id
        {
            get { return _Encuesta_Id; }
            set { _Encuesta_Id = value; }
        }

        
        //Zona de Constructores
        public EncuestaOpciones()
        {
        }
        //Para Insertar
        public EncuestaOpciones(String Nombre_Opcion, String Encuesta_Id)
        {
            _Nombre_Opcion = Nombre_Opcion; _Encuesta_Id = Encuesta_Id;
        }
        
        //Para Eliminar
        public EncuestaOpciones(String Opcion_Id)
        {
            _Opcion_Id = Opcion_Id;
        }


    }
}
