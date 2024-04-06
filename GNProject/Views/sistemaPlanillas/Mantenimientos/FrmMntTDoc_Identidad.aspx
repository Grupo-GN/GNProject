<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmMntTDoc_Identidad.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Mantenimientos.FrmMntTDoc_Identidad" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />

   <table align="center" width="100%">
     <tr>
     <td>
        
        <fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px;
           border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black; 
            min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; border-top: solid 1px black;">

   <br />
  <asp:Label ID="Label9" runat="server" Text="MANTENIMIENTO DE TIPOS DE DOCUMENTO DE IDENTIDAD" CssClass="miTitulo"></asp:Label>
    <br />
    <br />

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
<div>
        <fieldset>
<legend>
  <asp:Label ID="Label2" runat="server" Text="Nuevo Tipo de Documento" CssClass="miTituloOnTab"></asp:Label>
</legend>
        <table>
            <tr>
                <td>
                     <asp:Label ID="Label4" runat="server" Text="Descripción : " CssClass="miLabel"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtDescripcionNuevo" runat="server" Width="280px" CssClass="txt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtDescripcionNuevo" 
                        runat="server" ErrorMessage="*" Text="*" ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
                </td>
                <td>
                     <asp:Label ID="Label1" runat="server" Text="Abreviatura : " CssClass="miLabel"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtAbreviaturaNuevo" runat="server" Width="280px" CssClass="txt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtAbreviaturaNuevo" 
                        runat="server" ErrorMessage="*" Text="*" ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:ImageButton ID="btnGrabar" runat="server" Height="25px" ToolTip="Grabar" 
                        ImageUrl="~/Views/sistemaPlanillas/Imgs/btnSave.png"
                        ValidationGroup="ValidaGraba" Width="25px" onclick="btnGrabar_Click" />
                </td>
                <td>
                    <asp:Button ID="btnListar" runat="server" Text="Listar" 
                    onclick="btnListar_Click" CssClass="submit" />
                </td>
            </tr>
        </table>
    </fieldset>
</div>

<div style="width:100%;">
    <asp:GridView ID="grvTDoc_Identidad" runat="server" Width="100%"
        AutoGenerateColumns="False" CellPadding="2" CssClass="gridSmall" 
        DataKeyNames="Tipo_Doc_Id" ForeColor="#333333" 
        GridLines="None" onrowcancelingedit="grvTDoc_Identidad_RowCancelingEdit" 
        onrowcommand="grvTDoc_Identidad_RowCommand"
        onrowdeleting="grvTDoc_Identidad_RowDeleting" 
        onrowediting="grvTDoc_Identidad_RowEditing" 
        onrowupdating="grvTDoc_Identidad_RowUpdating" ShowFooter="true" 
        AllowPaging="true" onpageindexchanging="grvTDoc_Identidad_PageIndexChanging">
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
                          ImageUrl="~/Views/sistemaPlanillas/Icon/cancel.gif"  />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:ImageButton ID="ibtnNuevo" runat="server" CommandName="Insert" ToolTip="Nuevo Grabar"
                         ImageUrl="~/Views/sistemaPlanillas/Icon/add.gif"  ValidationGroup="ValidaNew"/>
                </FooterTemplate>
                <ItemStyle HorizontalAlign="Center" Width="45px" />
            </asp:TemplateField>
            <asp:BoundField DataField="Tipo_Doc_Id" HeaderText="TIPO_DOC_ID" ReadOnly="true">
                                          <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                                        Font-Bold="True" />
                <ItemStyle Width="70px" HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="DESCRIPCION">
                                          <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                                        Font-Bold="True" />
                <EditItemTemplate>
                    <asp:TextBox ID="txtDescripcion" runat="server" Width="280px" Text='<%# Eval("Descripcion") %>' CssClass="txt">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtDescripcion" 
                        runat="server" ErrorMessage="*" Text="*" ValidationGroup="Valida"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblDescripcion" runat="server" Text='<%# Eval("Descripcion") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtDescripcionNew" runat="server" Width="280px" CssClass="txt">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtDescripcionNew" 
                        runat="server" ErrorMessage="*" Text="*" ValidationGroup="ValidaNew"></asp:RequiredFieldValidator>
                </FooterTemplate>
                <ItemStyle Width="600px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ABREVIATURA">
                                          <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                                        Font-Bold="True" />
                <EditItemTemplate>
                    <asp:TextBox ID="txtAbreviatura" runat="server" Width="280px" Text='<%# Eval("Abreviatura") %>' CssClass="txt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtAbreviatura" 
                        runat="server" ErrorMessage="*" Text="*" ValidationGroup="Valida"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblAbreviatura" runat="server" Text='<%# Eval("Abreviatura") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtAbreviaturaNew" runat="server" Width="280px" CssClass="txt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtAbreviaturaNew" 
                        runat="server" ErrorMessage="*" Text="*" ValidationGroup="ValidaNew"></asp:RequiredFieldValidator>
                </FooterTemplate>
                        <ItemStyle Width="100px" />
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

