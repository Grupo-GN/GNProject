<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Encuestas.aspx.cs" Inherits="GNProject.Views.portal.Intranet.Encuestas" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
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
                    <asp:HiddenField ID="hdfID" runat="server" />
    <div class="title">
        <label id="lblTitle">Lista de Encuestas</label></div>
    <br />
    <div id="Tab1">
        <div>
            <table>
                <tr>
                    <td>
                        <input type="button" id="btnBuscar" value="Buscar" onclick="fn_Buscar();"class="EstiloGeneralBoton btn-buscar" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <table id="grvBandeja">
            </table>
            <div id="grvBandeja_Pie">
            </div>
        </div>
    </div>
    <div id="Tab2">
        <p style="text-align: right;">
            <a href="#" onclick='return fn_Volver();'>Volver</a>
        </p>
        <hr />
        <div id="DetalleEncuesta">
            <label id="lblTitulo_Encuesta" style="font-weight:bold;"></label><br />
            <label id="lblVigencia_Encuesta"></label><br /><br />
            <label id="lblDescripcion_Encuesta"></label><br /><br />
            <label id="lblExisteVoto" style="color:Orange;">Usted ya realizó su voto. Gracias por participar en la encuesta.</label>
            <div id="divVotar">
                <input type="hidden" id="hdfSoloUnaOpc" />
                <div id="divOpciones"></div>
                <br />
                <input id="btnVotarEncuesta" type="button" value="Votar" onclick="fn_VotarEncuesta();" />
            </div>
            <div id="divResultadoEncuesta">
                <table style="width:100%;">
                    <tr>
                        <td valign="top">
                            <div id="divResultados">
                            </div>
                        </td>
                        <td valign="top">
                            <asp:UpdatePanel ID="updResultado" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Button ID="btnVerBarras" runat="server" style="display:none;" Text="Mostrar Barras" OnClick="btnVerBarras_Click" />
                                    <asp:Label ID="lblCargandoBarras" runat="server"></asp:Label>
                                    <rsweb:reportviewer id="ReportViewer1" runat="server" font-names="Verdana" font-size="8pt"
                                        height="100%" width="200px" showcredentialprompts="False" showpromptareabutton="False"
                                        showparameterprompts="False" showzoomcontrol="False"
                                        ShowToolBar="false" ShowFindControls="false" ShowRefreshButton="false" ShowPageNavigationControls="false" ShowBackButton="false"
                                        AsyncRendering="False" SizeToReportContent="True">
                                    </rsweb:reportviewer>
                                </ContentTemplate>                    
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
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
        var no_pagina = "Encuestas.aspx";
        /*[INICIO] - Variables Grilla Bandeja*/
        var idGrilla_Bandeja = "#grvBandeja";
        var idPieGrilla_Bandeja = "#grvBandeja_Pie";
        var strCabecera_Bandeja = ['ID Encuesta', 'Titulo', 'Fecha Inicio', 'Fecha Cierre', 'Estado'];
        var ModelCol_Bandeja = [
                            { name: 'Encuesta_Id', index: 'Encuesta_Id', width: 5, align: 'center', hidden: true },
                            { name: 'Titulo', index: 'Titulo', width: 200, align: 'left' },
                            { name: 'sFecha_Inicio', index: 'sFecha_Inicio', width: 80, align: 'center' },
                            { name: 'sFecha_Cierre', index: 'sFecha_Cierre', width: 80, align: 'center' },
                            { name: 'no_estado', index: 'no_estado', width: 50, align: 'center' }
                            ];
        /*[FIN] - Variables Grilla Bandeja*/
        function fn_dblClickBandeja(rowID) {

        }

        this.fn_CargaInicial();
        function fn_CargaInicial() {
            $("#Tab2").hide();
            var id = '<%= Request.QueryString["id"] == null ? "0" : Request.QueryString["id"].ToString() %>';
            document.getElementById("<%= hdfID.ClientID %>").value = id;
            if (id != "0") {
                this.fn_VerDetalle(id);
            }
            else {
                fn_Buscar();
            }
            //var objResponse = [];
            //this.fc_CargaGrilla(idGrilla_Bandeja, idPieGrilla_Bandeja, strCabecera_Bandeja, ModelCol_Bandeja, objResponse, function () { }, fn_dblClickBandeja);
        }

        function fn_LimpiarFiltros() { }

        function fn_Buscar() {
            var msj = '';

            if (msj != '') {
                alert(msj);
            }
            else {
                //Variables Acceso a Datos
                var arr_parametros = new Array();

                var strUrlServicio = no_pagina + "/Get_Bandeja";
                this.fc_GetJQGrid_Ajax(arr_parametros, strUrlServicio, idGrilla_Bandeja, idPieGrilla_Bandeja
                    , strCabecera_Bandeja, ModelCol_Bandeja, function () { }, fn_dblClickBandeja);
            }
        }
        function fn_Volver() {
            var id = document.getElementById("<%= hdfID.ClientID %>").value = '<%= Request.QueryString["id"] == null ? "0" : Request.QueryString["id"].ToString() %>';
            if (id != "0") {
                history.back(1);
            }
            else {
                $("#Tab1").show();
                $("#Tab2").hide();
                $("#lblTitle").text("Lista de Encuestas");
                //llamamos a la funcion para reposicionar pie
                this.fn_reposicionarPie();
            }
            return false;
        }
        function fn_VerDetalle(id) {
            document.getElementById("<%= hdfID.ClientID %>").value = id;
            $("#Tab1").hide();
            $("#Tab2").show();
            $("#lblTitle").text("Detalle de Encuesta");
            $("#DetalleEncuesta").hide();

            //Obtiene datos de la encuesta
            var parametros = new Array();
            parametros[0] = id;
            parametros[1] = '<%=ClaseGlobal.Get_UserName(this.Page) %>';
            var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
            var strUrlServicio = no_pagina + "/Get_EncuestaxID";
            this.fc_CallService(strParametros, strUrlServicio,
                function (objResponse) {
                    $("#DetalleEncuesta").show();
                    $("#<%=hdfID.ClientID %>").val(id);
                    $("#lblTitulo_Encuesta").text(objResponse.no_titulo);
                    $("#lblDescripcion_Encuesta").text(objResponse.tx_descripcion);
                    $("#lblVigencia_Encuesta").text(objResponse.tx_vigencia);
                    $("#divOpciones").html("");
                    $("#divResultados").html("");
                    if (objResponse.fl_cerrado == "1") {
                        $("#divResultadoEncuesta").show();
                        $("#lblExisteVoto").hide();
                        $("#divVotar").hide();
                        var tabla_html = "Resultados de la encuesta:<br /><table cellpading='3px'><tr><th>Opción</th><th>Cantidad Votos</th><th>% Votos</th><tr>";
                        for (var i = 0; i < objResponse.resultados.length; i++) {
                            tabla_html += "<tr><td>" + objResponse.resultados[i].no_opcion + "</td><td style='text-align:center;'>"
                                    + objResponse.resultados[i].nu_votos + "</td><td style='text-align:center;'>"
                                    + objResponse.resultados[i].po_votos + " %</td><tr>";
                        }
                        tabla_html += "</table>"
                        $("#divResultados").append(tabla_html);
                        $("#<%=lblCargandoBarras.ClientID %>").text("Cargando barras...");
                        document.getElementById("<%=btnVerBarras.ClientID %>").click();
                    }
                    else {
                        $("#divResultadoEncuesta").hide();
                        if (objResponse.fl_existe_voto == "1") {
                            $("#lblExisteVoto").show();
                            $("#divVotar").hide();
                        }
                        else {
                            $("#lblExisteVoto").hide();
                            $("#divVotar").show();
                            var nu_opc = objResponse.opciones.length;
                            $("#hdfSoloUnaOpc").val(objResponse.fl_una_opc);
                            if (objResponse.fl_una_opc == "1") {
                                for (var i = 0; i < nu_opc; i++) {
                                    $("#divOpciones").append("<input name='rbOpcLista' type='radio' id='rbOpc" + i
                                    + "' value='" + objResponse.opciones[i].id_opcion + "'><label for=rbOpc" + i + ">"
                                    + objResponse.opciones[i].no_opcion + "</label></input><br />")
                                }
                            }
                            else {
                                for (var i = 0; i < nu_opc; i++) {
                                    $("#divOpciones").append("<input type='checkbox' id='chkOpc" + i
                                    + "' value='" + objResponse.opciones[i].id_opcion + "'><label for=chkOpc" + i + ">"
                                    + objResponse.opciones[i].no_opcion + "</label></input><br />")
                                }
                            }
                        }
                    }
                }
            );
            //llamamos a la funcion para reposicionar pie
            this.fn_reposicionarPie();
        }
        function fn_VotarEncuesta() {
            var opciones = new Array();
            if ($("#hdfSoloUnaOpc").val() == "1") {
                if ($("#divOpciones input[type='radio']:checked").val() == undefined) {
                    alert("- Debe seleccionar una opción.");
                    return;
                }
                opciones[0] = $("#divOpciones input[type='radio']:checked").val();
            }
            else {
                var fl_marco_opc = false;
                $("#divOpciones input[type='checkbox']:checked").each(function () {
                    fl_marco_opc = true;
                    opciones.push($(this).val());
                });
                if (fl_marco_opc == false) {
                    alert("- Debe seleccionar al menos una opción.");
                    return;
                }
            }

            var parametros = new Array();
            parametros[0] = $("#<%=hdfID.ClientID %>").val(); ;
            parametros[1] = '<%=ClaseGlobal.Get_UserName(this.Page) %>';
            parametros[2] = JSON.stringify(opciones);
            var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
            var strUrlServicio = no_pagina + "/GrabarVotoEncuesta";
            this.fc_CallService(strParametros, strUrlServicio,
                function (objResponse) {
                    var retorno = objResponse[0];
                    alert(retorno);
                    fn_Buscar();
                    fn_Volver();
                }
            );
        }

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
