<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="MntPersonas.aspx.cs" Inherits="GNProject.Views.ctrlDoc.Maestros.MntPersonas" %>

<%@ Import Namespace="GNProject.Acceso" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="pagina1">
        <div class="row linea-bottom">
            <div class="col l4 s12 titulo">Lista de Personas</div>
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
                <label>Tipo Documento</label>
            </div>
            <div class="col l3 m4 s8">
                <select id="cboTipoDoc_Bus" class="control-form"></select>
            </div>
            <div class="col l1 m2 s4">
                <label>Nro. Documento</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtNumeroDoc_Bus" type="text" class="control-form" />
            </div>
            <div class="col l1 m2 s4">
                <label>Nombres</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtNombres_Bus" type="text" class="control-form" />
            </div>
        </div>
        <div class="row">
            <div class="col l1 m2 s4">
                <label>Estado</label>
            </div>
            <div class="col l3 m4 s8">
                <select id="cboEstado_Bus" class="control-form">
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
                Persona
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
                <label>Tipo Documento</label>
            </div>
            <div class="col l3 m4 s8">
                <select id="cboTipoDoc" class="control-form"></select>
            </div>
            <div class="col l1 m2 s4">
                <label>Nro. Documento</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtNumeroDoc" type="text" class="control-form" />
            </div>
        </div>
        <div id="trconDNI" class="row">
            <div class="col l1 m2 s4">
                <label>Apellido Paterno</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtApPaterno" type="text" maxlength="30" class="control-form" />
            </div>
            <div class="col l1 m2 s4">
                <label>Apellido Materno</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtApMaterno" type="text" maxlength="30" class="control-form" />
            </div>
            <div class="col l1 m2 s4">
                <label>Nombres</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtNombres" type="text" class="control-form" />
            </div>
        </div>
        <div id="trconRUC" class="row">
            <div class="col l1 m2 s4">
                <label>Razón Social:</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtRazonSocial" type="text" maxlength="90" class="control-form" />
            </div>
            <div class="col l1 m2 s4">
                <label>Contacto</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtContacto" type="text" maxlength="90" class="control-form" />
            </div>
        </div>
        <div class="row">
            <div class="col l1 m2 s4">
                <label>Usuario</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtUsuario" type="text" maxlength="25" class="control-form" />
            </div>
            <div class="col l1 m2 s4">
                <label>Clave</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtClave" type="password" maxlength="25" class="control-form" />
            </div>
            <div class="col l1 m2 s4">
                <label>Perfil</label>
            </div>
            <div class="col l3 m4 s8">
                <select id="cboPerfil" class="control-form"></select>
            </div>
        </div>
        <div class="row titulo_section">
            Datos de Contacto
        </div>
        <div class="row">
            <div class="col l1 m2 s4">
                <label>Teléfono</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtTelefono" type="text" maxlength="10" class="control-form telefono" />
            </div>
            <div class="col l1 m2 s4">
                <label>Celular</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtCelular" type="text" maxlength="10" class="control-form celular" />
            </div>
            <div class="col l1 m2 s4">
                <label>Email</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtEmail" type="text" maxlength="40" class="control-form" />
            </div>
        </div>
        <div class="row">
            <div class="col l1 m2 s4">
                <label>Localidad</label>
            </div>
            <div class="col l3 m4 s8">
                <select id="cboLocalidad" class="control-form"></select>
            </div>
            <div class="col l1 m2 s4">
                <label>Area</label>
            </div>
            <div class="col l3 m4 s8">
                <select id="cboArea" class="control-form"></select>
            </div>
            <div class="col l1 m2 s4">
                <label>Sección</label>
            </div>
            <div class="col l3 m4 s8">
                <select id="cboSeccion" class="control-form"></select>
            </div>
        </div>
        <div class="row titulo_section">
            Datos de Contrato
        </div>
        <div class="row">
            <div class="col l1 m2 s4">
                <label>Cargo</label>
            </div>
            <div class="col l3 m4 s8">
                <select id="cboCargo" class="control-form"></select>
            </div>
            <div class="col l1 m2 s4">
                <label>Planilla</label>
            </div>
            <div class="col l3 m4 s8">
                <select id="cboPlanilla" class="control-form"></select>
            </div>
            <div class="col l1 m2 s4">
                <label>Tipo Contrato</label>
            </div>
            <div class="col l3 m4 s8">
                <select id="cboTipoContrato" class="control-form"></select>
            </div>
        </div>
        <div class="row">
            <div class="col l1 m2 s4">
                <label>Fecha Ingreso</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtFIngreso" type="text" class="control-form" />
            </div>
            <div class="col l1 m2 s4">
                <label>Fecha Cese</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtFCese" type="text" class="control-form" />
            </div>
            <div class="col l1 m2 s4">
                <label>Motivo Cese</label>
            </div>
            <div class="col l3 m4 s8">
                <select id="cboMotivoCese" class="control-form"></select>
            </div>
        </div>
        <div class="row">
            <div class="col l1 m2 s4">
                <label>Fec. Inicio Contrato</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtFIniContrato" type="text" class="control-form" />
            </div>
            <div class="col l1 m2 s4">
                <label>Fec. Fin Contrato</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtFFinContrato" type="text" class="control-form" />
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
        <div class="row">
            <div class="col l1 m2 s4">
                <label>Jefe Inmediato</label>
            </div>
            <div class="col l3 m4 s8">
                <select id="cboJefe" class="control-form"></select>
            </div>
            <div class="col l1 m2 s4">
                <label>Foto</label>
            </div>
            <div class="col l3 m4 s8">
                <input type="file" id="fileArchivo_Foto" class="control-form" />
                <div id="divFoto">
                </div>
                <a id="enlaceFoto" href="#" target="_blank"></a>
                <img id="imgEliminarFoto" alt="Eliminar Foto" onclick="fn_EliminarFoto();" title="Eliminar Foto"
                    src="../img/img_buttons/icono_cerrar.png" style="width: 20px; cursor: pointer;" />
            </div>
        </div>
        <div class="row">
            <div class="col l4 s12 titulo_section">
                Archivos Asociados
            </div>
            <div class="col l8 s12" style="text-align: right;">
                <button type="button" onclick="fn_NuevoArchivo();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/AñadirLista-48.png" />Agregar</button>
                <button type="button" onclick="fn_EliminarArchivo();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/Cancelar-48.png" />Eliminar</button>
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
        <div class="row">
            <div class="col l4 s12 titulo_section">
                Dirección
            </div>
            <div class="col l8 s12" style="text-align: right;">
                <button type="button" onclick="fn_NuevoDireccion();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/AñadirLista-48.png" />Agregar</button>
                <button type="button" onclick="fn_EliminarDireccion();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/Cancelar-48.png" />Eliminar</button>
            </div>
        </div>
        <div class="row" style="padding-right: 10px;">
            <div class="col l12">
                <table id="grvBandeja_Direccion">
                </table>
                <div id="grvBandeja_Direccion_Pie">
                </div>
            </div>
        </div>
    </div>
    <div id="modalEdicionDireccion" title="Editar Dirección">
        <div id="divmodalEdicionDireccion_General">
            <div class="row" style="display:none;">
                <div class="col l4 s4">
                    <label>ID</label>
                </div>
                <div class="col l8 s8">
                    <input id="txtIdDireccion" type="text" readonly="readonly" disabled="disabled" class="control-form" />
                </div>
            </div>
            <div class="row">
                <div class="col l4 s4">
                    <label>Dirección</label>
                </div>
                <div class="col l8 s8">
                    <input type="text" id="txt_Direccion" class="control-form" />
                </div>
            </div>
            <div class="row">
                <div class="col l4 s4">
                    <label>Departamento</label>
                </div>
                <div class="col l8 s8">
                    <select id="cboDepartamento" class="control-form"></select>
                </div>
            </div>
            <div class="row">
                <div class="col l4 s4">
                    <label>Provincia</label>
                </div>
                <div class="col l8 s8">
                    <select id="cboProvincia" class="control-form"></select>
                </div>
            </div>
            <div class="row">
                <div class="col l4 s4">
                    <label>Distrito</label>
                </div>
                <div class="col l8 s8">
                    <select id="cboDistrito" class="control-form"></select>
                </div>
            </div>
            <div class="row titulo_section">
                Datos de Contacto
            </div>
            <div class="row">
                <div class="col l4 s4">
                    <label>Contacto</label>
                </div>
                <div class="col l8 s8">
                    <input id="txtContacto_Dir" type="text" maxlength="90" class="control-form" />
                </div>
            </div>
            <div class="row">
                <div class="col l4 s4">
                    <label>Teléfono</label>
                </div>
                <div class="col l8 s8">
                    <input id="txtTelefono_Dir" onkeypress="return fc_SoloNumeros(event);" type="text" maxlength="20" class="control-form" />
                </div>
            </div>
            <div class="row">
                <div class="col l4 s4">
                    <label>Celular</label>
                </div>
                <div class="col l8 s8">
                    <input id="txtCelular_Dir" onkeypress="return fc_SoloNumeros(event);" type="text" maxlength="20" class="control-form" />
                </div>
            </div>
            <div class="row">
                <div class="col l4 s4">
                    <label>Email</label>
                </div>
                <div class="col l8 s8">
                    <input id="txtEmail_Dir" type="text" maxlength="40" class="control-form" />
                </div>
            </div>
            <div class="row">
                <div class="col l4 s4">
                    <label>Estado</label>
                </div>
                <div class="col l8 s8">
                    <select id="cboEstadoDireccion" class="control-form">
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
            <input id="btnGrabarmodalEdicionDireccion" type="button" value="Grabar" />
        </div>
    </div>
    <div id="modalFileUpload" title="Cargar Archivo">
        <div id="divmodalFileUpload_General">
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
                    <input type="file" id="fileArchivo" class="control-form" />
                </div>
            </div>
        </div>
        <div style="text-align: center;">
            <div id="uploadFile">
                Cargar Archivo
            </div>
        </div>
    </div>
    <div id="modalEliminar" title="¿Confirmar eliminar persona?">
        <div id="divmodalEliminar_General">
            <div class="row">
                <div class="col l4 s4">
                    <label>Nro. Documento</label>
                </div>
                <div class="col l8 s8">
                    <input id="txtDocumento_Eliminar" type="text" disabled="disabled" class="control-form" />
                    <input id="txtIdPersona_Eliminar" type="text" style="display: none;" disabled="disabled" />
                </div>
            </div>
            <div class="row">
                <div class="col l4 s4">
                    <label>Nombres</label>
                </div>
                <div class="col l8 s8">
                    <input id="txtNombre_Eliminar" type="text" disabled="disabled" class="control-form" />
                </div>
            </div>
            <div id="trPersonasCargo" class="row">
                <div class="col l4 s4">
                    <label>Personas a Cargo</label>
                </div>
                <div class="col l8 s8">
                    <input id="txtNroPersonas_Eliminar" type="text" disabled="disabled" class="control-form" />
                </div>
            </div>
            <div id="trNuevoJefe" class="row">
                <div class="col l4 s4">
                    <label>Jefe Reemplazo</label>
                </div>
                <div class="col l8 s8">
                    <select id="cboJefe_Eliminar" class="control-form">
                    </select>
                </div>
            </div>
        </div>
        <div style="text-align: center;">
            <input type="button" id="btnGrabarEliminar" value="Confirmar Eliminar" />
        </div>
    </div>
    <script type="text/javascript">
        var fileServer_ImgPersonas = '<%=Parametros.CDOC_FileServer_RutaImgPersonas.Replace("~", "..") %>';
        //#region - Variables Grilla Bandeja
        var idGrilla_Bandeja = "#grvBandeja";
        var idPieGrilla_Bandeja = "#grvBandeja_Pie";
        var strCabecera_Bandeja = ['ID', 'Tipo Doc.', 'Número Documento', 'Apellidos y Nombres', 'Localidad', 'Area', 'Sección', 'CodEstado', 'Estado'];
        var ModelCol_Bandeja = [
                            { name: 'id_persona', index: 'id_persona', width: 40, sorttype: 'number', sortable: true, align: 'center', hidden: true },
                            { name: 'no_documento', index: 'no_documento', width: 50, sortable: true, align: 'center' },
                            { name: 'nu_documento', index: 'nu_documento', width: 80, sortable: true, align: 'center' },
                            { name: 'no_busqueda', index: 'no_busqueda', width: 280, sortable: true },
                            { name: 'no_localidad', index: 'no_localidad', width: 100, sortable: true, align: 'center' },
                            { name: 'no_area', index: 'no_area', width: 140, sortable: true },
                            { name: 'no_seccion', index: 'no_seccion', width: 140, sortable: true },
                            { name: 'fl_activo', index: 'fl_activo', sortable: true, hidden: true },
                            { name: 'no_estado', index: 'no_estado', width: 60, sortable: true, align: 'center' }
        ];
        //#endregion - Variables Grilla Bandeja
        //#endregion - Variables Grilla Bandeja Files
        var objDatosFiles = new Array();
        var idGrilla_Files = "#grvFiles";
        var idPieGrilla_Files = "#grvFiles_Pie";
        var strCabecera_Files = ['ID', 'Nombre', 'Archivo', 'Peso KB', 'no_folder', 'no_file_all'];
        var ModelCol_Files = [
                    { name: 'id_persona_File', index: 'id_persona_File', hidden: true },
                    { name: 'no_documento', index: 'no_documento', width: 200, sortable: false },
                    { name: 'no_file', index: 'no_file', width: 200, sortable: false, formatter: fn_linkformat },
                    { name: 'qt_peso', index: 'qt_peso', width: 100, sortable: false },
                    { name: 'no_folder', index: 'no_folder', hidden: true },
                    { name: 'no_file_all', index: 'no_file_all', hidden: true }
        ];
        //#endregion - Variables Grilla Bandeja Files
        //#endregion - Variables Grilla Bandeja Direcciones
        //Variables Grilla
        var idGrilla = "#grvBandeja_Direccion";
        var idPieGrilla = "#grvBandeja_Direccion_Pie";
        var strCabecera = ['ID', 'id_persona', 'Dirección', '', 'Departamento', '', 'Provincia', '', 'Distrito', 'Contacto', '', '', '', '', 'Estado'];
        var ModelCol = [
                        { name: 'id_persona_direccion', index: 'id_persona_direccion', width: 40, sorttype: 'number', sortable: true, hidden: true },
                        { name: 'id_persona', index: 'id_persona', hidden: true },
                        { name: 'no_direccion', index: 'no_direccion', width: 300, sortable: true },
                        { name: 'co_dpto', index: 'co_dpto', hidden: true },
                        { name: 'no_dpto', index: 'no_dpto', width: 100, sortable: true, align: 'center' },
                        { name: 'co_prov', index: 'co_prov', hidden: true },
                        { name: 'no_prov', index: 'no_prov', width: 100, sortable: true, align: 'center' },
                        { name: 'co_dist', index: 'co_dist', hidden: true },
                        { name: 'no_dist', index: 'no_dist', width: 100, sortable: true, align: 'center' },
                        { name: 'no_contacto', index: 'no_contacto', width: 150, sortable: true },
                        { name: 'nu_telefono', index: 'nu_telefono', hidden: true },
                        { name: 'nu_celular', index: 'nu_celular', hidden: true },
                        { name: 'no_correo', index: 'no_correo', hidden: true },
                        { name: 'fl_activo', index: 'fl_activo', hidden: true },
                        { name: 'no_estado', index: 'no_estado', width: 50, sortable: true, align: 'center' }
        ];
        //#endregion - Variables Grilla Bandeja Direcciones

        fn_Iniciar();
        function fn_Iniciar() {
            $('#cboTipoDoc_Bus').keydown(function (event) {
                fc_PressKey(13, 'btnBuscar');
            });
            $('#txtNumeroDoc_Bus').keydown(function (event) {
                fc_PressKey(13, 'btnBuscar');
            });
            $('#txtNombres_Bus').keydown(function (event) {
                fc_PressKey(13, 'btnBuscar');
            });
            $('#cboEstado_Bus').keydown(function (event) {
                fc_PressKey(13, 'btnBuscar');
            });

            this.fc_FormatNumeros("txtNumeroDoc_Bus");
            this.fc_FormatNumeros("txtNumeroDoc");
            this.fc_FormatNumeros("txtTelefono");
            this.fc_FormatNumeros("txtCelular");
            this.fc_FormatFecha("txtFIngreso", DatePicker_Opciones_Default, "MIN", "txtFCese");
            this.fc_FormatFecha("txtFCese", DatePicker_Opciones_Default, "MAX", "txtFIngreso");
            this.fc_FormatFecha("txtFIniContrato", DatePicker_Opciones_Default, "MIN", "txtFFinContrato");
            this.fc_FormatFecha("txtFFinContrato", DatePicker_Opciones_Default, "MAX", "txtFIniContrato");
            $("#trconRUC").css("display", "none");
            $("#trconDNI").css("display", "none");

            var parametros = "{'codigo':'<%=Parametros.Combo.CDOC_TipoDocumentos %>', 'co_padre':''}";
            var urlService = "/wsGenerales.asmx/getCombo";
            this.fc_CallService(parametros, urlService, function (objResponse) {
                this.fc_FillCombo("cboTipoDoc_Bus", objResponse, textTodos);
                this.fc_FillCombo("cboTipoDoc", objResponse, textSeleccione);

                var valDNI = "<%=Parametros.OBJETO_DNI %>";
                $("#cboTipoDoc_Bus").val(valDNI);
                $("#cboTipoDoc_Bus").prop("disabled", true);
                $("#cboTipoDoc").val(valDNI);
                $("#cboTipoDoc").prop("disabled", true);
            });

            var parametros = "{'codigo':'<%=Parametros.Combo.UBIGEO %>', 'co_padre':'00|00|00'}";
            var urlService = "/wsGenerales.asmx/getCombo";
            this.fc_CallService(parametros, urlService, function (objResponse) {
                this.fc_FillCombo("cboDepartamento", objResponse, textSeleccione);
            });
            var parametros = "{'codigo':'<%=Parametros.Combo.CARGO %>', 'co_padre':''}";
            var urlService = "/wsGenerales.asmx/getCombo";
            this.fc_CallService(parametros, urlService, function (objResponse) {
                this.fc_FillCombo("cboCargo", objResponse, textSeleccione);
            });
            var parametros = "{'codigo':'<%=Parametros.Combo.PLANILLA %>', 'co_padre':''}";
            var urlService = "/wsGenerales.asmx/getCombo";
            this.fc_CallService(parametros, urlService, function (objResponse) {
                this.fc_FillCombo("cboPlanilla", objResponse, textSeleccione);
            });
            var parametros = "{'codigo':'<%=Parametros.Combo.TIPO_CONTRATO %>', 'co_padre':''}";
            var urlService = "/wsGenerales.asmx/getCombo";
            this.fc_CallService(parametros, urlService, function (objResponse) {
                this.fc_FillCombo("cboTipoContrato", objResponse, textSeleccione);
            });
            var parametros = "{'codigo':'<%=Parametros.Combo.LOCALIDAD %>', 'co_padre':''}";
            var urlService = "/wsGenerales.asmx/getCombo";
            this.fc_CallService(parametros, urlService, function (objResponse) {
                this.fc_FillCombo("cboLocalidad", objResponse, textSeleccione);
            });
            var parametros = "{'codigo':'<%=Parametros.Combo.AREAS %>', 'co_padre':''}";
            var urlService = "/wsGenerales.asmx/getCombo";
            this.fc_CallService(parametros, urlService, function (objResponse) {
                this.fc_FillCombo("cboArea", objResponse, textSeleccione);
            });
            var parametros = "{'codigo':'<%=Parametros.Combo.PERFIL %>', 'co_padre':''}";
            var urlService = "/wsGenerales.asmx/getCombo";
            this.fc_CallService(parametros, urlService, function (objResponse) {
                this.fc_FillCombo("cboPerfil", objResponse, textSeleccione);
            });
            var parametros = "{'codigo':'<%=Parametros.Combo.CDOC_MotivosCese %>', 'co_padre':''}";
            var urlService = "/wsGenerales.asmx/getCombo";
            this.fc_CallService(parametros, urlService, function (objResponse) {
                this.fc_FillCombo("cboMotivoCese", objResponse, textSeleccione);
            });

            var objResponse = [];
            JQGrid_Util.AutoWidthResponsive(idGrilla_Bandeja);
            JQGrid_Util.GetTabla_Local(idGrilla_Bandeja, idPieGrilla_Bandeja, strCabecera_Bandeja, ModelCol_Bandeja, JQGrid_Opciones_Default, objResponse, function () { }, function () { }, function () { });

            this.objDatosFiles = [];
            JQGrid_Util.AutoWidthResponsive(this.idGrilla_Files);
            JQGrid_Util.GetTabla_Local(this.idGrilla_Files, this.idPieGrilla_Files, this.strCabecera_Files
                , this.ModelCol_Files, JQGrid_Opciones_Default, this.objDatosFiles, function () { }, function () { }, function () { });

            JQGrid_Util.AutoWidthResponsive(this.idGrilla);
            JQGrid_Util.GetTabla_Local(this.idGrilla, this.idPieGrilla, this.strCabecera
                , this.ModelCol, JQGrid_Opciones_Default, [], function () { }, function () { }, function () { });

            this.fc_Modal("modalEdicionDireccion", true, function () { });
            this.fc_Modal("modalFileUpload", true, function () { });
            this.fc_Modal("modalEliminar", true, function () { });
        }

        function fn_Limpiar() {
            $("#cboTipoDoc_Bus").val("");
            $("#txtNumeroDoc_Bus").val("");
            $("#txtNombres_Bus").val("");
            $("#cboEstado_Bus").val("");
            JQGrid_Util.clearData(idGrilla_Bandeja);
        }
        function fn_Buscar() {
            var arr_parametros = new Array();
            arr_parametros[0] = $("#cboTipoDoc_Bus").val();
            arr_parametros[1] = $("#txtNumeroDoc_Bus").val();
            arr_parametros[2] = $("#txtNombres_Bus").val();
            arr_parametros[3] = $("#cboEstado_Bus").val();
            var urlService = page + "/getBandeja";
            JQGrid_Util.GetTabla_Ajax(arr_parametros, urlService, idGrilla_Bandeja, idPieGrilla_Bandeja
                , strCabecera_Bandeja, ModelCol_Bandeja, JQGrid_Opciones_Default
                , function () { }, fn_dblClickBandeja, function () { });
        }
        function fn_dblClickBandeja(rowID) {
            fn_Editar(rowID, undefined);
        }
        function fn_Editar(rowID, idPersona) {
            var rowData;
            if (rowID == undefined && idPersona == undefined) {
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

            $("#txtUsuario").prop("disabled", true);

            idPersona = (idPersona > 0 ? idPersona : rowData['id_persona']);
            var cboEstado = document.getElementById("cboEstado");
            cboEstado.disabled = false;

            var parametros = new Array();
            parametros[0] = idPersona;
            var strFiltros = "{'strFiltros':" + JSON.stringify(parametros) +
                ",'pPageSize':" + 0 +
                ",'pCurrentPage':" + 1 +
                ",'pSortColumn':'" + '' +
                "','pSortOrder':'" + '' + "'}";
            var strUrlServicio = page + "/Get_Personas_ID";
            this.fc_CallService(strFiltros, strUrlServicio,
                function (objResponse) {
                    /*Establece valores*/
                    if (objResponse[0].co_tipo_documento == "<%=Parametros.OBJETO_DNI %>") {
                        $("#trconRUC").css("display", "none");
                        $("#trconDNI").css("display", "");
                    }
                    else {
                        $("#trconRUC").css("display", "");
                        $("#trconDNI").css("display", "none");
                    }
                    document.getElementById("txtID").value = objResponse[0].id_persona;
                    document.getElementById("cboTipoDoc").value = objResponse[0].co_tipo_documento;
                    document.getElementById("txtNumeroDoc").value = objResponse[0].nu_documento;
                    document.getElementById("txtApPaterno").value = objResponse[0].ape_paterno;
                    document.getElementById("txtApMaterno").value = objResponse[0].ape_materno;
                    document.getElementById("txtNombres").value = objResponse[0].no_persona;
                    document.getElementById("txtRazonSocial").value = objResponse[0].no_razon_social;
                    document.getElementById("txtContacto").value = objResponse[0].no_contacto;
                    document.getElementById("txtTelefono").value = objResponse[0].nu_telefono;
                    document.getElementById("txtCelular").value = objResponse[0].nu_celular;
                    document.getElementById("txtEmail").value = objResponse[0].no_correo;
                    document.getElementById("cboEstado").value = objResponse[0].fl_activo;

                    $("#enlaceFoto").attr("href", fileServer_ImgPersonas + objResponse[0].no_foto.substr(0, 6) + "/" + objResponse[0].no_foto);
                    $("#enlaceFoto").text(objResponse[0].no_foto);

                    $('#divFoto').empty();
                    if (objResponse[0].no_foto != "") {
                        $('#divFoto').prepend('<img style="width: 100px; height: 100px;" id="theImg" src="' + fileServer_ImgPersonas + objResponse[0].no_foto.substr(0, 6) + "/" + objResponse[0].no_foto + '" />')
                    }
                    $("#fileArchivo_Foto").replaceWith($("#fileArchivo_Foto").clone());
                    if (objResponse[0].no_foto == "") { $("#fileArchivo_Foto").show(); $("#imgEliminarFoto").hide(); }
                    else { $("#fileArchivo_Foto").hide(); $("#imgEliminarFoto").show(); }

                    $('#cboCargo').val(objResponse[0].id_cargo);
                    $('#cboPlanilla').val(objResponse[0].id_planilla);
                    $('#cboTipoContrato').val(objResponse[0].id_tipo_contrato);

                    $('#txtFIngreso').val(objResponse[0].fe_ingreso);
                    $('#txtFCese').val(objResponse[0].fe_cese);
                    $('#cboMotivoCese').val(objResponse[0].co_tipo_cese);

                    $('#txtFIniContrato').val(objResponse[0].fe_ini_contrato);
                    $('#txtFFinContrato').val(objResponse[0].fe_fin_contrato);

                    $('#cboArea').val(objResponse[0].id_area);
                    $("#cboArea").trigger("change", [objResponse[0].id_seccion]);

                    $('#cboLocalidad').val(objResponse[0].id_localidad);

                    this.fn_CargaDireccion(objResponse[0].id_persona);


                    //carga Files
                    strFiltros = "{'id_persona':" + objResponse[0].id_persona + "}";
                    strUrlServicio = page + "/Get_ListaPersona_Files";
                    this.fc_CallService(strFiltros, strUrlServicio, function (objResponse) {
                        this.JQGrid_Util.GetTabla_Local(this.idGrilla_Files, this.idPieGrilla_Files, this.strCabecera_Files
                            , this.ModelCol_Files, JQGrid_Opciones_Default, objResponse, function () { }, function () { }, function () { });
                    });

                    //Carga Jefes
                    this.fn_CargaJefes(objResponse[0].id_jefe);

                    $('#txtUsuario').val(objResponse[0].no_usuario);
                    $('#cboPerfil').val(objResponse[0].id_perfil);

                }
            );
            }
            function fn_Eliminar() {
                try {
                    var rowId = $("#grvBandeja").jqGrid('getGridParam', 'selrow');
                    if (rowId == null) {
                        alert("- Debe seleccionar un registro.\n");
                        return;
                    }

                    var msg_retorno = "";
                    var rowData = jQuery("#grvBandeja").getRowData(rowId);
                    var id_persona = rowData['id_persona'];
                    var fl_activo = rowData['fl_activo'];
                    if (fl_activo == "0") {
                        msg_retorno += "- El registro ya se encuentra inactivo.\n";
                    }

                    $("#trPersonasCargo").css("display", "none");
                    $("#trNuevoJefe").css("display", "none");
                    $("#cboJefe_Eliminar").val("");
                    $("#txtNroPersonas_Eliminar").val("0");
                    //Cargamos Datos
                    var strUrlServicio = "/wsGenerales.asmx/getCombo";
                    //Numero de Personas a Cargo
                    var strFiltros = "{'codigo':'<%=Parametros.Combo.PERSONAS_JEFE %>'"
                                 + ",'co_padre': '" + id_persona + "'}";
                    this.fc_CallService(strFiltros, strUrlServicio,
                        function (objResponse) {
                            var nroPersonasCargo = objResponse.length;
                            $("#txtNroPersonas_Eliminar").val(nroPersonasCargo);
                            if (nroPersonasCargo > 0) {

                                //Combo Reemplazos
                                strFiltros = "{'codigo':'<%=Parametros.Combo.JEFE %>'"
                                        + ",'co_padre': '" + id_persona + "'}";
                            this.fc_CallService(strFiltros, strUrlServicio,
                            function (objResponse) {
                                textDefault = "<%=Parametros.OBJECTO_SELECCIONE %>";
                                this.fc_FillCombo("cboJefe_Eliminar", objResponse, textDefault);
                            }
                            );

                            //
                            $("#trPersonasCargo").css("display", "");
                            $("#trNuevoJefe").css("display", "");
                        }
                    }
                );

                    //Lenamos Datos
                    $("#txtIdPersona_Eliminar").val(id_persona);
                    $("#txtDocumento_Eliminar").val(rowData['nu_documento']);
                    $("#txtNombre_Eliminar").val(rowData['no_busqueda']);

                    //Mostramos Modal
                    $("#modalEliminar").dialog("open");
                }
                catch (ex) {
                    alert(ex);
                    $("#modalEliminar").dialog("close");
                }
            }
            $("#btnGrabarEliminar").button().click(function (event) {
                try {
                    var msg_retorno = "";
                    var strNumeroPersonas = $("#txtNroPersonas_Eliminar").val();
                    var strJefeReemplazo = $("#cboJefe_Eliminar").val();
                    var NumeroJefes = $('#cboJefe_Eliminar option').length;
                    var id_persona = $("#txtIdPersona_Eliminar").val();
                    var id_jefe = $("#cboJefe_Eliminar").val();

                    if (strNumeroPersonas == "0" || strNumeroPersonas == "") {
                        id_jefe = "";
                    }
                    else {
                        if (strJefeReemplazo == "" && NumeroJefes > 1) {
                            msg_retorno += "Debe seleccionar un jefe de reemplazo.";
                        }
                    }
                    if (msg_retorno != "") {
                        alert(msg_retorno);
                    }
                    else {
                        if (confirm('¿Está seguro de inactivar el registro?')) {
                            var parametros = new Array();
                            parametros[0] = id_persona;
                            parametros[1] = id_jefe;
                            parametros[2] = "<%=ClaseGlobal.Get_login_usuario()%>";
                        parametros[3] = "<%=ClaseGlobal.getUsuarioRed()%>";
                        parametros[4] = "<%=ClaseGlobal.getEstacionRed()%>";

                        //Variables Acceso a Datos
                        var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
                        var strUrlServicio = page + "/Eliminar";
                        fc_CallService(strParametros, strUrlServicio,
                                                    function (objResponse) {
                                                        var retorno = objResponse[0];
                                                        var msg_retorno = objResponse[1];
                                                        if (retorno > 0) {
                                                            //OK
                                                            $("#modalEliminar").dialog("close");
                                                            alert(msg_retorno);
                                                            this.fn_Buscar();
                                                        }
                                                        else {
                                                            //ERROR
                                                            alert(msg_retorno);
                                                        }
                                                    }
                                                );
                    }
                }
            }
            catch (ex) {
                alert(ex);
                $("#modalEliminar").dialog("close");
            }
        });

        function fn_Nuevo() {
            var rowId = $("#grvBandeja").jqGrid('getGridParam', 'selrow');
            if (rowId != null) { $('#grvBandeja').resetSelection(); }

            //Cambia de TAB
            document.getElementById("pagina1").style.display = 'none';
            $("#pagina2").fadeIn();
            document.getElementById("lblTituloTab2").innerHTML = "Nueva ";

            this.fn_Limpiar_Editar();

            var cboEstado = document.getElementById("cboEstado");
            cboEstado.value = "1";
            cboEstado.disabled = true;
            $("#txtUsuario").prop("disabled", false);
        }

        function fn_Limpiar_Editar() {
            document.getElementById("txtID").value = "";
            document.getElementById("cboTipoDoc").value = "";
            document.getElementById("txtNumeroDoc").value = "";
            document.getElementById("txtApPaterno").value = "";
            document.getElementById("txtApMaterno").value = "";
            document.getElementById("txtNombres").value = "";
            document.getElementById("txtRazonSocial").value = "";
            document.getElementById("txtContacto").value = "";
            document.getElementById("txtTelefono").value = "";
            document.getElementById("txtCelular").value = "";
            document.getElementById("txtEmail").value = "";

            $("#trconRUC").css("display", "none");
            $("#trconDNI").css("display", "none");
            $('#cboCargo').val("");
            $('#cboPlanilla').val("");
            $('#cboTipoContrato').val("");
            $('#txtFIngreso').val("");
            $('#txtFCese').val("");
            $('#cboMotivoCese').val("");
            $('#txtFIniContrato').val("");
            $('#txtFFinContrato').val("");
            $('#cboJefe').val("");

            $("#fileArchivo_Foto").replaceWith($("#fileArchivo_Foto").clone());
            $("#fileArchivo_Foto").hide(); $("#imgEliminarFoto").show();
            $("#enlaceFoto").attr("href", "");
            $("#enlaceFoto").text("");

            document.getElementById("cboArea").value = "";
            $("#cboArea").trigger("change");
            document.getElementById("cboLocalidad").value = "";

            $("#imgEliminarFoto").hide();
            $('#divFoto').empty();
            //Carga cabecera de Files
            this.objDatosFiles = [];
            JQGrid_Util.GetTabla_Local(this.idGrilla_Files, this.idPieGrilla_Files, this.strCabecera_Files
                , this.ModelCol_Files, JQGrid_Opciones_Default, this.objDatosFiles, function () { }, function () { }, function () { });

            var valDNI = "<%=Parametros.OBJETO_DNI %>";
                $("#cboTipoDoc").val(valDNI);
                $("#cboTipoDoc").prop('disabled', true);
                $("#cboTipoDoc").trigger("change");

                $('#txtUsuario').val("");
                $('#txtClave').val("");
                $('#cboPerfil').val("");

                //Carga Jefes
                this.fn_CargaJefes("0");
                $('#grvBandeja_Direccion').clearGridData(true);

                document.getElementById("txtNumeroDoc").focus();
            }

            function fn_Guardar() {
                var msg_retorno = "";

                if ($("#cboTipoDoc").val() == "") {
                    msg_retorno += "- Debe seleccionar un tipo de documento.\n";
                }
                if ($("#txtNumeroDoc").val() == "") {
                    msg_retorno += "- Debe ingresar un número de documento.\n";
                }
                if ($("#cboTipoDoc").val() == "<%=Parametros.OBJETO_DNI %>") {
                    if ($("#txtApPaterno").val() == "") {
                        msg_retorno += "- Debe ingresar un apellido paterno.\n";
                    }
                    if ($("#txtApMaterno").val() == "") {
                        msg_retorno += "- Debe ingresar un apellido materno.\n";
                    }
                    if ($("#txtNombres").val() == "") {
                        msg_retorno += "- Debe ingresar un nombre.\n";
                    }
                    if ($("#txtNumeroDoc").val().length != 8) {
                        msg_retorno += "- El número de documento debe tener 8 digitos.\n";
                    }
                }
                else {
                    if ($("#txtRazonSocial").val() == "") {
                        msg_retorno += "- Debe ingresar una razón social.\n";
                    }
                    if ($("#txtContacto").val() == "") {
                        msg_retorno += "- Debe ingresar un nombre de contacto.\n";
                    }
                    if ($("#txtNumeroDoc").val().length != 11) {
                        msg_retorno += "- El número de documento debe tener 11 digitos.\n";
                    }
                }
                if ($("#txtUsuario").val() == "") {
                    msg_retorno += "- Debe ingresar un usuario.\n";
                }
                if ($("#txtID").val() != "") {
                    if ($("#txtClave").val() != "" && $('#txtClave').val().length < 6) {
                        msg_retorno += "- Debe ingresar una clave valida.\n";
                    }
                }
                else {
                    if ($("#txtClave").val() == "" || $('#txtClave').val().length < 6) {
                        msg_retorno += "- Debe ingresar una clave valida.\n";
                    }
                }

                if ($("#cboPerfil").val() == "") {
                    msg_retorno += "- Debe seleccionar perfil.\n";
                }
                if ($("#txtEmail").val() != "") {
                    if (!this.fc_ValidarEmail($("#txtEmail").val())) {
                        msg_retorno += "- Correo inválido.\n";
                    }
                }

                if ($("#cboCargo").val() == "" || $("#cboCargo").val() == null) {
                    msg_retorno += "- Debe seleccionar un cargo.\n";
                }
                if ($("#cboPlanilla").val() == "" || $("#cboPlanilla").val() == null) {
                    msg_retorno += "- Debe seleccionar una planilla.\n";
                }
                if ($("#cboTipoContrato").val() == "" || $("#cboTipoContrato").val() == null) {
                    msg_retorno += "- Debe seleccionar un tipo de contrato.\n";
                }

                /*
                if ($("#txtFIngreso").val() == "") {
                msg_retorno += "- Debe ingresar una fecha de ingreso.\n";
                }
                if ($("#txtFCese").val() == "") {
                msg_retorno += "- Debe ingresar una fecha de cese.\n";
                }*/
                if ($("#cboArea").val() == "") {
                    msg_retorno += "- Debe seleccionar un area.\n";
                }
                if ($("#cboSeccion").val() == "" || $("#cboSeccion").val() == null) {
                    msg_retorno += "- Debe seleccionar una sección.\n";
                }
                if ($("#cboLocalidad").val() == "" || $("#cboLocalidad").val() == null) {
                    msg_retorno += "- Debe seleccionar una localidad.\n";
                }

                var NumeroJefes = $('#cboJefe option').length;
                if ($("#cboJefe").val() == "" && NumeroJefes > 1) {
                    msg_retorno += "- Debe seleccionar un Jefe Inmediato.\n";
                }
                //--

                if ($("#cboEstado").val() == "") {
                    msg_retorno += "- Debe seleccionar un estado.\n";
                }

                if (msg_retorno != "") {
                    alert(msg_retorno);
                }
                else if (confirm('¿Está seguro de guardar el registro?')) {
                    //INICIO - Sube archivo
                    var objFile = "fileArchivo_Foto"; //Id-Input-File
                    var strRuta = "<%=Parametros.CDOC_FileServer_RutaImgPersonas %>"; //Ruta para el File
                    var strNomArchivo = "";
                    //Subir Archivo
                    var strPeso = "<%=Parametros.CDOC_Max_Upload_File %>";
                var intPeso = parseInt(strPeso);
                if (document.getElementById(objFile).value == "") {
                    fn_GrabarPersona($("#enlaceFoto").text());
                }
                else {
                    this.fc_UploadFile(objFile, strRuta, intPeso,
                    //Despues de Subir el Archivo
                    function (objRespuesta, intPeso) {
                        var strIndicador = objRespuesta[0];
                        var strMessage = objRespuesta[1]; //nombre del archivo

                        if (strIndicador == "1") {
                            //Grabar EN BD
                            fn_GrabarPersona(strMessage);
                        }
                        else {
                            alert('Error:' + strMessage);
                        }
                    }
                );
                }
                    //FIN - Sube archivo
            }
    }

    function fn_GrabarPersona(no_foto) {

        var id_persona = $("#txtID").val();
        var parametros = new Array();

        parametros[0] = id_persona;
        parametros[1] = $('#cboTipoDoc').val();
        parametros[2] = $('#txtNumeroDoc').val();
        parametros[3] = $('#txtApPaterno').val();
        parametros[4] = $('#txtApMaterno').val();
        parametros[5] = $('#txtNombres').val();
        parametros[6] = $('#txtRazonSocial').val();
        parametros[7] = $('#txtContacto').val();
        parametros[8] = $('#txtTelefono').val();
        parametros[9] = $('#txtCelular').val();
        parametros[10] = $('#txtEmail').val();
        parametros[11] = "";
        parametros[12] = "";
        parametros[13] = "";
        parametros[14] = $('#cboEstado').val();
        parametros[15] = "<%=ClaseGlobal.Get_login_usuario()%>";
            parametros[16] = "<%=ClaseGlobal.getUsuarioRed()%>";
            parametros[17] = "<%=ClaseGlobal.getEstacionRed()%>";

            parametros[18] = no_foto;
            parametros[19] = "";
            parametros[20] = "";
            parametros[21] = "";
            parametros[22] = "";
            parametros[23] = "";

            parametros[24] = "";
            parametros[25] = "";
            parametros[26] = "";
            parametros[27] = "";

            parametros[28] = $('#cboCargo').val();
            parametros[29] = $('#cboPlanilla').val();
            parametros[30] = $('#cboTipoContrato').val();
            parametros[31] = $('#txtFIngreso').val();
            parametros[32] = $('#txtFCese').val();
            parametros[33] = $('#cboSeccion').val();
            parametros[34] = $('#cboLocalidad').val();
            parametros[35] = $('#cboJefe').val();

            parametros[36] = $('#txtUsuario').val();
            parametros[37] = $('#txtClave').val();
            parametros[38] = $('#cboPerfil').val();

            //
            parametros[39] = $('#txtFIniContrato').val();
            parametros[40] = $('#txtFFinContrato').val();
            parametros[41] = $('#cboMotivoCese').val();


            //Variables Acceso a Datos
            var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";

            var strUrlServicio = page + "/Guardar";
            this.fc_CallService(strParametros, strUrlServicio,
                function (objResponse) {
                    var retorno = objResponse[0];
                    var msg_retorno = objResponse[1];
                    if (retorno > 0) {
                        //OK
                        alert(msg_retorno);
                        if (confirm("¿Desea seguir editando los datos de la persona.?")) {
                            $("#txtID").val(retorno);
                            this.fn_Editar(undefined, retorno);
                        }
                        else {
                            this.fn_Volver();
                            this.fn_Buscar();
                        }
                    }
                    else {
                        //ERROR
                        alert(msg_retorno);
                    }
                }
            );
        }

        function fn_EliminarFoto() {

            var strMensaje = "";
            var id_persona = $("#txtID").val();

            if (id_persona == "") {
                strMensaje += "-Debe grabar antes de eliminar la foto.\n";

            }
            if (strMensaje != "") {
                alert(strMensaje);
                return false;
            }
            if (confirm('¿Está seguro de eliminar la foto?')) {

                var parametros = new Array();

                parametros[0] = id_persona;
                parametros[1] = $("#enlaceFoto").text();
                parametros[2] = "<%=ClaseGlobal.Get_login_usuario()%>";
                parametros[3] = "<%=ClaseGlobal.getUsuarioRed()%>";
                parametros[4] = "<%=ClaseGlobal.getEstacionRed()%>";

                //Variables Acceso a Datos
                var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
                var strUrlServicio = page + "/EliminarFoto";
                this.fc_CallService(strParametros, strUrlServicio,
                    function (objResponse) {
                        var retorno = objResponse[0];
                        var msg_retorno = objResponse[1];
                        if (retorno > 0) {
                            //OK
                            alert(msg_retorno);
                            $("#fileArchivo_Foto").show(); $("#imgEliminarFoto").hide();
                            $("#enlaceFoto").attr("href", "");
                            $("#enlaceFoto").text("");
                            $('#divFoto').empty();
                        }
                        else {
                            //ERROR
                            alert(msg_retorno);
                        }
                    }
                );
            }
        }

        function fn_Volver() {
            $("#pagina1").fadeIn();
            document.getElementById("pagina2").style.display = 'none';
        }

        /*#region - Funciones Direccion*/
        function fn_CargaDireccion(id_persona) {
            //Variables Acceso a Datos
            var parametros = new Array();
            parametros[0] = id_persona;
            var strFiltros = "{'strFiltros':" + JSON.stringify(parametros) +
                ",'pPageSize':" + 0 +
                ",'pCurrentPage':" + 1 +
                ",'pSortColumn':'" + '' +
                "','pSortOrder':'" + '' + "'}";
            var strUrlServicio = page + "/Get_ListaDirecciones_Persona";
            //Arma Grilla
            //JQGrid_Util.AutoWidthResponsive(idGrilla);
            this.fc_CallService(strFiltros, strUrlServicio, function (objResponse) {
                JQGrid_Util.GetTabla_Local(idGrilla, idPieGrilla, strCabecera, ModelCol, JQGrid_Opciones_Default, objResponse, fn_ClickBandeja_Direccion, fn_dblClickBandeja_Direccion, function () { });
            });
        }
        function fn_NuevoDireccion() {
            try {
                var id_persona = $("#txtID").val();
                if (id_persona == "") {
                    alert("- Debe grabar antes de agregar dirección.\n");
                    return;
                }
                document.getElementById("txtIdDireccion").value = "";
                document.getElementById("txt_Direccion").value = "";
                document.getElementById("cboDepartamento").value = "";

                document.getElementById("txtContacto_Dir").value = "";
                document.getElementById("txtTelefono_Dir").value = "";
                document.getElementById("txtCelular_Dir").value = "";
                document.getElementById("txtEmail_Dir").value = "";

                var cboEstado = document.getElementById("cboEstadoDireccion");
                cboEstado.value = "1";
                cboEstado.disabled = true;

                $('#cboDepartamento').trigger('change');
                $("#modalEdicionDireccion").dialog("open");
            }
            catch (ex) {
                alert(ex);
                $("#modalEdicionDireccion").dialog("close");
            }

        }
        $("#btnGrabarmodalEdicionDireccion").button().click(function (event) {
            try {
                var msg_retorno = "";
                if ($("#txt_Direccion").val() == "") {
                    msg_retorno += "- Debe ingresar una dirección.\n";
                }
                if ($("#cboDepartamento").val() == "") {
                    msg_retorno += "- Debe seleccionar un departamento.\n";
                }
                if ($("#cboProvincia").val() == "") {
                    msg_retorno += "- Debe seleccionar una provincia.\n";
                }
                if ($("#cboDistrito").val() == "") {
                    msg_retorno += "- Debe seleccionar un distrito.\n";
                }
                if ($("#txtEmail_Dir").val() != "") {
                    if (!fc_ValidarEmail($("#txtEmail_Dir").val())) {
                        msg_retorno += "- Correo inválido.\n";
                    }
                }
                if (msg_retorno != "") {
                    alert(msg_retorno);
                }
                else {
                    var parametros = new Array();
                    parametros[0] = $('#txtIdDireccion').val();
                    parametros[1] = $("#txtID").val();
                    parametros[2] = $('#txt_Direccion').val();
                    parametros[3] = $('#cboDepartamento').val();
                    parametros[4] = $('#cboProvincia').val();
                    parametros[5] = $('#cboDistrito').val();
                    parametros[6] = $('#txtContacto_Dir').val();
                    parametros[7] = $('#txtTelefono_Dir').val();
                    parametros[8] = $('#txtCelular_Dir').val();
                    parametros[9] = $('#txtEmail_Dir').val();
                    parametros[10] = $('#cboEstadoDireccion').val();
                    parametros[11] = "<%=ClaseGlobal.Get_login_usuario()%>";
                parametros[12] = "<%=ClaseGlobal.getUsuarioRed()%>";
                parametros[13] = "<%=ClaseGlobal.getEstacionRed()%>";

                //Variables Acceso a Datos
                var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
                var strUrlServicio = page + "/GrabarDireccion";
                fc_CallService(strParametros, strUrlServicio,
                    function (objResponse) {
                        var retorno = objResponse[0];
                        var msg_retorno = objResponse[1];
                        if (retorno > 0) {
                            //OK
                            alert(msg_retorno);
                            fn_CargaDireccion($("#txtID").val());
                            $("#modalEdicionDireccion").dialog("close");
                        }
                        else {
                            //ERROR
                            alert(msg_retorno);
                        }
                    }
                );
            }
        }
        catch (ex) {
            alert(ex);
            $("#modalEdicionDireccion").dialog("close");
        }
    });
    function fn_EliminarDireccion() {
        var rowId = $("#grvBandeja_Direccion").jqGrid('getGridParam', 'selrow');
        if (rowId == null) {
            alert("- Debe seleccionar un registro.\n");
            return;
        }

        var msg_retorno = "";
        var rowData = jQuery("#grvBandeja_Direccion").getRowData(rowId);
        var id_persona_direccion = rowData['id_persona_direccion'];
        var fl_activo = rowData['fl_activo'];
        if (fl_activo == "0") {
            msg_retorno += "- El registro ya se encuentra inactivo.\n";
        }

        if (msg_retorno != "") {
            alert(msg_retorno);
        }
        else {
            if (confirm('¿Está seguro de inactivar el registro?')) {
                var parametros = new Array();
                parametros[0] = id_persona_direccion;
                parametros[1] = "<%=ClaseGlobal.Get_login_usuario()%>";
                        parametros[2] = "<%=ClaseGlobal.getUsuarioRed()%>";
                        parametros[3] = "<%=ClaseGlobal.getEstacionRed()%>";

                        //Variables Acceso a Datos
                        var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
                        var strUrlServicio = page + "/EliminarDireccion";
                        this.fc_CallService(strParametros, strUrlServicio,
                            function (objResponse) {
                                var retorno = objResponse[0];
                                var msg_retorno = objResponse[1];
                                if (retorno > 0) {
                                    //OK
                                    alert(msg_retorno);
                                    fn_CargaDireccion($("#txtID").val());
                                }
                                else {
                                    //ERROR
                                    alert(msg_retorno);
                                }
                            }
                        );
                    }
                }
            }
            function fn_despuesCerrar_direcion() { }

            function fn_ClickBandeja_Direccion() { }

            function fn_dblClickBandeja_Direccion(rowid) {
                rowData = $("#grvBandeja_Direccion").getRowData(rowid);

                document.getElementById("txt_Direccion").value = rowData.no_direccion;
                document.getElementById("cboDepartamento").value = rowData.co_dpto;
                $('#cboDepartamento').trigger('change', [rowData.co_prov, rowData.co_dist]);
                document.getElementById("txtIdDireccion").value = rowData.id_persona_direccion;
                document.getElementById("cboEstadoDireccion").value = rowData.fl_activo;

                document.getElementById("txtContacto_Dir").value = rowData.no_contacto;
                document.getElementById("txtTelefono_Dir").value = rowData.nu_telefono;
                document.getElementById("txtCelular_Dir").value = rowData.nu_celular;
                document.getElementById("txtEmail_Dir").value = rowData.no_correo;

                var cboEstado = document.getElementById("cboEstadoDireccion");
                cboEstado.disabled = false;

                $("#modalEdicionDireccion").dialog("open");
            }
            /*#endregion - Funciones Direccion*/

            /*[INICIO] - Funciones para los Files*/
            function fn_linkformat(cellValue, options, rowObject) {
                var strFolder = rowObject["no_folder"];
                var strFile = rowObject["no_file_all"];
                var strLink = "<a href='<%=Parametros.CDOC_VirtualServer_Personas %>" + strFolder + "/" + strFile + "' target='_blank'>" + cellValue + "</a>";
                return strLink;
            }

            function fn_EliminarArchivo() {
                var rowId = $(idGrilla_Files).jqGrid('getGridParam', 'selrow');
                if (rowId == null) {
                    alert("- Debe seleccionar un registro.\n");
                    return;
                }
                if (confirm('¿Está seguro de eliminar el registro?')) {
                    var parametros = new Array();

                    var rowData = jQuery("#grvFiles").getRowData(rowId);
                    var id_persona_file = rowData['id_persona_File'];

                    parametros[0] = id_persona_file;
                    parametros[1] = "<%=ClaseGlobal.Get_login_usuario()%>";
                    parametros[2] = "<%=ClaseGlobal.getUsuarioRed()%>";
                    parametros[3] = "<%=ClaseGlobal.getEstacionRed()%>";

                    //Variables Acceso a Datos
                    var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
                    var strUrlServicio = page + "/EliminarPersona_File";
                    this.fc_CallService(strParametros, strUrlServicio,
                        function (objResponse) {
                            var retorno = objResponse[0];
                            var msg_retorno = objResponse[1];
                            if (retorno > 0) {
                                //OK
                                var strIdVehiculo = document.getElementById("txtID").value;
                                fn_Editar(undefined, strIdVehiculo);
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
            function fn_NuevoArchivo() {
                var strIdPersona = document.getElementById("txtID").value;
                var strMensaje = "";
                if (strIdPersona == "") {
                    strMensaje += "-Debe grabar el registro antes de adjuntar archivos\n";

                }
                if (strMensaje != "") {
                    alert(strMensaje);
                    return false;
                }
                document.getElementById("txtNombreFile").value = "";
                document.getElementById("fileArchivo").value = "";

                $("#modalFileUpload").dialog("open");
            }
            $("#uploadFile").button().click(function (event) {
                try {
                    var objFile = "fileArchivo"; //Id-Input-File
                    var strRuta = "<%=Parametros.CDOC_FileServer_RutaPersonas %>"; //Ruta para el File
                    var strNomArchivo = document.getElementById("txtNombreFile").value;
                    var strIdVehiculo = document.getElementById("txtID").value;
                    var strMensaje = "";

                    if (strIdVehiculo == "") {
                        strMensaje += "-Debe grabar antes de adjuntar archivos\n";

                    }
                    if (strNomArchivo == "") {
                        strMensaje += "-Debe ingresar un nombre de archivo\n";

                    }
                    if (document.getElementById(objFile).value == "") {
                        strMensaje += "-Debe seleccionar un archivo válido\n";
                    }
                    if (strMensaje != "") {
                        alert(strMensaje);
                        return false;
                    }
                    //Subir Archivo
                    var strPeso = "<%=Parametros.CDOC_Max_Upload_File %>";
                    var intPeso = parseInt(strPeso);

                    fc_UploadFile(objFile, strRuta, intPeso,
                    //Despues de Subir el Archivo
                     function (objRespuesta, intPeso) {
                         var strIndicador = objRespuesta[0];
                         var strMessage = objRespuesta[1];

                         if (strIndicador == "1") {
                             //Grabar EN BD
                             var parametros = new Array();

                             parametros[0] = strIdVehiculo;
                             parametros[1] = strNomArchivo;
                             parametros[2] = strMessage;
                             parametros[3] = intPeso;
                             parametros[4] = "<%=ClaseGlobal.Get_login_usuario()%>";
                             parametros[5] = "<%=ClaseGlobal.getUsuarioRed()%>";
                             parametros[6] = "<%=ClaseGlobal.getEstacionRed()%>";

                             var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";

                             var strUrlServicio = page + "/GrabarPersonaFile";
                             this.fc_CallService(strParametros, strUrlServicio,
                            function (objResponse) {
                                var retorno = objResponse[0];
                                var msg_retorno = objResponse[1];
                                if (retorno > 0) {
                                    //OK
                                    fn_Editar(undefined, strIdVehiculo);
                                    alert(msg_retorno);
                                    $("#modalFileUpload").dialog("close");
                                }
                                else {
                                    //ERROR
                                    alert(msg_retorno);
                                }
                            }
                        );
                         }
                         else {
                             alert('Error:' + strMessage);
                         }
                     });
                 } catch (ex) {
                     alert(ex);
                     fc_show_progress(false);
                 }
            });
             /*[FIN] - Funciones para los Files*/

             function fn_CargaJefes(strSeleccion) {
                 try {
                     var strIdPersona = document.getElementById("txtID").value;
                     strIdPersona = (strIdPersona == "" ? "0" : strIdPersona);
                     strSeleccion = (strSeleccion == "0" ? "" : strSeleccion);

                     var strFiltros = "{'codigo':'<%=Parametros.Combo.JEFE %>'"
            + ",'co_padre': '" + strIdPersona + "'}";
                 var strUrlServicio = "/wsGenerales.asmx/getCombo";
                 fc_CallService(strFiltros, strUrlServicio,
                     function (objResponse) {
                         var textDefault = "<%=Parametros.OBJECTO_SELECCIONE %>";
                         fc_FillCombo("cboJefe", objResponse, textDefault);
                         $('#cboJefe').val(strSeleccion);
                     }
            );

                 } catch (ex) {
                     alert(ex);
                 }
             }

             $("#cboDepartamento").change(function (event, co_prov_sel, co_dist_sel) {
                 var n = $(this).val();
                 $('#cboProvincia').empty();
                 $('#cboDistrito').empty();
                 $("#cboDistrito").append('<option value=""><%=Parametros.OBJECTO_SELECCIONE %></option>');
                 switch (n) {
                     case "":
                         $("#cboProvincia").append('<option value=""><%=Parametros.OBJECTO_SELECCIONE %></option>');
                         break;
                     default:
                         var strFiltros = "{'codigo':'<%=Parametros.Combo.UBIGEO %>'"
                            + ",'co_padre': '" + n + "|00|00'}";
                         var strUrlServicio = "/wsGenerales.asmx/getCombo";
                         fc_CallService(strFiltros, strUrlServicio,
                             function (objResponse) {
                                 var textDefault = "<%=Parametros.OBJECTO_SELECCIONE %>";
                            fc_FillCombo("cboProvincia", objResponse, textDefault);
                            if ($.type(co_prov_sel) === "string") {
                                $("#cboProvincia").val(co_prov_sel);
                                $("#cboProvincia").trigger('change', [co_dist_sel]);
                            }
                            else if ($("#cboProvincia").find("option").length == 1) {
                                $("#cboProvincia").trigger('change');
                            }
                        }
                    );
                        break;
                }
             });

            $("#cboProvincia").change(function (event, co_dist_sel) {
                $('#cboDistrito').empty();
                var n = $(this).val();
                switch (n) {
                    case "":
                        $("#cboDistrito").append('<option value=""><%=Parametros.OBJECTO_SELECCIONE %></option>');
                        break;
                    default:
                        var strDpto = $('#cboDepartamento').val();;
                        var strFiltros = "{'codigo':'<%=Parametros.Combo.UBIGEO %>'"
                            + ",'co_padre': '" + strDpto + "|" + n + "|00'}";
                        var strUrlServicio = "/wsGenerales.asmx/getCombo";
                        fc_CallService(strFiltros, strUrlServicio,
                            function (objResponse) {
                                var textDefault = "<%=Parametros.OBJECTO_SELECCIONE %>";
                                fc_FillCombo("cboDistrito", objResponse, textDefault);
                                if ($.type(co_dist_sel) === "string") {
                                    $("#cboDistrito").val(co_dist_sel);
                                }
                            }
                    );
                            break;
                    }
            });

                $("#cboArea").change(function (event, co_seccion) {
                    $('#cboSeccion').empty();
                    var n = $(this).val();
                    n = (n == null ? 0 : n);
                    switch (n) {
                        case "":
                            $("#cboSeccion").append('<option value=""><%=Parametros.OBJECTO_SELECCIONE %></option>');
                            break;
                        default:

                            var strFiltros = "{'codigo':'<%=Parametros.Combo.SECCION %>'"
                            + ",'co_padre': '" + n + "'}";
                        var strUrlServicio = "/wsGenerales.asmx/getCombo";
                        fc_CallService(strFiltros, strUrlServicio,
                            function (objResponse) {
                                var textDefault = "<%=Parametros.OBJECTO_SELECCIONE %>";
                                fc_FillCombo("cboSeccion", objResponse, textDefault);
                                if ($.type(co_seccion) === "number") {
                                    $("#cboSeccion").val(co_seccion);
                                }
                            }
                    );
                            break;
                    }
                });
                $("#cboTipoDoc").change(function () {
                    var n = $(this).val();
                    switch (n) {
                        case "<%=Parametros.OBJETO_DNI %>":
                    $("#trconRUC").css("display", "none");
                    $("#trconDNI").css("display", "");

                    document.getElementById("txtApPaterno").value = "";
                    document.getElementById("txtApMaterno").value = "";
                    document.getElementById("txtNombres").value = "";

                    break;
                case "<%=Parametros.OBJETO_RUC %>":
                    $("#trconRUC").css("display", "");
                    $("#trconDNI").css("display", "none");

                    document.getElementById("txtRazonSocial").value = "";
                    document.getElementById("txtContacto").value = "";

                    break;
                default:
                    $("#trconRUC").css("display", "none");
                    $("#trconDNI").css("display", "none");
                    break;

            }
        });
    </script>
</asp:Content>

