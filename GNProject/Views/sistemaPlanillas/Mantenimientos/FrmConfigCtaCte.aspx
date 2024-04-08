<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmConfigCtaCte.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Mantenimientos.FrmConfigCtaCte" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <link href="../Controles/miEstilo.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />

    <script src="../JQuery/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../JQuery/jquery-1.8.2.js" type="text/javascript"></script>
    <script type="text/javascript">
        function Valida() {
            var NroCuota = document.getElementById('<%=txtNroCuotas.ClientID%>');
            if(NroCuota.value == null || NroCuota.value ==""){
                  document.getElementById('<%=lblelErrorMs.ClientID%>').innerHTML = 'Error...Ingrese el numero de cuotas';
                  NroCuota.focus();
                  return false;
              }
              var MonCuota = document.getElementById('<%=txtMontoCtaCte.ClientID%>');
              if (MonCuota.value == null || MonCuota.value == "") {
                  document.getElementById('<%=lblelErrorMs.ClientID%>').innerHTML = 'Error...Ingrese el monto';
                  MonCuota.focus();
                  return false;
              }
            return true;
            
        }
    </script>
    <style type="text/css">
    .derecha
    {
    text-align:right;	
    }
    </style>
    
    <table align="center" width="100%">
        <tr>
            <td>
                <fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px; border-right: solid 1px black;
                    border-left: solid 1px black; border-bottom: solid 1px black; min-height: 550px;
                    overflow: hidden; border-radius: 8px 8px 0px 0px; border-top: solid 1px black;">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="width: 50%;" valign="middle">
                                        <asp:Label ID="Label9" runat="server" Text="CONFIGURACION DE CUENTAS CORRIENTES"
                                            CssClass="miTitulo" Width="300px"></asp:Label>
                                    </td>
                                    <td style="width: 50%;" align="right" valign="bottom">
                                        <asp:Panel ID="Panel1" runat="server" CssClass="elPanel">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnNew" runat="server" Text="Nuevo" CssClass="elBotonNew" Enabled="false"
                                                            OnClick="btnNew_Click" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnAdd" runat="server" Text="Grabar" CssClass="elBotonAdd" Enabled="false"
                                                            OnClick="btnAdd_Click" OnClientClick="return Valida();"/>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnCancel" runat="server" Text="Cancelar" CssClass="elBotonCancel"
                                                            Enabled="false" OnClick="btnCancel_Click" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnUpdate" runat="server" Text="Actualizar" CssClass="elBotonUpdate"
                                                            Enabled="false" OnClick="btnUpdate_Click" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnDelete" runat="server" Text="Eliminar" CssClass="elBotonDelete"
                                                            Enabled="false" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                            <fieldset style="background-color: White; border-style: outset; border-width: thin;border-radius: 8px 8px 8px 8px; height: 470px;">
                                <p>
                                </p>
                                <table width="100%">
                                    <tr>
                                        <td style="width: 105px;">
                                            <asp:Label ID="Label2" runat="server" Text="Digite los Nombres : " CssClass="miLabel"></asp:Label>
                                        </td>
                                        <td  style="width: 260px;">
                                            <asp:TextBox ID="txtNombrePersonal" CssClass="txt" runat="server" Width="250px"></asp:TextBox>
                                        </td>
                                        <td  style="width: 60px;">
                                            <asp:Button ID="btnBuscarr" runat="server" Text="Buscar" CssClass="submit" onclick="btnBuscarr_Click" 
                                                />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblelErrorMs" runat="server" Text="[lblError]" CssClass="miLabelError"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <cc1:TabContainer ID="TabContainer1" Width="100%" runat="server" ActiveTabIndex="0"
                                    Height="380">
                                    <cc1:TabPanel ID="TabPersonas" runat="server" HeaderText="Clientes">
                                        <ContentTemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td>
                                                        <div style="overflow: auto; width: 100%;">
                                                            <table class="gridSmallCabecera">
                                                                <tr>
                                                                    <th width="35px">
                                                                    </th>
                                                                    <th width="770px">
                                                                        <asp:Label ID="Label10" runat="server" Text="APELLIDOS Y NOMBRES" CssClass="tituloGrilla"></asp:Label>

                                                                    </th>
                                                                    <th width="90px">
                                                                        <asp:Label ID="Label1" runat="server" Text="NRO. DOC" CssClass="tituloGrilla"></asp:Label>

                                                                    </th>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                        <div style="overflow: auto; width: 100%; height: 339px;">
                                                            <asp:GridView ID="grvPersonal" runat="server" 
                                                                AutoGenerateColumns="False" ShowHeader="False"
                                                                DataKeyNames="Personal_Id,Nombre_Completo" CssClass="gridSmall" 
                                                                CellPadding="2"
                                                                GridLines="None"
                                                                ForeColor="#333333" Width="100%" 
                                                                OnRowCommand="grvPersonal_RowCommand" 
                                                                onrowdatabound="grvPersonal_RowDataBound" 
                                                                onprerender="grvPersonal_PreRender"><Columns>
                                                            <asp:TemplateField><ItemTemplate>
                                                                              <asp:ImageButton ID="ImageButton1" runat="server" 
                                                                              ToolTip="Nuevo" CommandName="Neww"
                                                                                ImageUrl="~/Views/sistemaPlanillas/Icon/Add.gif" onclick="ImageButton1_Click" />
                                                                            <asp:ImageButton ID="IbtnSelect" runat="server" ToolTip="Seleccionar" CommandName="Select"
                                                                                ImageUrl="../Icon/png/Go.png" onclick="IbtnSelect_Click" Width="15px"/>
         
                                                                    </ItemTemplate>

                                                                <ItemStyle Width="20px"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Nombre_Completo" HeaderText="Apellidos y Nombres">
                                                                <ItemStyle Width="450px" CssClass="FormatFontGridView"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Nro_Doc" HeaderText="Nro. Doc.">
                                                                <ItemStyle Width="50px" HorizontalAlign="Center" CssClass="FormatFontGridView"></ItemStyle>
                                                                </asp:BoundField>
                                                                                                                                </Columns>

                                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

                                                                <EditRowStyle BackColor="#999999" />

                                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />

                                                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />

                                                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />

                                                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />

                                                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                                                                            </asp:GridView>



                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>

                                    </ContentTemplate>
                                     </cc1:TabPanel>
                                    <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="Ctas. Ctes.">
                                        <ContentTemplate>
                                                  <table width="100%">
                                                <tr>
                                            <td>                                                    
                                            <div style="overflow: auto; width: 100%; height: 180px">
                                                <asp:GridView ID="grvCta_Cte" runat="server" AutoGenerateColumns="False" Width="100%"
                                                    CssClass="gridSmall" CellPadding="2" ForeColor="#333333" GridLines="None" DataKeyNames="Cta_Cte_Id"
                                                    OnRowDeleting="grvCta_Cte_RowDeleting" 
                                                    OnRowCommand="grvCta_Cte_RowCommand" onrowdatabound="grvCta_Cte_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="IbtnSelect_Cta_Cte" runat="server" ToolTip="Editar" CommandName="Select"
                                                                    ImageUrl="~/Views/sistemaPlanillas/Icon/Modify.gif" />
                                                                <asp:ImageButton ID="ibtnSCuotas" runat="server" Width="15px" 
                                                                    ToolTip="Ver Cuotas" CommandName="Detail"
                                                                    ImageUrl="~/Views/sistemaPlanillas/Icon/png/detail.png" onclick="ibtnSCuotas_Click" />
                                                                <asp:ImageButton ID="ibtnEliminarCta_Cte" runat="server" ToolTip="Eliminar" CommandArgument='<%# Eval("Cta_Cte_Id") %>'
                                                                    CommandName="Delete" ImageUrl="~/Views/sistemaPlanillas/Icon/delete.gif" OnClientClick="return confirm('�Esta Seguro De Eliminar? �Tambien de eliminaran las cuotas!');" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="60px" ></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Cta_Cte_Id" HeaderText="CTA_CTE_ID">
                                                            <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                                        Font-Bold="True" />
                                                            <ItemStyle Width="20px" HorizontalAlign="Center" CssClass="FormatFontGridView">
                                                        </ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Observaciones" HeaderText="OBSERVACIONES">
                                                            <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                                        Font-Bold="True" />
                                                            <ItemStyle Width="250px" CssClass="FormatFontGridView"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Monto" HeaderText="MONTO">
                                                            <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                                        Font-Bold="True" />
                                                            <ItemStyle Width="50px" HorizontalAlign="Center" CssClass="FormatFontGridView">
                                                        </ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Fecha_Ini" HeaderText="FECHA INI." 
                                                        DataFormatString="{0:dd/MM/yyyy}">
                                                            <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                                        Font-Bold="True" />
                                                            <ItemStyle Width="50px" HorizontalAlign="Center" CssClass="FormatFontGridView">
                                                        </ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Fecha_Fin" HeaderText="FECHA FIN." 
                                                        DataFormatString="{0:dd/MM/yyyy}">
                                                            <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                                        Font-Bold="True" />
                                                            <ItemStyle Width="50px" HorizontalAlign="Center" CssClass="FormatFontGridView">
                                                        </ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Personal_Id" HeaderText="Personal_Id" 
                                                            Visible="False">
                                                            <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                                        Font-Bold="True" />
                                                            <ItemStyle Width="0px"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Operacion_Id" HeaderText="OPERACION_ID">
                                                            <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                                        Font-Bold="True" />
                                                            <ItemStyle Width="50px" HorizontalAlign="Center" CssClass="FormatFontGridView">
                                                        </ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Motivo_Id" HeaderText="Motivo_Id" Visible="False">
                                                            <ItemStyle Width="0px"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Nro_Cuotas" HeaderText="NRO. CUOTAS">
                                                            <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                                        Font-Bold="True" />
                                                            <ItemStyle Width="50px" HorizontalAlign="Center" CssClass="FormatFontGridView">
                                                        </ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Moneda_Id" HeaderText="MONEDA_ID">
                                                            <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                                        Font-Bold="True" />
                                                            <ItemStyle Width="50px" HorizontalAlign="Center" CssClass="FormatFontGridView">
                                                        </ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Fecha_Sistema" HeaderText="FEC. SISTEMA" 
                                                        DataFormatString="{0:dd/MM/yyyy}">
                                                            <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                                        Font-Bold="True" />
                                                            <ItemStyle Width="50px" HorizontalAlign="Center" CssClass="FormatFontGridView">
                                                        </ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Estado_Id" HeaderText="Estado_Id" Visible="False">
                                                            <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                                        Font-Bold="True" />
                                                            <ItemStyle Width="0px" CssClass="FormatFontGridView"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Interes_Anual" HeaderText="INTERES ANUAL">
                                                            <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                                        Font-Bold="True" />
                                                            <ItemStyle Width="50px" HorizontalAlign="Left" CssClass="FormatFontGridView">
                                                        </ItemStyle>
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                    <EditRowStyle BackColor="#999999" />
                                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                </asp:GridView>
                                            </div>
                                            
                                                     </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    <div>
                                                     <table width="100%">
                                    <tr>

                                        <td>
                                            <div style="width: 100%;overflow:auto;height:195px">
                                                <asp:GridView ID="grvCuotas" runat="server" AutoGenerateColumns="False" 
                                                    CellPadding="2" CssClass="gridSmall" 
                                                    DataKeyNames="Cuotas_Id,Proceso_Id,Periodo_Id,Estado_Pago_Id" 
                                                    ForeColor="#333333" GridLines="None" 
                                                    OnRowCancelingEdit="grvCuotas_RowCancelingEdit" 
                                                    OnRowCommand="grvCuotas_RowCommand" OnRowDataBound="grvCuotas_RowDataBound" 
                                                    OnRowDeleting="grvCuotas_RowDeleting" OnRowEditing="grvCuotas_RowEditing" 
                                                    OnRowUpdating="grvCuotas_RowUpdating" ShowFooter="True" Width="100%">
                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <EditItemTemplate>
                                                                <asp:ImageButton ID="ibtnActualizarCuota" runat="server" 
                                                                    CommandArgument='<%# Eval("Cuotas_Id") %>' CommandName="Update" 
                                                                    ImageUrl="~/Views/sistemaPlanillas/Icon/Save.gif" ToolTip="Actualizar" ValidationGroup="Valida" 
                                                                    Width="20px" />
                                                                <asp:ImageButton ID="ibtnCancelarCuota" runat="server" CommandName="Cancel" 
                                                                    ImageUrl="~/Views/sistemaPlanillas/Icon/cancel.gif" ToolTip="Cancelar" />
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="IbtnSelect_Cuota" runat="server" 
                                                                    CommandArgument='<%# Eval("Cuotas_Id") %>' CommandName="Edit" 
                                                                    ImageUrl="~/Views/sistemaPlanillas/Icon/Modify.gif" ToolTip="Editar" />
                                                                <asp:ImageButton ID="ibtnEliminarCuota" runat="server" 
                                                                    CommandArgument='<%# Eval("Cuotas_Id") %>' CommandName="Delete" 
                                                                    ImageUrl="~/Views/sistemaPlanillas/Icon/delete.gif" 
                                                                    OnClientClick="return confirm('�Esta Seguro De Eliminar?');" 
                                                                    ToolTip="Eliminar" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Cuotas_Id" HeaderText="Cuotas_Id" Visible="False">
                                                            <ItemStyle Width="50px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Cuota_Desc" HeaderText="CUOTA" ReadOnly="True">
                                                            <HeaderStyle Font-Bold="True"  Font-Size="X-Small" 
                                                                ForeColor="#336699" />
                                                            <ItemStyle HorizontalAlign="Center" Width="15px" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="PROCESO">
                                                            <EditItemTemplate>
                                                                <asp:DropDownList ID="cboProcesoCuota" runat="server" CssClass="ddl">
                                                                </asp:DropDownList>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblProcesoCuota" runat="server" Text='<%# Eval("no_Proceso") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Font-Bold="True"  Font-Size="X-Small" 
                                                                ForeColor="#336699" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="PERIODO">
                                                            <EditItemTemplate>
                                                                <asp:DropDownList ID="cboPeriodoCuota" runat="server" CssClass="ddl">
                                                                </asp:DropDownList>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPeriodoCuota" runat="server" Text='<%# Eval("no_Periodo") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Font-Bold="True"  Font-Size="X-Small" 
                                                                ForeColor="#336699" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="MONTO S/.">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtMonto" runat="server" CssClass="txt" 
                                                                    Text='<%# Eval("Monto") %>' Width="70px"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                                    ControlToValidate="txtMonto" ErrorMessage="*" Text="*" ValidationGroup="Valida"></asp:RequiredFieldValidator>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblMonto" runat="server" Text='<%# Eval("Monto") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Font-Bold="True"  Font-Size="X-Small" 
                                                                ForeColor="#336699" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="DTALLE. ESTADO. PAG.">
                                                            <EditItemTemplate>
                                                                <asp:DropDownList ID="cboEstado_Pago" runat="server" CssClass="ddl">
                                                                </asp:DropDownList>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEstado_Pago" runat="server" 
                                                                    Text='<%# Eval("no_Estado_Pago") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Font-Bold="True"  Font-Size="X-Small" 
                                                                ForeColor="#336699" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ESTADO">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtEstado" runat="server" CssClass="txt" 
                                                                    Text='<%# Eval("Estado_Id") %>' Width="20px"></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEstado" runat="server" Text='<%# Eval("Estado_Id") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Font-Bold="True"  Font-Size="X-Small" 
                                                                ForeColor="#336699" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EditRowStyle BackColor="#999999" />
                                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                </asp:GridView>
                                            </div>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>

                                    </tr>


                                </table>
                                                    </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        

                                    
                                    </ContentTemplate>
                                    

</cc1:TabPanel>
                                    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Detalles de la Cta.">
                                        <HeaderTemplate>
                                            Detalles de la Cta.
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                                <table>
                                                    <tr>
                                                        <td class="derecha">
                                                             <asp:Label ID="Label4" runat="server" Text="Asignaci�n : " CssClass="miLabel"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:RadioButtonList ID="rbAsignacionList" runat="server" RepeatDirection="Horizontal" Font-Size="X-Small">
                                                                <asp:ListItem Value="M" Enabled="true" Text="Mensual">
                                                                </asp:ListItem>
                                                                <asp:ListItem Value="Q" Text="Quincenal">
                                                                </asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                    
                                                        <td class="derecha">
                                                            <asp:Label ID="Label3" runat="server" CssClass="miLabel" Text="Cta. Cte. : "></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblNroCta" runat="server" Font-Bold="True"
                                                                 BackColor="#CCCCCC" Width="60px"
                                                                BorderWidth="1px" CssClass="miLabel"></asp:Label>
                                                        </td>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="derecha">
                                                          <asp:Label ID="Label7" runat="server" Text="Motivo : " CssClass="miLabel"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="cboMotivoCtaCte" runat="server" 
                                                            CssClass="ddl" Width="120px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label6" runat="server" CssClass="miLabel" Text="Operaci�n : "></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="cboOperacion" runat="server" CssClass="ddl" Width="120px">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="derecha">
                                                            <asp:Label ID="Label8" runat="server" Text=" Nro. Cuotas : " CssClass="miLabel"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtNroCuotas" runat="server" CssClass="txt" Width="30px"></asp:TextBox><asp:RequiredFieldValidator
                                                                ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNroCuotas"
                                                                ErrorMessage="*" ValidationGroup="ValidaGrabaCta">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        </tr>
                                                        <tr>
                                                        <td class="derecha">
                                                          <asp:Label ID="Label11" runat="server" Text="Fec. Inicio : " CssClass="miLabel"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtFecha_Inicio" runat="server" CssClass="txt" Width="70px"></asp:TextBox><cc1:MaskedEditExtender
                                                                ID="txtFecha_Inicio_MaskedEditExtender" runat="server" CultureAMPMPlaceholder="a.m.;p.m."
                                                                CultureCurrencySymbolPlaceholder="S/." CultureDateFormat="DMY" CultureDatePlaceholder="/"
                                                                CultureDecimalPlaceholder="." CultureName="es-PE" CultureThousandsPlaceholder=","
                                                                CultureTimePlaceholder="" Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFecha_Inicio"
                                                                UserDateFormat="DayMonthYear">
                                                            </cc1:MaskedEditExtender>
                                                            <cc1:CalendarExtender ID="txtFecha_Inicio_CalendarExtender" runat="server" CssClass="calendar_Theme1"
                                                                Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFecha_Inicio" PopupButtonID="ibtnFec_Inicio">
                                                            </cc1:CalendarExtender>
                                                            <asp:ImageButton ID="ibtnFec_Inicio" runat="server" ToolTip="Click para mostrar el Calendario"
                                                                ImageUrl="~/Views/sistemaPlanillas/Imgs/buttons/img_Calendar.png" ImageAlign="TextTop" /><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFecha_Inicio"
                                                                    ErrorMessage="*" ValidationGroup="ValidaGrabaCta">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td class="derecha">
                                                          <asp:Label ID="Label12" runat="server" Text="Fec. Final : " CssClass="miLabel"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtFecha_Final" runat="server" CssClass="txt" Width="70px"></asp:TextBox><cc1:MaskedEditExtender
                                                                ID="txtFecha_Final_MaskedEditExtender" runat="server" CultureAMPMPlaceholder="a.m.;p.m."
                                                                CultureCurrencySymbolPlaceholder="S/." CultureDateFormat="DMY" CultureDatePlaceholder="/"
                                                                CultureDecimalPlaceholder="." CultureName="es-PE" CultureThousandsPlaceholder=","
                                                                CultureTimePlaceholder="" Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFecha_Final"
                                                                UserDateFormat="DayMonthYear">
                                                            </cc1:MaskedEditExtender>
                                                            <cc1:CalendarExtender ID="txtFecha_Final_CalendarExtender" runat="server" CssClass="calendar_Theme1"
                                                                Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFecha_Final" PopupButtonID="ibtnFec_Final">
                                                            </cc1:CalendarExtender>
                                                            <asp:ImageButton ID="ibtnFec_Final" runat="server" ToolTip="Click para mostrar el Calendario"
                                                                ImageUrl="~/Views/sistemaPlanillas/Imgs/buttons/img_Calendar.png" ImageAlign="TextTop" /><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFecha_Final"
                                                                    ErrorMessage="*" ValidationGroup="ValidaGrabaCta">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="derecha">
                                                          <asp:Label ID="Label13" runat="server" Text="Monto : " CssClass="miLabel"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtMontoCtaCte" runat="server" CssClass="txt" Width="70px"></asp:TextBox><asp:RequiredFieldValidator
                                                                ID="txtMontoCtaCte_RequiredFieldValidator" runat="server" ControlToValidate="txtMontoCtaCte"
                                                                ErrorMessage="*" ValidationGroup="ValidaGrabaCta">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="derecha">
                                                          <asp:Label ID="Label15" runat="server" Text="Moneda : " CssClass="miLabel"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="cboMoneda" runat="server" CssClass="ddl" Width="120px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="derecha">
                                                            <asp:Label ID="Label16" runat="server" Text="Estado : " CssClass="miLabel"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="cboEstado" runat="server" CssClass="ddl" Width="120px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                    <td >                                      
                                                          <asp:Label ID="Label14" runat="server" Text="Descripci�n : " CssClass="miLabel"></asp:Label>
                                                    </td> 
                                                    <td colspan="4">
                                                            <asp:TextBox ID="txtDescripcion" runat="server" Height="80px" TextMode="MultiLine"
                                                                Width="300px"></asp:TextBox>
                                                    </td>
                                                    </tr>
                                                </table>
                                                <table width="100%">
                                            <tr>
                                          <td>
                                         <div style="width: 100%;overflow:auto;height:90px">
                                        <asp:GridView ID="grvCuotas2" runat="server" AutoGenerateColumns="False" CellPadding="2"
                                            Width="100%"
                                                CssClass="gridSmall" DataKeyNames="Cuotas_Id,Proceso_Id,Periodo_Id,Estado_Pago_Id"
                                                ForeColor="#333333" GridLines="None" OnRowCancelingEdit="grvCuotas2_RowCancelingEdit"
                                                OnRowCommand="grvCuotas2_RowCommand" 
                                                OnRowDataBound="grvCuotas2_RowDataBound" OnRowDeleting="grvCuotas2_RowDeleting"
                                                OnRowEditing="grvCoutas2_RowEditing" OnRowUpdating="grvCoutas2_RowUpdating" 
                                                ShowFooter="True">
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="IbtnSelect_Cuota" runat="server" ToolTip="Editar" CommandArgument='<%# Eval("Cuotas_Id") %>'
                                                                CommandName="Edit"  ImageUrl="~/Views/sistemaPlanillas/Icon/Modify.gif"  />
                                                            <asp:ImageButton ID="ibtnEliminarCuota" runat="server" ToolTip="Eliminar"
                                                             CommandArgument='<%# Eval("Cuotas_Id") %>'
                                                                CommandName="Delete" ImageUrl="~/Views/sistemaPlanillas/Icon/delete.gif"
                                                                OnClientClick="return confirm('�Esta Seguro De Eliminar?');" />
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:ImageButton ID="ibtnActualizarCuota" runat="server" ToolTip="Actualizar" CommandArgument='<%# Eval("Cuotas_Id") %>'
                                                                CommandName="Update"  ImageUrl="~/Views/sistemaPlanillas/Icon/Save.gif" Width="20px"
                                                                ValidationGroup="Valida" />
                                                            <asp:ImageButton ID="ibtnCancelarCuota" runat="server" CommandName="Cancel" ToolTip="Cancelar"
                                                                 ImageUrl="~/Views/sistemaPlanillas/Icon/cancel.gif" />
                                                        </EditItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Cuotas_Id" HeaderText="Cuotas_Id" Visible="False">
                                                        <ItemStyle Width="50px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Cuota_Desc" ReadOnly="True" HeaderText="CUOTA">
                                                     <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                                        Font-Bold="True" />
                                                        <ItemStyle Width="15px" HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="PROCESO">
                                                     <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                                        Font-Bold="True" />
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="cboProcesoCuota" runat="server" CssClass="ddl">
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblProcesoCuota" runat="server" Text='<%# Eval("no_Proceso") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                       
                                                    <asp:TemplateField HeaderText="PERIODO">
                                                       <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                                        Font-Bold="True" />
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="cboPeriodoCuota" runat="server" CssClass="ddl">
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPeriodoCuota" runat="server" Text='<%# Eval("no_Periodo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                         <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="MONTO S/.">
                                                       <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                                        Font-Bold="True" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblMonto" runat="server" Text='<%# Eval("Monto") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtMonto" runat="server" CssClass="txt" Text='<%# Eval("Monto") %>'
                                                                Width="70px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtMonto"
                                                                runat="server" ErrorMessage="*" Text="*" ValidationGroup="Valida"></asp:RequiredFieldValidator>
                                                        </EditItemTemplate>
                                                         <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="DTALLE. ESTADO. PAG.">
                                                       <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                                        Font-Bold="True" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEstado_Pago" runat="server" Text='<%# Eval("no_Estado_Pago") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="cboEstado_Pago" runat="server" CssClass="ddl">
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                         <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="ESTADO">
                                                       <HeaderStyle ForeColor="#336699" Font-Size="X-Small" 
                                                                        Font-Bold="True" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEstado" runat="server" Text='<%# Eval("Estado_Id") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtEstado" runat="server" CssClass="txt" Text='<%# Eval("Estado_Id") %>'
                                                                Width="20px"></asp:TextBox>
                                                        </EditItemTemplate>
                                                         <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EditRowStyle BackColor="#999999" />
                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                            </asp:GridView>
                                        </div>
                                                        
                                                        </td>
                                                    </tr>
                                                </table>

                                    </ContentTemplate>
                                    

</cc1:TabPanel>
                                    
                                </cc1:TabContainer>
                                <asp:HiddenField ID="hdnPersonal_Id" runat="server" />
                                <asp:Label ID="lblNomPersonal" runat="server"></asp:Label>
                                
                                <table class="style1">
                                    <tr>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:HiddenField ID="hdnCta_Cte_Id" runat="server" />
                                            <asp:Label ID="lblCta_Cte" runat="server"></asp:Label>
                                        </td>

                                    </tr>
                                    </table>
                                    
                                   
                                </td> </tr> 
                                </table> 
                                </td> </tr>

                                </table>
                            </fieldset>
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
                </fieldset>
            </td>
        </tr>
    </table>
</asp:Content>
