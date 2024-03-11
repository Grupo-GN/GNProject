<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IndicesMultriples.aspx.cs" Inherits="GNProject.Views.Indicendia01.Server.Reportes.IndicesMultriples" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />

<label class="miTitulo">INDICES MULTIPLES</label><br />
<br />
<table class="tableDialog">
    <tr>
        <td><label class="miLabel">Indice X</label></td>
        <td><label class="miLabel">Indice Y</label></td>
        <td></td>
    </tr>
    <tr>
        <td>
            <select id="cboIndicesX" class="cbo">
                <option value="1">Por Localidad</option>
            </select>        
        </td>
        <td>
            <select id="cboIndicesY" class="cbo">
                <option value="1">Por Localidad</option>
            </select> 
        </td>
         <td><input  type="button" class="buttonHer" value="GENERAR" id="btnGenerar" /> <input  type="button" class="buttonHer" value="EXPORTAR" id="btnExportar" /></td>
    </tr>
</table>



<br />
<br />
<table id="tblIndices" style="max-width:100%;max-height:950px; overflow:scroll;">
    <thead id="theadIndices">
        
    </thead>

    <tbody id="tbodyIndices">
    
    </tbody>
</table>
             <div id="chartIndice" style="height: 300px; width: 100%;">
             </div>

<br /><br /><br /><br />
    <script src="../../jquery1.10/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../jsCanvas1.3/canvasjs.min.js" type="text/javascript"></script>
    <script src="../../jsExportExcel/ScriptExportarExcel.js" type="text/javascript"></script>
    <script src="Script_IndicesMultiples.js" type="text/javascript"></script>
<script type="text/javascript">

    $(document).ready(function () {
        Cargar_Ejes();
        Cargar_CboEjeX();
        Cargar_CboEjeY();
        $('#cboIndicesX').change(function () {
            var ejeyVal = $('#cboIndicesY').val();
            if ($(this).val() == ejeyVal) {
                Cargar_CboEjeY();
            }
        });
        $('#cboIndicesY').change(function () {
            var ejexVal = $('#cboIndicesX').val();
            if ($(this).val() == ejexVal) {
                Cargar_CboEjeX();
            }
        });

        $('#btnGenerar').click(function () {
            Generar_IndicesMultriples();


        });


        $('#btnExportar').click(function () {
            exportExcel('tblIndices', 'Indices');
        });
    });
</script>
</asp:Content>
