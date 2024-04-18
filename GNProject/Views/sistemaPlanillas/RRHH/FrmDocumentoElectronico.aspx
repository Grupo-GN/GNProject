<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmDocumentoElectronico.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.RRHH.FrmDocumentoElectronico" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <link href="../css/JqGrid/jquery-ui.css" rel="stylesheet" />
    <link href="../css/JqGrid/ui.jqgrid.css" rel="stylesheet" />
    <script src="../JQuery/jquery-1.11.1.min.js"></script>
    <script src="../JQuery/jquery-1.11.1-ui.min.js"></script>
    <script src="../JQuery/jqGrid-4.5.2/grid.locale-en.min.js"></script>
    <script src="../JQuery/jqGrid-4.5.2/jquery.jqGrid.src.min.js"></script>
    <script src="../JQuery/Funciones.min.js"></script>
    <style type="text/css">
        .ui-jqgrid tr.jqgrow td {
            white-space: normal !important;
        }
    </style>

    <link href="../Styles/nuevoEstiloPlanilla.css" rel="stylesheet" type="text/css" />

    <div>
        <div style="font-weight: bold; font-size: 14px; padding-bottom: 20px; text-align: center;">CONTROL DE DOCUMENTOS ELECTRÓNICOS</div>
        <table style="width: 100%;">
            <tr>
                <td>Planilla:
                </td>
                <td>
                    <select id="cboPlanilla_Bus" style="width: 150px;">
                    </select>
                </td>
                <td>Ejercicio:
                </td>
                <td>
                    <select id="cboEjercicio_Bus" style="width: 150px;">
                    </select>
                </td>
                <td>Periodo:
                </td>
                <td>
                    <select id="cboPeriodo_Bus" style="width: 150px;">
                        <option value="">--Todos--</option>
                    </select>
                </td>
            </tr>
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
                <td>Documento:
                </td>
                <td>
                    <select id="cboDocumento_Bus" style="width: 150px;">
                        <option value="">--Todos--</option>
                        <option value="BP">Boleta Pago</option>
                        <option value="CTS">CTS</option>
                        <option value="CUTIL">Certificado utilidad</option>
                        <option value="CQTA">Certificado de Quinta</option>
                        <option value="CBC">Certificado de Banco CTS</option>
                        <option value="CT">Certificado de Trabajo</option>
                        <option value="CL2">Certificado de Liquidacion 2</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>Fecha Envio:
                </td>
                <td colspan="3">
                    <input id="txtFec_Desde" type="text" style="width: 110px" />
                    a
                    <input id="txtFec_Hasta" type="text" style="width: 110px" />
                </td>
                <td></td>
                <td></td>
            </tr>
        </table>
        <div style="padding-top: 10px;">
            <button id="btnBuscar" type="button" onclick="fn_Buscar();">
                Buscar</button>
            <button id="btnImprimir" type="button" onclick="fn_ImprimirReporte();">
                Imprimir</button>
            <button id="btnGenerarReporte" type="button" onclick="fn_GenerarNuevoEnvio();">
                Enviar Documento</button>
        </div>
        <div style="padding-top: 10px;">
            <table id="grvBandeja">
            </table>
            <div id="grvBandeja_Pie">
            </div>
        </div>
    </div>

    <div id="dialog-confirm" title="Seleccione personal" style="display: none; overflow: none">
        <div style="font-family: Verdana; font-size: 11px;">
            <div style="font-weight: bold; font-size: 14px; padding-bottom: 20px; text-align: center;">
                ENVÌO DE DOCUMENTOS
            </div>
            <table style="width: 100%;">
                <tr>
                    <td>Planilla:
                    </td>
                    <td>
                        <select id="cboPlanilla_new" style="width: 150px;">
                        </select>
                    </td>
                    <td>Ejercicio:
                    </td>
                    <td>
                        <select id="cboEjercicio_new" style="width: 150px;">
                        </select>
                    </td>
                    <td>Periodo:
                    </td>
                    <td style="width: 200px;">
                        <select id="cboPeriodo_new" style="width: 150px;">
                            <option value="">--Seleccione--</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>Localidad:
                    </td>
                    <td>
                        <select id="cboLocalidad_new" style="width: 150px;">
                        </select>
                    </td>
                    <td>Área:
                    </td>
                    <td>
                        <select id="cboCatAuxiliar_new" style="width: 150px;">
                        </select>
                    </td>
                    <td>Sección:
                    </td>
                    <td>
                        <select id="cboCatAuxiliar2_new" style="width: 150px;">
                            <option value="">--Todos--</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>Proyecto:</td>
                    <td>
                        <select id="cboProyecto_new" style="width: 150px;"></select></td>
                    <td>Personal:
                    </td>
                    <td>
                        <select id="cboPersonal_new" style="width: 200px;">
                            <option value="">--Todos--</option>
                        </select>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Proceso:
                    </td>
                    <td>
                        <select class="miComboBox" id="cboProceso" style="width: 150px;">
                        </select>
                    </td>
                    <td>Tipo de Doc.:
                    </td>
                    <td>
                        <select id="ddlTipoDocumento" style="width: 150px;">
                            <option value="">--Seleccione--</option>
                            <option value="BP">Boleta Pago</option>
                            <option value="CTS">CTS</option>
                            <option value="CUTIL">Certificado utilidad</option>
                            <option value="CQTA">Certificado de Quinta</option>
                            <option value="CBC">Certificado de Banco CTS</option>
                            <option value="CT">Certificado de Trabajo</option>
                            <option value="CL2">Certificado de Liquidacion 2</option>
                        </select>
                    </td>
                    <td>
                        Modo Envío:
                    </td>
                    <td>
                        <select id="ddlGuardarArchivo">
                            <option value="0" selected="selected">En Línea</option>
                            <option value="1">Archivo Físico</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">Mostrar Personal sin envíos:
                        <input type="checkbox" id="chkPersonalSinEnvio" />
                    </td>
                    <td colspan="2">Mostrar Personal con correo:
                        <input type="checkbox" id="chkPersonalConCorreo" />
                    </td>
                    <td colspan="2">
                        <label id="lblDolares" style="display: none;">
                            <input id="chkDolares" type="checkbox" />Importe en Dólares</label>
                        <label id="lblAddTotalUSD" style="display: none;">
                            <input id="chkAddTotalUSD" type="checkbox" />Total en Dólares</label>
                    </td>
                </tr>
                <tr id="trAcumMontos" style="display: none;">
                    <td colspan="2">Acumular Montos:
                        <input id="chkAcumMontos" type="checkbox" />
                    </td>
                    <td colspan="2">
                        <label id="lblPeriodo_Desde" style="display: none;">Periodo Desde:</label>
                        <select id="cboPeriodo_Desde" style="display: none;"></select>
                    </td>
                    <td colspan="2">
                        <label id="lblNotaAcum" style="display: none; color: #ff6a00; font-weight: bold; font-size: 10px;">S&oacute;lo acumula los Ingresos/Descuentos/Aportes</label>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <div id="divNotaDolares" style="display: none; background-color: yellow; padding: 4px 2px; font-weight: bold;">
                            Tener en cuenta que es importante el ingreso del Tipo de Cambio al periodo seleccionado.
                        </div>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="3"></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
            </table>
            <div style="padding-top: 10px; text-align: center">
                <button id="btnBusca_new" type="button" onclick="fn_Buscar_Destinos()">
                    Buscar
                </button>
                &nbsp;&nbsp;&nbsp;
                <button id="btnEnvia_new" type="button" onclick="fn_GetEnviarDocumento();">
                    Enviar Documento
                </button>
            </div>
            Seleccione a los trabajadores que se les va a enviar el documento
            <div style="padding-top: 10px; text-align: center; width: 95%;">
                <table id="grvBandeja_new">
                </table>
                <div id="grvBandeja_Pie_new">
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        var pagePath = window.location.pathname;
        /*[INICIO] - Variables Grilla Bandeja*/
        var idGrilla_Bandeja = "#grvBandeja";
        var idPieGrilla_Bandeja = "#grvBandeja_Pie";
        var strCabecera_Bandeja = ['ID', 'Localidad', 'Personal', 'Correo Enviado', 'Documento', 'F. Envío', 'F. Recepción', 'Proceso', 'Periodo', 'Archivo', 'En Línea'];
        var ModelCol_Bandeja = [
            { name: 'id_envio', index: 'id_envio', width: 40, sortable: true, align: 'center' },
            { name: 'Localidad', index: 'Localidad', width: 100, sortable: true, align: 'left' },
            { name: 'personal', index: 'personal', width: 250, sortable: true, align: 'left' },
            { name: 'no_correo_enviado', index: 'no_correo_enviado', width: 200, sortable: true, align: 'left' },
            { name: 'documento', index: 'documento', width: 110, sortable: true, align: 'left' },
            { name: 'fe_envio', index: 'fe_envio', width: 70, sortable: true, align: 'center' },
            { name: 'fe_recepcion', index: 'fe_recepcion', width: 75, sortable: true, align: 'center' },
            { name: 'proceso', index: 'proceso', width: 110, sortable: true, align: 'center' },
            { name: 'periodo', index: 'periodo', width: 100, sortable: true, align: 'center' },
            { name: 'img_ver', index: 'img_ver', width: 50, sortable: false, align: 'center' },
            { name: 'img_genDocumento', index: 'img_genDocumento', width: 50, sortable: false, align: 'center' }
        ];

        var idGrilla_Bandeja_new = "#grvBandeja_new";
        var idPieGrilla_Bandeja_new = "#grvBandeja_Pie_new";
        var strCabecera_Bandeja_new = ['Personal ID', 'Personal', 'Correo Personal / Corporativo'];
        var ModelCol_Bandeja_new = [
            { name: 'Personal_Id', index: 'Personal_Id', hidden: true },
            { name: 'nom_personal', index: 'nom_personal', width: 300, sortable: true, align: 'left' },
            { name: 'email_personal', index: 'email_personal', width: 350, sortable: true, align: 'left' }
        ];
        /*[FIN] - Variables Grilla Bandeja*/

        this.fn_CargaInicial();
        function fn_CargaInicial() {
            $("button").button();

            var strParametros = "";
            var strUrlServicio = pagePath + "/Get_Combos";
            this.fc_CallService(strParametros, strUrlServicio, function (objResponse) {
                this.fc_FillCombo("cboPlanilla_Bus", objResponse.oPlanilla, "--Seleccione--");
                this.fc_FillCombo("cboEjercicio_Bus", objResponse.oEjercicio, "--Seleccione--");
                $("#cboEjercicio_Bus").prop('selectedIndex', objResponse.oEjercicio.length);
                this.fc_FillCombo("cboLocalidad_Bus", objResponse.oLocalidad, "--Todos--");
                this.fc_FillCombo("cboCatAuxiliar_Bus", objResponse.oCatAuxiliar, "--Todos--");

                this.fc_FillCombo("cboPlanilla_new", objResponse.oPlanilla, "--Seleccione--");
                this.fc_FillCombo("cboEjercicio_new", objResponse.oEjercicio, "--Seleccione--");
                $("#cboEjercicio_new").prop('selectedIndex', objResponse.oEjercicio.length);
                this.fc_FillCombo("cboLocalidad_new", objResponse.oLocalidad, "--Todos--");
                this.fc_FillCombo("cboCatAuxiliar_new", objResponse.oCatAuxiliar, "--Todos--");
                //20190701
                this.fc_FillCombo("cboProyecto_new", objResponse.oProyecto, "--Todos--");
                this.fc_FillCombo("cboProyecto_Bus", objResponse.oProyecto, "--Todos--");
            });

            var objResponse = [];
            this.JQGrid_Util.GetTabla_Local(idGrilla_Bandeja, idPieGrilla_Bandeja, strCabecera_Bandeja, ModelCol_Bandeja
                , JQGrid_Opciones_Default, objResponse, function () { }, function () { }, function () { });

            this.JQGrid_Util.GetTabla_Local(idGrilla_Bandeja_new, idPieGrilla_Bandeja_new, strCabecera_Bandeja_new, ModelCol_Bandeja_new
                , JQGrid_Opciones_Default, objResponse, function () { }, function () { }, function () { });

            //fn_SetGrupoCabecera();
            this.fc_FormatFecha("txtFec_Desde", DatePicker_Opciones_Default, "MIN", "txtFec_Hasta");
            this.fc_FormatFecha("txtFec_Hasta", DatePicker_Opciones_Default, "MAX", "txtFec_Desde");

            SISGNRSProcesosSelect();
        }

        $("#ddlTipoDocumento").change(function () {
            var value = $(this).val();
            $("#chkDolares").prop("checked", false).trigger("change");
            if (value == "BP") {
                $("#lblDolares").show();

                $("#trAcumMontos").show();
                $("#chkAcumMontos").prop("checked", false).trigger("change");
            }
            else {
                $("#lblDolares").hide();

                $("#trAcumMontos").hide();
                $("#chkAcumMontos").prop("checked", false).trigger("change");
            }
        });
        $("#chkDolares").change(function () {
            var flCheck = $(this).prop("checked");
            if (flCheck) {
                $("#divNotaDolares").show();
                $("#lblAddTotalUSD").hide();
            }
            else {
                $("#divNotaDolares").hide();
                $("#lblAddTotalUSD").show();
            }

            $("#chkAddTotalUSD").prop("checked", false);
        });

        $("#chkAcumMontos").change(function () {
            var Periodo_Id_Selected = $("#cboPeriodo_new").val();
            var fl_visible = $(this).prop("checked");
            if (fl_visible) {
                $("#lblPeriodo_Desde").show();
                $("#cboPeriodo_Desde").show();
                $("#lblNotaAcum").show();
            }
            else {
                $("#lblPeriodo_Desde").hide();
                $("#cboPeriodo_Desde").hide();
                $("#lblNotaAcum").hide();
            }

            if (fl_visible && Periodo_Id_Selected != "") {
                var parametros = new Object();
                parametros.co_cia = $("#ctl00_ucFiltros1_cboEmpresa").val();
                parametros.co_ejercicio = $("#cboEjercicio_new").val();
                parametros.co_planilla = $("#cboPlanilla_new").val();
                parametros.co_periodo_selected = Periodo_Id_Selected;
                var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
                var strUrlServicio = pagePath + "/Get_Periodo_Desde";
                fc_CallService(strParametros, strUrlServicio, function (objResponse) {
                    this.fc_FillCombo("cboPeriodo_Desde", objResponse, "--Seleccione--");
                });
            }
            else {
                fc_FillCombo("cboPeriodo_Desde", [], "--Seleccione--");
            }
        });

        function SISGNRSProcesosSelect() {
            $('<option value="">--Seleccione--</option>').appendTo('#cboProceso');
            $('<option value="01">REMUNERACIONES</option>').appendTo('#cboProceso');
            $('<option value="02">QUINCENA</option>').appendTo('#cboProceso');
            $('<option value="03">VACACIONES</option>').appendTo('#cboProceso');
            $('<option value="04">GRATIFICACION</option>').appendTo('#cboProceso');
            $('<option value="05">CTS</option>').appendTo('#cboProceso');
            $('<option value="06">PROVISION</option>').appendTo('#cboProceso');
            $('<option value="07">UTILIDADES</option>').appendTo('#cboProceso');
            $('<option value="08">LIQUIDACION</option>').appendTo('#cboProceso');
        }
        $("#cboPlanilla_Bus").change(function () {
            fn_CargarPeriodo();
            fn_CargarPersonal();
        });
        $("#cboEjercicio_Bus").change(function () {
            fn_CargarPeriodo();
            fn_CargarPersonal();
        });
        $("#cboPeriodo_Bus").change(function () {
            fn_CargarPersonal();
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

        $("#cboPlanilla_new").change(function () {
            fn_CargarPeriodo_new();
            fn_CargarPersonal_new();

            $("#ddlTipoDocumento").trigger("change");
        });
        $("#cboEjercicio_new").change(function () {
            fn_CargarPeriodo_new();
            fn_CargarPersonal_new();

            $("#ddlTipoDocumento").trigger("change");
        });
        $("#cboPeriodo_new").change(function () {
            fn_CargarPersonal_new();

            $("#ddlTipoDocumento").trigger("change");
        });
        $("#cboLocalidad_new").change(function () {
            fn_CargarPersonal_new();
        });
        $("#cboCatAuxiliar_new").change(function () {
            fn_CargarCatAuxiliar2_new();
            fn_CargarPersonal_new();
        });
        $("#cboCatAuxiliar2_new").change(function () {
            fn_CargarPersonal_new();
        });
        $("#cboProyecto_new").change(function () {
            fn_CargarPersonal_new();
        });
        function fn_CargarPeriodo() {
            if ($("#cboPlanilla_Bus").val() == "" || $("#cboEjercicio_Bus").val() == "") {
                this.fc_FillCombo("cboPeriodo_Bus", "", "--Todos--");
                this.fc_FillCombo("cboPeriodo_new", "", "--Seleccione--");
            }
            else {
                var parametros = new Object();
                parametros.co_planilla = $("#cboPlanilla_Bus").val();
                parametros.co_ejercicio = $("#cboEjercicio_Bus").val();
                var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
                var strUrlServicio = pagePath + "/Get_Periodo";
                this.fc_CallService(strParametros, strUrlServicio, function (objResponse) {
                    this.fc_FillCombo("cboPeriodo_Bus", objResponse, "--Todos--");
                    this.fc_FillCombo("cboPeriodo_new", objResponse, "--Seleccione--");
                });
            }
        }
        function fn_CargarCatAuxiliar2() {
            if ($("#cboCatAuxiliar_Bus").val() == "") {
                this.fc_FillCombo("cboCatAuxiliar2_Bus", "", "--Todos--");
                this.fc_FillCombo("cboCatAuxiliar2_new", "", "--Todos--");
            }
            else {
                var parametros = new Object();
                parametros.co_catAuxiliar = $("#cboCatAuxiliar_Bus").val();
                var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
                var strUrlServicio = pagePath + "/Get_CatAuxiliar2";
                this.fc_CallService(strParametros, strUrlServicio, function (objResponse) {
                    this.fc_FillCombo("cboCatAuxiliar2_Bus", objResponse, "--Todos--");
                    this.fc_FillCombo("cboCatAuxiliar2_new", objResponse, "--Todos--");
                });
            }
        }
        function fn_CargarPersonal() {
            if ($("#cboPlanilla_Bus").val() == "" || $("#cboEjercicio_Bus").val() == "") {
                this.fc_FillCombo("cboPersonal_Bus", "", "--Todos--");
                this.fc_FillCombo("cboPersonal_new", "", "--Todos--");
            }
            else {
                var parametros = new Object();
                parametros.co_Ejercicio = $("#cboEjercicio_Bus").val();
                parametros.co_Planilla = $("#cboPlanilla_Bus").val();
                parametros.co_Periodo = $("#cboPeriodo_Bus").val();
                parametros.co_Area = $("#cboLocalidad_Bus").val();
                parametros.co_catAuxiliar = $("#cboCatAuxiliar_Bus").val();
                parametros.co_catAuxiliar2 = $("#cboCatAuxiliar2_Bus").val();
                //20190701
                parametros.co_Proyecto = $("#cboProyecto_Bus").val();
                var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
                var strUrlServicio = pagePath + "/Get_Personal";
                this.fc_CallService(strParametros, strUrlServicio, function (objResponse) {
                    this.fc_FillCombo("cboPersonal_Bus", objResponse, "--Todos--");
                    this.fc_FillCombo("cboPersonal_new", objResponse, "--Todos--");
                });
            }
        }

        /***********************************/

        function fn_CargarPeriodo_new() {
            if ($("#cboPlanilla_new").val() == "" || $("#cboEjercicio_new").val() == "") {
                this.fc_FillCombo("cboPeriodo_new", "", "--Seleccione--");
            }
            else {
                var parametros = new Object();
                parametros.co_planilla = $("#cboPlanilla_new").val();
                parametros.co_ejercicio = $("#cboEjercicio_new").val();
                var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
                var strUrlServicio = pagePath + "/Get_Periodo";
                this.fc_CallService(strParametros, strUrlServicio, function (objResponse) {
                    this.fc_FillCombo("cboPeriodo_new", objResponse, "--Seleccione--");
                });
            }
        }
        function fn_CargarCatAuxiliar2_new() {
            if ($("#cboCatAuxiliar_new").val() == "") {
                this.fc_FillCombo("cboCatAuxiliar2_new", "", "--Todos--");
            }
            else {
                var parametros = new Object();
                parametros.co_catAuxiliar = $("#cboCatAuxiliar_new").val();
                var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
                var strUrlServicio = pagePath + "/Get_CatAuxiliar2";
                this.fc_CallService(strParametros, strUrlServicio, function (objResponse) {
                    this.fc_FillCombo("cboCatAuxiliar2_new", objResponse, "--Todos--");
                });
            }
        }


        function fn_CargarPersonal_new() {
            if ($("#cboPlanilla_new").val() == "" || $("#cboEjercicio_new").val() == "") {
                this.fc_FillCombo("cboPersonal_new", "", "--Todos--");
            }
            else {
                var parametros = new Object();
                parametros.co_Ejercicio = $("#cboEjercicio_new").val();
                parametros.co_Planilla = $("#cboPlanilla_new").val();
                parametros.co_Periodo = $("#cboPeriodo_new").val();
                parametros.co_Area = $("#cboLocalidad_new").val();
                parametros.co_catAuxiliar = $("#cboCatAuxiliar_new").val();
                parametros.co_catAuxiliar2 = $("#cboCatAuxiliar2_new").val();
                //20190701
                parametros.co_Proyecto = $("#cboProyecto_new").val();
                var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
                var strUrlServicio = pagePath + "/Get_Personal";
                this.fc_CallService(strParametros, strUrlServicio, function (objResponse) {
                    this.fc_FillCombo("cboPersonal_new", objResponse, "--Todos--");
                });
            }
        }


        /**********************************/

        function fn_Buscar() {
            var msg_retorno = "";
            if ($("#cboPlanilla_Bus").val() == "") msg_retorno += "- Debe seleccionar planilla.\n";
            if ($("#cboEjercicio_Bus").val() == "") msg_retorno += "- Debe seleccionar ejercicio.\n";
            //if ($("#cboPeriodo_Bus").val() == "") msg_retorno += "- Debe seleccionar periodo.\n";
            if ($("#txtFec_Desde").val() == "" && $("#txtFec_Hasta").val() != "") msg_retorno += "- Debe seleccionar fecha inicio.\n";
            if ($("#txtFec_Desde").val() != "" && $("#txtFec_Hasta").val() == "") msg_retorno += "- Debe seleccionar fecha final.\n";

            if (msg_retorno != "") alert(msg_retorno);
            else {
                var parametros = new Object();
                parametros.co_planilla = $("#cboPlanilla_Bus").val();
                parametros.co_ejercicio = $("#cboEjercicio_Bus").val();
                parametros.co_periodo = $("#cboPeriodo_Bus").val();
                parametros.id_localidad = $("#cboLocalidad_Bus").val();
                parametros.id_cat_aux = $("#cboCatAuxiliar_Bus").val();
                parametros.id_cat_aux2 = $("#cboCatAuxiliar2_Bus").val();
                parametros.id_proyecto = $("#cboProyecto_Bus").val();
                parametros.id_persona = $("#cboPersonal_Bus").val();
                parametros.id_documento = $("#cboDocumento_Bus").val();
                parametros.fec_inicial = $("#txtFec_Desde").val();
                parametros.fec_final = $("#txtFec_Hasta").val();

                var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
                var strUrlServicio = pagePath + "/Get_GrillaHistorialEnvio";
                this.fc_CallService(strParametros, strUrlServicio, function (objResponse) {
                    var JQGrid_Opciones = this.JQGrid_Opciones_Default;
                    JQGrid_Opciones.fl_paginar = false;
                    JQGrid_Opciones.height = 300;
                    JQGrid_Opciones.grouping = true;
                    this.JQGrid_Util.GetTabla_Local(idGrilla_Bandeja, idPieGrilla_Bandeja, strCabecera_Bandeja, ModelCol_Bandeja
                        , JQGrid_Opciones, objResponse, function () { }, function () { }, function () { });

                    // fn_SetGrupoCabecera();
                });
            }
        }
        function fn_genDocumento(token_envio) {
            window.open("GenDocumentoOnline.aspx?c=" + token_envio);
        }
        function fn_GetEnviarDocumento() {
            if (confirm("¿Está seguro de enviar el documento?")) {
                var msg = "";
                if (fc_Trim($("#cboEjercicio_new").val()) == "") { msg += "Seleccionar ejercicio.\n"; }
                if (fc_Trim($("#cboPeriodo_new").val()) == "") { msg += "Seleccionar periodo.\n"; }
                //if (fc_Trim($("#cboLocalidad_new").val()) == "") { msg += "Seleccionar localidad.\n"; }
                if (fc_Trim($("#cboProceso").val()) == "") { msg += "Seleccionar proceso.\n"; }
                if (fc_Trim($("#ddlTipoDocumento").val()) == "") { msg += "Seleccionar tipo de documento.\n"; }

                var rowIDs = this.JQGrid_Util.getRowIDsSelected(idGrilla_Bandeja_new);
                if (rowIDs.length <= 0) { msg += "Debe seleccionar al menos un personal.\n"; }

                if (msg != "") {
                    alert(msg);
                    return false;
                }

                var Personal_Ids = new Array();
                for (var i = 0; i < rowIDs.length; i++) {
                    var rowID = rowIDs[i];
                    var rowData = this.JQGrid_Util.getRowData(idGrilla_Bandeja_new, rowID);
                    if (fc_Trim(rowData.email_personal) == "") {
                        alert("Solo debe seleccionar personales con email.");
                        return false;
                    }
                    Personal_Ids[i] = rowData.Personal_Id;
                }

                var reporte = ""; var urlpath = "";
                var seldocumento = $("#ddlTipoDocumento").val();
                if (seldocumento == "BP") { reporte = "0001"; urlpath = "Get_ImprimeBoleta"; };
                if (seldocumento == "CTS") { reporte = "0002"; urlpath = "Get_ImprimeCTS"; };
                if (seldocumento == "CUTIL") { reporte = "0003"; urlpath = "Get_ImprimeUtilidad"; };
                if (seldocumento == "CQTA") { reporte = "0004"; urlpath = "Get_ImprimeQuinta"; };
                //imprime docuemnto
                if (seldocumento == "CBC") { reporte = ""; urlpath = "Get_ImprimeBancoCTS"; };
                if (seldocumento == "CT") { reporte = ""; urlpath = "Get_ImprimeCertTrabajo"; };
                if (seldocumento == "CL2") { reporte = ""; urlpath = "Get_ImprimeLiquida2"; };

                var parametros = new Array();
                parametros[0] = reporte;
                parametros[1] = "000001";
                parametros[2] = $("#cboPeriodo_new").val();
                parametros[3] = $("#cboProceso").val();
                parametros[4] = Personal_Ids;
                parametros[5] = ""; //NO SE USA
                parametros[6] = $("#cboEjercicio_new").val();
                parametros[7] = seldocumento;
                parametros[8] = $("#cboPeriodo_new option:selected").html();
                parametros[9] = ($("#chkDolares").prop("checked") ? "1" : "0");
                parametros[10] = ($("#chkAddTotalUSD").prop("checked") ? "1" : "0");
                parametros[11] = $("#cboPeriodo_Desde").val();
                parametros[12] = $("#ddlGuardarArchivo").val();
                var strParametros = { strParametros: parametros };
                var strUrlServicio = pagePath + "/" + urlpath;
                this.fn_CallService(strUrlServicio, true, JSON.stringify(strParametros), function (objResponse) {
                    var rpt = objResponse.d;
                    if (rpt != "") {
                        alert("A los siguientes trabajadores no se le pudo enviar el documento.\n" + rpt);
                        fn_Buscar_Destinos();
                        return;
                    }
                    else {
                        alert("Documentos enviados correctamente.");

                        var parametros = new Object();
                        parametros.co_planilla = $("#cboPlanilla_Bus").val();
                        parametros.co_ejercicio = $("#cboEjercicio_Bus").val();
                        parametros.co_periodo = $("#cboPeriodo_Bus").val();
                        parametros.id_localidad = $("#cboLocalidad_Bus").val();
                        parametros.id_cat_aux = $("#cboCatAuxiliar_Bus").val();
                        parametros.id_cat_aux2 = $("#cboCatAuxiliar2_Bus").val();
                        parametros.id_proyecto = $("#cboProyecto_Bus").val();
                        parametros.id_persona = $("#cboPersonal_Bus").val();
                        parametros.id_documento = $("#cboDocumento_Bus").val();
                        parametros.fec_inicial = $("#txtFec_Desde").val();
                        parametros.fec_final = $("#txtFec_Hasta").val();

                        var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
                        var strUrlServicio = pagePath + "/Get_GrillaHistorialEnvio";
                        this.fc_CallService(strParametros, strUrlServicio, function (objResponse) {
                            var JQGrid_Opciones = this.JQGrid_Opciones_Default;
                            JQGrid_Opciones.fl_paginar = false;
                            JQGrid_Opciones.height = 300;
                            JQGrid_Opciones.grouping = true;
                            this.JQGrid_Util.GetTabla_Local(idGrilla_Bandeja, idPieGrilla_Bandeja, strCabecera_Bandeja, ModelCol_Bandeja
                                , JQGrid_Opciones, objResponse, function () { }, function () { }, function () { });
                            $("#dialog-confirm").dialog("close");
                            fn_LimpiarEnvio();
                        });
                    }
                });
            }
        }
        function fn_LimpiarEnvio() {
            var strParametros = "";
            var strUrlServicio = pagePath + "/Get_Combos";
            this.fc_CallService(strParametros, strUrlServicio, function (objResponse) {
                this.fc_FillCombo("cboPlanilla_new", objResponse.oPlanilla, "--Seleccione--");
                this.fc_FillCombo("cboEjercicio_new", objResponse.oEjercicio, "--Seleccione--");
                $("#cboEjercicio_new").prop('selectedIndex', objResponse.oEjercicio.length);
                this.fc_FillCombo("cboLocalidad_new", objResponse.oLocalidad, "--Todos--");
                this.fc_FillCombo("cboCatAuxiliar_new", objResponse.oCatAuxiliar, "--Todos--");
            });

            var objResponse = [];
            this.JQGrid_Util.GetTabla_Local(idGrilla_Bandeja_new, idPieGrilla_Bandeja_new, strCabecera_Bandeja_new, ModelCol_Bandeja_new
                , JQGrid_Opciones_Default, objResponse, function () { }, function () { }, function () { });

        }
        function fn_GetFormatoFecha(fecha) {
            var FechaFormat = fecha;
            if (fecha == null) { return ""; }
            var value = new Date
                (
                parseInt(FechaFormat.replace(/(^.*\()|([+-].*$)/g, ''))
                );
            var mes = value.getMonth() + 1
            var dia = value.getDate()
            var anio = value.getFullYear();

            mes = ("0" + mes).slice(-2);
            dia = ("0" + dia).slice(-2);
            return anio + "-" + mes + "-" + dia;
        }
        function fn_Buscar_Destinos() {
            var msg = "";
            if (fc_Trim($("#cboPlanilla_new").val()) == "") { msg += "Seleccionar planilla.\n"; }
            if (fc_Trim($("#cboEjercicio_new").val()) == "") { msg += "Seleccionar ejercicio.\n"; }
            if (fc_Trim($("#cboPeriodo_new").val()) == "") { msg += "Seleccionar periodo.\n"; }
            //if (fc_Trim($("#cboLocalidad_new").val()) == "") { msg += "Seleccionar localidad.\n"; }
            if (fc_Trim($("#cboProceso").val()) == "") { msg += "Seleccionar proceso.\n"; }
            if (fc_Trim($("#ddlTipoDocumento").val()) == "") { msg += "Seleccionar tipo documento.\n"; }

            if (msg != "") {
                alert(msg);
                return false;
            }

            var parametros = new Object();
            parametros.id_personal = $("#cboPersonal_new").val();
            parametros.Periodo_Id = $("#cboPeriodo_new").val();
            parametros.Planilla_Id = $("#cboPlanilla_new").val();
            parametros.Localidad_Id = $("#cboLocalidad_new").val();
            parametros.Cat_Auxiliar_Id = $("#cboCatAuxiliar_new").val();
            parametros.Cat_Auxiliar2_Id = $("#cboCatAuxiliar2_new").val();
            parametros.Proyecto_Id = $("#cboProyecto_new").val();
            parametros.id_proceso = $("#cboProceso").val();
            parametros.id_documento = $("#ddlTipoDocumento").val();
            parametros.fl_personal_sin_envios = ($("#chkPersonalSinEnvio").prop("checked") ? "1" : "0");
            parametros.fl_personal_con_correo = ($("#chkPersonalConCorreo").prop("checked") ? "1" : "0");

            var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
            var strUrlServicio = pagePath + "/Get_GrillaPersonal";
            this.fc_CallService(strParametros, strUrlServicio, function (objResponse) {
                var JQGrid_Opciones = this.JQGrid_Opciones_Default;
                JQGrid_Opciones.fl_paginar = false;
                JQGrid_Opciones.height = 250;
                JQGrid_Opciones.grouping = true;
                JQGrid_Opciones.fl_multiselect = true;
                this.JQGrid_Util.GetTabla_Local(idGrilla_Bandeja_new, idPieGrilla_Bandeja_new, strCabecera_Bandeja_new, ModelCol_Bandeja_new
                    , JQGrid_Opciones, objResponse, function () { }, function () { }, function () { });

            });

        }

        function fn_ImprimirReporte() {
            var msg_retorno = "";
            if ($("#cboPlanilla_Bus").val() == "") msg_retorno += "- Debe seleccionar planilla.\n";
            if ($("#cboEjercicio_Bus").val() == "") msg_retorno += "- Debe seleccionar ejercicio.\n";
            //if ($("#cboPeriodo_Bus").val() == "") msg_retorno += "- Debe seleccionar periodo.\n";
            if ($("#txtFec_Desde").val() == "" && $("#txtFec_Hasta").val() != "") msg_retorno += "- Debe seleccionar fecha inicio.\n";
            if ($("#txtFec_Desde").val() != "" && $("#txtFec_Hasta").val() == "") msg_retorno += "- Debe seleccionar fecha final.\n";

            if (msg_retorno != "") alert(msg_retorno);
            else {
                var parametros = $("#cboPlanilla_Bus").val()
                    + ":" + $("#cboEjercicio_Bus").val()
                    + ":" + $("#cboPeriodo_Bus").val()
                    + ":" + $("#cboLocalidad_Bus").val()
                    + ":" + $("#cboCatAuxiliar_Bus").val()
                    + ":" + $("#cboCatAuxiliar2_Bus").val()
                    + ":" + $("#cboPersonal_Bus").val()
                    + ":" + $("#cboDocumento_Bus").val()
                    + ":" + $("#txtFec_Desde").val()
                    + ":" + $("#txtFec_Hasta").val()

                fn_OpenReport("REP_DOCUMENTO_ENVIO", parametros, "1");
            }
        }

        function fn_OpenReport(e, t, r) { var o = "750"; "1" == r && (o = "1050"); var a = "../Reportes/FrmPrint.aspx?Reporte_Id=" + e + "&prm=" + t; window.open(a, "_blank", "status=1,toolbar=no,menubar=no,location=no,scrollbars=1,resizable=1,width=" + o + ",height=600") }

        function fn_GenerarNuevoEnvio() {
            $("#cboPlanilla_new").val($("#cboPlanilla_Bus").val());
            $("#cboEjercicio_new").val($("#cboEjercicio_Bus").val());
            $("#cboPeriodo_new").val($("#cboPeriodo_Bus").val());
            $("#cboLocalidad_new").val($("#cboLocalidad_Bus").val());
            $("#cboCatAuxiliar_new").val($("#cboCatAuxiliar_Bus").val());
            $("#cboCatAuxiliar2_new").val($("#cboCatAuxiliar2_Bus").val());
            $("#cboPersonal_new").val($("#cboPersonal_Bus").val());
            $("#chkPersonalSinEnvio").prop("checked", true);
            $("#chkPersonalConCorreo").prop("checked", true);
            $("#ddlGuardarArchivo").val("0"); //En línea

            $("#ddlTipoDocumento").trigger("change");

            $("#dialog-confirm").dialog({
                resizable: false,
                height: 590,
                width: 800,
                modal: true,
                buttons: {
                    Cancelar: function () {
                        $(this).dialog("close");
                    }
                }
            });

        }

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

