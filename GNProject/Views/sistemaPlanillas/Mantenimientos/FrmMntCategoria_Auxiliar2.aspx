<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmMntCategoria_Auxiliar2.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Mantenimientos.FrmMntCategoria_Auxiliar2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />


<table align="center" width="100%">
     <tr>
     <td>
        
        <fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px;
           border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black; 
            min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; border-top: solid 1px black;">

    <br />
  <asp:Label ID="Label9" runat="server" Text="MANTENIMIENTO DE SECCIÓN" CssClass="miTitulo"></asp:Label>
    <br />
    <br />

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<div style="width:100%;">
    <asp:GridView ID="grvCategoria_Auxiliar2" runat="server" Width="100%"
        AutoGenerateColumns="False" CellPadding="2" CssClass="gridSmall" 
        DataKeyNames="Categoria_Auxiliar2_Id, Categoria_Auxiliar_Id" ForeColor="#333333" 
        GridLines="None" onrowcancelingedit="grvCategoria_Auxiliar2_RowCancelingEdit" 
        onrowcommand="grvCategoria_Auxiliar2_RowCommand"
        onrowdatabound="grvCategoria_Auxiliar2_RowDataBound" 
        onrowdeleting="grvCategoria_Auxiliar2_RowDeleting" 
        onrowediting="grvCategoria_Auxiliar2_RowEditing" 
        onrowupdating="grvCategoria_Auxiliar2_RowUpdating" ShowFooter="true" 
        AllowPaging="true" 
        onpageindexchanging="grvCategoria_Auxiliar2_PageIndexChanging">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
                <ItemStyle HorizontalAlign="Center" Width="32px" />
            </asp:TemplateField>
            <asp:BoundField DataField="Categoria_Auxiliar2_Id" HeaderText="Sección ID" ReadOnly="true">
                             <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                                        Font-Bold="True" />
                <ItemStyle Width="70px" HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="SECCION">
                         <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                                        Font-Bold="True" />
                <EditItemTemplate>
                    <asp:TextBox ID="txtDescripcion" runat="server" Width="280px" Text='<%# Eval("no_Seccion") %>' CssClass="txt">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtDescripcion" 
                        runat="server" ErrorMessage="*" Text="*" ValidationGroup="Valida"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblDescripcion" runat="server" Text='<%# Eval("no_Seccion") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtDescripcionNew" runat="server" Width="280px" CssClass="txt">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtDescripcionNew" 
                        runat="server" ErrorMessage="*" Text="*" ValidationGroup="ValidaNew"></asp:RequiredFieldValidator>
                </FooterTemplate>
                <ItemStyle Width="600px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="AREA">
                         <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                                        Font-Bold="True" />
                <EditItemTemplate>
                    <asp:DropDownList ID="cboCategoria_Auxiliar" runat="server" CssClass="ddl">
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblEstado" runat="server" Text='<%# Eval("no_Area") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="cboCategoria_AuxiliarNew" runat="server" CssClass="ddl">
                    </asp:DropDownList>
                </FooterTemplate>
                <ItemStyle HorizontalAlign="Center" Width="70px" />
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


 </fieldset>
    
         </td>
     </tr>
     </table>

</asp:Content>

