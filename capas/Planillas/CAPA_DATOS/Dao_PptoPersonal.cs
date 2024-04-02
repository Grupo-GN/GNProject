using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using System.Data;
using CAPA_ENTIDAD;
using Microsoft.ApplicationBlocks.Data;

namespace CAPA_DATOS
{
   public  class Dao_PptoPersonal
    {

       public static Dao_PptoPersonal oControllerInstance = null;
       public static Dao_PptoPersonal Create()
        {
            if (oControllerInstance == null)
            {
                oControllerInstance = new Dao_PptoPersonal();
            }
            return oControllerInstance;
        }

       public static DataTable Lista_PptoPersonal(Ent_PptoPersonal objE)
       {
           try
           {
               return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_Listar_PptoPersonal1",objE.Ejercicio_Id);
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
               return SqlHelper.ExecuteDataTable(Conex.CadCon(), "sp_GenerarMesMasivo", objE.Ejercicio_Id);
           }
           catch (Exception ex)
           {
               throw new Exception(ex.Message);
           }
       }

       public static DataTable Actualiza_PptoPersonal_Masico(Ent_PptoPersonal objE, string delimitador, Int32 cant_registros)
       {
           try
           {
               return SqlHelper.ExecuteDataTable(Conex.CadCon(), "spu_Actualizar_PptoPersonal", objE.Mes_Id_Masivo, objE.Categoria_Id_Masivo, objE.Valor_Masivo, delimitador, cant_registros);
           }
           catch (Exception ex)
           {
               throw new Exception(ex.Message);
           }
       }


    
       public Int32 Lista_ActivarPivot(Ent_PptoPersonal objE)
       {
           using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
           {
               using (SqlCommand cmd = new SqlCommand("EjecutarPivot", cn))
               {
                   cmd.CommandType = CommandType.StoredProcedure;
                   cn.Open();
                   int RES;
                   RES = cmd.ExecuteNonQuery();
                   cn.Close();
                   return RES;
               }
           }
       }

       public Int32 Lista_ActivarLevel80()
       {
           using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
           {
               using (SqlCommand cmd = new SqlCommand("EjecutarLevel80", cn))
               {
                   cmd.CommandType = CommandType.StoredProcedure;
                   cn.Open();
                   int RES;
                   RES = cmd.ExecuteNonQuery();
                   cn.Close();
                   return RES;
               }
           }
       }
    }
}
