<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmCalculos_Perm.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Datos.FrmCalculos_Perm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<link href="../jqueriUI/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet" />
<link rel="stylesheet" type="text/css" href="../css/multiple-select.css" />
<link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />

       <table align="center" width="100%">
     <tr>
     <td>
        
        <fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px;
           border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black; 
            min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; border-top: solid 1px black;">
    
    <br />
<asp:Label ID="Label1" runat="server" Text="DATOS ACUMULATIVOS" CssClass="miTitulo" ></asp:Label> 
<br />
<br />
<fieldset>
    <legend>Importar Datos</legend>
    <table style="width:100%;border-collapse:collapse;">
        <tr>
            <td>
                <input type="button" id="btnopen" value="Generar Plantilla" class="submit" /><br />           
                
            </td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" accept=".xls"/>
                <asp:Button ID="btnImportar" runat="server" Text="Procesar" ToolTip="Procesar información"    CssClass="submit" OnClick="btnImportar_Click"  />
            </td>
        </tr>
        <tr>
            <td colspan="2"><asp:Label ID="lblmensajefile" runat="server" CssClass="lblError" Text="-"></asp:Label></td>
        </tr>
    </table>
</fieldset>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
<fieldset style="overflow:auto; border-style: outset; border-width: thin; height:90%; min-height:410px; width: 97%; background-color:White">

<table >
<tr>
<td>

<div>
    <table>
        <tr>
            <td>
                <asp:Panel ID="pnlFiltro" runat="server">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Personal" CssClass="miLabel"></asp:Label> 
                                </td>
                            <td>
                                <asp:DropDownList ID="cboPersonal" runat="server" CssClass="ddl" Width="300px" 
                                    AutoPostBack="True" 
                                    onselectedindexchanged="cboPersonal_SelectedIndexChanged" 
                                    onprerender="cboPersonal_PreRender">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:ImageButton ID="btnBuscar" runat="server" Height="18px" ToolTip="Buscar"
                                    ImageUrl="~/Views/sistemaPlanillas/Imgs/Buscar.png" Width="34px" onclick="btnBuscar_Click" />
                            </td>
                            <td>
                                <asp:ImageButton ID="btnGrabar" runat="server" Height="25px" ToolTip="Grabar Todo" 
                                    ImageUrl="~/Views/sistemaPlanillas/Imgs/btnSave.png" OnClientClick="return confirm('¿Esta Seguro De Grabar Todos los Registros?');"
                                    ValidationGroup="ValidaGrabaVac" Width="25px" onclick="btnGrabar_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnGenerar" runat="server" Text="Generar" CssClass="submit"
                                    onclick="btnGenerar_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnGenerarTodos" runat="server" CssClass="submit" OnClick="btnGenerarTodos_Click" Text="Generar para Todos" />
                            </td>
                        </tr>
                        <tr>
                        <td></td>
                        <td colspan="2">
                            <asp:LinkButton ID="elLink" runat="server" ForeColor="Blue" 
                                onclick="elLink_Click">Refrescar Personal</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td>

            </td>
        </tr>
    </table>


</div>

<div style="overflow: auto; width: 100%;">
    <table class="gridSmallCabecera">
        <tr>
            <th width="40px"><asp:Label ID="Label3" runat="server" Text="NRO" CssClass="tituloGrilla"></asp:Label></th>
            <th width="90px"><asp:Label ID="Label4" runat="server" Text="CONCEPTO ID" CssClass="tituloGrilla"></asp:Label></th>
            <th width="570px"><asp:Label ID="Label5" runat="server" Text="DESCRIPCION" CssClass="tituloGrilla"></asp:Label></th>
            <th width="91px"><asp:Label ID="Label6" runat="server" Text="VALOR" CssClass="tituloGrilla" ></asp:Label></th>
            <th width="91px"><asp:Label ID="Label7" runat="server" Text="VALOR ANTERIOR" CssClass="tituloGrilla" ></asp:Label></th>
        </tr>
    </table>
</div>

<div style="overflow: auto; width: 100%; height:350px;">
    <asp:GridView ID="grvLista" runat="server" 
        ShowHeader="false"
        AutoGenerateColumns="False" CellPadding="2" CssClass="gridSmall" 
        DataKeyNames="Personal_Id, Periodo_Id, Concepto_Id, Proceso_Id" ForeColor="#333333" 
        GridLines="None"
        AllowPaging="True" 
        onpageindexchanging="grvLista_PageIndexChanging" 
        onrowdatabound="grvLista_RowDataBound" onprerender="grvLista_PreRender">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField HeaderText="Nro">
	            <ItemTemplate>
        	            <%# Container.DataItemIndex + 1 %>
	            </ItemTemplate>
	            <ItemStyle Width="40px" HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="Concepto_Id" HeaderText="Concepto_Id" ReadOnly="true">
                <ItemStyle Width="100px" HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Descripción">
                <ItemTemplate>
                    <asp:Label ID="lblno_Concepto" runat="server" ToolTip='<%# Eval("Comentario") %>' Text='<%# Eval("no_Concepto") %>'>
                    </asp:Label>
                </ItemTemplate>
                <ItemStyle Width="569px" />
            </asp:TemplateField>
            <%--<asp:BoundField DataField="no_Concepto" HeaderText="Descripción" ReadOnly="true">
                <ItemStyle Width="300px" />
            </asp:BoundField>--%>
            <asp:TemplateField HeaderText="Valor">
                <ItemTemplate>
                    <asp:TextBox ID="txtValor" runat="server" Width="91px" Text='<%# Eval("Valor") %>' CssClass="txt_align_derecha">
                    </asp:TextBox>
                </ItemTemplate>
                <ItemStyle Width="91px" HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Valor Anterior">
                <ItemTemplate>
                    <asp:TextBox ID="txtValor_Anterior" runat="server" Width="91px" Text='<%# Eval("Valor_Anterior") %>' CssClass="txt_align_derecha">
                    </asp:TextBox>
                </ItemTemplate>
                <ItemStyle Width="91px" HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#9ADBFA" />
    </asp:GridView>
</div>

</td>
</tr>
</table>

</fieldset>
<br />

    </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID = "btnImportar" />
            </Triggers>
</asp:UpdatePanel>

<asp:UpdateProgress ID="UpdateProgress1" runat="server"     AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1">
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

<div id="panelexcel" title="Generar Plantilla" style="width:700px;">
    <fieldset>
        <legend>Filtrar</legend>
        <table>
            <tr>
                <td style="text-align:right;width:200px;"><label>Planilla : </label></td>
                <td>
                    <select class="miComboBox" id="cboPlanilla" style="width:200px;"></select>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align:right;"><label>Ejercicio : </label></td>
                <td>
                    <select class="miComboBox" id="cboEjercicio" style="width:150px;"></select>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align:right;width:100px;"><label>Periodo : </label></td>
                <td><select class="miComboBox" id="cboPeriodoIni" style="width:150px;"></select></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align:right;"><label>Área : </label></td>
                <td><select id="cboArea" class="ddl"></select></td>
                <td style="text-align:right;width:100px;"><label>Cat. Auxiliar : </label></td>
                <td><select id="cboCatAuxiliar" class="ddl"></select></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align:right;">Personal Activo:</td>
                <td><select id="cboPersonalActivo" style="width:250px;"></select></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align:right;width:100px;">Conceptos Acumulados:</td>
                <td>
                    <select id="cboConcepto_Acumulados" style="width:250px;">
                    </select>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="8" style="text-align:center;">
                    <input type="button" id="btnGenerarReporteDetallado" class="submit" value="Generar Excel" style="width:200px;" />
                </td>
            </tr>
        </table>
    </fieldset>
</div>
    <script src="../JQuery/jquery-1.10.1.min.js" type="text/javascript"></script>
    <script src="../jqueriUI/js/jquery-ui-1.10.3.custom.min.js"></script>    
    <script type="text/javascript" src="../JQuery/jquery.multiple.select.js"></script>
    <script language="javascript" type="text/javascript">
    $(document).ready(function () {
        $('#panelexcel').dialog({ autoOpen: false, width: 700, height: 480 });

        CargarPlanilla();
        CargarEjercicio();

        ListaArea();
        ListaCatAuxiliar();
        CargarConceptos("#cboConcepto_Acumulados", "04");        

    });
    $('#btnopen').click(function () {
        $('#panelexcel').dialog('open');
    });
        function CargarPlanilla() {
            var pagePath = window.location.pathname;
            var urlajax = pagePath + '/ListaPlanilla';
            $.ajax({
                type: "POST",
                url: urlajax,
                contentType: "application/json; chartseft:utf-8",
                dataType: "json",
                async: true,
                success: function (response) {
                    var Datos = response.d;
                    var lengthD = Datos.length - 1;

                    $('#cboPlanilla').html('');
                    $('<option value="-1">--SELECCIONE--</option>').appendTo('#cboPlanilla');
                    for (var i = 0; i <= lengthD; i++) {
                        var html = '<option value="' + Datos[i].Planilla_Id + '">' + Datos[i].Descripcion + '</option>';
                        $(html).appendTo('#cboPlanilla');
                    }
                },
                error:
                function (XmlHttpError, error, description) {
                    alert(XmlHttpError.responseText);
                }
            });
        }
        function CargarEjercicio() {
            var pagePath = window.location.pathname;
            var urlajax = pagePath + '/ListaEjercicio';
            $.ajax({
                type: "POST",
                url: urlajax,
                contentType: "application/json; chartseft:utf-8",
                dataType: "json",
                async: true,
                success: function (response) {
                    var Datos = response.d;
                    var lengthD = Datos.length - 1;

                    $('#cboEjercicio').html('');
                    $('<option value="-1">--SELECCIONE--</option>').appendTo('#cboEjercicio');
                    for (var i = 0; i <= lengthD; i++) {
                        var html = '<option value="' + Datos[i].Ejercicio_Id + '">' + Datos[i].Descripcion + '</option>';
                        $(html).appendTo('#cboEjercicio');
                    }
                    $("#cboEjercicio").prop('selectedIndex', Datos.length);
                },
                error:
                function (XmlHttpError, error, description) {
                    alert(XmlHttpError.responseText);
                }
            });
        }

        $('#cboPlanilla').change(function (event) {
            var value = $(this).val();
            SISGNRSPeriodoPlanillaSelect();
            SISGNRSGetPersonalActivo();
        });
        $('#cboEjercicio').change(function (event) {
            var value = $(this).val();
            SISGNRSPeriodoPlanillaSelect();
        });
        $('#cboPeriodoIni').change(function (event) {
            SISGNRSGetPersonalActivo();
        });
       

        /*SISGNRSGetPersonalActivo*/
        function SISGNRSPeriodoPlanillaSelect() {
            var EmpresaID = "01", Anio = $('#cboEjercicio').val(), Planilla_Id = $('#cboPlanilla').val();
            params = {
                Compania_Id: EmpresaID,
                Anio: Anio,
                Planilla_Id: Planilla_Id
            };
            var pagePath = window.location.pathname;
            var urlajax = pagePath + '/Get_Periodo_Combo';
            $.ajax({
                type: "POST",
                data: JSON.stringify(params),
                dataType: "json",
                url: urlajax,
                contentType: "application/json; chartseft:utf-8",
                success: function (response) {
                    var datos = response.d;
                    var _len = datos.length - 1;
                    $('#cboPeriodoIni').html('');
                    for (var i = 0; i <= _len; i++) {
                        var html = '<option value="' + datos[i].Periodo_Id + '">' + datos[i].Descripcion + '</option>';
                        $(html).appendTo('#cboPeriodoIni');
                    }
                    var y = document.getElementById('cboPeriodoIni').options;
                    document.getElementById('cboPeriodoIni').selectedIndex = y.length - 1;
                },
                error:
                function (XmlHttpError, error, description) {
                    $("#secError").html(XmlHttpError.responseText);
                },
                async: false
            });
        };

        $('#btnGenerarReporteDetallado').click(function () {
            if ($("#cboProceso").multipleSelect("getSelects") == "") {
                alert("Debe seleccionar un proceso.");
                return;
            }
            if ($("#cboPlanilla").val() == "-1") {
                alert("Debe seleccionar planilla.");
                return;
            }
            if ($("#cboEjercicio").val() == "-1") {
                alert("Debe seleccionar ejercicio.");
                return;
            }
            var parametros = $("#cboPeriodoIni").val()
                    + ":" + $("#cboConcepto_Acumulados").multipleSelect("getSelects")
                    + ":" + $("#cboArea").val()
                    + ":" + $("#cboCatAuxiliar").val()
                    + ":" + $("#cboPersonalActivo").multipleSelect("getSelects");
            fc_OpenReport("REP_EXCEL_GEN_ACUM", parametros, "1");
        });

        function CargarConceptos(combo_Id, Tipo_Concepto_ID) {
            var params = {
                Tipo: Tipo_Concepto_ID
            };
            var pagePath = window.location.pathname;
            $.ajax({
                type: "POST",
                data: JSON.stringify(params),
                url: pagePath+'/ConfigFormulaGetConceptosByTipoList',
                contentType: "application/json; chartseft:utf-8",
                dataType: "json",
                async: true,
                success: function (response) {
                    var datos = response.d;
                    for (var i = 0; i < datos.length; i++) {
                        try {
                            $('<option value="' + datos[i].Concepto_Id + '">' + datos[i].Descripcion + '</option>').appendTo(combo_Id);
                        } catch (ex) { alert(ex + " Tipo: " + combo_Id); }
                    }

                    $(combo_Id).multipleSelect({
                        filter: true
                    });
                },
                error:
                    function (XmlHttpError, error, description) {
                        alert(XmlHttpError.responseText);
                    }
            });
        }

        function ListaArea() {
            var pagePath = window.location.pathname;
            var urlajax = pagePath + '/ListaArea';

            $.ajax({
                type: "POST",
                url: urlajax,
                contentType: "application/json; chartseft:utf-8",
                dataType: "json",
                async: true,
                success: function (response) {
                    var Datos = response.d;
                    var lengthD = Datos.length - 1;

                    $('#cboArea').html('');
                    $('<option value="">--TODOS--</option>').appendTo('#cboArea');
                    for (var i = 0; i <= lengthD; i++) {
                        var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                        $(html).appendTo('#cboArea');
                    }
                },
                error:
                     function (XmlHttpError, error, description) {
                         alert(XmlHttpError.responseText);
                     }
            });
        }

        function ListaCatAuxiliar() {
            var pagePath = window.location.pathname;
            var urlajax = pagePath + '/ListaCatAuxiliar';
            $.ajax({
                type: "POST",
                url: urlajax,
                contentType: "application/json; chartseft:utf-8",
                dataType: "json",
                async: true,
                success: function (response) {
                    var Datos = response.d;
                    var lengthD = Datos.length - 1;

                    $('#cboCatAuxiliar').html('');
                    $('<option value="">--TODOS--</option>').appendTo('#cboCatAuxiliar');
                    for (var i = 0; i <= lengthD; i++) {
                        var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                        $(html).appendTo('#cboCatAuxiliar');
                    }
                },
                error:
                function (XmlHttpError, error, description) {
                    alert(XmlHttpError.responseText);
                }
            });
        }

        function fc_OpenReport(e, t, r) { var o = "750"; "1" == r && (o = "1050"); var a = "../Reportes/FrmPrint.aspx?Reporte_Id=" + e + "&prm=" + t; window.open(a, "_blank", "status=1,toolbar=no,menubar=no,location=no,scrollbars=1,resizable=1,width=" + o + ",height=600") }

        function SISGNRSGetPersonalActivo() {
            var PlanillaId = $('#cboPlanilla').val() == null ? '' : $('#cboPlanilla').val();
            var PeriodoIni = $('#cboPeriodoIni').val() == null ? '' : $('#cboPeriodoIni').val();
            var params = {
                PlanillaId: PlanillaId,
                PeriodoIni: PeriodoIni,
                PeriodoFin: PeriodoIni
            };
            var pagePath = window.location.pathname;
            var urlajax = pagePath + '/ListaPersonalActivoReporteGeneral';
            $.ajax({
                type: "POST",
                data: JSON.stringify(params),
                url: urlajax,
                contentType: "application/json; chartseft:utf-8",
                dataType: "json",
                async: true,
                success: function (response) {
                    var Datos = response.d;
                    var lengthD = Datos.length - 1;

                    $('#cboPersonalActivo').html('');
                    //$('<option value="">-TODOS-</option>').appendTo('#cboPersonalActivo');
                    for (var i = 0; i <= lengthD; i++) {
                        var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                        $(html).appendTo('#cboPersonalActivo');
                    }
                    //$("#cboPersonalActivo").prop('selectedIndex', Datos.length);
                    $('#cboPersonalActivo').multipleSelect({
                        filter: true
                    });
                },
                error:
                function (XmlHttpError, error, description) {
                    alert(XmlHttpError.responseText);
                }
            });
        }
    </script>
</asp:Content>

