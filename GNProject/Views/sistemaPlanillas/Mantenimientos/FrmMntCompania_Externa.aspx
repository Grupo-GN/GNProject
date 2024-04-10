<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmMntCompania_Externa.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Mantenimientos.FrmMntCompania_Externa" %>

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
           /*border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black;*/ 
            min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; /*border-top: solid 1px black;*/">

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
<div class="tituloPagina">
    MANTENIMIENTO DE COMPAÑIAS EXTERNAS
</div>

<br />
<br />

<table>
    <tr>
        <td>
            <asp:Button ID="btnNuevo" runat="server" onclick="btnNuevo_Click" 
                Text="Nuevo" />
        </td>
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
</table>

<cc1:TabContainer ID="TabContainer1" Height="415px" runat="server" 
        ActiveTabIndex="0">
    <cc1:TabPanel ID="TabPanel1" HeaderText="Lista" runat="server">
        <ContentTemplate>

<div class="textoGeneral">
    <table>
        <tr>
            <td>Razón Social</td>
            <td>
                <asp:TextBox ID="txtRazonSocialBuscar" CssClass="txt" Width="300px" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:ImageButton ID="btnBuscar" runat="server" Height="18px" ToolTip="Buscar"
                    ImageUrl="~/Views/sistemaPlanillas/Imgs/Buscar.png" onclick="btnBuscar_Click" Width="34px" />
            </td>
            <td>                
            </td>
        </tr>
    </table>
</div>

<div style="overflow: auto; width: 650px; ">
    <table class="gridSmallCabecera">
        <tr>
            <th width="58px"></th>
            <th width="147px">Compania_Externa_Id</th>
            <th width="307px">Razón Social</th>
            <th width="117px">RUC</th>
        </tr>
    </table>
</div>
        <div style="overflow: auto; width: 650px; height: 350px; border:solid 0px;">
            <asp:GridView ID="grvCompania_Externa" runat="server"
                ShowHeader="false"
                AutoGenerateColumns="False" CellPadding="4" CssClass="gridSmall" 
                DataKeyNames="Compania_Externa_Id" ForeColor="#333333" 
                GridLines="None"
                onrowcommand="grvCompania_Externa_RowCommand"
                onrowdeleting="grvCompania_Externa_RowDeleting" AllowPaging="True"
                onpageindexchanging="grvCompania_Externa_PageIndexChanging">
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
                    <asp:BoundField DataField="Compania_Externa_Id" HeaderText="Compania_Externa_Id" ReadOnly="True">
                        <ItemStyle Width="140px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Razon_Social" HeaderText="Razón Social">
                        <ItemStyle Width="300px"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="RUC" HeaderText="RUC">
                        <ItemStyle Width="110px" HorizontalAlign="Center" />
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
    <table>
        <tr>
            <td>
                Compania_Externa Id</td>
            <td>
                <asp:Label ID="lblCompania_Externa_Id" runat="server" Width="50px" Height="18px" CssClass="lblCod"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Razón Social</td>
            <td>
                <asp:TextBox ID="txtRazon_Social" runat="server" CssClass="txt" 
                    Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtRazon_Social" ErrorMessage="*" Text="*" 
                    ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                RUC</td>
            <td>
                <asp:TextBox ID="txtRUC" runat="server" CssClass="txt" 
                    Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="txtRUC" ErrorMessage="*" Text="*" 
                    ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                CIIU</td>
            <td>
                <asp:DropDownList ID="cboCIIU" Width="300px" CssClass="ddl" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:CheckBox ID="ckCompaniaEnvia" Text="Compañia que envía Trabajadores" CssClass="ck" runat="server"></asp:CheckBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:CheckBox ID="ckCompaniaRecibe" Text="Compañia que recibe Trabajadores" CssClass="ck" runat="server"></asp:CheckBox>
            </td>
        </tr>
    </table>
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

