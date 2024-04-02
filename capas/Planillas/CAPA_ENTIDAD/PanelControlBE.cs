using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class PanelControlBE
    {
        public class FiltrosBE
        {
            public String TipoGrafico { get; set; }
            public String Planilla_Id { get; set; }
            public String Ejercicio_Id { get; set; }
            public String nMes_Ids { get; set; }
            public String Area_Ids { get; set; }
            public String CatAuxiliar_Ids { get; set; }
            public String Tipo_Agrupacion { get; set; }
            public String Personal_Ids { get; set; }

            public String Proceso_Ids { get; set; }
            public String Boleta_Columna { get; set; }
            public String Concepto_Ids { get; set; }
        }
        public class GraficoPieBE
        {
            public String CodTipoCategoria { get; set; }
            public String TipoCategoria { get; set; }
            public Decimal Valor { get; set; }
        }
        public class GraficoXYBE
        {
            public String Serie { get; set; }
            public String Cod_Eje_X { get; set; }
            public String Eje_X { get; set; }
            public Decimal Eje_Y_Valor { get; set; }
        }
    }
    
}
