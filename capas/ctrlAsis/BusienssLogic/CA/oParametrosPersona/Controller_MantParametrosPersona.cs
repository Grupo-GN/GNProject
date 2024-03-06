using System;
using System.Collections.Generic;
using System.Linq;
using Presistence;
using System.Collections;
namespace BusienssLogic.CA.oParametrosPersona
{
    public class Controller_MantParametrosPersona
    {
        private static Controller_MantParametrosPersona Instance = null;
        public static Controller_MantParametrosPersona GetInstance()
        {
            return Instance == null ? Instance = new Controller_MantParametrosPersona() : Instance;
        }




        public ArrayList Get_Planillas_List()
        {

            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rlist = new ArrayList();

                var query = from p in obj.Planilla
                            where p.Estado_Id=="01"
                            //where p.Planilla_Id == "01" || p.Planilla_Id == "04"
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

                var query = from p in obj.RH_Area //areas_planillas_sofya
                            select new { p.Area_Id, p.Descripcion };


                rlist.AddRange(query.ToList());
                return rlist;
                //return obj.Planilla.OrderBy(o => o.Planilla_Id).Skip(inicio).Take(FINALLROWS).ToList();

            }
        }

        public ArrayList Get_Secciones_List()
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

        public ArrayList Get_Personal_List()
        {

            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rlist = new ArrayList();

                var query = from p in obj.Personal
                            select new
                            {
                                p.Personal_Id,
                                Nombres = p.Apellido_Paterno + " " + p.Apellido_Materno + " " + p.Nombres
                            };

                query = query.OrderBy(o => o.Nombres);
                rlist.AddRange(query.ToList());
                return rlist;
                //return obj.Planilla.OrderBy(o => o.Planilla_Id).Skip(inicio).Take(FINALLROWS).ToList();

            }
        }

        public List<Presistence.CustomDAL.eParamentros> Get_Variables_List(string Personal_Id)
        {

            return Presistence.CustomDAL.customParamentroPersonal.GetInstance().Get_Parametros_Personal(Personal_Id);
                       
        }

        public ArrayList Get_ParametrosPersona_List()
        {

            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rlist = new ArrayList();

                var query = from p in obj.ParametrosControlAsistencia
                            select new { p.Parametro_Id, p.Variable, p.Valor };


                rlist.AddRange(query.ToList());
                return rlist;
                //return obj.Planilla.OrderBy(o => o.Planilla_Id).Skip(inicio).Take(FINALLROWS).ToList();

            }
        }

        private static int FINALLROWS = 12;
        public ArrayList Get_ParametrosPersona_List(string Personal_Id, int inicio)
        {


            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rlist = new ArrayList();

                var query = from p in obj.Personal
                            join pcap in obj.ParametrosCA_Personal on p.Personal_Id equals pcap.Personal_Id
                            join pca in obj.ParametrosControlAsistencia on pcap.Parametro_Id equals pca.Parametro_Id
                            where pcap.Personal_Id == Personal_Id
                            select new
                            {
                                p.Personal_Id,
                                Nombres = p.Apellido_Paterno + " " + p.Apellido_Materno + " " + p.Nombres,
                                pcap.Parametro_Id,
                                pca.Variable,
                                pcap.Valor

                            };

                query = query.OrderBy(o => o.Personal_Id).Skip(inicio).Take(FINALLROWS);
                rlist.AddRange(query.ToList());
                return rlist;

            }
        }
        ///Metodo para Insertar
        public bool Get_ParametrosPersona_Add(int Parametro_Id, string Personal_Id, string Valor)
        {
            try
            {
                using (ContextMaestro objeto = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {

                    int lineasafectadas = objeto.ParametrosCA_Personal.Count();

                    ParametrosCA_Personal pca = new ParametrosCA_Personal();

                    pca.Parametro_Id = Parametro_Id;
                    pca.Personal_Id = Personal_Id;
                    pca.Valor = Valor;
                    objeto.AddToParametrosCA_Personal(pca);
                    objeto.SaveChanges();
                    return true;
                                     

                }
            }
            catch (Exception ex) { throw ex; }

        }


        ///Metodo para Buscar

        public ParametrosControlAsistencia Get_ParametrosPersona_Find(int codigo)
        {
            try
            {
                using (ContextMaestro objeto = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    int lineas = objeto.ParametrosControlAsistencia.Where(obj => obj.Parametro_Id == codigo).Count();
                    if (lineas != 0)
                    {
                        ParametrosControlAsistencia pca = objeto.ParametrosControlAsistencia.Where(obj => obj.Parametro_Id == codigo).First();
                        if (pca != null)
                            return pca;
                    }
                    return null;
                }
            }

            catch (Exception ex) { throw ex; }
        }


        ///Metodo Para ACTUALIZAR ESTADO VEHICULO
        public bool Get_ParametrosPersona_UpdateValor(int Parametro_Id,string Personal_Id, string newValor)
        {
            try
            {
                using (ContextMaestro objContexto = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {

                    int lineasAfectadas = objContexto.ParametrosCA_Personal.Where(obj => obj.Personal_Id == Personal_Id && obj.Parametro_Id == Parametro_Id).Count();
                    if (lineasAfectadas != 0)
                    {
                        ParametrosCA_Personal objeto = objContexto.ParametrosCA_Personal.Where(obj => obj.Personal_Id == Personal_Id && obj.Parametro_Id == Parametro_Id).First();

                        objeto.Valor = newValor;
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


        public ArrayList Get_Parametros_List()
        {

            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rlist = new ArrayList();

                var query = from p in obj.ParametrosCA_Personal
                            where p.Personal_Id == "000567"
                            select new { p.Personal_Id, p.Parametro_Id };


                rlist.AddRange(query.ToList());
                return rlist;
                //return obj.Planilla.OrderBy(o => o.Planilla_Id).Skip(inicio).Take(FINALLROWS).ToList();

            }
        }
       
    }
}
