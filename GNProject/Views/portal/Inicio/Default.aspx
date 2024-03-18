<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GNProject.Views.portal.Inicio.Default" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/Assets/Css/PortalCss/Estilo.css" rel="stylesheet" type="text/css" />
    <%--<link href="/Assets/Css/PortalCss/Menu.css" rel="stylesheet" type="text/css" />--%>
    <link href="/Assets/Css/PortalCss/JqGrid/ui.jqgrid.css" rel="stylesheet" type="text/css" />
    <link href="/Assets/Css/PortalCss/JqGrid/jquery-ui.css" rel="stylesheet" type="text/css" /> 
    <link href="/Assets/Css/PortalCss/NewStyle.css" rel="stylesheet" type="text/css" />
    <script language="javascript">window.$q = []; window.$ = window.jQuery = function (a) { window.$q.push(a); };</script>
    <script type="text/javascript" src="/Scripts/Portal/Funciones.min.js"></script>
    <script type="text/javascript" src="/Scripts/Portal/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="/Scripts/Portal/jquery-1.11.1-ui.min.js"></script>
    <!--[if IE 7]> <script type="text/javascript" src="../js/jqGrid-4.5.2/jsonIE7.js"></script> <![endif]-->
    <script type="text/javascript" src="/Scripts/Portal/jqGrid-4.5.2/grid.locale-en.min.js"></script>
    <script type="text/javascript" src="/Scripts/Portal/jqGrid-4.5.2/jquery.jqGrid.src.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script language="jscript" type="text/jscript">
        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginReq);
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);
        function beginReq(sender, args) {
            try {
                $('#divProgress').show();
            }
            catch (ex) { alert("beginReq: " + ex); }
        }
        function endReq(sender, args) {
            try {
                $('#divProgress').hide();

                /*Para controlar un error inesperado*/
                if (args.get_error()) {
                    var error = args.get_error();
                    document.getElementById("errorMessageLabel").innerText = error.httpStatusCode + " - " + error.name + ", " + error.message + ", " + error.description;
                    args.set_errorHandled(true);

                    alert(args.get_error().description);

                    if (error.description == undefined && args.get_error().httpStatusCode == '0') {
                        //alert('Authentication expired, redirecting to login page');
                        //location.href = './Login.aspx'; // Whatever your login page is
                        //location.reload();
                    }
                }
            }
            catch (ex) { alert("endReq: " + ex); }
        }

        /*IE10 - Se reemplaza el método existente, pisos de las coordenadas X e Y, esto para no se genere error en los ImageButton*/
        if (navigator.appName.indexOf("Internet Explorer") != -1) {
            var badBrowser = (
                navigator.appVersion.indexOf("MSIE 1") != -1  //v10, 11, 12, etc. is fine too
            );
            if (badBrowser == true) {
                /*Cambia las coordenadas a boton tipo imagen*/
                Sys.WebForms.PageRequestManager.getInstance()._origOnFormActiveElement = Sys.WebForms.PageRequestManager.getInstance()._onFormElementActive;
                Sys.WebForms.PageRequestManager.getInstance()._onFormElementActive = function (element, offsetX, offsetY) {
                    if (element.tagName.toUpperCase() === 'INPUT' && element.type === 'image') {
                        offsetX = Math.floor(offsetX);
                        offsetY = Math.floor(offsetY);
                    }
                    this._origOnFormActiveElement(element, offsetX, offsetY);
                };
            }
        }
    </script>
    <div id="contenerdorInicioPortal" style="width:100%;position:relative">
        <div id="errorMessageLabel" runat="server">
            </div>
            
    <div id="contenedor" >
                <div id="Welcome" style="width:100%;height:200px;">
                    <div id="textWelcome" style="width:100%; text-align:center;top:50px;">
                        
                    </div>
                </div>
                <div id="contenidos" >
                    <table width="100%" border="0px" cellpadding="0px" cellspacing="0px">
                        <tr>
                            <td valign="top" id="columna1">
                                <div class="MenuLeft">
                                    <span class="upperframe"><span></span></span>
                                    <div class="roundframe">
                                        <div style="text-align: center;">
                                            <%--<img id="imgUsuario" alt="" title="" style="border: solid 1px #000;
                                                width: 100px; height: 140px;" src="<%=(Parametros.I_VirtualServer_ImgUsers + ClaseGlobal.Get_RutaFoto(this.Page))%>" />--%>
                                            <img id="imgUsuario" alt="" title="" style="border: solid 1px #000;
                                                width: 100px; height: 140px; margin-top:4px;" src="<%=(GNProject.Acceso.App_code_portal.Parametros.I_FileServer_RutaImgUsers.Replace("~", "..") + GNProject.Acceso.App_code_portal.ClaseGlobal.Get_RutaFoto(this.Page))%>" />
                                            <br />
                                            Bienvenido(a)
                                            <%=GNProject.Acceso.App_code_portal.ClaseGlobal.Get_UserName(this.Page)%>
                                            <br />
                                            <span class="link" style="font-style: italic;" onclick="fn_OpenCambiarPwd();">Cambiar Contraseña</span>
                                        </div>
                                        <br /><br />
                                        <div id="menuv">
                                            <ul>
                                                <%--<li>
                                                    <a href="../Intranet/MiCuenta.aspx">
                                                        Mi Cuenta
                                                    </a></li>--%>
                                                <li>
                                                    <a href="../Intranet/Contenidos.aspx?id=1">
                                                        Nuestra Empresa
                                                    </a></li>
                                                <li>
                                                    <a href="../Intranet/Contenidos.aspx?id=8">
                                                        Historia
                                                    </a></li>
                                                <li>
                                                    <a href="../Intranet/Contenidos.aspx?id=2">
                                                        Misión
                                                    </a></li>
                                                <li>
                                                    <a href="../Intranet/Contenidos.aspx?id=3">
                                                        Visión
                                                    </a></li>
                                                <li>
                                                    <a href="../Intranet/Contenidos.aspx?id=7">
                                                        Valores
                                                    </a></li>
                                                <li>
                                                    <a href="../Intranet/Contenidos.aspx?id=6">
                                                        Organigrama
                                                    </a></li>
                                                <li>
                                                    <a href="../Intranet/Videos.aspx">
                                                        Videos Organizacionales
                                                    </a></li>
                                            </ul>
                                        </div>
                                        <br /><br />
                                        <div>
                                            <p class="title">70 años</p>
                                            <div style="text-align:center;height:150px;">
                                                <asp:HiddenField ID="hdfCollages" runat="server" />
                                                <img id="img_70anios" src="/Assets/images/imgPortal/collage_empresa/70_anios.png" style="max-width:100%; max-height:100%;" />
                                            </div>
                                        </div>
                                        <br />
                                        <div>
                                            <p class="title">Cronograma de Actividades</p>
                                            <div id="divCronogramaMes" style="text-align:justify;"></div>
                                        </div>
                                        <br />
                                        <div>
                                            <p class="title">Enlaces de interés</p>
                                            <asp:Literal ID="ltrEnlacesInteres" runat="server">
                                            </asp:Literal>
                                        </div>
                                        <br />
                                        <div>
                                            <p class="title">Certificaciones</p>
                                            <div style="text-align:center;">
                                                <asp:HiddenField ID="hdfCertificaciones" runat="server" />
                                                <img id="img_iso" src="/Assets/images/imgPortal/certificaciones/9001.png" style="max-width:100%; max-height:100%;" />
                                            </div>
                                        </div>
                                        <%--<div>
                                            <p class="title">Cumpleaños del Día</p>
                                            <div id="divCumpleDelDia"></div>
                                        </div>--%>
                                    </div>
                                    <span class="lowerframe"><span></span></span>
                                </div>
                            </td>
                            <td valign="top" id="columna2">
                                <div class="MenuCenter">
                                    <span class="upperframe"><span></span></span>
                                    <div class="roundframe">
                                        <div>
                                            <p class="title">Bienvenida</p>
                                            <div id="divBienvenida" style="text-align:justify;"></div>
                                        </div>
                                        <div style="text-align: justify; font-size: 11px; font-weight: bold;">
                                            <label id="lblBienvenido">
                                            </label>
                                        </div>
                                        <br />
                                        <div style="text-align:center;">
                                            <img id="imgBienvenido" style="max-height:250px;max-width:100%;" src="" alt="" style="display: none;" />
                                        </div>
                                    </div>
                                    <span class="lowerframe"><span></span></span>
                                </div>
                                <div class="tborder contenido2">
                                    <span class="upperframe"><span></span></span>
                                    <div class="roundframe">
                                        <div>
                                            <p class="title">
                                                5 Últimos Anuncios
                                            </p>
                                            <div id="divUltAnuncios" style="font-size:12px;">
                                            </div>
                                            <p class="title">
                                                Cumpleaños del Mes
                                            </p>
                                            <div id="divCumpleMes">
                                            </div>
                                        </div>
                                    </div>
                                    <span class="lowerframe"><span></span></span>
                                </div>
                                
                            </td>
                            <td valign="top" id="columna3">
                                <div class="MenuRight">
                                    <span class="upperframe"><span></span></span>
                                    <div class="roundframe">
                                        <div>
                                            <p class="title">Cumpleaños del Día</p>
                                            <div id="divCumpleDelDia" style="text-align:justify;"></div>
                                        </div>
                                    </div>
                                    <span class="lowerframe"><span></span></span>

                                    <span class="upperframe"><span></span></span>
                                    <div class="roundframe">
                                        <div>
                                            <p class="title">Encuestas</p>
                                            <div id="divEncuestas" style="text-align:justify;"></div>
                                        </div>
                                    </div>
                                    <span class="lowerframe"><span></span></span>

                                    <span class="upperframe"><span></span></span>
                                    <div class="roundframe">
                                        <div>
                                            <p class="title">Resultado de Encuestas</p>
                                            <div id="divResultadoEncuestas" style="text-align:justify;"></div>
                                        </div>
                                    </div>
                                    <span class="lowerframe"><span></span></span>

                                    <span class="upperframe"><span></span></span>
                                    <div class="roundframe">
                                        <div>
                                            <p class="title">Preguntas Frecuentes</p>
                                            <div id="divPreguntasFrecuentes" style="text-align:justify;"></div>
                                        </div>
                                    </div>
                                    <span class="lowerframe"><span></span></span>
                                </div>
                            </td>
                        </tr>
                    </table>
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
        <%--</div>--%>
        <div id='divProgress'>
            <img alt="...Cargando..." src="/Assets/images/imgPortal/loading.gif" style="position: absolute; left: 50%;
                top: 50%; margin-top: -125px; margin-left: -180px; vertical-align: middle;" />
        </div>
    <div style="position:absolute;top:0;z-index:1000;width:100%;">
            <canvas id="canvas2" width="900" height="500" style="display:none;"></canvas>
        </div>
        <div id="modalCumpleDelDia" title="Cumpleaños del día">
            <div id="divmodalCumpleDelDia" class="textoGeneral" style="text-align: center;width: 450px;">
                <div id="divCumpleDelDia_Modal" style="max-height:400px;">
                </div>
            </div>
        </div>
        <div id="modalEncuesta" title="Encuesta" style="width: 500px;">
            <div id="divmodalEncuesta" class="textoGeneral" style="text-align: center; width:500px;">
                <div id="DetalleEncuesta">
                    <div id="divEncuesta_Modal" style="text-align:left;">
                        <asp:HiddenField ID="hdfEncuesta_Id" runat="server" />
                        <label id="lblTitulo_Encuesta" style="font-weight:bold;"></label><br />
                        <label id="lblVigencia_Encuesta"></label><br /><br />
                        <label id="lblDescripcion_Encuesta"></label><br /><br />
                        <label id="lblExisteVoto" style="color:Orange;">Usted ya realizó su voto. Gracias por participar en la encuesta.</label>
                        <div id="divVotar">
                            <input type="hidden" id="hdfSoloUnaOpc" />
                            <div id="divOpciones"></div>
                            <br />
                            <input id="btnVotarEncuesta" class="EstiloGeneralBoton" type="button" value="Votar" onclick="fn_VotarEncuesta();" />
                        </div>
                        <div id="divResultadoEncuesta">
                            <table style="width:100%;">
                                <tr>
                                    <td valign="top" id="tdSinGrafico">
                                        <div id="divResultados">
                                        </div>
                                        <a class="link" style="cursor:pointer;font-weight:bold;" onclick="javascript:$('#tdGrafico').show();$('#tdSinGrafico').hide();">>> Ver Gráfico</a>
                                    </td>
                                    <td valign="top" id="tdGrafico">
                                        <a class="link" style="cursor:pointer;font-weight:bold;" onclick="javascript:$('#tdGrafico').hide();$('#tdSinGrafico').show();"><< Volver</a>
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
    </div>
    <script type="text/javascript">
        $('#divProgress').css("display", "block");
        $('#divProgress').hide();

        //aplica CSS de JQuery
        $("input[type=button]").button();
        $("input[type=submit]").button();

        CargaInicial();
        function CargaInicial() {
            this.fn_GetCronogramaMes();
            this.fn_GetCumpleDelDia();
            this.fn_GetBienvenida();
            this.fn_GetUltAnuncios();
            this.fn_GetCumpleMes();
            this.fn_GetPreguntasFrecuentes();
            this.fn_GetEncuestasVigentes();
            this.fn_GetEncuestasCerradas();
        }
        function fn_GetCronogramaMes() {
            var parametros = new Array();
            var strParametros = "{}";
            
            var strUrlServicio = '<%= Page.ResolveUrl("~/Views/portal/Inicio/Default.aspx/Get_CronogramaMes") %>';
            this.fc_CallService(strParametros, strUrlServicio,
                function (objResponse) {
                    //$("#divCronogramaMes").text(objResponse[0].replace(/<br\s*[\/]?>/gi, "\n"));
                    $("#divCronogramaMes").html(objResponse[0]);
                }
            );
        }
        function fn_GetCumpleDelDia() {
            var parametros = new Array();
            var strParametros = "{}";
            var strUrlServicio = '<%= Page.ResolveUrl("~/Views/portal/Inicio/Default.aspx/Get_CumpleDelDia") %>';
            this.fc_CallService(strParametros, strUrlServicio,
                function (objResponse) {
                    $("#divCumpleDelDia").html(objResponse[0]);
                    if (objResponse[1] != "") {
                        $("#divCumpleDelDia_Modal").html(objResponse[1]);
                        fn_OpenCumpleDelDia();
                    }
                }
            );
        }
        function fn_GetBienvenida() {
            var parametros = new Array();
            var strParametros = "{}";
            var strUrlServicio = '<%= Page.ResolveUrl("~/Views/portal/Inicio/Default.aspx/Get_Bienvenida") %>';
            this.fc_CallService(strParametros, strUrlServicio,
                function (objResponse) {
                    $("#lblBienvenido").html(objResponse[0]);
                    if (objResponse[1] != "") {
                        $("#imgBienvenido").attr("src", objResponse[1]);
                        $("#imgBienvenido").show();
                    }
                    else {
                        $("#imgBienvenido").hide();
                    }
                }
            );
        }
        function fn_GetUltAnuncios() {
            var parametros = new Array();
            var strParametros = "{}";
            var strUrlServicio = '<%= Page.ResolveUrl("~/Views/portal/Inicio/Default.aspx/Get_UltAnuncios") %>';
            this.fc_CallService(strParametros, strUrlServicio,
                function (objResponse) {
                    $("#divUltAnuncios").html(objResponse[0]);
                }
            );
        }
        function fn_GetCumpleMes() {
            var parametros = new Array();
            var strParametros = "{}";
            var strUrlServicio = '<%= Page.ResolveUrl("~/Views/portal/Inicio/Default.aspx/Get_CumpleMes") %>';
            this.fc_CallService(strParametros, strUrlServicio,
                function (objResponse) {
                    $("#divCumpleMes").html(objResponse[0]);
                }
            );
        }
        function fn_GetEncuestasVigentes() {
            var parametros = new Array();
            var strParametros = "{}";
            var strUrlServicio = '<%= Page.ResolveUrl("~/Views/portal/Inicio/Default.aspx/Get_EncuestasVigentes") %>';
            this.fc_CallService(strParametros, strUrlServicio,
                function (objResponse) {
                    $("#divEncuestas").html(objResponse[0]);
                }
            );
        }
        function fn_GetEncuestasCerradas() {
            var parametros = new Array();
            var strParametros = "{}";
            var strUrlServicio = '<%= Page.ResolveUrl("~/Views/portal/Inicio/Default.aspx/Get_EncuestasCerradas") %>';
            this.fc_CallService(strParametros, strUrlServicio,
                function (objResponse) {
                    $("#divResultadoEncuestas").html(objResponse[0]);
                }
            );
        }
        function fn_GetPreguntasFrecuentes() {
            var parametros = new Array();
            var strParametros = "{}";
            var strUrlServicio = '<%= Page.ResolveUrl("~/Views/portal/Inicio/Default.aspx/Get_PreguntasFrecuentes") %>';
            this.fc_CallService(strParametros, strUrlServicio,
                function (objResponse) {
                    $("#divPreguntasFrecuentes").html(objResponse[0]);
                }
            );
        }

        //Modal Cambiar Password
        this.fc_Modal("modalCambiarPwd", function () { }, true);
        function fn_OpenCambiarPwd() {
            $("#txtPassword_Actual").val("");
            $("#txtPassword").val("");
            $("#txtPasswordConfirm").val("");
            $("#modalCambiarPwd").dialog("open");
        }
        function fn_UpdPwd() {
            var pwd_actual = $("#txtPassword_Actual").val();
            var pwd = $("#txtPassword").val();
            var pwdConfirm = $("#txtPasswordConfirm").val();
            if (fc_Trim(pwd_actual) == "") {
                alert("- Debe ingresar su contraseña.");
                return;
            }
            if (fc_Trim(pwd) == "") {
                alert("- Debe ingresar una contraseña.");
                return;
            }
            if (pwd != pwdConfirm) {
                alert("- Las contraseñas deben ser iguales.");
                return;
            }
            else if (confirm("Está seguro de cambiar su contraseña?")) {
                var parametros = new Array();
                parametros[0] = '<%=GNProject.Acceso.App_code_portal.ClaseGlobal.Get_UserID() %>';
                parametros[1] = pwd_actual;
                parametros[2] = pwd;
                var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
                var strUrlServicio = '<%= Page.ResolveUrl("~/Views/portal/Inicio/Default.aspx/UpdPwdUsu") %>';
                this.fc_CallService(strParametros, strUrlServicio,
                    function (objResponse) {
                        var retorno = objResponse[0];
                        var msg_retorno = objResponse[1];
                        alert(msg_retorno);
                        if (retorno > 0) {
                            $("#modalCambiarPwd").dialog("close");
                        }
                    }
                );
            }
        }

        //Modal Cumple del dia
        this.fc_Modal("modalCumpleDelDia", function () { }, true);
        function fn_OpenCumpleDelDia() {
            var fl_open_modalCumpleDia = "<%= Get_OpenModalCumpleDia() %>";
            if(fl_open_modalCumpleDia == "1"){
                $("#modalCumpleDelDia").dialog("open");
                fnShowEffect_Cumple();
            }
        }

        //Modal Encuesta
        this.fc_Modal("modalEncuesta", function () { }, true);
        function fn_OpenEncuesta(id) {
            this.fc_Modal("modalEncuesta", function () { }, true);
            //////$("#modalEncuesta").dialog("open");
            //////$("#modalEncuesta").parent().appendTo(jQuery("form:first")); //habilita postback del modal

            $("#DetalleEncuesta").hide();

            var parametros = new Array();
            parametros[0] = id;
            parametros[1] = '<%=GNProject.Acceso.App_code_portal.ClaseGlobal.Get_UserName(this.Page) %>';
            var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
            var strUrlServicio = '<%= Page.ResolveUrl("~/Views/portal/Intranet/Encuestas.aspx/Get_EncuestaxID") %>';
            this.fc_CallService(strParametros, strUrlServicio,
                function (objResponse) {
                    $("#modalEncuesta").dialog("open");
                    $("#modalEncuesta").parent().appendTo(jQuery("form:first")); //habilita postback del modal
                    $("#DetalleEncuesta").show();
                    $("#<%=hdfEncuesta_Id.ClientID %>").val(id);
                    $("#lblTitulo_Encuesta").text(objResponse.no_titulo);
                    $("#lblDescripcion_Encuesta").text(objResponse.tx_descripcion);
                    $("#lblVigencia_Encuesta").text(objResponse.tx_vigencia);
                    $("#divOpciones").html("");
                    $("#divResultados").html("");
                    if (objResponse.fl_cerrado == "1") {
                        $("#divResultadoEncuesta").show();

                        $('#tdGrafico').hide(); $('#tdSinGrafico').show();

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
            parametros[0] = $("#<%=hdfEncuesta_Id.ClientID %>").val(); ;
            parametros[1] = '<%=GNProject.Acceso.App_code_portal.ClaseGlobal.Get_UserName(this.Page) %>';
            parametros[2] = JSON.stringify(opciones);
            var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
            var strUrlServicio = '<%= Page.ResolveUrl("~/Views/portal/Intranet/Encuestas.aspx/GrabarVotoEncuesta") %>';
            this.fc_CallService(strParametros, strUrlServicio,
                function (objResponse) {
                    var retorno = objResponse[0];
                    alert(retorno);
                    $("#modalEncuesta").dialog("close");
                }
            );
        }

        //var lista_img_70anios = ["../img/collage_empresa/70_anios.png", "../img/collage_empresa/Veritas.png", "../img/collage_empresa/Central.jpg", "../img/collage_empresa/IMG-20180801-WA0004.jpg", "../img/collage_empresa/IMG_9109 (Copy).jpg", "../img/collage_empresa/IMG_9111 (Copy).jpg", "../img/collage_empresa/IMG_9122 (Copy).jpg", "../img/collage_empresa/IMG_20170424_130942.jpg"];
        //var lista_img_iso = ["../img/certificaciones/9001.png", "../img/certificaciones/14001.png", "../img/certificaciones/18001.png"];
        var lista_img_70anios = $("#<%=hdfCollages.ClientID%>").val().toString().split(',');
        var lista_img_iso = $("#<%=hdfCertificaciones.ClientID%>").val().toString().split(',');
        setInterval(changeImage, 5000);
        var index_img_70anios = 0;
        var index_img_iso = 0;
        function changeImage() {
            $("#img_70anios").attr("src", lista_img_70anios[index_img_70anios]);
            $("#img_iso").attr("src", lista_img_iso[index_img_iso]);
            index_img_70anios++;
            index_img_iso++;
            if (index_img_70anios == lista_img_70anios.length)
                index_img_70anios = 0;
            if (index_img_iso == lista_img_iso.length)
                index_img_iso = 0;
        }

        //para poner el Pie debajo del contenido principal
        var divHeightContenidos = document.getElementById("contenidos").offsetHeight;
        var divPie = document.getElementById("pie");
        divHeightContenidos = parseInt(divHeightContenidos) + 20;
        divPie.style.marginTop = divHeightContenidos + "px";
        
    </script>
</asp:Content>
