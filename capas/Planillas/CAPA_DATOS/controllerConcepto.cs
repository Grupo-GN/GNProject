using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAPA_ENTIDAD;
using System.Data;
using System.Data.SqlClient;

namespace CAPA_DATOS
{
    public class controllerConcepto
    {
        private static controllerConcepto instance = null;
        public static controllerConcepto getInstance() {
            return instance == null ? instance = new controllerConcepto() : instance;        
        }
        public List<Ent_Conceptos> ListarConceptosTipoMostrar(string xtipo,string xmostrar) {
            List<Ent_Conceptos> rList = new List<Ent_Conceptos>();
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString)) {
                string comando = "SELECT Concepto_Id,Descripcion FROM Conceptos WHERE Tipo_Dato='"+xtipo+"' AND Estado_Id='01' ";
                comando += "AND MostarMant=" + xmostrar + " ORDER BY Descripcion";
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Ent_Conceptos obj = new Ent_Conceptos();
                        obj.Concepto_Id = dr.GetValue(0).ToString();
                        obj.Descripcion = dr.GetValue(1).ToString();
                        rList.Add(obj);
                    }
                }
            }
            return rList;
        }
        public string ModificarEstadoMostrarMant(string xconceptoid,string xestado)
        {
            string resultado = "false#";
            try
            {
                using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
                {
                    string comando = "UPDATE Conceptos SET MostarMant=@estado WHERE Concepto_Id=@concepto";
                    using (SqlCommand cmd = new SqlCommand(comando, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@concepto", xconceptoid);
                        cmd.Parameters.AddWithValue("@estado", xestado);
                        cn.Open();
                        int xrow = cmd.ExecuteNonQuery();
                        if (xrow > 0)
                        {
                            resultado = "true#Actualizado correctamente.";
                        }
                    }
                }
            }
            catch (Exception ex) {
                resultado = "false#Error:" + ex.InnerException.Message;
            }
            return resultado;
        }
    }
}
