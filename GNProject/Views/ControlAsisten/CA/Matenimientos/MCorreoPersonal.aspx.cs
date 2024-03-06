using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presistence;
using BusienssLogic.CA.oCorreoPersonal;
using System.Web.Services;
using System.Collections;

namespace GNProject.Views.ControlAsisten.CA.Matenimientos
{
    public partial class MCorreoPersonal : System.Web.UI.Page
    {
        [WebMethod]
        public static ArrayList Get_Planillas_List(int inicio)
        {
            return Controller_MantCorreoPersonal.GetInstance().Get_Planillas_List();
        }
        [WebMethod]
        public static ArrayList Get_Localidades_List(int inicio)
        {
            return Controller_MantCorreoPersonal.GetInstance().Get_Localidades_List();
        }
        [WebMethod]
        public static ArrayList Get_Secciones_List(int inicio)
        {
            return Controller_MantCorreoPersonal.GetInstance().Get_Secciones_List();
        }
        [WebMethod]
        public static List<Categoria2> Get_Categorias_List(int inicio)
        {
            return Controller_MantCorreoPersonal.GetInstance().Get_Categorias_List();
        }
        [WebMethod]
        public static ArrayList Get_CorreoPersonal_List(string planilla, string area_id, string seccion, string categoria2_Id, int inicio, string nombre)
        {
            return Controller_MantCorreoPersonal.GetInstance().Get_CorreoPersonal_List(planilla, area_id, seccion, categoria2_Id, inicio, nombre);
        }

        [WebMethod]
        public static int Get_CorreoPersonal_List_MaxRows(string planilla, string area_id, string seccion, string categoria2_Id)
        {
            return Controller_MantCorreoPersonal.GetInstance().Get_CorreoPersonal_List_MaxRows(planilla, area_id, seccion, categoria2_Id);
        }
        [WebMethod]
        public static ArrayList Get_CorreoPersonal_Find(string codigo)
        {
            return Controller_MantCorreoPersonal.GetInstance().Get_CorreoPersonal_Find(codigo);
        }
        [WebMethod]
        public static bool Get_CorreoPersonal_Update(string codigo, string correo)
        {
            return Controller_MantCorreoPersonal.GetInstance().Get_CorreoPersonal_Update(codigo, correo);
        }
    }
}