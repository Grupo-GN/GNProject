<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="MntParametros.aspx.cs" Inherits="GNProject.Views.ctrlDoc.Maestros.MntParametros" %>

<%@ Import Namespace="GNProject.Acceso" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="pagina1">
        <div class="row linea-bottom">
            <div class="col l4 s12 titulo">Lista de Parámetros del Sistema</div>
            <div class="col l8 s12" style="text-align: right;">
                <button id="btnBuscar" type="button" onclick="fn_Buscar();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/Busqueda-48.png" />Buscar</button>
                <button type="button" onclick="fn_Limpiar();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/Escoba-48.png" />Limpiar</button>
                <button type="button" onclick="fn_Editar();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/Editar-48.png" />Editar</button>
            </div>
        </div>
        <div class="row titulo_section">
            Filtros de búsqueda
        </div>
        <div class="row">
            <div class="col l1 m2 s4">
                <label>Tabla</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtTabla_Bus" type="text" class="control-form" />
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
                <span id="lblTituloTab2">Nuevo</span>
                Parámetro del Sistema
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
                <label>Tabla</label>
            </div>
            <div class="col l6 m10 s8">
                <input id="txtTabla" type="text" class="control-form" disabled="disabled" />
            </div>
        </div>
        <div class="row">
            <div class="col l1 m2 s4">
                <label>Es Tabla?</label>
            </div>
            <div class="col l6 m10 s8">
                <input id="txtEsTabla" type="text" class="control-form" style="max-width: 50px;" disabled="disabled" />
            </div>
        </div>
        <div class="row">
            <div class="col l1 m2 s4">
                <label>Descripción</label>
            </div>
            <div class="col l6 m10 s8">
                <textarea id="txtDescripcion" rows="3" class="control-form"></textarea>
            </div>
        </div>
        <div class="row">
            <div class="col l4 s12 titulo_section">
                Detalle
            </div>
            <div class="col l8 s12" style="text-align: right;">
                <button id="btnNuevoDetalle" type="button" onclick="fn_NuevoParametroDetalle();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/AñadirLista-48.png" />Agregar</button>
            </div>
        </div>
        <div class="row" style="padding-right: 10px;">
            <table id="grvBandejaDetalle">
            </table>
            <div id="grvBandejaDetalle_Pie">
            </div>
        </div>
    </div>
    <div id="modalDetalle" title="Editar detalle">
        <div id="divmodalDetalle_General">
            <input id="txtIDParametroDetalle" rol="modal1" type="hidden" />
            <div class="row">
                <div class="col l4 s4">
                    <label>Descripción</label>
                </div>
                <div class="col l8 s8">
                    <input id="txtValor2" rol="modal1" type="text" class="control-form" />
                </div>
            </div>
            <div class="row">
                <div class="col l4 s4">
                    <label>Valor / Código interno</label>
                </div>
                <div class="col l8 s8">
                    <input id="txtValor3" rol="modal1" type="text" class="control-form" />
                </div>
            </div>
            <div class="row">
                <div class="col l4 s4">
                    <label id="lblTexto_Valor4">Valor Aux.</label>
                </div>
                <div class="col l8 s8">
                    <input id="txtValor4" rol="modal1" type="text" class="control-form" />
                    <select id="cboValor4" rol="modal1" class="control-form">
                        <option value="" selected="selected">
                            <%=Parametros.OBJECTO_SELECCIONE%></option>
                        <option value="1">CONDUCTOR</option>
                        <option value="2">AYUDANTE</option>
                    </select>
                    <input id="chkValor4" type="checkbox" />
                </div>
            </div>
            <div class="row">
                <div class="col l4 s4">
                    <label>Valor 5</label>
                </div>
                <div class="col l8 s8">
                    <input id="txtValor5" rol="modal1" type="text" class="control-form" />
                    <select id="cboTipoDatos" rol="modal1" class="control-form"></select>
                </div>
            </div>
            <div class="row">
                <div class="col l4 s4">
                    <label>Estado</label>
                </div>
                <div class="col l8 s8">
                    <select id="cboEstadoDetalle" class="control-form">
                        <option value="" selected="selected">
                            <%=Parametros.OBJECTO_SELECCIONE%></option>
                        <option value="1">
                            <%=Parametros.OBJECTO_ACTIVO %></option>
                        <option value="0">
                            <%=Parametros.OBJECTO_INACTIVO %></option>
                    </select>
                </div>
            </div>
        </div>
        <div style="text-align: center;">
            <button id="GrabarDetalle" type="button" onclick="fn_GrabarDetalle();">Grabar Detalle</button>
        </div>
    </div>
    <script type="text/javascript">
        //#region - Variables Grilla Bandeja
        var idGrilla_Bandeja = "#grvBandeja";
        var idPieGrilla_Bandeja = "#grvBandeja_Pie";
        var strCabecera_Bandeja = ['ID', 'Tabla', 'Descripción', 'Es Tabla'];
        var ModelCol_Bandeja = [
                            { name: 'id_parametro', index: 'id_parametro', width: 40, sorttype: 'number', sortable: true, align: 'center', hidden: true },
                            { name: 'no_tabla', index: 'no_tabla', width: 250, sortable: true },
                            { name: 'de_tabla', index: 'de_tabla', width: 300, sortable: true },
                            { name: 'fl_tabla', index: 'fl_tabla', width: 100, sortable: true, align: 'center' }
        ];
        //#endregion - Variables Grilla Bandeja
        //#region - Variables Grilla Bandeja Detalle
        var idGrilla_BandejaDetalle = "#grvBandejaDetalle";
        var idPieGrilla_BandejaDetalle = "#grvBandejaDetalle_Pie";
        var strCabecera_BandejaDetalle = ['ID', 'Código Parámetro', 'Descripción', 'Valor / Código interno', 'Valor Aux.', 'Valor5', 'CodEstado', 'Estado'];
        var ModelCol_BandejaDetalle = [
                            { name: 'id_parametro_detalle', index: 'id_parametro_detalle', hidden: true },
                            { name: 'no_valor1', index: 'no_valor1', width: 130, sortable: true, align: 'center' },
                            { name: 'no_valor2', index: 'no_valor2', width: 200, sortable: true },
                            { name: 'no_valor3', index: 'no_valor3', width: 200, sortable: true },
                            { name: 'no_valor4', index: 'no_valor4', width: 150, sortable: true },
                            { name: 'no_valor5', index: 'no_valor5', width: 150, sortable: true },
                            { name: 'fl_activo', index: 'fl_activo', hidden: true },
                            { name: 'no_estado', index: 'no_estado', width: 70, sortable: true, align: 'center' }
        ];
        //#endregion - Variables Grilla Bandeja Detalle

        fn_Iniciar();
        function fn_Iniciar() {
            $("#txtTabla_Bus").keydown(function (event) {
                fc_PressKey(13, 'btnBuscar');
            });

            var parametros = "{'codigo':'<%=Parametros.Combo.CDOC_TipoDatos %>'"
                + ",'co_padre': ''}";
            var urlService = "/wsGenerales.asmx/getCombo";
            this.fc_CallService(parametros, urlService, function (objResponse) {
                textDefault = "<%=Parametros.OBJECTO_SELECCIONE %>";
                this.fc_FillCombo("cboTipoDatos", objResponse, textDefault);
            });
            this.fc_Modal("modalDetalle", true, function () { });

            var objResponse = [];
            JQGrid_Util.AutoWidthResponsive(idGrilla_Bandeja);
            JQGrid_Util.GetTabla_Local(idGrilla_Bandeja, idPieGrilla_Bandeja, strCabecera_Bandeja, ModelCol_Bandeja, JQGrid_Opciones_Default, objResponse, function () { }, function () { }, function () { });
            JQGrid_Util.AutoWidthResponsive(idGrilla_BandejaDetalle);
        }

        function fn_Limpiar() {
            $("#txtTabla_Bus").val("");
            JQGrid_Util.clearData(idGrilla_Bandeja);
        }
        function fn_Buscar() {
            var arr_parametros = new Array();
            arr_parametros[0] = $("#txtTabla_Bus").val();
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

            /*Establece valores*/
            document.getElementById("txtID").value = rowData["id_parametro"];
            document.getElementById("txtTabla").value = rowData["no_tabla"];
            document.getElementById("txtDescripcion").value = rowData["de_tabla"];
            document.getElementById("txtEsTabla").value = rowData["fl_tabla"];

            if (rowData["fl_tabla"] == "SI") { $("#btnNuevoDetalle").show(); $("#txtValor3").attr("disabled", true); }
            else { $("#btnNuevoDetalle").hide(); $("#txtValor3").attr("disabled", false); }
            if ($("#txtID").val() == "5_0") //Datos adicionales de Persona (no usamos)
            {
                $("#txtValor4").attr("style", "display:none");
                $("#txtValor5").attr("style", "display:none");
                $("#cboValor4").attr("style", "display:");
                $("#cboTipoDatos").attr("style", "display:");
                $("#chkValor4").attr("style", "display:none");
            }
            else if ($("#txtTabla").val() == "Sub Grupo de Documentos") {
                var parametros = "{'codigo':'<%=Parametros.Combo.CDOC_GruposDocumento %>'"
                    + ",'co_padre': ''}";
                var urlService = "/wsGenerales.asmx/getCombo";
                this.fc_CallService(parametros, urlService, function (objResponse) {
                    this.fc_FillCombo("cboValor4", objResponse, textSeleccione);
                });
                $("#txtValor4").attr("style", "display:none");
                $("#txtValor5").attr("style", "display:");
                $("#cboValor4").attr("style", "display:");
                $("#cboTipoDatos").attr("style", "display:none");
                $("#chkValor4").attr("style", "display:none");
            }
            else if ($("#txtTabla").val() == "Documentos - Estados") {
                $("#txtValor4").attr("style", "display:none");
                $("#cboValor4").attr("style", "display:none");
                $("#chkValor4").attr("style", "display:");
                $("#txtValor5").attr("style", "display:");
                $("#cboTipoDatos").attr("style", "display:none");
            }
            else {
                $("#txtValor4").attr("style", "display:");
                $("#txtValor5").attr("style", "display:");
                $("#cboValor4").attr("style", "display:none");
                $("#chkValor4").attr("style", "display:none");
                $("#cboTipoDatos").attr("style", "display:none");
            }

            this.fn_GetDetalle();

            document.getElementById("txtDescripcion").focus();
        }

        function fn_Limpiar_Editar() {
            document.getElementById("txtID").value = "";
            document.getElementById("txtTabla").value = "";
            document.getElementById("txtDescripcion").value = "";
            document.getElementById("txtEsTabla").value = "";
            JQGrid_Util.clearData(idGrilla_BandejaDetalle);
        }

        function fn_Guardar() {
            var msg_retorno = "";
            if (fc_Trim($("#txtTabla").val()) == "") {
                msg_retorno += "- Debe ingresar nombre de tabla.\n";
            }

            if (msg_retorno != "") {
                alert(msg_retorno);
            }
            else if (confirm('¿Está seguro de guardar el registro?')) {
                var id_parametro = $("#txtID").val();
                var arr_parametros = new Array();
                arr_parametros[0] = id_parametro;
                arr_parametros[1] = $("#txtTabla").val();
                arr_parametros[2] = $("#txtDescripcion").val();
                arr_parametros[3] = $("#txtEsTabla").val();
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

        function fn_GetDetalle() {
            var parametros = "{'id':" + $("#txtID").val() + "}";
            var urlService = page + "/Get_Detalle";
            this.fc_CallService(parametros, urlService, function (objResponse) {
                this.JQGrid_Util.GetTabla_Local(idGrilla_BandejaDetalle, idPieGrilla_BandejaDetalle, strCabecera_BandejaDetalle, ModelCol_BandejaDetalle
                    , JQGrid_Opciones_Default, objResponse, function () { }, fn_dblClickBandejaDetalle, function () { });

                if (objResponse.length > 0) {
                    var textoValor4 = "Valor Aux.";
                    if (objResponse[0].no_valor1 == "<%=Parametros.Combo.CDOC_SubGruposDocumento%>") {
                        textoValor4 = "Grupo Asociado";
                    }
                    else if (objResponse[0].no_valor1 == "<%=Parametros.Combo.CDOC_EstadosDocumento%>") {
                        textoValor4 = "Ocultar en lista";
                    }
                    //Rename column header
                    $("#lblTexto_Valor4").text(textoValor4);
                    $(idGrilla_BandejaDetalle).jqGrid("setLabel", "no_valor4", textoValor4);
                }
            });
        }
        function fn_dblClickBandejaDetalle(rowID) {
            var rowData = $(this.idGrilla_BandejaDetalle).getRowData(rowID);

            fn_LimpiarModal();
            $("#txtIDParametroDetalle").val(rowData.id_parametro_detalle);
            $("#txtValor2").val(rowData.no_valor2);
            $("#txtValor3").val(rowData.no_valor3);
            if ($("#txtID").val() == "5_0") //Datos adicionales de Persona (no usamos)
            {
                $("#cboValor4").val(rowData.no_valor4);
                $("#cboTipoDatos").val(rowData.no_valor5);
            }
            else if ($("#txtTabla").val() == "Sub Grupo de Documentos") {
                $("#cboValor4").val(rowData.no_valor4);
                $("#txtValor5").val(rowData.no_valor5);
            }
            else if ($("#txtTabla").val() == "Documentos - Estados") {
                $("#chkValor4").prop("checked", rowData.no_valor4 == "1" ? true : false);
                $("#txtValor5").val(rowData.no_valor5);
            }
            else {
                $("#txtValor4").val(rowData.no_valor4);
                $("#txtValor5").val(rowData.no_valor5);
            }
            $("#cboEstadoDetalle").val(rowData.fl_activo);
            $("#modalDetalle").dialog("open");
            $('#modalDetalle').dialog("option", "title", "Editar Detalle");
        }
        function fn_NuevoParametroDetalle() {
            var id_parametro = document.getElementById("txtID").value;
            var msg_retorno = "";
            if (id_parametro == "") {
                msg_retorno += "-Debe grabar el parámetro antes de agregar detalles.\n";
            }
            if (msg_retorno != "") {
                alert(msg_retorno);
                return false;
            }

            fn_LimpiarModal();
            $("#cboEstadoDetalle").val("1");
            $("#modalDetalle").dialog("open");
            $('#modalDetalle').dialog("option", "title", "Agregar Detalle");
        }
        function fn_LimpiarModal() {
            $("[rol=modal1]").val("");
            $("#chkValor4").prop("checked", false);
        }
        function fn_GrabarDetalle() {
            var no_valor4 = "", no_valor5 = "";
            var msg_retorno = "";
            if ($("#txtID").val() == "") {
                msg_retorno += "- Debe seleccionar un parámetro.\n";
            }
            if (fc_Trim($("#txtValor2").val()) == "") { msg_retorno += "- Debe ingresar descripción.\n"; }
            if (fc_Trim($("#txtValor3").val()) == "" && $("#txtValor3").prop("disabled") == false) { msg_retorno += "- Debe ingresar valor/código interno.\n"; }

            if ($("#txtID").val() == "5_0") //Datos adicionales de Persona (no usamos)
            {
                no_valor4 = $("#cboValor4").val();
                no_valor5 = $("#cboTipoDatos").val();
                if (fc_Trim(no_valor4) == "") { msg_retorno += "- Debe seleccionar Valor Aux.\n"; }
                if (fc_Trim(no_valor5) == "") { msg_retorno += "- Debe seleccionar Valor 5 (tipo de dato).\n"; }
            }
            else if ($("#txtTabla").val() == "Sub Grupo de Documentos") {
                no_valor4 = $("#cboValor4").val();
                if (fc_Trim(no_valor4) == "") { msg_retorno += "- Debe seleccionar grupo.\n"; }
                no_valor5 = $("#txtValor5").val();
            }
            else if ($("#txtTabla").val() == "Documentos - Estados") {
                no_valor4 = $("#chkValor4").prop("checked") ? "1" : "";
                no_valor5 = $("#txtValor5").val();
            }
            else {
                no_valor4 = $("#txtValor4").val();
                no_valor5 = $("#txtValor5").val();
            }

            if ($("#cboEstadoDetalle").val() == "") { msg_retorno += "- Debe seleccionar estado.\n"; }

            if (msg_retorno != "") {
                alert(msg_retorno);
            }
            else {
                if (confirm('¿Está seguro de guardar el registro?')) {
                    var id_parametro = $("#txtID").val();
                    var arr_parametros = new Array();
                    arr_parametros[0] = $("#txtIDParametroDetalle").val();
                    arr_parametros[1] = $("#txtID").val();
                    arr_parametros[2] = $("#txtValor2").val();
                    arr_parametros[3] = $("#txtValor3").val();
                    arr_parametros[4] = no_valor4;
                    arr_parametros[5] = no_valor5;
                    arr_parametros[6] = $("#cboEstadoDetalle").val();
                    var parametros = "{'strParametros':" + JSON.stringify(arr_parametros) + "}";
                    var urlService = page + "/GrabarParametroDetalle";
                    this.fc_CallService(parametros, urlService, function (objResponse) {
                        if (objResponse[0] > 0) {
                            this.fn_GetDetalle();
                            $("#modalDetalle").dialog("close");
                        }
                        alert(objResponse[1]);
                    });
                }
            }
        }
    </script>
</asp:Content>
