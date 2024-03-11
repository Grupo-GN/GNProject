<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="sRepOsigermin.aspx.cs" Inherits="GNProject.Views.Indicendia01.Server.pRepOsigermin.sRepOsigermin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
<center>
<table style="width:70%;border-collapse:collapse;" id="tblDatos">
    <tr>
        <td colspan="6"><img src="../../img/OsigerminLogon.png" /></td>

    </tr>
    <tr>
        <td colspan="6" 
            
            style="font-family: Arial; font-size: 12px; font-weight: bold; text-align: center">FORMATO Nº 2</td>

    </tr>
    <tr>
        <td colspan="6" >&nbsp;</td>
    </tr>
    <tr>
        <td colspan="6" 
            
            style="font-family: Arial; font-size: 12px; font-weight: bold; text-decoration: underline; text-align: center">REPORTE FINAL</td>

    </tr>
    <tr>
        <td colspan="6" >&nbsp;</td>
    </tr>
    <tr>
        <td colspan="2">&nbsp;</td>
        <td style="font-family: Arial; font-size: 14px; text-align: left; border: 1px solid #000000;width:250px;">Emergencia  N°: </td>
        <td style="border: 1px solid #000000; text-align: center;" colspan="2">Año 2014</td>
        <td >&nbsp;</td>

    </tr>
    <tr>
        <td colspan="6" style="height: 10px">&nbsp;</td>
    </tr>
    <tr>
        <td colspan="2">&nbsp;</td>
        <td style="font-family: Arial; font-size: 14px; text-align: left; border: 1px solid #000000">Hidrocarburos Líquidos y/o GLP </td>
        <td style="font-family: Arial; font-size: 14px; text-align: center; border: 1px solid #000000" 
            colspan="2">(&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;)</td>
        <td>&nbsp;</td>

    </tr>
    <tr>
        <td colspan="2">&nbsp;</td>
        <td style="font-family: Arial; font-size: 14px; text-align: left; border: 1px solid #000000">Gas Natural </td>
        <td style="font-family: Arial; font-size: 14px; text-align: center; border: 1px solid #000000" 
            colspan="2">(&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;)</td>
        <td>&nbsp;</td>

    </tr>
    <tr>
        <td colspan="6" style="height: 10px">&nbsp;</td>
    </tr>
    <tr>
        <td colspan="2">&nbsp;</td>
        <td style="font-family: Arial; font-size: 14px; text-align: left; border: 1px solid #000000">Accidente</td>
        <td style="font-family: Arial; font-size: 14px; text-align: center; border: 1px solid #000000" 
            colspan="2">(&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;) </td>
        <td>&nbsp;</td>

    </tr>
    <tr>
        <td colspan="2">&nbsp;</td>
        <td style="font-family: Arial; font-size: 14px; text-align: left; border: 1px solid #000000">Incidente</td>
        <td style="font-family: Arial; font-size: 14px; text-align: center; border: 1px solid #000000" 
            colspan="2">(&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;)</td>
        <td>&nbsp;</td>

    </tr>
    <tr>
        <td colspan="6">&nbsp;</td>
    </tr>
    <tr>
        <td colspan="6" style="border: 1px solid #000000; font-family: Arial; font-size: 14px; font-weight: bold; text-align: left; height: 30px; background-color: #CCCCCC;">1. DATOS DEL ADMINISTRADO</td>
    </tr>
    <tr>
        <td colspan="6" 
            
            style="border: 1px solid #000000; font-family: Arial; font-size: 14px; text-align: left; height: 25px;">
           Nombre o Razón Social: LIMA GAS S.A.</td>
    </tr>
    <tr>
        <td style="border: 1px solid #000000" colspan="6">Representante legal: RAFAEL VIZCARDO MUÑOZ</td>
    </tr>
    <tr>
        <td style="border: 1px solid #000000" colspan="3">Registro de Hidrocarburos: A393860</td>
        <td style="border: 1px solid #000000" colspan="3">Placa(s) del vehículo (de ser el 
            caso):&nbsp;
</td>
    </tr>
    <tr>
        <td style="border: 1px solid #000000" colspan="3">Domicilio legal: CALLE A N° 149 ZONA 7 FUNDO BOCANEGRA</td>
        <td style="border: 1px solid #000000" colspan="3">Distrito: CALLAO</td>
    </tr>
    <tr>
        <td style="border: 1px solid #000000" colspan="3">Provincia / Departamento: LIMA</td>
        <td style="border: 1px solid #000000" colspan="3">Email: Rafael.vizcardo@limagas.com</td>
    </tr>
    <tr>
        <td style="border: 1px solid #000000">Teléfono(s): 215-9300</td>
        <td style="border: 1px solid #000000" colspan="3">RUC: 2010007348</td>
        <td style="border: 1px solid #000000" colspan="2">Actividad: COMERCIALIZACIÓN GLP</td>

    </tr>
    <tr>
        <td style="border: 1px solid #000000" colspan="3">PERSONA(S) DE CONTACTO(S):</td>
        <td style="border: 1px solid #000000" colspan="3">TELÉFONO(S) DE CONTACTO(S) - FAX:</td>
    </tr>
    <tr>
        <td style="border: 1px solid #000000" colspan="3">Karen Zapana Jara<br />
Juan José Navarro Alvarez
</td>
        <td style="border: 1px solid #000000" colspan="3">997572077<br />
997575302
</td>
    </tr>
    <tr>
        <td colspan="6" style="border: 1px solid #000000; font-family: Arial; font-size: 14px; font-weight: bold; text-align: left; height: 30px; background-color: #CCCCCC;">2. DEL EVENTO </td>
    </tr>
    <tr>
        <td style="border: 1px solid #000000" colspan="2">Fecha: <label id="lblFecha"></label></td>
        <td style="border: 1px solid #000000" colspan="2">Hora Inicio: &nbsp;&nbsp;&nbsp;</td>
        <td style="border: 1px solid #000000" colspan="2">Hora de Término: &nbsp;&nbsp;&nbsp;</td>
    </tr>
    <tr>
        <td style="border: 1px solid #000000" colspan="6">Lugar donde ocurrió el evento&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
    </tr>
    <tr>
        <td style="border: 1px solid #000000" colspan="6">&nbsp;</td>
    </tr>
    <tr>
        <td style="border: 1px solid #000000" colspan="2">Distrito: <label id="lblDistrito"></label></td>
        <td style="border: 1px solid #000000" colspan="2">Provincia: <label id="lblProvincia"></label></td>
        <td colspan="2" style="border: 1px solid #000000">Departamento: <label id="lblDepartamento"></label></td>
       
    </tr>
    <tr>
        <td style="border: 1px solid #000000" colspan="6">DESCRIPCION DETALLADA DEL EVENTO :</td>
    </tr>
    <tr>
        <td style="border: 1px solid #000000" colspan="6"><textarea id="txtDescripcion" rows="3" cols="30" style="width:100%;"></textarea></td>
    </tr>
    <tr>
        <td style="text-align: left;" colspan="6">&nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: left;" colspan="6">&nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: left;" colspan="6">&nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: left;" colspan="6">_____________________</td>
    </tr>
    <tr>
        <td colspan="6"> 	1 	Enumerar de manera correlativa las emergencias reportadas durante el año calendario en curso.</td>
    </tr>
    <tr>
        <td colspan="6">2 Cuando la emergencia corresponda a esta opción, el presente formato deberá ser remitido a la Gerencia de Fiscalización de Hidrocarburos Líquidos (GFHL) de OSINERGMIN vía fax (01 – 2645598), Mesa de Partes o al correo electrónico emergenciasGFHL@osinerg.gob.pe.</td>
    </tr>
    <tr>
        <td colspan="6">3 Cuando la emergencia corresponda a esta opción,  el presente formato deberá ser remitido a la Gerencia de Fiscalización de Gas Natural (GFGN) de OSINERGMIN vía fax (01 – 2645597), Mesa de Partes o vía electrónica habilitada por la GFGN.</td>
    </tr>
    <tr>
        <td colspan="6">&nbsp;</td>
    </tr>
    <tr>
        <td colspan="6">&nbsp;</td>
    </tr>
    
</table>
<table style="width:70%;border-collapse:collapse;">
    <tr>
        <td colspan="2"><img src="../../img/OsigerminLogon.png" /></td>

    </tr>
    <tr>
        <td colspan="2"style="border: 1px solid #000000; font-family: Arial; font-size: 14px; font-weight: bold; text-align: left; height: 30px; background-color: #CCCCCC;">3.- CONSECUENCIAS DEL EVENTO</td>
    </tr>
    <tr>
        <td colspan="2" style="border: 1px solid #000000">Cargo de la persona que suscribe el Reporte Preliminar: Ingreniero de Seguridad Industrial</td>
    </tr>
    <tr>
        <td colspan="2" style="border: 1px solid #000000; height: 100px;">FIRMA : </td>
    </tr>
    <tr>
        <td  colspan="2" style="border: 1px solid #000000">Nombre y Apellidos: </td>
        
    </tr>
    <tr>
        <td colspan="2" style="border: 1px solid #000000">DNI ó CE: </td>
    </tr>
    <tr>
        <td colspan="2" style="border: 1px solid #000000">Profesión: </td>
    </tr>

</table>
</center>
<br />
<br /><br /><br />
    <input type="button" value="EXPORTAR" class="buttonHer" id="btExportar" />
    <br />
    <br /><br /><br />
    <br /><br /><br />
    <script src="../../jquery1.10/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="Script_RepOsigermin.js" type="text/javascript"></script>
    <script src="../../jsExportExcel/ScriptExportarExcel.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var Incidente_Cod = getParameterByName('inccod');
            Get_Find_ReporteIncidente(Incidente_Cod);

            $('#btExportar').click(function () {
                tableToExcel('tblDatos', 'exp');
            });
        });
    </script>

</asp:Content>
