using Presistence;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Presistence.Customs;

namespace BusinessLogic.oSendEmail
{
    public class controller_SendEmail
    {
        private static controller_SendEmail Instance = null;
        public static controller_SendEmail Get_Instance()
        {
            return Instance == null ? Instance = new controller_SendEmail() : Instance;
        }

        public string SendMail_SMTP(string emailDestino, string Asunto, string HTMLcont)
        {
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            if (emailDestino.IndexOf(";") != -1)
            {
                string[] correos = new string[] { };
                correos = emailDestino.Split(';');
                for (int i = 0; i < correos.Length; i++)
                {
                    msg.To.Add(correos[i].ToString());
                }
            }
            else
            {
                msg.To.Add(emailDestino);
            }
            /*string cc = Get_MiCorreo_CC();
             if (cc.Trim() != "")
             {
                 msg.CC.Add(cc);
             }*/
            //msg.CC.Add("info@gestiondenegociosrs.com");
            msg.From = new MailAddress("personal@limagas.com", "Sistema de Seguridad", System.Text.Encoding.UTF8);
            msg.Subject = Asunto;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = HTMLcont;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;
            //Aquí es donde se hace lo especial
            SmtpClient client = new SmtpClient();

            string Email = Get_Credencial_Email();
            string Contraseña = Get_Credencial_Password();
            client.Credentials = new System.Net.NetworkCredential(Email, Contraseña);
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            try
            {
                client.Send(msg);
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                string cer = ex.Message.ToString();
                return "false#.::Error, Correo no enviado : " + cer;
            }
            return "true#Correo enviado correctamente.";
        }
        public string SendMail_Gerencia_SQL(string Incidencia_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("SEND_EMAIL_GERENCIA", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Incidencia_Id", Incidencia_Id);
                    cn.Open();
                    string cant = cmd.ExecuteScalar().ToString();

                    if (cant == "-1")
                    {
                        return "false#.::Error, Correo no enviado.";
                    }

                    return "true#Correo enviado correctamente.";
                }
            }
        }
        public string SendMail_Responsable_SQL(string Incidencia_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("SEND_EMAIL_RESPONSABLE", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Incidencia_Id", Incidencia_Id);
                    cn.Open();
                    string cant = cmd.ExecuteScalar().ToString();

                    if (cant == "-1")
                    {
                        return "false#.::Error, Correo no enviado.";
                    }

                    return "true#Correo enviado correctamente.";
                }
            }
        }
        public string Get_MiCorreo_CC()
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int existe = obj.Parametros_Sistema.Where(x => x.Parametro_Id == 3).Count();
                if (existe == 1)
                {
                    return obj.Parametros_Sistema.Where(x => x.Parametro_Id == 3).First().Valor;
                }
                return "";
            }
        }
        public string Get_Credencial_Email()
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                return obj.Parametros_Sistema.Where(x => x.Parametro_Id == 6).First().Valor;
            }
        }
        public string Get_Credencial_Password()
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                return obj.Parametros_Sistema.Where(x => x.Parametro_Id == 7).First().Valor;
            }
        }
    }
}
