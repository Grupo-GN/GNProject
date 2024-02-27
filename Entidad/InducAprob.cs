using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capas.Portal.Entidad
{
    public class InducAprob
    {
        private String _Categoria_Auxiliar_Id;

        public String Categoria_Auxiliar_Id
        {
            get { return _Categoria_Auxiliar_Id; }
            set { _Categoria_Auxiliar_Id = value; }
        }
        private String _Personal_Id;

        public String Personal_Id
        {
            get { return _Personal_Id; }
            set { _Personal_Id = value; }
        }

        //------- Zona de Constructores 
        public InducAprob()
        {
        }
        //Para Insertar y Actualizar y Eliminar
        public InducAprob(String Categoria_Auxiliar_Id, String Personal_Id)
        {
            _Categoria_Auxiliar_Id = Categoria_Auxiliar_Id; _Personal_Id = Personal_Id;
        }
        
        
    }
}
