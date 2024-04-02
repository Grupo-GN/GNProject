using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_D_Variables
    {
        /*FPS*/
        public static DataTable Lista_D_Variables(Ent_D_Variables objE, string fl_Sin_Valor)
        {
            try
            {
                /*fl_Sin_Valor => NULL ó '':Todos|0:Con Valor|1:Sin Valor*/
                return Dao_D_Variables.Lista_D_Variables(objE, fl_Sin_Valor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_D_Variables_Genera(Ent_D_Variables objE)
        {
            try
            {
                return Dao_D_Variables.Inserta_D_Variables_Genera(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable Inserta_D_Variables_Genera_x_Concepto(Ent_D_Variables objE)
        {
            try
            {
                return Dao_D_Variables.Inserta_D_Variables_Genera_x_Concepto(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable Actualiza_D_Variables_Masivo(Ent_D_Variables objE, string delimitador, int cant_registros)
        {
            try
            {
                return Dao_D_Variables.Actualiza_D_Variables_Masivo(objE, delimitador, cant_registros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_D_Variables(Ent_D_Variables objE)
        {
            try
            {
                return Dao_D_Variables.Elimina_D_Variables(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /*20180603*/
        public static DataTable Lista_D_Variablesv2(Ent_D_Variables objE, string fl_Sin_Valor)
        {
            try
            {
                /*fl_Sin_Valor => NULL ó '':Todos|0:Con Valor|1:Sin Valor*/
                return Dao_D_Variables.Lista_D_Variablesv2(objE, fl_Sin_Valor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
