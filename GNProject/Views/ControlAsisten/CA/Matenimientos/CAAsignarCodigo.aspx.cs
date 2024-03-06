using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presistence;
using System.Collections;
using System.Web.Services;
using BusienssLogic.CA.oAsignarHorarioPersona;
using BusienssLogic.CA.oAsignarCodigo;

namespace GNProject.Views.ControlAsisten.CA.Matenimientos
{
    public partial class CAAsignarCodigo : System.Web.UI.Page
    {
        [WebMethod]
        public static ArrayList Get_Planillas_List()
        {
            return Controller_MantAsignarHorarioPersona.GetInstance().Get_Planillas_List();
        }
        [WebMethod]
        public static ArrayList Get_Localidades_List()
        {
            return Controller_MantAsignarHorarioPersona.GetInstance().Get_Localidades_List();
        }

        [WebMethod]
        public static ArrayList Get_Areas_List()
        {
            return Controller_MantAsignarHorarioPersona.GetInstance().Get_Areas_List();
        }

        [WebMethod]
        public static ArrayList List_Periodo(string Plantilla)
        {
            return Controller_AsignarCodigo.GetInstance().List_Periodo(Plantilla);

        }
        [WebMethod]
        public static ArrayList CargarPersonal(string seccion, string Localidad, string Periodo_id)
        {
            return Controller_AsignarCodigo.GetInstance().CargarPersonal(seccion, Localidad, Periodo_id);
        }
        [WebMethod]
        public static bool AsignarCodigo_Save(string Personal_Id, string CodigoActual, string co_trabajador_id)
        {
            return Controller_AsignarCodigo.GetInstance().AsignarCodigo_Save(Personal_Id, CodigoActual, co_trabajador_id);
        }
    }
}