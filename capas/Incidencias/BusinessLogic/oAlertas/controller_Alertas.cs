using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistence;
using System.Collections;
namespace BusinessLogic.oAlertas
{
    public class controller_Alertas
    {
        private static controller_Alertas Instance = null;
        public static controller_Alertas Get_Instance() {
            return Instance == null ? Instance = new controller_Alertas() : Instance;
        }

        public List<int> Get_Alertas_By_Rol(string Usuario_Id,string Rol_Id) { 
            using(ContextMaestro obj=new ContextMaestro()){
                List<int> rList = new List<int>();
                
                if (Rol_Id == "01")
                {
                    //ADMINISTRADOR

                    //NUEVOS REPORTES
                    int new_report = obj.ReporteIncidente.Where(x => x.Estado_Id == "04").Count();
                    //REPORTES PENDIENTES
                    int rep_pend = obj.ReporteIncidente.Where(x => x.Estado_Id == "03").Count();
                    //ACIONES POR FINALIZAR
                    DateTime fec_actual = DateTime.Now;
                    int acc_fin = obj.ReporteIncidente.Where(x => x.Estado_Id == "03")
                        .Join(obj.AccionCorrectiva.Where(x => x.Estado_Id != "05"
                            && x.FechaFin>=fec_actual)
                        , a => a.Incidente_Id, b => b.Incidente_Id,
                        (a, b) => new { a.Incidente_Id, b.Accion_Id }).Distinct().Count();

                    //ACIONES FUERA DE FECHA
                    
                    int acc_ffecha = obj.ReporteIncidente.Where(x => x.Estado_Id == "03")
                        .Join(obj.AccionCorrectiva.Where(x => x.Estado_Id != "05" && x.FechaFin < fec_actual)
                        , a => a.Incidente_Id, b => b.Incidente_Id,
                        (a, b) => new { a.Incidente_Id, b.Accion_Id }).Distinct().Count();

                    //ACIONES POR REVISAR
                    int acc_revi = obj.ReporteIncidente.Where(x => x.Estado_Id == "03")
                        .Join(obj.AccionCorrectiva.Where(x => x.Estado_Id == "06")
                        , a => a.Incidente_Id, b => b.Incidente_Id,
                        (a, b) => new { a.Incidente_Id, b.Accion_Id }).Distinct().Count();

                    //ACIONES DESAPROBADAS
                    int acc_desa = obj.ReporteIncidente.Where(x => x.Estado_Id == "03")
                        .Join(obj.AccionCorrectiva.Where(x => (x.Estado_Id == "02" || x.Estado_Id == "04"))
                        , a => a.Incidente_Id, b => b.Incidente_Id,
                        (a, b) => new { a.Incidente_Id, b.Accion_Id }).Distinct().Count();


                    int osigerminPre = obj.ReporteIncidente.Where(x => (x.Estado_Id == "03" || x.Estado_Id == "01")
                                                                 && x.Informar_Osigermin=="01" && x.SendPreliminar=="00" ).Count();

                    int osigerminFin= obj.ReporteIncidente.Where(x => (x.Estado_Id == "03" || x.Estado_Id == "01") 
                                                                 && x.Informar_Osigermin == "01" &&  x.SendFinal == "00").Count();

                    rList.Add(new_report);
                    rList.Add(rep_pend);
                    rList.Add(acc_fin);
                    rList.Add(acc_ffecha);
                    rList.Add(acc_revi);
                    rList.Add(acc_desa);
                    rList.Add(osigerminPre);
                    rList.Add(osigerminFin);

                }
                else if(Rol_Id=="02"){
                    //JEFE
                    //ADMINISTRADOR

                    //NUEVOS REPORTES
                    int j_new_report = obj.ReporteIncidente.Where(x => x.Estado_Id == "04" && x.Personal_Registro == Usuario_Id).Count();

                    //REPORTES PENDIENTES
                    int j_rep_pend = obj.ReporteIncidente.Where(x => x.Estado_Id == "03" && x.Personal_Registro == Usuario_Id).Count();

                    //ACIONES POR FINALIZAR
                    DateTime fec_actual = DateTime.Now;
                    int j_acc_fin = obj.ReporteIncidente.Where(x => x.Estado_Id == "03" && x.Personal_Registro == Usuario_Id)
                        .Join(obj.AccionCorrectiva.Where(x => x.Estado_Id != "05"
                            && x.FechaFin >= fec_actual)
                        , a => a.Incidente_Id, b => b.Incidente_Id,
                        (a, b) => new { a.Incidente_Id, b.Accion_Id }).Distinct().Count();

                    //ACIONES FUERA DE FECHA
                    int j_acc_ffecha = obj.ReporteIncidente.Where(x => x.Estado_Id == "03" && x.Personal_Registro == Usuario_Id)
                        .Join(obj.AccionCorrectiva.Where(x => x.Estado_Id != "05" && x.FechaFin < fec_actual)
                        , a => a.Incidente_Id, b => b.Incidente_Id,
                        (a, b) => new { a.Incidente_Id, b.Accion_Id }).Distinct().Count();

                    //ACIONES POR REVISAR
                    int j_acc_revi = obj.ReporteIncidente.Where(x => x.Estado_Id == "03" && x.Personal_Registro == Usuario_Id)
                        .Join(obj.AccionCorrectiva.Where(x => x.Estado_Id == "06")
                        , a => a.Incidente_Id, b => b.Incidente_Id,
                        (a, b) => new { a.Incidente_Id, b.Accion_Id }).Distinct().Count();

                    //ACIONES DESAPROBADAS
                    int j_acc_desa = obj.ReporteIncidente.Where(x => x.Estado_Id == "03" && x.Personal_Registro == Usuario_Id)
                        .Join(obj.AccionCorrectiva.Where(x => (x.Estado_Id == "02" || x.Estado_Id == "04"))
                        , a => a.Incidente_Id, b => b.Incidente_Id,
                        (a, b) => new { a.Incidente_Id, b.Accion_Id }).Distinct().Count();


                    rList.Add(j_new_report);
                    rList.Add(j_rep_pend);
                    rList.Add(j_acc_fin);
                    rList.Add(j_acc_ffecha);
                    rList.Add(j_acc_revi);
                    rList.Add(j_acc_desa);

                }

                




                return rList;            
            }
        }





        
        #region DATOS POR ALERTA

        //NUEVOS REPORTES ADMINISTRADOR
        public ArrayList Get_NuevoReportes_ADM()
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                ArrayList rList = new ArrayList();
                var query = from r in obj.ReporteIncidente
                            join p in obj.Personal on r.Personal_Registro equals p.Personal_Id
                            join l in obj.RH_Area on r.Area_Id equals l.Area_Id
                            join i in obj.Intensidad on r.Intensidad_Id equals i.Intensidad_Id
                            join s in obj.Severidad on r.Severidad_Id equals s.Severidad_Id
                            where r.Estado_Id=="04"
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

        //NUEVOS REPORTES POR JEFE DE PLANTA

        public ArrayList Get_NuevoReportes_PLANT(string Per_Registro)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                ArrayList rList = new ArrayList();

                var query = from r in obj.ReporteIncidente
                            join p in obj.Personal on r.Personal_Registro equals p.Personal_Id
                            join l in obj.RH_Area on r.Area_Id equals l.Area_Id
                            join i in obj.Intensidad on r.Intensidad_Id equals i.Intensidad_Id
                            join s in obj.Severidad on r.Severidad_Id equals s.Severidad_Id
                            where 
                            r.Estado_Id=="04"
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


        //ACCIONES POR FINALIZAR
        public ArrayList Get_Acciones_Finalizar_ADM() { 
            using(ContextMaestro obj=new ContextMaestro()){
                ArrayList rList = new ArrayList();
                DateTime fecAc=DateTime.Now;

                var query = from r in obj.ReporteIncidente
                            join a in obj.AccionCorrectiva on r.Incidente_Id equals a.Incidente_Id
                            join p in obj.Personal on a.Responsable_Id equals p.Personal_Id
                            where r.Estado_Id == "03"
                            && a.FechaFin >= fecAc
                            && a.Estado_Id!="05"
                            select new { 
                                    r.Incidente_Id,
                                    a.Estado_Id,
                                    a.Descripcion,
                                    Responsable=p.Apellido_Paterno+" "+p.Apellido_Materno+", "+p.Nombres,
                                    r.FechaHora_Incidente,
                                    r.FechaHora_Reporte,
                                    a.FechaIni,
                                    a.FechaFin
                            };
                rList.AddRange(query.ToList());
                return rList;
            }        
        }
        public ArrayList Get_Acciones_Finalizar_PLANT(string Per_Registro)
        {

                using (ContextMaestro obj = new ContextMaestro())
                {
                    ArrayList rList = new ArrayList();
                    DateTime fecAc = DateTime.Now;

                    var query = from r in obj.ReporteIncidente
                                join a in obj.AccionCorrectiva on r.Incidente_Id equals a.Incidente_Id
                                join p in obj.Personal on a.Responsable_Id equals p.Personal_Id
                                where r.Estado_Id == "03"
                                && a.FechaFin >= fecAc
                                && r.Personal_Registro == Per_Registro
                                select new
                                {
                                    r.Incidente_Id,
                                    a.Estado_Id,
                                    a.Descripcion,
                                    Responsable = p.Apellido_Paterno + " " + p.Apellido_Materno + ", " + p.Nombres,
                                    r.FechaHora_Incidente,
                                    r.FechaHora_Reporte,
                                    a.FechaIni,
                                    a.FechaFin
                                };
                    rList.AddRange(query.ToList());
                    return rList;
                }  
            
        }

        //ACCIONES FUERA DE FECHA
        public ArrayList Get_Acciones_FFecha_ADM()
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                ArrayList rList = new ArrayList();
                DateTime fecAc = DateTime.Now;

                var query = from r in obj.ReporteIncidente
                            join a in obj.AccionCorrectiva on r.Incidente_Id equals a.Incidente_Id
                            join p in obj.Personal on a.Responsable_Id equals p.Personal_Id
                            where r.Estado_Id == "03"
                            && (a.FechaFin < fecAc && a.Estado_Id != "05")
                            select new
                            {
                                r.Incidente_Id,
                                a.Estado_Id,
                                a.Descripcion,
                                Responsable = p.Apellido_Paterno + " " + p.Apellido_Materno + ", " + p.Nombres,
                                r.FechaHora_Incidente,
                                r.FechaHora_Reporte,
                                a.FechaIni,
                                a.FechaFin
                            };
                rList.AddRange(query.ToList());
                return rList;
            }
        }
        public ArrayList Get_Acciones_FFecha_PLANT(string Per_Registro)
        {

            using (ContextMaestro obj = new ContextMaestro())
            {
                ArrayList rList = new ArrayList();
                DateTime fecAc = DateTime.Now;

                var query = from r in obj.ReporteIncidente
                            join a in obj.AccionCorrectiva on r.Incidente_Id equals a.Incidente_Id
                            join p in obj.Personal on a.Responsable_Id equals p.Personal_Id
                            where r.Estado_Id == "03"
                            && a.FechaFin < fecAc
                            && r.Personal_Registro == Per_Registro
                            && a.Estado_Id != "05"
                            select new
                            {
                                r.Incidente_Id,
                                a.Estado_Id,
                                a.Descripcion,
                                Responsable = p.Apellido_Paterno + " " + p.Apellido_Materno + ", " + p.Nombres,
                                r.FechaHora_Incidente,
                                r.FechaHora_Reporte,
                                a.FechaIni,
                                a.FechaFin
                            };
                rList.AddRange(query.ToList());
                return rList;
            }

        }

        //ACCIONES PENDIENTE DE REVISION
        public ArrayList Get_Acciones_Revisar_ADM()
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                ArrayList rList = new ArrayList();

                var query = from r in obj.ReporteIncidente
                            join a in obj.AccionCorrectiva on r.Incidente_Id equals a.Incidente_Id
                            join p in obj.Personal on a.Responsable_Id equals p.Personal_Id
                            where r.Estado_Id == "03"
                            && a.Estado_Id == "06"
                            select new
                            {
                                r.Incidente_Id,
                                a.Estado_Id,
                                a.Descripcion,
                                Responsable = p.Apellido_Paterno + " " + p.Apellido_Materno + ", " + p.Nombres,
                                r.FechaHora_Incidente,
                                r.FechaHora_Reporte,
                                a.FechaIni,
                                a.FechaFin
                            };
                rList.AddRange(query.ToList());
                return rList;
            }
        }
        public ArrayList Get_Acciones_Revisar_PLANT(string Per_Registro)
        {

            using (ContextMaestro obj = new ContextMaestro())
            {
                ArrayList rList = new ArrayList();


                var query = from r in obj.ReporteIncidente
                            join a in obj.AccionCorrectiva on r.Incidente_Id equals a.Incidente_Id
                            join p in obj.Personal on a.Responsable_Id equals p.Personal_Id
                            where r.Estado_Id == "03"                           
                            && r.Personal_Registro == Per_Registro
                            && a.Estado_Id == "06"
                            select new
                            {
                                r.Incidente_Id,
                                a.Estado_Id,
                                a.Descripcion,
                                Responsable = p.Apellido_Paterno + " " + p.Apellido_Materno + ", " + p.Nombres,
                                r.FechaHora_Incidente,
                                r.FechaHora_Reporte,
                                a.FechaIni,
                                a.FechaFin
                            };
                rList.AddRange(query.ToList());
                return rList;
            }

        }

        //ACCIONES DESAPROBADOS
        public ArrayList Get_Acciones_Desaprobados_ADM()
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                ArrayList rList = new ArrayList();

                var query = from r in obj.ReporteIncidente
                            join a in obj.AccionCorrectiva on r.Incidente_Id equals a.Incidente_Id
                            join p in obj.Personal on a.Responsable_Id equals p.Personal_Id
                            where r.Estado_Id == "03"
                            && (a.Estado_Id == "04" || a.Estado_Id=="02")
                            select new
                            {
                                r.Incidente_Id,
                                a.Estado_Id,
                                a.Descripcion,
                                Responsable = p.Apellido_Paterno + " " + p.Apellido_Materno + ", " + p.Nombres,
                                r.FechaHora_Incidente,
                                r.FechaHora_Reporte,
                                a.FechaIni,
                                a.FechaFin
                            };
                rList.AddRange(query.ToList());
                return rList;
            }
        }
        public ArrayList Get_Acciones_Desaprobados_PLANT(string Per_Registro)
        {

            using (ContextMaestro obj = new ContextMaestro())
            {
                ArrayList rList = new ArrayList();


                var query = from r in obj.ReporteIncidente
                            join a in obj.AccionCorrectiva on r.Incidente_Id equals a.Incidente_Id
                            join p in obj.Personal on a.Responsable_Id equals p.Personal_Id
                            where r.Estado_Id == "03"
                            && r.Personal_Registro == Per_Registro
                            && (a.Estado_Id == "04" || a.Estado_Id == "02")
                            select new
                            {
                                r.Incidente_Id,
                                a.Estado_Id,
                                a.Descripcion,
                                Responsable = p.Apellido_Paterno + " " + p.Apellido_Materno + ", " + p.Nombres,
                                r.FechaHora_Incidente,
                                r.FechaHora_Reporte,
                                a.FechaIni,
                                a.FechaFin
                            };
                rList.AddRange(query.ToList());
                return rList;
            }

        }

        //OSIGERMIN
        public ArrayList Get_Reportes_Osigermin_ADM()
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                ArrayList rList = new ArrayList();

                /* DateTime FI = DateTime.Parse(FechaIni);
                 DateTime FF = DateTime.Parse(FechaFin + " 23:59:00.000");*/
                var query = from r in obj.ReporteIncidente
                            join p in obj.Personal on r.Personal_Registro equals p.Personal_Id
                            join l in obj.RH_Area on r.Area_Id equals l.Area_Id
                            join i in obj.Intensidad on r.Intensidad_Id equals i.Intensidad_Id
                            join s in obj.Severidad on r.Severidad_Id equals s.Severidad_Id
                            where (r.Estado_Id=="03" || r.Estado_Id=="01")
                            && r.Informar_Osigermin=="01"
                            && (r.SendPreliminar=="00" || r.SendFinal=="00")
                            select new
                            {
                                r.Incidente_Id,
                                r.Estado_Id,
                                r.FechaHora_Reporte,
                                r.FechaHora_Incidente,
                                UsuReporte = p.Apellido_Paterno + " " + p.Apellido_Materno + ", " + p.Nombres,
                                RH_Area = l.Descripcion,
                                r.Informar_Gerencia,
                                r.Informar_Osigermin,
                                r.SendPreliminar,
                                r.SendFinal
                            };

                rList.AddRange(query.ToList());
                return rList;
            }
        }

        #endregion

    }
}
