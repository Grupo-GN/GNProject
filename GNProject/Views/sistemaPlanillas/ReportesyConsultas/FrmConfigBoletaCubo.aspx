<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmConfigBoletaCubo.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.ReportesyConsultas.FrmConfigBoletaCubo" %>

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
<asp:Label ID="Label1" runat="server" Text="  ORDENAMIENTO DE CONCEPTOS" CssClass="miTitulo" ></asp:Label> 


<div>
    <asp:Panel ID="pnlFiltro" runat="server">
        <table>
            <tr>
                <td>
                    Distribución</td>
                <td>
                    <asp:DropDownList ID="cboDistribución" runat="server" CssClass="ddl" Width="200px" 
                        AutoPostBack="True" 
                        onselectedindexchanged="cboDistribución_SelectedIndexChanged">
                        <asp:ListItem Value="1">Distribución en Boleta</asp:ListItem>
                        <asp:ListItem Value="2">Distribución en Cubo</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    Tipo Columna</td>
                <td>
                    <asp:DropDownList ID="cboColumnaBoleta" runat="server" CssClass="ddl" Width="200px" 
                        AutoPostBack="True" 
                        onselectedindexchanged="cboColumnaBoleta_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>                
                </td>
            </tr>
            <tr>
                <td>
                    Proceso</td>
                <td>
                    <asp:DropDownList ID="cboProceso" runat="server" CssClass="ddl" Width="200px" 
                        AutoPostBack="True" 
                        onselectedindexchanged="cboProceso_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:ImageButton ID="btnBuscar" runat="server" Height="18px" ToolTip="Buscar"
                        ImageUrl="~/Views/sistemaPlanillas/Imgs/Buscar.png" Width="34px" onclick="btnBuscar_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</div>

<table>
    <tr>
        <td>
            <asp:ImageButton ID="btnGrabar" runat="server" Height="25px" ToolTip="Grabar Todo" 
                ImageUrl="~/Views/sistemaPlanillas/Imgs/btnSave.png" OnClientClick="return confirm('¿Esta Seguro De Grabar Todos los Registros?');"
                ValidationGroup="ValidaGrabaVac" Width="25px" onclick="btnGrabar_Click" />
        </td>
        <td>
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" 
                onclick="btnAgregar_Click" CssClass="btn" />            
        </td>
        <td>
            <asp:Button ID="btnAtributos" runat="server" Text="Atributos" 
                onclick="btnAtributos_Click" CssClass="btn" />            
        </td>
    </tr>                    
</table>

<div style="overflow: hidden; width: 750px;">
    <table class="gridSmallCabecera">
        <tr>
            <th width="30px"></th>
            <th width="300px">Detalle</th>
            <th width="25px">Nro</th>
            <th width="300px">Descripción</th>
            <th width="50px">Afecto</th> 
            <th width="50px">Afecto a Quinta</th> 
            <th width="50px">Afecto a Essalud</th> 
        </tr>
    </table>
</div>
<asp:UpdatePanel ID="upConceptos" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
<div style="overflow: auto; width: 750px; height: 400px;">
    <asp:GridView ID="grvLista" runat="server" 
        ShowHeader="False"
        AutoGenerateColumns="False" CellPadding="4" CssClass="gridSmall" 
        DataKeyNames="Concepto_Id" ForeColor="#333333" 
        GridLines="None"
        AllowPaging="True" 
        onpageindexchanging="grvLista_PageIndexChanging" 
        onrowdatabound="grvLista_RowDataBound" 
        onrowdeleting="grvLista_RowDeleting">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="ibtnEliminar" runat="server" ToolTip="Quitar"
                        CommandName="Delete" Height="20px" ImageUrl="~/Views/sistemaPlanillas/Imgs/btnDelete.png" Width="20px"
                        OnClientClick="return confirm('¿Esta Seguro De Quitar el Registro?');" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="30px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Detalle">
                <ItemTemplate>
                    <asp:TextBox ID="txtDetalle" runat="server" Width="290px" Text='<%# Eval("Detalle") %>' CssClass="txt">
                    </asp:TextBox>
                </ItemTemplate>
                <ItemStyle Width="300px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nro">
                <ItemTemplate>
                    <asp:TextBox ID="txtBoleta_nro_orden" runat="server" Width="20px" Text='<%# Eval("Boleta_nro_orden") %>' CssClass="txt">
                    </asp:TextBox>
                </ItemTemplate>
                <ItemStyle Width="25px" HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField HeaderText="Descripción" DataField="Descripcion">
                <ItemStyle Width="300px" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Afecto">
                <ItemTemplate>
                    <asp:CheckBox ID="chkafecto" runat="server" Checked='<%# Eval("flagAfecto") %>' />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="50px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Afecto a Quinta">
                <ItemTemplate>
                    <asp:CheckBox ID="chkafectoquinta" runat="server" AutoPostBack="true" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="50px" />
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Afecto a ESSALUD">
                <ItemTemplate>
                    <asp:CheckBox ID="chkafectoessalud" runat="server" AutoPostBack="true" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="50px" />
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#9ADBFA" />
        <EmptyDataTemplate>
            <div style="text-align:center; width:678px;">No se encontraron registros</div>
        </EmptyDataTemplate>
    </asp:GridView>
</div>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="cboDistribución" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="cboColumnaBoleta" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="cboProceso" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnGrabar" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="grvConceptos" EventName="RowCommand" />
    </Triggers>
</asp:UpdatePanel>

<asp:UpdateProgress ID="UpdateProgress1" runat="server" 
    DisplayAfter="1">                                        
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

<asp:HiddenField ID="hdAgregar" runat="server" />

<cc1:ModalPopupExtender ID="mpAgregar" runat="server" TargetControlID="hdAgregar" PopupControlID="PanelModalP"
    BackgroundCssClass="modalBackground" CancelControlID="btnCerrarPopUp" PopupDragHandleControlID="PanelModalP">
</cc1:ModalPopupExtender>

<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>--%>

<asp:Panel ID="PanelModalP" runat="server" CssClass="popupControl" style="text-align: left;">
    <div style="background: #cecece;">
        <table width="100%">
            <tr>
                <td style="text-align: left; font-weight: bold;">
                    Búsqueda
                </td>
                <td style="text-align: right;">
                    <asp:Button ID="btnCerrarPopUp" runat="server" Text="X" CssClass="btn" />
                </td>
            </tr>
        </table>
    </div>
    <div style="padding: 25px;">
        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnFiltro">
            <table>
                <tr>
                    <td>
                        <asp:TextBox ID="txtFiltro_Concepto_Id" runat="server" CssClass="txt" Width="50px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFiltro_Detalle" runat="server" CssClass="txt" Width="150px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:ImageButton ID="btnFiltro" runat="server" Height="18px" ToolTip="Buscar"
                            ImageUrl="~/Views/sistemaPlanillas/Imgs/Buscar.png" Width="34px" onclick="btnFiltro_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <div style="overflow: hidden; width: 763px;">
            <table class="gridSmallCabecera">
                <tr>
                    <th width="50px">Agregar</th>
                    <th width="60px">Concepto_Id</th>
                    <th width="300px">Detalle</th>
                    <th width="300px">Descripción</th>
                </tr>
            </table>
        </div>
        <div style="overflow: auto; width: 763px; height: 400px;">
            <asp:UpdatePanel ID="upAgregar" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
            <table cellpadding="0px" cellspacing="0px"><tr><td>
            <asp:GridView ID="grvConceptos" runat="server"
                AutoGenerateColumns="False" CellPadding="4" CssClass="gridSmall" 
                DataKeyNames="Concepto_Id" ForeColor="#333333" 
                GridLines="None" ShowHeader="false"
                AllowPaging="false" onrowcommand="grvConceptos_RowCommand">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="Agregar">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkAgregar" CommandName="Select" runat="server" ForeColor="Black"
                                OnClientClick="return confirm('¿Esta Seguro De Agregar el Concepto?');" >Agregar</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="50px" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Concepto_Id" DataField="Concepto_Id">
                        <ItemStyle Width="60px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Detalle" DataField="Detalle">
                        <ItemStyle Width="300px" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Descripción" DataField="Descripcion">
                        <ItemStyle Width="300px" HorizontalAlign="Left" />
                    </asp:BoundField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#9ADBFA" />
                <EmptyDataTemplate>
                    <div style="text-align:center; width:733px;">No se encontraron registros</div>
                </EmptyDataTemplate>
            </asp:GridView>
            </td></tr></table>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnAgregar" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnFiltro" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>    
</asp:Panel>

    <%--</ContentTemplate>
</asp:UpdatePanel>--%>

<br />

<asp:HiddenField ID="hdAtributos" runat="server" />

<cc1:ModalPopupExtender ID="mpAtributos" runat="server" TargetControlID="hdAtributos" PopupControlID="pnlAtributos"
    BackgroundCssClass="modalBackground" CancelControlID="btnCerrarAtributosPopUp" PopupDragHandleControlID="pnlAtributos">
</cc1:ModalPopupExtender>

<asp:Panel ID="pnlAtributos" runat="server" CssClass="popupControl" style="text-align: left;">
    <div style="background: #cecece;">
        <table width="100%">
            <tr>
                <td style="text-align: left; font-weight: bold;">
                    Atributos de Concepto
                </td>
                <td style="text-align: right;">
                    <asp:Button ID="btnCerrarAtributosPopUp" runat="server" Text="X" CssClass="btn" />
                </td>
            </tr>
        </table>
    </div>
    <div style="padding: 25px;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            
        <table>
            <tr>
                <td>
                    Compania</td>
                <td>
                    <asp:Label ID="lblCompania" runat="server" />
                </td>
                <td></td>
            </tr>
            <tr>
                <td>
                    Planilla</td>
                <td>
                    <asp:Label ID="lblPlanilla" runat="server" />
                </td>
                <td></td>
            </tr>
            <tr>
                <td>
                    Proceso</td>
                <td>
                    <asp:DropDownList ID="cboProceso_Atributo" runat="server" CssClass="ddl" Width="200px">
                    </asp:DropDownList>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>
                    Atributo</td>
                <td>
                    <asp:DropDownList ID="cboTipoAtributosConcepto" runat="server" CssClass="ddl" Width="200px">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:ImageButton ID="btnMostrarAtributos" runat="server" Height="18px" ToolTip="Mostrar Atributos"
                        ImageUrl="~/Views/sistemaPlanillas/Imgs/Buscar.png" Width="34px" onclick="btnMostrarAtributos_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    Conceptos</td>
                <td>
                    <asp:DropDownList ID="cboConceptos" runat="server" CssClass="ddl">
                    </asp:DropDownList>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>
                    Valor</td>
                <td>
                    <asp:TextBox ID="txtAtributo_Boleta" runat="server" CssClass="txt" Width="70px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAtributo_Boleta" Text="*" ErrorMessage="*" ValidationGroup="validaGrabaAtributo">
                    </asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:ImageButton ID="btnAgregarAtributo" runat="server" Height="18px" ToolTip="Agregar Atributo"
                        ImageUrl="~/Views/sistemaPlanillas/Imgs/add.png" Width="34px" onclick="btnAgregarAtributo_Click" ValidationGroup="validaGrabaAtributo" />
                </td>
            </tr>
        </table>
        
            </ContentTemplate>
        </asp:UpdatePanel>
        
        <table>
            <tr>
                <td>
                    <asp:ImageButton ID="btnGrabarAtributo" runat="server" Height="25px" ToolTip="Grabar Todo" 
                        ImageUrl="~/Views/sistemaPlanillas/Imgs/btnSave.png" OnClientClick="return confirm('¿Esta Seguro De Grabar Todos los Atributos?');"
                        ValidationGroup="ValidaGrabaVac" Width="25px" onclick="btnGrabarAtributo_Click" />
                </td>
            </tr>                    
        </table>
        <div style="overflow: hidden; width: 430px;">
            <table class="gridSmallCabecera">
                <tr>
                    <th width="30px"></th>
                    <th width="300px">Descripción</th>
                    <th width="80px">Atributo Boleta</th>
                </tr>
            </table>
        </div>
        <div style="overflow: auto; width: 430px; height: 250px;">
            <asp:UpdatePanel ID="upAtributos" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="grvAtributos" runat="server"
                        AutoGenerateColumns="False" CellPadding="4" CssClass="gridSmall" 
                        DataKeyNames="Concepto_Id" ForeColor="#333333" 
                        GridLines="None" ShowHeader="false"
                        onrowdeleting="grvAtributos_RowDeleting"
                        AllowPaging="false">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnEliminar" runat="server" ToolTip="Quitar"
                                        CommandName="Delete" Height="20px" ImageUrl="~/Views/sistemaPlanillas/Imgs/btnDelete.png" Width="20px"
                                        OnClientClick="return confirm('¿Esta Seguro De Eliminar el Atributo?');" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="30px" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Descripción" DataField="Descripcion">
                                <ItemStyle Width="300px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Atributo Boleta">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAtributo_Boleta" runat="server" Width="70px" Text='<%# Eval("Atributo_Boleta") %>' CssClass="txt">
                                    </asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="80px" HorizontalAlign="Center" />
                            </asp:TemplateField>                    
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#9ADBFA" />
                        <EmptyDataTemplate>
                            <div style="text-align:center; width:420px;">No se encontraron registros</div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnAtributos" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnMostrarAtributos" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnAgregarAtributo" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnGrabarAtributo" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>    
</asp:Panel>

  </fieldset>
    
         </td>
     </tr>
     </table>

</asp:Content>

