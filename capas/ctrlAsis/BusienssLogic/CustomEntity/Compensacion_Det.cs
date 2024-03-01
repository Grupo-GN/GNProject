using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusienssLogic.CustomEntity
{

   public class Compensacion_Det
    {
        public int id_compensacion { get; set; }
        public DateTime fecha_compensada { get; set; }
        public DateTime hora_tardanza { get; set; }
        public DateTime fecha_falta { get; set; }
        public string modo_compensacion { get; set; }
        public int can_horas_compensadas { get; set; }
        public int Asistencia_Id { get; set; }
     



    }
}
