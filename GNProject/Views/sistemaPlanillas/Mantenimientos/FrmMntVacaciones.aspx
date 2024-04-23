<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmMntVacaciones.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Mantenimientos.FrmMntVacaciones" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />

    <link href="../Styles/nuevoEstiloPlanilla.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        function validaBuscar() {
            /*var error = document.getElementById('<%= txtNombrePersonal.ClientID %>').value;
            if (error == '') {
            mensajeLabel('Error... Para poder buscar debe Digitar los Nombres del Empleado');
            document.getElementById('<%= txtNombrePersonal.ClientID %>').focus();
            return false;
            } else {
            mensajeLabel('');
            return true;
            }*/
            return true;
        }
        function mensajeLabel(msg) {
            document.getElementById('<%= lblError.ClientID %>').innerHTML = msg;
        }
    </script>
    
         <table align="center" width="100%">
     <tr>
     <td>
        
        <fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px;
           /*border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black; */
            min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; /*border-top: solid 1px black;*/">
    
    
    <asp:Label ID="Label9" runat="server" Text="CONTROL DE VACACIONES" CssClass="miTitulo"></asp:Label>
    
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    
    <cc1:TabContainer ID="TabContainer1" Height="405px" runat="server" ActiveTabIndex="0" 
        ScrollBars="Vertical">
            <cc1:TabPanel ID="TabPanel1" HeaderText="Personal" runat="server">
            <ContentTemplate>

                
                     <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label60" runat="server" Text="Digite Los Nombres del Empleado : "
                                                 CssClass="miLabel"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNombrePersonal" CssClass="txt" runat="server" Width="200px"></asp:TextBox>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" 
                                            CssClass="submit EstiloGeneralBoton" OnClick="btnBuscar_Click" 
                                            ToolTip="Digite Los Nombres de un Empleado y de Click en Buscar"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                       </table>
                       
                                            <div id="HeaderDiv" style="overflow: hidden; width: 100%; border: solid 0px #000;height: 360px;">
                                                <table class="gridSmallCabecera" width="100%">
                                                    <tr>
                                                        <th width="28px">
                                                        </th>
                                                        <th width="95px">
                                                            <asp:Label ID="Label1" runat="server" Text="NRO. DOC" CssClass="tituloGrilla"></asp:Label>
                                                        </th>
                                                        <th width="740px">
                                                            <asp:Label ID="Label12" runat="server" Text="APELLIDOS Y NOMBRES" CssClass="tituloGrilla"></asp:Label>
                                                        </th>
                                                    </tr>
                                                    
                                                    <tr>
                                                   <td colspan="3">
                                                   <div id="divScroll" style="overflow: auto; width: 100%; border: solid 0px #000;
                                                height: 340px;">
                                                <asp:GridView ID="grvPersonal" runat="server" AutoGenerateColumns="False" CellPadding="2"
                                                    CssClass="gridSmall" DataKeyNames="Personal_Id,Nombre_Completo" ForeColor="#333333"
                                                    GridLines="None" OnRowCommand="grvPersonal_RowCommand" Width="100%" 
                                                    ShowHeader="False" onrowdatabound="grvPersonal_RowDataBound" 
                                                    AllowPaging="True"
                                                    PageSize="13" onpageindexchanging="grvPersonal_PageIndexChanging">
                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="IbtnSelect" runat="server" CommandName="Select" 
                                                                    ImageUrl="../Icon/forward.gif" ToolTip="Seleccionar" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="4%" CssClass="FormatFontGridView"/>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Nro_Doc" HeaderText="Nro. Doc.">
                                                            <ItemStyle HorizontalAlign="Center" Width="11%" CssClass="FormatFontGridView" 
                                                            Height="18px" />
                                                            <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                                Font-Bold="True" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Nombre_Completo" HeaderText="Apellidos y Nombres">
                                                            <ItemStyle Width="90%" CssClass="FormatFontGridView"/>
                                                            <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                                Font-Bold="True" />
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
                                            
                             
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel3" HeaderText="Vacaciones" runat="server" >
            <ContentTemplate>
            <div class="textoGeneral">
            
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" CssClass="miTituloOnTab" Font-Underline="True"
                                    Text="NOMBRE DEL EMPLEADO : " Width="130px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblNomPersonal" runat="server" CssClass="miLabel"></asp:Label>
                            </td>
                            <td>
                                <asp:Button ID="btnCalcular" runat="server" Text="Calcular y Generar Periodos" 
                                OnClick="btnCalcular_Click" CssClass="submit EstiloGeneralBoton" />
                            </td>
                            <td>
                                <asp:HiddenField ID="hdnPersonal_Id" runat="server" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    
                    <table width="100%">
                        <tr>
                            <td colspan="5">
                                <asp:GridView ID="grvVacaciones" runat="server" AutoGenerateColumns="False" 
                                CssClass="gridSmall" Width="100%"
                                    CellPadding="2" ForeColor="#333333" GridLines="None" DataKeyNames="Vacaciones_Id,Fecha_Ini,Fecha_Fin"
                                    OnRowDeleting="grvVacaciones_RowDeleting"
                                    OnRowCommand="grvVacaciones_RowCommand" 
                                    onrowdatabound="grvVacaciones_RowDataBound">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="IbtnSelect_Vacaciones" runat="server" ToolTip="Seleccionar"
                                                    CommandName="Select" ImageUrl="~/Views/sistemaPlanillas/Icon/Modify.gif" />
                                                <asp:ImageButton ID="ibtnEliminarVac" runat="server" ToolTip="Eliminar" CommandArgument='<%# Eval("Vacaciones_Id") %>'
                                                    CommandName="Delete" OnClientClick="return confirm('¿Esta Seguro De Eliminar?');"
                                                    ImageUrl="~/Views/sistemaPlanillas/Icon/delete.gif" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="6%"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Item" HeaderText="Item">
                                            <ItemStyle Width="5%" HorizontalAlign="Center"></ItemStyle>
                                            <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                Font-Bold="True" />
                                        </asp:BoundField>
                                        <asp:BoundField Visible="False" DataField="Personal_Id" HeaderText="Personal_Id">
                                            <ItemStyle Width="10%" HorizontalAlign="Center"></ItemStyle>
                                            <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                Font-Bold="True" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Fecha_Ini" HeaderText="Inicio" DataFormatString="{0:dd/MM/yyyy}">
                                            <ItemStyle Width="8%" HorizontalAlign="Center"></ItemStyle>
                                            <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                Font-Bold="True" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Fecha_Fin" HeaderText="Termino" DataFormatString="{0:dd/MM/yyyy}">
                                            <ItemStyle Width="8%" HorizontalAlign="Center"></ItemStyle>
                                            <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                Font-Bold="True" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Dias" HeaderText="Dias">
                                            <ItemStyle Width="6%" HorizontalAlign="Center"></ItemStyle>
                                            <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                Font-Bold="True" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Dias_Pagados" HeaderText="Pag">
                                            <ItemStyle Width="6%" HorizontalAlign="Center"></ItemStyle>
                                            <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                Font-Bold="True" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Dias_Pagados_Saldo" HeaderText="PSaldo">
                                            <ItemStyle Width="6%" HorizontalAlign="Center"></ItemStyle>
                                            <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                Font-Bold="True" />
                                        </asp:BoundField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <itemstyle width="45%"></itemstyle>
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
                            </td>
                        </tr>
                        </table>
                        
                        <table>
                        <tr>
                            <td>
                                <asp:HiddenField ID="hdnVacaciones_Id" runat="server" />
                                <asp:Label ID="lblNomPeriodoVac" runat="server"></asp:Label>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Panel ID="pnlNuevoDetalle" runat="server">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="cboPeriodoVacacion" runat="server" CssClass="ddl">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFec_Inicio" runat="server" CssClass="txt" Width="60px" ></asp:TextBox>
                                                <cc1:MaskedEditExtender ID="txtFec_Inicio_MaskedEditExtender" runat="server" CultureAMPMPlaceholder="a.m.;p.m."
                                                    CultureCurrencySymbolPlaceholder="S/." CultureDateFormat="DMY" CultureDatePlaceholder="/"
                                                    CultureDecimalPlaceholder="." CultureName="es-PE" CultureThousandsPlaceholder=","
                                                    CultureTimePlaceholder="" Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFec_Inicio"
                                                    UserDateFormat="DayMonthYear">
                                                </cc1:MaskedEditExtender>
                                                <cc1:CalendarExtender ID="txtFec_Inicio_CalendarExtender" runat="server" CssClass="calendar_Theme1"
                                                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFec_Inicio">
                                                </cc1:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFec_Inicio"
                                                    ErrorMessage="*" ValidationGroup="ValidaGrabaVac">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFec_Fin" runat="server" CssClass="txt" Width="60px"></asp:TextBox>
                                                <cc1:MaskedEditExtender ID="txtFec_Fin_MaskedEditExtender" runat="server" CultureAMPMPlaceholder="a.m.;p.m."
                                                    CultureCurrencySymbolPlaceholder="S/." CultureDateFormat="DMY" CultureDatePlaceholder="/"
                                                    CultureDecimalPlaceholder="." CultureName="es-PE" CultureThousandsPlaceholder=","
                                                    CultureTimePlaceholder="" Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFec_Fin"
                                                    UserDateFormat="DayMonthYear">
                                                </cc1:MaskedEditExtender>
                                                <cc1:CalendarExtender ID="txtFec_Fin_CalendarExtender" runat="server" CssClass="calendar_Theme1"
                                                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFec_Fin">
                                                </cc1:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFec_Fin"
                                                    ErrorMessage="*" ValidationGroup="ValidaGrabaVac">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="cboDetalle_Vac" runat="server" CssClass="ddl">
                                                    <asp:ListItem Value="0">NO VENDIDA</asp:ListItem>
                                                    <asp:ListItem Value="1">VENDIDA</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ibtnNuevo_DetalleVac" runat="server" Height="25px" ToolTip="Grabar"
                                                    ImageUrl="~/Views/sistemaPlanillas/Imgs/btnSave.png" OnClick="ibtnNuevo_DetalleVac_Click" ValidationGroup="ValidaGrabaVac"
                                                    Width="25px" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:GridView ID="grvVacaciones_Pagadas" runat="server" AutoGenerateColumns="False"
                                    CellPadding="4" CssClass="gridSmall" DataKeyNames="Vacaciones_Pagadas_Id,Periodo_Id"
                                    ForeColor="#333333" GridLines="None" OnRowCancelingEdit="grvVacaciones_Pagadas_RowCancelingEdit"
                                    OnRowDataBound="grvVacaciones_Pagadas_RowDataBound"
                                    OnRowDeleting="grvVacaciones_Pagadas_RowDeleting" OnRowEditing="grvVacaciones_Pagadas_RowEditing"
                                    OnRowUpdating="grvVacaciones_Pagadas_RowUpdating" ShowFooter="True">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="IbtnSelect_VacDet" runat="server" ToolTip="Editar" CommandArgument='<%# Eval("Vacaciones_Pagadas_Id") %>'
                                                    CommandName="Edit"  ImageUrl="~/Views/sistemaPlanillas/Icon/Modify.gif"  />
                                                <asp:ImageButton ID="ibtnEliminarDet" runat="server" ToolTip="Eliminar" CommandArgument='<%# Eval("Vacaciones_Pagadas_Id") %>'
                                                    CommandName="Delete" ImageUrl="~/Views/sistemaPlanillas/Icon/delete.gif" 
                                                    OnClientClick="return confirm('¿Esta Seguro De Eliminar?');" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:ImageButton ID="ibtnActualizarDet" runat="server" ToolTip="Actualizar" CommandArgument='<%# Eval("Vacaciones_Pagadas_Id") %>'
                                                    CommandName="Update"  ImageUrl="~/Views/sistemaPlanillas/Icon/Save.gif" 
                                                    ValidationGroup="Valida" />
                                                <asp:ImageButton ID="ibtnCancelarDet" runat="server" CommandName="Cancel" ToolTip="Cancelar"
                                                    ImageUrl="~/Views/sistemaPlanillas/Icon/back.gif" />
                                            </EditItemTemplate>
                                           <%-- <FooterTemplate>
                                                <asp:ImageButton ID="IbtnNuevo_VacDet" runat="server" CommandName="Insert" ToolTip="Nuevo Grabar"
                                                    Height="20px" ImageUrl="~/Views/sistemaPlanillas/Imgs/btnNew.png" Width="20px" ValidationGroup="ValidaNew" />
                                            </FooterTemplate>--%>
                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Vacaciones_Pagadas_Id" HeaderText="VACACIONES_PAGADAS_ID"
                                            Visible="False">
                                                   <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                Font-Bold="True" />
                                            <ItemStyle Width="50px" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="PERIODO">
                                               <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                Font-Bold="True" />
                                            <EditItemTemplate>
                                            
                                                <asp:DropDownList ID="cboPeriodoVac" runat="server" CssClass="ddl">
                                                </asp:DropDownList>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblPeriodoVac" runat="server" Text='<%# Eval("no_periodo") %>'></asp:Label>
                                            </ItemTemplate>
                                            <%--<FooterTemplate>
                                                <asp:DropDownList ID="cboPeriodoVacNew" runat="server" CssClass="ddl">
                                                </asp:DropDownList>
                                            </FooterTemplate>--%>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="INICIO">
                                               <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                Font-Bold="True" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblFecha_Inicio" runat="server" Text='<%# String.Format("{0:dd/MM/yyyy}", Eval("Fecha_Ini")) %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtFecha_Inicio" runat="server" CssClass="txt" Text='<%# String.Format("{0:dd/MM/yyyy}", Eval("Fecha_Ini")) %>'
                                                    Width="60px"></asp:TextBox>
                                                <cc1:MaskedEditExtender ID="txtFecha_Inicio_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                    CultureDecimalPlaceholder="" CultureName="es-PE" CultureThousandsPlaceholder=""
                                                    CultureTimePlaceholder="" Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFecha_Inicio"
                                                    UserDateFormat="DayMonthYear">
                                                </cc1:MaskedEditExtender>
                                                <cc1:CalendarExtender ID="txtFecha_Inicio_CalendarExtender" runat="server" CssClass="calendar_Theme1"
                                                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFecha_Inicio">
                                                </cc1:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFecha_Inicio"
                                                    ErrorMessage="*" ValidationGroup="Valida">*</asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <%--<FooterTemplate>
                                                <asp:TextBox ID="txtFecha_InicioNew" runat="server" CssClass="txt" Text='<%# String.Format("{0:dd/MM/yyyy}", Eval("Fecha_Ini")) %>'
                                                    Width="60px"></asp:TextBox>
                                                <cc1:MaskedEditExtender ID="txtFecha_InicioNew_MaskedEditExtender" runat="server"
                                                    CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                    CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureName="es-PE" CultureThousandsPlaceholder=""
                                                    CultureTimePlaceholder="" Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFecha_InicioNew"
                                                    UserDateFormat="DayMonthYear">
                                                </cc1:MaskedEditExtender>
                                                <cc1:CalendarExtender ID="txtFecha_InicioNew_CalendarExtender" runat="server" CssClass="calendar_Theme1"
                                                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFecha_InicioNew">
                                                </cc1:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFecha_InicioNew"
                                                    ErrorMessage="*" ValidationGroup="ValidaNew">*</asp:RequiredFieldValidator>
                                            </FooterTemplate>--%>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="FIN">
                                               <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                Font-Bold="True" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblFecha_Fin" runat="server" Text='<%# String.Format("{0:dd/MM/yyyy}", Eval("Fecha_Fin")) %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtFecha_Fin" runat="server" CssClass="txt" Text='<%# String.Format("{0:dd/MM/yyyy}", Eval("Fecha_Fin")) %>'
                                                    Width="60px"></asp:TextBox>
                                                <cc1:MaskedEditExtender ID="txtFecha_Fin_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                    CultureDecimalPlaceholder="" CultureName="es-PE" CultureThousandsPlaceholder=""
                                                    CultureTimePlaceholder="" Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFecha_Fin"
                                                    UserDateFormat="DayMonthYear">
                                                </cc1:MaskedEditExtender>
                                                <cc1:CalendarExtender ID="txtFecha_Fin_CalendarExtender" runat="server" CssClass="calendar_Theme1"
                                                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFecha_Fin">
                                                </cc1:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFecha_Fin"
                                                    ErrorMessage="*" ValidationGroup="Valida">*</asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <%--<FooterTemplate>
                                                <asp:TextBox ID="txtFecha_FinNew" runat="server" CssClass="txt" Text='<%# String.Format("{0:dd/MM/yyyy}", Eval("Fecha_Fin")) %>'
                                                    Width="60px"></asp:TextBox>
                                                <cc1:MaskedEditExtender ID="txtFecha_FinNew_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                    CultureDecimalPlaceholder="" CultureName="es-PE" CultureThousandsPlaceholder=""
                                                    CultureTimePlaceholder="" Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFecha_FinNew"
                                                    UserDateFormat="DayMonthYear">
                                                </cc1:MaskedEditExtender>
                                                <cc1:CalendarExtender ID="txtFecha_FinNew_CalendarExtender" runat="server" CssClass="calendar_Theme1"
                                                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFecha_FinNew">
                                                </cc1:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtFecha_FinNew"
                                                    ErrorMessage="*" ValidationGroup="ValidaNew">*</asp:RequiredFieldValidator>
                                            </FooterTemplate>--%>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Dias" HeaderText="DIAS" ReadOnly="True">
                                            <ItemStyle Width="40px" HorizontalAlign="Center" />
                                                   <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                Font-Bold="True" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="DETALLE">
                                               <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                Font-Bold="True" />
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_no_detalle" runat="server" Text='<%# Eval("no_detalle") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="cboNomDetalle_Vac" runat="server" CssClass="ddl">
                                                    <asp:ListItem Value="0">NO VENDIDA</asp:ListItem>
                                                    <asp:ListItem Value="1">VENDIDA</asp:ListItem>
                                                </asp:DropDownList>
                                            </EditItemTemplate>
                                            <%--<FooterTemplate>
                                                <asp:DropDownList ID="cboNomDetalle_VacNew" runat="server" CssClass="ddl">
                                                    <asp:ListItem Selected="True" Value="0">NO VENDIDA</asp:ListItem>
                                                    <asp:ListItem Value="1">VENDIDA</asp:ListItem>
                                                </asp:DropDownList>
                                            </FooterTemplate>--%>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#9ADBFA" />
                                </asp:GridView>
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

