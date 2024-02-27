using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

using GNProject.Acceso.App_code_portal;
using Capas.Portal.Entidad;

namespace GNProject.Views.portal.Maestros
{
    public partial class MasterIntranet : System.Web.UI.MasterPage
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
        /*Obtiene el Nombre de Página*/
        private String getFolderPageName()
        {
            string[] arrResult = HttpContext.Current.Request.RawUrl.Split('/');

            String folderPagina;
            if (arrResult.Length > 2) folderPagina = arrResult[arrResult.Length - 2] + "/" + arrResult[arrResult.GetUpperBound(0)];
            else folderPagina = arrResult[arrResult.GetUpperBound(0)];


            string[] arrResultParametros = folderPagina.Split('?');
            if (arrResultParametros.Length > 1) //si tiene parametros en la URL
            {
                folderPagina = arrResultParametros[0];
            }

            return folderPagina;
        }

        private String getFolderPageName_ConParametros()
        {
            string[] arrResult = HttpContext.Current.Request.RawUrl.Split('/');

            String folderPagina;
            if (arrResult.Length > 2) folderPagina = arrResult[arrResult.Length - 2] + "/" + arrResult[arrResult.GetUpperBound(0)];
            else folderPagina = arrResult[arrResult.GetUpperBound(0)];
            return folderPagina;
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

            //Arma Menu Vertical de acuerdo a la página
            MenuBEList oMenuList = ClaseGlobal.GetMenu();
            String folderPagina = this.getFolderPageName();
            if (folderPagina.Contains("OHSAS_Detalle.aspx"))
            {
                folderPagina = this.getFolderPageName_ConParametros();
            }

            MenuBE oMenuBE = oMenuBE = oMenuList.Find(men => men.url_pagina.Replace("~/", "") == folderPagina);

            Int32 id_menu_padre = oMenuBE == null ? -1 : oMenuBE.id_padre;
            List<MenuBE> oMenuVertical;
            if (id_menu_padre == -1) oMenuVertical = ClaseGlobal.GetMenuContenidos();
            else oMenuVertical = oMenuList.FindAll(men => men.id_padre == id_menu_padre);
            foreach (MenuBE ent in oMenuVertical)
            {
                MenuItem mnuItem = new MenuItem();
                mnuItem.Value = ent.id_menu.ToString();
                mnuItem.Text = ent.tx_descripcion;
                //mnuItem.ImageUrl = ent.icono;
                mnuItem.NavigateUrl = ent.url_pagina;

                //Agrega el ítem al menú
                mnuVertical.Items.Add(mnuItem);
            }
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
    }
}