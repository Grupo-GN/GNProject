<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ReporteIncidencias.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.ReportesyConsultas.ReporteIncidencias" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />
    <link href="../Controles/miEstilo.css" rel="stylesheet" type="text/css" />
    <link href="../jqueriUI/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet" type="text/css" />
    <link href="../css/StyleWilder.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/nuevoEstiloPlanilla.css" rel="stylesheet" type="text/css" />
    <fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px; /*border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black;*/ min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; /*border-top: solid 1px black;*/">
        <input type="hidden" id="empresaSession" value="<%= Session["EmpresaPlanilla"] %>" />
        <input type="hidden" id="periodoSession" value="<%= Session["PeriodoPlanilla"] %>" />
        <input type="hidden" id="planillaSession" value="<%= Session["planillaPlanilla"] %>" />
        <input type="hidden" id="anioSession" value="<%= Session["anioPlanilla"] %>" />
        <label class="miTitulo">REPORTE DE CAMBIO DE INFORMACIÓN</label>
        <br /><br />
        <table style="width:100%;border-collapse:collapse;">
            <tr>
                <td style="width:100px;">LOCALIDAD: </td>
                <td><select class="ddl" id="cboLocalidad"></select></td>
                <td style="width:100px;">PROYECTO: </td>
                <td><select class="ddl" id="cboProyecto"></select></td>
            </tr>
            <tr>
                <td>ÁREA: </td>
                <td><select class="ddl" id="cboArea"></select></td>
                <td>PERSONAL: </td>
                <td><select class="ddl" id="cboPersonal"></select></td>
            </tr>
            <tr>
                <td><input type="button" id="btnBuscar" value="Buscar" class="submit" /></td>
                <td><input type="button" id="btnDescargar" value="Descargar" class="submit" /></td>
                <td><img src="../Imgs/62163.gif" width="50px" id="imgCargando" style="display:none;" /><label id="lblprogreso" class="miLabelError" style="font-size:14px;"></label></td>
                <td></td>
            </tr>
        </table>
        <hr />
        <table class="gridSmall" style="width:100%;">
            <thead>
                <tr>
                    <th>PERSONAL</th>
                    <th>LOCALIDAD</th>
                    <th>AREA</th>
                    <th>PROYECTO</th>
                    <th style="min-width:80px;">FECHA</th>
                    <th style="min-width:80px;">USUARIO</th>
                    <th>CONCEPTO</th>
                    <th>VALOR ANTERIOR</th>
                    <th>VALOR ACTUAL</th>
                </tr>
            </thead>
            <tbody id="tbodydata"></tbody>
        </table>
    </fieldset>
    <script src="../JQuery/jquery-1.10.1.min.js" type="text/javascript"></script>
    <script src="scripts/ScriptReporteIncidencias.js"></script>
        <script type="text/javascript">
            $(document).ready(initilize);
        </script>
</asp:Content>

