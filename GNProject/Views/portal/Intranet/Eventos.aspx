<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Eventos.aspx.cs" Inherits="GNProject.Views.portal.Intranet.Eventos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <!---->
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
    
    <!---->
    <link href="/Assets/lightbox_portal/css/lightbox.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="/Assets/lightbox_portal/css/style.css" rel="stylesheet" type="text/css" media="screen" />
    <script src="/Assets/lightbox_portal/js/prototype.js" type="text/javascript"></script>
    <%--<script src="../lightbox/js/prototype.1.7.1.js" type="text/javascript"></script>--%>
    <script src="/Assets/lightbox_portal/js/scriptaculous.js?load=effects,builder" type="text/javascript"></script>
    <script src="/Assets/lightbox_portal/js/lightbox.js" type="text/javascript"></script>
    <!-- <script src="Scripts/swfobject_modified.js" type="text/javascript"></script> -->
    <script type="text/javascript">
        function MM_preloadImages() { //v3.0
            var d = document; if (d.images) {
                if (!d.MM_p) d.MM_p = new Array();
                var i, j = d.MM_p.length, a = MM_preloadImages.arguments; for (i = 0; i < a.length; i++)
                    if (a[i].indexOf("#") != 0) { d.MM_p[j] = new Image; d.MM_p[j++].src = a[i]; }
            }
        }
        function MM_swapImgRestore() { //v3.0
            var i, x, a = document.MM_sr; for (i = 0; a && i < a.length && (x = a[i]) && x.oSrc; i++) x.src = x.oSrc;
        }
        function MM_findObj(n, d) { //v4.01
            var p, i, x; if (!d) d = document; if ((p = n.indexOf("?")) > 0 && parent.frames.length) {
                d = parent.frames[n.substring(p + 1)].document; n = n.substring(0, p);
            }
            if (!(x = d[n]) && d.all) x = d.all[n]; for (i = 0; !x && i < d.forms.length; i++) x = d.forms[i][n];
            for (i = 0; !x && d.layers && i < d.layers.length; i++) x = MM_findObj(n, d.layers[i].document);
            if (!x && d.getElementById) x = d.getElementById(n); return x;
        }

        function MM_swapImage() { //v3.0
            var i, j = 0, x, a = MM_swapImage.arguments; document.MM_sr = new Array; for (i = 0; i < (a.length - 2); i += 3)
                if ((x = MM_findObj(a[i])) != null) { document.MM_sr[j++] = x; if (!x.oSrc) x.oSrc = x.src; x.src = a[i + 2]; }
        }
    </script>
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
                    <asp:HiddenField ID="hdfID" runat="server" />
    <div class="title">
        <label id="lblTitle">
            Lista de Eventos</label></div>
    <br />
    <div id="Tab1">
        <div>
            <table>
                <tr>
                    <td>
                        A continuación se presentan todos los eventos de la empresa.
                        <input type="button" id="btnBuscar" value="Buscar" onclick="fn_GetEventos();"class="EstiloGeneralBoton btn-buscar" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <div id="divEventos">
            </div>
        </div>
    </div>
    <div id="Tab2">
        <p style="text-align: right;">
            <a href="#" onclick='return fn_Volver();'>Volver</a>
        </p>
        <hr />
        <div style="clear: right; width: 100%;">
            <div style="padding-left: 15px; text-align: justify;">
                <div style="float: left;">
                    <label id="lblTituloEvento" style="font-weight: bold;">
                    </label>
                </div>
                <div style="float: right;">
                    Publicado el:
                    <label id="lblFechaEvento">
                    </label>
                </div>
                <div style="clear: left;">
                </div>
                <br />
                <label id="lblDescripcionEvento">
                </label>
                <br />
                <br />
            </div>
            <div id="divEventosDetalle" style="text-align: center;">
                &nbsp;</div>
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
        var no_pagina = "Eventos.aspx";
        this.fn_CargaInicial();
        function fn_CargaInicial() {
            jQuery("#Tab2").hide();
            var id = '<%= Request.QueryString["id"] == null ? "0" : Request.QueryString["id"].ToString() %>';
            document.getElementById("<%= hdfID.ClientID %>").value = id;
            if (id != "0") {
                this.fn_VerDetalle(id);
            }
            else {
                fn_GetEventos();
            }
        }

        function fn_LimpiarFiltros() { }

        function fn_GetEventos() {
            jQuery("#divEventos").html("");
            var parametros = new Array();
            //Variables Acceso a Datos
            var strParametros = "{'strFiltros':" + JSON.stringify(parametros) + "}";
            var strUrlServicio = no_pagina + "/Get_Eventos";
            this.fc_CallService(strParametros, strUrlServicio,
                function (objResponse) {
                    var retorno = objResponse[0];
                    jQuery("#divEventos").html(retorno);
                }
            );
        }
        function fn_Volver() {
            var id = document.getElementById("<%= hdfID.ClientID %>").value = '<%= Request.QueryString["id"] == null ? "0" : Request.QueryString["id"].ToString() %>';
            if (id != "0") {
                history.back(1);
            }
            else {
                jQuery("#Tab1").show();
                jQuery("#Tab2").hide();
                jQuery("#lblTitle").text("Lista de Eventos");

                //llamamos a la funcion para reposicionar pie
                this.fn_reposicionarPie();
            }
            return false;
        }
        function fn_VerDetalle(id) {
            document.getElementById("<%= hdfID.ClientID %>").value = id;
            
            jQuery("#Tab1").hide();
            jQuery("#Tab2").show();
            jQuery("#lblTitle").text("Detalle del Evento");

            //Obtiene detalle
            jQuery("#lblDescripcionEvento").html("");
            jQuery("#lblDescripcionEvento").html("");
            jQuery("#lblFechaEvento").html("");
            jQuery("#divEventosDetalle").html("");
            var strParametros = "{'id':" + id + "}";
            var strUrlServicio = no_pagina + "/Get_EventosDetalle";
            this.fc_CallService(strParametros, strUrlServicio,
                function (objResponse) {
                    jQuery("#lblTituloEvento").text(objResponse[0]);
                    jQuery("#lblDescripcionEvento").text(objResponse[1]);
                    jQuery("#lblFechaEvento").text(objResponse[2]);
                    jQuery("#divEventosDetalle").html(objResponse[3]);
                }
            );

            //llamamos a la funcion para reposicionar pie
            this.fn_reposicionarPie();
        }

        function fc_CallService(e, t, r) { fc_show_progress(!0), jQuery.ajax({ type: "POST", data: e, dataType: "json", url: t, contentType: "application/json; charset=utf-8", async: !0, beforeSend: function () { }, complete: function () { fc_show_progress(!1) }, success: function (e, t) { "success" == t ? r(JSON.parse(e.d)) : alert("ERROR SUCCESS: " + JSON.parse(jsondata.responseText).Message) }, error: function (e, t, r) { alert("Error: (" + e.status + "): " + r) } }) }
        function fc_show_progress(e) { e ? jQuery("#divProgress").show() : jQuery("#divProgress").hide() }

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
