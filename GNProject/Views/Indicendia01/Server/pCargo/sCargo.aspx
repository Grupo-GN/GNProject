<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="sCargo.aspx.cs" Inherits="GNProject.Views.Indicendia01.Server.pCargo.sCargo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />
    <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"
        type="text/css" />




<input type="button" value="NUEVO" class="buttonHer" id="btnNew" />

<fieldset>
    <legend>BUSQUEDA</legend>
    <label>Descripcion : </label><input type="text" class="txt" id="txtFindDescip" style="width:300px;"/>
    <label> Estado : </label><select id="cboEstadoFind" class="cbo"><option value="01">ACTIVO</option><option value="02">INACTIVO</option></select>
</fieldset>

<div  style="overflow: hidden; width: 100%; border: solid 1px #505050;height: 340px;">
<table class="table">
<thead>
        <tr>
            <th></th>            
            <th></th>  
            <th>CARGO</th>
            <th>ESTADO</th>
        </tr>
</thead>

<tbody id="tbodyCargo">

</tbody>
</table>
</div>
 <div style="overflow: hidden; width: 100%; border: solid 1px #505050;">
    <table class="table">
         <tfoot>
        <tr>
        <td  colspan="3">

            <label style="font-family: 'AENOR Fontana ND'; font-weight: bold; font-size: 1.1em;" >TOTAL REGISTROS: </label> &nbsp
            <input id="txtnRegistros" type="text" value="0" class="TextPage" readonly="true" /> &nbsp &nbsp
            <label style="font-family: 'AENOR Fontana ND'; font-weight: bold; font-size: 1.1em;" >PAGE: </label> &nbsp
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

    <div id="dialog-Cargo" title="MANTENIMIENTO CARGO">
    <table class="tableDialog">
        <tr>
            <td style="text-align:right;font-weight:bold;width:60px;">Codigo :</td>
            <td><input style="width:100px;" type="text" class="txtCodigo" value="???" id="txtcodigo" readonly /></td>
        </tr>
        <tr>
            <td style="text-align:right;font-weight:bold;">Cargo :</td>
            <td><input type="text" id="txtCargo" class="txt" style="width:100%;" /></td>
        </tr>
        <tr>
            <td style="text-align:right;font-weight:bold;">Estado :</td>
            <td><select id="cboEstado" class="cbo"><option value="01">ACTIVO</option><option value="02">INACTIVO</option></select></td>
        </tr>
        <tr>
            <td colspan="2"><label id="lblError" class="labelError"></label></td>
        </tr>
        <tr>
            <td colspan="2"><input type="button" id="btnGrabar" class="submit" value="GRABAR" />&nbsp; <input type="button" id="btnCalcelar" class="submit" value="CANCELAR" /></td>
        
        </tr>
    </table>
    
    </div>
    <br /><br /><br /><br /><br />
    <script src="../../jquery1.10/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../jqueryui/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="Script_Cargo.js" type="text/javascript"></script>
<script type="text/javascript">
    var TotalPaginador = 12;
    var TOTALREGISTROS;
    var inicio = 0;
    var PAGINAACTUAL = 1;
    var TIPOPROCESO = '';
    var Cargo_Proc = '';

    $(document).ready(function () {
            
        $('#dialog-Cargo').hide();
        Get_Cargo_List(Get_Descripcion_Find(), Get_Estado_Find(), inicio);
        Get_Cargo_List_MaxRows(Get_Descripcion_Find(), Get_Estado_Find());




        $('#txtFindDescip').keyup(function () {
            inicio = 0;
            Get_Cargo_List(Get_Descripcion_Find(), Get_Estado_Find(), inicio);
            Get_Cargo_List_MaxRows(Get_Descripcion_Find(), Get_Estado_Find());
        });

        $('#cboEstadoFind').change(function () {
            inicio = 0;
            Get_Cargo_List(Get_Descripcion_Find(), Get_Estado_Find(), inicio);
            Get_Cargo_List_MaxRows(Get_Descripcion_Find(), Get_Estado_Find());
        });

        $('#btnNew').click(function () {
            $('#lblError').html('&nbsp;');
            clear_Modal();
            open_Modal();
            TIPOPROCESO = '01';
            Cargo_Proc = '';
        });

        $('#tbodyCargo').on('click', '.buttonEdit', function () {
            $('#lblError').html('&nbsp;');
            clear_Modal();
            var codigo = this.id.substring(1);

            Get_Find_Cargo(codigo);

        });

        $('#tbodyCargo').on('click', '.buttonDesactiva', function () {
            if (confirm('¿Esta seguro de desactivar el cargo?')) {
            var codigo = this.id.substring(1);
                Get_Delete_Estado_Cargo(codigo,'02')
            }
        });

        $('#tbodyCargo').on('click', '.buttonActiva', function () {
            if (confirm('¿Esta seguro de activar el cargo?')) {
                var codigo = this.id.substring(1);
                Get_Delete_Estado_Cargo(codigo, '01')
            }
        });

        $('#btnGrabar').click(function () {
            $('#lblError').html('&nbsp;');
            if (!TIPOPROCESO) {
                alert('.::Error, Proceso no identificado.');
                return false;
            }
            var descripcion = $('#txtCargo').val();
            var estado = $('#cboEstado').val();
            if (!descripcion) {
                $('#lblError').html('.::Error, Descripcion no definida.');
                $('#txtCargo').focus();
                return false;
            }
            if (!descripcion) {
                $('#lblError').html('.::Error, Descripcion no definida.');
                $('#txtCargo').focus();
                return false;
            }
            if (TIPOPROCESO == '01') {
                Get_Add_Cargo(descripcion.toUpperCase(), estado);
            } else if (TIPOPROCESO == '02') {
                if (!Cargo_Proc) {
                    $('#lblError').html('.::Error,Seleccione un cargo.');
                    return false;
                }

            }
        });


        $('#btnCalcelar').click(function () {
            $('#dialog-Cargo').dialog('close');
            TIPOPROCESO = '';
            Cargo_Proc = '';
        });

        //NAVEGACION

        $('#btnUltimo').click(function () {  //metodos para actualizar

            var guardaPagina = parseInt($('#txtnRegistros').val());
            var laPaginaActual = guardaPagina / TotalPaginador;

            if (guardaPagina != 0) {
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

                    Get_Cargo_List(Get_Descripcion_Find(), Get_Estado_Find(), inicio);
                    Get_Cargo_List_MaxRows(Get_Descripcion_Find(), Get_Estado_Find());

                    setPaginaActual(PAGINAACTUAL);
                } else if (guardaPagina != TotalPaginador) {
                    PAGINAACTUAL = Math.ceil(laPaginaActual);

                    Get_Cargo_List(Get_Descripcion_Find(), Get_Estado_Find(), inicio);
                    Get_Cargo_List_MaxRows(Get_Descripcion_Find(), Get_Estado_Find());

                    setPaginaActual(PAGINAACTUAL);
                } else {
                    inicio = 0;
                }
            }
        });

        $('#btnPrimero').click(function () {  //metodos para actualizar
            inicio = 0;         //Primer Registro
            PAGINAACTUAL = 1;   //Primera Pagina

            Get_Cargo_List(Get_Descripcion_Find(), Get_Estado_Find(), inicio);
            Get_Cargo_List_MaxRows(Get_Descripcion_Find(), Get_Estado_Find());

            setPaginaActual(PAGINAACTUAL);
        });

        $('#btnAnterior').click(function () {  //metodos para actualizar
            if (inicio > 0) {
                inicio = parseInt(inicio) - TotalPaginador;
                if (inicio < 0) {
                    inicio = 0;
                }
                PAGINAACTUAL = parseInt(PAGINAACTUAL) - 1;

                Get_Cargo_List(Get_Descripcion_Find(), Get_Estado_Find(), inicio);
                Get_Cargo_List_MaxRows(Get_Descripcion_Find(), Get_Estado_Find());

                setPaginaActual(PAGINAACTUAL);
            }

        });
        $('#btnSiguiente').click(function () {  //metodos para actualizar

            if (parseInt($('#txtnRegistros').val()) > (parseInt(inicio) + parseInt(TotalPaginador))) {
                inicio = parseInt(inicio) + parseInt(TotalPaginador);
                PAGINAACTUAL = parseInt(PAGINAACTUAL) + 1;

                Get_Cargo_List(Get_Descripcion_Find(), Get_Estado_Find(), inicio);
                Get_Cargo_List_MaxRows(Get_Descripcion_Find(), Get_Estado_Find());

                setPaginaActual(PAGINAACTUAL);
            }

        });

        function setPaginaActual(nPagina) { //Pintar la pagina actual visitada
            $('#txtPaginaActual').val(nPagina);
        }
    });
</script>

</asp:Content>
