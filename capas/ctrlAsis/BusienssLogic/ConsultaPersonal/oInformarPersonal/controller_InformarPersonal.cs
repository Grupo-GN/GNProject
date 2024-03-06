using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BusienssLogic.ConsultaPersonal.oInformarPersonal
{
    public class controller_InformarPersonal
    {
        private static controller_InformarPersonal Instance = null;
        public static controller_InformarPersonal Get_Instance() {
            return Instance == null ? Instance = new controller_InformarPersonal() : Instance;
        }
        public string Get_Informar_PersonalBoleta_Masivo(string Personal, string Periodo, string Asunto, string Comentarios)
        {
            string Respuesta = "";
            if (Personal.IndexOf(";") != -1)
            {
                string[] Personales = Personal.Split(',');
                int cantT = 0, cantF = 0;
                for (int i = 0; i <= Personales.Length;i++ ) {
                    if (Personales[i].Trim() != "")
                    {
                        string re = Enviar_Correo(Personales[i], Periodo, "01", Asunto, Comentarios);
                        if (re == "TRUE")
                        {
                            cantT++;
                        }
                        else
                        {
                            cantF++;
                        }
                    }
                }
                Respuesta = "Enviados: " + cantT.ToString() + " Errores: " + cantF.ToString();
            }
            else {
                string re = Enviar_Correo(Personal, Periodo, "01", Asunto, Comentarios);
                if (re == "TRUE")
                {
                    Respuesta = "Enviados: 1 Errores: 0";
                }
                else
                {
                    Respuesta = "Enviados: 0 Errores: 1";
                }
            }

            return Respuesta;
            
        }

        public string Enviar_Correo(string Personal,string Periodo,string Proceso,string Asunto,string Comentarios)
        {
            using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("Send_EMail_Boleta_To_Personal", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PERI", Personal);
                    cmd.Parameters.AddWithValue("@PEIROD", Periodo);
                    cmd.Parameters.AddWithValue("@PROC", Proceso);
                    cmd.Parameters.AddWithValue("@Asunto", Asunto);
                    cmd.Parameters.AddWithValue("@Comentario", Comentarios);
                    cn.Open();
                    return cmd.ExecuteScalar().ToString();
                }

            }
        }
    }
}
