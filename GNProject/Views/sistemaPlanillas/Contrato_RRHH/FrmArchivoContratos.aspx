<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmArchivoContratos.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Contrato_RRHH.FrmArchivoContratos" %>

<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/nuevoEstiloPlanilla.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        function AbrirModal(pagina) {
            var navegador = '';
            if (navigator.userAgent.indexOf('MSIE') != -1) {
                navegador = 'MSIE';
            } else if (navigator.userAgent.indexOf('Firefox') != -1) {
                navegador = 'Firefox';
            } else if (navigator.userAgent.indexOf('Chrome') != -1) {
                navegador = 'Chrome';
            } else if (navigator.userAgent.indexOf('Opera') != -1) {
                navegador = 'Opera';
            } else {
                navegador = 'undefined';
            }
            var vReturnValue;

            if (navegador == 'Chrome' || navegador == 'Opera') {
                vReturnValue = window.open(pagina, "", "toolbar=no,scrollbars=yes, resizable=yes,HEIGHT=590,WIDTH=950,location=no");
            } else {
                vReturnValue = window.showModalDialog(pagina, "", "dialogHeight: 590px; dialogWidth: 950px; edge: Raised; center: yes; help: no; resizable: yes; scroll:off; status: no;titlebar=no;");
            }
            if (vReturnValue != null && vReturnValue == true) {
                __doPostBack('', '');
                return vReturnValue
            }
            else {
                return false
            }
        }

        //function mostrardiv() {

        //    div = document.getElementById('contdoc');
        //    div.style.display = '';

        //}
        //function cerrardiv() {
        //    div = document.getElementById('contdoc');
        //    div.style.display = 'none';

        //}


    </script>
    <table align="center" width="100%">
        <tr>
            <td>

                <fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px; /*border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black;*/ min-height: 500px; overflow: hidden; border-radius: 8px 8px 0px 0px; /*border-top: solid 1px black;*/">

                    <br />
                    <asp:Label ID="Label9" runat="server" Text="HISTORIAL DE CONTRATOS" CssClass="miTitulo"></asp:Label>
                    

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>

                            <table width="100%" style="font-family: Arial; font-size: 11px">
                                <tr>
                                    <td>
                                        <table style="width: 100%">

                                            <tr>
                                                <td colspan="6">&nbsp;</td>

                                            </tr>
                                            <tr>
                                                <td align="left" rowspan="15" colspan="2" style="width: 230px; padding: -21 -2 -2 -2; margin: -21 -2 -2 -2;" valign="top">
                                                    <div style="width: 100%; overflow: auto; height: 500px; margin-right: 0px;">
                                                        <asp:TreeView ID="treContratos" runat="server" ShowLines="True"
                                                            OnSelectedNodeChanged="treContratos_SelectedNodeChanged">
                                                        </asp:TreeView>
                                                    </div>
                                                </td>
                                                <td></td>
                                                <td align="left" colspan="4" rowspan="15" style="width: 500px; padding: -21 -2 -2 -2; margin: -21 -2 -2 -2;" valign="top">
                                                    <div id="contdoc" runat="server" visible="false" style="width: 100%; overflow: auto; height: 450px;">
                                                        <table style="width: 100%;">
                                                            <tr>
                                                                <td colspan="5">
                                                                    <h3>Subir Archivo de Contrato</h3>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblDatos" runat="server" Style="color: #006699"
                                                                        Text="Datos del Contrato de :"></asp:Label>
                                                                </td>
                                                                <td colspan="4">

                                                                    <asp:Label ID="lblpersonal" runat="server" Text=""></asp:Label>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td colspan="5">
                                                                    <asp:GridView ID="gvcontratos" runat="server" AutoGenerateColumns="False"
                                                                        BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px"
                                                                        CellPadding="4" GridLines="Horizontal" Width="100%"
                                                                        HorizontalAlign="Justify"
                                                                        OnSelectedIndexChanged="gvcontratos_SelectedIndexChanged"
                                                                        OnRowDataBound="gvcontratos_RowDataBound">
                                                                        <RowStyle BackColor="White" ForeColor="#333333" />
                                                                        <Columns>
                                                                            <asp:BoundField DataField="Fecha_ingreso" HeaderText="Fecha Ingreso" />
                                                                            <asp:BoundField DataField="Fecha_ini_contrato" HeaderText="Fecha Inicio de Contrato" />
                                                                            <asp:BoundField DataField="Fecha_fin_contrato" HeaderText="Fecha Fin de Contrato" />
                                                                            <asp:BoundField DataField="Descripcion" HeaderText="Tipo de Contrato" />
                                                                            <asp:BoundField HeaderText="Archivo" />
                                                                            <asp:CommandField HeaderText="Ver" ShowSelectButton="True" />


                                                                        </Columns>
                                                                        <FooterStyle BackColor="White" ForeColor="#333333" />
                                                                        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                                                                        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                                                        <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" />
                                                                    </asp:GridView>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="5">
                                                                    <asp:Label ID="lblancla" runat="server"
                                                                        Text="Datos del Archivo" Style="font-weight: 700"></asp:Label></td>

                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="style7">Nombre del Archivo PDF:                             </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:Label ID="lblnombrepdf" runat="server" Text="" Width="100%"></asp:Label>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" class="style5"></td>
                                                                <td align="right"></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">
                                                                    <asp:FileUpload ID="FUpdf" runat="server" />

                                                                </td>
                                                                <td class="style3">
                                                                    <asp:Button ID="btnsubir" runat="server" Text="Subir"
                                                                        OnClick="btnsubir_Click" />
                                                                </td>
                                                                <td class="style2">
                                                                    <asp:HyperLink ID="VER" runat="server" Target="_blank" ForeColor="Blue">Ver Archivo</asp:HyperLink>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">
                                                                    <asp:Label ID="lblcodigo" runat="server" Text="" Visible="false"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">
                                                                    <asp:Label ID="archivosel" runat="server" Text="" Visible="false"></asp:Label>
                                                                </td>

                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>


                                        </table>
                                    </td>
                                </tr>
                            </table>

                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="treContratos" EventName="SelectedNodeChanged" />

                            <asp:PostBackTrigger ControlID="btnsubir" />
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

                </fieldset>

            </td>
        </tr>
    </table>

</asp:Content>


