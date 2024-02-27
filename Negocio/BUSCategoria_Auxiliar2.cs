using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Capas.Portal.Datos;


namespace Capas.Portal.Negocio
{
    public class BUSCategoria_Auxiliar2
    {
        DAOCategoria_Auxiliar2 objDatos = new DAOCategoria_Auxiliar2();
        public DataTable ListaCategoria_Auxiliar2(String Categoria_Auxiliar_Id)
        {
            return objDatos.ListaCategoria_Auxiliar2(Categoria_Auxiliar_Id);
        }
    }
}
