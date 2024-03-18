<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MantEncuestas.aspx.cs" Inherits="GNProject.Views.portal.Mantenimientos.MantEncuestas"UnobtrusiveValidationMode="None"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
    <asp:UpdatePanel ID="updBotones" runat="server">
        <ContentTemplate>
            <p style="text-align: center;">
                <asp:Label ID="lblMensaje" Font-Bold="true" runat="server" Text=""></asp:Label>
            </p>
            <asp:ImageButton ID="btnEditar" runat="server" Width="20px" Height="20px" OnClick="btnEditar_Click"
                CssClass="imgEdit" ToolTip="Editar" ImageUrl="~/Assets/images/imgPortal/img_buttons/icono_editar.png"
                Style="display: none;" />
            <asp:ImageButton ID="btnEliminar" runat="server" Width="20px" Height="20px" OnClick="btnEliminar_Click"
                CssClass="imgDelete" ToolTip="Eliminar" ImageUrl="~/Assets/images/imgPortal/img_buttons/icono_cerrar.png"
                Style="display: none;" />
            <asp:HiddenField ID="hdfID" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="title">
        Mantenimiento de Encuestas</div>
    <br />
    <div id="Tab1">
        <div>
            <table>
                <tr>
                    <td>
                        <input type="button" id="btnBuscar" value="Buscar" onclick="fn_Buscar();"class="EstiloGeneralBoton btn-buscar" />
                        <asp:Button ID="btnNuevo" class="EstiloGeneralBoton btn-nuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" OnClientClick="return fn_Nuevo();" />
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
        <div>
            <asp:UpdatePanel ID="updTab2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                Encuesta Id:
                            </td>
                            <td>
                                <asp:Label ID="lblEncuestaId" runat="server" Text="" Font-Bold="True" ForeColor="#006699"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Titulo:
                            </td>
                            <td>
                                <asp:TextBox ID="txtTitulo" Width="400px" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtTitulo"
                                    runat="server" ErrorMessage="*" ValidationGroup="Valida"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Descripcion:
                            </td>
                            <td>
                                <asp:TextBox ID="txtDescripcion" Width="400px" Height="100px" TextMode="MultiLine" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtDescripcion"
                                    runat="server" ErrorMessage="*" ValidationGroup="Valida"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Fecha Inicio:
                            </td>
                            <td>
                                <asp:TextBox ID="txtFechaInicio" runat="server"></asp:TextBox>
                                <cc1:calendarextender id="txtFechaInicio_CalendarExtender" runat="server" cssclass="calendar_Theme1"
                                    enabled="True" format="dd/MM/yyyy" targetcontrolid="txtFechaInicio">
                                </cc1:calendarextender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtFechaInicio"
                                    runat="server" ErrorMessage="*" ValidationGroup="Valida"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Fecha Cierre:
                            </td>
                            <td>
                                <asp:TextBox ID="txtFechaCierre" runat="server"></asp:TextBox>
                                <cc1:calendarextender id="txtFechaCierre_CalendarExtender" runat="server" cssclass="calendar_Theme1"
                                    enabled="True" format="dd/MM/yyyy" targetcontrolid="txtFechaCierre">
                                </cc1:calendarextender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtFechaCierre"
                                    runat="server" ErrorMessage="*" ValidationGroup="Valida"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Solo Una Opción?:
                            </td>
                            <td>
                                <asp:CheckBox ID="ckSoloUnaOpcion" CssClass="ck" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight:bold;">
                                Opciones para la Encuesta:
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Nombre de Opción:
                            </td>
                            <td>
                                <asp:TextBox ID="txtNombreOpcion" runat="server" onkeydown="fc_PressKey(13, 'btnAgregarOpcion');"></asp:TextBox>                                
                                <input id="btnAgregarOpcion" type="button" value="Agregar Opción" onclick="return fn_AddOpcion();"class="EstiloGeneralBoton btn-nuevo" />
                                <input type="button" value="Eliminar Opción" onclick="return fn_QuitarOpcion();"class="EstiloGeneralBoton btn-eliminar" />                                
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table id="tblOpciones">
                                </table>
                                <div id="TblOpciones_Pie"></div>
                            </td>
                        </tr>
                    </table>
                    <hr />
                    <p>                        
                        <asp:Button ID="btnGrabar" class="EstiloGeneralBoton btn-guardar" runat="server" ValidationGroup="Valida" Text="Grabar"
                            OnClientClick="return fn_Grabar();" />
                        <asp:Button ID="btnUpdate" class="EstiloGeneralBoton btn-actualizar" runat="server" ValidationGroup="Valida" Text="Actualizar"
                            OnClientClick="return fn_Grabar();" />
                    </p>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnNuevo" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnEditar" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <script type="text/javascript">
        var no_pagina = "MantEncuestas.aspx";
        /*[INICIO] - Variables Grilla Bandeja*/
        var idGrilla_Bandeja = "#grvBandeja";
        var idPieGrilla_Bandeja = "#grvBandeja_Pie";
        var strCabecera_Bandeja = ['', 'ID Encuesta', 'Titulo', 'Descripción', 'Fecha Inicio', 'Fecha Cierre', 'Usuario'];
        var ModelCol_Bandeja = [
                            { name: 'Accion', width: 40, align: 'center' },
                            { name: 'Encuesta_Id', index: 'Encuesta_Id', width: 60, align: 'center', hidden: true },
                            { name: 'Titulo', index: 'Titulo', width: 300, align: 'left' },
                            { name: 'Descripcion', index: 'Descripcion', width: 250, align: 'left', hidden: true },
                            { name: 'sFecha_Inicio', index: 'sFecha_Inicio', width: 70, align: 'center' },
                            { name: 'sFecha_Cierre', index: 'sFecha_Cierre', width: 70, align: 'center' },
                            { name: 'User_Name', index: 'User_Name', width: 70, align: 'center' }
                            ];
        /*[FIN] - Variables Grilla Bandeja*/
        function fn_dblClickBandeja(rowID) {

        }

        this.fn_CargaInicial();
        function fn_CargaInicial() {
            $("#Tab2").hide();
            fn_Buscar();            
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

        function fn_Nuevo() {
            $("#Tab1").hide();
            $("#Tab2").show();
            return true;
        }
        function fn_Volver() {
            $("#Tab1").show();
            $("#Tab2").hide();
            return false;
        }
        function fn_Editar(id) {
            document.getElementById("<%= hdfID.ClientID %>").value = id;
            $("#Tab1").hide();
            $("#Tab2").show();
            document.getElementById("<%= btnEditar.ClientID %>").click();
        }
        function fn_Eliminar(id) {
            if (confirm('Está seguro de eliminar el registro?')) {
                document.getElementById("<%= hdfID.ClientID %>").value = id;
                document.getElementById("<%= btnEliminar.ClientID %>").click();
            }
        }

        function fn_Grabar() {
            var id_encuesta = fc_Trim($("#<%=lblEncuestaId.ClientID %>").text());
            var titulo = fc_Trim($("#<%=txtTitulo.ClientID %>").val());
            var descripcion = fc_Trim($("#<%=txtDescripcion.ClientID %>").val());
            var fe_inicio = fc_Trim($("#<%=txtFechaInicio.ClientID %>").val());
            var fe_cierre = fc_Trim($("#<%=txtFechaCierre.ClientID %>").val());
            var soloUnaOpcion = $("#<%=ckSoloUnaOpcion.ClientID %>").prop('checked') ? "1" : "0";
            var opciones = this.objDatosOpciones;
            var msg = "";
            if (titulo == "") { msg += "- Debe ingresar titulo.\n"; }
            if (descripcion == "") { msg += "- Debe ingresar descripción.\n"; }
            if (fe_inicio == "") { msg += "- Debe ingresar fecha inicio.\n"; }
            if (fe_cierre == "") { msg += "- Debe ingresar fecha cierre.\n"; }
            if (id_encuesta == "") { if (opciones.length <= 1) { msg += "- Debe agregar más de 1 opción.\n"; } }
            if (msg != "") {
                alert(msg);
                return false;
            }

            if (confirm('¿Está seguro de guardar el registro?')) {
                var parametros = new Array();
                parametros[0] = id_encuesta;
                parametros[1] = titulo;
                parametros[2] = descripcion;
                parametros[3] = soloUnaOpcion;                
                parametros[4] = fe_inicio;
                parametros[5] = fe_cierre;
                parametros[6] = "<%=ClaseGlobal.Get_UserName(this.Page)%>";
                parametros[7] = JSON.stringify(opciones);

                //Variables Acceso a Datos
                var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
                var strUrlServicio = no_pagina + "/Grabar";
                this.fc_CallService(strParametros, strUrlServicio,
                        function (objResponse) {
                            var retorno = objResponse[0];
                            var msg_retorno = objResponse[1];
                            alert(msg_retorno);
                            if (retorno > 0) {
                                this.fn_Volver();
                                this.fn_Buscar();
                            }
                        }
                    );
                }
                return false;
        }

        //Opciones
        var objDatosOpciones = new Array();
        var idGrilla_Opciones = "#tblOpciones";
        var idPieGrilla_Opciones = "#tblOpciones_Pie";
        var strCabecera_Opciones = ['ID Opción', 'Opción'];
        var ModelCol_Opciones = [
                        { name: 'id_opcion', index: 'id_opcion', width: 25 },
                        { name: 'no_opcion', index: 'no_opcion', width: 250 }
                        ];
        function fn_AddOpcion() {
            var id_encuesta = fc_Trim($("#<%=lblEncuestaId.ClientID %>").text());
            var no_opcion = fc_Trim($("#<%=txtNombreOpcion.ClientID %>").val());
            if (no_opcion == "") {
                alert("- Debe ingresar una opción.\n");
                return false;
            }

            if (id_encuesta == "") {
                var id = (objDatosOpciones.length) * -1;
                var objOpcion = { id_opcion: id, no_opcion: no_opcion };
                this.objDatosOpciones.push(objOpcion);
                $(idGrilla_Opciones).jqGrid('addRowData', id, objOpcion);
            }
            else {
                var parametros = new Array();
                parametros[0] = id_encuesta;
                parametros[1] = no_opcion;
                //Variables Acceso a Datos
                var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
                var strUrlServicio = no_pagina + "/AgregarOpcion";
                this.fc_CallService(strParametros, strUrlServicio,
                    function (objResponse) {
                        var retorno = objResponse[0];
                        var msg_retorno = objResponse[1];
                        alert(msg_retorno);
                        if (retorno > 0) {
                            fn_GetOpciones(id_encuesta);
                        }
                    }
                );
            }

            $("#<%=txtNombreOpcion.ClientID %>").val("");
            $("#<%=txtNombreOpcion.ClientID %>").focus();
            return false;
        }
        function fn_QuitarOpcion() {
            var id_encuesta = fc_Trim($("#<%=lblEncuestaId.ClientID %>").text());
            if (id_encuesta == "") {
                var rowId = $(idGrilla_Opciones).jqGrid('getGridParam', 'selrow');
                if (rowId == null) {
                    alert("- Debe seleccionar una opción.\n");
                    return false;
                }
                $(idGrilla_Opciones).jqGrid('delRowData', rowId);
            }
            else {
                var rowId = $(idGrilla_Opciones).jqGrid('getGridParam', 'selrow');
                if (rowId == null) {
                    alert("- Debe seleccionar una opción.\n");
                }
                else if (confirm('¿Está seguro de quitar la opción?')) {
                    var rowData = $(idGrilla_Opciones).jqGrid('getRowData', rowId);
                    var parametros = new Array();
                    parametros[0] = rowData["id_opcion"];
                    //Variables Acceso a Datos
                    var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
                    var strUrlServicio = no_pagina + "/EliminarOpcion";
                    this.fc_CallService(strParametros, strUrlServicio,
                        function (objResponse) {
                            var retorno = objResponse[0];
                            var msg_retorno = objResponse[1];
                            alert(msg_retorno);
                            if (retorno > 0) {
                                $(idGrilla_Opciones).jqGrid('delRowData', rowId);
                            }
                        }
                    );
                }
            }
            return false;
        }
        function fn_GetOpciones(id_encuesta) {
            //carga caracteristicas
            var strFiltros = "{'id_encuesta':'" + id_encuesta + "'}";
            var strUrlServicio = no_pagina + "/Get_OpcionesxEncuesta";
            this.fc_CallService(strFiltros, strUrlServicio,
                function (objResponse) {
                    this.fc_CargaGrilla(this.idGrilla_Opciones, this.idPieGrilla_Opciones, this.strCabecera_Opciones
                        , this.ModelCol_Opciones, objResponse, function () { }, function () { }, false);
                }
            );
        }
        function fn_CargaCabeceraOpciones() {
            //Carga cabecera de opciones
            this.objDatosOpciones = [];
            //Variables Grilla
            this.fc_CargaGrilla(this.idGrilla_Opciones, this.idPieGrilla_Opciones, this.strCabecera_Opciones
                , this.ModelCol_Opciones, this.objDatosOpciones, function () { }, function () { }, false);
        }
    </script>
</asp:Content>
