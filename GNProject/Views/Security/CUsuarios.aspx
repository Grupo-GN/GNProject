<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CUsuarios.aspx.cs" Inherits="GNProject.Views.Security.CUsuarios" %>
<%@ Import Namespace="GNProject.Acceso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   <link rel="stylesheet" type="text/css" href="/Assets/Css/JqGrid/jquery-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="/Assets/Css/JqGrid/ui.jqgrid.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="pagina1">
        <div class="row linea-bottom">
            <div class="col l4 s12 titulo">Lista de Usuarios</div>
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
                <label>Apellido Paterno</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtApPaterno_Busqueda" type="text" class="control-form" />
            </div>
            <div class="col l1 m2 s4">
                <label>Apellido Materno</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtApMaterno_Busqueda" type="text" class="control-form" />
            </div>
            <div class="col l1 m2 s4">
                <label>Nombres</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtNombres_Busqueda" type="text" class="control-form" />
            </div>
        </div>
        <div class="row">
            <div class="col l1 m2 s4">
                <label>Usuario</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtUsuario_Busqueda" type="text" class="control-form" />
            </div>
            <div class="col l1 m2 s4">
                <label>Perfil</label>
            </div>
            <div class="col l3 m4 s8">
                <select id="cboPerfil_Busqueda" class="control-form"></select>
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
                Usuario
            </div>
            <div class="col l8 s12" style="text-align: right;">
                <button type="button" onclick="fn_Guardar();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/Guardar-48.png" />Guardar</button>
                <button type="button" onclick="fn_Volver();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/Volver-48.png" />Volver</button>
            </div>
        </div>
        <div class="row titulo_section">
            Datos Generales
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
        <div class="row">
            <div class="col l1 m2 s4">
                <label>DNI</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtDNI" type="text" maxlength="8" class="control-form" />
            </div>
            <div class="col l1 m2 s4">
                <label>Email</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtCorreo" type="text" class="control-form" />
            </div>
            <div class="col l1 m2 s4">
                <label>Sexo</label>
            </div>
            <div class="col l3 m4 s8">
                <select id="cboSexo" class="control-form"></select>
            </div>
        </div>
        <div class="row">
            <div class="col l1 m2 s4">
                <label>Fec. Nacimiento</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtNacimiento" type="text" class="control-form" />
            </div>
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
        </div>
        <div class="row titulo_section">
            Datos de Acceso
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
        <div class="row">
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
            <div class="col l1 m2 s4">
                <label>Ver Doc. Reservados</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="chkVerDocReservado" type="checkbox" />
            </div>
            <div class="col l1 m2 s4">
                <label>Permitir Archivar Documentos</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="chkArchivarDoc" type="checkbox" />
            </div>
        </div>
    </div>

    <script type="text/javascript">
        //#region - Variables Grilla Bandeja
        var idGrilla_Bandeja = "#grvBandeja";
        var idPieGrilla_Bandeja = "#grvBandeja_Pie";
        var strCabecera_Bandeja = ['ID', 'Apellido Paterno', 'Apellido Materno', 'Nombres', 'Login', 'Perfil', 'CodEstado', 'Estado'];
        var ModelCol_Bandeja = [
                            { name: 'id_usuario', index: 'id_usuario', width: 40, sorttype: 'number', sortable: true, align: 'center', hidden: true },
                            { name: 'ape_paterno', index: 'ape_paterno', width: 100, sortable: true },
                            { name: 'ape_materno', index: 'ape_materno', width: 100, sortable: true },
                            { name: 'no_usuario', index: 'no_usuario', width: 200, sortable: true },
                            { name: 'login', index: 'login', width: 100, sortable: true, align: 'center' },
                            { name: 'no_perfil', index: 'no_perfil', width: 150, sortable: true, align: 'center' },
                            { name: 'fl_activo', index: 'fl_activo', hidden: true },
                            { name: 'no_estado', index: 'no_estado', width: 100, sortable: true, align: 'center' }
        ];
        //#endregion - Variables Grilla Bandeja

        fn_Iniciar();
        function fn_Iniciar() {
            $('#txtApPaterno_Busqueda').keydown(function (event) {
                fc_PressKey(13, 'btnBuscar');
            });
            $('#txtApMaterno_Busqueda').keydown(function (event) {
                fc_PressKey(13, 'btnBuscar');
            });
            $('#txtNombres_Busqueda').keydown(function (event) {
                fc_PressKey(13, 'btnBuscar');
            });
            $('#txtUsuario_Busqueda').keydown(function (event) {
                fc_PressKey(13, 'btnBuscar');
            });
            $('#cboPerfil_Busqueda').keydown(function (event) {
                fc_PressKey(13, 'btnBuscar');
            });
            $('#cboEstado_Busqueda').keydown(function (event) {
                fc_PressKey(13, 'btnBuscar');
            });

            var parametros = "{'codigo':'<%=Parametros.Combo.PERFIL %>'"
                + ",'co_padre': ''}";
            var urlService = "/wsGenerales.asmx/getCombo";
            this.fc_CallService(parametros, urlService, function (objResponse) {
                this.fc_FillCombo("cboPerfil_Busqueda", objResponse, textTodos);
                this.fc_FillCombo("cboPerfil", objResponse, textSeleccione);
            });

            var parametros = "{'codigo':'<%=Parametros.Combo.SEXO %>'"
                + ",'co_padre': ''}";
            var urlService = "/wsGenerales.asmx/getCombo";
            this.fc_CallService(parametros, urlService, function (objResponse) {
                this.fc_FillCombo("cboSexo", objResponse, textSeleccione);
            });

            this.fc_FormatNumeros("txtDNI");
            this.fc_FormatNumeros("txtTelefono");
            this.fc_FormatNumeros("txtCelular");
            DatePicker_Opciones_Default.fl_changeYear = true;
            DatePicker_Opciones_Default.maxDate = "0D";
            this.fc_FormatFecha("txtNacimiento", DatePicker_Opciones_Default, "", "");

            var objResponse = [];
            JQGrid_Util.AutoWidthResponsive(idGrilla_Bandeja);
            JQGrid_Util.GetTabla_Local(idGrilla_Bandeja, idPieGrilla_Bandeja, strCabecera_Bandeja, ModelCol_Bandeja, JQGrid_Opciones_Default, objResponse, function () { }, function () { }, function () { });
        }

        function fn_Limpiar() {
            $("#txtApPaterno_Busqueda").val("");
            $("#txtApMaterno_Busqueda").val("");
            $("#txtNombres_Busqueda").val("");
            $("#txtUsuario_Busqueda").val("");
            $("#cboPerfil_Busqueda").val("");
            $("#cboEstado_Busqueda").val("");

            JQGrid_Util.clearData(idGrilla_Bandeja);
        }
        function fn_Buscar() {
            var arr_parametros = new Array();
            arr_parametros[0] = $("#txtApPaterno_Busqueda").val();
            arr_parametros[1] = $("#txtApMaterno_Busqueda").val();
            arr_parametros[2] = $("#txtNombres_Busqueda").val();
            arr_parametros[3] = $("#txtUsuario_Busqueda").val();
            arr_parametros[4] = $("#cboPerfil_Busqueda").val();
            arr_parametros[5] = $("#cboEstado_Busqueda").val();
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
            $("#txtUsuario").prop("disabled", true);

            var cboEstado = document.getElementById("cboEstado");
            cboEstado.disabled = false;

            /*Establece valores*/
            var strFiltros = "{'id':" + rowData['id_usuario'] + "}";
            var urlService = page + "/Get_UsuarioxID";
            this.fc_CallService(strFiltros, urlService, function (objResponse) {
                document.getElementById("txtID").value = objResponse.id_usuario;
                document.getElementById("txtApPaterno").value = objResponse.ape_paterno;
                document.getElementById("txtApMaterno").value = objResponse.ape_materno;
                document.getElementById("txtNombres").value = objResponse.no_usuario;
                document.getElementById("txtDNI").value = objResponse.nu_dni;
                document.getElementById("txtCorreo").value = objResponse.no_correo;
                document.getElementById("cboSexo").value = objResponse.co_sexo;
                document.getElementById("txtNacimiento").value = objResponse.sfe_nacimiento;
                document.getElementById("txtTelefono").value = objResponse.nu_telefono;
                document.getElementById("txtCelular").value = objResponse.nu_celular;
                document.getElementById("txtUsuario").value = objResponse.login;
                document.getElementById("txtClave").value = "";
                document.getElementById("cboPerfil").value = objResponse.id_perfil;
                document.getElementById("cboEstado").value = objResponse.fl_activo;
                document.getElementById("chkVerDocReservado").checked = objResponse.fl_ver_doc_reservado;
                document.getElementById("chkArchivarDoc").checked = objResponse.fl_archivar_doc;
            });
        }
        function fn_Eliminar() {
            var rowId = $("#grvBandeja").jqGrid('getGridParam', 'selrow');
            if (rowId == null) {
                alert("- Debe seleccionar un registro.\n");
                return;
            }

            var msg_retorno = "";
            var rowData = jQuery("#grvBandeja").getRowData(rowId);
            var id_usuario = rowData['id_usuario'];
            var fl_activo = rowData['fl_activo'];
            if (fl_activo == "0") {
                msg_retorno += "- El registro ya se encuentra inactivo.\n";
            }

            if (msg_retorno != "") {
                alert(msg_retorno);
            }
            else if (confirm('¿Está seguro de inactivar el registro?')) {
                var arr_parametros = new Array();
                arr_parametros[0] = id_usuario;
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
            if (rowId != null) { $('#grvBandeja').resetSelection(); }

            //Cambia de TAB
            document.getElementById("pagina1").style.display = 'none';
            $("#pagina2").fadeIn();
            document.getElementById("lblTituloTab2").innerHTML = "Nuevo ";

            this.fn_Limpiar_Editar();

            var cboEstado = document.getElementById("cboEstado");
            cboEstado.value = "1";
            cboEstado.disabled = true;

            $("#txtUsuario").prop("disabled", false);
        }

        function fn_Limpiar_Editar() {
            document.getElementById("txtID").value = "";
            document.getElementById("txtApPaterno").value = "";
            document.getElementById("txtApMaterno").value = "";
            document.getElementById("txtNombres").value = "";
            document.getElementById("txtDNI").value = "";
            document.getElementById("txtCorreo").value = "";
            document.getElementById("cboSexo").value = "";
            document.getElementById("txtNacimiento").value = "";
            document.getElementById("txtTelefono").value = "";
            document.getElementById("txtCelular").value = "";
            document.getElementById("txtUsuario").value = "";
            document.getElementById("txtClave").value = "";
            document.getElementById("cboPerfil").value = "";
            document.getElementById("cboEstado").value = "";
            document.getElementById("chkVerDocReservado").checked = false;
            document.getElementById("chkArchivarDoc").checked = false;

            document.getElementById("txtApPaterno").focus();
        }

        function fn_Guardar() {
            var msg_retorno = "";
            if ($("#txtApPaterno").val() == "") {
                msg_retorno += "- Debe ingresar un apellido paterno.\n";
            }
            if ($("#txtApMaterno").val() == "") {
                msg_retorno += "- Debe ingresar un apellido materno.\n";
            }
            if ($("#txtNombres").val() == "") {
                msg_retorno += "- Debe ingresar un nombre.\n";
            }
            if ($("#txtDNI").val() == "") {
                msg_retorno += "- Debe ingresar un número de DNI.\n";
            }
            else if ($("#txtDNI").val().length < 8) {
                msg_retorno += "- El número DNI debe tener 8 digitos.\n";
            }
            if ($("#txtCorreo").val() != "") {
                if (!this.fc_ValidarEmail($("#txtCorreo").val())) {
                    msg_retorno += "- Correo inválido.\n";
                }
            }
            if ($("#cboSexo").val() == "") {
                msg_retorno += "- Debe seleccionar un sexo.\n";
            }
            //////if ($("#txtNacimiento").val() == "") {
            //////    msg_retorno += "- Debe ingresar fecha de nacimiento.\n";
            //////}
            if ($("#txtUsuario").val() == "") {
                msg_retorno += "- Debe ingresar un usuario.\n";
            }
            if ($("#txtID").val() == "" && $("#txtClave").val() == "") {
                msg_retorno += "- Debe ingresar una clave.\n";
            }
            if ($("#cboPerfil").val() == "") {
                msg_retorno += "- Debe seleccionar perfil.\n";
            }
            if ($("#cboEstado").val() == "") {
                msg_retorno += "- Debe seleccionar estado.\n";
            }
            if (msg_retorno != "") {
                alert(msg_retorno);
            }
            else {
                if (confirm('¿Está seguro de guardar el registro?')) {
                    var id_usuario = $("#txtID").val();
                    var arr_parametros = new Array();
                    arr_parametros[0] = id_usuario;
                    arr_parametros[1] = $("#txtApPaterno").val();
                    arr_parametros[2] = $("#txtApMaterno").val();
                    arr_parametros[3] = $("#txtNombres").val();
                    arr_parametros[4] = $("#txtDNI").val();
                    arr_parametros[5] = $("#txtCorreo").val();
                    arr_parametros[6] = $("#cboSexo").val();
                    arr_parametros[7] = $("#txtNacimiento").val();
                    arr_parametros[8] = $("#txtTelefono").val();
                    arr_parametros[9] = $("#txtCelular").val();
                    arr_parametros[10] = $("#txtUsuario").val();
                    arr_parametros[11] = $("#txtClave").val();
                    arr_parametros[12] = $("#cboPerfil").val();
                    arr_parametros[13] = $("#cboEstado").val();
                    arr_parametros[14] = $("#chkVerDocReservado").prop("checked");
                    arr_parametros[15] = $("#chkArchivarDoc").prop("checked");

                    //Variables Acceso a Datos
                    var parametros = "{'strParametros':" + JSON.stringify(arr_parametros) + "}";
                    var uslService = page + "/Guardar";
                    this.fc_CallService(parametros, uslService, function (objResponse) {
                        if (objResponse[0] > 0) {
                            this.fn_Volver();
                            this.fn_Buscar();
                        }
                        alert(objResponse[1]);
                    });
                }
            }
        }

        function fn_Volver() {
            $("#pagina1").fadeIn();
            document.getElementById("pagina2").style.display = 'none';
        }
    </script>
</asp:Content>

