<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmMntCargo.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Mantenimientos.FrmMntCargo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />

    <link href="../Styles/nuevoEstiloPlanilla.css" rel="stylesheet" type="text/css" />

   <table align="center" width="100%">
     <tr>
     <td>
        
        <fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px;
           /*border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black;*/ 
            min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; /*border-top: solid 1px black;*/">

    <br />
  <asp:Label ID="Label9" runat="server" Text="MANTENIMIENTO DE CARGOS" CssClass="miTitulo"></asp:Label>
    <br />
    <br />

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
<cc1:TabContainer ID="TabContainer1" Height="450px" runat="server">
    <cc1:TabPanel ID="TabPanel1" HeaderText="Lista" runat="server">
        <ContentTemplate>

    <table>
        <tr>
            <td>
              <asp:Label ID="Label60" runat="server" Text="Digite el Cargo : "
                                                 CssClass="miLabel" Width="110px"></asp:Label>
                        </td>
            <td>
                <asp:TextBox ID="txtCargoBuscar" CssClass="txt" Width="300px" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnListar" runat="server" Text="Listar" 
                    onclick="btnListar_Click" CssClass="submit" />
            </td>
            <td>
                <asp:Button ID="btnNuevo" runat="server" onclick="btnNuevo_Click" 
                    Text="Nuevo"  CssClass="submit"/>
            </td>
        </tr>
    </table>

<div style="overflow: auto; width: 100%; ">
    <table class="gridSmallCabecera">
        <tr>
            <th width="58px"></th>
            <th width="59px"><asp:Label ID="Label3" runat="server" Text="CARGO_ID" CssClass="tituloGrilla"></asp:Label></th>
            <th width="347px"><asp:Label ID="Label1" runat="server" Text="CARGO" CssClass="tituloGrilla"></asp:Label></th>
            <th width="323px"><asp:Label ID="Label2" runat="server" Text="OCUPACION" CssClass="tituloGrilla"></asp:Label></th>
            <th width="117px"><asp:Label ID="Label4" runat="server" Text="ESTADO" CssClass="tituloGrilla"></asp:Label></th>
        </tr>
    </table>
</div>
<div style="overflow: auto; width: 100%; height: 350px; border:solid 0px;">
    <asp:GridView ID="grvCargo" runat="server"  Width="100%"
        ShowHeader="False"
        AutoGenerateColumns="False" CellPadding="4" CssClass="gridSmall" 
        DataKeyNames="Cargo_Id,no_Cargo,Ocupacion_Id,Flag_Tareaje,Flag_Confianza" ForeColor="#333333" 
        GridLines="None"
        onrowcommand="grvCargo_RowCommand"
        onrowdeleting="grvCargo_RowDeleting" AllowPaging="True" 
        onpageindexchanging="grvCargo_PageIndexChanging" >
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="ibtnSelect" runat="server" ToolTip="Seleccionar"
                        CommandName="Select" ImageUrl="../Icon/Modify.gif" />
                    <asp:ImageButton ID="ibtnEliminar" runat="server" ToolTip="Eliminar"
                        CommandName="Delete" ImageUrl="../Icon/delete.gif"
                        OnClientClick="return confirm('¿Esta Seguro De Eliminar?');" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="30px" />
            </asp:TemplateField>
            <asp:BoundField DataField="Cargo_Id" HeaderText="CARGO_ID" ReadOnly="True">
                <ItemStyle Width="70px" HorizontalAlign="Center"  CssClass="FormatFontGridView" />
            </asp:BoundField>
            <asp:BoundField DataField="no_Cargo" HeaderText="CARGO">
                <ItemStyle Width="300px" CssClass="FormatFontGridView" />
            </asp:BoundField>
            <asp:BoundField DataField="no_Ocupacion" HeaderText="OCUPACION">
                <ItemStyle Width="300px" CssClass="FormatFontGridView" />
            </asp:BoundField>    
            <asp:BoundField DataField="no_Estado" HeaderText="ESTADO">
                <ItemStyle Width="65px" CssClass="FormatFontGridView"/>
            </asp:BoundField>
            
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
    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Datos del Cargo">
        <ContentTemplate>

<div class="textoGeneral">
    <asp:Panel ID="pnlNuevo" runat="server" GroupingText="Datos del Cargo">
        <table>
            <tr>
                <td>
                    Cargo Id</td>
                <td>
                    <asp:Label ID="lblCargo_Id" runat="server" Width="50px" Height="18px" CssClass="lblCod"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Descripción</td>
                <td>
                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="txt" 
                        Width="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtDescripcion" ErrorMessage="*" Text="*" 
                        ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Ocupación</td>
                <td>
                    <asp:DropDownList ID="cboOcupacion" runat="server" CssClass="ddl" 
                        Width="300px">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:CheckBox ID="ckTareaje" runat="server" CssClass="ck" Text="Flag Tareaje" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:CheckBox ID="ckConfianza" runat="server" CssClass="ck" 
                        Text="Flag Confianza" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <hr />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnGrabar" runat="server" onclick="btnGrabar_Click" 
                        Text="Grabar" ValidationGroup="ValidaGraba" CssClass="submit" />
                    &nbsp;
                    <asp:Button ID="btnActualizar" runat="server" onclick="btnActualizar_Click"
                        Text="Actualizar" ValidationGroup="ValidaGraba" CssClass="submit" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <hr />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
</div>

        </ContentTemplate>    
    </cc1:TabPanel>
</cc1:TabContainer>

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

