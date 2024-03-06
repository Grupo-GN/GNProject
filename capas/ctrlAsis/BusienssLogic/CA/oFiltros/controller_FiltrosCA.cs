using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Presistence;
using BusienssLogic.Acceso;

namespace BusienssLogic.CA.oFiltros
{
    public class controller_FiltrosCA
    {
        private static controller_FiltrosCA Instance = null;
        public static controller_FiltrosCA Get_Instance() {
            return Instance == null ? Instance = new controller_FiltrosCA() : Instance;
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
        public ArrayList Get_Periodo_Activo_By_CA(string Planilla_Id) {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection())) {
                ArrayList rList = new ArrayList();
                var query = from p in obj.Periodo
                            join pa in obj.Periodo_Asistencia on p.Descripcion equals pa.Periodo
                            where /*p.Estado_Id == "02"
                            && */p.Planilla_Id == Planilla_Id
                            select new { 
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
        public ArrayList Get_Periodos_Planilla(string Planilla_Id)
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rList = new ArrayList();
                var query = from p in obj.Periodo
                            where p.Estado_Id == "02"
                            && p.Planilla_Id == Planilla_Id
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
        // localida antigua 

        public List<areas_planillas_sofya> Get_Localidad_List_OLD(string Personal_Id)
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
                    //string localidad = obj.Personal_activo.Where(x => x.Personal_Id == Personal_Id).OrderByDescending(o => o.Periodo_Id).First().Area_Id;
                    List<string> periodos = obj.Personal_activo.Where(x => x.Personal_Id == Personal_Id).OrderByDescending(o => o.Periodo_Id).Skip(0).Take(3).Select(s => s.Periodo_Id).ToList();
                    List<string> localidades = new List<string>();
                    localidades.AddRange((from pa in obj.Personal_activo
                                          join jp in obj.Jefe_Personal on pa.Personal_Id equals jp.Personal_Id
                                          where jp.Jefe_Id == Personal_Id
                                          && periodos.Contains(pa.Periodo_Id)
                                          select pa.Area_Id).Distinct().ToList());

                    //aList = obj.areas_planillas_sofya.Where(x => x.Area_Id == localidad).ToList();
                    aList = obj.areas_planillas_sofya.Where(x => localidades.Contains(x.Area_Id)).ToList();
                }
                else if (nivel == "04")
                {
                    UsuarioLog usuLog = controller_AccesoSistema.Get_Instance().Get_DatosUsuario_Logeo(Personal_Id);

                    aList = obj.areas_planillas_sofya.Where(x => x.Area_Id == usuLog.Localidad_Id).ToList();
                }

                return aList;
            }
        }



        // fin localidad antigua
        //nueva 30.09.2020
        public ArrayList Get_Localidad_List_New(String Personal_Id)
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
                if (nivel=="01")
                {
                    var query = from c in obj.RH_Area
                                where c.Area_Id.Trim() != "00"
                                select new { c.Area_Id, c.Descripcion };
                    rList.AddRange(query.ToList());
                } else
                {
                    var query = from c in obj.RH_Area
                                where c.Area_Id.Trim() != "00"
                                select new { c.Area_Id, c.Descripcion };
                    rList.AddRange(query.ToList());

                }
                return rList;
            }
        }
        //fin 
        public List<RH_Area> Get_Localidad_List(string Personal_Id)
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                 
                List<RH_Area> aList = new List<RH_Area>();
                string nivel = "";
                nivel = obj.UsuarioPlanilla.Where(x => x.Personal_Id == Personal_Id).First().NivelAcceso;
                if (nivel == "01")
                {
                    aList= obj.RH_Area.Where(x => x.Area_Id != "00").ToList();
                    RH_Area todo = new RH_Area();
                    todo.Area_Id = "";
                    todo.Descripcion = "-TODOS-";
                    aList.Add(todo);
                }
                else if(nivel=="02"){
                    aList = obj.RH_Area.Where(x => x.Area_Id != "00").ToList();
                    RH_Area todo = new RH_Area();
                    todo.Area_Id = "";
                    todo.Descripcion = "-TODOS-";
                    aList.Add(todo);
                }
                else if (nivel == "03")
                {
                    //string localidad = obj.Personal_activo.Where(x => x.Personal_Id == Personal_Id).OrderByDescending(o => o.Periodo_Id).First().Area_Id;
                     List<string> periodos= obj.Personal_activo.Where(x => x.Personal_Id == Personal_Id).OrderByDescending(o => o.Periodo_Id).Skip(0).Take(3).Select(s=> s.Periodo_Id).ToList();
                    List<string> localidades = new List<string>();
                    localidades.AddRange((from pa in obj.Personal_activo
                                         join jp in obj.Jefe_Personal on pa.Personal_Id equals jp.Personal_Id
                                         where jp.Jefe_Id==Personal_Id
                                         && periodos.Contains(pa.Periodo_Id)
                                         select pa.Area_Id).Distinct().ToList());

                    //aList = obj.areas_planillas_sofya.Where(x => x.Area_Id == localidad).ToList();
                    aList = obj.RH_Area.Where(x =>localidades.Contains(x.Area_Id)).ToList();
                }
                else if (nivel == "04")
                {
                    UsuarioLog usuLog = controller_AccesoSistema.Get_Instance().Get_DatosUsuario_Logeo(Personal_Id);

                    aList = obj.RH_Area.Where(x => x.Area_Id == usuLog.Localidad_Id).ToList();
                }
                
                return aList;
            }
        }
        public ArrayList Get_Categoria_Auxiliar_List(string Personal_Id = "")
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rList = new ArrayList();
                if (Personal_Id == "")
                {
                    var query = from c in obj.Categoria_Auxiliar
                                where c.Categoria_Auxiliar_Id.Trim() != "00"
                                select new { c.Categoria_Auxiliar_Id, c.Descripcion };
                    rList.AddRange(query.ToList());
                    return rList;
                }

                string nivel = "";
                nivel = obj.UsuarioPlanilla.Where(x => x.Personal_Id == Personal_Id).First().NivelAcceso;

                if (nivel == "04")
                {
                    UsuarioLog usuLog = controller_AccesoSistema.Get_Instance().Get_DatosUsuario_Logeo(Personal_Id);

                    var query = from c in obj.Categoria_Auxiliar
                                where c.Categoria_Auxiliar_Id.Trim() != "00" && c.Categoria_Auxiliar_Id == usuLog.CatAuxiliar_Id
                                select new { c.Categoria_Auxiliar_Id, c.Descripcion };
                    rList.AddRange(query.ToList());
                }
                else
                {
                    var query = from c in obj.Categoria_Auxiliar
                                where c.Categoria_Auxiliar_Id.Trim() != "00"
                                select new { c.Categoria_Auxiliar_Id, c.Descripcion };
                    rList.AddRange(query.ToList());
                }
                return rList;
            }
        }
        public ArrayList Get_Categoria_Auxiliar2_List(string Cat_Aux, string Personal_Id = "")
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rList = new ArrayList();
                if (Personal_Id == "")
                {
                    var query = from c in obj.Categoria_Auxiliar2
                                where c.Categoria_Auxiliar2_Id.Trim() != "00"
                                && c.Categoria_Auxiliar_id.Contains(Cat_Aux)
                                select new { c.Categoria_Auxiliar2_Id, c.Descripcion };
                    rList.AddRange(query.ToList());
                    return rList;
                }

                string nivel = "";
                nivel = obj.UsuarioPlanilla.Where(x => x.Personal_Id == Personal_Id).First().NivelAcceso;

                if (nivel == "04")
                {
                    UsuarioLog usuLog = controller_AccesoSistema.Get_Instance().Get_DatosUsuario_Logeo(Personal_Id);

                    var query = from c in obj.Categoria_Auxiliar2
                                where c.Categoria_Auxiliar2_Id.Trim() != "00"
                                && c.Categoria_Auxiliar_id.Contains(Cat_Aux) && c.Categoria_Auxiliar2_Id == usuLog.CatAuxiliar2_Id
                                select new { c.Categoria_Auxiliar2_Id, c.Descripcion };
                    rList.AddRange(query.ToList());
                }
                else
                {
                    var query = from c in obj.Categoria_Auxiliar2
                                where c.Categoria_Auxiliar2_Id.Trim() != "00"
                                && c.Categoria_Auxiliar_id.Contains(Cat_Aux)
                                select new { c.Categoria_Auxiliar2_Id, c.Descripcion };
                    rList.AddRange(query.ToList());
                }
                return rList;
            }
        }
        public ArrayList Get_Categoria_List()
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rList = new ArrayList();
                var query = from c in obj.Categoria2
                            where (c.Categoria2_Id == "01" || c.Categoria2_Id == "02")
                            select new { c.Categoria2_Id, c.Descripcion };
                rList.AddRange(query.ToList());
                return rList;
            }
        }
        public ArrayList Get_PeriodoCA_By_Planilla(string Periodo_Id) {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rList = new ArrayList();
                if (Periodo_Id != "")
                {
                    string Descrip = obj.Periodo.Where(x => x.Periodo_Id == Periodo_Id).First().Descripcion;
                    var query = from p in obj.Periodo_Asistencia
                                where p.Periodo.Contains(Descrip)
                                select new
                                {
                                    p.Periodo_Asistencia_Id,
                                    p.Periodo,
                                    p.Date_Inicio,
                                    p.Date_Fin
                                };
                
                rList.AddRange(query.ToList());
                }
                return rList;
            }
        }
        public ArrayList Get_Personal_By_Filtros(string Periodo_Id, string Localidad_Id, string CategoriaAux, string CategoriaAux2, string Categoria
            , string Personal_Id = "")
        {
            Personal_Id = "000000";
            using(ContextMaestro obj=new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection())){

                string nivel = "";
                nivel = obj.UsuarioPlanilla.Where(x => x.Personal_Id == Personal_Id).First().NivelAcceso;
                if (nivel != "04")
                {
                    Personal_Id = "";
                }

                ArrayList rList = new ArrayList();
                var query = from p in obj.Personal
                            join pa in obj.Personal_activo on p.Personal_Id equals pa.Personal_Id
                            where pa.Periodo_Id == Periodo_Id
                            && pa.Area_Id.Contains(Localidad_Id)
                            && pa.Categoria_Auxiliar_Id.Contains(CategoriaAux)
                            && pa.Categoria_Auxiliar2_Id.Contains(CategoriaAux2)
                            && pa.Categoria2_Id.Contains(Categoria)
                            && (Personal_Id == "" || pa.Personal_Id.Contains(Personal_Id))
                            select new { 
                                pa.Personal_Id,
                                PersonalName=p.Apellido_Paterno+" "+p.Apellido_Materno+", "+p.Nombres
                            };
                query = query.OrderBy(o => o.PersonalName);
                rList.AddRange(query.ToList());
                return rList;
            }             
        }


    }
}
