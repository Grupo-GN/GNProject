<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="FrmPlantillaContratoTrab.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.RRHH.FrmPlantillaContratoTrab" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
     <input type="hidden" id="empresaSession" value="<%= Session["EmpresaPlanilla"] %>" />
        <input type="hidden" id="periodoSession" value="<%= Session["PeriodoPlanilla"] %>" />
        <input type="hidden" id="planillaSession" value="<%= Session["planillaPlanilla"] %>" />
        <input type="hidden" id="anioSession" value="<%= Session["anioPlanilla"] %>" />
    <div>
        <label class="title">PLANTILLA DE CONTRATOS</label>
        <br />
        <table style="width: 100%;">
            <tr>
                <td>Tipo Contrato:
                </td>
                <td>
                    <select id="cboTipoContrato_Busqueda" style="width: 250px;">
                    </select>
                </td>
                <td>Cargo:
                </td>
                <td>
                    <select id="cboCargo_Busqueda" style="width: 150px;">
                    </select>
                </td>
            </tr>
        </table>
        <div class="buttonsaction">
            <button id="btnBuscar" type="button" onclick="fn_Buscar();">
                Buscar</button>
            <button id="btnNuevo" type="button" onclick="fn_Nuevo();">
                Nuevo</button>
        </div>
        <div style="padding-top: 10px;">
            <table id="grvBandeja">
            </table>
            <div id="grvBandeja_Pie">
            </div>
        </div>
    </div>
    <div id="modalEdicionPlantilla" title="Plantilla de Contrato" style="max-width: 800px;">
        <div id="divmodalEdicionPlantilla_General" style="font-family: Verdana; font-size: 11px;">
            <div id="modalEdicionPlantilla_Contenedor">
                <table>
                    <tr>
                        <td>Tipo Contrato:
                        </td>
                        <td>
                            <select id="cboTipoContrato" style="width: 250px;"></select>
                        </td>
                        <td>Cargo:
                        </td>
                        <td>
                            <select id="cboCargo" style="width: 150px;"></select>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">Plantilla Contrato:
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">Palabras clave que se puede utilizar: <b>[TIPO_RENOVACION] [NOMBRE_TRABAJADOR] [DNI_TRABAJADOR] [DIRECCION_TRABAJADOR] [CARGO_TRABAJADOR] [FISCALIZACION] [FUNCIONES_CARGO] [FE_INICIO_CONTRATO] [FE_FINAL_CONTRATO] [PERIODO_PRUEBA] [SUELDO_TRABAJADOR_NUMERO] [SUELDO_TRABAJADOR_LETRA] [FECHA_FIRMA_CONTRATO]</b>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <div id="divPlantillaContrato" style="width: 700px; height: 400px; border: 1px solid #000; overflow: auto;">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="height: 5px;"></td>
                    </tr>
                    <tr>
                        <td colspan="4" style="text-align: center;">
                            <button id="btnVistaPreliminar" type="button" onclick="fn_VistaPreliminar();">
                                Vista Preliminar</button>
                            <button id="btnGrabar" type="button" onclick="fn_Grabar();">
                                Grabar</button>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        var pagePath = window.location.pathname;
        /*[INICIO] - Variables Grilla Bandeja*/
        var idGrilla_Bandeja = "#grvBandeja";
        var idPieGrilla_Bandeja = "#grvBandeja_Pie";
        var strCabecera_Bandeja = ['Tipo Contrato', 'Cargo', 'Plantilla Contrato', 'Tipo Contrato ID', 'Cargo ID'];
        var ModelCol_Bandeja = [
            { name: 'tipo_contrato', index: 'tipo_contrato', width: 250, sortable: true, align: 'left' },
            { name: 'cargo', index: 'cargo', width: 200, sortable: true, align: 'center' },
            { name: 'tx_plantilla_contrato', index: 'tx_plantilla_contrato', hidden: true },
            { name: 'tipo_contrato_id', index: 'tipo_contrato_id', hidden: true },
            { name: 'cargo_id', index: 'cargo_id', hidden: true }
        ];
        /*[FIN] - Variables Grilla Bandeja*/
        this.fn_CargaInicial();
        function fn_CargaInicial() {
            $("button").button();

            var strParametros = "";
            var strUrlServicio = pagePath + "/Get_Inicial";
            this.fc_CallService(strParametros, strUrlServicio, function (objResponse) {
                this.fc_FillCombo("cboTipoContrato_Busqueda", objResponse.oTipoContratos, "--Todos--");
                this.fc_FillCombo("cboCargo_Busqueda", objResponse.oCargo, "--Todos--");
                this.fc_FillCombo("cboTipoContrato", objResponse.oTipoContratos, "--Seleccione--");
                this.fc_FillCombo("cboCargo", objResponse.oCargo, "--Seleccione--");
            });
            this.fc_Modal("modalEdicionPlantilla", true, function () { });

            var objResponse = [];
            this.JQGrid_Util.GetTabla_Local(idGrilla_Bandeja, idPieGrilla_Bandeja, strCabecera_Bandeja, ModelCol_Bandeja
                , JQGrid_Opciones_Default, objResponse, function () { }, function () { }, function () { });

            bkLib.onDomLoaded(function () {
                new nicEditor({ fullPanel: true }).panelInstance('divPlantillaContrato');
            });
        }
        function fn_Buscar() {
            var parametros = new Array();
            parametros[0] = $("#cboTipoContrato_Busqueda").val();
            parametros[1] = $("#cboCargo_Busqueda").val();

            var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
            var strUrlServicio = pagePath + "/Get_Bandeja";
            this.fc_CallService(strParametros, strUrlServicio, function (objResponse) {
                this.JQGrid_Util.GetTabla_Local(idGrilla_Bandeja, idPieGrilla_Bandeja, strCabecera_Bandeja, ModelCol_Bandeja
                    , JQGrid_Opciones_Default, objResponse, function () { }, fn_DblClick_Bandeja, function () { });
            });
        }
        function fn_DblClick_Bandeja(rowID) {
            var rowData = this.JQGrid_Util.getRowData(idGrilla_Bandeja, rowID);
            $("#cboTipoContrato").val(rowData.tipo_contrato_id);
            $("#cboCargo").val(rowData.cargo_id);
            nicEditors.findEditor("divPlantillaContrato").setContent(rowData.tx_plantilla_contrato);

            this.Modal_Util.Open("modalEdicionPlantilla");
        }
        function fn_Nuevo() {
            $("#cboTipoContrato").val("");
            $("#cboCargo").val("");
            nicEditors.findEditor("divPlantillaContrato").setContent("");
            this.Modal_Util.Open("modalEdicionPlantilla");
        }
        function fn_Grabar() {
            var id_tipo_contrato = $("#cboTipoContrato").val();
            var cargo_id = $("#cboCargo").val();
            var tx_plantilla = nicEditors.findEditor("divPlantillaContrato").getContent();
            var msg_retorno = "";
            if (fc_Trim(id_tipo_contrato) == "") { msg_retorno += "- Debe seleccionar tipo contrato.\n"; }
            if (fc_Trim(cargo_id) == "") { msg_retorno += "- Debe seleccionar cargo.\n"; }
            if (fc_Trim(tx_plantilla) == "") { msg_retorno += "- Debe ingresar plantilla de contrato.\n"; }
            if (msg_retorno != "") {
                alert(msg_retorno);
            }
            else {
                var parametros = new Array();
                parametros[0] = id_tipo_contrato;
                parametros[1] = cargo_id;
                parametros[2] = tx_plantilla;
                parametros[3] = "1";
                parametros[4] = "";
                parametros[5] = "";
                parametros[6] = "";

                var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
                var strUrlServicio = pagePath + "/GuardarPlantilla";
                this.fc_CallService(strParametros, strUrlServicio, function (objResponse) {
                    if (objResponse.msg_retorno != "") {
                        alert(objResponse.msg_retorno);
                    }
                    if (objResponse.retorno > 0) {
                        Modal_Util.Close("modalEdicionPlantilla");
                        this.fn_Buscar();
                    }
                });
            }
        }
        function fn_VistaPreliminar() {
            var tx_detalle_html = nicEditors.findEditor("divPlantillaContrato").getContent();
            var wnd = window.open("about:blank", "newWindow", "height=500,width=850,top=0,left=0,resizable=yes,scrollbars=yes");
            wnd.document.write(tx_detalle_html);
        }
    </script>
</asp:Content>

