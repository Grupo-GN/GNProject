using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistence;
using System.Collections;
using PersistenceI;

namespace BusinessLogic.oListReportes
{
    public class controller_ListarReporte
    {
        private static controller_ListarReporte Instance = null;
        public static controller_ListarReporte Get_Instance() {
            return Instance == null ? Instance = new controller_ListarReporte() : Instance;
        }
        public List<RH_Area> Get_Licalidad_List()
        { 
            using(ContextMaestro obj=new ContextMaestro()){
                return obj.RH_Area.ToList();
            }
        }

        public ArrayList Get_Reportes_List_ADM(string Area_Id, DateTime FechaIni, DateTime FechaFin)
        { 
            using(ContextMaestro obj=new ContextMaestro()){
                ArrayList rList = new ArrayList();

               /* DateTime FI = DateTime.Parse(FechaIni);
                DateTime FF = DateTime.Parse(FechaFin + " 23:59:00.000");*/
                var query = from r in obj.ReporteIncidente
                            join p in obj.Personal on r.Personal_Registro equals p.Personal_Id
                            join l in obj.RH_Area on r.Area_Id equals l.Area_Id
                            join i in obj.Intensidad on r.Intensidad_Id equals i.Intensidad_Id
                            join s in obj.Severidad on r.Severidad_Id equals s.Severidad_Id
                            where r.Area_Id.Contains(Area_Id)
                            && (r.FechaHora_Reporte >= FechaIni && r.FechaHora_Reporte <= FechaFin)
                            select new {
                                r.Incidente_Id,
                                r.Estado_Id,
                                r.FechaHora_Reporte,
                                UsuReporte=p.Apellido_Paterno+" "+p.Apellido_Materno+", "+p.Nombres,
                                RH_Area=l.Descripcion,
                                Intensidad=i.Descripcion,
                                Severidad=s.Descripcion,
                                r.Informar_Gerencia,
                                r.Informar_Osigermin,
                                r.FechaHora_Incidente                            
                            };

                rList.AddRange(query.ToList());
                return rList;
            }
        }


        public ArrayList Get_Reportes_List_PLANT(string Area_Id, string Per_Registro, DateTime FechaIni, DateTime FechaFin)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                ArrayList rList = new ArrayList();
                /*string fi=DateTime.Parse(FechaIni).ToString();
                string ff=DateTime.Parse(FechaFin + " 23:59:00").ToString();
                DateTime FI = DateTime.Parse(fi);
                DateTime FF = DateTime.Parse(ff);*/
                var query = from r in obj.ReporteIncidente
                            join p in obj.Personal on r.Personal_Registro equals p.Personal_Id
                            join l in obj.RH_Area on r.Area_Id equals l.Area_Id
                            join i in obj.Intensidad on r.Intensidad_Id equals i.Intensidad_Id
                            join s in obj.Severidad on r.Severidad_Id equals s.Severidad_Id
                            where r.Area_Id.Contains(Area_Id)
                            && (r.FechaHora_Reporte >= FechaIni && r.FechaHora_Reporte <= FechaFin)
                            && r.Personal_Registro == Per_Registro
                            select new
                            {
                                r.Incidente_Id,
                                r.Estado_Id,
                                r.FechaHora_Reporte,
                                UsuReporte = p.Apellido_Paterno + " " + p.Apellido_Materno + ", " + p.Nombres,
                                RH_Area = l.Descripcion,
                                Intensidad = i.Descripcion,
                                Severidad = s.Descripcion,
                                r.Informar_Gerencia,
                                r.FechaHora_Incidente
                            };

                rList.AddRange(query.ToList());
                return rList;
            }
        }

        public ArrayList Get_Reportes_List_PEND( string Per_Registro)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                ArrayList rList = new ArrayList();

                var query = from r in obj.ReporteIncidente
                            join p in obj.Personal on r.Personal_Registro equals p.Personal_Id
                            join l in obj.RH_Area on r.Area_Id equals l.Area_Id
                            join i in obj.Intensidad on r.Intensidad_Id equals i.Intensidad_Id
                            join s in obj.Severidad on r.Severidad_Id equals s.Severidad_Id
                            where r.Personal_Registro == Per_Registro
                            && r.Estado_Id=="03"
                            select new
                            {
                                r.Incidente_Id,
                                r.Estado_Id,
                                r.FechaHora_Reporte,
                                UsuReporte = p.Apellido_Paterno + " " + p.Apellido_Materno + ", " + p.Nombres,
                                RH_Area = l.Descripcion,
                                Intensidad = i.Descripcion,
                                Severidad = s.Descripcion,
                                r.Informar_Gerencia,
                                r.FechaHora_Incidente
                            };

                rList.AddRange(query.ToList());
                return rList;
            }
        }

        public ArrayList Get_Reportes_List_PEND_ADM(string Area_Id, DateTime FechaIni, DateTime FechaFin)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                ArrayList rList = new ArrayList();

                var query = from r in obj.ReporteIncidente
                            join p in obj.Personal on r.Personal_Registro equals p.Personal_Id
                            join l in obj.RH_Area on r.Area_Id equals l.Area_Id
                            join i in obj.Intensidad on r.Intensidad_Id equals i.Intensidad_Id
                            join s in obj.Severidad on r.Severidad_Id equals s.Severidad_Id
                            where r.Area_Id.Contains(Area_Id)
                            && r.Estado_Id == "03"
                             && (r.FechaHora_Reporte >= FechaIni && r.FechaHora_Reporte <= FechaFin)
                             orderby r.FechaHora_Reporte descending
                            select new
                            {
                                r.Incidente_Id,
                                r.Estado_Id,
                                r.FechaHora_Reporte,
                                UsuReporte = p.Apellido_Paterno + " " + p.Apellido_Materno + ", " + p.Nombres,
                                RH_Area = l.Descripcion,
                                Intensidad = i.Descripcion,
                                Severidad = s.Descripcion,
                                r.Informar_Gerencia,
                                r.FechaHora_Incidente,
                                CantA=(obj.AccionCorrectiva.Where(x=> x.Incidente_Id==r.Incidente_Id && x.Estado_Id=="06").Count())
                            };

                rList.AddRange(query.ToList());
                return rList;
            }
        }


        //APROBAR REPORTE

        public string Aprobar_Reporte_ADM(string Incidencia_Id) {
            try
            {
                using (ContextMaestro obj = new ContextMaestro())
                {
                    int TotalAcc = obj.AccionCorrectiva.Where(x => x.Incidente_Id == Incidencia_Id).Count();
                    int AccRech = obj.AccionCorrectiva.Where(x => x.Incidente_Id == Incidencia_Id && x.Estado_Id=="02").Count();

                    int res = TotalAcc - AccRech;

                    int AccApro = obj.AccionCorrectiva.Where(x => x.Incidente_Id == Incidencia_Id && x.Estado_Id == "05").Count();

                    if (res == AccApro)
                    {
                        ReporteIncidente rep = obj.ReporteIncidente.Where(x => x.Incidente_Id == Incidencia_Id).First();
                        rep.Estado_Id = "01";
                        obj.SaveChanges();
                        return "true#El Reporte a sido realizado correctamente.";
                    }
                    else {

                        return "false#.::Error, No todas las Acciones Correctivas - Preventivas esta realizadas y aprobadas.\n El proceso no puede completarse.";
                    }
                }
            }
            catch (Exception ex) {
                return "false#" + ex.Message + ". \n Comuniquese con el área de soporte.";
            }
        }
    }
}
