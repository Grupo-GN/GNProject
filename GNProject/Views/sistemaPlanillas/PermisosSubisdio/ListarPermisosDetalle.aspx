<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ListarPermisosDetalle.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.PermisosSubisdio.ListarPermisosDetalle" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <script src="../JQuery/jquery-1.8.2.js" type="text/javascript"></script>
    <script src="../JQuery/jquery-1.8.2.min.js" type="text/javascript"></script>

    <style type="text/css">
        .centrado
        {
            text-align: center;
            font-family: AENOR Fontana ND;
            font-size: small;
            font-weight: bold;
        }
    </style>

    <script type="text/javascript" language="javascript">
          function AbrirModal(pagina) {
              var vReturnValue;
              vReturnValue = window.showModalDialog(pagina, "", "dialogHeight: 422px; dialogWidth: 726px; edge: Raised; center: yes; help: no; resizable: yes; scroll:off; status: no;titlebar=no;");
              if (vReturnValue != null && vReturnValue == true) {
                  __doPostBack('', '');
                  return vReturnValue
              }
              else {
                  return false
              }
          }
          function activaTab(index) {
              var tabContainer = document.getElementById('<%=TabContainer1.ClientID%>');
              if (tabContainer != undefined && tabContainer != null) {
                  tabContainer = tabContainer.control;
                  tabContainer.set_activeTabIndex(index);
              }
          }
          function msgError(msg) {
              $('#<%=lblError.ClientID %>').html(msg);
          }

          function validaCajs() {
              var personal = $('#<%=cboPersonal.ClientID %>');
              var permiso = $('#<%=cboPermiso.ClientID %>');
              var nDocumento = $('#<%=txtNroDocumento.ClientID %>');
              if (personal.val() == "000") {
                  msgError("ERROR... Debe Seleccionar un Personal");
                  personal.focus();
                  return false
              }
              if (permiso.val() == "000") {
                  msgError("ERROR... Debe Seleccionar un Permiso");
                  permiso.focus();
                  return false
              }
              if (nDocumento.val() == "") {
                  msgError("ERROR... Debe Digitar el Nro Documento del Permiso");
                  nDocumento.focus();
                  return false
              }

              if (confirm("Desea Grabar los Datos ??? ") == true) {
                  return true
              } else {
                  return false
              }
              
          }
        

               
    </script>

    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />
    <link href="../Controles/miEstilo.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/nuevoEstiloPlanilla.css" rel="stylesheet" type="text/css" />
    
         <table align="center" width="100%">
     <tr>
     <td>
        
        <fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px;
           /*border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black; */
            min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; /*border-top: solid 1px black;*/">
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td style="width: 50%;" valign="middle">
                        <asp:Label ID="Label9" runat="server" Text="REGISTRO DE INCIDENCIA AL DIA DE HOY"
                            CssClass="miTitulo" Width="300px"></asp:Label>
                    </td>
                    <td style="width: 50%;" align="right" valign="bottom">
                        <asp:Panel ID="Panel1" runat="server" CssClass="elPanel">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnNew" runat="server" Text="Nuevo" CssClass="elBotonNew" Enabled="true"
                                            OnClick="btnNew_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnAdd" runat="server" Text="Grabar" CssClass="elBotonAdd" Enabled="false"
                                            OnClick="btnAdd_Click" OnClientClick="return validaCajs();" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancelar" CssClass="elBotonCancel"
                                            Enabled="false" OnClick="btnCancel_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnUpdate" runat="server" Text="Actualizar" CssClass="elBotonUpdate"
                                            Enabled="false" OnClick="btnUpdate_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnDelete" runat="server" Text="Eliminar" CssClass="elBotonDelete"
                                            Enabled="false" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                Height="380px" AutoPostBack="True">
                    <cc1:TabPanel runat="server" ID="TabPanel1" HeaderText="Listar">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="btnFindPermisos" runat="server" Text="Buscar Historial Por Persona"
                                        CssClass="submit" OnClick="btnFindPermisos_Click" />
                                </td>
                            </tr>
                        </table>
                        <table width="100%">
                            <tr>
                                <td>
                                    <div style="overflow: auto; width: 100%; height: 320px; border: solid 0px;">
                                        <asp:GridView ID="grvPermisosDetalle" runat="server" Width="100%" AutoGenerateColumns="False"
                                            CellPadding="2" CssClass="gridSmall" DataKeyNames="PDetalle_Id" ForeColor="#333333"
                                            GridLines="None" AllowPaging="True" OnRowCommand="grvPermisosDetalle_RowCommand"
                                            OnRowDataBound="grvPermisosDetalle_RowDataBound" 
                                            OnRowDeleting="grvPermisosDetalle_RowDeleting" 
                                            onprerender="grvPermisosDetalle_PreRender">
                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ibtnSelect" runat="server" ToolTip="Seleccionar" CommandName="Select"
                                                            ImageUrl="../Icon/Modify.gif" /><asp:ImageButton ID="ibtnEliminar" runat="server"
                                                                ToolTip="Eliminar" CommandName="Delete" ImageUrl="../Icon/delete.gif" OnClientClick="return confirm('¿Esta Seguro De Eliminar el Permiso?');" /></ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="40px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="PDetalle_Id" HeaderText="PDetalle_Id" ReadOnly="True"
                                                    Visible="False">
                                                    <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                        Font-Bold="True" />
                                                    <ItemStyle Width="50px" HorizontalAlign="Center" CssClass="FormatFontGridView" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Nombres" HeaderText="Nombres">
                                                    <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                        Font-Bold="True" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="FormatFontGridView" Width="200px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="FechaInicio" HeaderText="FECHAINICIO">
                                                    <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                        Font-Bold="True" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="FormatFontGridView" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="FechaFin" HeaderText="FECHAFIN">
                                                    <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                        Font-Bold="True" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="FormatFontGridView" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="TipoPermiso" HeaderText="TIPOPERMISO">
                                                    <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                        Font-Bold="True" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="FormatFontGridView" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Nro_Documento" HeaderText="NRO. DOCUMENTO">
                                                    <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                        Font-Bold="True" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="FormatFontGridView" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DiasDiferencia" HeaderText="DIASDIFERENCIA">
                                                    <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                        Font-Bold="True" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="FormatFontGridView" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="SaldoActual" HeaderText="SALDOACTUAL">
                                                    <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                        Font-Bold="True" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="FormatFontGridView" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="SaldoAnterior" HeaderText="SALDOANTERIOR">
                                                    <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                        Font-Bold="True" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="FormatFontGridView" />
                                                </asp:BoundField>
                                                
                                                 <asp:BoundField DataField="SaldoAnterior" HeaderText="SALDOANTERIOR">
                                                    <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                        Font-Bold="True" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="FormatFontGridView" />
                                                </asp:BoundField>
                                                
                                                   <asp:BoundField DataField="Periodo" HeaderText="PERIODO">
                                                    <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                        Font-Bold="True" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="FormatFontGridView" />
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
                    </ContentTemplate>
                </cc1:TabPanel>
               
                
                 <cc1:TabPanel HeaderText="Registro de Incidencias" runat="server" ID="TabPanel2">
                    <HeaderTemplate>
                        Registro de Incidencias
                    </HeaderTemplate>
                    <ContentTemplate>
                        <fieldset>
                            <legend>
                                <asp:Label ID="Label7" runat="server" Text="DATOS PRINCIPALES" CssClass="miTituloOnTab"></asp:Label></legend>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text="ID : " CssClass="miLabel" Enabled="False"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtId" runat="server" CssClass="centrado" Width="50px" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="Personal : " CssClass="miLabel"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="cboPersonal" runat="server" CssClass="ddl" Width="300px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Fecha Inicio : " CssClass="miLabel" Width="100px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFecha_Inicio" runat="server" CssClass="txt" Width="60px"></asp:TextBox><cc1:MaskedEditExtender
                                            ID="txtFecha_Inicio_MaskedEditExtender" runat="server" CultureAMPMPlaceholder="a.m.;p.m."
                                            CultureCurrencySymbolPlaceholder="S/." CultureDateFormat="DMY" CultureDatePlaceholder="/"
                                            CultureDecimalPlaceholder="." CultureName="es-PE" CultureThousandsPlaceholder=","
                                            CultureTimePlaceholder="" Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFecha_Inicio"
                                            UserDateFormat="DayMonthYear">
                                        </cc1:MaskedEditExtender>
                                        <cc1:CalendarExtender ID="txtFecha_Inicio_CalendarExtender" runat="server" CssClass="calendar_Theme1"
                                            Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFecha_Inicio" PopupButtonID="ibtnFec_Inicio">
                                        </cc1:CalendarExtender>
                                        <asp:ImageButton ID="ibtnFec_Inicio" runat="server" ToolTip="Click para mostrar el Calendario"
                                            ImageUrl="~/Views/sistemaPlanillas/Imgs/buttons/img_Calendar.png" ImageAlign="TextTop" 
                                            onclick="ibtnFec_Inicio_Click" /><asp:RequiredFieldValidator
                                                ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFecha_Inicio"
                                                ErrorMessage="*" ValidationGroup="ValidaGrabaCta">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="Fecha Final : " CssClass="miLabel"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFecha_Final" runat="server" CssClass="txt" Width="60px"></asp:TextBox><cc1:MaskedEditExtender
                                            ID="txtFecha_Final_MaskedEditExtender" runat="server" CultureAMPMPlaceholder="a.m.;p.m."
                                            CultureCurrencySymbolPlaceholder="S/." CultureDateFormat="DMY" CultureDatePlaceholder="/"
                                            CultureDecimalPlaceholder="." CultureName="es-PE" CultureThousandsPlaceholder=","
                                            CultureTimePlaceholder="" Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFecha_Final"
                                            UserDateFormat="DayMonthYear">
                                        </cc1:MaskedEditExtender>
                                        <cc1:CalendarExtender ID="txtFecha_Final_CalendarExtender" runat="server" CssClass="calendar_Theme1"
                                            Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFecha_Final" PopupButtonID="ibtnFec_Final">
                                        </cc1:CalendarExtender>
                                        <asp:ImageButton ID="ibtnFec_Final" runat="server" ToolTip="Click para mostrar el Calendario"
                                            ImageUrl="~/Views/sistemaPlanillas/Imgs/buttons/img_Calendar.png" ImageAlign="TextTop" /><asp:RequiredFieldValidator
                                                ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtFecha_Final"
                                                ErrorMessage="*" ValidationGroup="ValidaGrabaCta">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text="Tipo de Permiso : " CssClass="miLabel"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="cboPermiso" runat="server" CssClass="ddl" 
                                            Width="200px" AutoPostBack="True" 
                                            onselectedindexchanged="cboPermiso_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="Nro Documento : " CssClass="miLabel"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNroDocumento" runat="server" CssClass="miComboBox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" Text="Dias Diferencia : " CssClass="miLabel"
                                            Enabled="False"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtdiasDiferencia" runat="server" CssClass="centrado" Width="50px"
                                            Enabled="False" AutoPostBack="True" 
                                            ontextchanged="txtdiasDiferencia_TextChanged">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label10" runat="server" Text="Saldo Actual : " CssClass="miLabel"
                                            Enabled="False"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtsaldoActual" runat="server" CssClass="centrado" Width="50px"
                                            Enabled="False">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label11" runat="server" Text="Saldo Anterior : " CssClass="miLabel"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtsaldoAnterior" runat="server" CssClass="centrado" Width="50px"
                                            Text="0" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lblError" runat="server" Text="[lblError]" ForeColor="Maroon" Font-Bold="True"
                                             Font-Size="X-Small"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </ContentTemplate>
                </cc1:TabPanel>
                
                
            
                
            </cc1:TabContainer>
            <p>
            </p>
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
