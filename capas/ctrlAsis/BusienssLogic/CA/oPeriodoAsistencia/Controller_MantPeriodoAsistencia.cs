using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presistence;
using System.Collections;

namespace BusienssLogic.CA.oPeriodoAsistencia
{
    public class Controller_MantPeriodoAsistencia
    {

        private static Controller_MantPeriodoAsistencia Instance = null;
        public static Controller_MantPeriodoAsistencia GetInstance()
        {
            return Instance == null ? Instance = new Controller_MantPeriodoAsistencia() : Instance;
        }




        public ArrayList Get_Periodos_List()
        {

            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rlist = new ArrayList();

                var query = from p in obj.Periodo
                            select new { p.Periodo_Id, p.Descripcion };


                rlist.AddRange(query.ToList());
                return rlist;
                //return obj.Planilla.OrderBy(o => o.Planilla_Id).Skip(inicio).Take(FINALLROWS).ToList();

            }
        }


        private static int FINALLROWS = 12;
        public List<Periodo_Asistencia> Get_PeriodoAsistencia_List(int inicio)
        {

            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {

                return obj.Periodo_Asistencia.OrderByDescending(o => o.Date_Inicio).Skip(inicio).Take(FINALLROWS).ToList();

            }
        }

        public bool Get_Activos_PorId_Update(int Periodo_Asistencia_Id, bool Estado)
        {

            try
            {
                using (ContextMaestro objeto = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    //var Opcion_Nombre = "";
                    int lineas = objeto.Periodo_Asistencia.Where(obj => obj.Periodo_Asistencia_Id == Periodo_Asistencia_Id).Count();
                    if (lineas != 0)
                    {
                        Periodo_Asistencia p = objeto.Periodo_Asistencia.Where(o => o.Periodo_Asistencia_Id == Periodo_Asistencia_Id).First();

                        p.Estado = Estado;
                        objeto.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex) { throw ex; }
        }


        ///////////////////////////////////
        public bool Get_PeriodoAsistencia_Update(int codigo, bool activo)
        {
            try
            {
                using (ContextMaestro objeto = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    //var Opcion_Nombre = "";
                    int lineas = objeto.Periodo_Asistencia.Where(obj => obj.Periodo_Asistencia_Id == codigo).Count();
                    if (lineas != 0)
                    {
                        if(activo==false){

                        Periodo_Asistencia pa = objeto.Periodo_Asistencia.Where(o => o.Periodo_Asistencia_Id == codigo).First();
                        pa.Estado = true;
                        objeto.SaveChanges();
                        return true;
                        
                        }else{
                            Periodo_Asistencia pa = objeto.Periodo_Asistencia.Where(o => o.Periodo_Asistencia_Id == codigo).First();
                            pa.Estado = false;
                            objeto.SaveChanges();
                            return true;


                        }


                    }
                    return false;
                }
            }
            catch (Exception ex) { throw ex; }
        }


        public int Get_PeriodoAsistencia_MaxRegistro()
        {
            using (ContextMaestro objContexto = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                List<Periodo_Asistencia> oLista = new List<Periodo_Asistencia>();
                oLista.Clear();
                oLista = objContexto.Periodo_Asistencia.ToList();
                return oLista.Count;
            }
        }


        //update detalle 
        public bool Get_PeriodoAsistencia_Delete(int Periodo_Asistencia_Id)
        {
            try
            {
                using (ContextMaestro objeto = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {

                    int lineas = objeto.Periodo_Asistencia.Where(obj => obj.Periodo_Asistencia_Id == Periodo_Asistencia_Id).Count();
                    if (lineas != 0)
                    {
                        Periodo_Asistencia pa = objeto.Periodo_Asistencia.Where(obj => obj.Periodo_Asistencia_Id == Periodo_Asistencia_Id).First();
                        objeto.DeleteObject(pa);
                        objeto.SaveChanges();

                        return true;
                    }
                    return false;
                }

            }
            catch (Exception ex)
            { throw ex; }

        }



        public bool Get_PeriodoAsistencia_Add(DateTime fechainicio2, string periodo, DateTime fechafin2, bool estado)
        {
            try
            {
                using (ContextMaestro objeto = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {

                    string PeriodoDecrip = objeto.Periodo.Where(x => x.Periodo_Id == periodo).First().Descripcion;

                    int lineasafectadas = objeto.Periodo_Asistencia.Count();
                    Periodo_Asistencia pa = new Periodo_Asistencia();
                    pa.Date_Inicio = fechainicio2;
                    pa.Periodo = PeriodoDecrip;
                    pa.Date_Fin = fechafin2;
                    pa.Estado = estado;
                    objeto.AddToPeriodo_Asistencia(pa);
                    objeto.SaveChanges();
                    return true;

                }
            }
            catch (Exception ex) { throw ex; }

        }

    

    }
 }
