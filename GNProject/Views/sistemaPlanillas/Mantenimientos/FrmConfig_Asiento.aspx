<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmConfig_Asiento.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Mantenimientos.FrmConfig_Asiento" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

 <script type="text/javascript">
          function AbrirModal(pagina) {
              var navegador = '';
              if (navigator.userAgent.indexOf('MSIE') != -1) {
                  navegador = 'MSIE';
              } else if (navigator.userAgent.indexOf('Firefox') != -1) {
                  navegador = 'Firefox';
              } else if (navigator.userAgent.indexOf('Chrome') != -1) {
                  navegador = 'Chrome';
              } else if (navigator.userAgent.indexOf('Opera') != -1) {
                  navegador = 'Opera';
              } else {
                  navegador = 'undefined';
              }
              var vReturnValue;

              if (navegador == 'Chrome' || navegador == 'Opera') {
                  vReturnValue = window.open(pagina, "", "toolbar=no,scrollbars=yes, resizable=yes,HEIGHT=395,WIDTH=465,location=no");
              } else {
                  vReturnValue = window.showModalDialog(pagina, "", "dialogHeight: 395px; dialogWidth: 465px; edge: Raised; center: yes; help: no; resizable: yes; scroll:off; status: no;titlebar=no;");
              }
              if (vReturnValue != null && vReturnValue == true) {
                  __doPostBack('', '');
                  return vReturnValue
              }
              else {
                  return false
              }
          }
 </script>  


 
<link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />
<link href="../Controles/miEstilo.css" rel="stylesheet" type="text/css" />


        <table align="center" width="100%">
     <tr>
     <td>
      
             <fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px;
           border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black; 
            min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; border-top: solid 1px black;">

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
      <table width="100%">
    <tr>
    <td style="width:50%;" valign="middle">
     <asp:Label ID="Label9" runat="server" 
    Text="CONFIGURADOR DE ASIENTOS" CssClass="miTitulo" Width="300px"></asp:Label>   
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
        CssClass="elBotonAdd" Enabled="false" onclick="btnAdd_Click" />
    </td>
    <td>
        <asp:Button ID="btnCancel" runat="server" Text="Cancelar" 
        CssClass="elBotonCancel" Enabled="false" onclick="btnCancel_Click"/></td>
    <td>
        <asp:Button ID="btnUpdate" runat="server" Text="Actualizar" 
        CssClass="elBotonUpdate" Enabled="false" onclick="btnUpdate_Click"/>
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

<cc1:TabContainer ID="TabContainer1" Height="360px" runat="server" 
        ActiveTabIndex="0">
    <cc1:TabPanel ID="TabPanel1" HeaderText="Asientos" runat="server">
        <ContentTemplate>

<div class="textoGeneral">
            <table>
        <tr>
            <td>
                <asp:Label ID="Label16" runat="server" Text="Digite Parte de la Descripcion : " 
                Width="150px" CssClass="miLabel"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtAsientoBuscar" runat="server" CssClass="miTextBox"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnFind" runat="server" Text="Buscar" CssClass="submit"
                ToolTip="Digite la Descripcion y de Click en Buscar" onclick="btnFind_Click"/>
            </td>
            <td>
             
                <asp:LinkButton ID="lkRefresacar" runat="server" ForeColor="Blue" 
                    onclick="lkRefresacar_Click">Refrescar Grilla</asp:LinkButton>
             
            </td>
    </tr>
        </table>
</div>
    
        <div style="overflow: auto; width: 100%; height: 270px; border:solid 0px;">
            <asp:GridView ID="grvAsiento" runat="server" Width="100%"
                AutoGenerateColumns="False" CellPadding="2" CssClass="gridSmall" 
                DataKeyNames="Asiento_Id,Descripcion,Libro,Glosa,Planilla_Id,Estado_Id"
                ForeColor="#333333" 
                GridLines="None"
                onrowcommand="grvAsiento_RowCommand"
                onrowdeleting="grvAsiento_RowDeleting" AllowPaging="True"
                onpageindexchanging="grvAsiento_PageIndexChanging" 
                onrowdatabound="grvAsiento_RowDataBound">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="ibtnSelect" runat="server" ToolTip="Seleccionar"
                                CommandName="Select" ImageUrl="../Icon/Modify.gif" />
                            <asp:ImageButton ID="ibtnEliminar" runat="server" ToolTip="Eliminar"
                                CommandName="Delete" ImageUrl="../Icon/delete.gif" 
                                OnClientClick="return confirm('Se Eliminará el Asiento y sus Concepto - Cuentas Relacionadas. ¿Esta Seguro De Eliminar?');" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Asiento_Id" HeaderText="ASIENTO_ID" ReadOnly="True">
                        <ItemStyle Width="50px" HorizontalAlign="Center" CssClass="FormatFontGridView" />
                                      <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                         Font-Bold="True" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Compania_Id" HeaderText="COMPANIA_ID">
                    <ItemStyle  HorizontalAlign="Center" CssClass="FormatFontGridView" />
                                  <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                         Font-Bold="True" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Ejercicio_Id" HeaderText="EJERCICIO">
                             <ItemStyle  HorizontalAlign="Center" CssClass="FormatFontGridView" />
                                           <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                         Font-Bold="True" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Planilla_Id" HeaderText="PLANILLA_ID">
                             <ItemStyle  HorizontalAlign="Center" CssClass="FormatFontGridView" />
                                           <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                         Font-Bold="True" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Descripcion" HeaderText="DESCRIPCION">
                             <ItemStyle  CssClass="FormatFontGridView" />
                                           <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                         Font-Bold="True" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Glosa" HeaderText="GLOSA">
                    <ItemStyle   CssClass="FormatFontGridView" />
                                  <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                         Font-Bold="True" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Libro" HeaderText="LIBRO">
                     <ItemStyle CssClass="FormatFontGridView" />
                                   <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                         Font-Bold="True" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Estado_Id" HeaderText="ESTADO">
                  <ItemStyle  HorizontalAlign="Center" CssClass="FormatFontGridView" />
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
    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Detalle de Asientos" Enabled="false">
        <ContentTemplate>
    
  <div class="textoGeneral">
  <fieldset>
  <legend>
      <asp:Label ID="Label2" runat="server" Text="Detalle de Asientos" 
          CssClass="miTituloOnTab"></asp:Label>
  </legend>
      <table width="500px">
        <tr>
            <td>
                Asiento_Id</td>
            <td>
                <asp:Label ID="lblAsiento_Id" runat="server" Width="50px" Height="18px" CssClass="lblCod"></asp:Label>
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtDescripcion" ErrorMessage="*" Text="*" 
                    ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Libro</td>
            <td>
                <asp:TextBox ID="txtLibro" runat="server" CssClass="txt" 
                    Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtLibro" ErrorMessage="*" Text="*" 
                    ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Glosa</td>
            <td>
                <asp:TextBox ID="txtGlosa" runat="server" CssClass="txt" 
                    Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtGlosa" ErrorMessage="*" Text="*" 
                    ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Planilla</td>
            <td>
                <asp:DropDownList ID="cboPlanilla" runat="server" CssClass="ddl" Width="300px">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Estado</td>
            <td>
                <asp:DropDownList ID="cboEstado" runat="server" CssClass="ddl" Width="300px">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
  </fieldset>
</div>
                  
        </ContentTemplate>    
    </cc1:TabPanel>
</cc1:TabContainer>


<asp:Panel ID="pnlDetalle" runat="server" Visible="false">
 <fieldset style="border-style: outset; border-width: thin; height:500px;">
<legend>
                                                 <asp:Label ID="Label3" runat="server" 
                                                 Text="Detalle de Concepto - Cuentas" CssClass="miTituloOnTab"></asp:Label>
</legend>
                
                  
        <div class="textoGeneral">
               <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Digite Parte de la Glosa : " 
                Width="150px" CssClass="miTituloOnTab"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtAsientoCuentasBuscar" runat="server" CssClass="miTextBox"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnFindAsientoCuenta" runat="server" Text="Buscar" CssClass="submit"
                ToolTip="Digite la Descripcion y de Click en Buscar" 
                    onclick="btnFindAsientoCuenta_Click" />
            </td>
            <td>
                <asp:Button ID="btnNewCC" runat="server" Text="Nuevo" CssClass ="submit" 
                    onclick="btnNewCC_Click" />
            </td>
    </tr>
        </table>
        </div>
        
        <div style="overflow: auto; width: 100%; height: 450px; border:solid 0px;">
            <asp:GridView ID="grvAsiento_Cuentas" runat="server" Width="100%"
                AutoGenerateColumns="False" CellPadding="2" CssClass="gridSmall" 
                DataKeyNames="Asiento_Cuenta_Id,Proceso_Id,Cubo_Columna,Concepto_Id,
                Glosa,Cuenta_Id,Cuenta_Tipo,lCentro_De_Costo,lAnalitica,lPartida_Presupuestaria"
                ForeColor="#333333" 
                GridLines="None"
                onrowcommand="grvAsiento_Cuentas_RowCommand"
                onrowdeleting="grvAsiento_Cuentas_RowDeleting" AllowPaging="True"
                onpageindexchanging="grvAsiento_Cuentas_PageIndexChanging" 
                onrowdatabound="grvAsiento_Cuentas_RowDataBound" 
                onprerender="grvAsiento_Cuentas_PreRender">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="ibtnSelect" runat="server" ToolTip="Seleccionar"
                                CommandName="Select" ImageUrl="../Icon/forward.gif"  />
                            <asp:ImageButton ID="ibtnEliminar" runat="server" ToolTip="Eliminar"
                                CommandName="Delete"  ImageUrl="../Icon/delete.gif"  
                                OnClientClick="return confirm('¿Esta Seguro De Eliminar?');" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Asiento_Cuenta_Id" HeaderText="CUENTA_ID" 
                        ReadOnly="True">
                        <ItemStyle Width="0%" HorizontalAlign="Center" 
                        CssClass="FormatFontGridView"/>
                       <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                         Font-Bold="True" />
                    </asp:BoundField>
                    <asp:BoundField DataField="no_Tipo_Cuenta" HeaderText="D-H">
                    <ItemStyle CssClass="FormatFontGridView" HorizontalAlign="Center" Width="5%"/>
                       <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                         Font-Bold="True" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Concepto_Id" HeaderText="CONCEPTO_ID">
                    <ItemStyle CssClass="FormatFontGridView" HorizontalAlign="Center" Width="7%"/>
                        <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                         Font-Bold="True" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Detalle" HeaderText="DETALLE">
                    <ItemStyle CssClass="FormatFontGridView"  Width="15%"/>
                      <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                         Font-Bold="True" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Descripcion" HeaderText="DESCRIPCION">
                    <ItemStyle CssClass="FormatFontGridView" Width="20%"/>
                      <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                         Font-Bold="True" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Cuenta_Id" HeaderText="CUENTA">
                    <ItemStyle HorizontalAlign="Center" CssClass="FormatFontGridView" Width="6%"/>
                      <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                         Font-Bold="True" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Glosa" HeaderText="GLOSA">
                    <ItemStyle CssClass="FormatFontGridView" Width="20%"/>
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
            
<%-- <div class="textoGeneral">
    <asp:Panel ID="pnlConcepto" runat="server" GroupingText="Concepto">
        <table>
            <tr>
                <td width="150px">
                    Asiento_Cuenta_Id</td>
                <td>
                    <asp:Label ID="lblAsiento_Cuenta_Id" runat="server" Width="50px" Height="18px" CssClass="lblCod"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Proceso</td>
                <td>
                    <asp:DropDownList ID="cboProceso" runat="server" CssClass="ddl" Width="300px" 
                        AutoPostBack="True" onselectedindexchanged="cboProceso_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Columna Boleta</td>
                <td>
                    <asp:DropDownList ID="cboColumna_Boleta" runat="server" CssClass="ddl" 
                        Width="300px" AutoPostBack="True" 
                        onselectedindexchanged="cboColumna_Boleta_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Concepto</td>
                <td>
                    <asp:DropDownList ID="cboConcepto" runat="server" CssClass="ddl" Width="500px">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="cboConcepto" ErrorMessage="*" Text="*" 
                        ValidationGroup="ValidaGrabaDet"></asp:RequiredFieldValidator>                    
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Glosa</td>
                <td>
                    <asp:TextBox ID="txtGlosa_Concepto" runat="server" CssClass="txt" 
                        Width="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="txtGlosa_Concepto" ErrorMessage="*" Text="*" 
                        ValidationGroup="ValidaGrabaDet"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
    
    <asp:Panel ID="pnlCuenta" runat="server" GroupingText="Cuenta">
        <table>
            <tr>
                <td width="150px">
                    Cuenta</td>
                <td>
                    <asp:DropDownList ID="cboCuenta" runat="server" CssClass="ddl" Width="300px" 
                        AutoPostBack="True" onselectedindexchanged="cboCuenta_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="cboCuenta" ErrorMessage="*" Text="*" 
                        ValidationGroup="ValidaGrabaDet"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Tipo Cuenta</td>
                <td>
                    <asp:DropDownList ID="cboTipo_Cuenta" runat="server" CssClass="ddl" Width="300px">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="ckPorCentro_Costo" runat="server" Text="Por Centro Costo" 
                        Enabled="False" CssClass="ck"></asp:CheckBox>
                </td>
                <td>
                    <asp:CheckBox ID="ckPorAnalitica" runat="server" Text="Por Analítica" 
                        Enabled="False" CssClass="ck"></asp:CheckBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="ckPorPartida_Presupuestaria" runat="server" 
                        Text="Por Partida Presupuestaria" Enabled="False" CssClass="ck"></asp:CheckBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
</div>    --%>
              
</fieldset></asp:Panel>

<table>
    <tr>
        <td>
            &nbsp;</td>
        <td align="center">
            &nbsp;
        </td>
        <td>
            &nbsp;</td>
    </tr>
</table>

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

