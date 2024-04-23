<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="MntDatosBancarios.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Mantenimientos.MntDatosBancarios" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />
    <link href="../Controles/miEstilo.css" rel="stylesheet" type="text/css" />
    <link href="../jqueriUI/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet" type="text/css" />
    <link href="../css/StyleWilder.css" rel="stylesheet" type="text/css" />

    <link href="../Styles/nuevoEstiloPlanilla.css" rel="stylesheet" type="text/css" />
        
    <fieldset style="width:100%; background-color: White; margin: 0px 0px 0px 0px;/*border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black;*/min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; /*border-top: solid 1px black;*/">
     <fieldset>
         <input type="hidden" id="empresaSession" value="<%= Session["EmpresaPlanilla"] %>" />
        <input type="hidden" id="periodoSession" value="<%= Session["PeriodoPlanilla"] %>" />
        <input type="hidden" id="planillaSession" value="<%= Session["planillaPlanilla"] %>" />
        <table width="100%">
            <tr>
                <td style="width:90%;">
                    <asp:Label ID="Label9" runat="server" Text="MANTENIMIENTO DE DATOS BANCARIOS" CssClass="miTitulo" Width="100%"></asp:Label>
                </td>
                <td style="text-align:right;width:28px;"><input type="button" class="elBotonUpdate" id="btnUpdate" value="Actualizar" title="Para Modificar el Registro" /></td>
            </tr>
            
        </table>
    </fieldset>
        <fieldset>
            <legend>BUSQUEDA</legend>
            <table style="border-collapse:collapse;">
                <tr>
                    <td><label class="miLabel">Buscar Personal:</label></td>
                    <td><input type="text" class="miTextBox" id="txtBuscar" /></td>
                    <td>Localidad:</td>
                    <td><select class="ddl" id="cboLocalidad"></select></td>
                    <td>Proyecto:</td>
                    <td><select class="ddl" id="cboProyecto"></select></td>
                    <td>Area:</td>
                    <td><select class="ddl" id="cboArea"></select></td>
                </tr>
            </table>     
            
        </fieldset>
        <div  style="overflow: hidden; width: 100%; border: solid 1px #505050;/*height: 320px;*/">
            <table class="gridSmall" style="width:100%;">
                <thead>
                    <tr>
                        <th>PERSONAL</th>
                        <th>TIPO DOC</th>
                        <th>NRO. DOC</th>
                        <th>TIPO CTA</th>
                        <th>BANCO</th>
                        <th>MONEDA</th>
                        <th>NRO. CTA</th>
                        <th>NRO. CTA INTERBANCARIA</th>
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
    </fieldset>
    <script src="../JQuery/jquery-1.10.1.min.js" type="text/javascript"></script>
    <script src="Scripts/ScriptDatosBancarios.js" type="text/javascript"></script>
    <script type="text/javascript">
        var inicio = 0;
        var TotalPaginador = 12;
        var TOTALREGISTROS;
        var PAGINAACTUAL = 1;
        $(document).ready(function () {
            Lista_Personal_DatosBancarios(inicio);
            $('#txtBuscar').keypress(function () { Lista_Personal_DatosBancarios(inicio); });
            $('#cboLocalidad').change(function () { Lista_Personal_DatosBancarios(inicio); });
            $('#cboProyecto').change(function () { Lista_Personal_DatosBancarios(inicio); });
            $('#cboArea').change(function () { Lista_Personal_DatosBancarios(inicio); });
            $('#btnUpdate').click(function () {
                if (confirm('¿Está seguro(a) de actualizar la información?')) {
                    Guardar();
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
                Lista_Personal_DatosBancarios(inicio);
                setPaginaActual(PAGINAACTUAL);

            } else if (guardaPagina != TotalPaginador) {
                PAGINAACTUAL = Math.ceil(laPaginaActual);
                Lista_Personal_DatosBancarios(inicio);
                setPaginaActual(PAGINAACTUAL);
            } else {
                inicio = 0;
            }

        });

        $('#btnPrimero').click(function () {  //metodos para actualizar
            inicio = 0;         //Primer Registro
            PAGINAACTUAL = 1;   //Primera Pagina
            Lista_Personal_DatosBancarios(inicio);
            setPaginaActual(PAGINAACTUAL);
        });

        $('#btnAnterior').click(function () {  //metodos para actualizar
            if (inicio > 0) {
                inicio = parseInt(inicio) - TotalPaginador;
                PAGINAACTUAL = parseInt(PAGINAACTUAL) - 1;
                Lista_Personal_DatosBancarios(inicio);
                setPaginaActual(PAGINAACTUAL);
            }

        });
        $('#btnSiguiente').click(function () {  //metodos para actualizar

            if (parseInt($('#txtnRegistros').val()) > (parseInt(inicio) + parseInt(TotalPaginador))) {
                inicio = parseInt(inicio) + parseInt(TotalPaginador);
                PAGINAACTUAL = parseInt(PAGINAACTUAL) + 1;
                Lista_Personal_DatosBancarios(inicio);
                setPaginaActual(PAGINAACTUAL);
            }

        });

        function setPaginaActual(nPagina) { //Pintar la pagina actual visitada
            $('#txtPaginaActual').val(nPagina);

        }
        });
    </script>
</asp:Content>

