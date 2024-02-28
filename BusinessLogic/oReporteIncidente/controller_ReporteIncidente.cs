using BusinessLogic.oSendEmail;
using Presistence;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presistence.Customs;

namespace BusinessLogic.oReporteIncidente
{
    public class controller_ReporteIncidente
    {
        private static controller_ReporteIncidente Instance = null;
        public static controller_ReporteIncidente Get_Instance()
        {
            return Instance == null ? Instance = new controller_ReporteIncidente() : Instance;
        }

        public string Get_Codigo_Generado()
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                string codigoGenerado = "";
                int cant = obj.CodigoGenerado.Count();
                if (cant == 0)
                {
                    codigoGenerado = "1";
                }
                else
                {

                    string max = Get_GenerarCodigo(); // obj.CodigoGenerado.Max(m => m.Generado_Id);
                    max = (int.Parse(max) + 1).ToString();
                    codigoGenerado = max;
                }
                try
                {
                    CodigoGenerado cod = new CodigoGenerado();
                    cod.Generado_Id = codigoGenerado;
                    cod.Fecha = DateTime.Now;
                    obj.AddToCodigoGenerado(cod);
                    obj.SaveChanges();
                    return codigoGenerado;
                }
                catch (Exception ex)
                {
                    string erro = ex.Message;
                    return "";
                }
            }
        }
        public bool Get_Delete_DatosCodigoGenerado()
        {
            using (ContextMaestro obj = new ContextMaestro())
            {

                return true;
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

        //ELIMINAR TODOS LOS DATOS AL CANCELAR 

        public bool Eliminar_Datos_Logicos(string Generado_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {

                //DELETE CODIGO GENERADO 

                string cmd = "DELETE CodigoGenerado WHERE Generado_Id='" + Generado_Id + "'";
                obj.ExecuteStoreCommand(cmd);
                cmd = "DELETE File_Incidencia WHERE Codigo_Gen='" + Generado_Id + "'";
                obj.ExecuteStoreCommand(cmd);
                cmd = "DELETE CausaReporte_Detalle WHERE Incidente_Id='" + Generado_Id + "'";
                obj.ExecuteStoreCommand(cmd);
                return true;
            }
        }


        //REGISTRAR EL REPORTE

        public string Registrar_ReporteIncidencia(
        string Personal_Registro, string Area_Id, string Categoria_Auxiliar_Id
        , string Categoria_Auxiliar2_Id, string Actividad_Propia, string Actividad_Rutinaria, string Intensidad_Id, string Descripcion
        , string Informar_Gerencia, string Informar_Osigermin, DateTime FechaHora_Incidente, string Lugar_Incidente, string Tipo, string Origen, string Severidad_Id
        , string LesionesPerdidas, string PosiblesCausas
        , string AccionInmediata, string Generado_Id, string TipoI_Id, string Afec_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                string Incidente_Id = Get_PrimaryKey_Reporte();
                try
                {
                    int existe = obj.ReporteIncidente.Where(x => x.Incidente_Id == Incidente_Id).Count();
                    if (existe == 0)
                    {
                        //string FEC=DateTime.Parse(FechaHora_Incidente).ToString();
                        ReporteIncidente rep = new ReporteIncidente();
                        rep.Incidente_Id = Incidente_Id;
                        rep.Personal_Registro = Personal_Registro;
                        rep.Area_Id = Area_Id;
                        rep.Categoria_Auxiliar_Id = Categoria_Auxiliar_Id;
                        rep.Categoria_Auxiliar2_Id = Categoria_Auxiliar2_Id;
                        rep.Actividad_Propia = Actividad_Propia;
                        rep.Actividad_Rutinaria = Actividad_Rutinaria;
                        rep.Intensidad_Id = Intensidad_Id;
                        rep.Descripcion = Descripcion;
                        rep.Informar_Gerencia = Informar_Gerencia;
                        rep.Informar_Osigermin = Informar_Osigermin;
                        rep.FechaHora_Incidente = FechaHora_Incidente;// DateTime.Parse(FEC);
                        rep.FechaHora_Reporte = DateTime.Now;
                        rep.Lugar_Incidente = Lugar_Incidente;
                        rep.Tipo = Tipo;
                        rep.Origen = Origen;
                        rep.Severidad_Id = Severidad_Id;
                        rep.LesionesPerdidas = LesionesPerdidas;
                        rep.PosiblesCausas = PosiblesCausas;
                        rep.AccionInmediata = AccionInmediata;
                        rep.Estado_Id = "04";
                        rep.SendMailGerencia = "00";
                        rep.SendFinal = "00";
                        rep.SendPreliminar = "00";
                        rep.TipoI_Id = TipoI_Id;
                        rep.Afec_Id = Afec_Id;

                        obj.AddToReporteIncidente(rep);
                        obj.SaveChanges();

                        string cmd = "DELETE CodigoGenerado WHERE Generado_Id='" + Generado_Id + "'";
                        obj.ExecuteStoreCommand(cmd);
                        cmd = "UPDATE File_Incidencia SET Incidente_Id='" + Incidente_Id + "' WHERE Codigo_Gen='" + Generado_Id + "'";
                        obj.ExecuteStoreCommand(cmd);

                        cmd = "UPDATE File_Incidencia SET Codigo_Gen='00' WHERE Incidente_Id='" + Incidente_Id + "'";
                        obj.ExecuteStoreCommand(cmd);


                        cmd = "UPDATE CausaReporte_Detalle SET Incidente_Id='" + Incidente_Id + "' WHERE Incidente_Id='" + Generado_Id + "'";
                        obj.ExecuteStoreCommand(cmd);

                        return "true#Registrado Correctamente.#" + Incidente_Id;
                    }
                    else
                    {
                        return "false#.::Error, Intentelo nuevamente.";
                    }
                }
                catch (Exception ex)
                {
                    int existe = obj.ReporteIncidente.Where(x => x.Incidente_Id == Incidente_Id).Count();
                    if (existe == 1)
                    {
                        ReporteIncidente reDelete = obj.ReporteIncidente.Where(x => x.Incidente_Id == Incidente_Id).First();
                        obj.DeleteObject(reDelete);
                        obj.SaveChanges();
                    }
                    return "false#" + ex.Message;
                }
            }
        }




        public string Actualizar_ReporteIncidencia(string Incidente_Id, string Personal_Registro, string Area_Id, string Categoria_Auxiliar_Id
        , string Categoria_Auxiliar2_Id, string Actividad_Propia, string Actividad_Rutinaria, string Intensidad_Id
        , string Informar_Gerencia, string FechaHora_Incidente, string Lugar_Incidente, string Tipo, string Severidad_Id
        , string LesionesPerdidas, string PosiblesCausas
        , string AccionInmediata)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                try
                {

                    int existe = obj.ReporteIncidente.Where(x => x.Incidente_Id == Incidente_Id).Count();
                    if (existe == 1)
                    {
                        ReporteIncidente rep = new ReporteIncidente();
                        rep.Incidente_Id = Incidente_Id;
                        rep.Actividad_Propia = Actividad_Propia;
                        rep.Actividad_Rutinaria = Actividad_Rutinaria;
                        rep.Intensidad_Id = Intensidad_Id;
                        rep.Informar_Gerencia = Informar_Gerencia;
                        rep.FechaHora_Incidente = DateTime.Parse(FechaHora_Incidente);
                        rep.Lugar_Incidente = Lugar_Incidente;
                        rep.Tipo = Tipo;
                        rep.Severidad_Id = Severidad_Id;
                        rep.LesionesPerdidas = LesionesPerdidas;
                        rep.PosiblesCausas = PosiblesCausas;
                        rep.AccionInmediata = AccionInmediata;
                        obj.SaveChanges();
                        return "true#Actualizado Correctamente.";
                    }
                    else
                    {
                        return "false#.::Error, Intentelo nuevamente.";
                    }
                }
                catch (Exception ex)
                {
                    return "false#" + ex.Message;
                }
            }

        }

        public bool Add_Accion_Correctiva(string Incidente_Id, string Descripcion, string Tipo_Responsable
            , string Responsable_Id, DateTime FechaIni, DateTime FechaFin)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                string Accion_Id = Get_PrimaryKey_Accion(Incidente_Id);
                int exist = obj.AccionCorrectiva.Where(x => x.Accion_Id == Accion_Id && x.Incidente_Id == Incidente_Id).Count();
                if (exist == 0)
                {

                    //string fi = DateTime.Parse(FechaIni).ToString();
                    //string ff = DateTime.Parse(FechaFin).ToString();

                    AccionCorrectiva acc = new AccionCorrectiva();
                    acc.Accion_Id = Accion_Id;
                    acc.Incidente_Id = Incidente_Id;
                    acc.Descripcion = Descripcion;
                    acc.Tipo_Responsable = Tipo_Responsable;
                    acc.Responsable_Id = Responsable_Id;
                    acc.FechaIni = FechaIni; //DateTime.Parse(fi);
                    acc.FechaFin = FechaFin; //DateTime.Parse(ff);
                    acc.Estado_Id = "03";
                    obj.AddToAccionCorrectiva(acc);
                    obj.SaveChanges();
                    return true;
                }
                return false;
            }

        }


        public bool Get_Informar_Gerencia(string Intensidad_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int cant = obj.Intensidad.Where(x => x.Intensidad_Id == Intensidad_Id && x.ReportarGerencia == "01").Count();
                if (cant > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool Get_Correos_Gerencia(string Area_Id)
        {

            using (ContextMaestro obj = new ContextMaestro())
            {
                int cant = obj.Gerentes.Where(x => x.Estado == "01").Count();
                if (cant > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public string Get_PrimaryKey_Reporte()
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int cant = obj.ReporteIncidente.Count();
                if (cant == 0)
                {
                    return "000001";
                }
                else
                {
                    string max = obj.ReporteIncidente.Max(m => m.Incidente_Id);
                    max = (int.Parse(max) + 1).ToString().PadLeft(6, '0');
                    return max;
                }

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

        public string Get_Add_CausaReporte_Detalle(string Incidente_Id, string Causa_Id, string Tipo)
        {
            try
            {
                using (ContextMaestro obj = new ContextMaestro())
                {
                    int existe = obj.CausaReporte_Detalle.Where(x => x.Incidente_Id == Incidente_Id && x.Causa_Id == Causa_Id).Count();
                    if (existe == 0)
                    {
                        CausaReporte_Detalle crd = new CausaReporte_Detalle();
                        crd.Incidente_Id = Incidente_Id;
                        crd.Causa_Id = Causa_Id;
                        crd.Tipo = Tipo;
                        obj.AddToCausaReporte_Detalle(crd);
                        obj.SaveChanges();
                        return "true#Registrado Correctamente.";
                    }
                    else
                    {
                        return "false#.::Error > La causa ya esta registrada intentelo luego.";
                    }

                }
            }
            catch (Exception ex)
            {
                return "false#.::Error > " + ex.Message;

            }
        }
        public string Get_Delete_CausaReporte_Detalle(string Incidente_Id, string Causa_Id)
        {
            try
            {
                using (ContextMaestro obj = new ContextMaestro())
                {
                    int existe = obj.CausaReporte_Detalle.Where(x => x.Incidente_Id == Incidente_Id && x.Causa_Id == Causa_Id).Count();
                    if (existe == 1)
                    {
                        CausaReporte_Detalle crd = obj.CausaReporte_Detalle.Where(x => x.Incidente_Id == Incidente_Id && x.Causa_Id == Causa_Id).First();
                        obj.DeleteObject(crd);
                        obj.SaveChanges();
                        return "true#Eliminado Correctamente.";
                    }
                    else
                    {
                        return "false#.::Error > La causa no a sido encontrado intentelo luego.";
                    }

                }
            }
            catch (Exception ex)
            {
                return "false#.::Error > " + ex.Message;

            }
        }

        public ArrayList Get_Reg_CausaReporte_Detalle_List(string Incidente_Id, string Tipo)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                ArrayList rList = new ArrayList();

                var query = from cr in obj.CausaReporte_Detalle
                            join ca in obj.CausaIncidente on cr.Causa_Id equals ca.Causa_Id
                            where cr.Incidente_Id == Incidente_Id
                            && cr.Tipo == Tipo
                            select new
                            {
                                cr.Incidente_Id,
                                cr.Causa_Id,
                                ca.Causa_Name,
                                ca.Descripcion
                            };

                rList.AddRange(query.OrderBy(o => o.Causa_Name).ToList());
                return rList;
            }
        }

        #region ENVIO DE CORREOS

        public string EnviarCorreoGerencia_RegistroReporte(string Incidente_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {

                ReporteIncidente rep = obj.ReporteIncidente.Where(x => x.Incidente_Id == Incidente_Id).First();
                string mensaje = "";
                if (rep.Informar_Gerencia == "01")
                {
                    string respuest = EnviarCorreo_Gerencia(Incidente_Id, rep.Area_Id);
                    string st = respuest.Split('#')[0].ToString();
                    mensaje = " Gerencia : " + respuest.Split('#')[1].ToString();
                    string semens = "";
                    if (st == "true")
                    {
                        semens = "01";
                    }
                    else
                    {
                        semens = "02";
                    }
                    int exi = obj.ReporteIncidente.Where(x => x.Incidente_Id == Incidente_Id).Count();

                    ReporteIncidente reSend = obj.ReporteIncidente.Where(x => x.Incidente_Id == Incidente_Id).First();
                    if (exi == 1)
                    {
                        reSend.SendMailGerencia = semens;
                        obj.SaveChanges();
                    }
                    return mensaje;
                }
                return "NO";
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
                    string correos = "";
                    string body = Get_BodyHTML_Gerencia(Incidente_Id);
                    for (int i = 0; i <= rCorreos.Count - 1; i++)
                    {
                        correos += rCorreos[i] + ";";
                    }
                    if (correos.Trim() != "")
                    {
                        correos = correos.Remove(correos.Length - 1);
                        return controller_SendEmail.Get_Instance().SendMail_SMTP(correos, "REPORTE DE INCIDENCIA", body);
                    }
                    else
                    {
                        return "false#.::Error > No se encontro ningun correo - Gerentes.";
                    }

                }
            }
        }
        public string Get_BodyHTML_Gerencia(string Incidente_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.getConexion()))
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
        //20190116
        private string Get_GenerarCodigo()
        {
            using (SqlConnection cn = new SqlConnection(Conexion.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT MAX(Generado_Id) FROM CodigoGenerado ", cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    return cmd.ExecuteScalar().ToString();
                }

            }
        }
        public string Get_SendCorreo_Administradores(string Incidente_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {

                ReporteIncidente rep = obj.ReporteIncidente.Where(x => x.Incidente_Id == Incidente_Id).First();
                string mensaje = "";

                string respuest = EnviarCorreo_Administracion(Incidente_Id);
                string st = respuest.Split('#')[0].ToString();
                mensaje = " Administración : " + respuest.Split('#')[1].ToString();
                string semens = "";
                if (st == "true")
                {
                    semens = "01";
                }
                else
                {
                    semens = "02";
                }
                int exi = obj.ReporteIncidente.Where(x => x.Incidente_Id == Incidente_Id).Count();

                ReporteIncidente reSend = obj.ReporteIncidente.Where(x => x.Incidente_Id == Incidente_Id).First();
                if (exi == 1)
                {
                    reSend.SendMailGerencia = semens;
                    obj.SaveChanges();
                }
                return mensaje;


            }
        }
        public string EnviarCorreo_Administracion(string Incidente_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                List<string> rCorreos = new List<string>();
                rCorreos.AddRange(obj.Personal.Where(x => x.Estado_Id == "01" && x.RolSistema == "01").Select(s => s.email).ToList());
                if (rCorreos.Count == 0)
                {
                    return "false#.::Error no se encontro a ningun Administrador Activo .";
                }
                else
                {
                    string correos = "";
                    string body = Get_BodyHTML_Administracion(Incidente_Id);
                    for (int i = 0; i <= rCorreos.Count - 1; i++)
                    {
                        correos += rCorreos[i] + ";";
                    }
                    correos = correos.Remove(correos.Length - 1);
                    return controller_SendEmail.Get_Instance().SendMail_SMTP(correos, "NUEVA INCIDENCIA", body);
                }
            }
        }
        public string Get_BodyHTML_Administracion(string Incidente_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("GET_HTML_EMAIL_ADMINISTRACION", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Incidencia_Id", Incidente_Id);
                    cn.Open();
                    return cmd.ExecuteScalar().ToString();
                }

            }
        }

        #endregion

        #region ARCHIVOS

        public List<File_Incidencia> Get_Files_List(string Cogido_Gen)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                return obj.File_Incidencia.Where(x => x.Codigo_Gen == Cogido_Gen).OrderBy(o => o.File_NameI).ToList();
            }
        }

        public List<File_Incidencia> Get_Files_List_Indicencia(string Incidencia_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                return obj.File_Incidencia.Where(x => x.Incidente_Id == Incidencia_Id).OrderBy(o => o.File_NameI).ToList();
            }
        }

        public bool Get_Add_DataFile(string Codigo_Gen, string File_NameI, string File_URL)
        {

            using (ContextMaestro obj = new ContextMaestro())
            {
                string FileI_Id = Get_Primary_Key_Gen(Codigo_Gen), Incidente_Id = "00000";
                int existe = obj.File_Incidencia.Where(x => x.FileI_Id == FileI_Id && x.Incidente_Id == Incidente_Id && x.Codigo_Gen == Codigo_Gen).Count();
                if (existe == 0)
                {
                    File_Incidencia fi = new File_Incidencia();
                    fi.FileI_Id = FileI_Id;
                    fi.Incidente_Id = Incidente_Id;
                    fi.Codigo_Gen = Codigo_Gen;
                    fi.File_NameI = File_NameI;
                    fi.File_URL = File_URL;
                    fi.Fecha_Registro = DateTime.Now;
                    obj.AddToFile_Incidencia(fi);
                    obj.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool Get_Add_DataFile_Inc(string Incidente_Id, string File_NameI, string File_URL)
        {

            using (ContextMaestro obj = new ContextMaestro())
            {
                string FileI_Id = Get_Primary_Key(Incidente_Id), Codigo_Gen = "00";
                int existe = obj.File_Incidencia.Where(x => x.FileI_Id == FileI_Id && x.Incidente_Id == Incidente_Id && x.Codigo_Gen == Codigo_Gen).Count();
                if (existe == 0)
                {
                    File_Incidencia fi = new File_Incidencia();
                    fi.FileI_Id = FileI_Id;
                    fi.Incidente_Id = Incidente_Id;
                    fi.Codigo_Gen = Codigo_Gen;
                    fi.File_NameI = File_NameI;
                    fi.File_URL = File_URL;
                    fi.Fecha_Registro = DateTime.Now;
                    obj.AddToFile_Incidencia(fi);
                    obj.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public bool Get_Delte_DataFile_Generado(string FileI_Id, string Codigo_Gen)
        {

            using (ContextMaestro obj = new ContextMaestro())
            {
                string Incidente_Id = "00000";
                int existe = obj.File_Incidencia.Where(x => x.FileI_Id == FileI_Id && x.Incidente_Id == Incidente_Id && x.Codigo_Gen == Codigo_Gen).Count();
                if (existe == 1)
                {
                    File_Incidencia fi = obj.File_Incidencia.Where(x => x.FileI_Id == FileI_Id && x.Incidente_Id == Incidente_Id && x.Codigo_Gen == Codigo_Gen).First();
                    obj.DeleteObject(fi);
                    obj.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public File_Incidencia Get_Find_File(string FileI_Id, string Codigo_Gen)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                string Incidente_Id = "00000";
                int existe = obj.File_Incidencia.Where(x => x.FileI_Id == FileI_Id && x.Incidente_Id == Incidente_Id && x.Codigo_Gen == Codigo_Gen).Count();
                if (existe == 1)
                {
                    return obj.File_Incidencia.Where(x => x.FileI_Id == FileI_Id && x.Incidente_Id == Incidente_Id && x.Codigo_Gen == Codigo_Gen).First();
                }
                return null;
            }

        }
        public File_Incidencia Get_Find_File_Incidencia(string FileI_Id, string Incidente_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                string Codigo_Gen = "00";
                int existe = obj.File_Incidencia.Where(x => x.FileI_Id == FileI_Id && x.Incidente_Id == Incidente_Id && x.Codigo_Gen == Codigo_Gen).Count();
                if (existe == 1)
                {
                    return obj.File_Incidencia.Where(x => x.FileI_Id == FileI_Id && x.Incidente_Id == Incidente_Id && x.Codigo_Gen == Codigo_Gen).First();
                }
                return null;
            }

        }
        public bool Get_Delte_DataFile(string FileI_Id, string Incidente_Id)
        {

            using (ContextMaestro obj = new ContextMaestro())
            {
                string Codigo_Gen = "00";
                int existe = obj.File_Incidencia.Where(x => x.FileI_Id == FileI_Id && x.Incidente_Id == Incidente_Id && x.Codigo_Gen == Codigo_Gen).Count();
                if (existe == 1)
                {
                    File_Incidencia fi = obj.File_Incidencia.Where(x => x.FileI_Id == FileI_Id && x.Incidente_Id == Incidente_Id && x.Codigo_Gen == Codigo_Gen).First();
                    obj.DeleteObject(fi);
                    obj.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public string Get_Primary_Key(string Incidente_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int cant = obj.File_Incidencia.Where(x => x.Incidente_Id == Incidente_Id).Count();
                if (cant == 0)
                {
                    return "001";
                }
                else
                {
                    string max = obj.File_Incidencia.Where(x => x.Incidente_Id == Incidente_Id).Max(m => m.FileI_Id);
                    max = (int.Parse(max) + 1).ToString().PadLeft(3, '0');
                    return max;
                }
            }
        }
        public string Get_Primary_Key_Gen(string CodGen)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int cant = obj.File_Incidencia.Where(x => x.Codigo_Gen == CodGen).Count();
                if (cant == 0)
                {
                    return "001";
                }
                else
                {
                    string max = obj.File_Incidencia.Where(x => x.Codigo_Gen == CodGen).Max(m => m.FileI_Id);
                    max = (int.Parse(max) + 1).ToString().PadLeft(3, '0');
                    return max;
                }
            }
        }
        #endregion

        #region DATOS DEL USUARIO

        public string Get_LocalidadyArea(string Area_Id, string Area_Id2)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                string localidad = "";
                int existe = obj.RH_Area.Where(x => x.Area_Id == Area_Id).Count();
                if (existe == 1)
                {
                    localidad = "Localidad : " + obj.RH_Area.Where(x => x.Area_Id == Area_Id).First().Descripcion;
                }
                else
                {
                    return "Error, no se encontro la localidad del usuario.";
                }
                return localidad;
            }
        }

        #endregion
    }
}

