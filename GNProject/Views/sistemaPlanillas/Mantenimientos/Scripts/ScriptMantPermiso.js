var disNew;
var disGrabar;
var disCancel;
var disUpdate;
var disDelete;
var TotalPaginador = 12;
var TOTALREGISTROS;
var PAGINAACTUAL = 1;
var inicio = 0;
function initilize() {
    $('#TabContainer').tabs();
    $('#TabContainer').tabs({ disabled: [1] });
    disGrabar = window.setInterval(function () {
        Disable_btnGrabar(true);
    }, 100);

    disCancel = window.setInterval(function () {
        Disable_btnCancelar(true);
    }, 100);

    disUpdate = window.setInterval(function () {
        Disable_btnActualizar(true);
    }, 100);

    disDelete = window.setInterval(function () {
        Disable_btnEliminar(true);
    }, 100);
    Get_Permiso_MS_Listar();
    $('#txtBuscar').keyup(function () {
        if ($('#cboBusquedaEn').val() != 'Todos') {
            inicio = 0;
            Get_Permiso_MS_Listar();
        }
    });

    //EVENTOS
    $('#tbodydatos').on('click', '.linkEditar', function () {
        var lcodigo = this.id.substring(3);

        //CargarDatos(); //@001 I/F
        clearDocumento();
        $('#hcodigo').val(lcodigo);
        Get_Permiso_MS_Buscar();

        window.clearInterval(disNew);
        window.clearInterval(disGrabar);
        window.clearInterval(disCancel);
        window.clearInterval(disUpdate);
        window.clearInterval(disDelete);

        Disable_btnActualizar(false);
        Disable_btnCancelar(false);

        disNew = window.setInterval(function () {
            Disable_btnNew(true);
        }, 100);

        disGrabar = window.setInterval(function () {
            Disable_btnGrabar(true);
        }, 100);

        disDelete = window.setInterval(function () {
            Disable_btnEliminar(true);
        }, 100);
        
        $('#TabContainer').tabs('enable');
        $('#TabContainer').tabs({ active: 1 });


    });
    $('#btnNew').click(function () {
        disNew = window.setInterval(function () {
            Disable_btnNew(true);
        }, 100);

        window.clearInterval(disGrabar);
        window.clearInterval(disCancel);

        Disable_btnGrabar(false);
        Disable_btnCancelar(false);

        $('#TabContainer').tabs('enable');
        $('#TabContainer').tabs({ active: 1 });
        clearDocumento();
        $('#hcodigo').val(0);
    });

    $('#btnCancel').click(function () {
        cancel();

    });

    $('#btnAdd').click(function () {
        Get_Permiso_MS_Procesar(1);
    });

    $('#btnUpdate').click(function () {
        Get_Permiso_MS_Procesar(2);
    });
    $('#tbodydatos').on('click', '.linkEliminar', function () {

        if (confirm('¿Esta seguro de eliminar el permiso?')) {
            var lcodigo = this.id.substring(3);
            $('#hcodigo').val(lcodigo);
            Get_Permiso_MS_Procesar(3);
        }

    });


    //NAVEGACION

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
            Get_Permiso_MS_Listar();
            setPaginaActual(PAGINAACTUAL);

        } else if (guardaPagina != TotalPaginador) {
            PAGINAACTUAL = Math.ceil(laPaginaActual);
            Get_Permiso_MS_Listar();
            setPaginaActual(PAGINAACTUAL);
        } else {
            inicio = 0;
        }

    });

    $('#btnPrimero').click(function () {  //metodos para actualizar
        inicio = 0;         //Primer Registro
        PAGINAACTUAL = 1;   //Primera Pagina
        Get_Permiso_MS_Listar();
        setPaginaActual(PAGINAACTUAL);
    });

    $('#btnAnterior').click(function () {  //metodos para actualizar
        if (inicio > 0) {
            inicio = parseInt(inicio) - TotalPaginador;
            PAGINAACTUAL = parseInt(PAGINAACTUAL) - 1;
            Get_Permiso_MS_Listar();
            setPaginaActual(PAGINAACTUAL);
        }

    });
    $('#btnSiguiente').click(function () {  //metodos para actualizar

        if (parseInt($('#txtnRegistros').val()) > (parseInt(inicio) + parseInt(TotalPaginador))) {
            inicio = parseInt(inicio) + parseInt(TotalPaginador);
            PAGINAACTUAL = parseInt(PAGINAACTUAL) + 1;
            Get_Permiso_MS_Listar();
            setPaginaActual(PAGINAACTUAL);
        }

    });

    function setPaginaActual(nPagina) { //Pintar la pagina actual visitada
        $('#txtPaginaActual').val(nPagina);

    }
}

function cancel() {
    window.clearInterval(disNew);
    window.clearInterval(disGrabar);
    window.clearInterval(disCancel);
    window.clearInterval(disUpdate);
    window.clearInterval(disDelete);

    Disable_btnNew(false);

    disGrabar = window.setInterval(function () {
        Disable_btnGrabar(true);
    }, 100);

    disCancel = window.setInterval(function () {
        Disable_btnCancelar(true);
    }, 100);

    disUpdate = window.setInterval(function () {
        Disable_btnActualizar(true);
    }, 100);

    disDelete = window.setInterval(function () {
        Disable_btnEliminar(true);
    }, 100);

    $('#TabContainer').tabs({ disabled: [1] });
    $('#TabContainer').tabs({ active: 0 });
    Get_Permiso_MS_Listar();
}
function clearDocumento() {
    $('#tDescripcion').val('');
    $('#cboConcepto').val('');
    $('#tMeses').val('');
    $('#tDias').val('');

};
function Get_Permiso_MS_Listar() {
    var descripcion = $('#txtBuscar').val();
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/Get_Permiso_MS_Listar';

    var params = {
        descripcion: descripcion,
        inicio: inicio
    };
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        data: JSON.stringify(params),
        dataType: "json",
        success: function (response) {
            //var Datos = response.d;
            var objResponse = response.d;
            var Datos = objResponse.oBandeja; //@001 I/F
            var qt_registros = objResponse.qt_registros; //@001 I/F
            var lengthD = Datos.length - 1;
            $('#tbodydatos').html('');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<tr>';
                html += '<td><input type="button" class="linkEditar" id="lnk' + Datos[i].Permiso_Id + '" title="" /></td>';
                html += '<td><input type="button" class="linkEliminar" id="del' + Datos[i].Permiso_Id + '" title="" /></td>';
                html += '<td>' + Datos[i].Permiso_Id + '</td>';
                html += '<td>' + Datos[i].descripcion + '</td>';
                html += '<td>' + Datos[i].NConcepto + '</td>';
                html += '<td>' + Datos[i].fechaAcumulado + '</td>';
                html += '<td>' + Datos[i].ejecutaAcumuladoDias + '</td>';                
                html += '</tr>';
                $(html).appendTo('#tbodydatos');
            }
            $('#txtnRegistros').val(qt_registros); //@001 I/F
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: true
    });

}
function Get_Permiso_MS_Procesar(Proceso) {
    var codigo = $('#hcodigo').val();
    var descripcion = '', concepto = '', meses = '', dias = 0;
    if (Proceso == 1 || Proceso == 2) {
        var descripcion = $('#tDescripcion').val();
        var concepto = $('#cboConcepto').val();
        var meses = $('#tMeses').val();
        var dias = $('#tDias').val();

        if (!$.trim(descripcion)) {
            Set_Error('.::Error, Descripción no definida.', 'tDescripcion', 1);
            return false;
        }
        if (!$.trim(concepto)) {
            Set_Error('.::Error, Concepto no definido.', 'cboConcepto', 1);
            return false;
        }
        if (!$.trim(meses)) {
            Set_Error('.::Error, Concepto no definido.', 'tMeses', 1);
            return false;
        }
        if (!$.trim(dias)) {
            Set_Error('.::Error, Concepto no definido.', 'tDias', 1);
            return false;
        }
    }

    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/Get_Permiso_MS_Mantenimiento';

    var params = {
        tipoProceso: Proceso
        , Permiso_Id: codigo
        , descripcion: descripcion
        , fechaAcumulado: meses
        , ejecutaAcumulado: dias
        , ConceptoId: concepto
    };
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        data: JSON.stringify(params),
        dataType: "json",
        success: function (response) {
            var objResponse = response.d;
            if (objResponse.split('#')[0] == "true") {
                alert(objResponse.split('#')[1]);
                clearDocumento();
                cancel();
            } else{
                alert(objResponse.split('#')[1]);
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: false
    });

}
function Get_Permiso_MS_Buscar() {
    var codigo = $('#hcodigo').val();
    console.log(codigo);
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/Get_Permiso_MS_Buscar';

    var params = {
        Permiso_Id: codigo
    };
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        data: JSON.stringify(params),
        dataType: "json",
        success: function (response) {
            var objResponse = response.d;
            if (objResponse.length > 0) {
                $('#hcodigo').val(objResponse[0][0]);
                $('#tDescripcion').val(objResponse[0][1]);
                $('#cboConcepto').val(objResponse[0][4]);
                $('#tMeses').val(objResponse[0][2]);
                $('#tDias').val(objResponse[0][3]);
            } else {
                alert('Error: Permiso no identificado.');
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: false
    });

}
function Set_Error(Mensaje, objFocus, IndiceActive) {
    $('#lblError').html(Mensaje);
    if (objFocus) {
        $('#' + objFocus).focus();
        var active = $('#TabContainer').tabs('option', 'active');
        if (parseInt(active) != parseInt(IndiceActive)) {
            $('#TabContainer').tabs({ active: IndiceActive });
        }

    }
}
//DISABLE BOTONES

function Disable_btnNew(ope) {
    document.getElementById('btnNew').disabled = ope;
}
function Disable_btnGrabar(ope) {
    document.getElementById('btnAdd').disabled = ope;
}
function Disable_btnCancelar(ope) {
    document.getElementById('btnCancel').disabled = ope;
}
function Disable_btnActualizar(ope) {
    document.getElementById('btnUpdate').disabled = ope;
}
function Disable_btnEliminar(ope) {
    document.getElementById('btnDelete').disabled = ope;
}