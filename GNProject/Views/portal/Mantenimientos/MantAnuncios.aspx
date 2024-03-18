﻿<%@ Page Async="true" ValidateRequest="false" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MantAnuncios.aspx.cs" Inherits="GNProject.Views.portal.Mantenimientos.MantAnuncios" UnobtrusiveValidationMode="None" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/Assets/Css/PortalCss/Estilo.css" rel="stylesheet" type="text/css" />
    <link href="/Assets/Css/PortalCss/Menu.css" rel="stylesheet" type="text/css" />
    <link href="/Assets/Css/PortalCss/JqGrid/ui.jqgrid.css" rel="stylesheet" type="text/css" />
    <link href="/Assets/Css/PortalCss/JqGrid/jquery-ui.css" rel="stylesheet" type="text/css" /> 
    <link href="/Assets/Css/PortalCss/NewStyle.css" rel="stylesheet" type="text/css" />
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
            <p style="text-align: center;">
                <asp:Label ID="lblMensaje" Font-Bold="true" runat="server" Text=""></asp:Label>
            </p>
            <asp:ImageButton ID="btnEditar" runat="server" Width="20px" Height="20px" OnClick="btnEditar_Click"
                CssClass="imgEdit" ToolTip="Editar" ImageUrl="~/Assets/images/imgPortal/img_buttons/icono_editar.png"
                Style="display: none;" />
            <asp:ImageButton ID="btnEliminar" runat="server" Width="20px" Height="20px" OnClick="btnEliminar_Click"
                CssClass="imgDelete" ToolTip="Eliminar" ImageUrl="~/Assets/images/imgPortal/img_buttons/icono_cerrar.png"
                Style="display: none;" />
            <asp:HiddenField ID="hdfID" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="title">
        Mantenimiento de Anuncios</div>
    <br />
    <div id="Tab1">
        <div>
            <table>
                <tr>
                    <td>
                        <input type="button" id="btnBuscar" value="Buscar" onclick="fn_Buscar();" class="EstiloGeneralBoton btn-buscar" />
                        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" OnClientClick="return fn_Nuevo();" class="EstiloGeneralBoton btn-nuevo" />
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
        <div >
            <asp:UpdatePanel ID="updTab2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                Anuncio Id:
                            </td>
                            <td>
                                <asp:Label ID="lblAnuncioId" runat="server" Text="" Font-Bold="True" ForeColor="#006699"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Titulo:
                            </td>
                            <td>
                                <asp:TextBox ID="txtTitulo" Width="400px" class="input_text" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtTitulo"
                                    runat="server" ErrorMessage="*" ValidationGroup="Valida"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Descripción:
                            </td>
                            <td>
                                <asp:TextBox ID="txtDescripcion" Width="400px" Height="200px" TextMode="MultiLine"
                                    class="input_text" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtDescripcion"
                                    runat="server" ErrorMessage="*" ValidationGroup="Valida"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Fecha:
                            </td>
                            <td>
                                <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtFecha_CalendarExtender" runat="server" CssClass="calendar_Theme1"
                                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFecha">
                                </cc1:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=GNProject.Acceso.App_code_portal.Parametros.I_Texto_CategoriaAuxiliar%>:
                            </td>
                            <td>
                                <asp:DropDownList ID="cboArea" Width="200px" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Imagen:
                            </td>
                            <td>
                                <label for="FileUpload1" class="EstiloGeneralBoton btn-seleccionarArchi">Seleccionar Archivo</label>
                                <asp:FileUpload ID="FileUpload1"  runat="server" />
                                <asp:Image ID="imgFoto" runat="server" Width="90" Height="100px" />
                                <asp:ImageButton ID="IbtnEliminarFoto" ToolTip="Eliminar Imagen" runat="server" ImageUrl="~/Assets/images/imgPortal/img_buttons/delete.png"
                                    Width="15px" Height="15px" OnClick="IbtnEliminarFoto_Click" class='icons-table deleteItem' />
                                <asp:Label ID="lblNombrFoto" runat="server" Visible="false"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <hr />
                    <p>
                        <asp:Button ID="btnGrabar" runat="server" Text="Grabar" ValidationGroup="Valida"
                            OnClick="btnGrabar_Click" class="EstiloGeneralBoton btn-grabar" />
                        <asp:Button ID="btnUpdate" runat="server" ValidationGroup="Valida" Text="Actualizar"
                            OnClick="btnUpdate_Click" class="EstiloGeneralBoton btn-actualizar" />
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
        var no_pagina = "MantAnuncios.aspx";
        /*[INICIO] - Variables Grilla Bandeja*/
        var idGrilla_Bandeja = "#grvBandeja";
        var idPieGrilla_Bandeja = "#grvBandeja_Pie";
        var strCabecera_Bandeja = ['', 'ID Anuncio', 'Titulo', '<%=GNProject.Acceso.App_code_portal.Parametros.I_Texto_CategoriaAuxiliar%>', 'Usuario', 'Fecha'];
        var ModelCol_Bandeja = [
                            { name: 'Accion', width: 50, align: 'center' },
                            { name: 'Anuncio_Id', index: 'Anuncio_Id', width: 60, align: 'center' },
                            { name: 'Titulo', index: 'Titulo', width: 250, align: 'left' },
                            { name: 'Area', index: 'Area', width: 70, align: 'center' },
                            { name: 'User_Name', index: 'User_Name', width: 90, align: 'center' },
                            { name: 'sFecha', index: 'sFecha', width: 70, align: 'center' }
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
            document.getElementById("<%= hdfID.ClientID %>").value = id;
            $("#Tab1").hide();
            $("#Tab2").show();
            document.getElementById("<%= btnEditar.ClientID %>").click();
        }
        function fn_Eliminar(id) {
            if (confirm('Está seguro de eliminar el registro?')) {
                document.getElementById("<%= hdfID.ClientID %>").value = id;
                document.getElementById("<%= btnEliminar.ClientID %>").click();
            }
        }
    </script>
</asp:Content>

