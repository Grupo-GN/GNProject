using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capas.Portal.Datos;

namespace Capas.Portal.Negocio
{
    public class BUSAuxStringConexion:ClsConexion
    {
        

        public BUSAuxStringConexion()
        {
            
        }
        public string GetAuxConexion()
        {
            return Conexion();
        }

    }
}
