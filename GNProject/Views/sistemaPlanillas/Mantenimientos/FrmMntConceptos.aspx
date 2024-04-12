<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmMntConceptos.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Mantenimientos.FrmMntConceptos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script language="javascript" type="text/javascript" src="../js/Script.js"></script>
    <script src="../JQuery/jquery-1.8.2.js" type="text/javascript"></script>
    <script src="../JQuery/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function fc_Grabar() {
            var msg = '';
            if (document.getElementById('<%= txtDescripcion.ClientID %>').value == '')
                msg = msg + 'Ingresar Descripci�n \n';
            if (document.getElementById('<%= rbParamExterno.ClientID %>').checked == false
            && document.getElementById('<%= rbDatoGeneral.ClientID %>').checked == false
            && document.getElementById('<%= rbFormulaStandard.ClientID %>').checked == false
            && document.getElementById('<%= rbFormulaAcumulable.ClientID %>').checked == false
            && document.getElementById('<%= rbDatoFijo.ClientID %>').checked == false
            && document.getElementById('<%= rbDatoVariable.ClientID %>').checked == false
            && document.getElementById('<%= rbFuncionInterna.ClientID %>').checked == false
            && document.getElementById('<%= rbTablaDelSistema.ClientID %>').checked == false) {
                msg = msg + 'Seleccionar un Tipo de Concepto \n';

            }
            if (document.getElementById('<%= rbPorAFP.ClientID %>').checked == false
            && document.getElementById('<%= rbPorPeriodo.ClientID %>').checked == false
            && document.getElementById('<%= rbPorSituacion.ClientID %>').checked == false
            && document.getElementById('<%= rbPorCtaCte.ClientID %>').checked == false
            && document.getElementById('<%= rbPorCompania.ClientID %>').checked == false
            && document.getElementById('<%= rbPorTipoPlanilla.ClientID %>').checked == false
            && document.getElementById('<%= rbPorEPS.ClientID %>').checked == false
            && document.getElementById('<%= rbPorPersonal.ClientID %>').checked == false
            && document.getElementById('<%= rbPorCatAux.ClientID %>').checked == false
            && document.getElementById('<%= rbPorCatAux2.ClientID %>').checked == false
            && document.getElementById('<%= rbPorCatDinamica.ClientID %>').checked == false) {
                msg = msg + 'Seleccionar Origen de Concepto (Unidad Periodica) \n';

            }
            if (msg != '') {
                alert(msg);
                return false;
            }
            else return true;
        }

        function fc_Actualizar() {
            var msg = '';
            if (document.getElementById('<%= lblConcepto_Id.ClientID %>').innerText == '') {
                msg = msg + 'Seleccionar un Concepto \n';
                alert(msg);
                fc_SetActiveTabIndex('<%= TabContainer1.ClientID %>', 0);
                return false;
            }
            if (document.getElementById('<%= txtDescripcion.ClientID %>').value == '')
                msg = msg + 'Ingresar Descripci�n \n';
            if (document.getElementById('<%= rbParamExterno.ClientID %>').checked == false
            && document.getElementById('<%= rbDatoGeneral.ClientID %>').checked == false
            && document.getElementById('<%= rbFormulaStandard.ClientID %>').checked == false
            && document.getElementById('<%= rbFormulaAcumulable.ClientID %>').checked == false
            && document.getElementById('<%= rbDatoFijo.ClientID %>').checked == false
            && document.getElementById('<%= rbDatoVariable.ClientID %>').checked == false
            && document.getElementById('<%= rbFuncionInterna.ClientID %>').checked == false
            && document.getElementById('<%= rbTablaDelSistema.ClientID %>').checked == false) {
                msg = msg + 'Seleccionar un Tipo de Concepto \n';

            }
            if (document.getElementById('<%= rbPorAFP.ClientID %>').checked == false
            && document.getElementById('<%= rbPorPeriodo.ClientID %>').checked == false
            && document.getElementById('<%= rbPorSituacion.ClientID %>').checked == false
            && document.getElementById('<%= rbPorCtaCte.ClientID %>').checked == false
            && document.getElementById('<%= rbPorCompania.ClientID %>').checked == false
            && document.getElementById('<%= rbPorTipoPlanilla.ClientID %>').checked == false
            && document.getElementById('<%= rbPorEPS.ClientID %>').checked == false
            && document.getElementById('<%= rbPorPersonal.ClientID %>').checked == false
            && document.getElementById('<%= rbPorCatAux.ClientID %>').checked == false
            && document.getElementById('<%= rbPorCatAux2.ClientID %>').checked == false
            && document.getElementById('<%= rbPorCatDinamica.ClientID %>').checked == false) {
                msg = msg + 'Seleccionar Origen de Concepto (Unidad Periodica) \n';

            }
            if (msg != '') {
                alert(msg);
                return false;
            }
            else return true;
        }

//////        function enableEstructura() {
//////            var estructura = document.getElementById('<=cboInterfaz.ClientID >').value;
//////            if (estructura == '00') {
//////                document.getElementById('cboEstructura.ClientID ').disabled = true;
//////                document.getElementById('cboEstructura.ClientID ').value = "00";
//////            } else if (estructura == "01") {
//////                document.getElementById('cboEstructura.ClientID ').disabled = false;
//////                document.getElementById('<=cboEstructura.ClientID ').focus();
//////            }
//////        }

    </script>
    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />
    <link href="../Controles/miEstilo.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/nuevoEstiloPlanilla.css" rel="stylesheet" type="text/css" />
    <table align="center" width="100%">
        <tr>
            <td>
                <fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px; /*border-right: solid 1px black;
                    border-left: solid 1px black; border-bottom: solid 1px black;*/ min-height: 500px;
                    overflow: hidden; border-radius: 8px 8px 0px 0px; /*border-top: solid 1px black;*/">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="width: 50%;" valign="middle">
                                        <asp:Label ID="Label9" runat="server" Text="MANTENIMIENTO DE CONCEPTOS" CssClass="miTitulo"
                                            Width="300px"></asp:Label>
                                    </td>
                                    <td style="width: 50%;" align="right" valign="bottom">
                                        <asp:Panel ID="Panel1" runat="server" CssClass="elPanel">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnNew" runat="server" Text="Nuevo" CssClass="elBotonNew" Enabled="true"
                                                            OnClick="btnNew_Click" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnAdd" runat="server" Text="Grabar" CssClass="elBotonAdd" Enabled="false"
                                                            OnClick="btnAdd_Click" OnClientClick="javascript: return fc_Grabar();" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnCancel" runat="server" Text="Cancelar" CssClass="elBotonCancel"
                                                            Enabled="false" OnClick="btnCancel_Click" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnUpdate" runat="server" Text="Actualizar" CssClass="elBotonUpdate"
                                                            Enabled="false" OnClick="btnUpdate_Click" OnClientClick="javascript: return fc_Actualizar();" />
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
                            <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="3" Width="100%"
                                Height="500px">
                                <cc1:TabPanel ID="TabPanel1" HeaderText="Lista" runat="server">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label16" runat="server" Text="Digite Parte del Concepto : " Width="125px"
                                                        CssClass="miLabel"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtConceptosBuscar" runat="server" CssClass="miTextBox"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="submit" OnClick="btnBuscar_Click"
                                                        ToolTip="Digite un Concepto y de Click en Buscar" />
                                                </td>
                                            </tr>
                                        </table>
                                        <div id="HeaderDiv" style="overflow: auto; width: 100%; border: solid 0px #000;">
                                            <table width="100%" class="gridSmallCabecera">
                                                <tr>
                                                    <th width="36px">
                                                        </td><th width="76px">
                                                            <asp:Label ID="Label10" runat="server" Text="ID" CssClass="tituloGrilla"></asp:Label>
                                                        </th>
                                                        <th width="300px">
                                                            <asp:Label ID="Label11" runat="server" Text="DESCRIPCION" CssClass="tituloGrilla"></asp:Label>
                                                        </th>
                                                        <th width="200px">
                                                            <asp:Label ID="Label12" runat="server" Text="DETALLE" CssClass="tituloGrilla"></asp:Label>
                                                        </th>
                                                        <th width="300px">
                                                            <asp:Label ID="Label13" runat="server" Text="COMENTARIO" CssClass="tituloGrilla"></asp:Label>
                                                        </th>
                                                        <th width="100px">
                                                            <asp:Label ID="Label14" runat="server" Text="NOMBRE ABR." CssClass="tituloGrilla"></asp:Label>
                                                        </th>
                                                        <th width="100px">
                                                            <asp:Label ID="Label15" runat="server" Text="CODIGO AUXILIAR" CssClass="tituloGrilla"></asp:Label>
                                                        </th>
                                                    </th>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="DataDiv" onscroll="Onscrollfunction('DataDiv', 'HeaderDiv');" style="overflow: auto;
                                            width: 100%; height: 35%; border: solid 0px #000;">
                                            <asp:GridView ID="grvConceptos" runat="server" Width="100%" ShowHeader="False" AutoGenerateColumns="False"
                                                CellPadding="1" CssClass="gridSmall" DataKeyNames="Concepto_Id" ForeColor="#333333"
                                                GridLines="None" PageSize="12" OnRowCommand="grvConceptos_RowCommand" OnRowDeleting="grvConceptos_RowDeleting"
                                                AllowPaging="True" OnPageIndexChanging="grvConceptos_PageIndexChanging" OnRowDataBound="grvConceptos_RowDataBound">
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ibtnSelect" runat="server" ToolTip="Seleccionar" CommandName="Select"
                                                                ImageUrl="../Icon/Modify.gif" /><asp:ImageButton ID="ibtnEliminar" runat="server"
                                                                    ToolTip="Eliminar" CommandName="Delete" ImageUrl="../Icon/delete.gif" OnClientClick="return confirm('�Esta Seguro De Eliminar?');" /></ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="40px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Concepto_Id" HeaderText="Concepto_Id" ReadOnly="True">
                                                        <ItemStyle Width="80px" HorizontalAlign="Center" CssClass="FormatFontGridView" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripci�n">
                                                        <ItemStyle Width="300px" CssClass="FormatFontGridView" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Detalle" HeaderText="Detalle">
                                                        <ItemStyle Width="200px" CssClass="FormatFontGridView" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Comentario" HeaderText="Comentario">
                                                        <ItemStyle Width="300px" CssClass="FormatFontGridView" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Nombre_Abrev" HeaderText="Nombre Abrev.">
                                                        <ItemStyle Width="100px" CssClass="FormatFontGridView" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Codigo_Auxiliar" HeaderText="Codigo Auxiliar">
                                                        <ItemStyle Width="100px" />
                                                    </asp:BoundField>
                                                </Columns>
                                                <EditRowStyle BackColor="#999999" />
                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#3A4F63" ForeColor="White" HorizontalAlign="Center" />
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
                                                    <td>
                                                        Concepto_Id
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblConcepto_Id" runat="server" Width="50px" Height="18px" CssClass="lblCod"></asp:Label>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Nombre
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="txt" Width="300px"></asp:TextBox><asp:RequiredFieldValidator
                                                            ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDescripcion"
                                                            ErrorMessage="*" Text="*" ValidationGroup="ValidaGraba"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                        Estado
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="cboEstado" runat="server" CssClass="ddl" Width="100px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Detalle
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDetalle" runat="server" CssClass="txt" Width="300px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        Abrev.
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtNombre_Abrev" runat="server" CssClass="txt" Width="100px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table>
                                                <tr>
                                                    <td valign="top">
                                                        <asp:Panel ID="pnlTipos" runat="server" GroupingText="TIPOS">
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="rbParamExterno" GroupName="Tipo_Dato" Text="PARAMETRO EXTERNO"
                                                                            runat="server" CssClass="rb" ForeColor="#CC66FF" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label1" runat="server" CssClass="ac" Text="P" Width="20px" BackColor="#CCCCCC"
                                                                            ForeColor="#CC66FF"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="rbDatoGeneral" GroupName="Tipo_Dato" Text="DATO GENERAL" runat="server"
                                                                            CssClass="rb" ForeColor="#CC66FF" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label2" runat="server" CssClass="ac" Text="G" Width="20px" BackColor="#CCCCCC"
                                                                            ForeColor="#CC66FF"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="rbFormulaStandard" GroupName="Tipo_Dato" Text="FORMULA" runat="server"
                                                                            CssClass="rb" ForeColor="#660066" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label3" runat="server" CssClass="ac" Text="F" Width="20px" BackColor="#BA64C6"
                                                                            ForeColor="White"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="rbFormulaAcumulable" GroupName="Tipo_Dato" Text="FORMULA ACUMULABLE"
                                                                            runat="server" CssClass="rb" ForeColor="#660066" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label4" runat="server" CssClass="ac" Text="A" Width="20px" BackColor="#BA64C6"
                                                                            ForeColor="White"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="rbDatoFijo" GroupName="Tipo_Dato" Text="DATO FIJO" runat="server"
                                                                            CssClass="rb" ForeColor="#660066" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label5" runat="server" CssClass="ac" Text="D" Width="20px" BackColor="#BA64C6"
                                                                            ForeColor="White"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="rbDatoVariable" GroupName="Tipo_Dato" Text="DATO VARIABLE" runat="server"
                                                                            CssClass="rb" ForeColor="#660066" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label6" runat="server" CssClass="ac" Text="V" Width="20px" BackColor="#BA64C6"
                                                                            ForeColor="White"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="rbFuncionInterna" GroupName="Tipo_Dato" Text="FUNCI�N VARIABLE"
                                                                            runat="server" CssClass="rb" ForeColor="#660066" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label7" runat="server" CssClass="ac" Text="I" Width="20px" BackColor="#BA64C6"
                                                                            ForeColor="White"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="rbTablaDelSistema" GroupName="Tipo_Dato" Text="TABLA DEL SISTEMA"
                                                                            runat="server" CssClass="rb" ForeColor="#660066" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label8" runat="server" CssClass="ac" Text="T" Width="20px" BackColor="#BA64C6"
                                                                            ForeColor="White"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:Panel ID="pnlUnidPeriodica" runat="server" GroupingText="UNIDAD PERIODICA">
                                                            <table>
                                                                <tr>
                                                                    <td class="style1">
                                                                        <asp:RadioButton ID="rbPorAFP" GroupName="Origen_Concepto" Text="POR AFP" runat="server"
                                                                            Width="150px" CssClass="rb" ForeColor="#CC66FF" BackColor="#CCCCCC" />
                                                                    </td>
                                                                    <td class="style1">
                                                                        <asp:RadioButton ID="rbPorCatAux" GroupName="Origen_Concepto" Text="POR CATEG. AUX1"
                                                                            runat="server" Width="150px" CssClass="rb" ForeColor="#CC66FF" BackColor="#CCCCCC" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="rbPorPeriodo" GroupName="Origen_Concepto" Text="POR PERIODO"
                                                                            runat="server" Width="150px" CssClass="rb" ForeColor="#CC66FF" BackColor="#CCCCCC" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:RadioButton ID="rbPorCatAux2" GroupName="Origen_Concepto" Text="POR CATEG. AUX2"
                                                                            runat="server" Width="150px" CssClass="rb" ForeColor="#CC66FF" BackColor="#CCCCCC" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="rbPorSituacion" GroupName="Origen_Concepto" Text="POR SITUACION"
                                                                            runat="server" Width="150px" CssClass="rb" ForeColor="#CC66FF" BackColor="#CCCCCC" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:RadioButton ID="rbPorCatDinamica" GroupName="Origen_Concepto" Text="POR CAT. DIN�MICAS"
                                                                            runat="server" Width="150px" CssClass="rb" ForeColor="#CC66FF" BackColor="#CCCCCC" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="rbPorCtaCte" GroupName="Origen_Concepto" Text="POR CTA-CTE"
                                                                            runat="server" Width="150px" CssClass="rb" ForeColor="#CC66FF" BackColor="#CCCCCC" />
                                                                    </td>
                                                                    <td>
                                                                        &#160;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="rbPorCompania" GroupName="Origen_Concepto" Text="POR COMPA�IA"
                                                                            runat="server" Width="150px" CssClass="rb" ForeColor="#CC66FF" BackColor="#CCCCCC" />
                                                                    </td>
                                                                    <td>
                                                                        &#160;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="rbPorTipoPlanilla" GroupName="Origen_Concepto" Text="POR TIPO PLANILLA"
                                                                            runat="server" Width="150px" CssClass="rb" ForeColor="#CC66FF" BackColor="#CCCCCC" />
                                                                    </td>
                                                                    <td>
                                                                        &#160;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="rbPorEPS" GroupName="Origen_Concepto" Text="POR EPS" runat="server"
                                                                            Width="150px" CssClass="rb" ForeColor="#CC66FF" BackColor="#CCCCCC" />
                                                                    </td>
                                                                    <td>
                                                                        &#160;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="rbPorPersonal" GroupName="Origen_Concepto" Text="POR PERSONAL"
                                                                            runat="server" Width="150px" CssClass="rb" ForeColor="White" BackColor="#BA64C6" />
                                                                    </td>
                                                                    <td>
                                                                        &#160;
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
                                <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="Datos Secundarios" Enabled="false">
                                    <ContentTemplate>
                                        <div class="textoGeneral">
                                            <table>
                                                <tr>
                                                    <td colspan="2">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    Valor por Defecto (Opcional)
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtValor_Defecto" Width="70px" CssClass="txt" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Nro de decimales a Redondear
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtNro_Decimales" Width="70px" CssClass="txt" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Grupo
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="cboGrupo_Concepto" runat="server" CssClass="ddl">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top">
                                                                    Observaci�n
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtComentario" TextMode="MultiLine" Height="50px" runat="server"
                                                                        CssClass="txt" Width="400px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <asp:Panel ID="pnlBoleta" runat="server" BorderWidth="1px" BorderStyle="Solid">
                                                            <table>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <asp:CheckBox ID="ckMostrar_En_Boleta" runat="server" Text="Mostrar en Boleta" CssClass="ck" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        En Columna
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="cboBoleta_Columna" runat="server" CssClass="ddl" Width="150px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        Nro Orden en Boleta
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtBoleta_nro_orden" Width="50px" CssClass="txt" runat="server"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        Proceso
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="cboBoleta_Proceso" runat="server" CssClass="ddl" Width="150px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:Panel ID="pnlOlap" runat="server" BorderWidth="1px" BorderStyle="Solid">
                                                            <table>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <asp:CheckBox ID="ckMostrar_En_Cubo" runat="server" Text="Mostrar en Consulta Olap"
                                                                            CssClass="ck" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        Columna
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="cboCubo_Columna" runat="server" CssClass="ddl" Width="150px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        Proceso
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="cboCubo_Proceso" runat="server" CssClass="ddl" Width="150px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </ContentTemplate>
                                </cc1:TabPanel>
                                <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="Otros" Enabled="false">
                                    <HeaderTemplate>
                                        Otros</HeaderTemplate>
                                    <ContentTemplate>
                                        <div class="textoGeneral">
                                            <fieldset>
                                                <legend>
                                                    <asp:Label ID="Label20" runat="server" Text="Selector de Interfaces" CssClass="miTituloOnTab"></asp:Label></legend>
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <table>
                                                           <%-- <tr>
                                                                <td>
                                                                    <asp:Label ID="Label17" runat="server" Text="Interfaces" CssClass="miLabel"></asp:Label>
                                                                </td>
                                                                <td colspan="2">
                                                                    <asp:DropDownList ID="cboInterfaz" CssClass="ddl" runat="server" onchange="enableEstructura()"
                                                                        Width="200px">
                                                                        <asp:ListItem Value="00">--Seleccione--</asp:ListItem>
                                                                        <asp:ListItem Value="01">Plame</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>--%>
                                                            <%--<tr>
                                                                <td>
                                                                    <asp:Label ID="Label18" runat="server" Text="Estructura" CssClass="miLabel"></asp:Label>
                                                                </td>
                                                                <td colspan="2">
                                                                    <asp:DropDownList ID="cboEstructura" runat="server" CssClass="ddl" Width="450px"
                                                                        Enabled="False" OnSelectedIndexChanged="cboEstructura_SelectedIndexChanged" AutoPostBack="true">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>--%>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label19" runat="server" Text="Concepto Rem PDT 601" CssClass="miLabel"></asp:Label>
                                                                </td>
                                                                <td colspan="3">
                                                                    <asp:DropDownList ID="cboConcepto_Remunerativo" runat="server" CssClass="ddl" Width="450px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </fieldset>
                                            <fieldset>
                                                <legend>
                                                    <asp:Label ID="Label21" runat="server" Text="Otros Datos" CssClass="miTituloOnTab"></asp:Label></legend>
                                                <table>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:CheckBox ID="chkCero" runat="server" Text="Guardar Valor Igual a Cero" />
                                                        </td>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:CheckBox ID="ckTotal" runat="server" CssClass="ck" Text="Concepto Totalizador?" />
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="ckMostrar_TotalizadoAnual" runat="server" CssClass="ck" Text="Utilidades (Remunerativa +)" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:CheckBox ID="ckMostrarEnAsiento" runat="server" Text="Mostrar en Asiento?" CssClass="ck" />
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="ckMostrar_TotalizadoAnualMinus" runat="server" Text="Utilidades (Remunerativa -)"
                                                                CssClass="ck" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Cod. Auxiliar
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCodigo_Auxiliar" runat="server" CssClass="txt" Width="150px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="ckMostrar_TotalizadoAnualDias" runat="server" Text="Utilidades (Dias Efectivos +)"
                                                                CssClass="ck" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="ckMostrar_TotalizadoAnualDiasMinus" runat="server" Text="Utilidades (Dias Efectivos -)"
                                                                CssClass="ck" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="ckMostrar_UtilidadesRemuVigente" runat="server" Text="Utilidades (Rem Vigente +)"
                                                                CssClass="ck" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="ckMostrar_UtilidadesRemuVigenteMinus" runat="server" Text="Utilidades (Rem Vigente -)"
                                                                CssClass="ck" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:CheckBox ID="ckI_Acumulados" runat="server" Text="FORMULAS ACUMULATIVAS DE RANGO ANUAL (I_ACM)"
                                                                CssClass="ck" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:CheckBox ID="ckDoble_FF" runat="server" Text="FORMULAS PARA OTROS GRUPOS EN EL MISMO PROCESO (FF) DOBLE F"
                                                                CssClass="ck" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </fieldset>
                                        </div>
                                    </ContentTemplate>
                                </cc1:TabPanel>
                            </cc1:TabContainer>
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
                                    <asp:Image ID="Image2" runat="server" alt="Procesando" ImageUrl="../css/ajax-loader.gif" />
                                </div>
                            </center>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </fieldset>
            </td>
        </tr>
    </table>
</asp:Content>
