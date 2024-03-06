using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presistence;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Data.Objects;
namespace BusienssLogic.CA.oAprobarJustandPermRRHH
{
    public class controller_AprobarJustandPermRRHH
    {
        private static controller_AprobarJustandPermRRHH Instance = null;
        public static controller_AprobarJustandPermRRHH Get_Instance(){
            return Instance == null ? Instance = new controller_AprobarJustandPermRRHH() : Instance;
        }

        public ArrayList Get_Planilla_List()
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rList = new ArrayList();
                var query = from p in obj.Planilla
                            where p.Estado_Id == "01"
                            select new { p.Planilla_Id, p.Descripcion };
                rList.AddRange(query.ToList());
                return rList;
            }
        }
        public List<areas_planillas_sofya> Get_Localidad_List()
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                return obj.areas_planillas_sofya.Where(x => x.Area_Id != "14").ToList();
            }
        }
        public ArrayList Get_Categoria_List()
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rList = new ArrayList();
                var query = from c in obj.Categoria2
                            where c.Categoria2_Id == "01" || c.Categoria2_Id == "02" || c.Categoria2_Id == "00"
                            select new { c.Categoria2_Id, c.Descripcion };
                rList.AddRange(query.ToList());
                return rList;
            }
        }
        public ArrayList Get_Personal_List(string Planilla_Id, string Periodo, string Localidad_Id, string Categoria_Id)
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rList = new ArrayList();
                int existeperiodo = obj.Periodo.Where(x => x.Planilla_Id == Planilla_Id && x.Descripcion == Periodo).Count();
                string periodo_id = "";
                if (existeperiodo > 0)
                {
                    periodo_id = obj.Periodo.Where(x => x.Planilla_Id == Planilla_Id && x.Descripcion == Periodo).First().Periodo_Id;
                }
                if (periodo_id != "")
                {
                    var query = from p in obj.Personal
                                join pa in obj.Personal_activo on p.Personal_Id equals pa.Personal_Id
                                //join jp in obj.Jefe_Personal on pa.Personal_Id equals jp.Personal_Id
                                where pa.Periodo_Id == periodo_id
                                && pa.Area_Id.Contains(Localidad_Id)
                                && pa.Categoria2_Id.Contains(Categoria_Id)
                                select new
                                {
                                    p.Personal_Id,
                                    Personal = p.Apellido_Paterno + " " + p.Apellido_Materno + ", " + p.Nombres
                                };
                    rList.AddRange(query.OrderBy(x => x.Personal).ToList());
                    return rList;
                }
                else
                {
                    return null;
                }

            }
        }
        public Periodo_Asistencia Get_Periodo_Activo_Asistencia()
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                int existe = obj.Periodo_Asistencia.Where(x => x.Estado == true).Count();
                if (existe == 1)
                {
                    return obj.Periodo_Asistencia.Where(x => x.Estado == true).First();
                }
                else
                {
                    return null;
                }
            }
        }
        #region JUSTIFICACIONES

        public List<Justif> Get_Justificaciones_Pendientes_Jefe(string Personal_Id, DateTime FechaIni, DateTime FechaFin)
        {
            using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("Get_Justificaciones_Pendientes_RRHH_CA", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Personal_Id", Personal_Id);
                    cmd.Parameters.AddWithValue("@FechaIni", FechaIni);
                    cmd.Parameters.AddWithValue("@FechaFin", FechaFin);
                    ///cmd.CommandTimeout = 120;
                    cmd.CommandTimeout = 0;
                    List<Justif> rList = new List<Justif>();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Justif mar = new Justif();
                        mar.Solicitado = dr.GetValue(1).ToString();
                        mar.Estado = dr.GetValue(2).ToString();
                        mar.Realizado = dr.GetValue(3).ToString();
                        mar.Asistencia_Id = dr.GetValue(4).ToString();
                        mar.Personal_Id = dr.GetValue(5).ToString();
                        mar.Personal = dr.GetValue(6).ToString();
                        mar.FechaMarc = dr.GetValue(7).ToString();
                        mar.Dia = dr.GetValue(8).ToString();
                        mar.HIH = dr.GetValue(9).ToString();
                        mar.HFH = dr.GetValue(10).ToString();
                        mar.HIM = dr.GetValue(11).ToString();
                        mar.HSM = dr.GetValue(12).ToString();
                        mar.HIP = dr.GetValue(13).ToString();
                        mar.HSP = dr.GetValue(14).ToString();
                        mar.THO = dr.GetValue(15).ToString();
                        mar.OBS = dr.GetValue(16).ToString();
                        rList.Add(mar);
                    }
                    return rList.OrderByDescending(o => o.Personal).Distinct().ToList();
                }
            }
        }
        public ArrayList Get_Justiticacion_Find(int Asistencia_Id)
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rList = new ArrayList();
                var query = from j in obj.JUSTIFICACION_CA
                            join m in obj.tbl_control_asistencia on j.Fecha equals m.fecha_asistencia
                            where m.Asistencia_Id == Asistencia_Id
                            select new
                            {
                                j.Justificacion_Id,
                                j.Fecha,
                                m.hora_ingreso_modificado,
                                m.hora_salida_modificado,
                                j.Tipo,
                                j.NewHora,
                                j.Motivo,
                                j.Estado
                            };
                rList.AddRange(query.ToList());
                return rList;
            }
        }
        public string Get_AA_Justificacion(int Justificacion_Id, string NewHora, string PersoModif)
        {
            try
            {
                using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    int existe = obj.JUSTIFICACION_CA.Where(x => x.Justificacion_Id == Justificacion_Id).Count();
                    if (existe == 1)
                    {
                        JUSTIFICACION_CA jus = obj.JUSTIFICACION_CA.Where(x => x.Justificacion_Id == Justificacion_Id).First();
                        jus.NewHora = NewHora;
                        jus.TipoModif = "03";
                        jus.Personal_Modif = PersoModif;
                        jus.FechaModif = DateTime.Now;
                        jus.Estado = "01";
                        obj.SaveChanges();
                        Send_Correo_Respuesta_Justificacion(Justificacion_Id);
                        Procesar_Justificacion(Justificacion_Id);
                        return "true#Actualizado Correctamente.";
                    }
                    else
                    {
                        return "false#.::Error > No se encontro la justificación.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "false#.::Error > " + ex.Message;
            }
        }
        public string Get_AprobarDesaprobar_Justificacion(int Justificacion_Id, string Estado, string PersoModif)
        {
            try
            {
                using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    int existe = obj.JUSTIFICACION_CA.Where(x => x.Justificacion_Id == Justificacion_Id).Count();
                    if (existe == 1)
                    {
                        JUSTIFICACION_CA just = obj.JUSTIFICACION_CA.Where(x => x.Justificacion_Id == Justificacion_Id).First();
                        just.Estado = Estado;
                        just.TipoModif = "03";
                        just.FechaModif = DateTime.Now;
                        just.Personal_Modif = PersoModif;
                        obj.SaveChanges();
                        Send_Correo_Respuesta_Justificacion(Justificacion_Id);
                        Procesar_Justificacion(Justificacion_Id);
                        return "true#Actualizado Correctamente.";
                    }
                    else
                    {
                        return "false#.::Error > No se encontro la justificación.";
                    }

                }
            }
            catch (Exception ex)
            {
                return "false#.::Error > " + ex.Message;
            }
        }
        public string Proc_AprobarJustificacion(int[] Asistencia_Id, string PersoModif)
        {
            try
            {
                using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    for (int i = 0; i <= Asistencia_Id.Count() - 1; i++)
                    {

                        int asistencia = Asistencia_Id[i];
                        List<JUSTIFICACION_CA> jList = new List<JUSTIFICACION_CA>();
                        DateTime fecha;
                        string personal_id;
                        fecha = obj.tbl_control_asistencia.Where(x => x.Asistencia_Id == asistencia).First().fecha_asistencia;
                        personal_id = obj.tbl_control_asistencia.Where(x => x.Asistencia_Id == asistencia).First().Personal_Id;
                        jList = obj.JUSTIFICACION_CA.Where(x => x.Fecha == fecha && x.Personal_Id == personal_id && x.Estado == "03").ToList();
                        for (int j = 0; j <= jList.Count - 1; j++)
                        {
                            int Justificacion_Id = jList[j].Justificacion_Id;
                            Get_AprobarDesaprobar_Justificacion(Justificacion_Id, "01", PersoModif);
                        }
                    }
                    return "true#Procesado correctamente.";
                }

            }
            catch (Exception ex)
            {
                return "false#.::Error > " + ex.Message;
            }
        }

        #endregion
        #region PERMISOS FECHAS

        public ArrayList Get_Permisos_Pendientes_Personal(string Personal_Id, DateTime FechaIni, DateTime FechaFin)
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rList = new ArrayList();

                var query = from p in obj.Permisos_Fecha_CA
                            join t in obj.Permisos_MS on p.TPermiso_Id equals t.Permiso_Id
                            join per in obj.Personal on p.Personal_ID equals per.Personal_Id
                            where p.Personal_ID.Contains(Personal_Id)
                                 && (EntityFunctions.TruncateTime(p.FechaIni) >= FechaIni.Date 
                                       && EntityFunctions.TruncateTime(p.FechaIni) <= FechaFin.Date)
                            && p.Estado != "01"
                            select new
                            {
                                p.PermisoD_Id,
                                Permiso = t.descripcion,
                                Personal = per.Apellido_Paterno + " " + per.Apellido_Materno + ", " + per.Nombres,
                                p.Descuento,
                                p.TipoReg,
                                p.Estado,
                                p.FechaIni,
                                p.FechaFin,
                                p.NroDoc,
                                p.AproJefe,
                                p.AproRRHH,
                                p.FechaModif
                            };

                rList.AddRange(query.ToList());
                return rList;
            }

        }

        public string Get_AprobarDesaprobar_Permiso_Fechas(int PermisoD_Id, string Comentarios, string Estado, string PersoModif)
        {
            try
            {
                using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    int existe = obj.Permisos_Fecha_CA.Where(x => x.PermisoD_Id == PermisoD_Id).Count();
                    if (existe == 1)
                    {
                        Permisos_Fecha_CA per = obj.Permisos_Fecha_CA.Where(x => x.PermisoD_Id == PermisoD_Id).First();
                        per.ComentariosRRHH = Comentarios;
                        if (Estado == "01")
                        {
                            per.AproRRHH = "01";
                        }
                        else if (Estado == "02") { per.AproRRHH = "02"; }
                        per.Estado = Estado;

                        per.TipoModif = "03";
                        per.FechaModif = DateTime.Now;
                        per.PersonalModig = PersoModif;
                        obj.SaveChanges();
                        Send_Correo_Respuesta_PermisoFechas(PermisoD_Id);
                        Procesar_PermisosFechas(PermisoD_Id);
                        return "true#Actualizado Correctamente.";
                    }
                    else
                    {
                        return "false#.::Error > El permiso no a sido encontrado.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "false#.::Error > " + ex.Message;
            }
        }

        public string Get_AA_Permiso_Fechas(int PermisoD_Id, int TPermiso_Id, DateTime FechaIni, DateTime FechaFin, string Descuento, string NroDoc, string Comentarios, string PersoModif)
        {
            try
            {
                using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {


                    int existe = obj.Permisos_Fecha_CA.Where(x => x.PermisoD_Id == PermisoD_Id).Count();
                    if (existe == 1)
                    {
                        Permisos_Fecha_CA perup = obj.Permisos_Fecha_CA.Where(x => x.PermisoD_Id == PermisoD_Id).First();
                        perup.TPermiso_Id = TPermiso_Id;
                        perup.FechaIni = FechaIni;
                        perup.FechaFin = FechaFin;
                        perup.Descuento = Descuento;
                        perup.NroDoc = NroDoc;
                        perup.Estado = "01";
                        perup.AproRRHH = "01";
                        perup.ComentariosRRHH = Comentarios;
                        perup.TipoModif = "03";
                        perup.FechaModif = DateTime.Now;
                        perup.PersonalModig = PersoModif;
                        obj.SaveChanges();
                        Send_Correo_Respuesta_PermisoFechas(PermisoD_Id);
                        Procesar_PermisosFechas(PermisoD_Id);
                        return "true#Actualizado correctamente.";
                    }
                    else
                    {
                        return "false#.::Error > Permiso no encontrado.";
                    }

                }
            }
            catch (Exception ex)
            {
                return "false#.::Error > " + ex.Message;
            }

        }


        #endregion
        #region PERMISOS HORAS

        public ArrayList Get_Permisos_Horas_Pendientes_Personal(string Personal_Id, DateTime FechaIni, DateTime FechaFin)
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rList = new ArrayList();

                var query = from p in obj.Permisos_Hora_CA
                            join t in obj.Permisos_MS on p.TPermiso_Id equals t.Permiso_Id
                            join pe in obj.Personal on p.Personal_ID equals pe.Personal_Id
                            where p.Personal_ID.Contains(Personal_Id)
                                /* && (EntityFunctions.TruncateTime(p.FechaIni) >= FechaIni.Date 
                                       && EntityFunctions.TruncateTime(p.FechaIni) <= FechaFin.Date)*/
                            && p.Estado != "01"
                            select new
                            {
                                p.PermisoH_Id,
                                p.Fecha,
                                Personal = pe.Apellido_Paterno + " " + pe.Apellido_Materno + ", " + pe.Nombres,
                                Permiso = t.descripcion,
                                p.Descuento,
                                p.TipoReg,
                                p.Estado,
                                p.HoraIni,
                                p.HoraFin,
                                p.AproJefe,
                                p.AproRRHH,
                                p.FechaModif
                            };

                rList.AddRange(query.ToList());
                return rList;
            }

        }

        public string Get_AprobarDesaprobar_Permiso_Horas(int PermisoH_Id, string Comentarios, string Estado, string PersoModif)
        {
            try
            {
                using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    int existe = obj.Permisos_Hora_CA.Where(x => x.PermisoH_Id == PermisoH_Id).Count();
                    if (existe == 1)
                    {
                        Permisos_Hora_CA per = obj.Permisos_Hora_CA.Where(x => x.PermisoH_Id == PermisoH_Id).First();
                        per.ComentariosJefe = Comentarios;
                        if (Estado == "01")
                        {
                            per.AproRRHH = "01";
                        }
                        else if (Estado == "02") { per.AproRRHH = "02"; }
                        per.Estado = Estado;

                        per.TipoModif = "03";
                        per.FechaModif = DateTime.Now;
                        per.PersonalModig = PersoModif;
                        obj.SaveChanges();
                        Send_Correo_Respuesta_PermisoHoras(PermisoH_Id);
                        return "true#Actualizado Correctamente.";
                    }
                    else
                    {
                        return "false#.::Error > El permiso no a sido encontrado.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "false#.::Error > " + ex.Message;
            }
        }

        public string Get_AA_Permisos_Horas(int PermisoH_Id, int TPermiso_Id, DateTime Fecha, DateTime HoraIni, DateTime HoraFin, string Descuento, string Comentario, string PersoModif, int AplicarIngSal)
        {
            try
            {
                using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {

                    int existe = obj.Permisos_Hora_CA.Where(x => x.PermisoH_Id == PermisoH_Id).Count();
                    if (existe == 1)
                    {
                        Permisos_Hora_CA perup = obj.Permisos_Hora_CA.Where(x => x.PermisoH_Id == PermisoH_Id).First();
                        perup.TPermiso_Id = TPermiso_Id;
                        perup.Fecha = Fecha;
                        perup.HoraIni = HoraIni;
                        perup.HoraFin = HoraFin;
                        perup.Descuento = Descuento;

                        perup.ComentariosRRHH = Comentario;
                        perup.AproRRHH = "01";
                        perup.Estado = "01";
                        perup.TipoModif = "03";
                        perup.FechaModif = DateTime.Now;
                        perup.PersonalModig = PersoModif;
                        perup.fl_aplica_ingsal = AplicarIngSal;
                        obj.SaveChanges();
                        Send_Correo_Respuesta_PermisoHoras(PermisoH_Id);
                        return "true#Actualizado correctamente.";
                    }
                    else
                    {
                        return "false#.::Error > Permiso no encontrado.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "false#.::Error > " + ex.Message;
            }

        }


        #endregion
        #region PROCESAR JUSTIFICACION

        private string Procesar_Justificacion(int Jusfiticacion_Id)
        {
            using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("SP_PROCESAR_JUSTIFICACION", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Justificacion_Id", Jusfiticacion_Id);
                    cn.Open();
                    string data = cmd.ExecuteScalar().ToString();
                    return data;
                }
            }
        }

        private string Procesar_PermisosFechas(int PermisoD_Id)
        {
            using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("SP_PROCESAR_PERMISOS_FECHAS", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PermisoD_Id", PermisoD_Id);
                    cn.Open();
                    string data = cmd.ExecuteScalar().ToString();
                    return data;
                }
            }
                      


        }

        #endregion
        #region ENVIAR CORREO DE RESPUESTA
        private string Send_Correo_Respuesta_Justificacion(int Jusfiticacion_Id)
        {
            using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SEND_CORREO_REPONDER_JUSTIFICACION", cn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Jusfiticacion_Id", Jusfiticacion_Id);
                    cn.Open();
                    string correo = "", asunto = "", cuerpo = "";
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        correo = dr.GetValue(0).ToString();
                        asunto = dr.GetValue(1).ToString();
                        cuerpo = dr.GetValue(2).ToString();
                        
                        if (correo.Trim() != "")
                        {
                            Utils.controller_SendSMTP.get_instance().sendMail(correo, asunto, cuerpo);
                        }
                    }
                    return "";
                }
            }
        }
        private string Send_Correo_Respuesta_PermisoFechas(int PermisoD_Id)
        {
            using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SEND_CORREO_REPONDER_PERMISOFECHAS", cn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PermisoD_Id", PermisoD_Id);
                    cn.Open();
                    string correo = "", asunto = "", cuerpo = "";
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        correo = dr.GetValue(0).ToString();
                        asunto = dr.GetValue(1).ToString();
                        cuerpo = dr.GetValue(2).ToString();
                        
                        if (correo.Trim() != "")
                        {
                            Utils.controller_SendSMTP.get_instance().sendMail(correo, asunto, cuerpo);
                        }
                    }
                    return "";
                }
            }
        }
        private string Send_Correo_Respuesta_PermisoHoras(int PermisoH_Id)
        {
            using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SEND_CORREO_REPONDER_PERMISOHORAS", cn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PermisoH_Id", PermisoH_Id);
                    cn.Open();
                    string correo = "", asunto = "", cuerpo = "";                    
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read()) {
                        correo = dr.GetValue(0).ToString();
                        asunto = dr.GetValue(1).ToString();
                        cuerpo = dr.GetValue(2).ToString();
                        
                        if (correo.Trim() != "")
                        {
                            Utils.controller_SendSMTP.get_instance().sendMail(correo, asunto, cuerpo);
                        }
                    }

                    return "";
                }
            }
        }
        #endregion
    }
    public class Justif
    {
        public string Solicitado { get; set; }
        public string Estado { get; set; }
        public string Realizado { get; set; }
        public string Asistencia_Id { get; set; }
        public string Personal_Id { get; set; }
        public string Personal { get; set; }
        public string FechaMarc { get; set; }
        public string Dia { get; set; }
        public string HIH { get; set; }
        public string HFH { get; set; }
        public string HIM { get; set; }
        public string HSM { get; set; }
        public string HIP { get; set; }
        public string HSP { get; set; }
        public string THO { get; set; }
        public string OBS { get; set; }
    }
}
