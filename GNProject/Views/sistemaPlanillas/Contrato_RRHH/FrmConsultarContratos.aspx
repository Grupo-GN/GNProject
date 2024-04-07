<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmConsultarContratos.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Contrato_RRHH.FrmConsultarContratos" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <table align="center" width="100%">
        <tr>
            <td>

                    <asp:Label ID="Label1" runat="server" Text="CONSULTAR CONTRATOS" CssClass="title"></asp:Label>
                    <br />
                    <br />

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>


                                <table>
                                    <%--<tr>
                                        <td align="left" class="style5">
                                            <b>
                                                <asp:CheckBox ID="chkFunciones" runat="server" Checked="false" Text="Con Funciones" AutoPostBack="true" Visible="false" /></b>

                                            <asp:CheckBoxList ID="chklstFunc" runat="server" Visible="false"></asp:CheckBoxList></td>
                                    </tr>--%>
                                    <tr>
                                        <td>

                                            <div>
                                                <asp:Panel ID="pnlFiltro" runat="server">
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
                                                            <td>
                                                                <asp:ImageButton ID="btnBuscar" runat="server" Height="18px" ToolTip="Buscar"
                                                                    ImageUrl="~/Views/sistemaPlanillas/Imgs/Buscar.png" Width="34px" OnClick="btnBuscar_Click" />
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </div>


                                            <div style="overflow: auto; width: 100%;">

                                                <asp:GridView ID="grvLista" runat="server"
                                                    ShowHeader="true"
                                                    PageSize="13"
                                                    AutoGenerateColumns="False" CellPadding="2" CssClass="gridSmall"
                                                    DataKeyNames="Personal_Id"
                                                    GridLines="None"
                                                    OnPageIndexChanging="grvLista_PageIndexChanging"
                                                    OnRowDataBound="grvLista_RowDataBound" Width="100%">
                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                    <Columns>
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
                                                        <asp:TemplateField HeaderText="IMPRIMIR CONTRATO">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnImprimir" runat="server" Text="Imprimir"
                                                                    OnClick="btnImprimir_Click" CommandName='<%#Eval("Personal_Id") %>' />
                                                            </ItemTemplate>
                                                            <HeaderStyle ForeColor="#336699" Font-Size="X-Small"
                                                                Font-Bold="True" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="EXPORTAR CONTRATO">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnExportarWord" runat="server" Text="Exportar Word"
                                                                    OnClick="btnExportarWord_Click" CommandName='<%#Eval("Personal_Id") %>' />
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

                        </ContentTemplate>
                        <Triggers>

                            <asp:PostBackTrigger ControlID="grvLista" />
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

            </td>
        </tr>
    </table>
    <script type="text/javascript">
        function fn_VistaPreliminar(html) {
            var css = "<style type='text/css'>@media print { #noprint { display:none; } } .link:hover { color: #c0c0c0; } .link { color: #003300; font-family: Arial; font-size: 11px; cursor: pointer; }</style>";
            var html_Cabecera = css + '<div id="noprint"><a class="link" href="javascript:;" onclick="window.print();">Imprimir</a>'
            + ' <a class="link" href="" onclick="window.close();">Cerrar</a><br /></div>';
            var tx_detalle_html = html_Cabecera + html;
            var wnd = window.open("about:blank", "newWindow", "height=500,width=850,top=0,left=0,resizable=yes,scrollbars=yes");
            if (wnd == null) {
                alert("Las ventanas emergentes para este sitio web est� bloqueda. Para poder imprimir los contratos debe habilitar/permitir las ventanas emergentes para este sitio web.");
            }
            else {
                wnd.document.write(tx_detalle_html);
            }
            //wnd.print();
        }
    </script>
</asp:Content>

