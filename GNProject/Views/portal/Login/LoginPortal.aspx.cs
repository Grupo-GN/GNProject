using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Security;
using Capas.Portal.Entidad;
using Capas.Portal.Negocio;
using GNProject.Acceso.App_code_portal;

namespace GNProject.Views.portal.Login
{
    public partial class LoginPortal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Boolean fl_expired = false;
                if (Page.Request["expired"] != null)
                {
                    fl_expired = Convert.ToBoolean(Page.Request["expired"]);
                    if (fl_expired)
                    {
                        UtilsScript.fc_DisplayAlert(this, "Su sesión ha expirado, ingrese nuevamente al Sistema.");
                    }
                }
                if (Page.Request["ReturnUrl"] != null)
                {
                    UtilsScript.fc_DisplayAlert(this, "Su sesión ha expirado, ingrese nuevamente al Sistema.");
                }

                /*Limpiar cajas*/
                //txtUsuario.Text ="fpumaylle";
                //txtPassword.Text = "123456";
                txtUsuario.Focus();

                try
                {
                    this.Inicializa();
                }
                catch (Exception ex)
                {
                    lblMsj.Text = ex.Message;
                }
            }
        }

        private void Inicializa()
        {
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                BUSUsuarios objNegUsuarios = new BUSUsuarios();

                Boolean aceptado = false;
                Usuarios objEUsu = new Usuarios();
                objEUsu.User_Name = txtUsuario.Text;
                objEUsu.Password = txtPassword.Text;
                aceptado = objNegUsuarios.ValidaLogin(objEUsu);
                if (aceptado)
                {
                    System.Data.DataTable dtUsuario = new System.Data.DataTable();
                    dtUsuario = objNegUsuarios.ListaUserxUserName(objEUsu);

                    //Actualiza contador de visitas por usuario
                    objNegUsuarios.ActualizaVisitasIntranet(dtUsuario.Rows[0]["User_Id"].ToString());

                    String Usuario_Perfil;
                    Usuario_Perfil = String.Format("{0}|{1}|{2}|{3}|{4}", dtUsuario.Rows[0]["User_Name"].ToString()
                        , dtUsuario.Rows[0]["Nombre_Completo"].ToString()
                        , dtUsuario.Rows[0]["Permiso_Id"].ToString()
                        , dtUsuario.Rows[0]["Ruta_Foto"].ToString()
                        , dtUsuario.Rows[0]["User_Id"].ToString());
                    Session["datosPortales"] = Usuario_Perfil;
                    AuxAccesoLogin.UserData = (string)Session["datosPortales"];
                    Label1.Text=(string)Session["datosPortales"];
                    //FormsAuthentication.RedirectFromLoginPage(Usuario_Perfil, false);
                    Response.Redirect("/Views/portal/Inicio/Default.aspx");
                }
                else
                {
                    txtPassword.Focus();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "<script>alert('La clave es incorrecta.');</script>", false);
                    
                    return;
                }
            }
            catch (Exception ex)
            {
                txtUsuario.Focus();
                lblMsj.Text = ex.Message;
            }
        }
    }
}