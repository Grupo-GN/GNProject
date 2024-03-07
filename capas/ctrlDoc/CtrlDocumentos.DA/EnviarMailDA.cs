using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using CtrlDocumentos.BE;
using System.Configuration;
using System.ComponentModel;

namespace CtrlDocumentos.DA
{
    public class EnviarMailDA
    {
        public bool EnviarEmail(EnviarMailBE oBE, out string strError)
        {
            try
            {
                System.Collections.Specialized.NameValueCollection nvc = (System.Collections.Specialized.NameValueCollection)ConfigurationManager.GetSection("group_GestionNegocios/sectionEmail");
                MailMessage msg = new MailMessage();
                //Configuraciones Iniciales
                msg.SubjectEncoding = System.Text.Encoding.UTF8;
                msg.BodyEncoding = System.Text.Encoding.UTF8;
                msg.IsBodyHtml = true;
                //Variables Envio Mail
                //Para
                msg.To.Add(oBE.no_para.Replace(";", ",").TrimEnd(','));

                //Copia
                if (!string.IsNullOrEmpty(oBE.no_copia.Replace(";", ",")))
                    msg.CC.Add(oBE.no_copia.Replace(";", ",").TrimEnd(','));
                //Copia Oculta
                if (!string.IsNullOrEmpty(oBE.no_copia_oculta.Replace(";", ",")))
                    msg.Bcc.Add(oBE.no_copia_oculta.Replace(";", ",").TrimEnd(','));

                msg.Subject = oBE.no_asunto;
                msg.Body = oBE.no_cuerpo;

                //COnfiguracion Variable From
                string DisplayName = nvc["DisplayName"];
                string MailAddress = nvc["MailAddress"];
                msg.From = new MailAddress(MailAddress, DisplayName, System.Text.Encoding.UTF8);

                //Credenciales al Servidor
                int Port = Int32.Parse(nvc["Puerto"].ToString());
                string Host = nvc["Host"].ToString();
                bool EnableSsl = Convert.ToBoolean(Convert.ToInt32(nvc["SSL"]));
                string Usario = nvc["UsuarioMail"].ToString();
                string Clave = nvc["ClaveMail"].ToString();

                SmtpClient client = new SmtpClient();
                client.Credentials = new System.Net.NetworkCredential(Usario, Clave);
                client.Port = Port;
                client.Host = Host;
                client.EnableSsl = EnableSsl;

                //envio del mail
                //client.Send(msg); //-> Envio Syncrono
                strError = "";
                
                client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
                object userState = msg;
                try
                {
                    client.SendAsync(msg, userState);
                    strError = "";
                }
                catch (Exception ex)
                {
                    no_error = string.Format("{0}|{1}", ex.Message, (ex.InnerException != null ? ex.InnerException.Message : string.Empty));
                    //System.Web.HttpContext.Current.Response.Write("1 > " + ex.Message);
                    strError = no_error;
                }
                finally
                { }
                
                return true;
            }

            catch (Exception ex)
            {
                strError = ex.Message.ToString();
                return false;
            }

        }

        #region "Envio de Correo Asyncrono"
        private string _no_error;
        public string no_error
        {
            get { return _no_error; }
            set { _no_error = value; }
        }
        static bool mailSent = false;
        /// <summary>
        /// Envio de correo Asyncrono
        /// </summary>
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
        #endregion
    }
}