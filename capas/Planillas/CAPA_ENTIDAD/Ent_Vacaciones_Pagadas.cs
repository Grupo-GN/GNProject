using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Vacaciones_Pagadas
    {
        string _Vacaciones_pagadas_id;

        public string Vacaciones_pagadas_id
        {
            get { return _Vacaciones_pagadas_id; }
            set { _Vacaciones_pagadas_id = value; }
        }

        string _Vacaciones_id;

        public string Vacaciones_id
        {
            get { return _Vacaciones_id; }
            set { _Vacaciones_id = value; }
        }

        string _Periodo_id;

        public string Periodo_id
        {
            get { return _Periodo_id; }
            set { _Periodo_id = value; }
        }

        DateTime _Fecha_Ini;

        public DateTime Fecha_Ini
        {
            get { return _Fecha_Ini; }
            set { _Fecha_Ini = value; }
        }

        DateTime _Fecha_Fin;

        public DateTime Fecha_Fin
        {
            get { return _Fecha_Fin; }
            set { _Fecha_Fin = value; }
        }

        string _lvendido;

        public string Lvendido
        {
            get { return _lvendido; }
            set { _lvendido = value; }
        }
    }
}
