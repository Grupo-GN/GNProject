<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmImprimirReportes.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.ReportesyConsultas.FrmImprimirReportes" %>

<%@ Register src="../UserControl/ucComboArea.ascx" tagname="ucComboArea" tagprefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />

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
                  vReturnValue = window.open(pagina, "", "toolbar=no,scrollbars=yes, resizable=yes,HEIGHT=647,WIDTH=1057,location=no");
              } else {
                  vReturnValue = window.showModalDialog(pagina, "", "dialogHeight: 647px; dialogWidth: 1057px; edge: Raised; center: yes; help: no; resizable: yes; scroll:off; status: no;titlebar=no;");
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
           border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black; 
            min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; border-top: solid 1px black;">
            
   <br />
  <asp:Label ID="Label9" runat="server" Text="IMPRIMIR REPORTES" CssClass="miTitulo"></asp:Label>
    <br />
    <br />

          <asp:UpdatePanel ID="updPersonalCombo" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
             <table>
                    <tr>
                    <td style="width:110px;">
                        <asp:Label ID="Label1" runat="server" 
                        Text="Filtro por Trabajador" CssClass="miLabel" Width="110px"></asp:Label>
                    </td>
                    <td>
                                <asp:DropDownList ID="cboPersonal" runat="server" CssClass="ddl" Width="250px">
                                </asp:DropDownList>
                    </td>
                    <td>   
                        <asp:Button ID="btnImprimir" runat="server" Text="Ver" CssClass="submit" 
                            onclick="btnImprimir_Click" Visible="False" />    </td>
                      <td>               
                          <asp:Button ID="btnPreview" runat="server" CssClass="submit" 
                            onclick="btnPreview_Click" Text="Preview / Imprimir" /></td>
                </tr>
             </table>               
            <table width="100%">    
                <tr>
                    <td colspan="4" style="font-weight: bold;">
                      <u><asp:Label ID="Label2" runat="server" Text="Listado de Reportes" CssClass="miTituloOnTab"></asp:Label> </u>
                    </td>        
                </tr>
                <tr>
                    <td colspan="4"> 
                        <div style="overflow: auto; width: 100%; height: 430px; 
                            border: solid 1px #000; color:Blue;">
                           <div style="color:Red">
                            <asp:UpdatePanel ID="updTreeView" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                               
                                    <asp:TreeView ID="tvwReportes" runat="server"  ForeColor="#3333FF"
                                        SelectedNodeStyle-ForeColor="Red" 
                                        HoverNodeStyle-BackColor="#CDCDCD"
                                        RootNodeStyle-ForeColor="Black"
                                         Width="100%"
                                        ontreenodedatabound="tvwReportes_TreeNodeDataBound" 
                                        onselectednodechanged="tvwReportes_SelectedNodeChanged">
                                        <ParentNodeStyle Font-Bold="False" />
                                        <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                                        <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" 
                                            HorizontalPadding="0px" VerticalPadding="0px" />
                                        <RootNodeStyle ForeColor="Black" />
                                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" 
                                            HorizontalPadding="0px" NodeSpacing="0px" VerticalPadding="0px" />
                                   
                                   
                                    </asp:TreeView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
            
                </ContentTemplate>
                        </asp:UpdatePanel>

<asp:UpdateProgress ID="UpdateProgress1" runat="server" 
    DisplayAfter="1" AssociatedUpdatePanelID="updPersonalCombo">                                        
    <ProgressTemplate>
        <div class="UpdateProgressModalBackground"></div>
        <center>                                            
            <div class="UpdateProgressPanel">
                Cargando...<br /><br />
            <asp:Image ID="Image2" runat="server" 
            alt="Procesando" ImageUrl="~/css/ajax-loader.gif" /> 
            </div> 
        </center>
    </ProgressTemplate>                                        
</asp:UpdateProgress>

 </fieldset>
    
         </td>
     </tr>
     </table>


</asp:Content>




