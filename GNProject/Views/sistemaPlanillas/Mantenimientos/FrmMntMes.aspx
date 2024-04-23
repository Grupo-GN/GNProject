<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmMntMes.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Mantenimientos.FrmMntMes" %>


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
    

   <asp:Label ID="Label9" runat="server" Text="MANTENIMIENTO DE MESES" CssClass="miTitulo"></asp:Label>
  
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    


<cc1:TabContainer ID="TabContainer1" Height="410px" runat="server" 
ScrollBars="Horizontal" Width="100%">
    <cc1:TabPanel ID="TabPanel1" HeaderText="Lista" runat="server">
        <ContentTemplate>


    <table>
        <tr>
            <td><asp:Label ID="Label60" runat="server" Text="Digite La Descripcion : "
                                                CssClass="miLabel" Width="120px"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtDescripcionBuscar" CssClass="txt" Width="300px" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnListar" runat="server" Text="Buscar" 
                    onclick="btnListar_Click" CssClass="submit EstiloGeneralBoton btn-buscar" />
            </td>
            <td>
                <asp:Button ID="btnNuevo" runat="server" onclick="btnNuevo_Click" 
                    Text="Nuevo" CssClass="submit EstiloGeneralBoton btn-nuevo" />
            </td>
            <td>
                <asp:Button ID="btnCrearMeses" runat="server" onclick="btnCrearMeses_Click" 
                    OnClientClick="return confirm('Acontinuación Se Generaran Todos Los Meses Correspondientes Al Ejercicio Seleccionado. ¿Esta Seguro De Realizar Esta Acción?');" 
                    Text="Crear Meses" CssClass="submit EstiloGeneralBoton" />
            </td>
        </tr>
    </table>


<div style="overflow: auto; width: 100%; ">
    <table class="gridSmallCabecera">
        <tr>
            <th width="45px"></th>
            <th width="82px"><asp:Label ID="Label3" runat="server" Text="MES_ID" CssClass="tituloGrilla"></asp:Label></th>
            <th width="157px"><asp:Label ID="Label1" runat="server" Text="DESCRIPCION" CssClass="tituloGrilla"></asp:Label></th>
            <th width="650px"></th>
        </tr>
    </table>
</div>
<div style="overflow: auto; width: 100%; height: 330px; border:solid 0px;">
    <asp:GridView ID="grvMes" runat="server" 
        ShowHeader="False"
        AutoGenerateColumns="False" CellPadding="2" CssClass="gridSmall" 
        DataKeyNames="Mes_Id,Descripcion,Ejercicio_Id,nMes,nSemanas" ForeColor="#333333" 
        GridLines="None"
        onrowcommand="grvMes_RowCommand"
        onrowdeleting="grvMes_RowDeleting" AllowPaging="True" 
        onpageindexchanging="grvMes_PageIndexChanging" Width="100%" 
        onrowdatabound="grvMes_RowDataBound" >
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="ibtnSelect" runat="server" ToolTip="Seleccionar"
                        CommandName="Select" ImageUrl="../Icon/Modify.gif"  />
                    <asp:ImageButton ID="ibtnEliminar" runat="server" ToolTip="Eliminar"
                        CommandName="Delete"  ImageUrl="../Icon/delete.gif" 
                        OnClientClick="return confirm('¿Esta Seguro De Eliminar?');" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="6%" />
            </asp:TemplateField>
            <asp:BoundField DataField="Mes_Id" HeaderText="Mes_Id" ReadOnly="True">
                <ItemStyle Width="10%" Height="18px"  HorizontalAlign="Center" CssClass="FormatFontGridView" />
            </asp:BoundField>
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción">
                <ItemStyle Width="18%" HorizontalAlign="Center" CssClass="FormatFontGridView" />
            </asp:BoundField>
            <asp:TemplateField>
                     <ItemTemplate>
<Itemstyle Width="50%" HorizontalAlign="Center" CssClass="FormatFontGridView"></itemstyle>
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
    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Datos del Mes">
        <ContentTemplate>

<div class="textoGeneral">
    <asp:Panel ID="pnlNuevo" runat="server" GroupingText="Datos del Mes">
        <table>
            <tr>
                <td>
                    Mes Id</td>
                <td>
                    <asp:Label ID="lblMes_Id" runat="server" Width="50px" Height="18px" CssClass="lblCod"></asp:Label>
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
                <td>Ejercicio</td>
                <td>
                    <asp:DropDownList ID="cboEjercicio" CssClass="ddl" Width="100px" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Nro. Mes</td>
                <td>
                    <asp:TextBox ID="txtNroMes" runat="server" CssClass="txt" 
                        Width="100px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtNroMes" ErrorMessage="*" Text="*" 
                        ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Cant. Semanas</td>
                <td>
                    <asp:TextBox ID="txtCant_Semanas" runat="server" CssClass="txt" 
                        Width="100px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtCant_Semanas" ErrorMessage="*" Text="*" 
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
                        Text="Grabar" ValidationGroup="ValidaGraba" CssClass="submit EstiloGeneralBoton" />
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

