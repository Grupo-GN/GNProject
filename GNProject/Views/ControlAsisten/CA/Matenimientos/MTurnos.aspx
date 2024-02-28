<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MTurnos.aspx.cs" Inherits="GNProject.Views.ControlAsisten.CA.Matenimientos.MTurnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"
        type="text/css" />

    <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />


     <input id="btnNew" class="buttonHer" type="button" value="Nuevo" />
    

    <fieldset>
    <%--modidga ,  cambiar height: 380px en el div--%>
           <div id="HeaderDiv" style="overflow: hidden; width: 100%; border: solid 1px #505050;height: 380px;">

     <table id="tblCarac" class="table">

        <thead><tr>
        <th>Edit</th>
        <th>Nombre</th>
        <th>Descripcion</th>
        <th>HoraIni</th>
        <th>HoraIniRefri</th>
        <th>HoraFinRefri</th>
        <th>HoraFin</th>
        </tr></thead>

       <tbody class="tbody" id="tbodyTurnos">

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




 <div id="dialog-form" >
 <table class="tableDialog">

<tr>
<td style="width:100px;">
<label class="miLabel">Codigo : </label>
</td>
<td>
<input id="txtCodigo" type="text" readonly="true" class="txtCodigo" value="???" />
</td>
</tr>

 <tr>
                 <td>
                  <label class="miLabel" >Nombre : </label></td>
                <td>
                    <input id="txtNombre" type="text" class="txt" style="width:180px;" />
                </td>
            </tr>

            <tr>
                 <td>
                  <label class="miLabel" >Descripcion : </label></td>
                <td>
                    <input id="txtDescripcion" type="text" class="txt" style="width:180px;" />
                </td>
            </tr>

            <tr>
                 <td>
                  <label class="miLabel" >HoraIni : </label></td>
                <td>
                    <input id="txtHoraIni" type="text" class="txt" style="width:60px;" maxlength="5" />
                </td>
            </tr>

            <tr>
                 <td>
                  <label class="miLabel" >HoraIniRefri : </label></td>
                <td>
                    <input id="txtHoraIniRefri" type="text" class="txt" style="width:60px;" maxlength="5" />
                </td>
            </tr>

            <tr>
                 <td>
                  <label class="miLabel" >HoraFinRefri : </label></td>
                <td>
                    <input id="txtHoraFinRefri" type="text" class="txt" style="width:60px;" maxlength="5" />
                </td>
            </tr>

            <tr>
                 <td>
                  <label class="miLabel" >HoraFin : </label></td>
                <td>
                    <input id="txtHoraFin" type="text" class="txt" style="width:60px;" maxlength="5" />
                </td>
            </tr>

            <tr>
    <td colspan="2">
    
       <table style="width: 100%">
          <tr>
            <td style="height:3px;" colspan="2">
             <label id="lblError" class="miLabelError" ></label>
            </td>
            </tr>
            <tr>
            <td colspan="2" style="width:100%;text-align:center;">
                <input id="btnGrabar" type="button" value="Grabar" class="submit" />
                <input id="btnCancelar" type="button" value="Salir" class="submit"/>
            </td>
            </tr>
  </table>
    
    </td>
    </tr>

 </table>

<label id="lblCodigSeleccionao"></label>

 </div>






<script src="../../jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../jqueryui/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="Scripts/Script_MantTurnos.js" type="text/javascript"></script>


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
                Get_Turnos_List(inicio)
                //modidga//quitar getBuscar(), Get_Turnos_MaxRegistro(getBuscar())
                Get_Turnos_MaxRegistro();
            });

            $('#txtnRegistros').val(Get_Turnos_MaxRegistro());

            function pasaModal() {
                //modidga//height: 360, width: 400,
                $("#dialog-form").dialog({
                    height: 360, width: 400, modal: true, autoOpen: true,
                    appendTo: "form", title: "MANTENIMIENTO DE TURNO",
                    show: { effect: "fade", duration: 800 },
                    hide: { effect: "fold", duration: 800 }
                });
            }

            Get_Turnos_List(0);
            //            Get_Turnos_MaxRegistro();
            $('#tbodyTurnos').on('click', '.buttonEdit', function () {
                mensajeError('&nbsp');
                TIPOPROCESO = '02';
                var codigo = this.id;
                codigo = codigo.substring(7);

                Get_Turnos_Find(codigo);
                Get_Turnos_List(inicio);
                pasaModal();
            });



            $('#btnNew').click(function () {
                TIPOPROCESO = '01';
                inicilizaObjetos();
                pasaModal();
                //$('#btnGrabar').attr('disabled', false);
            });

            $("#tblCarac").on("click", '.Editar', function () {

                mensajeError('&nbsp');
                var href = $(this).attr('href');
                var codigo = href.substring(1);
                Get_Turnos_Find(codigo);
                pasaModal();
                //$('#btnGrabar').attr('disabled', false);

            });

            //            $('#txtHoraIni').keyup(function () {

            //            });
            //            $('#txtHoraIniRefri').keyup(function () {
            //                mensajeError('&nbsp');
            //            });
            //            $('#txtHoraFinRefri').keyup(function () {
            //                mensajeError('&nbsp');
            //            });
            //            $('#txtHoraFin').keyup(function () {
            //                mensajeError('&nbsp');
            //            });

            //modidga//
            $('#btnGrabar').click(function () {
                var codigo = $('#txtCodigo').val();
                var nombre = $('#txtNombre').val();
                var descripcion = $('#txtDescripcion').val();
                var horaini = $('#txtHoraIni').val();
                var horainirefri = $('#txtHoraIniRefri').val();
                var horafinrefri = $('#txtHoraFinRefri').val();
                var horafin = $('#txtHoraFin').val();

                if (nombre == '' || nombre == null) {
                    mensajeError('ERROR... Debe digitar el nombre');
                    $('#txtNombre').focus();
                    return false;
                }
                if (descripcion == '' || descripcion == null) {
                    mensajeError('ERROR... Debe digitar la descripcion');
                    $('#descripcion').focus();
                    return false;
                }
                if (horaini == '' || horaini == null) {
                    mensajeError('ERROR... Debe digitar la hora de inicio');
                    $('#txtHoraIni').focus();
                    return false;
                }
                //
                horainiuno = horaini.substring(0, 2);
                horainidos = horaini.substring(2, 3);
                horainitres = horaini.substring(3, 5);
                if (horainiuno >= 0 && horainiuno <= 23 && horainidos == ':' && horainitres >= 0 && horainitres <= 59 && horaini.length == 5) {
                    mensajeError('&nbsp');
                }
                else {
                    mensajeError('ERROR... Formato hora de inicio Ejm. 08:30');
                    $('#txtHoraIni').focus();
                    return false;
                }
                //
                if (horainirefri == '' || horainirefri == null) {
                    mensajeError('ERROR... Debe digitar la hora de inicio de refrigerio');
                    $('#txtHoraIniRefri').focus();
                    return false;
                }
                
                horainirefriuno = horainirefri.substring(0, 2);
                horainirefridos = horainirefri.substring(2, 3);
                horainirefritres = horainirefri.substring(3, 5);
                if (horainirefriuno >= 0 && horainirefriuno <= 23 && horainirefridos == ':' && horainirefritres >= 0 && horainirefritres <= 59 && horainirefri.length == 5) {
                    mensajeError('&nbsp');
                }
                else {
                    mensajeError('ERROR... Formato hora de inicio de refrigerio Ejm. 08:30');
                    $('#txtHoraIniRefri').focus();
                    return false;
                }
                //
                if (horafinrefri == '' || horafinrefri == null) {
                    mensajeError('ERROR... Debe digitar la hora de fin de refrigerio');
                    $('#txtHoraFinRefri').focus();
                    return false;
                }
                //
                horafinrefriuno = horafinrefri.substring(0, 2);
                horafinrefridos = horafinrefri.substring(2, 3);
                horafinrefritres = horafinrefri.substring(3, 5);
                if (horafinrefriuno >= 0 && horafinrefriuno <= 23 && horafinrefridos == ':' && horafinrefritres >= 0 && horafinrefritres <= 59 && horafinrefri.length == 5) {
                    mensajeError('&nbsp');
                }
                else {
                    mensajeError('ERROR... Formato hora de fin de refrigerio Ejm. 08:30');
                    $('#txtHoraFinRefri').focus();
                    return false;
                }
                //
                if (horafin == '' || horafin == null) {
                    mensajeError('ERROR... Debe digitar la hora de fin');
                    $('#txtHoraFin').focus();
                    return false;
                }
                //
                horafinuno = horafin.substring(0, 2);
                horafindos = horafin.substring(2, 3);
                horafintres = horafin.substring(3, 5);
                if (horafinuno >= 0 && horafinuno <= 23 && horafindos == ':' && horafintres >= 0 && horafintres <= 59 && horafin.length == 5) {
                    mensajeError('&nbsp');
                }
                else {
                    mensajeError('ERROR... Formato hora de fin Ejm. 08:30');
                    $('#txtHoraFin').focus();
                    return false;
                }
                //

                mensajeError('&nbsp');
                
                if (TIPOPROCESO == "01") {

                    Get_Turnos_Add(nombre, descripcion, horaini, horainirefri, horafinrefri, horafin);

                } else if (TIPOPROCESO == "02") {

                    Get_Turnos_Update(codigo, nombre, descripcion, horaini, horainirefri, horafinrefri, horafin);

                }
                closeModalDiv();
                Get_Turnos_List(inicio);
                Get_Turnos_MaxRegistro();

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
                    Get_Turnos_List(inicio);
                    Get_Turnos_MaxRegistro();

                    setPaginaActual(PAGINAACTUAL);

                }
                ///////////modidga///////////////
                if (guardaPagina > inicio) {
                    inicio = (TotalPaginador * Math.floor(laPaginaActual));
                    PAGINAACTUAL = Math.ceil(laPaginaActual);
                    Get_Turnos_List(inicio);
                    Get_Turnos_MaxRegistro();
                    setPaginaActual(PAGINAACTUAL);
                }
                //////////////////////////////////////////////////// 
                else if (guardaPagina != TotalPaginador) {
                    PAGINAACTUAL = Math.ceil(laPaginaActual);
                    //var descripcion = $('#txtBuscar').val();
                    Get_Turnos_List(inicio);
                    Get_Turnos_MaxRegistro();
                    setPaginaActual(PAGINAACTUAL);
                } else {
                    inicio = 0;
                }

            });

            $('#btnPrimero').click(function () {  //metodos para actualizar
                inicio = 0;         //Primer Registro
                PAGINAACTUAL = 1;   //Primera Pagina
                //var descripcion = $('#txtBuscar').val();
                Get_Turnos_List(inicio);
                Get_Turnos_MaxRegistro();
                setPaginaActual(PAGINAACTUAL);
            });

            $('#btnAnterior').click(function () {  //metodos para actualizar
                if (inicio > 0) {
                    inicio = parseInt(inicio) - TotalPaginador;
                    PAGINAACTUAL = parseInt(PAGINAACTUAL) - 1;

                    //var descripcion = $('#txtBuscar').val();
                    Get_Turnos_List(inicio);
                    Get_Turnos_MaxRegistro();
                    setPaginaActual(PAGINAACTUAL);
                }

            });

            $('#btnSiguiente').click(function () {  //metodos para actualizar

                if (parseInt($('#txtnRegistros').val()) > (parseInt(inicio) + parseInt(TotalPaginador))) {
                    inicio = parseInt(inicio) + parseInt(TotalPaginador);
                    PAGINAACTUAL = parseInt(PAGINAACTUAL) + 1;

                    // var descripcion = $('#txtBuscar').val();
                    Get_Turnos_List(inicio);
                    Get_Turnos_MaxRegistro();
                    setPaginaActual(PAGINAACTUAL);
                }

            });

            function setPaginaActual(nPagina) { //Pintar la pagina actual visitada
                $('#txtPaginaActual').val(nPagina);
            }






            function inicilizaObjetos() {
                $('#txtCodigo').val('???');
                $('#txtNombre').val('');
                $('#txtDescripcion').val('');
                $('#txtHoraIni').val('');
                $('#txtHoraIniRefri').val('');
                $('#txtHoraFinRefri').val('');
                $('#txtHoraFin').val('');
            }



        });

    </script>

</asp:Content>
