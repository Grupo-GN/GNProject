using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Text;
using System.Configuration;
using System.ComponentModel;

/// <summary>
/// Descripción breve de CorreoElectronico
/// </summary>

namespace GNProject.Acceso.App_code_portal
{
    public class CorreoElectronico
    {
        public CorreoElectronico()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        private string _no_error;
        public string no_error
        {
            get { return _no_error; }
            set { _no_error = value; }
        }

        public bool EnviarCorreo(string to, string subject, string body_HTML)
        {

            bool flEnvio = true;
            StringBuilder strHTML = new StringBuilder();
            strHTML.Append(body_HTML);

            MailMessage oEmail = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            try
            {
                oEmail.From = new MailAddress(ConfigurationManager.AppSettings["MailAddress"], ConfigurationManager.AppSettings["DisplayName"]);
                string[] toList = to.Split(new char[] { ';', ',' });
                foreach (string recipient in toList)
                {
                    if (!String.IsNullOrEmpty(recipient.Trim()))
                        oEmail.To.Add(new MailAddress(recipient));
                }
                oEmail.Subject = subject;
                oEmail.Body = strHTML.ToString();
                /* Si deseamos Adjuntar algún archivo*/
                //////oEmail.Attachments.Add(new Attachment("C:\\archivo.pdf"));
                oEmail.IsBodyHtml = true;
                //oEmail.Priority = System.Net.Mail.MailPriority.High;
                smtp.Host = ConfigurationManager.AppSettings["Host"];
                smtp.Port = Int32.Parse(ConfigurationManager.AppSettings["Port"]);
                smtp.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["UserEmail"], ConfigurationManager.AppSettings["PwdEmail"]);
                ///smtp.EnableSsl = true; //SOLO PARA GMAIL Y HOTMAIL
                smtp.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
                object userState = oEmail;
                try
                {
                    smtp.SendAsync(oEmail, userState);
                }
                catch (Exception ex)
                {
                    flEnvio = false;
                    no_error = string.Format("{0}|{1}", ex.Message, (ex.InnerException != null ? ex.InnerException.Message : string.Empty));
                    //System.Web.HttpContext.Current.Response.Write("1 > " + ex.Message);
                }
                finally
                { }
            }
            catch (Exception ex)
            {
                flEnvio = false;
                no_error = string.Format("{0}|{1}", ex.Message, (ex.InnerException != null ? ex.InnerException.Message : string.Empty));
                //System.Web.HttpContext.Current.Response.Write("1 > " + ex.Message);
                Console.WriteLine("Error al enviar correo: " + no_error);
                // También puedes agregar más detalles sobre el error, como el stack trace
                Console.WriteLine("StackTrace: " + ex.StackTrace);
            }
            finally
            {
                oEmail = null;
                smtp = null;
            }
            return flEnvio;
        }

        static bool mailSent = false;
        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            MailMessage mail = (MailMessage)e.UserState;
            string no_asunto = mail.Subject;
            if (e.Error != null)
            {
                //Console.WriteLine("Error {1} ocurrido mientras se enviaba el correo [{0}] ", no_asunto, e.Error.ToString());
                mailSent = false;
            }
            else if (e.Cancelled)
            {
                mailSent = false;
                //Console.WriteLine("Envio cancelado de correo con asunto [{0}].", no_asunto);
            }
            else
            {
                //Console.WriteLine("Mensaje [{1}] enviado.", no_asunto);
                mailSent = true;
            }
        }

    }
}
