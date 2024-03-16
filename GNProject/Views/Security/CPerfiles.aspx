<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CPerfiles.aspx.cs" Inherits="GNProject.Views.Security.CPerfiles" %>
<%@ Import Namespace="GNProject.Acceso" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="pagina1">
        <div class="row linea-bottom">
            <div class="col l4 s12 titulo">Lista de Perfiles</div>
            <div class="col l8 s12" style="text-align: right;">
                <button id="btnBuscar" type="button" onclick="fn_Buscar();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="/Views/ctrlDoc/img/img_buttons/Busqueda-48.png" />Buscar</button>
                <button type="button" onclick="fn_Limpiar();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="/Views/ctrlDoc/img/img_buttons/Escoba-48.png" />Limpiar</button>
                <button type="button" onclick="fn_Nuevo();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="/Views/ctrlDoc/img/img_buttons/AñadirLista-48.png" />Nuevo</button>
                <button type="button" onclick="fn_Editar();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="/Views/ctrlDoc/img/img_buttons/Editar-48.png" />Editar</button>
                <button type="button" onclick="fn_Eliminar();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="/Views/ctrlDoc/img/img_buttons/Cancelar-48.png" />Eliminar</button>
            </div>
        </div>
        <div class="row titulo_section">
            Filtros de búsqueda
        </div>
        <div class="row">
            <div class="col l1 m2 s4">
                <label>Perfil</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtNomPerfil_Bus" type="text" class="control-form" />
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
                <span id="lblTituloTab2">Nuevo</span>
                Perfil
            </div>
            <div class="col l8 s12" style="text-align: right;">
                <button type="button" onclick="fn_Guardar();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="/Views/ctrlDoc/img/img_buttons/Guardar-48.png" />Guardar</button>
                <button type="button" onclick="fn_Volver();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="/Views/ctrlDoc/img/img_buttons/Volver-48.png" />Volver</button>
            </div>
        </div>
        <div class="row titulo_section">
            Datos de Perfil
        </div>
        <div class="row">
            <div class="col l6 s12">
                <div class="row" style="display:none;">
                    <div class="col l4 s4">
                        <label>ID</label>
                    </div>
                    <div class="col l8 s8">
                        <input id="txtID" type="text" class="control-form" disabled="disabled" />
                    </div>
                </div>
                <div class="row">
                    <div class="col l4 s4">
                        <label>Perfil</label>
                    </div>
                    <div class="col l8 s8">
                        <input id="txtNomPerfil" type="text" class="control-form" />
                    </div>
                </div>
                <div class="row">
                    <div class="col l4 s4">
                        <label>Detalle</label>
                    </div>
                    <div class="col l8 s8">
                        <input id="txtDetalle" type="text" class="control-form" />
                    </div>
                </div>
                <div class="row">
                    <div class="col l4 s4">
                        <label>Estado</label>
                    </div>
                    <div class="col l8 s8">
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
                    <div class="col s12">
                        Acceso a plantilla de documentos:
                        <div id="trvPlantillasDoc" class="clTreeView">
                        </div>
                    </div>
                </div>
            </div>
            <div class="col l6 s12">
                Acceso a opciones:
                <div id="trvOpciones" class="clTreeView">
                </div>
            </div>
        </div>
    </div>
    <div runat="server" ID="AdminConfiguration" visible="false">
        <div class="row titulo_section">
            Activación de modulos:
        </div>
        <asp:DropDownList ID="ddlMenus" runat="server">
            <asp:ListItem Text="Seleccione una opción" Value=""></asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="btnActivar" runat="server" Text="Activar" OnClick="btnActivar_Click" />
        <asp:Button ID="btnDesactivar" runat="server" Text="Desactivar" OnClick="btnDesactivar_Click" />
    </div>


    <script type="text/javascript">
        //#region - Variables Grilla Bandeja
        var idGrilla_Bandeja = "#grvBandeja";
        var idPieGrilla_Bandeja = "#grvBandeja_Pie";
        var strCabecera_Bandeja = ['ID', 'Perfil', 'Detalle', 'CodEstado', 'Estado', 'Ids Plantilla Doc'];
        var ModelCol_Bandeja = [
            { name: 'id_perfil', index: 'id_perfil', width: 40, sorttype: 'number', sortable: true, align: 'center', hidden: true },
            { name: 'no_perfil', index: 'no_perfil', width: 300, sortable: true },
            { name: 'de_perfil', index: 'de_perfil', width: 300, sortable: true },
            { name: 'fl_activo', index: 'fl_activo', hidden: true },
            { name: 'no_estado', index: 'no_estado', width: 100, sortable: true, align: 'center' },
            { name: 'ids_plantilla_doc', index: 'ids_plantilla_doc', hidden: true }
        ];
        //#endregion - Variables Grilla Bandeja

        fn_Iniciar();
        function fn_Iniciar() {
            $('#txtNomPerfil_Bus').keydown(function (event) {
                fc_PressKey(13, 'btnBuscar');
            });
            $('#cboEstado_Bus').keydown(function (event) {
                fc_PressKey(13, 'btnBuscar');
            });

            /*[INICIO] - Carga los menus-opciones*/
            var arr_parametros = "";
            var urlService = page + "/Get_OpcionesAll";
            this.fc_CallService(arr_parametros, urlService, function (objResponse) {
                var strIdDivArbol = "trvOpciones";
                var strTipoArbol = "checkbox";
                var strSeleccionMultiple = true;
                var strfn_callback = this.fn_DespuesArbol;
                var DataArbol = objResponse;
                this.fc_CrearTreeView(strIdDivArbol, strTipoArbol, strSeleccionMultiple, DataArbol, strfn_callback);
            });
            /*[FIN] - Carga los menus-opciones*/

            /*[INICIO] - Carga los menus-opciones*/
            var arr_parametros = "";
            var urlService = page + "/Get_PlantillasDocAll";
            this.fc_CallService(arr_parametros, urlService, function (objResponse) {
                var strIdDivArbol = "trvPlantillasDoc";
                var strTipoArbol = "checkbox";
                var strSeleccionMultiple = true;
                var strfn_callback = function () { };
                var DataArbol = objResponse;
                this.fc_CrearTreeView(strIdDivArbol, strTipoArbol, strSeleccionMultiple, DataArbol, strfn_callback);
            });
            /*[FIN] - Carga los menus-opciones*/

            var objResponse = [];
            JQGrid_Util.AutoWidthResponsive(idGrilla_Bandeja);
            JQGrid_Util.GetTabla_Local(idGrilla_Bandeja, idPieGrilla_Bandeja, strCabecera_Bandeja, ModelCol_Bandeja, JQGrid_Opciones_Default, objResponse, function () { }, function () { }, function () { });
        }

        function fn_DespuesArbol(ids_menu_selection) {
            //alert(ids_menu_selection);
        }

        function fn_Limpiar() {
            $("#txtNomPerfil_Bus").val("");
            $("#cboEstado_Bus").val("");
            JQGrid_Util.clearData(idGrilla_Bandeja);
        }
        function fn_Buscar() {
            var arr_parametros = new Array();
            arr_parametros[0] = $("#txtNomPerfil_Bus").val();
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
            document.getElementById("txtID").value = rowData['id_perfil'];
            document.getElementById("txtNomPerfil").value = rowData["no_perfil"];
            document.getElementById("txtDetalle").value = rowData["de_perfil"];
            document.getElementById("cboEstado").value = rowData['fl_activo'];

            //Chequea opciones del perfil
            var parametros = "{'id_perfil':" + rowData['id_perfil'] + "}";
            var urlService = page + "/Get_OpcionesxPerfil";
            this.fc_CallService(parametros, urlService, function (objResponse) {
                var arr_ids = objResponse.toString().split(',');
                for (i = 0; i <= arr_ids.length - 1; i++) {
                    $('#trvOpciones').jstree("select_node", arr_ids[i].toString());
                }
            });

            //Chequea plantillas asignadas
            var arr_ids_pd = rowData.ids_plantilla_doc.toString().split(',');
            for (i = 0; i <= arr_ids_pd.length - 1; i++) {
                $('#trvPlantillasDoc').jstree("select_node", arr_ids_pd[i].toString());
            }
        }
        function fn_Eliminar() {
            var rowId = $("#grvBandeja").jqGrid('getGridParam', 'selrow');
            if (rowId == null) {
                alert("- Debe seleccionar un registro.\n");
                return;
            }

            var msg_retorno = "";
            var rowData = jQuery("#grvBandeja").getRowData(rowId);
            var id_perfil = rowData['id_perfil'];
            var fl_activo = rowData['fl_activo'];
            if (fl_activo == "0") {
                msg_retorno += "- El registro ya se encuentra inactivo.\n";
            }

            if (msg_retorno != "") {
                alert(msg_retorno);
            }
            else if (confirm('¿Está seguro de inactivar el registro?')) {
                var arr_parametros = new Array();
                arr_parametros[0] = id_perfil;
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
        }

        function fn_Limpiar_Editar() {
            document.getElementById("txtID").value = "";
            document.getElementById("txtNomPerfil").value = "";
            document.getElementById("cboEstado").value = "";
            document.getElementById("txtDetalle").value = "";
            $("#trvOpciones").jstree("deselect_all");
            $("#trvPlantillasDoc").jstree("deselect_all");
            document.getElementById("txtNomPerfil").focus();
        }

        function fn_Guardar() {
            var msg_retorno = "";
            var ids_menu = $("#trvOpciones").jstree("get_selected").toString();
            var ids_plantillas = $("#trvPlantillasDoc").jstree("get_selected").toString();
            if ($("#txtNomPerfil").val() == "") {
                msg_retorno += "- Debe ingresar un nombre de perfil.\n";
            }
            if ($("#cboEstado").val() == "") {
                msg_retorno += "- Debe seleccionar estado.\n";
            }
            if (ids_menu == "") {
                msg_retorno += "- Debe seleccionar al menos una opción.\n";
            }

            if (msg_retorno != "") {
                alert(msg_retorno);
            }
            else if (confirm('¿Está seguro de guardar el registro?')) {
                var id_perfil = $("#txtID").val();
                var arr_parametros = new Array();
                arr_parametros[0] = id_perfil;
                arr_parametros[1] = $("#txtNomPerfil").val();
                arr_parametros[2] = $("#txtDetalle").val();
                arr_parametros[3] = $("#cboEstado").val();
                arr_parametros[4] = ids_menu;
                arr_parametros[5] = ids_plantillas;
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

 

