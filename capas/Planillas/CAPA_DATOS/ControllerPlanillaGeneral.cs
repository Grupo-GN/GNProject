using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace CAPA_DATOS
{
   public class ControllerPlanillaGeneral
    {

       public DataTable Get_ExportacionPlanilas_General_Ms(string reporte,
           string personal, string periodo, string proceso, string personalId)
       {
           using (SqlConnection cn = new SqlConnection(Conex.CadCon_String())) {
               using (SqlCommand cmd = new SqlCommand("PROC_SCIRE1_LISTAR_REPORTE", cn))
               {
                   cmd.CommandType = CommandType.StoredProcedure;
                   cn.Open();
                   cmd.Parameters.AddWithValue("@cReporte", reporte);
                   cmd.Parameters.AddWithValue("@Usuario", personal);
                   cmd.Parameters.AddWithValue("@cPeriodo", periodo);
                   cmd.Parameters.AddWithValue("@cProceso", proceso);
                   cmd.Parameters.AddWithValue("@Personal", personalId);
                   using (SqlDataAdapter da = new SqlDataAdapter(cmd)) {
                       DataTable tabla = new DataTable();
                       tabla.Clear();
                       da.Fill(tabla);
                       cn.Close();
                       cn.Dispose();
                       return tabla;
                   }
               }      
              
           }
       
       }

    }
}
