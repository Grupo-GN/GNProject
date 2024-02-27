<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MantCorreos.aspx.cs" Inherits="GNProject.Views.portal.Mantenimientos.MantCorreos" %>

<%@ Import Namespace="GNProject.Acceso.App_code_portal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/Assets/Css/PortalCss/Estilo.css" rel="stylesheet" type="text/css" />
    <link href="/Assets/Css/PortalCss/Menu.css" rel="stylesheet" type="text/css" />
    <link href="/Assets/Css/PortalCss/JqGrid/ui.jqgrid.css" rel="stylesheet" type="text/css" />
    <link href="/Assets/Css/PortalCss/JqGrid/jquery-ui.css" rel="stylesheet" type="text/css" />    
    <script language="javascript">window.$q = []; window.$ = window.jQuery = function (a) { window.$q.push(a); };</script>
    <script type="text/javascript" src="/Scripts/Portal/Funciones.min.js"></script>
    <script type="text/javascript" src="/Scripts/Portal/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="/Scripts/Portal/jquery-1.11.1-ui.min.js"></script>
    <!--[if IE 7]> <script type="text/javascript" src="../js/jqGrid-4.5.2/jsonIE7.js"></script> <![endif]-->
    <script type="text/javascript" src="/Scripts/Portal/jqGrid-4.5.2/grid.locale-en.min.js"></script>
    <script type="text/javascript" src="/Scripts/Portal/jqGrid-4.5.2/jquery.jqGrid.src.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="hdfID" runat="server" />    
    <div class="title">
        Mantenimiento de Plantillas de Correo</div>
    <br />
    <div id="Tab1">
        <div>
            <table>
                <tr>
                    <td>
                        <input type="button" id="btnBuscar" value="Buscar" onclick="fn_Buscar();" />
                        <input type="button" id="btnNuevo" value="Nuevo" onclick="fn_Nuevo();" style="display:none;" />
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
    <div id="Tab2">
        <p style="text-align: right;">
            <a href="#" onclick='return fn_Volver();'>Volver</a>
        </p>
        <hr />
        <div style="clear: right; width: 550px">
            <table style="width: 100%;">
                <tr>
                    <td>
                        Código Correo:
                    </td>
                    <td>
                        <label id="lblCodCorreo" style="font-weight:bold;"></label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Asunto:
                    </td>
                    <td>
                        <input id="txtAsunto" type="text" style="width:400px;" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Para:
                    </td>
                    <td>
                        <input id="txtPara" type="text" style="width:400px;" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Copia:
                    </td>
                    <td>
                        <input id="txtCC" type="text" style="width:400px;" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Copia Oculta:
                    </td>
                    <td>
                        <input id="txtBCC" type="text" style="width:400px;" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Cuerpo del correo:
                    </td>
                    <td>
                        <textarea id="txtBody" rows="3" cols="5" style="width:400px; height:200px;"></textarea>
                    </td>
                </tr>
            </table>
            <hr />
            <p>
                <input id="btnGrabar" type="button" value="Grabar" onclick="fn_Grabar();" />
            </p>
            <table style="width:100%;" id="tblImagenes">   
                <tr>
                    <td>
                        Imagenes <span style="color:Red;">(PNG,JPG,GIF)</span>:
                    </td>
                    <td>
                        <asp:FileUpload Width="300px" ID="fuArchivo" runat="server" />
                        <asp:Button ID="btnSubirArchivo" Text="Subir Imagen" runat="server" OnClick="btnSubirArchivo_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div id="divImagenes">
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <script type="text/javascript">
        var no_pagina = "MantCorreos.aspx";
        /*[INICIO] - Variables Grilla Bandeja*/
        var idGrilla_Bandeja = "#grvBandeja";
        var idPieGrilla_Bandeja = "#grvBandeja_Pie";
        var strCabecera_Bandeja = ['', 'ID Correo', 'Código', 'Asunto'];
        var ModelCol_Bandeja = [
                            { name: 'Accion', width: 40, align: 'center' },
                            { name: 'id_correo', index: 'id_correo', width: 25, align: 'center', hidden: true },
                            { name: 'co_correo', index: 'co_correo', width: 100, align: 'left' },
                            { name: 'no_asunto', index: 'no_asunto', width: 300, align: 'left' },
                            ];
        /*[FIN] - Variables Grilla Bandeja*/
        function fn_dblClickBandeja(rowID) { }

        this.fn_CargaInicial();
        function fn_CargaInicial() {
            $("#Tab2").hide();

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
                var strUrlServicio = no_pagina + "/Get_Bandeja";
                this.fc_GetJQGrid_Ajax(arr_parametros, strUrlServicio, idGrilla_Bandeja, idPieGrilla_Bandeja
                    , strCabecera_Bandeja, ModelCol_Bandeja, function () { }, fn_dblClickBandeja);
            }
        }

        function fn_LimpiarTab2() {
            $("#<%=hdfID.ClientID %>").val("");            
            $("#lblCodCorreo").text("");
            $("#txtAsunto").val("");
            $("#txtPara").val("");
            $("#txtCC").val("");
            $("#txtBCC").val("");
            $("#txtBody").val("");
            $("#tblImagenes").hide();
            document.getElementById("<%=fuArchivo.ClientID %>").parentNode.innerHTML = document.getElementById("<%=fuArchivo.ClientID %>").parentNode.innerHTML;
            $("#divImagenes").html("");
        }
        function fn_Nuevo() {
            $("#Tab1").hide();
            $("#Tab2").show();

            this.fn_LimpiarTab2();
        }
        function fn_Volver() {
            $("#Tab1").show();
            $("#Tab2").hide();
            return false;
        }
        function fn_Editar(id) {
            $("#Tab1").hide();
            $("#Tab2").show();

            //Carga datos
            this.fn_LimpiarTab2();
            document.getElementById("<%= hdfID.ClientID %>").value = id;
            var strFiltros = "{'id':" + id + "}";
            var strUrlServicio = no_pagina + "/Get_DatosxID";
            this.fc_CallService(strFiltros, strUrlServicio,
                function (objResponse) {
                    $("#lblCodCorreo").text(objResponse.co_correo);
                    $("#txtAsunto").val(objResponse.no_asunto);
                    $("#txtPara").val(objResponse.no_para);
                    $("#txtCC").val(objResponse.no_cc);
                    $("#txtBCC").val(objResponse.no_bcc);
                    $("#txtBody").val(objResponse.tx_body);
                    $("#tblImagenes").show();                    
                    if (objResponse.no_images != "") {
                        //obtener imagenes
                        $("#divImagenes").append(objResponse.imagenes_html);
                    }
                }
            );
        }
        function fn_Grabar() {
            var id_correo = fc_Trim($("#<%=hdfID.ClientID %>").val());            
            var no_asunto = fc_Trim($("#txtAsunto").val());
            var no_para = fc_Trim($("#txtPara").val());
            var no_cc = fc_Trim($("#txtCC").val());
            var no_bcc = fc_Trim($("#txtBCC").val());
            var tx_body = $("#txtBody").val();
            var msg = "";
            if (no_asunto == "") { msg += "- Debe ingresar asunto.\n"; }
            if (tx_body == "") { msg += "- Debe ingresar cuerpo del correo.\n"; }
            if (msg != "") {
                alert(msg);
            }
            else if (confirm('¿Está seguro de guardar el registro?')) {
                var parametros = new Array();
                parametros[0] = id_correo;
                parametros[1] = no_asunto;
                parametros[2] = no_para;
                parametros[3] = no_cc;
                parametros[4] = no_bcc;
                parametros[5] = tx_body;                
                parametros[6] = "<%=ClaseGlobal.Get_UserName(this.Page)%>";
                //Variables Acceso a Datos
                var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
                var strUrlServicio = no_pagina + "/Grabar";
                this.fc_CallService(strParametros, strUrlServicio,
                    function (objResponse) {
                        var retorno = objResponse[0];
                        var msg_retorno = objResponse[1];
                        alert(msg_retorno);
                        if (retorno > 0) {
                            this.fn_Volver();
                            this.fn_Buscar();
                        }
                    }
                );
            }
        }
//        function fn_SubirFile() {
//            $("#<%=hdfID.ClientID %>").val(id_correo);
//            document.getElementById("<%=btnSubirArchivo.ClientID %>").click();
//        }
        function fn_EliminarArchivo(no_archivo) {
            var id_correo = fc_Trim($("#<%=hdfID.ClientID %>").val());
            var parametros = new Array();
            parametros[0] = id_correo;
            parametros[1] = no_archivo;
            //Variables Acceso a Datos
            var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
            var strUrlServicio = no_pagina + "/EliminarArchivo";
            this.fc_CallService(strParametros, strUrlServicio,
                function (objResponse) {
                    var retorno = objResponse[0];
                    var msg_retorno = objResponse[1];
                    alert(msg_retorno);
                    if (retorno > 0) {
                        fn_Editar(id_correo);
                    }
                }
            );            
        }
    </script>
</asp:Content>
