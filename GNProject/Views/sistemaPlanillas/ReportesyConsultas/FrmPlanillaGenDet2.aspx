<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmPlanillaGenDet2.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.ReportesyConsultas.FrmPlanillaGenDet2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <link rel="stylesheet" type="text/css" href="../css/multiple-select.css" />
    <fieldset style="width:100%; background-color: White; margin: 0px 0px 0px 0px;
           border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black; 
            min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; border-top: solid 1px black;
            font-size:11px; font-family:Verdana;">
    <fieldset>
        <legend>Filtrar</legend>
        <table>
            <tr>
                <td style="text-align:right;width:100px;"><label>Planilla : </label></td>
                <td>
                    <select class="miComboBox" id="cboPlanilla" style="width:200px;"></select>
                </td>
                <td style="text-align:right;width:100px;"><label>Ejercicio : </label></td>
                <td>
                    <select class="miComboBox" id="cboEjercicio" style="width:150px;"></select>
                </td>
                <td style="text-align:right;width:100px;"></td>
                <td></td>
            </tr>
            <tr>
                <td style="text-align:right;width:100px;"><label>Proceso : </label></td>
                <td>
                    <select class="miComboBox" id="cboProceso" style="width:200px;"></select>
                </td>
                <td style="text-align:right;width:100px;"><label>Periodo Inicio : </label></td>
                <td><select class="miComboBox" id="cboPeriodoIni" style="width:150px;"></select></td>
                <td style="text-align:right;width:100px;"><label>Periodo Final : </label></td>
                <td><select class="miComboBox" id="cboPeriodoFin" style="width:150px;"></select></td>
            </tr>
            <tr>
                <td style="text-align:right;width:100px;">Conceptos Fijos:</td>
                <td>
                    <select id="cboConcepto_Fijos" style="width:300px;">
                    </select>
                </td>
                <td style="text-align:right;width:100px;"><label>Localidad : </label></td>
                <td><select id="cboArea" class="ddl"></select></td>
                <td style="text-align:right;width:100px;"><label>Proyecto : </label></td>
                <td><select id="cboProyecto" class="ddl"></select></td>
            </tr>
            <tr>
                <td style="text-align:right;width:100px;">Conceptos Variables:</td>
                <td><select id="cboConcepto_Variables" style="width:300px;"></select></td>
                <td style="text-align:right;width:100px;"><label>Área : </label></td>
                <td><select id="cboCatAuxiliar" class="ddl"></select></td>
                <td style="text-align:right;width:100px;">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align:right;width:100px;">Conceptos Directos:</td>
                <td>
                    <select id="cboConcepto_Directos" style="width:300px;">
                    </select>
                </td>
                <td style="text-align:right;width:100px;">Conceptos Acumulados:</td>
                <td colspan="2">
                    <select id="cboConcepto_Acumulados" style="width:300px;">
                    </select>
                </td>
                <td></td>
            </tr>
            <tr>
                <td style="text-align:right;width:100px;">Personal Activo:</td>
                <td><select id="cboPersonalActivo" style="width:300px;"></select></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td colspan="6" style="text-align:center;">
                    <label><input id="chkDolares" type="checkbox" /> Importe en dólares?</label>
                    <label><input type="checkbox" id="chkCentros" /> Generar Reporte por Centro de Costo</label><br />
                </td>
            </tr>
            <tr>
                <td colspan="6" style="text-align:center;">
                    <input type="button" id="btnGenerarReporteDetallado_SinGrupo" class="submit" value="Ver Planilla General" style="width:200px;" />
                    &nbsp;&nbsp;&nbsp;
                    <input type="button" id="btnGenerarReporteDetallado" class="submit" value="Generar Reporte Detallado" style="width:200px;" />
                    &nbsp;&nbsp;&nbsp;
                    <input type="button" id="btnGenerarReporteDetalladoResumen" class="submit" value="Generar Reporte Resumen" style="width:200px;" />
                    &nbsp;&nbsp;&nbsp;
                    <input type="button" id="btnGenerarReporteDetalladoComparativo" class="submit" value="Generar Reporte Comparativo" style="width:200px;" />
                </td>
            </tr>
            <tr>
                <td colspan="6" style="text-align:center;">
                    <input type="button" id="btnGenerarRemuneracionDet" class="submit" value="Reporte Remuneración Variable" style="width:200px;" />
                    &nbsp;&nbsp;&nbsp;
                    <input type="button" id="btnGenerarResumenIng" class="submit" value="Reporte Ingresos CCosto" style="width:200px;" />
                    &nbsp;&nbsp;&nbsp;
                    <input type="button" id="btnGenerarResumenIngLocalidad" class="submit" value="Reporte Ingresos Localidad" style="width:200px;" />
                    
                </td>
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
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            CargarPlanilla();
            CargarEjercicio();
            SISGNRSProcesosSelect();

            $("#cboProceso").multipleSelect();

            ListaArea();
            ListaCatAuxiliar();
            ListaProyecto();
            CargarConceptos("#cboConcepto_Fijos", "01");
            CargarConceptos("#cboConcepto_Variables", "02");
            CargarConceptos("#cboConcepto_Directos", "03");
            CargarConceptos("#cboConcepto_Acumulados", "04");
        });

        function CargarPlanilla() {
            var pagePath = window.location.pathname;
            var urlajax = pagePath + '/ListaPlanilla';
            $.ajax({
                type: "POST",
                url: urlajax,
                contentType: "application/json; chartseft:utf-8",
                dataType: "json",
                async: true,
                success: function (response) {
                    var Datos = response.d;
                    var lengthD = Datos.length - 1;

                    $('#cboPlanilla').html('');
                    $('<option value="-1">--SELECCIONE--</option>').appendTo('#cboPlanilla');
                    for (var i = 0; i <= lengthD; i++) {
                        var html = '<option value="' + Datos[i].Planilla_Id + '">' + Datos[i].Descripcion + '</option>';
                        $(html).appendTo('#cboPlanilla');
                    }
                },
                error:
                function (XmlHttpError, error, description) {
                    alert(XmlHttpError.responseText);
                }
            });
        }
        function CargarEjercicio() {
            var pagePath = window.location.pathname;
            var urlajax = pagePath + '/ListaEjercicio';
            $.ajax({
                type: "POST",
                url: urlajax,
                contentType: "application/json; chartseft:utf-8",
                dataType: "json",
                async: true,
                success: function (response) {
                    var Datos = response.d;
                    var lengthD = Datos.length - 1;

                    $('#cboEjercicio').html('');
                    $('<option value="-1">--SELECCIONE--</option>').appendTo('#cboEjercicio');
                    for (var i = 0; i <= lengthD; i++) {
                        var html = '<option value="' + Datos[i].Ejercicio_Id + '">' + Datos[i].Descripcion + '</option>';
                        $(html).appendTo('#cboEjercicio');
                    }
                    $("#cboEjercicio").prop('selectedIndex', Datos.length);
                },
                error:
                function (XmlHttpError, error, description) {
                    alert(XmlHttpError.responseText);
                }
            });
        }

        $('#cboPlanilla').change(function (event) {
            var value = $(this).val();
            SISGNRSPeriodoPlanillaSelect();
            SISGNRSGetPersonalActivo();
        });
        $('#cboEjercicio').change(function (event) {
            var value = $(this).val();
            SISGNRSPeriodoPlanillaSelect();
        });
        $('#cboPeriodoIni').change(function (event) {
            SISGNRSGetPersonalActivo();
        });
        $('#cboPeriodoFin').change(function (event) {
            SISGNRSGetPersonalActivo();
        });

        function SISGNRSProcesosSelect() {
            //$('<option value="01">REMUNERACIONES</option>').appendTo('#cboProceso');
            //$('<option value="02">QUINCENA</option>').appendTo('#cboProceso');
            //$('<option value="03">VACACIONES</option>').appendTo('#cboProceso');
            //$('<option value="04">GRATIFICACION</option>').appendTo('#cboProceso');
            //$('<option value="05">CTS</option>').appendTo('#cboProceso');
            //$('<option value="06">PROVISION</option>').appendTo('#cboProceso');
            //$('<option value="07">UTILIDADES</option>').appendTo('#cboProceso');
            //$('<option value="08">LIQUIDACION</option>').appendTo('#cboProceso');
            var pagePath = window.location.pathname;
            var urlajax = pagePath + '/Get_Proceso_Combo';
            $.ajax({
                type: "POST",
                data: "",
                dataType: "json",
                url: urlajax,
                contentType: "application/json; chartseft:utf-8",
                success: function (response) {
                    var datos = response.d;
                    var _len = datos.length - 1;
                    $('#cboProceso').html('');
                    for (var i = 0; i <= _len; i++) {
                        var html = '<option value="' + datos[i].Proceso_Id + '">' + datos[i].Descripcion + '</option>';
                        $(html).appendTo('#cboProceso');
                    }
                },
                error: function (XmlHttpError, error, description) {
                    $("#secError").html(XmlHttpError.responseText);
                },
                async: false
            });
        }
        function SISGNRSPeriodoPlanillaSelect() {
            var EmpresaID = "01", Anio = $('#cboEjercicio').val(), Planilla_Id = $('#cboPlanilla').val();
            params = {
                Compania_Id: EmpresaID,
                Anio: Anio,
                Planilla_Id: Planilla_Id
            };
            var pagePath = window.location.pathname;
            var urlajax = pagePath + '/Get_Periodo_Combo';
            $.ajax({
                type: "POST",
                data: JSON.stringify(params),
                dataType: "json",
                url: urlajax,
                contentType: "application/json; chartseft:utf-8",
                success: function (response) {
                    var datos = response.d;
                    var _len = datos.length - 1;
                    $('#cboPeriodoIni').html('');
                    $('#cboPeriodoFin').html('');
                    for (var i = 0; i <= _len; i++) {
                        var html = '<option value="' + datos[i].Periodo_Id + '">' + datos[i].Descripcion + '</option>';
                        $(html).appendTo('#cboPeriodoIni');
                        $(html).appendTo('#cboPeriodoFin');
                    }
                    var y = document.getElementById('cboPeriodoIni').options;
                    document.getElementById('cboPeriodoIni').selectedIndex = y.length - 1;
                    document.getElementById('cboPeriodoFin').selectedIndex = y.length - 1;
                },
                error:
                function (XmlHttpError, error, description) {
                    $("#secError").html(XmlHttpError.responseText);
                },
                async: false
            });
        };

        $('#btnGenerarReporteDetallado_SinGrupo').click(function () {
            if ($("#cboProceso").multipleSelect("getSelects") == "") {
                alert("Debe seleccionar un proceso.");
                return;
            }
            if ($("#cboPlanilla").val() == "-1") {
                alert("Debe seleccionar planilla.");
                return;
            }
            if ($("#cboEjercicio").val() == "-1") {
                alert("Debe seleccionar ejercicio.");
                return;
            }
            //20180705
            var ppersonal = $("#cboPersonalActivo").multipleSelect("getSelects");
            var ppersonalcount = $('#cboPersonalActivo option').length;
            var parperso;
            if (ppersonal.length == ppersonalcount) {
                parperso = 'all';
            } else {
                parperso = ppersonal;
            }

            var parametros = $("#cboPeriodoIni").val()
                    + ":" + $("#cboPeriodoFin").val()
                    + ":" + $("#cboProceso").multipleSelect("getSelects")
                    + ":" + $("#cboConcepto_Fijos").multipleSelect("getSelects")
                    + ":" + $("#cboConcepto_Variables").multipleSelect("getSelects")
                    + ":" + $("#cboConcepto_Directos").multipleSelect("getSelects")
                    + ":" + $("#cboConcepto_Acumulados").multipleSelect("getSelects")
                    + ":" + $("#cboArea").val()
                    + ":" + $("#cboCatAuxiliar").val()
            //+ ":" + $("#cboPersonalActivo").multipleSelect("getSelects");
                    + ":" + $("#cboProyecto").val()
                    + ":" + parperso
                    + ":" + ($("#chkDolares").prop("checked") ? "1" : "0");
            var nreporte = 'REP_PLANILLA_GENERAL_DETALLE';
            
            fc_OpenReport(nreporte, parametros, "1");
        });
        $('#btnGenerarReporteDetallado').click(function () {
            if ($("#cboProceso").multipleSelect("getSelects") == "") {
                alert("Debe seleccionar un proceso.");
                return;
            }
            if ($("#cboPlanilla").val() == "-1") {
                alert("Debe seleccionar planilla.");
                return;
            }
            if ($("#cboEjercicio").val() == "-1") {
                alert("Debe seleccionar ejercicio.");
                return;
            }
            //20180705
            var ppersonal = $("#cboPersonalActivo").multipleSelect("getSelects");
            var ppersonalcount = $('#cboPersonalActivo option').length;
            var parperso;
            if (ppersonal.length == ppersonalcount) {
                parperso = 'all';
            } else {
                parperso = ppersonal;
            }

            var parametros = $("#cboPeriodoIni").val()
                    + ":" + $("#cboPeriodoFin").val()
                    + ":" + $("#cboProceso").multipleSelect("getSelects")
                    + ":" + $("#cboConcepto_Fijos").multipleSelect("getSelects")
                    + ":" + $("#cboConcepto_Variables").multipleSelect("getSelects")
                    + ":" + $("#cboConcepto_Directos").multipleSelect("getSelects")
                    + ":" + $("#cboConcepto_Acumulados").multipleSelect("getSelects")
                    + ":" + $("#cboArea").val()
                    + ":" + $("#cboCatAuxiliar").val()
            //+ ":" + $("#cboPersonalActivo").multipleSelect("getSelects");
                    + ":" + $("#cboProyecto").val()
                    + ":" + parperso
                    + ":" + ($("#chkDolares").prop("checked") ? "1" : "0");
            var nreporte = 'REP_PLANILLA_GENERAL';
            if ($('#chkCentros').prop('checked') == true) {
                nreporte = 'REP_PLANILLA_GENERAL_CENTROS';
            }

            fc_OpenReport(nreporte, parametros, "1");
        });
        $('#btnGenerarReporteDetalladoResumen').click(function () {
            if ($("#cboProceso").multipleSelect("getSelects") == "") {
                alert("Debe seleccionar un proceso.");
                return;
            }
            if ($("#cboPlanilla").val() == "-1") {
                alert("Debe seleccionar planilla.");
                return;
            }
            if ($("#cboEjercicio").val() == "-1") {
                alert("Debe seleccionar ejercicio.");
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
                + ":" + $("#cboCatAuxiliar").val()
                + ":" + $("#cboProyecto").val()
                + ":" + $("#cboPersonalActivo").multipleSelect("getSelects")
                + ":" + ($("#chkDolares").prop("checked") ? "1" : "0");
            fc_OpenReport("REP_PLANILLA_GENERAL_RESUMEN", parametros, "1");
        });
        $('#btnGenerarReporteDetalladoComparativo').click(function () {
            if ($("#cboProceso").multipleSelect("getSelects") == "") {
                alert("Debe seleccionar un proceso.");
                return;
            }
            if ($("#cboPlanilla").val() == "-1") {
                alert("Debe seleccionar planilla.");
                return;
            }
            if ($("#cboEjercicio").val() == "-1") {
                alert("Debe seleccionar ejercicio.");
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
                + ":" + $("#cboCatAuxiliar").val()
                + ":" + $("#cboProyecto").val()
                + ":" + $("#cboPersonalActivo").multipleSelect("getSelects")
                + ":" + ($("#chkDolares").prop("checked") ? "1" : "0");
            fc_OpenReport("REP_PLANILLA_GENERAL_COMPARATIVO", parametros, "1");
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
        function ListaProyecto() {
            var pagePath = window.location.pathname;
            var urlajax = pagePath + '/ListaProyecto';
            $.ajax({
                type: "POST",
                url: urlajax,
                contentType: "application/json; chartseft:utf-8",
                dataType: "json",
                async: true,
                success: function (response) {
                    var Datos = response.d;
                    var lengthD = Datos.length - 1;

                    $('#cboProyecto').html('');
                    $('<option value="all">--TODOS--</option>').appendTo('#cboProyecto');
                    for (var i = 0; i <= lengthD; i++) {
                        var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                        $(html).appendTo('#cboProyecto');
                    }
                },
                error:
                    function (XmlHttpError, error, description) {
                        alert(XmlHttpError.responseText);
                    }
            });
        }
        function fc_OpenReport(e, t, r) { var o = "750"; "1" == r && (o = "1050"); var a = "../Reportes/FrmPrint.aspx?Reporte_Id=" + e + "&prm=" + t; window.open(a, "_blank", "status=1,toolbar=no,menubar=no,location=no,scrollbars=1,resizable=1,width=" + o + ",height=600") }

        function SISGNRSGetPersonalActivo() {
            var PlanillaId = $('#cboPlanilla').val() == null ? '' : $('#cboPlanilla').val();
            var PeriodoIni = $('#cboPeriodoIni').val() == null ? '' : $('#cboPeriodoIni').val();
            var PeriodoFin = $('#cboPeriodoFin').val() == null ? '' : $('#cboPeriodoFin').val();
            var params = {
                PlanillaId: PlanillaId,
                PeriodoIni: PeriodoIni,
                PeriodoFin: PeriodoFin
            };
            var pagePath = window.location.pathname;
            var urlajax = pagePath + '/ListaPersonalActivoReporteGeneral';
            $.ajax({
                type: "POST",
                data: JSON.stringify(params),
                url: urlajax,
                contentType: "application/json; chartseft:utf-8",
                dataType: "json",
                async: true,
                success: function (response) {
                    var Datos = response.d;
                    var lengthD = Datos.length - 1;

                    $('#cboPersonalActivo').html('');
                    //$('<option value="">-TODOS-</option>').appendTo('#cboPersonalActivo');
                    for (var i = 0; i <= lengthD; i++) {
                        var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                        $(html).appendTo('#cboPersonalActivo');
                    }
                    //$("#cboPersonalActivo").prop('selectedIndex', Datos.length);
                    $('#cboPersonalActivo').multipleSelect({
                        filter: true
                    });
                },
                error:
                function (XmlHttpError, error, description) {
                    alert(XmlHttpError.responseText);
                }
            });
        }
        $('#btnGenerarRemuneracionDet').click(function () {
            if ($("#cboPlanilla").val() == "-1") {
                alert("Debe seleccionar planilla.");
                return;
            }
            if ($("#cboEjercicio").val() == "-1") {
                alert("Debe seleccionar ejercicio.");
                return;
            }
            //20180705
            var ppersonal = $("#cboPersonalActivo").multipleSelect("getSelects");
            var ppersonalcount = $('#cboPersonalActivo option').length;
            var parperso;
            if (ppersonal.length == ppersonalcount) {
                parperso = 'all';
            } else {
                parperso = ppersonal;
            }

            var parametros = $("#cboPeriodoIni").val()
                    + ":" + $("#cboPeriodoFin").val()
                    + ":" + $("#cboConcepto_Fijos").multipleSelect("getSelects")
                    + ":" + $("#cboConcepto_Variables").multipleSelect("getSelects")
                    + ":" + $("#cboConcepto_Directos").multipleSelect("getSelects")
                    + ":" + $("#cboConcepto_Acumulados").multipleSelect("getSelects")
                    + ":" + $("#cboArea").val()
                    + ":" + $("#cboCatAuxiliar").val()
                    + ":" + $("#cboProyecto").val()
                + ":" + parperso;
            var nreporte = 'REP_REM_VARIABLE';

            fc_OpenReport(nreporte, parametros, "1");
        });
        $('#btnGenerarResumenIng').click(function () {
            if ($("#cboPlanilla").val() == "-1") {
                alert("Debe seleccionar planilla.");
                return;
            }
            if ($("#cboEjercicio").val() == "-1") {
                alert("Debe seleccionar ejercicio.");
                return;
            }
            if ($("#cboProceso").multipleSelect("getSelects") == "") {
                alert("Debe seleccionar un proceso.");
                return;
            }
            //20180705
            var ppersonal = $("#cboPersonalActivo").multipleSelect("getSelects");
            var ppersonalcount = $('#cboPersonalActivo option').length;
            var parperso;
            if (ppersonal.length == ppersonalcount) {
                parperso = 'all';
            } else {
                parperso = ppersonal;
            }

            var parametros = $("#cboPeriodoIni").val()
                + ":" + $("#cboPeriodoFin").val()
                + ":" + $("#cboProceso").multipleSelect("getSelects")
                + ":" + $("#cboArea").val()
                + ":" + $("#cboCatAuxiliar").val()
                + ":" + $("#cboProyecto").val()
                + ":" + parperso;
            var nreporte = 'REP_ING_CCOSTO';

            fc_OpenReport(nreporte, parametros, "1");
        });
        $('#btnGenerarResumenIngLocalidad').click(function () {
            if ($("#cboPlanilla").val() == "-1") {
                alert("Debe seleccionar planilla.");
                return;
            }
            if ($("#cboEjercicio").val() == "-1") {
                alert("Debe seleccionar ejercicio.");
                return;
            }
            if ($("#cboProceso").multipleSelect("getSelects") == "") {
                alert("Debe seleccionar un proceso.");
                return;
            }
            //20180705
            var ppersonal = $("#cboPersonalActivo").multipleSelect("getSelects");
            var ppersonalcount = $('#cboPersonalActivo option').length;
            var parperso;
            if (ppersonal.length == ppersonalcount) {
                parperso = 'all';
            } else {
                parperso = ppersonal;
            }

            var parametros = $("#cboPeriodoIni").val()
                + ":" + $("#cboPeriodoFin").val()
                + ":" + $("#cboProceso").multipleSelect("getSelects")
                + ":" + $("#cboArea").val()
                + ":" + $("#cboCatAuxiliar").val()
                + ":" + $("#cboProyecto").val()
                + ":" + parperso;
            var nreporte = 'REP_ING_LOCALIDAD';

            fc_OpenReport(nreporte, parametros, "1");
        });
    </script>
</asp:Content>




