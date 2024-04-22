<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmMntPlanilla.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Mantenimientos.FrmMntPlanilla" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 
    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/nuevoEstiloPlanilla.css" rel="stylesheet" type="text/css" />
    
             <table align="center" width="100%">
     <tr>
     <td>
        
        <fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px;
           /*border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black;*/ 
            min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; /*border-top: solid 1px black;*/">
    
    <br />
    
    <asp:Label ID="Label9" runat="server" Text="MANTENIMIENTO DE PLANILLAS" 
    CssClass="miTitulo"></asp:Label>
    <br />
    <br />
    
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    
    <cc1:TabContainer ID="TabContainer1" Width="100%" Height="405px" runat="server" ActiveTabIndex="0"
        ScrollBars="Vertical">
        
        <cc1:TabPanel ID="TabPanel1" HeaderText="Listar" runat="server">
            <ContentTemplate>
                <div class="textoGeneral">
                            
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="Label17" runat="server" Text="Busqueda" CssClass="miTituloOnTab"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="Digite la Planilla" CssClass="miLabel"
                                                Width="90px"></asp:Label>
                                        </td>
                                        <td style="width:315px;">
                                            <asp:TextBox ID="txtPlanillaBuscar" CssClass="miTextbox" Width="300px" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnListar" runat="server" Text="Listar" CssClass="submit" OnClick="btnListar_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" CssClass="submit"
                                                Text="Nuevo" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                

                                            <div id="HeaderDiv" style="overflow: hidden; width: 100%; border: solid 0px #000;">
                                                <table class="gridSmallCabecera" width="100%">
                                                    <tr>
                                                        <th width="39px">
                                                        </th>
                                                        <th width="60px">
                                                            <asp:Label ID="Label2" runat="server" Text="PLANILLA_ID" CssClass="tituloGrilla"></asp:Label>
                                                        </th>
                                                        <th width="762px">
                                                            <asp:Label ID="Label3" runat="server" Text="DESCRIPCION" CssClass="tituloGrilla"></asp:Label>
                                                        </th>
                                                    </tr>
                                    
                                    <tr>
                                        <td colspan="3">
                                            <div id="divScroll" style="overflow: auto; width: 100%; border: solid 0px #000;
                                                height: 290px;">
                                                <asp:GridView ID="grvPlanilla" runat="server" ShowHeader="False" AutoGenerateColumns="False"
                                                    CellPadding="2" CssClass="gridSmall" DataKeyNames="Planilla_Id" ForeColor="#333333"
                                                    GridLines="None" Width="100%" OnRowCommand="grvPlanilla_RowCommand" OnRowDeleting="grvPlanilla_RowDeleting"
                                                    AllowPaging="True" OnPageIndexChanging="grvPlanilla_PageIndexChanging" 
                                                    onrowdatabound="grvPlanilla_RowDataBound">
                                                      <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ibtnSelect" runat="server" ToolTip="Editar" CommandName="Select"
                                                                   ImageUrl="../Icon/Modify.gif"  />
                                                                <asp:ImageButton ID="ibtnEliminar" runat="server" ToolTip="Eliminar" CommandName="Delete"
                                                                     ImageUrl="../Icon/delete.gif"  OnClientClick="return confirm('¿Esta Seguro De Eliminar?');" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Planilla_Id" HeaderText="Planilla_Id" ReadOnly="True">
                                                            <ItemStyle Width="9%" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción">
                                                            <ItemStyle Width="85%" />
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
                                        </td>
                                    </tr>
                                </table>
                                </div>
                                
                </div>
            </ContentTemplate>
        </cc1:TabPanel>
        
        <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Datos de la Planilla">
            <ContentTemplate>
                <div class="textoGeneral">
                
                 <%--   <asp:Panel ID="pnlNuevo" runat="server" GroupingText="Datos del Planilla">
                     </asp:Panel>--%>
                     
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Planilla Id" CssClass="miLabel"></asp:Label> 
                                </td>
                                <td>
                                    <asp:Label ID="lblPlanilla_Id" runat="server" Width="50px" Height="18px" CssClass="lblCod"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="Compañia" CssClass="miLabel"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="cboCompania" runat="server" CssClass="ddl" Width="300px" AutoPostBack="True"
                                        OnSelectedIndexChanged="cboCompania_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="Descripción" CssClass="miLabel"></asp:Label> 
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="txt" Width="300px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDescripcion"
                                        ErrorMessage="*" Text="*" ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text="Periodicidad" CssClass="miLabel"></asp:Label> 
                                </td>
                                <td>
                                    <asp:DropDownList ID="cboPeriodicidad" runat="server" CssClass="ddl" Width="300px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Text="Estado" CssClass="miLabel"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="cboEstado" runat="server" CssClass="ddl" Width="300px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label10" runat="server" Text="Planilla Maestra" CssClass="miLabel"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="cboPlanilla_Master" runat="server" CssClass="ddl" Width="300px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Button ID="btnGrabar" runat="server" OnClick="btnGrabar_Click" Text="Grabar"
                                        ValidationGroup="ValidaGraba" />
                                    &nbsp;
                                    <asp:Button ID="btnActualizar" runat="server" OnClick="btnActualizar_Click" Text="Actualizar"
                                        ValidationGroup="ValidaGraba" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                   
                    
                </div>
            </ContentTemplate>
        </cc1:TabPanel>
        
    </cc1:TabContainer>

     </ContentTemplate>
    </asp:UpdatePanel>
    
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
        DisplayAfter="1">
        <ProgressTemplate>
            <div class="UpdateProgressModalBackground">
            </div>
            <center>
                <div class="UpdateProgressPanel">
                    Cargando...<br />
                    <br />
                    <asp:Image ID="Image2" runat="server" alt="Procesando" ImageUrl="~/Views/sistemaPlanilla/css/ajax-loader.gif" />
                </div>
            </center>
        </ProgressTemplate>
    </asp:UpdateProgress>
    
               </fieldset>
    
         </td>
     </tr>
     </table>
    
</asp:Content>
