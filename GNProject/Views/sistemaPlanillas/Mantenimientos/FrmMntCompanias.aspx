<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmMntCompanias.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Mantenimientos.FrmMntCompanias" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">


    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />

    <link href="../Styles/nuevoEstiloPlanilla.css" rel="stylesheet" type="text/css" />

    <table align="center" width="100%">
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="title">
                            MANTENIMIENTO DE COMPAÑIAS
                        </div>

                        <br />

                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="btnNuevo" runat="server" OnClick="btnNuevo_Click"
                                        Text="Nuevo" Visible="false" />
                                </td>
                                <td colspan="2" align="center">
                                    <asp:Button ID="btnGrabar" runat="server" OnClick="btnGrabar_Click" Visible="false"
                                        Text="Grabar" ValidationGroup="ValidaGraba" />
                                    &nbsp;
                                    <asp:Button ID="btnActualizar" runat="server" OnClick="btnActualizar_Click"
                                        Text="Actualizar" ValidationGroup="ValidaGraba" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        <cc1:TabContainer ID="TabContainer1" Height="415px" runat="server"
                            ActiveTabIndex="2">
                            <cc1:TabPanel ID="TabPanel1" HeaderText="Lista" runat="server">
                                <ContentTemplate>
                                    <div class="textoGeneral">
                                        <table>
                                            <tr>
                                                <td>Compania</td>
                                                <td>
                                                    <asp:TextBox ID="txtCompaniaBuscar" CssClass="txt" Width="300px" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="btnBuscar" runat="server" Height="18px" ToolTip="Buscar"
                                                        ImageUrl="~/Views/sistemaPlanillas/Imgs/Buscar.png" OnClick="btnBuscar_Click" Width="34px" />
                                                </td>
                                                <td></td>
                                            </tr>
                                        </table>
                                    </div>

                                    <div style="overflow: auto; /*width: 890px;*/ height: 350px; border: solid 0px;">
                                        <asp:GridView ID="grvCompania" runat="server" Width="1400px"
                                            AutoGenerateColumns="False" CellPadding="4" CssClass="gridSmall"
                                            DataKeyNames="Compania_Id" ForeColor="#333333"
                                            GridLines="None"
                                            OnRowDataBound="grvCompania_RowDataBound"
                                            OnRowCommand="grvCompania_RowCommand"
                                            OnRowDeleting="grvCompania_RowDeleting" AllowPaging="True"
                                            OnPageIndexChanging="grvCompania_PageIndexChanging">
                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ibtnSelect" runat="server" ToolTip="Seleccionar" Visible="false"
                                                            CommandName="Select" Height="20px" ImageUrl="~/Views/sistemaPlanillas/Imgs/Editar.png"
                                                            Width="20px" OnClick="ibtnSelect_Click" />
                                                        <asp:ImageButton ID="ibtnEliminar" runat="server" ToolTip="Eliminar" Visible="false"
                                                            CommandName="Delete" Height="20px" ImageUrl="~/Views/sistemaPlanillas/Imgs/btnDelete.png" Width="20px"
                                                            OnClientClick="return confirm('¿Esta Seguro De Eliminar?');" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Compania_Id" HeaderText="Compania_Id" ReadOnly="True">
                                                    <ItemStyle Width="50px" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Descripcion" HeaderText="Descripción"></asp:BoundField>
                                                <asp:BoundField DataField="Direccion" HeaderText="Dirección"></asp:BoundField>
                                                <asp:BoundField DataField="Representante" HeaderText="Representante"></asp:BoundField>
                                                <asp:BoundField DataField="Ruc" HeaderText="RUC"></asp:BoundField>
                                                <asp:BoundField DataField="Num_Telf" HeaderText="Num. Telf."></asp:BoundField>
                                                <asp:BoundField DataField="Nro_DocIde" HeaderText="Nro. Doc. Ide."></asp:BoundField>
                                                <asp:BoundField DataField="Area_AFP" HeaderText="Area AFP"></asp:BoundField>
                                                <asp:BoundField DataField="Telf_Area_AFP" HeaderText="Telf. Area AFP"></asp:BoundField>
                                                <asp:BoundField DataField="Nro_Libro" HeaderText="Nro. Libro"></asp:BoundField>
                                                <asp:BoundField DataField="Nro_Partida" HeaderText="Nro. Partida"></asp:BoundField>
                                            </Columns>
                                            <EditRowStyle BackColor="#999999" />
                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                            <SelectedRowStyle BackColor="#9ADBFA" />
                                        </asp:GridView>
                                    </div>

                                </ContentTemplate>
                            </cc1:TabPanel>
                            <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Datos Principales">
                                <ContentTemplate>
                                    <div class="textoGeneral">
                                        <table>
                                            <tr>
                                                <td valign="top">
                                                    <table>
                                                        <tr>
                                                            <td>Compania Id</td>
                                                            <td>
                                                                <asp:Label ID="lblCompania_Id" runat="server" Width="50px" Height="18px" CssClass="lblCod"></asp:Label>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>Razón Social</td>
                                                            <td>
                                                                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="txt"
                                                                    Width="300px"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                                    ControlToValidate="txtDescripcion" ErrorMessage="*" Text="*"
                                                                    ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>RUC</td>
                                                            <td>
                                                                <asp:TextBox ID="txtRUC" runat="server" CssClass="txt"
                                                                    Width="300px"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                                    ControlToValidate="txtRUC" ErrorMessage="*" Text="*"
                                                                    ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>Reg. Patronal</td>
                                                            <td>
                                                                <asp:TextBox ID="txtReg_Patronal" runat="server" CssClass="txt"
                                                                    Width="300px"></asp:TextBox>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>Dirección</td>
                                                            <td>
                                                                <asp:TextBox ID="txtDireccion" runat="server" CssClass="txt"
                                                                    Width="300px"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                                                    ControlToValidate="txtDireccion" ErrorMessage="*" Text="*"
                                                                    ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>Telefóno</td>
                                                            <td>
                                                                <asp:TextBox ID="txtTelefono" runat="server" CssClass="txt"
                                                                    Width="300px"></asp:TextBox>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>Representante</td>
                                                            <td>
                                                                <asp:TextBox ID="txtRepresentante" runat="server" CssClass="txt"
                                                                    Width="300px"></asp:TextBox>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>Tipo Documento</td>
                                                            <td>
                                                                <asp:DropDownList ID="cboTipo_Documento" Width="300px" CssClass="ddl" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>Nro. Doc.</td>
                                                            <td>
                                                                <asp:TextBox ID="txtNro_Doc" CssClass="txt" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>Área ó Dpto.</td>
                                                            <td>
                                                                <asp:TextBox ID="txtArea_AFP" CssClass="txt" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>Telf. Área ó Dpto.</td>
                                                            <td>
                                                                <asp:TextBox ID="txtTelf_Area_AFP" CssClass="txt" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                    </table>

                                                    <asp:Panel ID="pnlUbigeo" runat="server" GroupingText="Ubigeo">
                                                        <table>
                                                            <tr>
                                                                <td>Departamento</td>
                                                                <td>
                                                                    <asp:DropDownList ID="cboDepartamento" runat="server" CssClass="ddl"
                                                                        Width="150px" AutoPostBack="True"
                                                                        OnSelectedIndexChanged="cboDepartamento_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                                        ControlToValidate="cboDepartamento" InitialValue="--Seleccione--" ErrorMessage="*" Text="*"
                                                                        ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Provincia</td>
                                                                <td>
                                                                    <asp:DropDownList ID="cboProvincia" runat="server" CssClass="ddl"
                                                                        Width="150px" AutoPostBack="true" OnSelectedIndexChanged="cboProvincia_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                                        ControlToValidate="cboProvincia" InitialValue="--Seleccione--" ErrorMessage="*" Text="*"
                                                                        ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Distrito</td>
                                                                <td>
                                                                    <asp:DropDownList ID="cboDistrito" runat="server" CssClass="ddl"
                                                                        Width="150px">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                                        ControlToValidate="cboDistrito" InitialValue="--Seleccione--" ErrorMessage="*" Text="*"
                                                                        ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:CheckBox ID="ckCia_Default" Text="Compañia Local?" CssClass="ck" runat="server" />
                                                </td>
                                                <td valign="top">
                                                    <table>
                                                        <tr>
                                                            <td>Logo</td>
                                                            <td>
                                                                <asp:FileUpload ID="FileLogo" runat="server" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>
                                                                <asp:Image ID="imgLogoEmpresa" runat="server" Width="150px" Height="100px" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Firma Digital</td>
                                                            <td>
                                                                <asp:FileUpload ID="FileFirma" runat="server" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>
                                                                <asp:Image ID="imgFirmaEmpresa" runat="server" Width="150px" Height="100px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>

                                    </div>

                                </ContentTemplate>
                            </cc1:TabPanel>
                            <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="Datos Secundarios">
                                <ContentTemplate>
                                    <div class="textoGeneral">
                                        <table>
                                            <tr>
                                                <td valign="top">
                                                    <table>
                                                        <tr>
                                                            <td>Bcp Diskette S/.</td>
                                                            <td>
                                                                <asp:TextBox ID="txtCod_tel_soles" CssClass="txt" runat="server"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Bcp Diskette $.</td>
                                                            <td>
                                                                <asp:TextBox ID="txtCod_tel_dolares" CssClass="txt" runat="server"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Nro. Libro</td>
                                                            <td>
                                                                <asp:TextBox ID="txtNro_Libro" CssClass="txt" runat="server"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Nro. Partida</td>
                                                            <td>
                                                                <asp:TextBox ID="txtNro_Partida" CssClass="txt" runat="server"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td>CIIU</td>
                                                            <td>
                                                                <asp:DropDownList ID="cboCIIU" CssClass="ddl" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr style="visibility: hidden;">
                                                            <td>Ruta Reportes</td>
                                                            <td>
                                                                <asp:FileUpload ID="FileUpload_RutaReportes" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr style="visibility: hidden;">
                                                            <td>
                                                                <asp:Button ID="btnCtasBancarias" runat="server" Text="Button" />
                                                            </td>
                                                            <td></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td></td>
                                            </tr>
                                        </table>

                                    </div>

                                </ContentTemplate>
                            </cc1:TabPanel>
                            <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="Configuración Correo">
                                <ContentTemplate>
                                    <div class="textoGeneral">
                                        <table>
                                            <tr>
                                                <td>Servidor SMTP:</td>
                                                <td>
                                                    <asp:TextBox ID="txtSMTP_Host" runat="server" Width="250px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                                        ControlToValidate="txtSMTP_Host" ErrorMessage="*" Text="*"
                                                        ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Puerto:</td>
                                                <td>
                                                    <asp:TextBox ID="txtSMTP_Port" runat="server" Width="50"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                                        ControlToValidate="txtSMTP_Port" ErrorMessage="*" Text="*"
                                                        ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>SSL:</td>
                                                <td><asp:CheckBox ID="chkSMTP_SSL" runat="server"></asp:CheckBox></td>
                                            </tr>
                                            <tr style="display:none;">
                                                <td>Dirección Correo:</td>
                                                <td><asp:TextBox ID="txtSMTP_MailAddress" runat="server" Width="250px"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>Nombre a Mostrar:</td>
                                                <td>
                                                    <asp:TextBox ID="txtSMTP_DisplayName" runat="server" Width="250px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                                        ControlToValidate="txtSMTP_DisplayName" ErrorMessage="*" Text="*"
                                                        ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Usuario Correo:</td>
                                                <td>
                                                    <asp:TextBox ID="txtSMTP_User" runat="server"  Width="250px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                                        ControlToValidate="txtSMTP_User" ErrorMessage="*" Text="*"
                                                        ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Clave:</td>
                                                <td><asp:TextBox ID="txtSMTP_Pwd" runat="server" TextMode="Password"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2"><a href="../PruebaEnvioCorreo.aspx" target="_blank" style="color:darkblue;">Clic aquí para realizar un envío de correo a modo de prueba</a></td>
                                            </tr>
                                        </table>
                                    </div>
                                </ContentTemplate>
                            </cc1:TabPanel>
                        </cc1:TabContainer>

                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnActualizar" />
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
</asp:Content>
