﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MantCronogramaMes.aspx.cs" Inherits="GNProject.Views.portal.Mantenimientos.MantCronogramaMes" UnobtrusiveValidationMode="None" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
        Mantenimiento de Cronograma de Actividades</div>
    <br />
    <div id="Tab1">
        <div>
            <table>
                <tr>
                    <td>
                        <input type="button" id="btnBuscar" value="Buscar" onclick="fn_Buscar();" class="EstiloGeneralBoton btn-buscar" />
                        <asp:Button ID="btnNuevo" class="EstiloGeneralBoton btn-nuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" OnClientClick="return fn_Nuevo();" />
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
        <div>
            <asp:UpdatePanel ID="updTab2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                Cronograma Id:
                            </td>
                            <td>
                                <asp:Label ID="lblCronogramaMesId" runat="server" Text="" Font-Bold="True" ForeColor="#006699"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Titulo:
                            </td>
                            <td>
                                <asp:TextBox ID="txtTitulo" Width="300px" class="input_text" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtTitulo"
                                    runat="server" ErrorMessage="*" ValidationGroup="Valida"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Foto:
                            </td>
                            <td>
                                <asp:Label ID="lblNomFoto" runat="server" Text=""></asp:Label>
                                <asp:FileUpload Width="300px" ID="FileUpload1" runat="server" />
                                <asp:ImageButton ID="IbtnEliminarArchivo" class='icons-table deleteItem' runat="server" Width="20px" Height="25px"
                                    ImageUrl="~/Assets/images/imgPortal/img_buttons/delete.png" OnClick="IbtnEliminarArchivo_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Descripción:
                            </td>
                            <td>
                                <asp:TextBox ID="txtDescripcion" Width="300px" Height="50px" TextMode="MultiLine"
                                    class="input_text" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtDescripcion"
                                    runat="server" ErrorMessage="*" ValidationGroup="Valida"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Ubicación:
                            </td>
                            <td>
                                <asp:TextBox ID="txtUbicacion" Width="300px" class="input_text" runat="server"></asp:TextBox>
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
                                Fecha:
                            </td>
                            <td>
                                <asp:TextBox ID="txtFecha" runat="server" MaxLength="10"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtFecha_CalendarExtender" runat="server" CssClass="calendar_Theme1"
                                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFecha">
                                </cc1:CalendarExtender>
                                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFecha"
                                    ErrorMessage="*" ValidationGroup="Valida"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Hora Inicio:
                            </td>
                            <td>
                                <asp:TextBox ID="txtHoraInicio" class="input_text" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtHoraInicio_CalendarExtender" runat="server" CssClass="calendar_Theme1"
                                    Enabled="True" Format="dd/MM/yyyy HH:mm" TargetControlID="txtHoraInicio">
                                </cc1:CalendarExtender>
                                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtHoraInicio"
                                    ErrorMessage="*" ValidationGroup="Valida"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Hora Final:
                            </td>
                            <td>
                                <asp:TextBox ID="txtHoraFinal" class="input_text" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtHoraFinal_CalendarExtender" runat="server" Enabled="True"
                                    Format="dd/MM/yyyy HH:mm" TargetControlID="txtHoraFinal" CssClass="calendar_Theme1">
                                </cc1:CalendarExtender>
                                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtHoraFinal"
                                    ErrorMessage="*" ValidationGroup="Valida"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                    <hr />
                    <p>
                        <asp:Button ID="btnGrabar" class="EstiloGeneralBoton btn-guardar" runat="server" ValidationGroup="Valida" Text="Grabar"
                            OnClick="btnGrabar_Click" />
                        <asp:Button ID="btnUpdate" class="EstiloGeneralBoton btn-actualizar" runat="server" ValidationGroup="Valida" Text="Actualizar"
                            OnClick="btnUpdate_Click" />
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
        var no_pagina = "MantCronogramaMes.aspx";
        /*[INICIO] - Variables Grilla Bandeja*/
        var idGrilla_Bandeja = "#grvBandeja";
        var idPieGrilla_Bandeja = "#grvBandeja_Pie";
        var strCabecera_Bandeja = ['', 'ID Cronograma', 'Titulo', 'Ubicación', '<%=GNProject.Acceso.App_code_portal.Parametros.I_Texto_CategoriaAuxiliar%>', 'Fecha', 'Hora Inicio', 'Hora Fin', 'Usuario'];
        var ModelCol_Bandeja = [
                            { name: 'Accion', width: 40, align: 'center' },
                            { name: 'CronogramaMes_Id', index: 'CronogramaMes_Id', width: 60, align: 'center', hidden: true },
                            { name: 'Titulo', index: 'Titulo', width: 130, align: 'left' },
                            { name: 'Ubicacion', index: 'Ubicacion', width: 100, align: 'left' },
                            { name: 'Area', index: 'Area', width: 95, align: 'left' },
                            { name: 'sFecha', index: 'sFecha', width: 70, align: 'center' },
                            { name: 'sHora_Inicio', index: 'sHora_Inicio', width: 70, align: 'center' },
                            { name: 'sHora_Final', index: 'sHora_Final', width: 70, align: 'center' },
                            { name: 'User_Name', index: 'User_Name', width: 70, align: 'center' }
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

