<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmGenerarAsientos.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Procesos.FrmGenerarAsientos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />

    <link href="../Styles/nuevoEstiloPlanilla.css" rel="stylesheet" type="text/css" />

    <fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px;/*border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black;*/min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; /*border-top: solid 1px black;*/">
        
        <input type="hidden" id="empresaSession" value="<%= Session["EmpresaPlanilla"] %>" />
        <input type="hidden" id="periodoSession" value="<%= Session["PeriodoPlanilla"] %>" />
        <input type="hidden" id="planillaSession" value="<%= Session["planillaPlanilla"] %>" />
        <input type="hidden" id="anioSession" value="<%= Session["anioPlanilla"] %>" /><br />
    <br />
    <label class="miTitulo">GENERAR ASIENTOS - EXCEL</label>
        <table style="border-collapse:collapse;width:100%;">
            <tr>
                <td style="width:150px;"><label class="miLabel">Seleccione el Asiento: </label></td>
                <td>
                    <select id="cboAsiento"></select>                    
                </td>
                <td><input id="btnGenerar" type="button" value="Generar" class="submit" /></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
            </tr>
        </table>
        <div id="divError"></div>
    </fieldset>
    <script src="../JQuery/jquery-1.10.1.min.js" type="text/javascript"></script>
    <script src="Scripts/Script_GenerarAsientos.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(initilize);
    </script>
</asp:Content>

