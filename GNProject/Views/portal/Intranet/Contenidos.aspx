<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contenidos.aspx.cs" Inherits="GNProject.Views.portal.Intranet.Contenidos" %>

<%@ Import Namespace="GNProject.Acceso.App_code_portal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/Assets/Css/PortalCss/Estilo.css" rel="stylesheet" type="text/css" />
    <link href="/Assets/Css/PortalCss/Menu.css" rel="stylesheet" type="text/css" />
    <link href="/Assets/Css/PortalCss/NewStyle.css" rel="stylesheet" type="text/css" />
    <link href="/Assets/Css/PortalCss/JqGrid/ui.jqgrid.css" rel="stylesheet" type="text/css" />
    <link href="/Assets/Css/PortalCss/JqGrid/jquery-ui.css" rel="stylesheet" type="text/css" />    
    <script language="javascript">window.$q = []; window.$ = window.jQuery = function (a) { window.$q.push(a); };</script>
    <script type="text/javascript" src="/Scripts/Portal/Funciones.min.js"></script>
    <script type="text/javascript" src="/Scripts/Portal/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="/Scripts/Portal/jquery-1.11.1-ui.min.js"></script>
    <!--[if IE 7]> <script type="text/javascript" src="../js/jqGrid-4.5.2/jsonIE7.js"></script> <![endif]-->
    <script type="text/javascript" src="/Scripts/Portal/jqGrid-4.5.2/grid.locale-en.min.js"></script>
    <script type="text/javascript" src="/Scripts/Portal/jqGrid-4.5.2/jquery.jqGrid.src.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="contenerdorInicioPortal" style="width:100%;position:relative">
        <div id="errorMessageLabel" runat="server">
            </div>
        <div id="contenedor" >
                <div id="Welcome" style="width:100%;height:200px;">
                    <div id="textWelcome" style="width:100%; text-align:center;top:50px;">
                        
                    </div>
                </div>
            <div id="contenidos" >
                <div class="roundframe vistaIntranet">
                    
    <br />
    <div class="title">
        <asp:Label ID="lblTitle" runat="server"></asp:Label></div>
    <br />
    <div id="Tab1">
        <div>
            <p style="text-align: justify;">
                <asp:Label ID="lblDescripcion" runat="server" Text=""></asp:Label>
            </p>
            <div style="text-align:center;">
                <asp:Image ID="imgImg" runat="server" style="max-width:100%;" />
            </div>
        </div>
    </div>




                </div>
            </div>
	<div id="pie" style="width:100%">
            <div style="text-align: center; font-size: 10px; padding-top: 0px;">
                © <%=GNProject.Acceso.App_code_portal.Parametros.I_NombreProyecto %> <%=GNProject.Acceso.App_code_portal.Parametros.I_NombreEmpresa %> <%= DateTime.Now.Year.ToString() %>
            </div>
            <div style="text-align:right;padding-right:5px;">
                <a class="linkWeb" href="http://www.gestiondenegociosrs.com.pe" target="_blank">Desarrollado por: Gestión de Negocios S.A.C.</a>
            </div>
        </div>
        </div>
    </div>
    <script type="text/javascript">
        this.fn_reposicionarPie();
        function fn_reposicionarPie() {
            //para poner el Pie debajo del contenido principal
            var divHeightContenidos = document.getElementById("contenidos").offsetHeight;
            var divPie = document.getElementById("pie");
            divHeightContenidos = parseInt(divHeightContenidos) + 20;
            divPie.style.marginTop = divHeightContenidos + "px";
        }
    </script>
</asp:Content>