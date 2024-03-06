using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presistence;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace BusienssLogic.CA.oGenerarJustificacion
{
    public class controller_GenerarJustificacion
    {
        private static controller_GenerarJustificacion Instance = null;
        public static controller_GenerarJustificacion Get_Instance() {
            return Instance == null ? Instance = new controller_GenerarJustificacion() : Instance;
        }


        public Periodo_Asistencia Get_Periodo_Activo_Asistencia() {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection())) {
                int existe = obj.Periodo_Asistencia.Where(x => x.Estado == true).Count();
                if (existe == 1)
                {
                   return obj.Periodo_Asistencia.Where(x => x.Estado == true).First();                    
                }
                else {
                    return null;
                }            
            }
        }

        public string Get_Periodo_Planilla(string Periodo,string Personal_Id)
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                int existe = obj.Periodo.Where(x => x.Descripcion.Contains(Periodo)).Count();
                if (existe>0)
                {

                    var query = from pa in obj.Personal_activo
                                        join p in obj.Periodo on pa.Periodo_Id equals p.Periodo_Id
                                        where p.Descripcion.Contains(Periodo)
                                          && pa.Personal_Id == Personal_Id
                                        select  pa.Periodo_Id ;
                    string periodoCod = query.First();
                    return periodoCod;
                }
                return "";
               
            }
        }

        #region PERSONAL

        public ArrayList Get_DatosPersonal(string Personal_Id,string Periodo_Id) {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection())) {
                int existe = obj.Personal.Where(x => x.Personal_Id == Personal_Id).Count();
                if (existe > 0)
                {
                    ArrayList rlist = new ArrayList();
                    var query = from p in obj.Personal
                                join pa in obj.Personal_activo on p.Personal_Id equals pa.Personal_Id
                                join l in obj.RH_Area on pa.Area_Id equals l.Area_Id
                                join c in obj.Cargo on pa.Cargo_Id equals c.Cargo_id
                                where pa.Personal_Id == Personal_Id
                                       && pa.Periodo_Id == Periodo_Id
                                select new { 
                                    PersonalNom=p.Apellido_Paterno+" "+p.Apellido_Materno+", "+p.Nombres,
                                    Localidad=l.Descripcion,
                                    Cargo=c.Descripcion                                
                                };
                    rlist.AddRange(query.ToList());
                    return rlist;
                }
                else {
                    return null;
                }
            }
        }

        public List<MarcacionesMalPersonal> Get_Marcaciones_Malas_Personal(string Personal_Id,DateTime FechaIni,DateTime FechaFin)
        {
            using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion())) {
                using (SqlCommand cmd = new SqlCommand("Get_Marcaciones_Malas_Personal_CA",cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Personal_Id", Personal_Id);
                    cmd.Parameters.AddWithValue("@FechaIni", FechaIni);
                    cmd.Parameters.AddWithValue("@FechaFin", FechaFin);

                    List<MarcacionesMalPersonal> rList = new List<MarcacionesMalPersonal>();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read()) {
                        MarcacionesMalPersonal mar = new MarcacionesMalPersonal();
                        mar.Solicitado = dr.GetValue(1).ToString();
                        mar.Estado = dr.GetValue(2).ToString();
                        mar.Realizado = dr.GetValue(3).ToString();
                        mar.Asistencia_Id = dr.GetValue(4).ToString();
                        mar.Personal_Id = dr.GetValue(5).ToString();
                        mar.Tipo = dr.GetValue(6).ToString();
                        mar.FechaMarc = DateTime.Parse(dr.GetValue(7).ToString()).ToString("dd/MM/yyy HH:mm:ss");
                        mar.Dia = dr.GetValue(8).ToString();
                        mar.HIH = dr.GetValue(9).ToString();
                        mar.HFH = dr.GetValue(10).ToString();
                        mar.HIM = dr.GetValue(11).ToString();
                        mar.HSM = dr.GetValue(12).ToString();
                        mar.THO = dr.GetValue(13).ToString();
                        mar.OBS = dr.GetValue(14).ToString();                       
                        mar.HES = dr.GetValue(16).ToString();
                        mar.HEA = dr.GetValue(17).ToString();
                        mar.HED = dr.GetValue(18).ToString();
                        mar.MinTard = dr.GetValue(19).ToString();
                        mar.Falta = dr.GetValue(20).ToString();

                        rList.Add(mar);
                    }
                    return rList.OrderByDescending(o=> o.FechaMarc).Distinct().ToList();
                }            
            }
        }

        public JustificacionEdit Get_Justificacion_Find(int Asistencia_Id)
        {
            using(ContextMaestro obj=new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection())){
                int existe=obj.tbl_control_asistencia.Where(x=> x.Asistencia_Id==Asistencia_Id).Count();
                if(existe>0){

                    tbl_control_asistencia marc = obj.tbl_control_asistencia.Where(x => x.Asistencia_Id == Asistencia_Id).First();
                    string Personal_Id = marc.Personal_Id;
                    DateTime Fecha = marc.fecha_asistencia;

                    JustificacionEdit jus = new JustificacionEdit();

                    jus.Fecha = marc.fecha_asistencia;
                    if (marc.hora_ingreso_modificado.ToString() != "")
                    {
                        jus.HIR = DateTime.Parse(marc.hora_ingreso_modificado.ToString()).ToString("dd/MM/yyy HH:mm:ss");
                    }
                    else { 
                    jus.HIR = marc.hora_ingreso_modificado.ToString();
                    }
                    if (marc.hora_salida_modificado.ToString() != "")
                    {
                        jus.HSR = DateTime.Parse(marc.hora_salida_modificado.ToString()).ToString("dd/MM/yyy HH:mm:ss");
                    }
                    else
                    {
                        jus.HSR = marc.hora_salida_modificado.ToString();
                    }
                    jus.HIP = null;
                    jus.HSP = null;
                    jus.HIE = null;
                    jus.HSE = null;
                    jus.MI = null;
                    jus.MS = null;

                    int existeJusEntrada = obj.JUSTIFICACION_CA.Where(x => x.Personal_Id == Personal_Id && x.Fecha == Fecha && x.Tipo=="01").Count();
                    if (existeJusEntrada == 1)
                    {
                        jus.HIP = obj.JUSTIFICACION_CA.Where(x => x.Personal_Id == Personal_Id && x.Fecha == Fecha && x.Tipo == "01").First().NewHora;
                        jus.HIE = obj.JUSTIFICACION_CA.Where(x => x.Personal_Id == Personal_Id && x.Fecha == Fecha && x.Tipo == "01").First().Estado;
                        jus.MI = obj.JUSTIFICACION_CA.Where(x => x.Personal_Id == Personal_Id && x.Fecha == Fecha && x.Tipo == "01").First().Motivo;
                    }

                    int existeJusSalida = obj.JUSTIFICACION_CA.Where(x => x.Personal_Id == Personal_Id && x.Fecha == Fecha && x.Tipo == "02").Count();
                    if (existeJusSalida == 1)
                    {
                        jus.HSP = obj.JUSTIFICACION_CA.Where(x => x.Personal_Id == Personal_Id && x.Fecha == Fecha && x.Tipo == "02").First().NewHora;
                        jus.HSE = obj.JUSTIFICACION_CA.Where(x => x.Personal_Id == Personal_Id && x.Fecha == Fecha && x.Tipo == "02").First().Estado;
                        jus.MS = obj.JUSTIFICACION_CA.Where(x => x.Personal_Id == Personal_Id && x.Fecha == Fecha && x.Tipo == "02").First().Motivo;
                    }
                    return jus;
                }
                return null;
            }        
        }

        public List<string> Get_Files_Jusitificacion(int Asistencia_Id)
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                List<string> rList=new List<string>();
                int existe = obj.tbl_control_asistencia.Where(x => x.Asistencia_Id == Asistencia_Id).Count();
                if (existe > 0)
                {
                    tbl_control_asistencia marc = obj.tbl_control_asistencia.Where(x => x.Asistencia_Id == Asistencia_Id).First();
                    string Personal_Id = marc.Personal_Id;
                    DateTime Fecha = marc.fecha_asistencia;

                    string file_1="#";
                    string file_2 = "#";
                    int existe1 = obj.FileJustificacion.Where(x => x.Personal_Id == Personal_Id && x.Fecha == Fecha && x.Tipo == "01").Count();
                    if (existe1 == 1) {
                        file_1 = obj.FileJustificacion.Where(x => x.Personal_Id == Personal_Id && x.Fecha == Fecha && x.Tipo == "01").First().Name;
                        file_1 = "../ArchivoJustificacion/" + file_1;
                    }

                    int existe2 = obj.FileJustificacion.Where(x => x.Personal_Id == Personal_Id && x.Fecha == Fecha && x.Tipo == "02").Count();
                    if (existe2 == 1)
                    {
                        file_2 = obj.FileJustificacion.Where(x => x.Personal_Id == Personal_Id && x.Fecha == Fecha && x.Tipo == "02").First().Name;
                        file_2 = "../ArchivoJustificacion/" + file_2;
                    }

                    rList.Add(file_1);
                    rList.Add(file_2);
                }
                else {
                    rList.Add("#");
                    rList.Add("#");
                }
                return rList;
            }
        }

        public string Get_AM_Justificacion(DateTime Fecha, string Tipo, string Personal_Id, string NewHora, string TipoRegistro, string Motivo, string PersoModif)
        {
            try
            {
                using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    int existe = obj.JUSTIFICACION_CA.Where(x => x.Fecha == Fecha && x.Tipo == Tipo && x.Personal_Id == Personal_Id).Count();
                    if (existe == 1)
                    {
                        string HoraAnt="";
                        JUSTIFICACION_CA jus = obj.JUSTIFICACION_CA.Where(x => x.Fecha == Fecha && x.Tipo == Tipo && x.Personal_Id == Personal_Id).First();

                        HoraAnt = jus.NewHora;

                        jus.NewHora = NewHora;
                        jus.TipoModif = "01";
                        jus.Personal_Modif = PersoModif;
                        jus.FechaModif = DateTime.Now;
                        jus.Motivo = Motivo;
                        jus.Estado = "05";
                        obj.SaveChanges();
                        Send_Jefes_Actualizar_Justificacion(jus.Justificacion_Id, HoraAnt, jus.NewHora, Tipo);
                        return "true#Actualizado Correctamente.";
                    }
                    else
                    {
                        JUSTIFICACION_CA jus = new JUSTIFICACION_CA();
                        jus.Fecha = Fecha;
                        jus.Tipo = Tipo;
                        jus.Personal_Id = Personal_Id;
                        jus.NewHora = NewHora;
                        jus.TipoRegistro = TipoRegistro;
                        jus.FechaModif = null;
                        jus.TipoModif = null;
                        jus.Personal_Modif = null;
                        jus.Motivo = Motivo;
                        jus.Estado = "05";
                        obj.AddToJUSTIFICACION_CA(jus);
                        obj.SaveChanges();
                        string fecha=Fecha.ToString("yyyy-MM-dd");
                        int jusNew = obj.JUSTIFICACION_CA.Where(x => x.Personal_Id == Personal_Id).Max(m => m.Justificacion_Id);
                        Send_Jefes_Nueva_Justificacion(jusNew);
                        
                        return "true#Registrado Correctamente.";
                    }
                }
            }
            catch (Exception ex) {
                return "false#.::Error > " + ex.Message;
            }
        }

        public List<MarcacionesCorPersonal> Get_Marcaciones_Correctas_Personal(string Personal_Id, DateTime FechaIni, DateTime FechaFin)
        {
            using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("Get_Marcaciones_Correctas_Personal_CA", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Personal_Id", Personal_Id);
                    cmd.Parameters.AddWithValue("@FechaIni", FechaIni);
                    cmd.Parameters.AddWithValue("@FechaFin", FechaFin);

                    List<MarcacionesCorPersonal> rList = new List<MarcacionesCorPersonal>();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        MarcacionesCorPersonal mar = new MarcacionesCorPersonal();
                        mar.Solicitado = dr.GetValue(1).ToString();
                        mar.Estado = dr.GetValue(2).ToString();
                        mar.Realizado = dr.GetValue(3).ToString();
                        mar.Asistencia_Id = dr.GetValue(4).ToString();
                        mar.Personal_Id = dr.GetValue(5).ToString();
                        mar.FechaMarc = DateTime.Parse(dr.GetValue(6).ToString()).ToString("dd/MM/yyy HH:mm:ss");
                        mar.Dia = dr.GetValue(7).ToString();
                        mar.HIH = dr.GetValue(8).ToString();
                        mar.HFH = dr.GetValue(9).ToString();
                        mar.HIM = dr.GetValue(10).ToString();
                        mar.HSM = dr.GetValue(11).ToString();
                        mar.THO = dr.GetValue(12).ToString();
                        mar.OBS = dr.GetValue(13).ToString();
                        mar.HES = dr.GetValue(15).ToString();
                        mar.HEA = dr.GetValue(16).ToString();
                        mar.HED = dr.GetValue(17).ToString();
                        mar.MinTard = dr.GetValue(18).ToString();
                        mar.Falta = dr.GetValue(19).ToString();
                        rList.Add(mar);
                    }
                    return rList.OrderByDescending(o => o.FechaMarc).Distinct().ToList();
                }
            }
        }


        #endregion
        #region ENVIO DE CORREOS


        private string Send_Jefes_Nueva_Justificacion(int Justificacion_Id)
        { 
            using(SqlConnection cn=new SqlConnection(Presistence.Customs.Conexion.getConexion())){
                using (SqlCommand cmd = new SqlCommand("SP_SEND_CORREO_JEFES_NUEVA_JUSTIFICACION", cn)) {

                    /*cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Justificacion_Id", Justificacion_Id);
                    cn.Open();
                    string data = cmd.ExecuteScalar().ToString();
                    return data;*/
                    return "true#ok";
                }
            }        
        }

        private string Send_Jefes_Actualizar_Justificacion(int Jusfiticacion_Id, string HoraAnt, string HoraActu,string Tipo)
        {
            using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SEND_CORREO_JUSTIFICACION_ACTUALIZADA", cn))
                {

                    /*cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Jusfiticacion_Id", Jusfiticacion_Id);
                    cn.Open();
                    string data = cmd.ExecuteScalar().ToString();
                    return data;*/
                    return "true#ok";
                }
            }
        }

        #endregion
        #region GENERAR EXTERNOS

        public string Get_AM_Justificacion_Otros(DateTime Fecha, string Tipo, string Personal_Id, string NewHora, string TipoRegistro, string Motivo,string TipoModif, string PersoModif,string Estado)
        {
            try
            {
                using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    int existe = obj.JUSTIFICACION_CA.Where(x => x.Fecha == Fecha && x.Tipo == Tipo && x.Personal_Id == Personal_Id).Count();
                    if (existe == 1)
                    {
                        string HoraAnt = "";
                        JUSTIFICACION_CA jus = obj.JUSTIFICACION_CA.Where(x => x.Fecha == Fecha && x.Tipo == Tipo && x.Personal_Id == Personal_Id).First();

                        HoraAnt = jus.NewHora;
                        jus.NewHora = NewHora;
                        jus.TipoModif = TipoModif;
                        jus.Personal_Modif = PersoModif;
                        jus.FechaModif = DateTime.Now;
                        jus.Motivo = Motivo;
                        jus.Estado = Estado;
                        obj.SaveChanges();
                        Send_Jefes_Actualizar_Justificacion(jus.Justificacion_Id, HoraAnt, jus.NewHora, Tipo);

                        if (TipoRegistro == "03" && Estado == "01") {
                            Procesar_Justificacion(jus.Justificacion_Id);
                        }

                        return "true#Actualizado Correctamente.";
                    }
                    else
                    {
                        JUSTIFICACION_CA jus = new JUSTIFICACION_CA();
                        jus.Fecha = Fecha;
                        jus.Tipo = Tipo;
                        jus.Personal_Id = Personal_Id;
                        jus.NewHora = NewHora;
                        jus.TipoRegistro = TipoRegistro;
                        jus.FechaModif = null;
                        jus.TipoModif = null;
                        jus.Personal_Modif = null;
                        jus.Motivo = Motivo;
                        jus.Estado = Estado;
                        obj.AddToJUSTIFICACION_CA(jus);
                        obj.SaveChanges();
                        string fecha = Fecha.ToString("yyyy-MM-dd");
                        int jusNew = obj.JUSTIFICACION_CA.Where(x => x.Personal_Id == Personal_Id).Max(m => m.Justificacion_Id);
                        Send_Jefes_Nueva_Justificacion(jusNew);
                        


                        if (TipoRegistro == "03" && Estado == "01")
                        {
                           int justID=  obj.JUSTIFICACION_CA.Max(m => m.Justificacion_Id);
                           Procesar_Justificacion(justID);
                        }
                        return "true#Registrado Correctamente.";
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


        #endregion


        public bool Get_Insert_FileJustificacion(string Personal,DateTime Fecha,string Tipo,string Name,string Url) { 
            using(ContextMaestro obj=new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection())){
                int existe = obj.FileJustificacion.Where(x => x.Personal_Id == Personal && x.Fecha == Fecha && x.Tipo == Tipo).Count();
                if (existe == 1)
                {
                    FileJustificacion fiup = obj.FileJustificacion.Where(x => x.Personal_Id == Personal && x.Fecha == Fecha && x.Tipo == Tipo).First();
                    fiup.Name = Name;
                    fiup.Url = Url;
                    obj.SaveChanges();
                    return true;
                }
                else if (existe == 0) {
                    FileJustificacion fi = new FileJustificacion();
                    fi.Personal_Id = Personal;
                    fi.Fecha = Fecha;
                    fi.Tipo = Tipo;
                    fi.Name = Name;
                    fi.Url = Url;
                    obj.AddToFileJustificacion(fi);
                    obj.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public string Get_DeleteFileJustificacion(string Personal,DateTime Fecha,string Tipo) { 
            using(ContextMaestro obj=new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection())){
                int existe = obj.FileJustificacion.Where(x => x.Personal_Id == Personal && x.Fecha == Fecha && x.Tipo == Tipo).Count();
                if (existe == 1)
                {
                    FileJustificacion fi = obj.FileJustificacion.Where(x => x.Personal_Id == Personal && x.Fecha == Fecha && x.Tipo == Tipo).First();
                    
                    return fi.Name;
                }
                else {
                    return "";
                }
            
            }
        }
    }

    public class MarcacionesMalPersonal {
        public string Solicitado { get; set; }
        public string Estado { get; set; }
        public string Realizado { get; set; }
        public string Asistencia_Id { get; set; }
        public string Personal_Id { get; set; }
        public string Tipo { get; set; }
        public string FechaMarc { get; set; }
        public string Dia { get; set; }
        public string HIH { get; set; }
        public string HFH { get; set; }
        public string HIM { get; set; }
        public string HSM { get; set; }
        public string THO { get; set; }
        public string OBS { get; set; }
        public string HES { get; set; }
        public string HEA { get; set; }
        public string HED { get; set; }
        public string MinTard { get; set; }
        public string Falta { get; set; }


    }
    public class MarcacionesCorPersonal
    {
        public string Solicitado { get; set; }
        public string Estado { get; set; }
        public string Realizado { get; set; }
        public string Asistencia_Id { get; set; }
        public string Personal_Id { get; set; }
        /*public string Tipo { get; set; }*/
        public string FechaMarc { get; set; }
        public string Dia { get; set; }
        public string HIH { get; set; }
        public string HFH { get; set; }
        public string HIM { get; set; }
        public string HSM { get; set; }
        public string THO { get; set; }
        public string OBS { get; set; }
        public string HES { get; set; }
        public string HEA { get; set; }
        public string HED { get; set; }
        public string MinTard { get; set; }
        public string Falta { get; set; }

    }
    public class JustificacionEdit {
        public DateTime Fecha { get; set; }
        public string HIR { get; set; }
        public string HSR { get; set; }
        public string HIP { get; set; }
        public string HSP { get; set; }
        public string HIE { get; set; }
        public string HSE { get; set; }
        public string MI { get; set; }
        public string MS { get; set; }
    }


}

