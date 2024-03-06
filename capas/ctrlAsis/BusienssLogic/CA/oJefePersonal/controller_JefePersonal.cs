using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Presistence;
using Presistence.Customs;
using System.Data;
using System.Data.SqlClient;
namespace BusienssLogic.CA.oJefePersonal
{
    public class controller_JefePersonal
    {
        private static controller_JefePersonal instance = null;
        public static controller_JefePersonal getInstance() {
            return instance == null ? instance = new controller_JefePersonal() : instance;
        }
        public ArrayList Get_Gerentes(string pr1)
        {
            using (ContextMaestro contex = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection())) {
               /* List<string> cargos = new List<string>();
                cargos.AddRange((from c in contex.Cargo where c.Descripcion.Contains("GERENTE") select c.Cargo_id).ToList());

                List<string> periodos = new List<string>();
                periodos.AddRange((from c in contex.Periodo
                                   where c.Estado_Id == "02" 
                                 select new{ c.Periodo_Id,c.Fecha_Ini })
                                 .OrderByDescending(o=> o.Fecha_Ini).Take(3).ToList().Select(s=> s.Periodo_Id));


                var query = from g in contex.Personal
                            join p in contex.Personal_activo on g.Personal_Id equals p.Personal_Id
                            where cargos.Contains(g.Cargo_Id)
                            && periodos.Contains(p.Periodo_Id)
                            select new
                            {
                                a=g.Personal_Id,
                                Gerente = g.Apellido_Paterno + " " + g.Apellido_Materno + ", " + g.Nombres
                            };
                ArrayList rList = new ArrayList();
                rList.AddRange(query.OrderBy(o=> o.Gerente).ToList());*/
                ArrayList rList = new ArrayList();
                string Personal_Id = pr1;
                string nivel = "";
                nivel = contex.UsuarioPlanilla.Where(x => x.Personal_Id == Personal_Id).First().NivelAcceso;
                if (nivel == "01")
                {
                    var query = from g in contex.Personal
                                join p in contex.MasterGJ on g.Personal_Id equals p.Gerente_Id
                                select new
                                {
                                    a = g.Personal_Id,
                                    Gerente = g.Apellido_Paterno + " " + g.Apellido_Materno + ", " + g.Nombres
                                };
                    rList.AddRange(query.Distinct().OrderBy(o => o.Gerente).ToList());
                    //rList.Add(new { a = "x0", Gerente ="-TODOS-"});
                }
                else if (nivel == "02")
                {
                    var query = from g in contex.Personal
                                join p in contex.MasterGJ on g.Personal_Id equals p.Gerente_Id
                                select new
                                {
                                    a = g.Personal_Id,
                                    Gerente = g.Apellido_Paterno + " " + g.Apellido_Materno + ", " + g.Nombres
                                };
                    rList.AddRange(query.Distinct().OrderBy(o => o.Gerente).ToList());
                    //rList.Add(new { a = "x0", Gerente = "-TODOS-" });
                }
                else if (nivel == "03")
                {
                    /*var query = from g in contex.Personal
                                join p in contex.MasterGJ on g.Personal_Id equals p.Gerente_Id
                                select new
                                {
                                    a = g.Personal_Id,
                                    Gerente = g.Apellido_Paterno + " " + g.Apellido_Materno + ", " + g.Nombres
                                };
                    rList.AddRange(query.OrderBy(o => o.Gerente).ToList());*/
                }
                return rList;
            }
        }
        public ArrayList Get_Jefes(string pr1)
        {
            using (ContextMaestro contex = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                /*List<string> cargos = new List<string>();
                cargos.AddRange((from c in contex.Cargo where c.Descripcion.Contains("JEFE") select c.Cargo_id).ToList());

                List<string> periodos = new List<string>();
                periodos.AddRange((from c in contex.Periodo
                                   where c.Estado_Id == "02"
                                   select new { c.Periodo_Id, c.Fecha_Ini })
                                 .OrderByDescending(o => o.Fecha_Ini).Take(3).ToList().Select(s => s.Periodo_Id));


                var query = from g in contex.Personal
                            join p in contex.Personal_activo on g.Personal_Id equals p.Personal_Id
                            join a in contex.areas_planillas_sofya on p.Area_Id equals a.Area_Id
                            where cargos.Contains(g.Cargo_Id)
                            && periodos.Contains(p.Periodo_Id)
                            select new
                            {
                                a = g.Personal_Id,
                                jefe = g.Apellido_Paterno + " " + g.Apellido_Materno + ", " + g.Nombres,
                                b = a.descripcion,
                                c = a.descripcion + " - " + g.Apellido_Paterno + " " + g.Apellido_Materno + ", " + g.Nombres
                            };
                ArrayList rList = new ArrayList();
                rList.AddRange(query.OrderBy(o => o.c).ToList());*/
                List<string> periodos = new List<string>();
                periodos.AddRange((from c in contex.Periodo
                                   where c.Estado_Id == "02"
                                   select new { c.Periodo_Id, c.Fecha_Ini })
                                 .OrderByDescending(o => o.Fecha_Ini).Take(3).ToList().Select(s => s.Periodo_Id));
                ArrayList rList = new ArrayList();
                string Personal_Id = pr1;
                string nivel = "";
                nivel = contex.UsuarioPlanilla.Where(x => x.Personal_Id == Personal_Id).First().NivelAcceso;
                if (nivel == "01")
                {
                    var query = from g in contex.Personal
                                join pa in contex.Personal_activo on g.Personal_Id equals pa.Personal_Id
                                join p in contex.MasterGJ on g.Personal_Id equals p.Jefe_Id
                                join a in contex.RH_Area on pa.Area_Id equals a.Area_Id
                                select new
                                {
                                    a = g.Personal_Id,
                                    jefe = g.Apellido_Paterno + " " + g.Apellido_Materno + ", " + g.Nombres,
                                    b = a.Descripcion,
                                    c = a.Descripcion + " - " + g.Apellido_Paterno + " " + g.Apellido_Materno + ", " + g.Nombres
                                };
                    rList.AddRange(query.Distinct().OrderBy(o => o.c).ToList());
                    rList.Add(new { a = "x0", jefe = "-TODOS-", b = "", c = "TODOS -" });
                }
                else if (nivel == "02")
                {
                    var query = from g in contex.Personal
                                join pa in contex.Personal_activo on g.Personal_Id equals pa.Personal_Id
                                join p in contex.MasterGJ on g.Personal_Id equals p.Jefe_Id
                                join a in contex.RH_Area on pa.Area_Id equals a.Area_Id
                                select new
                                {
                                    a = g.Personal_Id,
                                    jefe = g.Apellido_Paterno + " " + g.Apellido_Materno + ", " + g.Nombres,
                                    b = a.Descripcion,
                                    c = a.Descripcion + " - " + g.Apellido_Paterno + " " + g.Apellido_Materno + ", " + g.Nombres
                                };
                    rList.AddRange(query.Distinct().OrderBy(o => o.c).ToList());
                    rList.Add(new { a = "x0", jefe = "-TODOS-", b = "-", c = "TODOS -" });
                }
                else if (nivel == "03")
                {
                    /*var query = from g in contex.Personal
                                join p in contex.MasterGJ on g.Personal_Id equals p.Gerente_Id
                                select new
                                {
                                    a = g.Personal_Id,
                                    Gerente = g.Apellido_Paterno + " " + g.Apellido_Materno + ", " + g.Nombres
                                };
                    rList.AddRange(query.OrderBy(o => o.Gerente).ToList());*/
                }
                return rList;
            }
        }


        public ArrayList Get_Jefes_Gerente(string pr1,string gere)
        {
            using (ContextMaestro contex = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                
                List<string> periodos = new List<string>();
                periodos.AddRange((from c in contex.Periodo
                                   where c.Estado_Id == "02"
                                   select new { c.Periodo_Id, c.Fecha_Ini })
                                 .OrderByDescending(o => o.Fecha_Ini).Take(3).ToList().Select(s => s.Periodo_Id));
                ArrayList rList = new ArrayList();
                string Personal_Id = pr1;
                string nivel = "";
                nivel = contex.UsuarioPlanilla.Where(x => x.Personal_Id == Personal_Id).First().NivelAcceso;
                if (nivel == "01")
                {
                    var query = from g in contex.Personal
                                join pa in contex.Personal_activo on g.Personal_Id equals pa.Personal_Id
                                join p in contex.MasterGJ on g.Personal_Id equals p.Jefe_Id
                                join a in contex.RH_Area on pa.Area_Id equals a.Area_Id
                                where p.Gerente_Id == gere
                                select new
                                {
                                    a = g.Personal_Id,
                                    jefe = g.Apellido_Paterno + " " + g.Apellido_Materno + ", " + g.Nombres,
                                    b = a.Descripcion,
                                    c = a.Descripcion + " - " + g.Apellido_Paterno + " " + g.Apellido_Materno + ", " + g.Nombres
                                };
                    rList.AddRange(query.Distinct().OrderBy(o => o.c).ToList());
                    //rList.Add(new { a = "x0", jefe = "-TODOS-", b = "", c = "TODOS -" });
                }
                else if (nivel == "02")
                {
                    var query = from g in contex.Personal
                                join pa in contex.Personal_activo on g.Personal_Id equals pa.Personal_Id
                                join p in contex.MasterGJ on g.Personal_Id equals p.Jefe_Id
                                join a in contex.RH_Area on pa.Area_Id equals a.Area_Id
                                where p.Gerente_Id == gere
                                select new
                                {
                                    a = g.Personal_Id,
                                    jefe = g.Apellido_Paterno + " " + g.Apellido_Materno + ", " + g.Nombres,
                                    b = a.Descripcion,
                                    c = a.Descripcion + " - " + g.Apellido_Paterno + " " + g.Apellido_Materno + ", " + g.Nombres
                                };
                    rList.AddRange(query.Distinct().OrderBy(o => o.c).ToList());
                    //rList.Add(new { a = "x0", jefe = "-TODOS-", b = "-", c = "TODOS -" });
                }
                else if (nivel == "03")
                {
                    /*var query = from g in contex.Personal
                                join p in contex.MasterGJ on g.Personal_Id equals p.Gerente_Id
                                select new
                                {
                                    a = g.Personal_Id,
                                    Gerente = g.Apellido_Paterno + " " + g.Apellido_Materno + ", " + g.Nombres
                                };
                    rList.AddRange(query.OrderBy(o => o.Gerente).ToList());*/
                }
                return rList;
            }
        }

        public ArrayList getPersonal(string pr1, string pr2, string pr3, string pr4,string local,string area,string seccion)
        { 
            using(SqlConnection cn=new SqlConnection(Conexion.getConexion())){
                using (SqlCommand cmd = new SqlCommand("SP_ListarPersonalJefe", cn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@Localidad", pr1.Trim());
                    //cmd.Parameters.AddWithValue("@Area", pr2.Trim());
                    cmd.Parameters.AddWithValue("@Gerente", pr1.Trim());
                    cmd.Parameters.AddWithValue("@Jefe", pr2.Trim());
                    //cmd.Parameters.AddWithValue("@Seccion", pr3.Trim());
                    cmd.Parameters.AddWithValue("@Personal", pr4.Trim());

                    cmd.Parameters.AddWithValue("@Localidad", local.Trim());
                    cmd.Parameters.AddWithValue("@Area", area.Trim());
                    cmd.Parameters.AddWithValue("@Seccion", seccion.Trim());
                    cn.Open();
                    SqlDataReader dr=cmd.ExecuteReader();
                    ArrayList rlist = new ArrayList();
                    while(dr.Read()){
                        object data = new { planilla=dr.GetValue(0).ToString(),
                                            id = dr.GetValue(1).ToString(),
                                            personal = dr.GetValue(2).ToString(),
                                            cate1 = dr.GetValue(3).ToString(),
                                            cate2 = dr.GetValue(4).ToString(),
                                            gere = dr.GetValue(5).ToString(),
                                            jefe = dr.GetValue(6).ToString(),
                                            loc = dr.GetValue(7).ToString()
                        };
                        rlist.Add(data);
                    }
                    return rlist;
                }           
            }      
        }

        public string AsignarGerente(string gereid, List<string> personal)
        {
            try
            {
                using (ContextMaestro contex = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    for (int i = 0; i <= personal.Count - 1; i++)
                    {
                        string personalid = personal[i];
                        int act = contex.Jefe_Personal.Where(x => x.Personal_Id == personalid).Count();
                        if (act == 1)
                        {
                            Jefe_Personal upd = contex.Jefe_Personal.Where(x => x.Personal_Id == personalid && x.Gerente_Id==gereid).First();
                            upd.Gerente_Id = gereid;
                            contex.SaveChanges();
                        }

                    }
                    return "true#Actualizado correctamente.";

                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    return "false#Error: " + ex.InnerException.Message;
                }
                else
                {
                    return "false#Error: " + ex.Message;
                }

            }
        }
        public string AsignarJefe(string jefeid, List<string> personal)
        {
            try
            {
                using (ContextMaestro contex = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    for (int i = 0; i <= personal.Count - 1; i++)
                    {
                        string personalid = personal[i];
                        int act = contex.Jefe_Personal.Where(x => x.Personal_Id == personalid && x.Jefe_Id==jefeid).Count();
                        if (act == 0)
                        {
                            Jefe_Personal jep = new Jefe_Personal();
                            jep.Gerente_Id = "";
                            jep.Jefe_Id = jefeid;
                            jep.Personal_Id = personalid;
                            contex.AddToJefe_Personal(jep);
                            contex.SaveChanges();
                        }
                        else
                        {
                            string gerente = "";
                            string jefe = jefeid;

                            /*Jefe_Personal upd = contex.Jefe_Personal.Where(x => x.Personal_Id == personalid && x.Jefe_Id == jefeid).First();
                            gerente = upd.Gerente_Id;
                            contex.DeleteObject(upd);
                            contex.SaveChanges();*/

                            Jefe_Personal inser = new Jefe_Personal();
                            inser.Gerente_Id = gerente;
                            inser.Jefe_Id = jefe;
                            inser.Personal_Id = personalid;
                            contex.AddToJefe_Personal(inser);
                            contex.SaveChanges();
                        }
                    }
                    return "true#Actualizado correctamente.";
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    return "false#Error: " + ex.InnerException.Message;
                }
                else
                {
                    return "false#Error: " + ex.Message;
                }

            }
        }
        // jefe personal
        public string AddJefePersonalNW(Jefe_Personal jp)
        {
            string respuesta = "false#";
            using (SqlConnection cn = new SqlConnection(Conexion.getConexion()))
            {
                string command = "SP_AddJefePersonal";
                using (SqlCommand cmd = new SqlCommand(command, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Jefe_Id", jp.Gerente_Id); 
                    cmd.Parameters.AddWithValue("@Gerente_Id", jp.Jefe_Id);
                    cmd.Parameters.AddWithValue("@Personal_Id", jp.Personal_Id);
                    cmd.Parameters.AddWithValue("@Coordinador_Id", jp.Coordinador_Id);
                    cn.Open();
                    int irows = cmd.ExecuteNonQuery();
                    if (irows > 0)
                    {
                        respuesta = "true#Registro correctamente.";
                    }
                    else { respuesta = "false#No se actualizó ningún registro."; }
                }
            }
            return respuesta;
        }

        public string AsignarGerenteJefe(string gereid, string jefeid, List<string> personal)
        {
            try
            {
                using (ContextMaestro contex = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    string Str=string.Empty;
                    for (int i = 0; i <= personal.Count - 1; i++)
                    {
                        string personalid = personal[i];
                        int act = contex.Jefe_Personal.Where(x => x.Personal_Id == personalid && x.Gerente_Id==gereid && x.Jefe_Id == jefeid).Count();
                        if (act == 0)
                        {
                            Jefe_Personal jep = new Jefe_Personal();
                            jep.Gerente_Id = gereid;
                            jep.Jefe_Id = jefeid;
                            jep.Personal_Id = personalid;
                            jep.Coordinador_Id = "";

                            ////contex.AddToJefe_Personal(jep);
                            //contex.AddToJefe_Personal(jep);

                            //contex.SaveChanges();
                            Str = AddJefePersonalNW(jep);
                        }
                        else
                        {
                            string gerente = gereid;
                            string jefe = jefeid;

                           Jefe_Personal upd = contex.Jefe_Personal.Where(x => x.Personal_Id == personalid && x.Jefe_Id == jefeid).First();
                           upd.Gerente_Id = gerente;
                            upd.Jefe_Id = jefe;
                            contex.DeleteObject(upd);
                            contex.SaveChanges();

                            /*Jefe_Personal inser = new Jefe_Personal();
                            inser.Gerente_Id = gerente;
                            inser.Jefe_Id = jefe;
                            inser.Personal_Id = personalid;
                            contex.AddToJefe_Personal(inser);
                            contex.SaveChanges();*/
                        }
                    }
                    if (Str !="")
                    {
                        return Str;
                       } else
                    {
                        return "true#Actualizado correctamente.";
                    }
                    
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    return "false#Error: " + ex.InnerException.Message;
                }
                else
                {
                    return "false#Error: " + ex.Message;
                }

            }
        }
    }
}

