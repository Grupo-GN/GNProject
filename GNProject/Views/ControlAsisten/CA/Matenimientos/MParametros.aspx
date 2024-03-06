<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MParametros.aspx.cs" Inherits="GNProject.Views.ControlAsisten.CA.Matenimientos.MParametros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"
          type="text/css" />

    <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/EstiloBarraHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleWilder.css" rel="stylesheet" type="text/css" />


    <input id="btnNew" class="buttonHer" type="button"  onclick="return btnNew_onclick()" value="Nuevo" />


    <fieldset>
           <div id="HeaderDiv" style="overflow: hidden; width: 100%; border: solid 1px #505050;height: 360px;">

     <table id="tblParametros" class="table">

        <thead class="theadth"><tr>
        <th  class="theadth"scope="col">Edit</th>
        <th  class="theadth"scope="col">Descripcion</th>
        <th class="theadth" scope="col">Variable</th>
        <th class="theadth" scope="col">Valor</th>
        <th class="theadth" scope="col">Tipo</th>
        <th class="theadth" scope="col">Abrev</th>
        <th class="theadth" scope="col">Estado</th>
        </tr></thead>

       <tbody class="tbody" id="tbodyParametros">

       </tbody>

    </table>
    </div>

 <div style="overflow: hidden; width: 100%; border: solid 1px #505050;">
    <table class="table">
         <tfoot>
        <tr>
        <td class="tfoottd"  colspan="3">

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
  
    </fieldset>




     <div id="dialog-form"
 style="font-size:x-small; font-family:AENOR Fontana ND;">
 <table class="borde">
 <tr>
 <td align="center" class="titulo" colspan="2">
          <label class="tituloModal" >Mantenimiento de Parametros</label>
</td>
</tr>

<tr>
<td class="style23">
&nbsp
</td>
</tr>

<tr>
<td class="style23">
<label class="miLabel" style="width:50%;">Codigo : </label>
</td>
<td style="text-align:left; width:50%;" >
<input id="txtCodigo" type="text" readonly="true"
class="estiloCajaCodigo" value="???" />
</td>
</tr>



            <tr>
                 <td class="style23">
                  <label class="miLabel" style="width:50%;">Descripcion : </label></td>
                <td style="text-align:left; width:50%;">
                    <textarea id="txtDescripcion" rows="4" cols="40" >
Ingrese su descripcion aqui...
</textarea>
                </td>
            </tr>

            <tr>
                 <td class="style23">
                  <label class="miLabel" style="width:50%;">Variable : </label></td>
                <td style="text-align:left; width:50%;">
                    <input id="txtVariable" type="text" class="txt" 
                        style="width:180px;" />
                </td>
            </tr>

            <tr>
                 <td class="style23">
                  <label class="miLabel" style="width:50%;">Valor : </label></td>
                <td style="text-align:left; width:50%;">
                    <input id="txtValor" type="text" class="txt" 
                        style="width:180px;" />
                </td>
            </tr>

            <tr>
                 <td class="style23">
                  <label class="miLabel" style="width:50%;">Tipo : </label></td>
                <td style="text-align:left; width:50%;">
                    <input id="txtTipo" type="text" class="txt" 
                        style="width:180px;" />
                </td>
            </tr>
       <tr>
                 <td class="style23">
                  <label class="miLabel" style="width:50%;">Abreviatura : </label></td>
                <td style="text-align:left; width:50%;">
                    <input id="txtabrev" type="text" class="txt" 
                        style="width:180px;" />
                </td>
            </tr>
        <tr>
                 <td class="style23">
                  <label class="miLabel" style="width:50%;">Estado : </label></td>
                <td style="text-align:left; width:50%;">
                   <select id="cboestado"  class="cbo" style="width:185px;">
                         <option value='00'>INACTIVO</option>
                         <option value='01' selected='selected'>ACTIVO</option>
                       </select>
                </td>
            </tr>

    <td colspan="2">
    
       <table style="width: 100%">
          <tr>
            <td style="height:3px;" colspan="2">
             <label id="lblError" class="miLabelError" ></label>
            </td>
            </tr>
            <tr>
            <td colspan="2" align="right" style="width:100%;">
                <input id="btnGrabar" type="button" value="Grabar" class="submit" />
                <input id="btnCancelar" type="button" value="Salir" class="submit"/>
            </td>
            </tr>
  </table>
    
    </td>

 </table>

<label id="lblCodigSeleccionao"></label>

 </div>


 <script src="../../jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../jqueryui/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="Scripts/Script_MantParametros.js" type="text/javascript"></script>


    <script type="text/javascript">
        var TIPOPROCESO;

        $(document).ready(function () {
            var inicio = 0;
            var TotalPaginador = 12;
            var TOTALREGISTROS;
            var PAGINAACTUAL = 1;


            $('#dialog-form').css('display', 'none');

            function mensajeError(msg) {
                $('#lblError').html(msg);
            }

            function closeModalDiv() {
                $('#dialog-form').dialog('close');
            }

            $('#btnCancelar').click(function () {
                closeModalDiv();
                Get_Parametros_List(inicio)
                Get_Parametros_MaxRegistro(getBuscar());
            });

            function pasaModal() {

                $("#dialog-form").dialog({
                    height: 340, width: 460, modal: true, autoOpen: true,
                    appendTo: "form", title: "MANTENIMIENTO DE PARAMETROS",
                    show: { effect: "fade", duration: 800 },
                    hide: { effect: "fold", duration: 800 }
                });
            }

            Get_Parametros_List(0);
            //            Get_Parametros_MaxRegistro();
            $('#tbodyParametros').on('click', '.ElLinkEditar', function () {
                TIPOPROCESO = '02';
                var codigo = this.id;
                codigo = codigo.substring(7);

                Get_Parametros_Find(codigo);
                Get_Parametros_List(inicio);
                pasaModal();
            });

            $('#txtnRegistros').val(Get_Parametros_MaxRegistro());

            $('#btnNew').click(function () {
                TIPOPROCESO = '01';
                inicilizaObjetos();
                pasaModal();
                // $('#btnGrabar').attr('disabled', false);
            });

            $("#tblParametros").on("click", '.Editar', function () {

                var href = $(this).attr('href');
                var codigo = href.substring(1);
                Get_Parametros_Find(codigo);
                pasaModal();
                //  $('#btnGrabar').attr('disabled', true);

            });

            $('#btnGrabar').click(function () {
                var codigo = $('#txtCodigo').val();
                var descripcion = $('#txtDescripcion').val();
                var variable = $('#txtVariable').val();
                var valor = $('#txtValor').val();
                var tipo = $('#txtTipo').val();
                var abrev = $('#txtabrev').val();
                var estado = $('#cboestado').val();

                if (descripcion == '' || descripcion == null) {
                    mensajeError('ERROR... Debe digitar la descripcion');
                    $('#txtDescripcion').focus();
                    return false
                }
                if (variable == '' || variable == null) {
                    mensajeError('ERROR... Debe digitar la variable');
                    $('#txtVariable').focus();
                    return false
                }
                if (valor == '' || valor == null) {
                    mensajeError('ERROR... Debe digitar el valor');
                    $('#txtValor').focus();
                    return false
                }
                function isNumeric(value) {
                    return typeof value === 'number' || /^\+|-?[0-9]+([,\.][0-9]*)?$/.test(value);
                }
                //
                if (isNumeric(valor)==false) {
                    mensajeError('ERROR... El valor debe ser numerico');
                    $('#txtValor').focus();
                    return false
                }
                //
                if (tipo == '' || tipo == null) {
                    mensajeError('ERROR... Debe digitar el tipo');
                    $('#txtTipo').focus();
                    return false
                }


                mensajeError('&nbsp');
                if (TIPOPROCESO == "01") {

                    Get_Parametros_Add(descripcion, variable, valor, tipo,abrev,estado);
                    //$('#btnGrabar').attr('disabled', true);
                } else if (TIPOPROCESO == "02") {

                    Get_Parametros_Update(codigo, descripcion, variable, valor, tipo,abrev,estado);
                }
                closeModalDiv();
                Get_Parametros_List(inicio);
                Get_Parametros_MaxRegistro();


            });



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
                    // var descripcion = $('#txtBuscar').val();
                    Get_Parametros_List(inicio);
                    Get_Parametros_MaxRegistro();

                    setPaginaActual(PAGINAACTUAL);

                } else if (guardaPagina != TotalPaginador) {
                    PAGINAACTUAL = Math.ceil(laPaginaActual);
                    //var descripcion = $('#txtBuscar').val();
                    Get_Parametros_List(inicio);
                    Get_Parametros_MaxRegistro();
                    setPaginaActual(PAGINAACTUAL);
                } else {
                    inicio = 0;
                }

            });

            $('#btnPrimero').click(function () {  //metodos para actualizar
                inicio = 0;         //Primer Registro
                PAGINAACTUAL = 1;   //Primera Pagina
                //var descripcion = $('#txtBuscar').val();
                Get_Parametros_List(inicio);
                Get_Parametros_MaxRegistro();
                setPaginaActual(PAGINAACTUAL);
            });

            $('#btnAnterior').click(function () {  //metodos para actualizar
                if (inicio > 0) {
                    inicio = parseInt(inicio) - TotalPaginador;
                    PAGINAACTUAL = parseInt(PAGINAACTUAL) - 1;

                    //var descripcion = $('#txtBuscar').val();
                    Get_Parametros_List(inicio);
                    Get_Parametros_MaxRegistro();
                    setPaginaActual(PAGINAACTUAL);
                }

            });

            $('#btnSiguiente').click(function () {  //metodos para actualizar

                if (parseInt($('#txtnRegistros').val()) > (parseInt(inicio) + parseInt(TotalPaginador))) {
                    inicio = parseInt(inicio) + parseInt(TotalPaginador);
                    PAGINAACTUAL = parseInt(PAGINAACTUAL) + 1;

                    // var descripcion = $('#txtBuscar').val();
                    Get_Parametros_List(inicio);
                    Get_Parametros_MaxRegistro();
                    setPaginaActual(PAGINAACTUAL);
                }

            });

            function setPaginaActual(nPagina) { //Pintar la pagina actual visitada
                $('#txtPaginaActual').val(nPagina);
            }

            function inicilizaObjetos() {
                $('#txtCodigo').val('???');
                $('#txtDescripcion').val('');
                $('#txtVariable').val('');
                $('#txtValor').val('');
                $('#txtTipo').val('');
                $('#cboestado').val('01');
                $('#txtabrev').val('');

            }



        });

    </script>

</asp:Content>
