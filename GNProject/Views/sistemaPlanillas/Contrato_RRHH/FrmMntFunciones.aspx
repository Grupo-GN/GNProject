<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmMntFunciones.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Contrato_RRHH.FrmMntFunciones" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <table align="center" width="100%">
        <tr>
            <td>


                    <br />
                    <asp:Label ID="Label9" runat="server" Text="MANTENIMIENTO DE FUNCIONES" CssClass="title"></asp:Label>
                    <br />
                    <br />

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>

                            <div>
                                
                                    <div>
                                        <asp:Label ID="Label2" runat="server" Text="Nuevo Cargo de Funciones" CssClass="miTituloOnTab"></asp:Label>
                                    </div>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label4" runat="server" Text="CARGO: " CssClass="miLabel"></asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="cboCargoNuevo" runat="server" CssClass="ddl"
                                                    OnSelectedIndexChanged="cboCargoNuevo_SelectedIndexChanged"
                                                    AutoPostBack="True">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                    ControlToValidate="cboCargoNuevo" ErrorMessage="*" InitialValue="-Seleccione-" ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text="FUNCION:" CssClass="miLabel"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtFuncionNuevo" runat="server" Width="280px" CssClass="txt"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtFuncionNuevo"
                                                    runat="server" ErrorMessage="*" Text="*" ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="btnGrabar" runat="server" Height="25px" ToolTip="Grabar"
                                                    ImageUrl="~/Views/sistemaPlanillas/Imgs/btnSave.png"
                                                    ValidationGroup="ValidaGraba" Width="25px" OnClick="btnGrabar_Click" />
                                            </td>

                                        </tr>
                                    </table>
                            </div>
                            <div style="width: 100%;">
                                <asp:GridView ID="grvFunciones" runat="server" Width="100%"
                                    AutoGenerateColumns="False" CellPadding="2" CssClass="gridSmall"
                                    DataKeyNames="Cargo_Funcion_Id,Cargo_Id" ForeColor="#333333"
                                    GridLines="None" OnRowCancelingEdit="grvFunciones_RowCancelingEdit"
                                    OnRowCommand="grvFunciones_RowCommand"
                                    OnRowDataBound="grvFunciones_RowDataBound"
                                    OnRowDeleting="grvFunciones_RowDeleting"
                                    OnRowEditing="grvFunciones_RowEditing"
                                    OnRowUpdating="grvFunciones_RowUpdating" ShowFooter="true"
                                    AllowPaging="true"
                                    OnPageIndexChanging="grvFunciones_PageIndexChanging">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Acciones">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibtnSelect" runat="server" ToolTip="Editar"
                                                    CommandName="Edit" ImageUrl="~/Views/sistemaPlanillas/Icon/Modify.gif" />
                                                <asp:ImageButton ID="ibtnEliminar" runat="server" ToolTip="Eliminar"
                                                    CommandName="Delete" ImageUrl="~/Views/sistemaPlanillas/Icon/delete.gif"
                                                    OnClientClick="return confirm('¿Está seguro de eliminar el registro?');" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:ImageButton ID="ibtnActualizar" runat="server" ToolTip="Actualizar"
                                                    CommandName="Update" ImageUrl="~/Views/sistemaPlanillas/Icon/Save.gif"
                                                    ValidationGroup="Valida" />
                                                <asp:ImageButton ID="ibtnCancelar" runat="server" CommandName="Cancel" ToolTip="Cancelar"
                                                    ImageUrl="~/Views/sistemaPlanillas/Icon/cancel.gif" />
                                            </EditItemTemplate>
                                            <%--<FooterTemplate>
                    <asp:ImageButton ID="ibtnNuevo" runat="server" CommandName="Insert" ToolTip="Nuevo Grabar"
                        ImageUrl="~/Views/sistemaPlanillas/Icon/add.gif"  ValidationGroup="ValidaNew"/>
                </FooterTemplate>--%>
                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Cargo_Funcion_Id" HeaderText="CARGO_FUNCION" ReadOnly="true" Visible="false">
                                            <HeaderStyle ForeColor="#336699" Font-Size="X-Small"
                                                Font-Bold="True" />
                                            <ItemStyle Width="70px" HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <%-- <asp:BoundField DataField="Cargo" HeaderText="CARGO" ReadOnly="true">
                             <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                                        Font-Bold="True" />
                <ItemStyle Width="70px" HorizontalAlign="Center" />
            </asp:BoundField>--%>
                                        <asp:TemplateField HeaderText="CARGO">
                                            <HeaderStyle ForeColor="#336699" Font-Size="X-Small"
                                                Font-Bold="True" />
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="cboCargo" runat="server" CssClass="ddl">
                                                </asp:DropDownList>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblEstado" runat="server" Text='<%# Eval("Cargo") %>'></asp:Label>
                                            </ItemTemplate>
                                            <%--<FooterTemplate>
                    <asp:DropDownList ID="cboCargoNew" runat="server" CssClass="ddl">
                    </asp:DropDownList>
                </FooterTemplate>--%>
                                            <ItemStyle HorizontalAlign="Center" Width="280px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="FUNCION">
                                            <HeaderStyle ForeColor="#336699" Font-Size="X-Small"
                                                Font-Bold="True" />
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtDescripcion" runat="server" Width="280px" Text='<%# Eval("Funcion") %>' CssClass="txt">
                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtDescripcion"
                                                    runat="server" ErrorMessage="*" Text="*" ValidationGroup="Valida"></asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblDescripcion" runat="server" Text='<%# Eval("Funcion") %>'></asp:Label>
                                            </ItemTemplate>
                                            <%--<FooterTemplate>
                   <asp:TextBox ID="txtDescripcionNew" runat="server" Width="280px" CssClass="txt">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtDescripcionNew" 
                        runat="server" ErrorMessage="*" Text="*" ValidationGroup="ValidaNew"></asp:RequiredFieldValidator>
                </FooterTemplate>--%>
                                            <ItemStyle Width="600px" />
                                        </asp:TemplateField>

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
                    </asp:UpdatePanel>

                    <asp:UpdateProgress ID="UpdateProgress1" runat="server"
                        AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1">

                        <ProgressTemplate>
        <div class="UpdateProgressModalBackground"></div>
        <center>                                            
            <div class="UpdateProgressPanel">
                Cargando...<br /><br />
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

