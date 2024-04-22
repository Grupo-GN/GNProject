<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmImprimirBoleta.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.ReportesyConsultas.FrmImprimirBoleta" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<%@ Register src="../UserControl/ucComboArea.ascx" tagname="ucComboArea" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<script language="javascript" type="text/javascript">
    function fc_seleccion_Personal(personal_Id, nombre_Completo) {
        document.getElementById("<%= txtPersonal_Seleccionado.ClientID %>").value = nombre_Completo;
        document.getElementById("<%= hdfPersonal_Id.ClientID %>").value = personal_Id;
        
    }
</script>

   <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/nuevoEstiloPlanilla.css" rel="stylesheet" type="text/css" />
   
     <table align="center" width="100%">
     <tr>
     <td>
        
        <fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px;
           /*border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black; */
            min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; /*border-top: solid 1px black;*/">
    
    <br />
<asp:Label ID="Label1" runat="server" Text="IMPRIMIR BOLETAS" CssClass="miTitulo" ></asp:Label> 
<br />
<br />
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
        <fieldset class="fielsetStyles" style="background-color:White; /*border-style: outset;*/ border-width: thin; height:90%; min-height:310px;  /*width: 97%;*/">
        <legend>
          <asp:Label ID="Label2" runat="server" Text="Filtros y Busquedas" CssClass="miTituloOnTab"></asp:Label>
        </legend>
        
                <table>
                    <tr>
                        <td width="270PX">
                            <asp:TextBox ID="txtNombre_Completo" runat="server" Width="250px" CssClass="txt"></asp:TextBox>
                        </td>                    
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Area" CssClass="miLabel" 
                                Width="40px"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="cboArea" runat="server" AutoPostBack="True" CssClass="ddl" OnSelectedIndexChanged="cboArea_SelectedIndexChanged" >
                            </asp:DropDownList>
                        </td>
                        <td>
                            <label class="miLabel" >GERENCIA / Proyecto : </label>
                        </td>
                        <td>
                            <asp:DropDownList ID="cboProyecto" runat="server" AutoPostBack="True" CssClass="ddl" OnSelectedIndexChanged="cboProyecto_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="270PX">
                            <asp:DropDownList ID="cboorden" runat="server" OnSelectedIndexChanged="cboorden_SelectedIndexChanged">
                                <asp:ListItem Value="Nombre_completo">Apellidos y Nombres</asp:ListItem>
                                <asp:ListItem Value="Nro_Doc">Nro. Documento</asp:ListItem>
                                <asp:ListItem Value="PR.Descripcion">Proyecto</asp:ListItem>
<%--                                <asp:ListItem Value="4">Localidad</asp:ListItem>--%>
                                <asp:ListItem Value="A.DESCRIPCION">Area</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<asp:ImageButton ID="bpasar" runat="server" ImageUrl="~/Views/sistemaPlanillas/Icon/forward.gif" OnClick="bpasar_Click" />
                        </td>
                        <td colspan="3">
                            <asp:ImageButton ID="bborrar" runat="server" ImageUrl="~/Views/sistemaPlanillas/Icon/back.gif" OnClick="bborrar_Click" style="width: 15px" OnClientClick="return confirm('Est� seguro de remover');" />
                            <asp:CheckBoxList ID="chkorden" runat="server" RepeatDirection="Horizontal" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px">
                            </asp:CheckBoxList>
                        </td>
                        <td>
                            <asp:Button ID="btnBuscar" runat="server" CssClass="submit" onclick="btnBuscar_Click" Text="Buscar" />
                        </td>
                        <td>
                            <asp:LinkButton ID="elLink" runat="server" ForeColor="Blue" onclick="elLink_Click">Refrescar Personal</asp:LinkButton>
                        </td>
                    </tr>
                </table>
                
                  <table>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="upPersonal" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                  
                                <div style="overflow: hidden; width: 100%;">
                                    <table class="gridSmallCabecera" width="100%">
                                        <tr>
                                            <th width="60px" style="height: 16px; ">
                                                <input name="SelectAllCheckBox1" class="ck" 
                                                onclick="SelectAllCheckBoxes(this , 'grvPersonal')" type="checkbox" title="Seleccionar Todo" />
                                            </th>
                                            <th width="450px"><asp:Label ID="Label6" runat="server" Text="APELLIDOS Y NOMBRES" 
                                            CssClass="tituloGrilla"></asp:Label>
                                            </th>
                                            <th width="100px"><asp:Label ID="Label11" runat="server" Text="NRO. DOC" 
                                            CssClass="tituloGrilla"></asp:Label>
                                            </th>
                                            <th width="150px"><asp:Label ID="Label12" runat="server" Text="AREA" 
                                            CssClass="tituloGrilla"></asp:Label>
                                            </th>
                                            <th width="150px"><asp:Label ID="Label5" runat="server" Text="PROYECTO" 
                                            CssClass="tituloGrilla"></asp:Label>
                                            </th>
                                        </tr>
                                    </table>
                                </div>
                                
                                <div style="overflow: auto; width: 100%; height: 240px; border: solid 0px #000; ">
                                    <asp:GridView ID="grvPersonal" runat="server" 
                                        ShowHeader="False"
                                        AutoGenerateColumns="False" CellPadding="2" CssClass="gridSmall" 
                                        DataKeyNames="Personal_Id,Nombre_Completo" ForeColor="#333333" 
                                        GridLines="None" Width="100%" onrowdatabound="grvPersonal_RowDataBound">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ck" runat="server" CssClass="ck" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="59px" />
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Apellidos y Nombres" DataField="Nombre_Completo_Personal_Id">
                                                <ItemStyle Width="700px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Nro_Doc" HeaderText="NRO. DOC">
                                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NArea" HeaderText="AREA">
                                            <ItemStyle Width="150px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NProyecto" HeaderText="Proyecto" >
                                            <ItemStyle Width="150px" />
                                            </asp:BoundField>
                                        </Columns>
                                        <EditRowStyle BackColor="#999999" />
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#9ADBFA" />
                                        <EmptyDataTemplate>
                                            <div style="text-align:center; width:387px;">No se encontraron registros</div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </div>
                                
                                <table width="100%">
                                <tr>
                                <td style="width: 100%; text-align:right; ">
                                  <asp:Label ID="Label7" runat="server" Text="Total Personal: " CssClass="miLabelSuma"></asp:Label>
                                  <asp:Label ID="lblTotPersonal" runat="server" Text="" CssClass="miLabelSuma"></asp:Label>
                                </td>
                                </tr>
                                </table>
            
                            </ContentTemplate>                            
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>        
                </tr>
            </table>  
            
        </fieldset>
        
            
    <%--        <asp:UpdatePanel ID="upVerBoleta" runat="server">
                <ContentTemplate>--%>
                
      <fieldset class="fielsetStyles" style="background-color:White; /*border-style: outset;*/ border-width: thin; margin-top: 10px;">
        <legend>
          <asp:Label ID="Label8" runat="server" Text="IMPRESION" CssClass="miTituloOnTab"></asp:Label>
        </legend>  
            <table> 
                <tr>
                    <td>PDF por Personal:</td>
                    <td><asp:CheckBox ID="chkPorPersonal" runat="server" AutoPostBack="true" OnCheckedChanged="chkPorPersonal_CheckedChanged"></asp:CheckBox></td>
                    <td></td>
                    <td></td>
                    <td colspan="4"></td>
                </tr>
                <tr>
                    <td>Acumular Montos:</td>
                    <td><asp:CheckBox ID="chkAcumMontos" runat="server" AutoPostBack="true" OnCheckedChanged="chkAcumMontos_CheckedChanged"></asp:CheckBox></td>
                    <td><asp:Label ID="lblPeriodo_Desde" runat="server" Visible="false">Periodo Desde:</asp:Label></td>
                    <td><asp:DropDownList ID="cboPeriodo_Desde" runat="server" CssClass="ddl" Visible="false"></asp:DropDownList></td>
                    <td colspan="4"><asp:Label ID="lblNotaAcum" runat="server" Visible="false" ForeColor="Orange" Font-Bold="true" Font-Size="10px">S&oacute;lo acumula los Ingresos/Descuentos/Aportes</asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label10" runat="server" Text=" Personal Seleccionado" CssClass="miLabel"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtPersonal_Seleccionado" runat="server" Width="250px" CssClass="txt" Font-Bold="true" Enabled="false"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label9" runat="server" Text="Tipo de Proceso" CssClass="miLabel"></asp:Label> 
                    </td>
                    
                    <td>
                        <asp:DropDownList ID="cboProcesos" runat="server" CssClass="ddl">
                        </asp:DropDownList>
                    </td>

                    <td>
                        <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" CssClass="submit" 
                            onclick="btnImprimir_Click" style="display:none;" />
                    </td>
                    <td>
                        <asp:Button ID="btnVer" runat="server" Text="Ver" CssClass="submit" 
                            onclick="btnVer_Click" style="display:none;" />                            
                    </td>
                    <td>
                        <asp:Button ID="btnPreview" runat="server" CssClass="submit" 
                            onclick="btnPreview_Click" Text="Preview" Visible="false" />
                        <asp:Button ID="btnPreview_Disenio" runat="server" CssClass="submit" 
                            onclick="btnPreview_Disenio_Click" Text="Preview Dise�o" Visible="false" />
                    </td>
                    <td>
                        <asp:Button ID="btnImprimirPDF_AYN" runat="server" onclick="btnImprimirPDF_AYN_Click" CssClass="submit"
                            Text="Ver PDF Dise&ntilde;o AYN" Visible="false" />
                        <asp:Button ID="btnImprimirPDF" runat="server" onclick="btnImprimirPDF_Click" CssClass="submit"
                            Text="Ver PDF Dise&ntilde;o" />
                        <asp:CheckBox ID="chkDolares" runat="server" Text="D&oacute;lares?" AutoPostBack="true" OnCheckedChanged="chkDolares_CheckedChanged" />
                        <asp:CheckBox ID="chkAddTotalUSD" runat="server" Text="Total en D&oacute;lares?" />
                    </td>
                </tr>
            </table>
            </fieldset>
                           <asp:HiddenField ID="hdfPersonal_Id" runat="server" />
        <%--        </ContentTemplate>
            </asp:UpdatePanel>    --%>
            
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

<%--        </ContentTemplate>
            </asp:UpdatePanel>    --%>

  </fieldset>
    
         </td>
     </tr>
     </table>
</asp:Content>

