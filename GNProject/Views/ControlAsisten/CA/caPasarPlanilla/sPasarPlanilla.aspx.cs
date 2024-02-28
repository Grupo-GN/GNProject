using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Collections;
using Presistence;
using BusienssLogic.CA.oPasarPlanilla;
using BusienssLogic.CA.oCompensaciones;
using static BusienssLogic.CA.oParametros.Controller_MantParametroxConcepto;
using BusienssLogic.CA.oParametros;

namespace GNProject.Views.ControlAsisten.CA.caPasarPlanilla
{
    public partial class sPasarPlanilla : System.Web.UI.Page
    {

        [WebMethod]
        public static ArrayList Get_Planilla_List()
        {
            return controller_PasarPlanilla.Get_Instance().Get_Planilla_List();
        }
        //nuevo
        [WebMethod]
        public static ArrayList Get_Localidad_List()
        {
            return controller_PasarPlanilla.Get_Instance().Get_Localidad_List();
        }
        //antiguo
        [WebMethod]
        public static List<areas_planillas_sofya> Get_Localidad_List_OLD()
        {
            return controller_PasarPlanilla.Get_Instance().Get_Localidad_List_OLD();
        }

        [WebMethod]
        public static ArrayList Get_Categoria_List()
        {
            return controller_PasarPlanilla.Get_Instance().Get_Categoria_List();
        }

        [WebMethod]
        public static ArrayList Get_Periodo_List(string Planilla_Id)
        {
            return controller_PasarPlanilla.Get_Instance().Get_Periodo_List(Planilla_Id);
        }

        [WebMethod]
        public static ArrayList Get_CategoriaAux_List()
        {
            return controller_PasarPlanilla.Get_Instance().Get_CategoriaAux_List();
        }

        [WebMethod]
        public static ArrayList Get_Personal_List(string Periodo_Id, string Localidad_Id, string CateAux, string Categoria)
        {
            if (Localidad_Id == null)
            {
                Localidad_Id = "";
            }

            return controller_PasarPlanilla.Get_Instance().Get_Personal_List(Periodo_Id, Localidad_Id, CateAux, Categoria);
        }

        [WebMethod]
        public static List<Novedades> Get_NovedadesPasarPlanilla(string Planilla_Id, string Periodo_Id, string Localidad_Id, string Flat, string[] Personal_Id)
        {
            return controller_PasarPlanilla.Get_Instance().Get_NovedadesPasarPlanilla(Planilla_Id, Periodo_Id, Localidad_Id, Flat, Personal_Id);
        }

        [WebMethod]
        public static List<Novedades> Get_NovedadesPasarPlanilla2(string Planilla_Id, string Periodo_Id, string Localidad_Id, string Flat, string[] Personal_Id, string FechaIni, string FechaFin)
        {
            return controller_PasarPlanilla.Get_Instance().Get_NovedadesPasarPlanilla2(Planilla_Id, Periodo_Id, Localidad_Id, Flat, Personal_Id, FechaIni, FechaFin);
        }


        [WebMethod]
        public static string ActualizarConceptoPlanilla(string Planilla_Id, string Periodo_Id, string Concepto_Id, string Personal_Id, decimal Valor)
        {
            return controller_PasarPlanilla.Get_Instance().ActualizarConceptoPlanilla(Planilla_Id, Periodo_Id, Concepto_Id, Personal_Id, Valor);
        }
        [WebMethod]
        public static string Get_Variables(string flat)
        {
            return ControllerCompensaciones.Get_Instance().Get_Variables(flat);

        }

        [WebMethod] //lista parametro concepto
        public static List<ParametroConcepto> ListaParametroConcepto2()
        {
            return Controller_MantParametroxConcepto.GetInstance().ListaParametroConcepto2();
        }

        [WebMethod]
        public static List<qsemana> ListaSemana()
        {
            return Controller_MantParametroxConcepto.GetInstance().ListaSemana();
        }


    }
}