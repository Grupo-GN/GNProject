using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Capas.Portal.Datos;


namespace Capas.Portal.Negocio
{
    public class BUSCorreos
    {
        DAOCorreos objDatos = new DAOCorreos();
        public String GetCorreosdeUsuriosAll(String strOpcion)
        {
            return objDatos.GetCorreosdeUsuriosAll(strOpcion);
        }
    }
}
