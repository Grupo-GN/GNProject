using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Cuotas
    {
        /*FPS*/
        public static DataSet Lista_Cuotas(Ent_Cuotas objE)
        {
            return Dao_Cuotas.Lista_Cuotas(objE);
        }
        public static DataSet Inserta_Cuotas(Ent_Cuotas objE)
        {
            return Dao_Cuotas.Inserta_Cuotas(objE);
        }
        public static DataSet Actualiza_Cuotas(Ent_Cuotas objE)
        {
            return Dao_Cuotas.Actualiza_Cuotas(objE);
        }
        public static DataSet Elimina_Cuotas(Ent_Cuotas objE)
        {
            return Dao_Cuotas.Elimina_Cuotas(objE);
        }

    }
}
