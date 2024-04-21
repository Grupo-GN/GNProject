<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="GenerarAsientos.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Procesos.GenerarAsientos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
        <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />
    <link href="../jqueriUI/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet" type="text/css" />
    <fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px;border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black;min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; border-top: solid 1px black;">
        <input type="hidden" id="empresaSession" value="<%= Session["EmpresaPlanilla"] %>" />
        <input type="hidden" id="periodoSession" value="<%= Session["PeriodoPlanilla"] %>" />
        <input type="hidden" id="planillaSession" value="<%= Session["planillaPlanilla"] %>" />
        <input type="hidden" id="anioSession" value="<%= Session["anioPlanilla"] %>" />
        <br />
    <br />
    <label class="miTitulo">GENERAR ASIENTOS - EXCEL</label>
        <table style="border-collapse:collapse;width:100%;">
            <tr>
                <td colspan="3"><input id="rbsap" type="radio" value="SAP" checked="checked" name="rbtipos" />SAP&nbsp;&nbsp;
                    <input id="rbStar" type="radio" value="STAR" name="rbtipos" />StarSoft&nbsp;&nbsp;
                    <input id="rbExcel" type="radio" value="EXCEL" name="rbtipos" />General
                    <input id="rbGeneral2" type="radio" value="GENERAL2" name="rbtipos" />Oddo
                    <input id="rbConsisat" type="radio" value="CONSISAT" name="rbtipos" />Consisat
                    <input id="rbTipoGroup" type="radio" value="TIPOGROUP" name="rbtipos" />JPCont
                    <label id="lblDolares" style="display:none;"><input id="chkDolares" type="checkbox" />Importe en Dólares?</label>
                    
                </td>                
            </tr>
            <tr>
                <td style="width:150px;"><label class="miLabel">Seleccione el Asiento: </label></td>
                <td>
                    <select id="cboAsiento"></select>                    
                </td>
                <td><input id="btnGenerarDet" type="button" value="Ver Detalle" class="submit" /> &nbsp;&nbsp;&nbsp;<input id="btnGenerar" type="button" value="Generar" class="submit" />&nbsp;&nbsp;&nbsp;<input id="btnGuardarAsiento" type="button" value="Guardar Asiento" class="submit" /></td>
            </tr>
            <tr> 
                <td colspan="3"><label class="miTitulo">Conceptos no configurados en el Asiento</label></td>                
            </tr>
            <tr>
                <td colspan="3">
                    <div id="TabContainer" style="height:415px;width:100%;">
                        <ul>
                            <li><a href="#Tab1">Conceptos No Configurados</a></li>
                            <li><a href="#Tab2">Asientos</a></li>
                            <li><a href="#Tab3">Asientos Detallados</a></li>
                        </ul>
                        <div id="Tab1">
                            <table class="gridSmall" style="width:100%;">
                                <thead>
                                    <tr>
                                        <th>ID</th>
                                        <th>CONCEPTO</th>
                                        <th>DETALLE</th>
                                        <th>VALOR</th>
                                    </tr>
                                </thead>
                                <tbody id="tbodyConcepto" class="tbodyPer">
            
            
                                </tbody>
                            </table>
                        </div>
                        <div id="Tab2"></div>
                        <div id="Tab3"></div>
                    </div>

                </td>
            </tr>
        </table>
        <div id="divError"></div>
    </fieldset>
    <script src="../JQuery/jquery-1.10.1.min.js" type="text/javascript"></script>
    <script src="../jqueriUI/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="Scripts/Script_GenerarAsientosGroup.js?v0.12" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(initilize);
    </script>
</asp:Content>

