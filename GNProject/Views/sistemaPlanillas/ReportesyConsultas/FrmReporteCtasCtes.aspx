<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmReporteCtasCtes.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.ReportesyConsultas.FrmReporteCtasCtes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../jqueriUI/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet" />
    <script type="text/javascript" src="../JQuery/jquery-1.10.1.min.js"></script>
    <script src="../jqueriUI/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../css/multiple-select.css" />
    <script type="text/javascript" src="../JQuery/jquery.multiple.select.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px; border-right: solid 1px black;
        border-left: solid 1px black; border-bottom: solid 1px black; min-height: 500px;
        overflow: hidden; border-radius: 8px 8px 0px 0px; border-top: solid 1px black;
        font-size: 11px; font-family: Verdana;">
        <fieldset style="background-color: #FFF;">
            <legend>Filtrar</legend>
            <table>
                <tr>
                    <td>
                        Planilla:
                    </td>
                    <td>
                        <select id="cboPlanilla" style="width:200px;">
                        </select>
                    </td>
                    <td>
                        Área:
                    </td>
                    <td>
                        <select id="cboArea" style="width:200px;">
                        </select>
                    </td>
                    <td style="width:100px;">Cat. Auxiliar:</td>
                    <td><select id="cboCatAuxiliar" class="ddl"></select></td>
                </tr>
                <tr>
                    <td>Estado:</td>
                    <td>
                        <select id="cboEstado" class="ddl">
                            <option value="">--Todos--</option>
                            <option value="01">ACTIVO</option>
                            <option value="02">BAJA</option>
                        </select>
                    </td>
                    <td>
                        Personal:
                    </td>
                    <td style="width:300px";>
                        <select id="cboPersonal" style="width:100%;">
                            <option>--Seleccione--</option>
                        </select>
                    </td>
                    <td style="display:none">
                        Fecha:
                    </td>
                    <td style="display:none">
                        <input id="txtFechaDesde" type="text" value="<%=DateTime.Now.ToShortDateString() %>" style="width:70px;" />
                        <input id="txtFechaHasta" type="text" value="<%=DateTime.Now.ToShortDateString() %>" style="width:70px;" />
                    </td>
                </tr>
                <tr>
                    <td colspan="6" style="text-align: center;">
                        <input type="button" id="btnVerReporte" class="submit" value="Ver Reporte Cuentas Corrientes" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </fieldset>
    <script language="javascript" type="text/javascript">
        var pagePath = window.location.pathname;
        $(document).ready(function () {
            $('#cboPersonal').html('');
            $('#cboPersonal').multipleSelect({
                filter: true
            });

            $("#txtFechaDesde").datepicker({
                dateFormat: "dd/mm/yy",
                defaultDate: "+1w",
                //changeMonth: true,
                changeYear: true
            });
            $("#txtFechaHasta").datepicker({
                dateFormat: "dd/mm/yy",
                defaultDate: "+1w",
                //changeMonth: true,
                changeYear: true
            });

            CargarPlanilla();
            ListaArea();
            ListaCatAuxiliar();
        });

        function CargarPlanilla() {
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
                    //$('<option value="-1">--SELECCIONE--</option>').appendTo('#cboPlanilla');
                    for (var i = 0; i <= lengthD; i++) {
                        var html = '<option value="' + Datos[i].Planilla_Id + '">' + Datos[i].Descripcion + '</option>';
                        $(html).appendTo('#cboPlanilla');
                    }

                    $('#cboPlanilla').multipleSelect({
                        filter: false
                    });
                },
                error: function (XmlHttpError, error, description) {
                    alert(XmlHttpError.responseText);
                }
            });
        }
        function ListaArea() {
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
                    //$('<option value="">--TODOS--</option>').appendTo('#cboArea');
                    for (var i = 0; i <= lengthD; i++) {
                        var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                        $(html).appendTo('#cboArea');
                    }

                    $('#cboArea').multipleSelect({
                        filter: false
                    });
                },
                error: function (XmlHttpError, error, description) {
                    alert(XmlHttpError.responseText);
                }
            });
        }
        function ListaCatAuxiliar() {
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

        $("#cboPlanilla").change(function () {
            fillPersonal();
        });
        $("#cboArea").change(function () {
            fillPersonal();
        });
        $("#cboCatAuxiliar").change(function () {
            fillPersonal();
        });
        $("#cboEstado").change(function () {
            fillPersonal();
        });

        function fillPersonal() {
            var Planilla_Ids = $("#cboPlanilla").multipleSelect("getSelects").toString();
            var Area_Ids = $("#cboArea").multipleSelect("getSelects").toString();
            var CatAuxiliar_Id = $("#cboCatAuxiliar").val();
            var Estado_Id = $("#cboEstado").val();

            if (Planilla_Ids.length > 0 && Area_Ids.length > 0) {
                var params = {
                    Planilla_Ids: Planilla_Ids,
                    Area_Ids: Area_Ids,
                    CatAuxiliar_Id: CatAuxiliar_Id,
                    Estado_Id: Estado_Id
                };

                var urlajax = pagePath + '/getPersonal';
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
                        $('#cboPersonal').html('');
                        //$('<option value="">--TODOS--</option>').appendTo('#cboPersonal');
                        for (var i = 0; i <= lengthD; i++) {
                            var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                            $(html).appendTo('#cboPersonal');
                        }

                        $('#cboPersonal').multipleSelect({
                            filter: true
                        });
                    },
                    error: function (XmlHttpError, error, description) {
                        alert(XmlHttpError.responseText);
                    }
                });
            }
            else {
                $('#cboPersonal').html('');
                $('#cboPersonal').multipleSelect({
                    filter: true
                });
            }
        }

        $("#btnVerReporte").click(function () {
            var Planilla_Ids = $("#cboPlanilla").multipleSelect("getSelects").toString();
            var Area_Ids = $("#cboArea").multipleSelect("getSelects").toString();
            var CatAuxiliar_Id = $("#cboCatAuxiliar").val();
            var Estado_Id = $("#cboEstado").val();
            var Personal_Ids = $("#cboPersonal").multipleSelect("getSelects").toString();
            var FechaDesde = $("#txtFechaDesde").val()
            var FechaHasta = $("#txtFechaHasta").val()

            if (Personal_Ids == "") {
                alert("Debe seleccionar al menos un personal.");
            }

            //////else if (FechaDesde == "") {
            //////    alert("Debe ingresar fecha desde.");
            //////}
            else {


                //20181209
                var ppersonal = $("#cboPersonal").multipleSelect("getSelects");
                var ppersonalcount = $('#cboPersonal option').length;
                var parperso;
                if (ppersonal.length == ppersonalcount) {
                    parperso = 'all';
                } else {
                    parperso = ppersonal;
                }

                var parametros = Planilla_Ids
                    + ":" + Area_Ids
                    + ":" + CatAuxiliar_Id
                    + ":" + Estado_Id
                    //+ ":" + Personal_Ids
                    + ":" + parperso
                    + ":" + FechaDesde
                    + ":" + FechaHasta;
                fc_OpenReport("REP_CTAS_CTES", parametros, "1");
            }
        });

        function fc_OpenReport(e, t, r) { var o = "750"; "1" == r && (o = "1050"); var a = "../Reportes/FrmPrint.aspx?Reporte_Id=" + e + "&prm=" + t; window.open(a, "_blank", "status=1,toolbar=no,menubar=no,location=no,scrollbars=1,resizable=1,width=" + o + ",height=600") }
    </script>
</asp:Content>


