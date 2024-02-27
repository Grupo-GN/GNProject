<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DirColaboradores.aspx.cs" Inherits="GNProject.Views.portal.Intranet.DirColaboradores" %>

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
        <label id="lblTitle">Directorio de Colaboradores</label></div>
    <br />
    <div id="Tab1">
        <div>
            <table>
                <tr>
                    <td>
                        Planilla:<asp:DropDownList ID="cboPlanilla" runat="server" AutoPostBack="True">
                            </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=Parametros.I_Texto_Localidad%>:
                        <asp:DropDownList ID="cboLocalidad" runat="server">
                        </asp:DropDownList>
                        &nbsp;<%=Parametros.I_Texto_CategoriaAuxiliar%>:
                        <asp:DropDownList ID="cboArea" runat="server">
                        </asp:DropDownList>
                        &nbsp;Nombre:
                        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                    </td>
                </tr>
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
                            <td class="rowDetalle">Apellido Paterno:</td>
                            <td class="rowDetalleSombra"><asp:Label ID="lblApePaterno" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="rowDetalle">Apellido Materno:</td>
                            <td class="rowDetalleSombra"><asp:Label ID="lblApeMaterno" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="rowDetalle">Nombres:</td>
                            <td class="rowDetalleSombra"><asp:Label ID="lblNombres" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="rowDetalle"><%=Parametros.I_Texto_Localidad%>:</td>
                            <td class="rowDetalleSombra"><asp:Label ID="lblLocalidad" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="rowDetalle"><%=Parametros.I_Texto_CategoriaAuxiliar%>:</td>
                            <td class="rowDetalleSombra"><asp:Label ID="lblArea" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="rowDetalle"><%=Parametros.I_Texto_CategoriaAuxiliar2%>:</td>
                            <td class="rowDetalleSombra"><asp:Label ID="lblSeccion" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="rowDetalle">Cargo:</td>
                            <td class="rowDetalleSombra"><asp:Label ID="lblCargo" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="rowDetalle">Teléfono:</td>
                            <td class="rowDetalleSombra"><asp:Label ID="lblTelefono" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="rowDetalle">Teléfono 2:</td>
                            <td class="rowDetalleSombra"><asp:Label ID="lblTelefono2" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="rowDetalle">Teléfono 3:</td>
                            <td class="rowDetalleSombra"><asp:Label ID="lblTelefono3" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="rowDetalle">Email:</td>
                            <td class="rowDetalleSombra"><asp:Label ID="lblEmail" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="rowDetalle">Fecha Cumpleaños:</td>
                            <td class="rowDetalleSombra"><asp:Label ID="lblFechaNacimiento" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="rowDetalle">Foto:</td>
                            <td class="rowDetalleSombra"><asp:Image ID="imgFoto" Width="150px" Height="200px" runat="server" /></td>
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
        var no_pagina = "DirColaboradores.aspx";
        /*[INICIO] - Variables Grilla Bandeja*/
        var idGrilla_Bandeja = "#grvBandeja";
        var idPieGrilla_Bandeja = "#grvBandeja_Pie";
        var strCabecera_Bandeja = ['', 'Personal Id', 'Apellidos y Nombres', 'Teléfono', 'Celular', 'Teléfono 3', 'Email', '<%=Parametros.I_Texto_Localidad%>', '<%=Parametros.I_Texto_CategoriaAuxiliar%>', '<%=Parametros.I_Texto_CategoriaAuxiliar2%>'];
        var ModelCol_Bandeja = [
                            { name: 'Foto', width: 30, align: 'center', sortable: false },
                            { name: 'Personal_Id', index: 'Personal_Id', width: 60, align: 'center', hidden: true },
                            { name: 'Nombre_Completo', index: 'Nombre_Completo', width: 130, align: 'left' },
                            { name: 'Telefono', index: 'Telefono', width: 70, align: 'center' },
                            { name: 'Telefono2', index: 'Telefono2', width: 70, align: 'center' },
                            { name: 'Telefono3', index: 'Telefono3', width: 70, align: 'center' },
                            { name: 'Email', index: 'Email', width: 150, align: 'left' },
                            { name: 'Localidad', index: 'Localidad', width: 60, align: 'left' },
                            { name: 'Area', index: 'Area', width: 95, align: 'left' },
                            { name: 'Seccion', index: 'Seccion', width: 100, align: 'left', hidden: true }
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
                
                arr_parametros[0] = $('#<%= cboPlanilla.ClientID%>').val();
                arr_parametros[1] = $("#<%= cboLocalidad.ClientID %>").val();
                arr_parametros[2] = $("#<%= cboArea.ClientID %>").val();
                arr_parametros[3] = $("#<%= txtNombre.ClientID %>").val();

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
                $("#lblTitle").text("Directorio de Colaboradores");

            }
            return false;
        }
        function fn_VerDetalle(id) {
            document.getElementById("<%= hdfID.ClientID %>").value = id;
            $("#Tab1").hide();
            $("#Tab2").show();
            $("#lblTitle").text("Datos del Personal");
            document.getElementById("<%= btnEditar.ClientID %>").click();
        }
    </script>
</asp:Content>