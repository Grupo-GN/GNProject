using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presistence;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
namespace BusienssLogic.CA.oAsignarTurnoMasivos
{
    public class Controller_MantAsignarTurnoMasivos
    {

        private static Controller_MantAsignarTurnoMasivos Instance = null;
        public static Controller_MantAsignarTurnoMasivos GetInstance()
        {
            return Instance == null ? Instance = new Controller_MantAsignarTurnoMasivos() : Instance;
        }

        public ArrayList Get_Planillas_List()
        {

            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rlist = new ArrayList();

                var query = from p in obj.Planilla
                            where p.Estado_Id == "01"
                            //where p.Planilla_Id == "01" || p.Planilla_Id == "04"
                            select new { p.Planilla_Id, p.Descripcion };


                rlist.AddRange(query.ToList());
                return rlist;
                //return obj.Planilla.OrderBy(o => o.Planilla_Id).Skip(inicio).Take(FINALLROWS).ToList();

            }
        }

        //nuevo 1.10.2020


        public ArrayList Get_Localidades_List(String Personal_Id)
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rList = new ArrayList();
                if (Personal_Id == "")
                {
                    var query = from c in obj.RH_Area
                                where c.Area_Id.Trim() != "00"
                                select new { c.Area_Id, c.Descripcion };
                    rList.AddRange(query.ToList());
                    return rList;
                }

                string nivel = "";
                nivel = obj.UsuarioPlanilla.Where(x => x.Personal_Id == Personal_Id).First().NivelAcceso;

                //datos 
                if (nivel == "01")
                {
                    var query = from c in obj.RH_Area
                                where c.Area_Id.Trim() != "00"
                                select new { c.Area_Id, c.Descripcion };
                    rList.AddRange(query.ToList());
                }
                else
                {
                    var query = from c in obj.RH_Area
                                where c.Area_Id.Trim() != "00"
                                select new { c.Area_Id, c.Descripcion };
                    rList.AddRange(query.ToList());

                }
                return rList;
            }
        }

        //antiguo
        public List<areas_planillas_sofya> Get_Localidades_List_02(string Personal_Id)
        {

            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                List<areas_planillas_sofya> aList = new List<areas_planillas_sofya>();
                string nivel = "";
                nivel = obj.UsuarioPlanilla.Where(x => x.Personal_Id == Personal_Id).First().NivelAcceso;
                if (nivel == "01")
                {
                    aList = obj.areas_planillas_sofya.Where(x => x.Area_Id != "14").ToList();
                    areas_planillas_sofya todo = new areas_planillas_sofya();
                    todo.Area_Id = "";
                    todo.descripcion = "-TODOS-";
                    aList.Add(todo);
                }
                else if (nivel == "02")
                {
                    aList = obj.areas_planillas_sofya.Where(x => x.Area_Id != "14").ToList();
                    areas_planillas_sofya todo = new areas_planillas_sofya();
                    todo.Area_Id = "";
                    todo.descripcion = "-TODOS-";
                    aList.Add(todo);
                }
                else if (nivel == "03")
                {
                    string localidad = obj.Personal_activo.Where(x => x.Personal_Id == Personal_Id).OrderByDescending(o => o.Periodo_Id).First().Area_Id;
                    aList = obj.areas_planillas_sofya.Where(x => x.Area_Id == localidad).ToList();
                }

                return aList;
            }
        }

        public ArrayList Get_Periodos_List(string Planilla)
        {

            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rList = new ArrayList();
                var query = from p in obj.Periodo
                            join pa in obj.Periodo_Asistencia on p.Descripcion equals pa.Periodo
                            where /*p.Estado_Id == "02"
                            && */p.Planilla_Id == Planilla
                            select new
                            {
                                p.Periodo_Id,
                                p.Descripcion,
                                p.Fecha_Ini,
                                p.Fecha_Fin,
                                p.Estado_Id
                            };
                query = query.OrderByDescending(o => o.Fecha_Ini);
                rList.AddRange(query.ToList());
                return rList;
            }
        }

        public ArrayList Get_Areas_List()
        {

            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rlist = new ArrayList();

                var query = from p in obj.Categoria_Auxiliar
                            select new { p.Categoria_Auxiliar_Id, p.Descripcion };


                rlist.AddRange(query.ToList());
                return rlist;
                //return obj.Planilla.OrderBy(o => o.Planilla_Id).Skip(inicio).Take(FINALLROWS).ToList();

            }
        }

        private static int FINALLROWS = 12;
        public ArrayList Get_AsignarTurnoMasivos_List(string Periodo_id, string seccion, string area_id, int inicio, string Personal_Id, string Jefe_Id)
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rlist = new ArrayList();

                string nivel = "";
                nivel = obj.UsuarioPlanilla.Where(x => x.Personal_Id == Personal_Id).First().NivelAcceso;

                if (nivel == "01"  ) {
                    var query = from per in obj.Personal
                                join ho in obj.Horarios on per.Horario_Id equals ho.Horario_Id into detPH
                                from ph in detPH.DefaultIfEmpty()
                                join perA in obj.Personal_activo on per.Personal_Id equals perA.Personal_Id
                                //join are in obj.areas_planillas_sofya on perA.Area_Id equals are.Area_Id//antiguo
                                join are in obj.RH_Area on perA.Area_Id equals are.Area_Id
                                join cat in obj.Categoria_Auxiliar on perA.Categoria_Auxiliar_Id equals cat.Categoria_Auxiliar_Id
                                join cat2 in obj.Categoria_Auxiliar2 on perA.Categoria_Auxiliar2_Id equals cat2.Categoria_Auxiliar2_Id
                                //join jp in obj.Jefe_Personal on per.Personal_Id equals jp.Personal_Id
                                where perA.Periodo_Id == Periodo_id
                                && perA.Categoria_Auxiliar_Id.Contains(seccion)
                                && perA.Area_Id.Contains(area_id)
                                //&& jp.Jefe_Id.Contains(Jefe_Id)
                                select new
                                {
                                    per.Personal_Id,
                                    Nombres = per.Apellido_Paterno + " " + per.Apellido_Materno + " " + per.Nombres,
                                    Horario_Id = ph == null ? 0 : ph.Horario_Id,
                                    Horario = ph == null ? "Sin Definir" : ph.Nombre,
                                    Localidad = are.Descripcion,
                                    Seccion = cat.Descripcion,
                                    Area = cat2.Descripcion

                                };

                    query = query.OrderBy(o => o.Nombres);//.Skip(inicio).Take(FINALLROWS);
                    rlist.AddRange(query.ToList());
                }
                else if (  nivel == "02")
                {
                    var query = from per in obj.Personal
                                join ho in obj.Horarios on per.Horario_Id equals ho.Horario_Id into detPH
                                from ph in detPH.DefaultIfEmpty()
                                join perA in obj.Personal_activo on per.Personal_Id equals perA.Personal_Id
                                //join are in obj.areas_planillas_sofya on perA.Area_Id equals are.Area_Id//antiguo
                                join are in obj.RH_Area on perA.Area_Id equals are.Area_Id
                                join cat in obj.Categoria_Auxiliar on perA.Categoria_Auxiliar_Id equals cat.Categoria_Auxiliar_Id
                                join cat2 in obj.Categoria_Auxiliar2 on perA.Categoria_Auxiliar2_Id equals cat2.Categoria_Auxiliar2_Id
                                join jp in obj.Jefe_Personal on per.Personal_Id equals jp.Personal_Id
                                where perA.Periodo_Id == Periodo_id
                                && perA.Categoria_Auxiliar_Id.Contains(seccion)
                                && perA.Area_Id.Contains(area_id)
                                && jp.Jefe_Id.Contains(Jefe_Id)
                                select new
                                {
                                    per.Personal_Id,
                                    Nombres = per.Apellido_Paterno + " " + per.Apellido_Materno + " " + per.Nombres,
                                    Horario_Id = ph == null ? 0 : ph.Horario_Id,
                                    Horario = ph == null ? "Sin Definir" : ph.Nombre,
                                    Localidad = are.Descripcion,
                                    Seccion = cat.Descripcion,
                                    Area = cat2.Descripcion

                                };

                    query = query.OrderBy(o => o.Nombres);//.Skip(inicio).Take(FINALLROWS);
                    rlist.AddRange(query.ToList());
                }

                else if (nivel == "03") {

                    var query = from per in obj.Personal
                                join ho in obj.Horarios on per.Horario_Id equals ho.Horario_Id into detPH
                                from ph in detPH.DefaultIfEmpty()
                                join perA in obj.Personal_activo on per.Personal_Id equals perA.Personal_Id
                                //join are in obj.areas_planillas_sofya on perA.Area_Id equals are.Area_Id//antiguo
                                join are in obj.RH_Area on perA.Area_Id equals are.Area_Id
                                join cat in obj.Categoria_Auxiliar on perA.Categoria_Auxiliar_Id equals cat.Categoria_Auxiliar_Id
                                join cat2 in obj.Categoria_Auxiliar2 on perA.Categoria_Auxiliar2_Id equals cat2.Categoria_Auxiliar2_Id
                                join jefe in obj.Jefe_Personal on per.Personal_Id equals jefe.Personal_Id
                                where perA.Periodo_Id == Periodo_id
                               /* && perA.Categoria_Auxiliar_Id.Contains(seccion)*/
                                && perA.Area_Id.Contains(area_id)
                                && jefe.Jefe_Id.Contains(Personal_Id)
                                select new
                                {
                                    per.Personal_Id,
                                    Nombres = per.Apellido_Paterno + " " + per.Apellido_Materno + " " + per.Nombres,
                                    Horario_Id= ph == null ? 0 : ph.Horario_Id,
                                   Horario = ph == null ? "Sin Definir" : ph.Nombre,
                                    Localidad = are.Descripcion,
                                    Seccion = cat.Descripcion,
                                    Area = cat2.Descripcion

                                };

                    query = query.OrderBy(o => o.Nombres);//.Skip(inicio).Take(FINALLROWS);
                    rlist.AddRange(query.ToList());
                }else if(nivel=="04"){
                    var query = from per in obj.Personal
                                join ho in obj.Horarios on per.Horario_Id equals ho.Horario_Id into detPH
                                from ph in detPH.DefaultIfEmpty()
                                join perA in obj.Personal_activo on per.Personal_Id equals perA.Personal_Id
                                //join are in obj.areas_planillas_sofya on perA.Area_Id equals are.Area_Id//antiguo 1.10.2020
                                join are in obj.RH_Area on perA.Area_Id equals are.Area_Id
                                join cat in obj.Categoria_Auxiliar on perA.Categoria_Auxiliar_Id equals cat.Categoria_Auxiliar_Id
                                join cat2 in obj.Categoria_Auxiliar2 on perA.Categoria_Auxiliar2_Id equals cat2.Categoria_Auxiliar2_Id
                                where perA.Periodo_Id == Periodo_id
                                && per.Personal_Id.Contains(Personal_Id)
                                select new
                                {
                                    per.Personal_Id,
                                    Nombres = per.Apellido_Paterno + " " + per.Apellido_Materno + " " + per.Nombres,
                                    Horario_Id = ph == null ? 0 : ph.Horario_Id,
                                    Horario = ph == null ? "Sin Definir" : ph.Nombre,
                                    Localidad = are.Descripcion,
                                    Seccion = cat.Descripcion,
                                    Area = cat2.Descripcion

                                };

                    query = query.OrderBy(o => o.Nombres);//.Skip(inicio).Take(FINALLROWS);
                    rlist.AddRange(query.ToList());
                }



                return rlist;

            }
        }

        public ArrayList Get_TurnoAsignar_List()
        {

            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rlist = new ArrayList();

                var query = from t in obj.Turnos
                            select new { t.Turno_Id, t.Nombre };


                rlist.AddRange(query.ToList());
                return rlist;
                //return obj.Planilla.OrderBy(o => o.Planilla_Id).Skip(inicio).Take(FINALLROWS).ToList();

            }
        }

        public List<Turnos> Get_TurnoAsignarLabel_List(int Turno_Id)
        {

            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                List<Turnos> rlist = new List<Turnos>();
                rlist.AddRange(obj.Turnos.Where(o=> o.Turno_Id == Turno_Id).ToList());
                
                return rlist;
               
            }
        }

        public string Get_TurnoAsignar_Proceso(string Personal,int turno,int cant,string fechaini,string fechafin,int alter,int dias) {
            try {
                using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion())) {
                    using (SqlCommand cmd = new SqlCommand("usp_AsignaTurnoMasivo", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Personal_Id", Personal);
                        cmd.Parameters.AddWithValue("@Turno_Id", turno);
                        cmd.Parameters.AddWithValue("@Cantidad", cant);
                        cmd.Parameters.AddWithValue("@Delimitador", "|");
                        cmd.Parameters.AddWithValue("@FechaInicio",DateTime.Parse(fechaini));
                        cmd.Parameters.AddWithValue("@FechaFin", DateTime.Parse(fechafin));
                        cmd.Parameters.AddWithValue("@Alternado", alter);
                        cmd.Parameters.AddWithValue("@DiasAlterna",dias);
                        cn.Open();
                        List<string> rsul = new List<string>();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read()) {
                            rsul.Add(dr.GetValue(0).ToString());
                            rsul.Add(dr.GetValue(1).ToString());                        
                        }
                        if (rsul.Count > 0)
                        {
                            string pro = rsul[0].ToString();
                            string mensaje = rsul[1].ToString();
                            if (int.Parse(pro) < 1)
                            {
                                return "false#.::Error > " + mensaje;
                            }
                            else {
                                return "true#" + mensaje;
                            }
                        }
                        else {
                            return "false#Intentelo nuevamente.";
                        }
                    }
                
                }

            }catch(Exception ex){
                return "false#.::Error > " + ex.Message;
            }
        
        }

       
    }
}
