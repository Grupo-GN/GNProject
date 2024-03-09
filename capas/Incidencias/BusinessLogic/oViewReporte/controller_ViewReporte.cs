using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Persistence;

namespace BusinessLogic.oViewReporte
{
    public class controller_ViewReporte
    {
        private static controller_ViewReporte Instance = null;
        public static controller_ViewReporte Get_Instance() {
            return Instance == null ? Instance = new controller_ViewReporte() : Instance;
        }
        public ArrayList Get_Find_ReporteIncidente(string Incidente_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                var queroper = from r in obj.ReporteIncidente
                               join p in obj.Personal on r.Personal_Registro equals p.Personal_Id
                               join l in obj.RH_Area on p.Area_Id equals l.Area_Id
                               where r.Incidente_Id == Incidente_Id
                               select l.Descripcion;
                string rh_Area_Usu = queroper.First(); 

                ArrayList rList = new ArrayList();
                var query = from r in obj.ReporteIncidente
                            join p in obj.Personal on r.Personal_Registro equals p.Personal_Id
                            join l in obj.RH_Area on r.Area_Id equals l.Area_Id
                            join c1 in obj.Categoria_Auxiliar on r.Categoria_Auxiliar_Id equals c1.Categoria_Auxiliar_Id
                            join c2 in obj.Categoria_Auxiliar2 on r.Categoria_Auxiliar2_Id equals c2.Categoria_Auxiliar2_Id into ljoin
                            from rc2 in ljoin.DefaultIfEmpty()
                            join i in obj.Intensidad on r.Intensidad_Id equals i.Intensidad_Id
                            join s in obj.Severidad on r.Severidad_Id equals s.Severidad_Id
                            join t in obj.Tipo on r.Tipo equals t.Tipo_Id
                            join o in obj.Origen on r.Origen equals o.Origen_Id
                            join ti in obj.TipoIncidente on r.TipoI_Id equals ti.TipoI_Id
                            join af in obj.AfectadoInc on r.Afec_Id equals af.Afec_Id
                            where r.Incidente_Id == Incidente_Id
                            select new
                            {
                                r.Incidente_Id,
                                PersonalReg = p.Apellido_Paterno + " " + p.Apellido_Materno + ", " + p.Nombres,
                                RH_Area = l.Descripcion,
                                r.Area_Id,
                                Cat1 = c1.Descripcion,
                                Cat2 = rc2.Categoria_Auxiliar2_Id == null ? "NO ESPECIFICADO" : rc2.Descripcion,
                                ActProp = r.Actividad_Propia,
                                ActRut = r.Actividad_Rutinaria,
                                Intensidad = i.Descripcion,
                                Descripcion = r.Descripcion,
                                InfoGenrencia = r.Informar_Gerencia,
                                InfoOsigermin = r.Informar_Osigermin,
                                FHInc = r.FechaHora_Incidente,
                                FHRep = r.FechaHora_Reporte,
                                Lugar = r.Lugar_Incidente,
                                Tipo = t.Descripcion,
                                Origen=o.Descripcion,
                                Severidad = s.Descripcion,
                                LesionesPer = r.LesionesPerdidas,
                                PosCausas = r.PosiblesCausas,
                                AccInmediata = r.AccionInmediata,
                                Estado = r.Estado_Id,
                                TipoI =ti.Descripcion,
                                Afecto=af.Descripcion,
                                RH_Area_Usu = rh_Area_Usu
                            };
                rList.AddRange(query.ToList());
                return rList;
            }
        }
        public ArrayList Get_AccionCorrectiva_List(string Incidente_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {

                ArrayList rList = new ArrayList();
                var query = from a in obj.AccionCorrectiva
                            join r in obj.Personal on a.Responsable_Id equals r.Personal_Id
                            where a.Incidente_Id == Incidente_Id
                            select new
                            {
                                a.Accion_Id,
                                a.Incidente_Id,
                                a.Descripcion,
                                a.Tipo_Responsable,
                                ResponsableName = r.Apellido_Paterno + " " + r.Apellido_Materno + ", " + r.Nombres,
                                a.Responsable_Id,
                                a.FechaIni,
                                a.FechaFin,
                                a.Estado_Id,
                            };

                rList.AddRange(query.ToList());
                return rList;
            }
        }
        public List<File_Incidencia> Get_Files_Incidencia_List(string Incidente_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                return obj.File_Incidencia.Where(x => x.Incidente_Id == Incidente_Id).ToList();
            }
        }
        public AccionCorrectiva Get_Find_AccionCorrectiva(string Incidente_Id, string Accion_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int existe = obj.AccionCorrectiva.Where(x => x.Incidente_Id == Incidente_Id && x.Accion_Id == Accion_Id).Count();
                if (existe == 1)
                {
                    return obj.AccionCorrectiva.Where(x => x.Incidente_Id == Incidente_Id && x.Accion_Id == Accion_Id).First();
                }
                return null;
            }
        }
        public List<Personal> Get_DataList_Responsable(string Nombres, string Usuario, string Area_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                var query = from p in obj.Personal
                            where p.Personal_Id != Usuario
                            && (p.Apellido_Paterno.Trim() + p.Apellido_Materno.Trim() + p.Nombres.Trim()).Contains(Nombres)
                            //&& p.Area_Id.Contains(Area_Id)
                            && p.Estado_Id == "01"
                            select p;

                return query.ToList();

            }
        }
        public List<File_Accion> Get_Files_Accion_List(string Incidente_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                return obj.File_Accion.Where(x => x.Incidente_Id == Incidente_Id).ToList();
            }
        }
    }

}
