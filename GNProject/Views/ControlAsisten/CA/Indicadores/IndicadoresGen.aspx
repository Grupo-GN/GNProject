<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IndicadoresGen.aspx.cs" Inherits="GNProject.Views.ControlAsisten.CA.Indicadores.IndicadoresGen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />
    <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet" type="text/css" />

    <section id="tabContainer" style="font-size: small; border-color:white;" >
    <ul>
        <li><a href="#Tab1">INDICADORES X PERSONAL</a></li>
        <li><a href="#Tab2">INDICADORES POR LOCALIDAD</a></li>
        <li><a href="#Tab3">INDICADORES POR AREA</a></li>

    </ul>
<section id="Tab1" style="height:100%" >
    <fieldset>
    <legend class="miTituloField">FILTROS INDICADORES X PERSONAL</legend>
    <table class="tableDialog">
        <tr>
            <td style="width:150px;text-align:right;"><label class="miLabel">Planilla : </label></td>
            <td><select class="cbo" id="cboPlanilla"></select></td>
            <td style="text-align:right;"><label class="miLabel">Periodo : </label></td>
            <td><select class="cbo" id="cboPeriodo"></select></td>
            <td style="text-align:right;"><label class="miLabel">Localidad : </label></td>
            <td><select class="cbo" id="cboLocalidad"></select></td>
        </tr>
        <tr>
            <td style="text-align:right;"><label class="miLabel">Personal : </label></td>
            <td colspan="2"><select class="cbo" id="cboPersonal"></select></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
          <tr>
            <td style="text-align:right;"><label class="miLabel">Fecha Inicio : </label></td>
            <td><input type="text" class="txt" id="txtFechaInicio" /></td>
            <td style="text-align:right;"><label class="miLabel">Fecha Final : </label></td>
            <td><input type="text" class="txt"  id="txtFechaFinal"/></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
 
            <td></td>
        </tr>
    </table>

</fieldset>

<fieldset>
    <table class="tableDialog">
        <tr>
            <td style="width:130px;"><input type="button" class="buttonHer" value="GENERAR" id="btnGenerar" /></td>
                      
            <td></td>
        </tr>
    </table>
</fieldset>
<br />   
     <%--SECCION DE CHARTS--%>  
      <div id="chart-container">
        <canvas id="graphCanvas"></canvas>
    </div>
   <div id="chart-container1">
        <canvas id="graphCanvas1"></canvas>
    </div>
     <div id="chart-container2">
        <canvas id="graphCanvas2"></canvas>
    </div>
       <div id="chart-container3">
        <canvas id="graphCanvas3"></canvas>
    </div>

      <div id="chart-container01">
        <canvas id="graphCanvas01"></canvas>
    </div>
      <div id="chart-container02">
        <canvas id="graphCanvas02"></canvas>
    </div>
      <div id="chart-container03">
        <canvas id="graphCanvas03"></canvas>
    </div>

    </section>
    <section id="Tab2" style="height:100%">

            <fieldset>
    <legend class="miTituloField">FILTROS</legend>
    <table class="tableDialog">
        <tr>
            <td style="width:150px;text-align:right;"><label class="miLabel">Planilla : </label></td>
            <td><select class="cbo" id="cboPlanilla1"></select></td>
            <td style="text-align:right;"><label class="miLabel">Periodo : </label></td>
            <td><select class="cbo" id="cboPeriodo1"></select></td>
           
        </tr>
    <tr style="display:none;">
            <td style="text-align:right;"><label class="miLabel">Localidad : </label></td>
            <td><select class="cbo" id="cboLocalidad1"></select></td>
    </tr>
          <tr>
            <td style="text-align:right;"><label class="miLabel">Fecha Inicio : </label></td>
            <td><input type="text" class="txt" id="txtFechaInicio1" /></td>
            <td style="text-align:right;"><label class="miLabel">Fecha Final : </label></td>
            <td><input type="text" class="txt"  id="txtFechaFinal1"/></td>
            <td></td>
            <td></td>
        </tr>
 
        <tr>
 
            <td></td>
        </tr>
    </table>

</fieldset>


        <fieldset>
    <table class="tableDialog">
        <tr>
         
            <td style="width:130px;"><input type="button" class="buttonHer" id="btnGenera1" value="GENERAR" /></td>
          
        </tr>
    </table>
    </fieldset>
<br /> 
      <%--SECCION DE CHARTS--%>
       <div id="chart-container4">
        <canvas id="graphCanvas4"></canvas>
    </div>
   <div id="chart-container5">
        <canvas id="graphCanvas5"></canvas>
    </div>
     <div id="chart-container6">
        <canvas id="graphCanvas6"></canvas>
    </div>
       <div id="chart-container7">
        <canvas id="graphCanvas7"></canvas>
    </div>

        <div id="chart-container04">
        <canvas id="graphCanvas04"></canvas>
    </div>
   <div id="chart-container05">
        <canvas id="graphCanvas05"></canvas>
    </div>
     <div id="chart-container06">
        <canvas id="graphCanvas06"></canvas>
    </div>

    </section>


<section id="Tab3" style="height:100%">

            <fieldset>
    <legend class="miTituloField">FILTROS</legend>
    <table class="tableDialog">
        <tr>
            <td style="width:150px;text-align:right;"><label class="miLabel">Planilla : </label></td>
            <td><select class="cbo" id="cboPlanilla2"></select></td>
            <td style="text-align:right;"><label class="miLabel">Periodo : </label></td>
            <td><select class="cbo" id="cboPeriodo2"></select></td>
          
        </tr>
       
        <tr style="display:none;">
              <td style="text-align:right;"><label class="miLabel">Localidad : </label></td>
            <td><select class="cbo" id="cboLocalidad2"></select></td>
         <td style="text-align:right;"><label class="miLabel">Area : </label></td>
            <td><select class="cbo" id="cboCategoriaAux"></select></td>
            <td style="text-align:right;"><label class="miLabel">Sección : </label></td>
            <td><select class="cbo" id="cboCategoriaAux2"></select></td>
            <td style="text-align:right;"><label class="miLabel">Categoria : </label></td>
            <td><select class="cbo" id="cboCategoria"></select></td>
        </tr>
          <tr>
            <td style="text-align:right;"><label class="miLabel">Fecha Inicio : </label></td>
            <td><input type="text" class="txt" id="txtFechaInicio2" /></td>
            <td style="text-align:right;"><label class="miLabel">Fecha Final : </label></td>
            <td><input type="text" class="txt"  id="txtFechaFinal2"/></td>
            <td></td>
            <td></td>
        </tr>
 
        <tr>
 
            <td></td>
        </tr>
    </table>

</fieldset>


        <fieldset>
    <table class="tableDialog">
        <tr>
         
            <td style="width:130px;"><input type="button" class="buttonHer" id="btnGenera2" value="GENERAR" /></td>
          
        </tr>
    </table>
    </fieldset>
<br /> 
      <%--SECCION DE CHARTS--%>
         <div id="chart-container8">
        <canvas id="graphCanvas8"></canvas>
    </div>
   <div id="chart-container9">
        <canvas id="graphCanvas9"></canvas>
    </div>
     <div id="chart-container10">
        <canvas id="graphCanvas10"></canvas>
    </div>
       <div id="chart-container11">
        <canvas id="graphCanvas11"></canvas>
    </div>

      <div id="chart-container08">
        <canvas id="graphCanvas08"></canvas>
    </div>
   <div id="chart-container09">
        <canvas id="graphCanvas09"></canvas>
    </div>
     <div id="chart-container010">
        <canvas id="graphCanvas010"></canvas>
    </div>


    </section>

</section>

    <script src="../../jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../jqueryui/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="chart.min.js" type="text/javascript"></script>
    <script src="Script_Indicadores.js" type="text/javascript"></script>

    <script type="text/javascript">
        var Personal_Proc = '<%= Session["Usuario_Id"] %>';
        var NivelAcceso_Proc = '<%= Session["Usuario_NivelAcceso"] %>';
        var Planilla_Id_Proc = '<%= Session["Usuario_Planilla_Id"] %>';
        var Area_Id_Proc = '<%= Session["Usuario_Area_Id"] %>';
        var CatAuxiliar_Id_Proc = '<%= Session["Usuario_CatAuxiliar_Id"] %>';
        var CatAuxiliar2_Id_Proc = '<%= Session["Usuario_CatAuxiliar2_Id"] %>';
        var PersonalSelec = [];

        $(document).ready(function () {
            $('#tabContainer').tabs();
            Get_Planilla_List();
            Get_Planilla_List1();
            Get_Periodo_Activo_By_CA(Get_Planilla_Find());
            Get_Localidad_List();
            Get_Categoria_Auxiliar_List();
            Get_Categoria_Auxiliar2_List(Get_CategoriaAux_Find());
            Get_Categoria_List();
            CrearCuadroFechas();
            Get_PeriodoCA_By_Planilla(Get_Periodo_Find());
            Get_PeriodoCA_By_Planilla1(Get_Periodo_Find1());
            Get_PeriodoCA_By_Planilla2(Get_Periodo_Find2());

            Get_Personal_By_Filtros(Get_Periodo_Find(), Get_Localidad_Find(), '', '', '');

            $('#cboPlanilla').change(function () {
                Get_Periodo_Activo_By_CA(Get_Planilla_Find());
                Get_Personal_By_Filtros(Get_Periodo_Find(), Get_Localidad_Find(), '', '', '');
            });
            $('#cboPeriodo').change(function () {
                Get_Personal_By_Filtros(Get_Periodo_Find(), Get_Localidad_Find(), '', '', '');
                Get_PeriodoCA_By_Planilla($(this).val());
            });
            $('#cboLocalidad').change(function () {
                Get_Personal_By_Filtros(Get_Periodo_Find(), Get_Localidad_Find(), '', '', '');
            });
            $('#cboPeriodo1').change(function () {
   
                Get_PeriodoCA_By_Planilla1($(this).val());
            });

            $('#cboPeriodo2').change(function () {

                Get_PeriodoCA_By_Planilla2($(this).val());
            });

            $('#cboCategoriaAux').change(function () {
              //  Get_Categoria_Auxiliar2_List(Get_CategoriaAux_Find());
               // Get_Personal_By_Filtros(Get_Periodo_Find(), Get_Localidad_Find(), Get_CategoriaAux_Find(), Get_CategoriaAux2_Find(), Get_Categoria_Find());
            });
            $('#cboCategoriaAux2').change(function () {
               // Get_Personal_By_Filtros(Get_Periodo_Find(), Get_Localidad_Find(), Get_CategoriaAux_Find(), Get_CategoriaAux2_Find(), Get_Categoria_Find());
            });
            $('#cboCategoria').change(function () {
               // Get_Personal_By_Filtros(Get_Periodo_Find(), Get_Localidad_Find(), Get_CategoriaAux_Find(), Get_CategoriaAux2_Find(), Get_Categoria_Find());
            });

            $('#btnGenerar').click(function () {
                var FechaInicio = $('#txtFechaInicio').val();
                var FechaFinal = $('#txtFechaFinal').val();
                showGraph($('#cboPersonal').val(), FechaInicio, FechaFinal, 'F', $('#cboPlanilla').val());
                showGraph($('#cboPersonal').val(), FechaInicio, FechaFinal, 'T', $('#cboPlanilla').val());
                showGraph($('#cboPersonal').val(), FechaInicio, FechaFinal, 'S', $('#cboPlanilla').val());
                showGraph($('#cboPersonal').val(), FechaInicio, FechaFinal, 'A', $('#cboPlanilla').val());
                showGraph($('#cboPersonal').val(), FechaInicio, FechaFinal, 'H', $('#cboPlanilla').val());
                showGraph($('#cboPersonal').val(), FechaInicio, FechaFinal, 'C', $('#cboPlanilla').val());
                showGraph($('#cboPersonal').val(), FechaInicio, FechaFinal, 'P', $('#cboPlanilla').val());
                //getListHE(Get_Planilla_Find(), Get_Periodo_Find(), Get_Localidad_Find(), $('#cboPersonal').val());

            });

            $('#btnGenera1').click(function () {
                var FechaInicio = $('#txtFechaInicio1').val();
                var FechaFinal = $('#txtFechaFinal1').val();
                showGraphLocalidad($('#cboPeriodo1').val(),'', FechaInicio, FechaFinal, 'F' );
                showGraphLocalidad($('#cboPeriodo1').val(), '', FechaInicio, FechaFinal, 'T');
                showGraphLocalidad($('#cboPeriodo1').val(), '', FechaInicio, FechaFinal, 'S');
                showGraphLocalidad($('#cboPeriodo1').val(), '', FechaInicio, FechaFinal, 'A');
                showGraphLocalidad($('#cboPeriodo1').val(), '', FechaInicio, FechaFinal, 'H');
                showGraphLocalidad($('#cboPeriodo1').val(), '', FechaInicio, FechaFinal, 'C');
                showGraphLocalidad($('#cboPeriodo1').val(), '', FechaInicio, FechaFinal, 'P');
                //getListHE(Get_Planilla_Find(), Get_Periodo_Find(), Get_Localidad_Find(), $('#cboPersonal').val());

            });

            $('#btnGenera2').click(function () {
                var FechaInicio = $('#txtFechaInicio2').val();
                var FechaFinal = $('#txtFechaFinal2').val();
                showGraphArea($('#cboPeriodo2').val(), '', FechaInicio, FechaFinal, 'F');
                showGraphArea($('#cboPeriodo2').val(), '', FechaInicio, FechaFinal, 'T');
                showGraphArea($('#cboPeriodo2').val(), '', FechaInicio, FechaFinal, 'S');
                showGraphArea($('#cboPeriodo2').val(), '', FechaInicio, FechaFinal, 'A');
                showGraphArea($('#cboPeriodo2').val(), '', FechaInicio, FechaFinal, 'H');
                showGraphArea($('#cboPeriodo2').val(), '', FechaInicio, FechaFinal, 'C');
                showGraphArea($('#cboPeriodo2').val(), '', FechaInicio, FechaFinal, 'P');
                //getListHE(Get_Planilla_Find(), Get_Periodo_Find(), Get_Localidad_Find(), $('#cboPersonal').val());

            });

        });
    </script>
    <style type="text/css">
  #chart-container {
    width: 50%;
    height: 50%;
    float: left;
    position: relative; 
  
        }
    #chart-container1 {
    width: 50%;
    height: 50%;
    float: right;
    position: relative;
   
        }
     #chart-container2 {
       width: 50%;
    height: 50%;
    float: left;
    position: relative; 
  
        }
        #chart-container3 {
    width: 50%;
    height: 50%;
    float: right;
    position: relative;
 
        }

            #chart-container01 {
       width: 50%;
    height: 50%;
    float: left;
    position: relative; 
  
        }
                #chart-container02 {
       width: 50%;
    height: 50%;
    float: right;
    position: relative; 
  
        }
                    #chart-container03 {
       width: 50%;
    height: 50%;
    float: left;
    position: relative; 
  
        }

          #chart-container4 {
    width: 50%;
    height: 50%;
    float: left;
    position: relative; 
  
        }
    #chart-container5 {
    width: 50%;
    height: 50%;
    float: right;
    position: relative;
   
        }
     #chart-container6 {
       width: 50%;
    height: 50%;
    float: left;
    position: relative; 
  
        }

               #chart-container04 {
    width: 50%;
    height: 50%;
    float: left;
    position: relative; 
  
        }
    #chart-container05 {
    width: 50%;
    height: 50%;
    float: right;
    position: relative;
   
        }
     #chart-container06 {
       width: 50%;
    height: 50%;
    float: left;
    position: relative; 
  
        }

        #chart-container7 {
    width: 50%;
    height: 50%;
    float: right;
    position: relative;
 
        }

     #chart-container8 {
    width: 50%;
    height: 50%;
    float: left;
    position: relative; 
  
        }
    #chart-container9 {
    width: 50%;
    height: 50%;
    float: right;
    position: relative;
   
        }
     #chart-container10 {
       width: 50%;
    height: 50%;
    float: left;
    position: relative; 
  
        }
        #chart-container11 {
    width: 50%;
    height: 50%;
    float: right;
    position: relative;
 
        }


             #chart-container08 {
    width: 50%;
    height: 50%;
    float: left;
    position: relative; 
  
        }
    #chart-container09 {
    width: 50%;
    height: 50%;
    float: right;
    position: relative;
   
        }
     #chart-container010 {
       width: 50%;
    height: 50%;
    float: left;
    position: relative; 
  
        }



    </style>

</asp:Content>
