<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master"  CodeBehind="FrmMntCcosto.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Mantenimientos.FrmMntCcosto" %>

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
  <asp:Label ID="Label9" runat="server" Text="MANTENIMIENTO DE CENTRO DE COSTO" CssClass="miTitulo"></asp:Label>


<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
<cc1:TabContainer ID="TabContainer1" Height="400px" runat="server" 
        ActiveTabIndex="0">
    <cc1:TabPanel ID="TabPanel1" HeaderText="Lista" runat="server">
        <ContentTemplate>

<div class="textoGeneral">
    <table>
        <tr>
                             <td>
                                            <asp:Label ID="Label60" runat="server" Text="Digite La Descripcion : "
                                                 CssClass="miLabel" Width="110px"></asp:Label>
                                        </td>
            <td>
                <asp:TextBox ID="txtCcostoBuscar" CssClass="txt" Width="300px" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnListar" runat="server" Text="Listar" 
                    onclick="btnListar_Click" CssClass="submit EstiloGeneralBoton" />
            </td>
            <td>
                <asp:Button ID="btnNuevo" runat="server" onclick="btnNuevo_Click" 
                    Text="Nuevo" CssClass="submit EstiloGeneralBoton btn-nuevo"/>
            </td>
        </tr>
    </table>
</div>

<div style="overflow: auto; width: 100%;  ">
    <table class="gridSmallCabecera">
        <tr>
            <th width="45px"></th>
            <th width="80px"><asp:Label ID="Label3" runat="server" Text="CCOSTO_ID" CssClass="tituloGrilla"></asp:Label></th>
            <th width="560px"><asp:Label ID="Label1" runat="server" Text="CENTRO COSTO" CssClass="tituloGrilla"></asp:Label></th>
            <th width="147px"><asp:Label ID="Label2" runat="server" Text="CODIGO AUXILIAR" CssClass="tituloGrilla"></asp:Label></th>
            <th width="110px"><asp:Label ID="Label4" runat="server" Text="ESTADO" CssClass="tituloGrilla"></asp:Label></th>
        </tr>
    </table>
</div>
    
    <div style="overflow: auto; width: 100%; height: 330px; border:solid 0px black;">
            <asp:GridView ID="grvCcosto" runat="server" Width="100%" 
                ShowHeader="False"
                AutoGenerateColumns="False" CellPadding="2" CssClass="gridSmall" 
                DataKeyNames="Ccosto_Id,no_Ccosto,dpto,prov,dist,Codigo_Auxiliar" ForeColor="#333333" 
                GridLines="None" PageSize="14"
                onrowcommand="grvCcosto_RowCommand"
                onrowdeleting="grvCcosto_RowDeleting" AllowPaging="True"
                onpageindexchanging="grvCcosto_PageIndexChanging">
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
                <ItemStyle HorizontalAlign="Center" Width="35px" />
            </asp:TemplateField>
                    <asp:BoundField DataField="Ccosto_Id" HeaderText="CCOSTO_ID" ReadOnly="True">
                        <ItemStyle Width="70px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="no_Ccosto" HeaderText="CENTRO COSTO">
                        <ItemStyle Width="400px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Codigo_Auxiliar" HeaderText="OCUPACION">
                        <ItemStyle Width="150px" />
                    </asp:BoundField>    
                    <asp:BoundField DataField="no_Estado" HeaderText="ESTADO">
                        <ItemStyle Width="65px" />
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
    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Datos del Centro de Costo">
        <ContentTemplate>
    
<div class="textoGeneral">
    
    <asp:Panel ID="pnlNuevo" runat="server" GroupingText="Datos del Centro de Costo">

        <table>
            <tr>
                <td>
                    Ccosto Id</td>
                <td>
                    <asp:Label ID="lblCcosto_Id" runat="server" Width="50px" Height="18px" CssClass="lblCod"></asp:Label>
                    <asp:TextBox ID="txtCcosto_Id" CssClass="txt" Width="50px" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="txtCcosto_Id" ErrorMessage="*" 
                        Text="*" ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
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
                    Departamento</td>
                <td>
                    <asp:DropDownList ID="cboDepartamento" runat="server" CssClass="ddl" 
                        Width="150px" AutoPostBack="True"
                        onselectedindexchanged="cboDepartamento_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="cboDepartamento" InitialValue="--Seleccione--" ErrorMessage="*" Text="*" 
                        ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Provincia</td>
                <td>                    
                    <asp:DropDownList ID="cboProvincia" runat="server" CssClass="ddl" 
                        Width="150px" AutoPostBack="true" onselectedindexchanged="cboProvincia_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="cboProvincia" InitialValue="--Seleccione--" ErrorMessage="*" Text="*" 
                        ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Distrito</td>
                <td>
                    <asp:DropDownList ID="cboDistrito" runat="server" CssClass="ddl" 
                        Width="150px">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="cboDistrito" InitialValue="--Seleccione--" ErrorMessage="*" Text="*" 
                        ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Codigo Auxiliar</td>
                <td>
                    <asp:TextBox ID="txtCodigo_Auxiliar" CssClass="txt" Width="100px" runat="server"></asp:TextBox>
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
                        Text="Grabar" ValidationGroup="ValidaGraba" CssClass="submit EstiloGeneralBoton btn-nuevo" />
                    &nbsp;
                    <asp:Button ID="btnActualizar" runat="server" onclick="btnActualizar_Click"
                        Text="Actualizar" ValidationGroup="ValidaGraba" CssClass="submit EstiloGeneralBoton" />
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
            alt="Procesando" ImageUrl="~/css/ajax-loader.gif" /> 
            </div> 
        </center>
    </ProgressTemplate>
                                        
</asp:UpdateProgress>

   </fieldset>
    
         </td>
     </tr>
     </table>

</asp:Content>

