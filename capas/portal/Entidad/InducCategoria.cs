using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capas.Portal.Entidad
{
    public class InducCategoria
    {
        private Int32 _CatInduccion_Id;

        public Int32 CatInduccion_Id
        {
            get { return _CatInduccion_Id; }
            set { _CatInduccion_Id = value; }
        }
        private String _NomCategoria;

        public String NomCategoria
        {
            get { return _NomCategoria; }
            set { _NomCategoria = value; }
        }
        
        private String _Categoria_Auxiliar_Id;

        public String Categoria_Auxiliar_Id
        {
            get { return _Categoria_Auxiliar_Id; }
            set { _Categoria_Auxiliar_Id = value; }
        }
        

        //------- Zona de Constructores 
        public InducCategoria()
        {
        }
        //Para Insertar
        public InducCategoria(String NomCategoria, String Categoria_Auxiliar_Id)
        {
            _NomCategoria = NomCategoria;  _Categoria_Auxiliar_Id = Categoria_Auxiliar_Id; ;
        }
        //Para Actualizar
        public InducCategoria(Int32 CatInduccion_Id, String NomCategoria)
        {
            _CatInduccion_Id = CatInduccion_Id; _NomCategoria = NomCategoria;
        }
        //Para Eliminar
        public InducCategoria(Int32 CatInduccion_Id)
        {
            _CatInduccion_Id = CatInduccion_Id;
        }
    }
}
