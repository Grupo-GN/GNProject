using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capas.Portal.Entidad
{
    public class EncuestaRespuestas
    {
        private String _Encuesta_Id;

        public String Encuesta_Id
        {
            get { return _Encuesta_Id; }
            set { _Encuesta_Id = value; }
        }
        private String _User_Name;

        public String User_Name
        {
            get { return _User_Name; }
            set { _User_Name = value; }
        }
        private String _Opcion_Id;

        public String Opcion_Id
        {
            get { return _Opcion_Id; }
            set { _Opcion_Id = value; }
        }


        //Zona de Constructores
        public EncuestaRespuestas()
        {
        }
        //Para Insertar y Actualizar
        public EncuestaRespuestas(String Encuesta_Id, String User_Name, String Opcion_Id)
        {
            _Encuesta_Id = Encuesta_Id; _User_Name = User_Name; _Opcion_Id = Opcion_Id;
        }
        //Para Eliminar
        public EncuestaRespuestas(String Encuesta_Id, String User_Name)
        {
            _Encuesta_Id = Encuesta_Id; _User_Name = User_Name;
        }
        //para listar por la Encuesta_Id
        public EncuestaRespuestas(String Encuesta_Id)
        {
            _Encuesta_Id = Encuesta_Id;
        }


    }
}
