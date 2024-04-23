<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmRenovaContrato.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Contrato_RRHH.FrmRenovaContrato" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <link href="../Styles/nuevoEstiloPlanilla.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />
    <%--<script type="text/javascript">

        //funcion para los checkbox
        var allCheckBoxSelector = '#<%=grvListaPersonal.ClientID%> input[id*="chkAll"]:checkbox';
        var checkBoxSelector = '#<%=grvListaPersonal.ClientID%> input[id*="chk"]:checkbox';

        function ToggleCheckUncheckAllOptionAsNeeded() {
            var totalCheckboxes = $(checkBoxSelector),
                checkedCheckboxes = totalCheckboxes.filter(":checked"),
                noCheckboxesAreChecked = (checkedCheckboxes.length === 0),
                allCheckboxesAreChecked = (totalCheckboxes.length === checkedCheckboxes.length);

            $(allCheckBoxSelector).attr('checked', allCheckboxesAreChecked);
        }

        $(document).ready(function () {
            $(allCheckBoxSelector).on('click', function () {
                $(checkBoxSelector).attr('checked', $(this).is(':checked'));

                ToggleCheckUncheckAllOptionAsNeeded();
            });

            $(checkBoxSelector).on('click', ToggleCheckUncheckAllOptionAsNeeded);

            ToggleCheckUncheckAllOptionAsNeeded();
        });

    </script>--%>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td>
                        <div>
                            <asp:Panel ID="pnlFiltro" runat="server">
                                <table width="100%">
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="Label1" runat="server" Text="RENOVAR CONTRATOS" CssClass="miTitulo"></asp:Label></td>
                                        <td align="right" colspan="4">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width:100px;">
                                            <asp:Label ID="Label2" runat="server" Text="Area" CssClass="miLabel"></asp:Label>
                                        </td>
                                        <td style="width:200px;">
                                            <asp:DropDownList ID="cboCategoria_Auxiliar" runat="server" CssClass="ddl" Width="183px"
                                                AutoPostBack="True"
                                                OnSelectedIndexChanged="cboCategoria_Auxiliar_SelectedIndexChanged"
                                                Height="16px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnVer" runat="server" CssClass="submit" OnClick="btnVer_Click" Text="Ver"
                                                Visible="false"/>
                                        </td>
                                        <td class="style1" colspan="3">
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="vertical-align: top">&nbsp; &nbsp;<asp:CheckBox ID="chkEnviar" runat="server"
                                            Text="Enviar Correo" OnCheckedChanged="chkEnviar_CheckedChanged"
                                            AutoPostBack="True" CssClass="miLabel" />
                                        </td>
                                        <td style="vertical-align: top">&nbsp;<asp:Label ID="Label3" runat="server" ForeColor="Red" Text="Para:"></asp:Label><asp:TextBox ID="txtDestinatario"
                                            runat="server" CssClass="textbox"></asp:TextBox></td>
                                        <td style="vertical-align: top">
                                            <asp:Label ID="lblMen" runat="server" ForeColor="Red" Text="Mensaje:"></asp:Label>
                                        </td>
                                        <td style="vertical-align: top">
                                            <asp:TextBox ID="txtMen" runat="server" Style="margin-bottom: 0px;"
                                                TextMode="MultiLine" Width="214px" CssClass="textbox"></asp:TextBox>
                                        </td>
                                        <td style="vertical-align: top">
                                            <asp:Button ID="btnEnviar" runat="server" CssClass="submit"
                                                OnClick="btnEnviar_Click" Text="Enviar" />
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td colspan="6">
                                            <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </div>

                        <div style="overflow: auto; width: 100%;">
                            <div style="text-align:center;">
                                <asp:Button ID="btnAbrirRenovarContratos" CssClass="EstiloGeneralBoton" runat="server" Text="Renovar Contratos" OnClientClick="return fn_AbrirRenovarContrato()" />
                            </div>
                            <asp:GridView ID="grvListaPersonal" runat="server"
                                PageSize="13"
                                AutoGenerateColumns="False" CellPadding="2" CssClass="gridSmall"
                                DataKeyNames="Personal_Id"
                                GridLines="None"
                                OnPageIndexChanging="grvListaPersonal_PageIndexChanging"
                                Width="100%" OnRowDataBound="grvListaPersonal_RowDataBound">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkCheckAll" runat="server" onclick="fn_CheckAll(this)" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkCheck" runat="server" onclick="fn_Check(this)" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Personal_Id" HeaderText="CODIGO">
                                        <HeaderStyle ForeColor="#336699" Font-Size="X-Small"
                                            Font-Bold="True" />
                                        <ItemStyle HorizontalAlign="Left" Width="50px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Nombres" HeaderText="NOMBRES">
                                        <HeaderStyle ForeColor="#336699" Font-Size="X-Small"
                                            Font-Bold="True" />
                                        <ItemStyle HorizontalAlign="Left" Width="220px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Localidad" HeaderText="LOCALIDAD">
                                        <HeaderStyle ForeColor="#336699" Font-Size="X-Small"
                                            Font-Bold="True" />
                                        <ItemStyle HorizontalAlign="Left" Width="150px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Area" HeaderText="AREA">
                                        <HeaderStyle ForeColor="#336699" Font-Size="X-Small"
                                            Font-Bold="True" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FechaIngreso" HeaderText="FEC INGRESO">
                                        <HeaderStyle ForeColor="#336699" Font-Size="X-Small"
                                            Font-Bold="True" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FechaIniContrato" HeaderText="FEC INI CONTRATO">
                                        <HeaderStyle ForeColor="#336699" Font-Size="X-Small"
                                            Font-Bold="True" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FechaFinContrato" HeaderText="FEC FIN CONTRATO">
                                        <HeaderStyle ForeColor="#336699" Font-Size="X-Small"
                                            Font-Bold="True" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FechaCese" HeaderText="FEC CESE CONTRATO">
                                        <HeaderStyle ForeColor="#336699" Font-Size="X-Small"
                                            Font-Bold="True" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="OBSERVACIONES" Visible="false">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtObservaciones" runat="server" CssClass="textbox"
                                                Text='<%# Eval("Observaciones") %>' TextMode="MultiLine"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle ForeColor="#336699" Font-Size="X-Small"
                                            Font-Bold="True" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="RENOVAR">
                                        <ItemTemplate>
                                            <asp:Button ID="btnModificar" runat="server" Text="Renovar"
                                                OnClick="btnModificar_Click" CommandName='<%#Eval("Personal_Id") %>' CssClass="EstiloGeneralBoton btn-agregar-en-tablas" />
                                        </ItemTemplate>
                                        <HeaderStyle ForeColor="#336699" Font-Size="X-Small"
                                            Font-Bold="True" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            </asp:GridView>
                        </div>

                    </td>
                </tr>
            </table>

            <br />

        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="grvListaPersonal" />
            <asp:PostBackTrigger ControlID="btnEnviar" />

        </Triggers>
    </asp:UpdatePanel>


    <asp:UpdateProgress ID="UpdateProgress1" runat="server"
        AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1">

        <ProgressTemplate>
            <div class="UpdateProgressModalBackground"></div>
            <center>
                <div class="UpdateProgressPanel">
                    Cargando...<br />
                    <br />
                    <asp:Image ID="Image2" runat="server"
                        alt="Procesando" ImageUrl="~/Views/sistemaPlanillas/css/ajax-loader.gif" />
                </div>
            </center>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <cc1:ModalPopupExtender ID="mpRenovarContratos" runat="server" BackgroundCssClass="modalBackground"
        CancelControlID="btnCerrar_RenovarContrato" DynamicServicePath="" Enabled="True"
        PopupControlID="pnlRenovarContratos" TargetControlID="hdfOpenRenovarContratos">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdfOpenRenovarContratos" runat="server" />
    <asp:Panel ID="pnlRenovarContratos" runat="server" CssClass="popupControl">
        <table width="100%" style="font-family:Arial;">
            <tr>
                <td colspan="4" style="color: #666666; font-weight: bold;" class="style4">Renovar Contratos</td>
            </tr>
            <tr>
                <td>Fecha inicio contrato</td>
                <td>
                    <asp:TextBox ID="txtFechaInicioContrato" runat="server" CssClass="textbox" 
                        Width="70px" MaxLength="10"></asp:TextBox>
                    <cc1:CalendarExtender ID="txtFechaInicioContrato_CalendarExtender" runat="server" 
                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaInicioContrato" CssClass="calendar_Theme1">
                    </cc1:CalendarExtender>
                </td>
                <td>Fecha fin contrato:</td>
                <td>
                    <asp:TextBox ID="txtFechaFinalContrato" runat="server" CssClass="textbox" 
                        Width="70px" MaxLength="10"></asp:TextBox>
                    <cc1:CalendarExtender ID="txtFechaFinalContrato_CalendarExtender" runat="server" 
                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaFinalContrato" CssClass="calendar_Theme1">
                    </cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:right;"><asp:Button ID="btnRenovar" runat="server" Text="Renovar" CssClass="EstiloGeneralBoton btn-agregar-en-tablas" OnClientClick="return fn_Renovar()" /></td>
                <td colspan="2" style="text-align:left;"><asp:Button ID="btnCerrar_RenovarContrato" runat="server" Text="Cerrar" CssClass="EstiloGeneralBoton btn-agregar-en-tablas"  /></td>
            </tr>
        </table>
    </asp:Panel>
    <script type="text/javascript">
        function fn_CheckAll(obj) {
            var chk = $(obj).prop("checked");
            $("#<%=grvListaPersonal.ClientID %> :checkbox[id$=chkCheck]").prop("checked", chk);
        }
        function fn_Check(obj) {
            var chk = $(obj).prop("checked");

            var qt_check = $("#<%=grvListaPersonal.ClientID %> :checkbox[id$=chkCheck]:checked").length;
            var qt_item = $("#<%=grvListaPersonal.ClientID %> :checkbox[id$=chkCheck]").length;

            if (qt_check == qt_item) {
                $("#<%=grvListaPersonal.ClientID %> :checkbox[id$=chkCheckAll]").prop("checked", true);
            }
            else {
                $("#<%=grvListaPersonal.ClientID %> :checkbox[id$=chkCheckAll]").prop("checked", false);
            }
        }
        function fn_AbrirRenovarContrato() {
            var qt_check = $("#<%=grvListaPersonal.ClientID %> :checkbox[id$=chkCheck]:checked").length;
            if (qt_check <= 0) {
                alert("- Debe seleccionar al menos un registro");
                return false;
            }
            else {
                var grid = document.getElementById("<%=grvListaPersonal.ClientID %>");
                var fecFinContrato;
                var fecFinContrato_Anterior = "";
                if (grid.rows.length > 0) {
                    for (i = 1; i < grid.rows.length - 1; i++) {
                        var node = grid.rows[i].cells[0].childNodes[1];
                        var checkbox = document.getElementById(node.id);
                        if (checkbox.checked) {
                            fecFinContrato = fc_Trim(grid.rows[i].cells[7].innerHTML);
                            if (fecFinContrato != fecFinContrato_Anterior && fecFinContrato_Anterior != "") {
                                alert("Los registros seleccionados deben tener la misma fecha final de contrato.")
                                return false;
                            }
                            fecFinContrato_Anterior = fecFinContrato;
                        }
                    }
                }

                $("#<%=txtFechaInicioContrato.ClientID %>").val("");
                $("#<%=txtFechaFinalContrato.ClientID %>").val("");
                document.getElementById("<%=hdfOpenRenovarContratos.ClientID %>").click();
            }
            return false;
        }
        function fn_Renovar() {
            var feInicio = $("#<%=txtFechaInicioContrato.ClientID %>").val();
            var feFinal = $("#<%=txtFechaFinalContrato.ClientID %>").val();
            if (feInicio == "" || feFinal == "") {
                alert("Debe ingresar fecha de inicio y fecha final.");
            }
            else if (fc_ValidarRangofechas(feInicio, feFinal) == false) {
                alert("La fecha fin de contrato debe ser mayor a la fecha inicio.");
            }
            else if (confirm("¿Está seguro de renovar los contratos seleccionados?")) {
                return true;
            }
            return false;
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">

    <style type="text/css">
        .style1 {
            width: 83px;
        }

        .style2 {
            width: 182px;
        }
    </style>

</asp:Content>


