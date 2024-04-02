using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CAPA_DATOS
{
    public class controllerImportCalculos
    {
        private static controllerImportCalculos instance = null;
        public static controllerImportCalculos getInstance()
        {
            return instance == null ? instance = new controllerImportCalculos() : instance;
        }
        public string GuardarCalculo(string pPeriodo, string pConcepto, string pPersonal, string pProceso, decimal pValor)
        {
            string resultado = "false#";
            try
            {
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    string comando = "UPDATE CALCULOS SET VALOR=@Valor ";
                    comando += "WHERE Periodo_Id=@PeriodoId AND Concepto_Id=@Concepto_Id ";
                    comando += "AND Proceso_Id=@Proceso_Id AND Personal_Id=@Personal_Id";
                    using (SqlCommand cmd = new SqlCommand(comando, cn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@PeriodoId", pPeriodo);
                        cmd.Parameters.AddWithValue("@Concepto_Id", pConcepto);
                        cmd.Parameters.AddWithValue("@Proceso_Id", pProceso);
                        cmd.Parameters.AddWithValue("@Personal_Id", pPersonal);
                        cmd.Parameters.AddWithValue("@Valor", pValor);
                        cn.Open();
                        int irows = cmd.ExecuteNonQuery();
                        if (irows > 0)
                        {
                            resultado = "true#Información actualizada correctamente.#" + pPeriodo + pConcepto + pPersonal + pProceso;
                        }
                        else
                        {
                            resultado = "false#No se actualizó ninguna información, verifique los datos o contacte con el área de soporte.#" + pPeriodo + pConcepto + pPersonal + pProceso;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = "false#Error: " + ex.Message + "#" + pPeriodo + pConcepto + pPersonal + pProceso;
            }
            return resultado;
        }
    }
}
