var inicio = 0;
var PROCESO = '';
var TotalPaginador = 12;
var TOTALREGISTROS;
var PAGINAACTUAL = 1;
function initilize() {
    $('#TabContainer').tabs();
    $('#TabContainer').tabs({ disabled: [1] });

    ListaLocalidad();
    ListaProyecto();
    ListaArea();
    Lista_Personal_CentroCosto();
    $('#btnCancel').click(function () {
        if (confirm('¿Está seguro(a) de cancelar todo?')) {
            datosAsig = [];
            centros = [];
            $('#TabContainer').tabs({ active: 0 });
            $('#TabContainer').tabs({ disabled: [1] });
        }
    });
    $('#btnUpdate').click(function () {
        if (confirm('¿Está seguro(a) de Actualizar?')) {
            ProcesarInformacion();
        }
    });
    $('#btnAgregar').click(function () {
        if (!$('#cboCCosto').val()) {
            alert('Seleccione un centro de costo');
        } else {
            agregarCentro($('#cboCCosto').val(), $('#cboCCosto option:selected').text());
        }
    });
    $('#tbodyPersonal').on('click', '.linkEditar', function () {
        PROCESO = '02';
        $('#TabContainer').tabs('enable');
        $('#TabContainer').tabs({ active: 1 });
        Buscar_Personal_CentroCosto(this.id);
    });
    $('#tbodyDetalle').on('click', '.linkEliminar', function () {
        if (confirm('¿Está seguro(a) de continuar?')) {
            quitarCentro(this.id);
        }
    });
    $("#tbodyDetalle").on('change', 'input', function () {
        cambiarCentro(this.id, $(this).val());
    });
    $('#btnUltimo').click(function () {  //metodos para actualizar

        var guardaPagina = parseInt($('#txtnRegistros').val());
        var laPaginaActual = guardaPagina / TotalPaginador;

        if (guardaPagina > 0 && guardaPagina < 10) {        //Hago un if para saber la ultima pagina
            inicio = 0;
            laPaginaActual = 1;                             //comparando el numero de pagina
        } else if (guardaPagina > 9 && guardaPagina < 100) {    //a division con el total de pagina
            inicio = (parseInt(guardaPagina.toString().substring(0, 1))) + "2";
        } else if (guardaPagina > 99 && guardaPagina < 1000) {
            inicio = guardaPagina.toString().substring(0, 2) + "2";
        } else if (guardaPagina > 999 && guardaPagina < 10000) {
            inicio = guardaPagina.toString().substring(0, 3) + "2";
        } else if (guardaPagina > 9999 && guardaPagina < 100000) {
            inicio = guardaPagina.toString().substring(0, 4) + "2";
        }

        if (inicio > guardaPagina)
            inicio = guardaPagina;

        if (guardaPagina == inicio) {
            inicio = inicio - TotalPaginador;
            PAGINAACTUAL = Math.ceil(laPaginaActual);
            Lista_Personal_CentroCosto();
            setPaginaActual(PAGINAACTUAL);

        } else if (guardaPagina != TotalPaginador) {
            PAGINAACTUAL = Math.ceil(laPaginaActual);
            Lista_Personal_CentroCosto();
            setPaginaActual(PAGINAACTUAL);
        } else {
            inicio = 0;
        }

    });

    $('#btnPrimero').click(function () {  //metodos para actualizar
        inicio = 0;         //Primer Registro
        PAGINAACTUAL = 1;   //Primera Pagina
        Lista_Personal_CentroCosto();
        setPaginaActual(PAGINAACTUAL);
    });

    $('#btnAnterior').click(function () {  //metodos para actualizar
        if (inicio > 0) {
            inicio = parseInt(inicio) - TotalPaginador;
            PAGINAACTUAL = parseInt(PAGINAACTUAL) - 1;
            Lista_Personal_CentroCosto();
            setPaginaActual(PAGINAACTUAL);
        }

    });
    $('#btnSiguiente').click(function () {  //metodos para actualizar

        if (parseInt($('#txtnRegistros').val()) > (parseInt(inicio) + parseInt(TotalPaginador))) {
            inicio = parseInt(inicio) + parseInt(TotalPaginador);
            PAGINAACTUAL = parseInt(PAGINAACTUAL) + 1;
            Lista_Personal_CentroCosto();
            setPaginaActual(PAGINAACTUAL);
        }

    });

    function setPaginaActual(nPagina) { //Pintar la pagina actual visitada
        $('#txtPaginaActual').val(nPagina);

    }
    $('#ctl00_ucFiltros1_cboPlanilla').change(function () {
        $('#cboTipoPlanilla').val($(this).val());
    });


    //IMPORTAR
    $('#btnGuardarImport').click(function () {
        if (confirm('¿Está seguro(a) de continuar?')) {
            if (importcc.length == 0) {
                alert('No se ha detectado ninguna información.');
            } else {
                ProcesarInformacionImport()
            }
        }
    });
}

function Lista_Personal_CentroCosto() {

    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaPersonalCentroCosto';
    var cbo = document.getElementById('periodoSession').value;
    var PeriodoId = cbo, LocalidadId = $('#cboLocalidad').val(), ProyectoId = $('#cboProyecto').val()
        , AreaId = $('#cboArea').val();
    var params = {
        PeriodoId: PeriodoId,
        LocalidadId: LocalidadId,
        ProyectoId: ProyectoId,
        AreaId: AreaId,
        inicio: inicio
    };
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        data: JSON.stringify(params),
        dataType: "json",
        success: function (response) {
            var datos = response.d;
            adecuarDatos(datos);
            var lengthD = datosAsig.length - 1;            
            $('#tbodyPersonal').html('');
            for (var i = 0; i <= lengthD; i++) {
                var canti = datosAsig[i].Centros.length;
                if (datosAsig[i].CcostoId2.trim() != '') { canti += 1;}
                var html = '<tr>';
                html += '<td rowspan="' + canti + '"><input type="button" class="linkEditar" id="' + datosAsig[i].PersonalId + '" title="" /></td>';
                html += '<td rowspan="' + canti + '">' + datosAsig[i].PersonalId + '</td>';
                html += '<td rowspan="' + canti + '">' + datosAsig[i].APaterno + '</td>';
                html += '<td rowspan="' + canti + '">' + datosAsig[i].AMaterno + '</td>';
                html += '<td rowspan="' + canti + '">' + datosAsig[i].Nombre + '</td>';
                html += '<td rowspan="' + canti + '">' + datosAsig[i].TDoc + '</td>';
                html += '<td rowspan="' + canti + '">' + datosAsig[i].NroDoc + '</td>';
                html += '<td rowspan="' + canti + '">' + datosAsig[i].Localidad + '</td>';
                html += '<td rowspan="' + canti + '">' + datosAsig[i].Proyecto + '</td>';
                html += '<td rowspan="' + canti + '">' + datosAsig[i].Area + '</td>';
                html += '<td>' + datosAsig[i].Centros[0].CcostoId + '</td>';
                html += '<td>' + datosAsig[i].Centros[0].NCcosto + '</td>';
                html += '<td>' + (datosAsig[i].Centros[0].Porcentaje > 0 ? datosAsig[i].Centros[0].Porcentaje+' %':'') + '</td>';
                html += '</tr>';
                $(html).appendTo('#tbodyPersonal');
                if (datosAsig[i].CcostoId2.trim() != '') { canti -= 1; }
                for (var v = 0; v <= canti - 1; v++) {
                    if (datosAsig[i].Centros[v].CcostoId2 != '') {
                        html = '<tr>';
                        html += '<td>' + datosAsig[i].Centros[v].CcostoId2 + '</td>';
                        html += '<td>' + datosAsig[i].Centros[v].NCcosto2 + '</td>';
                        html += '<td>' + (datosAsig[i].Centros[v].Porcentaje2 > 0 ? datosAsig[i].Centros[v].Porcentaje2 + ' %' : '') + '</td>';
                        html += '</tr>';
                        $(html).appendTo('#tbodyPersonal');
                    }
                }

                
                
            }
            Lista_Personal_CentroCosto_MaxRows();
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: true
    });

}
function Lista_Personal_CentroCosto_MaxRows() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaPersonalCentroCosto_MaxRows';
    var cbo = document.getElementById('periodoSession').value;
    var PeriodoId = cbo, LocalidadId = $('#cboLocalidad').val(), ProyectoId = $('#cboProyecto').val()
        , AreaId = $('#cboArea').val();
    var params = {
        PeriodoId: PeriodoId,
        LocalidadId: LocalidadId,
        ProyectoId: ProyectoId,
        AreaId: AreaId,
        inicio: inicio
    };
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        data: JSON.stringify(params),
        dataType: "json",
        success: function (response) {
            var data = response.d;
            $('#txtnRegistros').val(data);


        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: true
    });

}
function ListaLocalidad() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaLocalidad';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function (response) {
            var datos = response.d;
            var lengthD = datos.length - 1;
            $('#cboLocalidad').html('');
            $('<option value="">Todos</option>').appendTo('#cboLocalidad');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + datos[i][0] + '">' + datos[i][1] + '</option>';
                $(html).appendTo('#cboLocalidad');
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: false
    });
};
function ListaProyecto() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaProyecto';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function (response) {
            var datos = response.d;
            var lengthD = datos.length - 1;
            $('#cboProyecto').html('');
            $('<option value="">Todos</option>').appendTo('#cboProyecto');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + datos[i][0] + '">' + datos[i][1] + '</option>';
                $(html).appendTo('#cboProyecto');
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: false
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
        success: function (response) {
            var datos = response.d;
            var lengthD = datos.length - 1;
            $('#cboArea').html('');
            $('<option value="">Todos</option>').appendTo('#cboArea');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + datos[i][0] + '">' + datos[i][1] + '</option>';
                $(html).appendTo('#cboArea');
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: false
    });
};
function ListaCentroCosto(PersonalId) {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaCentroCosto';
    var cbo = document.getElementById('periodoSession').value;
    var PeriodoId = cbo;
    var params = {
        PeriodoId: PeriodoId,
        PersonalId: PersonalId
    };
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        data: JSON.stringify(params),
        dataType: "json",
        success: function (response) {
            var datos = response.d;
            var lengthD = datos.length - 1;
            $('#cboCCosto').html('');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + datos[i][0] + '">' + datos[i][1] + '</option>';
                $(html).appendTo('#cboCCosto');
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: true
    });
};
var datosAsig = [];
var centros = [];
function adecuarDatos(xdatos) {
    datosAsig = [];
    for (var i = 0; i <= xdatos.length - 1; i++) {
        var cod = xdatos[i].PersonalId;
        if (datosAsig.filter(f => f.PersonalId == cod).length == 0) {
            datosAsig.push({
                PersonalId: xdatos[i].PersonalId,
                APaterno: xdatos[i].APaterno,
                AMaterno: xdatos[i].AMaterno,
                Nombre: xdatos[i].Nombre,
                TDoc: xdatos[i].TDoc,
                NroDoc: xdatos[i].NroDoc,
                Localidad: xdatos[i].Localidad,
                Proyecto: xdatos[i].Proyecto,
                Area: xdatos[i].Area,
                CcostoId: xdatos[i].CcostoId,
                NCcosto: xdatos[i].NCcosto,
                CcostoId2: xdatos[i].CcostoId2,
                NCcosto2: xdatos[i].NCcosto2,
                Porcentaje: xdatos[i].Porcentaje,
                Porcentaje2: xdatos[i].Porcentaje2,
                Centros: xdatos.filter(w => w.PersonalId == cod)
            });
        }
    }
}


function Buscar_Personal_CentroCosto(PersonalId) {

    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/FindPersonalCentroCosto';
    var cbo = document.getElementById('periodoSession').value;
    var PeriodoId = cbo;
    var params = {
        PeriodoId: PeriodoId,
        PersonalId: PersonalId
    };
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        data: JSON.stringify(params),
        dataType: "json",
        success: function (response) {
            var datos = response.d;
            var lengthD = datos.length - 1;
            var cbop = document.getElementById('planillaSession').value;
            $('#tbodyDetalle').html('');
            var perso = '';
            centros = [];
            for (var i = 0; i <= lengthD; i++) {
                if (datos[i].PersonalId != '') {
                    perso = datos[i].PersonalId;
                    $('#lblpersonal').html(datos[0].APaterno + ' ' + datos[0].AMaterno + ', ' + datos[0].Nombre);
                    $('#idPersonal').val(datos[i].PersonalId);
                    $('#idPeriodo').val(PeriodoId);
                    $('#idPlanilla').val(cbop);
                }
                centros.push({ CcostoId: datos[i].CcostoId, NCcosto: datos[i].NCcosto, Porcentaje: datos[i].Porcentaje, Rem: datos[i].CcostoId2});                
            }
            ListaCentroCosto(perso);
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: false
    });
    cargarDetalle();
}
function cargarDetalle() {
    $('#tbodyDetalle').html('');
    var totalpor = 0;
    for (var i = 0; i <= centros.length - 1; i++) {
        var html = '<tr>';
        if (centros[i].Rem == '1') { html += '<td><input type="button" class="linkEliminar" id="' + centros[i].CcostoId + '" title="" /></td>'; }
        else { html += '<td>&nbsp;</td>'; }
        html += '<td>' + centros[i].CcostoId + '</td>';
        html += '<td>' + centros[i].NCcosto + '</td>';
        html += '<td><input id="' + centros[i].CcostoId + '" type="number" min="1" value="' + centros[i].Porcentaje + '" max="100" placeholder="%" class="ddl" /></td>';
        html += '</tr>';
        $(html).appendTo('#tbodyDetalle');
        totalpor += parseInt(centros[i].Porcentaje);
    }
    $('#lblTPor').html(totalpor + '%');
}

function agregarCentro(centroid,ncentro) {
    for (var i = 0; i <= centros.length - 1; i++) {
        if (centros[i].CcostoId == centroid) {
            alert('El centro de costo ya está en la lista, seleccione otro.');
            return;
        }
    }
    centros.push({ CcostoId: centroid, NCcosto: ncentro, Porcentaje: 1, Rem: '1' });
    alert('El centro de costo agregado.');
    cargarDetalle();
}
function quitarCentro(centroid) {
    for (var i = 0; i <= centros.length - 1; i++) {
        if (centros[i].CcostoId == centroid) {
            centros.splice(i, 1);
            alert('El centro de costo removido.');
            cargarDetalle();
            return;
        }
    }
    
}
function cambiarCentro(centroid, por) {
    for (var i = 0; i <= centros.length - 1; i++) {
        if (centros[i].CcostoId == centroid) {
            centros[i].Porcentaje = por;
            contarprocentaje();
        }
    }
}
function contarprocentaje() {
    var totalpor = 0;
    for (var i = 0; i <= centros.length - 1; i++) {
        totalpor += parseInt(centros[i].Porcentaje);
    }
    $('#lblTPor').html(totalpor + '%');
}

function ProcesarInformacion() {
    var cdatos = [];
    var cpor = 0;
    for (var i = 0; i <= centros.length - 1; i++) {
        cdatos.push({
            PlanillaId: $('#idPlanilla').val(),
            PeriodoId: $('#idPeriodo').val(),
            PersonalId: $('#idPersonal').val(),
            CcostoId: centros[i].CcostoId,
            Porcentaje: centros[i].Porcentaje,
            Tipo: centros[i].Rem
        });
        cpor += parseInt(centros[i].Porcentaje);
    }
    if (cpor > 100) {
        alert('La distribución supera el 100%, verificar los datos.');
        return;
    }
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ActualizarPersonalCentroCosto';
    var params = {
        datos: cdatos
    };
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        data: JSON.stringify(params),
        dataType: "json",
        success: function (response) {
            var datos = response.d;
            var rsl = datos.split('#');
            if (rsl[0] == "true") {
                alert(rsl[1]);
                datosAsig = [];
                centros = [];
                $('#TabContainer').tabs({ active: 0 });
                $('#TabContainer').tabs({ disabled: [1] });
                Lista_Personal_CentroCosto();
            } else {
                alert(rsl[1]);
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: false
    });
}


//IMPORTACION
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
    importcc = [];
    centrosImpor = [];
    $('#tbodyImport').html('');
    var lineas = contenido.split("\r\n");
    for (var i = 0; i <= lineas.length - 1; i++) {
        var valores = lineas[i].split('|');
        if (valores.length > 1) {
            importcc.push(valores);
            var ti = (valores[10]).toUpperCase().trim();
            if (ti == 'P') { ti = '0'; } else { ti = '1'; }
            centrosImpor.push({
                PlanillaId: '', PeriodoId: valores[0], PersonalId: valores[6]
                , CcostoId: valores[8], Porcentaje: valores[11], Rem: ti
            });
        }
    }
    importcc.sort(function (a, b) {
        if (a[5] > b[5]) { return 1; }
        if (a[5] < b[5]) { return -1; }
        return 0;
    });
    for (var i = 0; i <= importcc.length - 1; i++) {
        var valores = importcc[i];
        var html = '<tr>';
        html += '<td>' + valores[7] + '</td>';
        html += '<td>' + valores[5] + '</td>';
        html += '<td>' + valores[1] + '</td>';
        html += '<td>' + valores[2] + '</td>';
        html += '<td>' + valores[3] + '</td>';
        html += '<td>' + valores[4] + '</td>';
        html += '<td>' + valores[8] + '</td>';
        html += '<td>' + valores[9] + '</td>';
        html += '<td>' + valores[10] + '</td>';
        html += '<td>' + valores[11] + '</td>';
        html += '<td id="res' + valores[0] + valores[6] + valores[8] + '">&nbsp;</td>';
        html += '</tr>';
        $(html).appendTo('#tbodyImport');
    }
}
document.getElementById('file-input').addEventListener('change', leerArchivo, false);
var importcc = [];


function ProcesarInformacionImport() {
    var personas = [];
    for (var f = 0; f <= centrosImpor.length - 1; f++) {
        if (personas.indexOf(centrosImpor[f].PersonalId) < 0) {
            personas.push(centrosImpor[f].PersonalId);
        }

    }
    for (var p = 0; p <= personas.length - 1; p++) {
        var select = centrosImpor.filter(t => t.PersonalId == personas[p]);
        var cdatos = [];
        var cpor = 0;
        for (var i = 0; i <= select.length - 1; i++) {
            cdatos.push({
                PlanillaId: select[i].PlanillaId,
                PeriodoId: select[i].PeriodoId,
                PersonalId: select[i].PersonalId,
                CcostoId: select[i].CcostoId,
                Porcentaje: select[i].Porcentaje,
                Tipo: select[i].Rem
            });
            cpor += parseInt(select[i].Porcentaje);
        }
        if (cpor > 100) {
            alert('La distribución supera el 100%, verificar los datos.');
            return;
        }
        var pagePath = window.location.pathname;
        var urlajax = pagePath + '/ActualizarPersonalCentroCosto';
        var params = {
            datos: cdatos
        };
        $.ajax({
            type: "POST",
            url: urlajax,
            contentType: "application/json; chartseft:utf-8",
            data: JSON.stringify(params),
            dataType: "json",
            success: function (response) {
                var datos = response.d;
                var rsl = datos.split('#');
                if (rsl[0] == "true") {
                    $('#res' + rsl[2]).html(rsl[1]);
                    
                } else {
                    $('#res' + rsl[2]).html(rsl[1]);
                }
            },
            error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
            async: true
        });
    }

    Lista_Personal_CentroCosto();
}