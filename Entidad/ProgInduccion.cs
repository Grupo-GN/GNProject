using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capas.Portal.Entidad
{
    public class ProgInduccion
    {
        private String _Personal_Id;

        public String Personal_Id
        {
            get { return _Personal_Id; }
            set { _Personal_Id = value; }
        }
        
        private String _Categoria_Auxiliar_Id;

        public String Categoria_Auxiliar_Id
        {
            get { return _Categoria_Auxiliar_Id; }
            set { _Categoria_Auxiliar_Id = value; }
        }
        private Int32 _CatInduccion_Id;

        public Int32 CatInduccion_Id
        {
            get { return _CatInduccion_Id; }
            set { _CatInduccion_Id = value; }
        }

        private String _Descripcion;

        public String Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        private Boolean _Aprobado;

        public Boolean Aprobado
        {
          get { return _Aprobado; }
          set { _Aprobado = value; }
        }
        private String _User_Name;

        public String User_Name
        {
            get { return _User_Name; }
            set { _User_Name = value; }
        }

        //------- Zona de Constructores 
        public ProgInduccion()
        {
        }
        //Para Insertar y Actualizar
        public ProgInduccion(String Personal_Id, String Categoria_Auxiliar_Id, Int32 CatInduccion_Id, String Descripcion, Boolean Aprobado, String User_Name)
        {
            _Personal_Id = Personal_Id; _Categoria_Auxiliar_Id = Categoria_Auxiliar_Id; _CatInduccion_Id = CatInduccion_Id ; _Descripcion = Descripcion; _Aprobado = Aprobado; _User_Name = User_Name;
        }
        //Para Eliminar
        public ProgInduccion(String Personal_Id, String Categoria_Auxiliar_Id, Int32 CatInduccion_Id)
        {
            _Personal_Id = Personal_Id; _Categoria_Auxiliar_Id = Categoria_Auxiliar_Id; _CatInduccion_Id = CatInduccion_Id;
        }
        
        //para listar por trabajador
        public ProgInduccion(String Personal_Id)
        {
            _Personal_Id = Personal_Id;
        }

    }
}
