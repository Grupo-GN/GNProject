using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presistence;
using BusienssLogic.CA.oTurnos;
using System.Web.Services;
using System.Collections;

namespace GNProject.Views.ControlAsisten.CA.Matenimientos
{
    public partial class MTurnos : System.Web.UI.Page
    {
        [WebMethod]
        //public static List<Turnos> Get_Turnos_List(int inicio)
        public static ArrayList Get_Turnos_List(int inicio)
        {
            return Controller_MantTurnos.GetInstance().Get_Turnos_List(inicio);
        }

        [WebMethod]
        public static bool Get_Turnos_Update(int codigo, string nombre, string descripcion, DateTime horaini, DateTime horainirefri, DateTime horafinrefri, DateTime horafin)
        {
            return Controller_MantTurnos.GetInstance().Get_Turnos_Update(codigo, nombre, descripcion, horaini, horainirefri, horafinrefri, horafin);
        }

        [WebMethod]
        public static int Get_Turnos_MaxRegistro()
        {
            return Controller_MantTurnos.GetInstance()
                .Get_Turnos_MaxRegistro();
        }

        [WebMethod]
        public static bool Get_Turnos_Add(string nombre, string descripcion, DateTime horaini, DateTime horainirefri, DateTime horafinrefri, DateTime horafin)
        {
            return Controller_MantTurnos.GetInstance().Get_Turnos_Add(nombre, descripcion, horaini, horainirefri, horafinrefri, horafin);
        }

        [WebMethod]
        public static object Get_Turnos_Find(int codigo)
        {
            return Controller_MantTurnos.GetInstance().Get_Turnos_Find(codigo);
        }
    }
}