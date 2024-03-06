using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presistence;
using System.Collections;
namespace BusienssLogic.CA.oAsignarHorarioPersona
{
    public class Controller_MantAsignarHorarioPersona
    {
        private static Controller_MantAsignarHorarioPersona Instance = null;
        public static Controller_MantAsignarHorarioPersona GetInstance()
        {
            return Instance == null ? Instance = new Controller_MantAsignarHorarioPersona() : Instance;
        }

        
        public ArrayList Get_Planillas_List()
        {

            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rlist = new ArrayList();

                var query = from p in obj.Planilla
                            where p.Estado_Id=="01" //p.Planilla_Id == "01" || p.Planilla_Id == "04"
                            select new { p.Planilla_Id, p.Descripcion };


                rlist.AddRange(query.ToList());
                return rlist;
                //return obj.Planilla.OrderBy(o => o.Planilla_Id).Skip(inicio).Take(FINALLROWS).ToList();
            }
        }

        public ArrayList Get_Localidades_List()
        {

            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rlist = new ArrayList();

                var query = from p in obj.RH_Area //modificado 1.10.2020  obj.areas_planillas_sofy, descripcion
                            select new { p.Area_Id, p.Descripcion };


                rlist.AddRange(query.ToList());
                return rlist;
                //return obj.Planilla.OrderBy(o => o.Planilla_Id).Skip(inicio).Take(FINALLROWS).ToList();

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
        public ArrayList Get_AsignarHorarioPersonas_List(string Periodo_id, string seccion, string area_id, int inicio)
        {


            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rlist = new ArrayList();

                var query = from per in obj.Personal
                            join ho in obj.Horarios on per.Horario_Id equals ho.Horario_Id into detPH
                            from ph in detPH.DefaultIfEmpty()
                            join perA in obj.Personal_activo on per.Personal_Id equals perA.Personal_Id
                            join are in obj.RH_Area on perA.Area_Id equals are.Area_Id
                            // join are in obj.areas_planillas_sofya on perA.Area_Id equals are.Area_Id // modificado 1.10.2020
                            join cat in obj.Categoria_Auxiliar on perA.Categoria_Auxiliar_Id equals cat.Categoria_Auxiliar_Id
                            where perA.Periodo_Id == Periodo_id
                            && perA.Categoria_Auxiliar_Id.Contains(seccion)
                            && perA.Area_Id.Contains(area_id)
                            select new
                            {
                                per.Personal_Id,
                                Nombres = per.Apellido_Paterno + " " + per.Apellido_Materno + " " + per.Nombres,
                                Horario_Id=  ph==null ? 0 : ph.Horario_Id,
                                Horario = ph == null ? "Sin Definir" :  ph.Nombre,
                                Localidad = are.Descripcion,
                                Seccion = cat.Descripcion

                            }   ;
               
                //query = query.OrderBy(o => o.Personal_Id).Skip(inicio).Take(FINALLROWS);
                //query = query.OrderBy(o => o.Nombres).Skip(inicio).Take(FINALLROWS);

                if (query.Count()>0)
                {
                    rlist.AddRange(query.AsQueryable().ToList());
                }
               

                return rlist;

            }
        }

        public int Get_AsignarHorarioPersonas_MaxRegistro(string Periodo_id, string seccion, string area_id)
        {


            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                

                var query = from per in obj.Personal
                            join ho in obj.Horarios on per.Horario_Id equals ho.Horario_Id into detPH
                            from ph in detPH.DefaultIfEmpty()
                            join perA in obj.Personal_activo on per.Personal_Id equals perA.Personal_Id
                            join are in obj.areas_planillas_sofya on perA.Area_Id equals are.Area_Id
                            join cat in obj.Categoria_Auxiliar on perA.Categoria_Auxiliar_Id equals cat.Categoria_Auxiliar_Id
                            where perA.Periodo_Id == Periodo_id
                            && perA.Categoria_Auxiliar_Id.Contains(seccion)
                            && perA.Area_Id.Contains(area_id)
                            select new
                            {
                                per.Personal_Id,
                                Nombres = per.Apellido_Paterno + " " + per.Apellido_Materno + " " + per.Nombres,
                                ph.Horario_Id,
                                Horario = ph.Nombre,
                                Localidad = are.descripcion,
                                Seccion = cat.Descripcion

                            };
                               
              
                return query.Count();

            }
        }

        ///Metodo para Buscar

        public string Get_AsignarHorarioPersonas_Find(string codigo)
        {
            try
            {
                using (ContextMaestro objeto = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    int lineas = objeto.Personal.Where(obj => obj.Personal_Id == codigo).Count();
                    if (lineas != 0)
                    {
                        string perso = objeto.Personal.Where(obj => obj.Personal_Id == codigo).First().Horario_Id.ToString();
                        return perso;
                    }

                    return "";

                }
            }

            catch (Exception ex) { throw ex; }
        }



        ///////////////////////////////////
        ///////////////////////////////////
        public bool Get_AsignarHorarioPersonas_Update(string Personal_Id,int Horario_Id)
        {
            try
            {
                using (ContextMaestro objeto = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    //var Opcion_Nombre = "";
                    int lineas = objeto.Personal.Where(obj => obj.Personal_Id == Personal_Id).Count();
                    if (lineas != 0)
                    {
                        Personal p = objeto.Personal.Where(o => o.Personal_Id == Personal_Id).First();

                        p.Horario_Id = Horario_Id;
                        objeto.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public int Get_AsignarHorarioPersonas_MaximoRegistros()
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
        public bool Get_AsignarHorarioPersonas_Add(string localidad, string seccion, string nombres, string horarios)
        {
            try
            {
                using (ContextMaestro objeto = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {

                    int lineasafectadas = objeto.Personal.Count();

                    Personal perso = new Personal();

                    //perso.Localidad = localidad;
                    //perso.Seccion = seccion;
                    //perso.Nombres = nombres;
                    //perso.Horarios = horarios;
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

                var query = from hor in obj.Horarios
                            select new { hor.Horario_Id, hor.Nombre };

                query = query.OrderBy(o => o.Nombre);
                rlist.AddRange(query.ToList());
                return rlist;
                //return obj.Planilla.OrderBy(o => o.Planilla_Id).Skip(inicio).Take(FINALLROWS).ToList();

            }
        }

    }

}

