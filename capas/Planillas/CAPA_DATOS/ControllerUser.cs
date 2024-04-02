using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace CAPA_DATOS
{
    public class ControllerUser
    {

        public bool verificarUser(string user, string pass, String rucEmpresa) {
            //Verificar si la empresa existe "conexion"
            String codEmpresaConnection = "conexion_" + rucEmpresa;
            if (System.Configuration.ConfigurationManager.ConnectionStrings[codEmpresaConnection] == null)
            {
                throw new Exception("Empresa no configurada.");
            }

            String conn = System.Configuration.ConfigurationManager.ConnectionStrings[codEmpresaConnection].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand("spu_login", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable tabla = new DataTable();
                        tabla.Clear();
                        da.Fill(tabla);
                        return tabla.Rows.Count > 0 ? true : false;
                    }
                }
            }
        }

        public bool Get_Usuarios_GN_Mantenimientos(int idManteniminto, int idUsuario,
            string nombreUsuario, string password, int idRol, string estadoId) {

                using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("spu_Usuarios_GN_Mantenimiento", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        cmd.Parameters.AddWithValue("@idMantenimiento", idManteniminto);
                        cmd.Parameters.AddWithValue("@Usuario_ID", idUsuario);
                        cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@idRol", idRol);
                        cmd.Parameters.AddWithValue("@Estado_Id", estadoId);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
        }

       public List<User_Gn> Get_Usuarios_GN_Listado(string usuario)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("spu_Usuarios_GN_Listar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@nombreUsuario", usuario);
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<User_Gn> oLista = new List<User_Gn>();
                    while (dr.Read()) {
                        User_Gn objUser = new User_Gn();
                        objUser.idUsuario = int.Parse(dr.GetValue(0).ToString());
                        objUser.usuario = dr.GetValue(1).ToString();
                        objUser.password = dr.GetValue(2).ToString();
                        objUser.tipoUsuario = dr.GetValue(3).ToString(); //Rol
                        objUser.estado = dr.GetValue(4).ToString();
                        objUser.idRol = int.Parse(dr.GetValue(5).ToString());
                        oLista.Add(objUser);
                    }
                    return oLista;
                }
            }
        }

        public DataRow Get_Usuarios_GN_Buscar(int idUsuario)
     {
         using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
       {
           using (SqlCommand cmd = new SqlCommand("spu_Usuarios_GN_Buscar", cn))
           {
               cmd.CommandType = System.Data.CommandType.StoredProcedure;
               cn.Open();
               cmd.Parameters.AddWithValue("@Usuario_ID", idUsuario);
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


        //public DataTable Get_Menus_Listado()
        //{
        //    using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
        //    {
        //        using (SqlCommand cmds = new SqlCommand("spu_retornaMenu_ms3", cn))
        //        {
        //            cmds.CommandType = CommandType.StoredProcedure;
        //            cn.Open();
        //            using (SqlDataAdapter da = new SqlDataAdapter(cmds)) {
        //                DataTable tabla = new DataTable();
        //                da.Fill(tabla);
        //                return tabla;
        //            }
        //           // List<MenuDinamico> oLista = new List<MenuDinamico>();
        //            //SqlDataReader dr = cmds.ExecuteReader();
        //            //while (dr.Read())
        //            //{
        //            //    MenuDinamico objMenu = new MenuDinamico();
        //            //    objMenu.codigo = int.Parse(dr.GetValue(0).ToString());
        //            //    objMenu.idMenu = dr.GetValue(1).ToString();
        //            //    objMenu.idDetalleMenu = dr.GetValue(2).ToString();
        //            //    objMenu.idSubDetalleMenu = dr.GetValue(3).ToString();
        //            //    objMenu.idSub_SubDetalleMenu = dr.GetValue(4).ToString();
        //            //    objMenu.Menu = dr.GetValue(5).ToString();
        //            //    objMenu.DetalleMenu = dr.GetValue(6).ToString();
        //            //    objMenu.SubDetalleMenu = dr.GetValue(7).ToString();
        //            //    objMenu.Sub_SubDetalleMenu = dr.GetValue(8).ToString();
        //            //    oLista.Add(objMenu);
        //            //}
        //            //return oLista;
        //        }
        //    }
        //}

    }

    [Serializable]
    public class MenuDinamico {

        public int codigo { get; set; }
        public string idMenu { get; set; }
        public string idDetalleMenu { get; set; }
        public string idSubDetalleMenu { get; set; }
        public string idSub_SubDetalleMenu { get; set; }

        public string Menu { get; set; }
        public string DetalleMenu { get; set; }
        public string SubDetalleMenu { get; set; }
        public string Sub_SubDetalleMenu { get; set; }
    
    }
    
    [Serializable]
    public class User_Gn {

        public int idUsuario { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public string tipoUsuario { get; set; }
        public string estado { get; set; }
        public int idRol {get;set;}
    }

}
