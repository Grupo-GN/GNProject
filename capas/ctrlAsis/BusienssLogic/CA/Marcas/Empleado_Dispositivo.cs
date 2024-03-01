using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BusienssLogic.CA.Marcas
{
  public  class Empleado_Dispositivo
    {
        private static Empleado_Dispositivo Instance = null;
        string ConStr = Presistence.Customs.Conexion.getConexion();
        public static Empleado_Dispositivo Get_Instance()
        {
            return Instance == null ? Instance = new Empleado_Dispositivo() : Instance;
        }

        public class EmpDispositivo
        {
            public int id { set; get; }
            public string Nombre { set; get; }
            public string Personal_id { set; get; }
            public string Conexion { set; get; }
            public string Dispositivo { set; get; }
            public string TipoConexion { set; get; }
             
        }

        public class Data
        {
           public int id { set; get; }
            public string descripcion { set; get; }
        }


        public List<EmpDispositivo> ListaEmpDispsitivo(string personal_id)
        {
            List<EmpDispositivo> rlist = new List<EmpDispositivo>();
            string SPnom = string.Empty;
            SPnom = "SP_Lista_EmpleadoDispositivo";
            using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand(SPnom, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@personal_id", personal_id);

                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        EmpDispositivo nov = new EmpDispositivo();
                        nov.id = int.Parse( dr.GetValue(0).ToString());
                        nov.Nombre = dr.GetValue(1).ToString();
                        nov.Conexion = dr.GetValue(2).ToString();
                        nov.Dispositivo = dr.GetValue(3).ToString();
                        nov.TipoConexion = dr.GetValue(4).ToString();
                                               
                        rlist.Add(nov);
                    }
                    cmd.Parameters.Clear();
                    cn.Close();
                }
            }

            return rlist.OrderBy(o => o.Nombre).ToList();
        }


        public List<Data> ListaTipoConexion()
        {
            List<Data> rlist = new List<Data>();
            string SPnom = string.Empty;
            SPnom = "SP_ListaTipoConexiones";
            using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand(SPnom, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                   

                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Data nov = new Data();
                        nov.id = int.Parse(dr.GetValue(0).ToString());
                        nov.descripcion = dr.GetValue(1).ToString();
                       rlist.Add(nov);
                    }
                    cmd.Parameters.Clear();
                    cn.Close();
                }
            }

            return rlist.OrderBy(o => o.id).ToList();
        }

        public List<Data> ListaDispositivo()
        {
            List<Data> rlist = new List<Data>();
            string SPnom = string.Empty;
            SPnom = "SP_ListDispositivos";
            using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand(SPnom, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;



                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Data nov = new Data();
                        nov.id = int.Parse(dr.GetValue(0).ToString());
                        nov.descripcion = dr.GetValue(1).ToString();
                        rlist.Add(nov);
                    }
                    cmd.Parameters.Clear();
                    cn.Close();
                }
            }

            return rlist.OrderBy(o => o.id).ToList();
        }

        DataTable RUNTABLA(string NOMPRO, params object[] Lista)
        {

            var cn = new SqlConnection(ConStr);
            //CREAR UN COMANDO PARA EJECUTAR EL PROCEDIMIENTO
            SqlCommand CMD = new SqlCommand(NOMPRO, cn);
            //SqlParameter PRM=new  SqlParameter();
            CMD.CommandType = CommandType.StoredProcedure;
            cn.Open();
            //PREPARAR AL COMANDO PARA QUE RECIBA VALORES
            SqlCommandBuilder.DeriveParameters(CMD);
            //ASIGNAR LOS VALORES A LOS PARAMETERS RESPECTIVO
            int CONTADOR = 0;
            //EXEC SPFECHA '12/11/96','10/11/98'
            //EQUIVALE LISTA(0)='12/11/96' LISTA(1)='10/11/98'
            foreach (SqlParameter PRM in CMD.Parameters)
            {
                if (PRM.ParameterName != "@RETURN_VALUE")
                {

                    PRM.Value = Lista[CONTADOR];
                    CONTADOR = CONTADOR + 1;
                }
            }

            SqlDataAdapter DA = new SqlDataAdapter(CMD);
            DataTable DT = new DataTable();
            DA.Fill(DT);
            cn.Close();
            return DT;

        }


        public List<Data> InsertEmpleadoDisp(string Personal_id, string Conexion, string Tipodisp, string Tipoconexion)
        {
            List<Data> horario = new List<Data>();
            DataTable dt = new DataTable();
            dt = RUNTABLA("SP_InsertEmpleadoDispositivo",  Personal_id,   Conexion,  int.Parse( Tipodisp),int.Parse(Tipoconexion));
            foreach (DataRow item in dt.Rows)
            {
                Data nn = new Data();
               
                nn.id = int.Parse(item[0].ToString());
                nn.descripcion = item[1].ToString();
                horario.Add(nn);
            }
          
            return horario;
        }


        public List<Data> UpdateEmpleadoDisp(string id,string Personal_id, string Conexion, string Tipodisp, string Tipoconexion)
        {
            List<Data> horario = new List<Data>();
            DataTable dt = new DataTable();
            dt = RUNTABLA("SP_UpdateEmpleadoDispositivo",int.Parse(id), Personal_id, Conexion, int.Parse(Tipodisp), int.Parse(Tipoconexion));
            foreach (DataRow item in dt.Rows)
            {
                Data nn = new Data();

                nn.id = int.Parse(item[0].ToString());
                nn.descripcion = item[1].ToString();
                horario.Add(nn);
            }

            return horario;
        }

        public List<Data> DeleteEmpleadoDisp(string id )
        {
            List<Data> horario = new List<Data>();
            DataTable dt = new DataTable();
            dt = RUNTABLA("SP_DelEmpleadoDispositivo", int.Parse(id));
            foreach (DataRow item in dt.Rows)
            {
                Data nn = new Data();

                nn.id = int.Parse(item[0].ToString());
                nn.descripcion = item[1].ToString();
                horario.Add(nn);
            }

            return horario;
        }


        public List<EmpDispositivo> ListaEmpDispsitivoFind(string id)
        {
            List<EmpDispositivo> rlist = new List<EmpDispositivo>();
            string SPnom = string.Empty;
            SPnom = "Sp_List_EmpDisp_Find";
            using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand(SPnom, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", int.Parse(id));

                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        EmpDispositivo nov = new EmpDispositivo();
                        nov.id = int.Parse(dr.GetValue(0).ToString());
                        nov.Personal_id = dr.GetValue(1).ToString();
                        nov.Nombre = dr.GetValue(2).ToString();
                        nov.Conexion = dr.GetValue(3).ToString();
                        nov.Dispositivo = dr.GetValue(4).ToString();
                        nov.TipoConexion = dr.GetValue(5).ToString();

                        rlist.Add(nov);
                    }
                    cmd.Parameters.Clear();
                    cn.Close();
                }
            }

            return rlist.OrderBy(o => o.Nombre).ToList();
        }






    }
}
