using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Asiento
    {
        /*FPS*/
        public static DataTable Lista_Asiento(Ent_Asiento objE)
        {
            try
            {
                return Dao_Asiento.Lista_Asiento(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Asiento(Ent_Asiento objE)
        {
            try
            {
                return Dao_Asiento.Inserta_Asiento(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Asiento(Ent_Asiento objE)
        {
            try
            {
                return Dao_Asiento.Actualiza_Asiento(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Asiento(Ent_Asiento objE)
        {
            try
            {
                return Dao_Asiento.Elimina_Asiento(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    public static void Get_CuentasContablesMs_Mantenimiento(string tipoMant, string Planilla_Id,
    string Proceso_Id, string Concepto_Id, int Correlativo, string CuentaContable, string Glosa,
    string Cargo) 
     {
          Dao_Asiento.Get_CuentasContablesMs_Mantenimiento(tipoMant, Planilla_Id,
             Proceso_Id, Concepto_Id, Correlativo, CuentaContable, Glosa, Cargo);
     }

    public static DataTable Get_CuentasContablesMs_Listado(string Planilla_Id,
     string Proceso_Id)
    {
        return Dao_Asiento.Get_CuentasContablesMs_Listado(Planilla_Id, Proceso_Id);
    }


    }
}
