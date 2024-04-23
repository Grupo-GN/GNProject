<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="PlanillaNueva.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.nuevaPlanilla.PlanillaNueva" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" type="text/css" href="../css/multiple-select.css" />
    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />

    <link href="../Styles/nuevoEstiloPlanilla.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        @import "https://fonts.googleapis.com/css?family=Montserrat:300,400,700";

        .rwd-table {
            margin: 1em 0;
            min-width: 300px;
        }

            .rwd-table tr {
                border-top: 1px solid #ddd;
                border-bottom: 1px solid #ddd;
            }

            .rwd-table th {
                display: none;
            }

            .rwd-table td {
                display: block;
            }

                .rwd-table td:first-child {
                    padding-top: 0.5em;
                }

                .rwd-table td:last-child {
                    padding-bottom: 0.5em;
                }

                .rwd-table td:before {
                    content: attr(data-th) ": ";
                    font-weight: bold;
                    width: 6.5em;
                    display: inline-block;
                }

        @media (min-width: 480px) {
            .rwd-table td:before {
                display: none;
            }
        }

        .rwd-table th,
        .rwd-table td {
            text-align: left;
        }

        @media (min-width: 480px) {
            .rwd-table th,
            .rwd-table td {
                display: table-cell;
                padding: 0.25em 0.5em;
            }

                .rwd-table th:first-child,
                .rwd-table td:first-child {
                    padding-left: 0;
                }

                .rwd-table th:last-child,
                .rwd-table td:last-child {
                    padding-right: 0;
                }
        }



        .rwd-table {
            background: #34495e;
            color: #fff;
            border-radius: 0.4em;
            overflow: hidden;
        }

            .rwd-table tr {
                /*border-color: #46637f;*/
                border-color: #fff;
            }

            .rwd-table th,
            .rwd-table td {
                margin: 0.5em 1em;
            }

        @media (min-width: 480px) {
            .rwd-table th,
            .rwd-table td {
                padding: 1em !important;
            }
        }

        .rwd-table th,
        .rwd-table td:before {
            color: #dd5;
            BORDER-COLOR: #fff;
            BORDER: WHITE;
            BORDER-BOTTOM-STYLE: solid;
            position: sticky;
            top: 0;
            z-index: 10;
        }

        .box {
            width: 120px;
            height: 20px;
            border: 1px solid #afa7a7;
            font-size: 13px;
            color: #36383aa1;
            background-color: #ffffff;
            border-radius: 5px;
            /* box-shadow: 4px 4px #ccc;*/
        }


        .flipswitch {
            position: relative;
            background: #4c7ae2;
            width: 100px;
            height: 35px;
            -webkit-appearance: initial;
            border-radius: 3px;
            -webkit-tap-highlight-color: rgba(0, 0, 0, 0);
            outline: none;
            font-size: 13px;
            font-family: Trebuchet, Arial, sans-serif;
            font-weight: bold;
            cursor: pointer;
            border: 1px solid #a7a1a1;
        }

            .flipswitch:after {
                position: absolute;
                top: 5%;
                display: block;
                line-height: 32px;
                width: 45%;
                height: 90%;
                background: #fff;
                box-sizing: border-box;
                text-align: center;
                transition: all 0.3s ease-in 0s;
                color: black;
                border: #888 1px solid;
                border-radius: 3px;
            }

            .flipswitch:after {
                left: 2%;
                content: "NO";
            }

            .flipswitch:checked:after {
                left: 53%;
                content: "SI";
            }


        .myButton {
            box-shadow: 0px 0px 0px 2px #9fb4f2;
            background: linear-gradient(to bottom, #7892c2 5%, #476e9e 100%);
            background-color: #7892c2;
            border-radius: 10px;
            border: 1px solid #4e6096;
            display: inline-block;
            cursor: pointer;
            color: #ffffff;
            font-family: Arial;
            font-size: 15px;
            padding: 12px 37px;
            text-decoration: none;
            text-shadow: 0px 1px 0px #283966;
        }

            .myButton:hover {
                background: linear-gradient(to bottom, #476e9e 5%, #7892c2 100%);
                background-color: #476e9e;
            }

            .myButton:active {
                position: relative;
                top: 1px;
            }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px; /*border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black;*/ min-height: 500px; overflow: hidden; border-radius: 8px 8px 0px 0px; /*border-top: solid 1px black;*/ font-size: 11px; font-family: Verdana;">
        <fieldset>
        <input type="hidden" id="empresaSession" value="<%= Session["EmpresaPlanilla"] %>" />
        <input type="hidden" id="periodoSession" value="<%= Session["PeriodoPlanilla"] %>" />
        <input type="hidden" id="planillaSession" value="<%= Session["planillaPlanilla"] %>" />
        <input type="hidden" id="anioSession" value="<%= Session["anioPlanilla"] %>" />
            <legend>Filtrar</legend>
            <table>
                <%--<tr>
                            <td style="text-align: right; width: 100px;">
                                <label>Planilla : </label>
                            </td>
                            <td>
                                <select class="box" id="cboPlanilla" style="width: 200px;"></select>
                            </td>
                        </tr>--%>
                <tr>
                    <td style="text-align: right; width: 100px;">Localidad :</td>
                    <td>
                        <select class="box" id="cboArea"></select></td>
                    <td style="text-align: right; width: 100px;">
                        <label>Proyecto : </label>
                    </td>
                    <td>
                        <select id="cboProyecto" class="box"></select>
                    </td>
                    <td style="text-align: right; width: 100px;">
                        <label>Área : </label>
                    </td>
                    <td>
                        <select id="cboCatAuxiliar" class="box"></select>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 100px;">Personal Activo:</td>
                    <td colspan="2">
                        <select id="cboPersonalActivo" style="width: 300px;"></select>
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 100px;">
                        <label>Periodo Inicio : </label>
                    </td>
                    <td>
                        <select class="box" id="cboEjercicioIni" style="width: 150px;"></select>
                    </td>
                    <td style="text-align: right; width: 100px;">
                        <select class="box" id="cboPeriodoIni" style="width: 150px;"></select>
                    </td>                    
                    <td style="text-align: right; width: 100px;">
                        <label>Periodo Final : </label>
                    </td>
                    <td>
                        <select class="box" id="cboEjercicioFin" style="width: 150px;"></select>
                    </td>
                    <td>
                        <select class="box" id="cboPeriodoFin" style="width: 150px;"></select></td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 100px;">
                        <label>Estado : </label>
                    </td>
                    <td>
                        <select class="box" id="cboEstado" style="width: 150px;">
                            <option value="">--TODOS--</option>
                            <option selected="selected" value="P">PENDIENTE</option>
                            <option value="C">CANCELADO</option>
                        </select></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <%--            <tr>
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
            </tr>--%>
                <tr>
                    <td colspan="4" style="display: none;">
                        <fieldset style="width: 500px; height: 100px;">
                            <legend>Filtrar</legend>
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <input id="rbtTotal" name="rbtTotal" type="radio" />CANCELACION TOTAL</td>
                                    <td>
                                        <input id="rbtParcial" name="rbtParcial" type="radio" />CANCELACION PARCIAL</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <input id="chkG" type="checkbox" />GRATIFICACION</td>
                                    <td>
                                        <input id="chkC" type="checkbox" />CTS</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <input id="chkE" type="checkbox" />ESSALUD</td>
                                    <td>
                                        <input id="chkV" type="checkbox" />VACACIONES</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </fieldset>

                    </td>
                    <td style="text-align: left; width: 100px; display: none;">
                        <fieldset style="width: 100px; height: 100px;">
                            <legend>Filtrar por Periodo</legend>
                            <input class="flipswitch" type="checkbox" id="chkflperiodo" />
                        </fieldset>
                    </td>
                    <td style="text-align: left;"></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="text-align: center;"></td>
                    <td></td>
                    <td style="text-align: center; display: none; width: 100px">
                        <input id="chkDolares" type="checkbox" class="flipswitch" />
                    </td>
                    <td style="text-align: center; display: none">
                        <label>Importe en dólares?</label>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="9" style="text-align: center;">
                        <input type="button" id="btnBuscar" class="EstiloGeneralBoton" value="Listar Pagos" style="width: 200px;" />
                        &nbsp;&nbsp;&nbsp;
                     <input type="button" id="btnGenerarRegistraPlanilla" class="EstiloGeneralBoton btn-nuevo" value="Registrar Pagos" style="width: 250px;" />
                        &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnProcesarFormula" runat="server" class=" EstiloGeneralBoton" Text="Procesar Formula" Style="width: 200px;" OnClick="btnProcesarFormula_Click" />
                        &nbsp;&nbsp;&nbsp;
                       <asp:Button ID="btnreporte" runat="server" class="EstiloGeneralBoton" Text="Generar Reporte" Style="width: 200px; display: none;" OnClick="btnreporte_Click" />
                        &nbsp;&nbsp;&nbsp;
                       <%--<input type="button" id="btnExportar" class="myButton" value="Exportar Excel" style="width: 200px;" />
                        &nbsp;&nbsp;&nbsp;--%>
                       
                   
                    </td>
                    <td style="display: none;" colspan="6" style="text-align: center;">&nbsp;&nbsp;&nbsp;
                    <input type="button" id="btnGenerarReporteDetalladoResumen" class="submit EstiloGeneralBoton" value="Generar Reporte Resumen" style="width: 200px;" />
                        &nbsp;&nbsp;&nbsp;
                    <input type="button" id="btnGenerarReporteDetalladoComparativo" class="submit EstiloGeneralBoton" value="Generar Reporte Comparativo" style="width: 200px;" />
                    </td>
                </tr>
                <tr style="display: none;">
                    <td colspan="6">
                        <asp:HiddenField ID="txtlocalidad" runat="server" />
                        <asp:HiddenField ID="txtarea" runat="server" />
                        <asp:HiddenField ID="txtproyecto" runat="server" />
                        <asp:HiddenField ID="txtpersonal" runat="server" />
                        <%--<asp:HiddenField ID="txtplanilla" runat="server" />--%>
                    </td>
                    <td colspan="6"></td>
                </tr>
                <tr style="display: none;">
                    <td colspan="6" style="text-align: center;">
                        <input type="button" id="btnGenerarRemuneracionDet" class="submit" value="Reporte Remuneración Variable" style="width: 200px;" />
                        &nbsp;&nbsp;&nbsp;
                    <input type="button" id="btnGenerarResumenIng" class="submit" value="Reporte Ingresos CCosto" style="width: 200px;" />
                        &nbsp;&nbsp;&nbsp;
                    <input type="button" id="btnGenerarResumenIngLocalidad" class="submit" value="Reporte Ingresos Localidad" style="width: 200px;" />

                    </td>
                </tr>
            </table>
        </fieldset>

        <div id="barrprocess" style="display: none;">
            <img src="../img/loading2.gif" />
        </div>
        <fieldset style="overflow: auto; max-height: 1000px; /*max-width: 1000px;*/">
            <legend>Lista de Pagos Liquidación</legend>
            <div id="divta"></div>
            <div style="width: 1150px; overflow: auto; height: 550px;">
                <table id="TblPlanilla" class="gridSmall">
                    <thead style="position: sticky; top: 0; z-index: 10;">
                        <tr>

                            <th>
                                <input type="checkbox" id="chkAllApro" /></th>
                            <th style="display: none;">PERIODOID</th>
                            <th>NOMBRES Y APELLIDOS
                            </th>
                            <th>MES</th>
                            <th>PERIODO</th>
                            <th>F.INICIO</th>
                            <th>F.FINAL</th>
                            <th style="text-align: center;">
                                <input type="checkbox" id="chkvac" />Sel.Vac</th>
                            <th style="text-align: center;">
                                <input type="checkbox" id="chkcts" />Sel.Cts</th>
                            <th style="text-align: center;">
                                <input type="checkbox" id="chkgrati" />Sel.Grat</th>
                            <th style="text-align: center;">
                                <input type="checkbox" id="chkessalud" />Sel.Essa</th>
                            <th>VACACIONES</th>
                            <th>FECHA</th>
                            <th>CTS</th>
                            <th>FECHA</th>
                            <th>GRATIFICACION</th>
                            <th>FECHA</th>
                            <th>ESSALUD</th>
                            <th>FECHA</th>

                            <th>OTROS INGRESOS</th>
                            <th>DESCUENTOS PENCIONES</th>
                            <th>OTROS DESCUENTOS</th>
                            <th>NETO</th>
                            <th>ESTADO</th>
                            <th>OBSERVACION</th>
                        </tr>
                    </thead>
                    <tbody id="Tbodyplanilla">
                    </tbody>


                </table>

            </div>


        </fieldset>
    </fieldset>
    <div id="secError"></div>

    <asp:UpdatePanel ID="updatepnl" runat="server">
        <ContentTemplate>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnProcesarFormula" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnreporte" EventName="Click" />
            <%--btnreporte--%>
        </Triggers>
    </asp:UpdatePanel>

    <script src="../JQuery/jquery-1.10.1.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../JQuery/jquery.multiple.select.js"></script>
    <script type="text/javascript" src="asset/NuevaPlanilla.js"></script>
    <script type="text/javascript" src="jsExportExcel/ScriptExportarExcel.js"></script>

    <script language="javascript" type="text/javascript">
        function Get_Planilla_Id_Header() {
            var cbo = document.getElementById('planillaSession').value;
            return cbo;
        }
        function Get_Periodo_Id_Header() {
            var cbo = document.getElementById('periodoSession').value;
            return cbo;
        }
        $(document).ready(function () {
            //CargarPlanilla();
            CargarEjercicio();
            //SISGNRSProcesosSelect();
            //$("#cboProceso").multipleSelect();

            ListaArea();
            ListaCatAuxiliar();
            ListaProyecto();
            SISGNRSGetPersonalActivo();
            //////CargarConceptos("#cboConcepto_Fijos", "01");
            //////CargarConceptos("#cboConcepto_Variables", "02");
            //////CargarConceptos("#cboConcepto_Directos", "03");
            //////CargarConceptos("#cboConcepto_Acumulados", "04");

            SeleccionarTodoGeneral();
            SelVacaciones();
            SelCts();
            SelGrati();
            SelEssa();
            RegButon();
        });

        //function CargarPlanilla() {
        //    var pagePath = window.location.pathname;
        //    var urlajax = pagePath + '/ListaPlanilla';
        //    $.ajax({
        //        type: "POST",
        //        url: urlajax,
        //        contentType: "application/json; chartseft:utf-8",
        //        dataType: "json",
        //        async: true,
        //        success: function (response) {
        //            var Datos = response.d;
        //            var lengthD = Datos.length - 1;

        //            $('#cboPlanilla').html('');
        //            $('<option value="-1">--SELECCIONE--</option>').appendTo('#cboPlanilla');
        //            for (var i = 0; i <= lengthD; i++) {
        //                var html = '<option value="' + Datos[i].Planilla_Id + '">' + Datos[i].Descripcion + '</option>';
        //                $(html).appendTo('#cboPlanilla');
        //            }
        //        },
        //        error:
        //            function (XmlHttpError, error, description) {
        //                alert(XmlHttpError.responseText);
        //            }
        //    });
        //}
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

                    $('#cboEjercicioIni').html('');
                    $('#cboEjercicioFin').html('');
                    $('<option value="-1">--SELECCIONE--</option>').appendTo('#cboEjercicioIni');
                    $('<option value="-1">--SELECCIONE--</option>').appendTo('#cboEjercicioFin');
                    for (var i = 0; i <= lengthD; i++) {
                        var html = '<option value="' + Datos[i].Ejercicio_Id + '">' + Datos[i].Descripcion + '</option>';
                        $(html).appendTo('#cboEjercicioIni');
                        $(html).appendTo('#cboEjercicioFin');
                    }
                    $("#cboEjercicioIni").prop('selectedIndex', Datos.length);
                    $("#cboEjercicioFin").prop('selectedIndex', Datos.length);

                    SISGNRSPeriodoIniPlanillaSelect();
                    SISGNRSPeriodoFinPlanillaSelect();
                },
                error:
                    function (XmlHttpError, error, description) {
                        alert(XmlHttpError.responseText);
                    }
            });
        }

        //$('#cboPlanilla').change(function (event) {
        //    var value = $(this).val();
        //    SISGNRSPeriodoIniPlanillaSelect();
        //    SISGNRSGetPersonalActivo();
        //});
        $('#cboEjercicioIni').change(function (event) {
            var value = $(this).val();
            SISGNRSPeriodoIniPlanillaSelect();
        });
        $('#cboEjercicioFin').change(function (event) {
            var value = $(this).val();
            SISGNRSPeriodoFinPlanillaSelect();
        });
        //////$('#cboPeriodoIni').change(function (event) {

        //////});
        //////$('#cboPeriodoFin').change(function (event) {

        //////});

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
        function SISGNRSPeriodoIniPlanillaSelect() {
            var EmpresaID = "01", Anio = $('#cboEjercicioIni').val(), Planilla_Id = Get_Planilla_Id_Header();
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
        function SISGNRSPeriodoFinPlanillaSelect() {
            var EmpresaID = "01", Anio = $('#cboEjercicioFin').val(), Planilla_Id = Get_Planilla_Id_Header();
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
                    $('#cboPeriodoFin').html('');
                    for (var i = 0; i <= _len; i++) {
                        var html = '<option value="' + datos[i].Periodo_Id + '">' + datos[i].Descripcion + '</option>';
                        $(html).appendTo('#cboPeriodoFin');
                    }
                    var y = document.getElementById('cboPeriodoFin').options;
                    document.getElementById('cboPeriodoFin').selectedIndex = y.length - 1;
                },
                error:
                    function (XmlHttpError, error, description) {
                        $("#secError").html(XmlHttpError.responseText);
                    },
                async: false
            });
        };

        $('#btnBuscar').click(function () {
            if ($("#cboPersonalActivo").multipleSelect("getSelects") == "") {
                alert("Debe seleccionar un personal.");
                return;
            }
            if (Get_Planilla_Id_Header() == "") {
                alert("Debe seleccionar planilla.");
                return;
            }
            if ($("#cboEjercicioIni").val() == "-1") {
                alert("Debe seleccionar ejercicio desde.");
                return;
            }
            if ($("#cboEjercicioFin").val() == "-1") {
                alert("Debe seleccionar ejercicio hasta.");
                return;
            }
            var Periodo_Id_Desde = $("#cboPeriodoIni").val();
            var Periodo_Id_Hasta = $("#cboPeriodoFin").val();
            if (Periodo_Id_Hasta < Periodo_Id_Desde) {
                alert("Debe seleccionar un periodo final mayor al periodo de inicio.");
                return;
            }
            //20180705
            //var ppersonal = $("#cboPersonalActivo").multipleSelect("getSelects");
            //var ppersonalcount = $('#cboPersonalActivo option').length;
            //var parperso;
            //if (ppersonal.length == ppersonalcount) {
            //    parperso = 'all';
            //} else {
            //    parperso = ppersonal;
            //}

            //var parametros = $("#cboPeriodoIni").val()
            //        + ":" + $("#cboPeriodoFin").val()
            //        + ":" + $("#cboProceso").multipleSelect("getSelects")
            //        + ":" + $("#cboConcepto_Fijos").multipleSelect("getSelects")
            //        + ":" + $("#cboConcepto_Variables").multipleSelect("getSelects")
            //        + ":" + $("#cboConcepto_Directos").multipleSelect("getSelects")
            //        + ":" + $("#cboConcepto_Acumulados").multipleSelect("getSelects")
            //        + ":" + $("#cboArea").val()
            //        + ":" + $("#cboCatAuxiliar").val()
            ////+ ":" + $("#cboPersonalActivo").multipleSelect("getSelects");
            //        + ":" + $("#cboProyecto").val()
            //        + ":" + parperso
            //        + ":" + ($("#chkDolares").prop("checked") ? "1" : "0");
            //var nreporte = 'REP_PLANILLA_GENERAL';
            //if ($('#chkCentros').prop('checked') == true) {
            //    nreporte = 'REP_PLANILLA_GENERAL_CENTROS';
            //}

            //fc_OpenReport(nreporte, parametros, "1");

            get_ListaPlanilla();

        });

        $('#btnGenerarRegistraPlanilla').click(function () {
            RegistrarDatos();
        });

        $('#btnGenerarReporteDetalladoResumen').click(function () {
            if ($("#cboProceso").multipleSelect("getSelects") == "") {
                alert("Debe seleccionar un proceso.");
                return;
            }
            if (Get_Planilla_Id_Header() == "") {
                alert("Debe seleccionar planilla.");
                return;
            }
            if ($("#cboEjercicioIni").val() == "-1") {
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
            if (Get_Planilla_Id_Header() == "") {
                alert("Debe seleccionar planilla.");
                return;
            }
            if ($("#cboEjercicioIni").val() == "-1") {
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
            var pagePath = window.location.pathname;
            var params = {
                Tipo: Tipo_Concepto_ID
            };
            $.ajax({
                type: "POST",
                data: JSON.stringify(params),
                url: pagePath + '/ConfigFormulaGetConceptosByTipoList',
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
                    $('<option value="">--TODOS--</option>').appendTo('#cboProyecto');
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
            var PlanillaId = Get_Planilla_Id_Header();
            var Periodo_Id = Get_Periodo_Id_Header();
            var localidad = $('#cboArea').val();
            var proyecto = $('#cboProyecto').val();
            var Area = $('#cboCatAuxiliar').val();
            //var PeriodoIni = $('#cboPeriodoIni').val() == null ? '' : $('#cboPeriodoIni').val();
            //var PeriodoFin = $('#cboPeriodoFin').val() == null ? '' : $('#cboPeriodoFin').val();
            var params = {
                Planilla_Id: PlanillaId,
                Periodo_Id: Periodo_Id,
                Localidad_Id: localidad,
                Proyecto_Id: proyecto,
                Area_Id: Area
                //PeriodoIni: PeriodoIni,
                //PeriodoFin: PeriodoFin
            };
            var pagePath = window.location.pathname;
            //var urlajax = pagePath + '/ListaPersonalActivoReporteGeneral';
            var urlajax = pagePath + '/getPersonalActivo';
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
            if (Get_Planilla_Id_Header() == "") {
                alert("Debe seleccionar planilla.");
                return;
            }
            if ($("#cboEjercicioIni").val() == "-1") {
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
            if (Get_Planilla_Id_Header() == "-1") {
                alert("Debe seleccionar planilla.");
                return;
            }
            if ($("#cboEjercicioIni").val() == "-1") {
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
            if (Get_Planilla_Id_Header() == "-1") {
                alert("Debe seleccionar planilla.");
                return;
            }
            if ($("#cboEjercicioIni").val() == "-1") {
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

        //procesar formulas 
        <%--$('#cboPlanilla').on('change', function () {
            //alert("La acción se puede lanzar aquí, ¿por qué no? " + this.value);
            ////$('#txtlocalidad.ClientID').val(this.value);
            ////document.getElementById('txtlocalidad').value = this.value;
            $("#<%= txtplanilla.ClientID %>").val(this.value);
        })--%>

        $('#cboArea').on('change', function () {
            $("#<%= txtlocalidad.ClientID %>").val(this.value);
            SISGNRSGetPersonalActivo();
        })

        $('#cboCatAuxiliar').on('change', function () {
            $("#<%= txtarea.ClientID %>").val(this.value);
            SISGNRSGetPersonalActivo();
        })

        $('#cboProyecto').on('change', function () {
            $("#<%= txtproyecto.ClientID %>").val(this.value);
            SISGNRSGetPersonalActivo();
        })

        $('#cboPersonalActivo').on('change', function () {
            var ppersonal = $("#cboPersonalActivo").multipleSelect("getSelects");
            var ppersonalcount = $('#cboPersonalActivo option').length;
            var parperso;

            if (ppersonal.length == ppersonalcount) {
                parperso = '';
            } else {
                parperso = ppersonal;
            }

            var personal = parperso.toString();

            $("#<%= txtpersonal.ClientID %>").val(personal);
        })

        $('#btnExportar').click(function () {

            exportExcel('TblPlanilla', 'Reporte_Liquida');


        });

        var PeriodoCab = '';
        window.setInterval(function () {
            var Period = document.getElementById('periodoSession').value;
            if (!PeriodoCab) {
                PeriodoCab = Period;
            }
            if (PeriodoCab != Period) {
                location.reload(); //LoadPage();
                PeriodoCab = Period;
            }
        }, 1000);

    </script>

</asp:Content>



