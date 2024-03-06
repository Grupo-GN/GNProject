<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MPermisos.aspx.cs" Inherits="GNProject.Views.ControlAsisten.CA.Matenimientos.MPermisos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 25px;
        }
    </style>
</asp:Content>--%>
    <script src="../../jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    
    <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />

    <label class="miTitulo">REGISTRAR PERMISOS</label><br /><br />
    <table class="tableDialog">
        
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
            <td class="auto-style1">
                </td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
        </tr>

        <tr>
            <td><asp:Button ID="btnNuevo" runat="server" Text="NUEVO" class="buttonHer" OnClick="btnNuevo_Click"  /></td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
            <td></td>
            <td></td>
            <td>
                &nbsp;</td>
        </tr>
    </table>

    <hr />

    <asp:GridView ID="gvPermisos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" style="width:100%;" PageSize="1000" OnSelectedIndexChanged="gvPermisos_SelectedIndexChanged"
        DataKeyNames="Permiso_Id">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Icon/pencilEdit2.ico" SelectText="" ShowSelectButton="True">
            <ItemStyle HorizontalAlign="Center" Width="50px" />
            </asp:CommandField>
            <asp:TemplateField HeaderText="Permiso Horas">
                <ItemTemplate>
                    <asp:CheckBox ID="chkEstado" runat="server" OnCheckedChanged="chkEstado_CheckedChanged" AutoPostBack="True" />
                </ItemTemplate>
                <ItemStyle Width="50px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ID" SortExpression="Permiso_Id">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Permiso_Id") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblPermiso_Id" runat="server" Text='<%# Bind("Permiso_Id") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Width="50px" />
            </asp:TemplateField>
            <asp:BoundField DataField="descripcion" HeaderText="Descripcion" SortExpression="descripcion" />
            <asp:BoundField DataField="fechaAcumulado" HeaderText="Fecha Acumulado" SortExpression="fechaAcumulado">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="ejecutaAcumuladoDias" HeaderText="Ejecuta Acumulado Dias" SortExpression="ejecutaAcumuladoDias">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Tipo_Perm" HeaderText="Tipo Permiso" SortExpression="Tipo_Perm" />
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

</asp:Content>
