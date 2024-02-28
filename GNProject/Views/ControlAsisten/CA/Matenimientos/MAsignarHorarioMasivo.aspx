<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MAsignarHorarioMasivo.aspx.cs" Inherits="GNProject.Views.ControlAsisten.CA.Matenimientos.MAsignarHorarioMasivo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

 <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />


  

<table class="tableDialog">
	<tr>
		<td><label class="miLabel" style="width:50%;"> Planilla : </label></td>
        <td>
        <select name="Planilla" id="cboPlanilla"  class="cbo">
        
        </select> 
        </td>

        <td><label class="miLabel" style="width:50%;"> Periodo : </label></td>
		<td>
        <select name="Periodo" id="cboPeriodo"  class="cbo">
        </select>
        </td>
        <td rowspan="2"'><input id="btnVer" type="button" value="Ver" class="buttonHer" /></td>
	</tr>
	<tr>
		<td><label class="miLabel" style="width:50%;">  Localidad : </label></td>
		<td>
         <select name="Localidad" id="cboLocalidad"  class="cbo">
        </select> 
        </td>
        <td><label class="miLabel" style="width:50%;"> Área : </label></td>
		<td>
        <select name="Area" id="cboArea" class="cbo">
        </select> 
        </td>
	</tr>
</table>

<br />
<table class="tableDialog">
	
	<tr>
		<td style="width:170px;"><label class="miLabel">  Elegir Horario a Asignar : </label></td>
		<td>
         <select name="Horario" id="cboHorario" class="cbo"></select><input id="btnSelect" type="button" value="" class="buttonDetalle" title="Seleccionar Horario"/></td>
        <td rowspan="2"'>&nbsp;</td>
        <td><input id="btnAsignarHorarios" type="button" value="Asignar Horarios" class="submit" style="width:150px;" /></td>
	</tr>
</table>










    <fieldset>
           <div id="HeaderDiv" style="overflow: auto; width: 100%; border: solid 1px #505050;height: 600px;">

     <table id="tblCarac" class="table">

        <thead class="theadth"><tr>
         <%--<th><input type="checkbox" id="chkAll" style="vertical-align:top;" /></th>--%>
            <th  class="theadth"scope="col" style="text-align:left;"><input id="chkAll" type="checkbox" /></th>
        <th>Localidad</th>
        <th>Area</th>
        <th>Seccion</th>
        <th>Nombres</th>
        <th>Horarios</th>
        </tr></thead>

       <tbody class="tbody" id="tbodyAsignarHorarioMasivo">

       </tbody>

    </table>
    </div>

 <div style="overflow: hidden; width: 100%; border: solid 1px #505050;">
    <table class="table">
         <tfoot>
        <tr>
        <td class="tfoottd"  colspan="3">
             <div id="indicador_paginas"></div>
            <label style="font-family: 'AENOR Fontana ND'; font-weight: bold; font-size: 1.1em;" >TOTAL REGISTROS: </label> &nbsp
            <input id="txtnRegistros" type="text" value="0" class="TextPage" readonly="true" /> &nbsp &nbsp
            <label style="font-family: 'AENOR Fontana ND'; font-weight: bold; font-size: 1.1em;" >PAGE: </label> &nbsp
            <input id="txtPaginaActual" type="text" value="1" class="TextPage" readonly="true" />
             <input id="cargar_primera_pagina" type="button" value="|<" class="submitPager" />
             <input id="cargar_anterior_pagina" type="button" value="<<" class="submitPager" />
             <input id="cargar_siguiente_pagina" type="button" value=">>" class="submitPager" />
             <input id="cargar_ultima_pagina" type="button" value=">|" class="submitPager"/>
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
          <label class="tituloModal" >ASIGNACIÓN DE HORARIOS MASIVO </label>
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
                  <label class="miLabel" style="width:50%;">Localidad : </label></td>
                <td style="text-align:left; width:50%;">
                    <input id="txtLocalidad" type="text" class="txt" 
                        style="width:180px;" />
                </td>
            </tr>

            <tr>
                 <td class="style23">
                  <label class="miLabel" style="width:50%;">Area : </label></td>
                <td style="text-align:left; width:50%;">
                    <input id="txtArea" type="text" class="txt" 
                        style="width:180px;" />
                </td>
            </tr>

            <tr>
                 <td class="style23">
                  <label class="miLabel" style="width:50%;">Seccion : </label></td>
                <td style="text-align:left; width:50%;">
                    <input id="txtSeccion" type="text" class="txt" 
                        style="width:180px;" />
                </td>
            </tr>

            <tr>
                 <td class="style23">
                  <label class="miLabel" style="width:50%;">Nombres : </label></td>
                <td style="text-align:left; width:50%;">
                    <input id="txtNombres" type="text" class="txt" 
                        style="width:180px;" />
                </td>
            </tr>

            <tr>
                 <td class="style23">
                  <label class="miLabel" style="width:50%;">Horarios : </label></td>
                <td style="text-align:left; width:50%;">
                    <input id="txtHorarios" type="text" class="txt" 
                        style="width:180px;" />
                </td>
            </tr>

            </table>

<label id="lblCodigSeleccionao"></label>

 </div>






 
 <div id="dialog-form2"
 style="font-size:x-small; font-family:AENOR Fontana ND;">
 <table class="borde" id="tblDHorarios" >
 <thead>

  <tr>
 <td align="center" class="titulo" colspan="5" >
          <label class="tituloModal" >Detalle de Horarios</label>
</td>

</tr>

 </thead>
 <tbody id="tbodyHDetalle">
 
  <tr>
<td colspan="5"></td>
</tr>

<tr>
<td style="text-align:left">
<label class="miLabel" style="width:50%;">dia</label></td>
<td style="text-align:left; ">
<label class="miLabel" style="width:50%;">H. Inicio</label></td>
<td style="text-align:left; ">
<label class="miLabel" style="width:50%;">H. Ini Refrig.</label></td>
<td style="text-align:left; ">
<label class="miLabel" style="width:50%;">H. Fin Refrig.</label></td>
<td style="text-align:left; ">
<label class="miLabel" style="width:50%;">H. Fin</label></td>
</tr>


<tr>
<td style="text-align:left">
<label class="miLabel" style="width:50%;">lunes</label></td>
<td style="text-align:left;"><input id="txtHoraInicio" type="text" class="txt"style="width:180px;" value="" /></td>
<td style="text-align:left;"><input id="txtHoraInicioRefrigerio" type="text" class="txt" style="width:180px;" /></td>
<td style="text-align:left;"><input id="txtHoraFinRefrigerio" type="text" class="txt" style="width:180px;" /></td>
<td style="text-align:left;"><input id="txtHoraFin" type="text" class="txt" style="width:180px;" /></td>
</tr>


 </tbody>

   
<label id="Label2"></label>

 </div>






   
    <script src="../../jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../jqueryui/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="Scripts/Script_MantAsignarHorarioMasivo.js" type="text/javascript"></script>
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script type="text/javascript">
        var Personal_Proc = '<%= Session["Usuario_Id"] %>';
        var usuarioSes = Session.get('UsuarioSistema');
        var Rol = usuarioSes.NivelAcc;
        $(document).ready(function () {
            var inicio = 0;

            $('#dialog-form').css('display', 'none');
            $('#dialog-form2').css('display', 'none');

            function mensajeError(msg) {
                $('#lblError').html(msg);
            }
            function mensajeError2(msg) {
                $('#Label1').html(msg);
            }


            function closeModalDiv() {
                $('#dialog-form').dialog('close');
            }
            function closeModalDiv2() {//2
                $('#dialog-form2').dialog('close');
            }


            $('#btnCancelar').click(function () {
                closeModalDiv();

            });

            $('#btnCancelar2').click(function () {//2
                closeModalDiv2();

            });

            function getPlanilla() {
                return $('#cboPlanilla').val();
            }


            inicilizaObjetos();
            Get_Planillas_List(inicio);
            Get_Localidades_List();
            Get_Periodos_List('01');
            Get_Areas_List(inicio);
            Get_Horarios_List(inicio);

            $('#cboPlanilla').click(function () {

                Get_Periodos_List(getPlanilla());

            });

            function pasaModal() {

                $("#dialog-form").dialog({
                    height: 340, width: 460, modal: true, autoOpen: true,
                    appendTo: "form", title: "ASIGNACIÓN DE HORARIOS MASIVO",
                    show: { effect: "fade", duration: 800 },
                    hide: { effect: "fold", duration: 800 }
                });
            }

            function pasaModal2() {//

                $("#dialog-form2").dialog({
                    height: 440, width: 860, modal: true, autoOpen: true,
                    appendTo: "form", title: "Detalle de Horarios",
                    show: { effect: "fade", duration: 800 },
                    hide: { effect: "fold", duration: 800 }
                });
            }

            $('#btnSelect').click(function () {  //
                //var horario = this.id.substring(9);
                var horario = $('#cboHorario').val();
                Get_DetalleHorarios_List(horario);
                pasaModal2();
            });

            $('#btnAsignarHorarios').click(function () {  //
                var idHorario = $('#cboHorario').val();
                var cont = 0;
                $(".ckSelect:checked").each(function () {
                    var idck = this.id;
                    var newPersonal_Id = idck.substring(11, 17);
                    Get_AsignarHorarioMasivo_UpdateHorario(newPersonal_Id, idHorario);
                    cont = cont + 1;
                });
                if (cont > 0) {
                    alert('Se Actualizaron los Horarios y las Asistencias para los Trabajadores Correctamente.');
                    var Periodo_id = $('#cboPeriodo').val();
                    var seccion = $('#cboArea').val();
                    var area_id = $('#cboLocalidad').val();
                    if (Rol == '01') {

                        Get_AsignarHorarioMasivo_ListAdmin(Periodo_id, seccion, area_id, inicio);


                    } else {
                        Get_AsignarHorarioMasivo_List(Periodo_id, seccion, area_id, inicio);

                    }
                }
                else {
                    alert('Debe seleccionar algún personal de la lista.');
                }
            });




            $('#tbodyAsignarHorarioMasivo').on('click', '.ElLinkEditar', function () {

                pasaModal();
            });

            $('#btnVer').click(function () {  //
                var Periodo_id = $('#cboPeriodo').val();
                var seccion = $('#cboArea').val();
                var area_id = $('#cboLocalidad').val();
               
                if (Rol=='01') {

                    Get_AsignarHorarioMasivo_ListAdmin(Periodo_id, seccion, area_id, inicio);


                } else {
                    Get_AsignarHorarioMasivo_List(Periodo_id, seccion, area_id, inicio);

                }
               
                total_registros = parseInt($('#txtnRegistros').val());
                //saber cuantas paginas vamos a mostrar
                pagina_ultima = Math.round(total_registros / resultados_por_pagina) + 1;
                cargarPagina(pagina_actual, pagina_ultima, resultados_por_pagina);

            });

           
            SetData();

            var resultados_por_pagina = 10;
            var pagina_actual = 1;
            var pagina_ultima = 0;
            var total_registros = parseInt($('#txtnRegistros').val());
            //saber cuantas paginas vamos a mostrar
            pagina_ultima = Math.round(total_registros / resultados_por_pagina) + 1;
            $("#cargar_primera_pagina").click(function () {
                cargarPagina(1, pagina_ultima, resultados_por_pagina);
            });
            $("#cargar_anterior_pagina").click(function () {
                cargarPagina(pagina_actual - 1, pagina_ultima, resultados_por_pagina);
            });
            $("#cargar_siguiente_pagina").click(function () {
                cargarPagina(pagina_actual + 1, pagina_ultima, resultados_por_pagina);
            });
            $("#cargar_ultima_pagina").click(function () {
                cargarPagina(pagina_ultima, pagina_ultima, resultados_por_pagina);
            });

            $('#chkAll').change(function () {
                $('#tbodyAsignarHorarioMasivo input[type="checkbox"]').prop('checked', $(this).prop('checked'));
            });
            //Get_Categoria_List(inicio, "", "01");

            function inicilizaObjetos() {

                $('#cboPlanilla').val('');
                $('#cboLocalidad').val('');
                $('#cboPeriodo').val('');
                $('#cboArea').val('');
                $('#cboHorario').val('');
            }

        });
    </script>

</asp:Content>
