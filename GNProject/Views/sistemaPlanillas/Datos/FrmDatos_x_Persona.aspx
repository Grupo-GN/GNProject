<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmDatos_x_Persona.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Datos.FrmDatos_x_Persona" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />
<link href="../jqueriUI/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet" />
<link rel="stylesheet" type="text/css" href="../css/multiple-select.css" />

    <link href="../Styles/nuevoEstiloPlanilla.css" rel="stylesheet" type="text/css" />
     <table align="center" width="100%">
     <tr>
     <td>
        
        <fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px;
           /*border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black;*/ 
            min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; /*border-top: solid 1px black;*/">
    
    <br />
<asp:Label ID="Label1" runat="server" Text="DATOS POR PERSONAL" CssClass="miTitulo" ></asp:Label>
<br />
<table style="width:100%;border-collapse:collapse;">
    <tr>
        <td style="width:70%;">
            <fieldset>
                <legend>Importar Datos</legend>
                <input type="button" id="btnopen" value="Generar Plantilla" class="submit" />&nbsp;&nbsp;&nbsp;        
                <asp:FileUpload ID="FileUpload1" runat="server" accept=".xls"/>
                <asp:Button ID="btnImportar" runat="server" Text="Procesar" ToolTip="Procesar información"    CssClass="submit" OnClick="btnImportar_Click" />
                <asp:Label ID="lblmensajefile" runat="server" CssClass="lblError" Text="-"></asp:Label>
            </fieldset>
        </td>
        <td style="width:30%;">
            &nbsp;
        </td>
    </tr>
</table>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
<table>
    <tr>
    
        <td>
        
    <asp:Panel ID="pnlMostrar" runat="server" GroupingText="Mostrar">
    <table>
        <tr>
            <td>
                <asp:RadioButtonList ID="rbMostrar" CssClass="miLabel" runat="server" 
                    AutoPostBack="True" 
                    onselectedindexchanged="rbMostrar_SelectedIndexChanged" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True">Conceptos</asp:ListItem>
                    <asp:ListItem>Personal</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
    </table>
</asp:Panel>

        </td>
        <td>

<asp:Panel ID="pnlFiltroxConceptos" runat="server" GroupingText="Seleccione Personal">
    <table>
        <tr>
            <td>
                <asp:Label ID="Label8" runat="server" Text="Personal" CssClass="miLabel"></asp:Label></td>
            <td>
                <asp:DropDownList ID="cboPersonal" runat="server" CssClass="ddl" Width="300px" 
                    AutoPostBack="True" 
                    onselectedindexchanged="cboPersonal_SelectedIndexChanged1">
                </asp:DropDownList>
            </td>
            <td>
                <asp:ImageButton ID="btnBuscar" runat="server" Height="18px" ToolTip="Buscar"
                    ImageUrl="~/Views/sistemaPlanillas/Imgs/Buscar.png" Width="34px" onclick="btnBuscar_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label9" runat="server" Text="Proceso" CssClass="miLabel"></asp:Label></td>
            <td>
                <asp:DropDownList ID="cboProcesos" runat="server" CssClass="ddl" Width="150px" 
                    AutoPostBack="True" 
                    onselectedindexchanged="cboProcesos_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:LinkButton ID="elLink" runat="server" ForeColor="Blue" 
                    onclick="elLink_Click">Refrescar Personal</asp:LinkButton>
            </td>
            <td>
            
            </td>
        </tr>
    </table>
</asp:Panel>

<asp:Panel ID="pnlFiltroxPersonal" runat="server" GroupingText="Seleccione Dato Fijo o Variable">
    <table>
        <tr>
            <td>
                <asp:Label ID="Label10" runat="server" CssClass="miLabel" Text="Tipo Dato"></asp:Label></td>
            <td>
                <asp:DropDownList ID="cboTipo_Dato" runat="server" CssClass="ddl" Width="150px" 
                    AutoPostBack="True" 
                    onselectedindexchanged="cboTipo_Dato_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="lblnoProceso" runat="server" Text="Proceso"></asp:Label></td>
            <td>
                <asp:DropDownList ID="cboProcesos_2" runat="server" CssClass="ddl" Width="150px" 
                    AutoPostBack="True" 
                    onselectedindexchanged="cboProcesos_2_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label11" runat="server" Text="Concepto" CssClass="miLabel"></asp:Label></td>
            <td colspan="3">
                <asp:DropDownList ID="cboConceptos" runat="server" CssClass="ddl" Width="355px" 
                    AutoPostBack="True" 
                    onselectedindexchanged="cboConceptos_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>
                <asp:ImageButton ID="btnBuscar_x_Concepto" runat="server" Height="18px" ToolTip="Buscar"
                    ImageUrl="~/Views/sistemaPlanillas/Imgs/Buscar.png" Width="34px" onclick="btnBuscar_x_Concepto_Click" />
            </td>
        </tr>
    </table>
</asp:Panel>

        </td>
        
        <td>
        <asp:Panel ID="pnlMostarConceptos" runat="server" GroupingText="Mostrar Conceptos">
    <table>
        <tr>
            <td>
                <asp:DropDownList ID="cboMostrarConceptos" runat="server" CssClass="ddl" 
                    AutoPostBack="True" 
                    onselectedindexchanged="cboMostrarConceptos_SelectedIndexChanged">
                    <asp:ListItem Value="" Selected="True">--TODOS--</asp:ListItem>
                    <asp:ListItem Value="0">Con Valores</asp:ListItem>
                    <asp:ListItem Value="1">Sin Valores</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
    </table>
</asp:Panel>
</td>

    </tr>
</table>
<%--<table style="width:100%;">
    <tr>
        <td><asp:Button ID="btnGenerarConceptosAll" runat="server" Text="Generar todos los conceptos" ToolTip="Generar datos fijos, variables y directos"    onclick="btnGenerarConceptosAll_Click" CssClass="submit" /></td>
        <td>        

        </td>
        <td>&nbsp;</td>
        
    </tr>
</table>--%>


<cc1:TabContainer ID="TabContainer1" Height="450px" runat="server" 
        ActiveTabIndex="0">
    <cc1:TabPanel ID="TabPanel1" HeaderText="Datos Fijos" runat="server">
        <HeaderTemplate>
            Datos Fijos
        </HeaderTemplate>
        <ContentTemplate>
    <table align="center" width="100%">
<tr>
<td>

        <div class="textoGeneral">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Ingresar Valor" CssClass="miLabel"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtValorReemp_D_Fijos" runat="server" CssClass="txt_align_derecha" Width="70px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" Text="*"
                            ControlToValidate="txtValorReemp_D_Fijos" ValidationGroup="ValidaReemp_D_Fijos"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Button ID="btnReempValor_D_Fijos" runat="server" Text="Reemplazar Todos" ToolTip="Sirve Para Reemplazar los Valores"
                            ValidationGroup="ValidaReemp_D_Fijos" onclick="btnReempValor_D_Fijos_Click"
                            
                            OnClientClick="return confirm('¿Esta Seguro De Reemplazar Todos los Valores de la Lista de Datos Fijos?');" 
                            CssClass="submit" />
                    </td>
                    <td>
                        <asp:ImageButton ID="btnGrabar_D_Fijos" runat="server" Height="25px" ToolTip="Grabar Todo" 
                            ImageUrl="~/Views/sistemaPlanillas/Imgs/btnSave.png" OnClientClick="return confirm('¿Esta Seguro De Grabar Todos los Registros de Datos Fijos?');"
                            Width="25px" onclick="btnGrabar_D_Fijos_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnGenerar_D_Fijos" runat="server" Text="Generar" ToolTip="Sirve Para Generar"
                            onclick="btnGenerar_D_Fijos_Click" CssClass="submit" />
                    </td>
                </tr>
            </table>
        </div>
        
        <div style="overflow: auto; width: 100%;">
            <table class="gridSmallCabecera">
                <tr>
            <th width="30px"><asp:Label ID="Label3" runat="server" Text="NRO" CssClass="tituloGrilla"></asp:Label></th>
            <th width="230px"><asp:Label ID="Label7" runat="server" Text="PERSONAL" CssClass="tituloGrilla"></asp:Label></th>
            <th width="160px"><asp:Label ID="Label24" runat="server" Text="COMENTARIO" CssClass="tituloGrilla"></asp:Label></th>
            <th width="70px"><asp:Label ID="Label4" runat="server" Text="CONCEPTO ID" CssClass="tituloGrilla"></asp:Label></th>
            <th width="348px"><asp:Label ID="Label5" runat="server" Text="CONCEPTO" CssClass="tituloGrilla"></asp:Label></th>
            <th width="107px"><asp:Label ID="Label6" runat="server" Text="VALOR" CssClass="tituloGrilla" ></asp:Label></th>
                </tr>
            </table>
        </div>
        
        <div style="overflow: auto; width: 100%; height: 350px;">
            <asp:GridView ID="grv_D_Fijos" runat="server" 
                ShowHeader="False" Width="100%"
                AutoGenerateColumns="False" CellPadding="2" CssClass="gridSmall" 
                DataKeyNames="Periodo_Id,Personal_Id,Concepto_Id" ForeColor="#333333" 
                GridLines="None" 
                onpageindexchanging="grv_D_Fijos_PageIndexChanging" 
                onrowdatabound="grv_D_Fijos_RowDataBound" PageSize="1000" >
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="Nro">
	                    <ItemTemplate>
        	                    <%# Container.DataItemIndex + 1 %>
	                    </ItemTemplate>
	                    <ItemStyle Width="33px" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="no_Personal" HeaderText="Personal" >
                        <ItemStyle Width="224px" CssClass="FormatFontGridView"/>
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Comentario">
                        <ItemTemplate>
                            <asp:TextBox ID="txtComentarioValor" runat="server" Width="150px" Text='<%# Eval("Comentario_Valor") %>' CssClass="txt">
                            </asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="130px" HorizontalAlign="Center"/>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Concepto_Id" HeaderText="Concepto_Id" >
                        <ItemStyle Width="74px" HorizontalAlign="Center" CssClass="FormatFontGridView"/>
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Concepto">
                        <ItemTemplate>
                            <asp:Label ID="lblno_Concepto" runat="server" ToolTip='<%# Eval("Comentario") %>' Text='<%# Eval("no_Concepto") %>'>
                            </asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="323px" CssClass="FormatFontGridView"/>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valor">
                        <ItemTemplate>
                            <asp:TextBox ID="txtValor" runat="server" Width="90px" Text='<%# String.Format("{0:0.000}",Eval("Valor")) %>' CssClass="txt_align_derecha">
                            </asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="90px" HorizontalAlign="Center"/>
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
           
        <div style="overflow: auto; width: 100%;">
            <table class="gridSmallPiePagina">
                <tr>
                    <th width="108px">
                        <asp:Label ID="lblCantFijos" runat="server" Font-Bold="True" 
                        style="text-align:right; font-weight:bold; font-family: 'Droid Sans', 'Trebuchet MS', Helvetica, Arial, sans-serif; font-size:small;" ></asp:Label>
                    </th>
                    
                    <th width="715px" style="text-align:right; font-weight:bold; font-family: 'Droid Sans', 'Trebuchet MS', Helvetica, Arial, sans-serif; font-size:small;">
                        Total</th>
                    <th width="110px">
                        <asp:Label ID="lblTotFijos" runat="server" CssClass="miLabelSuma" Font-Bold="True"></asp:Label>
                    </th>
                </tr>
            </table>
        </div>
  
  </td>
</tr>
</table>
  
        </ContentTemplate>
    </cc1:TabPanel>
    
    <cc1:TabPanel ID="TabPanel2" HeaderText="Datos Variables" runat="server">
        <ContentTemplate>
    <table align="center" width="100%">
<tr>
<td>

<div class="textoGeneral">
    <table>
        <tr>
            <td><asp:Label ID="Label12" runat="server" Text="Ingresar Valor" CssClass="miLabel"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtValorReemp_D_Variables" runat="server" CssClass="txt_align_derecha" Width="70px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" Text="*"
                    ControlToValidate="txtValorReemp_D_Variables" ValidationGroup="ValidaReemp_D_Variables"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Button ID="btnReempValor_D_Variables" runat="server" Text="Reemplazar Todos" CssClass="submit" ToolTip="Sirve Para Reemplazar los Valores"
                    ValidationGroup="ValidaReemp_D_Variables" onclick="btnReempValor_D_Variables_Click"
                    OnClientClick="return confirm('¿Esta Seguro De Reemplazar Todos los Valores de la Lista de Datos Variables?');" />
            </td>
            <td>
                <asp:ImageButton ID="btnGrabar_D_Variables" runat="server" Height="25px" ToolTip="Grabar Todo" 
                    ImageUrl="~/Views/sistemaPlanillas/Imgs/btnSave.png" OnClientClick="return confirm('¿Esta Seguro De Grabar Todos los Registros de Datos Variables?');"
                    Width="25px" onclick="btnGrabar_D_Variables_Click" />
            </td>
            <td>
                <asp:Button ID="btnGenerar_D_Variables" runat="server" Text="Generar" ToolTip="Sirve Para Generar"
                    onclick="btnGenerar_D_Variables_Click" CssClass="submit" />
            </td>
        </tr>
    </table>
</div>

<div style="overflow: auto; width: 100%;">
    <table class="gridSmallCabecera">
           <tr>
            <th width="30px"><asp:Label ID="Label13" runat="server" Text="NRO" CssClass="tituloGrilla"></asp:Label></th>
            <th width="230px"><asp:Label ID="Label14" runat="server" Text="PERSONAL" CssClass="tituloGrilla"></asp:Label></th>
            <th width="160px"><asp:Label ID="Label15" runat="server" Text="COMENTARIO" CssClass="tituloGrilla"></asp:Label></th>
            <th width="70px"><asp:Label ID="Label25" runat="server" Text="CONCEPTO ID" CssClass="tituloGrilla"></asp:Label></th>
            <th width="348px"><asp:Label ID="Label16" runat="server" Text="CONCEPTO" CssClass="tituloGrilla"></asp:Label></th>
            <th width="107px"><asp:Label ID="Label17" runat="server" Text="VALOR" CssClass="tituloGrilla" ></asp:Label></th>
          </tr>
    </table>
</div>

<div style="overflow: auto; width: 100%; height: 350px;">
    <asp:GridView ID="grv_D_Variables" runat="server" 
        ShowHeader="False" Width="100%"
        AutoGenerateColumns="False" CellPadding="2" CssClass="gridSmall" 
        DataKeyNames="Periodo_Id,Personal_Id,Concepto_Id" ForeColor="#333333" 
        GridLines="None"
        AllowPaging="True" 
        onpageindexchanging="grv_D_Variables_PageIndexChanging" 
        onrowdatabound="grv_D_Variables_RowDataBound" PageSize="1000">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField HeaderText="Nro">
	            <ItemTemplate>
        	            <%# Container.DataItemIndex + 1 %>
	            </ItemTemplate>
	            <ItemStyle Width="33px" HorizontalAlign="Center"/>
            </asp:TemplateField>
            <asp:BoundField DataField="no_Personal" HeaderText="Personal" >
                <ItemStyle Width="224px" CssClass="FormatFontGridView"/>
            </asp:BoundField>
            <asp:TemplateField HeaderText="Comentario">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Width="150px" Text='<%# Eval("Comentario_Valor") %>' CssClass="txt">
                    </asp:TextBox>
                </ItemTemplate>
                <ItemStyle Width="130px" HorizontalAlign="Center"/>
            </asp:TemplateField>
            <asp:BoundField DataField="Concepto_Id" HeaderText="Concepto_Id" 
                ReadOnly="True">
                <ItemStyle Width="74px" HorizontalAlign="Center" CssClass="FormatFontGridView"/>
            </asp:BoundField>
            <asp:TemplateField HeaderText="Concepto">
                <ItemTemplate>
                    <asp:Label ID="Label18" runat="server" ToolTip='<%# Eval("Comentario") %>' Text='<%# Eval("no_Concepto") %>'>
                    </asp:Label>
                </ItemTemplate>
                <ItemStyle Width="323px" CssClass="FormatFontGridView"/>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Valor">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Width="90px" Text='<%# Eval("Valor") %>' CssClass="txt_align_derecha">
                    </asp:TextBox>
                </ItemTemplate>
                <ItemStyle Width="90px" HorizontalAlign="Center" />
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

<div style="overflow: auto; width: 100%;">
    <table class="gridSmallPiePagina">
        <tr>
            <th width="108px">
                <asp:Label ID="lblCantVariables" runat="server" Font-Bold="True"
                
                    style="text-align:right; font-weight:bold; font-family: 'Droid Sans', 'Trebuchet MS', Helvetica, Arial, sans-serif; font-size:small;"></asp:Label>
            </th>
            
            <th width="715px" style="text-align:right; font-weight:bold;font-family: 'Droid Sans', 'Trebuchet MS', Helvetica, Arial, sans-serif; font-size:small;">
                Total</th>
            <th width="110px">
                <asp:Label ID="lblTotVariables" runat="server" Font-Bold="True" 
                    CssClass="miLabelSuma"></asp:Label>
            </th>
        </tr>
    </table>
</div>

   </td>
</tr>
</table>
        </ContentTemplate>
    </cc1:TabPanel>
    
    <cc1:TabPanel ID="TabPanel3" HeaderText="Datos Directos" runat="server">
        <ContentTemplate>

   <table align="center" width="100%">
<tr>
<td>

<div class="textoGeneral">
    <table>
        <tr>
            <td><asp:Label ID="Label19" runat="server" Text="Ingresar Valor" CssClass="miLabel"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtValorReemp_D_Directos" runat="server" CssClass="txt_align_derecha" Width="70px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" Text="*"
                    ControlToValidate="txtValorReemp_D_Directos" ValidationGroup="ValidaReemp_D_Directos"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Button ID="btnReempValor_D_Directos" runat="server" Text="Reemplazar Todos" CssClass="submit" ToolTip="Sirve Para Reemplazar los Valores"
                    ValidationGroup="ValidaReemp_D_Directos" onclick="btnReempValor_D_Directos_Click"
                    OnClientClick="return confirm('¿Esta Seguro De Reemplazar Todos los Valores de la Lista de Datos Directos?');" />
            </td>
            <td>
                <asp:ImageButton ID="btnGrabar_D_Directos" runat="server" Height="25px" ToolTip="Grabar Todo" 
                    ImageUrl="~/Views/sistemaPlanillas/Imgs/btnSave.png" OnClientClick="return confirm('¿Esta Seguro De Grabar Todos los Registros de Datos Directos?');"
                    Width="25px" onclick="btnGrabar_D_Directos_Click" />
            </td>
            <td>
                <asp:Button ID="btnGenerar_D_Directos" runat="server" Text="Generar" CssClass="submit" ToolTip="Sirve Para Generar"
                    onclick="btnGenerar_D_Directos_Click" />
            </td>
        </tr>
    </table>
</div>

           <div style="overflow: auto; width: 100%;">
    <table class="gridSmallCabecera">
        <tr>
             <th width="30px"><asp:Label ID="Label20" runat="server" CssClass="tituloGrilla" Text="NRO"></asp:Label></th>
             <th width="230px"><asp:Label ID="Label21" runat="server" Text="PERSONAL" CssClass="tituloGrilla"></asp:Label></th>
            <th width="160px"><asp:Label ID="Label22" runat="server" Text="COMENTARIO" CssClass="tituloGrilla"></asp:Label></th>
            <th width="70px"><asp:Label ID="Label26" runat="server" Text="CONCEPTO ID" CssClass="tituloGrilla"></asp:Label></th>
             <th width="348px"><asp:Label ID="Label23" runat="server" CssClass="tituloGrilla" Text="CONCEPTO"></asp:Label></th>
             <th width="110px"><asp:Label ID="Label27" runat="server" CssClass="tituloGrilla" Text="VALOR"></asp:Label></th>
        </tr>
    </table>
</div>

           <div style="overflow: auto; width: 100%; height: 350px;">
                <asp:GridView ID="grv_D_Directos" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" CellPadding="2" CssClass="gridSmall" 
                    DataKeyNames="Periodo_Id,Personal_Id,Concepto_Id" ForeColor="#333333" 
                    GridLines="None" OnPageIndexChanging="grv_D_Directos_PageIndexChanging" 
                    Width="100%"
                    OnRowDataBound="grv_D_Directos_RowDataBound" ShowHeader="False" PageSize="1000">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="Nro">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="33px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="no_Personal" HeaderText="Personal">
                            <ItemStyle CssClass="FormatFontGridView" Width="224px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Comentario">
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Width="150px" Text='<%# Eval("Comentario_Valor") %>' CssClass="txt">
                            </asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="130px" HorizontalAlign="Center"/>
                    </asp:TemplateField>
                        <asp:BoundField DataField="Concepto_Id" HeaderText="Concepto_Id" 
                            ReadOnly="True">
                            <ItemStyle CssClass="FormatFontGridView" HorizontalAlign="Center" 
                                Width="74px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Concepto">
                            <ItemTemplate>
                                <asp:Label ID="Label28" runat="server" Text='<%# Eval("no_Concepto") %>' 
                                    ToolTip='<%# Eval("Comentario") %>'>
                    </asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="FormatFontGridView" Width="323px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Valor">
                            <ItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" CssClass="txt_align_derecha" 
                                    Text='<%# Eval("Valor") %>' Width="90px">
                    </asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="90px" />
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
            
            <div style="overflow: auto; width: 100%;">
                <table class="gridSmallPiePagina">
                    <tr>
                        <th colspan="2" width="108px">
                            <asp:Label ID="lblCantDirectos" runat="server" Font-Bold="True" 
                                style="text-align:right; font-weight:bold; font-family: 'Droid Sans', 'Trebuchet MS', Helvetica, Arial, sans-serif; font-size:small;"></asp:Label>
                        </th>
                        <th style="text-align:right; font-weight:bold; font-family: 'Droid Sans', 'Trebuchet MS', Helvetica, Arial, sans-serif; font-size:small;" 
                            width="715px">
                            Total
                        </th>
                        <th width="110px">
                            <asp:Label ID="lblTotDirectos" runat="server" CssClass="miLabelSuma" 
                                Font-Bold="True"></asp:Label>
                        </th>
                    </tr>
                </table>
            </div>

       </td>
</tr>
</table>
     
 
     
        </ContentTemplate>
    </cc1:TabPanel>
</cc1:TabContainer>


    </ContentTemplate>
<%--            <Triggers>
                <asp:PostBackTrigger ControlID = "btnImportar" />
            </Triggers>--%>
</asp:UpdatePanel>
<asp:UpdateProgress ID="UpdateProgress1" runat="server"     AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1">
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

<%--<%# Container.DataItemIndex + 1 %>--%>

    </fieldset>
    
         </td>
     </tr>
     </table>

<div id="panelexcel" title="Generar Plantilla" style="width:700px;">
    <fieldset>
        <legend>Filtrar</legend>
        <table>
            <tr>
                <td style="text-align:right;width:200px;"><label>Planilla : </label></td>
                <td>
                    <select class="miComboBox" id="cboPlanilla" style="width:200px;"></select>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align:right;"><label>Ejercicio : </label></td>
                <td>
                    <select class="miComboBox" id="cboEjercicio" style="width:200px;"></select>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>

            </tr>
            <tr>
                <td style="text-align:right;width:100px;"><label>Periodo : </label></td>
                <td><select class="miComboBox" id="cboPeriodoIni" style="width:200px;"></select></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>

            </tr>
            <tr>
                <td style="text-align:right;"><label>Localidad : </label></td>
                <td><select id="cboArea" class="ddl" style="width:200px;"></select></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align:right;"><label>Proyecto : </label></td>
                <td><select id="cboProyecto" class="ddl" style="width:200px;"></select></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align:right;width:100px;"><label>Área : </label></td>
                <td><select id="cboCatAuxiliar" class="ddl" style="width:200px;"></select></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align:right;">Personal Activo:</td>
                <td colspan="2"><select id="cboPersonalActivo" style="width:300px;"></select></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align:right;">Conceptos Fijos:</td>
                <td colspan="2">
                    <select id="cboConcepto_Fijos" style="width:300px;">
                    </select>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>

            </tr>
            <tr>
                <td style="text-align:right;">Conceptos Variables:</td>
                <td colspan="2">
                    <select id="cboConcepto_Variables" style="width:300px;">
                    </select>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align:right;">Conceptos Directos:</td>
                <td colspan="2">
                    <select id="cboConcepto_Directos" style="width:300px;">
                    </select>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>

            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="8" style="text-align:center;">
                    <input type="button" id="btnGenerarReporteDetallado" class="submit" value="Generar Excel" style="width:200px;" />
                </td>
            </tr>
        </table>
    </fieldset>
</div>

<div id="panelproc" title="Procesar Información Adicional">
    <table>
    </table>
</div>
    <script src="../JQuery/jquery-1.10.1.min.js" type="text/javascript"></script>
    <script src="../jqueriUI/js/jquery-ui-1.10.3.custom.min.js"></script>    
    <script type="text/javascript" src="../JQuery/jquery.multiple.select.js"></script>
<script language="javascript" type="text/javascript">
    $(document).ready(function () {
        $('#panelexcel').dialog({ autoOpen: false, width: 700, height: 580 });

        CargarPlanilla();
        CargarEjercicio();
        ListaProyecto();
        ListaArea();
        ListaCatAuxiliar();
        CargarConceptos("#cboConcepto_Fijos", "01");
        CargarConceptos("#cboConcepto_Variables", "02");
        CargarConceptos("#cboConcepto_Directos", "03");
        

    });
    $('#btnopen').click(function () {
        $('#panelexcel').dialog('open');
    });
        function CargarPlanilla() {
            var pagePath = window.location.pathname;
            var urlajax = pagePath + '/ListaPlanilla';
            $.ajax({
                type: "POST",
                url: urlajax,
                contentType: "application/json; chartseft:utf-8",
                dataType: "json",
                async: true,
                success: function (response) {
                    var Datos = response.d;
                    var lengthD = Datos.length - 1;

                    $('#cboPlanilla').html('');
                    $('<option value="-1">--SELECCIONE--</option>').appendTo('#cboPlanilla');
                    for (var i = 0; i <= lengthD; i++) {
                        var html = '<option value="' + Datos[i].Planilla_Id + '">' + Datos[i].Descripcion + '</option>';
                        $(html).appendTo('#cboPlanilla');
                    }
                },
                error:
                function (XmlHttpError, error, description) {
                    alert(XmlHttpError.responseText);
                }
            });
        }
        function CargarEjercicio() {
            var pagePath = window.location.pathname;
            var urlajax = pagePath + '/ListaEjercicio';
            $.ajax({
                type: "POST",
                url: urlajax,
                contentType: "application/json; chartseft:utf-8",
                dataType: "json",
                async: true,
                success: function (response) {
                    var Datos = response.d;
                    var lengthD = Datos.length - 1;

                    $('#cboEjercicio').html('');
                    $('<option value="-1">--SELECCIONE--</option>').appendTo('#cboEjercicio');
                    for (var i = 0; i <= lengthD; i++) {
                        var html = '<option value="' + Datos[i].Ejercicio_Id + '">' + Datos[i].Descripcion + '</option>';
                        $(html).appendTo('#cboEjercicio');
                    }
                    $("#cboEjercicio").prop('selectedIndex', Datos.length);
                },
                error:
                function (XmlHttpError, error, description) {
                    alert(XmlHttpError.responseText);
                }
            });
        }

        $('#cboPlanilla').change(function (event) {
            var value = $(this).val();
            SISGNRSPeriodoPlanillaSelect();
            SISGNRSGetPersonalActivo();
        });
        $('#cboEjercicio').change(function (event) {
            var value = $(this).val();
            SISGNRSPeriodoPlanillaSelect();
        });
        $('#cboPeriodoIni').change(function (event) {
            SISGNRSGetPersonalActivo();
        });
       

        /*SISGNRSGetPersonalActivo*/
        function SISGNRSPeriodoPlanillaSelect() {
            var EmpresaID = "01", Anio = $('#cboEjercicio').val(), Planilla_Id = $('#cboPlanilla').val();
            params = {
                Compania_Id: EmpresaID,
                Anio: Anio,
                Planilla_Id: Planilla_Id
            };
            var pagePath = window.location.pathname;
            var urlajax = pagePath + '/Get_Periodo_Combo';
            $.ajax({
                type: "POST",
                data: JSON.stringify(params),
                dataType: "json",
                url: urlajax,
                contentType: "application/json; chartseft:utf-8",
                success: function (response) {
                    var datos = response.d;
                    var _len = datos.length - 1;
                    $('#cboPeriodoIni').html('');
                    for (var i = 0; i <= _len; i++) {
                        var html = '<option value="' + datos[i].Periodo_Id + '">' + datos[i].Descripcion + '</option>';
                        $(html).appendTo('#cboPeriodoIni');
                    }
                    var y = document.getElementById('cboPeriodoIni').options;
                    document.getElementById('cboPeriodoIni').selectedIndex = y.length - 1;
                },
                error:
                function (XmlHttpError, error, description) {
                    $("#secError").html(XmlHttpError.responseText);
                },
                async: false
            });
        };

        $('#btnGenerarReporteDetallado').click(function () {
            if ($("#cboProceso").multipleSelect("getSelects") == "") {
                alert("Debe seleccionar un proceso.");
                return;
            }
            if ($("#cboPlanilla").val() == "-1") {
                alert("Debe seleccionar planilla.");
                return;
            }
            if ($("#cboEjercicio").val() == "-1") {
                alert("Debe seleccionar ejercicio.");
                return;
            }
            //20180702
            var ppersonal = $("#cboPersonalActivo").multipleSelect("getSelects");
            var ppersonalcount = $('#cboPersonalActivo option').length;
            var parperso;
            if (ppersonal.length == ppersonalcount) {
                parperso = 'all';
            } else {
                parperso = ppersonal;
            }

            var parametros = $("#cboPeriodoIni").val()
                    + ":" + $("#cboConcepto_Fijos").multipleSelect("getSelects")
                    + ":" + $("#cboConcepto_Variables").multipleSelect("getSelects")
                    + ":" + $("#cboConcepto_Directos").multipleSelect("getSelects")
                    + ":" + $("#cboArea").val()
                    + ":" + $("#cboCatAuxiliar").val()
            //+ ":" + $("#cboPersonalActivo").multipleSelect("getSelects");
                + ":" + $("#cboProyecto").val()
                    + ":" + parperso;
            fc_OpenReport("REP_EXCEL_GEN", parametros, "1");
        });

        function CargarConceptos(combo_Id, Tipo_Concepto_ID) {
            var params = {
                Tipo: Tipo_Concepto_ID
            };
            var pagePath = window.location.pathname;
            $.ajax({
                type: "POST",
                data: JSON.stringify(params),
                url: pagePath+'/ConfigFormulaGetConceptosByTipoList',
                contentType: "application/json; chartseft:utf-8",
                dataType: "json",
                async: true,
                success: function (response) {
                    var datos = response.d;
                    for (var i = 0; i < datos.length; i++) {
                        try {
                            $('<option value="' + datos[i].Concepto_Id + '">' + datos[i].Descripcion + '</option>').appendTo(combo_Id);
                        } catch (ex) { alert(ex + " Tipo: " + combo_Id); }
                    }

                    $(combo_Id).multipleSelect({
                        filter: true
                    });
                },
                error:
                    function (XmlHttpError, error, description) {
                        alert(XmlHttpError.responseText);
                    }
            });
        }

        function ListaArea() {
            var pagePath = window.location.pathname;
            var urlajax = pagePath + '/ListaArea';

            $.ajax({
                type: "POST",
                url: urlajax,
                contentType: "application/json; chartseft:utf-8",
                dataType: "json",
                async: true,
                success: function (response) {
                    var Datos = response.d;
                    var lengthD = Datos.length - 1;

                    $('#cboArea').html('');
                    $('<option value="">--TODOS--</option>').appendTo('#cboArea');
                    for (var i = 0; i <= lengthD; i++) {
                        var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                        $(html).appendTo('#cboArea');
                    }
                },
                error:
                     function (XmlHttpError, error, description) {
                         alert(XmlHttpError.responseText);
                     }
            });
        }

        function ListaCatAuxiliar() {
            var pagePath = window.location.pathname;
            var urlajax = pagePath + '/ListaCatAuxiliar';
            $.ajax({
                type: "POST",
                url: urlajax,
                contentType: "application/json; chartseft:utf-8",
                dataType: "json",
                async: true,
                success: function (response) {
                    var Datos = response.d;
                    var lengthD = Datos.length - 1;

                    $('#cboCatAuxiliar').html('');
                    $('<option value="">--TODOS--</option>').appendTo('#cboCatAuxiliar');
                    for (var i = 0; i <= lengthD; i++) {
                        var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                        $(html).appendTo('#cboCatAuxiliar');
                    }
                },
                error:
                function (XmlHttpError, error, description) {
                    alert(XmlHttpError.responseText);
                }
            });
        }
        function ListaProyecto() {
            var pagePath = window.location.pathname;
            var urlajax = pagePath + '/ListaProyecto';
            $.ajax({
                type: "POST",
                url: urlajax,
                contentType: "application/json; chartseft:utf-8",
                dataType: "json",
                async: true,
                success: function (response) {
                    var Datos = response.d;
                    var lengthD = Datos.length - 1;

                    $('#cboProyecto').html('');
                    $('<option value="all">--TODOS--</option>').appendTo('#cboProyecto');
                    for (var i = 0; i <= lengthD; i++) {
                        var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                        $(html).appendTo('#cboProyecto');
                    }
                },
                error:
                function (XmlHttpError, error, description) {
                    alert(XmlHttpError.responseText);
                }
            });
        }
        function fc_OpenReport(e, t, r) { var o = "750"; "1" == r && (o = "1050"); var a = "../Reportes/FrmPrint.aspx?Reporte_Id=" + e + "&prm=" + t; window.open(a, "_blank", "status=1,toolbar=no,menubar=no,location=no,scrollbars=1,resizable=1,width=" + o + ",height=600") }

        function SISGNRSGetPersonalActivo() {
            var PlanillaId = $('#cboPlanilla').val() == null ? '' : $('#cboPlanilla').val();
            var PeriodoIni = $('#cboPeriodoIni').val() == null ? '' : $('#cboPeriodoIni').val();
            var params = {
                PlanillaId: PlanillaId,
                PeriodoIni: PeriodoIni,
                PeriodoFin: PeriodoIni
            };
            var pagePath = window.location.pathname;
            var urlajax = pagePath + '/ListaPersonalActivoReporteGeneral';
            $.ajax({
                type: "POST",
                data: JSON.stringify(params),
                url: urlajax,
                contentType: "application/json; chartseft:utf-8",
                dataType: "json",
                async: true,
                success: function (response) {
                    var Datos = response.d;
                    var lengthD = Datos.length - 1;

                    $('#cboPersonalActivo').html('');
                    //$('<option value="">-TODOS-</option>').appendTo('#cboPersonalActivo');
                    for (var i = 0; i <= lengthD; i++) {
                        var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                        $(html).appendTo('#cboPersonalActivo');
                    }
                    //$("#cboPersonalActivo").prop('selectedIndex', Datos.length);
                    $('#cboPersonalActivo').multipleSelect({
                        filter: true
                    });
                },
                error:
                function (XmlHttpError, error, description) {
                    alert(XmlHttpError.responseText);
                }
            });
        }
</script>
</asp:Content>


