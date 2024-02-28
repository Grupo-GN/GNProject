using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presistence;
using System.Collections;

namespace BusinessLogic.oCapacitacionRealizar
{
    public class controller_CapacitacionRealizar
    {
        private static controller_CapacitacionRealizar Instance = null;
        public static controller_CapacitacionRealizar Get_Instance()
        {
            return Instance == null ? Instance = new controller_CapacitacionRealizar() : Instance;
        }
        public ArrayList Get_CapacitarcionPendiente(string Area_Id, string Personal_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                ArrayList rList = new ArrayList();
                var query = from ca in obj.CapacitacionIncidente
                            join re in obj.RealizaCapacitacion on ca.Capacitacion_Id equals re.Capacitacion_Id
                            join inc in obj.ReporteIncidente on ca.Incidente_Id equals inc.Incidente_Id
                            where re.Area_Id == Area_Id
                                  && re.Responsable_Id == Personal_Id
                            select new
                            {
                                ca.Capacitacion_Id,
                                ca.Incidente_Id,
                                ca.Descripcion,
                                ca.Observaciones,
                                re.Estado
                            };
                rList.AddRange(query.ToList());
                return rList;
            }

        }

        public objRealizaCapacitacion Get_RealizacionCapacitacion(string Realizacion_Id, string Capacitacion_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {

                int existe = obj.RealizaCapacitacion.Where(x => x.Realizacion_Id == Realizacion_Id && x.Capacitacion_Id == Capacitacion_Id).Count();

                if (existe == 1)
                {
                    RealizaCapacitacion rel = obj.RealizaCapacitacion.Where(x => x.Realizacion_Id == Realizacion_Id && x.Capacitacion_Id == Capacitacion_Id).First();
                    objRealizaCapacitacion obReal = new objRealizaCapacitacion();
                    obReal.Realizacion_Id = rel.Realizacion_Id;
                    obReal.Capacitacion_Id = rel.Capacitacion_Id;
                    obReal.Area_Id = rel.Area_Id;
                    obReal.Responsable_Id = rel.Responsable_Id;
                    obReal.Observaciones = rel.Observaciones;
                    obReal.FechaRegistro = DateTime.Parse(rel.FechaRegistro.ToString());
                    obReal.Estado = rel.Realizacion_Id;

                    return obReal;

                }

                return null;
            }
        }


    }

    public class objRealizaCapacitacion
    {
        public string Realizacion_Id { get; set; }
        public string Capacitacion_Id { get; set; }
        public string Area_Id { get; set; }
        public string Responsable_Id { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Estado { get; set; }

    }
}
