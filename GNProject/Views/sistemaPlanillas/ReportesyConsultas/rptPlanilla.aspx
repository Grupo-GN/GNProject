<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="rptPlanilla.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.ReportesyConsultas.rptPlanilla" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />
    <link href="../Controles/miEstilo.css" rel="stylesheet" type="text/css" />
    <link href="../jqueriUI/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../css/StyleWilder.css" rel="stylesheet" type="text/css" />
    <fieldset style="width:100%; background-color: White; margin: 0px 0px 0px 0px;
           border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black; 
            min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; border-top: solid 1px black;">
    <fieldset>
         <input type="hidden" id="empresaSession" value="<%= Session["EmpresaPlanilla"] %>" />
        <input type="hidden" id="periodoSession" value="<%= Session["PeriodoPlanilla"] %>" />
        <input type="hidden" id="planillaSession" value="<%= Session["planillaPlanilla"] %>" />
        <input type="hidden" id="anioSession" value="<%= Session["anioPlanilla"] %>" />
        <legend>Filtrar</legend>
        <table>
            <tr>
                <td style="text-align:right;width:100px;"><label>Proceso : </label></td>
                <td><select class="miComboBox" id="cboProceso"></select></td>
                <td style="text-align:right;width:100px;"><label>Periodo Inicio : </label></td>
                <td><select class="miComboBox" id="cboPeriodoIni"></select></td>
                <td style="text-align:right;width:100px;"><label>Periodo Final : </label></td>
                <td><select class="miComboBox" id="cboPeriodoFin"></select></td>
                <td>&nbsp;</td>
                <td><input type="button" id="btngenerar" class="submit" value="Generar" style="width:90px;" /></td>
                <td><input type="button" id="btnExcel" class="submit" value="Exportar" style="width:90px;" /></td>
            </tr>
        </table>
    </fieldset>
    <div id="barrprocess" style="display:none;"><img src="../img/loading2.gif"  /></div>
    <fieldset style="width:100%;overflow: auto;max-height:1000px;max-width:110%;">
        <legend>Planilla</legend>
        <div id="divta"></div>
        <div style="width:1000px;overflow: auto;height:450px;">
        <table class="gridSmall" id="tblDatos">
            <thead>
                <tr id="thDatos">
                    <th>Razon_Social</th>
<th>Direccion_cia</th>
<th>RUC</th>
<%--<th>Reg_Patronal</th>--%>
<th>Telefono</th>
<th>Proceso</th>
<th>CCosto_Id</th>
<%--<th>Planilla_Id</th>--%>
<th>TipoTrabajador</th>
<th>Catego</th>
<th>Catego2</th>
<th>Area</th>
<th>Personal_Id</th>
<th>Nombre_Completo</th>
<%--<th>Periodo_Id</th>
<th>Periodo</th>
<th>AnoMes</th>
<th>Cargo_Id</th>
<th>Cargo</th>
<th>AFP_Id</th>
<th>AFP</th>
<th>Fecha_Ingreso</th>
<th>Fecha_Nacimiento</th>
<th>Fecha_Cese</th>
<th>Proceso_Id</th>
<th>Direccion</th>
<th>Tipo_Doc_Id</th>
<th>Nro_Doc</th>
<th>Afp_Cod_Afiliacion</th>
<th>Seguro_Cod</th>
<th>HOR20</th>
<th>HOR35</th>
<th>HORDOB</th>
<th>Fecha_Fin_Contrato</th>
<th>Fecha_Ini_Periodo</th>
<th>Fecha_Fin_Periodo</th>
<th>Concepto_Id1</th>
<th>Valor1</th>
<th>Concepto_Id2</th>
<th>Valor2</th>
<th>Concepto_Id3</th>
<th>Valor3</th>
<th>NroHrsExt</th>
<th>NroHrsExtN</th>
<th>NroHrsExtT</th>
<th>TotHoras</th>
<th>TotHoras1</th>
<th>TotHoras2</th>
<th>TotHoras3</th>
<th>TotDM</th>
<th>TotDMS</th>
<th>FechaINIvaca</th>
<th>FechaFINvaca</th>
<th>PerFecIni</th>
<th>PerFecFin</th>
<th>Sueldo_Mes</th>
<th>Tipo_Cambio</th>
<th>Situacion</th>
<th>Ingresos_Afectos</th>
<th>Ctacte_Saldo</th>
<th>Ctacte_Cuotas</th>
<th>Ctacte_TotalDeuda</th>
<th>Total_Ingresos</th>
<th>Total_Descuentos</th>
<th>Total_Aportes</th>
<th>Total_Netos</th>
<th>Bancos</th>
<th>Cuenta</th>--%>

                </tr>
            </thead>
            <tbody id="tbodyData" class="tbodyPer"></tbody>
        </table>
        </div>
    </fieldset>
</fieldset>
<div id="secError"></div>
    <script src="../JQuery/jquery-1.10.1.min.js" type="text/javascript"></script>
    <script src="scripts/ScriptReportePlanilla.js" type="text/javascript"></script>
    <script src="scripts/Script_ExportExcel.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () { initialize(); });
    </script>
</asp:Content>


