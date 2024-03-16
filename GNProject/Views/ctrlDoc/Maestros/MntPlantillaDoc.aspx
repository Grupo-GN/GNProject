<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="MntPlantillaDoc.aspx.cs" Inherits="GNProject.Views.ctrlDoc.Maestros.MntPlantillaDoc" %>

<%@ Import Namespace="GNProject.Acceso" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
     <link href="/Assets/Css/tables.css" rel="stylesheet" type="text/css" />
    <div id="pagina1">
        <div class="row linea-bottom">
            <div class="col l4 s12 titulo">Lista de Plantilla Documentos</div>
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
                <label>Nombre Plantilla</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtNomPlantilla_Busqueda" type="text" class="control-form" />
            </div>
            <div class="col l1 m2 s4">
                <label>Estado</label>
            </div>
            <div class="col l3 m4 s8">
                <select id="cboEstado_Busqueda" class="control-form">
                    <option value="" selected="selected">
                        <%=Parametros.OBJECTO_TODOS%></option>
                    <option value="1">
                        <%=Parametros.OBJECTO_ACTIVO %></option>
                    <option value="0">
                        <%=Parametros.OBJECTO_INACTIVO %></option>
                </select>
            </div>
        </div>
        <div class="row titulo_section">
            Resultados
        </div>
        <div class="row" style="padding-right: 10%;padding-left:10%;">
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
                Plantilla de Documento
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
                <label>Nombre Plantilla</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtNomPlantilla" type="text" class="control-form" />
            </div>
            <div class="col l1 m2 s4">
                <label>Grupo</label>
            </div>
            <div class="col l3 m4 s8">
                <select id="cboGrupo" class="control-form"></select>
            </div>
            <div class="col l1 m2 s4">
                <label>Sub Grupo</label>
            </div>
            <div class="col l3 m4 s8">
                <select id="cboSubGrupo" class="control-form"></select>
            </div>
        </div>
        <div class="row">
            <div class="col l1 m2 s4">
                <label>Usuarios Responsables</label>
            </div>
            <div class="col l3 m4 s8">
                <select id="cboUsuariosResponsables" class="control-form"></select>
            </div>
            <div class="col l1 m2 s4">
                <label>Días Alerta Vencimiento</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtDiasParaAlerta" type="text" maxlength="5" class="control-form" />
            </div>
            <div class="col l1 m2 s4">
                <label>Estado</label>
            </div>
            <div class="col l3 m4 s8">
                <select id="cboEstado" class="control-form">
                    <option value="" selected="selected">
                        <%=Parametros.OBJECTO_TODOS%></option>
                    <option value="1">
                        <%=Parametros.OBJECTO_ACTIVO %></option>
                    <option value="0">
                        <%=Parametros.OBJECTO_INACTIVO %></option>
                </select>
            </div>
        </div>
         <div class="row">
            <div class="col l1 m2 s4">
                <label>Tipos Documento</label>
            </div>
            <div class="col l3 m4 s8">
                <select id="cboTipoDocArchivo" class="control-form"></select>
            </div>
        </div>
        <div class="row titulo_section">
            Características
        </div>
        <div class="row">
            <div class="col l1 m2 s4">
                <label>Característica</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtCaracteristica" type="text" class="control-form" />
            </div>
            <div class="col l8 m6 s12">
                <button id="imgAgregarArchivo" type="button" onclick="fn_AgregarItem();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/AñadirLista-48.png" />Agregar</button>
                <button type="button" onclick="fn_QuitarItem();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/Cancelar-48.png" />Quitar</button>
            </div>
        </div>
        <div class="row" style="padding-right: 10px;">
            <span style="text-align: right; font-size: 9px;">(Doble clic para editar)</span>
            <div class="col l12">
                <table id="grvCaracteristica">
                </table>
                <div id="grvCaracteristica_Pie">
                </div>
            </div>
        </div>
        <div class="row titulo_section">
            Archivos Asociados
        </div>
        <div class="row">
            <div class="col l1 m2 s4">
                <label>Documento</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtDocumento_File" type="text" class="control-form" />
            </div>
            <div class="col l8 m6 s12">
                <button id="imgAgregar_File" type="button" onclick="fn_AgregarFile();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/AñadirLista-48.png" />Agregar</button>
                <button type="button" onclick="fn_QuitarFile();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/Cancelar-48.png" />Quitar</button>
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
    </div>
    <script type="text/javascript">
        //#region - Variables Grilla Bandeja
        var idGrilla_Bandeja = "#grvBandeja";
        var idPieGrilla_Bandeja = "#grvBandeja_Pie";
        var strCabecera_Bandeja = ['ID', 'Plantilla Documento', 'Grupo', 'Sub Grupo', 'CodEstado', 'Estado', 'Cod. Grupo', 'Cod. Sub Grupo', 'IDs Usuarios Responsables', 'Dias Antes Vencimiento Alerta', 'Cods. Tipo doc. archivo'];
        var ModelCol_Bandeja = [
                            { name: 'id_plantilla_doc', index: 'id_plantilla_doc', width: 40, sorttype: 'number', sortable: true, align: 'center', hidden: true },
                            { name: 'no_plantilla_doc', index: 'no_plantilla_doc', width: 250, sortable: true, align: 'center' },
                            { name: 'no_grupo_doc', index: 'no_grupo_doc', width: 200, sortable: true },
                            { name: 'no_sub_grupo_doc', index: 'no_sub_grupo_doc', width: 200, sortable: true },
                            { name: 'fl_activo', index: 'fl_activo', hidden: true },
                            { name: 'no_estado', index: 'no_estado', width: 100, sortable: true, align: 'center' },
                            { name: 'co_grupo_doc', index: 'co_grupo_doc', hidden: true },
                            { name: 'co_sub_grupo_doc', index: 'co_sub_grupo_doc', hidden: true },
                            { name: 'ids_usuarios_responsables', index: 'ids_usuarios_responsables', hidden: true },
                            { name: 'qt_dias_ant_venc_alerta', index: 'qt_dias_ant_venc_alerta', hidden: true },
                            { name: 'cods_tipo_doc_archivo', index: 'cods_tipo_doc_archivo', hidden: true }
        ];
        //#endregion - Variables Grilla Bandeja

        //#region - Variables Grilla Caracteristica
        var objDatosCaracteristicas = new Array();
        var rowId_Caracteristica = null;
        var idGrilla_Caracteristica = "#grvCaracteristica";
        var idPieGrilla_Caracteristica = "#grvCaracteristica_Pie";
        var strCabecera_Caracteristica = ['ID', 'Característica', 'Tipo Dato', 'Obligatorio', 'Orden', 'Días de anticipación alerta'];
        var ModelCol_Caracteristica = [
                        { name: 'id_plantilla_doc_caracteristica', index: 'id_plantilla_doc_caracteristica', width: 40, sortable: false, hidden: true },
                        { name: 'no_caracteristica', index: 'no_caracteristica', width: 250, editable: true, edittype: 'text', sortable: false },
                        {
                            name: 'co_tipo_dato', index: 'co_tipo_dato', width: 100, editable: true, edittype: 'select', formatter: 'select'
                            , editoptions: { value: getAllSelectOptions() }, sortable: false, align: 'center'
                        },
                        {
                            name: 'txt_obligatorio', index: 'txt_obligatorio', width: 100, editable: true, edittype: 'checkbox'
                            , editoptions: { value: "SI:NO" }, sortable: false, align: 'center'
                        },
                        { name: 'nu_orden', index: 'nu_orden', width: 50, sortable: false, hidden: true },
                        { hidden: true, name: 'qt_dias_alerta', index: 'qt_dias_alerta', width: 100, editable: false, formatter: inputFormatNumero, unformat: inputUnFormatNumero, sortable: false, align: 'center' }
        ];
        //#endregion - Variables Grilla Caracteristica

        //#region - Variables Grilla Bandeja Files
        var objDatosFiles = new Array();
        var idGrilla_Files = "#grvFiles";
        var idPieGrilla_Files = "#grvFiles_Pie";
        var strCabecera_Files = ['ID', 'Nombre'];
        var ModelCol_Files = [
                    { name: 'id_plantilla_doc_file', index: 'id_plantilla_doc_file', hidden: true },
                    { name: 'no_documento', index: 'no_documento', width: 250, sortable: false }
        ];
        //#endregion - Variables Grilla Bandeja Files

        fn_Iniciar();
        function fn_Iniciar() {
            $("#txtNomPlantilla_Busqueda").keydown(function (event) {
                fc_PressKey(13, 'btnBuscar');
            });
            $("#cboEstado_Busqueda").keydown(function (event) {
                fc_PressKey(13, 'btnBuscar');
            });

            $("#txtCaracteristica").keydown(function (event) {
                fc_PressKey(13, 'imgAgregarArchivo');
            });

            $("#txtDocumento_File").keydown(function (event) {
                fc_PressKey(13, 'imgAgregar_File');
            });

            this.fc_FormatNumeros("txtDiasParaAlerta");

            var parametros = "{'codigo':'<%=Parametros.Combo.CDOC_GruposDocumento%>'"
                + ",'co_padre': ''}";
            var urlService = "/wsGenerales.asmx/getCombo";
            this.fc_CallService(parametros, urlService, function (objResponse) {
                textDefault = "<%=Parametros.OBJECTO_SELECCIONE %>";
                this.fc_FillCombo("cboGrupo", objResponse, textDefault);
            });

            var parametros = "{'codigo':'<%=Parametros.Combo.USUARIOS%>'"
                + ",'co_padre': ''}";
            var urlService = "/wsGenerales.asmx/getCombo";
            this.fc_CallService(parametros, urlService, function (objResponse) {
                textDefault = "<%=Parametros.OBJECTO_SELECCIONE %>";
                this.fc_FillCombo("cboUsuariosResponsables", objResponse, textDefault);
                $("#cboUsuariosResponsables option[value='']").remove();
                $("#cboUsuariosResponsables").multipleSelect({ filter: true });
            });

            var parametros = "{'codigo':'<%=Parametros.Combo.CDOC_TipoDoc_Archivos%>'"
                + ",'co_padre': ''}";
            var urlService = "/wsGenerales.asmx/getCombo";
            this.fc_CallService(parametros, urlService, function (objResponse) {
                textDefault = "<%=Parametros.OBJECTO_SELECCIONE %>";
                this.fc_FillCombo("cboTipoDocArchivo", objResponse, textDefault);
                $("#cboTipoDocArchivo option[value='']").remove();
                $("#cboTipoDocArchivo").multipleSelect("refresh");
            });

            var objResponse = [];
            JQGrid_Util.AutoWidthResponsive(idGrilla_Bandeja);
            JQGrid_Util.AutoWidthResponsive(idGrilla_Caracteristica);
            JQGrid_Util.AutoWidthResponsive(idGrilla_Files);
            JQGrid_Util.GetTabla_Local(idGrilla_Bandeja, idPieGrilla_Bandeja, strCabecera_Bandeja, ModelCol_Bandeja, JQGrid_Opciones_Default, objResponse, function () { }, function () { }, function () { });
        }

        $("#cboGrupo").change(function (event, codSubGrupo_Selected) {
            var codGrupo = fc_Trim($(this).val());
            if (codGrupo == "") {
                fc_FillCombo("cboSubGrupo", [], textSeleccione);
            }
            else {
                var parametros = "{'codigo':'<%=Parametros.Combo.CDOC_SubGruposDocumento %>'"
                    + ",'co_padre': '" + codGrupo + "'}";
                var urlService = "/wsGenerales.asmx/getCombo";
                fc_CallService(parametros, urlService, function (objResponse) {
                    this.fc_FillCombo("cboSubGrupo", objResponse, textSeleccione);
                    if (codSubGrupo_Selected != undefined) {
                        $("#cboSubGrupo").val(codSubGrupo_Selected);
                    }
                });
            }
        });

        function fn_Limpiar() {
            $("#txtNomPlantilla_Busqueda").val("");
            $("#cboEstado_Busqueda").val("");
            JQGrid_Util.clearData(idGrilla_Bandeja);
        }
        function fn_Buscar() {
            var arr_parametros = new Array();
            arr_parametros[0] = $("#txtNomPlantilla_Busqueda").val();
            arr_parametros[1] = $("#cboEstado_Busqueda").val();
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
            document.getElementById("txtID").value = rowData["id_plantilla_doc"];
            document.getElementById("txtNomPlantilla").value = rowData["no_plantilla_doc"];
            document.getElementById("cboGrupo").value = rowData["co_grupo_doc"];
            $("#cboGrupo").trigger("change", [rowData["co_sub_grupo_doc"]]);
            $("#cboUsuariosResponsables").multipleSelect("setSelects", rowData["ids_usuarios_responsables"].split(","));
            document.getElementById("txtDiasParaAlerta").value = rowData["qt_dias_ant_venc_alerta"];
            document.getElementById("cboEstado").value = rowData["fl_activo"];
            $("#cboTipoDocArchivo").multipleSelect("setSelects", rowData["cods_tipo_doc_archivo"].split(","));

            //carga caracteristicas
            var strFiltros = "{'id_plantilla_doc':" + rowData['id_plantilla_doc'] + "}";
            var strUrlServicio = page + "/Get_PlantillaDoc_Caracteristica";
            this.fc_CallService(strFiltros, strUrlServicio,
                function (objResponse) {

                    JQGrid_Util.GetTabla_Local(this.idGrilla_Caracteristica, this.idPieGrilla_Caracteristica, this.strCabecera_Caracteristica, this.ModelCol_Caracteristica
                        , JQGrid_Opciones_Default, objResponse, fn_click_caracteristica, fn_dblclick_caracteristica, function () { });

                    //Agrega ordenar filas
                    $(idGrilla_Caracteristica).jqGrid('sortableRows',
                        {
                            update: function (e, ui) {
                                //alert("item with id=" + ui.item[0].id + " is droped");
                                $(idGrilla_Caracteristica).restoreRow(rowId_Caracteristica); //row seleccionado anteriormente
                                $(idGrilla_Caracteristica).restoreRow(ui.item[0].id);
                                fn_SetOrdenRowsCaracteristicas();
                            }
                        });
                }
            );

            //carga files
            var strFiltros = "{'id_plantilla_doc':" + rowData['id_plantilla_doc'] + "}";
            var strUrlServicio = page + "/Get_PlantillaDoc_File";
            this.fc_CallService(strFiltros, strUrlServicio, function (objResponse) {
                JQGrid_Util.GetTabla_Local(this.idGrilla_Files, this.idPieGrilla_Files, this.strCabecera_Files, this.ModelCol_Files
                    , JQGrid_Opciones_Default, objResponse, function () { }, function () { }, function () { });
            });

            document.getElementById("txtNomPlantilla").focus();
        }
        function fn_Eliminar() {
            var rowId = $("#grvBandeja").jqGrid('getGridParam', 'selrow');
            if (rowId == null) {
                alert("- Debe seleccionar un registro.\n");
                return;
            }

            var msg_retorno = "";
            var rowData = jQuery("#grvBandeja").getRowData(rowId);
            var id_plantilla_doc = rowData["id_plantilla_doc"];
            var fl_activo = rowData["fl_activo"];
            if (fl_activo == "0") {
                msg_retorno += "- El registro ya se encuentra inactivo.\n";
            }

            if (msg_retorno != "") {
                alert(msg_retorno);
            }
            else if (confirm("¿Está seguro de inactivar el registro?")) {
                var arr_parametros = new Array();
                arr_parametros[0] = id_plantilla_doc;
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

            document.getElementById("txtNomPlantilla").focus();
        }

        function fn_Limpiar_Editar() {
            document.getElementById("txtID").value = "";
            document.getElementById("txtNomPlantilla").value = "";
            document.getElementById("cboGrupo").value = "";
            $("#cboGrupo").trigger("change");
            $("#cboUsuariosResponsables").multipleSelect("uncheckAll");
            document.getElementById("txtDiasParaAlerta").value = "";
            document.getElementById("cboEstado").value = "";
            $("#cboTipoDocArchivo").multipleSelect("uncheckAll");
            document.getElementById("txtCaracteristica").value = "";
            document.getElementById("txtDocumento_File").value = "";

            //Carga cabecera de caracteristicas
            this.objDatosCaracteristicas = [];
            //Variables Grilla
            JQGrid_Util.GetTabla_Local(this.idGrilla_Caracteristica, this.idPieGrilla_Caracteristica, this.strCabecera_Caracteristica, this.ModelCol_Caracteristica
                , JQGrid_Opciones_Default, this.objDatosCaracteristicas, fn_click_caracteristica, fn_dblclick_caracteristica, function () { });
            //Agrega ordenar filas
            $(idGrilla_Caracteristica).jqGrid('sortableRows',
            {
                update: function (e, ui) {
                    //alert("item with id=" + ui.item[0].id + " is droped");
                    $(idGrilla_Caracteristica).restoreRow(rowId_Caracteristica); //row seleccionado anteriormente
                    $(idGrilla_Caracteristica).restoreRow(ui.item[0].id);
                    fn_SetOrdenRowsCaracteristicas();
                }
            });

            //Carga cabecera de Files
            this.objDatosFiles = [];
            JQGrid_Util.GetTabla_Local(this.idGrilla_Files, this.idPieGrilla_Files, this.strCabecera_Files, this.ModelCol_Files
                , JQGrid_Opciones_Default, this.objDatosFiles, function () { }, function () { }, function () { });
        }
        
        function fn_Guardar() {
            if (rowId_Caracteristica != null) {
                //Se guarda si es que la fila se ha cambiado de valor
                $(idGrilla_Caracteristica).saveRow(rowId_Caracteristica); //row seleccionado anteriormente
            }

            var cont_ids_caracteristica = 0;
            var ids_PlantillaDoccaracteristica = "";
            var cad_no_caracteristica = "";
            var cad_co_tipo_dato_caracteristica = "";
            var cad_fl_obligatorio_caracteristica = "";
            var cad_nu_orden_caracteristica = "";
            var cad_qt_dias_alerta_caracteristica = "";

            var rowIDs = $(idGrilla_Caracteristica).jqGrid('getDataIDs');
            var delimit = "";
            for (var i = 0; i < rowIDs.length; i++) {
                var rowID = rowIDs[i];
                var rowData = $(idGrilla_Caracteristica).jqGrid('getRowData', rowID);
                cont_ids_caracteristica += 1;
                if (i > 0) delimit = "|";
                ids_PlantillaDoccaracteristica += delimit + rowData.id_plantilla_doc_caracteristica;
                cad_no_caracteristica += delimit + rowData.no_caracteristica;
                cad_co_tipo_dato_caracteristica += delimit + rowData.co_tipo_dato;
                cad_fl_obligatorio_caracteristica += delimit + (rowData.txt_obligatorio == "SI" ? "1" : "0");
                cad_nu_orden_caracteristica += delimit + rowData.nu_orden;
                cad_qt_dias_alerta_caracteristica += delimit + rowData.qt_dias_alerta;
            }

            //INI - Files
            var cont_ids_file = 0;
            var ids_PlantillaDoc_File = "";
            var cad_no_documento = "";

            var rowIDs = $(idGrilla_Files).jqGrid('getDataIDs');
            var delimit = "";
            for (var i = 0; i < rowIDs.length; i++) {
                var rowID = rowIDs[i];
                var rowData = $(idGrilla_Files).jqGrid('getRowData', rowID);
                cont_ids_file += 1;
                if (i > 0) delimit = "|";
                ids_PlantillaDoc_File += delimit + rowData.id_plantilla_doc_file;
                cad_no_documento += delimit + rowData.no_documento;
            }
            //FIN - Files

            var msg_retorno = "";
            if (fc_Trim($("#txtNomPlantilla").val()) == "") {
                msg_retorno += "- Debe ingresar nombre plantilla.\n";
            }
            if (fc_Trim($("#cboGrupo").val()) == "") {
                msg_retorno += "- Debe seleccionar grupo.\n";
            }
            if (fc_Trim($("#cboSubGrupo").val()) == "") {
                msg_retorno += "- Debe seleccionar sub grupo.\n";
            }
            if ($("#cboEstado").val() == "") {
                msg_retorno += "- Debe seleccionar estado.\n";
            }

            if (msg_retorno != "") {
                alert(msg_retorno);
            }
            else if (confirm('¿Está seguro de guardar el registro?')) {
                var id_plantilla_doc = $("#txtID").val();
                var arr_parametros = new Array();
                arr_parametros[0] = id_plantilla_doc;
                arr_parametros[1] = $("#txtNomPlantilla").val();
                arr_parametros[2] = $("#cboSubGrupo").val();
                arr_parametros[3] = $("#cboEstado").val();
                arr_parametros[4] = $("#cboTipoDocArchivo").multipleSelect("getSelects").toString();
                arr_parametros[5] = cont_ids_caracteristica;
                arr_parametros[6] = ids_PlantillaDoccaracteristica;
                arr_parametros[7] = cad_no_caracteristica;
                arr_parametros[8] = cad_co_tipo_dato_caracteristica;
                arr_parametros[9] = cad_fl_obligatorio_caracteristica;
                arr_parametros[10] = cad_nu_orden_caracteristica;
                arr_parametros[11] = cad_qt_dias_alerta_caracteristica;
                arr_parametros[12] = $("#cboUsuariosResponsables").multipleSelect("getSelects").toString();
                arr_parametros[13] = $("#txtDiasParaAlerta").val();
                arr_parametros[14] = cont_ids_file;
                arr_parametros[15] = ids_PlantillaDoc_File;
                arr_parametros[16] = cad_no_documento;

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

        /*[INICIO] - Funciones para las caracteristicas*/
        //[INICIO] - Carga valores de Tipos de datos
        //var objTipoDatos = "";
        //var strFiltrosTD = "{'codigo':'<%=Parametros.Combo.CDOC_TipoDatos %>'"
        //        + ",'co_padre': ''}";
        //var strUrlServicioTD = "/wsGenerales.asmx/getCombo";
        //this.fc_CallService(strFiltrosTD, strUrlServicioTD,
        //    function (objResponse) {
        //        var states = "";
        //        $.each(objResponse, function (index, value) {
        //            if (index == 0) states += objResponse[index].value + ":" + objResponse[index].nombre;
        //            else states += ";" + objResponse[index].value + ":" + objResponse[index].nombre;
        //        });
        //        objTipoDatos = states;
        //    }
        //);

        function getAllSelectOptions() {
            //objTipoDatos = {"01":'Texto','02':'Fecha','03':'Número'};
            var tipos = { '01': 'Texto', '02': 'Fecha', '03': 'Número'/*, '04': 'Fecha Vencimiento'*/ };
            return tipos;
            //verificar async
            //return objTipoDatos;
        }
        //[FIN] - Carga valores de Tipos de datos

        function inputFormatNumero(cellValue, options, rowObject) {
            var input = "";
            if (rowObject.co_tipo_dato == "04") //Fec. Vencimiento
            {
                input = '<input type="text" value="' + cellValue + '" style="width:50px;" maxlength="3" onkeypress="return fc_SoloNumeros(event);" />';
            }
            return input;
        }
        function inputUnFormatNumero(cellValue, options, cell) {
            return $('input', cell).val();
        }
        function fn_click_caracteristica(rowid) {
            if (rowId_Caracteristica != rowid) {
                $(idGrilla_Caracteristica).saveRow(rowId_Caracteristica); //row seleccionado anteriormente
            }
            rowId_Caracteristica = rowid;
        }
        function fn_dblclick_caracteristica(rowid) {
            $(idGrilla_Caracteristica).editRow(rowid);
        }
        function fn_SetOrdenRowsCaracteristicas() {
            var rowIDs = $(idGrilla_Caracteristica).jqGrid('getDataIDs');
            for (var i = 0; i < rowIDs.length; i++) {
                var rowID = rowIDs[i];
                var rowData = $(idGrilla_Caracteristica).jqGrid('getRowData', rowID);
                var index_RowNum = $(idGrilla_Caracteristica).jqGrid('getInd', rowID);
                rowData.nu_orden = index_RowNum;
                $(idGrilla_Caracteristica).jqGrid('setRowData', rowID, rowData);
            }
        }
        function fn_AgregarItem() {
            var no_caracteristica = $("#txtCaracteristica").val();
            if (no_caracteristica == "") {
                alert('- Debe ingresar característica.');
                $("#txtCaracteristica").focus();
                return;
            }

            var id = (objDatosCaracteristicas.length) * -1;
            var objCaracteristica = { id_plantilla_doc_caracteristica: id, no_caracteristica: no_caracteristica, co_tipo_dato: '01', txt_obligatorio: 'SI', nu_orden: 0, qt_dias_alerta: 0 };
            this.objDatosCaracteristicas.push(objCaracteristica);
            $(idGrilla_Caracteristica).jqGrid('addRowData', id, objCaracteristica);
            this.fn_SetOrdenRowsCaracteristicas();

            $('#txtCaracteristica').val("");
            $('#txtCaracteristica').focus();
        }

        function fn_QuitarItem() {
            var rowId = $(idGrilla_Caracteristica).jqGrid('getGridParam', 'selrow');
            if (rowId == null) {
                alert("- Debe seleccionar una característica.\n");
                return;
            }
            if (confirm('¿Está seguro de quitar la característica?')) {
                $(idGrilla_Caracteristica).jqGrid('delRowData', rowId);
                this.fn_SetOrdenRowsCaracteristicas();
            }
        }
        /*[FIN] - Funciones para las caracteristicas*/

        /*[INICIO] - Funciones para los Files*/
        function fn_AgregarFile() {
            var no_documento = fc_Trim($("#txtDocumento_File").val());
            if (no_documento == "") {
                alert('- Debe ingresar documento.');
                $("#txtDocumento_File").focus();
                return;
            }

            var id = (objDatosFiles.length) * -1;
            var objFile = { id_plantilla_doc_file: id, no_documento: no_documento };
            this.objDatosFiles.push(objFile);
            $(idGrilla_Files).jqGrid('addRowData', id, objFile);

            $('#txtDocumento_File').val("");
            $('#txtDocumento_File').focus();
        }

        function fn_QuitarFile() {
            var rowId = $(idGrilla_Files).jqGrid('getGridParam', 'selrow');
            if (rowId == null) {
                alert("- Debe seleccionar un documento.\n");
                return;
            }
            if (confirm('¿Está seguro de quitar el documento?')) {
                $(idGrilla_Files).jqGrid('delRowData', rowId);
            }
        }
        /*[FIN] - Funciones para los Files*/
    </script>
</asp:Content>
