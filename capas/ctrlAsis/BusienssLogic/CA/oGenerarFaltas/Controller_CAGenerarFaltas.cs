using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Presistence;
using System.Data;

namespace BusienssLogic.CA.oGenerarFaltas
{
   public class Controller_CAGenerarFaltas
    {
       public static Controller_CAGenerarFaltas Instance=null;
       public static Controller_CAGenerarFaltas GetInstance(){
           return Instance == null ? Instance = new Controller_CAGenerarFaltas() : Instance;
       }

       public ArrayList listaPersonalSinMarcaciones2(string Periodo_Id,string Area_Id,DateTime vi_fecha_inicio  
            ,DateTime vi_fecha_fin,string Planilla_Id) {
                try { 
                using(ContextMaestro obj=new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                  {
                    ArrayList rselec = new ArrayList();

                    var query2 = from p in obj.vwFPS_Personal_Periodo
                                where// p.Estado_Id == "01" && 
                                p.Periodo_Id == Periodo_Id
                                && (Area_Id == "" || p.area_id == Area_Id) && p.Planilla_id== Planilla_Id
                                 select  p.personal_id;

                    var cSelect = from xs in obj.tbl_control_asistencia.Distinct()
                                 where xs.fecha_asistencia >= vi_fecha_inicio && xs.fecha_asistencia <= vi_fecha_fin
                                 && query2.Any(a => a == xs.Personal_Id)
                                  select new
                                  {
                                      Personal_Id = xs.Personal_Id
                                  };
                    var distinctEmployees = cSelect.Distinct();
                    rselec.AddRange(distinctEmployees.ToList());
                 

                    DataTable dt = new DataTable();
                  
                    foreach (var item in rselec)
                    {
                        //dt = Class1.GetInstance().RUNTABLA("Sp_DeleteControl_Asistencia", vi_fecha_inicio, vi_fecha_fin,  item.ToString());

                    }

                    

                    ArrayList rLista = new ArrayList();

                     var query1 = from s in obj.tbl_control_asistencia   
                        where  s.fecha_asistencia >= vi_fecha_inicio && s.fecha_asistencia <= vi_fecha_fin
                        select s.Personal_Id;

                     var query = from p in obj.vwFPS_Personal_Periodo
                                 where // p.Estado_Id == "01"  && 
                                 p.Periodo_Id == Periodo_Id
                                 && (Area_Id == "" || p.area_id == Area_Id) && !query1.Any(a => a == p.personal_id)
                                 select new
                                 {
                                     Personal_Id=p.personal_id,
                                     Nombre=p.Nombre_Completo,
                                     Localidad=p.Localidad, 
                                     Seccion=p.Seccion
                                 };

                     rLista.AddRange(query.OrderBy(o => o.Nombre).ToList());


                    return rLista;                                
                  }
                }
                catch (Exception ex) { throw ex; }
       }


        public ArrayList listaPersonalSinMarcaciones(string Periodo_Id, string Area_Id, DateTime vi_fecha_inicio
        , DateTime vi_fecha_fin)
        {
            try
            {
                using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                   
                    ArrayList rLista = new ArrayList();

                    var query1 = from s in obj.tbl_control_asistencia
                                 where s.fecha_asistencia >= vi_fecha_inicio && s.fecha_asistencia <= vi_fecha_fin
                                 select s.Personal_Id;

                    var query = from p in obj.vwFPS_Personal_Periodo
                                where //p.Estado_Id == "01" && 
                                p.Periodo_Id == Periodo_Id
                                && (Area_Id == "" || p.area_id == Area_Id) && !query1.Any(a => a == p.personal_id)
                                select new
                                {
                                    Personal_Id = p.personal_id,
                                    Nombre = p.Nombre_Completo,
                                    Localidad = p.Localidad,
                                    Seccion = p.Seccion
                                };

                    rLista.AddRange(query.OrderByDescending(o => o.Nombre).ToList());


                    return rLista;
                }
            }
            catch (Exception ex) { throw ex; }
        }




        public ArrayList ListaSinMarcasN(string Periodo_Id, string Area_Id, DateTime vi_fecha_inicio, DateTime vi_fecha_fin)
        {
            try
            {
                // dt = Class1.GetInstance().RUNTABLA("Sp_DeleteControl_Asistencia", vi_fecha_inicio, vi_fecha_fin,  item.ToString());
                using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {

                    ArrayList rLista = new ArrayList();

                    var query1 = from s in obj.tbl_control_asistencia
                                 where s.fecha_asistencia >= vi_fecha_inicio && s.fecha_asistencia <= vi_fecha_fin
                                 select s.Personal_Id;

                    var query = from p in obj.vwFPS_Personal_Periodo
                                where p.Estado_Id == "01" && p.Periodo_Id == Periodo_Id
                                && (Area_Id == "" || p.area_id == Area_Id) && !query1.Any(a => a == p.personal_id)
                                select new
                                {
                                    Personal_Id = p.personal_id,
                                    Nombre = p.Nombre_Completo,
                                    Localidad = p.Localidad,
                                    Seccion = p.Seccion
                                };

                    rLista.AddRange(query.OrderByDescending(o => o.Nombre).ToList());


                    return rLista;
                }
            }
            catch (Exception ex) { throw ex; }
        }



        public string Set_GenerarFaltas(string Planilla_Id,string Periodo_Id, string Area_Id, string FechaInicio, string FechaFinal)
        {
            try
            {
                DateTime fecha_inicio = Convert.ToDateTime(FechaInicio);
                DateTime fecha_fin = Convert.ToDateTime(FechaFinal);

                DateTime fecha = new DateTime();
                fecha = fecha_inicio;

                string msj_retorno;
                msj_retorno = "";

                DataTable dt = new DataTable();

                while (fecha <= fecha_fin)
                {
                    dt = Class1.GetInstance().RUNTABLA("fps_spi_genera_faltaxDia_mhg", fecha, Planilla_Id, Periodo_Id, Area_Id);
                    Int32 rpta;
                    var msj = "";

                    rpta = Convert.ToInt32(dt.Rows[0][0].ToString());
                    msj = dt.Rows[0][1].ToString();

                    if (rpta == -1)
                    {
                        msj_retorno = msj_retorno + "Error al generar las faltas en el día" + fecha.ToString("dd/MM/yyyy") + ":" + msj + "\n";
                    }
                    else
                    {
                        msj_retorno = msj_retorno + "Se Genero las Faltas para el día " + fecha.ToString("dd/MM/yyyy") + ": " + msj + "\n";
                    }
                    fecha = fecha.AddDays(1);
                }
                return msj_retorno;

                //ListarPersonalSinMarcaciones();

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

             
        }


        public string Set_GenerarFaltas_Persona(string Planilla_Id, string Periodo_Id, string Area_Id, string FechaInicio, string FechaFinal,string Personal_id)
        {
            try
            {
                DateTime fecha_inicio = Convert.ToDateTime(FechaInicio);
                DateTime fecha_fin = Convert.ToDateTime(FechaFinal);

                DateTime fecha = new DateTime();
                fecha = fecha_inicio;
                int ret = 0;
                string msj_retorno;
                msj_retorno = "";

                DataTable dt = new DataTable();

                while (fecha <= fecha_fin)
                {
                    dt = Class1.GetInstance().RUNTABLA("fps_spi_genera_faltaxDia_Persona", fecha, Planilla_Id, Periodo_Id, Area_Id, Personal_id);
                    Int32 rpta;
                    var msj = "";

                    rpta = Convert.ToInt32(dt.Rows[0][0].ToString());
                    msj = dt.Rows[0][1].ToString();

                    if (rpta == -1)
                    {
                        ret = ret - 1;
                    }
                    else
                    {
                        ret = ret + 1;
                    }
                    fecha = fecha.AddDays(1);
                }

                if (ret > 0)
                {
                    msj_retorno = "ok";
                }
                else
                {
                    msj_retorno = "ok-";
                }
                return msj_retorno;

                //ListarPersonalSinMarcaciones();

            }
            catch (Exception ex)
            {
                return ex.Message;
            }


        }



        public string Proceso_FaltaElimina(string Periodo_Id, string Area_Id, DateTime vi_fecha_inicio, DateTime vi_fecha_fin, string Planilla_Id,string Personal_id)
        {
            string Elimina = "";
            try
            {
                using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    DataTable dt = new DataTable();
                    dt = Class1.GetInstance().RUNTABLA("Sp_DeleteControl_Asistencia_Proceso", vi_fecha_inicio, vi_fecha_fin,Personal_id);
                    Elimina = dt.Rows[0][0].ToString();
                    return Elimina;
                }
            }
            catch (Exception ex) { throw ex; }
        }


        public DataTable ListaPersonal(string Area_Id, string Periodo_Id, string Planilla_Id )
        {
             
            try
            {
                using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    DataTable dt = new DataTable();
                    dt = Class1.GetInstance().RUNTABLA("ListaPersonalControlAsistencia_", Area_Id,Periodo_Id,Planilla_Id);
                     
                    return dt;
                }
            }
            catch (Exception ex) { throw ex; }

        }


        public DataTable LimpiaMarcas( string Personal_id)
        {

            try
            {
                using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    DataTable dt = new DataTable();
                    dt = Class1.GetInstance().RUNTABLA("SP_LimpiaMarcas", Personal_id);

                    return dt;
                }
            }
            catch (Exception ex) { throw ex; }

        }

      

        public string Actualizar_Falta(int Asistencia_Id)
        {
            string Elimina = "";
            try
            {
                using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    DataTable dt = new DataTable();
                    dt = Class1.GetInstance().RUNTABLA("SP_Updatefalta_NW", Asistencia_Id);
                    Elimina = dt.Rows[0][0].ToString();
                    return Elimina;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public string Elimina_Reg_Controlasistencia(int Asistencia_Id)
        {
            string Elimina = "";
            try
            {
                using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    DataTable dt = new DataTable();
                    dt = Class1.GetInstance().RUNTABLA("SP_EliminaReg_Tbl_Controlasistencia", Asistencia_Id);
                    Elimina = dt.Rows[0][0].ToString();
                    return Elimina;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public DataTable Listar_FaltasProceso(DateTime fecha_inicio , DateTime fecha_fin)
        {
          
            try
            {
                using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    DataTable dt = new DataTable();
                    dt = Class1.GetInstance().RUNTABLA("SP_Lista_Faltas_Reproceso", fecha_inicio, fecha_fin);
                   
                    return dt;
                }
            }
            catch (Exception ex) { throw ex; }
        }


    }
}
