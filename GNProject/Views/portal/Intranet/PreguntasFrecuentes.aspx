<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PreguntasFrecuentes.aspx.cs" Inherits="GNProject.Views.portal.Intranet.PreguntasFrecuentes" %>

<%@ Import Namespace="GNProject.Acceso.App_code_portal" %>
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
    <br />
    <div class="title">
        <label id="lblTitle">Preguntas Frecuentes</label></div>
    <br />
    <div id="Tab1">
        <div>
            <asp:TreeView ID="TreeViewFaq" runat="server" NodeWrap="True">
            </asp:TreeView>
            <asp:Label ID="lblMsjFaq" runat="server" Visible="false" Text="No Se Encontraron Datos."></asp:Label>
        </div>
    </div>
    <div id="Tab2">
        <p style="text-align: right;">
            <a href="#" onclick='javascript:history.back(1);'>Volver</a>
        </p>
        <hr />
        <div style="clear: right; width: 550px">
            <table style="width:100%;">
                <tr>
                    <td class="rowDetalle">Pregunta:</td>
                    <td class="rowDetalleSombra" style="text-align:justify;"><asp:Label Font-Bold="true" ID="lblPregunta" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="rowDetalle">Respuesta:</td>
                    <td class="rowDetalleSombra" style="text-align:justify;"><asp:Label ID="lblRespuesta" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="rowDetalle"><%=Parametros.I_Texto_CategoriaAuxiliar%>:</td>
                    <td class="rowDetalleSombra"><asp:Label ID="lblArea" runat="server"></asp:Label></td>
                </tr>
            </table>
        </div>
    </div>
    <script type="text/javascript">
        this.fn_CargaInicial();
        function fn_CargaInicial() {
            $("#Tab2").hide();
            var id = '<%= Request.QueryString["id"] == null ? "0" : Request.QueryString["id"].ToString() %>';
            if (id != "0") {
                $("#Tab1").hide();
                $("#Tab2").show();
            }
        }
    </script>
</asp:Content>

