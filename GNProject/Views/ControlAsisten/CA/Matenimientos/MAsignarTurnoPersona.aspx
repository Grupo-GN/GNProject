<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MAsignarTurnoPersona.aspx.cs" Inherits="GNProject.Views.ControlAsisten.CA.Matenimientos.MAsignarTurnoPersona" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

 <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"
        type="text/css" />

    <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />

  

<table class="tableDialog">
	<tr>
		<td><label class="miLabel" style="width:50%;"> Planilla : </label></td>
        <td>
        <select name="Planilla" id="cboPlanilla" class="cbo">
        
        </select> 
        </td>

        <td><label class="miLabel" style="width:50%;"> Periodo : </label></td>
		<td>
        <select name="Periodo" id="cboPeriodo" class="cbo">
        </select>
        </td>
        <td rowspan="2"'><input id="btnVer" type="button" value="Ver" class="buttonHer" /></td>
	</tr>
	<tr>
		<td><label class="miLabel" style="width:50%;">  Localidad : </label></td>
		<td>
         <select name="Localidad" id="cboLocalidad" class="cbo">
        </select> 
        </td>
        <td><label class="miLabel" style="width:50%;"> Área : </label></td>
		<td>
        <select name="Area" id="cboArea" class="cbo">
        </select> 
        </td>
	</tr>
</table>

<br /><br />

<div id="dialog-form2">
<table class="tableDialog">
	<tr>
		<td><label class="miLabel" style="width:50%;"> Personal : </label></td>
        <td>
        <select name="Personal" id="cboPersonal">
        
        </select> 
        </td>
        <td rowspan="2"'><input id="btnVerTurnos" type="button" value="Ver Turnos" class="submit" /></td>
	</tr>
	<tr>
		<td><label class="miLabel" style="width:50%;">  Periodo : </label></td>
		<td>
         <select name="Periodo2" id="cboPeriodo2">
        </select> 
        </td>
       
	</tr>

</table>

 </div>


 <br /><br />
 <div id="dialog-form3">
    <fieldset>
           <div id="HeaderDiv" style="overflow: hidden;width:1200px; border: solid 1px #505050;height: 360px;">

     <table id="tblCarac" class="table">

        <thead class="theadth"><tr>
        <th  class="theadth"scope="col"></th>
        <th  class="theadth"scope="col">Lunes</th>
        <th  class="theadth"scope="col">Martes</th>
        <th class="theadth" scope="col">Miercoles</th>
        <th class="theadth" scope="col">Jueves</th>
        <th class="theadth" scope="col">Viernes</th>
        <th class="theadth" scope="col">Sabado</th>
        <th class="theadth" scope="col">Domingo</th>
        </tr></thead>

       <tbody class="tbody" id="tbodyAsignarTurnoPersona">

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
 </div>


    

 <div id="dialog-form"
 style="font-size:x-small; font-family:AENOR Fontana ND;">
 <table class="borde">
 <tr>
 <td align="center" class="titulo" colspan="2">
          <label class="tituloModal" >ASIGNACIÓN DE TURNOS POR PERSONA </label>
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

            <tr>
    <td colspan="2">
    
       <table style="width: 100%">
          <tr>
            <td style="height:3px;" colspan="2">
             <label id="lblError" class="miLabelError" >[lblError] : </label>
            </td>
            </tr>
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
    <script src="Scripts/Script_MantAsignarTurnoPersona.js" type="text/javascript"></script>

    <script type="text/javascript">

        $(document).ready(function () {
            var inicio = 0;

            $('#dialog-form').css('display', 'none');
            $('#dialog-form2').css('display', 'none');
            $('#dialog-form3').css('display', 'none');

            function closeModalDiv() {
                $('#dialog-form').dialog('close');
            }
            function closeModalDiv2() {//2
                $('#dialog-form2').dialog('close');
            }
            function closeModalDiv3() {//2
                $('#dialog-form3').dialog('close');
            }

            $('#btnCancelar').click(function () {
                closeModalDiv();

            });

            function getPlanilla() {
                return $('#cboPlanilla').val();
            }

      

            inicilizaObjetos();
            Get_Planillas_List(inicio);
            Get_Localidades_List(inicio);
            Get_Periodos_List(Get_Planilla_Find());
            Get_Areas_List(inicio);
            Get_Personal_List(inicio);
            Get_Periodos2_List(Get_Planilla_Find());

            $('#cboPlanilla').click(function () {

                Get_Periodos_List(getPlanilla());

            });

            function pasaModal() {

                $("#dialog-form").dialog({
                    height: 340, width: 460, modal: true, autoOpen: true,
                    appendTo: "form", title: "ASIGNACIÓN DE TURNOS POR PERSONA",
                    show: { effect: "fade", duration: 800 },
                    hide: { effect: "fold", duration: 800 }
                });
            }

            function pasaModal2() {//
                $("#dialog-form2").css('display', 'none');
            }
            function pasaModal3() {//
                $("#dialog-form3").css('display', 'none');
            }



            $('#tbodyAsignarTurnoPersona').on('click', '.ElLinkEditar', function () {

                pasaModal();
            });

            $('#btnVer').click(function () {  //
                $("#dialog-form2").css('display', 'table');

                //var Periodo_id = $('#cboPeriodo').val();
                //var seccion = $('#cboArea').val();
                //var area_id = $('#cboLocalidad').val();
                //seccion = seccion.trim();
                //Get_AsignarTurnoPersonas_List(Periodo_id, seccion, area_id, inicio);

            });

            $('#btnVerTurnos').click(function () {  //
                $("#dialog-form3").css('display', 'table');

                //var Periodo_id = $('#cboPeriodo').val();
                //var seccion = $('#cboArea').val();
                //var area_id = $('#cboLocalidad').val();
                //seccion = seccion.trim();
                //Get_AsignarTurnoPersonas_List(Periodo_id, seccion, area_id, inicio);

            });


            //Get_Categoria_List(inicio, "", "01");


            function inicilizaObjetos() {

                $('#cboPlanilla').val('');
                $('#cboLocalidad').val('');
                $('#cboPeriodo').val('');
                $('#cboArea').val('');
                $('#cboPersonal').val('');
                $('#cboPeriodo2').val('');
            }

        });
    </script>

</asp:Content>
