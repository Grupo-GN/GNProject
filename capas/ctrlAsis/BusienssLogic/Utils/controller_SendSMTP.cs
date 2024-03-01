using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace BusienssLogic.Utils
{
    public class controller_SendSMTP
    {
        private static controller_SendSMTP instance = null;
        public static controller_SendSMTP get_instance() {
            return instance == null ? instance = new controller_SendSMTP() : instance;
        }
        public string sendMail(string recipients, string subject, string body,List<string> repcc=null)
        {
            try
            {
                string host = ConfigurationManager.AppSettings["hostsmtp"].ToString();
                string puerto = ConfigurationManager.AppSettings["puerto"];
                string puertossl = ConfigurationManager.AppSettings["puertossl"].ToString();
                string account = ConfigurationManager.AppSettings["account"].ToString();
                string pwd = ConfigurationManager.AppSettings["pwd"].ToString();

                MailMessage email = new MailMessage();
                email.To.Add(new MailAddress(recipients));
                email.From = new MailAddress("not-reply@gnrsgroup.com");
                email.Bcc.Add(new MailAddress("rsalas@gestiondenegociosrs.com"));
               
                if (repcc != null)
                {

                    for (int i = 0; i <= repcc.Count - 1; i++)
                    {
                        email.Bcc.Add(new MailAddress(repcc[i]));
                    }
                }
                email.Subject = subject;
                email.Body = body;
                email.BodyEncoding = System.Text.Encoding.UTF8;
                email.IsBodyHtml = true;
                email.Priority = MailPriority.Normal;

                SmtpClient smtp = new SmtpClient(host, int.Parse(puerto));
                //smtp.Host = "smtp.live.com";
                //smtp.Port = int.Parse(puerto);
                //smtp.Port = int.Parse("587");
                smtp.EnableSsl = false;

                smtp.UseDefaultCredentials = false;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtp.Credentials = new NetworkCredential(account, pwd);
          


                MailMessage correo = new MailMessage();
                correo.From = new MailAddress(account, "Kyocode", System.Text.Encoding.UTF8);//Correo de salida
                correo.To.Add(new MailAddress(recipients));
                correo.Bcc.Add(new MailAddress("rsalas@gestiondenegociosrs.com"));
                correo.Subject = "Correo de prueba"; //Asunto
                correo.Body = "Este es un correo de prueba desde c#"; //Mensaje del correo
                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal;
                SmtpClient smtps = new SmtpClient();
                smtps.UseDefaultCredentials = false;
                smtps.Host = "smtp.gmail.com"; //Host del servidor de correo
                smtps.Port = 465; //Puerto de salida
                smtps.Credentials = new System.Net.NetworkCredential(account, pwd);//Cuenta de correo
                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                smtps.EnableSsl = true;//True si el servidor de correo permite ssl
                //smtps.Send(correo);
                smtp.Send(email);
                //email.Dispose();

                return "true#Mensaje Enviado.";
            }
            catch (Exception ex) {
                return "false#Error Correo: " + ex.Message;
            }

            
        }

    }
}
