using Presistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BusienssLogic.CA.oReporteGeneral
{
    public class Controller_Indicadores
    {
        private static Controller_Indicadores Instance = null;
        string ConStr = Presistence.Customs.Conexion.getConexion();
        public static Controller_Indicadores Get_Instance()
        {
            return Instance == null ? Instance = new Controller_Indicadores() : Instance;
        }

        public class Indicadores_Gen
        {
            public int cantidad { set; get; }
            public int dia  { set; get; }
            public string Localidad { set; get; }
            public string Area { set; get; }
        

        }

        public List<Indicadores_Gen> Lista_General(string Personal_Id, string Fecha_Inicio, string Fecha_Fin, string Flat,string planilla_id)
        {

            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                List<Indicadores_Gen> rlist = new List<Indicadores_Gen>();
                    string SPnom = string.Empty;
                    SPnom = "Sp_IndicadoresGeneral";
                using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
                    {
                        using (SqlCommand cmd = new SqlCommand(SPnom, cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;


                            if (Personal_Id.Count() == 0)
                            {
                                cmd.Parameters.AddWithValue("@Personal_Id", Personal_Id);
                                cmd.Parameters.AddWithValue("@fechaIni", DateTime.Parse( Fecha_Inicio));
                                cmd.Parameters.AddWithValue("@fechaFin", DateTime.Parse( Fecha_Fin));
                                cmd.Parameters.AddWithValue("@flat", Flat); //@Periodo_Id
                                cmd.Parameters.AddWithValue("@Periodo_Id", planilla_id);
                                cn.Open();
                                SqlDataReader dr = cmd.ExecuteReader();
                                while (dr.Read())
                                {
                                Indicadores_Gen nov = new Indicadores_Gen();
                                    nov.dia = int.Parse(dr.GetValue(0).ToString());
                                    nov.cantidad = int.Parse(dr.GetValue(1).ToString());

                                rlist.Add(nov);
                                }
                                cmd.Parameters.Clear();
                                cn.Close();
                       }
                    }

                }
                return rlist.OrderBy(o => o.dia).ToList();

            }

        }


        public List<Indicadores_Gen> Lista_Localidad(string Periodo_id, string Personal_Id, string Fecha_Inicio, string Fecha_Fin, string Flat)
        {

            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                List<Indicadores_Gen> rlist = new List<Indicadores_Gen>();
                string SPnom = string.Empty;
                SPnom = "Sp_IndicadoresXLocalidad";
                using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand(SPnom, cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;


                        if (Personal_Id.Count() == 0)
                        {
                            cmd.Parameters.AddWithValue("@Periodo_Id", Periodo_id);
                            cmd.Parameters.AddWithValue("@Personal_Id", Personal_Id);
                            cmd.Parameters.AddWithValue("@fechaIni", DateTime.Parse( Fecha_Inicio));
                            cmd.Parameters.AddWithValue("@fechaFin",DateTime.Parse( Fecha_Fin));
                            cmd.Parameters.AddWithValue("@flat", Flat);

                            cn.Open();
                            SqlDataReader dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                Indicadores_Gen nov = new Indicadores_Gen();
                                nov.Localidad = dr.GetValue(0).ToString();
                                nov.cantidad = int.Parse(dr.GetValue(1).ToString());

                                rlist.Add(nov);
                            }
                            cmd.Parameters.Clear();
                            cn.Close();
                        }
                    }

                }
                return rlist.OrderBy(o => o.Localidad).ToList();

            }

        }


        public List<Indicadores_Gen> Lista_Area(string Periodo_id, string Personal_Id, string Fecha_Inicio, string Fecha_Fin, string Flat)
        {

            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                List<Indicadores_Gen> rlist = new List<Indicadores_Gen>();
                string SPnom = string.Empty;
                SPnom = "Sp_IndicadoresXArea";
                using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand(SPnom, cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;


                        if (Personal_Id.Count() == 0)
                        {
                            cmd.Parameters.AddWithValue("@Periodo_Id", Periodo_id);
                            cmd.Parameters.AddWithValue("@Personal_Id", Personal_Id);
                            cmd.Parameters.AddWithValue("@fechaIni", DateTime.Parse( Fecha_Inicio));
                            cmd.Parameters.AddWithValue("@fechaFin", DateTime.Parse( Fecha_Fin));
                            cmd.Parameters.AddWithValue("@flat", Flat);

                            cn.Open();
                            SqlDataReader dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                Indicadores_Gen nov = new Indicadores_Gen();
                                nov.Area = dr.GetValue(0).ToString();
                                nov.cantidad = int.Parse(dr.GetValue(1).ToString());

                                rlist.Add(nov);
                            }
                            cmd.Parameters.Clear();
                            cn.Close();
                        }
                    }

                }
                return rlist.OrderBy(o => o.Area).ToList();

            }

        }










    }
}
