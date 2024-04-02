using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Plan_De_Cuentas
    {
        /*FPS*/
        public static DataTable Lista_Plan_De_Cuentas(Ent_Plan_De_Cuentas objE)
        {
            try
            {
                return Dao_Plan_De_Cuentas.Lista_Plan_De_Cuentas(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static List<Ent_Plan_De_Cuentas> Lista_Plan_De_Cuentas(string Compania_Id,
        string Ejercicio_Id, string Cuenta, string Descripcion)
        {
                return Dao_Plan_De_Cuentas.Lista_Plan_De_Cuentas_MS(Compania_Id,Ejercicio_Id,Cuenta,Descripcion);
        }


        public static DataTable Inserta_Plan_De_Cuentas(Ent_Plan_De_Cuentas objE)
        {
            try
            {
                return Dao_Plan_De_Cuentas.Inserta_Plan_De_Cuentas(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Plan_De_Cuentas(Ent_Plan_De_Cuentas objE)
        {
            try
            {
                return Dao_Plan_De_Cuentas.Actualiza_Plan_De_Cuentas(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Plan_De_Cuentas(Ent_Plan_De_Cuentas objE)
        {
            try
            {
                return Dao_Plan_De_Cuentas.Elimina_Plan_De_Cuentas(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /*Lista Tipo de Cuentas => Debe|Haber*/
        public static DataTable Lista_Tipo_Cuenta()
        {
            try
            {
                return Dao_Plan_De_Cuentas.Lista_Tipo_Cuenta();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
