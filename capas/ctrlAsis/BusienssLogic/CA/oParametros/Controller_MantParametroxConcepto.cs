using Presistence;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BusienssLogic.CA.oParametros
{
   public  class Controller_MantParametroxConcepto
    {
        private static Controller_MantParametroxConcepto Instance = null;
        public static Controller_MantParametroxConcepto GetInstance()
        {
            return Instance == null ? Instance = new Controller_MantParametroxConcepto() : Instance;
        }
        private static int FINALLROWS = 12;

        public class ParametroConcepto
        {
            public string  Id { set; get; }
            public string Concepto_Id { set; get; }
            public int Parametro_Id { set; get; }
            public string Concepto { set; get; }
            public string Parametro { set; get; }
            public string Estado { set; get; }
            public string abrev { set; get; }  
            public string semana { set; get; }      

        }
        //Lista Concepto - Parametro
        public List<ParametroConcepto> ListaParametroConcepto(int inicio)
        {

            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                List<ParametroConcepto> rlist = new List<ParametroConcepto>();
                                
                    string SPnom = string.Empty;
                    SPnom = "Sp_parametro_concepto_List";
                
                    using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
                    {
                        using (SqlCommand cmd = new SqlCommand(SPnom, cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
 
                                //cmd.Parameters.AddWithValue("@Planilla_Id", Planilla_Id);
                                //cmd.Parameters.AddWithValue("@Periodo_Id", Periodo_Id);
                                //cmd.Parameters.AddWithValue("@Area_Id", Localidad_Id);
                                //cmd.Parameters.AddWithValue("@Personal_Id", "");
                                //cmd.Parameters.AddWithValue("@Fecha_InicialFPS", FechaIni);
                                //cmd.Parameters.AddWithValue("@Fecha_FinalFPS", FechaFin);
                                cn.Open();
                                SqlDataReader dr = cmd.ExecuteReader();
                                while (dr.Read())
                                {
                                    ParametroConcepto nov = new ParametroConcepto();
                                 
                                    nov.Id = dr.GetValue(0).ToString();
                                    nov.Concepto_Id = dr.GetValue(1).ToString();
                                     nov.Parametro_Id = int.Parse(dr.GetValue(2).ToString());
                                     nov.Concepto = dr.GetValue(3).ToString();
                                    nov.Parametro = dr.GetValue(4).ToString();
                                    nov.Estado = dr.GetValue(5).ToString();
                                     nov.semana = dr.GetValue(6).ToString();
                                    rlist.Add(nov);
                                }
                                cmd.Parameters.Clear();
                                cn.Close();
 
                        }
                    }
 
                return rlist.OrderBy(o => o.Parametro).Skip(inicio).Take(FINALLROWS).ToList();
             

            }

        }


      //Lista Parametro - Concepto Id
          public List<ParametroConcepto> ListaParametroConceptoFind(string  Id)
        {

            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                List<ParametroConcepto> rlist = new List<ParametroConcepto>();
                                
                    string SPnom = string.Empty;
                    SPnom = "Sp_parametro_concepto_List_Id";
                
                    using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
                    {
                        using (SqlCommand cmd = new SqlCommand(SPnom, cn))
                        {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", Id);
                        //cmd.Parameters.AddWithValue("@Periodo_Id", Periodo_Id);
                        //cmd.Parameters.AddWithValue("@Area_Id", Localidad_Id);
                        //cmd.Parameters.AddWithValue("@Personal_Id", "");
                        //cmd.Parameters.AddWithValue("@Fecha_InicialFPS", FechaIni);
                        //cmd.Parameters.AddWithValue("@Fecha_FinalFPS", FechaFin);
                        cn.Open();
                                SqlDataReader dr = cmd.ExecuteReader();
                                while (dr.Read())
                                {
                                    ParametroConcepto nov = new ParametroConcepto();
                                     nov.Id = dr.GetValue(0).ToString();
                                        nov.Concepto_Id = dr.GetValue(1).ToString();
                                    nov.Parametro_Id = int.Parse(dr.GetValue(2).ToString());
                            nov.Estado = dr.GetValue(3).ToString();
                            nov.semana = dr.GetValue(4).ToString();
                                
                                    
                                    rlist.Add(nov);
                                }
                                cmd.Parameters.Clear();
                                cn.Close();
 
                        }
                    }
 
                return rlist.OrderBy(o => o.Id).ToList();
             

            }

        }

        // Insert Parametro  - Concepto

        public bool InsertaParametroConcepto(string Concepto_Id, string Parametro_Id, string Estado,string semana )
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Parametro_Concepto_Insert", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Concepto_Id", Concepto_Id);
                        cmd.Parameters.AddWithValue("@Parametro_Id", int.Parse( Parametro_Id));
                        cmd.Parameters.AddWithValue("@Estado", Estado);
                        cmd.Parameters.AddWithValue("@semana", semana);
                        cn.Open();
                        int cant = cmd.ExecuteNonQuery();
                        if (cant > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Actualiza Parametro Concepto
        public bool ActualizaParametroConcepto(string Id, string Concepto_Id, string Parametro_Id, string Estado,string semana)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Parametro_Concepto_Update", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Parameters.AddWithValue("@Concepto_Id", Concepto_Id);
                        cmd.Parameters.AddWithValue("@Parametro_Id", int.Parse(Parametro_Id));
                        cmd.Parameters.AddWithValue("@Estado", Estado);
                        cmd.Parameters.AddWithValue("@semana", semana);
                        cn.Open();
                        int cant = cmd.ExecuteNonQuery();
                        if (cant > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                // return "false#.::Error > " + ex.Message;
                return false;
            }
        }

        // Lista Parametro

        public ArrayList Get_Parametro_List()
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rList = new ArrayList();
                var query = from p in obj.ParametrosControlAsistencia
                            where p.C_estado == "01" && p.C_abrev !=""
                            select new { p.Parametro_Id, p.Descripcion };
                rList.AddRange(query.ToList());
                return rList;
            }
        }

        //Lista de Concepto

        public ArrayList Get_Concepto_List()
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rList = new ArrayList();
                var query = from p in obj.Conceptos
                            where p.Tipo_Dato=="02"
                            select new { p.Concepto_Id, p.Descripcion };
                rList.AddRange(query.ToList());
                return rList;
            }
        }

        //Lista Concepto - Parametro
        public int GetMaxData()
        {

            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                List<ParametroConcepto> rlist = new List<ParametroConcepto>();

                string SPnom = string.Empty;
                SPnom = "Sp_parametro_concepto_List";

                using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand(SPnom, cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            ParametroConcepto nov = new ParametroConcepto();

                            nov.Id = dr.GetValue(0).ToString();
                            nov.Concepto_Id = dr.GetValue(1).ToString();
                            nov.Parametro_Id = int.Parse(dr.GetValue(2).ToString());
                            nov.Concepto = dr.GetValue(3).ToString();
                            nov.Parametro = dr.GetValue(4).ToString();
                            nov.Estado = dr.GetValue(5).ToString();

                            rlist.Add(nov);
                        }
                        cmd.Parameters.Clear();
                        cn.Close();

                    }
                }
                int max = 0;
                max = rlist.OrderBy(o => o.Id).ToList().Count();
                return max ;


            }

        }

        //Lista Concepto - Parametro
        public List<ParametroConcepto> ListaParametroConcepto2()
        {

            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                List<ParametroConcepto> rlist = new List<ParametroConcepto>();

                string SPnom = string.Empty;
                SPnom = "Sp_parametro_concepto_List2";

                using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand(SPnom, cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            ParametroConcepto nov = new ParametroConcepto();

                            nov.abrev = dr.GetValue(0).ToString();
                            nov.Concepto_Id= dr.GetValue(1).ToString();
                            nov.Concepto = dr.GetValue(2).ToString();
                            nov.Parametro = dr.GetValue(3).ToString();
                            nov.Estado = dr.GetValue(4).ToString();
                            nov.semana= dr.GetValue(5).ToString();
                            rlist.Add(nov);
                        }
                        cmd.Parameters.Clear();
                        cn.Close();

                    }
                }

                return rlist.OrderBy(o => o.Parametro).ToList();


            }

        }

        public class qsemana
        {
            public string id { get; set; }
            public string semana { get; set; }
        }

        public List<qsemana> ListaSemana()
        {
            string Fecha = "";
            Fecha = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/01";
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                List<qsemana> rlist = new List<qsemana>();

                string SPnom = string.Empty;
                SPnom = "Sp_Semana_mes";

                using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand(SPnom, cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                     
                        cmd.Parameters.AddWithValue("@fecha01", Fecha);
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            qsemana nov = new qsemana();

                            nov.id = dr.GetValue(0).ToString();
                            nov.semana = dr.GetValue(1).ToString();
                            rlist.Add(nov);
                        }
                        cmd.Parameters.Clear();
                        cn.Close();

                    }
                }

                return rlist.ToList();


            }

        }







    }
}
