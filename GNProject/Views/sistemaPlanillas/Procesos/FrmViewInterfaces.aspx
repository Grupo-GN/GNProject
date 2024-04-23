<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmViewInterfaces.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Procesos.FrmViewInterfaces" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%--NOTAS:
    @001 FPS 30/03/2020 - Se quita opciones que no se usan y agrega filtros
--%>
<asp:Content ID="head1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/multiple-select.css" />
    <script src="../JQuery/jquery-1.10.1.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../JQuery/jquery.multiple.select.js"></script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript">

        function limpiaMSJ(source, args) {
            var label = document.getElementById('<%=lblError.ClientID %>');
            label.innerHTML = "";
            RestoreColor();
            return false;
        }

        var previousColor;
        function MakeRed() {
            previousColor = window.event.srcElement.style.color;
            window.event.srcElement.style.color = "#FF0000";
        }

        function RestoreColor() {
            window.event.srcElement.style.color = previousColor;
        }

        function tremer(n) {
            if (self.moveBy) {
                for (i = 10; i > 0; i--) {
                    for (j = n; j > 0; j--) {
                        self.moveBy(0, i);
                        self.moveBy(i, 0);
                        self.moveBy(0, -i);
                        self.moveBy(-i, 0);
                    }
                }
            }
        }

        function ocultaPanel() {
            var valueCombo = document.getElementById('<%= cboTelecred.ClientID %>').value;
    document.getElementById('<%= cboConcepto.ClientID %>').value = '01';
    var panel = document.getElementById('capa1');

    // var panel = document.getElementById('<%= pnlSeleccion.ClientID %>');
            if (valueCombo == "1") {
                panel.style.visibility = 'visible';
                //document.getElementById('clase2'), panel.style.visibility = 'true';
            }
            else {
                panel.style.visibility = 'hidden';
                document.getElementById('clase2').style.visibility = 'hidden';
            }
        }

        function ocultaPanelFechas() {
            var valueCombo = document.getElementById('<%= cboConcepto.ClientID %>').value;
    var panel = document.getElementById('clase2');

    // var panel = document.getElementById('<%= pnlSeleccion.ClientID %>');
            if (valueCombo == "03") {
                panel.style.visibility = 'visible';
            } else if (valueCombo != "03") {
                panel.style.visibility = 'hidden';
            }
        }

    </script>

    <style type="text/css">
        .titulo {
            display: none;
        }

        .style1 {
            height: 32px;
        }
    </style>

    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />

    <link href="../Styles/nuevoEstiloPlanilla.css" rel="stylesheet" type="text/css" />
    <table align="center" width="100%">
        <tr>
            <td>

                <fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px; /*border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black;*/ min-height: 500px; overflow: hidden; border-radius: 8px 8px 0px 0px; /*border-top: solid 1px black;*/">

            

                    <asp:Label ID="Label9" runat="server"
                        Text="GENERADOR DE INTERFACES" CssClass="miTitulo"></asp:Label>

                    <br />
                  

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>

                            <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="2"
                                Height="400px" Width="100%">
                                <cc1:TabPanel HeaderText="T-Registro" ID="panel1" runat="server">
                                    <ContentTemplate>

                                        <fieldset style="overflow: auto; /*border-style: outset;*/ border-width: thin; height: 80%; min-height: 375px; width: 97%; background-color: White">
                                            <table width="100%">
                                                <tr>
                                                    <td width="50"></td>
                                                    <td>
                                                        <%-- <asp:DropDownList ID="ddlPlanilla1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPlanilla_SelectedIndexChanged">
                        </asp:DropDownList>--%>
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td width="50" colspan="2">
                                                        <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="Red"
                                                            Text="[lblError]"></asp:Label>
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <td width="50">
                                                        <asp:Label ID="Label16" runat="server" Text="Interfaces: " CssClass="miLabel"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlInterfaces" runat="server" AutoPostBack="false"
                                                            OnSelectedIndexChanged="ddlInterfaces_SelectedIndexChanged" Width="830px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td width="50" class="style1">&nbsp;
                                                    </td>
                                                    <td class="style1">
                                                        <asp:Button ID="btnGenerar" runat="server" Text="Generar"
                                                            OnClick="btnGenerar_Click" CssClass="submit EstiloGeneralBoton btn-nuevo"
                                                            OnClientClick="limpiaMSJ();" ToolTip="Sirve Para Generar Archivos Planos" />
                                                        <cc1:ConfirmButtonExtender ID="btnGenerar_ConfirmButtonExtender" runat="server"
                                                            ConfirmText="Desea Generar el Archivo???" Enabled="True"
                                                            TargetControlID="btnGenerar">
                                                        </cc1:ConfirmButtonExtender>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                            </table>
                                        </fieldset>

                                    </ContentTemplate>
                                </cc1:TabPanel>
                                <cc1:TabPanel HeaderText="Archivos Plame" ID="TabPanel1" runat="server">
                                    <ContentTemplate>

                                        <fieldset style="overflow: auto; /*border-style: outset;*/ border-width: thin; height: 80%; min-height: 375px; width: 97%; background-color: White">

                                            <table width="100%">
                                                <tr>
                                                    <td width="50"></td>
                                                    <td></td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td width="50" colspan="2">
                                                        <asp:Label ID="lblErrorPlame" runat="server" Font-Bold="True" ForeColor="Red"
                                                            Text="[lblError]"></asp:Label>
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <td width="50">
                                                        <asp:Label ID="Label2" runat="server" Text="Interfaces: " CssClass="miLabel"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="cboPlame" runat="server"
                                                            Width="830px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td width="50" class="style1">&nbsp;
                                                    </td>
                                                    <td class="style1">
                                                        <asp:Button ID="btnGenerarPlame" runat="server" Text="Generar"
                                                            CssClass="submit EstiloGeneralBoton btn-nuevo"
                                                            ToolTip="Sirve Para Generar Archivos Plame" OnClick="btnGenerarPlame_Click" />
                                                        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server"
                                                            ConfirmText="Desea Generar el Archivo???" Enabled="True"
                                                            TargetControlID="btnGenerarPlame">
                                                        </cc1:ConfirmButtonExtender>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                            </table>

                                        </fieldset>

                                    </ContentTemplate>
                                </cc1:TabPanel>
                                <cc1:TabPanel HeaderText="Afp y Telecredito" ID="TabPanel2" runat="server">
                                    <ContentTemplate>

                                        <fieldset style="overflow: auto; /*border-style: outset;*/ border-width: thin; height: 80%; min-height: 375px; width: 97%; background-color: White;">

                                            <table>
                                                <tr>
                                                    <td>.</td>
                                                </tr>
                                                <tr>
                                                    <td width="50px" colspan="2" class="style3">
                                                        <asp:Label ID="lblErrorTelecredito" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label3" runat="server" Text="Interfaces: " CssClass="miLabel"
                                                            Width="110px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="cboTelecred" runat="server"
                                                            Width="770px" onchange="ocultaPanel();">
                                                            <%--<asp:ListItem Value="0">Interface AFP</asp:ListItem>--%> <%--@001 I/F--%>
                                                            <asp:ListItem Value="2">Interface AFP - 2015</asp:ListItem>
                                                            <%--<asp:ListItem Value="1">Inteface Pago Bancos</asp:ListItem>--%> <%--@001 I/F--%>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <%--@001 I--%>
                                                <tr>
                                                    <td class="miLabel">Area:</td>
                                                    <td>
                                                        <asp:DropDownList ID="cboArea" runat="server" style="width:100%;"></asp:DropDownList>
                                                        <asp:HiddenField ID="txhAreaIds" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="miLabel">Proyecto:</td>
                                                    <td>
                                                        <asp:DropDownList ID="cboProyecto" runat="server" style="width:100%;"></asp:DropDownList>
                                                        <asp:HiddenField ID="txhProyectoIds" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="miLabel">Centro Costo:</td>
                                                    <td>
                                                        <asp:DropDownList ID="cboCCosto" runat="server" style="width:100%;"></asp:DropDownList>
                                                        <asp:HiddenField ID="txhCCostoIds" runat="server" />
                                                    </td>
                                                </tr>
                                                <%--@001 F--%>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label4" runat="server" Text="Modo de Exportacion: "
                                                            CssClass="miLabel" Width="110px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:RadioButtonList ID="rbModo" runat="server" Font-Names="AENOR Fontana ND"
                                                            RepeatDirection="Horizontal">
                                                            <asp:ListItem Selected="True" Value="0">Archivo Excel</asp:ListItem>
                                                            <%--<asp:ListItem Selected="True" Value="1">Archivo Plano</asp:ListItem>--%> <%--@001 I/F--%>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                    <tr>
                                                        <td></td>
                                                        <td>
                                                            <asp:Button ID="btnGenerarTelecredito" runat="server" Text="Generar"
                                                                CssClass="submit EstiloGeneralBoton btn-nuevo" ToolTip="Sirve Para Generar Archivos Planos" OnClick="btnGenerarTelecredito_Click" />
                                                        </td>

                                                    </tr>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">

                                                        <div id="capa1" style="visibility: hidden;">
                                                            <asp:Panel ID="pnlSeleccion" runat="server" GroupingText="Datos del Telecredito">

                                                                <table>
                                                                    <tr>
                                                                        <td>Banco</td>
                                                                        <td>
                                                                            <asp:DropDownList ID="cboBanco" runat="server"></asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label17" runat="server" Text="Concepto" Width="107px"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="cboConcepto" runat="server" Width="200px" onchange="ocultaPanelFechas();">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="style2">
                                                                            <asp:Label ID="Label18" runat="server" Text="Moneda"></asp:Label>
                                                                        </td>
                                                                        <td class="style2">
                                                                            <asp:DropDownList ID="cboMoneda" runat="server" Width="200px">
                                                                                <asp:ListItem Value="DO">DOLARES AMERICANOS</asp:ListItem>
                                                                                <asp:ListItem Value="MN" Selected="True">NUEVOS SOLES</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label19" runat="server" Text="Con Fecha"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtFecha" runat="server" CssClass="txt" Width="60px"></asp:TextBox>
                                                                            <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server"
                                                                                CultureAMPMPlaceholder="a.m.;p.m." CultureCurrencySymbolPlaceholder="S/."
                                                                                CultureDateFormat="DMY" CultureDatePlaceholder="/" CultureDecimalPlaceholder="."
                                                                                CultureName="es-PE" CultureThousandsPlaceholder="," CultureTimePlaceholder=""
                                                                                Enabled="True" Mask="99/99/9999" MaskType="Date"
                                                                                TargetControlID="txtFecha" UserDateFormat="DayMonthYear">
                                                                            </cc1:MaskedEditExtender>
                                                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                                                                                CssClass="calendar_Theme1" Enabled="True" Format="dd/MM/yyyy"
                                                                                TargetControlID="txtFecha" PopupButtonID="ImageButton1">
                                                                            </cc1:CalendarExtender>
                                                                            <asp:ImageButton ID="ImageButton1" runat="server"
                                                                                ToolTip="Click para mostrar el Calendario"
                                                                                ImageUrl="~/Views/sistemaPlanillas/Imgs/buttons/img_Calendar.png" ImageAlign="TextTop" />
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                                                ControlToValidate="txtFecha" ErrorMessage="*"
                                                                                ValidationGroup="ValidaGrabaCta">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <div id="clase2" style="visibility: hidden;">
                                                                                <table>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblVacaDel" runat="server" Text="Vacaciones del" Width="104px"></asp:Label>
                                                                                        </td>

                                                                                        <td>
                                                                                            <asp:TextBox ID="txtFecha_Inicio" runat="server" CssClass="txt" Width="60px"></asp:TextBox>
                                                                                            <cc1:MaskedEditExtender ID="txtFecha_Inicio_MaskedEditExtender" runat="server"
                                                                                                CultureAMPMPlaceholder="a.m.;p.m." CultureCurrencySymbolPlaceholder="S/."
                                                                                                CultureDateFormat="DMY" CultureDatePlaceholder="/" CultureDecimalPlaceholder="."
                                                                                                CultureName="es-PE" CultureThousandsPlaceholder="," CultureTimePlaceholder=""
                                                                                                Enabled="True" Mask="99/99/9999" MaskType="Date"
                                                                                                TargetControlID="txtFecha_Inicio" UserDateFormat="DayMonthYear">
                                                                                            </cc1:MaskedEditExtender>
                                                                                            <cc1:CalendarExtender ID="txtFecha_Inicio_CalendarExtender" runat="server"
                                                                                                CssClass="calendar_Theme1" Enabled="True" Format="dd/MM/yyyy"
                                                                                                TargetControlID="txtFecha_Inicio" PopupButtonID="ibtnFec_Inicio">
                                                                                            </cc1:CalendarExtender>
                                                                                            <asp:ImageButton ID="ibtnFec_Inicio" runat="server"
                                                                                                ToolTip="Click para mostrar el Calendario"
                                                                                                ImageUrl="~/Views/sistemaPlanillas/Imgs/buttons/img_Calendar.png" ImageAlign="TextTop" />
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                                                                ControlToValidate="txtFecha_Inicio" ErrorMessage="*"
                                                                                                ValidationGroup="ValidaGrabaCta">*</asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                        <td></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblvacaAl" runat="server" Text="Vacaciones al"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtFecha_Final" runat="server" CssClass="txt" Width="60px"></asp:TextBox>
                                                                                            <cc1:MaskedEditExtender ID="txtFecha_Final_MaskedEditExtender" runat="server"
                                                                                                CultureAMPMPlaceholder="a.m.;p.m." CultureCurrencySymbolPlaceholder="S/."
                                                                                                CultureDateFormat="DMY" CultureDatePlaceholder="/" CultureDecimalPlaceholder="."
                                                                                                CultureName="es-PE" CultureThousandsPlaceholder="," CultureTimePlaceholder=""
                                                                                                Enabled="True" Mask="99/99/9999" MaskType="Date"
                                                                                                TargetControlID="txtFecha_Final" UserDateFormat="DayMonthYear">
                                                                                            </cc1:MaskedEditExtender>
                                                                                            <cc1:CalendarExtender ID="txtFecha_Final_CalendarExtender" runat="server"
                                                                                                CssClass="calendar_Theme1" Enabled="True" Format="dd/MM/yyyy"
                                                                                                TargetControlID="txtFecha_Final" PopupButtonID="ibtnFec_Final">
                                                                                            </cc1:CalendarExtender>
                                                                                            <asp:ImageButton ID="ibtnFec_Final" runat="server"
                                                                                                ToolTip="Click para mostrar el Calendario"
                                                                                                ImageUrl="~/Views/sistemaPlanillas/Imgs/buttons/img_Calendar.png" ImageAlign="TextTop" />
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6"
                                                                                                runat="server" ControlToValidate="txtFecha_Final" ErrorMessage="*"
                                                                                                ValidationGroup="ValidaGrabaCta">*</asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                        <td></td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </div>

                                                    </td>
                                                </tr>
                                            </table>


                                        </fieldset>

                                    </ContentTemplate>
                                </cc1:TabPanel>
                            </cc1:TabContainer>

                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="TabContainer1$TabPanel2$btnGenerarTelecredito" />
                            <asp:PostBackTrigger ControlID="TabContainer1$TabPanel1$btnGenerarPlame" />
                            <asp:PostBackTrigger ControlID="TabContainer1$panel1$btnGenerar" />
                        </Triggers>
                    </asp:UpdatePanel>


                    <asp:UpdateProgress ID="UpdateProgress1" runat="server"
                        AssociatedUpdatePanelID="UpdatePanel1"
                        DisplayAfter="1">
                        <ProgressTemplate>
                            <div class="UpdateProgressModalBackground">
                            </div>
                            <center>
                                <div class="UpdateProgressPanel">
                                    Cargando...<br />
                                    <br />
                                    <asp:Image ID="Image2" runat="server" alt="Procesando" ImageUrl="~/Views/sistemaPlanillas/css/ajax-loader.gif" />
                                </div>
                            </center>
                        </ProgressTemplate>
                    </asp:UpdateProgress>


                </fieldset>

            </td>
        </tr>
    </table>
    <%--@001 I--%>
    <script language="javascript" type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function (s, e) {
            reloadJS();
        });

        $(document).ready(function () {
            reloadJS();
        });

        function reloadJS() {
            $("#<%=cboArea.ClientID%>").multipleSelect();
            $("#<%=cboProyecto.ClientID%>").multipleSelect();
            $("#<%=cboCCosto.ClientID%>").multipleSelect();

            $('#<%=cboArea.ClientID%>').change(function (event) {
                var value = $(this).multipleSelect("getSelects").toString();
                $("#<%=txhAreaIds.ClientID%>").val(value);
            });
            $('#<%=cboProyecto.ClientID%>').change(function (event) {
                var value = $(this).multipleSelect("getSelects").toString();
                $("#<%=txhProyectoIds.ClientID%>").val(value);
            });
            $('#<%=cboCCosto.ClientID%>').change(function (event) {
                var value = $(this).multipleSelect("getSelects").toString();
                $("#<%=txhCCostoIds.ClientID%>").val(value);
            });
        }
        
    </script>
    <%--@001 F--%>
</asp:Content>

