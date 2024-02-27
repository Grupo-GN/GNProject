using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Capas.Portal.Datos;
using Capas.Portal.Entidad;
namespace Capas.Portal.Negocio
{
    public class BUSOHSAS
    {
        public List<OHSAS> GetOHSASAll()
        {
            return new DAOOHSAS().GetOHSASAll();
        }

    }
}
