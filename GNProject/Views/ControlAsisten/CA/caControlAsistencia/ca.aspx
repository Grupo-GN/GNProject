<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ca.aspx.cs" Inherits="GNProject.Views.ControlAsisten.CA.caControlAsistencia.ca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />
    <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"  type="text/css" />
  
<style>

input[type=text], select {
  width: 80%;
  padding: 4px 12px;
  margin: 8px 0;
  display: inline-block;
  border: 1px solid #ccc;
  border-radius: 4px;
  box-sizing: border-box;
}

/*div {
  border-radius: 5px;
  background-color: #f2f2f2;
  padding: 1px;
}*/

            .auto-style1 {
                height: 59px;
            }

    </style>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <fieldset>
    <legend class="miTituloField">FILTROS</legend>

        <%-- inicio de filtros --%>
        <table class="tableDialog">
        <%-- nuevo --%>
                <tr>
            <td style="width:200px;text-align:right;">
                <label class="miLabel">Planilla : </label></td>
            <td class="auto-style1">
                &nbsp;
                   <asp:DropDownList ID="cboPlanilla" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cboPlanilla_SelectedIndexChanged" >
                </asp:DropDownList>
            </td>
            <td style="text-align:right;"><label class="miLabel">Periodo : </label></td>
            <td>
                <asp:DropDownList ID="CmbPeridos" runat="server" AutoPostBack="True" ></asp:DropDownList>
                
            </td>
            <td style="text-align:right;"></td>
            <td>
            <asp:Button ID="btnCalcularHE" runat="server"  class="submit" Text="Calcular H.E dentro del Rango" 
                    onclick="btnCalcularHE_Click" Width="233px" />
            </td>
        </tr>
        <%-- fin --%>
        <tr>
            <td style="width:200px;text-align:right;"><label class="miLabel">Fecha Inicio : </label></td>
            <td class="auto-style1">
                <asp:TextBox ID="txtfechaini" runat="server" 
                    ontextchanged="txtfechaini_TextChanged" AutoPostBack="True"></asp:TextBox>
            </td>
            <td style="text-align:right;">
                <label class="miLabel">FECHA FIN : </label></td>
            <td>
                <asp:TextBox ID="txtfechafin" runat="server" CssClass="txt" 
                    ontextchanged="txtfechafin_TextChanged" AutoPostBack="True"></asp:TextBox>
            </td>
            <td style="text-align:right;"></td>
            <td>
                <asp:Button ID="btnRecalcular" runat="server"  class="submit" Text="Reprocesar Marcaciones" 
                    Width="233px" OnClick="btnRecalcular_Click" />
            </td>
        </tr>
        <tr>
            <td style="text-align:right;" class="auto-style1"><label class="miLabel">Localidad : </label></td>
            <td class="auto-style1">
                <asp:DropDownList ID="cboLocalidad" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="cboLocalidad_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td style="text-align:right;" class="auto-style1"><label class="miLabel">Personal : </label></td>
            <td class="auto-style1">
                <asp:DropDownList ID="cboPersonal" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="cboPersonal_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td style="text-align:right;" class="auto-style1"></td>
             <td class="auto-style1">
                 <asp:CheckBox ID="chkreprocesar" runat="server"  Text="Reprocesar Faltas" /> &nbsp;<asp:Button  runat="server" class="submit" Text="...." id="btnmos" style="width:10%"    OnClick="btnmos_Click" /><br />
                <asp:Button ID="btnFalta" runat="server"  class="submit" Text="Reasignar Falta" 
                    Width="233px" OnClick="btnFalta_Click"/>
            </td>
        </tr>
        <tr>
            <td style="text-align:right;"><label class="miLabel">Reemplazar Ingreso o Salida : </label></td>
            <td colspan="3" style="text-align:center;">
                <table style="width:100%;border-collapse:collapse;">
                    <tr>
                        <td style="width:150px;">
                            <asp:RadioButtonList ID="rbtipo" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="1">Ingreso</asp:ListItem>
                                <asp:ListItem Value="2">Salida</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td style="width:70px;">
                            <asp:TextBox ID="txthoramod" runat="server" CssClass="textbox" MaxLength="5" Width="50px"></asp:TextBox>
                        </td>
                        <td><asp:Button ID="btnactu" runat="server" Text="Actualizar" class="submit" OnClientClick="return confirm('¿Está seguro(a) de continuar?');" OnClick="btnactu_Click" /></td>
                    </tr>
                </table>
            </td>            
            <td style="text-align:right;">&nbsp;</td>
            <td>
                <asp:Button ID="btnelimina" runat="server" class="submit"   Text="Eliminar Registro" Width="233px" OnClick="btnelimina_Click" />
            </td>
        </tr>
        <tr>
            <td style="text-align:right;"><label class="miLabel">Asignar C. Costo : </label></td>
            <td class="auto-style1">
                <asp:DropDownList ID="cboAsigCC" runat="server" >
                </asp:DropDownList>
                <asp:Button ID="btnAsig1" runat="server" Text="Asignar" class="submit" OnClientClick="return confirm('¿Está seguro(a) de continuar?');" OnClick="btnAsig1_Click"/>
                &nbsp;
                </td>
            <td style="text-align:right;"><label class="miLabel">Asignar Turno : </label></td>
            <td>
                <asp:DropDownList ID="cboAsigTurno" runat="server" >
                </asp:DropDownList>
                &nbsp;
                <asp:Button ID="btnAsig2" runat="server" Text="Asignar" class="submit" OnClientClick="return confirm('¿Está seguro(a) de continuar?');" OnClick="btnAsig2_Click"/>
            </td>
            <td style="text-align:right;">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <%--<table class="tableDialog">
        <tr>
            <td style="width:200px;text-align:right;"><label class="miLabel">Fecha : </label></td>
            <td>
                <asp:TextBox ID="txtfechaini" runat="server" CssClass="txt" 
                    ontextchanged="txtfechaini_TextChanged" AutoPostBack="True"></asp:TextBox>
            </td>
            <td style="text-align:right;"><label class="miLabel">Periodo : </label></td>
            <td>
                <asp:TextBox ID="txtfechafin" runat="server" CssClass="txt" 
                    ontextchanged="txtfechafin_TextChanged" AutoPostBack="True"></asp:TextBox>
            </td>
            <td style="text-align:right;"></td>
            <td>
                <asp:Button ID="btnCalcularHE" runat="server" Text="Calcular H.E dentro del Rango" 
                    onclick="btnCalcularHE_Click" />
            </td>
        </tr>
        <tr>
            <td style="text-align:right;"><label class="miLabel">Localidad : </label></td>
            <td>
                <asp:DropDownList ID="cboLocalidad" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="cboLocalidad_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td style="text-align:right;"><label class="miLabel">Personal : </label></td>
            <td>
                <asp:DropDownList ID="cboPersonal" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="cboPersonal_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td style="text-align:right;"></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align:right;"><label class="miLabel">Reemplazar Ingreso o Salida : </label></td>
            <td colspan="3" style="text-align:center;">
                <table style="width:100%;border-collapse:collapse;">
                    <tr>
                        <td style="width:150px;">
                            <asp:RadioButtonList ID="rbtipo" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="1">Ingreso</asp:ListItem>
                                <asp:ListItem Value="2">Salida</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td style="width:70px;">
                            <asp:TextBox ID="txthoramod" runat="server" CssClass="textbox" MaxLength="5" Width="50px"></asp:TextBox>
                        </td>
                        <td><asp:Button ID="btnactu" runat="server" Text="Actualizar" CssClass="button" OnClientClick="return confirm('¿Está seguro(a) de continuar?');" OnClick="btnactu_Click" /></td>
                    </tr>
                </table>
            </td>            
            <td style="text-align:right;">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align:right;"><label class="miLabel">Asignar C. Costo : </label></td>
            <td>
                <asp:DropDownList ID="cboAsigCC" runat="server" >
                </asp:DropDownList>
                &nbsp;
                <asp:Button ID="btnAsig1" runat="server" Text="Asignar" CssClass="button" OnClientClick="return confirm('¿Está seguro(a) de continuar?');" OnClick="btnAsig1_Click"/>
            </td>
            <td style="text-align:right;"><label class="miLabel">Asignar Turno : </label></td>
            <td>
                <asp:DropDownList ID="cboAsigTurno" runat="server" >
                </asp:DropDownList>
                &nbsp;
                <asp:Button ID="btnAsig2" runat="server" Text="Asignar" CssClass="button" OnClientClick="return confirm('¿Está seguro(a) de continuar?');" OnClick="btnAsig2_Click"/>
            </td>
            <td style="text-align:right;">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>--%>
        <%-- fin de filtros --%>
        <asp:Panel ID="pnl01" runat="server">

   
                    <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" ForeColor="Red" 
                    CssClass="labelError"></asp:Label>
                <asp:Label ID="lblMensajeEH" runat="server" Text=""></asp:Label>
    <hr />
<%-- grilla CssClass="gridSmall"  --%>
                    <asp:GridView ID="gvAsistencia" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" CellPadding="4" 
                    DataKeyNames="Asistencia_id,ccosto_id,Turno_Id" Font-Names="Arial" Font-Size="8pt" 
                    ForeColor="#333333"  Width="100%" PageSize="25" 
        onrowcancelingedit="gvAsistencia_RowCancelingEdit" 
        onrowediting="gvAsistencia_RowEditing" 
        onrowupdating="gvAsistencia_RowUpdating" 
        onpageindexchanging="gvAsistencia_PageIndexChanging" OnRowDataBound="gvAsistencia_RowDataBound">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox ID="chktodos" runat="server"  onclick="SelectAllCheckBoxes(this , 'gvAsistencia')"/>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chksel" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Asistencia_id" HeaderText="Id" ReadOnly="True">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />
                            <ItemStyle Width="35px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Fecha_asistencia" HeaderText="Fecha" ReadOnly="True">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                            <ItemStyle Width="60px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Apellidos y Nombres" 
                            HeaderText="APELLIDOS Y NOMBRES" ReadOnly="True">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="180px" />
                            <ItemStyle HorizontalAlign="Left" Width="220px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Hora Ingreso">
                            <ItemTemplate>
                                <asp:Label ID="lblHraIngreso" runat="server" Width="60px"
                                    Text='<%# Eval("Hora_Ingreso_modificado") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtHraIngreso" runat="server" CssClass="textbox" MaxLength="5" Text='<%# Eval("Hora_Ingreso_modificado") %>' 
                                    ToolTip='<%# Eval("Asistencia_id") %>' Width="60px"></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderStyle Width="25px" />
                            <ItemStyle Width="25px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hora Salida">
                            <ItemTemplate>
                                <asp:Label ID="lblHraSalida" runat="server"  Width="60px"
                                    Text='<%# Eval("Hora_salida_modificado") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtHraSalida" runat="server" CssClass="textbox" 
                                    ForeColor="Black" 
                                    Text='<%# Eval("Hora_salida_modificado") %>' 
                                    ToolTip='<%# Eval("Asistencia_id") %>' Width="60px"></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderStyle Width="25px" />
                            <ItemStyle Width="25px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Total Hora" HeaderText="Horas Trabajadas" 
                            ReadOnly="True">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="25px" />
                            <ItemStyle HorizontalAlign="Left" Width="25px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="HETotal" HeaderText="H. E. Total" ReadOnly="True">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="25px" />
                            <ItemStyle HorizontalAlign="Left" Width="25px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="HESimples" HeaderText="H. E. Simple" ReadOnly="True">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="25px" />
                            <ItemStyle HorizontalAlign="Left" Width="25px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="HEAdicional" HeaderText="H. E. Adicional" 
                            ReadOnly="True">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="25px" />
                            <ItemStyle HorizontalAlign="Left" Width="25px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="HEDoble" HeaderText="H. E. Doble" ReadOnly="True">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="25px" />
                            <ItemStyle HorizontalAlign="Left" Width="25px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="C. Costo">
                            <ItemTemplate>
                                <asp:Label ID="lblccosto" runat="server" Text='<%# Eval("Ccosto_Id")%>'> </asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="cboccosto" runat="server" CssClass="ddl">
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Turno">
                            <ItemTemplate>
                                <asp:Label ID="lblturno" runat="server" Text='<%# Eval("Turno_Id")%>'> </asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="cboturno" runat="server" CssClass="ddl">
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Observaciones">
                            <ItemTemplate>
                                <asp:Label ID="lblObservaciones" runat="server" 
                                    Text='<%# Eval("observaciones") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtObservaciones" runat="server" CssClass="textbox" 
                                    Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" 
                                    Text='<%# Eval("observaciones") %>' TextMode="MultiLine" Width="99%"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Edit">
                            <ItemTemplate>
                                <asp:ImageButton ID="Edit" runat="server" CommandName="Edit" 
                                    ImageUrl="~/Icon/Modify.gif" ToolTip="Editar" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:ImageButton ID="Update" runat="server" CommandName="Update" 
                                    ImageUrl="~/Icon/Save.gif" ToolTip="Grabar" Width="16px" />
                                <asp:ImageButton ID="Cancel" runat="server" CommandName="Cancel" 
                                    ImageUrl="~/Icon/delete.gif" ToolTip="Cancelar" />
                            </EditItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle Width="50px" />
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle BackColor="#E3EAEB" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <FooterStyle BackColor="#347aca" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#347aca" CssClass="pgr" ForeColor="White" 
                        HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#347aca" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#347aca" />
                    <AlternatingRowStyle BackColor="White" CssClass="alt" />
                </asp:GridView>



<%-- grilla --%>
     </asp:Panel>
            <asp:Panel ID="pnl02" runat="server" Visible="False">

              
 <section id="dialog-JustPropuesta" title="Verificar Justificación">
       <asp:Button ID="Button1" runat="server"  class="submit" Text="regresar al listado" 
                    Width="233px" OnClick="Button1_Click"     />
     <br />
        <br />
        <div class="tableDialog">
           <asp:GridView ID="dgvfalta" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" CellPadding="4" 
                    DataKeyNames="id_registro_asistencia,Fecha_falta" Font-Names="Arial" Font-Size="8pt" 
                    ForeColor="#333333"   PageSize="25" >
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox ID="chktodos" runat="server"  onclick="SelectAllCheckBoxes(this , 'dgvfalta')"/>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chksel" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="id_registro_asistencia" HeaderText="Id" ReadOnly="True">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />
                            <ItemStyle Width="35px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Personal_Id" 
                            HeaderText="Personal_Id" Visible="False">
                        </asp:BoundField>
                        <asp:BoundField DataField="co_trabajador_id" HeaderText="co_trabajador_id" Visible="False" />
                        <asp:BoundField DataField="nombres" HeaderText="APELLIDOS Y NOMBRES" ReadOnly="True">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="180px" />
                        <ItemStyle HorizontalAlign="Left" Width="220px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Fecha_falta" HeaderText="Fecha" ReadOnly="True" DataFormatString="{0:d}">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                            <ItemStyle Width="60px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="fecha_registro" HeaderText="Fecha Registro" />
                    </Columns>
                    <RowStyle BackColor="#E3EAEB" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <FooterStyle BackColor="#347aca" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#347aca" CssClass="pgr" ForeColor="White" 
                        HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#347aca" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#347aca" />
                    <AlternatingRowStyle BackColor="White" CssClass="alt" />
                </asp:GridView>
        </div>
  
    </section>
    </asp:Panel>            
</fieldset>
</ContentTemplate>
    </asp:UpdatePanel>
<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1">                       
            <ProgressTemplate>
            <div class="UpdateProgressModalBackground">
            <center>                                            
                <div class="UpdateProgressPanel">
                Cargando...<br /><br />
                    <asp:Image ID="Image2" runat="server" 
                        alt="Procesando" ImageUrl="~/Icon/loader.gif" /> 
                                             
                </div> 
            </center></div>
            </ProgressTemplate>
                                        
</asp:UpdateProgress>
    <script src="../../jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../jqueryui/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#dialog-JustPropuesta').hide();
            function openD() {
                var nick = $('#<%=chkreprocesar.ClientID%>').val();
                if (nick==true) {
                    $('#dialog-JustPropuesta').dialog({
                    autoOpen: true,
                    modal: true,
                    width: 1000,
                    height: 500,
                    show: { effect: "fade", duration: 800 },
                    hide: { effect: "explode", duration: 800 }
                });
                }
               
            };
            $('#btnmos').click(function () {
                openD();
            });

            $('#btnSalirs').click(function () {
                $('#dialog-JustPropuesta').dialog('close');
            });
            setInterval(function () {

                var widget = $('#ContentPlaceHolder1_txtfechaini').datepicker('getDate');
                if (widget == null) {

                    $('#ContentPlaceHolder1_txtfechaini').datepicker({
                        monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
		    'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
                        monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun',
		        'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
                        dayNames: ['Domingo', 'Lunes', 'Martes', 'Mi&eacute;rcoles', 'Jueves', 'Viernes', 'S&aacute;bado'],
                        dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mi&eacute;', 'Juv', 'Vie', 'S&aacute;b'],
                        dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'S&aacute;'],
                        dateFormat: 'dd/mm/yy',
                        isRTL: false
                    });

                    $('#ContentPlaceHolder1_txtfechafin').datepicker({
                        monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
		    'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
                        monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun',
		        'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
                        dayNames: ['Domingo', 'Lunes', 'Martes', 'Mi&eacute;rcoles', 'Jueves', 'Viernes', 'S&aacute;bado'],
                        dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mi&eacute;', 'Juv', 'Vie', 'S&aacute;b'],
                        dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'S&aacute;'],
                        dateFormat: 'dd/mm/yy',
                        isRTL: false
                    });
                }

            }, 1000);
        });
    </script>

</asp:Content>
