using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using CAPA_DATOS;

namespace CAPA_LOGICO
{
    public static class Log_Ctacte_Motivo
    {
        /*FPS*/
        public static DataTable Lista_CtaCte_Motivo()
        {
            return Dao_Ctacte_Motivo.Lista_CtaCte_Motivo();
        }
    }
}
