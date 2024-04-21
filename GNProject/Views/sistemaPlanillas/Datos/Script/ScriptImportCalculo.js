
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
    calculos = [];
    $('#tbodyDatos').html('');
    var lineas = contenido.split("\r\n");
    for (var i = 0; i <= lineas.length - 1; i++) {
        var valores = lineas[i].split('|');        
        if (valores.length > 1) {
            calculos.push(valores);
            var html = '<tr>';
            html += '<td>' + valores[1] + '</td>';
            html += '<td>' + valores[2] + '</td>';
            html += '<td>' + valores[3] + '</td>';
            html += '<td>' + valores[4] + '</td>';
            html += '<td>' + valores[5] + '</td>';
            html += '<td>' + valores[7] + '</td>';
            html += '<td>' + valores[8] + '</td>';
            html += '<td>' + valores[9] + '</td>';
            html += '<td>' + valores[11] + '</td>';
            html += '<td>' + valores[12] + '</td>';
            html += '<td>' + valores[13] + '</td>';
            html += '<td id="res' + valores[0] + valores[8] + valores[6] + valores[10] + '">&nbsp;</td>';
            html += '</tr>';
            $(html).appendTo('#tbodyDatos');
        }
    }
}
document.getElementById('file-input').addEventListener('change', leerArchivo, false);
var calculos = [];
$(document).ready(function () {
    $('#btnGuardar').click(function () {
        if (confirm('¿Está seguro(a) de continuar?')) {
            if (calculos.length == 0) {
                alert('No se ha detectado ninguna información.');
            } else {
                GuardarCalculos()
            }
        }
    });

});

function GuardarCalculos() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/GuardarCalculo';
    for (var i = 0; i <= calculos.length - 1; i++) {
        var valores = calculos[i];
        var params = {
            pPeriodo: valores[0],
            pConcepto: valores[8],
            pPersonal: valores[6],
            pProceso: valores[10],
            pValor: valores[13],
        };
        $.ajax({
            type: "POST",
            url: urlajax,
            contentType: "application/json; chartseft:utf-8",
            data: JSON.stringify(params),
            dataType: "json",
            success: function (response) {
                var datos = response.d;
                var rt = datos.split('#');
                console.log(rt);
                $('#res' + rt[2]).html(rt[1]);
            },
            error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
            async: true
        });

    }

}