<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MAsignarTurnoMasivos.aspx.cs" Inherits="GNProject.Views.ControlAsisten.CA.Matenimientos.MAsignarTurnoMasivos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

 <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"
        type="text/css" />

    <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />
  

<table class="tableDialog">
	<tr>
		<td><label class="miLabel" style="width:50%;"> Planilla : </label></td>
        <td>
        <select name="Planilla" id="cboPlanilla">
        
        </select> 
        </td>

        <td><label class="miLabel" style="width:50%;"> Periodo : </label></td>
		<td>
        <select name="Periodo" id="cboPeriodo">
        </select>
        </td>
        <td rowspan="2"'><input id="btnVer" type="button" value="Ver" class="buttonHer" /></td>
	</tr>
	<tr>
		<td><label class="miLabel" style="width:50%;">  Localidad : </label></td>
		<td>
         <select name="Localidad" id="cboLocalidad">
        </select> 
        </td>
        <td><label class="miLabel" style="width:50%;"> Área : </label></td>
		<td>
        <select name="Area" id="cboArea">
        </select> 
        </td>
	</tr>
</table>
<hr />
<table class="tableDialog">
<tr>
    <td style="width:50%;vertical-align:top;">
        <fieldset>
            <legend  class="miTituloField">Turnos</legend>
            <table class="tableDialog">
                <tr>
                    <td style="text-align:right;"><label  class="miLabel"">TURNO A ASIGNAR :</label></td>
                    <td colspan="2"><select name="Personal" id="cboTurnoAsignar"></select></td>                    
                </tr>
                <tr>
                    <td style="text-align:right;"><label  class="miLabel">Hora Ingreso: </label></td>
                    <td><input type="text" id="txtinput1" style="width:40px;text-align:center;" /></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="text-align:right;"><label  class="miLabel">Hora Inicio Refrigerio: </label></td>
                    <td><input type="text" id="txtinput2" style="width:40px;text-align:center;"/></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="text-align:right;"><label  class="miLabel">Hora Fin Refrigerio: </label></td>
                    <td><input type="text" id="txtinput3" style="width:40px;text-align:center;"/></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="text-align:right;"><label  class="miLabel">Hora Salida:  </label></td>
                    <td><input type="text" id="txtinput4" style="width:40px;text-align:center;"/></td>
                    <td></td>
                </tr>

            </table>
        </fieldset>
    </td>
    <td style="width:50%; vertical-align:top;">
    <fieldset>
        <legend class="miTituloField">Asignar Turno</legend>
        <table class="tableDialog">
            <tr>
                <td style="text-align:right;"><label class="miLabel">DESDE : </label></td>
                <td><input id="datepicker" type="text" class="ddl" /></td>
                <td></td>
            </tr>
            <tr>
                <td style="text-align:right;"><label class="miLabel">HASTA : </label></td>
                <td><input id="datepicker2" type="text" class="ddl" /></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td><input id="ckSeleccion" class="chkseleccionado" type="checkbox"  value=""  title="AsignarTurnoMasivo" />Alternar&nbsp; <input id="txtBox" class="textbox" type="number" min="1" max="30" value="1" style="width:40px;"  /></td>
                <td></td>
            </tr>
            <tr>
                <td colspan="3"><input id="btnAsignarTurnos" type="button" value="Asignar Turnos" class="submit" style="width:130px;" /></td>
            </tr>
        </table>
    </fieldset>
    </td>
</tr>
</table>


 <div >
    <fieldset>
<div id="HeaderDiv" style="overflow: auto;width:100%; border: solid 1px #505050;height: 360px;">

     <table id="tblCarac" class="table">

        <thead class="theadth"><tr>
        <th  class="theadth"scope="col" style="text-align:left;"><input id="chkAll" type="checkbox" /></th>
        <th  class="theadth"scope="col">Localidad</th>
        <th  class="theadth"scope="col">Area</th>
        <th class="theadth" scope="col">Seccion ID</th>
        <th class="theadth" scope="col">Apellidos-Nombres</th>
        </tr></thead>

       <tbody class="tbody" id="tbodyAsignarTurnoMasivos">

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
    <script src="Scripts/Script_MantAsignarTurnoMasivos.js" type="text/javascript"></script>
   

    <script type="text/javascript">
        var Personal_Proc = '<%= Session["Usuario_Id"] %>';
        $(document).ready(function () {
            var inicio = 0;

            //document.getElementById("lblHorario").style.visibility = "hidden";




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
            $("#datepicker").datepicker();
            $("#datepicker2").datepicker();
            $('#dialog-form').css('display', 'none');


            $('#chkAll').change(function () {
                $('#tbodyAsignarTurnoMasivos input[type="checkbox"]').prop('checked', $(this).prop('checked'));
            });

            function closeModalDiv() {
                $('#dialog-form').dialog('close');
            }

            $('#btnCancelar').click(function () {
                closeModalDiv();

            });

            function getPlanilla() {
                return $('#cboPlanilla').val();
            }



            inicilizaObjetos();
            Get_Planillas_List(inicio);
            Get_Periodos_List(getPlanilla());
            Get_Localidades_List();
            Get_Areas_List(inicio);
            Get_TurnoAsignar_List(inicio);


            var Turno_Select = $('#cboTurnoAsignar').val();
            Get_TurnoAsignarLabel_List(Turno_Select);

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




            $('#tbodyAsignarTurnoPersona').on('click', '.ElLinkEditar', function () {

                pasaModal();
            });

            $('#btnVer').click(function () {  //
                var Periodo_id = $('#cboPeriodo').val();
                var seccion = $('#cboArea').val();
                var area_id = $('#cboLocalidad').val();

                seccion = seccion.trim();
                Get_AsignarTurnoMasivos_List(Periodo_id, seccion, area_id, inicio);
            });            

            $('#cboTurnoAsignar').change(function () {

                //document.getElementById("lblHorario").style.visibility = "visible";
                var Turno_id = $('#cboTurnoAsignar').val();
                Get_TurnoAsignarLabel_List(Turno_id);
            });

            //Get_Categoria_List(inicio, "", "01");


            $('#btnAsignarTurnos').click(function () {  //

                Get_TurnoAsignar_Proceso();

            });


            function inicilizaObjetos() {

                $('#cboPlanilla').val('');
                $('#cboLocalidad').val('');
                $('#cboPeriodo').val('');
                $('#cboArea').val('');
                $('#cboTurnoAsignar').val('');


            }

        });

    </script>

</asp:Content>
