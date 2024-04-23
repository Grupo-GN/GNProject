<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmSeguimientoContrato.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Contrato_RRHH.FrmSeguimientoContrato" %>

<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <link href="../Styles/nuevoEstiloPlanilla.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />
    <table width="100%">
        <tr>
            <td style="width: 100%">
                <asp:Label ID="Label1" runat="server" Text="SEGUIMIENTO DE CONTRATOS" CssClass="miTitulo"></asp:Label></td>
            <td style="text-align:right;">
                <asp:Button ID="btnGrabar" runat="server" Text="Grabar" ToolTip="Grabar" CssClass="EstiloGeneralBoton" OnClick="btnGenerar_Click" />
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Area" CssClass="miLabel"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="cboCategoria_Auxiliar" runat="server" CssClass="ddl" Width="200px"
                            AutoPostBack="True" OnSelectedIndexChanged="cboCategoriaAuxiliar_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
            <div style="overflow: auto; width: 100%;">
                <table width="1000px" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="vertical-align: top; border-right-style: none; border-right-width: 0px;" align="right">
                            <asp:GridView ID="grv" runat="server" CssClass="gridSmall" AutoGenerateColumns="false" Width="350px">
                                <HeaderStyle Height="80px" />
                                <RowStyle Height="30px" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Grabar" ItemStyle-Width="50px">
                                        <HeaderTemplate>
                                            Grabar
                                            <input name="SelectAllCheckBox" onclick="SelectAllCheckBoxesName(this, 'grv', 'chkGuardar')" type="checkbox" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkGuardar" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Nombres" HeaderText="Nombres" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="300px" />
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            </asp:GridView>
                        </td>
                        <td align="left" style="border-left-style: none; border-left-width: 0px;">
                            <div style="overflow: auto; width: 650px" id="divgrid">
                                <asp:GridView ID="GrvListaPersonal" runat="server" AutoGenerateColumns="False"
                                    CssClass="gridSmall" DataKeyNames="Personal_Id,Periodo_Id" ShowFooter="false" Width="1000px">
                                    <HeaderStyle Height="80px" />
                                    <RowStyle Height="30px" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Grabar" Visible="false">
                                            <HeaderTemplate>
                                                Grabar
                                                <input name="SelectAllCheckBox" onclick="SelectAllCheckBoxesName(this, 'GrvListaPersonal', 'chkGuardar')" type="checkbox" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkGuardar" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Nombres" HeaderText="Nombres" ItemStyle-HorizontalAlign="Left" Visible="false" />
                                        <asp:BoundField DataField="Localidad" HeaderText="Localidad">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Area" HeaderText="Area">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Fecha_Ingreso" HeaderText="Fecha Ingreso" DataFormatString="{0:dd/MM/yyyy}">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Fecha_Ini_Contrato" HeaderText="Fecha Ini Contrato" DataFormatString="{0:dd/MM/yyyy}">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Fecha_Fin_Contrato" HeaderText="Fecha Fin Contrato" DataFormatString="{0:dd/MM/yyyy}">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Correo 30">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkboxCorreo20" runat="server" Checked='<%#Bind("PrimerCorreo")%>' Enabled="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Correo 15">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkboxCorreo7" runat="server" Checked='<%#Bind("SegundoCorreo")%>' Enabled="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Renovado">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkboxRenovado" runat="server" Checked='<%#Bind("Renovado")%>' />
                                                <asp:CheckBox ID="chkboxRenovado_Cambio" runat="server" Checked='<%#Bind("Renovado")%>' Visible="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="FechaRenovacion" HeaderText="Fecha Renov" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:TemplateField HeaderText="Usuario Renov">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUsuarioRenov" runat="server" Text='<%#Bind("UsuarioRenueva") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Firmado">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkboxFirmado" runat="server" Checked='<%#Bind("Firmado")%>' />
                                                <asp:CheckBox ID="chkboxFirmado_Cambio" runat="server" Checked='<%#Bind("Firmado")%>' Visible="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="FechaFirma" HeaderText="Fecha Firma" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:TemplateField HeaderText="Usuario Firmo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUsuarioFirmo" runat="server" Text='<%#Bind("UsuarioFirma") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Entrega para Firma Representate Legal">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkboxEntrega" runat="server" Checked='<%#Bind("EntregaFirmaRepresentanteLegal")%>' />
                                                <asp:CheckBox ID="chkboxEntrega_Cambio" runat="server" Checked='<%#Bind("EntregaFirmaRepresentanteLegal")%>' Visible="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="FechaEntregaFirmaRepresentanteLegal" HeaderText="Fecha Entrega Firma Representante Legal" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:TemplateField HeaderText="Retornado Firmado Representante Legal">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkboxRetornado" runat="server" Checked='<%#Bind("RetornadoFirmadoRepresentanteLegal")%>' />
                                                <asp:CheckBox ID="chkboxRetornado_Cambio" runat="server" Checked='<%#Bind("RetornadoFirmadoRepresentanteLegal")%>' Visible="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="FechaRetornadoFirmadoRepresentanteLegal" HeaderText="Fecha Retornado Firmado Representante Legal" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:TemplateField HeaderText="Numero Envio Ministerio Trabajo">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtNumeroEnvio" runat="server" CssClass="textbox" Text='<%#Bind("NumeroEnvioMinisterioTrabajo") %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Cesado">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkboxCesado" runat="server" Checked='<%#Bind("Cesado") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Observaciones" HeaderText="Observaciones" ItemStyle-Width="250px" ItemStyle-Wrap="false" />
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
            </div>
        </ContentTemplate>
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
    <script type="text/javascript">
        function SelectAllCheckBoxesName(CheckBoxControl, GridName, CheckBoxName) {
            if (CheckBoxControl.checked == true) {
                var i;
                for (i = 0; i < document.forms[0].elements.length; i++) {
                    if ((document.forms[0].elements[i].type == 'checkbox') &&
            (document.forms[0].elements[i].name.indexOf(GridName) > -1)) {
                        if (document.forms[0].elements[i].name.indexOf(CheckBoxName) != -1) {
                            document.forms[0].elements[i].checked = true;
                        }
                    }
                }
            }
            else {
                var i;
                for (i = 0; i < document.forms[0].elements.length; i++) {
                    if ((document.forms[0].elements[i].type == 'checkbox') &&
            (document.forms[0].elements[i].name.indexOf(GridName) > -1)) {
                        if (document.forms[0].elements[i].name.indexOf(CheckBoxName) != -1) {
                            document.forms[0].elements[i].checked = false;
                        }
                    }
                }
            }
        }
    </script>
</asp:Content>
