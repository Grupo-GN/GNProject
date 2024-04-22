<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmReporteIncidencias.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.ReportesyConsultas.FrmReporteIncidencias" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
 
 <script src="../JQuery/jquery-1.8.2.js" type="text/javascript"></script>
    <script src="../JQuery/jquery-1.8.2.min.js" type="text/javascript"></script>
      

<link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />
    <link href="../Controles/miEstilo.css" rel="stylesheet" type="text/css" />   

    <link href="../Styles/nuevoEstiloPlanilla.css" rel="stylesheet" type="text/css" />
<table align="center" width="100%">
     <tr>
     <td>
        
        <fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px;
           /*border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black;*/ 
            min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; /*border-top: solid 1px black;*/">
          <input type="hidden" id="empresaSession" value="<%= Session["EmpresaPlanilla"] %>" />
        <input type="hidden" id="periodoSession" value="<%= Session["PeriodoPlanilla"] %>" />
        <input type="hidden" id="planillaSession" value="<%= Session["planillaPlanilla"] %>" />
        <input type="hidden" id="anioSession" value="<%= Session["anioPlanilla"] %>" />
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <legend CssClass="miTitulo">MANTENIMIENTO DE INCIDENCIAS</legend>
                         <table width="100%">
    <tr>
    <td style="width:50%;" valign="middle">
     <%--<asp:Label ID="Label20" runat="server" 
    Text="MANTENIMIENTO DE INCIDENCIAS" CssClass="miTitulo" Width="300px"></asp:Label>   --%>
    </td>
      <td style="width:50%;" align="right" valign="bottom">
    </td>
   </tr>
    </table>
   <cc1:TabContainer ID="TabIncidencias" runat="server" ActiveTabIndex="0" Height="423px" 
                Width="100%" onprerender="TabIncidencias_PreRender">
     <cc1:TabPanel ID="Tab1" runat="server" HeaderText="Datos Fijos">
            <HeaderTemplate>
                Datos Fijos
            </HeaderTemplate>
           <ContentTemplate>
            <table>
                <tr>
                    <td>
                    <asp:Panel ID="Panel5" runat="server" CssClass="notitulo" GroupingText="Seleccione Personal" Width="415px">
                    <table >                      
                    <tr>
                    <td><h2>Incidencias - Datos Fijos</h2></td> 
                    </tr>  
                    <tr>                        
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" CssClass="miLabel" Text="Personal"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="cboPersonal" runat="server" AutoPostBack="True" 
                                            CssClass="ddl" onselectedindexchanged="cboPersonal_SelectedIndexChanged1" 
                                            Width="300px" onprerender="cboPersonal_PreRender">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="elLink" runat="server" ForeColor="Blue" 
                                            onclick="elLink_Click">Refrescar Personal</asp:LinkButton>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </td> 
                    </tr> 
                </table> 
                    </asp:Panel>
                        <td>
                            <asp:Panel ID="Panel6" runat="server" CssClass="notitulo" GroupingText="Mostrar Personal" 
                                Width="220px">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="cboMostarPersonal_D" runat="server" AutoPostBack="True" 
                                                CssClass="ddl" 
                                                OnSelectedIndexChanged="cboMostarPersonal_D_SelectedIndexChanged">
                                                <asp:ListItem Value="0">--TODOS--</asp:ListItem>
                                                <asp:ListItem Value="1">Con Incidencias</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <td>
                                <asp:Panel ID="Panel7" runat="server" CssClass="notitulo" GroupingText="Exportar" Width="227px">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnExportar1" runat="server" onclick="btnExportar1_Click" CssClass="submit"
                                                    Text="Exportar" />
                                            </td>
                                            </tr>
                                            <tr>
                                           <td>
                                               <asp:Button ID="btnExportarTodo" runat="server" Text="Exportar General-Perido" 
                                                   CssClass="submit EstiloGeneralBoton" onclick="btnExportarTodo_Click" />
                                           </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </td>
                    </td> 


                </tr>                  

            </table>
                
                
                
                <table align="center">
                    <tr>
                    <div>
                    <td>
                                    
                        <div style="overflow: auto; width: 100%;">
                            <table class="gridSmallCabecera">
                                <tr>
                            <th width="130px"><asp:Label ID="Label1" runat="server" Text="Fecha" CssClass="tituloGrilla"></asp:Label></th>
                            <th width="90px"><asp:Label ID="Label3" runat="server" Text="Usuario" CssClass="tituloGrilla"></asp:Label></th>
                            <th width="90px"><asp:Label ID="Label2" runat="server" Text="Proceso" CssClass="tituloGrilla"></asp:Label></th>
                            <th width="180px"><asp:Label ID="Label7" runat="server" Text="Concepto" CssClass="tituloGrilla"></asp:Label></th>
                            <th width="80px"><asp:Label ID="Label4" runat="server" Text="Campo" CssClass="tituloGrilla"></asp:Label></th>
                            <th width="100px"><asp:Label ID="Label5" runat="server" Text="Valor Anterior" CssClass="tituloGrilla"></asp:Label></th>
                            <th width="100px"><asp:Label ID="Label6" runat="server" Text="Valor Actual" CssClass="tituloGrilla" ></asp:Label></th>
                                </tr>
                            </table>
                        </div>
                        
                        <div style="overflow: auto; width: 100%; height: 350px;">                            
                            <asp:GridView ID="grv_In_d_fijos" runat="server" 
                                ShowHeader="False"
                                AutoGenerateColumns="False" CellPadding="2" CssClass="gridSmall" 
                               ForeColor="#333333" GridLines="None" AllowPaging="True" 
                               onselectedindexchanging="grv_Incidencias_d_fijos_SelectedIndexChanging" 
                                onprerender="grv_In_d_fijos_PreRender">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>                    
                                     <asp:BoundField DataField="Fecha" HeaderText="Fecha" >
                                        <ItemStyle Width="150px" HorizontalAlign="Left" CssClass="FormatFontGridView"/>
                                    </asp:BoundField>                    
                                     <asp:BoundField DataField="Usuario" HeaderText="Usuario" >
                                        <ItemStyle Width="95px" HorizontalAlign="Left" CssClass="FormatFontGridView"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Proceso" HeaderText="Proceso" >
                                        <ItemStyle Width="95px" HorizontalAlign="Center" CssClass="FormatFontGridView"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="concepto" HeaderText="Concepto" >
                                        <ItemStyle Width="170px" HorizontalAlign="Left" CssClass="FormatFontGridView"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="campo" HeaderText="Campo" >
                                        <ItemStyle Width="80px" HorizontalAlign="Center" CssClass="FormatFontGridView"/>
                                    </asp:BoundField>
                                    
                                      <asp:BoundField DataField="DatoHistorio" HeaderText="DatoHistorio" >
                                        <ItemStyle Width="104px" HorizontalAlign="Center" CssClass="FormatFontGridView"/>
                                    </asp:BoundField>
                                       
                                     <asp:BoundField DataField="DatoActual" HeaderText="DatoActual" >
                                        <ItemStyle Width="104px" HorizontalAlign="Center" CssClass="FormatFontGridView"/>
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
                    </div>
                    </tr>
                    
            </table>

                   
            </ContentTemplate>

            </cc1:TabPanel>
            <cc1:TabPanel ID="Tab2" runat="server" HeaderText="Personal">
        <ContentTemplate>
              <table>
                <tr>
                    <td>
                       <asp:Panel ID="Panel1" runat="server" GroupingText="Seleccione Personal" Width="415px">
                     <table >
                      
                    <tr>
                    <td><h2>Incidencias - Personal</h2></td> 
                    </tr>  
                    <tr>                   
                                                    
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label9" runat="server" CssClass="miLabel" Text="Personal"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="cboPersonal2" runat="server" AutoPostBack="True" 
                                            CssClass="ddl"  
                                            Width="300px" onselectedindexchanged="cboPersonal2_SelectedIndexChanged" 
                                            onprerender="cboPersonal2_PreRender">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="Blue" 
                                            onclick="elLink_Click">Refrescar Personal</asp:LinkButton>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        

                    </tr> 
                </table> 
                    </asp:Panel>
                        <td>
                            <asp:Panel ID="Panel2" runat="server" GroupingText="Mostrar Personal" 
                                Width="220px">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="cboFiltrarPersonal_P" runat="server" AutoPostBack="True" 
                                                CssClass="ddl" 
                                                OnSelectedIndexChanged="cboFiltrarPersonal_P_SelectedIndexChanged">
                                                <asp:ListItem Value="0">--TODOS--</asp:ListItem>
                                                <asp:ListItem Value="1">Con Incidencias</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <td>
                                <asp:Panel ID="Panel8" runat="server" GroupingText="Exportar" Width="228px">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnexportar2" runat="server" onclick="btnexportar2_Click" 
                                                    Text="Exportar" CssClass="submit" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnExportarTodoPersonal" runat="server" 
                                                    Text="Exportar Todo" CssClass="submit" 
                                                    onclick="btnExportarTodoPersonal_Click"/>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </td>
                    </td>
                </tr>
              </table>
                    
                 <table align="center">
<tr>
<td>

        
        <div style="overflow: auto; width: 100%;">
            <table class="gridSmallCabecera">
                <tr>
            <th width="150px"><asp:Label ID="Label10" runat="server" Text="Fecha" CssClass="tituloGrilla"></asp:Label></th>
            <th width="90px"><asp:Label ID="Label11" runat="server" Text="Usuario" CssClass="tituloGrilla"></asp:Label></th>
            <th width="90px"><asp:Label ID="Label12" runat="server" Text="Proceso" CssClass="tituloGrilla"></asp:Label></th>
            <th width="130px"><asp:Label ID="Label14" runat="server" Text="Campo" CssClass="tituloGrilla"></asp:Label></th>
            <th width="200px"><asp:Label ID="Label15" runat="server" Text="Valor Anterior" CssClass="tituloGrilla"></asp:Label></th>
            <th width="200px"><asp:Label ID="Label16" runat="server" Text="Valor Actual" CssClass="tituloGrilla" ></asp:Label></th>
                </tr>
            </table>
        </div>
        
        <div style="overflow: auto; width: 100%; height: 350px;">
            <asp:GridView ID="grv_Inc_personal" runat="server" 
                ShowHeader="False"
                AutoGenerateColumns="False" CellPadding="2" CssClass="gridSmall" 
               ForeColor="#333333" GridLines="None" AllowPaging="True" 
               onselectedindexchanging="grv_Incidencias_d_fijos_SelectedIndexChanging" 
                onprerender="grv_Inc_personal_PreRender">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>                    
                     <asp:BoundField DataField="Fecha" HeaderText="Fecha" >
                        <ItemStyle Width="150px" HorizontalAlign="Left" CssClass="FormatFontGridView"/>
                    </asp:BoundField>                    
                     <asp:BoundField DataField="Usuario" HeaderText="Usuario" >
                        <ItemStyle Width="95px" HorizontalAlign="Left" CssClass="FormatFontGridView"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="Proceso" HeaderText="Proceso" >
                        <ItemStyle Width="95px" HorizontalAlign="Center" CssClass="FormatFontGridView"/>
                    </asp:BoundField>

                    <asp:BoundField DataField="campo" HeaderText="Campo" >
                        <ItemStyle Width="133px" HorizontalAlign="Left" CssClass="FormatFontGridView"/>
                    </asp:BoundField>
                    
                      <asp:BoundField DataField="DatoHistorio" HeaderText="DatoHistorio" >
                        <ItemStyle Width="205px" HorizontalAlign="Left" CssClass="FormatFontGridView"/>
                    </asp:BoundField>
                       
                     <asp:BoundField DataField="DatoActual" HeaderText="DatoActual" >
                        <ItemStyle Width="205px" HorizontalAlign="Left" CssClass="FormatFontGridView"/>
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
       <cc1:TabPanel ID="Tab3" runat="server" HeaderText="Personal Activo">
                <HeaderTemplate>
                    Personal Activo
                </HeaderTemplate>
              <ContentTemplate>
                <table>
                    <tr>
                        <td>
                       <asp:Panel ID="Panel3" runat="server" GroupingText="Seleccione Personal" Width="415px">
                        <table >
                      
                    <tr>
                    <td class="style1"><h2>Incidencias - Personal Activo</h2></td> 
                    </tr>  
                    <tr>                   
                                                    
                        <td class="style2">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label13" runat="server" CssClass="miLabel" Text="Personal"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="cboPersonal_activo" runat="server" AutoPostBack="True" 
                                            CssClass="ddl"  
                                            Width="300px" 
                                            OnSelectedIndexChanged="cboPersonal_activo_SelectedIndexChanged" 
                                            onprerender="cboPersonal_activo_PreRender" >
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">
                                        
                                    </td>
                                    <td class="style3">
                                        <asp:LinkButton ID="LinkButton2" runat="server" ForeColor="Blue" 
                                            onclick="elLink_Click">Refrescar Personal</asp:LinkButton>
                                    </td>
                                    <td class="style3">
                                    </td>
                                </tr>
                            </table>
                            
                        </td>
                        

                    </tr> 
                     </table> 
                        </asp:Panel>
                        <td>  
                        <asp:Panel ID="Panel4" runat="server" GroupingText="Mostrar Personal" Width="220px">                      
                        <table>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="cboMostrarPersonal" runat="server" AutoPostBack="True" 
                                        CssClass="ddl" 
                                        OnSelectedIndexChanged="cboMostrarPersonal_SelectedIndexChanged">
                                        <asp:ListItem Value="0">--TODOS--</asp:ListItem>
                                        <asp:ListItem Value="1">Con Incidencias</asp:ListItem>                                        
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                        </asp:Panel>
                            <td>
                           <asp:Panel ID="Panel9" runat="server" GroupingText="Exportar" 
                                Width="201px" Height="100px">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnExportar3" runat="server" Text="Exportar" CssClass="submit"
                                                onclick="btnExportar3_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        
                                    <td>
                                    <asp:Button ID="btnExportarTodoActivo" runat="server" Text="Exportar Todo-Periodo" 
                                            CssClass="submit" onclick="btnExportarTodoActivo_Click"/>
                                    </td>
                                    </tr>


                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>                      
                    
            <table align="center">
                        <tr>
                        <td>

        
        <div style="overflow: auto; width: 100%;">
            <table class="gridSmallCabecera">
                <tr>
            <th width="150px"><asp:Label ID="Label17" runat="server" Text="Fecha" CssClass="tituloGrilla"></asp:Label></th>
            <th width="90px"><asp:Label ID="Label18" runat="server" Text="Usuario" CssClass="tituloGrilla"></asp:Label></th>
            <th width="90px"><asp:Label ID="Label19" runat="server" Text="Proceso" CssClass="tituloGrilla"></asp:Label></th>
            <th width="80px"><asp:Label ID="Label24" runat="server" Text="Periodo" CssClass="tituloGrilla"></asp:Label></th>
            <th width="130px"><asp:Label ID="Label21" runat="server" Text="Campo" CssClass="tituloGrilla"></asp:Label></th>
            <th width="200px"><asp:Label ID="Label22" runat="server" Text="Valor Anterior" CssClass="tituloGrilla"></asp:Label></th>
            <th width="200px"><asp:Label ID="Label23" runat="server" Text="Valor Actual" CssClass="tituloGrilla" ></asp:Label></th>
                </tr>
            </table>
        </div>
        
        <div style="overflow: auto; width: 100%; height: 350px;">
            <asp:GridView ID="grvPersonalActivo" runat="server" 
                ShowHeader="False"
                AutoGenerateColumns="False" CellPadding="2" CssClass="gridSmall" 
               ForeColor="#333333" GridLines="None" AllowPaging="True" 
               onselectedindexchanging="grv_Incidencias_d_fijos_SelectedIndexChanging" 
                onprerender="grvPersonalActivo_PreRender">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>                    
                     <asp:BoundField DataField="Fecha" HeaderText="Fecha" >
                        <ItemStyle Width="150px" HorizontalAlign="Left" CssClass="FormatFontGridView"/>
                    </asp:BoundField>                    
                     <asp:BoundField DataField="Usuario" HeaderText="Usuario" >
                        <ItemStyle Width="95px" HorizontalAlign="Left" CssClass="FormatFontGridView"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="Proceso" HeaderText="Proceso" >
                        <ItemStyle Width="95px" HorizontalAlign="Center" CssClass="FormatFontGridView"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="Periodo" HeaderText="Periodo" >
                        <ItemStyle Width="80px" HorizontalAlign="Center" CssClass="FormatFontGridView"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="campo" HeaderText="Campo" >
                        <ItemStyle Width="133px" HorizontalAlign="Left" CssClass="FormatFontGridView"/>
                    </asp:BoundField>
                    
                      <asp:BoundField DataField="DatoHistorio" HeaderText="DatoHistorio" >
                        <ItemStyle Width="205px" HorizontalAlign="Left" CssClass="FormatFontGridView"/>
                    </asp:BoundField>
                       
                     <asp:BoundField DataField="DatoActual" HeaderText="DatoActual" >
                        <ItemStyle Width="205px" HorizontalAlign="Left" CssClass="FormatFontGridView"/>
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
    </cc1:TabContainer>               
  </ContentTemplate>
                    <Triggers>
                  
                    <asp:PostBackTrigger   ControlID="TabIncidencias$Tab1$btnExportar1" />
                    <asp:PostBackTrigger ControlID="TabIncidencias$Tab2$btnexportar2"  />
                    <asp:PostBackTrigger ControlID="TabIncidencias$Tab3$btnExportar3" />
                    <asp:PostBackTrigger   ControlID="TabIncidencias$Tab1$btnExportarTodo" />
                   
                   <asp:PostBackTrigger ControlID="TabIncidencias$Tab2$btnExportarTodoPersonal"  />                     
                   
                   <asp:PostBackTrigger ControlID="TabIncidencias$Tab3$btnExportarTodoActivo" />                </Triggers>
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

<asp:Content ID="Content3" runat="server" contentplaceholderid="head">

    </asp:Content>


