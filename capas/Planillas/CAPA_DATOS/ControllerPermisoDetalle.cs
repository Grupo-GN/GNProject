using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace CAPA_DATOS
{
   public class ControllerPermisoDetalle
    {

       public DataRow Get_Permisos_Detalle_MS_BuscarxID(int PDetalle_Id)
       {
           using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
           {
               using (SqlCommand cmd = new SqlCommand("spu_PermisosDetalle_MS_buscarId", cn))
               {
                   cmd.CommandType = System.Data.CommandType.StoredProcedure;
                   cn.Open();
                   cmd.Parameters.AddWithValue("@PDetalle_Id", PDetalle_Id);
                   using (SqlDataAdapter da = new SqlDataAdapter(cmd)) {
                       DataTable tabla = new DataTable();
                       tabla.Clear();
                       da.Fill(tabla);
                       cn.Close();
                       cn.Dispose();
                       return tabla.Rows[0];
                   }
               }
           }
       }


       public void Get_Permisos_Detalle_MS_Mantenimiento(int tipoProceso, int PDetalle_Id,
              string Personal_Id, DateTime FechaDiaria, DateTime Fecha1, DateTime Fecha2,
              int Permiso_Id, string Nro_Documento, int DiasDiferencia, int SaldoActual, int SaldoAnterior, string periodo_id)
       {
           using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
           {
               using (SqlCommand cmd = new SqlCommand("spu_PermisosDetalle_Mantenimiento", cn))
               {
                   cmd.CommandType = System.Data.CommandType.StoredProcedure;
                   cn.Open();
                   cmd.Parameters.AddWithValue("@tipoProceso", tipoProceso);
                   cmd.Parameters.AddWithValue("@PDetalle_Id", PDetalle_Id);
                   cmd.Parameters.AddWithValue("@Personal_Id", Personal_Id);
                   cmd.Parameters.AddWithValue("@FechaDiaria", FechaDiaria);
                   cmd.Parameters.AddWithValue("@Fecha1", Fecha1);
                   cmd.Parameters.AddWithValue("@Fecha2", Fecha2);
                   cmd.Parameters.AddWithValue("@Permiso_Id", Permiso_Id);
                   cmd.Parameters.AddWithValue("@Nro_Documento", Nro_Documento);
                   cmd.Parameters.AddWithValue("@DiasDiferencia", DiasDiferencia);
                   cmd.Parameters.AddWithValue("@SaldoActual", SaldoActual);
                   cmd.Parameters.AddWithValue("@SaldoAnterior", SaldoAnterior);
                   cmd.Parameters.AddWithValue("@periodo_id", periodo_id);
                   cmd.ExecuteNonQuery();
                   cn.Close();
                   cn.Dispose();
               }
           }
       }

       public List<CAPA_ENTIDAD.EntMs.PermisoDetalle> Get_Permisos_Detalle_MS_Listar(DateTime fecha) {
           using (SqlConnection cn = new SqlConnection(Conex.CadCon_String())) {
               using (SqlCommand cmd = new SqlCommand("spu_PermisosDetalle_MS_Listar", cn))
               {
                   cmd.CommandType = System.Data.CommandType.StoredProcedure;
                   cn.Open();
                   cmd.Parameters.AddWithValue("@fecha", fecha);
                   SqlDataReader dr = cmd.ExecuteReader();
                   List<CAPA_ENTIDAD.EntMs.PermisoDetalle> oLista = new List<CAPA_ENTIDAD.EntMs.PermisoDetalle>();
                   while (dr.Read()) {
                       CAPA_ENTIDAD.EntMs.PermisoDetalle objDet = new CAPA_ENTIDAD.EntMs.PermisoDetalle();
                       objDet.PDetalle_Id = int.Parse(dr.GetValue(0).ToString());
                       objDet.Nombres = dr.GetValue(1).ToString();
                       objDet.FechaInicio = Convert.ToDateTime(dr.GetValue(2).ToString());
                       objDet.FechaFin = Convert.ToDateTime(dr.GetValue(3).ToString());
                       objDet.TipoPermiso = dr.GetValue(4).ToString();
                       objDet.Nro_Documento = dr.GetValue(5).ToString();
                       objDet.DiasDiferencia = int.Parse(dr.GetValue(6).ToString());
                       objDet.SaldoActual = int.Parse(dr.GetValue(7).ToString());
                       objDet.SaldoAnterior = int.Parse(dr.GetValue(8).ToString());
                       objDet.Periodo =dr.GetValue(9).ToString();
                       oLista.Add(objDet);
                   }
                   cn.Close();
                   cn.Dispose();
                   return oLista;
               }
           }
       }

       public List<CAPA_ENTIDAD.EntMs.PermisoDetalle> Get_Permisos_Detalle_MS_Buscar_PersonalYPermisos(
           string  Personal_Id,int Permiso_Id)
       {
           using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
           {
               using (SqlCommand cmd = new SqlCommand("spu_PermisosDetalle_MS_Buscar_PersonalYPermisos", cn))
               {
                   cmd.CommandType = System.Data.CommandType.StoredProcedure;
                   cn.Open();
                   cmd.Parameters.AddWithValue("@personal", Personal_Id);
                   cmd.Parameters.AddWithValue("@permiso", Permiso_Id);
                   SqlDataReader dr = cmd.ExecuteReader();
                   List<CAPA_ENTIDAD.EntMs.PermisoDetalle> oLista = new List<CAPA_ENTIDAD.EntMs.PermisoDetalle>();
                   while (dr.Read())
                   {
                       CAPA_ENTIDAD.EntMs.PermisoDetalle objDet = new CAPA_ENTIDAD.EntMs.PermisoDetalle();
                       objDet.PDetalle_Id = int.Parse(dr.GetValue(0).ToString());
                       objDet.Nombres = dr.GetValue(1).ToString();
                       objDet.FechaInicio = Convert.ToDateTime(dr.GetValue(2).ToString());
                       objDet.FechaFin = Convert.ToDateTime(dr.GetValue(3).ToString());
                       objDet.TipoPermiso = dr.GetValue(4).ToString();
                       objDet.Nro_Documento = dr.GetValue(5).ToString();
                       objDet.DiasDiferencia = int.Parse(dr.GetValue(6).ToString());
                       objDet.SaldoActual = int.Parse(dr.GetValue(7).ToString());
                       objDet.SaldoAnterior = int.Parse(dr.GetValue(8).ToString());
                       oLista.Add(objDet);
                   }
                   cn.Close();
                   cn.Dispose();
                   return oLista;
               }
           }
       } 

    }
}
