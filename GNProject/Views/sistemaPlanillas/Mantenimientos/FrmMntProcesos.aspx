<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="FrmMntProcesos.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Mantenimientos.FrmMntProcesos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />
    <link href="../Controles/miEstilo.css" rel="stylesheet" type="text/css" />

    <link href="../Styles/nuevoEstiloPlanilla.css" rel="stylesheet" type="text/css" />

 <script type="text/javascript" language="javascript">
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
                  vReturnValue = window.open(pagina, "", "toolbar=no,scrollbars=yes, resizable=yes,HEIGHT=147,WIDTH=331,location=no");
              } else {
                  vReturnValue = window.showModalDialog(pagina, "", "dialogHeight: 155px; dialogWidth: 340px; edge: Raised; center: yes; help: no; resizable: yes; scroll:off; status: no;titlebar=no;");
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
     <asp:Label ID="Label1" runat="server" 
    Text="MANTENIMIENTO DE PROCESOS" CssClass="miTitulo" Width="100%"></asp:Label>   
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
        CssClass="elBotonAdd" Enabled="false" />
    </td>
    <td>
        <asp:Button ID="btnCancel" runat="server" Text="Cancelar" 
        CssClass="elBotonCancel" Enabled="false"/></td>
    <td>
        <asp:Button ID="btnUpdate" runat="server" Text="Actualizar" 
        CssClass="elBotonUpdate" Enabled="false"/>
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

 <fieldset style=" background-color:White; /*border-style: outset;*/ border-width: thin; 
     border-radius:8px 8px 8px 8px; min-height:310px; height:auto;">
<p>
</p>

            <table width="100%">
        <tr>
            <td>
            
<div class="textoGeneral">

        <table>
            <tr>
            <td>
                <asp:Label ID="Label16" runat="server" Text="Digite Parte del Proceso : " 
                Width="150px" CssClass="miLabel"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtProcesoNuevo" runat="server" Width="280px" CssClass="txt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtProcesoNuevo" 
                        runat="server" ErrorMessage="*" Text="*" ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Button ID="btnListar" runat="server" Text="Buscar" 
                    onclick="btnListar_Click" CssClass="submit EstiloGeneralBoton" />
                </td>
            </tr>
        </table>

 <div style="overflow: auto; width: 100%; height: 320px; border:solid 0px;">
    <asp:GridView ID="grvProcesos" runat="server" Width="100%"
        AutoGenerateColumns="False" CellPadding="2" CssClass="gridSmall" 
        DataKeyNames="Proceso_Id, Estado_Id" ForeColor="#333333" 
        GridLines="None"
        onrowcommand="grvProcesos_RowCommand"
        onrowdatabound="grvProcesos_RowDataBound" 
        onrowdeleting="grvProcesos_RowDeleting" 
        onrowupdating="grvProcesos_RowUpdating" ShowFooter="true" AllowPaging="True" 
        onpageindexchanging="grvProcesos_PageIndexChanging" 
         onrowediting="grvProcesos_RowEditing" onprerender="grvProcesos_PreRender">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="ibtnSelect" runat="server" ToolTip="Editar"
                        CommandName="Edit"  ImageUrl="../Icon/Modify.gif"  />
                    <asp:ImageButton ID="ibtnEliminar" runat="server" ToolTip="Eliminar"
                        CommandName="Delete"  ImageUrl="../Icon/delete.gif" 
                        OnClientClick="return confirm('¿Esta Seguro De Eliminar?');" />
                </ItemTemplate>
           <%--     <EditItemTemplate>
                    <asp:ImageButton ID="ibtnActualizar" runat="server" ToolTip="Actualizar"
                        CommandName="Update" Height="20px" ImageUrl="~/Views/sistemaPlanillas/Imgs/btnSave.png" 
                        Width="20px" ValidationGroup="Valida" />
                    <asp:ImageButton ID="ibtnCancelar" runat="server" CommandName="Cancel" ToolTip="Cancelar"
                        Height="20px" ImageUrl="~/Views/sistemaPlanillas/Imgs/back.png" Width="20px" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:ImageButton ID="ibtnNuevo" runat="server" CommandName="Insert" ToolTip="Nuevo Grabar"
                        Height="20px" ImageUrl="~/Views/sistemaPlanillas/Imgs/btnNew.png" Width="20px" ValidationGroup="ValidaNew"/>
                </FooterTemplate>--%>
                <ItemStyle HorizontalAlign="Center" Width="40px" />
            </asp:TemplateField>
            <asp:BoundField DataField="Proceso_Id" HeaderText="PROCESO_ID" ReadOnly="true">
                                      <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                         Font-Bold="True" />
                <ItemStyle Width="50px" HorizontalAlign="Center"  CssClass="FormatFontGridView"/>
            </asp:BoundField>
               <asp:BoundField DataField="Proceso" HeaderText="PROCESO" ReadOnly="true">
                <ItemStyle Width="550px" CssClass="FormatFontGridView"/>
                                          <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                         Font-Bold="True" />
            </asp:BoundField>
                   <asp:BoundField DataField="Estado_id" HeaderText="ESTADO_ID" ReadOnly="true">
                                             <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                         Font-Bold="True" />
                <ItemStyle Width="70px" HorizontalAlign="Center" />
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
</div>

</td>
</tr>
</table>

</fieldset>

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
