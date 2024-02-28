using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presistence;
using BusienssLogic.CA.oParametros;
using System.Web.Services;

namespace GNProject.Views.ControlAsisten.CA.Matenimientos
{
    public partial class MParametros : System.Web.UI.Page
    {
        [WebMethod]
        public static List<ParametrosControlAsistencia> Get_Parametros_List(int inicio)
        {
            return Controller_MantParametros.GetInstance().Get_Parametros_List(inicio);
        }



        [WebMethod]
        public static bool Get_Parametros_Update(int codigo, string descripcion, string variable, string valor, string tipo, string abrev, string estado)
        {
            return Controller_MantParametros.GetInstance().Get_Parametros_Update(codigo, descripcion, variable, valor, tipo, abrev, estado);
        }


        [WebMethod]
        public static bool Get_Parametros_Add(string descripcion, string variable, string valor, string tipo, string abrev, string estado)
        {
            return Controller_MantParametros.GetInstance().Get_Parametros_Add(descripcion, variable, valor, tipo, abrev, estado);
        }

        [WebMethod]
        public static ParametrosControlAsistencia Get_Parametros_Find(int codigo)
        {
            return Controller_MantParametros.GetInstance().Get_Parametros_Find(codigo);
        }

        [WebMethod]
        public static int Get_Parametros_MaxRegistro()
        {
            return Controller_MantParametros.GetInstance()
                .Get_Parametros_MaxRegistro();
        }

    }
}