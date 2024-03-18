<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Anuncios.aspx.cs" Inherits="GNProject.Views.portal.Intranet.Anuncios" %>


<%@ Import Namespace="GNProject.Acceso.App_code_portal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/Assets/Css/PortalCss/Estilo.css" rel="stylesheet" type="text/css" />
    <link href="/Assets/Css/PortalCss/Menu.css" rel="stylesheet" type="text/css" />
    <link href="/Assets/Css/PortalCss/NewStyle.css" rel="stylesheet" type="text/css" />
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
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <asp:UpdatePanel ID="updBotones" runat="server">
        <ContentTemplate>
            <asp:ImageButton ID="btnEditar" runat="server" Width="20px" Height="20px" OnClick="btnEditar_Click"
                CssClass="imgEdit" ToolTip="Editar" ImageUrl="~/img/img_buttons/icono_editar.png" Style="display: none;" />
            <asp:HiddenField ID="hdfID" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>

    <div id="contenerdorInicioPortal" style="width:100%;position:relative">
        <div id="errorMessageLabel" runat="server">
            </div>
        <div id="contenedor" >
                <div id="Welcome" style="width:100%;height:200px;">
                    <div id="textWelcome" style="width:100%; text-align:center;top:50px;">
                        
                    </div>
                </div>
            <div id="contenidos" >
                <div class="roundframe vistaIntranet">
                    <div class="title">
        <label id="lblTitle">Lista de Anuncios</label></div>
    <br />
    <div id="Tab1">
        <div>
            <table>
                <tr>
                    <td>
                        <input type="button" id="btnBuscar" value="Buscar" onclick="fn_Buscar();" class="EstiloGeneralBoton btn-buscar" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <table id="grvBandeja" class="Ntable">
            </table>
            <div id="grvBandeja_Pie"class="Ntable-pie">
            </div>
        </div>
    </div>
    <div id="Tab2">
        <p style="text-align: right;">
            <a href="#" onclick='return fn_Volver();'>Volver</a>
        </p>
        <hr />
        <div >
            <asp:UpdatePanel ID="updTab2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table style="width:100%;">
                        <tr>
                            <td class="rowDetalle">Titulo:</td>
                            <td class="rowDetalleSombra"><asp:Label ID="lblTitulo" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="rowDetalle">Descripción:</td>
                            <td class="rowDetalleSombra"><asp:Label ID="lblDescripcion" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="rowDetalle"></td>
                            <td class="rowDetalleSombra"><asp:Image ID="Image1" runat="server" Width="80%" ImageUrl=''></asp:Image></td>
                        </tr>
                        <tr>
                            <td class="rowDetalle"><%=Parametros.I_Texto_CategoriaAuxiliar%>:</td>
                            <td class="rowDetalleSombra"><asp:Label ID="lblArea" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="rowDetalle">Fecha:</td>
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

                </div>
            </div>
            <div id="pie" style="width:100%">
            <div style="text-align: center; font-size: 10px; padding-top: 0px;">
                © <%=GNProject.Acceso.App_code_portal.Parametros.I_NombreProyecto %> <%=GNProject.Acceso.App_code_portal.Parametros.I_NombreEmpresa %> <%= DateTime.Now.Year.ToString() %>
            </div>
            <div style="text-align:right;padding-right:5px;">
                <a class="linkWeb" href="http://www.gestiondenegociosrs.com.pe" target="_blank">Desarrollado por: Gestión de Negocios S.A.C.</a>
            </div>
        </div>
        </div>
    </div>
    
        
    <script type="text/javascript">
        var no_pagina = "Anuncios.aspx";
        /*[INICIO] - Variables Grilla Bandeja*/
        var idGrilla_Bandeja = "#grvBandeja";
        var idPieGrilla_Bandeja = "#grvBandeja_Pie";
        var strCabecera_Bandeja = ['ID Anuncio', 'Titulo', '<%=Parametros.I_Texto_CategoriaAuxiliar%>', 'Fecha'];
        var ModelCol_Bandeja = [
            { name: 'Anuncio_Id', index: 'Anuncio_Id', align: 'center', hidden: true },
            { name: 'Titulo', index: 'Titulo', align: 'left' },
            { name: 'Area', index: 'Area', align: 'left' },
            { name: 'sFecha', index: 'sFecha', align: 'center' }
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
                $("#lblTitle").text("Lista de Anuncios");
                //llamamos a la funcion para reposicionar pie
                this.fn_reposicionarPie();
            }
            return false;
        }
        function fn_VerDetalle(id) {
            document.getElementById("<%= hdfID.ClientID %>").value = id;
            $("#Tab1").hide();
            $("#Tab2").show();
            $("#lblTitle").text("Detalle del Anuncio");
            document.getElementById("<%= btnEditar.ClientID %>").click();
            //llamamos a la funcion para reposicionar pie
            this.fn_reposicionarPie();
        }
        this.fn_reposicionarPie();
        function fn_reposicionarPie() {
            //para poner el Pie debajo del contenido principal
            var divHeightContenidos = document.getElementById("contenidos").offsetHeight;
            var divPie = document.getElementById("pie");
            divHeightContenidos = parseInt(divHeightContenidos) + 20;
            divPie.style.marginTop = divHeightContenidos + "px";
        }
    </script>
</asp:Content>
