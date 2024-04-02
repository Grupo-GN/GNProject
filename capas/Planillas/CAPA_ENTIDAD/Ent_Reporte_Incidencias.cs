using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Reporte_Incidencias
    {
        string _Personal_id;

        public string Personal_id
        {
            get { return _Personal_id; }
            set { _Personal_id = value; }
        }
        string _Periodo_Id;

        public string Periodo_Id
        {
            get { return _Periodo_Id; }
            set { _Periodo_Id = value; }
        }
        string _Concepto_Id;

        public string Concepto_Id
        {
            get { return _Concepto_Id; }
            set { _Concepto_Id = value; }
        }
        string _tabla;

        public string Tabla
        {
            get { return _tabla; }
            set { _tabla = value; }
        }
    }
}
