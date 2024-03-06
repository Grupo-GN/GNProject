<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MHorarios.aspx.cs" Inherits="GNProject.Views.ControlAsisten.CA.Matenimientos.MHorarios" %>
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
        <th></th>
        <th></th>
        <th scope="col">HORARIO</th>
        <th scope="col">F Creacion</th>
        <th scope="col">F Modificacion</th>
        </tr></thead>

       <tbody class="tbody" id="tbodyHorarios">

       </tbody>

    </table>
    </div>

 <div style="overflow: hidden; width: 100%; border: solid 1px #505050;">
    <table class="table">
         <tfoot>
        <tr>
        <td class="tfoottd"  colspan="3">

            <label style="font-family: 'AENOR Fontana ND'; font-weight: bold; font-size: 1.1em;" >TOTAL REGISTROS: </label> &nbsp
            <input id="txtnRegistros" type="text" value="0" class="TextPage" readonly="readonly" /> &nbsp &nbsp
            <label style="font-family: 'AENOR Fontana ND'; font-weight: bold; font-size: 1.1em;" >PAGE: </label> &nbsp
            <input id="txtPaginaActual" type="text" value="1" class="TextPage" readonly="readonly" />
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


     <div id="dialog-form" title="Mantenimiento de Horario"
 style="font-size:x-small; font-family:AENOR Fontana ND;">
 <table class="tableDialog">
<tr>
<td class="style23">
&nbsp
</td>
</tr>

<tr>
<td  style="width:70px;">
<label class="miLabel" >Codigo : </label>
</td>
<td>
    <input id="txtCodigo" type="text" readonly="true" class="txtCodigo" value="???" />
</td>
</tr>

 <tr>
                 <td>
                  <label class="miLabel">Nombre : </label></td>
                <td>
                    <input id="txtNombre" type="text" class="txt" style="width:100%;" />
                </td>
            </tr>

            <tr>
    <td colspan="2">
    
       <table style="width: 100%">
          <tr>
            <td style="height:3px;" colspan="2">
             <label id="lblError" class="miLabelError" > </label>
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




 <div id="dialog-form2" style="font-size:x-small; font-family:AENOR Fontana ND;" title="Detalle de Horarios">
 <fieldset >
    <label class="miLabel">Horario_Id: </label>
   <input id="txtHoraId" type="text" class="estiloCajaCodigo" readonly="readonly"/>
 </fieldset>
<label id="Label1" class="miLabelError"> </label>
 <br />    
<table class="table" id="tblDHorarios" >
<thead>
    <tr>
        <th>dia</th>
        <th>H. Inicio</th>
        <th>H. Ini Refrig.</th>
        <th>H. Fin Refrig.</th>
        <th>H. Fin</th>
    </tr>
</thead>
 <tbody id="tbodyHDetalle">

 </tbody>
 </table>
<input type="button" value="Modificar" id="btnModificar" class="submit"/> <input type="button" value="Cancelar" id="btnCancelar2" class="submit"/>

   
<label id="Label2"></label>

 </div>
 
 

    <script src="../../jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../jqueryui/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="Scripts/Script_MantHorarios.js" type="text/javascript"></script>
   
   
    <script type="text/javascript">


        $(document).ready(function () {
            var inicio = 0;
            var TotalPaginador = 12;
            var TOTALREGISTROS;
            var PAGINAACTUAL = 1;


            var TIPOPROCESO;

            $('#dialog-form').css('display', 'none');
            $('#dialog-form2').css('display', 'none');

            function mensajeError(msg) {
                $('#lblError').html(msg);
            }
            function mensajeError2(msg) {
                $('#Label1').html(msg);
            }
            function mensajeError3(msg) {
                $('#Label2').html(msg);
            }
            function closeModalDiv() {
                $('#dialog-form').dialog('close');
            }
            function closeModalDiv2() {//2
                $('#dialog-form2').dialog('close');
            }


            $('#btnCancelar').click(function () {
                closeModalDiv();
                Get_Horarios_List(inicio)
                Get_Horarios_MaxRegistro();
            });

            $('#btnCancelar2').click(function () {//2
                closeModalDiv2();

            });

            function gethorario() {
                return $('#txtHoraId').val();
            }



            function pasaModal() {

                $("#dialog-form").dialog({
                    height: 250, width: 380, modal: true, autoOpen: true,
                    appendTo: "form", title: "MANTENIMIENTO DE HORARIO",
                    show: { effect: "fade", duration: 800 },
                    hide: { effect: "fold", duration: 800 }
                });
            }
            //          modidga   modificar height: de 400 
            function pasaModal2() {//

                $("#dialog-form2").dialog({
                    height: 400, width: 860, modal: true, autoOpen: true,
                    appendTo: "form", title: "Detalle de Horarios",
                    show: { effect: "fade", duration: 800 },
                    hide: { effect: "fold", duration: 800 }
                });
            }


            Get_Horarios_List(0);
            //            Get_Turnos_MaxRegistro();
            $('#tbodyHorarios').on('click', '.buttonEdit', function () {
                TIPOPROCESO = '02';
                var codigo = this.id;
                codigo = codigo.substring(7);

                Get_Horarios_Find(codigo);
                Get_Horarios_List(inicio);
                pasaModal();
            });

            $('#tbodyHorarios').on('click', '.buttonDetalle', function () {//2
                var horario = this.id.substring(9);
                Get_DetalleHorarios_List(horario);

                $('#txtHoraId').val(horario);
                pasaModal2();

            });


            $('#txtnRegistros').val(Get_Horarios_MaxRegistro());

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
                Get_Horarios_Find(codigo);
                pasaModal();
                //$('#btnGrabar').attr('disabled', false);

            });

            /*$("#tblCarac").on("click", '.Seleccionar', function () {//2

            mensajeError('&nbsp');
            var href = $(this).attr('href');
            var codigo = href.substring(1);
            Get_DetalleHorarios_List(codigo);
            pasaModal();
            $('#btnGrabar2').attr('disabled', false);

            });*/


            $('#btnGrabar').click(function () {
                var codigo = $('#txtCodigo').val();
                var nombre = $('#txtNombre').val();



                if (nombre == '' || nombre == null) {
                    mensajeError('ERROR... Debe digitar el nombre');
                    $('#txtNombre').focus();
                    return false
                }


                mensajeError('&nbsp');

                if (TIPOPROCESO == "01") {

                    Get_Horarios_Add(nombre);

                    //$('#btnGrabar').attr('disabled', true);
                } else if (TIPOPROCESO == "02") {

                    Get_Horarios_Update(codigo, nombre);

                }
                closeModalDiv();
                Get_Horarios_List(inicio);
                Get_Horarios_MaxRegistro();


            });

            $('#btnModificar').click(function () {//grabar

                var Horario_Id = parseInt($('#txtHoraId').val());

                mensajeError('&nbsp');
                $('#tbodyHDetalle tr').each(function (index) {
                    var Dia, hi, hir, hfr, hf;

                    if (index >= 0) {
                        $(this).children("td").each(function (index2) {
                            switch (index2) {

                                case 0:
                                    if ($(this).find('label').attr('id') == "Lunes") { Dia = "1" }
                                    if ($(this).find('label').attr('id') == "Martes") { Dia = "2" }
                                    if ($(this).find('label').attr('id') == "Miercoles") { Dia = "3" }
                                    if ($(this).find('label').attr('id') == "Jueves") { Dia = "4" }
                                    if ($(this).find('label').attr('id') == "Viernes") { Dia = "5" }
                                    if ($(this).find('label').attr('id') == "Sabado") { Dia = "6" }
                                    if ($(this).find('label').attr('id') == "Domingo") { Dia = "7" }; break;
                                case 1: hi = $(this).find('input[type=text]').val(); break;
                                case 2: hir = $(this).find('input[type=text]').val(); break;
                                case 3: hfr = $(this).find('input[type=text]').val(); break;
                                case 4: hf = $(this).find('input[type=text]').val(); break;
                            }

                        });

                        Get_Horarios_Deta_Update(Horario_Id, Dia, hi, hir, hfr, hf);

                    }

                });
                alert('Detalle grabado correctamente.');
                closeModalDiv2();
            });
            

            //modidga//
            //$('#tbodyHDetalle').on("keyup", ".txt", function () {
            $('#tbodyHDetalle').on("blur", ".txt", function () {
                mensajeError3('', null);
                var hora = "00:00";
                maxd = 2;
                maxi = 2;
                var fieldValue = $(this).val();
                if (fieldValue == 0 || fieldValue == "") {
                    // $(this).val(hora);
                    Get_DetalleHorarios_List(gethorario());
                }
                text = fieldValue.substring(fieldValue.indexOf(':') + 1, fieldValue.length);
                text2 = fieldValue.substring(fieldValue.indexOf(':') - 3, fieldValue.length - 3);
                a = parseInt(fieldValue.substring(0, 2));
                b = parseInt(fieldValue.substring(3, 5));
                if (text.length > maxd || text.length < maxd || a < 0 || a > 23) {
                    Get_DetalleHorarios_List(gethorario());
                }
                
                if (text2.length > maxi || text2.length < maxi || b < 0 || b > 59) {
                    Get_DetalleHorarios_List(gethorario());
                }
               
                if (isNaN(fieldValue)) {
                    var abc = "ABCDEFGHIJKMNÑLOPQRSTUVWXYZ.,_-||°'¿?¡][{+};/*()&%$#!=¡¨´";
                    for (i = 0; i < abc.length; i++) {
                        if (fieldValue.substring(i, i + 1) == abc)
                        { Get_DetalleHorarios_List(gethorario()); }
                    }
                }
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
                    Get_Horarios_List(inicio);
                    Get_Horarios_MaxRegistro();

                    setPaginaActual(PAGINAACTUAL);

                }
                ///////////modidga///////////////
                if (guardaPagina > inicio) {
                    inicio = (TotalPaginador * Math.floor(laPaginaActual));
                    PAGINAACTUAL = Math.ceil(laPaginaActual);
                    Get_Horarios_List(inicio);
                    Get_Horarios_MaxRegistro();
                    setPaginaActual(PAGINAACTUAL);
                }
                ////////////////////////////////////////////////////

                else if (guardaPagina != TotalPaginador) {
                    PAGINAACTUAL = Math.ceil(laPaginaActual);
                    //var descripcion = $('#txtBuscar').val();
                    Get_Horarios_List(inicio);
                    Get_Horarios_MaxRegistro();
                    setPaginaActual(PAGINAACTUAL);
                } else {
                    inicio = 0;
                }

            });

            $('#btnPrimero').click(function () {  //metodos para actualizar
                inicio = 0;         //Primer Registro
                PAGINAACTUAL = 1;   //Primera Pagina
                //var descripcion = $('#txtBuscar').val();
                Get_Horarios_List(inicio);
                Get_Horarios_MaxRegistro();
                setPaginaActual(PAGINAACTUAL);
            });

            $('#btnAnterior').click(function () {  //metodos para actualizar
                if (inicio > 0) {
                    inicio = parseInt(inicio) - TotalPaginador;
                    PAGINAACTUAL = parseInt(PAGINAACTUAL) - 1;

                    //var descripcion = $('#txtBuscar').val();
                    Get_Horarios_List(inicio);
                    Get_Horarios_MaxRegistro();
                    setPaginaActual(PAGINAACTUAL);
                }

            });

            $('#btnSiguiente').click(function () {  //metodos para actualizar

                if (parseInt($('#txtnRegistros').val()) > (parseInt(inicio) + parseInt(TotalPaginador))) {
                    inicio = parseInt(inicio) + parseInt(TotalPaginador);
                    PAGINAACTUAL = parseInt(PAGINAACTUAL) + 1;

                    // var descripcion = $('#txtBuscar').val();
                    Get_Horarios_List(inicio);
                    Get_Horarios_MaxRegistro();
                    setPaginaActual(PAGINAACTUAL);
                }

            });

            function setPaginaActual(nPagina) { //Pintar la pagina actual visitada
                $('#txtPaginaActual').val(nPagina);
            }


            function inicilizaObjetos() {
                $('#txtCodigo').val('???');
                $('#txtNombre').val('');
            }

        });

    </script>


</asp:Content>
