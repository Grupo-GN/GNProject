using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_General
    {
        string planillaId;

        public string _PlanillaId
        {
            get { return planillaId; }
            set { planillaId = value; }
        }
        string Ejercicio_Id;

        public string _Ejercicio_Id
        {
            get { return Ejercicio_Id; }
            set { Ejercicio_Id = value; }
        }
    }
}
