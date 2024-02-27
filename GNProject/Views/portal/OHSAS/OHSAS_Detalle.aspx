<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OHSAS_Detalle.aspx.cs" Inherits="GNProject.Views.portal.OHSAS.OHSAS_Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="hdfID_OHSAS" runat="server" /> 
    <div class="title">
        <asp:Label id="lblTitle" runat="server"></asp:Label></div>
    <br />
    <div id="Tab1">
        <div>
            <table>
                <tr>
                    <td>
                        <input type="button" id="btnBuscar" value="Buscar" onclick="fn_Buscar();" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <table id="grvBandeja">
            </table>
            <div id="grvBandeja_Pie">
            </div>
        </div>
    </div>    
    <script type="text/javascript">
        var no_pagina = "OHSAS_Detalle.aspx";
        /*[INICIO] - Variables Grilla Bandeja*/
        var idGrilla_Bandeja = "#grvBandeja";
        var idPieGrilla_Bandeja = "#grvBandeja_Pie";
        var strCabecera_Bandeja = ['ID OHSAS Det.', 'Titulo', 'Descripción', 'Documento', '<%=GNProject.Acceso.App_code_portal.Parametros.I_Texto_CategoriaAuxiliar%>', 'Fecha'];
        var ModelCol_Bandeja = [
                            { name: 'id_ohsas_detalle', index: 'id_ohsas_detalle', width: 60, align: 'center', hidden: true },
                            { name: 'no_titulo', index: 'no_titulo', width: 150, align: 'left' },
                            { name: 'tx_descripcion', index: 'tx_descripcion', width: 250, align: 'left' },
                            { name: 'no_archivo', index: 'no_archivo', width: 130, align: 'left' },
                            { name: 'no_area', index: 'no_area', width: 70, align: 'center' },
                            { name: 'sfe_registro', index: 'sfe_registro', width: 70, align: 'center' }
        ];
        /*[FIN] - Variables Grilla Bandeja*/
        function fn_dblClickBandeja(rowID) {

        }

        this.fn_CargaInicial();
        function fn_CargaInicial() {
            fn_Buscar();

            //var objResponse = [];
            //this.fc_CargaGrilla(idGrilla_Bandeja, idPieGrilla_Bandeja, strCabecera_Bandeja, ModelCol_Bandeja, objResponse, function () { }, fn_dblClickBandeja);
        }

        function fn_LimpiarFiltros() { }

        function fn_Buscar() {
            var msj = '';

            if (msj != '') {
                alert(msj);
            }
            else {
                //Variables Acceso a Datos
                var arr_parametros = new Array();
                arr_parametros[0] = document.getElementById("<%=hdfID_OHSAS.ClientID%>").value;
                var strUrlServicio = no_pagina + "/Get_Bandeja";
                this.fc_GetJQGrid_Ajax(arr_parametros, strUrlServicio, idGrilla_Bandeja, idPieGrilla_Bandeja
                    , strCabecera_Bandeja, ModelCol_Bandeja, function () { }, fn_dblClickBandeja);
            }
        }
    </script>
</asp:Content>