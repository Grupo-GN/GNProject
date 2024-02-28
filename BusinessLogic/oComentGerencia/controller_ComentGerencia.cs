using Presistence;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presistence.Customs;
using BusinessLogic.oSendEmail;

namespace BusinessLogic.oComentGerencia
{
    public class controller_ComentGerencia
    {
        private static controller_ComentGerencia Instance = null;
        public static controller_ComentGerencia Get_Instance()
        {
            return Instance == null ? Instance = new controller_ComentGerencia() : Instance;
        }

        public string Get_Add_Comentario(string Incidente_Id, string Gerente_Id, string EventoComentario, string Comentario)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {

                string EventoDesc = "";
                switch (EventoComentario)
                {
                    case "01": EventoDesc = "Reportado"; break;
                    case "02": EventoDesc = "Actualizado"; break;
                }

                int proc = obj.ComentGerencia.Where(x => x.Incidente_Id == Incidente_Id && x.Gerente_Id == Gerente_Id && x.EventoComentario == EventoDesc).Count();

                if (proc == 0)
                {

                    string Coment_Id = Get_PrimaryKey_Comentario(Incidente_Id, Gerente_Id);
                    int existe = obj.ComentGerencia.Where(x => x.Incidente_Id == Incidente_Id && x.Gerente_Id == Gerente_Id && x.Coment_Id == Coment_Id).Count();
                    if (existe > 0)
                    {
                        return "false#.::Error > Vuelva a intentarlo por favor.";
                    }
                    else
                    {

                        ComentGerencia comen = new ComentGerencia();
                        comen.Incidente_Id = Incidente_Id;
                        comen.Gerente_Id = Gerente_Id;
                        comen.Coment_Id = Coment_Id;
                        comen.EventoComentario = EventoDesc;
                        comen.Comentario = Comentario;
                        comen.FechaRegistro = DateTime.Now;
                        obj.AddToComentGerencia(comen);
                        obj.SaveChanges();
                        string sendM = EnviarCorreo_NuevoComentario(Incidente_Id, Gerente_Id, Coment_Id).Split('#')[1].ToString();

                        return "true#Su Comentario a sido difundico correctament. " + sendM;
                    }
                }
                else
                {

                    int existeupdate = obj.ComentGerencia.Where(x => x.Incidente_Id == Incidente_Id && x.Gerente_Id == Gerente_Id && x.EventoComentario == EventoDesc).Count();
                    if (existeupdate > 0)
                    {
                        ComentGerencia comenU = obj.ComentGerencia.Where(x => x.Incidente_Id == Incidente_Id && x.Gerente_Id == Gerente_Id && x.EventoComentario == EventoDesc).First();
                        comenU.Comentario = Comentario;
                        obj.SaveChanges();
                        string sendMU = EnviarCorreo_NuevoComentario(Incidente_Id, Gerente_Id, comenU.Coment_Id).Split('#')[1];
                        return "true#Su Comentario a sido difundico correctamente. " + sendMU;

                    }
                    else
                    {

                        return "false#.::Error > No se pudo actulizar el comentario.";
                    }

                }

            }
        }

        public string Get_Comentario_Historico(string Incidente_Id, string Gerente_Id, string EventoComentario)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {

                string EventoDesc = "";
                switch (EventoComentario)
                {
                    case "01": EventoDesc = "Reportado"; break;
                    case "02": EventoDesc = "Actualizado"; break;
                }
                int existeupdate = obj.ComentGerencia.Where(x => x.Incidente_Id == Incidente_Id && x.Gerente_Id == Gerente_Id && x.EventoComentario == EventoDesc).Count();
                if (existeupdate > 0)
                {
                    ComentGerencia comenU = obj.ComentGerencia.Where(x => x.Incidente_Id == Incidente_Id && x.Gerente_Id == Gerente_Id && x.EventoComentario == EventoDesc).First();
                    return comenU.Comentario;
                }
                else
                {
                    return "";
                }

            }
        }

        private string Get_PrimaryKey_Comentario(string Incidente_Id, string Gerente_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int existe = obj.ComentGerencia.Where(x => x.Incidente_Id == Incidente_Id && x.Gerente_Id == Gerente_Id).Count();
                if (existe == 0)
                {
                    return "001";
                }
                else
                {
                    string max = obj.ComentGerencia.Where(x => x.Incidente_Id == Incidente_Id && x.Gerente_Id == Gerente_Id).Max(m => m.Coment_Id);
                    max = (int.Parse(max) + 1).ToString().PadLeft(3, '0');
                    return max;
                }
            }
        }
        private string EnviarCorreo_NuevoComentario(string Incidente_Id, string Gerente_Id, string Coment_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                List<string> rCorreos = new List<string>();


                /* //ADMINISTRADORES
                 rCorreos.AddRange(obj.Personal.Where(x => x.RolSistema == "01" && x.Estado == "01").Select(s => s.email));

                 //JEFES DE PLANTA
                 rCorreos.AddRange(obj.Personal.Where(x => x.Estado == "01" && x.RolSistema == "02").Select(s => s.email));

                 //RESPONSABLES
                 rCorreos.AddRange(obj.AccionCorrectiva.Where(x => x.Incidente_Id == Incidente_Id && x.Estado_Id!="02" && x.Estado_Id!="03").Join(obj.Personal, a => a.Responsable_Id, b => b.Personal_Id,
                     (a, b) => new { a.Accion_Id,b.email }).Select(s=> s.email));*/
                rCorreos.Add("wpisco19@gmail.com");
                if (rCorreos.Count == 0)
                {
                    return "false#.::Error no se encontro a ningun personal.";
                }
                else
                {
                    string apePate = obj.Gerentes.Where(x => x.Gerente_Id == Gerente_Id).First().Apellido_Paterno;
                    string apeMate = obj.Gerentes.Where(x => x.Gerente_Id == Gerente_Id).First().Apellido_Materno;
                    string Nombre = obj.Gerentes.Where(x => x.Gerente_Id == Gerente_Id).First().Nombres;
                    string tgeren = obj.Gerentes.Where(x => x.Gerente_Id == Gerente_Id).First().GerenciaDes;

                    string comentario = obj.ComentGerencia.Where(x => x.Incidente_Id == Incidente_Id && x.Gerente_Id == Gerente_Id && x.Coment_Id == Coment_Id).First().Comentario;
                    string correos = "";
                    string body = Get_BodyHTML_ComentarioGerencia(Incidente_Id);
                    body = body.Replace("@NomGerente", apePate + " " + apeMate + ", " + Nombre);
                    body = body.Replace("@Comentario", comentario);
                    body = body.Replace("@TGerente", tgeren);

                    for (int i = 0; i <= rCorreos.Count - 1; i++)
                    {
                        correos += rCorreos[i] + ";";
                    }
                    correos = correos.Remove(correos.Length - 1);
                    //controller_SendEmail.Get_Instance().SendMail_SMTP(correos, "COMENTARIO - GERENCIA", body)
                    return "true#hola";
                }
            }
        }
        private string Get_BodyHTML_ComentarioGerencia(string Incidente_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("GET_HTML_EMAIL_COMENTARIOGERENCIA", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Incidencia_Id", Incidente_Id);
                    cn.Open();
                    return cmd.ExecuteScalar().ToString();
                }

            }
        }
    }
}
