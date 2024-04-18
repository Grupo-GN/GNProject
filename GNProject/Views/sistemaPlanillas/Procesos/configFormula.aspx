<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="configFormula.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Procesos.configFormula" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />
    <link href="../Controles/miEstilo.css" rel="stylesheet" type="text/css" />
    <link href="../jqueriUI/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../css/StyleWilder.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery.treeview.css" rel="stylesheet" type="text/css" />

    <link href="../Styles/nuevoEstiloPlanilla.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #tblFormulas tbody tr:hover
        {
            border:1px solid #FFFFFF;
            }
    </style>
    <fieldset style="width:100%; background-color: White; margin: 0px 0px 0px 0px;
           /*border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black;*/ 
            min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; /*border-top: solid 1px black;*/">
        <input type="hidden" id="empresaSession" value="<%= Session["EmpresaPlanilla"] %>" />
        <input type="hidden" id="periodoSession" value="<%= Session["PeriodoPlanilla"] %>" />
        <input type="hidden" id="planillaSession" value="<%= Session["planillaPlanilla"] %>" />
        <input type="hidden" id="anioSession" value="<%= Session["anioPlanilla"] %>" />
    <table style="width:100%;">
        <tr>
            <td style="width:50px;"><input type="button" class="submit" value="NUEVO" id="btnNewConfig" /></td>
            <td></td>
        </tr>
    </table>
    <section id="TabContainer">
        <ul>
            <li><a href="#Tab1">Formulas</a></li>
            <li><a href="#Tab2">Configuración</a></li>
        </ul>
        <section id="Tab1">
            <fieldset>
                <legend class="titulocontrolUser">Filtrar</legend>
                <table style="border-collapse:separate;width:100%;">
                    <tr>
                        <td style="text-align:right;width:50px;"><label class="miLabel">Proceso : </label></td>
                        <td><select id="cboProcesoFind" class="ddl"></select></td>
                        <td style="text-align:right;width:70px;"><label class="miLabel">Fórmula : </label></td>
                        <td><input type="text" class="ddl" id="txtFormulaFind" /></td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </fieldset>
        <table class="gridSmall" style="width:100%;" id="tblFormulas">
            <thead>
                <tr>
                    <th></th>
                    <th>NRO</th>
                    <th>FÓRMULA</th>
                    <th>PROCESO</th>
                    <th>ULT. MODIFICACIÓN</th>
                    <%--<th>ESTADO</th>--%>             
                </tr>
            </thead>
            <tbody id="tbodyFormula" class="tbodyPer">
            
            </tbody>
        </table>
        </section>
        <section id="Tab2">
        <input type="button" class="submit" value="Guardar" id="btnGuardarForm" />&nbsp;<input type="button" class="submit" value="Cancelar" id="btnCancelConfig" /><br /><br />
            <table style="border-collapse:collapse;width:100%;">
                <tr>
                    <td style="text-align:left;" colspan="2"><label id="lblError" class="lblError">&nbsp;</label></td>
                    <td rowspan="9">
                        <section style="overflow-y:scroll;vertical-align:top;height:150px;">
                            <div id='sidetree'>
                                <div class='treeheader' style=''>Parametros y Formulas</div>
                                <ul class='treeview' id='tree'>
                                    <%--<li><div class='hitarea expandable-hitarea'></div><span>SECCION</span>
                                        <ul style='display: none;'>
                                            <li style='cursor:pointer'><span onclick='addtext(this)'>concepto</span></li>
                                        </ul>
                                    </li>--%>
                                </ul>
                            </div>
                        </section>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align:right;width:100px;"><label class="lbl">CONCEPTO : </label></td>
                    <td style="width:300px;"><select class="ddl" id="cboConcepto"></select></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align:right;"><label class="lbl">PROCESO FUENTE : </label></td>
                    <td><select class="ddl" id="cboProcesoFuente"></select></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align:right;"><label class="lbl">PROCESO : </label></td>
                    <td><select class="ddl" id="cboProceso"></select></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align:right;"><label class="lbl">NRO : </label></td>
                    <td><input type="number" class="ddl" style="width:100px;" min="1" id="txtNroForm" /></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="3"><input type="button" class="submit" value="Validar" id="btnValidarFormula" /></td>
                </tr>
                <tr>
                    <td colspan="4">&nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align:right;vertical-align:top;"><label class="lbl">FORMULA : </label></td>
                    <td colspan="3"><textarea rows="4" cols="30" class="ddl" style="width:100%;" id="txtFormula"></textarea></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="3"><label class="lblError" id="lblErrorFormula">&nbsp;</label></td>
                </tr>
                <tr>
                    <td style="text-align:right;vertical-align:top;"><label class="lbl">CONDICIÓN : </label></td>
                    <td colspan="3"><textarea rows="4" cols="30" class="ddl" style="width:100%;" id="txtCodicion"></textarea></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="3"><label class="lblError" id="lblErrorCondicion">&nbsp;</label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </section>
    </section>
    



    </fieldset>

    <script src="../JQuery/jquery-1.10.1.min.js" type="text/javascript"></script>
    <script src="../jqueriUI/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
        <script type="text/javascript" src="../Scripts/jquery.treeview.js"></script>
    <script src="Scripts/Script_ConfigFormula.js?v0.1" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(initilize);
    </script>
</asp:Content>

