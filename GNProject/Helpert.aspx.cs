using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using GNProject.Acceso;
namespace GNProject
{
    public partial class Helpert : System.Web.UI.Page
    {
        [WebMethod]
        public static UsuarioLog Get_DatosUsuario_Logeo(string Personal_Id)
        {
            return controller_AccesoSistema.Get_Instance().Get_DatosUsuario_Logeo(Personal_Id);
        }
        [WebMethod]
        public static string Get_ValidarDatosUsuario_Logeo(string Personal_Id)
        {
            return controller_AccesoSistema.Get_Instance().Get_ValidarDatosUsuario_Logeo(Personal_Id);
        }
    }
}