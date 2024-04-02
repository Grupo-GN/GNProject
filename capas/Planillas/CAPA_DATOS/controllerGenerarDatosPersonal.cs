using CAPA_ENTIDAD;
using CAPA_ENTIDAD.EntMs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CAPA_DATOS
{
    public class controllerGenerarDatosPersonal
    {
        private static controllerGenerarDatosPersonal instance = null;
        public static controllerGenerarDatosPersonal getInstance()
        {
            return instance == null ? instance = new controllerGenerarDatosPersonal() : instance;
        }
        public List<ListaPersonal> Lista_Personal_x_GenerarDatos(string Compania_Id, string Periodo_Id, string NomColumna, string Param, string PersonalId)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("uspListarPersonal_x_Filtro_Columna", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@vi_Compania_Id", Compania_Id);
                    cmd.Parameters.AddWithValue("@vi_Periodo_Id", Periodo_Id);
                    cmd.Parameters.AddWithValue("@vi_NomColumna", NomColumna);
                    cmd.Parameters.AddWithValue("@vi_Param", Param);
                    cmd.Parameters.AddWithValue("@PersonalId", PersonalId);
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<ListaPersonal> oLista = new List<ListaPersonal>();
                    while (dr.Read())
                    {
                        CAPA_ENTIDAD.EntMs.ListaPersonal objPer = new CAPA_ENTIDAD.EntMs.ListaPersonal();
                        objPer.Personal_Id = dr.GetValue(0).ToString();
                        objPer.Apellido_Paterno = dr.GetValue(1).ToString();
                        objPer.Apellido_Materno = dr.GetValue(2).ToString();
                        objPer.Nombres = dr.GetValue(3).ToString();
                        objPer.Nro_Doc = dr.GetValue(4).ToString();
                        objPer.Telefono = dr.GetValue(5).ToString();
                        objPer.Telefono2 = dr.GetValue(6).ToString();
                        objPer.Nombre_Zona = dr.GetValue(7).ToString();
                        objPer.Estado_Id = dr.GetValue(8).ToString();
                        objPer.TDocumento = dr.GetValue(9).ToString();
                        objPer.Proyecto = dr.GetValue(10).ToString();
                        oLista.Add(objPer);
                    }
                    return oLista.OrderBy(o => o.Apellido_Paterno).ToList();
                }
            }

        }

        /*
        public List<string> Inserta_D_Fijos_Genera(string Periodo_Id, string[] Personal_Id)
        {
            List<string> resultado = new List<string>(); // "false#" + Personal_Id + "#";
            for (int i = 0; i <= Personal_Id.Count() - 1; i++)
            {
                try
                {

                    using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("fps_spi_D_Fijos_Genera", cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@vi_Periodo_Id", Periodo_Id);
                            cmd.Parameters.AddWithValue("@vi_Personal_Ids", Personal_Id[i]);
                            cmd.CommandTimeout = 0;
                            cn.Open();
                            SqlDataReader dr = cmd.ExecuteReader();
                            List<ListaPersonal> oLista = new List<ListaPersonal>();
                            while (dr.Read())
                            {
                                resultado.Add("true#" + Personal_Id[i] + "#" + dr.GetValue(1).ToString());
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    resultado.Add("false#" + Personal_Id[i] + "#" + ex.Message);
                }
            }
            return resultado;
        }
        public List<string> Inserta_D_Variables_Genera(string Periodo_Id, string[] Personal_Id)
        {
            List<string> resultado = new List<string>(); // "false#" + Personal_Id + "#";
            for (int i = 0; i <= Personal_Id.Count() - 1; i++)
            {
                try
                {

                    using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("fps_spi_D_Variables_Genera", cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@vi_Periodo_Id", Periodo_Id);
                            cmd.Parameters.AddWithValue("@vi_Personal_Ids", Personal_Id[i]);
                            cmd.CommandTimeout = 0;
                            cn.Open();
                            SqlDataReader dr = cmd.ExecuteReader();
                            List<ListaPersonal> oLista = new List<ListaPersonal>();
                            while (dr.Read())
                            {
                                resultado.Add("true#" + Personal_Id[i] + "#" + dr.GetValue(1).ToString());
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    resultado.Add("false#" + Personal_Id[i] + "#" + ex.Message);
                }
            }
            return resultado;
        }
        public List<string> Inserta_D_Directos_Genera(string Periodo_Id, string[] Personal_Id)
        {
            List<string> resultado = new List<string>(); // "false#" + Personal_Id + "#";
            for (int i = 0; i <= Personal_Id.Count() - 1; i++)
            {
                try
                {

                    using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("fps_spi_D_Directos_Genera", cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@vi_Periodo_Id", Periodo_Id);
                            cmd.Parameters.AddWithValue("@vi_Personal_Ids", Personal_Id[i]);
                            cmd.CommandTimeout = 0;
                            cn.Open();
                            SqlDataReader dr = cmd.ExecuteReader();
                            List<ListaPersonal> oLista = new List<ListaPersonal>();
                            while (dr.Read())
                            {
                                resultado.Add("true#" + Personal_Id[i] + "#" + dr.GetValue(1).ToString());
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    resultado.Add("false#" + Personal_Id[i] + "#" + ex.Message);
                }
            }
            return resultado;
        }
        */

        public void generaDatos_AllConceptos(string Periodo_Id, string Personal_Ids
            , Boolean flGenDFijos, Boolean flGenDVariables, Boolean flGenDDirectos, Boolean flGenAcumulativos
            , out Int32 retorno, out String msg_retorno)
        {
            if (flGenDFijos)
            {
                Ent_D_Fijos oEnt_D_Fijos = new Ent_D_Fijos();
                oEnt_D_Fijos.Periodo_Id = Periodo_Id;
                oEnt_D_Fijos.Personal_Id = Personal_Ids;
                DataTable dtRes_Fijos = Dao_D_Fijos.Inserta_D_Fijos_Genera(oEnt_D_Fijos);
            }
            if (flGenDVariables)
            {
                Ent_D_Variables oEnt_D_Variables = new Ent_D_Variables();
                oEnt_D_Variables.Periodo_Id = Periodo_Id;
                oEnt_D_Variables.Personal_Id = Personal_Ids;
                DataTable dtRes_Variables = Dao_D_Variables.Inserta_D_Variables_Genera(oEnt_D_Variables);
            }
            if (flGenDDirectos)
            {
                Ent_D_Directos oEnt_D_Directos = new Ent_D_Directos();
                oEnt_D_Directos.Periodo_Id = Periodo_Id;
                oEnt_D_Directos.Personal_Id = Personal_Ids;
                DataTable dtRes_Directos = Dao_D_Directos.Inserta_D_Directos_Genera(oEnt_D_Directos);
            }
            if (flGenAcumulativos)
            {
                Ent_Calculos_Perm oEnt_Calculos_Perm = new Ent_Calculos_Perm();
                oEnt_Calculos_Perm.Periodo_Id = Periodo_Id;
                oEnt_Calculos_Perm.Personal_Id = Personal_Ids;
                DataTable dtRes_Calculos_Perm = Dao_Calculos_Perm.Inserta_Calculos_Perm_Genera(oEnt_Calculos_Perm);
            }

            retorno = 1;
            msg_retorno = "Se generaron los conceptos correctamente.";
        }
    }
}
