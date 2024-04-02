<%@ Page Language="C#" MasterPageFile="~/Master/MasterModales.master" AutoEventWireup="true" CodeFile="PruebaControl.aspx.cs" Inherits="Controles_PruebaControl" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<link href="miEstilo.css" type="text/css" rel="Stylesheet" />

<asp:Panel ID="Panel1" runat="server" CssClass="elPanel">
    <table>
    <tr>
    <td>
        <asp:Button ID="btnNew" runat="server" Text="Nuevo" 
        CssClass="elBotonNew" Enabled="true"/></td>
    <td>
        <asp:Button ID="btnAdd" runat="server" Text="Grabar" 
        CssClass="elBotonAdd" Enabled="false"/>
    </td>
    <td>
        <asp:Button ID="btnCancel" runat="server" Text="Cancelar" 
        CssClass="elBotonCancel" Enabled="false"/></td>
    <td>
        <asp:Button ID="btnUpdate" runat="server" Text="Modificar" 
        CssClass="elBotonUpdate" Enabled="false"/></td>
        <td>
            <asp:Button ID="btnDelete" runat="server" Text="Eliminar" 
            CssClass="elBotonDelete" Enabled="false"/>
        </td>
    </tr>
    </table>
</asp:Panel>

</asp:Content>

