using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_D_Directos
    {
        /*FPS*/
        public static DataTable Lista_D_Directos(Ent_D_Directos objE, Ent_Procesos objEProc, string fl_Sin_Valor)
        {
            try
            {
                /*fl_Sin_Valor => NULL ó '':Todos|0:Con Valor|1:Sin Valor*/
                return Dao_D_Directos.Lista_D_Directos(objE, objEProc, fl_Sin_Valor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_D_Directos_Genera(Ent_D_Directos objE)
        {
            try
            {
                return Dao_D_Directos.Inserta_D_Directos_Genera(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_D_Directos_Masivo(Ent_D_Directos objE, string delimitador, int cant_registros)
        {
            try
            {
                return Dao_D_Directos.Actualiza_D_Directos_Masivo(objE, delimitador, cant_registros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_D_Directos(Ent_D_Directos objE)
        {
            try
            {
                return Dao_D_Directos.Elimina_D_Directos(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
