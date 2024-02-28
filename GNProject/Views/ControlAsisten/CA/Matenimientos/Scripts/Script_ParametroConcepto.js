//funcion listar periodos

function Get_Parametro_List() {
    $.ajax({
        type: "POST",
        data: JSON.stringify(),
        dataType: "json",
        url: "ParametroXConcepto.aspx/Get_Parametro_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            $('#cboparametro').html('');
            var lengthDatos = Data.length - 1;
            $('<option value="">-SELECCIONAR-</option>').appendTo('#cboparametro');
            $("#cboparametro > option[value='']").attr("selected", true);
            for (var i = 0; i <= lengthDatos; i++) {
                var html = '<option value="' + Data[i].Parametro_Id + '">' + Data[i].Descripcion + '</option>';
                $(html).appendTo('#cboparametro');
            }
         
        },
        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: true
    });
}

// Lista Concepto

function Get_Concepto_List() {
    $.ajax({
        type: "POST",
        data: JSON.stringify(),
        dataType: "json",
        url: "ParametroXConcepto.aspx/Get_Concepto_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            $('#cboconcepto').html('');
            $('<option value="">-SELECCIONAR-</option>').appendTo('#cboconcepto');
            $("#cboconcepto > option[value='']").attr("selected", true);
            var lengthDatos = Data.length - 1;
            for (var i = 0; i <= lengthDatos; i++) {
                var html = '<option value="' + Data[i].Concepto_Id + '">' + Data[i].Descripcion + '</option>';
                $(html).appendTo('#cboconcepto');
            }
          
        },
        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: true
    });
}

// lista de parametros x concepto

function Get_Parametros_List(inicio) {
    var params = {
        inicio: inicio
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "ParametroXConcepto.aspx/ListaParametroConcepto",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            $('#tbodyParametros').html('');

            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {
                var html = '<tr>';
                html += '<td class="tbodyLink"><input id="btnEdit' + Data[i].Id + '" type="button"  value=""  class="ElLinkEditar" title="Editar Parametro" /></td>';
                html += '<td style="display:none;">' + Data[i].Concepto_Id + '</td>';
                html += '<td style="display:none;">' + Data[i].Parametro_Id + '</td>';
                html += '<td>' + Data[i].Concepto + '</td>';
                html += '<td>' + Data[i].Parametro + '</td>';
                if (Data[i].Estado == '01') {
                    //html += '<td>' + Data[i].C_estado + '</td>';
                    html += '<td>' + 'ACTIVO' + '</td>';
                } else {
                    html += '<td>' + 'INACTIVO' + '</td>';
                }

                switch (Data[i].semana) {
                    case '1':
                        html += '<td>' + 'SEMANA 1' + '</td>';
                        break;
                    case '2':
                        html += '<td>' + 'SEMANA 2' + '</td>';
                        break;
                    case '3':
                        html += '<td>' + 'SEMANA 3' + '</td>';
                        break;
                    case '4':
                        html += '<td>' + 'SEMANA 4' + '</td>';
                        break;
                    case '5':
                        html += '<td>' + 'SEMANA 5' + '</td>';
                        break;
                    case '15':
                        html += '<td>' + '1° QUINCENA' + '</td>';
                        break;
                    case '16':
                        html += '<td>' + '2° QUINCENA' + '</td>';
                        break;
                    case '30':
                        html += '<td>' + 'MENSUAL' + '</td>';
                        break;
                    default:
                        html += '<td>' + 'S/N' + '</td>';
                        break;
                    
                }

                html += '</tr>';

                $(html).appendTo('#tbodyParametros');
            }

        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}
// lista cantidad de datos

function Get_Parametros_MaxRegistro() {

    $.ajax({
        type: "POST",
        dataType: "json",
        url: "ParametroXConcepto.aspx/GetMaxData",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            setTotalRegistros(Data);
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });
}



function setTotalRegistros(TotalRegistros) {
    $('#txtnRegistros').val(TotalRegistros);
}


//funcion buscar y cargar turnos por codigo
function Get_Parametros_Find(codigo) {
    var params = {
        codigo: codigo
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "ParametroXConcepto.aspx/ListaParametroConceptoFind",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {
                $('#txtCodigo').val(Data[i].Id);
                $('#cboconcepto').val(Data[i].Concepto_Id);
                $('#cboparametro').val(Data[i].Parametro_Id);
                $('#cboestado').val(Data[i].Estado);
                $('#cbosemana').val(Data[i].semana);
            }

        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}
// insert
function Get_Parametros_Add(  Concepto_Id,   Parametro_Id,   Estado,semana) {
    param =
         {
             Concepto_Id: Concepto_Id,
             Parametro_Id: Parametro_Id,
             Estado: Estado,
             semana:semana
         };
    $.ajax({
        type: "POST",
        data: JSON.stringify(param),
        dataType: "json",
        url: "ParametroXConcepto.aspx/InsertaParametroConcepto",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            alert('Inserto Correctamenta')
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });
}

//actualizar turno
function Get_Parametros_Update(codigo, Concepto_Id, Parametro_Id, Estado,semana) {
    var params = {
        codigo: codigo,
        Concepto_Id: Concepto_Id,
        Parametro_Id: Parametro_Id,
        Estado: Estado,
        semana:semana
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "ParametroXConcepto.aspx/ActualizaParametroConcepto",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            alert('Modificado Correctamente')
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });
}

function Get_semana_List() {
    $.ajax({
        type: "POST",
        data: JSON.stringify(),
        dataType: "json",
        url: "ParametroXConcepto.aspx/ListaSemana",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            $('#cbosemana').html('');
            var lengthDatos = Data.length - 1;
            $('<option value="">-SELECCIONAR-</option>').appendTo('#cbosemana');
            $("#cbosemana > option[value='']").attr("selected", true);
            for (var i = 0; i <= lengthDatos; i++) {
                var html = '<option value="' + Data[i].id + '">' + Data[i].semana + '</option>';
                $(html).appendTo('#cbosemana');
            }
          
        },
        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: true
    });
}






function mensajeError(msg) {
    $('#lblError').html(msg);
}

function closeModalDiv() {
    $('#dialog-form').dialog('close');
}

// llamado al htlm

var TIPOPROCESO;

$(document).ready(function () {
    var inicio = 0;
    var TotalPaginador = 12;
    var TOTALREGISTROS;
    var PAGINAACTUAL = 1;


    $('#dialog-form').css('display', 'none');
    Get_Parametro_List();
    Get_Concepto_List();
    Get_semana_List();


    $('#btnCancelar').click(function () {
        closeModalDiv();
        Get_Parametros_List(inicio)
        Get_Parametros_MaxRegistro(getBuscar());
    });

    function pasaModal() {

        $("#dialog-form").dialog({
            height: 340, width: 460, modal: true, autoOpen: true,
            appendTo: "form", title: "MANTENIMIENTO DE PARAMETROS X CONCEPTO",
            show: { effect: "fade", duration: 800 },
            hide: { effect: "fold", duration: 800 }
        });
    }

    Get_Parametros_List(0);
    //            Get_Parametros_MaxRegistro();
    $('#tbodyParametros').on('click', '.ElLinkEditar', function () {
        TIPOPROCESO = '02';
        var codigo = this.id;
        codigo = codigo.substring(7);

        Get_Parametros_Find(codigo);
        Get_Parametros_List(inicio);
        pasaModal();
    });

    $('#txtnRegistros').val(Get_Parametros_MaxRegistro());

    $('#btnNew').click(function () {
        TIPOPROCESO = '01';
        inicilizaObjetos();
        pasaModal();
        // $('#btnGrabar').attr('disabled', false);
    });

    $("#tblParametros").on("click", '.Editar', function () {

        var href = $(this).attr('href');
        var codigo = href.substring(1);
        Get_Parametros_Find(codigo);
        pasaModal();
        //  $('#btnGrabar').attr('disabled', true);

    });

    $('#btnGrabar').click(function () {
        var codigo = $('#txtCodigo').val();
        var concepto_id = $('#cboconcepto').val();
        var parametro_id = $('#cboparametro').val();
        var estado = $('#cboestado').val();
        var semana = $('#cbosemana').val();

        if (concepto_id == '' || concepto_id == null) {
            mensajeError('ERROR... Debe seleccionar la concepto');
            $('#cboconcepto').focus();
            return false
        }
         
        if (parametro_id == '' || parametro_id == null) {
            mensajeError('ERROR... Debe seleccionar el variable');
            $('#cboparametro').focus();
            return false
        }


        mensajeError('&nbsp');
        if (TIPOPROCESO == "01") {

            Get_Parametros_Add(concepto_id, parametro_id, estado,semana);
            //$('#btnGrabar').attr('disabled', true);
        } else if (TIPOPROCESO == "02") {

            Get_Parametros_Update(codigo, concepto_id, parametro_id, estado,semana);
        }
        closeModalDiv();
        Get_Parametros_List(inicio);
        Get_Parametros_MaxRegistro();


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
            // var descripcion = $('#txtBuscar').val();
            Get_Parametros_List(inicio);
            Get_Parametros_MaxRegistro();

            setPaginaActual(PAGINAACTUAL);

        } else if (guardaPagina != TotalPaginador) {
            PAGINAACTUAL = Math.ceil(laPaginaActual);
            //var descripcion = $('#txtBuscar').val();
            Get_Parametros_List(inicio);
            Get_Parametros_MaxRegistro();
            setPaginaActual(PAGINAACTUAL);
        } else {
            inicio = 0;
        }

    });

    $('#btnPrimero').click(function () {  //metodos para actualizar
        inicio = 0;         //Primer Registro
        PAGINAACTUAL = 1;   //Primera Pagina
        //var descripcion = $('#txtBuscar').val();
        Get_Parametros_List(inicio);
        Get_Parametros_MaxRegistro();
        setPaginaActual(PAGINAACTUAL);
    });

    $('#btnAnterior').click(function () {  //metodos para actualizar
        if (inicio > 0) {
            inicio = parseInt(inicio) - TotalPaginador;
            PAGINAACTUAL = parseInt(PAGINAACTUAL) - 1;

            //var descripcion = $('#txtBuscar').val();
            Get_Parametros_List(inicio);
            Get_Parametros_MaxRegistro();
            setPaginaActual(PAGINAACTUAL);
        }

    });

    $('#btnSiguiente').click(function () {  //metodos para actualizar

        if (parseInt($('#txtnRegistros').val()) > (parseInt(inicio) + parseInt(TotalPaginador))) {
            inicio = parseInt(inicio) + parseInt(TotalPaginador);
            PAGINAACTUAL = parseInt(PAGINAACTUAL) + 1;

            // var descripcion = $('#txtBuscar').val();
            Get_Parametros_List(inicio);
            Get_Parametros_MaxRegistro();
            setPaginaActual(PAGINAACTUAL);
        }

    });

    function setPaginaActual(nPagina) { //Pintar la pagina actual visitada
        $('#txtPaginaActual').val(nPagina);
    }

    function inicilizaObjetos() {
        $('#txtCodigo').val('???');
        $('#cboconcepto').val('');
        $('#cboparametro').val('');
        $('#cboestado').val('01');
       

    }



});
