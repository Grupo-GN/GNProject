<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="MntDocumentos.aspx.cs" Inherits="GNProject.Views.ctrlDoc.Maestros.MntDocumentos" %>


<%@ Import Namespace="GNProject.Acceso" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="pagina1">
        <div class="row linea-bottom">
            <div class="col l4 s12 titulo">Lista de Documentos</div>
            <div class="col l8 s12" style="text-align: right;">
                <button id="btnBuscar" type="button" onclick="fn_Buscar();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/Busqueda-48.png" />Buscar</button>
                <button type="button" onclick="fn_Limpiar();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/Escoba-48.png" />Limpiar</button>
                <button type="button" onclick="fn_Nuevo();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/AñadirLista-48.png" />Nuevo</button>
                <button type="button" onclick="fn_Editar();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/Editar-48.png" />Editar</button>
                <button id="btnAnular" type="button" style="background: none; padding: 0 0 0 10px; border: none; display:none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/Cancelar-48.png" />Anular</button>
                <button id="btnActivar" type="button" style="background: none; padding: 0 0 0 10px; border: none; display:none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/Comprobado-48.png" />Activar</button>
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
                <select id="cboEstado_Busqueda" class="control-form"></select>
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
                <button id="btnArchivar" runat="server" type="button" style="background: none; padding: 0 0 0 10px; border: none; display:none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/Importar-48.png" />Archivar</button>
                <button id="btnDesarchivar" runat="server" type="button" style="background: none; padding: 0 0 0 10px; border: none; display:none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/Exportar-48.png" />Desarchivar</button>
                <%--<button id="btnRenovar" type="button" onclick="fn_Renovar();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/Copiar-48.png" />Renovar</button>--%>
                <button id="btnGuardar" type="button" onclick="fn_Guardar();" style="background: none; padding: 0 0 0 10px; border: none;">
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
            <div class="col l3 m6 s12">
                <span>Grupo</span>
                <select id="cboGrupoDocumento" class="control-form"></select>
            </div>
            <div class="col l3 m6 s12">
                <span>Sub Grupo</span>
                <select id="cboSubGrupoDocumento" class="control-form"></select>
            </div>
            <div class="col l3 m6 s12">
                <span>Plantilla Documento</span>
                <select id="cboPlantillaDocumento" class="control-form"></select>
            </div>
            <div class="col l3 m6 s12">
                <span>Tipo Asignación</span>
                <select id="cboTipoAsignacion" class="control-form"></select>
            </div>
        </div>
        <div class="row">
            <div class="col l3 m6 s12">
                <span>Personal / Empresa</span>
                <select id="cboPersona_Empresa" class="control-form"></select>
            </div>
            <div class="col l3 m6 s12">
                <span>Nombre Documento</span>
                <input id="txtNomDocumento" type="text" class="control-form" />
            </div>
            <div class="col l3 m6 s12">
                <span id="lblFecInicio">Fec. Inicio</span>
                <div>
                    <input id="txtFecInicio" type="text" class="control-form" />
                </div>
            </div>
            <div class="col l3 m6 s12">
                <span>Fec. Vencimiento</span>
                <div>
                    <input id="txtFecVencimiento" type="text" class="control-form" />
                    <input type="hidden" id="txhFlIndeterminado" /> 
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
                <input id="chkReservado" type="checkbox" />
            </div>
        </div>
        <div class="row titulo_section">
            Configuración de Alerta
        </div>
        <div class="row">
            <div class="col l3 m6 s12">
                <span>Usuarios Responsables</span>
                <select id="cboUsuariosResponsables" class="control-form"></select>
            </div>
            <div class="col l3 m6 s12">
                <span>Días Alerta Vencimiento</span>
                <input id="txtDiasParaAlerta" type="text" maxlength="5" class="control-form" />
            </div>
        </div>
        <div class="row">
            <div class="col l4 s12 titulo_section">
                Archivos Asociados
            </div>
            <div class="col l8 s12" style="text-align: right;">
                <button id="btnArchivarArchivo" runat="server" type="button" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/Importar-48.png" />Archivar</button>
                <button id="btnDesarchivarArchivo" runat="server" type="button" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/Exportar-48.png" />Desarchivar</button>
                <button id="btnRenovarArchivo" type="button" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/Copiar-48.png" />Renovar</button>
                <button id="btnNuevoArchivo" type="button" onclick="fn_NuevoArchivo();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/AñadirLista-48.png" />Agregar</button>
                <button id="btnEliminarArchivo" type="button" onclick="fn_EliminarArchivo();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/Cancelar-48.png" />Eliminar</button>
            </div>
        </div>
        <div class="row" style="padding-right: 10px;">
            <span style="text-align: right; font-size: 9px;">(Doble clic para editar)</span>
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
    <div id="modalFileUpload" title="Documento Asociado">
        <div id="divmodalFileUpload_General">
            <input id="hdfIDDocumentoFile" type="hidden" />
            <input id="txhIDDocumentoFile_Renov" type="hidden" />
            <div class="row">
                <div class="col l4 s4">
                    <label>Tipo Documento</label>
                </div>
                <div class="col l8 s8">
                    <select id="cboTipoDoc_FU" class="control-form"></select>
                </div>
            </div>
            <div class="row">
                <div class="col l4 s4">
                    <label>Nombre</label>
                </div>
                <div class="col l8 s8">
                    <input id="txtNombreFile" type="text" maxlength="250" class="control-form" />
                </div>
            </div>
            <div class="row">
                <div class="col l4 s4">
                    <label>Archivo</label>
                </div>
                <div class="col l8 s8">
                    <div id="divEnlaceFile"></div>
                    <input type="file" id="fileArchivo" class="control-form" />
                </div>
            </div>
            <div class="row">
                <div class="col l4 s4">
                    <label>Control Principal</label>
                </div>
                <div class="col l8 s8">
                    <input id="chkPrincipal_FU" type="checkbox" />
                </div>
            </div>
            <div class="row">
                <div class="col l4 s4">
                    <label>Activar Alerta Vencimiento</label>
                </div>
                <div class="col l8 s8">
                    <input id="chkActivarAlerta_FU" type="checkbox" />
                </div>
            </div>
            <div id="divVencimiento_FU">
                <div class="row">
                    <div class="col l4 s4">
                        <label>Fec. Inicio</label>
                    </div>
                    <div class="col l8 s8">
                        <input id="txtFecInicio_FU" type="text" class="control-form" />
                    </div>
                </div>
                <div class="row">
                    <div class="col l4 s4">
                        <label>Fec. Vencimiento</label>
                    </div>
                    <div class="col l8 s8">
                        <input id="txtFecVencimiento_FU" type="text" class="control-form" />
                    </div>
                </div>
                <div class="row">
                    <div class="col l4 s4">
                        <label>Usuarios Responsables</label>
                    </div>
                    <div class="col l8 s8">
                        <select id="cboUsuariosResponsables_FU" class="control-form"></select>
                    </div>
                </div>
                <div class="row">
                    <div class="col l4 s4">
                        <label>Días Alerta Vencimiento</label>
                    </div>
                    <div class="col l8 s8">
                        <input id="txtDiasParaAlerta_FU" type="text" class="control-form" style="max-width:50px;" />
                    </div>
                </div>
                <div class="row">
                    <div class="col l4 s4">
                        <label>Reservado</label>
                    </div>
                    <div class="col l8 s8">
                        <input id="chkReservado_FU" type="checkbox" />
                    </div>
                </div>
            </div>
        </div>
        <div style="text-align: center;">
            <div id="uploadFile">
                Guardar Documento Asociado
            </div>
        </div>
    </div>
    <script type="text/javascript">
        var objEstadosDoc;
        var objEstadosDoc_NuevoReg;
        //#region - Variables Grilla Bandeja
        var idGrilla_Bandeja = "#grvBandeja";
        var idPieGrilla_Bandeja = "#grvBandeja_Pie";
        var strCabecera_Bandeja = ['ID', 'Grupo', 'Sub Grupo', 'Plantilla', 'Documento', 'Fec. Inicio', 'Fec. Vencimiento', 'Días para Vencimiento', 'Tipo Asignación', 'Personal / Empresa', 'Id Plantilla', 'CodEstado', 'Estado', 'Cod. Tipo Asignación', 'Id Persona_Empresa', 'IDs Usuarios Responsables', 'Dias Antes Vencimiento Alerta', 'Cod. Grupo', 'Cod. Sub Grupo'];
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
                            { name: 'no_estado', index: 'no_estado', width: 70, sortable: true, align: 'center' },
                            { name: 'co_tipo_asignacion', index: 'co_tipo_asignacion', hidden: true },
                            { name: 'id_persona_empresa', index: 'id_persona_empresa', hidden: true },
                            { name: 'ids_usuarios_responsables', index: 'ids_usuarios_responsables', hidden: true },
                            { name: 'qt_dias_ant_venc_alerta', index: 'qt_dias_ant_venc_alerta', hidden: true },
                            { name: 'co_grupo_doc', index: 'co_grupo_doc', hidden: true },
                            { name: 'co_sub_grupo_doc', index: 'co_sub_grupo_doc', hidden: true }
        ];
        //#endregion - Variables Grilla Bandeja
        //#region - Variables Grilla Bandeja Files
        var objDatosFiles = new Array();
        var idGrilla_Files = "#grvFiles";
        var idPieGrilla_Files = "#grvFiles_Pie";
        var strCabecera_Files = ['ID', 'Cod. Tipo Doc', 'Tipo Documento', 'Nombre', 'Archivo', 'Peso KB', 'no_folder', 'no_file_all', 'Control Principal', 'FL Control Principal', 'Activar Alerta', 'FL Activar Alerta', 'Fec. Inicio', 'Fec. Vencimiento', 'IDs Usuarios Responsables', 'Dias Anticipación Alerta', 'FL Reservado', 'Cod. Estado', 'Estado'];
        var ModelCol_Files = [
                    { name: 'id_documento_file', index: 'id_documento_file', hidden: true },
                    { name: 'co_tipo_doc', index: 'co_tipo_doc', hidden: true},
                    { name: 'no_tipo_doc', index: 'no_tipo_doc', width: 100, sortable: false, align: 'center' },
                    { name: 'no_documento', index: 'no_documento', width: 300, sortable: false },
                    { name: 'no_file', index: 'no_file', width: 100, sortable: false, formatter: fn_linkformat, align: 'center' },
                    { name: 'qt_peso', index: 'qt_peso', width: 100, sortable: false, hidden: true },
                    { name: 'no_folder', index: 'no_folder', hidden: true },
                    { name: 'no_file_all', index: 'no_file_all', hidden: true },
                    { name: 'tx_principal', index: 'tx_principal', width: 100, sortable: false, align: 'center' },
                    { name: 'fl_principal', index: 'fl_principal', width: 100, sortable: false, align: 'center', hidden: true },
                    { name: 'tx_activar_alerta', index: 'tx_activar_alerta', width: 100, sortable: false, align: 'center' },
                    { name: 'fl_activar_alerta', index: 'fl_activar_alerta', width: 100, sortable: false, align: 'center', hidden: true },
                    { name: 'sfe_inicio', index: 'sfe_inicio', width: 100, sortable: false, align: 'center' },
                    { name: 'sfe_vencimiento', index: 'sfe_vencimiento', width: 100, sortable: false, align: 'center' },
                    { name: 'ids_usuarios_responsables', index: 'ids_usuarios_responsables', hidden: true },
                    { name: 'qt_dias_ant_venc_alerta', index: 'qt_dias_ant_venc_alerta', hidden: true },
                    { name: 'fl_reservado', index: 'fl_reservado', width: 100, sortable: false, align: 'center', hidden: true },
                    { name: 'co_estado', index: 'co_estado', hidden: true },
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
                            , formatter: inputFormat, unformat: inputUnFormat
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

        $("#cboGrupoDocumento").change(function (event) {
            var value = $(this).val();
            if (value == "") {
                fc_FillCombo("cboSubGrupoDocumento", [], textSeleccione);
                $("#cboSubGrupoDocumento").trigger("change");
            }
            else {
                var sendInfo = "{'codigo':'<%=Parametros.Combo.CDOC_SubGruposDocumento %>', 'co_padre':'" + value + "'}";
                var urlService = "/wsGenerales.asmx/getCombo";
                fc_CallService(sendInfo, urlService, function (objResponse) {
                    this.fc_FillCombo("cboSubGrupoDocumento", objResponse, textSeleccione);
                    $("#cboSubGrupoDocumento").trigger("change");
                });
            }
        });

        $("#cboSubGrupoDocumento").change(function (event) {
            var value = $(this).val();
            if (value == "") {
                fc_FillCombo("cboPlantillaDocumento", [], textSeleccione);
                $("#cboPlantillaDocumento").trigger("change");
            }
            else {
                var sendInfo = "{'codigo':'<%=Parametros.Combo.PLANTILLA_DOCUMENTOS %>', 'co_padre':'" + value + "'}";
                var urlService = "/wsGenerales.asmx/getCombo";
                fc_CallService(sendInfo, urlService, function (objResponse) {
                    this.fc_FillCombo("cboPlantillaDocumento", objResponse, textSeleccione);
                    $("#cboPlantillaDocumento").trigger("change");
                });
            }
        });

        function fn_GetDatosPlantilla(id_plantilla_doc) {
            if (id_plantilla_doc != "") {
                var strFiltros = "{'id_plantilla_doc':" + id_plantilla_doc + "}";
                var strUrlServicio = page + "/Get_DatosPlantilla";
                this.fc_CallService(strFiltros, strUrlServicio,
                    function (objResponse) {
                        JQGrid_Util.GetTabla_Local(this.idGrilla_Caracteristica, this.idPieGrilla_Caracteristica, this.strCabecera_Caracteristica, this.ModelCol_Caracteristica
                            , JQGrid_Opciones_Default, objResponse.objCaracteristicas, fn_click_caracteristica, fn_dblclick_caracteristica, function () { });

                        $("#cboUsuariosResponsables").multipleSelect("setSelects", objResponse["ids_usuarios_responsables"].split(","));
                        $("#cboUsuariosResponsables").trigger("change");
                        $("#txtDiasParaAlerta").val(objResponse["qt_dias_ant_venc_alerta"]);

                        JQGrid_Util.GetTabla_LocalGrouping(this.idGrilla_Files, this.idPieGrilla_Files, this.strCabecera_Files, this.ModelCol_Files
                            , JQGrid_Opciones_Default, objResponse.objFiles, this.nameGroupField_Files, fn_clickBandeja_Files, fn_dblClickBandeja_Files, function () { });

                        this.fc_FillCombo("cboTipoDoc_FU", objResponse.oComboTipoDocArchivo, textSeleccione);
                    }
                );
            }
            else {
                $(idGrilla_Caracteristica).clearGridData(true);
                $("#cboUsuariosResponsables").multipleSelect("uncheckAll");
                $("#txtDiasParaAlerta").val("");

                $(idGrilla_Files).clearGridData(true);
            }
        }

        $("#cboPlantillaDocumento").change(function (event) {
            var value = $(this).val();

            if ("<%=Parametros.CDOC_MODO_RRHH%>" == "1") {
                $("#cboPersona_Empresa").trigger("change");
            }

            fn_GetDatosPlantilla(value);
        });

        $("#cboTipoAsignacion").change(function (event, id_persona_empresa) {
            if ("<%=Parametros.CDOC_MODO_RRHH%>" == "1" && id_persona_empresa == undefined) {
                $("#txtNomDocumento").val("");
                $("#txtFecInicio").val("");
                $("#txtFecVencimiento").val("");
                $("#txhFlIndeterminado").val("");
            }

            var value = $(this).val();
            if (value == "") {
                fc_FillCombo("cboPersona_Empresa", [], textSeleccione);
                $("#cboPersona_Empresa option[value='']").remove();
                $("#cboPersona_Empresa").multipleSelect("refresh");
            }
            else {
                var parametros = "{'codigo':'<%=Parametros.Combo.PERSONA_EMPRESA %>', 'co_padre':'" + value + "'}";
                var urlService = "/wsGenerales.asmx/getCombo";
                fc_CallService(parametros, urlService, function (objResponse) {
                    this.fc_FillCombo("cboPersona_Empresa", objResponse, textSeleccione);
                    $("#cboPersona_Empresa option[value='']").remove();
                    $("#cboPersona_Empresa").multipleSelect("refresh");
                    if (id_persona_empresa > 0) {
                        $("#cboPersona_Empresa").multipleSelect("setSelects", id_persona_empresa.toString().split(","));
                    }
                });
            }
        });

        $("#cboPersona_Empresa").change(function (event) {
            var idDocumento = document.getElementById("txtID").value;
            var codTipoAsig = $("#cboTipoAsignacion").val();
            if (codTipoAsig == "00") //Personal
            {
                $("#lblFecInicio").text("Fec. Ingreso");
                $("#txtFecInicio").prop("disabled", true); 
            }
            else {
                $("#lblFecInicio").text("Fec. Inicio");
                $("#txtFecInicio").prop("disabled", false);
            }

            if (idDocumento == "") {
                if ("<%=Parametros.CDOC_MODO_RRHH%>" == "1") {
                    var value = $("#cboPersona_Empresa").multipleSelect("getSelects").toString();
                    var codPlantilla = $("#cboPlantillaDocumento").val();
                    if (value != "" && codPlantilla != "" && codTipoAsig == "00") {
                        var parametros = "{'id_persona':" + value + "}";
                        var urlService = page + "/getDatosPersona";
                        fc_CallService(parametros, urlService, function (res) {
                            var nomPlantilla = $("#cboPlantillaDocumento option:selected").text();
                            var nomPersona = $("#cboPersona_Empresa").multipleSelect("getSelects", "text").toString();

                            $("#txtNomDocumento").val(nomPlantilla + " / " + $.trim(nomPersona) + " " + res.fe_ingreso);
                            $("#txtFecInicio").val(res.fe_ingreso);
                            $("#txtFecVencimiento").val(res.fe_fin_contrato);
                            $("#txhFlIndeterminado").val(res.fl_indeterminado);
                        });
                    }
                    else {
                        $("#txtNomDocumento").val("");
                        $("#txtFecInicio").val("");
                        $("#txtFecVencimiento").val("");
                        $("#txhFlIndeterminado").val("");
                    }
                }
            }
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

            this.fc_FormatFecha("txtFecInicio", DatePicker_Opciones_Default, "MIN", "txtFecVencimiento");
            this.fc_FormatFecha("txtFecVencimiento", DatePicker_Opciones_Default, "MAX", "txtFecInicio");
            this.fc_FormatNumeros("txtDiasParaAlerta");

            var parametros = "{'codigo':'<%=Parametros.Combo.CDOC_EstadosDocumento %>', 'co_padre':''}";
            var urlService = "/wsGenerales.asmx/getCombo";
            this.fc_CallService(parametros, urlService, function (objResponse) {
                this.fc_FillCombo("cboEstado_Busqueda", objResponse, textTodos);
                $("#cboEstado_Busqueda option[value='']").remove();
                $("#cboEstado_Busqueda").multipleSelect();
                //$("#cboEstado_Busqueda").multipleSelect("checkAll");
                $("#cboEstado_Busqueda").multipleSelect("setSelects", ("01,02,05").split(","));

                objEstadosDoc = objResponse;
                objEstadosDoc_NuevoReg = new Array();
                $.each(objEstadosDoc, function (index, obj) {
                    if (obj.value == "01" || obj.value == "02" || obj.value == "05") {
                        objEstadosDoc_NuevoReg.push({ "value": obj.value, "nombre": obj.nombre });
                    }
                });
            });

            var parametros = "{'codigo':'<%=Parametros.Combo.TIPO_ASIGNACION %>', 'co_padre':''}";
            var urlService = "/wsGenerales.asmx/getCombo";
            this.fc_CallService(parametros, urlService, function (objResponse) {
                $("#cboPersona_Empresa_Busqueda").multipleSelect({ filter: true });
                $("#cboPersona_Empresa").multipleSelect({ filter: true, single: true });

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

            var parametros = "{'codigo':'<%=Parametros.Combo.CDOC_TipoDoc_Archivos %>', 'co_padre':''}";
            var urlService = "/wsGenerales.asmx/getCombo";
            this.fc_CallService(parametros, urlService, function (objResponse) {
                this.fc_FillCombo("cboTipoDoc_Busqueda", objResponse, textTodos);
                $("#cboTipoDoc_Busqueda option[value='']").remove();
                $("#cboTipoDoc_Busqueda").multipleSelect();
            });

            var parametros = "{'codigo':'<%=Parametros.Combo.USUARIOS%>'" + ",'co_padre': ''}";
            var urlService = "/wsGenerales.asmx/getCombo";
            this.fc_CallService(parametros, urlService, function (objResponse) {
                this.fc_FillCombo("cboUsuariosResponsables", objResponse, textSeleccione);
                $("#cboUsuariosResponsables option[value='']").remove();
                $("#cboUsuariosResponsables").multipleSelect({ filter: true });

                this.fc_FillCombo("cboUsuariosResponsables_FU", objResponse, textSeleccione);
                $("#cboUsuariosResponsables_FU option[value='']").remove();
                $("#cboUsuariosResponsables_FU").multipleSelect({ filter: true });
            });

            var objResponse = [];
            JQGrid_Util.AutoWidthResponsive(idGrilla_Bandeja);
            JQGrid_Util.AutoWidthResponsive(idGrilla_Caracteristica);
            JQGrid_Util.AutoWidthResponsive(idGrilla_Files);
            JQGrid_Util.GetTabla_Local(idGrilla_Bandeja, idPieGrilla_Bandeja, strCabecera_Bandeja, ModelCol_Bandeja, JQGrid_Opciones_Default, objResponse, function () { }, function () { }, function () { });
            
            this.fc_Modal("modalFileUpload", true, function () { });

            //this.fc_FormatFecha("txtFecInicio_FU", DatePicker_Opciones_Default, "MIN", "txtFecVencimiento_FU");
            //this.fc_FormatFecha("txtFecVencimiento_FU", DatePicker_Opciones_Default, "MAX", "txtFecInicio_FU");
            this.fc_FormatFecha("txtFecInicio_FU", DatePicker_Opciones_Default, "", "");
            this.fc_FormatFecha("txtFecVencimiento_FU", DatePicker_Opciones_Default, "", "");
            this.fc_FormatNumeros("txtDiasParaAlerta_FU");
        }

        function fn_Limpiar() {
            $("#btnAnular").hide();
            $("#btnActivar").hide();

            $("#cboGrupoDocumento_Busqueda").val("").trigger("change");
            $("#txtNomDocumento_Busqueda").val("");
            $("#cboTipoAsignacion_Busqueda").val("").trigger("change");
            //$("#cboEstado_Busqueda").multipleSelect("checkAll");
            $("#cboEstado_Busqueda").multipleSelect("setSelects", ("01,02,05").split(","));
            $("#txtFecVencimiento_Desde").val("");
            $("#txtFecVencimiento_Hasta").val("");
            $("#cboTipoDoc_Busqueda").multipleSelect("uncheckAll");
            JQGrid_Util.clearData(idGrilla_Bandeja);
        }

        function fn_Buscar() {
            $("#btnAnular").hide();
            $("#btnActivar").hide();

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
                , fn_clickBandeja, fn_dblClickBandeja, function () { });
        }
        function fn_clickBandeja(rowID) {
            var rowData = JQGrid_Util.getRowDataSelected(idGrilla_Bandeja);
            $("#btnAnular").hide();
            $("#btnActivar").hide();
            if (rowData.co_estado != "<%=Parametros.EstadosDocumento.Anulado%>") {
                $("#btnAnular").show();
            }
            if (rowData.co_estado == "<%=Parametros.EstadosDocumento.Anulado%>") {
                $("#btnActivar").show();
            }
        }
        function fn_dblClickBandeja(rowID) {
            fn_Editar(rowID, undefined);
        }
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
            var strUrlServicio = page + "/Get_Documento";
            this.fc_CallService(strFiltros, strUrlServicio, function (objResponse) {
                rowData = objResponse;
                //Cambia de TAB
                //if (rowData["co_estado"] == "<%=Parametros.EstadosDocumento.Vigente%>") {
                //    $("#btnRenovar").show();
                //}
                //else {
                //    $("#btnRenovar").hide();
                //}
                
                $("#<%=btnArchivar.ClientID%>").hide();
                $("#<%=btnDesarchivar.ClientID%>").hide();
                if (rowData["co_estado"] == "<%=Parametros.EstadosDocumento.Archivado%>") {
                    $("#<%=btnDesarchivar.ClientID%>").show();
                }
                if (rowData["co_estado"] == "<%=Parametros.EstadosDocumento.Vigente%>" || rowData["co_estado"] == "<%=Parametros.EstadosDocumento.VencidoPorRenovar%>") {
                    $("#<%=btnArchivar.ClientID%>").show();
                }


                if (rowData["co_estado"] != "<%=Parametros.EstadosDocumento.Anulado%>") {
                    $("#btnGuardar").show();
                    
                    $("#btnNuevoArchivo").show();
                    $("#btnEliminarArchivo").show();
                }
                else {
                    $("#btnGuardar").hide();
                    
                    $("#btnNuevoArchivo").hide();
                    $("#btnEliminarArchivo").hide();
                }

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
                $("#cboTipoAsignacion").prop("disabled", true);
                $("#cboPersona_Empresa").multipleSelect("disable");
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
                
                $("#cboUsuariosResponsables").multipleSelect("setSelects", rowData["ids_usuarios_responsables"].split(","));
                $("#cboUsuariosResponsables").trigger("change");
                document.getElementById("txtDiasParaAlerta").value = rowData["qt_dias_ant_venc_alerta"];

                $("#chkReservado").prop("checked", rowData["fl_reservado"]);

                $("#txtFecInicio").prop("disabled", true);
                $("#txtFecInicio + .ui-datepicker-trigger").css("display", "none");
                $("#txtFecVencimiento").prop("disabled", true);
                $("#txtFecVencimiento + .ui-datepicker-trigger").css("display", "none");

                //carga caracteristicas
                var strFiltros = "{'id_documento':" + rowData["id_documento"] + "}";
                var strUrlServicio = page + "/Get_Documento_Caracteristica";
                this.fc_CallService(strFiltros, strUrlServicio,
                    function (objResponse) {
                        JQGrid_Util.GetTabla_Local(this.idGrilla_Caracteristica, this.idPieGrilla_Caracteristica, this.strCabecera_Caracteristica, this.ModelCol_Caracteristica
                            , JQGrid_Opciones_Default, objResponse, fn_click_caracteristica, fn_dblclick_caracteristica, function () { });

                        //carga Files
                        strFiltros = "{'id_documento':" + rowData["id_documento"] + "}";
                        strUrlServicio = page + "/Get_ListaDocumento_Files";
                        this.fc_CallService(strFiltros, strUrlServicio, function (objResponse) {
                            $("#<%=btnArchivarArchivo.ClientID%>").hide();
                            $("#<%=btnDesarchivarArchivo.ClientID%>").hide();
                            $("#btnRenovarArchivo").hide();

                            JQGrid_Util.GetTabla_LocalGrouping(this.idGrilla_Files, this.idPieGrilla_Files, this.strCabecera_Files, this.ModelCol_Files
                                , JQGrid_Opciones_Default, objResponse, this.nameGroupField_Files, fn_clickBandeja_Files, fn_dblClickBandeja_Files, function () { });
                        });
                    }
                );

                this.fc_FillCombo("cboTipoDoc_FU", rowData.oComboTipoDocArchivo, textSeleccione);

                document.getElementById("cboPlantillaDocumento").focus();
            });
        }
        $("#btnAnular").click(function () {
            var rowId = $("#grvBandeja").jqGrid('getGridParam', 'selrow');
            if (rowId == null) {
                alert("- Debe seleccionar un registro.\n");
                return;
            }

            var msg_retorno = "";
            var rowData = jQuery("#grvBandeja").getRowData(rowId);
            var id_documento = rowData["id_documento"];
            var co_estado = rowData["co_estado"];
            if (co_estado == "<%=Parametros.EstadosDocumento.Anulado%>") {
                msg_retorno += "- El registro ya se encuentra anulado.\n";
            }

            if (msg_retorno != "") {
                alert(msg_retorno);
            }
            else if (confirm("¿Está seguro de anular el registro?")) {
                var arr_parametros = new Array();
                arr_parametros[0] = id_documento;
                var parametros = "{'strParametros':" + JSON.stringify(arr_parametros) + "}";
                var urlService = page + "/Eliminar";
                fc_CallService(parametros, urlService, function (objResponse) {
                    if (objResponse[0] > 0) {
                        this.fn_Buscar();
                    }
                    alert(objResponse[1]);
                });
            }
        });

        $("#btnActivar").click(function () {
            var rowId = $("#grvBandeja").jqGrid('getGridParam', 'selrow');
            if (rowId == null) {
                alert("- Debe seleccionar un registro.\n");
                return;
            }

            var msg_retorno = "";
            var rowData = jQuery("#grvBandeja").getRowData(rowId);
            var id_documento = rowData["id_documento"];
            var co_estado = rowData["co_estado"];
            if (co_estado != "<%=Parametros.EstadosDocumento.Anulado%>") {
                msg_retorno += "- El registro debe tener el estado anulado.\n";
            }

            if (msg_retorno != "") {
                alert(msg_retorno);
            }
            else if (confirm("¿Está seguro de activar el registro?")) {
                var arr_parametros = new Array();
                arr_parametros[0] = id_documento;
                var parametros = "{'strParametros':" + JSON.stringify(arr_parametros) + "}";
                var urlService = page + "/Activar";
                fc_CallService(parametros, urlService, function (objResponse) {
                    if (objResponse[0] > 0) {
                        this.fn_Buscar();
                    }
                    alert(objResponse[1]);
                });
            }
        });

        function fn_Nuevo() {
            var rowId = $("#grvBandeja").jqGrid('getGridParam', 'selrow');
            if (rowId != null) {
                $("#grvBandeja").resetSelection();

                $("#btnAnular").hide();
                $("#btnActivar").hide();
            }

            //Cambia de TAB
            //$("#btnRenovar").hide();
            $("#<%=btnArchivar.ClientID%>").hide();
            $("#<%=btnDesarchivar.ClientID%>").hide();
            $("#btnGuardar").show();

            $("#<%=btnArchivarArchivo.ClientID%>").hide();
            $("#<%=btnDesarchivarArchivo.ClientID%>").hide();
            $("#btnRenovarArchivo").hide();
            $("#btnNuevoArchivo").show();
            $("#btnEliminarArchivo").show();

            document.getElementById("pagina1").style.display = 'none';
            $("#pagina2").fadeIn();
            document.getElementById("lblTituloTab2").innerHTML = "Nuevo ";

            this.fn_Limpiar_Editar();

            this.fc_FillCombo("cboEstado", objEstadosDoc_NuevoReg, textSeleccione);
            var cboEstado = document.getElementById("cboEstado");
            cboEstado.value = "01";
            //cboEstado.disabled = true;

            $("#cboGrupoDocumento").prop("disabled", false);
            $("#cboSubGrupoDocumento").prop("disabled", false);
            $("#cboPlantillaDocumento").prop("disabled", false);

            var sendInfo = "{'codigo':'<%=Parametros.Combo.CDOC_GruposDocumento %>'"
            + ",'co_padre': ''}";
            var urlService = "/wsGenerales.asmx/getCombo";
            this.fc_CallService(sendInfo, urlService, function (objResponse) {
                this.fc_FillCombo("cboGrupoDocumento", objResponse, textSeleccione);
                //$("#cboGrupoDocumento").trigger("change");
                document.getElementById("cboGrupoDocumento").focus();
            });
        }

        function fn_Limpiar_Editar() {
            idRenov = "";
            this.fn_BloquearDatosRenovacion(false);
            document.getElementById("txtID").value = "";
            $("#cboGrupoDocumento").val("").trigger("change");
            document.getElementById("txtNomDocumento").value = "";
            document.getElementById("txtFecInicio").value = "";
            document.getElementById("txtFecVencimiento").value = "";
            document.getElementById("txhFlIndeterminado").value = "";
            document.getElementById("cboEstado").value = "";
            $("#cboTipoAsignacion").val("").trigger("change");
            $("#chkReservado").prop("checked", false);

            $("#txtFecInicio").prop("disabled", false);
            $("#txtFecInicio + .ui-datepicker-trigger").css("display", "");
            $("#txtFecVencimiento").prop("disabled", false);
            $("#txtFecVencimiento + .ui-datepicker-trigger").css("display", "");

            //Carga cabecera de caracteristicas
            this.objDatosCaracteristicas = [];
            //Variables Grilla
            JQGrid_Util.GetTabla_Local(this.idGrilla_Caracteristica, this.idPieGrilla_Caracteristica, this.strCabecera_Caracteristica, this.ModelCol_Caracteristica
                , JQGrid_Opciones_Default, this.objDatosCaracteristicas, fn_click_caracteristica, fn_dblclick_caracteristica, function () { });

            //Carga cabecera de Files
            this.objDatosFiles = [];
            JQGrid_Util.GetTabla_LocalGrouping(this.idGrilla_Files, this.idPieGrilla_Files, this.strCabecera_Files, this.ModelCol_Files
                , JQGrid_Opciones_Default, this.objDatosFiles, this.nameGroupField_Files, fn_clickBandeja_Files, fn_dblClickBandeja_Files, function () { });
        }

        $("#<%=btnArchivar.ClientID%>").click(function () {
            var idDocumento = document.getElementById("txtID").value;
            if (idDocumento == "") {
                alert("- Debe grabar el registro antes de archivar.\n");
                return;
            }

            var codEstado = $("#cboEstado").val();
            if (codEstado != "<%=Parametros.EstadosDocumento.Vigente%>" && codEstado != "<%=Parametros.EstadosDocumento.VencidoPorRenovar%>") {
                alert("- Para archivar el documento debe estar en estado Vigente o Vencido por Renovar.\n");
                return;
            }

            if (confirm("¿Está seguro de archivar el documento?")) {
                var arr_parametros = new Array();
                arr_parametros[0] = idDocumento;
                var parametros = "{'strParametros':" + JSON.stringify(arr_parametros) + "}";
                var urlService = page + "/Archivar";
                fc_CallService(parametros, urlService, function (objResponse) {
                    if (objResponse[0] > 0) {
                        fn_Volver();
                        fn_Buscar();
                    }
                    alert(objResponse[1]);
                });
            }
        });

        $("#<%=btnDesarchivar.ClientID%>").click(function () {
            var idDocumento = document.getElementById("txtID").value;
            if (idDocumento == "") {
                alert("- Debe grabar el registro antes de desarchivar.\n");
                return;
            }

            var codEstado = $("#cboEstado").val();
            if (codEstado != "<%=Parametros.EstadosDocumento.Archivado %>") {
                alert("- El estado debe ser archivado.\n");
                return;
            }

            if (confirm("¿Está seguro de desarchivar el documento?")) {
                var arr_parametros = new Array();
                arr_parametros[0] = idDocumento;
                var parametros = "{'strParametros':" + JSON.stringify(arr_parametros) + "}";
                var urlService = page + "/Desarchivar";
                fc_CallService(parametros, urlService, function (objResponse) {
                    if (objResponse[0] > 0) {
                        fn_Volver();
                        fn_Buscar();
                    }
                    alert(objResponse[1]);
                });
            }
        });

        function fn_Guardar() {
            var cont_ids_caracteristica = 0;
            var ids_documento_caracteristica = "";
            var cad_no_caracteristica = "";
            var cad_co_tipo_dato_caracteristica = "";
            var cad_no_valor_dato_caracteristica = "";
            var cad_fl_obligatorio_caracteristica = "";
            var cad_nu_orden_caracteristica = "";
            var cad_no_archivo_caracteristica = "";

            var rowIDs = $(idGrilla_Caracteristica).jqGrid('getDataIDs');
            var delimit = "";
            for (var i = 0; i < rowIDs.length; i++) {
                var rowID = rowIDs[i];
                var rowData = $(idGrilla_Caracteristica).jqGrid('getRowData', rowID);

                if (rowData.txt_obligatorio == "SI" && rowData.no_valor_dato == "" && rowData.co_tipo_dato != "04") {
                    alert("- Debe ingresar todos los valores obligatorios de las características.");
                    return;
                }
                else if (rowData.txt_obligatorio == "SI" && rowData.co_tipo_dato == "04"
                            && (rowData.no_valor_dato == "" || rowData.no_archivo == "")) {
                    alert("- Debe ingresar todos los valores obligatorios con sus respectivos archivos de las características.");
                    return;
                }

                cont_ids_caracteristica += 1;
                if (i > 0) delimit = "|";
                ids_documento_caracteristica += delimit + rowData.id_documento_caracteristica;
                cad_no_caracteristica += delimit + rowData.no_caracteristica;
                cad_co_tipo_dato_caracteristica += delimit + rowData.co_tipo_dato;
                cad_no_valor_dato_caracteristica += delimit + rowData.no_valor_dato;
                cad_fl_obligatorio_caracteristica += delimit + (rowData.txt_obligatorio == "SI" ? "1" : "0");
                cad_nu_orden_caracteristica += delimit + rowData.nu_orden;
                cad_no_archivo_caracteristica += delimit + rowData.no_archivo;
            }

            var msg_retorno = "";
            if (fc_Trim($("#cboGrupoDocumento").val()) == "") {
                msg_retorno += "- Debe seleccionar grupo.\n";
            }
            if (fc_Trim($("#cboSubGrupoDocumento").val()) == "") {
                msg_retorno += "- Debe seleccionar sub grupo.\n";
            }
            if (fc_Trim($("#cboPlantillaDocumento").val()) == "") {
                msg_retorno += "- Debe seleccionar plantilla.\n";
            }
            if (fc_Trim($("#txtNomDocumento").val()) == "") {
                msg_retorno += "- Debe ingresar nombre documento.\n";
            }

            if (fc_Trim($("#txtFecInicio").val()) == "") {
                msg_retorno += "- Debe ingresar fecha inicio.\n";
            }
            else if (this.fc_ValidarFecha($("#txtFecInicio").val()) == false) {
                msg_retorno += "- Fecha inicio incorrecto (dd/MM/yyyy).\n";
            }

            
            if ($("#txtID").val() == "" && $("#txhFlIndeterminado").val() != "1" && fc_Trim($("#txtFecVencimiento").val()) == "") {
                msg_retorno += "- Debe ingresar fecha vencimiento.\n";
            }
            if (fc_Trim($("#txtFecVencimiento").val()) != "" && this.fc_ValidarFecha($("#txtFecVencimiento").val()) == false) {
                msg_retorno += "- Fecha vencimiento incorrecto (dd/MM/yyyy).\n";
            }

            if ($("#txtFecInicio").val() != "" && $("#txtFecVencimiento").val() != "") {
                if (this.fc_ValidarRangofechas($("#txtFecInicio").val(), $("#txtFecVencimiento").val()) == false) {
                    msg_retorno += "- La fecha de vencimiento debe ser mayor a la fecha de inicio.\n";
                }
            }

            if ($("#cboEstado").val() == "") {
                msg_retorno += "- Debe seleccionar estado.\n";
            }

            if ($("#cboTipoAsignacion").val() == "") {
                msg_retorno += "- Debe seleccionar tipo asignación.\n";
            }
            else if ($("#cboPersona_Empresa").multipleSelect("getSelects").toString() == "") {
                msg_retorno += "- Debe seleccionar personal / empresa.\n";
            }

            if ($("#cboUsuariosResponsables").multipleSelect("getSelects").toString() == "") {
                msg_retorno += "- Debe seleccionar al menos un usuario responsable.\n";
            }
            var qt_dias_ant_venc_alerta = fc_Trim($("#txtDiasParaAlerta").val());
            if (msg_retorno != "") {
                alert(msg_retorno);
            }
            else if (qt_dias_ant_venc_alerta <= 0) {
                msg_retorno += "- Los días de anticipación para el envío de alerta debe ser mayor a 0.\n";
                alert(msg_retorno);
            }
            else if (confirm('¿Está seguro de guardar el registro?')) {
                var id_documento = $("#txtID").val();
                var arr_parametros = new Array();
                arr_parametros[0] = id_documento;
                arr_parametros[1] = $("#cboPlantillaDocumento").val();
                arr_parametros[2] = $("#txtNomDocumento").val();
                arr_parametros[3] = $("#cboTipoAsignacion").val();
                arr_parametros[4] = $("#cboPersona_Empresa").multipleSelect("getSelects").toString();
                arr_parametros[5] = $("#txtFecInicio").val();
                arr_parametros[6] = $("#txtFecVencimiento").val();
                arr_parametros[7] = $("#cboUsuariosResponsables").multipleSelect("getSelects").toString();
                arr_parametros[8] = $("#txtDiasParaAlerta").val();
                arr_parametros[9] = $("#cboEstado").val();
                arr_parametros[10] = cont_ids_caracteristica;
                arr_parametros[11] = ids_documento_caracteristica;
                arr_parametros[12] = cad_no_caracteristica;
                arr_parametros[13] = cad_co_tipo_dato_caracteristica;
                arr_parametros[14] = cad_no_valor_dato_caracteristica;
                arr_parametros[15] = cad_fl_obligatorio_caracteristica;
                arr_parametros[16] = cad_nu_orden_caracteristica;
                arr_parametros[17] = cad_no_archivo_caracteristica;
                arr_parametros[18] = idRenov;
                arr_parametros[19] = $("#chkReservado").prop("checked");
                var parametros = "{'strParametros':" + JSON.stringify(arr_parametros) + "}";
                var urlService = page + "/Guardar";
                this.fc_CallService(parametros, urlService, function (objResponse) {
                    if (objResponse[0] > 0) {
                        idRenov = "";
                        if (confirm(objResponse[1] + "\n¿Desea seguir editando los datos del documento.?")) {
                            $("#txtID").val(objResponse[0]);
                            fn_Editar(undefined, objResponse[0]);
                        }
                        else {
                            this.fn_Volver();
                            this.fn_Buscar();
                        }
                    }
                    else {
                        alert(objResponse[1]);
                    }
                });
            }
        }

        function fn_Volver() {
            $("#pagina1").fadeIn();
            document.getElementById("pagina2").style.display = 'none';
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

        function fn_EliminarArchivo() {
            var strIdPersona = document.getElementById("txtID").value;
            if (strIdPersona == "") {
                alert("- Debe grabar el registro antes de eliminar archivos.\n");
                return;
            }

            var rowId = $(idGrilla_Files).jqGrid('getGridParam', 'selrow');
            if (rowId == null) {
                alert("- Debe seleccionar un registro.\n");
                return;
            }
            if (confirm('¿Está seguro de eliminar el registro?')) {
                var parametros = new Array();

                var rowData = jQuery("#grvFiles").getRowData(rowId);
                var id_documento_file = rowData['id_documento_file'];

                parametros[0] = id_documento_file;
                parametros[1] = "<%=ClaseGlobal.Get_login_usuario()%>";
                parametros[2] = "<%=ClaseGlobal.getUsuarioRed()%>";
                parametros[3] = "<%=ClaseGlobal.getEstacionRed()%>";

                //Variables Acceso a Datos
                var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
                var strUrlServicio = page + "/EliminarDocumento_File";
                this.fc_CallService(strParametros, strUrlServicio,
                    function (objResponse) {
                        var retorno = objResponse[0];
                        var msg_retorno = objResponse[1];
                        if (retorno > 0) {
                            //OK
                            var strIdDocumento = document.getElementById("txtID").value;
                            fn_Editar(undefined, strIdDocumento);
                            alert(msg_retorno);

                        }
                        else {
                            //ERROR
                            alert(msg_retorno);
                        }
                    }
                );
            }
        }

        function fn_clickBandeja_Files(rowID) {
            var rowData = JQGrid_Util.getRowDataSelected(idGrilla_Files);
            $("#<%=btnArchivarArchivo.ClientID%>").hide();
            $("#<%=btnDesarchivarArchivo.ClientID%>").hide();
            $("#btnRenovarArchivo").hide();

            if (rowData.co_estado == "<%=Parametros.EstadosDocumento.Archivado%>") {
                $("#<%=btnDesarchivarArchivo.ClientID%>").show();
            }
            if (rowData.co_estado == "<%=Parametros.EstadosDocumento.Vigente%>" || rowData.co_estado == "<%=Parametros.EstadosDocumento.VencidoPorRenovar%>") {
                $("#<%=btnArchivarArchivo.ClientID%>").show();
                $("#btnRenovarArchivo").show();
            }
        }

        function fn_dblClickBandeja_Files(rowID) {
            var rowData = JQGrid_Util.getRowData(idGrilla_Files, rowID);

            var strIdPersona = document.getElementById("txtID").value;
            var strMensaje = "";
            if (strIdPersona == "") {
                strMensaje += "- Debe grabar el registro antes de editar archivos\n";
            }
            if (strMensaje != "") {
                alert(strMensaje);
                return;
            }

            var codEstado = $("#cboEstado").val();
            if (codEstado != "<%=Parametros.EstadosDocumento.Anulado%>") {
                if (rowData["co_estado"] == ""
                    || rowData["co_estado"] == "<%=Parametros.EstadosDocumento.Vigente%>" || rowData["co_estado"] == "<%=Parametros.EstadosDocumento.VencidoPorRenovar%>") {
                    $("#txhIDDocumentoFile_Renov").val("");
                    document.getElementById("hdfIDDocumentoFile").value = rowData["id_documento_file"];
                    document.getElementById("cboTipoDoc_FU").value = rowData["co_tipo_doc"];
                    document.getElementById("txtNombreFile").value = rowData["no_documento"];
                    document.getElementById("fileArchivo").value = "";
                    $("#divEnlaceFile").html("");

                    document.getElementById("txtFecInicio_FU").value = rowData["sfe_inicio"];
                    document.getElementById("txtFecVencimiento_FU").value = rowData["sfe_vencimiento"];
                    $("#chkPrincipal_FU").prop("checked", (rowData["fl_principal"] == "1" ? true : false));
                    $("#chkActivarAlerta_FU").prop("checked", (rowData["fl_activar_alerta"] == "1" ? true : false));
                    $("#cboUsuariosResponsables_FU").multipleSelect("setSelects", rowData["ids_usuarios_responsables"].split(","));
                    $("#cboUsuariosResponsables_FU").trigger("change");
                    document.getElementById("txtDiasParaAlerta_FU").value = rowData["qt_dias_ant_venc_alerta"];
                    $("#chkReservado_FU").prop("checked", rowData["fl_reservado"] == "1" ? true : false);

                    $("#modalFileUpload").dialog("open");

                    if (rowData["no_file"] == "") {
                        $("#fileArchivo").show();
                    }
                    else {
                        $("#fileArchivo").hide();
                        $("#divEnlaceFile").append(rowData["no_file"]);
                        $("#divEnlaceFile").append("<img src='../img/img_buttons/icono_cerrar.png' style='width:20px;cursor:pointer;' title='Quitar' onclick='fn_OcultarArchivo()' />");
                    }
                }
            }
        }

        function fn_OcultarArchivo() {
            $("#divEnlaceFile").html("");
            $("#fileArchivo").show();
        }

        $("#<%=btnArchivarArchivo.ClientID%>").click(function () {
            var strIdPersona = document.getElementById("txtID").value;
            if (strIdPersona == "") {
                alert("- Debe grabar el registro antes de archivar.\n");
                return;
            }

            var rowId = $(idGrilla_Files).jqGrid('getGridParam', 'selrow');
            if (rowId == null) {
                alert("- Debe seleccionar un registro.\n");
                return;
            }

            var rowData = JQGrid_Util.getRowData(idGrilla_Files, rowId);
            if (rowData.co_estado != "<%=Parametros.EstadosDocumento.Vigente%>" && rowData.co_estado != "<%=Parametros.EstadosDocumento.VencidoPorRenovar%>") {
                alert("- Para archivar el documento debe estar en estado Vigente o Vencido por Renovar.\n");
                return;
            }

            if (confirm("¿Está seguro de archivar el documento?")) {
                var arr_parametros = new Array();
                arr_parametros[0] = rowData.id_documento_file;
                var parametros = "{'strParametros':" + JSON.stringify(arr_parametros) + "}";
                var urlService = page + "/ArchivarFile";
                fc_CallService(parametros, urlService, function (objResponse) {
                    if (objResponse[0] > 0) {
                        fn_Editar(undefined, document.getElementById("txtID").value);
                    }
                    alert(objResponse[1]);
                });
            }
        });

        $("#<%=btnDesarchivarArchivo.ClientID%>").click(function () {
            var strIdPersona = document.getElementById("txtID").value;
            if (strIdPersona == "") {
                alert("- Debe grabar el registro antes de desarchivar.\n");
                return;
            }

            var rowId = $(idGrilla_Files).jqGrid('getGridParam', 'selrow');
            if (rowId == null) {
                alert("- Debe seleccionar un registro.\n");
                return;
            }

            var rowData = JQGrid_Util.getRowData(idGrilla_Files, rowId);
            if (rowData.co_estado != "<%=Parametros.EstadosDocumento.Archivado %>") {
                alert("- El estado debe ser archivado.\n");
                return;
            }

            if (confirm("¿Está seguro de desarchivar el documento?")) {
                var arr_parametros = new Array();
                arr_parametros[0] = rowData.id_documento_file;
                var parametros = "{'strParametros':" + JSON.stringify(arr_parametros) + "}";
                var urlService = page + "/DesarchivarFile";
                fc_CallService(parametros, urlService, function (objResponse) {
                    if (objResponse[0] > 0) {
                        fn_Editar(undefined, document.getElementById("txtID").value);
                    }
                    alert(objResponse[1]);
                });
            }
        });

        $("#btnRenovarArchivo").click(function () {
            var strIdPersona = document.getElementById("txtID").value;
            if (strIdPersona == "") {
                alert("- Debe grabar el registro antes de renovar un archivo asociado.\n");
                return;
            }

            var rowId = $(idGrilla_Files).jqGrid('getGridParam', 'selrow');
            if (rowId == null) {
                alert("- Debe seleccionar un registro.\n");
                return;
            }

            var rowData = JQGrid_Util.getRowData(idGrilla_Files, rowId);
            if (rowData.co_estado != "<%=Parametros.EstadosDocumento.Vigente%>" && rowData.co_estado != "<%=Parametros.EstadosDocumento.VencidoPorRenovar%>") {
                alert("- El documento asociado debe estar en estado Vigente o Vencido por Renovar.\n");
                return;
            }

            fn_LimpiarControles_FU();
            $("#txhIDDocumentoFile_Renov").val(rowData.id_documento_file);

            $("#modalFileUpload").dialog("open");
        });

        function fn_NuevoArchivo() {
            var strIdPersona = document.getElementById("txtID").value;
            var strMensaje = "";
            if (strIdPersona == "") {
                strMensaje += "- Debe grabar el registro antes de adjuntar archivos\n";
            }
            if (strMensaje != "") {
                alert(strMensaje);
                return;
            }

            fn_LimpiarControles_FU();

            $("#modalFileUpload").dialog("open");
        }
        function fn_LimpiarControles_FU() {
            $("#divEnlaceFile").html("");
            $("#fileArchivo").show();

            $("#txhIDDocumentoFile_Renov").val("");
            document.getElementById("hdfIDDocumentoFile").value = "";
            $("#cboTipoDoc_FU").val("");
            document.getElementById("txtNombreFile").value = "";
            document.getElementById("fileArchivo").value = "";
            document.getElementById("txtFecInicio_FU").value = "";
            document.getElementById("txtFecVencimiento_FU").value = "";
            $("#chkPrincipal_FU").prop("checked", false);
            $("#chkActivarAlerta_FU").prop("checked", false);
            $("#cboUsuariosResponsables_FU").multipleSelect("uncheckAll");
            document.getElementById("txtDiasParaAlerta_FU").value = "";
            $("#chkReservado_FU").prop("checked", false);
        }

        $("#uploadFile").button().click(function (event) {
            try {
                var objFile = "fileArchivo"; //Id-Input-File
                var strRuta = "<%=Parametros.CDOC_FileServer_RutaDocumentos %>"; //Ruta para el File
                var IDDocumentoFile_Renov = $("#txhIDDocumentoFile_Renov").val();
                var IDDocumentoFile = document.getElementById("hdfIDDocumentoFile").value;
                var co_tipo_doc = $("#cboTipoDoc_FU").val();
                var strNomArchivo = document.getElementById("txtNombreFile").value;
                var strIdDocumento = document.getElementById("txtID").value;
                var strMensaje = "";

                if (strIdDocumento == "") {
                    strMensaje += "- Debe grabar antes de adjuntar archivos.\n";
                }
                if (co_tipo_doc == "") {
                    strMensaje += "- Debe seleccionar tipo de documento.\n";
                }
                if (strNomArchivo == "") {
                    strMensaje += "- Debe ingresar un nombre de archivo.\n";
                }
                if (fc_ExistDisplayControl(objFile)) {
                    if (document.getElementById(objFile).value == "") {
                        strMensaje += "- Debe seleccionar un archivo válido.\n";
                    }
                }

                var fe_inicio = fc_Trim($("#txtFecInicio_FU").val());
                var fe_vencimiento = fc_Trim($("#txtFecVencimiento_FU").val());
                var fl_principal = $("#chkPrincipal_FU").prop("checked");
                var fl_activar_alerta = $("#chkActivarAlerta_FU").prop("checked");
                var ids_usuarios_responsables = $("#cboUsuariosResponsables_FU").multipleSelect("getSelects").toString();
                var qt_dias_ant_venc_alerta = fc_Trim($("#txtDiasParaAlerta_FU").val());
                var fl_reservado = $("#chkReservado_FU").prop("checked");
                if (fl_principal || fl_activar_alerta) {
                    if (fl_principal && fl_activar_alerta == false) {
                        strMensaje += "- Si es control principal, se debe activar la alerta de vencimiento.\n";
                    }

                    if (fe_inicio == "") {
                        strMensaje += "- Debe ingresar fecha de inicio.\n";
                    }
                    else if (fc_ValidarFecha(fe_inicio) == false) {
                        strMensaje += "- Fecha inicio incorrecto (dd/MM/yyyy).\n";
                    }

                    if (fe_vencimiento == "") {
                        strMensaje += "- Debe ingresar fecha de vencimiento.\n";
                    }
                    else if (fc_ValidarFecha(fe_vencimiento) == false) {
                        strMensaje += "- Fecha vencimiento incorrecto (dd/MM/yyyy).\n";
                    }

                    if (fe_inicio != "" && fe_vencimiento != "") {
                        if (fc_ValidarRangofechas(fe_inicio, fe_vencimiento) == false) {
                            strMensaje += "- La fecha de vencimiento debe ser mayor a la fecha de inicio.\n";
                        }
                    }

                    if (ids_usuarios_responsables == "") {
                        strMensaje += "- Debe seleccionar al menos un usuario responsable.\n";
                    }
                    if (qt_dias_ant_venc_alerta <= 0) {
                        strMensaje += "- Los días de anticipación para el envío de alerta debe ser mayor a 0.\n";
                    }
                }

                if (strMensaje != "") {
                    alert(strMensaje);
                    return false;
                }

                var msgConfirm = "¿Está seguro de guardar el archivo asociado?";
                if (fl_principal) { msgConfirm = "¿Está seguro de guardar el archivo asociado y establecerlo como principal?"; }
                if (confirm(msgConfirm)) {
                    if (fc_ExistDisplayControl(objFile)) {
                        //Subir Archivo
                        var strPeso = "<%=Parametros.CDOC_Max_Upload_File %>";
                        var intPeso = parseInt(strPeso);
                        fc_UploadFile(objFile, strRuta, intPeso, function (objRespuesta, intPeso) {
                            var strIndicador = objRespuesta[0];
                            var strMessage = objRespuesta[1];
                            if (strIndicador == "1") {
                                //Grabar EN BD
                                var parametros = new Array();
                                parametros[0] = strIdDocumento;
                                parametros[1] = strNomArchivo;
                                parametros[2] = strMessage;
                                parametros[3] = intPeso;
                                parametros[4] = "<%=ClaseGlobal.Get_login_usuario()%>";
                                parametros[5] = "<%=ClaseGlobal.getUsuarioRed()%>";
                                parametros[6] = "<%=ClaseGlobal.getEstacionRed()%>";
                                parametros[7] = (fl_activar_alerta ? "1" : "0");
                                parametros[8] = fe_inicio;
                                parametros[9] = fe_vencimiento;
                                parametros[10] = IDDocumentoFile;
                                parametros[11] = (fl_principal ? "1" : "0");
                                parametros[12] = qt_dias_ant_venc_alerta;
                                parametros[13] = IDDocumentoFile_Renov;
                                parametros[14] = co_tipo_doc;
                                parametros[15] = ids_usuarios_responsables;
                                parametros[16] = (fl_reservado ? "1" : "0");
                                fn_GrabarFile(parametros)
                            }
                            else {
                                alert('Error:' + strMessage);
                            }
                        });
                    }
                    else {
                        //Grabar EN BD
                        var parametros = new Array();
                        parametros[0] = strIdDocumento;
                        parametros[1] = strNomArchivo;
                        parametros[2] = ""; //Sin archivo para que no se actualice
                        parametros[3] = 0;
                        parametros[4] = "<%=ClaseGlobal.Get_login_usuario()%>";
                        parametros[5] = "<%=ClaseGlobal.getUsuarioRed()%>";
                        parametros[6] = "<%=ClaseGlobal.getEstacionRed()%>";
                        parametros[7] = (fl_activar_alerta ? "1" : "0");
                        parametros[8] = fe_inicio;
                        parametros[9] = fe_vencimiento;
                        parametros[10] = IDDocumentoFile;
                        parametros[11] = (fl_principal ? "1" : "0");
                        parametros[12] = qt_dias_ant_venc_alerta;
                        parametros[13] = IDDocumentoFile_Renov;
                        parametros[14] = co_tipo_doc;
                        parametros[15] = ids_usuarios_responsables;
                        parametros[16] = (fl_reservado ? "1" : "0");
                        fn_GrabarFile(parametros)
                    }
                }
            } catch (ex) {
                alert(ex);
                fc_show_progress(false);
            }
        });
        function fn_GrabarFile(parametros) {
            var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
            var strUrlServicio = page + "/GrabarDocumentoFile";
            this.fc_CallService(strParametros, strUrlServicio, function (objResponse) {
                var retorno = objResponse[0];
                var msg_retorno = objResponse[1];
                if (retorno > 0) {
                    //OK
                    fn_Editar(undefined, document.getElementById("txtID").value);
                    alert(msg_retorno);
                    $("#modalFileUpload").dialog("close");
                }
                else {
                    //ERROR
                    alert(msg_retorno);
                }
            });
        }
        /*[FIN] - Funciones para los Files*/

        /*[INICIO] - Funciones para las caracteristicas*/
        function inputFormat(cellValue, options, rowObject) {
            var input = "";
            var btnEditar = "";
            if (rowObject.co_tipo_dato == "01") //Texto
            {
                input = '<input type="text" value="' + cellValue + '" style="width:90%;" />';
            }
            else if (rowObject.co_tipo_dato == "02" || rowObject.co_tipo_dato == "04") //Fecha y Fecha Vencimiento
            {
                var fl_antes = "1";
                if (rowObject.co_tipo_dato == "04") fl_antes = "0";

                var disabled = "";
                if (rowObject.co_tipo_dato == "04" && rowObject.txt_obligatorio == "SI" && rowObject.no_archivo != "") //Fecha Vencimiento
                {
                    disabled = "disabled=disabled";

                    btnEditar = ' <img id="btnEditar_' + options.rowId + '" src="../img/img_buttons/icono_editar_fecha.png" alt="Actualizar Fechas" title="Actualizar Fechas"' +
                    'border="0" height="20px" onclick="fn_EditarFile(' + options.rowId + ');" style="cursor: pointer;" />';
                }

                input = '<input style="width:80px;" ' + disabled + ' id="txtFec_' + options.rowId + '" type="text" value="' + cellValue + '" onfocus="fn_SetFormatFecha(this, ' + fl_antes + ');" />';
            }
            else if (rowObject.co_tipo_dato == "03") //Número
            {
                input = '<input type="text" value="' + cellValue + '" onkeypress="return fc_SoloNumeros(event);" />';
            }
            else
                input = '<input type="text" value="' + cellValue + '" />';
            return input + btnEditar;
        }
        function inputUnFormat(cellValue, options, cell) {
            return $('input', cell).val();
        }
        function fn_SetFormatFecha(objControl, fl_antes) {
            $("#" + objControl.id).removeAttr('onfocus');
            if (fl_antes == 1) fc_FormatFecha(objControl.id, false, false, "", "0D");
            else fc_FormatFecha(objControl.id, false, false, "0D", "");
            $("#" + objControl.id).focus();
        }
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
        function fn_EditarFile(rowID) {
            var txtFec = "txtFec_" + rowID;
            var objFile = "fuArchivo_" + rowID;
            var btnSubir = "btnSubir_" + rowID;
            var btnEditar = "btnEditar_" + rowID;
            var objEnlace = "enlaceArchivo_" + rowID;
            $("#" + txtFec).attr("disabled", false);
            $("#" + objFile).show();
            $("#" + btnSubir).show();
            $("#" + btnEditar).hide();
            $("#" + objEnlace).text("");
        }

        function fn_SubirFile(rowID) {
            var objFile = "fuArchivo_" + rowID;
            var objEnlace = "enlaceArchivo_" + rowID;
            var btnSubir = "btnSubir_" + rowID;

            var no_file = $("#" + objFile).val();
            if (no_file == "") {
                alert("- Debe seleccionar un archivo.");
                return;
            }

            var strRuta = "<%=Parametros.CDOC_FileServer_RutaDocumentos %>"; //Ruta para el File
            //Subir Archivo
            var strPeso = "<%=Parametros.CDOC_Max_Upload_File %>";
            var intPeso = parseInt(strPeso);
            fc_UploadFile(objFile, strRuta, intPeso, function (objRespuesta, intPeso) {
                var strIndicador = objRespuesta[0];
                var strMessage = objRespuesta[1]; //nombre del archivo

                if (strIndicador == "1") {
                    $("#" + objEnlace).attr("href", fileServer_documentos + strMessage.substr(0, 6) + "/" + strMessage);
                    $("#" + objEnlace).text(strMessage);
                    $("#" + objFile).hide();
                    $("#" + btnSubir).hide();
                }
                else {
                    alert('Error:' + strMessage);
                }
            });
        }
        function fn_click_caracteristica(rowid) {
        }
        function fn_dblclick_caracteristica(rowid) {
        }
        /*[FIN] - Funciones para las caracteristicas*/

        function fn_BloquearDatosRenovacion(fl_block) {
            $("#cboPlantillaDocumento").prop("disabled", fl_block);
            $("#cboEstado").prop("disabled", fl_block);
            $("#cboTipoAsignacion").prop("disabled", fl_block);
            $("#cboPersona_Empresa").multipleSelect((fl_block == true ? "disable" : "enable"));
        }
        var idRenov = "";
        /*
        function fn_Renovar() {
            var id_documento = $("#txtID").val();
            if (id_documento > 0) {
                if (confirm('¿Está seguro de renovar el documento?')) {
                    idRenov = id_documento;

                    $("#btnRenovar").hide();
                    document.getElementById("lblTituloTab2").innerHTML = "Renovación de ";
                    $("#txtID").val("");
                    document.getElementById("txtFecInicio").value = "";
                    document.getElementById("txtFecVencimiento").value = "";
                    this.fn_BloquearDatosRenovacion(true);

                    alert("Por favor, ingresar los nuevos datos del documento.");
                }
            }
        }
        */

        $("#chkActivarAlerta_FU").change(function () {
            var flCheck = $(this).prop("checked");
            if (flCheck) {
                //Setea valores por defecto de la cabecera
                $("#cboUsuariosResponsables_FU").multipleSelect("setSelects", $("#cboUsuariosResponsables").multipleSelect("getSelects"));
                document.getElementById("txtDiasParaAlerta_FU").value = document.getElementById("txtDiasParaAlerta").value;
            }
            else {
                $("#cboUsuariosResponsables_FU").multipleSelect("uncheckAll");
                document.getElementById("txtDiasParaAlerta_FU").value = "";
            }
        });

        $("#cboUsuariosResponsables").change(function () {
            $("#cboUsuariosResponsables+.ms-parent").attr("title", $("#cboUsuariosResponsables").multipleSelect("getSelects", "text").toString());
        });
        $("#cboUsuariosResponsables_FU").change(function () {
            $("#cboUsuariosResponsables_FU+.ms-parent").attr("title", $("#cboUsuariosResponsables_FU").multipleSelect("getSelects", "text").toString());
        });

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
                        var strUrlServicio = page + "/getBandeja_SubGrid_Files";
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