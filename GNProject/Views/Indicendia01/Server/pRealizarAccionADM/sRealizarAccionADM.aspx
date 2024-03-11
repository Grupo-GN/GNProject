<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="sRealizarAccionADM.aspx.cs" Inherits="GNProject.Views.Indicendia01.Server.pRealizarAccionADM.sRealizarAccionADM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

 <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />
    <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"
        type="text/css" />
<style type="text/css">
    .clVerAr
    {
        cursor:pointer;
        text-align:center;
        }
</style>

    <table class="table">
<thead>
        <tr style="font-size:14px;">
            <th></th>            
            <th></th>  
            <th>ESTADO</th>
            <th>DESCRIPCION</th>
            <th>RESPONSABLE</th>
            <th>FECHA DE REPORTE</th>
            <th>FECHA VENCIMIENTO</th>
            <th>ARCHIVOS</th>            
        </tr>
</thead>
<tbody id="tbodyAccion" style="max-height:500px;overflow:auto;">

</tbody>
</table>
<a href="../../ArchivosAcciones/000003/001/3119_59.jpg" target="_blank"></a>

<div id="dialog-files" title="VER ARCHIVOS">
   <table class="table">
                    <thead>
                        <tr>
                            <th></th>
                            <th>Archivo</th>
                            <th>Ver</th>
                        </tr>
                    </thead>
                    <tbody id="tbodyFiles"></tbody>
                </table>
</div>
<br /><br /><br /><br /><br />
    <script src="../../jquery1.10/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../jqueryui/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="Script_RealizarAccionADM.js" type="text/javascript"></script>

    <script type="text/javascript">
        var Incidente_Cod = getParameterByName('inccod');

        $(document).ready(function () {
            $('#dialog-files').hide();
            Get_Acciones_Reporte(Incidente_Cod);



            window.setInterval(function () { Get_Acciones_Reporte(Incidente_Cod); }, 5000);

            $('#tbodyAccion').on('click', '.buttonAprobar', function () {
                if (confirm('¿Esta seguro Aprobar la acción?')) {
                    var codigo = this.id;
                    Get_Aprobar_Accion_ADM(Incidente_Cod, codigo);
                }
            });

            $('#tbodyAccion').on('click', '.buttonDelete', function () {
                if (confirm('¿Esta desaprobar la acción?')) {
                    var codigo = this.id;
                    Get_Desaprobar_Accion_ADM(Incidente_Cod, codigo);
                }
            });

            $('#tbodyAccion').on('click', '.clVerAr', function () {

                Get_FilesAccion_List(Incidente_Cod, this.id);
                open_Modal();
            });

        });
    
    </script>
</asp:Content>
