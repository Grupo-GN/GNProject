<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmMntPlantillaSustento.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Mantenimientos.FrmMntPlantillaSustento" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />
    <link href="../Controles/miEstilo.css" rel="stylesheet" type="text/css" />
    <script src="../JQuery/jquery-1.8.2.js" type="text/javascript"></script>
    <script src="../JQuery/jquery-1.8.2.min.js" type="text/javascript"></script>
    
      <script type="text/javascript" >
          function Valida() {
              var Nombre = document.getElementById('<%=txtnombre.ClientID%>');
              if (Nombre.value == "" || Nombre.value == null) {
                  document.getElementById('<%=lblError.ClientID%>').innerHTML = 'Error...Ingrese un nombre para la plantilla';
                  Nombre.focus();
                  return false;
              }
              var ConceptosIN = document.getElementById('<%=lbConceptosIN.ClientID%>');
              if (ConceptosIN.options.length==0 || ConceptosIN.options.length == null) {
                  document.getElementById('<%=lblError.ClientID%>').innerHTML = 'Error...Seleccione los conceptos a mostrar';
                  ConceptosIN.focus();
                  return false;
              }
              var personalIN = document.getElementById('<%=lbpersonalIN.ClientID%>');
              if (personalIN.options.length == 0 || personalIN.options.length == null) {
                  document.getElementById('<%=lblError.ClientID%>').innerHTML = 'Error...Seleccione los campos del personal a mostrar';
                  personalIN.focus();
                  return false;
              }
              if (confirm('¿Desea Grabar?') == false) {
                  return false;
              }
              return true;
          }
//funcion para cambiar de tab
    function activaTab(index) {
        var tabContainer = document.getElementById('<%=TabContainer1.ClientID%>');
        if (tabContainer != undefined && tabContainer != null) {
            tabContainer = tabContainer.control;
            tabContainer.set_activeTabIndex(index);
        }
    }
      </script>   
    <table align="center" width="100%">
        <tr>
            <td>                 
             <fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px;
               border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black; 
                min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; border-top: solid 1px black;">
            
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
            <ContentTemplate>
                   <table width="100%">
                    <tr>
                    <td style="width:50%;" valign="middle">
                     <asp:Label ID="Label20" runat="server" 
                    Text="Mantenimiento de Plantilla para Sustentos" CssClass="miTitulo" Width="300px"></asp:Label>   
                    </td>
                      <td style="width:50%;"  valign="middle" align="right">
                          
                          <asp:Panel ID="Panel1" runat="server" CssClass="elPanel">
                                <table>
                                <tr>
                                <td>
                                    <asp:Button ID="btnNew" runat="server" Text="Nuevo" 
                                    CssClass="elBotonNew" onclick="btnNew_Click" 
                                        ToolTip="Para Agregar un Nuevo Registro"/></td>
                                <td>
                                    <asp:Button ID="btnAdd" runat="server" Text="Grabar" 
                                    CssClass="elBotonAdd" Enabled="false" 
                                    onclick="btnAdd_Click"  ToolTip="Para Grabar un Nuevo Registro"
                                    OnClientClick="return Valida();"/>
                                </td>
                                <td>
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancelar" 
                                    CssClass="elBotonCancel" Enabled="false" onclick="btnCancel_Click" ToolTip="Para Cancelar la Informacion"/></td>
                                <td>
                                    <asp:Button ID="btnUpdate" runat="server" Text="Actualizar" 
                                    CssClass="elBotonUpdate" Enabled="false" onclick="btnUpdate_Click" ToolTip="Para Modificar el Registro"
                                    OnClientClick="return Valida();"/>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnDelete" runat="server" Text="Eliminar" 
                                        CssClass="elBotonDelete" Enabled="false" onclick="btnDelete_Click"/>
                                    </td>
                                </tr>
                                </table>
                            </asp:Panel>
                          </td>
                   </tr>
                   <tr>
                    <td colspan="2" align="right"> 
                        <asp:Label ID="lblError" runat="server" Text="" CssClass="lblError"></asp:Label></td>
                   </tr>
                    </table>
                     <table width="100%">
                     <tr>
                     <td>
                     <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" 
                        Width="100%" Height="415px" ScrollBars="Vertical">
                            
                            <cc1:TabPanel ID="TabPanel6" runat="server" HeaderText="Lista >>"><HeaderTemplate>
                                Lista &gt;&gt;</HeaderTemplate>
                                <ContentTemplate>
                                <div style="overflow: auto; width: 100%; border:solid 0px #000;" id="divScroll" onscroll="Onscrollfunction('DataDiv', 'HeaderDiv');">
                                
                                 
                                
                                <asp:GridView ID="grvPlantillas"  runat="server" AutoGenerateColumns="False" 
                                                    CellPadding="2" CssClass="gridSmall" 
                                    ForeColor="#333333" GridLines="None" PageSize="15" DataKeyNames="PlantillaSU_Id"
                                                            AllowPaging="True"  ><AlternatingRowStyle BackColor="White" ForeColor="#284775" /><Columns><asp:TemplateField><ItemTemplate><asp:ImageButton ID="IbtnSelect" runat="server" ToolTip="Editar" CommandArgument='<%# Eval("PlantillaSU_Id") %>'
                                                                           CommandName='<%# Eval("Nombre") %>' ImageUrl="../Icon/Modify.gif" OnClick="IbtnSelect_Click" /><asp:ImageButton ID="ibtnEliminar" runat="server" ToolTip="Eliminar"
                                                                             CommandArgument='<%# Eval("PlantillaSU_Id") %>'
                                                                                    CommandName="Delete" ImageUrl="../Icon/delete.gif"
                                                                                    
                                                                    OnClientClick="return confirm('¿Esta Seguro De Eliminar?');" 
                                                                    onclick="ibtnEliminar_Click" /></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="55px" /></asp:TemplateField><asp:BoundField DataField="PlantillaSU_Id" HeaderText="ID"><HeaderStyle ForeColor="#336699" Font-Size="X-Small" Font-Names="AENOR Fontana ND"
                                                                        Font-Bold="True" /><ItemStyle Width="55px" HorizontalAlign="Center" CssClass="FormatFontGridView"/></asp:BoundField><asp:BoundField DataField="Nombre" HeaderText="Plantilla"><HeaderStyle ForeColor="#336699" Font-Size="X-Small" Font-Names="AENOR Fontana ND"
                                                                        Font-Bold="True" /><ItemStyle Width="100px" HorizontalAlign="Left" CssClass="FormatFontGridView"/></asp:BoundField><asp:BoundField DataField="CamposPersonal" HeaderText="Campos Mostrar-Personal"><HeaderStyle ForeColor="#336699" Font-Size="X-Small" Font-Names="AENOR Fontana ND"
                                                                        Font-Bold="True" /><ItemStyle HorizontalAlign="Left" Width="350px" CssClass="FormatFontGridView"/></asp:BoundField><asp:BoundField DataField="DetalleConceptos" HeaderText="Campos Conceptos-Mostrar"><HeaderStyle ForeColor="#336699" Font-Size="X-Small" Font-Names="AENOR Fontana ND"
                                                                        Font-Bold="True" /><ItemStyle Width="350px" CssClass="FormatFontGridView"/></asp:BoundField></Columns><EditRowStyle BackColor="#999999" /><FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" /><HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"  /><PagerStyle BackColor="#3A4F63" ForeColor="White" HorizontalAlign="Center" Height="5px" /><RowStyle BackColor="#F7F6F3" ForeColor="#333333" /><SelectedRowStyle BackColor="#9ADBFA" /></asp:GridView></div><asp:HiddenField ID="hdnPlantilla_Id" runat="server" /><asp:HiddenField ID="hdnConceptos" runat="server" /><asp:HiddenField ID="hdnCamposPersonal" runat="server" /><asp:HiddenField ID="hdnProcesos" runat="server" /></ContentTemplate></cc1:TabPanel>
                             <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="Matenimiento"><ContentTemplate><table><tr><td><div id="asociar"><table><tr><td colspan="2"><asp:Label ID="lbltitulo" runat="server" Text="Mantenimiento de Plantilla"
                                   Font-Bold="True" Font-Size="Large" Font-Names="AENOR Fontana ND"></asp:Label></td><tr><td>
                                     Nombre de la Platilla:&nbsp;&nbsp; 
                                   <asp:TextBox ID="txtnombre" runat="server" Height="20px" Width="235px"></asp:TextBox></td>
                                   </tr></tr><tr><td rowspan="3"><div>
                                   <table width="400px">
                                   <tr><td colspan="3" ><div>
                                   <asp:Panel ID="pnlFiltro" runat="server">
                                   <table>
                                   <tr>
                                    <td>Tipo de Dato</td>
                                    <td>
                                        <asp:DropDownList ID="cboTipoDato" runat="server" AutoPostBack="True" CssClass="ddl" Width="200px"
                                            onselectedindexchanged="cboTipoDato_SelectedIndexChanged">
                                            <asp:ListItem Value="05">Canculo</asp:ListItem>
                                            <asp:ListItem Value="01">Dato Fijo</asp:ListItem>
                                            <asp:ListItem Value="02">Dato Variable</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                   </tr>
                                   <tr><td>Distribución</td>
                                   <td><asp:DropDownList ID="cboDistribución" runat="server" CssClass="ddl" Width="200px" AutoPostBack="True" onselectedindexchanged="cboDistribución_SelectedIndexChanged">
                                   <asp:ListItem Value="1">Distribución en Boleta</asp:ListItem>
                                   <asp:ListItem Value="2">Distribución en Cubo</asp:ListItem></asp:DropDownList></td>
                                   </tr>
                                   <tr><td >
                                         Tipo Columna</td><td ><asp:DropDownList ID="cboColumnaBoleta" runat="server" CssClass="ddl" Width="200px" 
                                    AutoPostBack="True" 
                                    onselectedindexchanged="cboColumnaBoleta_SelectedIndexChanged">
                                        </asp:DropDownList></td></tr><tr><td>Proceso</td><td><asp:DropDownList ID="cboProceso" runat="server" CssClass="ddl" Width="200px" AutoPostBack="True" 
                                    onselectedindexchanged="cboProceso_SelectedIndexChanged">
                                        </asp:DropDownList></td></tr></table></asp:Panel></div></td ></tr><tr><td colspan="3">
                                         Asociar Conceptos</td></tr><tr><td align="center" >Conceptos</td><td ><b>&nbsp;</b></td><td align="center">
                                         Mostrar</td></tr><tr><td  >
                                         <asp:ListBox 
                                        ID="lbConceptos" runat="server" Height="188px" Width="250px" 
                                                 AutoPostBack="True" 
                                                 onselectedindexchanged="lbConceptos_SelectedIndexChanged" 
                                                 SelectionMode="Multiple" onprerender="lbConceptos_PreRender"></asp:ListBox></td><td ></td><td><asp:ListBox ID="lbConceptosIN" runat="server" Height="188px" Width="250px" 
                                                        SelectionMode="Multiple" AutoPostBack="True" 
                                                            onselectedindexchanged="lbConceptosIN_SelectedIndexChanged"></asp:ListBox></td></tr></table></td></tr><tr><td></td></tr></table></div></td><td><table width="400px"><tr><td  style="padding: 120px 0px 0px;">
                                 Asociar Datos del Personal</td></tr><tr><td>Campos</td><td></td><td>Mostrar</td></tr><tr><td><asp:ListBox ID="lbPersonal" runat="server" AutoPostBack="True" Height="188px" 
                                                            onselectedindexchanged="lbPersonal_SelectedIndexChanged" Width="170px"></asp:ListBox></td><td><br />
                                     &gt;&gt;</td><td><asp:ListBox ID="lbpersonalIN" runat="server" AutoPostBack="True" 
                                                               Height="188px" onselectedindexchanged="lbpersonalIN_SelectedIndexChanged" 
                                                            SelectionMode="Multiple" Width="170px"></asp:ListBox></td></tr></table></td></tr></table></ContentTemplate></cc1:TabPanel>
                        </cc1:TabContainer>
                     </td>
  
                     </tr>
                    </table>

                   </div>
                    </td>
                   </tr>
                       <tr>
        <td>
            &nbsp;</td>
    </tr>
                     
                    </table>            
            </ContentTemplate>
             <Triggers>
                
             </Triggers>
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


