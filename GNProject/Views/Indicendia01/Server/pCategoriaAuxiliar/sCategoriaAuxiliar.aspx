<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="sCategoriaAuxiliar.aspx.cs" Inherits="GNProject.Views.Indicendia01.Server.pCategoriaAuxiliar.sCategoriaAuxiliar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />
    <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"
        type="text/css" />




<input type="button" value="NUEVO" class="buttonHer" id="btnNewCategoria" />

<fieldset>
    <legend>BUSQUEDA</legend>
    <label>Descripcion : </label><input type="text" class="txt" id="txtFindDescip" style="width:300px;"/>
</fieldset>

<div  style="overflow: hidden; width: 100%; border: solid 1px #505050;height: 340px;">
<table class="table">
<thead>
        <tr>
            <th></th>
            
            <th>DESCRIPCION</th>
        </tr>
</thead>

<tbody id="tbodyCategoriaA">
    <tr>
        <td></td>        
        <td>CALLAO</td>

    </tr>
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

    <div id="dialog-Categoria" title="MATENIMIENTO CATEGORIA AUXILIAR">
    <table class="tableDialog">
        <tr>
            <td style="text-align:right;font-weight:bold;">Codigo :</td>
            <td><input style="width:100%;" type="text" class="txtCodigo" value="??" id="txtcodigo" readonly /></td>
        </tr>
        <tr>
            <td style="text-align:right;font-weight:bold;vertical-align:text-top;">Descripcion :</td>
            <td><textarea rows="2" cols="30" id="txtDescripcion" ></textarea></td>
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
    <script src="Script_CategoriaAuxiliar.js" type="text/javascript"></script>

    <script type="text/javascript">
        var TotalPaginador = 12;
        var TOTALREGISTROS;
        var inicio = 0;
        var PAGINAACTUAL = 1;
        var TIPOPROCESO = '';
        var Categoria_Proc = '';
        $(document).ready(function () {
            $('#dialog-Categoria').hide();
            Get_CategoriaAuxliar_List(get_FindDescrip(), inicio);
            Get_CategoriaAuxliar_List_MaxRows(get_FindDescrip());

            $('#btnNewCategoria').click(function () {
                clearModal();
                open_Modal();
                TIPOPROCESO = '01';
            });

            $('#btnGrabar').click(function () {
                if (!TIPOPROCESO) {
                    alert('.::Error , Proceso no definido.')
                    return false;
                }
                var descripcion = $('#txtDescripcion').val();
                if (TIPOPROCESO == '01') {
                    if (!descripcion) {
                        $('#lblError').html('.::Error, descripcion no definida.');
                        $('#txtDescripcion').focus();
                        return false;
                    }
                    Get_Add_CategoriaAuxliar(descripcion.toUpperCase());
                } else if (TIPOPROCESO == '02') {
                   
                    if (!Categoria_Proc) {
                        alert('.::Error , Seleccione una categoria.')
                        return false;
                    }
                    if (!descripcion) {
                        $('#lblError').html('.::Error, descripcion no definida.');
                        $('#txtDescripcion').focus();
                        return false;
                    }
                    Get_Update_CategoriaAuxliar(Categoria_Proc, descripcion.toUpperCase());
                }
                Get_CategoriaAuxliar_List(get_FindDescrip(), inicio);
                Get_CategoriaAuxliar_List_MaxRows(get_FindDescrip());
            });


            $('#txtFindDescip').keyup(function () {
                inicio = 0;
                Get_CategoriaAuxliar_List(get_FindDescrip(), inicio);
                Get_CategoriaAuxliar_List_MaxRows(get_FindDescrip());
            });

            $('#tbodyCategoriaA').on('click', '.buttonEdit', function () {
                var codigo = this.id;
                Get_CategoriaAuxliar_Find(codigo);
            });

            $('#btnCalcelar').click(function () {
                $('#dialog-Categoria').dialog('close');
                TIPOPROCESO = '';
                Categoria_Proc = '';
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

                    Get_CategoriaAuxliar_List(get_FindDescrip(), inicio);
                    Get_CategoriaAuxliar_List_MaxRows(get_FindDescrip());

                    setPaginaActual(PAGINAACTUAL);
                } else if (guardaPagina != TotalPaginador) {
                    PAGINAACTUAL = Math.ceil(laPaginaActual);

                    Get_CategoriaAuxliar_List(get_FindDescrip(), inicio);
                    Get_CategoriaAuxliar_List_MaxRows(get_FindDescrip());

                    setPaginaActual(PAGINAACTUAL);
                } else {
                    inicio = 0;
                }

            });

            $('#btnPrimero').click(function () {  //metodos para actualizar
                inicio = 0;         //Primer Registro
                PAGINAACTUAL = 1;   //Primera Pagina
                Get_CategoriaAuxliar_List(get_FindDescrip(), inicio);
                Get_CategoriaAuxliar_List_MaxRows(get_FindDescrip());
                setPaginaActual(PAGINAACTUAL);
            });

            $('#btnAnterior').click(function () {  //metodos para actualizar
                if (inicio > 0) {
                    inicio = parseInt(inicio) - TotalPaginador;
                    PAGINAACTUAL = parseInt(PAGINAACTUAL) - 1;
                    Get_CategoriaAuxliar_List(get_FindDescrip(), inicio);
                    Get_CategoriaAuxliar_List_MaxRows(get_FindDescrip());
                    setPaginaActual(PAGINAACTUAL);
                }

            });
            $('#btnSiguiente').click(function () {  //metodos para actualizar

                if (parseInt($('#txtnRegistros').val()) > (parseInt(inicio) + parseInt(TotalPaginador))) {
                    inicio = parseInt(inicio) + parseInt(TotalPaginador);
                    PAGINAACTUAL = parseInt(PAGINAACTUAL) + 1;
                    Get_CategoriaAuxliar_List(get_FindDescrip(), inicio);
                    Get_CategoriaAuxliar_List_MaxRows(get_FindDescrip());
                    setPaginaActual(PAGINAACTUAL);
                }

            });

            function setPaginaActual(nPagina) { //Pintar la pagina actual visitada
                $('#txtPaginaActual').val(nPagina);
            }

        });
    </script>
</asp:Content>
