<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmGenerarSustentoPlanilla.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.ReportesyConsultas.FrmGenerarSustentoPlanilla" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
  
    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />
    <link href="../Controles/miEstilo.css" rel="stylesheet" type="text/css" />
    <script src="../JQuery/jquery-1.8.2.js" type="text/javascript"></script>
    <script src="../JQuery/jquery-1.8.2.min.js" type="text/javascript"></script>

    <link href="../Styles/nuevoEstiloPlanilla.css" rel="stylesheet" type="text/css" />

 <script type="text/javascript" language="javascript">
     function AbrirModal(pagina) {
         var vReturnValue;
         vReturnValue = window.showModalDialog(pagina, "", "dialogHeight: 380px; dialogWidth: 380px; edge: Raised; center: yes; help: no; resizable: yes; scroll:off; status: no;titlebar=no;");
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
            
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
            <ContentTemplate>

                   <table>
                   <tr>
                    <td>
                                      <table width="100%">
                    <tr>
                    <td style="width:50%;" valign="middle">
                     <asp:Label ID="Label20" runat="server" 
                    Text="Sustento de Planilla del Mes" CssClass="miTitulo" Width="300px"></asp:Label>   
                    </td>

                   </tr>
                    </table>
                    </td>
                   </tr>
                   <tr>
                    <td>
                                         <table width="100%">
                     <tr>
                     <td>Seleccione los Sustentos a Exportar</td>
                     <td align="right"><asp:Label ID="lblerror" runat="server" CssClass="lblError"></asp:Label>
                     <asp:Button ID="btnExportar" runat="server" Text="Generar" CssClass="submit" 
                              onclick="btnExportar_Click" />
                         
                      </td>   
                     </tr>  
                    </table>
                    </td>
                   </tr>
                   <tr>
                    <td>
                    <table>
                    <tr>
                        <td>
                            <asp:GridView ID="grvSustentos" runat="server" AllowPaging="True" 
                                AutoGenerateColumns="False" CellPadding="2" CssClass="gridSmall" 
                                DataKeyNames="PlantillaSU_Id" ForeColor="#333333" GridLines="None" 
                                PageSize="15">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Ver Detalle">
                                     <HeaderStyle Font-Bold="True" Font-Names="AENOR Fontana ND" Font-Size="X-Small" 
                                            ForeColor="#336699" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="IbtnSelect" runat="server" 
                                                CommandArgument='<%# Eval("PlantillaSU_Id") %>' 
                                                CommandName='<%# Eval("Nombre") %>' ImageUrl="../Imgs/Buscar.png" 
                                                Width="15px" Height="15px"
                                                OnClick="IbtnSelect_Click" ToolTip="Ver Detalle" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="55px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Nombre" HeaderText="Sustento">
                                        <HeaderStyle Font-Bold="True" Font-Names="AENOR Fontana ND" Font-Size="X-Small" 
                                            ForeColor="#336699" />
                                        <ItemStyle CssClass="FormatFontGridView" HorizontalAlign="Left" Width="250px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Seleccionar">
                                    <HeaderStyle Font-Bold="True" Font-Names="AENOR Fontana ND" Font-Size="X-Small" 
                                            ForeColor="#336699" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkOK" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="55px" />
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#3A4F63" ForeColor="White" Height="5px" 
                                    HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#9ADBFA" />
                            </asp:GridView>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink1" runat="server"
                            NavigateUrl="~/Views/sistemaPlanillas/ReportesyConsultas/ExcelInter/Sustento.xls"><font color=blue>Descargar</font></asp:HyperLink>
                        </td>
                    </tr>
                    </table> 
                    </td>
                   </tr>
                   </table>     
                   
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>         
            </ContentTemplate>
             <Triggers>
           <asp:PostBackTrigger ControlID="btnExportar" />              
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



<asp:Content ID="Content3" runat="server" contentplaceholderid="head">

    </asp:Content>




