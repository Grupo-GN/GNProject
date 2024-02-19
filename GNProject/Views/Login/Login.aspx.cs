using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.Services;
using GNProject.Acceso;
using static Presistence.Customs.Conexion;
using Presistence;
using GNProject.Entity.Security;

namespace GNProject.Views.Login
{
    public partial class Login : System.Web.UI.Page
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
                txtUsuario1.Focus();

                try
                {
                    this.Inicializa();
                }
                catch (Exception ex)
                {
                    //lblMsj.Text = ex.Message;
                    UtilsScript.fc_DisplayAlert(this, ex.Message);
                }
            }
        }
        private void Inicializa()
        {
        }
        protected void btnIngresar1_Click(object sender, EventArgs e)
        {
            try
            {
                lblError1.InnerHtml = "";
             
                String rucEmpresa = Request.Form["Ruc"].ToString().Trim();
                String usuario = txtUsuario1.Value;
                String clave = txtContraseña1.Value;


                UsuarioBE oUsuarioBE = controller_AccesoSistema.Get_Instance().Get_Acceder_Sistema(usuario, clave, rucEmpresa);
                if (oUsuarioBE == null)
                {
                    lblError1.InnerHtml = ".::Error > Usuario o Contraseña incorrecta.";
                }
                else
                {
                    if (rucEmpresa == "")
                    {
                        Response.Write("<script language='javascript'>alert('INGRESAR RUC');</script>");
                    }
                    else
                    {
                        if (ListDatosEmpresa(Request.Form["Ruc"]).Count() > 0)
                        {
                            String Usuario_Perfil;
                            Usuario_Perfil = String.Format("{0}|{1}|{2}|{3}|{4}|{5}", oUsuarioBE.login.Trim(), oUsuarioBE.nombrecompleto
                                , oUsuarioBE.id_perfil.ToString(), oUsuarioBE.no_perfil, oUsuarioBE.id_usuario.ToString(),rucEmpresa);
                            FormsAuthentication.RedirectFromLoginPage(Usuario_Perfil, false);
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>alert('EL RUC INGRESADO NO CONTIENE DATOS');</script>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblError1.InnerHtml = ".::Error > " + ex.Message;
            }
        }

        [WebMethod]
        public static List<DatosSql> ListaDatos(string ruc)
        {
            return ListData(ruc);
        }

        [WebMethod]
        public static List<Presistence.Customs.Conexion.DatoEmpresa> ListDatosEmpresa(string ruc)
        {
            return ListDatoEmpresa(ruc);
        }



        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'>comprueba();</script>");
        }

        protected void btnsig_Click(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            string ruc = "";
            ruc = Request.Form["Ruc"];
            if (ruc == "")
            {
                Response.Write("<script language='javascript'>alert('INGRESAR RUC');</script>");

            }
            else
            {
                Response.Write("<script language='javascript'>comprueba();</script>");
                ClientScript.RegisterStartupScript(GetType(), "hwa", "comprueba();", true);
            }
        }

    }
}
