using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using PersistenceI;
using BusinessLogic.oSendEmail;
using Persistence.eConexion;

namespace BusinessLogic.oEditReporteIncidente
{
    public class controller_EditReporteIncidente
    {
        private static controller_EditReporteIncidente Instance = null;
        public static controller_EditReporteIncidente Get_Instance() {
            return Instance == null ? Instance = new controller_EditReporteIncidente() : Instance;
        }

        public ArrayList Get_Find_ReporteIncidente(string Incidente_Id)
        { 
            using(ContextMaestro obj=new ContextMaestro()){
                ArrayList rList = new ArrayList();
                var query = from r in obj.ReporteIncidente
                            join p in obj.Personal on r.Personal_Registro equals p.Personal_Id
                            join l in obj.RH_Area on r.Area_Id equals l.Area_Id
                            join c1 in obj.Categoria_Auxiliar on r.Categoria_Auxiliar_Id equals c1.Categoria_Auxiliar_Id
                            join c2 in obj.Categoria_Auxiliar2 on r.Categoria_Auxiliar2_Id equals c2.Categoria_Auxiliar2_Id into ljoin
                            from rc2 in ljoin.DefaultIfEmpty()
                            join i in obj.Intensidad on r.Intensidad_Id equals i.Intensidad_Id
                            join s in obj.Severidad on r.Severidad_Id equals s.Severidad_Id
                            join t in obj.Tipo on r.Tipo equals t.Tipo_Id
                            join o in obj.Origen on r.Origen equals o.Origen_Id
                            where r.Incidente_Id == Incidente_Id
                            select new { 
                                r.Incidente_Id,
                                PersonalReg= p.Apellido_Paterno+" "+p.Apellido_Materno+", "+p.Nombres,
                                RH_Area = l.Descripcion,
                                r.Area_Id,
                                Cat1=c1.Descripcion,
                                Cat2 = rc2.Categoria_Auxiliar2_Id == null ? "" : rc2.Descripcion,
                                ActProp=r.Actividad_Propia,
                                ActRut=r.Actividad_Rutinaria,
                                Intensidad=i.Descripcion,
                                Descripcion=r.Descripcion,
                                InfoGenrencia=r.Informar_Gerencia,
                                InfoOsigermin=r.Informar_Osigermin,
                                FHInc=r.FechaHora_Incidente,
                                FHRep=r.FechaHora_Reporte,
                                Lugar=r.Lugar_Incidente,
                                Tipo=t.Descripcion,
                                Origen=o.Descripcion,
                                Severidad=s.Descripcion,
                                LesionesPer=r.LesionesPerdidas,
                                PosCausas=r.PosiblesCausas,
                                AccInmediata=r.AccionInmediata,
                                Estado=r.Estado_Id                            
                            };
                rList.AddRange(query.ToList());
                return rList;          
            }
        }
        public ArrayList Get_AccionCorrectiva_List(string Incidente_Id)
        { 
            using(ContextMaestro obj=new ContextMaestro()){
                ArrayList rList = new ArrayList();
                var query = from a in obj.AccionCorrectiva
                            join r in obj.Personal on a.Responsable_Id equals r.Personal_Id
                            where a.Incidente_Id == Incidente_Id
                            select new {
                                a.Accion_Id,
                                a.Incidente_Id,
                                a.Descripcion,
                                a.Tipo_Responsable,
                                ResponsableName=r.Apellido_Paterno+" "+r.Apellido_Materno+", "+r.Nombres,
                                a.Responsable_Id,
                                a.FechaIni,
                                a.FechaFin,
                                a.Estado_Id
                            };

                rList.AddRange(query.ToList());
                return rList;
            }
        }
        public List<File_Incidencia> Get_Files_Incidencia_List(string Incidente_Id)
        { 
            using(ContextMaestro obj=new ContextMaestro()){
                return obj.File_Incidencia.Where(x => x.Incidente_Id == Incidente_Id).ToList();
            }
        }
        public AccionCorrectiva Get_Find_AccionCorrectiva(string Incidente_Id, string Accion_Id)
        { 
            using(ContextMaestro obj=new ContextMaestro()){
                int existe = obj.AccionCorrectiva.Where(x => x.Incidente_Id == Incidente_Id && x.Accion_Id == Accion_Id).Count();
                if (existe == 1) {
                    return obj.AccionCorrectiva.Where(x => x.Incidente_Id == Incidente_Id && x.Accion_Id == Accion_Id).First();
                }
                return null;
            }        
        }
        public List<Personal> Get_DataList_Responsable(string Nombres, string Usuario, string Area_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                var query = from p in obj.Personal
                            where p.Personal_Id != Usuario
                            && (p.Apellido_Paterno.Trim() + p.Apellido_Materno.Trim() + p.Nombres.Trim()).Contains(Nombres)
                            //&& p.Area_Id.Contains(Area_Id)
                            && p.Estado_Id == "01"
                            select p;

                return query.ToList();

            }
        }
        public string Get_Aprobrar_Accion(string Incidente_Id, string Accion_Id)
        {
            try
            {

                using(ContextMaestro obj=new ContextMaestro()){
                    int exist = obj.AccionCorrectiva.Where(x => x.Incidente_Id == Incidente_Id && x.Accion_Id == Accion_Id).Count();
                    if (exist == 1)
                    {

                        AccionCorrectiva acc = obj.AccionCorrectiva.Where(x => x.Incidente_Id == Incidente_Id && x.Accion_Id == Accion_Id).First();
                        acc.Estado_Id = "01";
                        obj.SaveChanges();
                        return "true#Aprobado correctamente.";
                    }
                    else {

                        return "false#.::Error, Intentelo nuevamente.";
                    }
                
                }

            }
            catch (Exception ex) {
                return "false#" + ex.Message;
            }
        }
        public string Get_Desaprobrar_Accion(string Incidente_Id, string Accion_Id)
        {
            try
            {

                using (ContextMaestro obj = new ContextMaestro())
                {
                    int exist = obj.AccionCorrectiva.Where(x => x.Incidente_Id == Incidente_Id && x.Accion_Id == Accion_Id).Count();
                    if (exist == 1)
                    {

                        AccionCorrectiva acc = obj.AccionCorrectiva.Where(x => x.Incidente_Id == Incidente_Id && x.Accion_Id == Accion_Id).First();
                        acc.Estado_Id = "02";
                        obj.SaveChanges();
                        return "true#Desaprobado correctamente.";
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
        public string Add_Accion_Correctiva(string Incidente_Id, string Descripcion, string Tipo_Responsable
            , string Responsable_Id, DateTime FechaIni, DateTime FechaFin)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                string Accion_Id = Get_PrimaryKey_Accion(Incidente_Id);
                int exist = obj.AccionCorrectiva.Where(x => x.Accion_Id == Accion_Id && x.Incidente_Id == Incidente_Id).Count();
                if (exist == 0)
                {

                    /*string fi = DateTime.Parse(FechaIni).ToString();
                    string ff = DateTime.Parse(FechaFin).ToString();*/

                    AccionCorrectiva acc = new AccionCorrectiva();
                    acc.Accion_Id = Accion_Id;
                    acc.Incidente_Id = Incidente_Id;
                    acc.Descripcion = Descripcion;
                    acc.Tipo_Responsable = Tipo_Responsable;
                    acc.Responsable_Id = Responsable_Id;
                    acc.FechaIni = FechaIni;// DateTime.Parse(fi);
                    acc.FechaFin = FechaFin;// DateTime.Parse(ff);
                    acc.Estado_Id = "03";
                    obj.AddToAccionCorrectiva(acc);
                    obj.SaveChanges();
                    return "true#Registrado Correctamente.";
                }
                return "false#.::Error, Intentelo nuevamente.";
            }

        }
        public string Get_PrimaryKey_Accion(string Incidente_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int cant = obj.AccionCorrectiva.Where(x => x.Incidente_Id == Incidente_Id).Count();
                if (cant == 0)
                {
                    return "001";
                }
                else
                {
                    string max = obj.AccionCorrectiva.Where(x => x.Incidente_Id == Incidente_Id).Max(m => m.Accion_Id);
                    max = (int.Parse(max) + 1).ToString().PadLeft(3, '0');
                    return max;
                }

            }
        }

        public string Get_Update_AccionCorrectiva(string Incidente_Id,string Accion_Id , string Descripcion, string Tipo_Responsable
            , string Responsable_Id, string FechaIni, string FechaFin)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {                
                int exist = obj.AccionCorrectiva.Where(x => x.Accion_Id == Accion_Id && x.Incidente_Id == Incidente_Id).Count();
                if (exist == 1)
                {
                    string fi = DateTime.Parse(FechaIni).ToString();
                    string ff = DateTime.Parse(FechaFin).ToString();

                    AccionCorrectiva acc = obj.AccionCorrectiva.Where(x => x.Accion_Id == Accion_Id && x.Incidente_Id == Incidente_Id).First();
                    acc.Descripcion = Descripcion;
                    acc.Tipo_Responsable = Tipo_Responsable;
                    acc.Responsable_Id = Responsable_Id;
                    acc.FechaIni = DateTime.Parse(fi);
                    acc.FechaFin = DateTime.Parse(ff);                                      
                    obj.SaveChanges();
                    return "true#Actualizado Correctamente.";
                }
                return "false#.::Error, Intentelo nuevamente.";
            }

        }

        public string Get_AprobarReporte(string Incidente_Id) { 
            try{
                  using(ContextMaestro obj=new ContextMaestro()){

                      int existe = obj.ReporteIncidente.Where(x => x.Incidente_Id == Incidente_Id).Count();
                      if (existe == 1)
                      {

                          int existeAcciones = obj.AccionCorrectiva.Where(x => x.Incidente_Id == Incidente_Id && x.Estado_Id == "01").Count();
                          if (existeAcciones == 0) {
                              return "false#.::Error, No se encontro alguna Acción Correctiva Aprobada.";
                          }
                          ReporteIncidente rep = obj.ReporteIncidente.Where(x => x.Incidente_Id == Incidente_Id).First();
                          rep.Estado_Id = "03";
                          obj.SaveChanges();
                          EnviarCorreoReporteAprobado(Incidente_Id);

                          string infGern = obj.ReporteIncidente.Where(x => x.Incidente_Id == Incidente_Id).First().Informar_Gerencia;
                          string area_id = obj.ReporteIncidente.Where(x => x.Incidente_Id == Incidente_Id).First().Area_Id;
                          string respuestasendmailGerencia="";
                          if (infGern == "01")
                          {
                              respuestasendmailGerencia = EnviarCorreo_Gerencia(Incidente_Id, area_id);
                          }
                          string respuestasendemail = SendEmail_ByResponsable(Incidente_Id);
                          return "true#En hora buena, el Reporte esta aprobada y entra en curso.\n Gerencia :" + respuestasendmailGerencia + "\n Responsables : "+respuestasendemail;
                      }
                      else {
                          return "false#.::Error, Intentelo nuevamente.";
                      }

                  }
            
            }catch(Exception ex){
                return "false#" + ex.Message;
            }
        }

        void EnviarCorreoReporteAprobado(string Incidente_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                List<string> rCorreos = new List<string>();              
                rCorreos.AddRange(obj.Personal.Where(x => x.Estado_Id == "01" && x.RolSistema == "01").Select(s => s.email).ToList());

                string UsuariReg = obj.ReporteIncidente.Where(x => x.Incidente_Id == Incidente_Id).First().Personal_Registro;
                rCorreos.AddRange(obj.Personal.Where(x => x.Estado_Id == "01" && x.Personal_Id == UsuariReg).Select(s => s.email).ToList());

                string correos = "";
                string body = Get_BodyHTML_Gerencia(Incidente_Id);
                for (int i = 0; i <= rCorreos.Count - 1; i++)
                {
                    if (rCorreos[i].Trim() != "")
                    {
                        correos += rCorreos[i] + ";";
                    }
                }
                if (correos != "")
                {
                    correos = correos.Remove(correos.Length - 1);
                    controller_SendEmail.Get_Instance().SendMail_SMTP(correos, "REPORTE DE INCIDENCIA - EN CURSO", body);
                }
            }
        }


        public string EnviarCorreo_Gerencia(string Incidente_Id, string Area_Id)
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
                    string body = Get_BodyHTML_Gerencia(Incidente_Id);
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
                            controller_SendEmail.Get_Instance().SendMail_SMTP(gList[i].Correo, "REPORTE DE INCIDENCIA - EN CURSO", boduMen);
                        }
                    }
                    return "true#Enviado Correctamente.";

                }
            }
        }
        public string Get_BodyHTML_Gerencia(string Incidente_Id)
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

        public string SendEmail_ByResponsable(string Incidente_Id)
        {
            try
            {
                using (ContextMaestro obj = new ContextMaestro())
                {

                    //GET RESPONSABLES 

                    List<string> resposanbles = new List<string>();


                    resposanbles.AddRange(
                        obj.AccionCorrectiva.Where(x => x.Incidente_Id == Incidente_Id && x.Estado_Id=="01").Select(s => s.Responsable_Id).Distinct().ToList()
                        );

                    int cont = 0;
                    for (int r = 0; r <= resposanbles.Count - 1; r++)
                    {
                        string responsable_id = resposanbles[r].ToString();
                        string body = Get_BodyHTML_IncidenciaResponsable(Incidente_Id, responsable_id);
                        string correo = obj.Personal.Where(x => x.Personal_Id == responsable_id).First().email;
                        if (correo.Trim() != "")
                        {
                            string ret=controller_SendEmail.Get_Instance().SendMail_SMTP(correo, "ACCIÓN CORRECTIVA", body);                            
                            bool pro = bool.Parse(ret.Split('#')[0].ToString());
                            if (pro == true) {
                                cont += 1;
                            }
                        }

                    }         
                    int enviaError =(cont- resposanbles.Count )*-1 ;
                    return cont.ToString() + " Enviados ; Cantidad de errores : " + enviaError.ToString();
                }
            }
            catch (Exception ex) {
                return ex.Message.ToString();
            }
        }
        public string Get_BodyHTML_IncidenciaResponsable(string Incidente_Id, string Responsable_Id)
        { 
            using(SqlConnection cn=new SqlConnection(conex.getConexion())){
                using (SqlCommand cmd = new SqlCommand("GET_HTML_ACCION_RESPONSABLE",cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Incidencia_Id", Incidente_Id);
                    cmd.Parameters.AddWithValue("@RESPONSABLE_ID", Responsable_Id);
                    cn.Open();
                    return cmd.ExecuteScalar().ToString();                
                }           

            }
        }
        
        public string Get_Estado_Reporte(string Incidencia_Id){
            using(ContextMaestro obj=new ContextMaestro()){
                int existe = obj.ReporteIncidente.Where(x => x.Incidente_Id == Incidencia_Id).Count();
                if (existe == 1) {
                    return obj.ReporteIncidente.Where(x => x.Incidente_Id == Incidencia_Id).First().Estado_Id;
                }
                return "";
            }
        }

        /*  ENVIAR CORREO OSIGERMIN */
        public string Send_CorreoOsigermin(string Tipo, string Incidente_Id) { 
            using(ContextMaestro obj=new ContextMaestro()){

                int existecorreo = obj.Parametros_Sistema.Where(x => x.Parametro_Id == 1).Count();
                if (existecorreo == 0) {
                    return "false#.::Error Correo de osigermin no encontrado.";
                }

                string correo = obj.Parametros_Sistema.Where(x => x.Parametro_Id == 1).First().Valor;
                if (correo.Trim() == "") {
                    return "false#.::Error Correo de osigermin no encontrado.";
                }
                return "true#Enviado Correctamente.";
            
            }
        }



    }
}
