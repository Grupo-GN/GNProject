using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CAPA_DATOS
{
    public class controller_ReporteIncidencias
    {
        private static controller_ReporteIncidencias instance = null;
        public static controller_ReporteIncidencias getInstance()
        {
            return instance == null ? instance = new controller_ReporteIncidencias() : instance;
        }
        public ArrayList ListarPersonal(string Periodo,string Localidad,string Area,string Proyecto)
        {

            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("uspListarPersonalIncidenciasDF", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Periodo_Id", Periodo);
                    cmd.Parameters.AddWithValue("@Localidad_Id", Localidad);
                    cmd.Parameters.AddWithValue("@Area_Id", Area);
                    cmd.Parameters.AddWithValue("@Proyecto_Id", Proyecto);
                    ArrayList rList = new ArrayList();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);
                        rList.Add(values);
                    }
                    return rList;
                }
            }
        }
        public ArrayList ListarReporteIncidenciasDatosFijos(string Periodo, string Localidad, string Area, string Proyecto,string Personal)
        {

            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("uspReporteIncidenciasDatosFijos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Periodo_Id", Periodo);
                    cmd.Parameters.AddWithValue("@Localidad_Id", Localidad);
                    cmd.Parameters.AddWithValue("@Area_Id", Area);
                    cmd.Parameters.AddWithValue("@Proyecto_Id", Proyecto);
                    cmd.Parameters.AddWithValue("@Personal_Id", Personal);
                    ArrayList rList = new ArrayList();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);
                        rList.Add(values);
                    }
                    return rList;
                }
            }
        }
    }
}
