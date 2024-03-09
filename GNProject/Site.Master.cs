using BusinessLogic.oLogin;
using GNProject.Acceso;
using GNProject.Entity.BL;
using GNProject.Entity.Menu;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace GNProject
{
    public partial class Site : MasterPage
    {

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblNomUsuario_MP.Text = ClaseGlobal.Get_nombrecompleto_usuario();
                this.initIncidenciaSession();
                //Int32 id_usuario = ClaseGlobal.Get_IdUsuario_usuario();
                //Int32 retorno; String msg_retorno;
                //SeguridadBL oSeguridadBL = new SeguridadBL();
                //List<MenuBE> lstOpciones = oSeguridadBL.ObtenerOpcionesxUsuario(id_usuario, out retorno, out msg_retorno);
                //acá se valida si tiene acceso a la página, si no se le envía a la página de inicio
            }
        }

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.CargaMenu();
               
            }
        }

        private void CargaMenu()
        {
            Int32 id_perfil = ClaseGlobal.Get_IdPerfil_usuario();
            MenuBL oMenuBL = new MenuBL();
            MenuBEList oMenuBEList = new MenuBEList();

            /*Obteniendo el Menu por Perfil*/
            String fl_con_padres = "1";
            oMenuBEList = oMenuBL.Get_MenuxPerfil(id_perfil, fl_con_padres);
            MenuCtrlDoc.Text = AddMenu(oMenuBEList, 1);
            MenuCtrlAsis.Text = AddMenu(oMenuBEList,2);
            MenuPortal.Text = AddMenu(oMenuBEList, 3);
            MenuPlanillas.Text = AddMenu(oMenuBEList, 4);
            MenuCapacitacion.Text = AddMenu(oMenuBEList, 5);
            MenuIncidencia.Text = AddMenu(oMenuBEList, 6);


        }
        private string AddMenu(MenuBEList oMenuBEList, int id_seccion)
        {
            String html_menu = "<div class=\"sb-sidenav-menu\">"; // Agregar clase para el menú lateral
            // Inicio del contenedor de menú colapsable
            html_menu += "<div class=\"collapse\" id=\"collapsePages6a\" aria-labelledby=\"headingTwo\" data-bs-parent=\"#sidenavAccordion\">";

            foreach (MenuBE ent in oMenuBEList)
            {
                // Verificar si es un elemento padre y pertenece a la sección deseada
                if (ent.id_padre == 0 && ent.id_seccion == id_seccion)
                {
                    // Abrir el contenedor de menú anidado
                    html_menu += $"<nav class=\"sb-sidenav-menu-nested nav accordion\" id=\"sidenavAccordionPages{ent.id_menu}\">";

                    // Inicio del enlace colapsable
                    html_menu += $"<a class=\"nav-link collapsed\" href=\"#\" data-bs-toggle=\"collapse\" data-bs-target=\"#pagesCollapseAuthf4{ent.id_menu}\" aria-expanded=\"false\" aria-controls=\"pagesCollapseAuth{ent.id_menu}\">";
                    html_menu += ent.tx_descripcion;

                    // Flecha indicadora de colapso
                    html_menu += "<div class=\"sb-sidenav-collapse-arrow\"><i class=\"fas fa-angle-down\"></i></div>";
                    html_menu += "</a>";

                    // Contenedor del menú desplegable
                    html_menu += $"<div class=\"collapse\" id=\"pagesCollapseAuthf4{ent.id_menu}\" aria-labelledby=\"headingOne{ent.id_menu}\" data-bs-parent=\"#sidenavAccordionPages{ent.id_menu}\">";

                    // Inicio del menú desplegable
                    html_menu += "<nav class=\"sb-sidenav-menu-nested nav\">";

                    // Generar los elementos del menú filtrando por la sección deseada
                    html_menu = this.AddMenuItem(html_menu, oMenuBEList, ent.id_menu, id_seccion);

                    // Cierre del menú desplegable
                    html_menu += "</nav>";

                    // Cierre del contenedor del menú desplegable
                    html_menu += "</div>";

                    // Cierre del contenedor del menú anidado
                    html_menu += "</nav>";
                }
            }

            // Cierre del contenedor de menú colapsable
            html_menu += "</div>";

            // Asignar el HTML generado al control Literal
            return html_menu;
        }

        private string AddMenuItem(string html_menu, MenuBEList oMenuBEList, int id_menu, int id_seccion)
        {
            foreach (MenuBE ent in oMenuBEList)
            {
                if (ent.id_padre == id_menu && ent.id_seccion == id_seccion)
                {
                    if (oMenuBEList.Any(x => x.id_padre == ent.id_menu && x.id_seccion == id_seccion))
                    {
                        // Si el elemento actual tiene hijos, entonces es un enlace desplegable
                        var subMenuId = "submenu_" + ent.id_menu;
                        html_menu += $"<a class=\"nav-link collapsed\" href=\"#\" data-bs-toggle=\"collapse\" data-bs-target=\"#{subMenuId}\" aria-expanded=\"false\" aria-controls=\"{subMenuId}\">";
                        html_menu += $"{ent.tx_descripcion}<div class=\"sb-sidenav-collapse-arrow\"><i class=\"fas fa-angle-down\"></i></div></a>";

                        // Abrir el contenedor del submenú
                        html_menu += $"<div class=\"collapse\" id=\"{subMenuId}\" aria-labelledby=\"headingOne{ent.id_menu}\" data-bs-parent=\"#sidenavAccordionPages{ent.id_menu}\">";
                        html_menu += "<nav class=\"sb-sidenav-menu-nested nav\">";

                        // Generar los elementos del submenú de manera recursiva
                        html_menu = this.AddMenuItem(html_menu, oMenuBEList, ent.id_menu, id_seccion);

                        // Cerrar el menú anidado
                        html_menu += "</nav>";

                        // Cerrar el contenedor del submenú
                        html_menu += "</div>";
                    }
                    else
                    {
                        // Si el elemento actual no tiene hijos, entonces es un enlace simple
                        html_menu += $"<a class=\"nav-link\" href=\"{ent.url_pagina}\">{ent.tx_descripcion}</a>";
                    }
                }
            }
            return html_menu;
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            FormsAuthentication.SignOut();
            //FormsAuthentication.RedirectToLoginPage();
            Response.Redirect("~/Login.aspx");
        }
        protected void initIncidenciaSession()
        {
            
            string dni;
            string[] arr_Usuario_Perfil = System.Web.HttpContext.Current.User.Identity.Name.Split('|');
            if (arr_Usuario_Perfil.Length > 0)
            {
                dni = arr_Usuario_Perfil[3]; // Asigna el DNI como cadena sin necesidad de convertirlo
                string personal_id = controller_Login.Get_Instance().getPersonalId(dni);
                Session["loginId"] = personal_id;



            }
        }
       
    }
}