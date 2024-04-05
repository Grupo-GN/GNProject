<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmCambioPlanilla.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Procesos.FrmCambioPlanilla" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />
    <link href="../Controles/miEstilo.css" rel="stylesheet" type="text/css" />
    <link href="../jqueriUI/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet" type="text/css" />
    <link href="../css/StyleWilder.css" rel="stylesheet" type="text/css" />

    <fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px; border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black; min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; border-top: solid 1px black;">   
        <input type="hidden" id="empresaSession" value="<%= Session["EmpresaPlanilla"] %>" />
        <input type="hidden" id="periodoSession" value="<%= Session["PeriodoPlanilla"] %>" />
        <input type="hidden" id="planillaSession" value="<%= Session["planillaPlanilla"] %>" />
        <label class="miTitulo">CAMBIAR DE PLANILLA</label>
        <table style="border-collapse:collapse;width:100%;">
            <tr>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td colspan="3">
                    <fieldset>
                        <legend>BUSQUEDA</legend>
                        <label class="miLabel">Filtrar Por:</label>
                        <select id="cboBusquedaEn" class="ddl" style="width:150px;"> </select>
                        <label class="miLabel">Digite la Persona a Buscar:</label>
                        <input type="text" class="miTextBox" id="txtBuscar" />
                        <input type="button" id="btnCambiar" class="btn" value="Cambiar de Planilla" />
                    </fieldset>
                    <div  style="overflow: hidden; width: 100%; border: solid 1px #505050;height: 260px;">
                        <table class="gridSmall" style="width:100%;">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>ID</th>
                                    <th>AP. PATERNO</th>
                                    <th>AP. MATERNO</th>
                                    <th>NOMBRES</th>
                                    <th>TIPO DOC</th>
                                    <th>NRO. DOC</th>
                                    <th>F. INGRESO</th>
                                    <th>F. INI. CONTRATO</th>
                                    <th>F. FIN</th>
                                    <th>PROYECTO</th>
                                    <th>TELÉFONO</th>        
                                </tr>
                            </thead>
                            <tbody id="tbodyPersonal" class="tbodyPer">
            
            
                            </tbody>
                        </table>
                    </div>
                    <div style="overflow: hidden; width: 100%; border: solid 1px #505050;">
                        <table class="table">
                            <tfoot>
                                <tr>
                                    <td class="tfoottd"  colspan="3">
                                        <label style="font-family: 'Droid Sans', 'Trebuchet MS', Helvetica, Arial, sans-serif; font-weight: bold; font-size: 1.1em;" >TOTAL REGISTROS: </label> &nbsp
                                        <input id="txtnRegistros" type="text" value="0" class="TextPage" readonly="true" /> &nbsp &nbsp
                                        <label style="font-family: 'Droid Sans', 'Trebuchet MS', Helvetica, Arial, sans-serif; font-weight: bold; font-size: 1.1em;" >PAGE: </label> &nbsp
                                        <input id="txtPaginaActual" type="text" value="1" class="TextPage" readonly="true" />
                                        <input id="btnPrimero" type="button" value="|<" class="submitPager" />
                                        <input id="btnAnterior" type="button" value="<<" class="submitPager" />
                                        <input id="btnSiguiente" type="button" value=">>" class="submitPager" />
                                        <input id="btnUltimo" type="button" value=">|" class="submitPager"/>
                                    </td>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </fieldset>

    <div id="divCambiar"  style="display:none;">
        <fieldset>
            <legend>CAMBIAR DE PLANILLA</legend>
            <table style="width:100%;border-collapse:collapse;">
                <tr>
                    <td>Planilla</td>
                    <td><select id="cboPlanillaChange" class="ddl"></select></td>
                    <td>Ejercicio</td>
                    <td><select id="cboEjercicioChange" class="ddl"></select></td>
                    <td>Mes</td>
                    <td><select id="cboMesChange" class="ddl"></select></td>
                    <td>Periodo</td>
                    <td><select id="cboPeriodoChange" class="ddl"></select></td>
                    <td><input type="button" value="CAMBIAR" class="btn" id="btnProcesar" /></td>
                </tr>
            </table>
        </fieldset>
        <table class="gridSmall" style="width:100%;">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>APELLIDOS Y NOMBRES</th>
                    <th>PLANILLA ACTUAL</th>       
                    <th>PERIODO ACTUAL</th>
                    <th>RESULTADO</th>
                </tr>
            </thead>
            <tbody id="tbodycambio" class="tbodyPer">
            
            
            </tbody>
        </table>
    </div>
    <div id="divError"></div>
    <script src="../JQuery/jquery-1.10.1.min.js" type="text/javascript"></script>
    <script src="../jqueriUI/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="Scripts/Script_CambiarPlanilla.js" type="text/javascript"></script>
    <script type="text/javascript">
        var inicio = 0;
        var TotalPaginador = 12;
        var TOTALREGISTROS;
        var PAGINAACTUAL = 1;
        $(document).ready(function () {


            ListaColumnPersonal();
            Lista_Personal_x_Filtro_Columna(Get_Compania(), Get_Periodo(), Get_ColumnaBusqueda(), Get_TextoBusqueda(), inicio);

            $('#cboBusquedaEn').change(function () {
                inicio = 0;
                Lista_Personal_x_Filtro_Columna(Get_Compania(), Get_Periodo(), Get_ColumnaBusqueda(), Get_TextoBusqueda(), inicio);
            });
            $('#txtBuscar').keyup(function () {
                if ($('#cboBusquedaEn').val() != 'Todos') {
                    inicio = 0;
                    Lista_Personal_x_Filtro_Columna(Get_Compania(), Get_Periodo(), Get_ColumnaBusqueda(), Get_TextoBusqueda(), inicio);
                }
            });
            $('#ctl00_ucFiltros1_cboPlanilla').change(function () {
                inicio = 0;
                Lista_Personal_x_Filtro_Columna(Get_Compania(), Get_Periodo(), Get_ColumnaBusqueda(), Get_TextoBusqueda(), inicio);
            });

            $('#btnCambiar').click(function () {
                $("#divCambiar").dialog({
                    minWidth: 850,
                    minHeight :500
                });
                Lista_Personal_x_CambiarPlanilla();
            });
            $('#tbodyPersonal').on('click', "input[type='checkbox']", function () {
                if (this.checked) {
                    seleccionados.push(this.id);
                } else {
                    var pos = seleccionados.indexOf(this.id);
                    if (pos > -1) {
                        seleccionados.splice(pos, 1);
                    }
                }
            });
             $('#btnProcesar').click(function () {
                 if (confirm('¿Está seguro(a) de realizar el cambio?')) {
                     ProcesarCambio();
                     seleccionados = [];
                     inicio = 0;
                     Lista_Personal_x_Filtro_Columna(Get_Compania(), Get_Periodo(), Get_ColumnaBusqueda(), Get_TextoBusqueda(), inicio);
                 }
            });
            //NAVEGACION

            $('#btnUltimo').click(function () {  //metodos para actualizar

                var guardaPagina = parseInt($('#txtnRegistros').val());
                var laPaginaActual = guardaPagina / TotalPaginador;

                if (guardaPagina > 0 && guardaPagina < 10) {        //Hago un if para saber la ultima pagina
                    inicio = 0;
                    laPaginaActual = 1;                             //comparando el numero de pagina
                } else if (guardaPagina > 9 && guardaPagina < 100) {    //a division con el total de pagina
                    inicio = (parseInt(guardaPagina.toString().substring(0, 1))) + "2";
                } else if (guardaPagina > 99 && guardaPagina < 1000) {
                    inicio = guardaPagina.toString().substring(0, 2) + "2";
                } else if (guardaPagina > 999 && guardaPagina < 10000) {
                    inicio = guardaPagina.toString().substring(0, 3) + "2";
                } else if (guardaPagina > 9999 && guardaPagina < 100000) {
                    inicio = guardaPagina.toString().substring(0, 4) + "2";
                }

                if (inicio > guardaPagina)
                    inicio = guardaPagina;

                if (guardaPagina == inicio) {
                    inicio = inicio - TotalPaginador;
                    PAGINAACTUAL = Math.ceil(laPaginaActual);
                    Lista_Personal_x_Filtro_Columna(Get_Compania(), Get_Periodo(), Get_ColumnaBusqueda(), Get_TextoBusqueda(), inicio);
                    setPaginaActual(PAGINAACTUAL);

                } else if (guardaPagina != TotalPaginador) {
                    PAGINAACTUAL = Math.ceil(laPaginaActual);
                    Lista_Personal_x_Filtro_Columna(Get_Compania(), Get_Periodo(), Get_ColumnaBusqueda(), Get_TextoBusqueda(), inicio);
                    setPaginaActual(PAGINAACTUAL);
                } else {
                    inicio = 0;
                }

            });

            $('#btnPrimero').click(function () {  //metodos para actualizar
                inicio = 0;         //Primer Registro
                PAGINAACTUAL = 1;   //Primera Pagina
                Lista_Personal_x_Filtro_Columna(Get_Compania(), Get_Periodo(), Get_ColumnaBusqueda(), Get_TextoBusqueda(), inicio);
                setPaginaActual(PAGINAACTUAL);
            });

            $('#btnAnterior').click(function () {  //metodos para actualizar
                if (inicio > 0) {
                    inicio = parseInt(inicio) - TotalPaginador;
                    PAGINAACTUAL = parseInt(PAGINAACTUAL) - 1;
                    Lista_Personal_x_Filtro_Columna(Get_Compania(), Get_Periodo(), Get_ColumnaBusqueda(), Get_TextoBusqueda(), inicio);
                    setPaginaActual(PAGINAACTUAL);
                }

            });
            $('#btnSiguiente').click(function () {  //metodos para actualizar

                if (parseInt($('#txtnRegistros').val()) > (parseInt(inicio) + parseInt(TotalPaginador))) {
                    inicio = parseInt(inicio) + parseInt(TotalPaginador);
                    PAGINAACTUAL = parseInt(PAGINAACTUAL) + 1;
                    Lista_Personal_x_Filtro_Columna(Get_Compania(), Get_Periodo(), Get_ColumnaBusqueda(), Get_TextoBusqueda(), inicio);
                    setPaginaActual(PAGINAACTUAL);
                }

            });

            function setPaginaActual(nPagina) { //Pintar la pagina actual visitada
                $('#txtPaginaActual').val(nPagina);
            }


            ListaTipoPlanillaChange();
            ListaEjercicioChange();
            ListaMesChange();
            ListaPeriodoChange();
            $('#cboPlanillaChange').change(function () {
                ListaEjercicioChange();
                ListaMesChange();
                ListaPeriodoChange();
            });
            $('#cboEjercicioChange').change(function () {
                ListaMesChange();
                ListaPeriodoChange();
            });
            $('#cboMesChange').change(function () {
                ListaPeriodoChange();
            });
        });
    </script>
</asp:Content>

