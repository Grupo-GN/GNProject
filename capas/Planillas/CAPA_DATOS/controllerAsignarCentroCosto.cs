using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CAPA_DATOS
{
    public class controllerAsignarCentroCosto
    {
        private static controllerAsignarCentroCosto instance = null;
        public static controllerAsignarCentroCosto getInstance()
        {
            return instance == null ? instance = new controllerAsignarCentroCosto() : instance;
        }
        private static int FINALROWS = 12;
        public List<PersonalCentro> ListaPersonalCentroCosto(string PeriodoId, string LocalidadId, string ProyectoId, string AreaId, int inicio)
        {
            List<PersonalCentro> rlist = new List<PersonalCentro>();
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("uspListarPersonalAsignarCentroCosto", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@vi_Periodo_Id", PeriodoId);
                    cmd.Parameters.AddWithValue("@LocalidadId", LocalidadId);
                    cmd.Parameters.AddWithValue("@ProyectoId", ProyectoId);
                    cmd.Parameters.AddWithValue("@AreaId", AreaId);
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        PersonalCentro obj = new PersonalCentro();
                        obj.PersonalId = dr.GetValue(0).ToString();
                        obj.APaterno = dr.GetValue(1).ToString();
                        obj.AMaterno = dr.GetValue(2).ToString();
                        obj.Nombre = dr.GetValue(3).ToString();
                        obj.TDoc = dr.GetValue(4).ToString();
                        obj.NroDoc = dr.GetValue(5).ToString();
                        obj.Localidad = dr.GetValue(6).ToString();
                        obj.Proyecto = dr.GetValue(7).ToString();
                        obj.Area = dr.GetValue(8).ToString();
                        obj.CcostoId = dr.GetValue(9).ToString();
                        obj.NCcosto = dr.GetValue(10).ToString();
                        obj.CcostoId2 = dr.GetValue(11).ToString();
                        obj.NCcosto2 = dr.GetValue(12).ToString();
                        obj.Porcentaje = int.Parse(dr.GetValue(13).ToString());
                        obj.Porcentaje2 = int.Parse(dr.GetValue(14).ToString());
                        rlist.Add(obj);
                    }
                    return rlist.Skip(inicio).Take(FINALROWS).ToList();
                }
            }
        }
        public int ListaPersonalCentroCosto_MaxRows(string PeriodoId, string LocalidadId, string ProyectoId, string AreaId, int inicio)
        {
            List<PersonalCentro> rlist = new List<PersonalCentro>();
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("uspListarPersonalAsignarCentroCosto", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@vi_Periodo_Id", PeriodoId);
                    cmd.Parameters.AddWithValue("@LocalidadId", LocalidadId);
                    cmd.Parameters.AddWithValue("@ProyectoId", ProyectoId);
                    cmd.Parameters.AddWithValue("@AreaId", AreaId);
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        PersonalCentro obj = new PersonalCentro();
                        obj.PersonalId = dr.GetValue(0).ToString();
                        obj.APaterno = dr.GetValue(1).ToString();
                        obj.AMaterno = dr.GetValue(2).ToString();
                        obj.Nombre = dr.GetValue(3).ToString();
                        obj.TDoc = dr.GetValue(4).ToString();
                        obj.NroDoc = dr.GetValue(5).ToString();
                        obj.Localidad = dr.GetValue(6).ToString();
                        obj.Proyecto = dr.GetValue(7).ToString();
                        obj.Area = dr.GetValue(8).ToString();
                        obj.CcostoId = dr.GetValue(9).ToString();
                        obj.NCcosto = dr.GetValue(10).ToString();
                        obj.CcostoId2 = dr.GetValue(11).ToString();
                        obj.NCcosto2 = dr.GetValue(12).ToString();
                        rlist.Add(obj);
                    }
                    return rlist.Count;
                }
            }
        }


        public List<PersonalCentro> FindPersonalCentroCosto(string PeriodoId, string PersonalId)
        {
            List<PersonalCentro> rlist = new List<PersonalCentro>();
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("uspPersonalCentroCostoAsignado", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Periodo_Id", PeriodoId);
                    cmd.Parameters.AddWithValue("@PersonalId", PersonalId);
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        PersonalCentro obj = new PersonalCentro();
                        obj.PersonalId = dr.GetValue(0).ToString();
                        obj.APaterno = dr.GetValue(1).ToString();
                        obj.AMaterno = dr.GetValue(2).ToString();
                        obj.Nombre = dr.GetValue(3).ToString();
                        obj.TDoc = dr.GetValue(4).ToString();
                        obj.NroDoc = dr.GetValue(5).ToString();
                        obj.Localidad = dr.GetValue(6).ToString();
                        obj.Proyecto = dr.GetValue(7).ToString();
                        obj.Area = dr.GetValue(8).ToString();
                        obj.CcostoId = dr.GetValue(9).ToString();
                        obj.NCcosto = dr.GetValue(10).ToString();
                        obj.Porcentaje = int.Parse(dr.GetValue(11).ToString());
                        obj.CcostoId2 = dr.GetValue(12).ToString();
                        rlist.Add(obj);
                    }
                    return rlist.ToList();
                }
            }
        }
        public ArrayList ListaLocalidad()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("fps_sps_RH_Area", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@vi_Area_Id","");
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
        public ArrayList ListaProyecto()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("fps_sps_Proyecto", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@vi_Proyecto_Id", "");
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
        public ArrayList ListaArea()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("fps_sps_Categoria_Auxiliar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@vi_Categoria_Auxiliar_Id", "");
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
        public ArrayList ListaCentroCosto(string PeriodoId, string PersonalId)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("uspListarCentroCostoAsignacion", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Periodo_Id", PeriodoId);
                    cmd.Parameters.AddWithValue("@PersonalId", PersonalId);
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


        public string ActualizarPersonalCentroCosto( List<PersonalCentroPrm> datos)
        {
            string resultado = "false#";
            try
            {
                int cantidad = datos.Sum(s => s.Porcentaje);
                if (cantidad > 100)
                {
                    return "false#La distribución supera el 100%, verificar los datos.#"+ datos[0].PeriodoId+ datos[0].PersonalId+ datos[0].CcostoId;
                }
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM PersonalCentroCosto WHERE Personal_Id=@Personal_Id AND Periodo_Id=@Periodo_Id", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Personal_Id", datos[0].PersonalId);
                        cmd.Parameters.AddWithValue("@Periodo_Id", datos[0].PeriodoId);
                        cn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                int corr = 0;
                for (int x = 0; x <= datos.Count - 1; x++)
                {
                    if (datos[x].Tipo == "0")
                    {
                        using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                        {
                            using (SqlCommand cmd = new SqlCommand("UPDATE Personal_activo SET PorcentajeCC=@Por WHERE Personal_Id=@Personal_Id AND Periodo_Id=@Periodo_Id", cn))
                            {
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue("@Por", datos[x].Porcentaje);
                                cmd.Parameters.AddWithValue("@Personal_Id", datos[x].PersonalId);
                                cmd.Parameters.AddWithValue("@Periodo_Id", datos[x].PeriodoId);
                                cn.Open();
                                corr += cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    else
                    {
                        using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                        {
                            using (SqlCommand cmd = new SqlCommand("INSERT INTO PersonalCentroCosto VALUES(@Planilla_Id,@Periodo_Id,@Personal_Id,@Ccosto_Id,@Porcentaje,'',GETDATE(),'',NULL,NULL)", cn))
                            {
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue("@Planilla_Id", datos[x].PlanillaId);
                                cmd.Parameters.AddWithValue("@Periodo_Id", datos[x].PeriodoId);
                                cmd.Parameters.AddWithValue("@Personal_Id", datos[x].PersonalId);
                                cmd.Parameters.AddWithValue("@Ccosto_Id", datos[x].CcostoId);
                                cmd.Parameters.AddWithValue("@Porcentaje", datos[x].Porcentaje);
                                cn.Open();
                                corr += cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    
                }
                resultado = "true#Información procesada." + corr.ToString() + " registros actualizados de " + datos.Count.ToString()+ "#" + datos[0].PeriodoId + datos[0].PersonalId + datos[0].CcostoId;
            }
            catch(Exception ex)
            {
                resultado = "false#Error:" + ex.Message+ "#" + datos[0].PeriodoId + datos[0].PersonalId + datos[0].CcostoId;
            }


            return resultado;
        }
    }

    public class PersonalCentro
    {
        public string PersonalId { get; set; }
        public string APaterno { get; set; }
        public string AMaterno { get; set; }
        public string Nombre { get; set; }
        public string TDoc { get; set; }
        public string NroDoc { get; set; }
        public string Localidad { get; set; }
        public string Proyecto { get; set; }
        public string Area { get; set; }
        public string CcostoId { get; set; }
        public string NCcosto { get; set; }
        public string CcostoId2 { get; set; }
        public string NCcosto2 { get; set; }
        public int Porcentaje { get; set; }
        public int Porcentaje2 { get; set; }
    }
    public class PersonalCentroPrm
    {
        public string PlanillaId { get; set; }
        public string PeriodoId { get; set; }
        public string PersonalId { get; set; }
        public string CcostoId { get; set; }
        public int Porcentaje { get; set; }
        public string Tipo { get; set; }
    }
}
