using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//
using System.Web.Security;
using Capas.Portal.Entidad;
using Capas.Portal.Negocio;
using System.Web.Services;
using GNProject.Acceso.App_code_portal;
using Microsoft.Reporting.WebForms;
using GNProject.Acceso.App_code_portal.dsResultadoEncuestasTableAdapters;




namespace GNProject.Views.portal.Maestros
{
    public partial class MasterIntranetDefault : System.Web.UI.MasterPage
    {
        //protected void Page_Load(object sender, EventArgs e)
        //{

        //}
        /*Obtiene el Nombre de Página*/
        private String getPageName()
        {
            string[] arrResult = HttpContext.Current.Request.RawUrl.Split('/');
            String result = arrResult[arrResult.GetUpperBound(0)];

            /*Para obtener solo el nombre de la pagina sin la extensión [.aspx]*/
            //arrResult = result.Split('.');
            //result = arrResult[arrResult.GetLowerBound(0)];

            return result;
        }

        public String Get_OpenModalCumpleDia()
        {
            String rpta;
            if (Session["modalCumpleDelDia"] == null)
                rpta = "1";
            else
                rpta = "0";
            Session["modalCumpleDelDia"] = rpta;
            return rpta;
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            /*Validar Acceso*/
            if (String.IsNullOrEmpty(Page.User.Identity.Name) == true)
            {
                Response.Redirect("~/Login.aspx?expired=1");
                return;
            }

            if (!Page.IsPostBack)
            {
            }
            /***************/
            string no_Pagina;
            no_Pagina = this.getPageName();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Context.Request.Browser.Adapters.Clear(); //Para que funcione el Control Menu en Chrome
            if (!Page.IsPostBack)
            {
                this.Inicializa();
            }
        }

        private void Inicializa()
        {
            this.CargaMenu();

            #region "Carga enlaces de interes"
            BUSEnlaces objNegEnlaces = new BUSEnlaces();
            List<Enlace> oLista = new List<Enlace>();
            String User_Id = ClaseGlobal.Get_UserID();
            oLista = objNegEnlaces.GetEnlacesAll(User_Id);

            String html_Enlaces = "<div style=\"text-align:justify;\">";
            foreach (Enlace ent in oLista)
            {
                if (String.IsNullOrEmpty(ent.Direccion) || ent.Direccion == "#")
                {
                    html_Enlaces += String.Format("<p>• {0}</p>", ent.Nom_Enlace);
                }
                else
                {
                    html_Enlaces += String.Format("<p><a href=\"{0}\" target=\"_blank\">• {1}</a></p>", ent.Direccion, ent.Nom_Enlace);
                }
            }
            html_Enlaces += "</div>";
            ltrEnlacesInteres.Text = html_Enlaces;
            #endregion "Carga enlaces de interes"

            String path_Raiz = Server.MapPath("~/");
            String[] arrFiles_Collage = System.IO.Directory.GetFiles(Server.MapPath("~/Assets/images/imgPortal/collage_empresa/"));
            String[] arrFiles_Certificaciones = System.IO.Directory.GetFiles(Server.MapPath("~/Assets/images/imgPortal/certificaciones/"));
            hdfCollages.Value = String.Join(",", arrFiles_Collage).Replace(path_Raiz, "../");
            hdfCertificaciones.Value = String.Join(",", arrFiles_Certificaciones).Replace(path_Raiz, "../");
        }

        private void CargaMenu()
        {
            MenuBEList oMenuBEList = ClaseGlobal.GetMenu();

            foreach (MenuBE ent in oMenuBEList)
            {
                //Indica que son elementos padres
                if (ent.id_padre == 0)
                {
                    MenuItem mnuItem = new MenuItem();
                    mnuItem.Value = ent.id_menu.ToString();
                    mnuItem.Text = ent.tx_descripcion;
                    //mnuItem.ImageUrl = ent.icono;
                    mnuItem.NavigateUrl = ent.url_pagina;

                    //Agrega el ítem al menú
                    mnuPrincipal.Items.Add(mnuItem);

                    //Agregamos sus hijos
                    this.AddMenuItem(mnuItem, oMenuBEList);
                }
            }
        }

        private void AddMenuItem(MenuItem mnuItem, MenuBEList oMenuBEList)
        {
            foreach (MenuBE ent in oMenuBEList)
            {
                if (ent.id_padre.ToString() == mnuItem.Value && ent.id_padre != 0) //Si es hijo del item y no es padre
                {
                    MenuItem mnuNewItem = new MenuItem();
                    mnuNewItem.Value = ent.id_menu.ToString();
                    mnuNewItem.Text = ent.tx_descripcion;
                    //mnuNewItem.ImageUrl = ent.icono;
                    mnuNewItem.NavigateUrl = ent.url_pagina;

                    //Agregamos el nuevo item
                    mnuItem.ChildItems.Add(mnuNewItem);

                    //Llamada recursiva para ver si el menú nuevo tiene hijos
                    this.AddMenuItem(mnuNewItem, oMenuBEList);
                }
            }
        }

        protected void ibtnCerrarSesion_Click(object sender, ImageClickEventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            FormsAuthentication.SignOut();
            //FormsAuthentication.RedirectToLoginPage();
            Response.Redirect("~/Login.aspx");
        }

        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object Get_Bienvenida()
        {
            BUSContenidos objNegContenidos = new BUSContenidos();
            System.Data.DataTable dt = new System.Data.DataTable();
            Contenidos objEContenidos = new Contenidos();
            objEContenidos.Contenido_Id = 4; //4 = Bienvenido
            dt = objNegContenidos.ListaContenidosxId(objEContenidos);
            String msg_bienvenida = dt.Rows[0]["Descripcion"].ToString();
            String ruta_img = dt.Rows[0]["Ruta_Img"].ToString().Trim();
            dt.Dispose();

            object response = new object[] { msg_bienvenida, ruta_img };

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(response);
        }
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object Get_Menu(Int32 id)
        {
            object response = new object();

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(response);
        }

        protected void btnVerBarras_Click(object sender, EventArgs e)
        {
            String Encuesta_Id = hdfEncuesta_Id.Value;

            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reportes/rptResultadoEncuestas.rdlc");

            //se cambio esta parte tenia un using namespace ahora lo hemos quitado
            dtResultadoEncuestasTableAdapter tablaResultadoEncuestas = new dtResultadoEncuestasTableAdapter();
            dsResultadoEncuestas.dtResultadoEncuestasDataTable datosResultadoEncuestas = tablaResultadoEncuestas.GetData(Encuesta_Id);

            List<dsResultadoEncuestas.dtResultadoEncuestasRow> data = datosResultadoEncuestas.ToList();
            data.RemoveAt(data.Count - 1);

            if (ReportViewer1.LocalReport.DataSources.Count > 0) ReportViewer1.LocalReport.DataSources.RemoveAt(0);

            ReportDataSource dataSource = new ReportDataSource("dtResultadoEncuestas", data);
            ReportViewer1.LocalReport.DataSources.Add(dataSource);
            lblCargandoBarras.Text = "";
        }
    }
}