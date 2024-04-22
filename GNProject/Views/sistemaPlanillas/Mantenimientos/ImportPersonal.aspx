<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ImportPersonal.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Mantenimientos.ImportPersonal" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />
    <link href="../Controles/miEstilo.css" rel="stylesheet" type="text/css" />
    <link href="../jqueriUI/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet" type="text/css" />
    <link href="../css/StyleWilder.css" rel="stylesheet" type="text/css" />

    <link href="../Styles/nuevoEstiloPlanilla.css" rel="stylesheet" type="text/css" />
    <fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px; /*border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black;*/ min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; /*border-top: solid 1px black;*/">
        <br />
        <table>
            <tr>
                <td><input type="file" id="file-input" /></td>
                <td><input type="button" class="submit" id="btnGuardar" value="Guardar Información" /></td>
                <td><a href="../ReportesyConsultas/frmPersonalExport.aspx" class="lbl" target="_blank" style="color:Blue;">Descargar Datos del Personal para la Plantilla</a> &nbsp;&nbsp;</td>
                <td><a href="Files/Import.xlsm" class="lbl" target="_blank" style="color:Blue;">Descargar Generador</a></td>
                <td>&nbsp;</td>
                <td><img src="../Imgs/62163.gif" width="50px" id="imgCargando" style="display:none;" /><label id="lblprogreso" class="miLabelError" style="font-size:14px;"></label></td>
                <td></td>
            </tr>
        </table>
        <div style="overflow:scroll;max-width:1200px;max-height:500px">
            <table class="gridSmall" style="width:100%;">
                <thead>
                    <tr>
                        <th>PLANILLA</th>
                        <th>T. DOC</th>
                        <th>N° DOC</th>
                        <th>A. PATERNO</th>
                        <th>A. MATERNO</th>
                        <th>NOMBRES</th>
                        <th>SEXO</th>
                        <th>FECHA NACIMIENTO</th>
                        <th>E.CIVIL</th>
                        <th>F.INI.APORTE</th>
                        <th>REG.PEN</th>
                        <th>CUSP</th>
                        <th>CCOSTO</th>
                        <th>GERENCIA</th>
                        <th>AREA</th>
                        <th>SECCION</th>
                        <th>TEL1</th>
                        <th>TEL2</th>
                        <th>TEL3</th>
                        <th>NRO HIJOS</th>
                        <th>BANCO CTA</th>
                        <th>MONEDA CTA</th>
                        <th>TIPO CTA</th>
                        <th>NRO CTA</th>
                        <th>NRO CTA INTERBANCARIA</th>
                        <th>BANCO CTA CTS</th>
                        <th>MONEDA CTA CTS</th>
                        <th>TIPO CTA CTS</th>
                        <th>NRO CTA CTS</th>
                        <th>EMAIL</th>
                        <th>NACIONALIDAD</th>
                        <th>DIRECCION</th>
                        <th>TIPO VIA</th>
                        <th>NRO VIA</th>
                        <th>TIPO ZONA</th>
                        <th>NOMBRE ZONA</th>
                        <th>REG. LAB.</th>
                        <th>NIVEL EDU.</th>
                        <th>SCTR SALUD</th>
                        <th>SCTR PENSION</th>
                        <th>TIPO CONTRATO</th>
                        <th>EPS</th>
                        <th>EMAIL P.</th>
                        <th>CATEGORIA</th>
                        <th>CATEGORIA 2</th>
                        <th>LOCALIDAD</th>
                        <th>CARGO</th>
                        <th>TIPO TRAB.</th>
                        <th>F.INGRESO</th>
                        <th>F.INICIO</th>
                        <th>F.FINAL</th>
                        <th>ESTADO</th>
                        <th>F.CESE</th>
                        <th>MOT.CESE</th>
                        <th>RESULTADO</th>
                    </tr>
                </thead>
                <tbody id="tbodyDatos" class="tbodyPer">
            
            
                </tbody>
            </table>
        </div>
    </fieldset>
    <div id="divError"></div>
    <script src="../JQuery/jquery-1.10.1.min.js" type="text/javascript"></script>
    <script src="Scripts/ScriptImportPersonal.js"></script>

</asp:Content>

