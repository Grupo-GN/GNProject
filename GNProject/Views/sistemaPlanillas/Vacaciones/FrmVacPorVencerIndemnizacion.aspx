<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmVacPorVencerIndemnizacion.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Vacaciones.FrmVacPorVencerIndemnizacion" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table width="100%">
        <tr>
            <td style="width: 50%">
                <asp:Label ID="Label1" runat="server" Text="VACACIONES POR VENCER E INDEMNIZACIONES" CssClass="title"></asp:Label></td>
            <td style="text-align: right;">
                <asp:Button ID="btnBuscar" runat="server" CssClass="button" Text="Buscar" OnClick="btnBuscar_Click" ValidationGroup="ValidaFiltros" />
                &nbsp;
                <asp:Button ID="btnExportar" runat="server" CssClass="button" Text="Exportar" OnClick="btnExportar_Click" ValidationGroup="ValidaFiltros" />
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td class="miLabel">Localidad:
                    </td>
                    <td>
                        <asp:DropDownList ID="cboLocalidad" runat="server" CssClass="ddl" Width="200px">
                        </asp:DropDownList>
                    </td>
                    <td class="miLabel">
                        Area:
                    </td>
                    <td>
                        <asp:DropDownList ID="cboCategoria_Auxiliar" runat="server" CssClass="ddl" Width="200px">
                        </asp:DropDownList>
                    </td>
                    <td class="miLabel">Fecha Final:
                    </td>
                    <td>
                        <asp:TextBox ID="txtFechaFin_Desde" runat="server" CssClass="textbox"
                            Width="70px" MaxLength="10"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtFechaFin_Desde_CalendarExtender" runat="server"
                            Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaFin_Desde" CssClass="calendar_Theme1">
                        </cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="txtFechaFin_Desde" ErrorMessage="*" ValidationGroup="ValidaFiltros">
                        </asp:RequiredFieldValidator>
                        a
                        <asp:TextBox ID="txtFechaFin_Hasta" runat="server" CssClass="textbox"
                            Width="70px" MaxLength="10"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtFechaFin_Hasta_CalendarExtender" runat="server"
                            Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaFin_Hasta" CssClass="calendar_Theme1">
                        </cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="txtFechaFin_Hasta" ErrorMessage="*" ValidationGroup="ValidaFiltros">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <br />
            <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" ForeColor="DarkOrange"></asp:Label>
            <div style="overflow: auto; width: 100%;max-height:400px;">
                <asp:GridView ID="grvBandeja" runat="server"
                    AutoGenerateColumns="False" CellPadding="2" CssClass="gridSmall"
                    GridLines="None"
                    Width="100%">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="Nombres" HeaderText="NOMBRES">
                            <ItemStyle HorizontalAlign="Left" Width="250px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Localidad" HeaderText="LOCALIDAD">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Area" HeaderText="AREA" />
                        <asp:BoundField DataField="Cargo" HeaderText="CARGO">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Fecha_Ingreso" HeaderText="FEC. INGRESO" />
                        <asp:BoundField DataField="PeriodoIni" HeaderText="INICIO DE PERIODO"></asp:BoundField>
                        <asp:BoundField DataField="PeriodoFin" HeaderText="FIN DE PERIODO"></asp:BoundField>
                        <asp:BoundField DataField="Dias_Pagados_Saldo" HeaderText="DIAS VACACIONES"></asp:BoundField>
                        <asp:BoundField DataField="PeriodoIniProximo" HeaderText="PRÓXIMO PERIODO INICIO"></asp:BoundField>
                        <asp:BoundField DataField="PeriodoFinProximo" HeaderText="PRÓXIMO PERIODO FIN"></asp:BoundField>
                        <asp:BoundField DataField="GeneraIndemnizacion" HeaderText="GENERA INDEMNIZACIÓN"></asp:BoundField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="#336699" Font-Size="X-Small" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                </asp:GridView>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
        DisplayAfter="1">
        <ProgressTemplate>
            <div class="UpdateProgressModalBackground"></div>
            <center>
                <div class="UpdateProgressPanel">
                    Cargando...<br />
                    <br />
                    <asp:Image ID="Image2" runat="server"
                        alt="Procesando" ImageUrl="~/Views/sistemaPlanillas/css/ajax-loader.gif" />
                </div>
            </center>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
