<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmCtaCompania.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Mantenimientos.FrmCtaCompania" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />
    <link href="../Controles/miEstilo.css" rel="stylesheet" type="text/css" />

<fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px;border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black; min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; border-top: solid 1px black;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <table width="100%">
                <tr>
                    <td style="width:50%;" valign="middle"><asp:Label ID="Label20" runat="server" Text="Cta. Bancaria por Compañia" CssClass="miTitulo" Width="300px"></asp:Label>
                        <asp:HiddenField ID="CodigoCta" runat="server" />
                    </td>
                    <td style="width:50%;" align="right" valign="bottom">
                        <asp:Panel ID="Panel1" runat="server" CssClass="elPanel">
                            <table>
                                <tr>
                                    <td><asp:Button ID="btnNew" runat="server" Text="Nuevo" CssClass="elBotonNew" 
                                            ToolTip="Para Agregar un Nuevo Registro" onclick="btnNew_Click"/></td>
                                    <td><asp:Button ID="btnAdd" runat="server" Text="Grabar" CssClass="elBotonAdd" 
                                            Enabled="false" OnClientClick="return confirm('¿Está seguro(a) de registrar la información?');"  
                                            ToolTip="Para Grabar un Nuevo Registro" onclick="btnAdd_Click"/></td>
                                    <td><asp:Button ID="btnCancel" runat="server" Text="Cancelar" 
                                            CssClass="elBotonCancel" Enabled="false" ToolTip="Para Cancelar la Informacion" 
                                            onclick="btnCancel_Click"/></td>
                                    <td><asp:Button ID="btnUpdate" runat="server" Text="Actualizar" CssClass="elBotonUpdate" Enabled="false" onclick="btnUpdate_Click" ToolTip="Para Modificar el Registro" OnClientClick="return confirm('¿Está seguro(a) de actualizar la información?');"  /></td>
                                    <td><asp:Button ID="btnDelete" runat="server" Text="Eliminar" CssClass="elBotonDelete" Enabled="false"/></td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>

            <cc1:TabContainer ID="TabGeneral" Width="100%" runat="server" 
                ActiveTabIndex="1" Height="380">
                <cc1:TabPanel ID="TabDetalle" runat="server" HeaderText="Cuentas"><ContentTemplate>
                <asp:GridView ID="dgvdetalle" runat="server" AutoGenerateColumns="False" CssClass="gridSmall" Width="100%">
                    <Columns>
                        <asp:TemplateField>
                        <ItemTemplate><asp:ImageButton ID="btnEdit" runat="server" ToolTip="Editar" 
                                CommandName="Select" ImageUrl="~/Views/sistemaPlanillas/Icon/Modify.gif" Width="15px" 
                                CommandArgument='<%# Eval("Codigo") %>'
                                onclick="btnEdit_Click"/></ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                        <asp:BoundField DataField="Banco" HeaderText="Banco" />
                        <asp:BoundField DataField="Moneda" HeaderText="Moneda"><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                        <asp:BoundField DataField="NroCta" HeaderText="Nro. Cta"><ItemStyle HorizontalAlign="Center" /></asp:BoundField></Columns></asp:GridView></ContentTemplate></cc1:TabPanel>
                <cc1:TabPanel ID="TabMant" runat="server" HeaderText="Mant. Cuentas">
                    <ContentTemplate>
                        <table style="width:100%;border-collapse:collapse;">
                            <tr>
                                <td style="text-align:right;">Banco: </td>
                                <td>
                                    <asp:DropDownList ID="cboBanco" runat="server" CssClass="miComboBox" Width="250px">
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                           <tr>
                                <td style="text-align:right;">Moneda: </td>
                                <td>
                                    <asp:DropDownList ID="cboMoneda" runat="server" CssClass="miComboBox" Width="150px">
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                           <tr>
                                <td style="text-align:right;">Nro Cuenta: </td>
                                <td>
                                    <asp:TextBox ID="txtnrocta" runat="server" Width="150px" MaxLength="50"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </cc1:TabPanel>
            </cc1:TabContainer>


        </ContentTemplate>
    </asp:UpdatePanel>

</fieldset>

</asp:Content>

