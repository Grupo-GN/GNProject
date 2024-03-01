using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Presistence;

namespace BusienssLogic.CA.oAsignarCodigo
{
    public class Controller_AsignarCodigo
    {
        private static Controller_AsignarCodigo Instance = null;
        public static Controller_AsignarCodigo GetInstance()
        {
            return Instance == null ? Instance = new Controller_AsignarCodigo() : Instance;
        }
         //private static int FINALLROWS = 12;


        public  ArrayList List_Periodo( string Plantilla)
        {
             try { 
             using(ContextMaestro obj=new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection())){
                 ArrayList rLista = new ArrayList();
                   
                         var query = from p in obj.Periodo
                                     where p.Planilla_Id == Plantilla && p.Estado_Id == "02"  
                                    select new { Periodo_Id = p.Periodo_Id, Descripcion = p.Descripcion };
                        rLista.AddRange(query.OrderByDescending(o=>o.Periodo_Id).ToList());
                        return rLista;
                    } 
             
             }
             catch (Exception ex)
             { throw ex; }
         
         }

        public ArrayList CargarPersonal(string seccion, string Localidad, string Periodo_id)
        {
            try {

                ArrayList rlist = new ArrayList();
                using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    var query = from per in obj.Personal
                                join ho in obj.Horarios on per.Horario_Id equals ho.Horario_Id into detPH
                                from ph in detPH.DefaultIfEmpty()
                                join perA in obj.Personal_activo on per.Personal_Id equals perA.Personal_Id
                                //join are in obj.areas_planillas_sofya on perA.Area_Id equals are.Area_Id
                                join are in obj.RH_Area on perA.Area_Id equals are.Area_Id
                                join cat in obj.Categoria_Auxiliar on perA.Categoria_Auxiliar_Id equals cat.Categoria_Auxiliar_Id
                                where perA.Periodo_Id == Periodo_id
                                //&& (seccion == "0" || perA.Categoria_Auxiliar_Id == seccion)
                                && perA.Categoria_Auxiliar_Id.Contains(seccion)
                                //&& (Localidad == "" || perA.Area_Id == Localidad) 
                                && perA.Area_Id.Contains(Localidad)
                                select new
                                {
                                    Personal_Id=per.Personal_Id,                                    
                                    //ph.Horario_Id,
                                    //Horario = ph.Nombre,
                                    Localidad = are.Descripcion,
                                    Seccion = cat.Descripcion,
                                    Nombres = per.Apellido_Paterno + " " + per.Apellido_Materno + " " + per.Nombres,
                                    //codigo=per.co_trabajador_id,
                                    codigo = per.co_trabajador_id == null ? "0" : per.co_trabajador_id // a Nullable<bool>
                                    
                                };

                    rlist.AddRange(query.ToList());
                    return rlist;
                }
            }
            catch(Exception ex){
                throw ex;
            }
        
        
        
        }

        public bool AsignarCodigo_Save(string Personal_Id,string CodigoActual, string co_trabajador_id)
        {
            try {
               using(ContextMaestro obj=new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
               {

                   int lineas=obj.Personal.Where(o =>o.Personal_Id== Personal_Id && o.co_trabajador_id == co_trabajador_id).Count();
                   if (lineas == 0)
                   {
                       Personal per = obj.Personal.Where(o => o.Personal_Id == Personal_Id).First();
                       per.co_trabajador_id=co_trabajador_id;
                       obj.SaveChanges();                       
                       return true; 
                   }
                   
                   return false; 
               
               } 
           }
            catch (Exception ex) { throw ex; }
        
        }

      

    }
}
