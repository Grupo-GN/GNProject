using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using CAPA_DATOS;

namespace CAPA_LOGICO
{
    public static class Log_PptoPersonal
    {

        public static DataTable Lista_PptoPersonal(Ent_PptoPersonal objE)
        {
            try
            {
                return Dao_PptoPersonal.Lista_PptoPersonal(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Lista_PptoMes(Ent_PptoPersonal objE)
        {
            try
            {
                return Dao_PptoPersonal.Lista_PptoMes(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static DataTable Actualiza_PptoPersonal_Masico(Ent_PptoPersonal objE, string delimitador, int cant_registros)
        {
            try
            {
                return Dao_PptoPersonal.Actualiza_PptoPersonal_Masico(objE, delimitador, cant_registros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        //PIVOT ACTIVAR 90

 

        public static Int32 Lista_ActivarPivot(Ent_PptoPersonal objE)
        {
            return Dao_PptoPersonal.Create().Lista_ActivarPivot(objE);
        }

        public static Int32 Lista_ActivarLevel80()
        {
            return Dao_PptoPersonal.Create().Lista_ActivarLevel80();
        }
    }
}
