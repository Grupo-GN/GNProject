function fc_OpenReport(e, t, r) { var o = "750"; "1" == r && (o = "1050"); var a = "../Reportes/FrmPrint.aspx?Reporte_Id=" + e + "&prm=" + t; window.open(a, "_blank", "status=1,toolbar=no,menubar=no,location=no,scrollbars=1,resizable=1,width=" + o + ",height=600") }
function initilize() {
    $('#TabContainer').tabs();
    cargarCombo();
    Lista_ConceptosNoConfigurados();

    $('#btnGenerar').click(function () {
        if ($('#rbsap').prop('checked') == true) {
            var parametros = document.getElementById('periodoSession').value
            fc_OpenReport("REPASIENTOSAP", parametros, "1");
        }
        if ($('#rbStar').prop('checked') == true) {
            var parametros = document.getElementById('periodoSession').value
            fc_OpenReport("REPASIENTOSTAR", parametros, "1");
        }
        if ($('#rbExcel').prop('checked') == true) {
            var parametros = $("#cboAsiento").val() + ":" + document.getElementById('periodoSession').value;
            fc_OpenReport("REPASIENTOEXCEL", parametros, "1");
        }
        if ($('#rbGeneral2').prop('checked') == true) {
            var parametros = $("#ctl00_ucFiltros1_cboPeriodo").val()
                + ":" + $("#cboAsiento").val()
                + ":" + ($("#chkDolares").prop("checked") ? "1" : "0");

            if ($("#cboAsiento").val() != null) {
                fc_OpenReport("RepAsiento_General2", parametros, "1");
            }
            else { alert("No existen asientos configurados para el ejercicio actual."); }
        }
        if ($('#rbConsisat').prop('checked') == true) {
            var parametros = $("#ctl00_ucFiltros1_cboPeriodo").val()
                + ":" + ($("#chkDolares").prop("checked") ? "1" : "0");
            fc_OpenReport("REPASIENTO_CONSISAT", parametros, "1");
        }
        if ($('#rbTipoGroup').prop('checked') == true) {
            var parametros = $("#ctl00_ucFiltros1_cboPeriodo").val()
                + ":" + $("#cboAsiento").val() 
                + ":" + ($("#chkDolares").prop("checked") ? "1" : "0");
            fc_OpenReport("REPASIENTO_TIPOGROUP", parametros, "1");
        }
    });


    $('#btnGenerarDet').click(function () {
        if ($('#rbExcel').prop('checked') == true) {
            var parametros = $("#cboAsiento").val() + ":" + document.getElementById('periodoSession').value;
            fc_OpenReport("REPASIENTOEXCELDETALLE", parametros, "1");
        }
    });


    $('#btnGuardarAsiento').click(function () {
        if (confirm('¿Está seguro(a) de continuar?')) {
            $('#btnGuardarAsiento').prop('disabled', true);
            var xPeriodo = document.getElementById('periodoSession').value;
            var xAsiento = $('#cboAsiento').val();
            var valueTipoAsiento = $("input[name='rbtipos']:checked").val();
            var params = {
                xPeriodoId: xPeriodo,
                xAsientoId: xAsiento,
                xCodTipoAsiento: valueTipoAsiento
            };
            $.ajax({
                type: "POST",
                url: 'GenerarAsientos.aspx/RegistrarAsientos',
                contentType: "application/json; chartseft:utf-8",
                data: JSON.stringify(params),
                dataType: "json",
                success: function (response) {
                    var datos = response.d;
                    alert(datos.split('#')[1]);
                    $('#btnGuardarAsiento').prop('disabled', false);
                },
                error:
                    function (XmlHttpError, error, description) {
                        $("#divError").html(XmlHttpError.responseText);
                    },
                async: false
            });
            $('#btnGuardarAsiento').prop('disabled', false);

            //if ($('#rbsap').prop('checked') == true) {
            //    RegistrarAsientosSap();
            //}
            //if ($('#rbStar').prop('checked') == true) {
            //    RegistrarAsientosStar();
            //}
            //if ($('#rbExcel').prop('checked') == true) {
            //    RegistrarAsientosGeneral();
            //}
        }
    });
    $('#rbsap').click(function () { cargarCombo(); Lista_ConceptosNoConfigurados(); $("#lblDolares").hide(); });
    $('#rbStar').click(function () { cargarCombo(); Lista_ConceptosNoConfigurados(); $("#lblDolares").hide(); });
    $('#rbExcel').click(function () { cargarCombo(); Lista_ConceptosNoConfigurados(); $("#lblDolares").hide(); });
    $('#rbGeneral2').click(function () { cargarCombo(); Lista_ConceptosNoConfigurados(); $("#lblDolares").hide(); });
    $('#rbConsisat').click(function () { cargarCombo(); Lista_ConceptosNoConfigurados(); $("#lblDolares").prop("checked", false).hide(); });
    $("#rbTipoGroup").click(function () { cargarCombo(); Lista_ConceptosNoConfigurados(); $("#lblDolares").show(); $("#chkDolares").prop("checked", false); });
    $('#cboAsiento').change(function () {
        Lista_ConceptosNoConfigurados();
    });
};

function cargarCombo() {
    $('#cboAsiento').html('');
    if ($('#rbsap').prop('checked') == true || $('#rbStar').prop('checked') == true || $('#rbConsisat').prop('checked') == true) {
        $('<option value="01">Planillas</option>').appendTo('#cboAsiento');
        $('<option value="06">Provisiones</option>').appendTo('#cboAsiento');
    }
    if ($('#rbExcel').prop('checked') == true || $('#rbGeneral2').prop('checked') == true || $('#rbTipoGroup').prop('checked') == true) {
        CargarAsientos();
    }
}
function CargarAsientos() {
    var xEjercicio = document.getElementById('anioSession').value, xPlanilla = document.getElementById('planilllaSession').value;
    var params = {
        xEjercicio: xEjercicio,
        xPlanilla: xPlanilla
    };
    $.ajax({
        type: "POST",
        url: 'FrmGenerarAsientos.aspx/GetAsientosSelect',
        contentType: "application/json; chartseft:utf-8",
        data: JSON.stringify(params),
        dataType: "json",
        success: function (response) {
            var datos = response.d;
            $('#cboAsiento').html('');
            for (var i = 0; i <= datos.length - 1; i++) {
                $('<option value="' + datos[i][0] + '">' + datos[i][1] + '</>').appendTo('#cboAsiento');
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: false
    });
};


function Lista_ConceptosNoConfigurados() {
    $('#tbodyConcepto').html('');
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/GetVerificarConceptosNoIncluidos';

    var params = {
        xAsiento: ($("#cboAsiento").val() != null ? $("#cboAsiento").val() : "")
        , xEjercicio: document.getElementById('anioSession').value
        , xPlanilla: document.getElementById('planillaSession').value
        , xPeriodo: document.getElementById('periodoSession').value
    };
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        data: JSON.stringify(params),
        dataType: "json",
        success: function (response) {
            var data = response.d;
            var lengthD = data.length - 1;
            $('#tbodyConcepto').html('');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<tr>';
                html += '<td>' + data[i][0] + '</td>';
                html += '<td>' + data[i][1] + '</td>';
                html += '<td>' + data[i][2] + '</td>';
                html += '<td style="text-align:right;">' + data[i][3] + '</td>';
                html += '</tr>';
                $(html).appendTo('#tbodyConcepto');
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: true
    });

}


//function RegistrarAsientosSap() {
//    $('#btnGuardarAsiento').prop('disabled', true);
//    var xPeriodo = $('#ctl00_ucFiltros1_cboPeriodo').val();
//    var params = {
//        xPeriodoId: xPeriodo
//    };
//    $.ajax({
//        type: "POST",
//        url: 'GenerarAsientos.aspx/RegistrarAsientosSap',
//        contentType: "application/json; chartseft:utf-8",
//        data: JSON.stringify(params),
//        dataType: "json",
//        success: function (response) {
//            var datos = response.d;
//            alert(datos.split('#')[1]);
//            $('#btnGuardarAsiento').prop('disabled', false);
//        },
//        error:
//            function (XmlHttpError, error, description) {
//                $("#divError").html(XmlHttpError.responseText);
//            },
//        async: false
//    });
//    $('#btnGuardarAsiento').prop('disabled', false);
//};
//function RegistrarAsientosStar() {
//    $('#btnGuardarAsiento').prop('disabled', true);
//    var xPeriodo = $('#ctl00_ucFiltros1_cboPeriodo').val();
//    var params = {
//        xPeriodoId: xPeriodo
//    };
//    $.ajax({
//        type: "POST",
//        url: 'GenerarAsientos.aspx/RegistrarAsientosStarSoft',
//        contentType: "application/json; chartseft:utf-8",
//        data: JSON.stringify(params),
//        dataType: "json",
//        success: function (response) {
//            var datos = response.d;
//            alert(datos.split('#')[1]);
//            $('#btnGuardarAsiento').prop('disabled', false);
//        },
//        error:
//            function (XmlHttpError, error, description) {
//                $("#divError").html(XmlHttpError.responseText);
//            },
//        async: false
//    });
//    $('#btnGuardarAsiento').prop('disabled', false);
//};
//function RegistrarAsientosGeneral() {
//    $('#btnGuardarAsiento').prop('disabled', true);
//    var xPeriodo = $('#ctl00_ucFiltros1_cboPeriodo').val(), xAsiento = $('#cboAsiento').val();
//    var params = {
//        xPeriodoId: xPeriodo,
//        xAsientoId: xAsiento
//    };
//    $.ajax({
//        type: "POST",
//        url: 'GenerarAsientos.aspx/RegistrarAsientosGeneral',
//        contentType: "application/json; chartseft:utf-8",
//        data: JSON.stringify(params),
//        dataType: "json",
//        success: function (response) {
//            var datos = response.d;
//            alert(datos.split('#')[1]);
//            $('#btnGuardarAsiento').prop('disabled', false);
//        },
//        error:
//            function (XmlHttpError, error, description) {
//                $("#divError").html(XmlHttpError.responseText);
//            },
//        async: false
//    });
//    $('#btnGuardarAsiento').prop('disabled', false);
//};