using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace CAPA_DATOS
{
    public class ControllerRoles
    {

        #region Roles

        public bool Get_Roles_Mantenimiento_Ms(int idOpcion, int idRol,
                                    string rol, string estado)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("spu_Roles_GN_Mantenimientos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@idOpcion", idOpcion);
                    cmd.Parameters.AddWithValue("@idRol", idRol);
                    cmd.Parameters.AddWithValue("@Rol", rol);
                    cmd.Parameters.AddWithValue("@estado", estado);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }

        public List<Roles> Get_Roles_Listar_Ms(string descripcion)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("spu_Roles_GN_Listar", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    List<Roles> oLista = new List<Roles>();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Roles objRol = new Roles();
                        objRol.idRol = int.Parse(dr.GetValue(0).ToString());
                        objRol.rol = dr.GetValue(1).ToString();
                        objRol.estado = dr.GetValue(2).ToString();
                        oLista.Add(objRol);
                    }
                    return oLista;
                }
            }
        }

        public DataRow Get_Roles_Buscar_Ms(int idRol)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("spu_Roles_GN_Buscar", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@idRol", idRol);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
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

        public string Get_Roles_GenerarCodigo_Ms() {
            string sql = "select MAX(idRol)+1 as Codigo from Roles_GN";
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd)) {
                        DataTable tabla = new DataTable();
                        tabla.Clear();
                        da.Fill(tabla);
                        return tabla.Rows[0][0].ToString();
                    }
                }
            }
        }

        #endregion

        #region RolesDetalle
        
        /// <summary>
        /// Add detalle Rol
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="idnivelAcceso"></param>
        /// <param name="idMenu"></param>
        /// <param name="idMenuDetalle"></param>
        /// <param name="idMenuSubDetalle"></param>
        /// <param name="idMenuSub_SubDetalle"></param>
        /// <returns></returns>
        public bool Get_DetalleRol_Add_Ms(int idRol, int idnivelAcceso,
       string idMenu, string idMenuDetalle, string idMenuSubDetalle, string idMenuSub_SubDetalle)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("spu_Roles_GN_Detalle_Add", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@idRol", idRol);
                    cmd.Parameters.AddWithValue("@idNivelAcceso", idnivelAcceso);
                    cmd.Parameters.AddWithValue("@idMenuPrincipal", idMenu);
                    cmd.Parameters.AddWithValue("@idMenuDetalle", idMenuDetalle);
                    cmd.Parameters.AddWithValue("@idMenuSubDetalle", idMenuSubDetalle);
                    cmd.Parameters.AddWithValue("@idMenuSubSubDetalle", idMenuSub_SubDetalle);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }


        /// <summary>
        /// Elimina los detalles asociados a un rol
        /// </summary>
        /// <param name="idRol"></param>
        /// <returns></returns>
        public bool Get_DetalleRol_Delete_Ms(int idRol)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("spu_Roles_GN_Detalle_Delete", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@idRol", idRol);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }


        /// <summary>
        /// Retorna los codigos del acceso para chekear 
        /// </summary>
        /// <param name="idRol"></param>
        /// <returns></returns>
        public List<int> Get_DetalleRol_Checked_true_Ms(int idRol,int indice) {
            string sql = "spu_Roles_GN_Detalle_BuscarRoles_ByChecked";
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String())) {
                using (SqlCommand cmd = new SqlCommand(sql, cn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@idRol", idRol);
                    cmd.Parameters.AddWithValue("@indice", indice);
                    List<int> oLista = new List<int>();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read()) {
                        oLista.Add(int.Parse(dr.GetValue(1).ToString()));
                    }
                    return oLista;
                }
            }
        }

        #endregion
    }

    public class Roles {
        public int idRol { get; set; }
        public string rol { get; set; }
        public string estado { get; set; }

        public Roles(int idRol,string rol,string estado)
        {
            this.idRol = idRol;
            this.rol = rol;
            this.estado = estado;
        }

        public Roles() { 
        
        }

    }

}
