<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CambiarClave.aspx.cs" Inherits="GNProject.Views.ControlAsisten.CA.Matenimientos.CambiarClave" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../../jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../jqueryui/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="Scripts/Script_CAAsignarCodigo.js" type="text/javascript"></script>

    <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />

    <label class="miTitulo">CAMBIAR CONTRASEÑA</label>
    <br />
    <br />
    <table class="tableDialog">
        <tr>
            <td style="width:250px;text-align:right;">Sus credenciales seran enviadas al siguiente correo:</td>
            <td style="vertical-align:bottom;"><asp:Label runat="server" ID="lblemail" CssClass="miLabel"></asp:Label></td>
        </tr>
        <tr>
            <td style="text-align:right;">Contraseña Actual:</td>
            <td><input type="password" id="txtContraseña" required placeholder="Contraseña" runat="server"></td>
        </tr>
        <tr>
            <td style="text-align:right;">Nueva Contraseña:</td>
            <td><input type="password" id="txtContraseña2" required placeholder="Contraseña" runat="server"></td>
        </tr>
        <tr>
            <td colspan="2">
                <label style="color:Red;" id="lblError" runat="server">&nbsp;</label>
            </td>
        </tr>
        <tr>
            <td colspan="2"><asp:Button ID="btnGrabar" runat="server" Text="Grabar" class="buttonHer" OnClick="btnGrabar_Click" /></td>
        </tr>
    </table>
	    

</asp:Content>
