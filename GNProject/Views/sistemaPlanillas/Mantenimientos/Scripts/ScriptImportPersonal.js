
function leerArchivo(e) {
    var archivo = e.target.files[0];
    if (!archivo) {
        return;
    }
    var lector = new FileReader();
    lector.onload = function (e) {
        var contenido = e.target.result;
        mostrarContenido(contenido);
    };
    lector.readAsText(archivo);
}
function mostrarContenido(contenido) {
    importP = [];
    $('#tbodyDatos').html('');
    var lineas = contenido.split("\r\n");
    for (var i = 0; i <= lineas.length - 1; i++) {
        var valores = lineas[i].split('|');
        if (valores.length > 1) {
            importP.push(valores);
            //console.log(valores);
            var html = '<tr id="tr' + valores[2] + '">';
            html += '<td>' + valores[0] + '</td>';
            html += '<td>' + valores[1] + '</td>';
            html += '<td>' + valores[2] + '</td>';
            html += '<td>' + valores[3] + '</td>';
            html += '<td>' + valores[4] + '</td>';
            html += '<td>' + valores[5] + '</td>';
            html += '<td>' + valores[6] + '</td>';
            html += '<td>' + valores[7] + '</td>';
            html += '<td>' + valores[8] + '</td>';
            html += '<td>' + valores[9] + '</td>';
            html += '<td>' + valores[10] + '</td>';
            html += '<td>' + valores[11] + '</td>';
            html += '<td>' + valores[12] + '</td>';
            html += '<td>' + valores[13] + '</td>';
            html += '<td>' + valores[14] + '</td>';
            html += '<td>' + valores[15] + '</td>';
            html += '<td>' + valores[16] + '</td>';
            html += '<td>' + valores[17] + '</td>';
            html += '<td>' + valores[18] + '</td>';
            html += '<td>' + valores[19] + '</td>';
            html += '<td>' + valores[20] + '</td>';
            html += '<td>' + valores[21] + '</td>';
            html += '<td>' + valores[22] + '</td>';
            html += '<td>' + valores[23] + '</td>';
            html += '<td>' + valores[24] + '</td>';
            html += '<td>' + valores[25] + '</td>';
            html += '<td>' + valores[26] + '</td>';
            html += '<td>' + valores[27] + '</td>';
            html += '<td>' + valores[28] + '</td>';
            html += '<td>' + valores[29] + '</td>';
            html += '<td>' + valores[30] + '</td>';
            html += '<td>' + valores[31] + '</td>';
            html += '<td>' + valores[32] + '</td>';
            html += '<td>' + valores[33] + '</td>';
            html += '<td>' + valores[34] + '</td>';
            html += '<td>' + valores[35] + '</td>';
            html += '<td>' + valores[36] + '</td>';
            html += '<td>' + valores[37] + '</td>';
            html += '<td>' + valores[38] + '</td>';
            html += '<td>' + valores[39] + '</td>';
            html += '<td>' + valores[40] + '</td>';
            html += '<td>' + valores[41] + '</td>';
            html += '<td>' + valores[42] + '</td>';
            html += '<td>' + valores[43] + '</td>';
            html += '<td>' + valores[44] + '</td>';
            html += '<td>' + valores[45] + '</td>';
            html += '<td>' + valores[46] + '</td>';
            html += '<td>' + valores[47] + '</td>';
            html += '<td>' + valores[48] + '</td>';
            html += '<td>' + valores[49] + '</td>';
            html += '<td>' + valores[50] + '</td>';
            html += '<td>' + valores[51] + '</td>';
            html += '<td>' + valores[52] + '</td>';
            html += '<td>' + valores[53] + '</td>';
            html += '<td id="res' + valores[2]+ '">&nbsp;</td>';
            html += '</tr>';
            $(html).appendTo('#tbodyDatos');
        }
    }
    $('#lblprogreso').html(importP.length + ' Registros.');
}
document.getElementById('file-input').addEventListener('change', leerArchivo, false);
var importP = [];
$(document).ready(function () {
    $('#btnGuardar').click(function () {
        if (confirm('¿Está seguro(a) de continuar?')) {
            if (importP.length == 0) {
                alert('No se ha detectado ninguna información.');
            } else {
                GuardarPersonal()
            }
        }
    });

});

function GuardarPersonal() {
    var avance = 0, error = 0;
    $('#imgCargando').show();
    $('#lblprogreso').html("Procesando..." + avance + ' de ' + importP.length + ' registros. Errores: ' + error);
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ProcesarImportPersonal';
    var SessionUsuarioAcceso = 'Admin';
    for (var i = 0; i <= importP.length - 1; i++) {
        var valores = importP[i];
        var params = {
            xPeriodo: $('#ctl00_ucFiltros1_cboPeriodo').val(),
            xUsuario: SessionUsuarioAcceso,
            prm: valores,
        };
        $.ajax({
            type: "POST",
            url: urlajax,
            contentType: "application/json; chartseft:utf-8",
            data: JSON.stringify(params),
            dataType: "json",
            success: function (response) {
                var datos = response.d;
                console.log(datos);
                $('#res' + datos[3]).html(datos[2]);
                avance += 1;
                if (datos[0] == 'true') {
                    $('#tr' + datos[3]).css('background-color', '#BFEFDA');                    
                } else {
                    $('#tr' + datos[3]).css('background-color', '#F9D0D0');
                    error += 1;
                }
                $('#lblprogreso').html("Procesando..." + avance + ' de ' + importP.length + ' registros. Errores: ' + error);
                if (avance == importP.length) { $('#imgCargando').hide(); }
            },
            error:
                function (XmlHttpError, error, description) {
                    error += 1;
                    $("#divError").html(XmlHttpError.responseText);
                },
            async: true
        });

    }

}