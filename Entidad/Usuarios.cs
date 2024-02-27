using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace Capas.Portal.Entidad
{
    public class Usuarios
    {
        private String _User_Id;

        public String User_Id
        {
          get { return _User_Id; }
          set { _User_Id = value; }
        }
        private String _Planilla_Id;

        public String Planilla_Id
        {
          get { return _Planilla_Id; }
          set { _Planilla_Id = value; }
        }
        private String _Personal_Id;

        public String Personal_Id
        {
          get { return _Personal_Id; }
          set { _Personal_Id = value; }
        }
        private String _User_Name;

        public String User_Name
        {
          get { return _User_Name; }
          set { _User_Name = value; }
        }
        private String _Password;

        public String Password
        {
          get { return _Password; }
          set { _Password = value; }
        }
        private String _Ruta_Foto;

        public String Ruta_Foto
        {
          get { return _Ruta_Foto; }
          set { _Ruta_Foto = value; }
        }
        private Int32 _Permiso_Id;

        public Int32 Permiso_Id
        {
          get { return _Permiso_Id; }
          set { _Permiso_Id = value; }
        }
        private String _Email;

        public String Email
        {
          get { return _Email; }
          set { _Email = value; }
        }
        private String _Categoria_Auxiliar_Id;

        public String Categoria_Auxiliar_Id
        {
          get { return _Categoria_Auxiliar_Id; }
          set { _Categoria_Auxiliar_Id = value; }
        }
        private String _Categoria_Auxiliar2_Id;

        public String Categoria_Auxiliar2_Id
        {
          get { return _Categoria_Auxiliar2_Id; }
          set { _Categoria_Auxiliar2_Id = value; }
        }
        private String _Estado_Id;

        public String Estado_Id
        {
          get { return _Estado_Id; }
          set { _Estado_Id = value; }
        }

        public String Nombre_Completo { get; set; }
        public String Permiso { get; set; }
        public String Periodo_Id { get; set; }
        public String Tipo_Trabajador { get; set; }
        public String Localidad { get; set; }
        public String Area { get; set; }
        public String Seccion { get; set; }
        public Int32 nu_ingresos { get; set; }
        
        //------- Zona de Constructores 
        //para insertar
        public Usuarios(String Planilla_Id, String Personal_Id, String User_Name, String Password, String Ruta_Foto,
            Int32 Permiso_Id, String Email, String Categoria_Auxiliar_Id, String Categoria_Auxiliar2_Id, String Estado_Id)
        {
            _Planilla_Id = Planilla_Id; _Personal_Id = Personal_Id; _User_Name = User_Name;
            _Password = Password; _Ruta_Foto = Ruta_Foto; _Permiso_Id = Permiso_Id; _Email = Email;
            _Categoria_Auxiliar_Id = Categoria_Auxiliar_Id; _Categoria_Auxiliar2_Id = Categoria_Auxiliar2_Id; _Estado_Id = Estado_Id;
        }
        //para actualizar
        public Usuarios(String User_Id, String Password, String Ruta_Foto,
            Int32 Permiso_Id, String Email, String Estado_Id)
        {
            _User_Id = User_Id; _Password = Password; _Ruta_Foto = Ruta_Foto; _Permiso_Id = Permiso_Id; _Email = Email;
            _Estado_Id = Estado_Id;
        }

        public Usuarios(String User_Id)
        {
            _User_Id = User_Id;
        }

        public Usuarios()
        {
            
        }

        public Usuarios(String User_Id, String Estado_Id)
        {
            _User_Id = User_Id; _Estado_Id = Estado_Id;
        }


    }
}
