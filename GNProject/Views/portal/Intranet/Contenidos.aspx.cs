using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Capas.Portal.Entidad;
using Capas.Portal.Negocio;
using System.Data;
using GNProject.Acceso.App_code_portal;

namespace GNProject.Views.portal.Intranet
{
    public partial class Contenidos : System.Web.UI.Page
    {
        BUSContenidos objNegContenidos = new BUSContenidos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable dt = new DataTable();
                Capas.Portal.Entidad.Contenidos objEContenidos = new Capas.Portal.Entidad.Contenidos();
                if (Request.QueryString["id"] == null) objEContenidos.Contenido_Id = 1; //1 = Quienes Somos
                else objEContenidos.Contenido_Id = Convert.ToInt32(Request.QueryString["id"]);

                if (objEContenidos.Contenido_Id == 1) lblTitle.Text = "Nuestra Empresa";
                else if (objEContenidos.Contenido_Id == 2) lblTitle.Text = "Misión";
                else if (objEContenidos.Contenido_Id == 3) lblTitle.Text = "Visión";
                else if (objEContenidos.Contenido_Id == 6) lblTitle.Text = "Organigrama";
                else if (objEContenidos.Contenido_Id == 7) lblTitle.Text = "Valores";
                else if (objEContenidos.Contenido_Id == 8) lblTitle.Text = "Historia";

                dt = objNegContenidos.ListaContenidosxId(objEContenidos);
                //sale error cuando dt no tiene datos
                lblDescripcion.Text = dt.Rows[0]["Descripcion"].ToString();
                if (dt.Rows[0]["Ruta_Img"].ToString().Trim() == "")
                {
                    imgImg.Visible = false;
                }
                else
                {
                    imgImg.Visible = true;
                }
                imgImg.ImageUrl = Parametros.I_FileServer_RutaContenidos + dt.Rows[0]["Ruta_Img"].ToString();
                dt.Dispose();
            }
        }
    }
}