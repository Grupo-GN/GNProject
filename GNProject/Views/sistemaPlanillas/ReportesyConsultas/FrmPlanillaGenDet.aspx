<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmPlanillaGenDet.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.ReportesyConsultas.FrmPlanillaGenDet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
    li.selected {
        background-color: #E6E6E6;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />
    <link href="../Controles/miEstilo.css" rel="stylesheet" type="text/css" />
    <link href="../jqueriUI/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../css/StyleWilder.css" rel="stylesheet" type="text/css" />

    <link rel="stylesheet" type="text/css" href="../css/multiple-select.css" />

    <fieldset style="width:100%; background-color: White; margin: 0px 0px 0px 0px;
           border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black; 
            min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; border-top: solid 1px black;">
    <fieldset>
        <legend>Filtrar</legend>
        <table>
            <tr>
                <td style="text-align:right;width:100px;"><label>Proceso : </label></td>
                <td>
                    <select class="miComboBox" id="cboProceso" style="width:200px;"></select>
                </td>
                <td style="text-align:right;width:100px;"><label>Periodo Inicio : </label></td>
                <td><select class="miComboBox" id="cboPeriodoIni"></select></td>
                <td style="text-align:right;width:100px;"><label>Periodo Final : </label></td>
                <td><select class="miComboBox" id="cboPeriodoFin"></select></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td style="text-align:right;width:100px;">Conceptos Fijos:</td>
                <td>
                    <select id="cboConcepto_Fijos" style="width:250px;">
                    </select>
                </td>
                <td style="text-align:right;width:100px;">Conceptos Variables:</td>
                <td>
                    <select id="cboConcepto_Variables" style="width:250px;">
                    </select>
                </td>
                <td style="text-align:right;width:100px;"><label>Área : </label></td>
                <td><select id="cboArea" class="ddl"></select></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td style="text-align:right;width:100px;">Conceptos Directos:</td>
                <td>
                    <select id="cboConcepto_Directos" style="width:250px;">
                    </select>
                </td>
                <td style="text-align:right;width:100px;">Conceptos Acumulados:</td>
                <td>
                    <select id="cboConcepto_Acumulados" style="width:250px;">
                    </select>
                </td>
                <td style="text-align:right;width:100px;"><label>Cat. Auxiliar : </label></td>
                <td><select id="cboCatAuxiliar" class="ddl"></select></td>
                <td></td>
                <td><input type="button" id="btnGenerarReporteDetallado" class="submit" value="Generar Reporte" style="width:100px;" /></td>
            </tr>
        </table>
    </fieldset>
    <div id="barrprocess" style="display:none;"><img src="../img/loading2.gif"  /></div>
    <fieldset style="width:100%;overflow: auto;max-height:1000px;max-width:110%;">
        <legend>Planilla General Detallado</legend>
        <div id="divta"></div>
        <div style="width:1000px;overflow: auto;height:450px;">
        
        </div>
    </fieldset>
</fieldset>
<div id="secError"></div>
    <script src="../JQuery/jquery-1.10.1.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../JQuery/jquery.multiple.select.js"></script>
    <script src="scripts/ScriptReportePlanilla.js" type="text/javascript"></script>
    <script src="scripts/Script_ExportExcel.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            initialize();
            $("#cboProceso").multipleSelect();

            ListaArea();
            ListaCatAuxiliar();
            CargarConceptos("#cboConcepto_Fijos", "01");
            CargarConceptos("#cboConcepto_Variables", "02");
            CargarConceptos("#cboConcepto_Directos", "03");
            CargarConceptos("#cboConcepto_Acumulados", "04");
        });

        $('#btnGenerarReporteDetallado').click(function () {

            if ($("#cboProceso").multipleSelect("getSelects") == "") {
                alert("Debe seleccionar un proceso.");
                return;
            }
            var parametros = $("#cboPeriodoIni").val()
                    + ":" + $("#cboPeriodoFin").val()
                    + ":" + $("#cboProceso").multipleSelect("getSelects")
                    + ":" + $("#cboConcepto_Fijos").multipleSelect("getSelects")
                    + ":" + $("#cboConcepto_Variables").multipleSelect("getSelects")
                    + ":" + $("#cboConcepto_Directos").multipleSelect("getSelects")
                    + ":" + $("#cboConcepto_Acumulados").multipleSelect("getSelects")
                    + ":" + $("#cboArea").val()
                    + ":" + $("#cboCatAuxiliar").val();

            fc_OpenReport("REP_PLANILLA_GENERAL", parametros, "1");

        });

        function CargarConceptos(combo_Id, Tipo_Concepto_ID) {
            var params = {
                Tipo: Tipo_Concepto_ID
            };
            $.ajax({
                type: "POST",
                data: JSON.stringify(params),
                url: 'FrmPlanillaGenDet.aspx/ConfigFormulaGetConceptosByTipoList',
                contentType: "application/json; chartseft:utf-8",
                dataType: "json",
                async: true,
                success: function (response) {
                    var datos = response.d;
                    for (var i = 0; i < datos.length; i++) {
                        try {
                            $('<option value="' + datos[i].Concepto_Id + '">' + datos[i].Descripcion + '</option>').appendTo(combo_Id);
                        } catch (ex) { alert(ex + " Tipo: " + combo_Id); }
                    }

                    $(combo_Id).multipleSelect({
                        filter: true
                    });
                },
                error:
                    function (XmlHttpError, error, description) {
                        alert(XmlHttpError.responseText);
                    }
            });
        }

        function ListaArea() {
            var pagePath = window.location.pathname;
            var urlajax = pagePath + '/ListaArea';

            $.ajax({
                type: "POST",
                url: urlajax,
                contentType: "application/json; chartseft:utf-8",
                dataType: "json",
                async: true,
                success: function (response) {
                    var Datos = response.d;
                    var lengthD = Datos.length - 1;

                    $('#cboArea').html('');
                    $('<option value="">--TODOS--</option>').appendTo('#cboArea');
                    for (var i = 0; i <= lengthD; i++) {
                        var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                        $(html).appendTo('#cboArea');
                    }
                },
                error:
                     function (XmlHttpError, error, description) {
                         alert(XmlHttpError.responseText);
                     }
            });
        }

        function ListaCatAuxiliar() {
            var pagePath = window.location.pathname;
            var urlajax = pagePath + '/ListaCatAuxiliar';
            $.ajax({
                type: "POST",
                url: urlajax,
                contentType: "application/json; chartseft:utf-8",
                dataType: "json",
                async: true,
                success: function (response) {
                    var Datos = response.d;
                    var lengthD = Datos.length - 1;

                    $('#cboCatAuxiliar').html('');
                    $('<option value="">--TODOS--</option>').appendTo('#cboCatAuxiliar');
                    for (var i = 0; i <= lengthD; i++) {
                        var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                        $(html).appendTo('#cboCatAuxiliar');
                    }
                },
            error:
                function (XmlHttpError, error, description) {
                    alert(XmlHttpError.responseText);
                }
            });
        }

        function fc_OpenReport(e, t, r) { var o = "750"; "1" == r && (o = "1050"); var a = "../Reportes/FrmPrint.aspx?Reporte_Id=" + e + "&prm=" + t; window.open(a, "_blank", "status=1,toolbar=no,menubar=no,location=no,scrollbars=1,resizable=1,width=" + o + ",height=600") }

    </script>
</asp:Content>
