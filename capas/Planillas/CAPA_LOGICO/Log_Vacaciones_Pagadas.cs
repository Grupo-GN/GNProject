using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Vacaciones_Pagadas
    {
        /*FPS*/
        public static DataTable Lista_Vacaciones_Pagadas(Ent_Vacaciones_Pagadas objE)
        {
            return Dao_Vacaciones_Pagadas.Lista_Vacaciones_Pagadas(objE);
        }

        public static DataSet Actualiza_Vacaciones_Pagadas(Ent_Vacaciones_Pagadas objE)
        {
            return Dao_Vacaciones_Pagadas.Actualiza_Vacaciones_Pagadas(objE);
        }

        public static DataSet Elimina_Vacaciones_Pagadas(Ent_Vacaciones_Pagadas objE)
        {
            return Dao_Vacaciones_Pagadas.Elimina_Vacaciones_Pagadas(objE);
        }

        public static DataSet Inserta_Vacaciones_Pagadas(Ent_Vacaciones_Pagadas objE)
        {
            return Dao_Vacaciones_Pagadas.Inserta_Vacaciones_Pagadas(objE);
        }
    }
}
