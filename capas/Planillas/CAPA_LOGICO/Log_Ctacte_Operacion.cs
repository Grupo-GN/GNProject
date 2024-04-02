using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using CAPA_DATOS;

namespace CAPA_LOGICO
{
    public static class Log_Ctacte_Operacion
    {
        /*FPS*/
        public static DataTable Lista_Ctacte_Operacion()
        {
            return Dao_Ctacte_Operacion.Lista_Ctacte_Operacion();
        }
    }
}
