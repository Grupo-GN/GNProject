<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MantUsuarios.aspx.cs" Inherits="GNProject.Views.portal.Mantenimientos.MantUsuarios" UnobtrusiveValidationMode="None" %>

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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnGrabar" />
            <asp:PostBackTrigger ControlID="btnUpdate" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="updBotones" runat="server">
        <ContentTemplate>
            <p style="text-align:center;">
                <asp:Label ID="lblMensaje" Font-Bold="true" runat="server" Text=""></asp:Label>
            </p>
            <asp:ImageButton ID="btnEditar" runat="server" Width="20px" Height="20px" OnClick="btnEditar_Click"
                CssClass="imgEdit" ToolTip="Editar" ImageUrl="~/img/img_buttons/icono_editar.png" Style="display: none;" />
            <asp:ImageButton ID="btnEliminar" runat="server" Width="20px" Height="20px" OnClick="btnEliminar_Click"
                CssClass="imgDelete" ToolTip="Eliminar" ImageUrl="~/img/img_buttons/icono_cerrar.png" Style="display: none;" />
            <asp:HiddenField ID="hdfUserID" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="title">
        Mantenimiento de Usuarios</div>
    <br />
    <div id="Tab1">
        <div>
            <table>
                <tr>
                    <td>
                        Busqueda por:
                        <asp:DropDownList ID="cboTipoBusqueda" runat="server">
                            <asp:ListItem Value="2" Selected="True">Nombre</asp:ListItem>
                            <asp:ListItem Value="1">Usuario</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txtBusca" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <input type="button" id="btnBuscar" value="Buscar" onclick="fn_Buscar();" />
                        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" OnClientClick="return fn_Nuevo();" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <div style="text-align:right; font-weight:bold; padding-right:10px;">
                Total de visitas al <%=GNProject.Acceso.App_code_portal.Parametros.I_NombreProyecto %>: <asp:Label ID="lblTotalVisitas" runat="server"></asp:Label>
            </div>
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
                    <div class="Row1">
                        <div class="col1 fl ar mgl10 pdt5">
                            <asp:Label ID="lblNomUser_Id" runat="server" Text="User_Id:"></asp:Label>
                        </div>
                        <div class="fl mgl10 pdt5">
                            <asp:Label ID="lblUserId" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="Clear">
                        </div>
                    </div>
                    <div class="Row1">
                        <div class="col1 fl ar mgl10 pdt5">
                            Planilla:</div>
                        <div class="fl mgl10 pdt5">
                            <asp:DropDownList ID="cboPlanilla" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cboPlanilla_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="cboPlanilla"
                                InitialValue="-Seleccione-" runat="server" ErrorMessage="*" ValidationGroup="Valida"></asp:RequiredFieldValidator>
                        </div>
                        <div class="Clear">
                        </div>
                    </div>
                    <div class="Row1">
                        <div class="col1 fl ar mgl10 pdt5">
                            <%=GNProject.Acceso.App_code_portal.Parametros.I_Texto_Localidad%>:</div>
                        <div class="fl mgl10 pdt5">
                            <asp:DropDownList ID="cboLocalidad" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cboLocalidad_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="cboLocalidad"
                                InitialValue="-Seleccione-" runat="server" ErrorMessage="*" ValidationGroup="Valida"></asp:RequiredFieldValidator>
                        </div>
                        <div class="Clear">
                        </div>
                    </div>
                    <div class="Row1">
                        <div class="col1 fl ar mgl10 pdt5">
                            <%=GNProject.Acceso.App_code_portal.Parametros.I_Texto_CategoriaAuxiliar%>:</div>
                        <div class="fl mgl10 pdt5">
                            <asp:DropDownList ID="cboArea" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cboArea_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="Clear">
                        </div>
                    </div>
                    <div class="Row1">
                        <div class="col1 fl ar mgl10 pdt5">
                            <%=GNProject.Acceso.App_code_portal.Parametros.I_Texto_CategoriaAuxiliar2%>:</div>
                        <div class="fl mgl10 pdt5">
                            <asp:DropDownList ID="cboSeccion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cboSeccion_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="Clear">
                        </div>
                    </div>
                    <div class="Row1">
                        <div class="col1 fl ar mgl10 pdt5">
                            Personal:</div>
                        <div class="fl mgl10 pdt5">
                            <asp:DropDownList ID="cboPersonal" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="cboPersonal"
                                InitialValue="-Seleccione-" runat="server" ErrorMessage="*" ValidationGroup="Valida"></asp:RequiredFieldValidator>
                        </div>
                        <div class="Clear">
                        </div>
                    </div>
                    <div class="Row1">
                        <div class="col1 fl ar mgl10 pdt5">
                            Foto:</div>
                        <div class="fl mgl10 pdt5">
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </div>
                        <div class="Clear">
                        </div>
                    </div>
                    <div class="Row1">
                        <div class="col1 fl ar mgl10 pdt5">
                        </div>
                        <div class="fl mgl10 pdt5">
                            <asp:Image ID="imgFoto" runat="server" Width="90" Height="100px" />
                            <asp:ImageButton ID="IbtnEliminarArchivo" runat="server" Width="20px" Height="25px"
                                ImageUrl="~/img/img_buttons/icono_cerrar.png" OnClick="IbtnEliminarArchivo_Click" />
                        </div>
                        <div class="Clear">
                        </div>
                    </div>
                    <div class="Row1">
                        <div class="col1 fl ar mgl10 pdt5">
                            Email:</div>
                        <div class="fl mgl10 pdt5">
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        </div>
                        <div class="Clear">
                        </div>
                    </div>
                    <div class="Row1">
                        <div class="col1 fl ar mgl10 pdt5">
                            Usuario:</div>
                        <div class="fl mgl10 pdt5">
                            <asp:TextBox ID="txtUsuario" Width="100px" class="input_text" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUsuario"
                                ErrorMessage="*" ValidationGroup="Valida"></asp:RequiredFieldValidator>
                        </div>
                        <div class="Clear">
                        </div>
                    </div>
                    <div class="Row1">
                        <div class="col1 fl ar mgl10 pdt5">
                            Contraseña:</div>
                        <div class="fl mgl10 pdt5">
                            <asp:TextBox ID="txtPassword" TextMode="SingleLine" Width="100px" class="input_text"
                                runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                                ValidationGroup="Valida" ControlToValidate="txtPassword">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="Clear">
                        </div>
                    </div>
                    <div class="Row1">
                        <div class="col1 fl ar mgl10 pdt5">
                            Confirmar Contraseña:</div>
                        <div class="fl mgl10 pdt5">
                            <asp:TextBox ID="txtConfirmPassword" TextMode="SingleLine" Width="100px" class="input_text"
                                runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*"
                                ValidationGroup="Valida" ControlToValidate="txtConfirmPassword">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="Clear">
                        </div>
                    </div>
                    <div class="Row1">
                        <div class="col1 fl ar mgl10 pdt5">
                            Permiso:</div>
                        <div class="fl mgl10 pdt5">
                            <asp:DropDownList ID="cboPermiso" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" InitialValue="-Seleccione-"
                                ErrorMessage="*" ValidationGroup="Valida" ControlToValidate="cboPermiso">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="Clear">
                        </div>
                    </div>
                    <hr />
                    <p>
                        <asp:Button ID="btnGrabar" runat="server" Text="Grabar" ValidationGroup="Valida"
                            OnClick="btnGrabar_Click" />
                        <asp:Button ID="btnUpdate" runat="server" ValidationGroup="Valida"
                            Text="Actualizar" OnClick="btnUpdate_Click" />
                    </p>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnNuevo" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnEditar" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>

    <script type="text/javascript">
        var no_pagina = "MantUsuarios.aspx";
        /*[INICIO] - Variables Grilla Bandeja*/
        var idGrilla_Bandeja = "#grvBandeja";
        var idPieGrilla_Bandeja = "#grvBandeja_Pie";
        var strCabecera_Bandeja = ['', 'ID Usuario', 'Apellidos y Nombres', 'Usuario', 'Email', '<%=GNProject.Acceso.App_code_portal.Parametros.I_Texto_Localidad%>', '<%=GNProject.Acceso.App_code_portal.Parametros.I_Texto_CategoriaAuxiliar%>', '<%=GNProject.Acceso.App_code_portal.Parametros.I_Texto_CategoriaAuxiliar2%>', '<span style="font-size:9px;">Cant. Visitas<span>'];
        var ModelCol_Bandeja = [
                            { name: 'Accion', width: 40, align: 'center' },
                            { name: 'User_Id', index: 'User_Id', width: 60, align: 'center', hidden: true },
                            { name: 'Nombre_Completo', index: 'Nombre_Completo', width: 130, align: 'left' },
                            { name: 'User_Name', index: 'User_Name', width: 70, align: 'center' },
                            { name: 'Email', index: 'Email', width: 140, align: 'left' },
                            { name: 'Localidad', index: 'Localidad', width: 60, align: 'left' },
                            { name: 'Area', index: 'Area', width: 95, align: 'left' },
                            { name: 'Seccion', index: 'Seccion', width: 100, align: 'left' },
                            { name: 'nu_ingresos', index: 'nu_ingresos', width: 40, align: 'center' }
                            ];
        /*[FIN] - Variables Grilla Bandeja*/
        function fn_dblClickBandeja(rowID) {

        }

        this.fn_CargaInicial();
        function fn_CargaInicial() {
            $("#Tab2").hide();
            fn_Buscar();
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
                arr_parametros[0] = $("#<%= cboTipoBusqueda.ClientID %>").val();
                arr_parametros[1] = $("#<%= txtBusca.ClientID %>").val();

                var strUrlServicio = no_pagina + "/Get_Bandeja";
                this.fc_GetJQGrid_Ajax(arr_parametros, strUrlServicio, idGrilla_Bandeja, idPieGrilla_Bandeja
                    , strCabecera_Bandeja, ModelCol_Bandeja, function () { }, fn_dblClickBandeja);
            }
        }

        function fn_Nuevo() {
            $("#Tab1").hide();
            $("#Tab2").show();
            return true;
        }
        function fn_Volver() {
            $("#Tab1").show();
            $("#Tab2").hide();
            return false;
        }
        function fn_Editar(id) {
            document.getElementById("<%= hdfUserID.ClientID %>").value = id;
            $("#Tab1").hide();
            $("#Tab2").show();
            document.getElementById("<%= btnEditar.ClientID %>").click();
        }
        function fn_Eliminar(id) {
            if (confirm('Está seguro de eliminar el registro?')) {
                document.getElementById("<%= hdfUserID.ClientID %>").value = id;
                document.getElementById("<%= btnEliminar.ClientID %>").click();
            }
        }
    </script>
</asp:Content>

