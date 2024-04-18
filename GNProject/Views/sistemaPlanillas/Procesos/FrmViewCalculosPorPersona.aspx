<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmViewCalculosPorPersona.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Procesos.FrmViewCalculosPorPersona" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/nuevoEstiloPlanilla.css" rel="stylesheet" type="text/css" />
    
    
             <table align="center" width="100%">
     <tr>
     <td>
        
        <fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px;
           /*border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black;*/ 
            min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; /*border-top: solid 1px black;*/">
    
    <br />
    <asp:Label ID="Label9" runat="server" Text="VERIFICACION DE FORMULAS" CssClass="miTitulo"></asp:Label>
    <br />
    <br />
   <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            
    <cc1:TabContainer ID="TabContainer1" Height="410px" runat="server" ActiveTabIndex="0"
        ScrollBars="Vertical">
        <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="Calculos">
            <ContentTemplate>
            <div class="textoGeneral">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label17" runat="server" Text="Personal :  " CssClass="miTituloOnTab"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPersona" runat="server" CssClass="ddl" 
                                AutoPostBack="True" onprerender="ddlPersona_PreRender" 
                                onselectedindexchanged="ddlPersona_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="miLabel" runat="server" Text="Proceso :  " CssClass="miTituloOnTab"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlProceso" runat="server" CssClass="ddl">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click"
                                CssClass="submit" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;
                        </td>
                        <td>
                        
                            <asp:LinkButton ID="elLink" runat="server" ForeColor="Blue" 
                                onclick="elLink_Click">Refrescar Personal</asp:LinkButton>
                        
                        </td>
                    </tr>
                </table>
                <div style="overflow: auto; width: 100%; border: solid 0px #000;">
                    <asp:GridView ID="grvCalculos" runat="server" AutoGenerateColumns="False" CssClass="gridSmall"
                        CellPadding="1" GridLines="None" Width="100%" OnRowCommand="grvCalculos_RowCommand"
                        OnRowDataBound="grvCalculos_RowDataBound" 
                        onprerender="grvCalculos_PreRender">
                        <AlternatingRowStyle BackColor="White"  ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" ImageUrl="~/Views/sistemaPlanillas/Imgs/Buscar.png" Width="25px" Height="15px"
                                        ID="btnShowDetail" CommandName="ShowDetail" CommandArgument='<%#Eval("Formula_Id").ToString()+":"+Eval("Descripcion").ToString()%>' /></ItemTemplate>
                                <ItemStyle Width="4%" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="NRO ORDEN" DataField="Nro">
                                <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                    Font-Bold="True" />
                                <ItemStyle Width="7%" HorizontalAlign="Center" Font-Size="X-Small" Font-Names="arial" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="DESCRIPCION" DataField="Descripcion">
                                <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                    Font-Bold="True" />
                                <ItemStyle Width="81%" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="VALOR" DataField="Valor">
                                <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                    Font-Bold="True" />
                                <ItemStyle Width="8%" HorizontalAlign="Right" Font-Bold="True" 
                                Font-Names="Arial" Font-Size="X-Small" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
                </div>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Fijos">
            <ContentTemplate>
                  <asp:Label ID="Label5" runat="server" Text="DATOS FIJOS" CssClass="miTituloOnTab"></asp:Label></u>
                  <br />   
                            <div style="overflow: auto; width: 100%; border: solid 0px #000;">
                                <asp:GridView ID="grvFijos" runat="server" AutoGenerateColumns="False" CssClass="gridSmall"
                                    CellPadding="3" GridLines="None" Width="100%" 
                                    onrowdatabound="grvFijos_RowDataBound" onprerender="grvFijos_PreRender">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField HeaderText="DESCRIPCION" DataField="Descripcion">
                                            <ItemStyle Width="90%" CssClass="FormatFontGridView"/>
                                            <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                Font-Bold="True" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="VALOR" DataField="Valor">
                                            <ItemStyle Width="10%" HorizontalAlign="Right" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small"/>
                                            <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                Font-Bold="True" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="Variables">
            <ContentTemplate>
                 <asp:Label ID="Label4" runat="server" Text="VARIABLES" CssClass="miTituloOnTab"></asp:Label>
                            <br />                 
                            <div style="overflow: auto; width: 100%; border: solid 0px #000;">
                                <asp:GridView ID="grvVariables" runat="server" AutoGenerateColumns="False" CssClass="gridSmall"
                                    CellPadding="3" GridLines="None" Width="100%" 
                                    onrowdatabound="grvVariables_RowDataBound" 
                                    onprerender="grvVariables_PreRender">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField HeaderText="DESCRIPCION" DataField="Descripcion">
                                            <ItemStyle Width="90%" CssClass="FormatFontGridView"/>
                                            <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                Font-Bold="True" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="VALOR" DataField="Valor">
                                            <ItemStyle Width="10%" HorizontalAlign="Right" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small"/>
                                            <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                Font-Bold="True" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </div>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="Parametros">
            <ContentTemplate>
 

                                <asp:Label ID="Label6" runat="server" Text="PARAMETROS" CssClass="miTituloOnTab"></asp:Label></u>
                            <br />
                            
                            <div style="overflow: auto; width: 100%; border: solid 0px #000;">
                                <asp:GridView ID="grvParametros" runat="server" AutoGenerateColumns="False" CssClass="gridSmall"
                                    CellPadding="3" GridLines="None" Width="100%" 
                                    onrowdatabound="grvParametros_RowDataBound" 
                                    onprerender="grvParametros_PreRender">
                                    <Columns>
                                        <asp:BoundField HeaderText="DESCRIPCION" DataField="Descripcion">
                                            <ItemStyle Width="90%" CssClass="FormatFontGridView"/>
                                            <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                Font-Bold="True" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="VALOR" DataField="Valor">
                                            <ItemStyle Width="10%" HorizontalAlign="Right" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small"/>
                                            <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                Font-Bold="True" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                    </div>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel5" runat="server" HeaderText="Acumulados">
            <ContentTemplate>

                                <asp:Label ID="Label3" runat="server" Text="ACUMULADOS" CssClass="miTituloOnTab"></asp:Label></u>
                            <br />
                            <div style="overflow: auto; width: 100%; border: solid 0px #000;">
                                <asp:GridView ID="grvAcumulados" runat="server" AutoGenerateColumns="False" CssClass="gridSmall"
                                    CellPadding="3" GridLines="None" Width="100%" 
                                    onrowdatabound="grvAcumulados_RowDataBound" 
                                    onprerender="grvAcumulados_PreRender">
                                    <Columns>
                                        <asp:BoundField HeaderText="DESCRIPCION" DataField="Descripcion">
                                            <ItemStyle Width="90%" CssClass="FormatFontGridView"/>
                                            <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                Font-Bold="True" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="VALOR" DataField="Valor">
                                            <ItemStyle Width="10%" HorizontalAlign="Right" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small"/>
                                            <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                Font-Bold="True" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </div>
      
            </ContentTemplate>
        </cc1:TabPanel>
    </cc1:TabContainer>
    
    <asp:Button ID="btnHide" runat="server" Style="display: none" />
    
    <cc1:ModalPopupExtender ID="pnl" runat="server" TargetControlID="btnHide" PopupControlID="pnlDetail"
        BackgroundCssClass="FondoAplicacion" CancelControlID="btnCerrar">
    </cc1:ModalPopupExtender>
    
    <asp:Panel ID="pnlDetail" runat="server" Width="600px" Height="300px" BackColor="LightGray"
        Style="display: none">
        <table class="style1">
            <tr>
                <td>
                </td>
                <td>
                    <asp:Label ID="lblFormula" runat="server" Text="" CssClass="miTituloOnTab"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" CssClass="miLabel" Text="Formula : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFormula" runat="server" Width="500px" Height="100px" CssClass="txt"
                        Wrap="true" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" CssClass="miLabel" Text="Condicion : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCondicion" runat="server" Width="500px" Height="100px" CssClass="txt"
                        Wrap="true" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
        <asp:Button ID="btnCerrar" runat="server" Text="Cerrar" CssClass="submit" />
    </asp:Panel>
    
    </ContentTemplate>
    </asp:UpdatePanel>
    
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
    AssociatedUpdatePanelID="UpdatePanel1"
        DisplayAfter="1">
        <ProgressTemplate>
            <div class="UpdateProgressModalBackground">
            </div>
            <center>
                <div class="UpdateProgressPanel">
                    Cargando...<br />
                    <br />
                    <asp:Image ID="Image2" runat="server" alt="Procesando" ImageUrl="~/Views/sistemaPlanillas/css/ajax-loader.gif" />
                </div>
            </center>
        </ProgressTemplate>
    </asp:UpdateProgress>
    
    </fieldset>
         </td>
     </tr>
     </table>
    
</asp:Content>

