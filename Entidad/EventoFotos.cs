using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capas.Portal.Entidad
{
    public class EventoFotos
    {
        private Int32 _EventoFotos_Id;

        public Int32 EventoFotos_Id
        {
            get { return _EventoFotos_Id; }
            set { _EventoFotos_Id = value; }
        }
        private String _Nombre_Foto;

        public String Nombre_Foto
        {
            get { return _Nombre_Foto; }
            set { _Nombre_Foto = value; }
        }
        private Int32 _Evento_Id;

        public Int32 Evento_Id
        {
            get { return _Evento_Id; }
            set { _Evento_Id = value; }
        }

        public String sFecha { get; set; }
        public String Titulo { get; set; }
        public String Descripcion { get; set; }

        //Zona de Constructores
        public EventoFotos()
        {
        }
        //Para Insertar
        public EventoFotos(String Nombre_Foto, Int32 Evento_Id)
        {
            _Nombre_Foto = Nombre_Foto; _Evento_Id = Evento_Id;
        }


    }
}
