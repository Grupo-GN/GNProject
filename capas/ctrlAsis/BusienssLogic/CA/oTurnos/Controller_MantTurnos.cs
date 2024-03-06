using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presistence;
using System.Collections;
namespace BusienssLogic.CA.oTurnos
{
    public class Controller_MantTurnos
    {
        private static Controller_MantTurnos Instance = null;
        public static Controller_MantTurnos GetInstance()
        {
            return Instance == null ? Instance = new Controller_MantTurnos() : Instance;
        }

        private static int FINALLROWS = 12;
        //public List<Turnos> Get_Turnos_List(int inicio)
        public ArrayList Get_Turnos_List(int inicio)
        {
            ArrayList rlist = new ArrayList();
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                //return obj.Turnos.OrderBy(o => o.Turno_Id).Skip(inicio).Take(FINALLROWS).ToList();
                var query = (from t in obj.Turnos
                             select t).AsEnumerable().Select(
                                 s => new
                                 {
                                     Turno_Id = s.Turno_Id,
                                     Nombre = s.Nombre,
                                     Descripcion = s.Descripcion,
                                     HoraInicio = s.HoraInicio.GetValueOrDefault().ToString("dd/MM/yyyy HH:mm:ss"),
                                     HoraInicioRefrigerio = s.HoraInicioRefrigerio.GetValueOrDefault().ToString("dd/MM/yyyy HH:mm:ss"),
                                     HoraFinRefrigerio = s.HoraFinRefrigerio.GetValueOrDefault().ToString("dd/MM/yyyy HH:mm:ss"),
                                     HoraFin = s.HoraFin.GetValueOrDefault().ToString("dd/MM/yyyy HH:mm:ss")
                                 });

                rlist.AddRange(query.OrderBy(o => o.Turno_Id).Skip(inicio).Take(FINALLROWS).ToList());
                return rlist;                                                                                                                                             
            }
        }

        ///////////////////////////////////
        public bool Get_Turnos_Update(int codigo, string nombre, string descripcion, DateTime horaini, DateTime horainirefri, DateTime horafinrefri, DateTime horafin)
        {
            try
            {
                using (ContextMaestro objeto = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    //var Opcion_Nombre = "";
                    int lineas = objeto.Turnos.Where(obj => obj.Turno_Id == codigo).Count();
                    if (lineas != 0)
                    {
                        Turnos turn = objeto.Turnos.Where(o => o.Turno_Id == codigo).First();
                        turn.Nombre = nombre;
                        turn.Descripcion = descripcion;
                        turn.HoraInicio = horaini;
                        turn.HoraInicioRefrigerio = horainirefri;
                        turn.HoraFinRefrigerio = horafinrefri;
                        turn.HoraFin = horafin;

                        objeto.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        ///Metodo para Buscar
        public object Get_Turnos_Find(int codigo)
        {
            try
            {
                using (ContextMaestro objeto = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    int lineas = objeto.Turnos.Where(obj => obj.Turno_Id == codigo).Count();
                    if (lineas > 0)
                    {
                        //Turnos turn = objeto.Turnos.Where(obj => obj.Turno_Id == codigo).First();
                        var query = (from t in objeto.Turnos where t.Turno_Id == codigo
                                     select t).AsEnumerable().Select(
                                s => new
                                {
                                    Turno_Id = s.Turno_Id,
                                    Nombre = s.Nombre,
                                    Descripcion = s.Descripcion,
                                    HoraInicio = s.HoraInicio.GetValueOrDefault().ToString("dd/MM/yyyy HH:mm:ss"),
                                    HoraInicioRefrigerio = s.HoraInicioRefrigerio.GetValueOrDefault().ToString("dd/MM/yyyy HH:mm:ss"),
                                    HoraFinRefrigerio = s.HoraFinRefrigerio.GetValueOrDefault().ToString("dd/MM/yyyy HH:mm:ss"),
                                    HoraFin = s.HoraFin.GetValueOrDefault().ToString("dd/MM/yyyy HH:mm:ss")
                                });

                        return query.ToList().First();
                        //if (turn != null)
                        //    return turn;
                    }
                    return null;
                }
            }

            catch (Exception ex) { throw ex; }
        }


        public int Get_Turnos_MaxRegistro()
        {
            using (ContextMaestro objContexto = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                List<Turnos> oLista = new List<Turnos>();
                oLista.Clear();
                oLista = objContexto.Turnos.ToList();
                return oLista.Count;
            }
        }





        ///Metodo para Insertar
        public bool Get_Turnos_Add(string nombre, string descripcion, DateTime horaini, DateTime horainirefri, DateTime horafinrefri, DateTime horafin)
        {
            try
            {
                using (ContextMaestro objeto = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {

                    int lineasafectadas = objeto.Turnos.Count();

                    Turnos turn = new Turnos();

                    turn.Nombre = nombre;
                    turn.Descripcion = descripcion;
                    turn.HoraInicio = horaini;
                    turn.HoraInicioRefrigerio = horainirefri;
                    turn.HoraFinRefrigerio = horafinrefri;
                    turn.HoraFin = horafin;
                    objeto.AddToTurnos(turn);
                    objeto.SaveChanges();
                    return true;                   

                }
            }
            catch (Exception ex) { throw ex; }

        }

    }




}
