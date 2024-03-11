using BusinessLogic.oSendEmail;
using Presistence;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using Presistence.Customs;

namespace BusinessLogic.oRepPendientes
{
    public class controller_RepPendientes
    {
        private static controller_RepPendientes Instance = null;
        public static controller_RepPendientes Get_Instance()
        {
            return Instance == null ? Instance = new controller_RepPendientes() : Instance;
        }

        public ArrayList Get_Acciones_Reporte(string Incidente_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                ArrayList rList = new ArrayList();

                var query = from r in obj.ReporteIncidente
                            join a in obj.AccionCorrectiva on r.Incidente_Id equals a.Incidente_Id
                            join p in obj.Personal on a.Responsable_Id equals p.Personal_Id
                            where r.Incidente_Id == Incidente_Id
                            && (a.Estado_Id == "01" || a.Estado_Id == "04" || a.Estado_Id == "05" || a.Estado_Id == "06")
                            select new
                            {
                                a.Accion_Id,
                                a.Estado_Id,
                                a.Descripcion,
                                Responsable = p.Apellido_Paterno + " " + p.Apellido_Materno + ", " + p.Nombres,
                                r.FechaHora_Incidente,
                                a.FechaFin,
                                Cant = (obj.File_Accion.Where(x => x.Incidente_Id == Incidente_Id && x.Accion_Id == a.Accion_Id).Count())
                            };

                rList.AddRange(query.ToList());
                return rList;
            }
        }
        public string Get_RealizarAccion(string Incidente_Id, string Accion_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int existefile = obj.File_Accion.Where(x => x.Incidente_Id == Incidente_Id && x.Accion_Id == Accion_Id).Count();
                if (existefile == 0)
                {
                    return "false#.::Error, No existen archivos de respaldo.";
                }

                int existe = obj.AccionCorrectiva.Where(x => x.Incidente_Id == Incidente_Id && x.Accion_Id == Accion_Id).Count();
                if (existe == 1)
                {
                    AccionCorrectiva acc = obj.AccionCorrectiva.Where(x => x.Incidente_Id == Incidente_Id && x.Accion_Id == Accion_Id).First();
                    acc.Estado_Id = "06";
                    obj.SaveChanges();
                    EnviarCorreoAccionRealizada(Incidente_Id, Accion_Id, "REPORTE DE INCIDENCIA - Accion Realizada");
                    return "true#Acción realizada correctamente.";
                }
                else
                {
                    return "false#.::Error, Intentelo nuevamente.";
                }
            }
        }

        void EnviarCorreoAccionRealizada(string Incidente_Id, string Accion_Id, string Subjet)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                List<string> rCorreos = new List<string>();


                rCorreos.AddRange(obj.Personal.Where(x => x.Estado_Id == "01" && x.RolSistema == "01").Select(s => s.email).ToList());

                string UsuariReg = obj.ReporteIncidente.Where(x => x.Incidente_Id == Incidente_Id).First().Personal_Registro;
                rCorreos.AddRange(obj.Personal.Where(x => x.Estado_Id == "01" && x.Personal_Id == UsuariReg).Select(s => s.email).ToList());

                string infGern = obj.ReporteIncidente.Where(x => x.Incidente_Id == Incidente_Id).First().Informar_Gerencia;
                if (infGern == "01")
                {
                    rCorreos.AddRange(obj.Gerentes.Where(x => x.Estado == "01").Select(s => s.Correo).ToList());
                }
                string correos = "";
                string body = Get_BodyHTML_AccionRealizada(Incidente_Id, Accion_Id);
                for (int i = 0; i <= rCorreos.Count - 1; i++)
                {
                    if (rCorreos[i].Trim() != "")
                    {
                        correos += rCorreos[i] + ";";
                    }
                }
                correos = correos.Remove(correos.Length - 1);
                controller_SendEmail.Get_Instance().SendMail_SMTP(correos, Subjet, body);
            }
        }
        public string Get_BodyHTML_AccionRealizada(string Incidente_Id, string Accion_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("GET_HTML_ACCION_REALIZADA", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Incidencia_Id", Incidente_Id);
                    cmd.Parameters.AddWithValue("@Accion_Id", Accion_Id);
                    cn.Open();
                    return cmd.ExecuteScalar().ToString();
                }

            }
        }


        void EnviarCorreoAccionRealizadaAMD(string Incidente_Id, string Accion_Id, string Subjet)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                List<string> rCorreos = new List<string>();




                string UsuariReg = obj.ReporteIncidente.Where(x => x.Incidente_Id == Incidente_Id).First().Personal_Registro;
                rCorreos.AddRange(obj.Personal.Where(x => x.Estado_Id == "01" && x.Personal_Id == UsuariReg).Select(s => s.email).ToList());

                string infGern = obj.ReporteIncidente.Where(x => x.Incidente_Id == Incidente_Id).First().Informar_Gerencia;
                if (infGern == "01")
                {
                    rCorreos.AddRange(obj.Gerentes.Where(x => x.Estado == "01").Select(s => s.Correo).ToList());
                }

                /* reponsables */

                string Responsable = obj.AccionCorrectiva.Where(x => x.Incidente_Id == Incidente_Id && x.Accion_Id == Accion_Id).First().Responsable_Id;
                rCorreos.AddRange(obj.Personal.Where(x => x.Estado_Id == "01" && x.Personal_Id == Responsable).Select(s => s.email).ToList());


                string correos = "";
                string body = Get_BodyHTML_AccionRealizada(Incidente_Id, Accion_Id);
                for (int i = 0; i <= rCorreos.Count - 1; i++)
                {
                    if (rCorreos[i].Trim() != "")
                    {
                        correos += rCorreos[i] + ";";
                    }
                }
                correos = correos.Remove(correos.Length - 1);
                controller_SendEmail.Get_Instance().SendMail_SMTP(correos, Subjet, body);
            }
        }

        public string Get_Aprobar_Accion_ADM(string Incidente_Id, string Accion_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int existefile = obj.File_Accion.Where(x => x.Incidente_Id == Incidente_Id && x.Accion_Id == Accion_Id).Count();
                if (existefile == 0)
                {
                    return "false#.::Error, No existen archivos de respaldo.";
                }

                int existe = obj.AccionCorrectiva.Where(x => x.Incidente_Id == Incidente_Id && x.Accion_Id == Accion_Id).Count();
                if (existe == 1)
                {
                    AccionCorrectiva acc = obj.AccionCorrectiva.Where(x => x.Incidente_Id == Incidente_Id && x.Accion_Id == Accion_Id).First();
                    acc.Estado_Id = "05";
                    obj.SaveChanges();
                    EnviarCorreoAccionRealizadaAMD(Incidente_Id, Accion_Id, "REPORTE DE INCIDENCIA - Accion Aprobada");
                    return "true#Acción realizada correctamente.";
                }
                else
                {
                    return "false#.::Error, Intentelo nuevamente.";
                }
            }
        }
        public string Get_Desaprobar_Accion_ADM(string Incidente_Id, string Accion_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int existefile = obj.File_Accion.Where(x => x.Incidente_Id == Incidente_Id && x.Accion_Id == Accion_Id).Count();
                if (existefile == 0)
                {
                    return "false#.::Error, No existen archivos de respaldo.";
                }

                int existe = obj.AccionCorrectiva.Where(x => x.Incidente_Id == Incidente_Id && x.Accion_Id == Accion_Id).Count();
                if (existe == 1)
                {
                    AccionCorrectiva acc = obj.AccionCorrectiva.Where(x => x.Incidente_Id == Incidente_Id && x.Accion_Id == Accion_Id).First();
                    acc.Estado_Id = "04";
                    obj.SaveChanges();
                    EnviarCorreoAccionRealizadaAMD(Incidente_Id, Accion_Id, "REPORTE DE INCIDENCIA - Accion Desaprobada");
                    return "true#Acción desaprobada correctamente.";
                }
                else
                {
                    return "false#.::Error, Intentelo nuevamente.";
                }
            }
        }

        //ARCHIVOS

        public List<File_Accion> Get_FilesAccion_List(string Incidente_Id, string Accion_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                return obj.File_Accion.Where(x => x.Incidente_Id == Incidente_Id && x.Accion_Id == Accion_Id).OrderBy(o => o.File_NameI).ToList();
            }
        }
        public bool Get_Add_FileAccion(string Incidente_Id, string Accion_Id, string File_NameI, string File_URL)
        {

            using (ContextMaestro obj = new ContextMaestro())
            {
                string FileA_Id = Get_Primary_Key_File(Incidente_Id, Accion_Id);
                int existe = obj.File_Accion.Where(x => x.FileA_Id == FileA_Id && x.Incidente_Id == Incidente_Id && x.Accion_Id == Accion_Id).Count();
                if (existe == 0)
                {
                    File_Accion fi = new File_Accion();
                    fi.FileA_Id = FileA_Id;
                    fi.Incidente_Id = Incidente_Id;
                    fi.Accion_Id = Accion_Id;
                    fi.File_NameI = File_NameI;
                    fi.File_URL = File_URL;
                    fi.Fecha_Registro = DateTime.Now;
                    obj.AddToFile_Accion(fi);
                    obj.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public bool Get_Delete_FileAccion(string Incidente_Id, string Accion_Id, string FileA_Id)
        {

            using (ContextMaestro obj = new ContextMaestro())
            {

                int existe = obj.File_Accion.Where(x => x.FileA_Id == FileA_Id && x.Incidente_Id == Incidente_Id && x.Accion_Id == Accion_Id).Count();
                if (existe == 1)
                {
                    File_Accion fi = obj.File_Accion.Where(x => x.FileA_Id == FileA_Id && x.Incidente_Id == Incidente_Id && x.Accion_Id == Accion_Id).First();
                    obj.DeleteObject(fi);
                    obj.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public File_Accion Get_Find_FileAccion(string Incidente_Id, string Accion_Id, string FileA_Id)
        {

            using (ContextMaestro obj = new ContextMaestro())
            {

                int existe = obj.File_Accion.Where(x => x.FileA_Id == FileA_Id && x.Incidente_Id == Incidente_Id && x.Accion_Id == Accion_Id).Count();
                if (existe == 1)
                {
                    return obj.File_Accion.Where(x => x.FileA_Id == FileA_Id && x.Incidente_Id == Incidente_Id && x.Accion_Id == Accion_Id).First();

                }
                return null;
            }
        }
        public string Get_Primary_Key_File(string Incidente_Id, string Accion_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int cant = obj.File_Accion.Where(x => x.Incidente_Id == Incidente_Id && x.Accion_Id == Accion_Id).Count();
                if (cant == 0)
                {
                    return "001";
                }
                else
                {
                    string max = obj.File_Accion.Where(x => x.Incidente_Id == Incidente_Id && x.Accion_Id == Accion_Id).Max(m => m.FileA_Id);
                    max = (int.Parse(max) + 1).ToString().PadLeft(3, '0');
                    return max;
                }
            }
        }

    }
}
