<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucFiltros.ascx.cs" Inherits="GNProject.ucFiltros" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <fieldset style="/*border: solid 1px #2f2b2b;*/ background-color: White; border-radius: 8px 8px 8px 8px;
            padding: -3px 0 0 0; margin-top: -2px;">
            <table align="center" cellspacing="0" cellpadding="0" style="padding: 7px 0px 0 15px;"
                width="100%">
                <tr>
                    <td style="font-weight: bold; width: 280px;">
                        <asp:Label ID="Label1" runat="server" Text="Empresa" CssClass="titulocontrolUser"></asp:Label>
                    </td>
                    <td style="font-weight: bold; width: 200px;">
                        <asp:Label ID="Label2" runat="server" Text="Planilla" CssClass="titulocontrolUser"></asp:Label>
                    </td>
                    <td style="font-weight: bold; width: 150px;">
                        <asp:Label ID="Label3" runat="server" Text="Ejercicio" CssClass="titulocontrolUser"></asp:Label>
                    </td>
                    <td style="font-weight: bold; width: 150px;">
                        <asp:Label ID="Label5" runat="server" Text="Mes" CssClass="titulocontrolUser"></asp:Label>
                    </td>
                    <td style="font-weight: bold; width: 150px;">
                        <asp:Label ID="Label4" runat="server" Text="Periodo" CssClass="titulocontrolUser"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="cboEmpresa" runat="server" Width="270px" CssClass="ddl" AutoPostBack="True"
                            OnSelectedIndexChanged="cboEmpresa_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="cboPlanilla" runat="server" Width="200px" CssClass="ddl" AutoPostBack="True"
                            OnSelectedIndexChanged="cboPlanilla_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="cboEjercicio" runat="server" Width="150px" CssClass="ddl" AutoPostBack="True"
                            OnSelectedIndexChanged="cboEjercicio_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="cboMes" runat="server" Width="150px" CssClass="ddl" AutoPostBack="True"
                            OnSelectedIndexChanged="cboMes_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="cboPeriodo" runat="server" Width="150px" CssClass="ddl" AutoPostBack="True"
                            OnSelectedIndexChanged="cboPeriodo_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </fieldset>
    </ContentTemplate>
    <%--                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="cboPlanilla" 
                        EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="cboEjercicio" 
                        EventName="SelectedIndexChanged" />
                </Triggers>--%>
</asp:UpdatePanel>
<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
    DisplayAfter="1">
    <ProgressTemplate>
        <div class="UpdateProgressModalBackground">
        </div>
        <center>
            <div class="UpdateProgressPanel">
                Cargando...<br />
                <br />
                <asp:Image ID="Image2" runat="server" alt="Procesando" ImageUrl="~/Views/sistemaPlanillas/css/ajax-loader.gif" />
            </div>
        </center>
    </ProgressTemplate>
</asp:UpdateProgress>
