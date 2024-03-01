using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using Presistence;

namespace BusienssLogic.Acceso
{
    public class controller_AccesoSistema
    {
        private static controller_AccesoSistema Instance = null;
        public static controller_AccesoSistema Get_Instance() {
            return Instance == null ? Instance = new controller_AccesoSistema() : Instance;
        }
        public UsuarioPlanilla Get_Acceder_Sistema(string Usuario,string Password, String rucEmpresa) {
            try
            {
                String codEmpresaConnection = "ContextMaestro_" + rucEmpresa;
                if (System.Configuration.ConfigurationManager.ConnectionStrings[codEmpresaConnection] == null)
                {
                    throw new Exception("Empresa no configurada.");
                }

                using (ContextMaestro obj = new ContextMaestro("name=" + codEmpresaConnection))
                {
                    int existe = obj.UsuarioPlanilla.Where(x => x.UsuarioName == Usuario && x.Password == Password && x.Estado == "01").Count();
                    if (existe == 1)
                    {
                        return obj.UsuarioPlanilla.Where(x => x.UsuarioName == Usuario && x.Password == Password && x.Estado == "01").First();
                    }
                    else
                    {
                        return null;
                    }

                }
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public UsuarioLog Get_DatosUsuario_Logeo(string Personal_Id)
        {
            if (Personal_Id == "000000")
            {
                UsuarioLog usuAdmi = new UsuarioLog();
                usuAdmi.Localidad_Id = "00";
                usuAdmi.NivelAcc = "01";
                usuAdmi.Personal_Id = Personal_Id;
                usuAdmi.PersonalNombres = "Administrador";
                return usuAdmi;
            }
            else
            {
                using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    UsuarioLog usu = new UsuarioLog();
                    var query = from p in obj.Personal
                                join u in obj.UsuarioPlanilla on p.Personal_Id equals u.Personal_Id
                                where p.Personal_Id == Personal_Id
                                select new
                                {
                                    p.Personal_Id,
                                    PersonalName = p.Apellido_Paterno + " " + p.Apellido_Materno + ", " + p.Nombres,
                                    p.Area_Id,
                                    u.NivelAcceso
                                };
                    usu.Personal_Id = query.First().Personal_Id;
                    usu.PersonalNombres = query.First().PersonalName;
                    usu.Localidad_Id = query.First().Area_Id;
                    usu.NivelAcc = query.First().NivelAcceso;

                    //Obtiene datos del personal del ultimo periodo activo
                    var datosPeriodo = from pa in obj.Personal_activo
                                       join per in obj.Periodo //on pa.Periodo_Id equals per.Periodo_Id
                                       on new { pa.Planilla_Id, pa.Periodo_Id } equals new { per.Planilla_Id, per.Periodo_Id }
                                       where pa.Personal_Id == Personal_Id && per.Estado_Id == "02"
                                       orderby pa.Periodo_Id descending 
                                       select new
                                      {
                                          pa.Planilla_Id,
                                          pa.Area_Id,
                                          pa.Categoria_Auxiliar_Id,
                                          pa.Categoria_Auxiliar2_Id
                                      };
                    usu.Planilla_Id = datosPeriodo.First().Planilla_Id;
                    usu.Localidad_Id = datosPeriodo.First().Area_Id;
                    usu.CatAuxiliar_Id = datosPeriodo.First().Categoria_Auxiliar_Id;
                    usu.CatAuxiliar2_Id = datosPeriodo.First().Categoria_Auxiliar2_Id;
                    //Obtiene datos del personal del ultimo periodo activo

                    return usu;
                }
            }
        }
        public string Get_ValidarDatosUsuario_Logeo(string Personal_Id)
        {

                using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    UsuarioLog usu = new UsuarioLog();
                    if (Personal_Id != "000000")
                    {
                        var query = from p in obj.Personal
                                    join u in obj.UsuarioPlanilla on p.Personal_Id equals u.Personal_Id
                                    where p.Personal_Id == Personal_Id
                                    select new
                                    {
                                        p.Personal_Id,
                                        PersonalName = p.Apellido_Paterno + " " + p.Apellido_Materno + ", " + p.Nombres,
                                        p.Area_Id,
                                        u.NivelAcceso,
                                        u.UsuarioName,
                                        u.Password
                                    };
                        usu.Personal_Id = query.First().Personal_Id;
                        usu.PersonalNombres = query.First().PersonalName;
                        usu.Localidad_Id = query.First().Area_Id;
                        usu.NivelAcc = query.First().NivelAcceso;

                        if (query.First().UsuarioName == query.First().Password)
                        {
                            return "true#Por razones de seguridad debe cambiar su contraseña.";
                        }
                        else
                        {
                            return "false#";
                        }
                    }
                    else {
                        usu.Personal_Id = "000000";
                        usu.PersonalNombres = "Administrador";
                        usu.Localidad_Id = "";
                        usu.NivelAcc = "01";
                        return "false#Administrador";
                    }
                }
            
        }
        public bool CambiarClaveUsuario_Save(string Personal_Id, string ClaveAnterior, string ClaveNueva)
        {
            try
            {
                using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {

                    int lineas = obj.UsuarioPlanilla.Where(o => o.Personal_Id == Personal_Id && o.Password == ClaveAnterior).Count();
                    if (lineas == 1)
                    {
                        UsuarioPlanilla usu = obj.UsuarioPlanilla.Where(o => o.Personal_Id == Personal_Id).First();
                        usu.Password = ClaveNueva;
                        obj.SaveChanges();
                        string bodyhtml = "<!DOCTYPE html><html><head><meta charset=\"UTF-8\"><title>Cedenciales</title></head><body>";
	                    bodyhtml += "<table style=\"width:100%;\"><tr><td style=\"width:150px;text-align:right;font-weight: bold;\">Estimad#1:</td><td>#2</td>";
		                bodyhtml += "</tr><tr><td colspan=\"2\" style=\"font-weight: bold;\">La siguiente información le servirá para acceder al sistema de control de asistencia de Lima Gas:</td>";
		                bodyhtml += "</tr><tr><td style=\"width:150px;text-align:right;font-weight: bold;\">Usuario: </td><td>#3</td></tr><tr><td style=\"width:150px;text-align:right;font-weight: bold;\">Password: </td>";
                        bodyhtml += "<td>#4</td></tr><tr><td colspan=\"2\" style=\"font-weight: bold;\">Esta información es confidencial, evite que otras personas la conozcan.</td>";
		                bodyhtml +="</tr></table></body></html>";
                        Personal perso = new Personal();
                        perso = obj.Personal.Where(x => x.Personal_Id == Personal_Id).First();
                        if (perso.Sexo_Id == "01")
                        {
                            bodyhtml=bodyhtml.Replace("#1", "o");
                        }
                        else {
                            bodyhtml = bodyhtml.Replace("#1", "a");
                        }
                        bodyhtml = bodyhtml.Replace("#2", perso.Apellido_Paterno + " " + perso.Apellido_Materno + ", " + perso.Nombres);
                        bodyhtml = bodyhtml.Replace("#3", usu.UsuarioName);
                        bodyhtml = bodyhtml.Replace("#4", usu.Password);
                        string correo = perso.email;
                        List<string> copias = new List<string>();
                        copias.Add("ezevallos@limagas.com");
                        Utils.controller_SendSMTP.get_instance().sendMail(correo, "Acceso - Control de Asistencia", bodyhtml, copias);
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public string GetEmailPersonalCambiarClave(string Personal_Id)
        {
            try
            {
                using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {

                    int lineas = obj.Personal.Where(o => o.Personal_Id == Personal_Id).Count();
                    if (lineas == 1)
                    {
                        Personal usu = obj.Personal.Where(o => o.Personal_Id == Personal_Id).First();
                        return usu.email;
                    }
                    return "";
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public string GetLlaveEncriptar()
        {
            string llave = "", razon = "", ruc = "";
            using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
            {
                string comando = "SELECT Descripcion,Ruc FROM Compania WHERE Compania_Id='01'";
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        razon = dr.GetValue(0).ToString();
                        ruc = dr.GetValue(1).ToString();
                    }
                }
            }
            llave = ruc.Substring(0, 3).Trim();
            llave += razon.Substring(razon.Length - 4, 4).Trim();
            llave += ruc.Substring(ruc.Length - 3, 2).Trim();
            llave += razon.Substring(0, 3).Trim();
            llave = llave.ToUpper();
            return llave;
        }
        public UsuarioPlanilla GetUsuarioAccesoSistema(string Usuario)
        {
            try
            {
                using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    int existe = obj.UsuarioPlanilla.Where(x => x.UsuarioName == Usuario && x.Estado == "01").Count();
                    if (existe == 1)
                    {
                        return obj.UsuarioPlanilla.Where(x => x.UsuarioName == Usuario && x.Estado == "01").First();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<UsuariosNN> ListUsuariosNN(string Planilla_Id, string Periodo_Id, string Localidad_Id, string Personal_Id)
        {

            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                List<UsuariosNN> rlist = new List<UsuariosNN>();
                string PeriodoDe = obj.Periodo.Where(x => x.Periodo_Id == Periodo_Id).First().Descripcion;
                int exiteperiodo = obj.Periodo_Asistencia.Where(x => x.Periodo == PeriodoDe).Count();
                if (exiteperiodo == 1)
                {
                    int periodoca = obj.Periodo_Asistencia.Where(x => x.Periodo == PeriodoDe).First().Periodo_Asistencia_Id;

                    string SPnom = string.Empty;
                    SPnom = "Sp_Lista_Usuarios";


                    using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
                    {
                        using (SqlCommand cmd = new SqlCommand(SPnom, cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;


                            if (Personal_Id.Count() == 0)
                            {
                                cmd.Parameters.AddWithValue("@planillaid", Planilla_Id);
                                cmd.Parameters.AddWithValue("@periodoid", Periodo_Id);
                                cmd.Parameters.AddWithValue("@localidad", Localidad_Id);
                                cmd.Parameters.AddWithValue("@personalid", Personal_Id);

                                cn.Open();
                                SqlDataReader dr = cmd.ExecuteReader();
                                while (dr.Read())
                                {
                                    UsuariosNN nov = new UsuariosNN();
                                    nov.Personal_Id = dr.GetValue(0).ToString();
                                    nov.PersonalNombres = dr.GetValue(1).ToString();
                                    nov.Usuario = dr.GetValue(2).ToString();
                                    nov.Clave = dr.GetValue(3).ToString();
                                    nov.nivelacceso = dr.GetValue(4).ToString();
                                    rlist.Add(nov);
                                }
                                cmd.Parameters.Clear();
                                cn.Close();

                            }


                        }
                    }

                }
                return rlist.OrderBy(o => o.PersonalNombres).ToList();

            }

        }

        public List<UsuariosNN> ListaUsuariosFind(string Id)
        {

            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                List<UsuariosNN> rlist = new List<UsuariosNN>();

                string SPnom = string.Empty;
                SPnom = "Sp_Lista_Usuarios_find";

                using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand(SPnom, cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", Id);
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            UsuariosNN nov = new UsuariosNN();
                            nov.Personal_Id = dr.GetValue(0).ToString();
                            nov.PersonalNombres = dr.GetValue(1).ToString();
                            nov.Usuario = dr.GetValue(2).ToString();
                            nov.Clave = dr.GetValue(3).ToString();
                            nov.nivelacceso = dr.GetValue(4).ToString();
                            rlist.Add(nov);
 
                        }
                        cmd.Parameters.Clear();
                        cn.Close();

                    }
                }

                return rlist.OrderBy(o => o.PersonalNombres ).ToList();


            }

        }

        public bool insertarUsuario(string Personal_Id, string Usuario, string Clave,string Acceso,string Estado)
        {
            try
            {
                using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {

                    int lineas = obj.UsuarioPlanilla.Where(o => o.Personal_Id == Personal_Id  && o.UsuarioName==Usuario).Count();
                    if (lineas == 1)
                    {
                        UsuarioPlanilla usu = obj.UsuarioPlanilla.Where(o => o.Personal_Id == Personal_Id && o.UsuarioName == Usuario).First();
                        usu.Password = Clave;
                        obj.SaveChanges();

                        return true;
                    }
                    else
                    {
                        UsuarioPlanilla Usu = new UsuarioPlanilla();
                        Usu.Personal_Id = Personal_Id;
                        Usu.UsuarioName = Usuario;
                        Usu.Password = Clave;
                        Usu.NivelAcceso = Acceso;
                        Usu.Estado = Estado;
                        obj.AddToUsuarioPlanilla(Usu);
                        obj.SaveChanges();
                        return true;
                    }
                   
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public string UpdateUsuarios(string Personal_Id, string Usuario, string Clave, string Acceso )
        {
            try
            {
                using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {

                    int lineas = obj.UsuarioPlanilla.Where(o => o.Personal_Id == Personal_Id && o.UsuarioName == Usuario).Count();
                    if (lineas == 1)
                    {
                        UsuarioPlanilla usu = obj.UsuarioPlanilla.Where(o => o.Personal_Id == Personal_Id && o.UsuarioName == Usuario).First();
                        usu.Password = Clave;
                        usu.NivelAcceso = Acceso;
                        obj.SaveChanges();

                        return "1";
                    }
                   
                    return "0";
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public string Insert_Usuarios(string id_personal, List<string> Rlist)
        {
            string msg = "";

            string s1;
            string personal_id = "";
                string usuario = "";
                string clave = "";
                string acceso = "";
                string estado = "";
                 int contador = -1;
            DataTable dt = new DataTable();
                foreach (var item in Rlist)
                {
                    contador = -1;
                    s1 = item.ToString();
                    dt = SplitData(s1);
                    foreach (DataRow rw in dt.Rows)
                    {
                        contador = contador + 1;
                        if (contador == 0)
                        {
                            personal_id =  rw[0].ToString();
                        }
                        if (contador == 1)
                        {
                            usuario =  rw[0].ToString();
                        }
                        if (contador == 2)
                        {
                        clave= rw[0].ToString();
                        }

                    if (contador == 3)
                    {
                        acceso = rw[0].ToString();
                    }

                    if (contador == 4)
                    {
                        estado = rw[0].ToString();
                    }

                   



                }
                bool dtdet = false;
                dtdet = insertarUsuario(personal_id, usuario, clave, acceso, estado);

                if (dtdet==false)
                {
                    msg = "0";
                    return msg;
                }
 

            }



            msg = "1";
            return msg;
        }

        DataTable SplitData(string valor)
        {
            DataTable dt = new DataTable();

            dt = RUNTABLA("delimitador", valor);
            return dt;
        }
        
        DataTable RUNTABLA(string NOMPRO, params object[] Lista)
        {
            string ConStr = Presistence.Customs.Conexion.getConexion();
            var cn = new SqlConnection(ConStr);
            //CREAR UN COMANDO PARA EJECUTAR EL PROCEDIMIENTO
            SqlCommand CMD = new SqlCommand(NOMPRO, cn);
            //SqlParameter PRM=new  SqlParameter();
            CMD.CommandType = CommandType.StoredProcedure;
            cn.Open();
            //PREPARAR AL COMANDO PARA QUE RECIBA VALORES
            SqlCommandBuilder.DeriveParameters(CMD);
            //ASIGNAR LOS VALORES A LOS PARAMETERS RESPECTIVO
            int CONTADOR = 0;
            //EXEC SPFECHA '12/11/96','10/11/98'
            //EQUIVALE LISTA(0)='12/11/96' LISTA(1)='10/11/98'
            foreach (SqlParameter PRM in CMD.Parameters)
            {
                if (PRM.ParameterName != "@RETURN_VALUE")
                {

                    PRM.Value = Lista[CONTADOR];
                    CONTADOR = CONTADOR + 1;
                }
            }

            SqlDataAdapter DA = new SqlDataAdapter(CMD);
            DataTable DT = new DataTable();
            DA.Fill(DT);
            cn.Close();
            return DT;

        }        
    }// fin de clase





    public class UsuarioLog {
        public string Personal_Id { get; set; }
        public string PersonalNombres { get; set; }
        public string Localidad_Id { get; set; }
        public string NivelAcc { get; set; }
        public string Planilla_Id { get; set; }
        public string CatAuxiliar_Id { get; set; }
        public string CatAuxiliar2_Id { get; set; }
    }

    public class UsuariosNN
    {
        public string Personal_Id { get; set; }
        public string PersonalNombres { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string nivelacceso { get; set; }
     
    }








}





