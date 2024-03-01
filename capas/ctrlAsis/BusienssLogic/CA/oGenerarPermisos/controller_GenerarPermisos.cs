using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presistence;
using System.Collections;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Data;

namespace BusienssLogic.CA.oGenerarPermisos
{
    public class controller_GenerarPermisos
    {
        private static controller_GenerarPermisos Instance = null;
        public static controller_GenerarPermisos Get_Instance() {
            return Instance == null ? Instance = new controller_GenerarPermisos() : Instance;
        }

        public ArrayList Get_Tipo_Permisos()
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection())) {

                ArrayList rList = new ArrayList();

                var query=from p in obj.Permisos_MS
                         // where (p.Permiso_Id == 1 || p.Permiso_Id == 6 || p.Permiso_Id == 7 || p.Permiso_Id == 8)
                          select new{p.Permiso_Id,p.descripcion,p.estado};

                rList.AddRange(query.OrderBy(o=> o.descripcion).ToList());
                return rList;                 

                //return obj.Permisos_MS.OrderBy(o => o.descripcion).ToList();            
            }            
        }

        public ArrayList Get_Permisos_Fecha_By_Personal(string Personal_Id, DateTime FechaIni, DateTime FechaFin)
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection())) {
                ArrayList rList = new ArrayList();

                var query=from p in obj.Permisos_Fecha_CA
                          join t in obj.Permisos_MS on p.TPermiso_Id equals t.Permiso_Id
                          where p.Personal_ID==Personal_Id
                        /*  && (EntityFunctions.TruncateTime(p.FechaIni) >= FechaIni.Date 
                                && EntityFunctions.TruncateTime(p.FechaIni) <= FechaFin.Date)*/
                          select new{
                                p.PermisoD_Id,
                                Permiso=t.descripcion,
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

        public string Get_AM_Permisos_Fechas(int PermisoD_Id, int TPermiso_Id, string Personal_ID, DateTime FechaIni, DateTime FechaFin, string Descuento, string TipoReg, string Motivo, string NroDoc, string PersoModif)
        {
            try
            {
                using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    if (PermisoD_Id == 0)
                    {
                        Permisos_Fecha_CA per = new Permisos_Fecha_CA();
                        per.TPermiso_Id = TPermiso_Id;
                        per.Personal_ID = Personal_ID;
                        per.FechaIni = FechaIni;
                        per.FechaFin = FechaFin;
                        per.Descuento = Descuento;
                        per.TipoReg = TipoReg;
                        per.Motivo = Motivo;
                        per.NroDoc = NroDoc;
                        per.AproJefe = "00";
                        per.ComentariosJefe = "";
                        per.AproRRHH = "00";
                        per.ComentariosRRHH = "";
                        per.TipoModif = null;
                        per.FechaModif = null;
                        per.PersonalModig = null;
                        per.FechaRegistro = DateTime.Now;
                        per.Estado = "05";
                        obj.AddToPermisos_Fecha_CA(per);
                        obj.SaveChanges();
                        string FI=FechaIni.ToString("yyyy-MM-dd");
                        string FF=FechaFin.ToString("yyyy-MM-dd");
                        int NewPermisoD_Id = obj.Permisos_Fecha_CA.Where(x => x.Personal_ID == Personal_ID).Max(m => m.PermisoD_Id);
                        Send_Jefes_Nuevo_PermisoFechas(NewPermisoD_Id);

                        return "true#Registrado correctamente.#" + NewPermisoD_Id.ToString();
                    }
                    else
                    {
                        int existe = obj.Permisos_Fecha_CA.Where(x => x.PermisoD_Id == PermisoD_Id).Count();
                        if (existe == 1)
                        {
                            Permisos_Fecha_CA perup = obj.Permisos_Fecha_CA.Where(x => x.PermisoD_Id == PermisoD_Id).First();
                            string FIANT=perup.FechaIni.ToString("yyyy-MM-dd");
                            string FFANT=perup.FechaFin.ToString("yyyy-MM-dd");

                            perup.TPermiso_Id = TPermiso_Id;
                            perup.FechaIni = FechaIni;
                            perup.FechaFin = FechaFin;
                            perup.Descuento = Descuento;
                            perup.Motivo = Motivo;
                            perup.NroDoc = NroDoc;
                            perup.Estado = "05";

                            perup.TipoModif = "01";
                            perup.PersonalModig = PersoModif;
                            perup.FechaModif = DateTime.Now;

                            obj.SaveChanges();

                            Send_Jefes_Actualizar_PermisoFechas(perup.PermisoD_Id, FIANT, FFANT, perup.FechaIni.ToString("yyyy-MM-dd"), perup.FechaFin.ToString("yyyy-MM-dd"));

                            return "true#Actualizado correctamente.";
                        }
                        else {
                            return "false#.::Error > Permiso no encontrado.";
                        }

                    }

                }
            }
            catch (Exception ex) {
                return "false#.::Error > " + ex.Message;
            }
        
        }

        public ArrayList Get_Permiso_Fechas_Find(int PermisoD_Id)
        { 
            using(ContextMaestro obj=new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection())){
                int existe = obj.Permisos_Fecha_CA.Where(x => x.PermisoD_Id == PermisoD_Id).Count();
                if (existe == 1)
                {
                    string Ruta="";
                    int existeFile = obj.FilePermiso.Where(x => x.Permiso_Id == PermisoD_Id && x.Tipo == "01").Count();
                    if (existeFile == 1)
                    {
                        Ruta = "../ArchivoPermiso/" + obj.FilePermiso.Where(x => x.Permiso_Id == PermisoD_Id && x.Tipo == "01").First().Name;
                    }
                    else {
                        Ruta = "#";
                    }


                    ArrayList rlist = new ArrayList();
                    var query = from p in obj.Permisos_Fecha_CA
                                join per in obj.Personal on p.Personal_ID equals per.Personal_Id
                                where p.PermisoD_Id == PermisoD_Id
                                select new
                                {
                                    PersonalName = per.Apellido_Paterno + " " + per.Apellido_Materno + ", " + per.Nombres
                                    ,p.PermisoD_Id
                                    ,p.TPermiso_Id
                                    ,p.Personal_ID
                                    ,p.FechaIni
                                    ,p.FechaFin
                                    ,p.Descuento
                                    ,p.TipoReg
                                    ,p.Motivo
                                    ,p.NroDoc
                                    ,p.AproJefe
                                    ,p.ComentariosJefe
                                    ,p.AproRRHH
                                    ,p.ComentariosRRHH
                                    ,p.TipoModif
                                    ,p.FechaModif
                                    ,p.PersonalModig
                                    ,p.FechaRegistro
                                    ,p.Estado
                                    ,Archivo=Ruta
                                };
                    
                    rlist.AddRange(query.ToList());
                    return rlist;
                }
                else {
                    return null;
                }
            }
        }

        public string Get_Cancelar_SolicitudPermisoDias(int PermisoD_Id, string PersoModif)
        {
            try
            {
                using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection())) {
                    int existe = obj.Permisos_Fecha_CA.Where(x => x.PermisoD_Id == PermisoD_Id).Count();
                    if (existe == 1)
                    {
                        Permisos_Fecha_CA per = obj.Permisos_Fecha_CA.Where(x => x.PermisoD_Id == PermisoD_Id).First();
                        per.Estado = "06";
                        per.TipoModif = "01";
                        per.PersonalModig = PersoModif;
                        per.FechaModif = DateTime.Now;
                        obj.SaveChanges();
                        Send_Jefes_Cancelar_PermisoFechas(PermisoD_Id);
                        return "true#Permiso cancelado correctamente.";
                    }
                    else {
                        return "false#.::Error > No se encontro el permiso intentelo luego.";
                    
                    }                
                }
            }
            catch (Exception ex) {
                return "false#.::Error > " + ex.Message;
            }        
        }

        public string Get_Aplica_Descuento_By_TPermiso(int TPermiso_Id) { 
            using(ContextMaestro obj=new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection())){
                int existe = obj.Permisos_MS.Where(x => x.Permiso_Id == TPermiso_Id).Count();
                if (existe == 1)
                {
                    return obj.Permisos_MS.Where(x => x.Permiso_Id == TPermiso_Id).First().Descuento;
                }
                else {
                    return "";
                }
            }
        }

        
        public List<VacacionesPropuesta> Get_DetalleVacaciones(string Personal_Id, DateTime FechaIni, DateTime FechaFin)
        { 
            using(ContextMaestro obj=new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection())){

                
                List<VacacionesPropuesta> vList = new List<VacacionesPropuesta>();
                var query = from va in obj.Vacaciones
                            where va.Personal_id == Personal_Id
                            && va.Dias_Pagados_Saldo>0
                            select new {
                                va.Vacaciones_id
                                  ,va.Personal_id
                                  ,va.Fecha_Ini
                                  ,va.Fecha_Fin
                                  ,va.Dias
                                  ,va.Dias_Pagados
                                  ,va.Dias_Pagados_Saldo
                                  ,va.Estado_Id,
                                   FechaPerIni="",
                                FechaPerFin = "",
                                DiasSaldoPermi=0
                            };

                query = query.OrderBy(o => o.Dias_Pagados_Saldo);
                for (int i = 0; i <= query.Count() - 1; i++) {
                    VacacionesPropuesta vs = new VacacionesPropuesta();
                    vs.Vacaciones_id = query.ToList()[i].Vacaciones_id;
                    vs.Personal_id = query.ToList()[i].Personal_id;
                    vs.Fecha_Ini = query.ToList()[i].Fecha_Ini;
                    vs.Fecha_Fin = query.ToList()[i].Fecha_Fin;
                    vs.Dias = int.Parse(query.ToList()[i].Dias.ToString());
                    vs.Dias_Pagados = int.Parse(query.ToList()[i].Dias_Pagados.ToString());
                    vs.Dias_Pagados_Saldo = int.Parse(query.ToList()[i].Dias_Pagados_Saldo.ToString());

                    vList.Add(vs);
                }
                
                
                if (vList.Count > 0)
                {
                    int saldo = vList[0].Dias_Pagados_Saldo;
                    int daysDiff = ((TimeSpan)(FechaFin-FechaIni)).Days + 1;                  

                    int dif = saldo - daysDiff;
                    if (dif < 0)
                    {
                        vList[0].DiasSaldoPermi = int.Parse(dif.ToString());
                        vList[0].CantDias = daysDiff;
                        vList[0].FechaPerIni = FechaIni.ToString("yyyy-MM-dd");
                        vList[0].FechaPerFin = FechaFin.ToString("yyyy-MM-dd");
                        vList[0].Mensaje = "El permiso genera una cantidad mayor al saldo que usted tiene.";
                    }
                    else {
                        vList[0].DiasSaldoPermi = int.Parse(dif.ToString());
                        vList[0].CantDias = daysDiff;
                        vList[0].FechaPerIni = FechaIni.ToString("yyyy-MM-dd");
                        vList[0].FechaPerFin = FechaFin.ToString("yyyy-MM-dd");
                        vList[0].Mensaje = "El permiso se aplicara para este periodo.";
                    }
                }
                return vList.ToList();           
            }        
        }

        #region PARA PERMISOS POR HORA
        public ArrayList Get_Permisos_Horas_By_Personal(string Personal_Id, DateTime FechaIni, DateTime FechaFin)
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rList = new ArrayList();
                var query = (from p in obj.Permisos_Hora_CA
                             join t in obj.Permisos_MS on p.TPermiso_Id equals t.Permiso_Id
                             where p.Personal_ID == Personal_Id
                             /*&& (EntityFunctions.TruncateTime(p.Fecha) >= FechaIni.Date
                                   && EntityFunctions.TruncateTime(p.Fecha) <= FechaFin.Date)*/
                             select new
                             {
                                 p.PermisoH_Id,
                                 p.Fecha,
                                 Permiso = t.descripcion,
                                 p.Descuento,
                                 p.TipoReg,
                                 p.Estado,
                                 p.HoraIni,
                                 p.HoraFin,
                                 p.AproJefe,
                                 p.AproRRHH,
                                 p.FechaModif
                             }).AsEnumerable().Select(s => new
                             {
                                 s.PermisoH_Id,
                                 Fecha = s.Fecha.ToString("dd/MM/yyyy HH:mm:ss"),
                                 s.Permiso,
                                 s.Descuento,
                                 s.TipoReg,
                                 s.Estado,
                                 HoraIni = s.HoraIni.ToString("dd/MM/yyyy HH:mm:ss"),
                                 HoraFin = s.HoraFin.ToString("dd/MM/yyyy HH:mm:ss"),
                                 s.AproJefe,
                                 s.AproRRHH,
                                 s.FechaModif
                             });

                rList.AddRange(query.ToList());                
                return rList;
            }

        }

        public string Get_AM_Permisos_Horas(int PermisoH_Id, int TPermiso_Id, string Personal_ID, DateTime Fecha, DateTime HoraIni, DateTime HoraFin, string Descuento, string TipoReg, string Motivo, string PersoModif, int AplicarIngSal)
        {
            try
            {
                using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    if (PermisoH_Id == 0)
                    {
                        Permisos_Hora_CA per = new Permisos_Hora_CA();
                        per.TPermiso_Id = TPermiso_Id;
                        per.Personal_ID = Personal_ID;
                        per.Fecha = Fecha;
                        per.HoraIni = HoraIni;
                        per.HoraFin = HoraFin;
                        per.Descuento = Descuento;
                        per.TipoReg = TipoReg;
                        per.Motivo = Motivo;
                        per.AproJefe = "00";
                        per.ComentariosJefe = "";
                        per.AproRRHH = "00";
                        per.ComentariosRRHH = "";
                        per.TipoModif = null;
                        per.FechaModif = null;
                        per.PersonalModig = null;
                        per.Estado = "05";
                        per.fl_aplica_ingsal = AplicarIngSal;
                        obj.AddToPermisos_Hora_CA(per);
                        obj.SaveChanges();
                        int NewPermisoH_Id = obj.Permisos_Hora_CA.Where(x => x.Personal_ID == Personal_ID).Max(m => m.PermisoH_Id);

                        Send_Jefes_Nuevo_PermisoHoras(NewPermisoH_Id);
                        return "true#Registrado correctamente.#"+NewPermisoH_Id.ToString();
                    }
                    else
                    {
                        int existe = obj.Permisos_Hora_CA.Where(x => x.PermisoH_Id == PermisoH_Id).Count();
                        if (existe == 1)
                        {
                            Permisos_Hora_CA perup = obj.Permisos_Hora_CA.Where(x => x.PermisoH_Id == PermisoH_Id).First();
                            string FechaAnt=Fecha.ToString("yyyy-MM-dd");
                            DateTime HIng=HoraIni;
                            DateTime HFin=HoraFin;
                            perup.TPermiso_Id = TPermiso_Id;
                            perup.Fecha = Fecha;
                            perup.HoraIni = HoraIni;
                            perup.HoraFin = HoraFin;
                            perup.Descuento = Descuento;
                            perup.Motivo = Motivo;
                            perup.Estado = "05";
                            perup.TipoModif = "01";
                            perup.PersonalModig = PersoModif;
                            perup.FechaModif = DateTime.Now;
                            perup.fl_aplica_ingsal = AplicarIngSal;
                            obj.SaveChanges();
                            Send_Jefes_Actualizar_PermisoHoras(PermisoH_Id, FechaAnt, HIng, HFin);
                            return "true#Actualizado correctamente.";
                        }
                        else
                        {
                            return "false#.::Error > Permiso no encontrado.";
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                return "false#.::Error > " + ex.Message;
            }

        }

        public ArrayList Get_Permiso_Horas_Find(int PermisoH_Id)
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                int existe = obj.Permisos_Hora_CA.Where(x => x.PermisoH_Id == PermisoH_Id).Count();
                if (existe == 1)
                {

                    string Ruta = "";
                    int existeFile = obj.FilePermiso.Where(x => x.Permiso_Id == PermisoH_Id && x.Tipo == "02").Count();
                    if (existeFile == 1)
                    {
                        Ruta = "../ArchivoPermiso/" + obj.FilePermiso.Where(x => x.Permiso_Id == PermisoH_Id && x.Tipo == "02").First().Name;
                    }
                    else
                    {
                        Ruta = "#";
                    }
                    ArrayList rlist = new ArrayList();

                    var query = (from p in obj.Permisos_Hora_CA
                                 join per in obj.Personal on p.Personal_ID equals per.Personal_Id
                                 where p.PermisoH_Id == PermisoH_Id
                                 select new
                                 {
                                     PersonalName = per.Apellido_Paterno + " " + per.Apellido_Materno + ", " + per.Nombres,
                                     p.PermisoH_Id,
                                     p.TPermiso_Id,
                                     p.Personal_ID,
                                     p.Fecha,
                                     p.HoraIni,
                                     p.HoraFin,
                                     p.Descuento,
                                     p.TipoReg,
                                     p.Motivo,
                                     p.AproJefe,
                                     p.ComentariosJefe,
                                     p.AproRRHH,
                                     p.ComentariosRRHH,
                                     p.TipoModif,
                                     p.FechaModif,
                                     p.PersonalModig,
                                     p.Estado,
                                     Archivo = Ruta,
                                     p.fl_aplica_ingsal
                                 });
                                 /*).AsEnumerable().Select(s => new { 
                                     s.PersonalName,
                                     s.PermisoH_Id,
                                     s.TPermiso_Id,
                                     s.Personal_ID,
                                     Fecha = s.Fecha.ToString("dd/MM/yyyy HH:mm:ss"),
                                     HoraIni = s.HoraIni.ToString("dd/MM/yyyy HH:mm:ss"),
                                     HoraFin = s.HoraFin.ToString("dd/MM/yyyy HH:mm:ss"),
                                     s.Descuento,
                                     s.TipoReg,
                                     s.Motivo,
                                     s.AproJefe,
                                     s.ComentariosJefe,
                                     s.AproRRHH,
                                     s.ComentariosRRHH,
                                     s.TipoModif,
                                     s.FechaModif,
                                     s.PersonalModig,
                                     s.Estado,
                                     s.Archivo,
                                     s.fl_aplica_ingsal
                                 });*/
                    rlist.AddRange(query.ToList());
                    return rlist;
                }
                else
                {
                    return null;
                }
            }
        }

        public string Get_Cancelar_SolicitudPermisoHoras(int PermisoH_Id, string PersoModif)
        {
            try
            {
                using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    int existe = obj.Permisos_Hora_CA.Where(x => x.PermisoH_Id == PermisoH_Id).Count();
                    if (existe == 1)
                    {
                        Permisos_Hora_CA per = obj.Permisos_Hora_CA.Where(x => x.PermisoH_Id == PermisoH_Id).First();
                        per.Estado = "06";
                        per.TipoModif = "01";
                        per.PersonalModig = PersoModif;
                        per.FechaModif = DateTime.Now;
                        obj.SaveChanges();
                        Send_Jefes_Cancelar_PermisoHoras(PermisoH_Id);
                        return "true#Permiso cancelado correctamente.";
                    }
                    else
                    {
                        return "false#.::Error > No se encontro el permiso intentelo luego.";

                    }
                }
            }
            catch (Exception ex)
            {
                return "false#.::Error > " + ex.Message;
            }
        }

        #endregion

        #region ENVIO DE CORREOS PERMISOS POR FECHAS

        private string Send_Jefes_Nuevo_PermisoFechas(int PermisoD_Id)
        {
            using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SEND_CORREO_JEFES_NUEVO_PERMISOFECHAS", cn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PermisoD_Id", PermisoD_Id);
                    cn.Open();
                    string correo = "", asunto = "", cuerpo = "";                    
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read()) {
                        correo = dr.GetValue(0).ToString();
                        asunto = dr.GetValue(1).ToString();
                        cuerpo = dr.GetValue(2).ToString();
                    }
                    
                    if (correo.Trim() != "")
                    {
                        return Utils.controller_SendSMTP.get_instance().sendMail(correo, asunto, cuerpo);
                    }
                    else { return "false#Correo no identificado."; }
                }
            }
        }

        private string Send_Jefes_Actualizar_PermisoFechas(int PermisoD_Id, string FechaIni, string FechaFin, string FechaIniAct, string FechaFinAct)
        {
            using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SEND_CORREO_JEFES_ACTUALIZAR_PERMISOFECHAS", cn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PermisoD_Id", PermisoD_Id);
                    cmd.Parameters.AddWithValue("@FINI", FechaIni);
                    cmd.Parameters.AddWithValue("@FFIN", FechaFin);
                    cmd.Parameters.AddWithValue("@FINI_ACT", FechaIniAct);
                    cmd.Parameters.AddWithValue("@FFIN_ACT", FechaFinAct);
                    cn.Open();
                    string correo = "", asunto = "", cuerpo = "";
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        correo = dr.GetValue(0).ToString();
                        asunto = dr.GetValue(1).ToString();
                        cuerpo = dr.GetValue(2).ToString();
                    }
                    
                    if (correo.Trim() != "")
                    {
                        return Utils.controller_SendSMTP.get_instance().sendMail(correo, asunto, cuerpo);
                        
                    }
                    else { return "false#Correo no identificado."; }
                }
            }
        }

        private string Send_Jefes_Cancelar_PermisoFechas(int PermisoD_Id)
        {
            using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SEND_CORREO_JEFES_CANCELAR_PERMISOFECHAS", cn))
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
                    }
                    
                    if (correo.Trim() != "")
                    {
                        return Utils.controller_SendSMTP.get_instance().sendMail(correo, asunto, cuerpo);
                    }
                    else { return "false#Correo no identificado."; }
                }
            }
        }

        #endregion

        #region ENVIO DE CORREOS PERMISOS POR HORAS

        private string Send_Jefes_Nuevo_PermisoHoras(int PermisoH_Id)
        {
            using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SEND_CORREO_JEFES_NUEVO_PERMISOHORAS", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PermisoH_Id", PermisoH_Id);
                    cn.Open();
                    string correo = "", asunto = "", cuerpo = "";
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        correo = dr.GetValue(0).ToString();
                        asunto = dr.GetValue(1).ToString();
                        cuerpo = dr.GetValue(2).ToString();
                    }
                    
                    if (correo.Trim() != "")
                    {
                        return Utils.controller_SendSMTP.get_instance().sendMail(correo, asunto, cuerpo);
                    }
                    else { return "false#Correo no identificado."; }
                }
            }
        }

        private string Send_Jefes_Actualizar_PermisoHoras(int PermisoH_Id, string Fecha, DateTime HoraIni, DateTime HoraFin)
        {
            using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SEND_CORREO_JEFES_ACTUALIZAR_PERMISOHORAS", cn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PermisoH_Id", PermisoH_Id);
                    cmd.Parameters.AddWithValue("@FECHA", Fecha);
                    cmd.Parameters.AddWithValue("@HINI", HoraIni);
                    cmd.Parameters.AddWithValue("@HFIN", HoraFin);
                    cn.Open();
                    string correo = "", asunto = "", cuerpo = "";
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        correo = dr.GetValue(0).ToString();
                        asunto = dr.GetValue(1).ToString();
                        cuerpo = dr.GetValue(2).ToString();
                    }
                    
                    if (correo.Trim() != "")
                    {
                        return Utils.controller_SendSMTP.get_instance().sendMail(correo, asunto, cuerpo);
                    }
                    else { return "false#Correo no identificado."; }
                    
                }
            }
        }

        private string Send_Jefes_Cancelar_PermisoHoras(int PermisoH_Id)
        {
            using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SEND_CORREO_JEFES_CANCELAR_PERMISOHORAS", cn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PermisoH_Id", PermisoH_Id);
                    cn.Open();
                    string correo = "", asunto = "", cuerpo = "";
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        correo = dr.GetValue(0).ToString();
                        asunto = dr.GetValue(1).ToString();
                        cuerpo = dr.GetValue(2).ToString();
                    }
                    
                    if (correo.Trim() != "")
                    {
                        return Utils.controller_SendSMTP.get_instance().sendMail(correo, asunto, cuerpo);
                    }
                    else { return "false#Correo no identificado."; }
                }
            }
        }

        #endregion



        #region OTROS 

        public string Get_AM_Permisos_Fechas_Otros(int PermisoD_Id, int TPermiso_Id, string Personal_ID, DateTime FechaIni, DateTime FechaFin
            , string Descuento, string TipoReg, string Motivo, string NroDoc, string AproJefe, string ComentariosJefe
            , string AproRRHH, string ComentariosRRHH, string TipoModif, string PersoModif, string Estado)
        {
            try
            {
                using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    if (PermisoD_Id == 0)
                    {
                        Permisos_Fecha_CA per = new Permisos_Fecha_CA();
                        per.TPermiso_Id = TPermiso_Id;
                        per.Personal_ID = Personal_ID;
                        per.FechaIni = FechaIni;
                        per.FechaFin = FechaFin;
                        per.Descuento = Descuento;
                        per.TipoReg = TipoReg;
                        per.Motivo = Motivo;
                        per.NroDoc = NroDoc;
                        per.AproJefe = AproJefe;
                        per.ComentariosJefe = ComentariosJefe;
                        per.AproRRHH = AproRRHH;
                        per.ComentariosRRHH = ComentariosRRHH;
                        per.TipoModif = null;
                        per.FechaModif = null;
                        per.PersonalModig = null;
                        per.FechaRegistro = DateTime.Now;
                        per.Estado = Estado;
                        obj.AddToPermisos_Fecha_CA(per);
                        obj.SaveChanges();
                        string FI = FechaIni.ToString("yyyy-MM-dd");
                        string FF = FechaFin.ToString("yyyy-MM-dd");
                        int NewPermisoD_Id = obj.Permisos_Fecha_CA.Where(x => x.Personal_ID == Personal_ID).Max(m => m.PermisoD_Id);
                        Send_Jefes_Nuevo_PermisoFechas(NewPermisoD_Id);

                        if (TipoReg == "03" && Estado == "01")
                        {
                            int PerFechID = obj.Permisos_Fecha_CA.Max(m => m.PermisoD_Id);
                            Procesar_PermisosFechas(PerFechID);
                        }
                        return "true#Registrado correctamente.";
                    }
                    else
                    {
                        int existe = obj.Permisos_Fecha_CA.Where(x => x.PermisoD_Id == PermisoD_Id).Count();
                        if (existe == 1)
                        {
                            Permisos_Fecha_CA perup = obj.Permisos_Fecha_CA.Where(x => x.PermisoD_Id == PermisoD_Id).First();
                            string FIANT = perup.FechaIni.ToString("yyyy-MM-dd");
                            string FFANT = perup.FechaFin.ToString("yyyy-MM-dd");

                            perup.TPermiso_Id = TPermiso_Id;
                            perup.FechaIni = FechaIni;
                            perup.FechaFin = FechaFin;
                            perup.Descuento = Descuento;
                            perup.Motivo = Motivo;
                            perup.NroDoc = NroDoc;
                            perup.Estado = Estado;
                            perup.ComentariosJefe = ComentariosJefe;
                            perup.ComentariosRRHH = ComentariosRRHH;


                            perup.TipoModif = TipoModif;
                            perup.PersonalModig = PersoModif;
                            perup.FechaModif = DateTime.Now;


                            obj.SaveChanges();

                            Send_Jefes_Actualizar_PermisoFechas(perup.PermisoD_Id, FIANT, FFANT, perup.FechaIni.ToString("yyyy-MM-dd"), perup.FechaFin.ToString("yyyy-MM-dd"));
                            if (TipoReg == "03" && Estado == "01")
                            {
                                Procesar_PermisosFechas(perup.PermisoD_Id);
                            }
                            return "true#Actualizado correctamente.";
                        }
                        else
                        {
                            return "false#.::Error > Permiso no encontrado.";
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                return "false#.::Error > " + ex.Message;
            }

        }


        public string Get_AM_Permisos_Horas_Otros(int PermisoH_Id, int TPermiso_Id, string Personal_ID, DateTime Fecha, DateTime HoraIni
            , DateTime HoraFin, string Descuento, string TipoReg, string AproJefe, string ComentariosJefe
            , string AproRRHH, string ComentariosRRHH, string Motivo, string PersoModif, string TipoModif, string Estado
            , int AplicarIngSal)
        {
            try
            {
                using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    if (PermisoH_Id == 0)
                    {
                        Permisos_Hora_CA per = new Permisos_Hora_CA();
                        per.TPermiso_Id = TPermiso_Id;
                        per.Personal_ID = Personal_ID;
                        per.Fecha = Fecha;
                        per.HoraIni = HoraIni;
                        per.HoraFin = HoraFin;
                        per.Descuento = Descuento;
                        per.TipoReg = TipoReg;
                        per.Motivo = Motivo;
                        per.AproJefe = AproJefe;
                        per.ComentariosJefe = ComentariosJefe;
                        per.AproRRHH = AproRRHH;
                        per.ComentariosRRHH = ComentariosRRHH;
                        per.TipoModif = null;
                        per.FechaModif = null;
                        per.PersonalModig = null;
                        per.Estado = Estado;
                        per.fl_aplica_ingsal = AplicarIngSal;
                        obj.AddToPermisos_Hora_CA(per);
                        obj.SaveChanges();
                        int NewPermisoH_Id = obj.Permisos_Hora_CA.Where(x => x.Personal_ID == Personal_ID).Max(m => m.PermisoH_Id);
                  
                        Send_Jefes_Nuevo_PermisoHoras(NewPermisoH_Id);
                        return "true#Registrado correctamente.";
                    }
                    else
                    {
                        int existe = obj.Permisos_Hora_CA.Where(x => x.PermisoH_Id == PermisoH_Id).Count();
                        if (existe == 1)
                        {
                            Permisos_Hora_CA perup = obj.Permisos_Hora_CA.Where(x => x.PermisoH_Id == PermisoH_Id).First();
                            string FechaAnt = Fecha.ToString("yyyy-MM-dd");
                            DateTime HIng = HoraIni;
                            DateTime HFin = HoraFin;
                            perup.TPermiso_Id = TPermiso_Id;
                            perup.Fecha = Fecha;
                            perup.HoraIni = HoraIni;
                            perup.HoraFin = HoraFin;
                            perup.Descuento = Descuento;
                            perup.Motivo = Motivo;
                            perup.Estado = Estado;
                            perup.TipoModif = TipoModif;

                            perup.ComentariosJefe = ComentariosJefe;
                            perup.ComentariosRRHH = ComentariosRRHH;

                            perup.PersonalModig = PersoModif;
                            perup.FechaModif = DateTime.Now;
                            obj.SaveChanges();
                            Send_Jefes_Actualizar_PermisoHoras(PermisoH_Id, FechaAnt, HIng, HFin);
                            return "true#Actualizado correctamente.";
                        }
                        else
                        {
                            return "false#.::Error > Permiso no encontrado.";
                        }

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



        public string Delete_ArchivoPermiso(int Permiso_Id, string Personal_Id,string Tipo) { 
            using(ContextMaestro obj=new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection())){
                int existe = obj.FilePermiso.Where(x => x.Permiso_Id == Permiso_Id && x.Personal_Id == Personal_Id && x.Tipo == Tipo).Count();
                if (existe == 1)
                {
                    return obj.FilePermiso.Where(x => x.Permiso_Id == Permiso_Id && x.Personal_Id == Personal_Id && x.Tipo == Tipo).First().Name;
                }
                else {
                    return "";
                }          
            
            }        
        }
        public bool Insert_ArchivoPermiso(int Permiso_Id, string Personal_Id, string Tipo,string Name,string Url)
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                int existe = obj.FilePermiso.Where(x => x.Permiso_Id == Permiso_Id && x.Personal_Id == Personal_Id && x.Tipo == Tipo).Count();
                if (existe == 1)
                {
                    FilePermiso fp = obj.FilePermiso.Where(x => x.Permiso_Id == Permiso_Id && x.Personal_Id == Personal_Id && x.Tipo == Tipo).First();
                    fp.Name = Name;
                    fp.Url = Url;
                    obj.SaveChanges();
                    return true;
                }
                else if (existe == 0)
                {
                    FilePermiso fpi = new FilePermiso();
                    fpi.Permiso_Id = Permiso_Id;
                    fpi.Personal_Id = Personal_Id;
                    fpi.Tipo = Tipo;
                    fpi.Name = Name;
                    fpi.Url = Url;
                    obj.AddToFilePermiso(fpi);
                    obj.SaveChanges();
                    return true;
                }
                else {
                    return false;
                }

            }

        }
        
    }

    public class VacacionesPropuesta {
        public string Vacaciones_id { get; set; }
        public string Personal_id { get; set; }
        public DateTime Fecha_Ini { get; set; }
        public DateTime Fecha_Fin { get; set; }
        public int Dias { get; set; }
        public int Dias_Pagados { get; set; }
        public int Dias_Pagados_Saldo { get; set; }
        public string Estado_Id { get; set; }
        public string FechaPerIni { get; set; }
        public string FechaPerFin { get; set; }
        public int CantDias { get; set; }
        public int DiasSaldoPermi { get; set; }
        public string Mensaje { get; set; }
    }
}

