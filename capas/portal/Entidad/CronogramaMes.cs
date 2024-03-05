using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capas.Portal.Entidad
{
    public class CronogramaMes
    {
        private String _CronogramaMes_Id;

        public String CronogramaMes_Id
        {
            get { return _CronogramaMes_Id; }
            set { _CronogramaMes_Id = value; }
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
        private String _Ubicacion;

        public String Ubicacion
        {
            get { return _Ubicacion; }
            set { _Ubicacion = value; }
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
        private DateTime _Hora_Inicio;

        public DateTime Hora_Inicio
        {
            get { return _Hora_Inicio; }
            set { _Hora_Inicio = value; }
        }
        private DateTime _Hora_Final;

        public DateTime Hora_Final
        {
            get { return _Hora_Final; }
            set { _Hora_Final = value; }
        }
        private String _Nombre_Foto;

        public String Nombre_Foto
        {
            get { return _Nombre_Foto; }
            set { _Nombre_Foto = value; }
        }
        private String _User_Name;

        public String User_Name
        {
            get { return _User_Name; }
            set { _User_Name = value; }
        }

        public String Area { get; set; }
        public String sFecha { get; set; }
        public String sHora_Inicio { get; set; }
        public String sHora_Final { get; set; }

        //Zona de Constructores
        public CronogramaMes()
        {
        }
        //para insertar
        public CronogramaMes(String Titulo, String Descripcion, String Ubicacion, String Categoria_Auxiliar_Id, DateTime Fecha, DateTime Hora_Inicio, DateTime Hora_Final, String Nombre_Foto, String User_Name)
        {
            _Titulo = Titulo; _Descripcion = Descripcion; _Ubicacion = Ubicacion; _Categoria_Auxiliar_Id = Categoria_Auxiliar_Id; _Fecha = Fecha; _Hora_Inicio = Hora_Inicio; _Hora_Final = Hora_Final; _Nombre_Foto = Nombre_Foto ; _User_Name = User_Name;
        }
        //para actualizar
        public CronogramaMes(String CronogramaMes_Id, String Titulo, String Descripcion, String Ubicacion, String Categoria_Auxiliar_Id,DateTime Fecha, DateTime Hora_Inicio, DateTime Hora_Final, String Nombre_Foto, String User_Name)
        {
            _CronogramaMes_Id = CronogramaMes_Id; _Titulo = Titulo; _Descripcion = Descripcion; _Ubicacion = Ubicacion; _Categoria_Auxiliar_Id = Categoria_Auxiliar_Id; _Fecha = Fecha; _Hora_Inicio = Hora_Inicio; _Hora_Final = Hora_Final; _Nombre_Foto = Nombre_Foto; _User_Name = User_Name;
        }
        //para eliminar
        public CronogramaMes(String CronogramaMes_Id)
        {
            _CronogramaMes_Id = CronogramaMes_Id;
        }
    }
}
