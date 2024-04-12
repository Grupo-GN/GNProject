<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmMntCompania_Externa_Establecimientos.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Mantenimientos.FrmMntCompania_Externa_Establecimientos" %>

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

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
<div class="tituloPagina">
    MANTENIMIENTO DE ESTABLECIMIENTOS EXTERNOS
</div>

<br />
<br />

<cc1:TabContainer ID="TabContainer1" Height="470px" runat="server" 
        ActiveTabIndex="0">
    <cc1:TabPanel ID="TabPanel1" HeaderText="Lista" runat="server">
        <ContentTemplate>

<div class="textoGeneral">
    <table>
        <tr>
            <td>Establecimiento</td>
            <td>
                <asp:TextBox ID="txtEstablecimientoBuscar" CssClass="txt" Width="300px" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnListar" runat="server" Text="Listar" 
                    onclick="btnListar_Click" />
            </td>
            <td>
                <asp:Button ID="btnNuevo" runat="server" onclick="btnNuevo_Click" 
                    Text="Nuevo" />
            </td>
        </tr>
    </table>
</div>

<div style="overflow: auto; width: 610px; ">
    <table class="gridSmallCabecera">
        <tr>
            <th width="58px"></th>
            <th width="127px">Cia_Ext_Establec_Id</th>
            <th width="307px">Descripcion</th>
        </tr>
    </table>
</div>
    
        <div style="overflow: auto; width: 610px; height: 400px; border:solid 0px;">
            <asp:GridView ID="grvCompania_Externa_Establecimientos" runat="server" 
                ShowHeader="false"
                AutoGenerateColumns="False" CellPadding="4" CssClass="gridSmall" 
                DataKeyNames="Cia_Ext_Establec_Id,Compania_Externa_Id,Descripcion,CentroRiesgo,Codigo_Establecimiento,Tasa"
                ForeColor="#333333" GridLines="None"
                onrowcommand="grvCompania_Externa_Establecimientos_RowCommand"
                onrowdeleting="grvCompania_Externa_Establecimientos_RowDeleting" AllowPaging="True"
                onpageindexchanging="grvCompania_Externa_Establecimientos_PageIndexChanging">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="ibtnSelect" runat="server" ToolTip="Seleccionar"
                                CommandName="Select" Height="20px" ImageUrl="~/Views/sistemaPlanillas/Imgs/Editar.png" Width="20px" />
                            <asp:ImageButton ID="ibtnEliminar" runat="server" ToolTip="Eliminar"
                                CommandName="Delete" Height="20px" ImageUrl="~/Views/sistemaPlanillas/Imgs/btnDelete.png" Width="20px"
                                OnClientClick="return confirm('¿Esta Seguro De Eliminar?');" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Cia_Ext_Establec_Id" HeaderText="Cia_Ext_Establec_Id" ReadOnly="True">
                        <ItemStyle Width="120px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion">
                        <ItemStyle Width="300px" />
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
    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Datos Principales">
        <ContentTemplate>
    
<div class="textoGeneral">
    
    <asp:Panel ID="pnlNuevo" runat="server" GroupingText="Datos del Establecimiento Externo">

        <table>
            <tr>
                <td>
                    Establecimiento Externo Id</td>
                <td>
                    <asp:Label ID="lblCia_Ext_Establec_Id" runat="server" Width="50px" Height="18px" CssClass="lblCod"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>Compañia</td>
                <td>
                    <asp:DropDownList ID="cboCompania_Externa" runat="server" CssClass="ddl" Width="150px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Descripción</td>
                <td>
                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="txt" 
                        Width="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtDescripcion" ErrorMessage="*" Text="*" 
                        ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:CheckBox ID="ckCentroRiesgo" CssClass="ck" Text="Centro de Riesgo?" runat="server" />
                </td>                
            </tr>
            <tr>
                <td>Código Auxiliar</td>
                <td>
                    <asp:TextBox ID="txtCodigo_Auxiliar" CssClass="txt" Width="100px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Tasa</td>
                <td>
                    <asp:TextBox ID="txtTasa" CssClass="txt" Width="100px" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtTasa" ErrorMessage="*" Text="*" 
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

