<%@ Page Language="C#"MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="LoginPortal.aspx.cs" Inherits="GNProject.Views.portal.Login.LoginPortal"UnobtrusiveValidationMode="None" %>


<%@ Import Namespace="GNProject.Acceso.App_code_portal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<title>.::<%=Parametros.I_NombreProyecto %> <%=Parametros.I_NombreEmpresa %>::.</title>
    <link href="/Assets/Css/PortalCss/Estilo.css" rel="stylesheet" type="text/css" />
    <link href="/Assets/Css/PortalCss/NewStyle.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/Portal/Validaciones.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="/Scripts/Portal/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="/Scripts/Portal/jquery-1.11.1-ui.min.js"></script>
    <link href="/Assets/Css/PortalCss/JqGrid/jquery-ui.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            background-image: url(img/fondo_login.jpg);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div id="form1" runat="server">
    <center>
        <div class="div_login">
            <div class="div_form_login roundframe">
                <table class="form_login" cellpadding="3px">
                    <tr>
                        <td>
                            Usuario:
                        </td>
                        <td>
                            <asp:TextBox ID="txtUsuario" runat="server" CssClass="input_login"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsuario"
                                ErrorMessage="*">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Contraseña:
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="input_login"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                                ErrorMessage="*">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align:center; ">
                            <asp:Button class="EstiloGeneralBoton btn-ingresar" ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblMsj" runat="server" Text="" ForeColor="Red"></asp:Label>
                            <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
                <div style="text-align:right;padding: 30px 20px 0 0;">
                    <a class="linkWeb" href="http://www.gestiondenegociosrs.com.pe" target="_blank">Desarrollado por: Gestión de Negocios S.A.C.</a>
                </div>
            </div>
        </div>
    </center>
    </div>
    <script type="text/javascript" language="javascript">
        $("#<%=btnIngresar.ClientID %>").button();
    </script>
</asp:Content>
