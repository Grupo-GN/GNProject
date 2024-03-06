using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusienssLogic.CA.oReporteGeneral;
using System.Web.Services;
using static BusienssLogic.CA.oReporteGeneral.Controller_Indicadores;

namespace GNProject.Views.ControlAsisten.CA.Indicadores
{
    public partial class IndicadoresGen : System.Web.UI.Page
    {
        //General
        [WebMethod]
        public static List<Indicadores_Gen> Lista_General(string Personal_Id, string Fecha_Inicio, string Fecha_Fin, string Flat, string planilla_id)
        {
            return Controller_Indicadores.Get_Instance().Lista_General(Personal_Id, Fecha_Inicio, Fecha_Fin, Flat, planilla_id);
        }
        //Localidad
        [WebMethod]
        public static List<Indicadores_Gen> Lista_Localidad(string Periodo_id, string Personal_Id, string Fecha_Inicio, string Fecha_Fin, string Flat)
        {
            return Controller_Indicadores.Get_Instance().Lista_Localidad(Periodo_id, "", Fecha_Inicio, Fecha_Fin, Flat);
        }
        //area
        [WebMethod]
        public static List<Indicadores_Gen> Lista_Area(string Periodo_id, string Personal_Id, string Fecha_Inicio, string Fecha_Fin, string Flat)
        {
            return Controller_Indicadores.Get_Instance().Lista_Area(Periodo_id, "", Fecha_Inicio, Fecha_Fin, Flat);
        }

    }
}