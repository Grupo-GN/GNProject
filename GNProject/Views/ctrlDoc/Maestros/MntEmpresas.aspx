<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="MntEmpresas.aspx.cs" Inherits="GNProject.Views.ctrlDoc.Maestros.MntEmpresas" %>

<%@ Import Namespace="GNProject.Acceso" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="pagina1">
        <div class="row linea-bottom">
            <div class="col l4 s12 titulo">Lista de Empresas</div>
            <div class="col l8 s12" style="text-align: right;">
                <button id="btnBuscar" type="button" onclick="fn_Buscar();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/Busqueda-48.png" />Buscar</button>
                <button type="button" onclick="fn_Limpiar();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/Escoba-48.png" />Limpiar</button>
                <button type="button" onclick="fn_Nuevo();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/AñadirLista-48.png" />Nuevo</button>
                <button type="button" onclick="fn_Editar();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/Editar-48.png" />Editar</button>
                <button type="button" onclick="fn_Eliminar();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/Cancelar-48.png" />Eliminar</button>
            </div>
        </div>
        <div class="row titulo_section">
            Filtros de búsqueda
        </div>
        <div class="row">
            <div class="col l1 m2 s4">
                <label>Tipo Empresa</label>
            </div>
            <div class="col l3 m4 s8">
                <select id="cboTipoEmpresa_Bus" class="control-form"></select>
            </div>
            <div class="col l1 m2 s4">
                <label>Nro. RUC</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtRUC_Bus" type="text" class="control-form ruc" />
            </div>
            <div class="col l1 m2 s4">
                <label>Razón Social</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtRazonSocial_Bus" type="text" class="control-form" />
            </div>
        </div>
        <div class="row">
            <div class="col l1 m2 s4">
                <label>Estado</label>
            </div>
            <div class="col l3 m4 s8">
                <select id="cboEstado_Bus" class="control-form">
                    <option value="">
                        <%=Parametros.OBJECTO_TODOS%></option>
                    <option value="1" selected="selected">
                        <%=Parametros.OBJECTO_ACTIVO %></option>
                    <option value="0">
                        <%=Parametros.OBJECTO_INACTIVO %></option>
                </select>
            </div>
        </div>
        <div class="row titulo_section">
            Resultados
        </div>
        <div class="row" style="padding-right: 10px;">
            <table id="grvBandeja">
            </table>
            <div id="grvBandeja_Pie">
            </div>
        </div>
    </div>
    <div id="pagina2" style="display: none;">
        <div class="row linea-bottom">
            <div class="col l4 s12 titulo">
                <span id="lblTituloTab2">Nueva</span>
                Empresa
            </div>
            <div class="col l8 s12" style="text-align: right;">
                <button type="button" onclick="fn_Guardar();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/Guardar-48.png" />Guardar</button>
                <button type="button" onclick="fn_Volver();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/Volver-48.png" />Volver</button>
            </div>
        </div>
        <div class="row titulo_section">
            Información General
        </div>
        <div class="row" style="display:none;">
            <div class="col l1 m2 s4">
                <label>ID</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtID" type="text" class="control-form" disabled="disabled" />
            </div>
        </div>
        <div class="row">
            <div class="col l1 m2 s4">
                <label>Nro. RUC</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtRUC" type="text" maxlength="11" class="control-form ruc" />
            </div>
            <div class="col l1 m2 s4">
                <label>Razón Social</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtRazonSocial" type="text" class="control-form" />
            </div>
        </div>
        <div class="row">
            <div class="col l1 m2 s4">
                <label>Detalle</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtDetalle" type="text" class="control-form" />
            </div>
            <div class="col l1 m2 s4">
                <label>Tipo Empresa</label>
            </div>
            <div class="col l3 m4 s8">
                <select id="cboTipoEmpresa" class="control-form"></select>
            </div>
            <div class="col l1 m2 s4">
                <label>Estado</label>
            </div>
            <div class="col l3 m4 s8">
                <select id="cboEstado" class="control-form">
                    <option value="" selected="selected">
                        <%=Parametros.OBJECTO_SELECCIONE%></option>
                    <option value="1">
                        <%=Parametros.OBJECTO_ACTIVO %></option>
                    <option value="0">
                        <%=Parametros.OBJECTO_INACTIVO %></option>
                </select>
            </div>
        </div>
        <div class="row titulo_section">
            Datos de Contacto
        </div>
        <div class="row">
            <div class="col l1 m2 s4">
                <label>Contacto</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtContacto" type="text" class="control-form" />
            </div>
            <div class="col l1 m2 s4">
                <label>Teléfono</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtTelefono" type="text" maxlength="15" class="control-form telefono" />
            </div>
            <div class="col l1 m2 s4">
                <label>Celular</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtCelular" type="text" maxlength="15" class="control-form celular" />
            </div>
        </div>
        <div class="row">
            <div class="col l1 m2 s4">
                <label>Email</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtCorreo" type="text" class="control-form" />
            </div>
        </div>
    </div>

    <script type="text/javascript">
        //#region - Variables Grilla Bandeja
        var idGrilla_Bandeja = "#grvBandeja";
        var idPieGrilla_Bandeja = "#grvBandeja_Pie";
        var strCabecera_Bandeja = ['ID', 'Nro. RUC', 'Razón Social', 'Tipo Empresa', 'Contacto', 'Teléfono', 'Nro. Celular', 'Email', 'Estado', 'Detalle', 'Cod. Estado', 'Cod. Tipo Empresa'];
        var ModelCol_Bandeja = [
                            { name: 'id_empresa', index: 'id_empresa', width: 40, sorttype: 'number', sortable: true, align: 'center', hidden: true },
                            { name: 'nu_ruc', index: 'nu_ruc', width: 90, sortable: true, align: 'center' },
                            { name: 'no_razon_social', index: 'no_razon_social', width: 200, sortable: true },
                            { name: 'no_tipo_empresa', index: 'no_tipo_empresa', width: 100, sortable: true, align: 'center' },
                            { name: 'no_contacto', index: 'no_contacto', width: 150, sortable: true },
                            { name: 'nu_telefono', index: 'nu_telefono', width: 85, sortable: true, align: 'center' },
                            { name: 'nu_celular', index: 'nu_celular', width: 95, sortable: true, align: 'center' },
                            { name: 'no_correo', index: 'no_correo', width: 150, sortable: true },
                            { name: 'no_estado', index: 'no_estado', width: 70, sortable: true, align: 'center' },
                            { name: 'de_empresa', index: 'de_empresa', hidden: true },
                            { name: 'fl_activo', index: 'fl_activo', hidden: true },
                            { name: 'co_tipo_empresa', index: 'co_tipo_empresa', hidden: true }
        ];
        //#endregion - Variables Grilla Bandeja

        fn_Iniciar();
        function fn_Iniciar() {
            $("#cboTipoEmpresa_Bus").keydown(function (event) {
                fc_PressKey(13, 'btnBuscar');
            });
            $("#txtRUC_Bus").keydown(function (event) {
                fc_PressKey(13, 'btnBuscar');
            });
            $("#txtRazonSocial_Bus").keydown(function (event) {
                fc_PressKey(13, 'btnBuscar');
            });
            $("#cboEstado_Bus").keydown(function (event) {
                fc_PressKey(13, 'btnBuscar');
            });

            this.fc_FormatNumeros("txtRUC_Bus");
            this.fc_FormatNumeros("txtRUC");

            var parametros = "{'codigo':'<%=Parametros.Combo.CDOC_TipoEmpresas%>'"
                + ",'co_padre': ''}";
            var urlService = "/wsGenerales.asmx/getCombo";
            this.fc_CallService(parametros, urlService, function (objResponse) {
                textDefault = "<%=Parametros.OBJECTO_SELECCIONE %>";
                this.fc_FillCombo("cboTipoEmpresa_Bus", objResponse, textTodos);
                this.fc_FillCombo("cboTipoEmpresa", objResponse, textDefault);
            });

            var objResponse = [];
            JQGrid_Util.AutoWidthResponsive(idGrilla_Bandeja);
            JQGrid_Util.GetTabla_Local(idGrilla_Bandeja, idPieGrilla_Bandeja, strCabecera_Bandeja, ModelCol_Bandeja, JQGrid_Opciones_Default, objResponse, function () { }, function () { }, function () { });
        }

        function fn_Limpiar() {
            $("#cboTipoEmpresa_Bus").val("");
            $("#txtRUC_Bus").val("");
            $("#txtRazonSocial_Bus").val("");
            $("#cboEstado_Bus").val("1");
            JQGrid_Util.clearData(idGrilla_Bandeja);
        }
        function fn_Buscar() {
            var arr_parametros = new Array();
            arr_parametros[0] = $("#cboTipoEmpresa_Bus").val();
            arr_parametros[1] = $("#txtRUC_Bus").val();
            arr_parametros[2] = $("#txtRazonSocial_Bus").val();
            arr_parametros[3] = $("#cboEstado_Bus").val();
            var urlService = page + "/getBandeja";
            JQGrid_Util.GetTabla_Ajax(arr_parametros, urlService, idGrilla_Bandeja, idPieGrilla_Bandeja
                , strCabecera_Bandeja, ModelCol_Bandeja, JQGrid_Opciones_Default
                , function () { }, fn_dblClickBandeja, function () { });
        }
        function fn_dblClickBandeja(rowID) {
            fn_Editar(rowID);
        }
        function fn_Editar(rowID) {
            var rowData;
            if (rowID == undefined) {
                rowID = $("#grvBandeja").jqGrid('getGridParam', 'selrow');
                if (rowID == null) {
                    alert("- Debe seleccionar un registro.\n");
                    return;
                }
                rowData = JQGrid_Util.getRowData(idGrilla_Bandeja, rowID);
            }
            else {
                rowData = JQGrid_Util.getRowData(idGrilla_Bandeja, rowID);
            }

            //Cambia de TAB
            document.getElementById("pagina1").style.display = 'none';
            $("#pagina2").fadeIn();
            document.getElementById("lblTituloTab2").innerHTML = "Detalle de ";

            this.fn_Limpiar_Editar();

            var cboEstado = document.getElementById("cboEstado");
            cboEstado.disabled = false;

            /*Establece valores*/
            document.getElementById("txtID").value = rowData["id_empresa"];
            document.getElementById("txtRUC").value = rowData["nu_ruc"];
            document.getElementById("txtRazonSocial").value = rowData["no_razon_social"];
            document.getElementById("txtDetalle").value = rowData["de_empresa"];
            document.getElementById("txtContacto").value = rowData["no_contacto"];
            document.getElementById("txtTelefono").value = rowData["nu_telefono"];
            document.getElementById("txtCelular").value = rowData["nu_celular"];
            document.getElementById("txtCorreo").value = rowData["no_correo"];
            document.getElementById("cboTipoEmpresa").value = rowData["co_tipo_empresa"];
            document.getElementById("cboEstado").value = rowData["fl_activo"];
            document.getElementById("txtRUC").focus();
        }
        function fn_Eliminar() {
            var rowId = $("#grvBandeja").jqGrid('getGridParam', 'selrow');
            if (rowId == null) {
                alert("- Debe seleccionar un registro.\n");
                return;
            }

            var msg_retorno = "";
            var rowData = jQuery("#grvBandeja").getRowData(rowId);
            var id_empresa = rowData["id_empresa"];
            var fl_activo = rowData["fl_activo"];
            if (fl_activo == "0") {
                msg_retorno += "- El registro ya se encuentra inactivo.\n";
            }

            if (msg_retorno != "") {
                alert(msg_retorno);
            }
            else if (confirm("¿Está seguro de inactivar el registro?")) {
                var arr_parametros = new Array();
                arr_parametros[0] = id_empresa;
                var parametros = "{'strParametros':" + JSON.stringify(arr_parametros) + "}";
                var urlService = page + "/Eliminar";
                this.fc_CallService(parametros, urlService, function (objResponse) {
                    if (objResponse[0] > 0) {
                        this.fn_Buscar();
                    }
                    alert(objResponse[1]);
                });
            }
        }

        function fn_Nuevo() {
            var rowId = $("#grvBandeja").jqGrid('getGridParam', 'selrow');
            if (rowId != null) { $("#grvBandeja").resetSelection(); }

            //Cambia de TAB
            document.getElementById("pagina1").style.display = 'none';
            $("#pagina2").fadeIn();
            document.getElementById("lblTituloTab2").innerHTML = "Nueva ";

            this.fn_Limpiar_Editar();

            var cboEstado = document.getElementById("cboEstado");
            cboEstado.value = "1";
            cboEstado.disabled = true;

            document.getElementById("txtRUC").focus();
        }

        function fn_Limpiar_Editar() {
            document.getElementById("txtID").value = "";
            document.getElementById("txtRUC").value = "";
            document.getElementById("txtRazonSocial").value = "";
            document.getElementById("txtDetalle").value = "";
            document.getElementById("txtContacto").value = "";
            document.getElementById("txtTelefono").value = "";
            document.getElementById("txtCelular").value = "";
            document.getElementById("txtCorreo").value = "";
            document.getElementById("cboTipoEmpresa").value = "";
            document.getElementById("cboEstado").value = "";
        }

        function fn_Guardar() {
            var msg_retorno = "";
            if (fc_Trim($("#txtRUC").val()) == "") {
                msg_retorno += "- Debe ingresar número de RUC.\n";
            }
            else if ($("#txtRUC").val().length < 8) {
                msg_retorno += "- El número de RUC debe tener 11 digitos.\n";
            }

            if (fc_Trim($("#txtRazonSocial").val()) == "") {
                msg_retorno += "- Debe ingresar razón social.\n";
            }
            if (fc_Trim($("#txtCorreo").val()) != "") {
                if (!this.fc_ValidarEmail($("#txtCorreo").val())) {
                    msg_retorno += "- Correo inválido.\n";
                }
            }
            if ($("#cboTipoEmpresa").val() == "") {
                msg_retorno += "- Debe seleccionar tipo empresa.\n";
            }
            if ($("#cboEstado").val() == "") {
                msg_retorno += "- Debe seleccionar estado.\n";
            }

            if (msg_retorno != "") {
                alert(msg_retorno);
            }
            else if (confirm('¿Está seguro de guardar el registro?')) {
                var id_empresa = $("#txtID").val();
                var arr_parametros = new Array();
                arr_parametros[0] = id_empresa;
                arr_parametros[1] = $("#txtRUC").val();
                arr_parametros[2] = $("#txtRazonSocial").val();
                arr_parametros[3] = $("#txtDetalle").val();
                arr_parametros[4] = $("#txtContacto").val();
                arr_parametros[5] = $("#txtTelefono").val();
                arr_parametros[6] = $("#txtCelular").val();
                arr_parametros[7] = $("#txtCorreo").val();
                arr_parametros[8] = $("#cboTipoEmpresa").val()
                arr_parametros[9] = $("#cboEstado").val();
                var parametros = "{'strParametros':" + JSON.stringify(arr_parametros) + "}";
                var urlService = page + "/Guardar";
                this.fc_CallService(parametros, urlService, function (objResponse) {
                    if (objResponse[0] > 0) {
                        this.fn_Volver();
                        this.fn_Buscar();
                    }
                    alert(objResponse[1]);
                });
            }
        }

        function fn_Volver() {
            $("#pagina1").fadeIn();
            document.getElementById("pagina2").style.display = 'none';
        }
    </script>
</asp:Content>

