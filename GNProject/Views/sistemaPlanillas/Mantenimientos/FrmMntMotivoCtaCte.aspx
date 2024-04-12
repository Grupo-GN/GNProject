<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmMntMotivoCtaCte.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Mantenimientos.FrmMntMotivoCtaCte" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/nuevoEstiloPlanilla.css" rel="stylesheet" type="text/css" />

    <fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px;/*border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black;*/ min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; /*border-top: solid 1px black;*/">
        <br />
        <asp:Label ID="Label9" runat="server" Text="MANTENIMIENTO DE MOTIVOS" CssClass="miTitulo"></asp:Label>
        <br />
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <fieldset>
                    <legend>
                        <asp:Label ID="Label2" runat="server" Text="Buscar" CssClass="miTituloOnTab"></asp:Label>
                    </legend>
                    <table style="border-collapse:collapse;width:100%;">
                        <tr>
                            <td style="width:70px;"><label class="miLabel">Descripción : </label></td>
                            <td>
                                <asp:TextBox ID="txtbuscar" runat="server" Width="280px" CssClass="txt"></asp:TextBox>&nbsp;&nbsp;
                                <asp:Button ID="btnBuscar" runat="server" CssClass="btn" onclick="btnBuscar_Click" Text="Buscar" />
                            </td>

                        </tr>
                    </table>
                </fieldset>
                <asp:GridView ID="dgvMotivo" runat="server" CssClass="gridSmall" 
                    AutoGenerateColumns="False" DataKeyNames="MotivoId,ConceptoId" Width="100%"
                    ShowFooter="True" onrowdatabound="dgvMotivo_RowDataBound" 
                    onrowcancelingedit="dgvMotivo_RowCancelingEdit" 
                    onrowcommand="dgvMotivo_RowCommand" onrowdeleting="dgvMotivo_RowDeleting" 
                    onrowediting="dgvMotivo_RowEditing" onrowupdating="dgvMotivo_RowUpdating"
                    >
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnSelect" runat="server" ToolTip="Editar"
                                    CommandName="Edit"  ImageUrl="~/Views/sistemaPlanillas/Icon/Modify.gif"  />
                                <asp:ImageButton ID="ibtnEliminar" runat="server" ToolTip="Eliminar"
                                    CommandName="Delete" ImageUrl="~/Views/sistemaPlanillas/Icon/delete.gif" 
                                    OnClientClick="return confirm('¿Esta Seguro De Eliminar?');" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:ImageButton ID="ibtnActualizar" runat="server" ToolTip="Actualizar"
                                    CommandName="Update"  ImageUrl="~/Views/sistemaPlanillas/Icon/Save.gif"  
                                    ValidationGroup="Valida" />
                                <asp:ImageButton ID="ibtnCancelar" runat="server" CommandName="Cancel" ToolTip="Cancelar"
                                     ImageUrl="~/Views/sistemaPlanillas/Icon/cancel.gif" />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:ImageButton ID="ibtnNuevo" runat="server" CommandName="Insert" ToolTip="Nuevo Grabar"
                                    ImageUrl="~/Views/sistemaPlanillas/Icon/add.gif"  ValidationGroup="ValidaNew"/>
                            </FooterTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="CÓDIGO" DataField="MotivoId" ReadOnly="True" >
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="MOTIVO">
                            <ItemTemplate>
                                <asp:Label ID="lblDescripcion" runat="server" Text='<%# Eval("NMotivo") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtmotivo" runat="server" Width="280px" Text='<%# Eval("NMotivo") %>' CssClass="txt">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtmotivo" 
                                    runat="server" ErrorMessage="*" Text="*" ValidationGroup="Valida"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtmotivonew" runat="server" Width="280px" CssClass="txt">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtmotivonew" 
                                    runat="server" ErrorMessage="*" Text="*" ValidationGroup="ValidaNew"></asp:RequiredFieldValidator>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CONCEPTO">
                            <EditItemTemplate>
                                <asp:DropDownList ID="cboconcepto" runat="server" CssClass="ddl">
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblconcepto" runat="server" Text='<%# Eval("NConcepto") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="cboconceptoNew" runat="server" CssClass="ddl">
                                </asp:DropDownList>
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1">                                        
            <ProgressTemplate>
                <div class="UpdateProgressModalBackground"></div>
                <center>                                            
                    <div class="UpdateProgressPanel">Cargando...<br /><br />
                        <asp:Image ID="Image2" runat="server" alt="Procesando" ImageUrl="~/Views/sistemaPlanillas/css/ajax-loader.gif" /> 
                    </div> 
                </center>
            </ProgressTemplate>                                        
        </asp:UpdateProgress>
    </fieldset>
</asp:Content>

