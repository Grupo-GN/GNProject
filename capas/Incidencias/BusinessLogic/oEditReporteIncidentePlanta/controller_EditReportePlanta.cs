using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Persistence;
using BusinessLogic.oSendEmail;
using System.Data.SqlClient;
using System.Data;
using Persistence.eConexion;

namespace BusinessLogic.oEditReporteIncidentePlanta
{
    public class controller_EditReportePlanta
    {
        private static controller_EditReportePlanta Instance = null;
        public static controller_EditReportePlanta Get_Instance() {
            return Instance == null ? Instance = new controller_EditReportePlanta() : Instance;
        }
        public ArrayList Get_Find_ReporteIncidente(string Incidente_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                var queroper = from r in obj.ReporteIncidente
                               join p in obj.Personal on r.Personal_Registro equals p.Personal_Id
                               join l in obj.RH_Area on p.Area_Id equals l.Area_Id
                               where r.Incidente_Id == Incidente_Id
                               select l.Descripcion;
                string rh_Area_Usu = queroper.First();

                ArrayList rList = new ArrayList();
                var query = from r in obj.ReporteIncidente
                            join p in obj.Personal on r.Personal_Registro equals p.Personal_Id
                            join l in obj.RH_Area on r.Area_Id equals l.Area_Id
                            where r.Incidente_Id == Incidente_Id
                            select new
                            {
                                r.Incidente_Id,
                                PersonalReg = p.Apellido_Paterno + " " + p.Apellido_Materno + ", " + p.Nombres,
                                RH_Area = l.Descripcion,
                                r.Area_Id,
                                Cat1 = r.Categoria_Auxiliar_Id,
                                Cat2 = r.Categoria_Auxiliar2_Id,
                                ActProp = r.Actividad_Propia,
                                ActRut = r.Actividad_Rutinaria,
                                Intensidad = r.Intensidad_Id,
                                Descripcion = r.Descripcion,
                                InfoGenrencia = r.Informar_Gerencia,
                                InfoOsigermin = r.Informar_Osigermin,
                                FHInc = r.FechaHora_Incidente,
                                FHRep = r.FechaHora_Reporte,
                                Lugar = r.Lugar_Incidente,
                                Tipo = r.Tipo,
                                Origen = r.Origen,
                                Severidad = r.Severidad_Id,
                                LesionesPer = r.LesionesPerdidas,
                                PosCausas = r.PosiblesCausas,
                                AccInmediata = r.AccionInmediata,
                                Estado = r.Estado_Id,
                                r.TipoI_Id,
                                r.Afec_Id,
                                RH_Area_Usu = rh_Area_Usu
                            };
                rList.AddRange(query.ToList());
                return rList;
            }
        }
        public string Actualizar_ReporteIncidencia(
string Incidente_Id, string Categoria_Auxiliar_Id
, string Categoria_Auxiliar2_Id, string Actividad_Propia, string Actividad_Rutinaria, string Intensidad_Id
, string Descripcion
, string Informar_Gerencia, string Informar_Osigermin, string FechaHora_Incidente
            , string Lugar_Incidente, string Tipo, string Origen, string Severidad_Id
, string LesionesPerdidas, string PosiblesCausas
, string AccionInmediata, string TipoInc, string AfecInc)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                try
                {

                    int existe = obj.ReporteIncidente.Where(x => x.Incidente_Id == Incidente_Id && x.Estado_Id == "04").Count();
                    if (existe == 1)
                    {
                        string FEC = DateTime.Parse(FechaHora_Incidente).ToString();
                        ReporteIncidente rep = obj.ReporteIncidente.Where(x => x.Incidente_Id == Incidente_Id).First();
                        rep.Categoria_Auxiliar_Id = Categoria_Auxiliar_Id;
                        rep.Categoria_Auxiliar2_Id = Categoria_Auxiliar2_Id;
                        rep.Actividad_Propia = Actividad_Propia;
                        rep.Actividad_Rutinaria = Actividad_Rutinaria;
                        rep.Intensidad_Id = Intensidad_Id;
                        rep.Descripcion = Descripcion;
                        rep.Informar_Gerencia = Informar_Gerencia;
                        rep.Informar_Osigermin = Informar_Osigermin;
                        rep.FechaHora_Incidente = DateTime.Parse(FEC);
                        rep.Lugar_Incidente = Lugar_Incidente;
                        rep.Tipo = Tipo;
                        rep.Origen = Origen;
                        rep.Severidad_Id = Severidad_Id;
                        rep.LesionesPerdidas = LesionesPerdidas;
                        rep.PosiblesCausas = PosiblesCausas;
                        rep.AccionInmediata = AccionInmediata;
                        rep.TipoI_Id = TipoInc;
                        rep.Afec_Id = AfecInc;
                        obj.SaveChanges();

                        EnviarCorreoReporteActualizado(Incidente_Id);
                        return "true#Actualizado Correctamente.#" + Incidente_Id;
                    }
                    else
                    {
                        return "false#.::Error, El Reporte ya esta en curso.";
                    }
                }
                catch (Exception ex)
                {
                    return "false#" + ex.Message;
                }
            }
        }

        void EnviarCorreoReporteActualizado(string Incidente_Id)
        { 
            using (ContextMaestro obj = new ContextMaestro())
            {

                string Estado = obj.ReporteIncidente.Where(x => x.Incidente_Id == Incidente_Id).First().Estado_Id;

                List<string> rCorreos = new List<string>();
                
                rCorreos.AddRange(obj.Personal.Where(x => x.Estado_Id == "01" && x.RolSistema=="01").Select(s => s.email).ToList());

                string UsuariReg = obj.ReporteIncidente.Where(x => x.Incidente_Id == Incidente_Id).First().Personal_Registro;
                rCorreos.AddRange(obj.Personal.Where(x => x.Estado_Id == "01" && x.Personal_Id == UsuariReg).Select(s => s.email).ToList());

                if (Estado == "03")
                {
                    string infGern = obj.ReporteIncidente.Where(x => x.Incidente_Id == Incidente_Id).First().Informar_Gerencia;
                    if (infGern == "01")
                    {
                      string  respuestasendmailGerencia = EnviarCorreo_Gerencia(Incidente_Id);
                    }
                }
                string correos = "";
                string body = Get_BodyHTML_Gerencia(Incidente_Id);
                for (int i = 0; i <= rCorreos.Count - 1; i++)
                {
                    if (rCorreos[i].Trim() != "")
                    {
                        correos += rCorreos[i] + ";";
                    }
                }
                if (correos!=""){
                    correos = correos.Remove(correos.Length - 1);
                controller_SendEmail.Get_Instance().SendMail_SMTP(correos, "REPORTE DE INCIDENCIA - ACTUALIZADA", body);
                }
            }
        }

        public string Get_BodyHTML_Gerencia(string Incidente_Id)
        {
            using (SqlConnection cn = new SqlConnection(conex.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("GET_HTML_EMAIL_GERENCIA", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Incidencia_Id", Incidente_Id);
                    cn.Open();
                    return cmd.ExecuteScalar().ToString();
                }

            }
        }

        public string Get_Update_AccionCorrectiva(string Incidente_Id, string Accion_Id, string Descripcion, string Tipo_Responsable
    , string Responsable_Id, DateTime FechaIni, DateTime FechaFin)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int exist = obj.AccionCorrectiva.Where(x => x.Accion_Id == Accion_Id && x.Incidente_Id == Incidente_Id).Count();
                if (exist == 1)
                {
                    AccionCorrectiva acc = obj.AccionCorrectiva.Where(x => x.Accion_Id == Accion_Id && x.Incidente_Id == Incidente_Id).First();
                    acc.Descripcion = Descripcion;
                    acc.Tipo_Responsable = Tipo_Responsable;
                    acc.Responsable_Id = Responsable_Id;
                    acc.FechaIni = FechaIni;//DateTime.Parse(FechaIni);
                    acc.FechaFin = FechaFin;//DateTime.Parse(FechaFin);
                    acc.Estado_Id = "03";
                    obj.SaveChanges();
                    return "true#Actualizado Correctamente.";
                }
                return "false#.::Error, Intentelo nuevamente.";
            }

        }

        public string Get_Desechar_Accion(string Incidente_Id, string Accion_Id)
        {
            try
            {

                using (ContextMaestro obj = new ContextMaestro())
                {
                    int exist = obj.AccionCorrectiva.Where(x => x.Incidente_Id == Incidente_Id && x.Accion_Id == Accion_Id).Count();
                    if (exist == 1)
                    {

                        AccionCorrectiva acc = obj.AccionCorrectiva.Where(x => x.Incidente_Id == Incidente_Id && x.Accion_Id == Accion_Id).First();
                        obj.DeleteObject(acc);
                        obj.SaveChanges();
                        return "true#Desechado correctamente.";
                    }
                    else
                    {
                        return "false#.::Error, Intentelo nuevamente.";
                    }

                }

            }
            catch (Exception ex)
            {
                return "false#" + ex.Message;
            }
        }


        public string EnviarCorreo_Gerencia(string Incidente_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                List<string> rCorreos = new List<string>();
                rCorreos.AddRange(obj.Gerentes.Where(x => x.Estado == "01").Select(s => s.Correo).ToList());
                if (rCorreos.Count == 0)
                {
                    return "false#.::Error no se encontro a ningun Gerente activo .";
                }
                else
                {
                    string body = Get_BodyHTML_Gerencia_Coment(Incidente_Id);
                    List<Gerentes> gList = new List<Gerentes>();
                    gList.AddRange(obj.Gerentes.Where(x => x.Estado == "01").ToList());
                    for (int i = 0; i <= gList.Count - 1; i++)
                    {
                        string boduMen = body;
                        if (gList[i].Correo.Trim() != "")
                        {
                            boduMen = boduMen.Replace("@GER_ID", gList[i].Gerente_Id);
                            boduMen = boduMen.Replace("@EV_ID", "01");
                            //correos += rCorreos[i] + ";";
                            controller_SendEmail.Get_Instance().SendMail_SMTP(gList[i].Correo, "REPORTE DE INCIDENCIA - ACTUALIZADA", boduMen);
                        }
                    }
                    return "true#Enviado Correctamente.";

                }
            }
        }
        public string Get_BodyHTML_Gerencia_Coment(string Incidente_Id)
        {
            using (SqlConnection cn = new SqlConnection(conex.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("GET_HTML_EMAIL_GERENCIA_COMENT", cn))
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
