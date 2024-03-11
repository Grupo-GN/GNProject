using BusinessLogic.oLogin;
using System;
using PersistenceI;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.Indicendia01.Login
{
    public partial class Acceso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["loginId"] = "";
        }

        [WebMethod]
        public static Personal Get_Acceso_Sistema(string Usuario, string contraseña)
        {
            Personal perlog = controller_Login.Get_Instance().Get_Acceso_Sistema(Usuario, contraseña);
            if (perlog != null)
            {
                Acceso ac = new Acceso();
                ac.CargarSession(perlog.Personal_Id);
            }
            return perlog;
        }

        public void CargarSession(string PersonalOBJ)
        {

            Session["loginId"] = PersonalOBJ;

        }
    }
}