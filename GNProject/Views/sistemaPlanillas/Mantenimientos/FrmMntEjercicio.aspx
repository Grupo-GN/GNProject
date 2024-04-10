<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmMntEjercicio.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Mantenimientos.FrmMntEjercicio" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />

     <link href="../Styles/nuevoEstiloPlanilla.css" rel="stylesheet" type="text/css" />


     <table align="center" width="100%">
     <tr>
     <td>
        
        <fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px;
           /*border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black; */
            min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; /*border-top: solid 1px black;*/">
    
    <br />
  <asp:Label ID="Label9" runat="server" Text="MANTENIMIENTO DE EJERCICIOS" CssClass="miTitulo"></asp:Label>
    <br />
    <br />

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
 
<cc1:TabContainer ID="TabContainer1" Height="410px" runat="server" Width="100%" ScrollBars="Vertical">
    <cc1:TabPanel ID="TabPanel1" HeaderText="Lista" runat="server">
        <ContentTemplate>
    <table>
        <tr>
                 <td>
                                            <asp:Label ID="Label60" runat="server" Text="Digite La Descripcion : "
                                                 CssClass="miLabel" Width="110px"></asp:Label>
                                        </td>
            <td>
                <asp:TextBox ID="txtDescripcionBuscar" CssClass="txt" Width="300px" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnListar" runat="server" Text="Listar" 
                    onclick="btnListar_Click" CssClass="submit" />
            </td>
            <td>
                <asp:Button ID="btnNuevo" runat="server" onclick="btnNuevo_Click" 
                    Text="Nuevo" CssClass="submit" />
            </td>
        </tr>
    </table>

<div style="overflow: auto; width: 100%;  ">
    <table class="gridSmallCabecera">
        <tr>
            <th width="42px"></th>
            <th width="86px"><asp:Label ID="Label3" runat="server" Text="EJERCICIO_ID" CssClass="tituloGrilla"></asp:Label></th>
            <th width="145px"><asp:Label ID="Label1" runat="server" Text="DESCRIPCION" CssClass="tituloGrilla"></asp:Label></th>
            <th width="90px"><asp:Label ID="Label2" runat="server" Text="AÑO" CssClass="tituloGrilla"></asp:Label></th>
             <th width="555px"></th>
        </tr>
    </table>
</div>

<div style="overflow: auto; width: 100%; height: 320px; border:solid 0px black;">
    <asp:GridView ID="grvEjercicio" runat="server" 
        ShowHeader="False"
        AutoGenerateColumns="False" CellPadding="2" CssClass="gridSmall" 
        DataKeyNames="Ejercicio_Id,Descripcion,Ano" ForeColor="#333333" 
        GridLines="None"
        onrowcommand="grvEjercicio_RowCommand"
        onrowdeleting="grvEjercicio_RowDeleting" AllowPaging="True" 
        onpageindexchanging="grvEjercicio_PageIndexChanging" 
        onrowdatabound="grvEjercicio_RowDataBound" Width="100%">
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
                <ItemStyle HorizontalAlign="Center" Width="45px" />
            </asp:TemplateField>
            <asp:BoundField DataField="Ejercicio_Id" HeaderText="Ejercicio_Id" ReadOnly="True">
                <ItemStyle Width="10%" HorizontalAlign="Center"  CssClass="FormatFontGridView" Height="18px" />
            </asp:BoundField>
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción">
                <ItemStyle Width="16%" HorizontalAlign="Center" CssClass="FormatFontGridView"  />
            </asp:BoundField>
            <asp:BoundField DataField="Ano" HeaderText="Año">
                <ItemStyle Width="10%" HorizontalAlign="Center" CssClass="FormatFontGridView"  />
            </asp:BoundField>      
                <asp:TemplateField>
                                            <ItemTemplate>
                                                <Itemstyle Width="60%" HorizontalAlign="Center" CssClass="FormatFontGridView"></itemstyle>
                                            </ItemTemplate>
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
    </cc1:TabPanel>
    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Datos del Ejercicio">
        <ContentTemplate>

<div class="textoGeneral">
    <asp:Panel ID="pnlNuevo" runat="server" GroupingText="Datos del Ejercicio">
        <table>
            <tr>
                <td>
                    Ejercicio Id</td>
                <td>
                    <asp:Label ID="lblEjercicio_Id" runat="server" Width="50px" Height="18px" CssClass="lblCod"></asp:Label>
                    <asp:TextBox ID="txtEjercicio_Id" runat="server" CssClass="txt" 
                        Width="100px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtEjercicio_Id" ErrorMessage="*" Text="*" 
                        ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Descripción</td>
                <td>
                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="txt" 
                        Width="100px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtDescripcion" ErrorMessage="*" Text="*" 
                        ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Año</td>
                <td>
                    <asp:TextBox ID="txtAnio" runat="server" CssClass="txt" 
                        Width="100px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtAnio" ErrorMessage="*" Text="*" 
                        ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
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
                        Text="Grabar" ValidationGroup="ValidaGraba" />
                    &nbsp;
                    <asp:Button ID="btnActualizar" runat="server" onclick="btnActualizar_Click"
                        Text="Actualizar" ValidationGroup="ValidaGraba" />
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

