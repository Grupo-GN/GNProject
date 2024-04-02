using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CAPA_DATOS
{
    public class ControllerMenus
    {
        /// <summary>
        /// Checkear en Usuarios alos Roles x rol
        /// </summary>
        /// <param name="idRol"></param>
        /// <param name="indice"></param>
        /// <returns></returns>
        public List<int> Get_Roles_GN_Detalle_Checked_true_Ms(int idRol, int indice)
        {
            string sql = "spu_Roles_GN_Detalle_BuscarRol_ByChecked";
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@idRol", idRol);
                    cmd.Parameters.AddWithValue("@indice", indice);
                    List<int> oLista = new List<int>();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        oLista.Add(int.Parse(dr.GetValue(1).ToString()));
                    }
                    return oLista;
                }
            }
        }



        /// <summary>
        /// Checkear en Usuarios alos Usuarios_Gn x User
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="indice"></param>
        /// <returns></returns>
        public List<int> Get_DetalleUsuariosGN_Checked_true_Ms(int idUsuario, int indice)
        {
            string sql = "spu_Usuarios_GN_NivelesAcceso_BuscarUsuario_ByChecked";
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmd.Parameters.AddWithValue("@indice", indice);
                    List<int> oLista = new List<int>();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        oLista.Add(int.Parse(dr.GetValue(1).ToString()));
                    }
                    return oLista;
                }
            }
        }




        /// <summary>
        /// Agregar nuevos permisos a los usuarios
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="idnivelAcceso"></param>
        /// <param name="idMenu"></param>
        /// <param name="idMenuDetalle"></param>
        /// <param name="idMenuSubDetalle"></param>
        /// <param name="idMenuSub_SubDetalle"></param>
        /// <returns></returns>
        public bool Get_Menus_Add_Ms(int idUsuario, int idnivelAcceso,
            string idMenu, string idMenuDetalle, string idMenuSubDetalle, string idMenuSub_SubDetalle) {
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("spu_Usuarios_GN_NivelesAcceso_Insert", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
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
        /// Eliminar todos los permisos del User
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public bool Get_Menus_Delete_Ms(int idUsuario)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("spu_Usuarios_GN_NivelesAcceso_Delete_Ms", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }

        /// <summary>
        /// Cargar menu(check) por usuario 
        ///(NOSE USA)
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        //public DataTable Get_Menus_TraePermisos_Ms(int idUsuario)
        //{
        //    using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("spu_retornaMenu_ms_ByUser", cn))
        //        {
        //            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
        //            cn.Open();
        //            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
        //            {
        //                DataTable tabla = new DataTable();
        //                tabla.Clear();
        //                da.Fill(tabla);
        //                cn.Close();
        //                cn.Dispose();
        //                return tabla;
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// Listado de Menues (no se usa)
        /// </summary>
        /// <returns></returns>
        //public List<MenuDinamico> Get_Menues_Listar() {
        //    using (SqlConnection cn = new SqlConnection(Conex.CadCon_String())) {
        //        using (SqlCommand cmd = new SqlCommand("spu_retornaMenu_ms", cn))
        //        {
        //            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //            cn.Open();
        //            List<MenuDinamico> oLista = new List<MenuDinamico>();
        //            SqlDataReader dr = cmd.ExecuteReader();
        //            while (dr.Read())
        //            {
        //                MenuDinamico objMenu = new MenuDinamico();
        //                objMenu.codigo = int.Parse(dr.GetValue(0).ToString());
        //                objMenu.idMenu = dr.GetValue(1).ToString();
        //                objMenu.idDetalleMenu = dr.GetValue(2).ToString();
        //                objMenu.idSubDetalleMenu = dr.GetValue(3).ToString();
        //                objMenu.idSub_SubDetalleMenu = dr.GetValue(4).ToString();
        //                objMenu.Menu = dr.GetValue(5).ToString();
        //                objMenu.DetalleMenu = dr.GetValue(6).ToString();
        //                objMenu.SubDetalleMenu = dr.GetValue(7).ToString();
        //                objMenu.Sub_SubDetalleMenu = dr.GetValue(8).ToString();
        //                oLista.Add(objMenu);
        //            }
        //            return oLista;

        //        }
        //    }
        //}


        /// <summary>
        /// Para cargar los menus separados en Tabs
        /// </summary>
        /// <param name="detalleMenuId"></param>
        /// <returns></returns>
        public List<MenuDinamico> Get_Menues_Listar_ByMenuId(int detalleMenuId)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("spu_retornaMenu_ms_byDetalleId", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@elIdDetalleId", detalleMenuId);
                    List<MenuDinamico> oLista = new List<MenuDinamico>();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        MenuDinamico objMenu = new MenuDinamico();
                        objMenu.codigo = int.Parse(dr.GetValue(0).ToString());
                        objMenu.idMenu = dr.GetValue(1).ToString();
                        objMenu.idDetalleMenu = dr.GetValue(2).ToString();
                        objMenu.idSubDetalleMenu = dr.GetValue(3).ToString();
                        objMenu.idSub_SubDetalleMenu = dr.GetValue(4).ToString();
                        objMenu.Menu = dr.GetValue(5).ToString();
                        objMenu.DetalleMenu = dr.GetValue(6).ToString();
                        objMenu.SubDetalleMenu = dr.GetValue(7).ToString();
                        objMenu.Sub_SubDetalleMenu = dr.GetValue(8).ToString();
                        oLista.Add(objMenu);
                    }
                    return oLista;

                }
            }
        }

        #region MenuDinamicoByUser

        public DataRow Get_Menus_Trae_idUsuario(string Usuario)
        {
            string sql = "select * from Usuarios_GN where NombreUsuario = '" + Usuario + "'";
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cn.Open();
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

        public DataTable Get_Menus_Trae_MenuPrincipal(int idusuario)
        {
            string sql = "select * from MenuPlanillas_Ms where Menu_Principal_Id in (select idMenuPrincipal from Usuarios_GN_NivelesAcceso where Usuario_ID= " + idusuario + ")";
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
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

        public DataTable Get_Menus_Trae_MenuDetalle(int idUsuario)
        {
            string sql = "select * from MenuPlanillas_Detalle_Ms where Menu_Detalle_Id in (select idMenuDetalle from Usuarios_GN_NivelesAcceso where Usuario_ID= " + idUsuario + ")";
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
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

        public DataTable Get_Menus_Trae_MenuSubDetalle(int idUsuario)
        {
            string sql = "select * from MenuPlanillas_SubDetalle_Ms where Menu_SubDetalle_Id in (select idMenuSubDetalle from Usuarios_GN_NivelesAcceso where Usuario_ID= " + idUsuario + ")";
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
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

       public DataTable Get_Menus_Trae_MenuSub_SubDetalle(int idUsuario)
        {
            string sql = "select * from MenuPlanillas_Sub_SubDetalle_Ms where Menu_Sub_SubDetalle_Id in (select idMenuSubSubDetalle from Usuarios_GN_NivelesAcceso where Usuario_ID= " + idUsuario + ")";
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
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

        #endregion


        #region MenuDinamicoByRol

       public DataTable Get_Menus_Trae_MenuPrincipal_ByRol(int idRol)
       {
           string sql = "select * from MenuPlanillas_Ms where Menu_Principal_Id in (select idMenuPrincipal from Roles_GN_Detalle where idRol= " + idRol + ")";
           using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
           {
               using (SqlCommand cmd = new SqlCommand(sql, cn))
               {
                   cmd.CommandType = System.Data.CommandType.Text;
                   cn.Open();
                   using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                   {
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

       public DataTable Get_Menus_Trae_MenuDetalle_ByRol(int idRol)
       {
           string sql = "select * from MenuPlanillas_Detalle_Ms where Menu_Detalle_Id in (select idMenuDetalle from Roles_GN_Detalle where idRol= " + idRol + ")";
           using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
           {
               using (SqlCommand cmd = new SqlCommand(sql, cn))
               {
                   cmd.CommandType = System.Data.CommandType.Text;
                   cn.Open();
                   using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                   {
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

       public DataTable Get_Menus_Trae_MenuSubDetalle_ByRol(int idRol)
       {
           string sql = "select * from MenuPlanillas_SubDetalle_Ms where Menu_SubDetalle_Id in (select idMenuSubDetalle from Roles_GN_Detalle where idRol= " + idRol + ")";
           using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
           {
               using (SqlCommand cmd = new SqlCommand(sql, cn))
               {
                   cmd.CommandType = System.Data.CommandType.Text;
                   cn.Open();
                   using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                   {
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

       public DataTable Get_Menus_Trae_MenuSub_SubDetalle_ByRol(int idRol)
       {
           string sql = "select * from MenuPlanillas_Sub_SubDetalle_Ms where Menu_Sub_SubDetalle_Id in (select idMenuSubSubDetalle from Roles_GN_Detalle where idRol= " + idRol + ")";
           using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
           {
               using (SqlCommand cmd = new SqlCommand(sql, cn))
               {
                   cmd.CommandType = System.Data.CommandType.Text;
                   cn.Open();
                   using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                   {
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

        #endregion

    }
}
