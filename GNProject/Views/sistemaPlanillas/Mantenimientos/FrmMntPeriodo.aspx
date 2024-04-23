<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmMntPeriodo.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Mantenimientos.FrmMntPeriodo" %>

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
    
    
    <asp:Label ID="Label9" runat="server" Text="MANTENIMIENTO DE PERIODOS" CssClass="miTitulo"></asp:Label>
    
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
<cc1:TabContainer ID="TabContainer1" Height="410px" runat="server" ActiveTabIndex="0"
ScrollBars="Vertical" Width="100%">
    <cc1:TabPanel ID="TabPanel1" HeaderText="Lista" runat="server">
        <HeaderTemplate>
            Lista
        </HeaderTemplate>
        <ContentTemplate>


    <table>
<tr>
            <td>
                                            <asp:Label ID="Label60" runat="server" Text="Digite La Descripcion : "
                                                CssClass="miLabel" Width="120px"></asp:Label>
                                        </td>
            <td>
                <asp:TextBox ID="txtDescripcionBuscar" CssClass="txt" Width="300px" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnListar" runat="server" Text="Listar" 
                    onclick="btnListar_Click"  CssClass="submit EstiloGeneralBoton"/>
            </td>
            <td>
                <asp:Button ID="btnNuevo" runat="server" onclick="btnNuevo_Click" 
                    Text="Nuevo" CssClass="submit EstiloGeneralBoton btn-nuevo" />
            </td>
            
        </tr>
    </table>


<div style="overflow: auto; width: 100%; ">
    <table class="gridSmallCabecera">
        <tr>
            <th width="48px"></th>
            <th width="100px"><asp:Label ID="Label1" runat="server" Text="PERIODO_ID" CssClass="tituloGrilla"></asp:Label></th>
            <th width="776px"><asp:Label ID="Label2" runat="server" Text="DESCRIPCION" CssClass="tituloGrilla"></asp:Label></th>
        </tr>
    </table>
</div>

<div style="overflow: auto; width: 100%; border:solid 0px;">
    <asp:GridView ID="grvPeriodo" runat="server"  Width="100%"
        ShowHeader="False"
        AutoGenerateColumns="False" CellPadding="2" CssClass="gridSmall" 
        DataKeyNames="Periodo_Id" ForeColor="#333333" 
        GridLines="None"
        onrowcommand="grvPeriodo_RowCommand"
        onrowdeleting="grvPeriodo_RowDeleting" AllowPaging="True" 
        onpageindexchanging="grvPeriodo_PageIndexChanging" 
        onrowdatabound="grvPeriodo_RowDataBound" >
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="ibtnSelect" runat="server" ToolTip="Editar"
                        CommandName="Select"  ImageUrl="../Icon/Modify.gif" />
                    <asp:ImageButton ID="ibtnEliminar" runat="server" ToolTip="Eliminar"
                        CommandName="Delete" ImageUrl="../Icon/delete.gif" 
                        OnClientClick="return confirm('¿Esta Seguro De Eliminar?');" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="45px" />
            </asp:TemplateField>
            <asp:BoundField DataField="Periodo_Id" HeaderText="Periodo_Id" ReadOnly="True">
                <ItemStyle Width="110px" Height="18px" HorizontalAlign="Center" CssClass="FormatFontGridView" />
            </asp:BoundField>
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción">
                <ItemStyle Width="684px" CssClass="FormatFontGridView" />
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
    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Datos del Periodo">
        <ContentTemplate>

<div class="textoGeneral">
    <asp:Panel ID="pnlNuevo" runat="server" GroupingText="Datos del Periodo">
        <table>
            <tr>
                <td>
                    Periodo Id</td>
                <td colspan="3">
                    <asp:Label ID="lblPeriodo_Id" runat="server" Width="50px" Height="18px" CssClass="lblCod"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Descripción</td>
                <td colspan="3">
                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="txt" 
                        Width="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtDescripcion" ErrorMessage="*" Text="*" 
                        ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Planilla</td>
                <td colspan="3">
                    <asp:DropDownList ID="cboPlanilla" Width="300px" CssClass="ddl" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Mes</td>
                <td colspan="3">
                    <asp:DropDownList ID="cboMes" Width="300px" CssClass="ddl" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Semana</td>
                <td>
                    <asp:TextBox ID="txtSemana" Width="50px" CssClass="txt" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtSemana" ErrorMessage="*" Text="*" 
                        ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
                </td>
                <td>
                    Nro. Semana</td>
                <td>
                    <asp:TextBox ID="txtNro_Semana" Width="50px" CssClass="txt" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtNro_Semana" ErrorMessage="*" Text="*" 
                        ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Fecha Inicio</td>
                <td>
                    <asp:TextBox ID="txtFecha_Inicio" runat="server" CssClass="txt" Width="60px"></asp:TextBox>
                        <cc1:MaskedEditExtender ID="txtFecha_Inicio_MaskedEditExtender" runat="server" 
                            CultureAMPMPlaceholder="a.m.;p.m." CultureCurrencySymbolPlaceholder="S/" 
                            CultureDateFormat="DMY" CultureDatePlaceholder="/" CultureDecimalPlaceholder="." 
                            CultureName="es-PE" CultureThousandsPlaceholder="," CultureTimePlaceholder="" 
                            Enabled="True" Mask="99/99/9999" MaskType="Date" 
                            TargetControlID="txtFecha_Inicio" UserDateFormat="DayMonthYear">
                        </cc1:MaskedEditExtender>
                        <cc1:CalendarExtender ID="txtFecha_Inicio_CalendarExtender" runat="server" 
                            CssClass="calendar_Theme1" Enabled="True" Format="dd/MM/yyyy" 
                            TargetControlID="txtFecha_Inicio" PopupButtonID="ibtnFec_Inicio">
                        </cc1:CalendarExtender>
                        <asp:ImageButton ID="ibtnFec_Inicio" runat="server" 
                            ToolTip="Click para mostrar el Calendario" 
                            ImageUrl="~/Views/sistemaPlanillas/Imgs/buttons/img_Calendar.png" ImageAlign="TextTop" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                            ControlToValidate="txtFecha_Inicio" ErrorMessage="*" 
                            ValidationGroup="ValidaGrabaCta">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    Fecha Fin</td>
                <td>
                    <asp:TextBox ID="txtFecha_Final" runat="server" CssClass="txt" Width="60px"></asp:TextBox>
                        <cc1:MaskedEditExtender ID="txtFecha_Final_MaskedEditExtender" runat="server" 
                            CultureAMPMPlaceholder="a.m.;p.m." CultureCurrencySymbolPlaceholder="S/" 
                            CultureDateFormat="DMY" CultureDatePlaceholder="/" CultureDecimalPlaceholder="." 
                            CultureName="es-PE" CultureThousandsPlaceholder="," CultureTimePlaceholder="" 
                            Enabled="True" Mask="99/99/9999" MaskType="Date" 
                            TargetControlID="txtFecha_Final" UserDateFormat="DayMonthYear">
                        </cc1:MaskedEditExtender>
                        <cc1:CalendarExtender ID="txtFecha_Final_CalendarExtender" runat="server" 
                            CssClass="calendar_Theme1" Enabled="True" Format="dd/MM/yyyy" 
                            TargetControlID="txtFecha_Final" PopupButtonID="ibtnFec_Final">
                        </cc1:CalendarExtender>
                        <asp:ImageButton ID="ibtnFec_Final" runat="server" 
                            ToolTip="Click para mostrar el Calendario" 
                            ImageUrl="~/Views/sistemaPlanillas/Imgs/buttons/img_Calendar.png" ImageAlign="TextTop" 
                        onclick="ibtnFec_Final_Click" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" 
                            runat="server" ControlToValidate="txtFecha_Final" ErrorMessage="*" 
                            ValidationGroup="ValidaGrabaCta">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Tipo Cambio</td>
                <td colspan="3">
                    <asp:TextBox ID="txtTipo_Cambio" Width="50px" CssClass="txt" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="txtTipo_Cambio" ErrorMessage="*" Text="*" 
                        ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="3">
                    <asp:CheckBox ID="chkLiqBenef" runat="server" Text="Pagar Liquidación de Beneficios Sociales" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btnCrearPeriodos" runat="server" 
                        OnClientClick="return confirm('Acontinuación Se Generaran Todos Los Periodos Correspondientes Al Ejercicio Seleccionado. ¿Esta Seguro De Realizar Esta Acción?');" 
                        Text="Crear Periodos" onclick="btnCrearPeriodos_Click" CssClass="EstiloGeneralBoton" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <asp:Button ID="btnGrabar" runat="server" OnClick="btnGrabar_Click" 
                        Text="Grabar" ValidationGroup="ValidaGraba" CssClass="EstiloGeneralBoton" />
                    &nbsp;
                    <asp:Button ID="btnActualizar" runat="server" OnClick="btnActualizar_Click" 
                        Text="Actualizar" ValidationGroup="ValidaGraba" CssClass="EstiloGeneralBoton" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <hr />
                </td>
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