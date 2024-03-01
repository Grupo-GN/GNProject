using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presistence;
using System.Collections;
namespace BusienssLogic.CA.oHorarios
{
    public class Controller_MantHorarios
    {
        private static Controller_MantHorarios Instance = null;
        public static Controller_MantHorarios GetInstance()
        {
            return Instance == null ? Instance = new Controller_MantHorarios() : Instance;
        }

        private static int FINALLROWS = 12;
        public List<Horarios> Get_Horarios_List(int inicio)
        {
            try
            {
                using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    List<Horarios> rlista = new List<Horarios>();
                    rlista = obj.Horarios.OrderBy(o => o.Horario_Id).Skip(inicio).Take(FINALLROWS).ToList();
                    return rlista;

                }
            }
            catch (Exception ex)
            { throw ex; }

           
        }

        // modidga//
        //public List<Horarios_Detalle> Get_DetalleHorarios_List(int Horario_Id)//2
        public ArrayList Get_DetalleHorarios_List(int Horario_Id)//2
        {
            try
            {
                using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    int lineas = obj.Horarios_Detalle.Where(x => x.Horario_Id == Horario_Id).Count();
                    ArrayList rlist = new ArrayList();
                    if (lineas == 0)
                    {
                        //List<Horarios_Detalle> rlista = new List<Horarios_Detalle>();
                                            
                        for (int i = 1; i < 8; i++)
                        {
                                Horarios_Detalle hd = new Horarios_Detalle();
                                hd.Dia = i.ToString();
                                hd.Horario_Id = Horario_Id;
                                hd.HoraInicio = Convert.ToDateTime("00:00");
                                hd.HoraInicioRefrigerio = Convert.ToDateTime("00:00");
                                hd.HoraFinRefrigerio = Convert.ToDateTime("00:00");
                                hd.HoraFin = Convert.ToDateTime("00:00");
                                hd.Fecha_Creacion = DateTime.Now;
                                obj.AddToHorarios_Detalle(hd);
                                obj.SaveChanges();                            
                        }
                        var query = (from h in obj.Horarios_Detalle
                                     where h.Horario_Id == Horario_Id
                                     select h).AsEnumerable().Select(
          s => new
          {
              Horario_Detalle_Id = s.Horario_Detalle_Id,
              Horario_Id = s.Horario_Id,
              Dia = s.Dia,
              HoraInicio = s.HoraInicio.GetValueOrDefault().ToString("dd/MM/yyyy HH:mm:ss"),
              HoraInicioRefrigerio = s.HoraInicioRefrigerio.GetValueOrDefault().ToString("dd/MM/yyyy HH:mm:ss"),
              HoraFinRefrigerio = s.HoraFinRefrigerio.GetValueOrDefault().ToString("dd/MM/yyyy HH:mm:ss"),
              HoraFin = s.HoraFin.GetValueOrDefault().ToString("dd/MM/yyyy HH:mm:ss"),
              Fecha_Creacion = s.Fecha_Creacion.GetValueOrDefault().ToString("dd/MM/yyyy HH:mm:ss"),
              Fecha_Modificacion = s.Fecha_Modificacion.GetValueOrDefault().ToString("dd/MM/yyyy HH:mm:ss")
          });

                        rlist.AddRange(query.ToList());
                        return rlist;
                        //return obj.Horarios_Detalle.Where(x => x.Horario_Id == Horario_Id).OrderBy(o => o.Dia).ToList();
                    }
                    else{
                        var query=(from h in obj.Horarios_Detalle
                                  where h.Horario_Id==Horario_Id
                                       select h).AsEnumerable().Select(
                                  s=> new {
                                      Horario_Detalle_Id= s.Horario_Detalle_Id,
                                      Horario_Id= s.Horario_Id,
                                      Dia= s.Dia,
                                      HoraInicio =s.HoraInicio.GetValueOrDefault().ToString("dd/MM/yyyy HH:mm:ss"),
                                      HoraInicioRefrigerio = s.HoraInicioRefrigerio.GetValueOrDefault().ToString("dd/MM/yyyy HH:mm:ss"),
                                      HoraFinRefrigerio = s.HoraFinRefrigerio.GetValueOrDefault().ToString("dd/MM/yyyy HH:mm:ss"),
                                      HoraFin = s.HoraFin.GetValueOrDefault().ToString("dd/MM/yyyy HH:mm:ss"),
                                      Fecha_Creacion = s.Fecha_Creacion.GetValueOrDefault().ToString("dd/MM/yyyy HH:mm:ss"),
                                      Fecha_Modificacion = s.Fecha_Modificacion.GetValueOrDefault().ToString("dd/MM/yyyy HH:mm:ss")
                                  });
                        
                        rlist.AddRange(query.ToList());
                        return rlist;
                         //return obj.Horarios_Detalle.Where(x=> x.Horario_Id==Horario_Id).OrderBy(o => o.Dia).ToList();                    
                    }
                }
            }
            catch (Exception ex)
            { throw ex; }


        }

        ////////modidga///////////////////////////
        public bool Get_Horarios_Deta_Update(int Horario_Id,string Dia, string hi, string hir, string hfr, string hf)
        {
            try
            {
                using (ContextMaestro objeto = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {

                    int lineas = objeto.Horarios_Detalle.Where(obj => obj.Horario_Id == Horario_Id && obj.Dia==Dia).Count();
                    if (lineas != 0)
                    {

                        Horarios_Detalle hd = objeto.Horarios_Detalle.Where(o => o.Horario_Id == Horario_Id && o.Dia==Dia).First();
                            hd.HoraInicio = Convert.ToDateTime(hi);
                            hd.HoraInicioRefrigerio = Convert.ToDateTime(hir);
                            hd.HoraFinRefrigerio = Convert.ToDateTime(hfr);
                            hd.HoraFin = Convert.ToDateTime(hf);
                            
                            hd.Fecha_Modificacion = DateTime.Now;
                            objeto.SaveChanges();
                        

                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex) { throw ex; }
        }
        

         ///////////////////////////////////
        public bool Get_Horarios_Update(int codigo, string nombre)
        {
            try
            {
                using (ContextMaestro objeto = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    //var Opcion_Nombre = "";
                    int lineas = objeto.Horarios.Where(obj => obj.Horario_Id == codigo).Count();
                    if (lineas != 0)
                    {
                        Horarios hor = objeto.Horarios.Where(o => o.Horario_Id == codigo).First();
                        hor.Nombre = nombre;
                      
                        hor.Fecha_Modificacion = DateTime.Now;
                  
                        objeto.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex) { throw ex; }
        }



        ///Metodo para Buscar

        public Horarios Get_Horarios_Find(int codigo)
        {
            try
            {
                using (ContextMaestro objeto = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    int lineas = objeto.Horarios.Where(obj => obj.Horario_Id == codigo).Count();
                    if (lineas != 0)
                    {
                        Horarios hor = objeto.Horarios.Where(obj => obj.Horario_Id == codigo).First();
                        if (hor != null)
                            return hor;
                    }
                    return null;
                }
            }

            catch (Exception ex) { throw ex; }
        }


        public int Get_Horarios_MaximoRegistros()
        {
            using (ContextMaestro objContexto = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                List<Horarios> oLista = new List<Horarios>();
                oLista.Clear();
                oLista = objContexto.Horarios.ToList();
                return oLista.Count;
            }
        }


        


        ///Metodo para Insertar
        public bool Get_Horarios_Add(string nombre)
        {
            try
            {
                using (ContextMaestro objeto = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    
                    int lineasafectadas = objeto.Horarios.Count();
                    //Modificado por jhonatan garcia 30.09.2020
                    int nConteoDatos = objeto.Horarios.Count();
                    if(lineasafectadas!=0 || nConteoDatos==0 ){
                        Horarios hor = new Horarios();
                        
                        hor.Nombre = nombre;
                        hor.Fecha_Creacion = DateTime.Now;
                        hor.Fecha_Modificacion = null;
                        objeto.AddToHorarios(hor);
                        objeto.SaveChanges();
                        return true;
                    }else{
                        return false;
                    }

                }
            }
            catch (Exception ex) { throw ex; }

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


    }

       
    

}
