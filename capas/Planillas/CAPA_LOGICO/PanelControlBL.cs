using CAPA_DATOS;
using CAPA_ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_LOGICO
{
    public class PanelControlBL
    {
        PanelControlDA oPanelControlDA = new PanelControlDA();
        public List<PanelControlBE.GraficoPieBE> getGraficoPie(PanelControlBE.FiltrosBE oFiltrosBE)
        {
            try
            {
                return oPanelControlDA.getGraficoPie(oFiltrosBE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<PanelControlBE.GraficoXYBE> getGraficoXY(PanelControlBE.FiltrosBE oFiltrosBE)
        {
            try
            {
                return oPanelControlDA.getGraficoXY(oFiltrosBE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
