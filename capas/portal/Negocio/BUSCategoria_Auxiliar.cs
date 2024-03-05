using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Capas.Portal.Datos;


namespace Capas.Portal.Negocio
{
    public class BUSCategoria_Auxiliar
    {
        DAOCategoria_Auxiliar objDatos = new DAOCategoria_Auxiliar();
        public DataTable ListaCategoria_Auxiliar()
        {
            return objDatos.ListaCategoria_Auxiliar();
        }

        public DataTable ListaCategoria_AuxiliaSinTodos()
        {
            return objDatos.ListaCategoria_AuxiliaSinTodos();
        }

    }
}
