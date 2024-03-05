using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Capas.Portal.Datos;
using Capas.Portal.Entidad;

namespace Capas.Portal.Negocio
{
    public class BUSBuzonSugerencia
    {
        DAOBuzonSugerencia objDatos = new DAOBuzonSugerencia();
        public DataTable ListaBuzonSugerenciaAll()
        {
            return objDatos.ListaBuzonSugerenciaAll();
        }

        public Int32 InsertBuzonSugerencia(BuzonSugerencia objE)
        {
            return objDatos.InsertBuzonSugerencia(objE);
        }

    }
}
