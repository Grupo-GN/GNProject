<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="MntAreas.aspx.cs" Inherits="GNProject.Views.ctrlDoc.Maestros.MntAreas" %>
<%@ Import Namespace="GNProject.Acceso" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="pagina1">
        <div class="row linea-bottom">
            <div class="col l4 s12 titulo">Lista de Areas</div>
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
                <label>Area</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtNomArea_Bus" type="text" class="control-form" />
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
            <div class="col l4 s12 titulo">
                <span id="lblTituloTab2">Nueva</span>
                Area
            </div>
            <div class="col l8 s12" style="text-align: right;">
                <button type="button" onclick="fn_Guardar();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/Guardar-48.png" />Guardar</button>
                <button type="button" onclick="fn_Volver();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/Volver-48.png" />Volver</button>
            </div>
        </div>
        <div class="row titulo_section">
            Datos del Area
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
                <label>Area</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtNomArea" type="text" class="control-form" />
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
        <div class="row">
            <div class="col l1 m2 s4">
                <label>Usuario Responsable</label>
            </div>
            <div class="col l3 m4 s8">
                <select id="cboUsuarioResponsable" class="control-form"></select>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        //#region - Variables Grilla Bandeja
        var idGrilla_Bandeja = "#grvBandeja";
        var idPieGrilla_Bandeja = "#grvBandeja_Pie";
        var strCabecera_Bandeja = ['ID', 'Area', '', 'CodEstado', 'Estado', 'IDs Usuario Responsable'];
        var ModelCol_Bandeja = [
                            { name: 'id_area', index: 'id_area', width: 40, sorttype: 'number', sortable: true, align: 'center', hidden: true },
                            { name: 'no_area', index: 'no_area', width: 200, sortable: true },
                            { name: 'co_homologacion', index: 'co_homologacion', hidden: true },
                            { name: 'fl_activo', index: 'fl_activo', hidden: true },
                            { name: 'no_estado', index: 'no_estado', width: 100, sortable: true, align: 'center' },
                            { name: 'ids_usuario_responsable', index: 'ids_usuario_responsable', hidden: true }
        ];
        //#endregion - Variables Grilla Bandeja

        fn_Iniciar();
        function fn_Iniciar() {
            $('#txtNomArea_Bus').keydown(function (event) {
                fc_PressKey(13, 'btnBuscar');
            });
            $('#cboEstado_Bus').keydown(function (event) {
                fc_PressKey(13, 'btnBuscar');
            });

            var sendInfo = "{'codigo':'<%=Parametros.Combo.USUARIOS %>', 'co_padre':''}";
            var urlService = "/wsGenerales.asmx/getCombo";
            fc_CallService(sendInfo, urlService, function (objResponse) {
                this.fc_FillCombo("cboUsuarioResponsable", objResponse, textTodos);
                $("#cboUsuarioResponsable option[value='']").remove();
                $("#cboUsuarioResponsable").multipleSelect({ filter: true });
            });

            var objResponse = [];
            JQGrid_Util.AutoWidthResponsive(idGrilla_Bandeja);
            JQGrid_Util.GetTabla_Local(idGrilla_Bandeja, idPieGrilla_Bandeja, strCabecera_Bandeja, ModelCol_Bandeja, JQGrid_Opciones_Default, objResponse, function () { }, function () { }, function () { });
        }

        function fn_Limpiar() {
            $("#txtNomArea_Bus").val("");
            $("#cboEstado_Bus").val("");
            JQGrid_Util.clearData(idGrilla_Bandeja);
        }
        function fn_Buscar() {
            var arr_parametros = new Array();
            arr_parametros[0] = $("#txtNomArea_Bus").val();
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
            document.getElementById("txtID").value = rowData["id_area"];
            document.getElementById("txtNomArea").value = rowData["no_area"];
            document.getElementById("txtHomologacion").value = rowData["co_homologacion"];
            document.getElementById("cboEstado").value = rowData["fl_activo"];
            $("#cboUsuarioResponsable").multipleSelect("setSelects", rowData["ids_usuario_responsable"].split(","));
        }
        function fn_Eliminar() {
            var rowId = $("#grvBandeja").jqGrid('getGridParam', 'selrow');
            if (rowId == null) {
                alert("- Debe seleccionar un registro.\n");
                return;
            }

            var msg_retorno = "";
            var rowData = jQuery("#grvBandeja").getRowData(rowId);
            var id_area = rowData['id_area'];
            var fl_activo = rowData['fl_activo'];
            if (fl_activo == "0") {
                msg_retorno += "- El registro ya se encuentra inactivo.\n";
            }

            if (msg_retorno != "") {
                alert(msg_retorno);
            }
            else if (confirm('¿Está seguro de inactivar el registro?')) {
                var arr_parametros = new Array();
                arr_parametros[0] = id_area;
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
            document.getElementById("txtNomArea").value = "";
            document.getElementById("cboEstado").value = "";
            document.getElementById("txtHomologacion").value = "";
            $("#cboUsuarioResponsable").multipleSelect("uncheckAll");
            document.getElementById("txtNomArea").focus();
        }

        function fn_Guardar() {
            var msg_retorno = "";
            if ($("#txtNomArea").val() == "") {
                msg_retorno += "- Debe ingresar un nombre de área.\n";
            }
            if ($("#cboEstado").val() == "") {
                msg_retorno += "- Debe seleccionar estado.\n";
            }

            if (msg_retorno != "") {
                alert(msg_retorno);
            }
            else if (confirm('¿Está seguro de guardar el registro?')) {
                var id_area = $("#txtID").val();
                var arr_parametros = new Array();
                arr_parametros[0] = id_area;
                arr_parametros[1] = $("#txtNomArea").val();
                arr_parametros[2] = $("#txtHomologacion").val();
                arr_parametros[3] = $("#cboEstado").val();
                arr_parametros[4] = $("#cboUsuarioResponsable").multipleSelect("getSelects").toString();
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