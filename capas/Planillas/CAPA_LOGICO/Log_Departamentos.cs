using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;

namespace CAPA_LOGICO
{
    public static class Log_Departamentos
    {
        /*FPS*/
        public static DataTable Lista_Departamentos()
        {
            return Dao_Departamentos.Lista_Departamentos();
        }
    }
}
