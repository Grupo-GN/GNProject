<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AsignaConceptos.aspx.cs" Inherits="GNProject.Views.ControlAsisten.CA.Matenimientos.AsignaConceptos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../../jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    
    <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />

    <label class="miTitulo">ASIGNAR CONCEPTOS</label><br /><br />

    <table class="tableDialog">

        <tr>
            <td colspan="2">
                <asp:CheckBox ID="chkDatosFijos" runat="server" AutoPostBack="True" OnCheckedChanged="chkDatosFijos_CheckedChanged" Text="Datos Fijos a Proyectar 5ta Categoria" />
            </td>
            <td><asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>

        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>

        <tr>
            <td><label class="miLabel"> Tipo Proceso: </label></td>
            <td><asp:DropDownList ID="cmbTipoProceso" runat="server" class="cbo"></asp:DropDownList></td>
            <td><label class="miLabel"> Boleta Columna </label></td>
            <td><asp:DropDownList ID="cmbBoletaColumna" runat="server" class="cbo" ></asp:DropDownList></td>
            <td><asp:Button ID="btnMostrar" runat="server" Text="MOSTRAR" class="buttonHer" OnClick="btnMostrar_Click"  /></td>
        </tr>
    </table>
    <hr />

    <asp:GridView ID="gvConceptos" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" style="width:100%;" PageSize="1000" OnSelectedIndexChanged="gvConceptos_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField HeaderText="Codigo Concepto">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Concepto_Id") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblcodconcepto" runat="server" Text='<%# Bind("Concepto_Id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
            <asp:BoundField DataField="Concepto_Remunerativo_Id" HeaderText="Codigo Asig. Plame" />
            <asp:BoundField DataField="descremunerativo" HeaderText="Asig. Plame Descripcion" />
            <asp:TemplateField HeaderText="Quinta Categoria">
                <ItemTemplate>
                    <asp:CheckBox ID="chkquintacategoria" runat="server" />
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ONP">
                <ItemTemplate>
                    <asp:CheckBox ID="chkonp" runat="server" />
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="AFP">
                <ItemTemplate>
                    <asp:CheckBox ID="chkafp" runat="server" />
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="EsSalud">
                <ItemTemplate>
                    <asp:CheckBox ID="chkessalud" runat="server" />
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Afecto Prom 5ta Cat">
                <ItemTemplate>
                    <asp:CheckBox ID="chkAfectoPromedio" runat="server" />
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Views/ControlAsisten/Icon/Modify.gif" ShowSelectButton="True" />
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#116fb4" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#116fb4" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
</asp:GridView>
    
    
    <br />
    <table class="tableDialog">
        <tr>
            <td style="width: 79%">
                &nbsp;</td>
            <td align="right"><asp:Button ID="btnGrabar" runat="server" Text="GRABAR" class="buttonHer" OnClick="btnGrabar_Click"  align="right" /></td>
        </tr>
    </table>
    

    <asp:GridView ID="gvDatosFijos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" style="width:100%;" PageSize="1000">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField HeaderText="Código Concepto">
                <ItemTemplate>
                    <asp:Label ID="lblConceptoId" runat="server" Text='<%# Bind("Concepto_Id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" SortExpression="Descripcion" />
            <asp:TemplateField HeaderText="Datos Fijos">
                <ItemTemplate>
                    <asp:CheckBox ID="chkDatosFijos" runat="server" />
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>


    <table class="tableDialog">
        <tr>
            <td style="width: 79%">
                &nbsp;</td>
            <td align="right"><asp:Button ID="btnGrabarDatosFijos" runat="server" Text="GRABAR" class="buttonHer" align="right" Visible="False" OnClick="btnGrabarDatosFijos_Click" /></td>
        </tr>
    </table>

</asp:Content>
