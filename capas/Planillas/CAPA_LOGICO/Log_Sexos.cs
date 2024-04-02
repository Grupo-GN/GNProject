using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;

namespace CAPA_LOGICO
{
    public static class Log_Sexos
    {
        /*FPS*/
        public static DataTable ListaSexos()
        {
            return Dao_Sexos.ListaSexos();
        }
    }
}
