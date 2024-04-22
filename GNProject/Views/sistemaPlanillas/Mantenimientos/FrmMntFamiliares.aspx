<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmMntFamiliares.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Mantenimientos.FrmMntFamiliares" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register src="../UserControl/ucComboTipoDocumento.ascx" tagname="ucComboTipoDocumento" tagprefix="uc1" %>
<%@ Register src="../UserControl/ucTextBoxFecha.ascx" tagname="ucTextBoxFecha" tagprefix="uc2" %>
<%@ Register src="../UserControl/ucComboSexos.ascx" tagname="ucComboSexos" tagprefix="uc3" %>
<%@ Register src="../UserControl/ucComboEstados.ascx" tagname="ucComboEstados" tagprefix="uc4" %>
<%@ Register src="../UserControl/ucComboPersonal.ascx" tagname="ucComboPersonal" tagprefix="uc5" %>
<%@ Register src="../UserControl/ucComboTipo_Via.ascx" tagname="ucComboTipo_Via" tagprefix="uc6" %>
<%@ Register src="../UserControl/ucTipo_Zona.ascx" tagname="ucTipo_Zona" tagprefix="uc7" %>
<%@ Register src="../UserControl/ucComboDepartamento.ascx" tagname="ucComboDepartamento" tagprefix="uc8" %>
<%@ Register src="../UserControl/ucComboProvincias.ascx" tagname="ucComboProvincias" tagprefix="uc9" %>
<%@ Register src="../UserControl/ucComboDistritos.ascx" tagname="ucComboDistritos" tagprefix="uc10" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<script language="javascript" type="text/javascript">
    function fc_Grabar() {
        var msg = '';
        if (document.getElementById('<%= cboPersonal.ClientID %>_cboPersonal').selectedIndex == 0) {
            msg = msg + '- Seleccionar Personal \n';
            alert(msg);
            document.getElementById('<%= cboPersonal.ClientID %>_cboPersonal').focus();
            return false;
        }
        if (fc_Trim(document.getElementById('<%= txtNombres.ClientID %>').value) == '')
            msg = msg + '- Ingresar Nombres \n';
        if (fc_Trim(document.getElementById('<%= txtApellido_Paterno.ClientID %>').value) == '')
            msg = msg + '- Ingresar Apellido Paterno \n';
        if (fc_Trim(document.getElementById('<%= txtApellido_Materno.ClientID %>').value) == '')
            msg = msg + '- Ingresar Apellido Materno \n';
        if (document.getElementById('<%= cboTipoDocumento.ClientID %>_cboTipoDocumento').selectedIndex == 0)
            msg = msg + '- Seleccionar Tipo de Documento \n';
        if (fc_Trim(document.getElementById('<%= txtNro_Documento.ClientID %>').value) == '')
            msg = msg + '- Ingresar Nro. Documento \n';
        if (document.getElementById('<%= cboSexos.ClientID %>_cboSexos').selectedIndex == 0)
            msg = msg + '- Seleccionar Sexo \n';
        if (fc_Trim(document.getElementById('<%= txtFecha_Nacimiento.ClientID %>_txtFecha').value) == '')
            msg = msg + '- Ingresar Fecha Nacimiento \n';
                
        if (msg != '') {
            alert(msg);
            fc_SetActiveTabIndex('<%= TabContainer1.ClientID %>', 1);
            return false;
        }
        else return true;
    }

    function fc_Actualizar() {
        var msg = '';
        if (document.getElementById('<%= lblFamiliar_Id.ClientID %>').innerText == '') {
            msg = msg + 'Seleccionar un Familiar \n';
            alert(msg);
            fc_SetActiveTabIndex('<%= TabContainer1.ClientID %>', 0);
            return false;
        }
        if (fc_Trim(document.getElementById('<%= txtNombres.ClientID %>').value) == '')
            msg = msg + '- Ingresar Nombres \n';
        if (fc_Trim(document.getElementById('<%= txtApellido_Paterno.ClientID %>').value) == '')
            msg = msg + '- Ingresar Apellido Paterno \n';
        if (fc_Trim(document.getElementById('<%= txtApellido_Materno.ClientID %>').value) == '')
            msg = msg + '- Ingresar Apellido Materno \n';
        if (document.getElementById('<%= cboTipoDocumento.ClientID %>_cboTipoDocumento').selectedIndex == 0)
            msg = msg + '- Seleccionar Tipo de Documento \n';
        if (fc_Trim(document.getElementById('<%= txtNro_Documento.ClientID %>').value) == '')
            msg = msg + '- Ingresar Nro. Documento \n';
        if (document.getElementById('<%= cboSexos.ClientID %>_cboSexos').selectedIndex == 0)
            msg = msg + '- Seleccionar Sexo \n';
        if (fc_Trim(document.getElementById('<%= txtFecha_Nacimiento.ClientID %>_txtFecha').value) == '')
            msg = msg + '- Ingresar Fecha Nacimiento \n';

        if (msg != '') {
            alert(msg);
            fc_SetActiveTabIndex('<%= TabContainer1.ClientID %>', 1);
            return false;
        }
        else return true;
    }

    function fc_Nuevo() {
        var msg = '';
        
        if (document.getElementById('<%= cboPersonal.ClientID %>_cboPersonal').selectedIndex == 0) {
            msg = msg + '- Seleccionar Personal \n';
            alert(msg);
            document.getElementById('<%= cboPersonal.ClientID %>_cboPersonal').focus();
            return false;
        }
        
        /*Limpiar Textos*/
        fc_Limpiar_DatosPrincipales();
        fc_Limpiar_DatosComplementarios();
        
        fc_SetActiveTabIndex('<%= TabContainer1.ClientID %>', 1);
        var indexPersonal = document.getElementById('<%= cboPersonal.ClientID %>_cboPersonal').selectedIndex;
        document.getElementById('<%= lblPersonal.ClientID %>').innerText =
            document.getElementById('<%= cboPersonal.ClientID %>_cboPersonal').options[indexPersonal].text;
        
        return true;
    }

    function fc_Limpiar_DatosPrincipales() {
        /*Limpiar Textos*/
        document.getElementById('<%= lblFamiliar_Id.ClientID %>').innerText = '';
        document.getElementById('<%= lblPersonal.ClientID %>').innerText = '';
        document.getElementById('<%= txtNombres.ClientID %>').value = '';
        document.getElementById('<%= txtApellido_Paterno.ClientID %>').value = '';
        document.getElementById('<%= txtApellido_Materno.ClientID %>').value = '';
        document.getElementById('<%= cboTipoDocumento.ClientID %>_cboTipoDocumento').selectedIndex = 0;
        document.getElementById('<%= txtNro_Documento.ClientID %>').value = '';
        document.getElementById('<%= cboSexos.ClientID %>_cboSexos').selectedIndex = 0;
        document.getElementById('<%= txtFecha_Nacimiento.ClientID %>_txtFecha').value = '';
        document.getElementById('<%= cboVinculo_Familiar.ClientID %>').selectedIndex = 0;
        document.getElementById('<%= ckAfiliado_EPS.ClientID %>').checked = false;

        document.getElementById('<%= pnlAcreditacionDePaternidad.ClientID %>').disabled = true;
        document.getElementById('<%= cboTipo_Doc_Paternidad.ClientID %>').selectedIndex = 0;
        document.getElementById('<%= txtNro_Doc_Paternidad.ClientID %>').value = '';

        document.getElementById('<%= cboEstados.ClientID %>_cboEstados').selectedIndex = 0;
        document.getElementById('<%= txtFecha_Alta.ClientID %>_txtFecha').value = '';
        document.getElementById('<%= txtNro_RD_Incapacidad.ClientID %>').value = '';
    }
    function fc_Limpiar_DatosComplementarios() {
        document.getElementById('<%= ckDomicilio_Propio.ClientID %>').checked = false;
        fc_ActivaPanelDomicilio(false);
        /*Panel Ubicacion*/
        document.getElementById('<%= cboTipo_Via.ClientID %>_cboTipo_Via').selectedIndex = 0;
        document.getElementById('<%= txtNombre_Via.ClientID %>').value = '';
        document.getElementById('<%= txtNumero_Via.ClientID %>').value = '';
        document.getElementById('<%= txtInterior_Via.ClientID %>').value = '';
        document.getElementById('<%= cboTipo_Zona.ClientID %>_cboTipo_Zona').selectedIndex = 0;
        document.getElementById('<%= txtNombre_Zona.ClientID %>').value = '';
        document.getElementById('<%= txtReferencia.ClientID %>').value = '';
        /*Panel Ubigeo*/
        document.getElementById('<%= cboDepartamentos.ClientID %>_cboDepartamentos').selectedIndex = 0;
        for (i = document.getElementById('<%= cboProvincias.ClientID %>_cboProvincias').options.length - 1; i >= 0 ; i--) {
            document.getElementById('<%= cboProvincias.ClientID %>_cboProvincias').remove(i);
        }
        for (i = document.getElementById('<%= cboDistritos.ClientID %>_cboDistritos').options.length - 1; i >= 0; i--) {
            document.getElementById('<%= cboDistritos.ClientID %>_cboDistritos').remove(i);
        }
    }

    function fc_Load() {
        fc_ActivaPanelDomicilio(false);
        fc_ActivaPanelAcreditacion("");
    }

    function fc_ActivaPanelDomicilio(fl_check) {
        //        var check;
        if (fl_check == true)
            fl_check = false;
        else
            fl_check = true;
        document.getElementById('<%= pnlUbicacion.ClientID %>').disabled = fl_check
        document.getElementById('<%= cboTipo_Via.ClientID %>_cboTipo_Via').disabled = fl_check
        document.getElementById('<%= txtNumero_Via.ClientID %>').disabled = fl_check
        document.getElementById('<%= txtInterior_Via.ClientID %>').disabled = fl_check
        document.getElementById('<%= cboTipo_Zona.ClientID %>_cboTipo_Zona').disabled = fl_check
        document.getElementById('<%= txtNombre_Zona.ClientID %>').disabled = fl_check
        document.getElementById('<%= txtReferencia.ClientID %>').disabled = fl_check

        document.getElementById('<%= pnlUbigeo.ClientID %>').disabled = fl_check
        document.getElementById('<%= cboDepartamentos.ClientID %>_cboDepartamentos').disabled = fl_check
        document.getElementById('<%= cboProvincias.ClientID %>_cboProvincias').disabled = fl_check
        document.getElementById('<%= cboDistritos.ClientID %>_cboDistritos').disabled = fl_check
        
    }

    function fc_ActivaPanelAcreditacion(objComboValue) {
        var cod = objComboValue;  //fc_Trim(objCombo.options[objCombo.selectedIndex].value);
        var fl_check;
        if (cod == '04') /*Gestante*/
            fl_check = false;
        else
            fl_check = true;
        document.getElementById('<%= pnlAcreditacionDePaternidad.ClientID %>').disabled = fl_check;
        document.getElementById('<%= cboTipo_Doc_Paternidad.ClientID %>').disabled = fl_check;
        document.getElementById('<%= txtNro_Doc_Paternidad.ClientID %>').disabled = fl_check;
        
        document.getElementById('<%= cboTipo_Doc_Paternidad.ClientID %>').selectedIndex = 0;
        document.getElementById('<%= txtNro_Doc_Paternidad.ClientID %>').value = '';
    }

</script>

    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />
<link href="../Controles/miEstilo.css" rel="stylesheet" type="text/css" />

    <link href="../Styles/nuevoEstiloPlanilla.css" rel="stylesheet" type="text/css" />


     <table align="center" width="100%">
     <tr>
     <td>
        
        <fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px;
           /*border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black;*/ 
            min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; /*border-top: solid 1px black;*/">

<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    

<table width="100%">
    <tr>
    <td style="width:50%;" valign="middle">
     <asp:Label ID="Label9" runat="server" 
    Text="MANTENIMIENTO DE DERECHO HABIENTES" CssClass="miTitulo" Width="300px"></asp:Label>   
    </td>
      <td style="width:50%;" align="right" valign="bottom">
       <asp:Panel ID="Panel1" runat="server" CssClass="elPanel">
    <table>
    <tr>
    <td>
        <asp:Button ID="btnNew" runat="server" Text="Nuevo" 
        CssClass="elBotonNew" Enabled="true" onclick="btnNew_Click"
        OnClientClick="javascript: return fc_Nuevo();" /></td>
    <td>
        <asp:Button ID="btnAdd" runat="server" Text="Grabar" 
        CssClass="elBotonAdd" Enabled="false" onclick="btnAdd_Click"  
        OnClientClick="javascript: return fc_Grabar();"/>
    </td>
    <td>
        <asp:Button ID="btnCancel" runat="server" Text="Cancelar" 
        CssClass="elBotonCancel" Enabled="false" onclick="btnCancel_Click"/></td>
    <td>
        <asp:Button ID="btnUpdate" runat="server" Text="Actualizar" 
        CssClass="elBotonUpdate" Enabled="false" onclick="btnUpdate_Click"
        OnClientClick="javascript: return fc_Actualizar();"/>
        </td>
        <td>
            <asp:Button ID="btnDelete" runat="server" Text="Eliminar" 
            CssClass="elBotonDelete" Enabled="false"/>
        </td>
    </tr>
    </table>
</asp:Panel>
    </td>
   </tr>
    </table>
    
<div>
    <table>
        <tr>
            <td>
                 <asp:Label ID="Label16" runat="server" Text="Seleccione el Nombre del Personal : " 
                Width="175px"  CssClass="miLabel"></asp:Label>
                </td>
            <td>
                <uc5:ucComboPersonal ID="cboPersonal" runat="server" AutoPostBack="true" CssClass="ddl" OnSelectedIndexChanged="cboPersonal_SelectedIndexChanged" />
            </td>
        </tr>
    </table>
</div>

<cc1:TabContainer ID="TabContainer1" Height="400px" runat="server" ActiveTabIndex="0">
    <cc1:TabPanel ID="TabPanel1" HeaderText="Lista" runat="server">    
        <ContentTemplate>

    <table>
        <tr>
            <td> 
            <asp:Label ID="Label1" runat="server" Text="Digite los Nombres : " 
                Width="125px"  CssClass="miLabel"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtFamiliaresBuscar" CssClass="txt" Width="300px" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnFind" runat="server" Text="Buscar"
                CssClass="submit" onclick="btnFind_Click" />
            </td>
            <td>                
            </td>
        </tr>
    </table>


<div id="HeaderDiv" style="overflow: hidden; width: 100%; border:solid 0px #000;">
    <table width="100%" class="gridSmallCabecera">
        <tr>
            <th width="42px"></td>
            <th width="80px"><asp:Label ID="Label10" runat="server" Text="FAMILIAR_ID" CssClass="tituloGrilla"></asp:Label></th>
            <th width="80px"><asp:Label ID="Label2" runat="server" Text="PERSONAL_ID" CssClass="tituloGrilla"></asp:Label></th>
            <th width="300px"><asp:Label ID="Label3" runat="server" Text="APELLIDOS Y NOMBRES" CssClass="tituloGrilla"></asp:Label></th>
            <th width="80px"><asp:Label ID="Label4" runat="server" Text="NRO. DOC" CssClass="tituloGrilla"></asp:Label></th>
            <th width="100px"><asp:Label ID="Label5" runat="server" Text="SEXO" CssClass="tituloGrilla"></asp:Label></th>
            <th width="110px"><asp:Label ID="Label6" runat="server" Text="FEC. NACIMIENTO" CssClass="tituloGrilla"></asp:Label></th>
        </tr>
    </table>
</div>
        
        <div id="DataDiv" onscroll="Onscrollfunction('DataDiv', 'HeaderDiv');"
            style="overflow: auto; width: 100%; height: 35%; border:solid 0px #000;">                
            <asp:GridView ID="grvFamiliares" runat="server" Width="100%"
                ShowHeader="False"
                GridLines="None"
                AutoGenerateColumns="False" CellPadding="2" CssClass="gridSmall" 
                DataKeyNames="Familiar_Id,Personal_Id" ForeColor="#333333"
                PageSize="13"
                onrowcommand="grvFamiliares_RowCommand"
                onrowdeleting="grvFamiliares_RowDeleting" AllowPaging="True"
                onpageindexchanging="grvFamiliares_PageIndexChanging" 
                onrowdatabound="grvFamiliares_RowDataBound">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="ibtnSelect" runat="server" ToolTip="Seleccionar"
                                CommandName="Select" ImageUrl="../Icon/Modify.gif"/>
                            <asp:ImageButton ID="ibtnEliminar" runat="server" ToolTip="Eliminar"
                                CommandName="Delete"  ImageUrl="../Icon/delete.gif" 
                                OnClientClick="return confirm('�Esta Seguro De Eliminar?');" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="45px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Familiar_Id" HeaderText="Familiar_Id" ReadOnly="True">
                        <ItemStyle Width="80px" Height="18px" HorizontalAlign="Center" CssClass="FormatFontGridView" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Personal_Id" HeaderText="Pesonal_Id">
                        <ItemStyle Width="80px" HorizontalAlign="Center" CssClass="FormatFontGridView"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="Nombre_Completo" HeaderText="Apellidos y Nombres">
                        <ItemStyle Width="300px" CssClass="FormatFontGridView"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="Nro_Doc" HeaderText="Nro. Doc.">
                        <ItemStyle Width="80px" HorizontalAlign="Center" CssClass="FormatFontGridView"/>
                    </asp:BoundField>    
                    <asp:BoundField DataField="no_Sexo" HeaderText="Sexo">
                        <ItemStyle Width="100px" HorizontalAlign="Center" CssClass="FormatFontGridView"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="Fecha_Nacimiento" DataFormatString="{0:dd/MM/yyy}" HeaderText="Fec. Nacimiento">
                        <ItemStyle Width="110px" HorizontalAlign="Center" CssClass="FormatFontGridView"/>
                    </asp:BoundField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#9ADBFA" />
            </asp:GridView>
                
        </div>

        </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Datos Principales" Enabled="false">    
        <ContentTemplate>
        
<div class="textoGeneral">
    <table>
        <tr>
            <td width="90px">
                Familiar_Id</td>
            <td colspan="2">
                <asp:Label ID="lblFamiliar_Id" runat="server" Width="70px" Height="18px" CssClass="lblCod"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Personal</td>
            <td colspan="2">
                <asp:Label ID="lblPersonal" runat="server" Width="450px" Height="18px" CssClass="lblCod"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Nombres</td>
            <td colspan="2">
                <asp:TextBox ID="txtNombres" runat="server" CssClass="txt" 
                    Width="450px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtNombres" ErrorMessage="*" Text="*" 
                    ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Apellido Paterno</td>
            <td colspan="2">
                <asp:TextBox ID="txtApellido_Paterno" runat="server" CssClass="txt" 
                    Width="450px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtApellido_Paterno" ErrorMessage="*" Text="*" 
                    ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Apellido Materno</td>
            <td colspan="2">
                <asp:TextBox ID="txtApellido_Materno" runat="server" CssClass="txt" 
                    Width="450px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtApellido_Materno" ErrorMessage="*" Text="*" 
                    ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <table>
                    <tr>
                        <td width="90px">
                            Tipo Documento</td>
                        <td width="250px">
                            <uc1:ucComboTipoDocumento ID="cboTipoDocumento" runat="server" CssClass="ddl" />
                        </td>
                        <td width="100px">
                            Nro. Doc.</td>
                        <td>
                            <asp:TextBox ID="txtNro_Documento" runat="server" CssClass="txt" Width="70px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <table>
                    <tr>
                        <td width="90px">
                            Sexo</td>
                        <td width="250px">
                            <uc3:ucComboSexos ID="cboSexos" runat="server" CssClass="ddl" />
                        </td>
                        <td width="100px">
                            Fecha Nacimiento</td>
                        <td>
                            <uc2:ucTextBoxFecha ID="txtFecha_Nacimiento" runat="server" CssClass="txt" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                Tipo Vinculo</td>
            <td width="100px">
                <asp:DropDownList ID="cboVinculo_Familiar" runat="server" CssClass="ddl"
                    AutoPostBack="True" 
                    onselectedindexchanged="cboVinculo_Familiar_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>
                <asp:CheckBox ID="ckAfiliado_EPS" Text="Afiliado EPS" runat="server" CssClass="ck" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Panel ID="pnlAcreditacionDePaternidad" 
                    GroupingText="ACREDITACI�N DE PATERNIDAD" runat="server">
                    <table>
                        <tr>
                            <td>
                                Tipo Documento</td>
                            <td>
                                <asp:DropDownList ID="cboTipo_Doc_Paternidad" runat="server" CssClass="ddl" Width="450px"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Nro. Doc.</td>
                            <td>
                                <asp:TextBox ID="txtNro_Doc_Paternidad" runat="server" CssClass="txt" Width="70px"></asp:TextBox>

                            </td>
                        </tr>
                    </table>
                </asp:Panel>

            </td>
        </tr>
        <tr>
            <td>
                Estado</td>
            <td colspan="2">
                <uc4:ucComboEstados ID="cboEstados" runat="server" CssClass="ddl" />
                
            </td>
        </tr>
        <tr>
            <td>
                Fec. Alta</td>
            <td colspan="2">
                <uc2:ucTextBoxFecha ID="txtFecha_Alta" runat="server" CssClass="txt" />

            </td>
        </tr>
        <tr>
            <td>
                Nro. RD Incapacidad</td>
            <td colspan="2">
                <asp:TextBox ID="txtNro_RD_Incapacidad" runat="server" CssClass="txt" 
                    Width="450px"></asp:TextBox>
            </td>
        </tr>
    </table>
    
</div>

        </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="Datos Complementarios" Enabled="false">    
        <ContentTemplate>

<div class="textoGeneral">
    <table>
        <tr>
            <td>
                <asp:CheckBox ID="ckDomicilio_Propio" runat="server" Text="Domicilio Propio" CssClass="ck"
                    AutoPostBack="true"
                    oncheckedchanged="ckDomicilio_Propio_CheckedChanged" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlUbicacion" GroupingText="Ubicaci�n" runat="server">
                    <table>
                        <tr>
                            <td>
                                Tipo V�a</td>
                            <td colspan="3">
                                <uc6:ucComboTipo_Via ID="cboTipo_Via" runat="server" CssClass="ddl" Width="200px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Nombre V�a</td>
                            <td colspan="3">
                                <asp:TextBox ID="txtNombre_Via" runat="server" CssClass="txt" Width="250px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                N�mero V�a</td>
                            <td>
                                <asp:TextBox ID="txtNumero_Via" runat="server" CssClass="txt" Width="50px"></asp:TextBox>
                            </td>
                            <td>
                                Interior V�a</td>
                            <td>
                                <asp:TextBox ID="txtInterior_Via" runat="server" CssClass="txt" Width="50px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Tipo Zona</td>
                            <td colspan="3">
                                <uc7:ucTipo_Zona ID="cboTipo_Zona" runat="server" CssClass="ddl" Width="200px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Nombre Zona</td>
                            <td colspan="3">
                                <asp:TextBox ID="txtNombre_Zona" runat="server" CssClass="txt" Width="250px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Referencia</td>
                            <td colspan="3">
                                <asp:TextBox ID="txtReferencia" runat="server" CssClass="txt" Width="250px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlUbigeo" GroupingText="Ubigeo" runat="server">
                    <table>
                        <tr>
                            <td>
                                Departamento
                            </td>
                            <td>
                                <uc8:ucComboDepartamento ID="cboDepartamentos" runat="server" 
                                    CssClass="ddl" Width="200px" AutoPostBack="true" onselectedindexchanged="cboDepartamentos_SelectedIndexChanged" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Provincia
                            </td>
                            <td>
                                <uc9:ucComboProvincias ID="cboProvincias" runat="server" 
                                    CssClass="ddl" Width="200px" AutoPostBack="true" onselectedindexchanged="cboProvincias_SelectedIndexChanged" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Distrito
                            </td>
                            <td>
                                <uc10:ucComboDistritos ID="cboDistritos" runat="server" CssClass="ddl" Width="200px" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</div>

        </ContentTemplate>
    </cc1:TabPanel>
</cc1:TabContainer>

    </ContentTemplate>
</asp:UpdatePanel>

<asp:UpdateProgress ID="UpdateProgress1" runat="server" 
    AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1">
                                        
    <ProgressTemplate>
        <div class="UpdateProgressModalBackground"></div>
        <center>                                            
            <div class="UpdateProgressPanel">
            Cargando...<br /><br />
            <asp:Image ID="Image2" runat="server" 
            alt="Procesando" ImageUrl="~/Views/sistemaPlanillas/css/ajax-loader.gif" /> 
            </div> 
        </center>
    </ProgressTemplate>
                                        
</asp:UpdateProgress>

       </fieldset>
    
         </td>
     </tr>
     </table>



</asp:Content>