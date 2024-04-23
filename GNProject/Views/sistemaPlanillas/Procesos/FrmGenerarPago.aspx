<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmGenerarPago.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Procesos.FrmGenerarPago" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<%--@001 I/F--%>

<%--
    NOTAS:
    ======
    @001 FPS 07/04/2020 - Se agrega evento handler para que se llame a un método de una página cuando se cambia de Periodo y agrega funcionalidad de acumular montos por rango de periodo
    @002 FPS 15/07/2022 - Se cambia texto del label banco por banco de cia
    @003 FPS 30/10/2023 - Se agrega filtro estado personal y exportación agrupado por proyecto
--%>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <link rel="stylesheet" type="text/css" href="../css/multiple-select.css" />
    <script src="../JQuery/jquery-1.10.1.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../JQuery/jquery.multiple.select.js"></script>

    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />
    <fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px; /*border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black;*/ min-height: 500px; border-radius: 8px 8px 0px 0px; /*border-top: solid 1px black;*/">
        <label class="miTitulo">Generar Archivo para Bancos</label>
        <br />
        <br />
        
                <table style="width: 100%; border-collapse: collapse;">
                    <tr>
                        <td>
                            <label class="miLabel">Proceso: </label>
                        </td>
                        <td>
                            <asp:DropDownList ID="cboConcepto" runat="server" CssClass="ddl" AutoPostBack="True" OnSelectedIndexChanged="cboConcepto_SelectedIndexChanged"></asp:DropDownList></td>
                        <td>
                            <label class="miLabel">Banco de Compañía: </label> <%--@002 I/F--%>
                        </td>
                        <td>
                            <asp:DropDownList ID="cboBanco" runat="server" CssClass="ddl" AutoPostBack="True" OnSelectedIndexChanged="cboBanco_SelectedIndexChanged"></asp:DropDownList></td>
                        <td>
                            <label class="miLabel">Estado: </label>
                        </td>
                        <td>
                            <asp:DropDownList ID="cboEstado" CssClass="ddl" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cboEstado_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="1">TODOS</asp:ListItem>
                                <asp:ListItem Value="2">NO GENERADOS</asp:ListItem>
                                <asp:ListItem Value="3">GENERADOS</asp:ListItem>
                            </asp:DropDownList></td>

                    </tr>
                    <tr>
                        <td>
                            <label class="miLabel">Localidad</label></td>
                        <td>
                            <asp:DropDownList ID="cboArea" runat="server" Width="100%" CssClass="miComboBox" AutoPostBack="false">
                            </asp:DropDownList>
                            <asp:HiddenField ID="hdfArea" runat="server" />
                        </td>
                        <td>
                            <label class="miLabel">Proyecto</label></td>
                        <td style="text-align: left;">
                            <asp:DropDownList ID="cboProyecto" runat="server" CssClass="miComboBox" AutoPostBack="false">
                            </asp:DropDownList>
                            <asp:HiddenField ID="hdfProyecto" runat="server" />
                        </td>
                        <td>
                            <label class="miLabel">Area:</label></td>
                        <td>
                            <asp:DropDownList ID="cboCatAuxiliar" runat="server" CssClass="ddl" AutoPostBack="True" OnSelectedIndexChanged="btnBuscar_Click">
                            </asp:DropDownList>                            
                        </td>
                    </tr>
                    <%--@003 I--%>
                    <tr>
                        <td>
                            <label class="miLabel">Estado Personal</label>
                        </td>
                        <td colspan="5">
                            <asp:DropDownList ID="cboEstadoPersonal" runat="server" CssClass="ddl" AutoPostBack="True" OnSelectedIndexChanged="btnBuscar_Click">
                                <asp:ListItem Value="" Selected="True" Text="-TODOS-"></asp:ListItem>
                                <asp:ListItem Value="01" Text="ACTIVO"></asp:ListItem>
                                <asp:ListItem Value="02" Text="CESADO"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <%--@003 F--%>
                    <%--@001 I--%>
                    <tr>
                        <td class="miLabel">Acumular Montos:</td>
                        <td>
                            <asp:CheckBox ID="chkAcumMontos" runat="server" AutoPostBack="true" OnCheckedChanged="chkAcumMontos_CheckedChanged"></asp:CheckBox></td>
                        <td class="miLabel">
                            <asp:UpdatePanel ID="updAcumMontos1" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Label ID="lblPeriodo_Desde" runat="server" Visible="false">Periodo Desde:</asp:Label>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="chkAcumMontos" EventName="CheckedChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="updAcumMontos2" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:DropDownList ID="cboPeriodo_Desde" runat="server" CssClass="ddl" Visible="false"></asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="chkAcumMontos" EventName="CheckedChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td colspan="2">
                            <asp:UpdatePanel ID="updAcumMontos3" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Label ID="lblNotaAcum" runat="server" Visible="false" ForeColor="Orange" Font-Bold="true" Font-Size="10px">Acumular&aacute; los montos desde el periodo seleccionado.</asp:Label>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="chkAcumMontos" EventName="CheckedChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <%--@001 F--%>
                    <tr>
                        <td>
                            <asp:Button ID="btnBuscar" runat="server" CssClass="submit EstiloGeneralBoton btn-buscar" OnClick="btnBuscar_Click" Text="Buscar" />
                            &nbsp;</td>
                        <td>
                            <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>--%>
                                    <asp:Button ID="btnGenerar" runat="server" CssClass="submit EstiloGeneralBoton btn-nuevo" OnClick="btnGenerar_Click" OnClientClick="return confirm('¿Está seguro(a) de continuar?')" Text="Generar" ToolTip="Sirve Para Generar Archivos Planos" />
                                <%--</ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="btnGenerar" />
                                </Triggers>
                            </asp:UpdatePanel>--%>
                        </td>
                        <td>&nbsp;</td>
                        <td colspan="2" style="text-align: right;">
                            <asp:Button ID="btnobs" runat="server" CssClass="submit EstiloGeneralBoton" OnClick="btnobs_Click" OnClientClick="return confirm('¿Está seguro(a) de remplazar la información?')" Text="Reemplazar Observaciones" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtobstodos" runat="server" MaxLength="250"></asp:TextBox>
                        </td>
                    </tr>
                    <%--@003 I--%>
                    <tr style="border-top: solid 1px;">
                        <td colspan="2">
                            <asp:CheckBox ID="chkExportPorProyecto" runat="server" AutoPostBack="false" Text="Exportar por Proyecto" CssClass="miLabel"></asp:CheckBox>
                        </td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <%--@003 F--%>
                    <tr>
                        <td>
                            <asp:Label ID="lblErrorTelecredito" runat="server" Text="" CssClass="lblError"></asp:Label></td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <asp:UpdatePanel ID="updBandeja" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Label ID="lblMontoTotal" runat="server" Font-Bold="true" Font-Size="14px" ForeColor="#2196f3"></asp:Label>
                                    <asp:GridView ID="gvPersonal" runat="server" AutoGenerateColumns="False" CssClass="gridSmall" Width="100%"
                                        DataKeyNames="PersonalId,Estado,Proyecto">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkall" runat="server" onclick="SelectAllCheckBoxes(this , 'gvPersonal'); fnCalculateChecked();" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chksel" runat="server" onclick="fnCalculateChecked();" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="NroDoc" HeaderText="NRO. DOC">
                                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ApellidosNombres" HeaderText="APELLIDOS Y NOMBRES" />
                                            <asp:BoundField DataField="Area" HeaderText="LOCALIDAD" />
                                            <asp:BoundField DataField="Proyecto" HeaderText="PROYECTO" />
                                            <asp:BoundField DataField="CatAuxiliar" HeaderText="AREA" />
                                            <asp:BoundField DataField="Banco" HeaderText="BANCO" />
                                            <asp:BoundField DataField="Tipo_Cta_Ahorro" HeaderText="TIPO CTA." />
                                            <%--@001 I/F--%>
                                            <asp:BoundField DataField="Cta" HeaderText="NRO. CTA / INTERBANCARIA" />
                                            <asp:BoundField DataField="Valor" HeaderText="MONTO">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Observaciones">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtobs" runat="server" TextMode="MultiLine" Width="98%"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Ult. Impresión">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button ID="btnEstado" runat="server" Text='<%# Eval("NEstado") %>' OnClick="btnEstado_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="cboConcepto" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="cboBanco" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="cboEstado" EventName="SelectedIndexChanged" />
                                    <%--<asp:AsyncPostBackTrigger ControlID="cboArea" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="cboProyecto" EventName="SelectedIndexChanged" />--%>
                                    <asp:AsyncPostBackTrigger ControlID="cboCatAuxiliar" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="chkAcumMontos" EventName="CheckedChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnobs" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="cboEstadoPersonal" EventName="SelectedIndexChanged" /> <%--@003 I/F--%>
                                    <asp:PostBackTrigger ControlID="btnGenerar" />
                                </Triggers>
                            </asp:UpdatePanel>                            
                        </td>
                    </tr>
                </table>
            
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="1">
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
    <script language="javascript" type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(InitializeRequest);
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequest);
        var flPostBack = false;
        function InitializeRequest(sender, args) {
            $("#<%=UpdateProgress1.ClientID%>").show();
            flPostBack = true;
        }
        function EndRequest(sender, args) {
            $("#<%=UpdateProgress1.ClientID%>").hide();
            flPostBack = false;
        }

        $(document).ready(function () {
            $("#<%=cboArea.ClientID%>").multipleSelect();
            $("#<%=cboProyecto.ClientID%>").multipleSelect();

            $("#<%=cboArea.ClientID%>").change(function () {
                $("#<%=hdfArea.ClientID%>").val($("#<%=cboArea.ClientID%>").multipleSelect("getSelects").toString());
                $("#<%=btnBuscar.ClientID%>").click();
            });
            $("#<%=cboProyecto.ClientID%>").change(function () {
                $("#<%=hdfProyecto.ClientID%>").val($("#<%=cboProyecto.ClientID%>").multipleSelect("getSelects").toString());
                $("#<%=btnBuscar.ClientID%>").click();
            });

           if (flPostBack == false) {
                //Se vuelve a inicializar multiselect
               var Area_Ids = $("#<%=hdfArea.ClientID%>").val();
               var Proyecto_Ids = $("#<%=hdfProyecto.ClientID%>").val();
               if (Area_Ids != "" || Proyecto_Ids != "") {
                   $("#<%=cboArea.ClientID%>").multipleSelect("setSelects", Area_Ids.split(','));
                   $("#<%=cboProyecto.ClientID%>").multipleSelect("setSelects", Proyecto_Ids.split(','));
               }
            }
        });
        function fnCalculateChecked() {
            var grid = document.getElementById("<%=gvPersonal.ClientID%>");
            var sum = 0;
            for (var i = 1; i < grid.rows.length; i++) {
                var Cell_objCheckBox = grid.rows[i].cells[0].getElementsByTagName("input")[0];
                if (Cell_objCheckBox.checked) {
                    var cell_Monto = grid.rows[i].cells[9];
                    sum = sum + parseFloat(cell_Monto.innerText);
                }                
            }
            $("#<%=lblMontoTotal.ClientID%>").text("Total Seleccionado: " + sum.toFixed(4).toString());
        }
    </script>
</asp:Content>