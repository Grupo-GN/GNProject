using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusienssLogic.Acceso;
using Presistence;

namespace GNProject.Views.ControlAsisten.CA.Matenimientos
{
    public partial class CambiarClave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["Usuario_Id"] != null)
                {
                    lblemail.Text = controller_AccesoSistema.Get_Instance().GetEmailPersonalCambiarClave(Session["Usuario_Id"].ToString());
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            if (Session["Usuario_Id"] != null)
            {
                if (txtContraseña.Value.Trim() == "") lblError.InnerHtml = ".::Error > Debe ingresar contraseña actual.";
                else if (txtContraseña2.Value.Trim() == "") lblError.InnerHtml = ".::Error > Debe ingresar nueva contraseña.";
                else
                {
                    String Personal_Id = Session["Usuario_Id"].ToString();

                    lblError.InnerHtml = "";
                    Boolean rpta = controller_AccesoSistema.Get_Instance().CambiarClaveUsuario_Save
                        (Personal_Id, txtContraseña.Value, txtContraseña2.Value);
                    if (rpta == false)
                    {
                        lblError.InnerHtml = ".::Error > Contraseña incorrecta.";
                    }
                    else
                    {
                        lblError.InnerHtml = "Contraseña actualizado correctamente.";
                    }
                }
            }
            else
            {
                lblError.InnerHtml = ".::Error > Se perdió la sesión del usuario. Volver a ingresar.";
            }
        }
    }
}