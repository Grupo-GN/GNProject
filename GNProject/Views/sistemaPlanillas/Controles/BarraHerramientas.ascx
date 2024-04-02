<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BarraHerramientas.ascx.cs" Inherits="Controles_BarraHerramientas" %>
<link href="miEstilo.css" rel="Stylesheet" type="text/css" />
<style type="text/css"> 
  .btn_Imagen
 {
     background:transparent url(../imagesSesion/login-btn.png) top left no-repeat;
 }
</style> 

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
        CssClass="elBotonUpdate" Enabled="false"/>
        </td>
        <td>
            <asp:Button ID="btnDelete" runat="server" Text="Eliminar" 
            CssClass="elBotonDelete" Enabled="false"/>
        </td>
    </tr>
    </table>
</asp:Panel>