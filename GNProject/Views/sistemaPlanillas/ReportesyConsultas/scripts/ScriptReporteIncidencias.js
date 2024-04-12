function initilize() {
    ListaArea();
    ListaCatAuxiliar();
    ListaProyecto();
    ListaPersonal();
    ListarReporteIncidenciasDatosFijos();
    $('#cboLocalidad').change(function () {
        ListaPersonal();
        ListarReporteIncidenciasDatosFijos();
    });
    $('#cboProyecto').change(function () {
        ListaPersonal();
        ListarReporteIncidenciasDatosFijos();
    });
    $('#cboArea').change(function () {
        ListaPersonal();
        ListarReporteIncidenciasDatosFijos();
    });
    $('#cboPersonal').change(function () {
        ListarReporteIncidenciasDatosFijos();
    });
    $('#btnBuscar').click(function () {
        ListarReporteIncidenciasDatosFijos();
    });
    $('#btnDescargar').click(function () {
        var parametros = document.getElementById('periodoSession').value
            + ":" + $('#cboLocalidad').val()
            + ":" + $('#cboArea').val()
            + ":" + $('#cboProyecto').val()
            + ":" + $('#cboPersonal').val();
        fc_OpenReport("REP_INCIDENCIASDF", parametros, "1");
    });
};

function ListaArea() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaArea';

    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboLocalidad').html('');
            $('<option value="">--TODOS--</option>').appendTo('#cboLocalidad');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboLocalidad');
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
        async: false,
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
function ListaProyecto() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaProyecto';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboProyecto').html('');
            $('<option value="">--TODOS--</option>').appendTo('#cboProyecto');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboProyecto');
            }
        },
        error:
            function (XmlHttpError, error, description) {
                alert(XmlHttpError.responseText);
            }
    });
}
function ListaPersonal() {
    $('#imgCargando').show();
    $('#lblprogreso').html('Cargando...');
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListarPersonal';
    var params = {
        Periodo: document.getElementById('periodoSession').value,
        Localidad: $('#cboLocalidad').val(),
        Area: $('#cboArea').val(),
        Proyecto: $('#cboProyecto').val()
    };
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        data: JSON.stringify(params),
        dataType: "json",
        async: true,
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboPersonal').html('');
            $('<option value="">--TODOS--</option>').appendTo('#cboPersonal');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboPersonal');
            }
            $('#imgCargando').hide();
            $('#lblprogreso').html('');
        },
        error:
            function (XmlHttpError, error, description) {
                alert(XmlHttpError.responseText);
            }
    });
}

function ListarReporteIncidenciasDatosFijos() {

    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListarReporteIncidenciasDatosFijos';

    var params = {
        Periodo: document.getElementById('periodoSession').value,
        Localidad: $('#cboLocalidad').val(),
        Area: $('#cboArea').val(),
        Proyecto: $('#cboProyecto').val(),
        Personal: $('#cboPersonal').val()
    };
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        data: JSON.stringify(params),
        dataType: "json",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#tbodydata').html('');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<tr>';
                html += '<td>' + Datos[i][0] + '</td>';
                html += '<td>' + Datos[i][1] + '</td>';
                html += '<td>' + Datos[i][2] + '</td>';
                html += '<td>' + Datos[i][3] + '</td>';
                html += '<td>' + Datos[i][4] + '</td>';
                html += '<td>' + Datos[i][5] + '</td>';
                html += '<td>' + Datos[i][6] + '</td>';
                html += '<td style="text-align:right;">' + Datos[i][7] + '</td>';
                html += '<td style="text-align:right;">' + Datos[i][8] + '</td>';
                html += '</tr>';
                $(html).appendTo('#tbodydata');
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: true
    });

}

function fc_OpenReport(e, t, r) { var o = "750"; "1" == r && (o = "1050"); var a = "../Reportes/FrmPrint.aspx?Reporte_Id=" + e + "&prm=" + t; window.open(a, "_blank", "status=1,toolbar=no,menubar=no,location=no,scrollbars=1,resizable=1,width=" + o + ",height=600") }