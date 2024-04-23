<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmProcesar_MS.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.nuevaPlanilla.FrmProcesar_MS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script src="../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var allCheckBoxSelector = '#<%=grvPersonal.ClientID%> input[id*="chkAll"]:checkbox';
        var checkBoxSelector = '#<%=grvPersonal.ClientID%> input[id*="chk"]:checkbox';

        function ToggleCheckUncheckAllOptionAsNeeded() {
            var totalCheckboxes = $(checkBoxSelector),
                checkedCheckboxes = totalCheckboxes.filter(":checked"),
                noCheckboxesAreChecked = (checkedCheckboxes.length === 0),
                allCheckboxesAreChecked = (totalCheckboxes.length === checkedCheckboxes.length);

            $(allCheckBoxSelector).attr('checked', allCheckboxesAreChecked);
        }

        $(document).ready(function () {
            $(allCheckBoxSelector).live('click', function () {
                $(checkBoxSelector).attr('checked', $(this).is(':checked'));

                ToggleCheckUncheckAllOptionAsNeeded();
            });

            $(checkBoxSelector).live('click', ToggleCheckUncheckAllOptionAsNeeded);

            ToggleCheckUncheckAllOptionAsNeeded();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />

    <link href="../Styles/nuevoEstiloPlanilla.css" rel="stylesheet" type="text/css" />

            <table align="center" width="100%">
     <tr>
     <td>
          <fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px;
           /*border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black; */
            min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; /*border-top: solid 1px black;*/">
    
    <br />
    <asp:Label ID="Label9" runat="server" Text="PROCESAR PLANILLAS" CssClass="miTitulo"></asp:Label>
    <br />
    <asp:UpdatePanel ID="Upd" runat="server">
        <ContentTemplate>
        <fieldset style="overflow:auto; /*border-style: outset;*/ border-width: thin; height:430px; width: 97.5%; background-color:White">
            <table width="100%">
                <tr>
                    <td style="width: 60px;">
                        Localidad :
                    </td>
                    <td style="width: 210px;">
                        <asp:DropDownList ID="cboArea" runat="server" CssClass="ddl" Width="200px" OnSelectedIndexChanged="btnVer_Click">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 100px;">Proyecto: </td>
                    <td style="width: 210px;">
                        <asp:DropDownList ID="cboProyecto" runat="server" CssClass="ddl" Width="200px" OnSelectedIndexChanged="btnVer_Click">
                        </asp:DropDownList>
                    </td>
                    <td>Área :</td>
                    <td>
                        <asp:DropDownList ID="cboCatAuxiliar" runat="server" CssClass="ddl" Width="200px" OnSelectedIndexChanged="btnVer_Click">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 50px;">
                        <asp:Label ID="Label1" runat="server" Text="Proceso : " CssClass="miLabel"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlProceso" runat="server"
                         OnSelectedIndexChanged="ddlProceso_SelectedIndexChanged" CssClass="ddl" 
                            Width="200px">
                        </asp:DropDownList>                       
                    </td>
                    <td colspan="2">
                        <asp:Button ID="btnVer" runat="server" Text="Ver Planilla" OnClick="btnVer_Click" CssClass="submit EstiloGeneralBoton" />&nbsp;
                        <asp:Button ID="btnProcesar" runat="server" Text="Procesar" OnClick="btnProcesar_Click"
                            Enabled="False" CssClass="submit EstiloGeneralBoton btn-nuevo" />
                    </td>
                    <td colspan="2"><asp:Label ID="lblmsj" runat="server" Text="" CssClass="miLabelError"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <asp:GridView ID="grvPersonal" runat="server" AutoGenerateColumns="False" 
                            DataKeyNames="Personal_Id" CssClass="gridSmall" Width="100%" 
                            onprerender="grvPersonal_PreRender">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkAll" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk" runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle Width="5%" HorizontalAlign="Center"/>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="CODIGO" DataField="Personal_Id">
                                   <HeaderStyle ForeColor="#336699" Font-Size="X-Small" Font-Bold="True" />
                                    <ItemStyle Width="8%" HorizontalAlign="Center"/>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="NOMBRES" DataField="Nombres" >
                                    <HeaderStyle ForeColor="#336699" Font-Size="X-Small" Font-Bold="True" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TDocumento" HeaderText="T. Doc" />
                                <asp:BoundField DataField="Nro_Doc" HeaderText="Nro. Doc" />
                                <asp:BoundField HeaderText="Fecha Ingreso" DataField="Fecha_ingreso" ItemStyle-HorizontalAlign="Center">
                                     <ItemStyle Width="10%"/>
                                    <HeaderStyle ForeColor="#336699" Font-Size="X-Small" Font-Bold="True" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Fecha Cese" DataField="Fecha_cese" ItemStyle-HorizontalAlign="Center">
                                     <ItemStyle Width="10%"/>
                                    <HeaderStyle ForeColor="#336699" Font-Size="X-Small" Font-Bold="True" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Fecha Ini. Contrato" DataField="Fecha_ini_contrato" ItemStyle-HorizontalAlign="Center">
                                     <ItemStyle Width="10%"/>
                                    <HeaderStyle ForeColor="#336699" Font-Size="X-Small" Font-Bold="True" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Fecha Fin. Contrato" DataField="Fecha_fin_contrato" ItemStyle-HorizontalAlign="Center">
                                     <ItemStyle Width="10%"/>
                                    <HeaderStyle ForeColor="#336699" Font-Size="X-Small" Font-Bold="True" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Fecha Ini. Vacaciones" DataField="Fecha_ini_vac" ItemStyle-HorizontalAlign="Center" HtmlEncode="false">
                                     <ItemStyle Width="10%"/>
                                    <HeaderStyle ForeColor="#336699" Font-Size="X-Small" Font-Bold="True" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Fecha Fin. Vacaciones" DataField="Fecha_fin_vac" ItemStyle-HorizontalAlign="Center" HtmlEncode="false">
                                     <ItemStyle Width="10%"/>
                                    <HeaderStyle ForeColor="#336699" Font-Size="X-Small" Font-Bold="True" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Proyecto" HeaderText="Proyecto" />
                                <asp:BoundField DataField="Reg_Pensionario" HeaderText="Sistema de Pensión" />
                                <asp:BoundField DataField="Basico" HeaderText="Básico" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Label ID="lblInvalidFormula" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>
    
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
    AssociatedUpdatePanelID="Upd"
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
