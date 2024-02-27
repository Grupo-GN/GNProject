<%@ Page ValidateRequest="false" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MantContenidos.aspx.cs" Inherits="GNProject.Views.portal.Mantenimientos.MantContenidos" UnobtrusiveValidationMode="None"  %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/Assets/Css/PortalCss/Estilo.css" rel="stylesheet" type="text/css" />
    <link href="/Assets/Css/PortalCss/Menu.css" rel="stylesheet" type="text/css" />
    <link href="/Assets/Css/PortalCss/JqGrid/ui.jqgrid.css" rel="stylesheet" type="text/css" />
    <link href="/Assets/Css/PortalCss/JqGrid/jquery-ui.css" rel="stylesheet" type="text/css" />    
    <script language="javascript">window.$q = []; window.$ = window.jQuery = function (a) { window.$q.push(a); };</script>
    <script type="text/javascript" src="/Scripts/Portal/Funciones.min.js"></script>
    <script type="text/javascript" src="/Scripts/Portal/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="/Scripts/Portal/jquery-1.11.1-ui.min.js"></script>
    <!--[if IE 7]> <script type="text/javascript" src="../js/jqGrid-4.5.2/jsonIE7.js"></script> <![endif]-->
    <script type="text/javascript" src="/Scripts/Portal/jqGrid-4.5.2/grid.locale-en.min.js"></script>
    <script type="text/javascript" src="/Scripts/Portal/jqGrid-4.5.2/jquery.jqGrid.src.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="updBotones" runat="server">
        <ContentTemplate>
            <p style="text-align: center;">
                <asp:Label ID="lblMensaje" Font-Bold="true" runat="server" Text=""></asp:Label>
            </p>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="title">
        Mantenimiento de Contenidos</div>
    <br />
    <div id="Tab1">
        <div>
            <asp:UpdatePanel ID="updTab1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="Row1">
                        <div class="col1 fl ar mgl10 pdt5">
                            Categoría:</div>
                        <div class="fl mgl10 pdt5">
                            <asp:DropDownList ID="cboContenido" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cboContenido_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="cboContenido"
                                InitialValue="-Seleccione-" runat="server" ErrorMessage="*" ValidationGroup="Valida"></asp:RequiredFieldValidator>
                        </div>
                        <div class="Clear">
                        </div>
                    </div>
                    <div class="Row1">
                        <div class="col1 fl ar mgl10 pdt5">
                            Descripción:</div>
                        <div class="fl mgl10 pdt5">
                            <asp:TextBox ID="txtDescripcion" TextMode="MultiLine" Width="400px" Height="200px"
                                runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtDescripcion"
                                runat="server" ErrorMessage="*" ValidationGroup="Valida"></asp:RequiredFieldValidator>
                        </div>
                        <div class="Clear">
                        </div>
                    </div>
                    <div class="Row1">
                        <div class="col1 fl ar mgl10 pdt5">
                            Imagen:</div>
                        <div class="fl mgl10 pdt5">
                            <asp:FileUpload ID="FileUploadFoto" runat="server" />
                        </div>
                        <div class="Clear">
                        </div>
                    </div>
                    <div class="Row1">
                        <div class="col1 fl ar mgl10 pdt5">
                            <asp:Button ID="btnSubirFoto" runat="server" Text="Subir Imagen"
                                OnClick="btnSubirFoto_Click" />
                            <asp:Label ID="lblNombreFoto" runat="server" Visible="false"></asp:Label>
                            <p style="display: block; text-align: right; padding: 3px 0px; margin: 0px;">
                                <asp:Button ID="btnEliminarFoto" runat="server" Text="Eliminar Imagen"
                                    OnClick="btnEliminarFoto_Click" />
                            </p>
                        </div>
                        <div class="fl mgl10 pdt5">
                            <asp:Image ID="imgFoto" runat="server" Width="90" Height="100px" /></div>
                        <div class="Clear">
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnSubirFoto" />
                </Triggers>
            </asp:UpdatePanel>
            <p>
                <asp:Button ID="btnUpdate" class="button" runat="server" Text="Actualizar" ValidationGroup="Valida"
                    OnClick="btnUpdate_Click" />
            </p>
        </div>
    </div>
</asp:Content>