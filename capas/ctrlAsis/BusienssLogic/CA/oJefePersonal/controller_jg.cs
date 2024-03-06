using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using Presistence.Customs;
using System.Data;
using Presistence;

namespace BusienssLogic.CA.oJefePersonal
{
    public class controller_jg
    {
        private static controller_jg instance = null;
        public static controller_jg getinstance() {
            return instance == null ? instance = new controller_jg() : instance;
        }
        public ArrayList getGerentesJefesByLocalidad(string pr1)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("SP_ListarGerentesJefesMaster", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SeccionId", pr1.Trim());
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    ArrayList rlist = new ArrayList();
                    while (dr.Read())
                    {
                        object data = new
                        {
                            a = dr.GetValue(0).ToString(),
                            b = dr.GetValue(1).ToString(),
                            c = dr.GetValue(2).ToString(),
                            d = dr.GetValue(3).ToString(),
                            e = dr.GetValue(4).ToString(),
                            f = dr.GetValue(5).ToString(),
                            g = dr.GetValue(6).ToString(),
                            h = dr.GetValue(7).ToString()
                        };
                        rlist.Add(data);
                    }
                    return rlist;
                }
            }  
        
        }
        public ArrayList getPersonalAdd(string pr1,string pr2,string pr3,string pr4) {
            using (ContextMaestro contex = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection())) {

                List<string> periodos = new List<string>();
                periodos.AddRange((from c in contex.Periodo
                                   where c.Estado_Id == "02"
                                   select new { c.Periodo_Id, c.Fecha_Ini })
                                 .OrderByDescending(o => o.Fecha_Ini).Take(3).ToList().Select(s => s.Periodo_Id));

                ArrayList rList = new ArrayList();
                var query = from p in contex.Personal
                            join pa in contex.Personal_activo on p.Personal_Id equals pa.Personal_Id
                            join c in contex.Cargo on pa.Cargo_Id equals c.Cargo_id
                            join ca in contex.Categoria_Auxiliar on pa.Categoria_Auxiliar_Id equals ca.Categoria_Auxiliar_Id
                            join ca2 in contex.Categoria_Auxiliar2 on pa.Categoria_Auxiliar2_Id equals ca2.Categoria_Auxiliar2_Id
                            //join l in contex.areas_planillas_sofya on pa.Area_Id equals l.Area_Id // modificado 02.10.2020
                            join l in contex.RH_Area on pa.Area_Id equals l.Area_Id
                            where periodos.Contains(pa.Periodo_Id)
                            && l.Area_Id.Contains(pr1)
                            && ca.Categoria_Auxiliar_Id.Contains(pr2)
                            && ca2.Categoria_Auxiliar2_Id.Contains(pr3)
                            && (p.Apellido_Paterno + " " + p.Apellido_Materno + " " + p.Nombres).Contains(pr4)
                            orderby l.Descripcion,ca.Descripcion,ca2.Descripcion,c.Descripcion,p.Apellido_Paterno
                            select new { 
                                a=p.Personal_Id,
                                b=p.Apellido_Paterno+" "+p.Apellido_Materno+", "+p.Nombres,
                                c=c.Descripcion,
                                d=ca.Descripcion,
                                e=ca2.Descripcion,
                                f=l.Descripcion                            
                            };
                rList.AddRange(query.ToList());
                return rList;
            }
        }
        public string addPersonalGJ(string pr1, string pr2, string pr3, string pr4, string pr5, string pr6) {
            try
            {
                using (ContextMaestro contex = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    if (pr1 == "")
                    {
                        List<string> loc = new List<string>();
                        //loc.AddRange(contex.areas_planillas_sofya.Where(x => x.Area_Id != "14").Select(s => s.Area_Id)); // modificado 02.10.2020
                        loc.AddRange(contex.RH_Area.Where(x => x.Area_Id != "00").Select(s => s.Area_Id));
                        for (int i = 0; i <= loc.Count - 1; i++)
                        {
                            string localidad = loc[i];
                            MasterGJ obj = new MasterGJ();
                            obj.Localidad_Id = localidad;
                            obj.Area_Id = pr2;
                            obj.Seccion_Id = pr3;
                            obj.Gerente_Id = pr5;
                            obj.Jefe_Id = pr6;
                            obj.Estado = 1;
                            contex.AddToMasterGJ(obj);
                            contex.SaveChanges();
                        }
                        return "true#Actualizado correctamente.";
                    }
                    else
                    {
                        MasterGJ obj = new MasterGJ();
                        obj.Localidad_Id = pr1;
                        obj.Area_Id = pr2;
                        obj.Seccion_Id = pr3;
                        obj.Gerente_Id = pr5;
                        obj.Jefe_Id = pr6;
                        obj.Estado = 1;
                        contex.AddToMasterGJ(obj);
                        contex.SaveChanges();
                        return "true#Actualizado correctamente.";
                    }

                }
            }catch(Exception ex){
                if (ex.InnerException != null)
                {
                    return "false#Error: " + ex.InnerException.Message;
                }
                else { return "false#Error: " + ex.Message; }
            }
        }
        public string Procesar(string codigo) {
            try
            {
                string localidad = codigo.Substring(0, 2);
                string area = codigo.Substring(2, 2);
                string secc = codigo.Substring(4, 2);
                using (ContextMaestro contex = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {

                    int existe = contex.MasterGJ.Where(x => x.Localidad_Id == localidad.Trim() && x.Area_Id == area.Trim() && x.Seccion_Id == secc.Trim()).Count();
                    if (existe == 0)
                    {
                        return "false#La información no existe.";
                    }
                    List<MasterGJ> master = new List<MasterGJ>();
                    master.AddRange(contex.MasterGJ.Where(x => x.Localidad_Id == localidad.Trim() && x.Area_Id == area.Trim() && x.Seccion_Id == secc.Trim()).ToList());
                    for (int i = 0; i <= master.Count - 1; i++)
                    {
                        MasterGJ gj = master[i];
                        if (gj.Gerente_Id.Trim() == "" || gj.Jefe_Id.Trim() == "")
                        {
                            return "false#La configuración no esta completada.";
                        }

                        List<string> personal = new List<string>();
                        List<string> periodos = new List<string>();
                        periodos.AddRange((from c in contex.Periodo
                                           where c.Estado_Id == "02"
                                           select new { c.Periodo_Id, c.Fecha_Ini })
                                         .OrderByDescending(o => o.Fecha_Ini).Take(3).ToList().Select(s => s.Periodo_Id));

                        personal.AddRange(contex.Personal_activo.Where(x => periodos.Contains(x.Periodo_Id) && x.Area_Id == localidad
                            && x.Categoria_Auxiliar_Id == area && x.Categoria_Auxiliar2_Id == secc).Select(s => s.Personal_Id));

                        controller_JefePersonal.getInstance().AsignarGerenteJefe(gj.Gerente_Id, gj.Jefe_Id, personal);

                    }

                    return "true#Información procesada correctamente.";
                }
            }catch (Exception ex) {
                if (ex.InnerException != null) {
                    return "false#Error: " + ex.InnerException.Message;
                }
                else { return "false#Error: " + ex.Message; }
            }
        }
    }
}
