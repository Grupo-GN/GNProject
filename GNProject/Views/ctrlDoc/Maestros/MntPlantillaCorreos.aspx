<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="MntPlantillaCorreos.aspx.cs" Inherits="GNProject.Views.ctrlDoc.Maestros.MntPlantillaCorreos" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <script src="/jScripts/ctrl/nicEdit/nicEdit.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        bkLib.onDomLoaded(function() {
            new nicEditor({ iconsPath: '../js/nicEdit/nicEditorIcons.gif', fullPanel: true, maxHeight: 320, uploadURI : '../nicUpload.ashx' }).panelInstance('txtDetalle');
        });
    </script>
    <div id="pagina1">
        <div class="row linea-bottom">
            <div class="col l4 s12 titulo">Lista de Correos</div>
            <div class="col l8 s12" style="text-align: right;">
                <button id="btnBuscar" type="button" onclick="fn_Buscar();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/Busqueda-48.png" />Buscar</button>
                <button type="button" onclick="fn_Limpiar();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/Escoba-48.png" />Limpiar</button>
                <button type="button" onclick="fn_Editar();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/Editar-48.png" />Editar</button>
            </div>
        </div>
        <div class="row titulo_section">
            Filtros de búsqueda
        </div>
        <div class="row">
            <div class="col l1 m2 s4">
                <label>Asunto</label>
            </div>
            <div class="col l3 m4 s8">
                <input id="txtAsunto_Bus" type="text" class="control-form" />
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
                Correo
            </div>
            <div class="col l8 s12" style="text-align: right;">
                <button type="button" onclick="fn_VistaPreliminar();" style="background: none; padding: 0 0 0 10px; border: none;">
                    <img style="width: 30px; left: 50%; margin-left: -15px; display: block; position: relative;" src="../img/img_buttons/icono_ver_detalle.png" />Vista Preliminar</button>
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
                <label>Asunto</label>
            </div>
            <div class="col l6 m10 s8">
                <input id="txtAsunto" type="text" class="control-form" />
            </div>
        </div>
        <div class="row">
            <div class="col l1 m2 s4">
                <label>Para</label>
            </div>
            <div class="col l6 m10 s8">
                <input id="txtPara" type="text" class="control-form" />
            </div>
        </div>
        <div class="row">
            <div class="col l1 m2 s4">
                <label>Copia</label>
            </div>
            <div class="col l6 m10 s8">
                <input id="txtCC" type="text" class="control-form" />
            </div>
        </div>
        <div class="row">
            <div class="col l1 m2 s4">
                <label>Copia Oculta</label>
            </div>
            <div class="col l6 m10 s8">
                <input id="txtBCC" type="text" class="control-form" />
            </div>
        </div>
        <div class="row">
            <div class="col l12">
                <label>Detalle</label>
            </div>
        </div>
        <div class="row">
            <div class="col l12">
                <textarea id="txtDetalle" rows="20" class="control-form" style="width:705px;height:520px;"></textarea>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        //#region - Variables Grilla Bandeja
        var idGrilla_Bandeja = "#grvBandeja";
        var idPieGrilla_Bandeja = "#grvBandeja_Pie";
        var strCabecera_Bandeja = ['ID', 'Asunto', 'Para', 'Copia', 'Copia Oculta', 'Detalle'];
        var ModelCol_Bandeja = [
                            { name: 'id_correo', index: 'id_correo', width: 40, sorttype: 'number', sortable: true, align: 'center', hidden: true },
                            { name: 'no_asunto', index: 'no_asunto', width: 250, sortable: true },
                            { name: 'no_para', index: 'no_para', width: 250, sortable: true },
                            { name: 'no_cc', index: 'no_cc', width: 200, sortable: true },
                            { name: 'no_bcc', index: 'no_bcc', width: 150, sortable: true, align: 'center' },
                            { name: 'no_detalle', index: 'no_detalle', hidden: true }
        ];
        //#endregion - Variables Grilla Bandeja

        fn_Iniciar();
        function fn_Iniciar() {
            $("#txtAsunto_Bus").keydown(function (event) {
                fc_PressKey(13, 'btnBuscar');
            });

            var objResponse = [];
            JQGrid_Util.AutoWidthResponsive(idGrilla_Bandeja);
            JQGrid_Util.GetTabla_Local(idGrilla_Bandeja, idPieGrilla_Bandeja, strCabecera_Bandeja, ModelCol_Bandeja, JQGrid_Opciones_Default, objResponse, function () { }, function () { }, function () { });
        }

        function fn_Limpiar() {
            $("#txtAsunto_Bus").val("");
            JQGrid_Util.clearData(idGrilla_Bandeja);
        }
        function fn_Buscar() {
            var arr_parametros = new Array();
            arr_parametros[0] = $("#txtAsunto_Bus").val();
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

            /*Establece valores*/
            document.getElementById("txtID").value = rowData["id_correo"];
            document.getElementById("txtAsunto").value = rowData["no_asunto"];
            document.getElementById("txtPara").value = rowData["no_para"];
            document.getElementById("txtCC").value = rowData["no_cc"];
            document.getElementById("txtBCC").value = rowData["no_bcc"];
            //document.getElementById("txtDetalle").value = rowData["no_detalle"];

            var parametros = "{'id':" + rowData["id_correo"] + "}";
            var urlService = page + "/getCorreoxID";
            this.fc_CallService(parametros, urlService, function (objResponse) {
                //document.getElementById("txtDetalle").value = objResponse["no_detalle"];
                nicEditors.findEditor("txtDetalle").setContent(objResponse["no_detalle"]);
            });

            document.getElementById("txtAsunto").focus();
        }

        function fn_Limpiar_Editar() {
            document.getElementById("txtID").value = "";
            document.getElementById("txtAsunto").value = "";
            document.getElementById("txtPara").value = "";
            document.getElementById("txtCC").value = "";
            document.getElementById("txtBCC").value = "";
            //document.getElementById("txtDetalle").value = "";
            nicEditors.findEditor("txtDetalle").setContent("");
        }

        function fn_Guardar() {
            var msg_retorno = "";
            if (fc_Trim($("#txtAsunto").val()) == "") {
                msg_retorno += "- Debe ingresar asunto.\n";
            }
            //if (fc_Trim($("#txtDetalle").val()) == "") {
            if(fc_Trim(nicEditors.findEditor("txtDetalle").getContent()) == "") {
                msg_retorno += "- Debe ingresar detalle del correo.\n";
            }

            if (msg_retorno != "") {
                alert(msg_retorno);
            }
            else if (confirm('¿Está seguro de guardar el registro?')) {
                var id_correo = $("#txtID").val();
                var arr_parametros = new Array();
                arr_parametros[0] = id_correo;
                arr_parametros[1] = $("#txtAsunto").val();
                arr_parametros[2] = $("#txtPara").val();
                arr_parametros[3] = $("#txtCC").val();
                arr_parametros[4] = $("#txtBCC").val();
                //arr_parametros[5] = $("#txtDetalle").val();
                arr_parametros[5] = nicEditors.findEditor("txtDetalle").getContent();
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

        function fn_VistaPreliminar() {
            //var tx_detalle_html = $("#txtDetalle").val();
            var tx_detalle_html = nicEditors.findEditor("txtDetalle").getContent();
            var wnd = window.open("about:blank", "newWindow", "height=500,width=850,top=0,left=0,resizable=yes");
            wnd.document.write(tx_detalle_html);
        }
    </script>
</asp:Content>