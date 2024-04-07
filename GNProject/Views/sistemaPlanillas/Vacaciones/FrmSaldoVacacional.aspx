<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="FrmSaldoVacacional.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Vacaciones.FrmSaldoVacacional" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="100%">
        <tr>
            <td style="width: 50%">
                <asp:Label ID="Label1" runat="server" Text="SALDO VACACIONAL" CssClass="title"></asp:Label></td>
            <td style="text-align: right;">
                <asp:Button ID="btnBuscar" runat="server" CssClass="button" Text="Buscar" OnClick="btnBuscar_Click" ValidationGroup="ValidaFiltros" />
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
                    <td class="miLabel">Area:
                    </td>
                    <td>
                        <asp:DropDownList ID="cboCategoria_Auxiliar" runat="server" CssClass="ddl" Width="200px">
                        </asp:DropDownList>
                    </td>
                    <td class="miLabel">Fecha a Procesar:
                    </td>
                    <td>
                        <asp:TextBox ID="txtFechaProceso" runat="server" CssClass="textbox"
                            Width="70px" MaxLength="10"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtFechaProceso_CalendarExtender" runat="server"
                            Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaProceso" CssClass="calendar_Theme1">
                        </cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="txtFechaProceso" ErrorMessage="*" ValidationGroup="ValidaFiltros">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <br />
            <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" ForeColor="DarkOrange"></asp:Label>
            <div style="overflow: auto; width: 100%; max-height: 400px;max-width:1000px;">
                <asp:GridView ID="grvBandeja" runat="server"
                    AutoGenerateColumns="False" CellPadding="2" CssClass="gridSmall"
                    GridLines="None"
                    OnRowDataBound="grvBandeja_RowDataBound"
                    ShowFooter="True"
                    Width="100%">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="Personal_Id" HeaderText="Codigo" Visible="False" />
                        <asp:BoundField DataField="Nombres" HeaderText="Nombres" >
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FechaIngreso" HeaderText="F. Ingreso" DataFormatString="{0:dd/MM/yyyy}"/>
                        <asp:BoundField DataField="DerechoVac" HeaderText="Derecho Vac.">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DiasTomados" HeaderText="Dias Tomados">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DiasSaldo" HeaderText="Dias Saldo">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DiasTruncas" DataFormatString="{0:N2}" 
                            HeaderText="Dias Truncas">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TotalVacacion" DataFormatString="{0:N2}" HeaderText="Tot. Vacacion">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Indemnizacion" HeaderText="Indemnizacion">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Cancelados" HeaderText="Dias Indemnizacion Cancelado">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Diferencia" HeaderText="Saldo Indemnizacion">
                            <ItemStyle HorizontalAlign="Center" />    
                        </asp:BoundField>                        
                        <asp:BoundField DataField="Enero" HeaderText="Enero" 
                            DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="Febrero" HeaderText="Febrero" 
                            DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="Marzo" HeaderText="Marzo" 
                            DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="Abril" HeaderText="Abril" 
                            DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="Mayo" HeaderText="Mayo" 
                            DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="Junio" HeaderText="Junio" 
                            DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="Julio" HeaderText="Julio" 
                            DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="Agosto" HeaderText="Agosto" 
                            DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="Setiembre" HeaderText="Setiembre" 
                            DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="Octubre" HeaderText="Octubre" 
                            DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="Noviembre" HeaderText="Noviembre" 
                            DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="Diciembre" HeaderText="Diciembre" 
                            DataFormatString="{0:N2}" />
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
