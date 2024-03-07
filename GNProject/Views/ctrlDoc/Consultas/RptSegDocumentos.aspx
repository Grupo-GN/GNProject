<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="RptSegDocumentos.aspx.cs" Inherits="GNProject.Views.ctrlDoc.Consultas.RptSegDocumentos" %>
<%@ Import Namespace="GNProject.Acceso" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="pagina1">
        <div class="row linea-bottom">
            <div class="col l6 s12 titulo">Reporte de Seguimiento de Documentos</div>
            <div class="col l6 s12" style="text-align: right;">
                <button id="btnBuscar" type="button" onclick="fn_Buscar();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/Busqueda-48.png" />Buscar</button>
                <button type="button" onclick="fn_Limpiar();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/Escoba-48.png" />Limpiar</button>
                <button type="button" onclick="fn_VerReporte();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/Reporte-48.png" />Ver Reporte</button>
                <button type="button" onclick="fn_VerReporteDetallado();" style="background: none; padding: 0 0 0 10px; border: none; width:90px;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/Reporte-48.png" />Ver Reporte Detallado</button>
            </div>
        </div>
        <div class="row titulo_section">
            Filtros de búsqueda
        </div>
        <div class="row">
            <div class="col l3 m6 s12">
                <span>Grupo</span>
                <select id="cboGrupoDocumento_Busqueda" class="control-form"></select>
            </div>
            <div class="col l3 m6 s12">
                <span>Sub Grupo</span>
                <select id="cboSubGrupoDocumento_Busqueda" class="control-form"></select>
            </div>
            <div class="col l3 m6 s12">
                <span>Plantilla</span>
                <select id="cboPlantillaDocumento_Busqueda" class="control-form"></select>
            </div>
            <div class="col l3 m6 s12">
                <span>Nombre Documento</span>
                <input id="txtNomDocumento_Busqueda" type="text" class="control-form" />
            </div>
        </div>
        <div class="row">
            <div class="col l3 m6 s12">
                <span>Tipo Asignación</span>
                <select id="cboTipoAsignacion_Busqueda" class="control-form"></select>
            </div>
            <div class="col l3 m6 s12">
                <span><%=Parametros.CDOC_Texto_Area%></span>
                <select id="cboArea_Busqueda" class="control-form"></select>
            </div>
            <div class="col l3 m6 s12">
                <span><%=Parametros.CDOC_Texto_Seccion%></span>
                <select id="cboSeccion_Busqueda" class="control-form">
                    <option value="" selected="selected"><%=Parametros.OBJECTO_TODOS%></option>
                </select>
            </div>
            <div class="col l3 m6 s12">
                <span>Personal / Empresa</span>
                <select id="cboPersona_Empresa_Busqueda" class="control-form"></select>
            </div>
        </div>
        <div class="row">
            <div class="col l3 m6 s12">
                <span>Estado</span>
                <select id="cboEstado_Busqueda" class="control-form">
                </select>
            </div>
            <div class="col l3 m6 s12">
                <span>Fec. Vencimiento</span>
                <div>
                    <input id="txtFecVencimiento_Desde" type="text" class="control-form" />
                    a
                    <input id="txtFecVencimiento_Hasta" type="text" class="control-form" />
                </div>
            </div>
            <div class="col l3 m6 s12">
                <span>Tipo Documento</span>
                <select id="cboTipoDoc_Busqueda" class="control-form"></select>
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
                Documento
            </div>
            <div class="col l8 s12" style="text-align: right;">
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
            <div class="col l3 m6 s12">
                <span>Grupo</span>
                <select id="cboGrupoDocumento" class="control-form" disabled="disabled"></select>
            </div>
            <div class="col l3 m6 s12">
                <span>Sub Grupo</span>
                <select id="cboSubGrupoDocumento" class="control-form" disabled="disabled"></select>
            </div>
            <div class="col l3 m6 s12">
                <span>Plantilla Documento</span>
                <select id="cboPlantillaDocumento" class="control-form" disabled="disabled"></select>
            </div>
            <div class="col l3 m6 s12">
                <span>Tipo Asignación</span>
                <select id="cboTipoAsignacion" class="control-form" disabled="disabled"></select>
            </div>
        </div>
        <div class="row">
            <div class="col l3 m6 s12">
                <span>Personal / Empresa</span>
                <select id="cboPersona_Empresa" class="control-form" disabled="disabled"></select>
            </div>
            <div class="col l3 m6 s12">
                <span>Nombre Documento</span>
                <input id="txtNomDocumento" type="text" class="control-form" disabled="disabled" />
            </div>
            <div class="col l3 m6 s12">
                <span id="lblFecInicio">Fec. Inicio</span>
                <div>
                    <input id="txtFecInicio" type="text" class="control-form" disabled="disabled" style="width:80px;" />
                </div>
            </div>
            <div class="col l3 m6 s12">
                <span>Fec. Vencimiento</span>
                <div>
                    <input id="txtFecVencimiento" type="text" class="control-form" disabled="disabled" style="width:80px;" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col l3 m6 s12">
                <span>Estado</span>
                <select id="cboEstado" class="control-form"></select>
            </div>
            <div class="col l3 m6 s12">
                <span>Reservado</span>
                <input id="chkReservado" type="checkbox" disabled="disabled" />
            </div>
        </div>
        <div class="row">
            <div class="col l4 s12 titulo_section">
                Archivos Asociados
            </div>
            <div class="col l8 s12" style="text-align: right;">
            </div>
        </div>
        <div class="row" style="padding-right: 10px;">
            <div class="col l12">
                <table id="grvFiles">
                </table>
                <div id="grvFiles_Pie">
                </div>
            </div>
        </div>
        <div class="row titulo_section">
            Características
        </div>
        <div class="row" style="padding-right: 10px;">
            <div class="col l12">
                <table id="grvCaracteristica">
                </table>
                <div id="grvCaracteristica_Pie">
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        var objEstadosDoc;
        var objEstadosDoc_NuevoReg;
        //#region - Variables Grilla Bandeja
        var idGrilla_Bandeja = "#grvBandeja";
        var idPieGrilla_Bandeja = "#grvBandeja_Pie";
        var strCabecera_Bandeja = ['ID', 'Grupo', 'Sub Grupo', 'Plantilla', 'Documento', 'Fec. Inicio', 'Fec. Vencimiento', 'Días para Vencimiento', 'Tipo Asignación', 'Personal / Empresa', 'Id Plantilla', 'CodEstado', 'Estado'];
        var ModelCol_Bandeja = [
                            { name: 'id_documento', index: 'id_documento', width: 40, sorttype: 'number', sortable: true, align: 'center', hidden: true },
                            { name: 'no_grupo_doc', index: 'no_grupo_doc', width: 120, sortable: true },
                            { name: 'no_sub_grupo_doc', index: 'no_sub_grupo_doc', width: 120, sortable: true },
                            { name: 'no_plantilla_doc', index: 'no_plantilla_doc', width: 150, sortable: true },
                            { name: 'no_documento', index: 'no_documento', width: 280, sortable: true },
                            { name: 'fe_inicio', index: 'fe_inicio', width: 70, sortable: true, align: 'center' },
                            { name: 'fe_vencimiento', index: 'fe_vencimiento', width: 70, sortable: true, align: 'center' },
                            { name: 'qt_dias_para_vencimiento', index: 'qt_dias_para_vencimiento', width: 70, sortable: true, align: 'center' },
                            { name: 'no_tipo_asignacion', index: 'no_tipo_asignacion', width: 90, sortable: true, align: 'center' },
                            { name: 'no_persona_empresa', index: 'no_persona_empresa', width: 200, sortable: true },
                            { name: 'id_plantilla_doc', index: 'id_plantilla_doc', hidden: true },
                            { name: 'co_estado', index: 'co_estado', hidden: true },
                            { name: 'no_estado', index: 'no_estado', width: 70, sortable: true, align: 'center' }
        ];
        //#endregion - Variables Grilla Bandeja
        //#region - Variables Grilla Bandeja Files
        var objDatosFiles = new Array();
        var idGrilla_Files = "#grvFiles";
        var idPieGrilla_Files = "#grvFiles_Pie";
        var strCabecera_Files = ['ID', 'Tipo Documento', 'Nombre', 'Archivo', 'Peso KB', 'no_folder', 'no_file_all', 'Activar Alerta', 'Fec. Inicio', 'Fec. Vencimiento', 'Estado'];
        var ModelCol_Files = [
                    { name: 'id_documento_file', index: 'id_documento_file', hidden: true },
                    { name: 'no_tipo_doc', index: 'no_tipo_doc', width: 100, sortable: false, align: 'center' },
                    { name: 'no_documento', index: 'no_documento', width: 300, sortable: false },
                    { name: 'no_file', index: 'no_file', width: 100, sortable: false, formatter: fn_linkformat, align: 'center' },
                    { name: 'qt_peso', index: 'qt_peso', width: 100, sortable: false, hidden: true },
                    { name: 'no_folder', index: 'no_folder', hidden: true },
                    { name: 'no_file_all', index: 'no_file_all', hidden: true },
                    { name: 'fl_activar_alerta', index: 'fl_activar_alerta', width: 100, sortable: false, align: 'center', hidden: true },
                    { name: 'sfe_inicio', index: 'sfe_inicio', width: 100, sortable: false, align: 'center' },
                    { name: 'sfe_vencimiento', index: 'sfe_vencimiento', width: 100, sortable: false, align: 'center' },
                    { name: 'no_estado', index: 'no_estado', width: 100, sortable: false, align: 'center' }
        ];
        var nameGroupField_Files = "no_tipo_doc";
        //#endregion - Variables Grilla Bandeja Files
        /*#region - Variables Grilla Bandeja Caracteristicas*/
        var objDatosCaracteristicas = new Array();
        var idGrilla_Caracteristica = "#grvCaracteristica";
        var idPieGrilla_Caracteristica = "#grvCaracteristica_Pie";
        var strCabecera_Caracteristica = ['ID', 'N°', 'Característica', 'Tipo Dato', 'Valor Dato', 'Archivo', 'Obligatorio'];
        var ModelCol_Caracteristica = [
                        { name: 'id_documento_caracteristica', index: 'id_documento_caracteristica', width: 40, sortable: false, hidden: true },
                        { name: 'nu_orden', index: 'nu_orden', width: 40, sortable: false, align: 'center', hidden: true },
                        { name: 'no_caracteristica', index: 'no_caracteristica', width: 250, sortable: false },
                        { name: 'co_tipo_dato', index: 'co_tipo_dato', sortable: false, hidden: true },
                        {
                            name: 'no_valor_dato', index: 'no_valor_dato', width: 250, sortable: false, editable: false
                        },
                        {
                            hidden: true, name: 'no_archivo', index: 'no_archivo', sortable: false, editable: false
                            , formatter: inputFileFormat, unformat: inputFileUnFormat
                        },
                        { name: 'txt_obligatorio', index: 'txt_obligatorio', width: 80, sortable: false, align: 'center' }
        ];
        /*#endregion - Variables Grilla Bandeja Caracteristicas*/

        $("#cboGrupoDocumento_Busqueda").change(function (event) {
            var value = $(this).val();
            var sendInfo = "{'codigo':'<%=Parametros.Combo.CDOC_SubGruposDocumento %>', 'co_padre':'" + value + "'}";
            var urlService = "/wsGenerales.asmx/getCombo";
            fc_CallService(sendInfo, urlService, function (objResponse) {
                this.fc_FillCombo("cboSubGrupoDocumento_Busqueda", objResponse, textTodos);
                $("#cboSubGrupoDocumento_Busqueda").trigger("change");
            });
        });

        $("#cboSubGrupoDocumento_Busqueda").change(function (event) {
            var value = $(this).val();
            var sendInfo = "{'codigo':'<%=Parametros.Combo.PLANTILLA_DOCUMENTOS %>', 'co_padre':'" + value + "'}";
            var urlService = "/wsGenerales.asmx/getCombo";
            fc_CallService(sendInfo, urlService, function (objResponse) {
                this.fc_FillCombo("cboPlantillaDocumento_Busqueda", objResponse, textTodos);
            });
        });

        $("#cboTipoAsignacion_Busqueda").change(function (event) {
            var value = $(this).val();

            $("#cboArea_Busqueda").val("").prop("disabled", true);
            $("#cboSeccion_Busqueda").val("").prop("disabled", true);

            if (value == "") {
                fc_FillCombo("cboPersona_Empresa_Busqueda", [], textTodos);
                $("#cboPersona_Empresa_Busqueda option[value='']").remove();
                $("#cboPersona_Empresa_Busqueda").multipleSelect("refresh");
            }
            else {

                if (value == "00") { //PERSONAL
                    $("#cboArea_Busqueda").prop("disabled", false);
                    $("#cboSeccion_Busqueda").prop("disabled", false);
                }

                //lista todos
                var sendInfo = "{'codigo':'<%=Parametros.Combo.PERSONA_EMPRESA %>', 'co_padre':'" + value + "'}";
                var urlService = "/wsGenerales.asmx/getCombo";
                fc_CallService(sendInfo, urlService, function (objResponse) {
                    this.fc_FillCombo("cboPersona_Empresa_Busqueda", objResponse, textTodos);
                    $("#cboPersona_Empresa_Busqueda option[value='']").remove();
                    $("#cboPersona_Empresa_Busqueda").multipleSelect("refresh");
                });
            }
        });

        $("#cboArea_Busqueda").change(function (event) {
            $("#cboSeccion_Busqueda").empty();
            var value = $(this).val();
            switch (value) {
                case "":
                    $("#cboSeccion_Busqueda").append("<option value=''>" + textTodos + "</option>");
                    $("#cboSeccion_Busqueda").trigger("change");
                    break;
                default:
                    var strFiltros = "{'codigo':'<%=Parametros.Combo.SECCION %>'"
                        + ",'co_padre': '" + value + "'}";
                    var strUrlServicio = "/wsGenerales.asmx/getCombo";
                    fc_CallService(strFiltros, strUrlServicio, function (res) {
                        fc_FillCombo("cboSeccion_Busqueda", res, textTodos);
                        $("#cboSeccion_Busqueda").trigger("change");
                    });
                    break;
            }
        });

        $("#cboSeccion_Busqueda").change(function (event) {
            var value = $(this).val();
            var idArea = $("#cboArea_Busqueda").val();

            var prmXML = '<prm IDArea="' + idArea + '" IDSeccion="' + value + '" />';
            var sendInfo = "{'codigo':'<%=Parametros.Combo.PERSONA %>', 'co_padre':'" + prmXML + "'}";
            var urlService = "/wsGenerales.asmx/getCombo";
            fc_CallService(sendInfo, urlService, function (objResponse) {
                this.fc_FillCombo("cboPersona_Empresa_Busqueda", objResponse, textTodos);
                $("#cboPersona_Empresa_Busqueda option[value='']").remove();
                $("#cboPersona_Empresa_Busqueda").multipleSelect("refresh");
            });
        });

        fn_Iniciar();
        function fn_Iniciar() {
            $("#cboGrupoDocumento_Busqueda").keydown(function (event) {
                fc_PressKey(13, 'btnBuscar');
            });
            $("#cboSubGrupoDocumento_Busqueda").keydown(function (event) {
                fc_PressKey(13, 'btnBuscar');
            });
            $("#cboPlantillaDocumento_Busqueda").keydown(function (event) {
                fc_PressKey(13, 'btnBuscar');
            });
            $("#txtNomDocumento_Busqueda").keydown(function (event) {
                fc_PressKey(13, 'btnBuscar');
            });
            $("#cboTipoAsignacion_Busqueda").keydown(function (event) {
                fc_PressKey(13, 'btnBuscar');
            });
            $("#cboPersona_Empresa_Busqueda").keydown(function (event) {
                fc_PressKey(13, 'btnBuscar');
            });
            $("#cboEstado_Busqueda").keydown(function (event) {
                fc_PressKey(13, 'btnBuscar');
            });
            $("#txtFecVencimiento_Desde").keydown(function (event) {
                fc_PressKey(13, 'btnBuscar');
            });
            $("#txtFecVencimiento_Hasta").keydown(function (event) {
                fc_PressKey(13, 'btnBuscar');
            });
            $("#cboArea_Busqueda").keydown(function (event) {
                fc_PressKey(13, 'btnBuscar');
            });
            $("#cboSeccion_Busqueda").keydown(function (event) {
                fc_PressKey(13, 'btnBuscar');
            });
            $("#cboTipoDoc_Busqueda").keydown(function (event) {
                fc_PressKey(13, 'btnBuscar');
            });
            
            DatePicker_Opciones_Default.fl_changeMonth = true;
            DatePicker_Opciones_Default.fl_changeYear = true;
            this.fc_FormatFecha("txtFecVencimiento_Desde", DatePicker_Opciones_Default, "MIN", "txtFecVencimiento_Hasta");
            this.fc_FormatFecha("txtFecVencimiento_Hasta", DatePicker_Opciones_Default, "MAX", "txtFecVencimiento_Desde");

            var sendInfo = "{'codigo':'<%=Parametros.Combo.CDOC_GruposDocumento %>'"
            + ",'co_padre': ''}";
            var urlService = "/wsGenerales.asmx/getCombo";
            this.fc_CallService(sendInfo, urlService, function (objResponse) {
                this.fc_FillCombo("cboGrupoDocumento_Busqueda", objResponse, textTodos);
                $("#cboGrupoDocumento_Busqueda").trigger("change");

                this.fc_FillCombo("cboGrupoDocumento", objResponse, textSeleccione);
            });

            var sendInfo = "{'codigo':'<%=Parametros.Combo.TIPO_ASIGNACION %>'"
                + ",'co_padre': ''}";
            var urlService = "/wsGenerales.asmx/getCombo";
            this.fc_CallService(sendInfo, urlService, function (objResponse) {
                $("#cboPersona_Empresa_Busqueda").multipleSelect({ filter: true });

                this.fc_FillCombo("cboTipoAsignacion_Busqueda", objResponse, textTodos);
                $("#cboTipoAsignacion_Busqueda").trigger("change");

                this.fc_FillCombo("cboTipoAsignacion", objResponse, textSeleccione);
                $("#cboTipoAsignacion").trigger("change");
            });

            var parametros = "{'codigo':'<%=Parametros.Combo.AREAS %>', 'co_padre':''}";
            var urlService = "/wsGenerales.asmx/getCombo";
            this.fc_CallService(parametros, urlService, function (objResponse) {
                this.fc_FillCombo("cboArea_Busqueda", objResponse, textTodos);
            });

            var parametros = "{'codigo':'<%=Parametros.Combo.ESTADOS_DOC_REP %>', 'co_padre':''}";
            var urlService = "/wsGenerales.asmx/getCombo";
            this.fc_CallService(parametros, urlService, function (objResponse) {
                this.fc_FillCombo("cboEstado_Busqueda", objResponse, textTodos);
                $("#cboEstado_Busqueda option[value='']").remove();
                $("#cboEstado_Busqueda").multipleSelect();
                $("#cboEstado_Busqueda").multipleSelect("checkAll");

                objEstadosDoc = objResponse;
                objEstadosDoc_NuevoReg = new Array();
                $.each(objEstadosDoc, function (index, obj) {
                    if (obj.value == "01" || obj.value == "02" || obj.value == "05") {
                        objEstadosDoc_NuevoReg.push({ "value": obj.value, "nombre": obj.nombre });
                    }
                });
            });

            var parametros = "{'codigo':'<%=Parametros.Combo.CDOC_TipoDoc_Archivos %>', 'co_padre':''}";
            var urlService = "/wsGenerales.asmx/getCombo";
            this.fc_CallService(parametros, urlService, function (objResponse) {
                this.fc_FillCombo("cboTipoDoc_Busqueda", objResponse, textTodos);
                $("#cboTipoDoc_Busqueda option[value='']").remove();
                $("#cboTipoDoc_Busqueda").multipleSelect();
            });

            var objResponse = [];
            JQGrid_Util.AutoWidthResponsive(idGrilla_Bandeja);
            JQGrid_Util.AutoWidthResponsive(idGrilla_Caracteristica);
            JQGrid_Util.AutoWidthResponsive(idGrilla_Files);
            JQGrid_Util.GetTabla_Local(idGrilla_Bandeja, idPieGrilla_Bandeja, strCabecera_Bandeja, ModelCol_Bandeja, JQGrid_Opciones_Default, objResponse, function () { }, function () { }, function () { });
        }

        function fn_Limpiar() {
            $("#cboGrupoDocumento_Busqueda").val("").trigger("change");
            $("#txtNomDocumento_Busqueda").val("");
            $("#cboTipoAsignacion_Busqueda").val("").trigger("change");
            $("#cboEstado_Busqueda").multipleSelect("checkAll");
            $("#txtFecVencimiento_Desde").val("");
            $("#txtFecVencimiento_Hasta").val("");
            $("#cboTipoDoc_Busqueda").multipleSelect("uncheckAll");
            JQGrid_Util.clearData(idGrilla_Bandeja);
        }
        function fn_Buscar() {
            var msg_retorno = "";
            var sfe_vencimiento_desde = fc_Trim($("#txtFecVencimiento_Desde").val());
            var sfe_vencimiento_hasta = fc_Trim($("#txtFecVencimiento_Hasta").val());

            if (sfe_vencimiento_desde != "" && this.fc_ValidarFecha(sfe_vencimiento_desde) == false) {
                msg_retorno += "- Fecha vencimiento desde incorrecto (dd/MM/yyyy).\n";
            }
            if (sfe_vencimiento_hasta != "" && this.fc_ValidarFecha(sfe_vencimiento_hasta) == false) {
                msg_retorno += "- Fecha vencimiento hasta incorrecto (dd/MM/yyyy).\n";
            }

            if (sfe_vencimiento_desde != "" && sfe_vencimiento_hasta != "") {
                if (this.fc_ValidarRangofechas(sfe_vencimiento_desde, sfe_vencimiento_hasta) == false) {
                    msg_retorno += "- La fecha vencimiento desde debe ser menor a la fecha de vencimiento hasta.\n";
                }
            }

            if (msg_retorno != "") {
                alert(msg_retorno);
            }
            else {
                var arr_parametros = new Array();
                arr_parametros[0] = $("#cboGrupoDocumento_Busqueda").val();
                arr_parametros[1] = $("#cboPlantillaDocumento_Busqueda").val();
                arr_parametros[2] = $("#txtNomDocumento_Busqueda").val();
                arr_parametros[3] = $("#cboTipoAsignacion_Busqueda").val();
                arr_parametros[4] = $("#cboPersona_Empresa_Busqueda").multipleSelect("getSelects").toString();
                arr_parametros[5] = $("#txtFecVencimiento_Desde").val();
                arr_parametros[6] = $("#txtFecVencimiento_Hasta").val();
                arr_parametros[7] = $("#cboEstado_Busqueda").multipleSelect("getSelects").toString();
                arr_parametros[8] = $("#cboSubGrupoDocumento_Busqueda").val();
                arr_parametros[9] = $("#cboTipoDoc_Busqueda").multipleSelect("getSelects").toString();
                arr_parametros[10] = $("#cboArea_Busqueda").val();
                arr_parametros[11] = $("#cboSeccion_Busqueda").val();
                var urlService = page + "/getBandeja";
                //JQGrid_Util.GetTabla_Ajax
                this.fc_GetJQGrid_Ajax_SubGrid(arr_parametros, urlService, idGrilla_Bandeja, idPieGrilla_Bandeja
                    , strCabecera_Bandeja, ModelCol_Bandeja, JQGrid_Opciones_Default
                    , function () { }, fn_dblClickBandeja, function () { });
            }
        }
        function fn_dblClickBandeja(rowID) {
            fn_Editar(rowID, undefined);
        }
        var pageMntDoc = "../../../Views/ctrlDoc/Maestros/MntDocumentos.aspx";
        function fn_Editar(rowID, idDocumento) {
            var rowData;
            if (rowID == undefined && idDocumento == undefined) {
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

            idDocumento = (idDocumento > 0 ? idDocumento : rowData["id_documento"]);

            var strFiltros = "{'id_documento':" + idDocumento + "}";
            var strUrlServicio = pageMntDoc + "/Get_Documento";
            this.fc_CallService(strFiltros, strUrlServicio, function (objResponse) {
                rowData = objResponse;
                //Cambia de TAB
                document.getElementById("pagina1").style.display = 'none';
                $("#pagina2").fadeIn();
                document.getElementById("lblTituloTab2").innerHTML = "Detalle de ";

                this.fn_Limpiar_Editar();

                this.fc_FillCombo("cboEstado", objEstadosDoc, textSeleccione);
                var cboEstado = document.getElementById("cboEstado");
                cboEstado.disabled = true;

                $("#cboGrupoDocumento").prop("disabled", true);
                $("#cboSubGrupoDocumento").prop("disabled", true);
                $("#cboPlantillaDocumento").prop("disabled", true);
                /*Establece valores*/
                document.getElementById("txtID").value = rowData["id_documento"];

                fc_FillCombo("cboGrupoDocumento", [{ value: rowData["co_grupo_doc"], nombre: rowData["no_grupo_doc"] }], textSeleccione);
                document.getElementById("cboGrupoDocumento").value = rowData["co_grupo_doc"];

                fc_FillCombo("cboSubGrupoDocumento", [{ value: rowData["co_sub_grupo_doc"], nombre: rowData["no_sub_grupo_doc"] }], textSeleccione);
                document.getElementById("cboSubGrupoDocumento").value = rowData["co_sub_grupo_doc"];

                fc_FillCombo("cboPlantillaDocumento", [{ value: rowData["id_plantilla_doc"], nombre: rowData["no_plantilla_doc"] }], textSeleccione);
                document.getElementById("cboPlantillaDocumento").value = rowData["id_plantilla_doc"];

                document.getElementById("txtNomDocumento").value = rowData["no_documento"];
                document.getElementById("txtFecInicio").value = rowData["fe_inicio"];
                document.getElementById("txtFecVencimiento").value = rowData["fe_vencimiento"];
                document.getElementById("cboEstado").value = rowData["co_estado"];
                document.getElementById("cboTipoAsignacion").value = rowData["co_tipo_asignacion"];
                $("#cboTipoAsignacion").trigger("change", [rowData["id_persona_empresa"]]);
                if (rowData["co_tipo_asignacion"] == "00") //Personal
                {
                    $("#lblFecInicio").text("Fec. Ingreso");
                    $("#txtFecInicio").prop("disabled", true);
                }
                else {
                    $("#lblFecInicio").text("Fec. Inicio");
                    $("#txtFecInicio").prop("disabled", false);
                }

                $("#chkReservado").prop("checked", rowData["fl_reservado"]);

                //carga caracteristicas
                var strFiltros = "{'id_documento':" + rowData["id_documento"] + "}";
                var strUrlServicio = pageMntDoc + "/Get_Documento_Caracteristica";
                this.fc_CallService(strFiltros, strUrlServicio,
                    function (objResponse) {
                        JQGrid_Util.GetTabla_Local(this.idGrilla_Caracteristica, this.idPieGrilla_Caracteristica, this.strCabecera_Caracteristica, this.ModelCol_Caracteristica
                            , JQGrid_Opciones_Default, objResponse, fn_click_caracteristica, fn_dblclick_caracteristica, function () { });

                        //carga Files
                        strFiltros = "{'id_documento':" + rowData["id_documento"] + "}";
                        strUrlServicio = pageMntDoc + "/Get_ListaDocumento_Files";
                        this.fc_CallService(strFiltros, strUrlServicio,
                            function (objResponse) {
                                JQGrid_Util.GetTabla_LocalGrouping(this.idGrilla_Files, this.idPieGrilla_Files, this.strCabecera_Files, this.ModelCol_Files
                                    , JQGrid_Opciones_Default, objResponse, this.nameGroupField_Files, function () { }, fn_dblClickBandeja_Files, function () { });
                            }
                        );
                    }
                );

                document.getElementById("cboPlantillaDocumento").focus();
            });
        }
        $("#cboTipoAsignacion").change(function (event, id_persona_empresa) {
            var value = $(this).val();
            if (value == "") {
                fc_FillCombo("cboPersona_Empresa", [], textSeleccione);
            }
            else {
                var parametros = "{'codigo':'<%=Parametros.Combo.PERSONA_EMPRESA %>', 'co_padre':'" + value + "'}";
                var urlService = "/wsGenerales.asmx/getCombo";
                fc_CallService(parametros, urlService, function (objResponse) {
                    this.fc_FillCombo("cboPersona_Empresa", objResponse, textSeleccione);
                    if (id_persona_empresa > 0) {
                        $("#cboPersona_Empresa").val(id_persona_empresa);
                    }
                });
            }
        });
        function fn_Limpiar_Editar() {
            idRenov = "";
            this.fn_BloquearDatosRenovacion(false);
            document.getElementById("txtID").value = "";
            $("#cboGrupoDocumento").val("").trigger("change");
            document.getElementById("txtNomDocumento").value = "";
            document.getElementById("txtFecInicio").value = "";
            document.getElementById("txtFecVencimiento").value = "";
            document.getElementById("cboEstado").value = "";
            $("#cboTipoAsignacion").val("").trigger("change");
            $("#chkReservado").prop("checked", false);

            //Carga cabecera de caracteristicas
            this.objDatosCaracteristicas = [];
            //Variables Grilla
            JQGrid_Util.GetTabla_Local(this.idGrilla_Caracteristica, this.idPieGrilla_Caracteristica, this.strCabecera_Caracteristica, this.ModelCol_Caracteristica
                , JQGrid_Opciones_Default, this.objDatosCaracteristicas, fn_click_caracteristica, fn_dblclick_caracteristica, function () { });

            //Carga cabecera de Files
            this.objDatosFiles = [];
            JQGrid_Util.GetTabla_LocalGrouping(this.idGrilla_Files, this.idPieGrilla_Files, this.strCabecera_Files, this.ModelCol_Files
                , JQGrid_Opciones_Default, this.objDatosFiles, this.nameGroupField_Files, function () { }, fn_dblClickBandeja_Files, function () { });
        }
        function fn_BloquearDatosRenovacion(fl_block) {
            //////$("#cboPlantillaDocumento").prop("disabled", fl_block);
            //////$("#cboEstado").prop("disabled", fl_block);
            //////$("#cboTipoAsignacion").prop("disabled", fl_block);
            //////$("#cboPersona_Empresa").prop("disabled", fl_block);
        }
        var idRenov = "";
        function fn_VerReporte() {
            var msg_retorno = "";
            var nomGrupoDoc = $("#cboGrupoDocumento_Busqueda option:selected").text();
            var codGrupoDoc = $("#cboGrupoDocumento_Busqueda").val();
            var nomSubGrupoDoc = $("#cboSubGrupoDocumento_Busqueda option:selected").text();
            var codSubGrupoDoc = $("#cboSubGrupoDocumento_Busqueda").val();
            var nomPlantillaDoc = $("#cboPlantillaDocumento_Busqueda option:selected").text();
            var codPlantillaDoc = $("#cboPlantillaDocumento_Busqueda").val();
            var nomDocumento = fc_Trim($("#txtNomDocumento_Busqueda").val());
            var nomTipoAsignacion = $("#cboTipoAsignacion_Busqueda option:selected").text();
            var codTipoAsignacion = $("#cboTipoAsignacion_Busqueda").val();
            var nomsPersonaEmpresa = $("#cboPersona_Empresa_Busqueda").multipleSelect("getSelects", "text").toString();
            var codsPersonaEmpresa = $("#cboPersona_Empresa_Busqueda").multipleSelect("getSelects").toString();
            var nomEstado = $("#cboEstado_Busqueda").multipleSelect("getSelects", "text").toString();
            var codsEstado = $("#cboEstado_Busqueda").multipleSelect("getSelects").toString();
            var sfe_vencimiento_desde = fc_Trim($("#txtFecVencimiento_Desde").val());
            var sfe_vencimiento_hasta = fc_Trim($("#txtFecVencimiento_Hasta").val());
            var co_tipo_doc = $("#cboTipoDoc_Busqueda").multipleSelect("getSelects").toString();
            var id_area = $("#cboArea_Busqueda").val();
            var id_seccion = $("#cboSeccion_Busqueda").val();

            if (sfe_vencimiento_desde != "" && this.fc_ValidarFecha(sfe_vencimiento_desde) == false) {
                msg_retorno += "- Fecha vencimiento desde incorrecto (dd/MM/yyyy).\n";
            }
            if (sfe_vencimiento_hasta != "" && this.fc_ValidarFecha(sfe_vencimiento_hasta) == false) {
                msg_retorno += "- Fecha vencimiento hasta incorrecto (dd/MM/yyyy).\n";
            }

            if (sfe_vencimiento_desde != "" && sfe_vencimiento_hasta != "") {
                if (this.fc_ValidarRangofechas(sfe_vencimiento_desde, sfe_vencimiento_hasta) == false) {
                    msg_retorno += "- La fecha vencimiento desde debe ser menor a la fecha de vencimiento hasta.\n";
                }
            }

            codPlantillaDoc = (codPlantillaDoc == "" ? "0" : codPlantillaDoc);
            id_area = (id_area == "" ? "0" : id_area);
            id_seccion = (id_seccion == "" ? "0" : id_seccion);

            if (msg_retorno != "") {
                alert(msg_retorno);
            }
            else {
                var parametros = nomGrupoDoc + "|" + nomSubGrupoDoc + "|" + nomPlantillaDoc + "|" + nomTipoAsignacion + "|" + nomsPersonaEmpresa + "|" + nomEstado
                    + "|" + codGrupoDoc + "|" + codSubGrupoDoc + "|" + codPlantillaDoc + "|" + nomDocumento + "|" + codTipoAsignacion + "|" + codsPersonaEmpresa
                    + "|" + sfe_vencimiento_desde + "|" + sfe_vencimiento_hasta + "|" + codsEstado
                    + "|" + co_tipo_doc + "|" + id_area + "|" + id_seccion;
                var arr_parametros = new Array();
                arr_parametros[0] = "<%=Parametros.CDOC_Reportes.RepSegDocumentos %>";
                arr_parametros[1] = parametros;

                var parametros = "{'cadena':" + JSON.stringify(arr_parametros) + "}";
                var urlService = "/wsGenerales.asmx/genCod";
                this.fc_CallService(parametros, urlService, function (objResponse) {
                    var codrep = objResponse[0];
                    var prm = objResponse[1];
                    this.fc_OpenReport(codrep, prm, "0");
                });
            }
        }
        /*[INICIO] - Funciones para los Files*/
        function fn_linkformat(cellValue, options, rowObject) {
            var strFolder = rowObject["no_folder"];
            var strFile = rowObject["no_file_all"];
            if (strFile == "") { return ""; }

            //var strLink = "<a href='<%=Parametros.CDOC_VirtualServer_Documentos %>" + strFolder + "/" + strFile + "' target='_blank'>" + cellValue + "</a>";
            var imgVer = "<img src='../img/img_buttons/Busqueda-48.png' style='width:25px;' />";
            var strLink = "<a href='<%=Parametros.CDOC_VirtualServer_Documentos %>" + strFolder + "/" + strFile + "' target='_blank'>" + imgVer + "</a>";
            return strLink;
        }
        function fn_dblClickBandeja_Files(rowID) {
        }
        /*[FIN] - Funciones para los Files*/
        /*[INICIO] - Funciones para las caracteristicas*/
        function inputFileFormat(cellValue, options, rowObject) {
            var input = "";
            var styleDisplay = "";
            var linkArchivo = "";
            var btnSubir = "";
            var btnEditar = "";
            if (rowObject.co_tipo_dato == "04" && rowObject.txt_obligatorio == "SI") //Fecha Vencimiento
            {
                if (cellValue != "") {
                    styleDisplay = "display:none;";
                    linkArchivo = fileServer_documentos + cellValue.substr(0, 6) + "/" + cellValue;
                }

                input = '<input id="fuArchivo_' + options.rowId + '" style="width:200px; ' + styleDisplay + '" type="file" />';
                enlace = '<a id="enlaceArchivo_' + options.rowId + '" href="' + linkArchivo + '" target="_blank">' + cellValue + '</a>';
                btnSubir = ' <img id="btnSubir_' + options.rowId + '" src="../img/img_buttons/icono_upload.png" alt="Subir Archivo" title="Subir Archivo"' +
                    'border="0" height="20px" onclick="fn_SubirFile(' + options.rowId + ');" style="cursor: pointer; ' + styleDisplay + '" />';
                input += enlace + btnSubir;
            }
            return input;
        }
        function inputFileUnFormat(cellValue, options, cell) {
            return $('a', cell).text();
        }
        function fn_click_caracteristica(rowid) {
        }
        function fn_dblclick_caracteristica(rowid) {
        }
        /*[FIN] - Funciones para las caracteristicas*/
        function fn_Volver() {
            $("#pagina1").fadeIn();
            document.getElementById("pagina2").style.display = 'none';
        }
        function fn_VerReporteDetallado() {
            var msg_retorno = "";
            var nomGrupoDoc = $("#cboGrupoDocumento_Busqueda option:selected").text();
            var codGrupoDoc = $("#cboGrupoDocumento_Busqueda").val();
            var nomSubGrupoDoc = $("#cboSubGrupoDocumento_Busqueda option:selected").text();
            var codSubGrupoDoc = $("#cboSubGrupoDocumento_Busqueda").val();
            var nomPlantillaDoc = $("#cboPlantillaDocumento_Busqueda option:selected").text();
            var codPlantillaDoc = $("#cboPlantillaDocumento_Busqueda").val();
            var nomDocumento = fc_Trim($("#txtNomDocumento_Busqueda").val());
            var nomTipoAsignacion = $("#cboTipoAsignacion_Busqueda option:selected").text();
            var codTipoAsignacion = $("#cboTipoAsignacion_Busqueda").val();
            var nomsPersonaEmpresa = $("#cboPersona_Empresa_Busqueda").multipleSelect("getSelects", "text").toString();
            var codsPersonaEmpresa = $("#cboPersona_Empresa_Busqueda").multipleSelect("getSelects").toString();
            var nomEstado = $("#cboEstado_Busqueda").multipleSelect("getSelects", "text").toString();
            var codsEstado = $("#cboEstado_Busqueda").multipleSelect("getSelects").toString();
            var sfe_vencimiento_desde = fc_Trim($("#txtFecVencimiento_Desde").val());
            var sfe_vencimiento_hasta = fc_Trim($("#txtFecVencimiento_Hasta").val());
            var co_tipo_doc = $("#cboTipoDoc_Busqueda").multipleSelect("getSelects").toString();
            var id_area = $("#cboArea_Busqueda").val();
            var id_seccion = $("#cboSeccion_Busqueda").val();

            if (sfe_vencimiento_desde != "" && this.fc_ValidarFecha(sfe_vencimiento_desde) == false) {
                msg_retorno += "- Fecha vencimiento desde incorrecto (dd/MM/yyyy).\n";
            }
            if (sfe_vencimiento_hasta != "" && this.fc_ValidarFecha(sfe_vencimiento_hasta) == false) {
                msg_retorno += "- Fecha vencimiento hasta incorrecto (dd/MM/yyyy).\n";
            }

            if (sfe_vencimiento_desde != "" && sfe_vencimiento_hasta != "") {
                if (this.fc_ValidarRangofechas(sfe_vencimiento_desde, sfe_vencimiento_hasta) == false) {
                    msg_retorno += "- La fecha vencimiento desde debe ser menor a la fecha de vencimiento hasta.\n";
                }
            }

            codPlantillaDoc = (codPlantillaDoc == "" ? "0" : codPlantillaDoc);
            id_area = (id_area == "" ? "0" : id_area);
            id_seccion = (id_seccion == "" ? "0" : id_seccion);

            if (msg_retorno != "") {
                alert(msg_retorno);
            }
            else {
                var parametros = nomGrupoDoc + "|" + nomSubGrupoDoc + "|" + nomPlantillaDoc + "|" + nomTipoAsignacion + "|" + nomsPersonaEmpresa + "|" + nomEstado
                    + "|" + codGrupoDoc + "|" + codSubGrupoDoc + "|" + codPlantillaDoc + "|" + nomDocumento + "|" + codTipoAsignacion + "|" + codsPersonaEmpresa
                    + "|" + sfe_vencimiento_desde + "|" + sfe_vencimiento_hasta + "|" + codsEstado
                    + "|" + co_tipo_doc + "|" + id_area + "|" + id_seccion;
                var arr_parametros = new Array();
                arr_parametros[0] = "<%=Parametros.CDOC_Reportes.RepSegDocumentos_Det %>";
                arr_parametros[1] = parametros;

                var parametros = "{'cadena':" + JSON.stringify(arr_parametros) + "}";
                var urlService = "/wsGenerales.asmx/genCod";
                this.fc_CallService(parametros, urlService, function (objResponse) {
                    var codrep = objResponse[0];
                    var prm = objResponse[1];
                    this.fc_OpenReport(codrep, prm, "0");
                });
            }
        }

        //--SubGrid de bandeja
        //#region - Variables Grilla Bandeja SubGrid
        var strCabecera_Bandeja_SubGrid = ['ID', 'Tipo Documento', 'Nombre', 'Archivo', 'Control Principal', 'Activar Alerta', 'Fec. Inicio', 'Fec. Vencimiento', 'Estado'];
        var ModelCol_Bandeja_SubGrid = [
                    { name: 'id_documento_file', index: 'id_documento_file', hidden: true },
                    { name: 'no_tipo_doc', index: 'no_tipo_doc', width: 100, sortable: false, align: 'center' },
                    { name: 'no_documento', index: 'no_documento', width: 300, sortable: false },
                    { name: 'no_file', index: 'no_file', width: 100, sortable: false, formatter: fn_linkformat, align: 'center' },
                    { name: 'tx_principal', index: 'tx_principal', width: 100, sortable: false, align: 'center' },
                    { name: 'tx_activar_alerta', index: 'tx_activar_alerta', width: 100, sortable: false, align: 'center' },
                    { name: 'sfe_inicio', index: 'sfe_inicio', width: 100, sortable: false, align: 'center' },
                    { name: 'sfe_vencimiento', index: 'sfe_vencimiento', width: 100, sortable: false, align: 'center' },
                    { name: 'no_estado', index: 'no_estado', width: 100, sortable: false, align: 'center' }
        ];
        //#endregion - Variables Grilla Bandeja SubGrid

        function fc_GetJQGrid_Ajax_SubGrid(arr_parametros, strUrlServicio, IdTabla, IdPieTabla, Cabecera, ModelCol, JQGrid_Opciones, fn_Click, fn_dblClick, fn_Complete) {
            var no_tabla = IdTabla.replace('#', '');
            if (document.getElementById('gbox_' + no_tabla) != null) {
                $(IdTabla).jqGrid('GridUnload'); //Limpia todos los datos (cabecera, estilos de la grilla) y lo deja como si no huviera cargado nada
            }

            if (IdTabla.indexOf("#") < 0) IdTabla = ("#" + IdTabla);
            if (IdPieTabla.indexOf("#") < 0) IdPieTabla = ("#" + IdPieTabla);

            //Carga JQGrid
            //if (JQGrid_Opciones.fl_paginar == false) JQGrid_Opciones.pageSize = objDatos.length;
            if (JQGrid_Opciones.fl_paginar == false) JQGrid_Opciones.pageSize = 10000;

            $(IdTabla).jqGrid(
                {
                    datatype: function () {
                        $.ajax({
                            type: 'POST',
                            data: "{'strFiltros':" + JSON.stringify(arr_parametros) +
                                ",'pPageSize':'" + $(IdTabla).getGridParam("rowNum") +
                                "','pCurrentPage':'" + $(IdTabla).getGridParam("page") +
                                "','pSortColumn':'" + $(IdTabla).getGridParam("sortname") +
                                "','pSortOrder':'" + $(IdTabla).getGridParam("sortorder")
                                + "'}", //Parametros de entrada del PageMethod
                            dataType: 'json',
                            url: strUrlServicio,
                            contentType: 'application/json; charset=utf-8',
                            async: true,
                            //complete: function (data, textStatus) {
                            //$(IdTabla)[0].addJSONData(JSON.parse(jsondata.responseText).d);
                            //}
                            beforeSend: function () {
                                fc_show_progress(true);
                            },
                            complete: function () {
                                fc_show_progress(false);
                            },
                            success: function (data, textStatus) {
                                if (textStatus == "success")
                                    $(IdTabla)[0].addJSONData(JSON.parse(data.d));
                                else
                                    alert(JSON.parse(data.responseText).Message);
                            },
                            error: function (request, textStatus, error) {
                                fc_errorAjax(request, textStatus, error);
                            }
                        });
                    },
                    jsonReader: //jsonReader –> JQGridJSonResponse data.
                    {
                        root: "Items",
                        page: "CurrentPage",
                        total: "PageCount",
                        records: "RecordCount",
                        repeatitems: true,
                        cell: "Row",
                        id: "ID"
                    },
                    colNames: Cabecera,
                    colModel: ModelCol,
                    pager: IdPieTabla,
                    rownumbers: true,
                    loadtext: "Cargando datos...",
                    viewrecords: true, /*Muestra cantidad de registros*/
                    recordtext: "{0} - {1} de {2} registros",
                    emptyrecords: 'No existen resultados',
                    pgtext: 'Pág: {0} de {1}', //Paging input control text format.
                    rowNum: JQGrid_Opciones.pageSize, // PageSize.
                    //width: 'auto', //Se utiliza autowidth para que se ajuste ancho
                    height: JQGrid_Opciones.height, //auto //'100%' //230 => para 10 registros
                    scroll: JQGrid_Opciones.fl_paginar_scroll,
                    pgbuttons: JQGrid_Opciones.fl_paginar,
                    pginput: JQGrid_Opciones.fl_paginar,
                    //rowList: [10, 20, 30], //Variable PageSize DropDownList.
                    multiboxonly: true, /*Permite seleccionar fila solo desde el CheckBox*/
                    multiselect: JQGrid_Opciones.fl_multiselect,
                    sortname: 0, //Default SortColumn
                    sortorder: "asc", //Default SortOrder.
                    autowidth: true, //Para recalcular automáticamente al ancho del elemento padre
                    shrinkToFit: false,
                    forceFit: true,
                    gridview: true,
                    altRows: JQGrid_Opciones.altRows, /*Alternate Rows*/
                    hoverrows: !JQGrid_Opciones.altRows
                    , subGrid: true
                    , subGridRowExpanded: function (subgrid_id, row_id) {
                        var rowData = $(idGrilla_Bandeja).jqGrid("getRowData", row_id);
                        var id_documento = rowData["id_documento"];
                        var cods_tipo_documento = $("#cboTipoDoc_Busqueda").multipleSelect("getSelects").toString();

                        var subgrid_table_id, pager_id;
                        subgrid_table_id = subgrid_id + "_t";
                        pager_id = "p_" + subgrid_table_id;
                        $("#" + subgrid_id).html("<table id='" + subgrid_table_id + "' class='scroll'></table><div id='" + pager_id + "' class='scroll'></div>");
                        //$("#" + subgrid_id).html("<div style='width:100%;'><table style='width:100%;' id='" + subgrid_table_id + "' class='scroll'></table><div id='" + pager_id + "' class='scroll'></div></div>");

                        //Carga SubGrid
                        var parametros = new Array();
                        parametros[0] = id_documento;
                        parametros[1] = cods_tipo_documento;
                        var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
                        var strUrlServicio = pageMntDoc + "/getBandeja_SubGrid_Files";
                        fc_CallService(strParametros, strUrlServicio, function (res) {
                            fc_GetJQGrid_Local_(("#" + subgrid_table_id), ("#" + pager_id), strCabecera_Bandeja_SubGrid, ModelCol_Bandeja_SubGrid, JQGrid_Opciones_Default, res.oBandeja, function () { }, function () { }, function () { });
                        });

                        /*jQuery("#" + subgrid_table_id).jqGrid({
                            url: "subgrid.php?q=2&id=" + row_id,
                            datatype: "xml",
                            colNames: ['No', 'Item', 'Qty', 'Unit', 'Line Total'],
                            colModel: [
                                { name: "num", index: "num", width: 80, key: true },
                                { name: "item", index: "item", width: 130 },
                                { name: "qty", index: "qty", width: 70, align: "right" },
                                { name: "unit", index: "unit", width: 70, align: "right" },
                                { name: "total", index: "total", width: 70, align: "right", sortable: false }
                            ],
                            rowNum: 20,
                            pager: pager_id,
                            sortname: 'num',
                            sortorder: "asc",
                            height: '100%'
                        });
                        jQuery("#" + subgrid_table_id).jqGrid("navGrid", "#" + pager_id, { edit: false, add: false, del: false })*/
                    }
                    , gridComplete: function () { /*Se ejecuta al terminar de cargar la grilla*/
                        /*var rowIDs = $(IdTabla).jqGrid('getDataIDs'); //Obtiene los Id de las filas concatenados con ","
                        for (var i = 0; i < rowIDs.length; i++) {
                        var rowID = rowIDs[i];
                        var rowData = $(IdTabla).jqGrid('getRowData', rowID); //Obtiene los valores de la fila Ejm: row.nid ó row.customer
                        }*/
                        if (fn_Complete != "" && fn_Complete != undefined) {
                            fn_Complete();
                        }
                    }
                    , onSelectRow: function (rowID) {
                        if (fn_Click != "" && fn_Click != undefined) {
                            fn_Click(rowID);
                        }
                    }
                    , ondblClickRow: function (rowID) {
                        if (fn_dblClick != "" && fn_dblClick != undefined) {
                            fn_dblClick(rowID);
                        }
                    }
                }).navGrid(IdPieTabla, {
                    edit: false, add: false, search: false, del: false, refresh: false
                });
        }

        function fc_GetJQGrid_Local_(IdTabla, IdPieTabla, Cabecera, ModelCol, JQGrid_Opciones, objDatos, fn_Click, fn_dblClick, fn_Complete) {
            try {
                var no_tabla = IdTabla.replace('#', '');
                if (document.getElementById('gbox_' + no_tabla) != null) {
                    $(IdTabla).jqGrid('GridUnload'); //Limpia todos los datos (cabecera, estilos de la grilla) y lo deja como si no huviera cargado nada
                }

                if (IdTabla.indexOf("#") < 0) IdTabla = ("#" + IdTabla);
                if (IdPieTabla.indexOf("#") < 0) IdPieTabla = ("#" + IdPieTabla);

                //Carga JQGrid
                if (JQGrid_Opciones.fl_paginar == false) JQGrid_Opciones.pageSize = objDatos.length;

                var gridData = objDatos;
                var theGrid = $(IdTabla);
                numberTemplate = { formatter: 'number', align: 'right', sorttype: 'number' };
                theGrid.jqGrid({
                    datatype: 'local',
                    data: gridData,
                    colNames: Cabecera,
                    colModel: ModelCol,
                    pager: IdPieTabla,
                    rownumbers: true,
                    loadtext: "Cargando datos...",
                    loadonce: true,
                    viewrecords: true, /*Muestra cantidad de registros*/
                    recordtext: "{0} - {1} de {2} registros",
                    //emptyrecords: 'No se encontraron resultados',
                    emptyrecords: 'No existen resultados',
                    pgtext: 'Pág: {0} de {1}', //Paging input control text format.
                    rowNum: JQGrid_Opciones.pageSize, // PageSize.
                    //width: 'auto', //Se utiliza autowidth para que se ajuste ancho
                    height: JQGrid_Opciones.height, //auto //'100%' //230 => para 10 registros
                    scroll: JQGrid_Opciones.fl_paginar_scroll,
                    pgbuttons: JQGrid_Opciones.fl_paginar,
                    pginput: JQGrid_Opciones.fl_paginar,
                    //rowList: [10, 20, 30], //Variable PageSize DropDownList.
                    multiboxonly: true, /*Permite seleccionar fila solo desde el CheckBox*/
                    multiselect: JQGrid_Opciones.fl_multiselect,
                    sortname: 0, //Default SortColumn
                    sortorder: "asc", //Default SortOrder.
                    autowidth: true, //Para recalcular automáticamente al ancho del elemento padre
                    shrinkToFit: false,
                    forceFit: true,
                    gridview: true,
                    altRows: JQGrid_Opciones.altRows, /*Alternate Rows*/
                    hoverrows: !JQGrid_Opciones.altRows
                    , gridComplete: function () { /*Se ejecuta al terminar de cargar la grilla*/
                        /*
                        var rowIDs = $(IdTabla).jqGrid('getDataIDs'); //Obtiene los Id de las filas concatenados con ","
                        for (var i = 0; i < rowIDs.length; i++) {
                        var rowID = rowIDs[i];
                        var rowData = $(IdTabla).jqGrid('getRowData', rowID); //Obtiene los valores de la fila Ejm: row.nid ó row.customer
                        }
                        */
                        if (fn_Complete != "" && fn_Complete != undefined) {
                            fn_Complete();
                        }
                    }
                    , onSelectRow: function (rowID) {
                        if (fn_Click != "" && fn_Click != undefined) {
                            fn_Click(rowID);
                        }
                    }
                    //, ondblClickRow: function (rowID) {
                    , ondblClickRow: function (rowID, row, col, e) {
                        if (fn_dblClick != "" && fn_dblClick != undefined) {
                            fn_dblClick(rowID);
                        }

                        //detener la propagación del evento de grilla maestra
                        e.stopImmediatePropagation(); 
                    }
                    , onSortCol: function (index, columnIndex, sortOrder) {
                        //$(IdTabla).trigger("reloadGrid");
                    }
                    , onPaging: function (pgButton) {

                    }
                });

            } catch (ex) {
                alert("CATCH: " + ex);
            }
        }
    </script>
</asp:Content>