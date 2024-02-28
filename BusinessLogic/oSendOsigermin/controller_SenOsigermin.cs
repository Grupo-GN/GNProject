using Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BusinessLogic.oSendOsigermin
{
    public class controller_SenOsigermin
    {
        private static controller_SenOsigermin Instance = null;
        public static controller_SenOsigermin Get_Instance()
        {
            return Instance == null ? Instance = new controller_SenOsigermin() : Instance;
        }
        public List<string> Get_Datos_Osigermin(string Incidencia_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                List<string> rList = new List<string>();

                //PRELIMINAR

                rList.Add(
                    obj.ReporteIncidente.Where(x => x.Incidente_Id == Incidencia_Id).First().SendPreliminar
                    );
                rList.Add(
                    obj.ReporteIncidente.Where(x => x.Incidente_Id == Incidencia_Id).First().SendFinal
                    );
                int existePre = obj.File_Osigermin.Where(x => x.Incidente_Id == Incidencia_Id && x.Tipo == "01").Count();
                if (existePre == 1)
                {
                    rList.Add(
                            obj.File_Osigermin.Where(x => x.Incidente_Id == Incidencia_Id && x.Tipo == "01").First().File_NameI
                            );
                }
                else
                {
                    rList.Add("-");
                }
                int existeFin = obj.File_Osigermin.Where(x => x.Incidente_Id == Incidencia_Id && x.Tipo == "02").Count();
                if (existeFin == 1)
                {
                    rList.Add(
                            obj.File_Osigermin.Where(x => x.Incidente_Id == Incidencia_Id && x.Tipo == "02").First().File_NameI
                            );
                }
                else
                {
                    rList.Add("-");
                }

                return rList;
            }
        }
        public bool Get_SabeFile(string Incidencia_Id, string FileNameOsiger, string Tipo)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int exit = obj.File_Osigermin.Where(x => x.Incidente_Id == Incidencia_Id && x.Tipo == Tipo).Count();
                if (exit == 0)
                {
                    File_Osigermin fio = new File_Osigermin();
                    fio.FileI_Id = "001";
                    fio.Incidente_Id = Incidencia_Id;
                    fio.Tipo = Tipo;
                    fio.File_NameI = FileNameOsiger;
                    fio.File_URL = "";
                    fio.Fecha_Registro = DateTime.Now;
                    obj.AddToFile_Osigermin(fio);
                    obj.SaveChanges();
                    return true;
                }
                else if (exit == 1)
                {
                    File_Osigermin fio = obj.File_Osigermin.Where(x => x.Incidente_Id == Incidencia_Id && x.Tipo == Tipo).First();
                    fio.File_NameI = FileNameOsiger;
                    obj.SaveChanges();
                    return true;
                }
                return false;
            }
        }




        public string Get_Enviar_Correo_Osigermin(string Incidencia_Id, string Tipo, string Asunto, string Comentario, string ServerPath)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int existepara = obj.Parametros_Sistema.Where(x => x.Parametro_Id == 1).Count();

                if (existepara == 0)
                {
                    return "false#.::Error, Correo de osigermin no encontrado.";
                }
                string correo = obj.Parametros_Sistema.Where(x => x.Parametro_Id == 1).First().Valor;
                if (correo.Trim() == "")
                {
                    return "false#.::Error, Correo de osigermin no definido.";
                }

                int existeF = obj.File_Osigermin.Where(x => x.Incidente_Id == Incidencia_Id && x.Tipo == Tipo).Count();
                if (existeF == 0)
                {
                    return "false#.::Error, archivo no encontrado.";
                }
                string filename = obj.File_Osigermin.Where(x => x.Incidente_Id == Incidencia_Id && x.Tipo == Tipo).First().File_NameI;
                string proceso = SendMail_SMTP(correo, Asunto, Comentario, ServerPath, filename);

                if (proceso.IndexOf("#") != -1)
                {
                    bool respro = bool.Parse(proceso.Split('#')[0].ToString());
                    if (respro == true)
                    {
                        ReporteIncidente rep = obj.ReporteIncidente.Where(x => x.Incidente_Id == Incidencia_Id).First();
                        if (Tipo == "01")
                        {
                            rep.SendPreliminar = "01";
                        }
                        else if (Tipo == "02")
                        {
                            rep.SendFinal = "01";
                        }
                        obj.SaveChanges();
                    }
                }


                return proceso;
            }

        }
        public string SendMail_SMTP(string emailDestino, string Asunto, string HTMLcont, string ServerPath, string namefile)
        {
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.To.Add(emailDestino);


            string Email = Get_Credencial_Email();
            string Contraseña = Get_Credencial_Password();
            string archivoRuta = ServerPath + namefile;


            msg.From = new MailAddress(Email, "Sistema de Seguridad", System.Text.Encoding.UTF8);
            msg.Subject = Asunto;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = HTMLcont;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;

            if (File.Exists(archivoRuta) == true)
            {
                msg.Attachments.Add(new Attachment(archivoRuta));
            }
            else
            {
                return "false#.::Error, no se encontro el archivo.";
            }
            //Aquí es donde se hace lo especial
            SmtpClient client = new SmtpClient();

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

