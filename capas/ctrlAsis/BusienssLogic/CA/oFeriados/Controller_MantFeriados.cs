using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presistence;
namespace BusienssLogic.CA.oFeriados

{
    public class Controller_MantFeriados
    {

        private static Controller_MantFeriados Instance = null;
        public static Controller_MantFeriados GetInstance()
        {
            return Instance == null ? Instance = new Controller_MantFeriados() : Instance;
        }

        private static int FINALLROWS = 12;
        public List<Feriados> Get_Feriados_List(int inicio)
        { 
        
            using(ContextMaestro obj=new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                return obj.Feriados.OrderByDescending(o => o.Fecha).Skip(inicio).Take(FINALLROWS).ToList();            
            }
        }


        ///////////////////////////////////
        public bool Get_Feriados_Update(int codigo, string nombre, string descripcion, DateTime fecha)
        {
            try
            {
                using (ContextMaestro objeto = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    //var Opcion_Nombre = "";
                    int lineas = objeto.Feriados.Where(obj => obj.Feriado_Id == codigo).Count();
                    if (lineas != 0)
                    {
                        Feriados feri = objeto.Feriados.Where(o => o.Feriado_Id== codigo).First();
                        feri.Nombre = nombre;
                        feri.Descripcion = descripcion;
                        feri.Fecha = fecha;
                        objeto.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex) { throw ex; }
        }



        ///Metodo para Buscar

        public Feriados Get_Feriados_Find(int codigo)
        {
            try
            {
                using (ContextMaestro objeto = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    int lineas = objeto.Feriados.Where(obj => obj.Feriado_Id == codigo).Count();
                    if (lineas != 0)
                    {
                        Feriados feri = objeto.Feriados.Where(obj => obj.Feriado_Id == codigo).First();
                        if (feri != null)
                        return feri;
                    }
                    return null;
                }
            }

            catch (Exception ex) { throw ex; }
        }


        public int Get_Feriados_MaxRegistro()
        {
            using (ContextMaestro objContexto = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                List<Feriados> oLista = new List<Feriados>();
                oLista.Clear();
                oLista = objContexto.Feriados.ToList();
                return oLista.Count;
            }
        }


        


        ///Metodo para Insertar
        public bool Get_Feriados_Add(string nombre, string descripcion, DateTime fecha)
        {
            try
            {
                using (ContextMaestro objeto = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    
                    int lineasafectadas = objeto.Turnos.Count();

                        Feriados feri = new Feriados();

                        feri.Nombre = nombre;
                        feri.Descripcion = descripcion;
                        feri.Fecha = fecha;
                        objeto.AddToFeriados(feri);
                        objeto.SaveChanges();
                        return true;

                }
            }
            catch (Exception ex) { throw ex; }

        }

    }
    }

