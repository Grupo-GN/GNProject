<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="frmPersonalExport.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.ReportesyConsultas.frmPersonalExport" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <link rel="stylesheet" type="text/css" href="../css/multiple-select.css" />
    <link href="../Styles/nuevoEstiloPlanilla.css" rel="stylesheet" type="text/css" />
    <fieldset style="width:100%; background-color: White; margin: 0px 0px 0px 0px;/*border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black;*/min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; /*border-top: solid 1px black;*/font-size:11px; font-family:Verdana;">
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
        <td style="text-align:right;width:100px;"><label>Periodo : </label></td>
        <td><select class="miComboBox" id="cboPeriodoIni" style="width:150px;" name="D1"></select></td>
        </tr>
        <tr>
        <td style="text-align:right;width:100px;"><label>Localidad : </label></td>
        <td>
        
            <select id="cboArea" class="ddl" name="D2"></select></td>
        <td style="text-align:right;width:100px;">
            <label>&nbsp;Cat. Auxiliar : </label></td>
        <td><select id="cboCatAuxiliar" class="ddl" name="D3"></select></td>
        <td style="text-align:right;width:100px;">&nbsp;</td>
        <td>&nbsp;</td>
        </tr>
        <tr>
        <td style="text-align:right;width:100px;">Personal : </td>
        <td colspan="2"><select id="cboPersonalActivo" style="width:350px;" name="D4"></select></td>
        <td>
        &nbsp;</td>
        <td style="text-align:right;width:100px;">&nbsp;</td>
        <td>&nbsp;</td>
        </tr>
        <tr>
        <td colspan="6" style="text-align:center;">
        <input type="button" id="btnGenerarReporteDetallado" class="submit" value="Generar Reporte Detallado" style="width:200px;" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;
        </td>
        </tr>
        </table>
        </fieldset>
    </fieldset>
    <div id="secError"></div>
    <script src="../JQuery/jquery-1.10.1.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../JQuery/jquery.multiple.select.js"></script>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            CargarPlanilla();
            CargarEjercicio();

            ListaArea();
            ListaCatAuxiliar();
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
                    console.log(XmlHttpError.responseText);
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
                    console.log(XmlHttpError.responseText);
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
                        }
                        var y = document.getElementById('cboPeriodoIni').options;
                        document.getElementById('cboPeriodoIni').selectedIndex = y.length - 1;
                    },
                    error:
                    function (XmlHttpError, error, description) {
                        $("#secError").html(XmlHttpError.responseText);
                    },
                    async: false
                });
            };
            function SISGNRSGetPersonalActivo() {
                var PlanillaId = $('#cboPlanilla').val() == null ? '' : $('#cboPlanilla').val();
                var PeriodoIni = $('#cboPeriodoIni').val() == null ? '' : $('#cboPeriodoIni').val();
                var PeriodoFin = $('#cboPeriodoIni').val() == null ? '' : $('#cboPeriodoIni').val();
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
        $('#btnGenerarReporteDetallado').click(function () {
            if ($("#cboPlanilla").val() == "-1") {
                alert("Debe seleccionar planilla.");
                return;
            }
            if ($("#cboEjercicio").val() == "-1") {
                alert("Debe seleccionar ejercicio.");
                return;
            }
            var ppersonal = $("#cboPersonalActivo").multipleSelect("getSelects");
            var ppersonalcount = $('#cboPersonalActivo option').length;
            var parperso;
            if (ppersonal.length == ppersonalcount) {
                parperso = 'all';
            } else {
                parperso = ppersonal;
            }

            var parametros = $("#cboPeriodoIni").val()
                    + ":" + $("#cboArea").val()
                    + ":" + $("#cboCatAuxiliar").val()
                    + ":" + parperso;
            fc_OpenReport("REPDATAEXPORTPERSONAL", parametros, "1");
        });

        function fc_OpenReport(e, t, r) { var o = "750"; "1" == r && (o = "1050"); var a = "../Reportes/FrmPrint.aspx?Reporte_Id=" + e + "&prm=" + t; window.open(a, "_blank", "status=1,toolbar=no,menubar=no,location=no,scrollbars=1,resizable=1,width=" + o + ",height=600") }
    </script>
</asp:Content>

