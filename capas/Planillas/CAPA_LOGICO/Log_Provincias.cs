using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Provincias
    {
        /*FPS*/
        public static DataTable Lista_Provincias(Ent_Provincias objE)
        {
            return Dao_Provincias.Lista_Provincias(objE);
        }
    }
}
