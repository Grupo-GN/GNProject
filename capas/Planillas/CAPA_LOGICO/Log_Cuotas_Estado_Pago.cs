using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using CAPA_DATOS;

namespace CAPA_LOGICO
{
    public static class Log_Cuotas_Estado_Pago
    {
        /*FPS*/
        public static DataTable Lista_Cuotas_Estado_Pago()
        {
            return Dao_Cuotas_Estado_Pago.Lista_Cuotas_Estado_Pago();
        }
    }
}
