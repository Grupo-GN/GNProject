function CargarAsientos() {
    var xEjercicio = $('#ctl00_ucFiltros1_cboEjercicio').val(), xPlanilla = $('#ctl00_ucFiltros1_cboPlanilla').val();
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
            console.log(datos);
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


function fc_OpenReport(e, t, r) { var o = "750"; "1" == r && (o = "1050"); var a = "../Reportes/FrmPrint.aspx?Reporte_Id=" + e + "&prm=" + t; window.open(a, "_blank", "status=1,toolbar=no,menubar=no,location=no,scrollbars=1,resizable=1,width=" + o + ",height=600") }
function initilize() {
    CargarAsientos();


    $('#btnGenerar').click(function () {

        var parametros = $("#cboAsiento").val()
        + ":" + $("#ctl00_ucFiltros1_cboPeriodo").val();
        fc_OpenReport("REPASIENTOEXCEL", parametros, "1");
    });
};