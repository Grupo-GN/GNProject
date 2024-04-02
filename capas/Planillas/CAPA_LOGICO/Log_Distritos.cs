using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Distritos
    {
        /*FPS*/
        public static DataTable Lista_Distritos(Ent_Distritos objE)
        {
            return Dao_Distritos.Lista_Distritos(objE);
        }
    }
}
