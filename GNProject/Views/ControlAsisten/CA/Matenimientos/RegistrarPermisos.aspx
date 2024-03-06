<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarPermisos.aspx.cs" Inherits="GNProject.Views.ControlAsisten.CA.Matenimientos.RegistrarPermisos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style type="text/css">
        .auto-style1 {
            height: 24px;
        }
        .auto-style2 {
            height: 25px;
        }
    </style>

    <script src="../../jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    
    <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />

    <fieldset>
    <legend class="miTituloField">REGISTRAR PERMISOS</legend>
    <table class="tableDialog">
        <tr>
            <td class="auto-style2"></td>
            <td class="auto-style2"></td>
            <td class="auto-style2"></td>
            <td class="auto-style2"></td>
            <td class="auto-style2"></td>
            <td class="auto-style2"></td>
            <td class="auto-style2"></td>
            <td class="auto-style2"></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center; font-weight: bold;">
                <asp:CheckBox ID="chkCesados" runat="server" AutoPostBack="True" OnCheckedChanged="chkCesados_CheckedChanged" Text="PERSONAL CESADOS" Font-Bold="True" Font-Size="X-Large" ForeColor="#000040" EnableViewState="True" CssClass="ui-corner-tl" />
              
            </td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td><asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox></td>
            <td></td>
            <td></td>
            <td><label class="miLabel">Periodo : </label></td>
            <td>
                <asp:Label ID="lblPeriodo" runat="server" CssClass="miTituloField"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:150px;text-align:right;"><label class="miLabel">Planilla : </label></td>
            <td><asp:DropDownList ID="cboPlanilla" runat="server" OnSelectedIndexChanged="cboPlanilla_SelectedIndexChanged" style="font-size: 11px; " AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td style="text-align:right;"><label class="miLabel">Area : </label></td>
            <td>
                <asp:DropDownList ID="cboArea" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cboArea_SelectedIndexChanged"  style="font-size: 11px; ">
                </asp:DropDownList>
            </td>
            <td style="text-align:right;"><label class="miLabel">Sección : </label></td>
            <td>
                <asp:DropDownList ID="cboSeccion" runat="server" OnSelectedIndexChanged="cboSeccion_SelectedIndexChanged" style="font-size: 11px; ">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="lblPeriodoId" runat="server" CssClass="miTituloField" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align:right;"><label class="miLabel">Localidad : </label></td>
            <td>
                <asp:DropDownList ID="cboLocalidad" runat="server" OnSelectedIndexChanged="cboLocalidad_SelectedIndexChanged" style="font-size: 11px; ">
                </asp:DropDownList>
            </td>
            <td style="text-align:right;"><label class="miLabel">Categoria : </label></td>
            <td>
                <asp:DropDownList ID="cboCategoria" runat="server" OnSelectedIndexChanged="cboCategoria_SelectedIndexChanged" style="font-size: 11px; ">
                </asp:DropDownList>
            </td>
            <td style="text-align:right;"></td>
            <td>
                <asp:Button ID="btnVerPersonal" runat="server" Text="ver personal"  class="buttonHer" OnClick="btnVerPersonal_Click" />
            </td>

            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>

        <tr>
            <td>&nbsp;</td>
            <td colspan="2">
                <asp:Label ID="lblerror" runat="server" Font-Bold="False" Font-Size="Small" ForeColor="Red" Visible="False"></asp:Label>
            </td><td colspan="2">&nbsp;</td>
            <td>&nbsp;</td><td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>

        <tr>
            <td style="text-align:right;"><label class="miLabel">Asignación Jefe : </label></td>
            <td>
                <asp:DropDownList ID="cboAsigJefe" runat="server" style="font-size: 11px; ">
                </asp:DropDownList>
            </td>
            <td style="text-align:right;"><label class="miLabel">Asignación Coordinador : </label></td>
            <td>
                <asp:DropDownList ID="cboAsigCoordinador" runat="server" style="font-size: 11px; ">
                </asp:DropDownList>
            </td>
            <td style="text-align:right;"><label class="miLabel">Asignación Gerente : </label></td>
            <td>
                <asp:DropDownList ID="cboAsigGerente" runat="server" style="font-size: 11px; ">
                </asp:DropDownList>
            </td>

            <td style="text-align:right;"><label class="miLabel">Nivel Acceso : </label></td>
            <td>
                <asp:DropDownList ID="cboNivelAcceso" runat="server" OnSelectedIndexChanged="cboNivelAcceso_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>

    </table>
</fieldset>
    <br />
    <div style="float: left;">
    <asp:Button ID="btnAsignar" runat="server" Text="ASIGNAR" class="buttonHer" OnClick="btnAsignar_Click"  />
    </div>
    <div style="float: left; padding-left: 20px; line-height: 35px;"><asp:Label ID="lblerrorSeleccion" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red" Visible="False"></asp:Label></div>

    <br />
   
           
    <asp:GridView ID="gvMostrarPermisos" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None"  style="width:100%;" PageSize="1000" OnSelectedIndexChanged="gvMostrarPermisos_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="chkSeleccion" runat="server" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Personal Id">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Personal_Id") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblPersonalId" runat="server" Text='<%# Bind("Personal_Id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Personal" HeaderText="Personal" />
            <asp:BoundField DataField="email" HeaderText="Correo Corporativo" />
            <asp:BoundField DataField="email_personal" HeaderText="Correo Personal" />
            <asp:BoundField DataField="Jefe" HeaderText="Jefe Inmediato" />
            <asp:BoundField DataField="Coordinador" HeaderText="Coordinador Central" />
            <asp:BoundField DataField="Gerente" HeaderText="Gerente" />
            <asp:BoundField DataField="UsuarioName" HeaderText="Usuario" />
            <asp:BoundField DataField="Password" HeaderText="Clave" />
            <asp:BoundField DataField="NivelAcceso" HeaderText="Nivel Acceso" />
            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Icon/pencilEdit2.ico" SelectText="" ShowSelectButton="True" />
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

    <asp:GridView ID="gvMostrarCesados" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" style="width:100%;" PageSize="1000">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Personal_Id" HeaderText="Personal Id" SortExpression="Personal_Id" />
            <asp:BoundField DataField="Personal" HeaderText="Personal" SortExpression="Personal" />
            <asp:BoundField DataField="email" HeaderText="Correo Corporativo" SortExpression="email" />
            <asp:BoundField DataField="email_personal" HeaderText="Correo Personal" SortExpression="email_personal" />
            <asp:BoundField DataField="Jefe" HeaderText="Jefe Inmediato" SortExpression="Jefe" />
            <asp:BoundField DataField="Coordinador" HeaderText="Coordinador Central" SortExpression="Coordinador" />
            <asp:BoundField DataField="Gerente" HeaderText="Gerente" SortExpression="Gerente" />
            <asp:BoundField DataField="UsuarioName" HeaderText="Usuario" SortExpression="UsuarioName" />
            <asp:BoundField DataField="Password" HeaderText="Clave" SortExpression="Password" />
            <asp:BoundField DataField="NivelAcceso" HeaderText="Nivel Acceso" SortExpression="NivelAcceso" />
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
