<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmPrm_x_Periodo.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Datos.FrmPrm_x_Periodo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

   <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />

       <table align="center" width="100%">
     <tr>
     <td>
        
        <fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px;
           border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black; 
            min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; border-top: solid 1px black;">

    <br />
    <asp:Label ID="Label1" runat="server" Text="PARAMETROS POR PERIODO" CssClass="miTitulo" ></asp:Label> 
<br />
<br />
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
<fieldset style="overflow:auto; border-style: outset; border-width: thin; height:90%;
     min-height:410px; width: 97.5%; background-color:White">

<table width="100%">
<tr>
<td>

<div>
    <asp:Panel ID="pnlFiltro" runat="server">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Periodo" CssClass="miLabel"></asp:Label>
                    </td>
                <td>
                    <asp:DropDownList ID="cboPeriodo" runat="server" CssClass="ddl" Width="200px" 
                        AutoPostBack="True" onselectedindexchanged="cboPeriodo_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:ImageButton ID="btnBuscar" runat="server" Height="18px" ToolTip="Buscar"
                        ImageUrl="~/Views/sistemaPlanillas/Imgs/Buscar.png" Width="34px" onclick="btnBuscar_Click" />
                </td>
                <td>
                    <asp:ImageButton ID="btnGrabar" runat="server" Height="25px" ToolTip="Grabar Todo" 
                        ImageUrl="~/Views/sistemaPlanillas/Imgs/btnSave.png" OnClientClick="return confirm('¿Esta Seguro De Grabar Todos los Registros?');"
                        ValidationGroup="ValidaGrabaVac" Width="25px" onclick="btnGrabar_Click" />
                </td>
                <td>
                    <asp:Button ID="btnGenerar" runat="server" Text="Generar"  CssClass="submit"
                        onclick="btnGenerar_Click" ToolTip="Genera los Parametros por Periodo" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</div>

<div style="overflow: auto; width: 100%;">
    <table class="gridSmallCabecera" width="100%">
       <tr>
            <th width="40px"><asp:Label ID="Label3" runat="server" Text="NRO" CssClass="tituloGrilla"></asp:Label></th>
            <th width="110px"><asp:Label ID="Label4" runat="server" Text="CONCEPTO ID" CssClass="tituloGrilla"></asp:Label></th>
            <th width="635px"><asp:Label ID="Label5" runat="server" Text="DESCRIPCION" CssClass="tituloGrilla"></asp:Label></th>
            <th width="91px"><asp:Label ID="Label6" runat="server" Text="VALOR" CssClass="tituloGrilla" ></asp:Label></th>
        </tr>
    </table>
</div>

<div style="overflow: auto; width: 100%;">

    <asp:GridView ID="grvLista" runat="server" 
        ShowHeader="false"
        PageSize="13"
        AutoGenerateColumns="False" CellPadding="2" CssClass="gridSmall" 
        DataKeyNames="Periodo_Id, Concepto_Id"
        GridLines="None"
        AllowPaging="True" 
        onpageindexchanging="grvLista_PageIndexChanging" 
        onrowdatabound="grvLista_RowDataBound" Width="100%" 
        onprerender="grvLista_PreRender">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField HeaderText="Nro">
	            <ItemTemplate>
        	            <%# Container.DataItemIndex + 1 %>
	            </ItemTemplate>
	            <ItemStyle Width="40px" HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="Concepto_Id" HeaderText="Concepto_Id" ReadOnly="true">
                <ItemStyle Width="120px" HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="no_Concepto" HeaderText="Descripción" ReadOnly="true">
                <ItemStyle Width="636px" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Valor">
                <ItemTemplate>
                    <asp:TextBox ID="txtValor" runat="server" Width="91px" Text='<%# Eval("Valor") %>' CssClass="txt_align_derecha">
                    </asp:TextBox>
                </ItemTemplate>
                <ItemStyle Width="91px" HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
       <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    </asp:GridView>
    
</div>

</td>
</tr>
</table>

</fieldset>

<br />

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

