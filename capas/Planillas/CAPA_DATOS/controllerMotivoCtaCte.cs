using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAPA_ENTIDAD;
using System.Data.SqlClient;
using System.Data;

namespace CAPA_DATOS
{
    public class controllerMotivoCtaCte
    {
        private static controllerMotivoCtaCte instance = null;
        public static controllerMotivoCtaCte getinstance() {
            return instance == null ? instance = new controllerMotivoCtaCte() : instance;
        }
        public List<Ent_MotivoCtaCte> ListarMotivosCtaCte(string xbuscar) {
            List<Ent_MotivoCtaCte> rlist = new List<Ent_MotivoCtaCte>();
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                string comando = "SELECT M.MOTIVO_CTACTE_ID,M.DESCRIPCION,C.CONCEPTO_ID,C.DESCRIPCION [CONCEPTO] ";
                comando += "FROM Ctacte_Motivo M INNER JOIN CONCEPTOS C ON M.CONCEPTO_ID=C.CONCEPTO_ID ";
                comando += "WHERE M.DESCRIPCION LIKE '%" + xbuscar + "%'";
                comando += "ORDER BY DESCRIPCION ";
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Ent_MotivoCtaCte obj = new Ent_MotivoCtaCte();
                        obj.MotivoId = dr.GetValue(0).ToString();
                        obj.NMotivo = dr.GetValue(1).ToString();
                        obj.ConceptoId = dr.GetValue(2).ToString();
                        obj.NConcepto = dr.GetValue(3).ToString();
                        rlist.Add(obj);
                    }
                }
            }

            return rlist;
        }
        public List<Ent_SelectConcepto> ListarMotivosCtaCte_Conceptos()
        {
            List<Ent_SelectConcepto> rlist = new List<Ent_SelectConcepto>();
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                string comando = "SELECT CONCEPTO_ID,DESCRIPCION FROM Conceptos WHERE Tipo_Dato='03' ORDER BY DESCRIPCION";
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Ent_SelectConcepto obj = new Ent_SelectConcepto();
                        obj.ConceptoId = dr.GetValue(0).ToString();
                        obj.NConcepto = dr.GetValue(1).ToString();
                        rlist.Add(obj);
                    }
                }
            }
            return rlist;
        }
        public string InsertarMotivosCtaCte(string xDescripcion,string xConceptoId)
        {
            string resultado = "false#";
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                string comando = "usp_InsertMotivoCtaCte";
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Descripcion", xDescripcion);
                    cmd.Parameters.AddWithValue("@Concepto_Id", xConceptoId);
                    cn.Open();
                    int cant = cmd.ExecuteNonQuery();
                    if (cant > 0)
                    {
                        resultado = "true#Motivo Registrado correctamente.";
                    }
                    else {
                        resultado = "false#Error: El motivo no pudo ser registrado, inténtelo nuevamente.";
                    }
                }
            }
            return resultado;
        }
        public string ActualizarMotivosCtaCte(string xId, string xDescripcion, string xConceptoId)
        {
            string resultado = "false#";
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                string comando = "usp_ActualizarMotivoCtaCte";
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Motivo_CtaCte_Id", xId);
                    cmd.Parameters.AddWithValue("@Descripcion", xDescripcion);
                    cmd.Parameters.AddWithValue("@Concepto_Id", xConceptoId);
                    cn.Open();
                    int cant = cmd.ExecuteNonQuery();
                    if (cant > 0)
                    {
                        resultado = "true#Motivo Actualizado correctamente.";
                    }
                    else
                    {
                        resultado = "false#Error: El motivo no pudo ser actualizado, inténtelo nuevamente.";
                    }
                }
            }
            return resultado;
        }
        public string EliminarMotivosCtaCte(string xId)
        {
            string resultado = "false#";
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                string comando = "SELECT COUNT(CTA_CTE_ID) [CANT] FROM Ctas_ctes WHERE MOTIVO_ID=@Motivo_CtaCte_Id";
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Motivo_CtaCte_Id", xId);
                    cn.Open();
                    int cant = int.Parse(cmd.ExecuteScalar().ToString());
                    if (cant > 0)
                    {
                       return resultado = "false#El Motivo no puede ser eliminado porque ya está siendo usado.";
                    }
                }
            }

            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                string comando = "DELETE FROM Ctacte_Motivo WHERE Motivo_CtaCte_Id=@Motivo_CtaCte_Id";
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Motivo_CtaCte_Id", xId);
                    cn.Open();
                    int cant = cmd.ExecuteNonQuery();
                    if (cant > 0)
                    {
                        resultado = "true#Motivo eliminado correctamente.";
                    }
                    else
                    {
                        resultado = "false#Error: El motivo no pudo ser eliminado, inténtelo nuevamente.";
                    }
                }
            }
            return resultado;
        }
    }
}
