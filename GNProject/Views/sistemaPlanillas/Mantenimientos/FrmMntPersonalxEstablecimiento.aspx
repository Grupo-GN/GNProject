<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmMntPersonalxEstablecimiento.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Mantenimientos.FrmMntPersonalxEstablecimiento" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/nuevoEstiloPlanilla.css" rel="stylesheet" type="text/css" />

     <table align="center" width="100%">
     <tr>
     <td>
        
        <fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px; 
            min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; /*border-top: solid 1px black;*/">

    <br />
    
    <asp:Label ID="Label9" runat="server" Text="MAESTRO DE ESTABLECIMIENTOS - PERSONAL POR PERIODO" 
    CssClass="miTitulo"></asp:Label>
    <br />
    <br />
    
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

<div>
    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" 
        onclick="btnNuevo_Click"  CssClass="submit" />
    &nbsp;
    <asp:Button ID="btnAsignacionMasiva" runat="server" 
        onclick="btnAsignacionMasiva_Click" Text="Asignación Masiva"  CssClass="submit"/>
</div>

<br />

<asp:Panel ID="pnlAsignacionNormal" runat="server">
    <table>
        <tr>
            <td width="480px">
                <div>
                    <asp:Label ID="Label3" runat="server" Text="Filtro por Establecimiento : " CssClass="miLabel"></asp:Label>
                    <asp:DropDownList ID="cboEstablecimiento" 
                        runat="server" Width="250px" AutoPostBack="True" 
                        onselectedindexchanged="cboEstablecimiento_SelectedIndexChanged" 
                        CssClass="ddl">
                    </asp:DropDownList>
                </div>
                <div style="overflow: auto; width: 450px; ">
                    <table class="gridSmallCabecera">
                        <tr>
                            <th width="35px"></th>
                            <th width="211px"> <asp:Label ID="Label2" runat="server" Text="PERSONAL" CssClass="tituloGrilla"></asp:Label></th>
                            <th width="160px"> <asp:Label ID="Label1" runat="server" Text="ESTABLECIMIENTO" CssClass="tituloGrilla"></asp:Label></th>
                        </tr>
                    </table>
                </div>
                <div style="overflow: auto; width: 450px; height: 360px; border:solid 0px;">
                <%--<div>--%>
                    <asp:GridView ID="grvPersonal" runat="server" AutoGenerateColumns="False"
                        ShowHeader="false"
                        CssClass="gridSmall" CellPadding="2" ForeColor="#333333"
                        GridLines="None" DataKeyNames="Personal_Id, Nombre_Completo, Periodo_Id" 
                        onrowcommand="grvPersonal_RowCommand" 
                        onrowdeleting="grvPersonal_RowDeleting" 
                        onrowdatabound="grvPersonal_RowDataBound">
                         <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="IbtnSelect" runat="server" ToolTip="Seleccionar"
                                        CommandName="Select"
                                        ImageUrl="~/Icon/Modify.gif" />
                                    <asp:ImageButton ID="IbtnDelete" runat="server" ToolTip="Eliminar"
                                        CommandName="Delete"
                                        ImageUrl="~/Icon/delete.gif"
                                        OnClientClick="return confirm('¿Esta Seguro De Eliminar?');" />
                                </ItemTemplate>      
                                <ItemStyle Width="50px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Nombre_Completo" HeaderText="Personal">
                                <ItemStyle Width="250px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="no_Establecimiento" HeaderText="Establecimiento">
                                <ItemStyle Width="180px"></ItemStyle>
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
                <br />
                      <asp:Label ID="Label4" runat="server" CssClass="miLabelSuma" Text="Totales por Establecimiento : "></asp:Label>
                    <asp:Label ID="lblTotEstablecimiento" runat="server" CssClass="miLabelSuma"></asp:Label>
            </td>
            <td valign="top">
                <asp:Panel ID="pnlDatosPersonal" runat="server" GroupingText="Datos Personal">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="Periodo : " CssClass="miLabel"></asp:Label>
                                </td>
                            <td>
                                <asp:Label ID="lblPeriodo" runat="server"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                   <asp:Label ID="Label6" runat="server" Text="Personal : " CssClass="miLabel"></asp:Label> </td>
                            <td>
                                <asp:DropDownList ID="cboPersonal" Width="250px" runat="server" CssClass="ddl">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="cboPersonal" ErrorMessage="*" InitialValue="-Seleccione-" 
                                    ValidationGroup="Valida">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                 <asp:Label ID="Label7" runat="server" Text="Establecimiento : " CssClass="miLabel"></asp:Label> </td>
                            <td>
                                <asp:DropDownList ID="cboEstablecimientoNew" Width="250px" runat="server" 
                                    CssClass="ddl">
                                </asp:DropDownList>
                                                </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="cboEstablecimientoNew" ErrorMessage="*" 
                                    InitialValue="-Seleccione-" ValidationGroup="Valida">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text="Tasa : " CssClass="miLabel"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtTasa" runat="server" CssClass="txt" Width="50px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ControlToValidate="txtTasa" ErrorMessage="*" ValidationGroup="Valida">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:CheckBox ID="ckDestacaOtraEmpresa" runat="server" 
                                    CssClass="ck" Text="Es un personal que destaque a otra empresa?" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:CheckBox ID="ckDestacaDesdeOtraEmpresa" runat="server" 
                                    CssClass="ck" Text="Es un personal que me destacan desde otra empresa?" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Button ID="btnGrabar" runat="server" Text="Grabar" 
                                    onclick="btnGrabar_Click" ValidationGroup="Valida" CssClass="submit" />
                                &nbsp;
                                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" 
                                    onclick="btnActualizar_Click" ValidationGroup="Valida" CssClass="submit" />
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>        
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Panel>

<asp:Panel ID="pnlAsignacionMasiva" runat="server">

    <table class="style1">
        <tr>
            <td>
                <div>
                    Establecimiento Origen: <asp:DropDownList ID="cboEstablecimientoOrigen" 
                        runat="server" Width="250px" AutoPostBack="True" CssClass="ddl" 
                        onselectedindexchanged="cboEstablecimientoOrigen_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </td>
            <td>
                &nbsp;</td>
            <td>
                <div>
                    Establecimiento Destino: <asp:DropDownList ID="cboEstablecimientoDestino" 
                        runat="server" Width="250px" AutoPostBack="True" CssClass="ddl" 
                        onselectedindexchanged="cboEstablecimientoDestino_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btnGrabarMasivo" runat="server" onclick="btnGrabarMasivo_Click" 
                    Text="Grabar" />
            </td>
        </tr>
        <tr>
            <td valign="top" align="center">
                <div style="overflow: auto; width: 300px; ">
                    <table class="gridSmallCabecera">
                        <tr>
                            <th width="40px">
                                <input name="SelectAllCheckBox2" class="ck" onclick="SelectAllCheckBoxes(this , 'grvPersonalOrigen')" type="checkbox" title="Seleccionar Todo" />
                            </th>
                            <%--<th width="248px">Personal</th>--%>
                            <th width="257px">Personal</th>
                        </tr>
                    </table>
                </div>
                <div style="overflow: auto; width: 300px; height: 400px">
                    <asp:GridView ID="grvPersonalOrigen" runat="server" AutoGenerateColumns="False"
                        ShowHeader="false"
                        CssClass="gridSmall" CellPadding="4" ForeColor="#333333"
                        GridLines="None" DataKeyNames="Personal_Id, Nombre_Completo" >
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <input name="SelectAllCheckBox" class="ck" onclick="SelectAllCheckBoxes(this , 'grvPersonalOrigen')" type="checkbox" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox CssClass="ck" ID="ckOrigen" runat="server" />
                                </ItemTemplate>
                                <ItemStyle Width="33px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Nombre_Completo" HeaderText="Personal">
                                <ItemStyle Width="250px" HorizontalAlign="Left"></ItemStyle>
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
            <td>
                <asp:Button ID="btnAgregar" runat="server" Text="&gt;&gt;" 
                    onclick="btnAgregar_Click" />
                <br />
                <asp:Button ID="btnQuitar" runat="server" Text="&lt;&lt;" 
                    onclick="btnQuitar_Click" />
            </td>
            <td valign="top" align="center">
                <div style="overflow: auto; width: 300px; ">
                    <table class="gridSmallCabecera">
                        <tr>
                            <th width="40px">
                                <input name="SelectAllCheckBox3" class="ck" onclick="SelectAllCheckBoxes(this , 'grvPersonalDestino')" type="checkbox" title="Seleccionar Todo" />
                            </th>
                            <%--<th width="248px">Personal</th>--%>
                            <th width="257px">Personal</th>
                        </tr>
                    </table>
                </div>
                <div style="overflow: auto; width: 300px; height: 400px">
                    <asp:GridView ID="grvPersonalDestino" runat="server" AutoGenerateColumns="False"
                        ShowHeader="false"
                        CssClass="gridSmall" CellPadding="4" ForeColor="#333333"
                        GridLines="None" DataKeyNames="Personal_Id, Nombre_Completo" >
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <input name="SelectAllCheckBox" class="ck" onclick="SelectAllCheckBoxes(this , 'grvPersonalDestino')" type="checkbox" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox CssClass="ck" ID="ckDestino" runat="server" />
                                </ItemTemplate>
                                <ItemStyle Width="33px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Nombre_Completo" HeaderText="Personal">
                                <ItemStyle Width="250px" HorizontalAlign="Left"></ItemStyle>
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
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>

</asp:Panel>

    
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
            alt="Procesando" ImageUrl="~/Views/sistemaPLanillas/css/ajax-loader.gif" /> 
            </div> 
        </center>
    </ProgressTemplate>
                                        
</asp:UpdateProgress>

       </fieldset>
    
         </td>
     </tr>
     </table>

</asp:Content>

