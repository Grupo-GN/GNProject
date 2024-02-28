using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusienssLogic.CA.oCompensaciones;
using System.Web.Services;
using System.Collections;

namespace GNProject.Views.ControlAsisten.CA.caReporteGeneral
{
    public partial class CaReporteHE : System.Web.UI.Page
    {
        [WebMethod]
        public static ArrayList Lista_HoraExtra(string Planilla_Id, string Periodo_Id, string Localidad_Id, string id_personal)
        {

            return ControllerCompensaciones.Get_Instance().Lista_HoraExtra(Planilla_Id, Periodo_Id, Localidad_Id, id_personal);
        }

        [WebMethod]
        public static string Insert_Bolsa_HE(List<string> Rlist)
        {
            return ControllerCompensaciones.Get_Instance().Insert_Bolsa_HE(Rlist);
        }

        [WebMethod]
        public static ArrayList ListaBolsaHorasComp(string id_personal)
        {

            return ControllerCompensaciones.Get_Instance().ListaBolsaHorasComp(id_personal);
        }
    }
}