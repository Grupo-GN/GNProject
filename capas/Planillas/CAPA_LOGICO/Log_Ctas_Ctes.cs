using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Ctas_Ctes
    {
        /*FPS*/
        public static DataSet Lista_Ctas_Ctes(Ent_Ctas_Ctes objE)
        {
            return Dao_Ctas_Ctes.Lista_Ctas_Ctes(objE);
        }

        public static DataSet Graba_Ctas_Ctes(Ent_Ctas_Ctes objE)
        {
            return Dao_Ctas_Ctes.Graba_Ctas_Ctes(objE);
        }

        public static DataSet Actualiza_Ctas_Ctes(Ent_Ctas_Ctes objE)
        {
            return Dao_Ctas_Ctes.Actualiza_Ctas_Ctes(objE);
        }

        public static DataSet Elimina_Ctas_Ctes(Ent_Ctas_Ctes objE)
        {
            return Dao_Ctas_Ctes.Elimina_Ctas_Ctes(objE);
        }
        public static string Valida_Nro_Cuotas(int NroC, DateTime FInicio, string personalID, String fl_quincenal)
        {
            return Dao_Ctas_Ctes.Valida_Nro_Cuotas(NroC, FInicio, personalID, fl_quincenal).ToString();
        }
        public static string Elimina_Cuotas(Ent_Ctas_Ctes objE)
        {
            return Dao_Ctas_Ctes.Elimina_Cuotas(objE);
        }
    }
}
