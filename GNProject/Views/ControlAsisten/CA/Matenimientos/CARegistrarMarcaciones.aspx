<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CARegistrarMarcaciones.aspx.cs" Inherits="GNProject.Views.ControlAsisten.CA.Matenimientos.CARegistrarMarcaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />
    
<label class="miTitulo">SUBIR MARCACIONES</label>
<br />
<fieldset>
<legend class="miTituloField">Datos</legend>
<label class="miLabel">Periodo Vigente: </label>&nbsp;
<input id="txtcodigo" class="estiloCajaCodigo" readonly="readonly" type="text" runat="server" style="font-size:12px;"/>
&nbsp;&nbsp;&nbsp;
<label class="miLabel">Fecha Inicio: </label>&nbsp;
<input id="txtfi" runat="server" style="background-color: #FFFFCC; color: #2B60DE;
   font-family:AENOR Fontana ND Demibold;
   font-weight:bold;
   text-align:center;
	min-height: 16px;
	border: #B1B1B1 1px solid;
	text-transform:uppercase;
	font-size:12px;
	width:135px;"   readonly="readonly" type="text" />&nbsp;
<label class="miLabel">Fecha Fin : </label>&nbsp;
<input id="txtft" runat="server" style="background-color: #FFFFCC; color: #2B60DE;
   font-family:AENOR Fontana ND Demibold;
   font-weight:bold;
   text-align:center;
	min-height: 16px;
	border: #B1B1B1 1px solid;
	text-transform:uppercase;
	font-size:12px;
	width:135px;" readonly="readonly" type="text" />&nbsp;
</fieldset>
<fieldset>
<legend class="miTituloField">Cargar Archivo</legend>
    <table style="width:100%;border-collapse:collapse;">
        <tr>
            <td><asp:FileUpload ID="fileUpd" runat="server" CssClass="submitGrabar" Width="320px" /></td>
            <td>
                <asp:RadioButtonList ID="rbtipo" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1" Selected="True">GNRS</asp:ListItem>
                    <asp:ListItem Value="2">AYN</asp:ListItem>
                    <asp:ListItem Value="1">Consorcio</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>
                <asp:Button ID="btnVer" runat="server" CssClass="submit" Text="Marcaciones" onclick="btnVer_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnGuardar" runat="server" CssClass="submit" Text="Guardar" onclick="btnGuardar_Click" />
                <asp:Button ID="btnDescargarArchivo" runat="server"  CssClass="submit" Text="Plantilla" OnClick="btnDescargarArchivo_Click" />
            </td>
        </tr>
    </table>

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<%--<input id="btnArchivo" type="button" value="Archivo" class="submit" />--%><%--<input id="btnVer" type="button" value="Ver" class="submit"  />--%>
<%--<input id="btnGuardar" type="button" value="Guardar" class="submitGrabar"/>--%>
</fieldset>
<asp:Label id="lblMsj" class="miLabelError" runat="server" ></asp:Label> <br />
<asp:Label ID="lblError" runat="server" Text="" CssClass="lblError"></asp:Label>
 <asp:Panel ID="Panel1" style="margin: auto; width: 80%" runat="server">
  <table>
   <tr>
    <td>
   <div >
 <table class="gridSmallCabecera">
                <tr>
            <th width="164px"><asp:Label ID="Label9" runat="server" Text="ID" CssClass="tituloGrilla"></asp:Label></th>
            <th width="240px"><asp:Label ID="Label10" runat="server" Text="Fecha" CssClass="tituloGrilla"></asp:Label></th>
            <th width="164px"><asp:Label ID="Label1" runat="server" Text="Hora Ingreso" CssClass="tituloGrilla"></asp:Label></th>
            <th width="164px"><asp:Label ID="Label2" runat="server" Text="Hora Salida" CssClass="tituloGrilla"></asp:Label></th>
            <th width="95px"><asp:Label ID="Label11" runat="server" Text="Tipo" CssClass="tituloGrilla"></asp:Label></th>
            <th width="143px"><asp:Label ID="Label12" runat="server" Text="Mensaje" CssClass="tituloGrilla"></asp:Label></th>
             </tr>
 </table>
</div>
<div>
<asp:GridView ID="grvMarcaciones" runat="server" CssClass="mGrid" 
                            AutoGenerateColumns="False" CellPadding="1" ForeColor="#333333" 
                            ShowHeader="false"
                            GridLines="None">
                            <RowStyle HorizontalAlign="Left" BackColor="#E3EAEB" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle HorizontalAlign="Left" BackColor="#1C5E55" Font-Bold="True" 
                                ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="ID" >
                                <HeaderStyle Width="170px" />
                                <ItemStyle Width="170px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha" >
                                <HeaderStyle Width="250px" />
                                <ItemStyle Width="250px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Ingreso" HeaderText="Hora Ingreso" >
                                <HeaderStyle Width="170px" />
                                <ItemStyle Width="170px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Salida" HeaderText="Hora Salida" >
                                <HeaderStyle Width="170px" />
                                <ItemStyle Width="170px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Tipo" HeaderText="Tipo" >
                                <HeaderStyle Width="100px" />
                                <ItemStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Mensaje" HeaderText="Mensaje" >
                                <HeaderStyle Width="150px" />
                                <ItemStyle Width="150px" />
                                </asp:BoundField>
                            </Columns>
                            <EditRowStyle BackColor="#7C6F57" />
                            <AlternatingRowStyle BackColor="White" />

    </asp:GridView>
    </div>
    </td>
    </tr>
    </table>
    </asp:Panel>

    <asp:Panel ID="Panel2" runat="server">
   <table>
   <tr>
    <td>
    <div >
 <table class="gridSmallCabecera">
                <tr>
            <th width="270"><asp:Label ID="Label3" runat="server" Text="Nombres" CssClass="tituloGrilla"></asp:Label></th>
            <th width="80px"><asp:Label ID="Label4" runat="server" Text="Cod.Trabajador" CssClass="tituloGrilla"></asp:Label></th>
            <th width="85px"><asp:Label ID="Label5" runat="server" Text="Fecha" CssClass="tituloGrilla"></asp:Label></th>
            <th width="42px"><asp:Label ID="Label7" runat="server" Text="H. Ingreso" CssClass="tituloGrilla"></asp:Label></th>
            <th width="42px"><asp:Label ID="Label8" runat="server" Text="H. Salida" CssClass="tituloGrilla"></asp:Label></th>
            <th width="85px"><asp:Label ID="Label13" runat="server" Text="Fecha Registro" CssClass="tituloGrilla"></asp:Label></th>
            <th width="77px"><asp:Label ID="Label14" runat="server" Text="¿Asignado?" CssClass="tituloGrilla"></asp:Label></th>
            <th width="80px"><asp:Label ID="Label15" runat="server" Text="Error" CssClass="tituloGrilla"></asp:Label></th>
            
             </tr>
 </table>
</div>

    <div style="height:450px;overflow:auto;">
        <asp:GridView ID="grvPersonal" runat="server" CssClass="mGrid" AutoGenerateColumns="False"
                             CellPadding="4" ForeColor="#333333" GridLines="None" ShowHeader="false" >
                            <RowStyle HorizontalAlign="Left" BackColor="#E3EAEB" />
                            <Columns>
                                <asp:BoundField DataField="Nombres" HeaderText="Nombres" ReadOnly="true" 
                                    HeaderStyle-HorizontalAlign="Left" >
                                    <HeaderStyle HorizontalAlign="Left" Width="280px" />
                                    <ItemStyle Width="280px" HorizontalAlign="Left"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="co_trabajador_id" HeaderText="Cod. Trabajador" 
                                    HeaderStyle-HorizontalAlign="Left" >
                                    <HeaderStyle HorizontalAlign="Left" Width="85px"/>
                                    <ItemStyle Width="85px" HorizontalAlign="Left"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha" ReadOnly="true" HeaderStyle-HorizontalAlign="Left"
                                    DataFormatString="{0:dd/MM/yyyy}" >
                                    <HeaderStyle HorizontalAlign="Left" Width="90px"/>
                                    <ItemStyle Width="90px" HorizontalAlign="Left"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="Hora_ingreso" HeaderText="H. Ingreso" 
                                    ReadOnly="true" HeaderStyle-HorizontalAlign="Left"
                                    DataFormatString="{0:HH:mm}" >
                                    <HeaderStyle HorizontalAlign="Left" Width="45px"/>
                                    <ItemStyle Width="45px" HorizontalAlign="Left"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="Hora_salida" HeaderText="H. Salida" ReadOnly="true" HeaderStyle-HorizontalAlign="Left"
                                    DataFormatString="{0:HH:mm}" >
                                    <HeaderStyle HorizontalAlign="Left" Width="45px"/>
                                    <ItemStyle Width="45px" HorizontalAlign="Left"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="fecha_registro" HeaderText="Fecha Registro" ReadOnly="true"
                                    HeaderStyle-HorizontalAlign="Left" DataFormatString="{0:dd/MM/yyyy}" >
                                   <HeaderStyle HorizontalAlign="Left" Width="90px"/>
                                    <ItemStyle Width="90px" HorizontalAlign="Left"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="asignado" HeaderText="Asignado?" ReadOnly="true" 
                                    HeaderStyle-HorizontalAlign="Left" >
                                    <HeaderStyle HorizontalAlign="Left" Width="80px"/>
                                    <ItemStyle Width="80px" HorizontalAlign="Left"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="mensaje_error" HeaderText="Error" ReadOnly="true"
                                    HeaderStyle-HorizontalAlign="Left" >
                                    <HeaderStyle HorizontalAlign="Left" Width="85px"/>
                                    <ItemStyle Width="85px" HorizontalAlign="Left"/>
                                </asp:BoundField>
                            </Columns>
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#7C6F57" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                        </div>
 </td>
</tr>

</table>
</asp:Panel>
    
<script src="../../jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../jqueryui/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
     <script src="Scripts/Script_CARegistrarMarcaciones.js" type="text/javascript"></script>

    <script type="text/javascript">
           Get_Periodo_Asistencia_List();


    </script>

</asp:Content>
