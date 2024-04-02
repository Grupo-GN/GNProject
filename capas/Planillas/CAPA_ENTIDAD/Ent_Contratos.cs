using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    [Serializable]
            public class Ent_Contratos
    {
       

        private string ePeriodoId;
        public string PeriodoId
        {
            get { return ePeriodoId; }
            set { ePeriodoId = value; }
        }

        private string eArea;
        public string Area
        {
            get { return eArea; }
            set { eArea = value; }
        }

                          
       // public String Mes{ get; set; }
        public Int32 Mes { get; set; }

        private String _Anio;
        public String Anio
        {
            get { return _Anio; }
            set { _Anio = value; }
        }

        //private int _flag;

        //public int Flag
        //{
        //    get { return _flag; }
        //    set { _flag = value; }
        //}
    }


            public class Ent_DiferenciaFechas
            {
                public string FechaInicial { get; set; }
                public string FechaFinal { get; set; }
                public Int32 Anios { get; set; }
                public Int32 Meses { get; set; }
                public Int32 Dias { get; set; }

            }
}
