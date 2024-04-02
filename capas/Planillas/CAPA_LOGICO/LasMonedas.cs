using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAPA_ENTIDAD.EntMs;

namespace CAPA_LOGICO
{
    public class LasMonedas
    {
        public List<Moneda> GetMonedas_Exportacion()
        {
            CAPA_DATOS.ControllerInterfacesExp u = new CAPA_DATOS.ControllerInterfacesExp();
            return u.Monedas_GetMostrar();
        }

    }
}
