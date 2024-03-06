using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusienssLogic.CA.oParametros;
using static BusienssLogic.CA.oParametros.Controller_MantParametroxConcepto;
using System.Collections;
using System.Web.Services;

namespace GNProject.Views.ControlAsisten.CA.Matenimientos
{
    public partial class ParametroXConcepto : System.Web.UI.Page
    {
        [WebMethod] //lista parametro concepto
        public static List<ParametroConcepto> ListaParametroConcepto(int inicio)
        {
            return Controller_MantParametroxConcepto.GetInstance().ListaParametroConcepto(inicio);
        }

        [WebMethod] // lista parametro concepto id
        public static List<ParametroConcepto> ListaParametroConceptoFind(string codigo)
        {
            return Controller_MantParametroxConcepto.GetInstance().ListaParametroConceptoFind(codigo);
        }

        [WebMethod] // inserta parametro conepto
        public static bool InsertaParametroConcepto(string Concepto_Id, string Parametro_Id, string Estado, string semana)
        {
            return Controller_MantParametroxConcepto.GetInstance().InsertaParametroConcepto(Concepto_Id, Parametro_Id, Estado, semana);
        }

        [WebMethod] // actualiza parametro concepto
        public static bool ActualizaParametroConcepto(string codigo, string Concepto_Id, string Parametro_Id, string Estado, string semana)
        {
            return Controller_MantParametroxConcepto.GetInstance().ActualizaParametroConcepto(codigo, Concepto_Id, Parametro_Id, Estado, semana);
        }

        [WebMethod] // lista parametro  
        public static ArrayList Get_Parametro_List()
        {
            return Controller_MantParametroxConcepto.GetInstance().Get_Parametro_List();
        }

        [WebMethod] // lista  concepto  
        public static ArrayList Get_Concepto_List()
        {
            return Controller_MantParametroxConcepto.GetInstance().Get_Concepto_List();
        }
        [WebMethod]
        public static int GetMaxData()
        {
            return Controller_MantParametroxConcepto.GetInstance().GetMaxData();
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