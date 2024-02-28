<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MFeriados.aspx.cs" Inherits="GNProject.Views.ControlAsisten.CA.Matenimientos.MFeriados" %>
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

        <thead class="theadth"><tr>
        <th  class="theadth"scope="col">Edit</th>
        <th  class="theadth"scope="col">Nombre</th>
        <th  class="theadth"scope="col">Descripcion</th>
        <th class="theadth" scope="col">Fecha</th>
        </tr></thead>

       <tbody class="tbody" id="tbodyFeriados">

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
<td >
<input id="txtCodigo" type="text" readonly="true"
class="txtCodigo" value="???" />
</td>
</tr>

 <tr>
                 <td>
                  <label class="miLabel" style="width:50%;">Nombre : </label></td>
                <td>
                    <input id="txtNombre" type="text" class="txt" style="width:100%;" />
                </td>
            </tr>

            <tr>
                 <td>
                  <label class="miLabel" style="width:50%;">Descripcion : </label></td>
                <td>
                    <input id="txtDescripcion" type="text" class="txt" style="width:100%;" />
                </td>
            </tr>

            <tr>
                 <td>
                  <label class="miLabel" style="width:50%;">Fecha : </label></td>
                <td>
                    <input id="txtFecha" type="text" class="txt" 
                        style="width:100%;" />
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
    <script src="Scripts/Script_MantFeriados.js" type="text/javascript"></script>


 <script type="text/javascript">
     var TIPOPROCESO;

     $(document).ready(function () {
         var inicio = 0;
         var TotalPaginador = 12;
         var TOTALREGISTROS;
         var PAGINAACTUAL = 1;



         $.datepicker.regional['es'] =
	  {
	      closeText: 'Cerrar',
	      prevText: 'Previo',
	      nextText: 'Próximo',

	      monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
	  'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
	      monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun',
	  'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
	      monthStatus: 'Ver otro mes', yearStatus: 'Ver otro año',
	      dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
	      dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mie', 'Jue', 'Vie', 'Sáb'],
	      dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sa'],
	      dateFormat: 'dd/mm/yy', firstDay: 0,
	      initStatus: 'Selecciona la fecha', isRTL: false
	  };
         $.datepicker.setDefaults($.datepicker.regional['es']);
         $("#txtFecha").datepicker();

         $('#dialog-form').css('display', 'none');

         function mensajeError(msg) {
             $('#lblError').html(msg);
         }

         function closeModalDiv() {
             $('#dialog-form').dialog('close');
         }

         $('#btnCancelar').click(function () {
             closeModalDiv();
             Get_Feriados_List(inicio)
             Get_Feriados_MaxRegistro();
         });

         function pasaModal() {
             //modidga//height: 280, width: 385
             $("#dialog-form").dialog({
                 height: 280, width: 385, modal: true, autoOpen: true,
                 appendTo: "form", title: "MANTENIMIENTO DE FERIADOS",
                 show: { effect: "fade", duration: 800 },
                 hide: { effect: "fold", duration: 800 }
             });
         }

         Get_Feriados_List(0);
         //            Get_Feriados_MaxRegistro();
         $('#tbodyFeriados').on('click', '.buttonEdit', function () {
             TIPOPROCESO = '02';
             var codigo = this.id;
             codigo = codigo.substring(7);
             mensajeError('&nbsp');
             Get_Feriados_Find(codigo);
             Get_Feriados_List(inicio);
             pasaModal();
         });

         $('#txtnRegistros').val(Get_Feriados_MaxRegistro());

         $('#btnNew').click(function () {
             TIPOPROCESO = '01';
             inicilizaObjetos();
             pasaModal();
             //$('#btnGrabar').attr('disabled', false);
         });

         $("#tblCarac").on("click", '.Editar', function () {

             var href = $(this).attr('href');
             var codigo = href.substring(1);
             Get_Feriados_Find(codigo);
             pasaModal();
             //$('#btnGrabar').attr('disabled', false);

         });

         $('#btnGrabar').click(function () {
             var codigo = $('#txtCodigo').val();
             var nombre = $('#txtNombre').val();
             var descripcion = $('#txtDescripcion').val();
             var fecha = $('#txtFecha').val();

             if (nombre == '' || nombre == null) {
                 mensajeError('ERROR... Debe digitar el nombre');
                 $('#txtNombre').focus();
                 return false
             }
             if (descripcion == '' || descripcion == null) {
                 mensajeError('ERROR... Debe digitar la descripcion');
                 $('#descripcion').focus();
                 return false
             }
             if (fecha == '' || fecha == null) {
                 mensajeError('ERROR... Debe digitar la fecha');
                 $('#txtHoraIni').focus();
                 return false
             }


             mensajeError('&nbsp');
             if (TIPOPROCESO == "01") {
                 var dia = fecha.substring(0, 2);
                 var mes = fecha.substring(3, 5);
                 var anio = fecha.substring(6, 10);

                 var fecha = anio + "-" + mes + "-" + dia;

                 Get_Feriados_Add(nombre, descripcion, fecha);
                 //$('#btnGrabar').attr('disabled', true);
             } else if (TIPOPROCESO == "02") {

                 var dia = fecha.substring(0, 2);
                 var mes = fecha.substring(3, 5);
                 var anio = fecha.substring(6, 10);

                 var fecha = anio + "-" + mes + "-" + dia;
  
                 Get_Feriados_Update(codigo, nombre, descripcion, fecha);

             }
             closeModalDiv();
             Get_Feriados_List(inicio);
             Get_Feriados_MaxRegistro();


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
                 Get_Feriados_List(inicio);
                 Get_Feriados_MaxRegistro();
                 setPaginaActual(PAGINAACTUAL);

             }
             ///////////modidga///////////////
             if (guardaPagina > inicio) {
                 inicio = (TotalPaginador * Math.floor(laPaginaActual));
                 PAGINAACTUAL = Math.ceil(laPaginaActual);
                 Get_Feriados_List(inicio);
                 Get_Feriados_MaxRegistro();
                 setPaginaActual(PAGINAACTUAL);
             }
             //////////////////////////////////////////////////// 
             else if (guardaPagina != TotalPaginador) {
                 PAGINAACTUAL = Math.ceil(laPaginaActual);
                 //var descripcion = $('#txtBuscar').val();
                 Get_Feriados_List(inicio);
                 Get_Feriados_MaxRegistro();
                 setPaginaActual(PAGINAACTUAL);
             } else {
                 inicio = 0;
             }

         });

         $('#btnPrimero').click(function () {  //metodos para actualizar
             inicio = 0;         //Primer Registro
             PAGINAACTUAL = 1;   //Primera Pagina
             //var descripcion = $('#txtBuscar').val();
             Get_Feriados_List(inicio);
             Get_Feriados_MaxRegistro();
             setPaginaActual(PAGINAACTUAL);
         });

         $('#btnAnterior').click(function () {  //metodos para actualizar
             if (inicio > 0) {
                 inicio = parseInt(inicio) - TotalPaginador;
                 PAGINAACTUAL = parseInt(PAGINAACTUAL) - 1;

                 //var descripcion = $('#txtBuscar').val();
                 Get_Feriados_List(inicio);
                 Get_Feriados_MaxRegistro();
                 setPaginaActual(PAGINAACTUAL);
             }

         });

         $('#btnSiguiente').click(function () {  //metodos para actualizar

             if (parseInt($('#txtnRegistros').val()) > (parseInt(inicio) + parseInt(TotalPaginador))) {
                 inicio = parseInt(inicio) + parseInt(TotalPaginador);
                 PAGINAACTUAL = parseInt(PAGINAACTUAL) + 1;

                 // var descripcion = $('#txtBuscar').val();
                 Get_Feriados_List(inicio);
                 Get_Feriados_MaxRegistro();
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
             $('#txtFecha').val('');
         }



     });

 </script>

</asp:Content>
