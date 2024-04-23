<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AsigBancoPagoCia_Personal.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Mantenimientos.AsigBancoPagoCia_Personal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/JqGrid/jquery-ui.css" rel="stylesheet" />
    <link href="../css/JqGrid/ui.jqgrid.css" rel="stylesheet" />
    <script src="../JQuery/jquery-1.11.1.min.js"></script>
    <script src="../JQuery/jquery-1.11.1-ui.min.js"></script>
    <script src="../JQuery/jqGrid-4.5.2/grid.locale-en.min.js"></script>
    <script src="../JQuery/jqGrid-4.5.2/jquery.jqGrid.src.min.js"></script>
    <script src="../JQuery/Funciones.min.js"></script>

    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />

    <link href="../Styles/nuevoEstiloPlanilla.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .ui-jqgrid tr.jqgrow td {
            white-space: normal !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <input type="hidden" id="empresaSession" value="<%= Session["EmpresaPlanilla"] %>" />
        <input type="hidden" id="periodoSession" value="<%= Session["PeriodoPlanilla"] %>" />
        <input type="hidden" id="planillaSession" value="<%= Session["planillaPlanilla"] %>" />
        <input type="hidden" id="anioSession" value="<%= Session["anioPlanilla"] %>" />
        <div class="miTitulo" style="font-weight: bold; font-size: 14px; margin-bottom: 20px; text-align: center;">ASIGNACIÓN MASIVA DE BANCO DE PAGO DE LA COMPAÑÍA</div>
        <table style="width: 100%;">
            <tr>
                <td>Localidad:
                </td>
                <td>
                    <select id="cboLocalidad_Bus" style="width: 150px;">
                    </select>
                </td>
                <td>Área:
                </td>
                <td>
                    <select id="cboCatAuxiliar_Bus" style="width: 150px;">
                    </select>
                </td>
                <td>Sección:
                </td>
                <td>
                    <select id="cboCatAuxiliar2_Bus" style="width: 150px;">
                        <option value="">--Todos--</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>Proyecto:</td>
                <td>
                    <select id="cboProyecto_Bus" style="width: 150px;"></select>
                </td>
                <td>Personal:
                </td>
                <td>
                    <select id="cboPersonal_Bus" style="width: 250px;">
                        <option value="">--Todos--</option>
                    </select>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>            
        </table>
        <div style="padding-top: 10px;text-align:right;">
            <button id="btnBuscar" type="button" onclick="fn_Buscar();">
                Buscar</button>
            <button id="btnOpenAsignarBanco" type="button">
                Asignar Banco Haberes</button>
            <button id="btnOpenAsignarBanco_CTS" type="button">
                Asignar Banco CTS</button>
        </div>
        <div style="padding-top: 10px;">
            <table id="grvBandeja">
            </table>
            <div id="grvBandeja_Pie">
            </div>
        </div>
    </div>
    <div id="dialog-confirm" title="Asignación" style="display: none; overflow: none;">
        <div style="font-family: Verdana; font-size: 11px;">
            <div style="font-weight: bold; font-size: 14px; padding-bottom: 20px; text-align: center;">
                <label id="lblTitulo_Dialog"></label>
            </div>
            <table style="width: 100%;">
                <tr>
                    <td>
                        <label id="lblBancoPagoCia"></label>
                    </td>
                    <td>
                        <input id="txh_FlagBanco_CTS" type="hidden" />
                        <select id="cboBancoPago_Cia" style="width: 150px;">
                        </select>
                    </td>
                </tr>
            </table>
            <div style="padding-top: 10px; text-align: center">
                <button id="btnGuardarAsignacion" type="button">
                    Guardar Asignación
                </button>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        var pagePath = window.location.pathname;
        /*[INICIO] - Variables Grilla Bandeja*/
        var idGrilla_Bandeja = "#grvBandeja";
        var idPieGrilla_Bandeja = "#grvBandeja_Pie";
        var strCabecera_Bandeja = ['Personal_Id', 'Periodo_Id', 'Nombre Completo', 'Localidad', 'Area', 'Sección', 'Proyecto', 'Banco Pago Cia', 'Banco Pago CTS Cia', 'Nro. Cta. Hab.', 'Nro. Cta. Inter. Hab.', 'Banco Cta. Hab.'];
        var ModelCol_Bandeja = [
            { name: 'Personal_Id', index: 'id_envio', hidden: true },
            { name: 'Periodo_Id', index: 'Periodo_Id', hidden: true },
            { name: 'Nombre_Completo', index: 'Nombre_Completo', width: 250, sortable: true, align: 'left' },
            { name: 'Localidad', index: 'Localidad', width: 100, sortable: true, align: 'center' },
            { name: 'Area', index: 'Area', width: 100, sortable: true, align: 'center' },
            { name: 'Seccion', index: 'Seccion', width: 100, sortable: true, align: 'center' },
            { name: 'Proyecto', index: 'Proyecto', width: 100, sortable: true, align: 'center' },
            { name: 'Banco_pago_cia', index: 'Banco_pago_cia', width: 100, sortable: true, align: 'center' },
            { name: 'Banco_pago_cts_cia', index: 'Banco_pago_cts_cia', width: 100, sortable: true, align: 'center' },
            { name: 'Nro_cta', index: 'Nro_cta', width: 100, sortable: true, align: 'center' },
            { name: 'Nro_cta_interbancaria', index: 'Nro_cta_interbancaria', width: 150, sortable: true, align: 'center' },
            { name: 'Banco_cta', index: 'Banco_cta', width: 100, sortable: true, align: 'center' }
        ];
        /*[FIN] - Variables Grilla Bandeja*/
        function Get_Compania() {
            var cboCompa = document.getElementById('empresaSession').value;
            return cboCompa;
        }
        function Get_Planilla() {
            var cbo = document.getElementById('planillaSession').value;
            return cbo;
        }
        function Get_Ejercicio() {
            var cbo = document.getElementById('anioSession').value;
            return cbo;
        }
        function Get_Periodo() {
            var cbo = document.getElementById('periodoSession').value;
            return cbo;
        }

        //#region "Eventos Cabecera"
        Sys.Application.add_init(appl_init); 
        function appl_init() {
            var pgRegMgr = Sys.WebForms.PageRequestManager.getInstance();
            pgRegMgr.add_beginRequest(BeginHandler);
            pgRegMgr.add_endRequest(EndHandler);
        } 
        function BeginHandler() {
            beforeAsyncPostBack();
        } 
        function EndHandler() {           
            afterAsyncPostBack();
        }
        function beforeAsyncPostBack() {
            //var curtime = new Date();
            //console.log('Time before PostBack:   ' + curtime);           
        } 
        function afterAsyncPostBack() {
            //var curtime = new Date();
            //console.log('Time after PostBack:    ' + curtime);

            var PeriodoCab_Nuevo = Get_Periodo();
            if (PeriodoCab_Anterior != PeriodoCab_Nuevo) {                
                PeriodoCab_Anterior = PeriodoCab_Nuevo;
                CargarChangeCab();
            }
        }
        var PeriodoCab_Anterior = Get_Periodo();
        function CargarChangeCab() {
            fn_CargarPersonal();
            JQGrid_Util.clearData(idGrilla_Bandeja);
        }
        //#endregion "Eventos Cabecera"

        $(document).ready(function () {
            $("button").button();

            var strParametros = "";
            var strUrlServicio = pagePath + "/Get_Combos";
            fc_CallService(strParametros, strUrlServicio, function (objResponse) {
                this.fc_FillCombo("cboLocalidad_Bus", objResponse.oLocalidad, "--Todos--");
                this.fc_FillCombo("cboCatAuxiliar_Bus", objResponse.oCatAuxiliar, "--Todos--");
                this.fc_FillCombo("cboProyecto_Bus", objResponse.oProyecto, "--Todos--");
                this.fc_FillCombo("cboPersonal_Bus", [], "--Todos--");
                fn_CargarPersonal();
            });

            var objResponse = [];
            JQGrid_Util.GetTabla_Local(idGrilla_Bandeja, idPieGrilla_Bandeja, strCabecera_Bandeja, ModelCol_Bandeja
                , JQGrid_Opciones_Default, objResponse, function () { }, function () { }, function () { });
        });
        $("#cboLocalidad_Bus").change(function () {
            fn_CargarPersonal();
        });
        $("#cboCatAuxiliar_Bus").change(function () {
            fn_CargarCatAuxiliar2();
            fn_CargarPersonal();
        });
        $("#cboCatAuxiliar2_Bus").change(function () {
            fn_CargarPersonal();
        });
        $("#cboProyecto_Bus").change(function () {
            fn_CargarPersonal();
        });
        function fn_CargarCatAuxiliar2() {
            if ($("#cboCatAuxiliar_Bus").val() == "") {
                this.fc_FillCombo("cboCatAuxiliar2_Bus", "", "--Todos--");
            }
            else {
                var parametros = new Object();
                parametros.co_catAuxiliar = $("#cboCatAuxiliar_Bus").val();
                var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
                var strUrlServicio = pagePath + "/Get_CatAuxiliar2";
                this.fc_CallService(strParametros, strUrlServicio, function (objResponse) {
                    this.fc_FillCombo("cboCatAuxiliar2_Bus", objResponse, "--Todos--");
                });
            }
        }
        function fn_CargarPersonal() {
            var co_ejercicio = Get_Ejercicio();
            var co_planilla = Get_Planilla();
            var co_periodo = Get_Periodo();

            if ($("#cboPlanilla_Bus").val() == "" || $("#cboEjercicio_Bus").val() == "") {
                this.fc_FillCombo("cboPersonal_Bus", "", "--Todos--");
                this.fc_FillCombo("cboPersonal_new", "", "--Todos--");
            }
            else {
                var parametros = new Object();
                parametros.co_Ejercicio = co_ejercicio;
                parametros.co_Planilla = co_planilla;
                parametros.co_Periodo = co_periodo;
                parametros.co_Area = $("#cboLocalidad_Bus").val();
                parametros.co_catAuxiliar = $("#cboCatAuxiliar_Bus").val();
                parametros.co_catAuxiliar2 = $("#cboCatAuxiliar2_Bus").val();
                parametros.co_Proyecto = $("#cboProyecto_Bus").val();
                var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
                var strUrlServicio = pagePath + "/Get_Personal";
                this.fc_CallService(strParametros, strUrlServicio, function (objResponse) {
                    this.fc_FillCombo("cboPersonal_Bus", objResponse, "--Todos--");
                });
            }
        }
        function fn_Buscar() {
            var co_ejercicio = Get_Ejercicio();
            var co_planilla = Get_Planilla();
            var co_periodo = Get_Periodo();

            var msg_retorno = "";
            if (co_planilla == "") msg_retorno += "- Debe seleccionar planilla.\n";
            if (co_ejercicio == "") msg_retorno += "- Debe seleccionar ejercicio.\n";
            if (co_periodo == "") msg_retorno += "- Debe seleccionar periodo.\n";

            if (msg_retorno != "") alert(msg_retorno);
            else {
                var parametros = new Object();
                parametros.co_planilla = co_planilla
                parametros.co_ejercicio = co_ejercicio;
                parametros.co_periodo = co_periodo;
                parametros.id_localidad = $("#cboLocalidad_Bus").val();
                parametros.id_cat_aux = $("#cboCatAuxiliar_Bus").val();
                parametros.id_cat_aux2 = $("#cboCatAuxiliar2_Bus").val();
                parametros.id_proyecto = $("#cboProyecto_Bus").val();
                parametros.id_persona = $("#cboPersonal_Bus").val();

                var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
                var strUrlServicio = pagePath + "/Get_Bandeja";
                this.fc_CallService(strParametros, strUrlServicio, function (objResponse) {
                    var JQGrid_Opciones = this.JQGrid_Opciones_Default;
                    JQGrid_Opciones.fl_paginar = false;
                    JQGrid_Opciones.height = 300;
                    JQGrid_Opciones.grouping = true;
                    JQGrid_Opciones.fl_multiselect = true;
                    this.JQGrid_Util.GetTabla_Local(idGrilla_Bandeja, idPieGrilla_Bandeja, strCabecera_Bandeja, ModelCol_Bandeja
                        , JQGrid_Opciones, objResponse, function () { }, function () { }, function () { });
                });
            }
        }

        $("#btnOpenAsignarBanco").click(function () {
            var msg = "";

            var rowIDs = JQGrid_Util.getRowIDsSelected(idGrilla_Bandeja);
            if (rowIDs.length <= 0) { msg += "Debe seleccionar al menos un personal.\n"; }

            if (msg != "") { alert(msg); }
            else {
                $("#lblTitulo_Dialog").text("ASIGNACIÓN DE BANCO DE PAGO");
                $("#lblBancoPagoCia").text("Banco de Pago de Compañía - MN:");
                $("#txh_FlagBanco_CTS").val("0");
                $("#cboBancoPago_Cia").val("");

                $("#dialog-confirm").dialog({
                    resizable: false,
                    height: 200,
                    width: 410,
                    modal: true,
                    buttons: {
                        Cancelar: function () {
                            $(this).dialog("close");
                        }
                    }
                });
            }
        });

        $("#btnOpenAsignarBanco_CTS").click(function () {
            var msg = "";

            var rowIDs = JQGrid_Util.getRowIDsSelected(idGrilla_Bandeja);
            if (rowIDs.length <= 0) { msg += "Debe seleccionar al menos un personal.\n"; }

            if (msg != "") { alert(msg); }
            else {
                $("#lblTitulo_Dialog").text("ASIGNACIÓN DE BANCO DE PAGO CTS");
                $("#lblBancoPagoCia").text("Banco de Pago CTS de Compañía - MN:");
                $("#txh_FlagBanco_CTS").val("1");
                $("#cboBancoPago_Cia").val("");

                $("#dialog-confirm").dialog({
                    resizable: false,
                    height: 200,
                    width: 410,
                    modal: true,
                    buttons: {
                        Cancelar: function () {
                            $(this).dialog("close");
                        }
                    }
                });
            }
        });

        $("#btnGuardarAsignacion").click(function () {
            var msg = "";
            var co_periodo = Get_Periodo();
            var idBanco = $("#cboBancoPago_Cia").val();
            var fl_CTS = $("#txh_FlagBanco_CTS").val();

            if (idBanco == "") { msg += "Debe seleccionar un banco.\n"; }

            var rowIDs = JQGrid_Util.getRowIDsSelected(idGrilla_Bandeja);
            if (rowIDs.length <= 0) { msg += "Debe seleccionar al menos un personal.\n"; }

            if (msg != "") { alert(msg); }
            else if (confirm("¿Está seguro de guardar la asignación?")) {
                var Personal_Ids = "";
                var delimit = "";
                for (var i = 0; i < rowIDs.length; i++) {
                    var rowID = rowIDs[i];
                    var rowData = JQGrid_Util.getRowData(idGrilla_Bandeja, rowID);

                    if (i > 0) { delimit = "|"; }
                    Personal_Ids += delimit + rowData.Personal_Id;
                }

                var parametros = new Object();
                parametros.co_periodo = co_periodo;
                parametros.ids_personal = Personal_Ids;
                parametros.co_banco_pago_cia = idBanco;
                parametros.fl_CTS = fl_CTS;
                parametros.fl_cts = "0";
                var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
                var strUrlServicio = pagePath + "/setAsigBancoPago_Cia";
                fc_CallService(strParametros, strUrlServicio, function (objResponse) {
                    alert(objResponse.msg_retorno);
                    if (objResponse.retorno > 0) {
                        $("#dialog-confirm").dialog("close");
                        fn_Buscar();
                    }
                });
            }
        });

        function fn_CallService(strUrl, strAsync, strParametros, fn_callback) {
            $.ajax({
                type: 'POST',
                url: strUrl,
                data: strParametros,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: strAsync,
                beforeSend: function () { fc_show_progress(!0); },
                success: function (response) { var data = response; fn_callback(data); },
                complete: function () { fc_show_progress(!1); },
                error: function (jqXHR, status, err) {
                    if (jqXHR.status === 0) {
                        alert('Not connect: Verify Network.');
                    } else if (jqXHR.status == 404) {
                        alert('Requested page not found [404]');
                    } else if (jqXHR.status == 500) {
                        alert('Internal Server Error [500].');
                    } else {
                        alert('Uncaught Error: ' + jqXHR.responseText);
                    }
                }
            });
        }
    </script>   
</asp:Content>