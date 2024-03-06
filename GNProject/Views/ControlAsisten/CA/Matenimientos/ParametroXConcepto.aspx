<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ParametroXConcepto.aspx.cs" Inherits="GNProject.Views.ControlAsisten.CA.Matenimientos.ParametroXConcepto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"
        type="text/css" />

    <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/EstiloBarraHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleWilder.css" rel="stylesheet" type="text/css" />

    <input id="btnNew" class="buttonHer" type="button" onclick="return btnNew_onclick()" value="Nuevo" />
    <fieldset>
        <div id="HeaderDiv" style="overflow: hidden; width: 100%; border: solid 1px #505050; height: 360px;">

            <table id="tblParametros" class="table">

                <thead class="theadth">
                    <tr>
                        <th class="theadth" scope="col">Edit</th>
                        <th class="theadth" style="display:none;" scope="col">Concepto_Id</th>
                        <th class="theadth" style="display:none;" scope="col">Variable_Id</th>
                        <th class="theadth" scope="col">Concepto</th>
                        <th class="theadth" scope="col">Parametro</th>
                        <th class="theadth" scope="col">Estado</th>
                        <th class="theadth" scope="col">semana</th>
                    </tr>
                </thead>

                <tbody class="tbody" id="tbodyParametros">
                </tbody>

            </table>
        </div>

        <div style="overflow: hidden; width: 100%; border: solid 1px #505050;">
            <table class="table">
                <tfoot>
                    <tr>
                        <td class="tfoottd" colspan="3">

                            <label style="font-family: 'AENOR Fontana ND'; font-weight: bold; font-size: 1.1em;">TOTAL REGISTROS: </label>
                            &nbsp
            <input id="txtnRegistros" type="text" value="0" class="TextPage" readonly="true" />
                            &nbsp &nbsp
            <label style="font-family: 'AENOR Fontana ND'; font-weight: bold; font-size: 1.1em;">PAGE: </label>
                            &nbsp
            <input id="txtPaginaActual" type="text" value="1" class="TextPage" readonly="true" />
                            <input id="btnPrimero" type="button" value="|<" class="submitPager" />
                            <input id="btnAnterior" type="button" value="<<" class="submitPager" />
                            <input id="btnSiguiente" type="button" value=">>" class="submitPager" />
                            <input id="btnUltimo" type="button" value=">|" class="submitPager" />
                        </td>
                    </tr>
                </tfoot>
            </table>
        </div>

    </fieldset>




    <div id="dialog-form"
        style="font-size: x-small; font-family: AENOR Fontana ND;">
        <table class="borde">
            <tr>
                <td align="center" class="titulo" colspan="2">
                    <label class="tituloModal">Mantenimiento de Parametros x Concepto</label>
                </td>
            </tr>

            <tr>
                <td class="style23">&nbsp
                </td>
            </tr>
            <tr>
                <td class="style23">
                    <label class="miLabel" style="width: 50%;">Codigo : </label>
                </td>
                <td style="text-align: left; width: 50%;">
                    <input id="txtCodigo" type="text" readonly="true"
                        class="estiloCajaCodigo" value="???" />
                </td>
            </tr>
            <tr>
                <td class="style23">
                    <label class="miLabel" style="width: 50%;">Concepto : </label>
                </td>
                <td style="text-align: left; width: 50%;">
                    <select id="cboconcepto" class="cbo" style="width: 185px;">
                    </select>
                </td>
            </tr>


            <tr>
                <td class="style23">
                    <label class="miLabel" style="width: 50%;">Variable : </label>
                </td>
                <td style="text-align: left; width: 50%;">
                    <select id="cboparametro" class="cbo" style="width: 185px;">
                    </select>
                </td>
            </tr>
    <tr>
                <td class="style23">
                    <label class="miLabel" style="width: 50%;">semana : </label>
                </td>
                <td style="text-align: left; width: 50%;">
                    <select id="cbosemana" class="cbo" style="width: 185px;">
                    </select>
                </td>
            </tr>

            <tr>
                <td class="style23">
                    <label class="miLabel" style="width: 50%;">Estado : </label>
                </td>
                <td style="text-align: left; width: 50%;">
                    <select id="cboestado" class="cbo" style="width: 185px;">
                        <option value='00'>INACTIVO</option>
                        <option value='01' selected='selected'>ACTIVO</option>
                    </select>
                </td>
            </tr>

            <td colspan="2">

                <table style="width: 100%">
                    <tr>
                        <td style="height: 3px;" colspan="2">
                            <label id="lblError" class="miLabelError"></label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="right" style="width: 100%;">
                            <input id="btnGrabar" type="button" value="Grabar" class="submit" />
                            <input id="btnCancelar" type="button" value="Salir" class="submit" />
                        </td>
                    </tr>
                </table>

            </td>

        </table>

        <label id="lblCodigSeleccionao"></label>

    </div>

     <script src="../../jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../jqueryui/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="Scripts/Script_ParametroConcepto.js" type="text/javascript"></script>

</asp:Content>
