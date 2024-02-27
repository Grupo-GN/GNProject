<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReservSalas.aspx.cs" Inherits="GNProject.Views.portal.Intranet.ReservSalas" %>

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
    <asp:UpdatePanel ID="updBotones" runat="server">
        <ContentTemplate>
            <asp:ImageButton ID="btnEditar" runat="server" Width="20px" Height="20px" OnClick="btnEditar_Click"
                CssClass="imgEdit" ToolTip="Editar" ImageUrl="~/img/img_buttons/icono_editar.png" Style="display: none;" />
            <asp:HiddenField ID="hdfID" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="title">
        <label id="lblTitle">Lista de Reservación de Salas</label></div>
    <br />
    <div id="Tab1">
        <div>
            <table>
                <tr>
                    <td>
                        <input type="button" id="btnBuscar" value="Buscar" onclick="fn_Buscar();" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <table id="grvBandeja">
            </table>
            <div id="grvBandeja_Pie">
            </div>
        </div>
    </div>
    <div id="Tab2">
        <p style="text-align: right;">
            <a href="#" onclick='return fn_Volver();'>Volver</a>
        </p>
        <hr />
        <div style="clear: right; width: 550px">
            <asp:UpdatePanel ID="updTab2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table style="width:100%;">
                        <tr>
                            <td class="rowDetalle">Titulo:</td>
                            <td class="rowDetalleSombra"><asp:Label ID="lblTitulo" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="rowDetalle">Ubicación:</td>
                            <td class="rowDetalleSombra"><asp:Label ID="lblUbicacion" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="rowDetalle">Descripción:</td>
                            <td class="rowDetalleSombra"><asp:Label ID="lblDescripcion" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="rowDetalle"><%=Parametros.I_Texto_CategoriaAuxiliar%>:</td>
                            <td class="rowDetalleSombra"><asp:Label ID="lblArea" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="rowDetalle">Fecha:</td>
                            <td class="rowDetalleSombra"><asp:Label ID="lblFecha" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="rowDetalle">Hora Inicio:</td>
                            <td class="rowDetalleSombra"><asp:Label ID="lblHoraInicio" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="rowDetalle">Hora Final:</td>
                            <td class="rowDetalleSombra"><asp:Label ID="lblHoraFinal" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnEditar" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <script type="text/javascript">
        var no_pagina = "ReservSalas.aspx";
        /*[INICIO] - Variables Grilla Bandeja*/
        var idGrilla_Bandeja = "#grvBandeja";
        var idPieGrilla_Bandeja = "#grvBandeja_Pie";
        var strCabecera_Bandeja = ['ID Calendario', 'Titulo', 'Ubicación', '<%=Parametros.I_Texto_CategoriaAuxiliar%>', 'Fecha', 'Hora Inicio', 'Hora Fin'];
        var ModelCol_Bandeja = [
                            { name: 'Calendario_Id', index: 'Calendario_Id', width: 60, align: 'center', hidden: true },
                            { name: 'Titulo', index: 'Titulo', width: 130, align: 'left' },
                            { name: 'Ubicacion', index: 'Ubicacion', width: 100, align: 'left' },
                            { name: 'Area', index: 'Area', width: 95, align: 'left' },
                            { name: 'sFecha', index: 'sFecha', width: 70, align: 'center' },
                            { name: 'sHora_Inicio', index: 'sHora_Inicio', width: 70, align: 'center' },
                            { name: 'sHora_Final', index: 'sHora_Final', width: 70, align: 'center' }
                            ];
        /*[FIN] - Variables Grilla Bandeja*/
        function fn_dblClickBandeja(rowID) {

        }

        this.fn_CargaInicial();
        function fn_CargaInicial() {
            $("#Tab2").hide();
            var id = '<%= Request.QueryString["id"] == null ? "0" : Request.QueryString["id"].ToString() %>';
            document.getElementById("<%= hdfID.ClientID %>").value = id;
            if (id != "0") {
                this.fn_VerDetalle(id);
            }
            else {
                fn_Buscar();
            }
            //var objResponse = [];
            //this.fc_CargaGrilla(idGrilla_Bandeja, idPieGrilla_Bandeja, strCabecera_Bandeja, ModelCol_Bandeja, objResponse, function () { }, fn_dblClickBandeja);
        }

        function fn_LimpiarFiltros() { }

        function fn_Buscar() {
            var msj = '';

            if (msj != '') {
                alert(msj);
            }
            else {
                //Variables Acceso a Datos
                var arr_parametros = new Array();

                var strUrlServicio = no_pagina + "/Get_Bandeja";
                this.fc_GetJQGrid_Ajax(arr_parametros, strUrlServicio, idGrilla_Bandeja, idPieGrilla_Bandeja
                    , strCabecera_Bandeja, ModelCol_Bandeja, function () { }, fn_dblClickBandeja);
            }
        }
        function fn_Volver() {
            var id = document.getElementById("<%= hdfID.ClientID %>").value = '<%= Request.QueryString["id"] == null ? "0" : Request.QueryString["id"].ToString() %>';
            if (id != "0") {
                history.back(1);
            }
            else {
                $("#Tab1").show();
                $("#Tab2").hide();
                $("#lblTitle").text("Lista de Reservación de Salas");

            }
            return false;
        }
        function fn_VerDetalle(id) {
            document.getElementById("<%= hdfID.ClientID %>").value = id;
            $("#Tab1").hide();
            $("#Tab2").show();
            $("#lblTitle").text("Detalle de Reservación de Sala");
            document.getElementById("<%= btnEditar.ClientID %>").click();
        }
    </script>
</asp:Content>
