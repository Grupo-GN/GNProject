<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="FrmMntPlan_De_Cuentas.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Mantenimientos.FrmMntPlan_De_Cuentas" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />
<link href="../Controles/miEstilo.css" rel="stylesheet" type="text/css" />

    <link href="../Styles/nuevoEstiloPlanilla.css" rel="stylesheet" type="text/css" />

    <script src="../JQuery/jquery-1.8.2.js" type="text/javascript"></script>
    <script src="../JQuery/jquery-1.8.2.min.js" type="text/javascript"></script>
    
<script type="text/javascript">
    $(document).ready(function() {

        $('#<%= ckAnalitica.ClientID %>').change(function() {
            if ($(this).is(':checked')) {
                $('#<%=ckCentro_Costo.ClientID %>').attr('checked', false);
                $('#<%=ckArea.ClientID %>').attr('checked', false);
                $('#<%=cboCentro_Costo.ClientID %>').val('000');
                $('#<%=cboArea.ClientID %>').val('000');
                $('#<%=cboCentro_Costo.ClientID %>').attr('disabled', true);
                $('#<%=cboArea.ClientID %>').attr('disabled', true);
            }
            return false
        });

        $('#<%= ckCentro_Costo.ClientID %>').change(function() {
            if ($(this).is(':checked')) {
                $('#<%=ckAnalitica.ClientID %>').attr('checked', false);
                $('#<%=ckArea.ClientID %>').attr('checked', false);
                $('#<%=cboArea.ClientID %>').val('000');
                $('#<%=cboCentro_Costo.ClientID %>').attr('disabled', false);
                $('#<%=cboArea.ClientID %>').attr('disabled', true);
            } else {
                $('#<%=cboCentro_Costo.ClientID %>').attr('disabled', true);
            }
            return false
        });

        $('#<%= ckArea.ClientID %>').change(function() {
            if ($(this).is(':checked')) {
                $('#<%=ckCentro_Costo.ClientID %>').attr('checked', false);
                $('#<%=ckAnalitica.ClientID %>').attr('checked', false);
                $('#<%=cboCentro_Costo.ClientID %>').val('000');
                $('#<%=cboArea.ClientID %>').attr('disabled', false);
                $('#<%=cboCentro_Costo.ClientID %>').attr('disabled', true);
            } else {
            $('#<%=cboArea.ClientID %>').attr('disabled', true);
        }
        return false
        });

    });
</script>

     <table align="center" width="100%">
     <tr>
     <td>
        
        <fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px;
           /*border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black;*/ 
            min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; /*border-top: solid 1px black;*/">

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
      <table width="100%">
    <tr>
    <td style="width:50%;" valign="middle">
     <asp:Label ID="Label9" runat="server" 
    Text="MANTENIMIENTO DE PLAN DE CUENTAS" CssClass="miTitulo" Width="300px"></asp:Label>   
    </td>
      <td style="width:50%;" align="right" valign="bottom">
       <asp:Panel ID="Panel1" runat="server" CssClass="elPanel">
    <table>
    <tr>
    <td>
        <asp:Button ID="btnNew" runat="server" Text="Nuevo" 
        CssClass="elBotonNew" Enabled="true" onclick="btnNew_Click"/></td>
    <td>
        <asp:Button ID="btnAdd" runat="server" Text="Grabar" 
        CssClass="elBotonAdd" Enabled="false" 
       onclick="btnAdd_Click"/>
    </td>
    <td>
        <asp:Button ID="btnCancel" runat="server" Text="Cancelar" 
        CssClass="elBotonCancel" Enabled="false" onclick="btnCancel_Click"/></td>
    <td>
        <asp:Button ID="btnUpdate" runat="server" Text="Actualizar" 
        CssClass="elBotonUpdate" Enabled="false"
         onclick="btnUpdate_Click"/>
        </td>
        <td>
            <asp:Button ID="btnDelete" runat="server" Text="Eliminar" 
            CssClass="elBotonDelete" Enabled="false"/>
        </td>
    </tr>
    </table>
</asp:Panel>
    </td>
   </tr>
    </table>
<cc1:TabContainer ID="TabContainer1" Height="460px" runat="server" 
        ActiveTabIndex="0">
    <cc1:TabPanel ID="TabPanel1" HeaderText="Lista" runat="server">
        <ContentTemplate>

<div class="textoGeneral">
        <table>
        <tr>
            <td>
                <asp:Label ID="Label16" runat="server" Text="Digite Parte de la Descripcion : " 
                Width="150px" CssClass="miLabel"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtFindDescrip" runat="server" CssClass="miTextBox"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnFind" runat="server" Text="Buscar" CssClass="submit"
                ToolTip="Digite la Descripcion y de Click en Buscar" onclick="btnFind_Click"/>
            </td>
    </tr>
        </table>
</div>
    
        <div style="overflow: auto; width: 100%; height: 422px; border:solid 0px;">
            <asp:GridView ID="grvPlan_De_Cuentas" runat="server" Width="100%"
                AutoGenerateColumns="False" CellPadding="2" CssClass="gridSmall" 
                DataKeyNames="Compania_Id,Ejercicio_Id,Cuenta" ForeColor="#333333" 
                GridLines="None"
                onrowcommand="grvPlan_De_Cuentas_RowCommand"
                onrowdeleting="grvPlan_De_Cuentas_RowDeleting" 
                AllowPaging="True" PageSize="18"
                onpageindexchanging="grvPlan_De_Cuentas_PageIndexChanging" 
                onrowdatabound="grvPlan_De_Cuentas_RowDataBound">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="ibtnSelect" runat="server" ToolTip="Seleccionar"
                                CommandName="Select"  ImageUrl="../Icon/Modify.gif"/>
                            <asp:ImageButton ID="ibtnEliminar" runat="server" ToolTip="Eliminar"
                                CommandName="Delete"  ImageUrl="../Icon/delete.gif" 
                                OnClientClick="return confirm('¿Esta Seguro De Eliminar?');" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Compania_Id" HeaderText="COMPANIA" ReadOnly="True">
                        <ItemStyle Width="50px" HorizontalAlign="Center"  CssClass="FormatFontGridView" />
                        <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                         Font-Bold="True" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Ejercicio_Id" HeaderText="EJERCICIO">
                    <ItemStyle CssClass="FormatFontGridView"  HorizontalAlign="Center" />
                         <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                         Font-Bold="True" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Cuenta" HeaderText="CUENTA">
                    <ItemStyle CssClass="FormatFontGridView"/>
                         <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                         Font-Bold="True" />
                    </asp:BoundField>    
                    <asp:BoundField DataField="Descripcion" HeaderText="DESCRIPCION">
                    <ItemStyle CssClass="FormatFontGridView"/>
                         <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                         Font-Bold="True" />
                    </asp:BoundField>
                    <asp:BoundField DataField="lPartida_Presupuestaria" HeaderText="lPART. PRESUPUESTARIA">
                    <ItemStyle CssClass="FormatFontGridView"  HorizontalAlign="Center"/>
                         <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                         Font-Bold="True" />
                    </asp:BoundField>
                    <asp:BoundField DataField="lCentro_De_Costo" HeaderText="lCENTRO DE COSTOS">
                    <ItemStyle CssClass="FormatFontGridView"  HorizontalAlign="Center"/>
                         <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                         Font-Bold="True" />
                    </asp:BoundField>
                    <asp:BoundField DataField="lAnalitica" HeaderText="lANALITICA">
                    <ItemStyle CssClass="FormatFontGridView"  HorizontalAlign="Center"/>
                         <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                         Font-Bold="True" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Anexo" HeaderText="Anexo" Visible ="False" >
                    </asp:BoundField>
                    <asp:BoundField DataField="SubAnexo" HeaderText="SubAnexo" Visible ="False">
                    </asp:BoundField>
                    <asp:BoundField DataField="CCosto_Id" HeaderText="CCosto_Id" Visible ="False">
                    </asp:BoundField>
                    <asp:BoundField DataField="Area_Id" HeaderText="Area_Id" Visible ="False">
                    </asp:BoundField>
                    <asp:BoundField DataField="Tipo_Trabajador_Id" HeaderText="Tipo_Trabajador_Id" 
                        Visible ="False">
                    </asp:BoundField>
                    <asp:BoundField DataField="lArea" HeaderText="lAREA">
                    <ItemStyle CssClass="FormatFontGridView"  HorizontalAlign="Center"/>
                         <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                         Font-Bold="True" />
                    </asp:BoundField>
                    <asp:BoundField DataField="lTipo_Trabajador" HeaderText="lTIPO_TRABAJADOR">
                    <ItemStyle CssClass="FormatFontGridView"  HorizontalAlign="Center"/>
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

        </ContentTemplate>    
    </cc1:TabPanel>
    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Datos Principales" Enabled="false">
        <ContentTemplate>
    
<div class="textoGeneral">

<fieldset style="border-style: outset; border-width: thin;">
<legend>
                                                 <asp:Label ID="Label3" runat="server" 
                                                 Text="Datos Principales" CssClass="miTituloOnTab"></asp:Label>
</legend>

 <table width="500px">
        <tr>
            <td>
                Compania</td>
            <td>
                <asp:DropDownList ID="cboCompania" runat="server" Width="300px" CssClass="ddl"></asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Ejercicio</td>
            <td>
                <asp:DropDownList ID="cboEjercicio" runat="server" Width="300px" CssClass="ddl"></asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Cuenta</td>
            <td>
                <asp:Label ID="lblCuenta" runat="server" Width="50px" Height="18px" CssClass="lblCod"></asp:Label>
                <asp:TextBox ID="txtCuenta" runat="server" CssClass="txt" 
                    Width="50px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtCuenta" ErrorMessage="*" Text="*" 
                    ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Descripción</td>
            <td>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="txt" 
                    Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtDescripcion" ErrorMessage="*" Text="*" 
                    ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Tipo Agrupación Asiento Cta.</td>
            <td>
                <asp:DropDownList ID="cboTipoAgrupacionAsientoCta" runat="server" Width="300px" CssClass="ddl"></asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>

</fieldset>

   
    
<fieldset style="border-style: outset; border-width: thin;">
<legend>
                                                 <asp:Label ID="Label1" runat="server" 
                                                 Text="Agrupados" CssClass="miTituloOnTab"></asp:Label>
</legend>

        <table width="500px">
                <tr>
            <td colspan="1">
            <fieldset>
            <legend>
                             <asp:Label ID="Label4" runat="server" 
                                                 Text="Analitica" CssClass="miTituloOnTab"></asp:Label>
            </legend>
           <asp:CheckBox ID="ckAnalitica" runat="server" Text="Analítica" CssClass="ck"></asp:CheckBox>
            </fieldset>

            </td>
            <td>
                &nbsp;</td>
        </tr>
                <tr>
                <td>
                
           <fieldset>
            <legend>
                             <asp:Label ID="Label5" runat="server" 
                                                 Text="Centro de Costos" CssClass="miTituloOnTab"></asp:Label>
            </legend>
                
                <table>
                <tr>
            <td colspan="2">
                 <asp:CheckBox ID="ckCentro_Costo" runat="server" Text="Centro de Costo" CssClass="ck"></asp:CheckBox>
            </td>
             </tr>
            <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="C.C. Asociado" Width="100px"></asp:Label> 
                </td>
            <td>
                <asp:DropDownList ID="cboCentro_Costo" runat="server" Width="300px" 
                CssClass="ddl" Enabled ="false"></asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
            <td colspan="2">
                <asp:CheckBox ID="ckPartida_Presupuestaria" runat="server" Text="Partida Presupuestaria" 
                CssClass="ck" Width="170px"></asp:CheckBox>
            </td>
            </tr>
            </table>
            
            </fieldset>
            
            </td>
            </tr>
            <tr>
            <td>
                       <fieldset>
            <legend>
                             <asp:Label ID="Label6" runat="server" 
                                                 Text="Localidad" CssClass="miTituloOnTab"></asp:Label>
            </legend>
         <table>
            <tr>
                <td colspan="2">
                    <asp:CheckBox ID="ckArea" runat="server" Text="Área" CssClass="ck"></asp:CheckBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td>
                    Localidad</td>
                <td>                    
                    <asp:DropDownList ID="cboArea" runat="server" CssClass="ddl" Width="300px"
                    Enabled="false"></asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            </table>
            </fieldset>
               </td>
            </tr>
            
            <tr>
            <td>
            
            <table>
            <tr>
                       
                <td colspan="2">
                    <asp:CheckBox ID="ckTipo_Trabajador" runat="server" Text="Tipo Trabajador" CssClass="ck"></asp:CheckBox>
                </td>
            </tr>
            <tr>
                <td>
                    Tipo Trabajador</td>
                <td >
                    <asp:DropDownList ID="cboTipo_Trabajador" runat="server" CssClass="ddl" Width="300px">
                    </asp:DropDownList>
                </td>
            </tr>
            </table>
            
                 </td>
                        </tr>      
        </table>

</fieldset>

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
