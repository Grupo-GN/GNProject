<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MParametrosPersona.aspx.cs" Inherits="GNProject.Views.ControlAsisten.CA.Matenimientos.MParametrosPersona" %>
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
        <option value=""></option>
        </select> 
        </td>

        <td><label class="miLabel" style="width:50%;"> Seccion : </label></td>
		<td>
        <select name="Seccion" id="cboSeccion">
        <option value=""></option>
        </select>
        </td>
        <td rowspan="2"'><input id="btnVer" type="button" value="Ver" class="buttonHer" /></td>
        


	</tr>
	<tr>
		<td><label class="miLabel" style="width:50%;">  Localidad : </label></td>
		<td>
         <select name="Localidad" id="cboLocalidad">
        <option value=""></option>
        </select> 
        </td>
        <td><label class="miLabel" style="width:50%;"> Periodo : </label></td>
		<td>
         <select name="Periodo" id="cboPeriodo">
        <option value=""></option>
        </select> 
        </td>
	</tr>
</table>
<br />
<div id="dialog-form2">
<table class="tableDialog">
	<tr>
		<td><label class="miLabel" style="width:50%;"> Personal : </label></td>
        <td>
        <select name="Personal" id="cboPersonal">
        
        </select> 
        </td>
        <td rowspan="2"'><input id="btnVerParametros" type="button" value="Ver Parametros" class="submit" style="width:150px;" /></td>
	</tr>
</table>

 </div>

    <br />
 <div id="dialog-form4">
 <table class="tableDialog">
 <tr>
 <td><label class="miLabel" style="width:50%;"> Variable : </label></td>
 <td><select name="Variable" id="cboVariable"></select></td>
 <td><label class="miLabel" style="width:50%;"> Valor : </label></td>
 <td><input id="txtValor" type="text" value="" /></td>
 <td><input id="btnGrabar" type="button" value="Grabar" class="submit" /></td>
  <td><input id="btnActualizar" type="button" value="Actualizar Valor" class="submit" style="width:130px;" /></td>
 </tr>
 </table>
 </div>

 <div id="dialog-form3">
    <fieldset>
           <div id="Div1" style="overflow: hidden;width:1200px; border: solid 1px #505050;height: 360px;">

     <table id="tblCarac" class="table">

        <thead class="theadth"><tr>
        <th  class="theadth"scope="col">Variable</th>
        <th  class="theadth"scope="col">Valor</th>
        </tr></thead>




       <tbody class="tbody" id="tbodyParametrosPersona">

       </tbody>




    </table>
    </div>
    <div style="overflow: hidden; width: 100%; border: solid 1px #505050;">
    <table class="table">
         <tfoot>
        <tr>
        <td class="tfoottd"  colspan="3">

            <label style="font-family: 'AENOR Fontana ND'; font-weight: bold; font-size: 1.1em;" >TOTAL REGISTROS: </label> &nbsp
            <input id="Text1" type="text" value="0" class="TextPage" readonly="true" /> &nbsp &nbsp
            <label style="font-family: 'AENOR Fontana ND'; font-weight: bold; font-size: 1.1em;" >PAGE: </label> &nbsp
            <input id="Text2" type="text" value="1" class="TextPage" readonly="true" />
             <input id="Button1" type="button" value="|<" class="submitPager" />
             <input id="Button2" type="button" value="<<" class="submitPager" />
             <input id="Button3" type="button" value=">>" class="submitPager" />
             <input id="Button4" type="button" value=">|" class="submitPager"/>
        </td>
        </tr>
        </tfoot>
    </table>
    </div>
  
    </fieldset>
 </div>











    <fieldset>
           <div id="HeaderDiv" style="overflow: hidden; width: 100%; border: solid 1px #505050;height: 360px;">


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


    <script src="../../jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../jqueryui/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="Scripts/Script_MantParametrosPersona.js" type="text/javascript"></script>

    <script type="text/javascript">

        $(document).ready(function () {
            var inicio = 0;
            var variable = 0;
            var valor = 0;

            $('#dialog-form2').css('display', 'none');
            $('#dialog-form3').css('display', 'none');
            $('#dialog-form4').css('display', 'none');

            function closeModalDiv2() {//2
                $('#dialog-form2').dialog('close');
            }
            function closeModalDiv3() {//2
                $('#dialog-form3').dialog('close');
            }
            function closeModalDiv4() {//2
                $('#dialog-form4').dialog('close');
            }

            function get_Id_persona() {
                return $('#cboPersonal').val();
            }

            function get_Valor() {

                return $('#txtValor').val();
            }

            function get_Planilla_Find() {
                return $('#cboPlanilla').val();
            }
            inicilizaObjetos();
            Get_Planillas_List();
            Get_Localidades_List();
            Get_Secciones_List();
            Get_Periodos_List(get_Planilla_Find());
            Get_Personal_List();




            function pasaModal2() {//
                $("#dialog-form2").css('display', 'none');
            }
            function pasaModal3() {//
                $("#dialog-form3").css('display', 'none');
            }
            function pasaModal4() {//
                $("#dialog-form4").css('display', 'none');
            }

            $('#btnVer').click(function () {  //
                $("#dialog-form2").css('display', 'table');

            });

            $('#btnVerParametros').click(function () {  //
                $("#dialog-form3").css('display', 'table');
                $("#dialog-form4").css('display', 'table');


                Get_Variables_List(get_Id_persona());
                

                Get_ParametrosPersona_Find(2);
                Get_ParametrosPersona_List(get_Id_persona(), inicio);


            });



            $('#btnGrabar').click(function () {

                var Parametro_Id = $('#cboVariable').val();
                
                Get_ParametrosPersona_Add(Parametro_Id, get_Id_persona(), get_Valor());

                Get_ParametrosPersona_List(get_Id_persona(), inicio);
                Get_Variables_List(get_Id_persona());
            });

            $('#btnActualizar').click(function () {
                var Parametro_Id = $('#cboVariable').val();


                Get_ParametrosPersona_UpdateValor(Parametro_Id, get_Id_persona(), get_Valor());

                Get_ParametrosPersona_List(get_Id_persona(), inicio);
            });



            $('#cboParametro').click(function () {

                Get_Parametros_List();
            });



            //Get_Categoria_List(inicio, "", "01");


            function inicilizaObjetos() {

                $('#cboPlanilla').val('');
                $('#cboLocalidad').val('');
                $('#cboSeccion').val('');
                $('#cboPeriodo').val('');
                $('#cboPersonal').val('');
                $('#cboVariable').val('');
            }




        });

           
    </script>

</asp:Content>
