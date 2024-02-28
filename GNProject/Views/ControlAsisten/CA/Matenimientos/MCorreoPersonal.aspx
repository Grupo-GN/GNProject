<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MCorreoPersonal.aspx.cs" Inherits="GNProject.Views.ControlAsisten.CA.Matenimientos.MCorreoPersonal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

 <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />
  

<table class="tableDialog">
	<tr>
		<td><label class="miLabel" style="width:50%;"> Planilla : </label></td>
        <td>
        <select name="Planilla" id="cboPlanilla" class="cbo"></select> 
        </td>

        <td><label class="miLabel" style="width:50%;"> Seccion : </label></td>
		<td>
        <select name="Seccion" id="cboSeccion"  class="cbo"></select>
        </td>
        <td rowspan="2"'><input id="btnVer" type="button" value="Ver" class="buttonHer" /></td>
	</tr>
	<tr>
		<td><label class="miLabel" style="width:50%;">  Localidad : </label></td>
		<td>
         <select name="Localidad" id="cboLocalidad" class="cbo"></select> 
        </td>
        <td><label class="miLabel" style="width:50%;"> Categoria : </label></td>
		<td>
        <select name="Categoria" id="cboCategoria" class="cbo"></select> 
        </td>
	</tr>
    <tr>
        <td><label class="miLabel" style="width:50%;">  Nombre : </label></td>
        <td><input type="text" id="txtFind" class="txt"  style="width:100%;"  /> </td>
    </tr>
</table>


<br /><br />



    <fieldset>
           <div id="HeaderDiv" style="overflow: auto; width: 100%; border: solid 1px #505050;height: 360px;">
               
     <table id="tblCarac" class="table" style="overflow:scroll;">

        <thead class="theadth"><tr>
        <th  class="theadth"scope="col">Edit</th>
        <th  class="theadth"scope="col">Area</th>
        <th  class="theadth"scope="col">Personal</th>
        <th class="theadth" scope="col">Correo</th>
        </tr></thead>

       <tbody class="tbody" id="tbodyCorreoPersonal">

       </tbody>

    </table>
    </div>

<%-- <div style="overflow: hidden; width: 100%; border: solid 1px #505050;">
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
    </div>--%>
          <div style="overflow: hidden; width: 100%; border: solid 1px #505050;">
        <table class="table">
            <tfoot>
                <tr>
                    <td class="tfoottd" colspan="3">
                        <div id="indicador_paginas"></div>
                        <label style="font-family: 'AENOR Fontana ND'; font-weight: bold; font-size: 1.1em;">TOTAL REGISTROS: </label>
                        &nbsp
            <input id="txtnRegistros" type="text" value="0" class="TextPage" readonly="readonly" />
                        &nbsp &nbsp
            <label style="font-family: 'AENOR Fontana ND'; font-weight: bold; font-size: 1.1em;">PAGE: </label>
                        &nbsp
                <input id="txtPaginaActual" type="text" value="1" class="TextPage" readonly="readonly" />
                   
                        <input id="cargar_primera_pagina" type="button" value="|<" class="submitPager" />
                        <input id="cargar_anterior_pagina" type="button" value="<<" class="submitPager" />
                        <input id="cargar_siguiente_pagina" type="button" value=">>" class="submitPager" />
                        <input id="cargar_ultima_pagina" type="button" value=">|" class="submitPager" />
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
          <label class="tituloModal" >Mantenimiento de Correos</label>
</td>
</tr>

<tr>
<td class="style23">
&nbsp
</td>
</tr>

<input type="hidden" value="???" id="txtCodigo" />
                <tr>
<td class="style23">
<label class="miLabel" style="width:50%;">Nombre : </label>
</td>
<td style="text-align:left; width:50%;" >
<input id="txtNombre" type="text" readonly="true"
class="estiloCajaCodigo" value="???" style="width:250px;"/>
</td>
</tr>
            <tr>
                 <td class="style23">
                  <label class="miLabel" style="width:50%;">Correo : </label></td>
                <td style="text-align:left; width:50%;">
                    <input id="txtCorreo" type="text" class="txt" 
                        style="width:180px;text-transform:none;" />
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



       <script src="Scripts/index.js"></script>
    <link href="../../css/index.css" rel="stylesheet" />
	    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="../../jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../jqueryui/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="Scripts/Script_MantCorreoPersonal.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            var inicio = 0;
            var TotalPaginador = 12;
            var TOTALREGISTROS;
            var PAGINAACTUAL = 1;

            $('#dialog-form').css('display', 'none');

            function closeModalDiv() {
                $('#dialog-form').dialog('close');
            }

            $('#btnCancelar').click(function () {
                closeModalDiv();
            });


            function mensajeError(msg) {
                $('#lblError').html(msg);
            }

            inicilizaObjetos();
            Get_Planillas_List(inicio);
            Get_Localidades_List(inicio);
            Get_Secciones_List(inicio);
            Get_Categorias_List(inicio);

            function pasaModal() {

                $("#dialog-form").dialog({
                    height: 340, width: 460, modal: true, autoOpen: true,
                    appendTo: "form", title: "MANTENIMIENTO DE CORREOS",
                    show: { effect: "fade", duration: 800 },
                    hide: { effect: "fold", duration: 800 }
                });
            }






            $('#tbodyCorreoPersonal').on('click', '.buttonEdit', function () {
                var codigo = this.id;
                codigo = codigo.substring(7);

                Get_CorreoPersonal_Find(codigo);
                pasaModal();
            });




            $('#txtFind').keyup(function () {
                var categoria2_Id = $('#cboCategoria').val();
                var seccion = $('#cboSeccion').val();
                var area_id = $('#cboLocalidad').val();
                var planilla = $('#cboPlanilla').val();
                var nombre = $('#txtFind').val();
                Get_CorreoPersonal_List(planilla, area_id, seccion, categoria2_Id, inicio,nombre);
                cargarpag();
            });

            $('#btnVer').click(function () {  //

                var categoria2_Id = $('#cboCategoria').val();
                var seccion = $('#cboSeccion').val();
                var area_id = $('#cboLocalidad').val();
                var planilla = $('#cboPlanilla').val();
                var nombre = $('#txtFind').val();
                Get_CorreoPersonal_List(planilla, area_id, seccion, categoria2_Id, inicio, nombre);
                cargarpag();


            });


            $('#btnGrabar').click(function () {
                var codigo = $('#txtCodigo').val();
                var nombre = $('#txtNombre').val();
                var correo = $('#txtCorreo').val();

                var categoria2_Id = $('#cboSeccion').val();
                var seccion = $('#cboCategoria').val();
                var area_id = $('#cboLocalidad').val();
                var planilla = $('#cboPlanilla').val();

                if (nombre == '' || nombre == null) {
                    mensajeError('ERROR... Debe digitar el nombre');
                    $('#txtNombre').focus();
                    return false
                }
                if (correo == '' || correo == null) {
                    mensajeError('ERROR... Debe digitar el correo');
                    $('#txtCorreo').focus();
                    return false
                }

                mensajeError('&nbsp');

                Get_CorreoPersonal_Update(codigo, correo);
                closeModalDiv();
                Get_CorreoPersonal_List(planilla, area_id, seccion, categoria2_Id, inicio);
                cargarpag();
             });

            //Get_Categoria_List(inicio, "", "01");


            function inicilizaObjetos() {
                $('#txtCodigo').val('???');
                $('#cboSeccion').val('');
                $('#cboCategoria').val('');
                $('#cboLocalidad').val('');
                $('#cboPlanilla').val('');
            }


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
                    var categoria2_Id = $('#cboCategoria').val();
                    var seccion = $('#cboSeccion').val();
                    var area_id = $('#cboLocalidad').val();
                    var planilla = $('#cboPlanilla').val();
                    Get_CorreoPersonal_List(planilla, area_id, seccion, categoria2_Id, inicio);

                    setPaginaActual(PAGINAACTUAL);

                }
                ///////////modidga///////////////
                if (guardaPagina > inicio) {
                    inicio = (TotalPaginador * Math.floor(laPaginaActual));
                    PAGINAACTUAL = Math.ceil(laPaginaActual);
                    var categoria2_Id = $('#cboCategoria').val();
                    var seccion = $('#cboSeccion').val();
                    var area_id = $('#cboLocalidad').val();
                    var planilla = $('#cboPlanilla').val();
                    Get_CorreoPersonal_List(planilla, area_id, seccion, categoria2_Id, inicio);
                    setPaginaActual(PAGINAACTUAL);
                }
                //////////////////////////////////////////////////// 
                else if (guardaPagina != TotalPaginador) {
                    PAGINAACTUAL = Math.ceil(laPaginaActual);
                    var categoria2_Id = $('#cboCategoria').val();
                    var seccion = $('#cboSeccion').val();
                    var area_id = $('#cboLocalidad').val();
                    var planilla = $('#cboPlanilla').val();
                    Get_CorreoPersonal_List(planilla, area_id, seccion, categoria2_Id, inicio);
                    setPaginaActual(PAGINAACTUAL);
                } else {
                    inicio = 0;
                }

            });

            $('#btnPrimero').click(function () {  //metodos para actualizar
                inicio = 0;         //Primer Registro
                PAGINAACTUAL = 1;   //Primera Pagina
                var categoria2_Id = $('#cboCategoria').val();
                var seccion = $('#cboSeccion').val();
                var area_id = $('#cboLocalidad').val();
                var planilla = $('#cboPlanilla').val();
                Get_CorreoPersonal_List(planilla, area_id, seccion, categoria2_Id, inicio);
                setPaginaActual(PAGINAACTUAL);
            });

            $('#btnAnterior').click(function () {  //metodos para actualizar
                if (inicio > 0) {
                    inicio = parseInt(inicio) - TotalPaginador;
                    PAGINAACTUAL = parseInt(PAGINAACTUAL) - 1;
                    var categoria2_Id = $('#cboCategoria').val();
                    var seccion = $('#cboSeccion').val();
                    var area_id = $('#cboLocalidad').val();
                    var planilla = $('#cboPlanilla').val();
                    Get_CorreoPersonal_List(planilla, area_id, seccion, categoria2_Id, inicio);
                    setPaginaActual(PAGINAACTUAL);
                }

            });

            $('#btnSiguiente').click(function () {  //metodos para actualizar

                if (parseInt($('#txtnRegistros').val()) > (parseInt(inicio) + parseInt(TotalPaginador))) {
                    inicio = parseInt(inicio) + parseInt(TotalPaginador);
                    PAGINAACTUAL = parseInt(PAGINAACTUAL) + 1;
                    var categoria2_Id = $('#cboCategoria').val();
                    var seccion = $('#cboSeccion').val();
                    var area_id = $('#cboLocalidad').val();
                    var planilla = $('#cboPlanilla').val();
                    Get_CorreoPersonal_List(planilla, area_id, seccion, categoria2_Id, inicio);
                    setPaginaActual(PAGINAACTUAL);
                }

            });

            function setPaginaActual(nPagina) { //Pintar la pagina actual visitada
                $('#txtPaginaActual').val(nPagina);
            }

            var resultados_por_pagina = 12;
            var pagina_actual = 1;
            var pagina_ultima = 0;
            var totalreg = 0;
            var total_registros = parseInt($('#txtnRegistros').val());
            //saber cuantas paginas vamos a mostrar
            pagina_ultima = Math.round(total_registros / resultados_por_pagina) + 1;
            //cargar la primera pagina

            //eventos para los botones
            //$("#cargar_primera_pagina").click(function () {
            //    cargarpag();
            //    cargarPaginaNueva(1, pagina_ultima, 'tblCarac', resultados_por_pagina);
            //});
            //$("#cargar_anterior_pagina").click(function () {
            //    cargarpag();
            //    cargarPaginaNueva(pagina_actual - 1, pagina_ultima, 'tblCarac', resultados_por_pagina);
            //});
            //$("#cargar_siguiente_pagina").click(function () {
            //    cargarpag();
            //    cargarPaginaNueva(pagina_actual + 1, pagina_ultima, 'tblCarac', resultados_por_pagina);
            //});
            //$("#cargar_ultima_pagina").click(function () {
                
            //    cargarPaginaNueva(pagina_ultima, pagina_ultima, 'tblCarac', resultados_por_pagina);
            //});


            function cargarpag() {
                var total_registros = parseInt($('#txtnRegistros').val());
                //saber cuantas paginas vamos a mostrar
                pagina_ultima = Math.round(total_registros / resultados_por_pagina) + 1;
                cargarPaginaNueva(pagina_actual, pagina_ultima, 'tblCarac', resultados_por_pagina);
            }




        });
    </script>

</asp:Content>
