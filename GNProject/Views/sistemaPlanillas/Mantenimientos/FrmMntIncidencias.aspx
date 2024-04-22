<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmMntIncidencias.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Mantenimientos.FrmMntIncidencias" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
 <script src="../JQuery/jquery-1.8.2.js" type="text/javascript"></script>
    <script src="../JQuery/jquery-1.8.2.min.js" type="text/javascript"></script>
      
<script type="text/javascript">


    function mensaje(msg) {        
        document.getElementById('<%=lblNombrePersonal.ClientID %>').innerHTML=msg;
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
            <asp:Label ID="lblNombrePersonal" runat="server"></asp:Label>
            
                         <table width="100%">
    <tr>
    <td style="width:50%;" valign="middle">
     <asp:Label ID="Label20" runat="server" 
    Text="MANTENIMIENTO DE INCIDENCIAS" CssClass="miTitulo" Width="300px"></asp:Label>   
    </td>
      <td style="width:50%;" align="right" valign="bottom">
       <asp:Panel ID="Panel1" runat="server" CssClass="elPanel">

</asp:Panel>
    </td>
   </tr>
    </table>
   <cc1:TabContainer ID="TabIncidencias" runat="server" ActiveTabIndex="0" Height="423px" 
                Width="750px">
     <cc1:TabPanel ID="Tab1" runat="server" HeaderText="Datos Fijos">
            <HeaderTemplate>
                Datos Fijos
            </HeaderTemplate>
            <ContentTemplate>
              <table>
                  <tr>
                    <td>
                        <asp:Button ID="btnNew" runat="server" Text="Nuevo" 
                        CssClass="elBotonNew" onclick="btnNew_Click" 
                            ToolTip="Para Agregar un Nuevo Registro"/>
                   </td>
                    <td>
                        <asp:Button ID="btnAdd" runat="server" Text="Grabar" 
                        CssClass="elBotonAdd" Enabled="False" onclick="btnAdd_Click"  
                            ToolTip="Para Grabar un Nuevo Registro"/>
                    </td>
                    <td>
                        <asp:Button ID="btnCancel" runat="server" Text="Cancelar" 
                        CssClass="elBotonCancel" Enabled="False" onclick="btnCancel_Click" 
                            ToolTip="Para Cancelar la Informacion"/></td>
                    <td>
                    <asp:Button ID="btnUpdate" runat="server" Text="Actualizar" 
                    CssClass="elBotonUpdate" Enabled="False" onclick="btnUpdate_Click" 
                        ToolTip="Para Modificar el Registro"/>
                    </td>
                    <td>
                        <asp:Button ID="btnDelete" runat="server" Text="Eliminar" 
                        CssClass="elBotonDelete" Enabled="False" onclick="btnDelete_Click"/>
                    </td>
                </tr>
            </table>
                <table >
                      
                    <tr>
                    <td><h2>Incidencias - Datos Fijos</h2></td> 
                    </tr>  
                    <tr>
                    <td>
                        <p>Seleccione los campos que se van a controlar</p>
                    </td>
                    </tr> 
                     <tr>                    
                        <td align="left" colspan="3">
                            <asp:CheckBoxList ID="chbCampos" runat="server">
                            </asp:CheckBoxList>
                         </td>
                         <td></td>
                         <td></td>
                    </tr>
                </table> 
                   

                   
            </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="Tab2" runat="server" HeaderText="Personal">
            <ContentTemplate>
               <table>
                  <tr>
                    <td>
                        <asp:Button ID="btnNew2" runat="server" Text="Nuevo" 
                        CssClass="elBotonNew" 
                            ToolTip="Para Agregar un Nuevo Registro" onclick="btnNew2_Click"/>
                   </td>
                    <td>
                        <asp:Button ID="btnAdd2" runat="server" Text="Grabar" 
                        CssClass="elBotonAdd" Enabled="False" 
                            ToolTip="Para Grabar un Nuevo Registro" onclick="btnAdd2_Click"/>
                    </td>
                    <td>
                        <asp:Button ID="btnCancelar2" runat="server" Text="Cancelar" 
                        CssClass="elBotonCancel" Enabled="False"  
                            ToolTip="Para Cancelar la Informacion" onclick="btnCancelar2_Click"/></td>
                    <td>
                    <asp:Button ID="btnUdt2" runat="server" Text="Actualizar" 
                    CssClass="elBotonUpdate" Enabled="False" 
                        ToolTip="Para Modificar el Registro" onclick="btnUdt2_Click"/>
                    </td>
                    <td>
                        <asp:Button ID="btnDel2" runat="server" Text="Eliminar" 
                        CssClass="elBotonDelete" Enabled="False" onclick="btnDel2_Click" />
                    </td>
                </tr>
            </table>
                <table >
   
                    <tr>
                    <td><h2>Incidencias - Personal</h2></td> 
                    </tr>  
                    <tr>
                    <td>
                        <p>Seleccione los campos que se van a controlar</p>
                    </td>
                    </tr> 
                     <tr>                    
                        <td align="left" colspan="3">
                        <div style="width: 100%; border: solid 1px black; overflow: auto; height: 296px;">
                          <asp:CheckBoxList ID="chbcamposPersonal" runat="server" RepeatLayout="Flow">
                            </asp:CheckBoxList>
                        </div>
                          
                         </td>

                    </tr>
                </table>  
            </ContentTemplate>
            </cc1:TabPanel>
       <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="Personal Activo">
                <ContentTemplate>
                 <table>
                  <tr>
                    <td>
                        <asp:Button ID="btnNew3" runat="server" Text="Nuevo" 
                        CssClass="elBotonNew" 
                            ToolTip="Para Agregar un Nuevo Registro" onclick="btnNew3_Click" />
                   </td>
                    <td>
                        <asp:Button ID="btnAdd3" runat="server" Text="Grabar" 
                        CssClass="elBotonAdd" Enabled="False" 
                            ToolTip="Para Grabar un Nuevo Registro" onclick="btnAdd3_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnCancel3" runat="server" Text="Cancelar" 
                        CssClass="elBotonCancel" Enabled="False"  
                            ToolTip="Para Cancelar la Informacion" onclick="btnCancel3_Click" />
                     </td>
                    <td>
                    <asp:Button ID="btnUpd3" runat="server" Text="Actualizar" 
                    CssClass="elBotonUpdate" Enabled="False" 
                        ToolTip="Para Modificar el Registro" onclick="btnUpd3_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnDelete3" runat="server" Text="Eliminar" 
                        CssClass="elBotonDelete" Enabled="False" />
                    </td>
                </tr>
            </table>
            
                <table >
   
                    <tr>
                    <td><h2>Incidencias - Personal Activo</h2></td> 
                    </tr>  
                    <tr>
                    <td>
                        <p>Seleccione los campos que se van a controlar</p>
                    </td>
                    </tr> 
                     <tr>                    
                        <td align="left">
                        <div style="width: 100%; border: solid 1px black; overflow: auto; height: 296px;">
                          <asp:CheckBoxList ID="chbPersonalActivo" runat="server" RepeatLayout="Flow">
                            </asp:CheckBoxList>
                        </div>
                          
                         </td>

                    </tr>
                </table>  
                </ContentTemplate>
       </cc1:TabPanel>
    </cc1:TabContainer>                        
  </ContentTemplate>
    </asp:UpdatePanel>
    
<%--    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
        DisplayAfter="1">
        <ProgressTemplate>
            <div class="UpdateProgressModalBackground">
            </div>
            <center>
                <div class="UpdateProgressPanel">
                    Cargando...<br />
                    <br />
                    <asp:Image ID="Image2" runat="server" alt="Procesando" ImageUrl="~/css/ajax-loader.gif" />
                </div>  
            </center>
        </ProgressTemplate>
    </asp:UpdateProgress>--%>
    
            </fieldset>
    
         </td>
     </tr>
     </table>
</asp:Content>

