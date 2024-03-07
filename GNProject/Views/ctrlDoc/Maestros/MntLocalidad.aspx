<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="MntLocalidad.aspx.cs" Inherits="GNProject.Views.ctrlDoc.Maestros.MntLocalidad" %>
<%@ Import Namespace="GNProject.Acceso" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="pagina1">
        <div class="row linea-bottom">
            <div class="col l4 s12 titulo">Lista de Localidades</div>
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
                <label>Localidad</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtNomLocalidad_Bus" type="text" class="control-form" />
            </div>
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
            <div class="col l4 s12 titulo"><span id="lblTituloTab2">Nueva</span> Localidad</div>
            <div class="col l8 s12" style="text-align: right;">
                <button type="button" onclick="fn_Guardar();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/Guardar-48.png" />Guardar</button>
                <button type="button" onclick="fn_Volver();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/Volver-48.png" />Volver</button>
            </div>
        </div>
        <div class="row titulo_section">
            Datos de Localidad
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
                <label>Localidad</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtNomLocalidad" type="text" class="control-form" />
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
        <div class="row" style="display:none;">
            <div class="col l1 m2 s4">
                <label>Cod. Homologación</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtHomologacion" type="text" class="control-form" />
            </div>
        </div>
    </div>

    <script type="text/javascript">
        //#region - Variables Grilla Bandeja
        var idGrilla_Bandeja = "#grvBandeja";
        var idPieGrilla_Bandeja = "#grvBandeja_Pie";
        var strCabecera_Bandeja = ['ID', 'Localidad', '', 'CodEstado', 'Estado'];
        var ModelCol_Bandeja = [
                            { name: 'id_localidad', index: 'id_localidad', width: 40, sorttype: 'number', sortable: true, align: 'center', hidden: true },
                            { name: 'no_localidad', index: 'no_localidad', width: 200, sortable: true },
                            { name: 'co_homologacion', index: 'co_homologacion', hidden: true },
                            { name: 'fl_activo', index: 'fl_activo', hidden: true },
                            { name: 'no_estado', index: 'no_estado', width: 100, sortable: true, align: 'center' }
        ];
        //#endregion - Variables Grilla Bandeja

        fn_Iniciar();
        function fn_Iniciar() {
            $('#txtNomLocalidad_Bus').keydown(function (event) {
                fc_PressKey(13, 'btnBuscar');
            });
            $('#cboEstado_Bus').keydown(function (event) {
                fc_PressKey(13, 'btnBuscar');
            });

            var objResponse = [];
            JQGrid_Util.AutoWidthResponsive(idGrilla_Bandeja);
            JQGrid_Util.GetTabla_Local(idGrilla_Bandeja, idPieGrilla_Bandeja, strCabecera_Bandeja, ModelCol_Bandeja, JQGrid_Opciones_Default, objResponse, function () { }, function () { }, function () { });
        }

        function fn_Limpiar() {
            $("#txtNomLocalidad_Bus").val("");
            $("#cboEstado_Bus").val("");
            JQGrid_Util.clearData(idGrilla_Bandeja);
        }
        function fn_Buscar() {
            var arr_parametros = new Array();
            arr_parametros[0] = $("#txtNomLocalidad_Bus").val();
            arr_parametros[1] = $("#cboEstado_Bus").val();
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
            document.getElementById("txtID").value = rowData["id_localidad"];
            document.getElementById("txtNomLocalidad").value = rowData["no_localidad"];
            document.getElementById("txtHomologacion").value = rowData["co_homologacion"];
            document.getElementById("cboEstado").value = rowData["fl_activo"];
        }
        function fn_Eliminar() {
            var rowId = $("#grvBandeja").jqGrid('getGridParam', 'selrow');
            if (rowId == null) {
                alert("- Debe seleccionar un registro.\n");
                return;
            }

            var msg_retorno = "";
            var rowData = jQuery("#grvBandeja").getRowData(rowId);
            var id_localidad = rowData['id_localidad'];
            var fl_activo = rowData['fl_activo'];
            if (fl_activo == "0") {
                msg_retorno += "- El registro ya se encuentra inactivo.\n";
            }

            if (msg_retorno != "") {
                alert(msg_retorno);
            }
            else if (confirm('¿Está seguro de inactivar el registro?')) {
                var arr_parametros = new Array();
                arr_parametros[0] = id_localidad;
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
            document.getElementById("lblTituloTab2").innerHTML = "Nueva ";

            this.fn_Limpiar_Editar();

            var cboEstado = document.getElementById("cboEstado");
            cboEstado.value = "1";
            cboEstado.disabled = true;
        }

        function fn_Limpiar_Editar() {
            document.getElementById("txtID").value = "";
            document.getElementById("txtNomLocalidad").value = "";
            document.getElementById("cboEstado").value = "";
            document.getElementById("txtHomologacion").value = "";
            document.getElementById("txtNomLocalidad").focus();
        }

        function fn_Guardar() {
            var msg_retorno = "";
            if ($("#txtNomLocalidad").val() == "") {
                msg_retorno += "- Debe ingresar un nombre de localidad.\n";
            }
            if ($("#cboEstado").val() == "") {
                msg_retorno += "- Debe seleccionar estado.\n";
            }

            if (msg_retorno != "") {
                alert(msg_retorno);
            }
            else if (confirm('¿Está seguro de guardar el registro?')) {
                var id_localidad = $("#txtID").val();
                var arr_parametros = new Array();
                arr_parametros[0] = id_localidad;
                arr_parametros[1] = $("#txtNomLocalidad").val();
                arr_parametros[2] = $("#txtHomologacion").val();
                arr_parametros[3] = $("#cboEstado").val();
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


