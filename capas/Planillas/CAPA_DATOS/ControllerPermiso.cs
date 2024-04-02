using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace CAPA_DATOS
{
    public class ControllerPermiso
    {

        public DataRow Get_Permiso_MS_Buscar(int Permiso_Id) {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("spu_Permisos_MS_Buscar", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@PermisoId", Permiso_Id);
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

        public void Get_Permiso_MS_Mantenimiento(int tipoProceso,int Permiso_Id,
            string descripcion, string fechaAcumulado,int ejecutaAcumulado)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String())) {
                using (SqlCommand cmd = new SqlCommand("spu_Permisos_MS_Mantenimiento", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@tipoProceso", tipoProceso);
                    cmd.Parameters.AddWithValue("@codigo", Permiso_Id);
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@fechaAcumulado", fechaAcumulado);
                    cmd.Parameters.AddWithValue("@ejecutaAcumuladoDias", ejecutaAcumulado);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    cn.Dispose();
                }
            }
        }

        public List<CAPA_ENTIDAD.EntMs.Permisos> Get_Permiso_MS_Listar(string descripcion) {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String())) {
                using (SqlCommand cmd = new SqlCommand("spu_Permisos_MS_Listar", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    List<CAPA_ENTIDAD.EntMs.Permisos> oLista = new List<CAPA_ENTIDAD.EntMs.Permisos>();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read()) {
                        CAPA_ENTIDAD.EntMs.Permisos objPermi = new CAPA_ENTIDAD.EntMs.Permisos();
                        objPermi.Permiso_Id = dr.GetValue(0).ToString();
                        objPermi.descripcion = dr.GetValue(1).ToString();
                        objPermi.fechaAcumulado = dr.GetValue(2).ToString();
                        objPermi.ejecutaAcumuladoDias = dr.GetValue(3).ToString();
                        oLista.Add(objPermi);
                    }
                    cn.Close();
                    cn.Dispose();
                    return oLista;
                }
            }
        }




    }
}
