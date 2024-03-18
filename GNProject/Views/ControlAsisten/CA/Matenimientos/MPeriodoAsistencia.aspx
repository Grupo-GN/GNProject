<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MPeriodoAsistencia.aspx.cs" Inherits="GNProject.Views.ControlAsisten.CA.Matenimientos.MPeriodoAsistencia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"
        type="text/css" />

    <link href="../../css/Herramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/Tablas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/EstiloBarraHerramientas.css" rel="stylesheet" type="text/css" />
<%--    <link href="../../css/StyleWilder.css" rel="stylesheet" type="text/css" />--%>
<%--    <link href="../../css/EstiloMaycol.css" rel="stylesheet" type="text/css" />--%>

    <input id="btnNew" class="elBotonAdd" type="button"  onclick="return btnNew_onclick()" value="Nuevo" />
    <input id="btnListar" class="elBotonAdd" type="button"  onclick="return btnEdit_onclick()" value="Listar" />

<br /><br />


<fieldset>
           <div id="HeaderDiv" style="overflow: hidden; width: 100%; border: solid 1px #505050;height: 360px;">

     <table id="tblCarac" class="table">

        <thead class="theadth" style:"padding: 8px !important;"><tr>
        <th  class="theadth"scope="col">Cambiar estado</th>
        <th class="theadth" scope="col">Eliminar</th>
        <th  class="theadth"scope="col">Periodo Asistencia Id</th>
        <th  class="theadth"scope="col">Fecha de Inicio</th>
        <th class="theadth" scope="col">Fecha de Fin</th>
        <th class="theadth" scope="col">Periodo</th>
        <th class="theadth" scope="col">Activo</th>
        </tr></thead>

       <tbody class="tbody" id="tbodyPeriodoAsistencia">

       </tbody>

    </table>
    </div>

 <div style="overflow: hidden; width: 100%; border: solid 1px #505050;">
    <table class="table">
         <tfoot style:"background:#116fb4 !important;">
        <tr>
        <td class="tfoottd"  colspan="3" style="background: #116fb4;">

            <label style="font-family: 'AENOR Fontana ND'; font-weight: bold; font-size: 18px;" >TOTAL REGISTROS: </label> &nbsp
            <input id="txtnRegistros" type="text" value="0" class="TextPage" readonly="true" /> &nbsp &nbsp
            <label style="font-family: 'AENOR Fontana ND'; font-weight: bold; font-size: 18px;" >PAGE: </label> &nbsp
            <input id="txtPaginaActual" type="text" value="1" class="TextPage" readonly="true" />
             <input id="btnPrimero" type="button" value="|<" class="submitPager" style:"width:30px;heigth:20px;"/>
             <input id="btnAnterior" type="button" value="<<" class="submitPager" style:"width:30px;heigth:20px;"/>
             <input id="btnSiguiente" type="button" value=">>" class="submitPager" style:"width:30px;heigth:20px;"/>
             <input id="btnUltimo" type="button" value=">|" class="submitPager" style:"width:30px;heigth:20px;"/>
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
          <label class="tituloModal" >ADMINISTRACION DE PERIODOS DE ASISTENCIA </label>
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
                  <label class="miLabel" style="width:50%;">Fecha Inicio : </label></td>
                  <td style="text-align:left; width:50%;">
                    <input id="txtFechaInicio2" type="text" class="txt" 
                        style="width:180px;" />
                </td>
            </tr>
            <tr>
                 <td class="style23">
                  <label class="miLabel" style="width:50%;">Periodo : </label></td>
                  <td>
                  <select name="Periodo" id="cboPeriodo">
                  </select> 
                  </td>
            </tr>
            <tr>
                 <td class="style23">
                  <label class="miLabel" style="width:50%;">Fecha Fin : </label></td>
                  <td style="text-align:left; width:50%;">
                    <input id="txtFechaFin2" type="text" class="txt" 
                        style="width:180px;" />
                </td>
            </tr>
            <tr>
                 <td class="style23">
                  <label class="miLabel" style="width:50%;">¿Activo?</label></td>
                  <td><input id="chkActivo" type="checkbox" value=""></td>
            </tr>

            <tr>
    <td colspan="2">
    
       <table style="width: 100%">
            <tr>
            <td colspan="2" align="right" style="width:100%;">
                <input id="btnGrabar" type="button" value="Grabar" class="submitGrabar" />
                <input id="btnCancelar" type="button" value="Salir" class="submitSal"/>
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
    <script src="Scripts/Script_MantPeriodoAsistencia.js" type="text/javascript"></script>

    <script type="text/javascript">

        $(document).ready(function () {
            var inicio = 0;
            var TotalPaginador = 12;
            var TOTALREGISTROS;
            var PAGINAACTUAL = 1;


            inicilizaObjetos();

            $('#dialog-form').css('display', 'none');

            function mensajeError(msg) {
                $('#lblError').html(msg);
            }

            function closeModalDiv() {
                $('#dialog-form').dialog('close');
            }

            $('#btnCancelar').click(function () {
                closeModalDiv();
            });



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
            $("#txtFechaInicio2").datepicker();
            $("#txtFechaFin2").datepicker();


            Get_Periodos_List(inicio);


            $('#btnListar').click(function () {  //
                Get_PeriodoAsistencia_List(inicio);


            });
            var Estado = true;
            $('#tbodyPeriodoAsistencia').on('click', '.ElLinkEditar', function () {
                var Periodo_Asistencia_Id = this.id;

                Periodo_Asistencia_Id = Periodo_Asistencia_Id.substring(7);

                if (Estado == true) {
                    Estado = false;
                    Get_Activos_PorId_Update(Periodo_Asistencia_Id, Estado);
                    Get_PeriodoAsistencia_List(inicio);
                } else {
                    Estado = true;
                    Get_Activos_PorId_Update(Periodo_Asistencia_Id, Estado);
                    Get_PeriodoAsistencia_List(inicio);
                }

            });


            $('#tbodyPeriodoAsistencia').on('click', '.ElLinkEliminar', function () {

                var Periodo_Asistencia_Id = this.id;
                Periodo_Asistencia_Id = Periodo_Asistencia_Id.substring(9);

                Get_PeriodoAsistencia_Delete(Periodo_Asistencia_Id);
                Get_PeriodoAsistencia_List(inicio);
            });


            $('#txtnRegistros').val(Get_PeriodoAsistencia_MaxRegistro());


            function pasaModal() {

                $("#dialog-form").dialog({
                    height: 340, width: 460, modal: true, autoOpen: true,
                    appendTo: "form", title: "PERIODOS DE ASISTENCIA",
                    show: { effect: "fade", duration: 800 },
                    hide: { effect: "fold", duration: 800 }
                });
            }

            $('#btnNew').click(function () {  //

                pasaModal();
            });

            $('#btnGrabar').click(function () {
                var codigo = $('#txtCodigo').val();
                var fechainicio2 = $('#txtFechaInicio2').val();
                //var periodo = $('#cboPeriodo option:selected').text();
                var periodo = $('#cboPeriodo').val();
                var fechafin2 = $('#txtFechaFin2').val();
                var estado = false;
                if (document.getElementById('chkActivo').checked) {
                    estado = true;
                } else {
                    estado = false;
                }
                var dia = fechainicio2.substring(0, 2);
                var mes = fechainicio2.substring(3, 5);
                var anio = fechainicio2.substring(6, 10);

                var fechainicio2 = anio + "-" + mes + "-" + dia;

                var dia2 = fechafin2.substring(0, 2);
                var mes2 = fechafin2.substring(3, 5);
                var anio2 = fechafin2.substring(6, 10);

                var fechafin2 = anio2 + "-" + mes2 + "-" + dia2;
                closeModalDiv();
                Get_PeriodoAsistencia_Add(fechainicio2, periodo, fechafin2, estado);
                Get_PeriodoAsistencia_List(inicio);


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
                    Get_PeriodoAsistencia_List(inicio);
                    Get_PeriodoAsistencia_MaxRegistro();

                    setPaginaActual(PAGINAACTUAL);

                } else if (guardaPagina != TotalPaginador) {
                    PAGINAACTUAL = Math.ceil(laPaginaActual);
                    //var descripcion = $('#txtBuscar').val();
                    Get_PeriodoAsistencia_List(inicio);
                    Get_PeriodoAsistencia_MaxRegistro();
                    setPaginaActual(PAGINAACTUAL);
                } else {
                    inicio = 0;
                }

            });

            $('#btnPrimero').click(function () {  //metodos para actualizar
                inicio = 0;         //Primer Registro
                PAGINAACTUAL = 1;   //Primera Pagina
                //var descripcion = $('#txtBuscar').val();
                Get_PeriodoAsistencia_List(inicio);
                Get_PeriodoAsistencia_MaxRegistro();
                setPaginaActual(PAGINAACTUAL);
            });

            $('#btnAnterior').click(function () {  //metodos para actualizar
                if (inicio > 0) {
                    inicio = parseInt(inicio) - TotalPaginador;
                    PAGINAACTUAL = parseInt(PAGINAACTUAL) - 1;

                    //var descripcion = $('#txtBuscar').val();
                    Get_PeriodoAsistencia_List(inicio);
                    Get_PeriodoAsistencia_MaxRegistro();
                    setPaginaActual(PAGINAACTUAL);
                }

            });

            $('#btnSiguiente').click(function () {  //metodos para actualizar

                if (parseInt($('#txtnRegistros').val()) > (parseInt(inicio) + parseInt(TotalPaginador))) {
                    inicio = parseInt(inicio) + parseInt(TotalPaginador);
                    PAGINAACTUAL = parseInt(PAGINAACTUAL) + 1;

                    // var descripcion = $('#txtBuscar').val();
                    Get_PeriodoAsistencia_List(inicio);
                    Get_PeriodoAsistencia_MaxRegistro();
                    setPaginaActual(PAGINAACTUAL);
                }

            });

            function setPaginaActual(nPagina) { //Pintar la pagina actual visitada
                $('#txtPaginaActual').val(nPagina);
            }

            function inicilizaObjetos() {
                $('#txtCodigo').val('???');
                $('#txtFechaInicio2').val('');
                $('#cboPeriodo').val('');
                $('#txtFechaFin2').val('');

            }

        });
    </script>

</asp:Content>
