using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presistence;
using BusienssLogic.CA.oFeriados;
using System.Web.Services;

namespace GNProject.Views.ControlAsisten.CA.Matenimientos
{
    public partial class MFeriados : System.Web.UI.Page
    {
        [WebMethod]
        public static List<Feriados> Get_Feriados_List(int inicio)
        {
            return Controller_MantFeriados.GetInstance().Get_Feriados_List(inicio);
        }



        [WebMethod]
        public static bool Get_Feriados_Update(int codigo, string nombre, string descripcion, DateTime fecha)
        {
            return Controller_MantFeriados.GetInstance().Get_Feriados_Update(codigo, nombre, descripcion, fecha);
        }

        [WebMethod]
        public static int Get_Feriados_MaxRegistro()
        {
            return Controller_MantFeriados.GetInstance()
                .Get_Feriados_MaxRegistro();
        }

        [WebMethod]
        public static bool Get_Feriados_Add(string nombre, string descripcion, DateTime fecha)
        {
            return Controller_MantFeriados.GetInstance().Get_Feriados_Add(nombre, descripcion, fecha);
        }

        [WebMethod]
        public static Feriados Get_Feriados_Find(int codigo)
        {
            return Controller_MantFeriados.GetInstance().Get_Feriados_Find(codigo);
        }
    }
}