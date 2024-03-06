using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presistence;
using BusienssLogic.CA.oParametrosPersona;
using System.Web.Services;
using System.Collections;

namespace GNProject.Views.ControlAsisten.CA.Matenimientos
{
    public partial class MParametrosPersona : System.Web.UI.Page
    {
        [WebMethod]
        public static ArrayList Get_Planillas_List()
        {
            return Controller_MantParametrosPersona.GetInstance().Get_Planillas_List();
        }
        [WebMethod]
        public static ArrayList Get_Localidades_List()
        {
            return Controller_MantParametrosPersona.GetInstance().Get_Localidades_List();
        }
        [WebMethod]
        public static ArrayList Get_Secciones_List()
        {
            return Controller_MantParametrosPersona.GetInstance().Get_Secciones_List();
        }
        [WebMethod]
        public static ArrayList Get_Periodos_List(string Planilla)
        {
            return Controller_MantParametrosPersona.GetInstance().Get_Periodos_List(Planilla);
        }
        [WebMethod]
        public static ArrayList Get_Personal_List()
        {
            return Controller_MantParametrosPersona.GetInstance().Get_Personal_List();
        }
        [WebMethod]
        public static List<Presistence.CustomDAL.eParamentros> Get_Variables_List(string Personal_Id)
        {
            return Controller_MantParametrosPersona.GetInstance().Get_Variables_List(Personal_Id);
        }
        [WebMethod]
        public static ArrayList Get_ParametrosPersona_List(string Personal_Id, int inicio)
        {
            return Controller_MantParametrosPersona.GetInstance().Get_ParametrosPersona_List(Personal_Id, inicio);
        }
        [WebMethod]
        public static bool Get_ParametrosPersona_Add(int Parametro_Id, string Personal_Id, string Valor)
        {
            return Controller_MantParametrosPersona.GetInstance().Get_ParametrosPersona_Add(Parametro_Id, Personal_Id, Valor);
        }
        [WebMethod]
        public static ParametrosControlAsistencia Get_ParametrosPersona_Find(int codigo)
        {
            return Controller_MantParametrosPersona.GetInstance().Get_ParametrosPersona_Find(codigo);
        }
        [WebMethod]
        public static bool Get_ParametrosPersona_UpdateValor(int Parametro_Id, string Personal_Id, string newValor)
        {
            return Controller_MantParametrosPersona.GetInstance().Get_ParametrosPersona_UpdateValor(Parametro_Id, Personal_Id, newValor);
        }
        [WebMethod]
        public static ArrayList Get_Parametros_List()
        {
            return Controller_MantParametrosPersona.GetInstance().Get_Parametros_List();
        }
    }
}