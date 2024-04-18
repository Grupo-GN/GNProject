<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmGenerarTRegistro.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Procesos.FrmGenerarTRegistro" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/nuevoEstiloPlanilla.css" rel="stylesheet" type="text/css" />

    <fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px;/*border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black*/;min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; /*border-top: solid 1px black;*/">
       <input type="hidden" id="empresaSession" value="<%= Session["EmpresaPlanilla"] %>" />
        <input type="hidden" id="periodoSession" value="<%= Session["PeriodoPlanilla"] %>" />
        <input type="hidden" id="planillaSession" value="<%= Session["planillaPlanilla"] %>" />
        <input type="hidden" id="anioSession" value="<%= Session["anioPlanilla"] %>" />
        <br />
    <br />
        <label class="miTitulo">GENERAR ASIENTOS - EXCEL</label>
            <table style="border-collapse:collapse;width:100%;">
                <tr>
                    <td style="width:150px;"><label class="miLabel">Seleccione el Asiento: </label></td>
                    <td>
                        <asp:DropDownList ID="cboTRegistro" runat="server">
                            <asp:ListItem Value="E4">E-4 DATOS PERSONALES</asp:ListItem>
                            <asp:ListItem Value="E5">E-5 DATOS DEL TRABAJADOR</asp:ListItem>
                            <asp:ListItem Value="E11">E-11 PERIODOS</asp:ListItem>
                            <asp:ListItem Value="E17">E-17 ESTABLECIMIENTOS</asp:ListItem>
                            <asp:ListItem Value="E29">E-29 ESTUDIOS CONCLUIDOS</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <input id="HHcodigos" type="hidden" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnGenerar" runat="server" Text="Generar Excel" CssClass="submit" OnClick="btnGenerar_Click" />
                        &nbsp;&nbsp;
                        <asp:Button ID="btnGenerarTXT" runat="server" Text="Generar Archivo Plano" CssClass="submit" OnClick="btnGenerarTXT_Click" />
                    </td>
                    <td><a target="_blank" href="Files/T-Registro-2 9.xlsm" style="color:Blue;" class="lbl" >Descargar Macro T-Registro</a></td>
                </tr>
            </table>
    <div id="Tab1">
        <fieldset>
            <legend>BUSQUEDA</legend>
            <label class="miLabel">Filtrar Por:</label>
            <select id="cboBusquedaEn" class="ddl" style="width:150px;"> </select>
            <label class="miLabel">Digite la Persona a Buscar:</label>
            <input type="text" class="miTextBox" id="txtBuscar" />&nbsp;</fieldset>
        <div  style="overflow: hidden; width: 100%; border: solid 1px #505050;height: 300px;">
        <table class="gridSmall" style="width:100%;">
            <thead>
                <tr>
                    <th>
                        <asp:CheckBox ID="chktodos" runat="server" />
                        </th>
                    <th>ID</th>
                    <th>AP. PATERNO</th>
                    <th>AP. MATERNO</th>
                    <th>NOMBRES</th>
                    <th>TIPO DOC</th>
                    <th>NRO. DOC</th>
                    <th>F. INGRESO</th>
                    <th>F. INI. CONTRATO</th>
                    <th>F. FIN</th>
                    <th>F. CESE</th>
                    <th>PROYECTO</th>     
                </tr>
            </thead>
            <tbody id="tbodyPersonal" class="tbodyPer">
            
            
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
            
    </div>
            <div id="divError"></div>
        </fieldset>
        <script src="../JQuery/jquery-1.10.1.min.js" type="text/javascript"></script>
        <script src="Scripts/Script_GenerarTRegistro.js" type="text/javascript"></script>
        <script type="text/javascript">
            $(document).ready(initilize);
        </script>
</asp:Content>

