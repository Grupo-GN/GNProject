using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presistence;
using Presistence.Customs;
using System.Data;
using System.Data.SqlClient;

namespace BusienssLogic.CA.oControlAsistencia
{
    public class controller_ca
    {
        private static controller_ca instance = null;
        public static controller_ca getInstance()
        {
            return instance == null ? instance = new controller_ca() : instance;
        }
        public List<Personal> Get_Personal_By_Filtros(string Localidad_Id,string Personal_Id,string periodoid,string planillaid)
        {
            using(SqlConnection cn=new SqlConnection(Conexion.getConexion())){
                using (SqlCommand cmd = new SqlCommand("ListaPersonalControlAsistencia_WPP2012", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.AddWithValue("@Area_Id", Localidad_Id);
                    cmd.Parameters.AddWithValue("@Jefe", Personal_Id);
                    cmd.Parameters.AddWithValue("@periodoid", periodoid);
                    cmd.Parameters.AddWithValue("@planillaid", planillaid);
                    cn.Open();
                    List<Personal> rlist = new List<Personal>();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read()) {
                        Personal obj = new Personal();
                        obj.Personal_Id = dr.GetValue(0).ToString();
                        obj.Nombres = dr.GetValue(1).ToString();
                        rlist.Add(obj);
                    }
                    return rlist;
                }
            }
        }
        public int Get_ListarAsistencias(DateTime fecha_inicio, DateTime fecha_fin)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.getConexion()))
            {
                string command = "SELECT * FROM Periodo_Asistencia where Estado = 1 and (convert(date, Date_Inicio)<= '" + fecha_inicio.ToString("yyy-MM-dd") + "' and convert(date, Date_Fin) >= '" + fecha_inicio.ToString("yyy-MM-dd") + "' and convert(date, Date_Fin) >= '" + fecha_fin.ToString("yyy-MM-dd") + "' and convert(date, Date_Inicio)<= '" + fecha_fin.ToString("yyy-MM-dd") + "' )";
                using (SqlCommand cmd = new SqlCommand(command, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows == true)
                    {
                        return 1;
                    }
                    else {
                        return 0;
                    }
                }
            }
        }
        public DataTable Get_ListarAsistenciasMarcaciones(DateTime fecha_inicio, DateTime fecha_fin, string Personal_Id, string Localidad_Id, string Jefe_Id,string planillaid,string periodoid)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.getConexion()))
            {
                //using (SqlCommand cmd = new SqlCommand("fps_sps_Asistencias", cn))
                using (SqlCommand cmd = new SqlCommand("ListControlAsistencia", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@fecha_inicio", fecha_inicio);
                    cmd.Parameters.AddWithValue("@fecha_final", fecha_fin);
                    cmd.Parameters.AddWithValue("@Personal_Id", Personal_Id);
                    cmd.Parameters.AddWithValue("@Localidad_Id", Localidad_Id);
                    cmd.Parameters.AddWithValue("@Jefe_Id", Jefe_Id);

                    cmd.Parameters.AddWithValue("@planillaid", planillaid);
                    cmd.Parameters.AddWithValue("@periodoid", periodoid);
                    cn.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable Get_ControlAsistencia(int Asistencia_id, string hora_ingreso, string hora_salida, string observacion,string TurnoId,string CCostoId)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("fps_spu_CAsistencia", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@vi_Asistencia_id", Asistencia_id);
                    cmd.Parameters.AddWithValue("@vi_hora_ingreso", hora_ingreso);
                    cmd.Parameters.AddWithValue("@vi_hora_salida", hora_salida);
                    cmd.Parameters.AddWithValue("@vi_observacion", observacion);
                    cmd.Parameters.AddWithValue("@vi_Turno_Id", TurnoId);
                    cmd.Parameters.AddWithValue("@vi_Ccosto_Id", CCostoId);
                    cn.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable Get_SelectAsistencia(DateTime fecha_inicio, DateTime fecha_final, string Localidad_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("fps_sps_AsistenciasWPP", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@fecha_inicio", fecha_inicio);
                    cmd.Parameters.AddWithValue("@fecha_final", fecha_final);
                    cmd.Parameters.AddWithValue("@Localidad_Id", Localidad_Id);
                    cn.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable Get_ProcesarAsistencia(int Asistencia_id, string hora_ingreso, string hora_salida, string observacion)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("fps_spu_CAsistencia", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@vi_Asistencia_id", Asistencia_id);
                    cmd.Parameters.AddWithValue("@vi_hora_ingreso", hora_ingreso);
                    cmd.Parameters.AddWithValue("@vi_hora_salida", hora_salida);
                    cmd.Parameters.AddWithValue("@vi_observacion", observacion);
                    cn.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        //20190114
        public DataTable Get_CargarCentroCostos()
        {
            using (SqlConnection cn = new SqlConnection(Conexion.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT ccosto_id,Descripcion FROM CCOSTO ORDER BY DESCRIPCION", cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable Get_CargarTurnos()
        {
            using (SqlConnection cn = new SqlConnection(Conexion.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Turno_Id,Nombre+' - '+DESCRIPCION [Nombre] FROM Turnos ORDER BY Nombre", cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public string ModificarHoraIngresoSalida(int AsistenciaId, string hora,int tipo) {
            string respuesta = "false#";
            using (SqlConnection cn = new SqlConnection(Conexion.getConexion()))
            {
                string command = "usp_ActualizaHoraIngresoSalida";
                using (SqlCommand cmd = new SqlCommand(command, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@vi_Asistencia_id", AsistenciaId);
                    cmd.Parameters.AddWithValue("@vi_hora", hora);
                    cmd.Parameters.AddWithValue("@vi_t", tipo);
                    cn.Open();
                    int irows = cmd.ExecuteNonQuery();
                    if (irows > 0)
                    {
                        respuesta= "true#Actualizado correctamente.";
                    }
                    else { respuesta = "false#No se actualizó ningún registro."; }
                }
            }
            return respuesta;
        }

        public string ModificarCentroCosto(int AsistenciaId,string CCostoId)
        {
            string respuesta = "false#";
            using (SqlConnection cn = new SqlConnection(Conexion.getConexion()))
            {
                string command = "uspModificarCentroCostoCA";
                using (SqlCommand cmd = new SqlCommand(command, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Asistencia_Id", AsistenciaId);
                    cmd.Parameters.AddWithValue("@Ccosto_Id", CCostoId);
                    cn.Open();
                    int irows = cmd.ExecuteNonQuery();
                    if (irows > 0)
                    {
                        respuesta = "true#Actualizado correctamente.";
                    }
                    else { respuesta = "false#No se actualizó ningún registro."; }
                }
            }
            return respuesta;
        }
        public string ModificarTurno(int AsistenciaId, string TurnoId)
        {
            string respuesta = "false#";
            using (SqlConnection cn = new SqlConnection(Conexion.getConexion()))
            {
                string command = "uspModificarTurnoCA";
                using (SqlCommand cmd = new SqlCommand(command, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Asistencia_Id", AsistenciaId);
                    cmd.Parameters.AddWithValue("@Turno_Id", TurnoId);
                    cn.Open();
                    int irows = cmd.ExecuteNonQuery();
                    if (irows > 0)
                    {
                        respuesta = "true#Actualizado correctamente.";
                    }
                    else { respuesta = "false#No se actualizó ningún registro."; }
                }
            }
            return respuesta;
        }
        

    }

}

