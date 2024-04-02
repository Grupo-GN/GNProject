using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Reportes_DetalleBE
    {
        private string newReporte_Id;
        public string Reporte_Id
        {
            get { return newReporte_Id; }
            set { newReporte_Id = value; }
        }

        private string newNro_Orden;
        public string Nro_Orden
        {
            get { return newNro_Orden; }
            set { newNro_Orden = value; }
        }

        private string newAlias;
        public string strAlias
        {
            get { return newAlias; }
            set { newAlias = value; }
        }

        private string newcSQL;
        public string cSQL
        {
            get { return newcSQL; }
            set { newcSQL = value; }
        }
    }
}
