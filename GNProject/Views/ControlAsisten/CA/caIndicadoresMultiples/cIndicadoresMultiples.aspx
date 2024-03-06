<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cIndicadoresMultiples.aspx.cs" Inherits="GNProject.Views.ControlAsisten.CA.caIndicadoresMultiples.cIndicadoresMultiples" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />
    <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"
        type="text/css" />
  <style>

  
  #lbDimen,#lbDimenProcesar,#lbSum,#lbSumProcesar
  {
      list-style-type: none;
      width:230px;
      border:1px solid #737373;
      float: left;
      margin: 0;
      padding: 0;
      height:300px;
      overflow-x:hidden;
      overflow-y:auto;
      }
      #lbDimen li,#lbDimenProcesar li,#lbSum li,#lbSumProcesar li
      {
           margin: 5px; padding: 5px; font-size: 12px; width: 89%; 
           cursor:move;
           border:1px solid #d3d3d3;
           background:#e6e6e6;
          }  
          
.listBox
{
          list-style-type: none;
      width:230px;
      border:1px solid #737373;
      float: left;
      margin: 0;
      padding: 0;
      height:200px;
      overflow-x:hidden;
      overflow-y:auto;
    }
  </style>

<label class="miTitulo" >Indicadores Multiples - Control de Asistencia</label><br /><br />
<fieldset>
    <legend class="miTituloField">Generar Indicadores</legend>
    <table class="tableDialog">
        <tr>
            <td><img src="../../Icon/cubo.ico" style="border:none;cursor:pointer;" id="imgOpenDimen" /></td>
            <td><img src="../../Icon/suma.ico" style="border:none;cursor:pointer;" id="imgOpenSum"  /></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td><label class="miLabel">Seleccionar Dimensiones</label></td>
            <td><label class="miLabel">Seleccionar Conceptos a Calcular</label></td>
            <td style="text-align:right;"><label class="miLabel">Fecha Inicio : </label></td>
            <td><input type="text" class="txt" id="txtFechaInicio" /></td>
            <td style="text-align:right;"><label class="miLabel">Fecha Final : </label></td>
            <td><input type="text" class="txt" id="txtFechaFinal" /></td>
            <td></td>
        </tr>
    </table>
</fieldset>
<input type="button" class="buttonHer" value="GENERAR" id="btnGenerar"/>

<table class="table" id="tablaIndiceMultiple">
    <thead id="theadReport">        
    </thead>
    <tbody id="tbodyReport"></tbody>
</table>

  <section id="chartContainer" style="height: 300px; width: 100%;">
  </section>

<section title="Dimensiones" id="dialog-Dimensiones">
    <table class="tableDialog">
        <tr>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>
                <ul id="lbDimen"  class="droptrue">
  
                </ul>
            </td>
            <td>>></td>
            <td>
                <ul id="lbDimenProcesar" class="droptrue">
                
                </ul>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="text-align:center;"><input type="button" class="submit" value="Listo" /> </td>
        </tr>
    </table>
</section>

<section title="Dimensiones" id="dialog-Sum">
    <table class="tableDialog">
        <tr>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>
                <ul id="lbSum"  class="droptrue">
  
                </ul>
            </td>
            <td>>></td>
            <td>
                <ul id="lbSumProcesar" class="droptrue">
                    
                </ul>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="text-align:center;"><input type="button" class="submit" value="Listo" /> </td>
        </tr>
    </table>
</section>

<section id="dialog-FiltrosDimen" title="Filtros Para las Dimenesiones">
    <table class="tableDialog">
        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>
                <ul class="listBox" id="lbFiltrosDim">
                    <li><input type="checkbox" /><label>PLANILLA</label></li>
                    <li><input type="checkbox" /><label>PLANILLA</label></li>
                </ul>
            </td>
            <td style="vertical-align:top;">
                <section style="width:100%;height:100%;vertical-align:top;">
                    <table class="tableDialog" style="vertical-align:top;height:100%;">
                        <tbody id="tbodyFiltrosDim">
                            <tr>
                                <td></td>
                                <td></td>
                            </tr>
                        </tbody>

                    </table>
                </section>
            </td>
            
        </tr>
        <tr>
            <td></td>
            <td></td>

        </tr>
    </table>
</section>

    <script src="../../jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../jqueryui/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="Script_IndicadoresMultiples.js" type="text/javascript"></script>
    <script src="../../jsCanvas1.3/canvasjs.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var DimenSelec = [];
        var DimenFiltros = [];
        $(document).ready(function () {
            $('#dialog-Dimensiones').hide();
            $('#dialog-FiltrosDimen').hide();
            $('#dialog-Sum').hide();
            $("ul.droptrue").sortable({
                connectWith: "ul"
            });
            CrearCuadroFechas();
            Get_Dimensiones();
            Get_SumaCamposCA();


            $('#imgOpenDimen').click(function () {
                open_DialogDimensiones();
            });
            $('#imgOpenSum').click(function () {
                open_DialogSuma();
            });


            $('#btnFiltrosDimen').click(function () {
                open_DialogFiltrosDimen();
                DimenSelec = [];
                $('#lbDimenProcesar li').each(function () {
                    DimenSelec.push({ cod: this.id, Desc: $(this).html() });
                });
                CargarDimensionesFiltros();
            });


            $('#lbFiltrosDim').on('click', 'input[type="checkbox"]', function () {
                if ($(this).prop('checked') == true) {
                    CargarFiltro_By_Dimension(this.id);
                } else {
                    RemoveFiltro(this.id);
                }
            });

            $('#btnGenerar').click(function () {
                GenerarReportedeIndicesMultiples();

            });

        });
    </script>

</asp:Content>
