using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presistence;
using System.Collections;

using System.Data;
using System.Data.Entity;
using Presistence.CustomDAL;

namespace BusienssLogic.CA.oAsignarHorarioMasivo
{
    public class Controller_MantAsignarHorarioMasivo
    {
        private static Controller_MantAsignarHorarioMasivo Instance = null;
        public static Controller_MantAsignarHorarioMasivo GetInstance()
        {
            return Instance == null ? Instance = new Controller_MantAsignarHorarioMasivo() : Instance;
        }

        public const int FINALROWS = 12;


        public ArrayList Get_Planillas_List()
        {

            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rlist = new ArrayList();

                var query = from p in obj.Planilla
                            where p.Estado_Id == "01"
                           // where p.Planilla_Id == "01" //|| p.Planilla_Id == "04"
                            select new { p.Planilla_Id, p.Descripcion };


                rlist.AddRange(query.ToList());
                return rlist;
                //return obj.Planilla.OrderBy(o => o.Planilla_Id).Skip(inicio).Take(FINALLROWS).ToList();

            }
        }
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
                                select new { c.Area_Id, c.Descripcion } ;
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

        public List<RH_Area> Get_Localidades_List_2(string Personal_Id)
        {

            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                List<RH_Area> aList = new List<RH_Area>();
                string nivel = "";
                nivel = obj.UsuarioPlanilla.Where(x => x.Personal_Id == Personal_Id).First().NivelAcceso;
                if (nivel == "01")
                {
                    aList = obj.RH_Area.Where(x => x.Area_Id != "14").ToList();
                    RH_Area todo = new RH_Area();
                    todo.Area_Id = "";
                    todo.Descripcion = "-TODOS-";
                    aList.Add(todo);
                }
                else if (nivel == "02")
                {
                    aList = obj.RH_Area.Where(x => x.Area_Id != "14").ToList();
                    RH_Area todo = new RH_Area();
                    todo.Area_Id = "";
                    todo.Descripcion = "-TODOS-";
                    aList.Add(todo);
                }
                else if (nivel == "03")
                {
                    string localidad = obj.Personal_activo.Where(x => x.Personal_Id == Personal_Id).OrderByDescending(o => o.Periodo_Id).First().Area_Id;
                    aList = obj.RH_Area.Where(x => x.Area_Id == localidad).ToList();
                }

                return aList;

            }
        }

        //cambio 01.10.2020
        public List<areas_planillas_sofya> Get_Localidades_List_OLD(string Personal_Id)
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
        public ArrayList Get_AsignarHorarioMasivo_List(string Periodo_id, string seccion, string area_id, int inicio, string Jefe_Id)
        {


            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rlist = new ArrayList();

                var query = from per in obj.Personal
                            join ho in obj.Horarios on per.Horario_Id equals ho.Horario_Id into detPH
                            from ph in detPH.DefaultIfEmpty()
                            join perA in obj.Personal_activo on per.Personal_Id equals perA.Personal_Id
                            join are in obj.RH_Area on perA.Area_Id equals are.Area_Id
                            //join are in obj.areas_planillas_sofya on perA.Area_Id equals are.Area_Id //modificado 01.10.2020
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
                                Horario_Id= ph == null ? 0 : ph.Horario_Id,
                                Horario = ph == null ? "Sin Definir" : ph.Nombre,
                                Localidad = are.Descripcion,
                                Seccion = cat.Descripcion,
                                Area = cat2.Descripcion

                            };

                //query = query.OrderBy(o => o.Personal_Id).Skip(inicio).Take(FINALLROWS);
                rlist.AddRange(query.OrderBy(o=> o.Nombres).ToList());
                return rlist;

            }
        }

        public ArrayList Get_AsignarHorarioMasivo_ListAdmin(string Periodo_id, string seccion, string area_id, int inicio, string Jefe_Id)
        {


            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rlist = new ArrayList();

                var query = from per in obj.Personal
                            join ho in obj.Horarios on per.Horario_Id equals ho.Horario_Id into detPH
                            from ph in detPH.DefaultIfEmpty()
                            join perA in obj.Personal_activo on per.Personal_Id equals perA.Personal_Id
                            join are in obj.RH_Area on perA.Area_Id equals are.Area_Id
                            //join are in obj.areas_planillas_sofya on perA.Area_Id equals are.Area_Id //modificado 01.10.2020
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

                //query = query.OrderBy(o => o.Personal_Id).Skip(inicio).Take(FINALLROWS);
                rlist.AddRange(query.OrderBy(o => o.Nombres).ToList());
                return rlist;

            }
        }



        ///Metodo para Buscar

        public Personal Get_AsignarHorarioMasivo_Find(string codigo)
        {
            try
            {
                using (ContextMaestro objeto = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    int lineas = objeto.Personal.Where(obj => obj.Personal_Id == codigo).Count();
                    if (lineas != 0)
                    {
                        Personal perso = objeto.Personal.Where(obj => obj.Personal_Id == codigo).First();
                        if (perso != null)
                            return perso;
                    }
                    return null;
                }
            }

            catch (Exception ex) { throw ex; }
        }



        ///////////////////////////////////
        public bool Get_AsignarHorarioMasivo_Update(int idHorario, string idcknum)
        {
            try
            {
                using (ContextMaestro objeto = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    //var Opcion_Nombre = "";
                    int lineas = objeto.Horarios.Where(obj => obj.Horario_Id == idHorario).Count();
                    if (lineas != 0)
                    {
                        Horarios hora = objeto.Horarios.Where(o => o.Horario_Id == idHorario).First();
                        //hora.Nombre = nombre;
   

                        objeto.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex) { throw ex; }
        }


        public int Get_AsignarHorarioMasivo_MaximoRegistros()
        {
            using (ContextMaestro objContexto = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                List<Personal> oLista = new List<Personal>();
                oLista.Clear();
                oLista = objContexto.Personal.ToList();
                return oLista.Count;
            }
        }

         ///Metodo para Insertar
        public bool Get_AsignarHorarioMasivo_Add(string localidad, string seccion, string nombres, string horarios)
        {
            try
            {
                using (ContextMaestro objeto = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    
                    int lineasafectadas = objeto.Personal.Count();

                         Personal perso = new Personal();

                         // perso.localidad = localidad;
                         // perso.seccion = seccion;
                         // perso.nombres = nombres;
                         // perso.horarios = horarios;
                        objeto.AddToPersonal(perso);
                        objeto.SaveChanges();
                        return true;
                    
                   

                }
            }
            catch (Exception ex) { throw ex; }

        }


        public ArrayList Get_Horarios_List()
        {

            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rlist = new ArrayList();

                var query = from h in obj.Horarios
                            select new { h.Horario_Id, h.Nombre };


                rlist.AddRange(query.ToList());
                return rlist;
                //return obj.Planilla.OrderBy(o => o.Planilla_Id).Skip(inicio).Take(FINALLROWS).ToList();

            }
        }

        public List<Horarios_Detalle> Get_DetalleHorarios_List(int Horario_Id)//2
        {
            try
            {
                using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    return obj.Horarios_Detalle.Where(x => x.Horario_Id == Horario_Id).OrderBy(o => o.Dia).ToList();

                }
            }
            catch (Exception ex)
            { throw ex; }


        }


        ///Metodo para Detalle Horarios
        public bool Get_DetalleHorarios_Add(DateTime HoraInicio, DateTime HoraInicioRefrigerio, DateTime HoraFinRefrigerio, DateTime HoraFin)
        {
            try
            {
                using (ContextMaestro objeto = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {

                    int lineasafectadas = objeto.Horarios_Detalle.Count();
                    if (lineasafectadas != 0)
                    {
                        Horarios_Detalle hordet = new Horarios_Detalle();

                        hordet.HoraInicio = HoraInicio;
                        hordet.HoraInicioRefrigerio = HoraInicioRefrigerio;
                        hordet.HoraFinRefrigerio = HoraFinRefrigerio;
                        hordet.HoraFin = HoraFin;
                        objeto.AddToHorarios_Detalle(hordet);
                        objeto.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception ex) { throw ex; }

        }





        ///Metodo Para ACTUALIZAR ESTADO VEHICULO
        public bool Get_AsignarHorarioMasivo_UpdateHorario(string Personal_Id, int newHorario_Id)
        {
            try
            {
                using (ContextMaestro objContexto = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {

                    int lineasAfectadas = objContexto.Personal.Where(obj => obj.Personal_Id == Personal_Id).Count();
                    if (lineasAfectadas != 0)
                    {
                        Personal objeto = objContexto.Personal.Where(obj => obj.Personal_Id == Personal_Id).First();

                        objeto.Horario_Id = newHorario_Id;
                        objContexto.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    }

