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
    public static class Dao_Ctas_Ctes
    {
        /*FPS*/
        public static DataSet Lista_Ctas_Ctes(Ent_Ctas_Ctes objE)
        {
            return SqlHelper.ExecuteDataset(Conex.CadCon(), "fps_sps_Ctas_Ctes", objE.Personal_Id, objE.Cta_Cte_Id);
        }

        public static DataSet Graba_Ctas_Ctes(Ent_Ctas_Ctes objE)
        {
            //try {
                /*Registra la Cta. Cte. y genera sus Cuotas*/
            
                return SqlHelper.ExecuteDataset(Conex.CadCon(), "fps_spi_Ctas_Ctes", objE.Personal_Id, objE.Operacion_Id
                , objE.Motivo_Id, objE.Nro_Cuotas, objE.Monto, objE.Moneda_Id, objE.Fecha_Sistema,objE.Fecha_Ini
                , objE.Fecha_Fin, objE.Observaciones, objE.Estado_Id, objE.Interes_Anual, objE.Interes_Cantidad_Periodos
                , objE.fl_quincenal);
            //}catch(Exception ex){
            //    throw new Exception(ex.Message);
            //}
          
        }

        public static DataSet Actualiza_Ctas_Ctes(Ent_Ctas_Ctes objE)
        {
            /*Actualiza la Cta. Cte. y vuelve a genera sus Cuotas*/
            return SqlHelper.ExecuteDataset(Conex.CadCon(), "fps_spu_Ctas_Ctes", objE.Cta_Cte_Id, objE.Personal_Id, objE.Operacion_Id
                , objE.Motivo_Id, objE.Nro_Cuotas, objE.Monto, objE.Moneda_Id, objE.Fecha_Sistema, objE.Fecha_Ini
                , objE.Fecha_Fin, objE.Observaciones, objE.Estado_Id, objE.Interes_Anual, objE.Interes_Cantidad_Periodos
                , objE.fl_quincenal);
        }

        public static DataSet Elimina_Ctas_Ctes(Ent_Ctas_Ctes objE)
        {
            return SqlHelper.ExecuteDataset(Conex.CadCon(), "fps_spd_Ctas_Ctes", objE.Cta_Cte_Id);
        }

        public static string Valida_Nro_Cuotas(int NroC, DateTime FInicio,string personalID, String fl_quincenal)
        { 
            //using(SqlConnection cn=new SqlConnection(Conex.CadCon_String())){
            //    using (SqlCommand cmd = new SqlCommand("sp_Valida_Nro_Cuotas_WPP",cn)) {
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("@vi_Nro_Cuotas", NroC);
            //        cmd.Parameters.AddWithValue("@vi_Fecha_Ini", FInicio);
            //        cmd.Parameters.AddWithValue("@vi_Personal_Id", personalID);
            //        cn.Open();
            //        return cmd.ExecuteScalar().ToString();                    
            //    }
            
            //}
            return SqlHelper.ExecuteScalar(Conex.CadCon_String(), "sp_Valida_Nro_Cuotas_WPP", NroC, FInicio, personalID
                , fl_quincenal).ToString();
        
        }

        public static string Elimina_Cuotas(Ent_Ctas_Ctes objE)
        {
            return SqlHelper.ExecuteScalar(Conex.CadCon_String(), "SP_Delete_Cuota", objE.Cuota_Id).ToString();
        }

    }
}
