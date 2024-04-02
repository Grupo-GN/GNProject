using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CAPA_ENTIDAD;

/// =================================================================
/// @001 FPS 07/04/2020 - Se agrega funcionalidad de acumular montos por rango de periodo
/// @002 FPS 25/11/2022 - Ajustes filtros multiples y total seleccionados
/// @003 FPS 30/10/2023 - Se agrega filtro estado personal
/// =================================================================

namespace CAPA_DATOS
{
    public class controller_GenerarArchivoBancos
    {
        private static controller_GenerarArchivoBancos instance = null;
        public static controller_GenerarArchivoBancos getinstance()
        {
            return instance == null ? instance = new controller_GenerarArchivoBancos() : instance;
        }

        public List<Ent_Bancos> ListarBancosCombo() {
            List<Ent_Bancos> rlist = new List<Ent_Bancos>();
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                //string comando = "SELECT Banco_Id,Descripcion FROM Bancos WHERE Banco_Id IN ('2','11','9','38') ORDER BY Banco_Id";
                string comando = "SELECT Banco_Id,Descripcion FROM Bancos WHERE fl_gen_archivo_pago = 1 ORDER BY Banco_Id";
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Ent_Bancos obj = new Ent_Bancos();
                        obj.Banco_Id = dr.GetValue(0).ToString();
                        obj.Descripcion = dr.GetValue(1).ToString();
                        rlist.Add(obj);
                    }
                }
            }
            return rlist;
        }

        public List<Ent_ArchivoBancos> ListarPersonalBancos(string ConceptoId,string BancoId,string PeriodoId,string Area_Ids,string Categoria_Auxiliar_Id,string Proyecto_Ids
            , String Periodo_Id_Desde //@001 I/F
            , String Estado_Id) //@003 I/F
        {
            List<Ent_ArchivoBancos> rlist = new List<Ent_ArchivoBancos>();
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                string comando = "uspListarPersonalGenerarArchivoBancos";
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ConceptoId", ConceptoId);
                    cmd.Parameters.AddWithValue("@BancoId", BancoId);
                    cmd.Parameters.AddWithValue("@PeriodoId", PeriodoId);
                    cmd.Parameters.AddWithValue("@Area_Ids", Area_Ids); //@002 I/F //Area_Id
                    cmd.Parameters.AddWithValue("@Categoria_Auxiliar_Id", Categoria_Auxiliar_Id);
                    cmd.Parameters.AddWithValue("@Proyecto_Ids", Proyecto_Ids); //@002 I/F //Proyecto_Id
                    cmd.Parameters.AddWithValue("@vi_Periodo_Id_Desde", Periodo_Id_Desde); //@001 I/F
                    cmd.Parameters.AddWithValue("@Estado_Id", Estado_Id); //@003 I/F
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Ent_ArchivoBancos obj = new Ent_ArchivoBancos();
                        obj.PersonalId= dr.GetValue(0).ToString();
                        obj.NroDoc = dr.GetValue(1).ToString();
                        obj.APaterno = dr.GetValue(2).ToString();
                        obj.AMaterno = dr.GetValue(3).ToString();
                        obj.Nombres = dr.GetValue(4).ToString();
                        obj.Banco = dr.GetValue(5).ToString();
                        obj.Cta = dr.GetValue(6).ToString();
                        obj.Valor = decimal.Parse(dr.GetValue(7).ToString());
                        obj.Estado = bool.Parse(dr.GetValue(8).ToString());

                        obj.CatAuxiliar = dr.GetValue(9).ToString();
                        obj.Proyecto = dr.GetValue(10).ToString();
                        obj.Area = dr.GetValue(11).ToString();
                        obj.Tipo_Cta_Ahorro = dr.GetValue(12).ToString(); //@001 I/F
                        rlist.Add(obj);
                    }
                }
            }
            return rlist;
        }
        public string ActualizarEstadoPersonalActivo(string xPeriodo, string xPersonal)
        {
            string resultado = "";
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                string comando = "uspActualizarEstadoGenerarArchivoPersonalActivo";
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PersonalId", xPersonal);
                    cmd.Parameters.AddWithValue("@PeriodoId", xPeriodo);
                    cn.Open();
                    int irow = cmd.ExecuteNonQuery();
                    resultado = irow > 0 ? "true#Actualizado" : "false#No Actualizado";
                }
            }
            return resultado;
        }

        public List<string> DatosPorPeriodo(string PeriodoId)
        {
            List<string> datos = new List<string>();
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("uspDatosPeriodoPorCodigo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@Periodo_Id", PeriodoId);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        datos.Add(dr.GetValue(0).ToString());
                        datos.Add(dr.GetValue(1).ToString());
                        datos.Add(dr.GetValue(2).ToString());
                    }
                }
            }
            return datos;
        }
    }
}
