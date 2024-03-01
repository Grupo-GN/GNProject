using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

  namespace BusienssLogic.CustomEntity
{
   public class General
    {
        static string cx = Presistence.Customs.Conexion.getConexion();

        
      public static  DataTable ListaPermisos()
        {
            //string cx = Presistence.Customs.Conexion.getConexion();
            SqlConnection cnx;
            DataTable dt = new DataTable();

            cnx = new SqlConnection(cx);
            cnx.Open();
            SqlDataAdapter da = new SqlDataAdapter("ListarPermisos", cnx);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(dt);
            return dt;
        }

        public static void updatepermiso(string lblPermiso_Id, string Estado_Permiso)
        {
            SqlConnection cnx;
            cnx = new SqlConnection(cx);
            cnx.Open();

            SqlCommand cmd = new SqlCommand("Update_Permisos", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Permiso_Id", SqlDbType.VarChar).Value = lblPermiso_Id.ToString();
            cmd.Parameters.Add("@estado", SqlDbType.Char).Value = Estado_Permiso.ToString();
            cmd.ExecuteNonQuery();
            cnx.Close();
        }


    }
}
