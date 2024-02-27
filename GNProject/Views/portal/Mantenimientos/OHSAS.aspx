<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OHSAS.aspx.cs" Inherits="GNProject.Views.portal.Mantenimientos.OHSAS"UnobtrusiveValidationMode="None" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Import Namespace="GNProject.Acceso.App_code_portal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/Assets/Css/PortalCss/Estilo.css" rel="stylesheet" type="text/css" />
    <link href="/Assets/Css/PortalCss/Menu.css" rel="stylesheet" type="text/css" />
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
    <p style="text-align: center;">
        <asp:Label ID="lblMensaje" Font-Bold="true" runat="server" Text=""></asp:Label>
    </p>
    <asp:HiddenField ID="hdfID" runat="server" />    
    <div class="title">
        Sistema Integrado de Gestión SIG</div>
    <br />
    <div id="Tab1">
        <div>
            <table>
                <tr>
                    <td>
                        Sistema Integrado de Gestión SIG: <select id="cboOHSAS_Busqueda"></select>
                        <input type="button" id="btnBuscar" value="Buscar" onclick="fn_Buscar();" />
                        <input type="button" id="btnNuevo" value="Nuevo" onclick="fn_Nuevo();" />
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
        <div style="clear: right; width: 550px">
            <table style="width: 100%;">
                <tr>
                    <td>
                        Id:
                    </td>
                    <td>
                        <label id="lblID" style="color:#006699; font-weight:bold;"></label>                                
                    </td>
                </tr>
                <tr>
                    <td>
                        Sistema Integrado de Gestión SIG:
                    </td>
                    <td>
                        <select id="cboOHSAS"></select>
                    </td>
                </tr>
                <tr>
                    <td>
                        Titulo:
                    </td>
                    <td>
                        <input id="txtTitulo" type="text" style="width:400px;" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Descripción:
                    </td>
                    <td>
                        <textarea id="txtDescripcion" rows="3" cols="5" style="width:400px;"></textarea>
                    </td>
                </tr>
                <tr>
                    <td>
                        Archivo <span style="color:Red;">(DOC,PPT,PDF)</span>:
                    </td>
                    <td>
                        <asp:FileUpload Width="300px" ID="fuArchivo" runat="server" />
                        <asp:Label ID="lblNomArchivo" runat="server" Text=""></asp:Label>
                        <asp:ImageButton ID="btnEliminarArchivo" runat="server" Width="15px" 
                            ImageUrl="~/img/img_buttons/icono_cerrar.png" OnClientClick="return fn_EliminarArchivo();" />
                    </td>
                </tr>                        
                <tr>
                    <td>Fecha:</td>
                    <td>
                        <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtFecha_CalendarExtender" runat="server" 
                            CssClass="calendar_Theme1" Enabled="True" Format="dd/MM/yyyy" 
                            TargetControlID="txtFecha">
                        </cc1:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=GNProject.Acceso.App_code_portal.Parametros.I_Texto_CategoriaAuxiliar%>:
                    </td>
                    <td>
                        <select id="cboArea"></select>
                    </td>
                </tr>
            </table>
            <hr />
            <p>
                <input id="btnGrabar" type="button" value="Grabar" onclick="fn_Grabar();" />
                <asp:Button ID="btnSubirArchivo" runat="server" OnClick="btnSubirArchivo_Click" style="display:none;" />
                <input id="btnUpdate" type="button" value="Actualizar" onclick="fn_Grabar();" />
            </p>
        </div>
    </div>
    <script type="text/javascript">
        var no_pagina = "OHSAS.aspx";
        /*[INICIO] - Variables Grilla Bandeja*/
        var idGrilla_Bandeja = "#grvBandeja";
        var idPieGrilla_Bandeja = "#grvBandeja_Pie";
        var strCabecera_Bandeja = ['', 'ID', 'OHSAS', 'Titulo', '<%=GNProject.Acceso.App_code_portal.Parametros.I_Texto_CategoriaAuxiliar%>', 'Usuario', 'Fecha', 'ID Ohsas', 'Descripcion', 'Archivo'];
        var ModelCol_Bandeja = [
                            { name: 'Accion', width: 40, align: 'center' },
                            { name: 'id_ohsas_detalle', index: 'id_ohsas_detalle', width: 25, align: 'center' },
                            { name: 'no_ohsas', index: 'no_titulo', width: 100, align: 'left' },
                            { name: 'no_titulo', index: 'no_titulo', width: 250, align: 'left' },
                            { name: 'no_area', index: 'no_area', width: 90, align: 'center' },
                            { name: 'co_usuario', index: 'co_usuario', width: 70, align: 'center' },
                            { name: 'sfe_registro', index: 'sfe_registro', width: 70, align: 'center' },
                            { name: 'id_ohsas', index: 'id_ohsas', width: 1, hidden: true },
                            { name: 'tx_descripcion', index: 'tx_descripcion', width: 1, hidden: true },
                            { name: 'no_archivo', index: 'no_archivo', width: 1, hidden: true }
                            ];
        /*[FIN] - Variables Grilla Bandeja*/
        function fn_dblClickBandeja(rowID) { }

        this.fn_CargaInicial();
        function fn_CargaInicial() {
            $("#Tab2").hide();

            var strFiltros = "{'codigo':'<%=GNProject.Acceso.App_code_portal.Parametros.opcCodMaestroCombo.CATEGORIA_AUXILIAR %>'}";
            var strUrlServicio = "/wsGenerales.asmx/Get_ListaCombo";
            this.fc_CallService(strFiltros, strUrlServicio,
                function (objResponse) {
                    textDefault = "<%=GNProject.Acceso.App_code_portal.Parametros.OBJECTO_SELECCIONE %>";
                    this.fc_CargarCombo("cboArea", objResponse, textDefault);
                }
            );

            strFiltros = "{'codigo':'<%=GNProject.Acceso.App_code_portal.Parametros.opcCodMaestroCombo.OHSAS %>'}";
            strUrlServicio = "/wsGenerales.asmx/Get_ListaCombo";
            this.fc_CallService(strFiltros, strUrlServicio,
                function (objResponse) {
                    var textDefault = "<%=GNProject.Acceso.App_code_portal.Parametros.OBJECTO_TODOS %>";
                    this.fc_CargarCombo("cboOHSAS_Busqueda", objResponse, textDefault);
                    textDefault = "<%=GNProject.Acceso.App_code_portal.Parametros.OBJECTO_SELECCIONE %>";
                    this.fc_CargarCombo("cboOHSAS", objResponse, textDefault);
                }
            );

            fn_Buscar();
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
                arr_parametros[0] = $("cboOHSAS_Busqueda").val();
                var strUrlServicio = no_pagina + "/Get_Bandeja";
                this.fc_GetJQGrid_Ajax(arr_parametros, strUrlServicio, idGrilla_Bandeja, idPieGrilla_Bandeja
                    , strCabecera_Bandeja, ModelCol_Bandeja, function () { }, fn_dblClickBandeja);
            }
        }

        function fn_LimpiarTab2() {
            $("#<%=hdfID.ClientID %>").val("");
            $("#lblID").text("");
            $("#cboOHSAS").val("");
            $("#txtTitulo").val("");
            $("#txtDescripcion").val("");
            $("#<%=lblNomArchivo.ClientID %>").text("");
            $("#<%=fuArchivo.ClientID %>").show();
            $("#<%=btnEliminarArchivo.ClientID %>").hide();
            document.getElementById("<%=fuArchivo.ClientID %>").parentNode.innerHTML = document.getElementById("<%=fuArchivo.ClientID %>").parentNode.innerHTML;
            $("#<%=txtFecha.ClientID %>").val("");
            $("#cboArea").val("");
        }
        function fn_Nuevo() {
            $("#Tab1").hide();
            $("#Tab2").show();
            //se agregó lo siguiente
            //es propio de html por eso de hace asi el id es con minuscula
            $("#btnGrabar").show();
            //ea agregado desde asp el ID es con mayuscula
            $("#btnUpdate").hide();

            this.fn_LimpiarTab2();
            $("#<%=txtFecha.ClientID %>").val("<%= DateTime.Now.ToShortDateString() %>");
        }
        function fn_Volver() {
            $("#Tab1").show();
            $("#Tab2").hide();
            return false;
        }
        function fn_Editar(id) {
            $("#Tab1").hide();
            $("#Tab2").show();
            //se agregó lo siguiente
            $("#btnGrabar").hide();
            $("#btnUpdate").show();
            //Carga datos
            this.fn_LimpiarTab2();
            document.getElementById("<%= hdfID.ClientID %>").value = id;
            var strFiltros = "{'id':" + id + "}";
            var strUrlServicio = no_pagina + "/Get_DatosxID";
            this.fc_CallService(strFiltros, strUrlServicio,
                    function (objResponse) {
                        $("#lblID").text(id);
                        $("#cboOHSAS").val(objResponse.id_ohsas);
                        $("#txtTitulo").val(objResponse.no_titulo);
                        $("#txtDescripcion").val(objResponse.tx_descripcion);
                        if (objResponse.no_archivo != "") {
                            $("#<%=fuArchivo.ClientID %>").hide();
                            $("#<%=btnEliminarArchivo.ClientID %>").show();
                        }
                        else {
                            $("#<%=fuArchivo.ClientID %>").show();
                            $("#<%=btnEliminarArchivo.ClientID %>").hide();
                        }
                        $("#<%=lblNomArchivo.ClientID %>").text(objResponse.no_archivo);
                        $("#<%=txtFecha.ClientID %>").val(objResponse.sfe_registro);
                        $("#cboArea").val(objResponse.id_area);
                    }
                );
        }
        function fn_Eliminar(id) {
            if (confirm('Está seguro de eliminar el registro?')) {
                document.getElementById("<%= hdfID.ClientID %>").value = id;
                //Variables Acceso a Datos
                var strParametros = "{'id':" + id + "}";
                var strUrlServicio = no_pagina + "/Eliminar";
                this.fc_CallService(strParametros, strUrlServicio,
                        function (objResponse) {
                            var retorno = objResponse[0];
                            var msg_retorno = objResponse[1];
                            alert(msg_retorno);
                            if (retorno > 0) {                                
                                fn_Buscar();
                            }
                        }
                    );
            }
        }
        function fn_Grabar() {
            var id_ohsas_detalle = fc_Trim($("#<%=hdfID.ClientID %>").val());
            var id_ohsas = $("#cboOHSAS").val();
            var titulo = fc_Trim($("#txtTitulo").val());
            var descripcion = fc_Trim($("#txtDescripcion").val());
            var no_archivo = fc_Trim($("#<%=lblNomArchivo.ClientID %>").text());
            var fecha = fc_Trim($("#<%=txtFecha.ClientID %>").val());
            var id_area = $("#cboArea").val();
            var msg = "";
            if (id_ohsas == "") { msg += "- Debe seleccionar OHSAS.\n"; }
            if (titulo == "") { msg += "- Debe ingresar titulo.\n"; }
            if (descripcion == "") { msg += "- Debe ingresar descripción.\n"; }
            if (fecha == "") { msg += "- Debe ingresar fecha.\n"; }
            if (fc_Trim(id_area) == "") { msg += "- Debe seleccionar area.\n"; }
            if (msg != "") {
                alert(msg);                
            }//se cambio lo siguiente
            else if ($("#btnGrabar").is(":hidden") ? confirm('¿Está seguro de actualizar el registro?') : confirm('¿Está seguro de guardar el registro?')) {
                var parametros = new Array();
                parametros[0] = id_ohsas_detalle;
                parametros[1] = id_ohsas;
                parametros[2] = titulo;
                parametros[3] = descripcion;
                parametros[4] = id_ohsas_detalle == "" ? "" : no_archivo;
                parametros[5] = fecha;
                parametros[6] = id_area;
                parametros[7] = "<%=ClaseGlobal.Get_UserName(this.Page)%>";
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
                            if (fc_Trim($("#<%=fuArchivo.ClientID %>").val()) != "") {
                                fn_SubirFile(retorno);
                            }
                            else this.fn_Buscar();
                        }
                    }
                );
            }
        }
        function fn_SubirFile(id_ohsas_detalle) {
            $("#<%=hdfID.ClientID %>").val(id_ohsas_detalle);
            document.getElementById("<%=btnSubirArchivo.ClientID %>").click();
        }
        function fn_EliminarArchivo() {
            var id_ohsas_detalle = fc_Trim($("#<%=hdfID.ClientID %>").val());
            var no_archivo = $("#<%=lblNomArchivo.ClientID %>").text();
            var parametros = new Array();
            parametros[0] = id_ohsas_detalle;
            parametros[1] = no_archivo;
            //Variables Acceso a Datos
            var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
            var strUrlServicio = no_pagina + "/EliminarArchivo";
            this.fc_CallService(strParametros, strUrlServicio,
                function (objResponse) {
                    var retorno = objResponse[0];
                    var msg_retorno = objResponse[1];
                    alert(msg_retorno);
                    if (retorno > 0) {
                        $("#<%=fuArchivo.ClientID %>").show();
                        $("#<%=btnEliminarArchivo.ClientID %>").hide();
                        $("#<%=lblNomArchivo.ClientID %>").text("");
                    }
                }
            );
            return false;
        }
    </script>
</asp:Content>
