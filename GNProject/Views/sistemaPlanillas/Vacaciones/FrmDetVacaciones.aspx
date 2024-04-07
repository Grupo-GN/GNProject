<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="FrmDetVacaciones.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Vacaciones.FrmDetVacaciones" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table width="100%">
        <tr>
            <td style="width: 50%">
                <asp:Label ID="Label1" runat="server" Text="VACACIONES DETALLADA POR PERSONA" CssClass="title"></asp:Label></td>
            <td style="text-align: right;">
                <asp:Button ID="btnBuscar" runat="server" CssClass="button" Text="Buscar" OnClick="btnBuscar_Click" ValidationGroup="ValidaFiltros" />
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td class="miLabel">Localidad:
                    </td>
                    <td>
                        <asp:DropDownList ID="cboLocalidad" runat="server" CssClass="ddl" Width="200px"
                            AutoPostBack="true" OnSelectedIndexChanged="cboLocalidad_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td class="miLabel">Area:
                    </td>
                    <td>
                        <asp:DropDownList ID="cboCategoria_Auxiliar" runat="server" CssClass="ddl" Width="200px"
                            AutoPostBack="true" OnSelectedIndexChanged="cboCategoria_Auxiliar_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td class="miLabel">Personal:
                    </td>
                    <td>
                        <asp:DropDownList ID="cboPersonal" runat="server" CssClass="ddl" Width="200px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="miLabel">Fecha a Procesar:
                    </td>
                    <td>
                        <asp:TextBox ID="txtFechaProceso" runat="server" CssClass="textbox"
                            Width="70px" MaxLength="10"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtFechaProceso_CalendarExtender" runat="server"
                            Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaProceso" CssClass="calendar_Theme1">
                        </cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="txtFechaProceso" ErrorMessage="*" ValidationGroup="ValidaFiltros">
                        </asp:RequiredFieldValidator>
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
            </table>
            <br />
            <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" ForeColor="DarkOrange"></asp:Label>
            <div style="overflow: auto; width: 100%; max-height: 400px;">
                <asp:GridView ID="grvBandeja" runat="server"
                    AutoGenerateColumns="False" CellPadding="2" CssClass="gridSmall"
                    GridLines="None"
                    OnRowDataBound="grvBandeja_RowDataBound"
                    ShowFooter="True"
                    Width="100%">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="Vacaciones_Id" HeaderText="Vacaciones_Id" />
                        <asp:BoundField DataField="FechaInicio" HeaderText="Periodo Inicio">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FechaFin" HeaderText="Periodo Fin">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DerechoVac" HeaderText="Derecho Vac.">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DiasTomados" HeaderText="Dias Tomados">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DiasSaldo" HeaderText="Dias Saldo">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Detalle">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" ToolTip="Ver Detalle"
                                    CommandName='<%# Eval("Vacaciones_Id") %>' Height="20px"
                                    ImageUrl="~/Views/sistemaPlanillas/img/Buscar.png" OnClick="ImageButton1_Click" />
                                <cc1:ModalPopupExtender ID="ImageButton1_ModalPopupExtender" runat="server"
                                    DynamicServicePath="" Enabled="True" TargetControlID="ImageButton1"
                                    BackgroundCssClass="modalBackground" CancelControlID="btnCancelVaca"
                                    PopupControlID="PanelModalVaca">
                                </cc1:ModalPopupExtender>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Indemnizacion" HeaderText="Indemnizacion">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Cancelado" HeaderText="Dias Indemnizacion Cancelado" />
                        <asp:BoundField DataField="SaldoIndemnizacion" HeaderText="Saldo Indemnizacion" />
                        <asp:TemplateField HeaderText="Cancelacion Indemnizacion">
                            <ItemTemplate>
                                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="button"
                                    OnClick="btnAgregar_Click" CommandName='<%#Eval("Vacaciones_Id")%>' />
                                <cc1:ModalPopupExtender ID="btnAgregar_ModalPopupExtender" runat="server"
                                    DynamicServicePath="" Enabled="true" TargetControlID="btnAgregar"
                                    BackgroundCssClass="modalBackground" CancelControlID="btnCancelar" PopupControlID="pnlAgregarVacaciones">
                                </cc1:ModalPopupExtender>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="#336699" Font-Size="X-Small" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                </asp:GridView>
            </div>

            <asp:Panel ID="PanelModalVaca" runat="server" CssClass="popupControl">
                <br />
                <center>
                    <table>
                        <tr>
                            <td>&nbsp;</td>
                            <td style="font-size: 14px; color: #666666; font-weight: bold;">Detalle de Vacaciones del Periodo
                                <asp:Label ID="lblPeriodoDetVaca" runat="server"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Label ID="lblMensajeDetVaca" runat="server" Font-Bold="True"
                                    ForeColor="Red"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="3" style="text-align: center">
                                <asp:GridView ID="GrvVacacionDet" runat="server" AutoGenerateColumns="False"
                                    CssClass="gridSmall" ShowFooter="True" Width="450px">
                                    <Columns>
                                        <asp:BoundField DataField="Vacaciones_Id" HeaderText="Vacaciones_Id" Visible="false" />
                                        <asp:BoundField DataField="PeriodoInicio" HeaderText="Periodo Inic." Visible="false">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PeriodoFin" HeaderText="Periodo Fin." Visible="false">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FechaInicio" HeaderText="Fec. Inic.">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FechaFin" HeaderText="Fecha Fin.">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="MesVacacion" HeaderText="Mes Vacacion">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DiasTomados" HeaderText="Dias Tomados">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                    </Columns>
                                    <PagerStyle CssClass="pgr" />
                                    <AlternatingRowStyle CssClass="alt" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Button ID="btnCancelVaca" runat="server" CssClass="button" Text="Cerrar" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </center>
                <br />
            </asp:Panel>

            <asp:Panel ID="pnlAgregarVacaciones" runat="server" CssClass="popupControl" BorderStyle="Solid" BorderColor="#C2E1F6" BorderWidth="5px">
                <asp:UpdatePanel ID="upd" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>

                        <br />
                        <span style="font-size: 14px; color: #666666; font-weight: bold; text-align: center;">Cancelar Dias de Indemnizacion
                        <br />
                            Periodo:
                            <asp:Label ID="lblPeriodoVac" runat="server" Text=""></asp:Label>
                        </span>
                        <br />
                        <table>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td align="left" colspan="3">Fecha Inicio:
                                <asp:TextBox ID="txtFechaInicio" runat="server" CssClass="textbox" AutoPostBack="true">
                                </asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="calendar_Theme1"
                                        Enabled="true" Format="dd/MM/yyyy" TargetControlID="txtFechaInicio">
                                    </cc1:CalendarExtender>
                                </td>
                                <td align="left">Fecha Fin:
                                <asp:TextBox ID="txtFechaFin" runat="server" CssClass="textbox" AutoPostBack="true">
                                </asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="calendar_Theme1"
                                        Enabled="true" Format="dd/MM/yyyy" TargetControlID="txtFechaFin">
                                    </cc1:CalendarExtender>
                                </td>
                                <td>
                                    <asp:Button ID="btnAgregarVacCan" runat="server" Text="Agregar" CssClass="button" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">Total de Dias Cancelados:
                                <asp:Label ID="lblDias" runat="server" Text=""></asp:Label>
                                </td>
                                <td align="left"></td>
                                <td></td>
                            </tr>
                        </table>
                        <table width="400px">
                            <tr>
                                <td>
                                    <asp:GridView ID="grvVacacionesCanceladas" runat="server" AutoGenerateColumns="false"
                                        CssClass="gridSmall" DataKeyNames="Personal_IndemnizacionCanceladaDetalle_Id">
                                        <Columns>
                                            <asp:BoundField DataField="Vacaciones_id" HeaderText="Vacacion" Visible="false" />
                                            <asp:BoundField DataField="Personal_Id" HeaderText="Vacacion" Visible="false" />
                                            <asp:BoundField DataField="Fecha_Inicio" HeaderText="FechaInicio" DataFormatString="{0:dd/MM/yyyy}" />
                                            <asp:BoundField DataField="Fecha_Fin" HeaderText="FechaFin" DataFormatString="{0:dd/MM/yyyy}" />
                                            <asp:BoundField DataField="Dias" HeaderText="Dias" />
                                            <asp:TemplateField HeaderText="Eliminar">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="Del" ImageUrl="~/Views/sistemaPlanillas/Images/Del.png" CommandArgument='<%#Eval("Personal_IndemnizacionCanceladaDetalle_Id") %>'
                                                        runat="server" Width="15px" CommandName="Del" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>

                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:Button ID="btnCancelar" runat="server" CssClass="button" Text="Cerrar" />
                <br />
            </asp:Panel>

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server"
        DisplayAfter="1">
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

    <script type="text/javascript">
        function fnClickPostBack(sender, e) {
            __doPostBack(sender, e);
        } 
    </script>
</asp:Content>
