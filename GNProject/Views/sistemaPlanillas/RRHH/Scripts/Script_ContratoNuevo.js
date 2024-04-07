/*
    NOTAS:
    ======
    @001 FPS 07/04/2020 - Ajustes 
*/

function initilize() {
    ListaTipoPlanilla();
    ListaPeriodo();
    cargarBancos();
    cargarRegPensionario();
    document.getElementById('cboRegPensionario').value = "99"; //@001 I/F
    cargarEstadoCivil();
    cargarTipoContrato();
    cargarCargo();
    cargarFuncionesxCargo(); $("#tdFunciones").hide();
    cargarArea();
    cargarCatAuxiliar();
    cargarCatAuxiliar2();
    ListaJefe();
    ListaCoordinador();
    ListaJefeCoordinadorGerente();
    cargarSeguroMedico();

    $("#txtFecNacim").datepicker({
        dateFormat: "dd/mm/yy",
        defaultDate: "+1w",
        //changeMonth: true,
        changeYear: true
    });
    $("#txtFecIngreso").datepicker({
        dateFormat: "dd/mm/yy",
        defaultDate: "+1w",
        //changeMonth: true,
        changeYear: true
    });
    $("#txtFecIniContrato").datepicker({
        dateFormat: "dd/mm/yy",
        defaultDate: "+1w",
        //changeMonth: true,
        changeYear: true
    });
    $("#txtFecFinContrato").datepicker({
        dateFormat: "dd/mm/yy",
        defaultDate: "+1w",
        //changeMonth: true,
        changeYear: true
    });
    $('#cboCatAuxiliar').change(function () {
        cargarCatAuxiliar2();
        ListaJefe();
        ListaCoordinador();
        ListaJefeCoordinadorGerente();
    });
    $("#cboCargo").change(function () {
        cargarFuncionesxCargo();
    });
    $("#chkAsigFunciones").change(function () {
        var flCheck = $(this).prop("checked");
        if (flCheck) { $("#tdFunciones").show(); }
        else { $("#tdFunciones").hide(); }

        cargarFuncionesxCargo();
    });

    $('#btnNew').click(function () {
        clearDocumento();
    });
    $('#btnAdd').click(function () {
        if (Valida_Datos() == true) {
            GuardarPersonal();
        }
    });
};
function ListaTipoPlanilla() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaTipoPlanilla';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#cboPlanilla').html('');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboPlanilla');
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: false
    });
}
function ListaPeriodo() {
    var EjercicioId = document.getElementById('anioSession').value, Planilla_Id = $('#cboPlanilla').val(), MesId = document.getElementById('mesSession').value;
    var params = {
        EjercicioId: EjercicioId,
        Planilla_Id: Planilla_Id,
        MesId: MesId
    };
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaPeriodo';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        data: JSON.stringify(params),
        dataType: "json",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#cboPeriodo').html('');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboPeriodo');
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: false
    });
}
function cargarBancos() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaBanco';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function (response) {
            var datos = response.d;
            $('#cboBanco').html('');
            $('#cboBancoCTS').html('');
            for (var i = 0; i <= datos.length - 1; i++) {
                $('<option value="' + datos[i][0] + '">' + datos[i][1] + '</>').appendTo('#cboBanco');
                $('<option value="' + datos[i][0] + '">' + datos[i][1] + '</>').appendTo('#cboBancoCTS');
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: false
    });
};
function cargarRegPensionario() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaRegPensionario';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function (response) {
            var datos = response.d;
            $('#cboRegPensionario').html('');
            for (var i = 0; i <= datos.length - 1; i++) {
                $('<option value="' + datos[i][0] + '">' + datos[i][1] + '</>').appendTo('#cboRegPensionario');
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: false
    });
};
function cargarEstadoCivil() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaEstadoCivil';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function (response) {
            var datos = response.d;
            $('#cboECivil').html('');
            for (var i = 0; i <= datos.length - 1; i++) {
                $('<option value="' + datos[i][0] + '">' + datos[i][1] + '</>').appendTo('#cboECivil');
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: false
    });
};
function cargarTipoContrato() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaTipoContrato';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function (response) {
            var datos = response.d;
            $('#cboTipoContrato').html('');
            $('<option value="">-Seleccione-</>').appendTo('#cboTipoContrato'); //@001 I/F
            for (var i = 0; i <= datos.length - 1; i++) {
                $('<option value="' + datos[i][0] + '">' + datos[i][1] + '</>').appendTo('#cboTipoContrato');
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: false
    });
};
function cargarCargo() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaCargo';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function (response) {
            var datos = response.d;
            $('#cboCargo').html('');
            $('<option value="">-Seleccione-</>').appendTo('#cboCargo');
            for (var i = 0; i <= datos.length - 1; i++) {
                $('<option value="' + datos[i][0] + '">' + datos[i][1] + '</>').appendTo('#cboCargo');
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: false
    });
};
function cargarFuncionesxCargo() {
    var flCheck = $("#chkAsigFunciones").prop("checked");
    var Cargo_Id = $('#cboCargo').val();
    if (Cargo_Id == "" || !flCheck) {
        $('#cboFunciones').html('');
        //$('<option value="">-Seleccione-</>').appendTo('#cboFunciones');
        $("#cboFunciones").multipleSelect();
    }
    else {
        var pagePath = window.location.pathname;
        var urlajax = pagePath + '/getFuncionesxCargo';
        var params = {
            Cargo_Id: Cargo_Id
        };
        $.ajax({
            type: "POST",
            url: urlajax,
            data: JSON.stringify(params),
            contentType: "application/json; chartseft:utf-8",
            dataType: "json",
            success: function (response) {
                var datos = response.d;
                $('#cboFunciones').html('');
                //$('<option value="">-Seleccione-</>').appendTo('#cboFunciones');
                for (var i = 0; i <= datos.length - 1; i++) {
                    $('<option value="' + datos[i][0] + '">' + datos[i][1] + '</>').appendTo('#cboFunciones');
                }
                $("#cboFunciones").multipleSelect();
            },
            error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
            async: false
        });
    }
};
function cargarArea() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaArea';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function (response) {
            var datos = response.d;
            $('#cboArea').html('');
            $('<option value="">-Seleccione-</>').appendTo('#cboArea');
            for (var i = 0; i <= datos.length - 1; i++) {
                $('<option value="' + datos[i][0] + '">' + datos[i][1] + '</>').appendTo('#cboArea');
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: false
    });
};
function cargarCatAuxiliar() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaCatAuxiliar';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function (response) {
            var datos = response.d;
            $('#cboCatAuxiliar').html('');
            $('<option value="">-Seleccione-</>').appendTo('#cboCatAuxiliar');
            for (var i = 0; i <= datos.length - 1; i++) {
                $('<option value="' + datos[i][0] + '">' + datos[i][1] + '</>').appendTo('#cboCatAuxiliar');
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: false
    });
};
function cargarCatAuxiliar2() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaCatAuxiliar2';
    var params = {
        xCatAuxiliar: $('#cboCatAuxiliar').val()
    };
    $.ajax({
        type: "POST",
        url: urlajax,
        data: JSON.stringify(params),
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function (response) {
            var datos = response.d;
            $('#cboCatAuxiliar2').html('');
            $('<option value="">-Seleccione-</>').appendTo('#cboCatAuxiliar2');
            for (var i = 0; i <= datos.length - 1; i++) {
                $('<option value="' + datos[i][0] + '">' + datos[i][1] + '</>').appendTo('#cboCatAuxiliar2');
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: false
    });
};

function ListaJefe() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListarCombos';
    var codigo = $('#cboCatAuxiliar').val();
    var params = {
        xOp: 'JEFES',
        xCodigo: codigo
    };
    $.ajax({
        type: "POST",
        url: urlajax,
        data: JSON.stringify(params),
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function (response) {
            var datos = response.d;
            $('#cboJefe').html('');
            $('<option value="">-Seleccione-</>').appendTo('#cboJefe');
            for (var i = 0; i <= datos.length - 1; i++) {
                $('<option value="' + datos[i][0] + '">' + datos[i][1] + '</>').appendTo('#cboJefe');
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: false
    });
};
function ListaCoordinador() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListarCombos';
    var codigo = $('#cboCatAuxiliar').val();
    var params = {
        xOp: 'COORDINADORES',
        xCodigo: codigo
    };
    $.ajax({
        type: "POST",
        url: urlajax,
        data: JSON.stringify(params),
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function (response) {
            var datos = response.d;
            $('#cboCoodinador').html('');
            $('<option value="">-Seleccione-</>').appendTo('#cboCoodinador');
            for (var i = 0; i <= datos.length - 1; i++) {
                $('<option value="' + datos[i][0] + '">' + datos[i][1] + '</>').appendTo('#cboCoodinador');
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: false
    });
};
function ListaJefeCoordinadorGerente() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListarCombos';
    var codigo = $('#cboCatAuxiliar').val();
    var params = {
        xOp: 'GERENTES',
        xCodigo: ''
    };
    $.ajax({
        type: "POST",
        url: urlajax,
        data: JSON.stringify(params),
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function (response) {
            var datos = response.d;
            $('#cboGerente').html('');
            $('<option value="">-Seleccione-</>').appendTo('#cboGerente');
            for (var i = 0; i <= datos.length - 1; i++) {
                $('<option value="' + datos[i][0] + '">' + datos[i][1] + '</>').appendTo('#cboGerente');
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: false
    });
};

function cargarSeguroMedico() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaSeguroMedico';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function (response) {
            var datos = response.d;
            $('#cboSeguroMedico').html('');
            $('<option value="">-Seleccione-</>').appendTo('#cboSeguroMedico');
            for (var i = 0; i <= datos.length - 1; i++) {
                $('<option value="' + datos[i][0] + '">' + datos[i][1] + '</>').appendTo('#cboSeguroMedico');
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: false
    });
};

function GuardarPersonal() {
    var cat2 = '';
    if ($('#rbnsujeto').attr('checked') == true) {
        cat2 = '01';
    } else {
        cat2 = '02';
    }
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/GuardarPersonalNuevo';
    var codigo = $('#cboCatAuxiliar').val();
    var params = {
        Planilla_Id: $('#ctl00_ucFiltros1_cboPlanilla').val()
        , Periodo_Id: $('#ctl00_ucFiltros1_cboPeriodo').val()
        , Fecha_ingreso: $('#txtFecIngreso').val()
        , Fecha_ini_contrato: $('#txtFecIniContrato').val()
        , Fecha_fin_contrato: $('#txtFecFinContrato').val()
        , Cargo_Id: $('#cboCargo').val()
        , Afp_Id: $('#cboRegPensionario').val()
        , Direccion: $('#txtDireccion').val()
        , Nro_cta: $('#txtNroCuenta').val()
        , Banco_cta_Id: $('#cboBanco').val()
        , Nro_cta_cts: $('#txtNroCuentaCTS').val()
        , Banco_cta_cts_Id: $('#cboBancoCTS').val()
        , Observaciones: $('#txtObservaciones').val()
        , Area_Id: $('#cboArea').val()
        , Categoria2_Id: cat2
        , Tipo_Contrato_Id: $('#cboTipoContrato').val()
        , Seguro_Medico_Id: $('#cboSeguroMedico').val()
        , Categoria_Auxiliar_Id: $('#cboCatAuxiliar').val()
        , Categoria_Auxiliar2_Id: $('#cboCatAuxiliar2').val()
        , Fecha_Nacimiento: $('#txtFecNacim').val()
        , ECivil: $('#cboECivil').val()
        , Apellido_Paterno: $('#txtApePaterno').val()
        , Apellido_Materno: $('#txtApeMaterno').val()
        , Nombres: $('#txtNombre').val()
        , Telefono: $('#txtTelf').val()
        , Telefono2: $('#txtTelf2').val()
        , Telefono3: $('#txtTelf3').val()
        , CorreoCorp: $('#txtEmail').val()
        , CorreoPer: $('#txtemailp').val()
        , NroDoc: $('#txtNroDoc').val()
        , CUSP: $('#txtCUSP').val()
        , NroHijos: $('#txtNumHijos').val()
        , Alergias: $('#txtAlergias').val()
        , CodigoSap: $('#txtCodSAP').val()
        , CodigoSapDeudor: $('#txtSAPDeudor').val()
        , JefeId: $('#cboJefe').val()
        , GerenteId: $('#cboGerente').val()
        , CoodinadorId: $('#cboCoodinador').val()
        , Sueldo: $('#txtBruto').val()
        , Movilidad: $('#txtMovilidad').val()
        , ValeAlimento: $('#txtValeAlimento').val()
        , Cargo_Funcion_Ids: $("#cboFunciones").multipleSelect("getSelects").toString()
    };
    $.ajax({
        type: "POST",
        url: urlajax,
        data: JSON.stringify(params),
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function (response) {
            var datos = response.d;
            if(datos.split('#')[0] == 'true'){
                clearDocumento();
            }
            alert(datos.split('#')[1]);
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: false
    });
}

function Valida_Datos() {
    Set_Error('', null, 0);
    //DATOS PRINCIPALES


    if (!$.trim($('#txtNombre').val())) {
        Set_Error('.::Error, Nombre no definido', 'txtNombre', 1);
        return false;
    }
    if (!$.trim($('#txtApePaterno').val())) {
        Set_Error('.::Error, Apellidos Paterno no definido', 'txtApePaterno', 1);
        return false;
    }
    if (!$.trim($('#txtApeMaterno').val())) {
        Set_Error('.::Error, Apellidos Materno no definido', 'txtApeMaterno', 1);
        return false;
    }
    if (!$.trim($('#txtDireccion').val())) {
        Set_Error('.::Error, Dirección no definida', 'txtDireccion', 1);
        return false;
    }
    if (!$.trim($('#txtEmail').val())) {
        Set_Error('.::Error, Email Corporativo no definido', 'txtEmail', 1);
        return false;
    }
    if (!$.trim($('#txtFecNacim').val())) {
        Set_Error('.::Error, Fecha de Nacimiento no definido', 'txtFecNacim', 1);
        return false;
    }
    var fechas = formatFecha.format1($.trim($('#txtFecNacim').val()));
    if (!fechaValida(fechas)) {
        Set_Error('.::Error, Fecha de Nacimiento invalida', 'txtFecNacim', 1);
        return false;
    }
    if (!$.trim($('#txtNroDoc').val())) {
        Set_Error('.::Error, Numero de documento no definido', 'txtNroDoc', 1);
        return false;
    } else {
        if (isNaN($.trim($('#txtNroDoc').val()))) {
            Set_Error('.::Error, Numero de documento incorrecto, digite solo números', 'txtNroDoc', 1);
            return false;
        }
    }
    if (!$('#cboBanco').val()) {
        Set_Error('.::Error, Banco de cuenta no definido', 'cboBanco', 2);
        return false;
    }

    if (!$('#cboBancoCTS').val()) {
        Set_Error('.::Error, Banco de cuenta CTS no definido', 'cboBancoCTS', 2);
        return false;
    }

    if (!$('#cboRegPensionario').val()) {
        Set_Error('.::Error, Tipo de pensionista no definido', 'cboRegPensionario', 3);
        return false;
    }
    if (!$('#cboECivil').val()) {
        Set_Error('.::Error, Estado civil no definido', 'cboECivil', 2);
        return false;
    }
    if (!$('#txtNumHijos').val()) {
        Set_Error('.::Error, Numero de hijos no definido', 'txtNumHijos', 2);
        return false;
    }
    if (isNaN($('#txtNumHijos').val())) {
        Set_Error('.::Error, Digite solo numeros', 'txtNumHijos', 2);
        return false;
    }
    if (!$('#txtFecIngreso').val()) {
        Set_Error('.::Error, Fecha de ingreso no definido', 'txtFecIngreso', 2);
        return false;
    }
    var fechaIngr = formatFecha.format1($.trim($('#txtFecIngreso').val()));
    if (!fechaValida(fechaIngr)) {
        Set_Error('.::Error, Fecha de Ingreso invalida', 'txtFecIngreso', 2);
        return false;
    }

    if (!$('#txtFecIniContrato').val()) {
        Set_Error('.::Error, Fecha de inicio de contrato no definido', 'txtFecIniContrato', 2);
        return false;
    }

    var fechaIniContr = formatFecha.format1($.trim($('#txtFecIniContrato').val()));
    if (!fechaValida(fechaIniContr)) {
        Set_Error('.::Error, Fecha de inicio de contrato invalida', 'txtFecIniContrato', 2);
        return false;
    }

    if (!$('#txtFecFinContrato').val()) {
        Set_Error('.::Error, Fecha fin de contrato no definido', 'txtFecFinContrato', 2);
        return false;
    }

    var fechaFinContr = formatFecha.format1($.trim($('#txtFecFinContrato').val()));
    if (!fechaValida(fechaFinContr)) {
        Set_Error('.::Error, Fecha fin de contrato invalida', 'txtFecFinContrato', 2);
        return false;
    }
    if (!$('#cboTipoContrato').val()) {
        Set_Error('.::Error, Tipo de Contrato no definido', 'cboTipoContrato', 2);
        return false;
    }
    if (!$('#cboCargo').val()) {
        Set_Error('.::Error, Puesto no definido', 'cboCargo', 3);
        return false;
    }
    if (!$('#cboArea').val()) {
        Set_Error('.::Error, Departamento no definido', 'cboArea', 2);
        return false;
    }
    if (!$('#txtBruto').val()) {
        Set_Error('.::Error, Sueldo  no definido', 'txtBruto', 2);
        return false;
    }
    if (isNaN($('#txtBruto').val())) {
        Set_Error('.::Error,Sueldo, Digite solo numeros', 'txtBruto', 2);
        return false;
    }
    if (!$('#cboCatAuxiliar').val()) {
        Set_Error('.::Error, Area no definida', 'cboCatAuxiliar', 2);
        return false;
    }
    if (!$('#cboCatAuxiliar2').val()) {
        Set_Error('.::Error, Sección no definida', 'cboCatAuxiliar2', 2);
        return false;
    }
    if (!$('#cboSeguroMedico').val()) {
        Set_Error('.::Error, Seguro Médico no definido', 'cboSeguroMedico', 2);
        return false;
    }

    if (isNaN($('#txtMovilidad').val())) {
        $('#txtMovilidad').val('0')
    }
    if (isNaN($('#txtValeAlimento').val())) {
        $('#txtValeAlimento').val('0')
    }

    return true;
}

function clearDocumento() {

    //----- Datos Principales

    $('#txtNombre').val('');
    $('#txtApePaterno').val('');
    $('#txtApeMaterno').val('');
    $('#txtDireccion').val('');
    $('#txtContacto').val('');

    $('#txtFecNacim').val('');
    $('#txtNroDoc').val('');
    $('#txtTelf').val('');
    $('#txtTelf2').val('');
    $('#txtTelf3').val('');
    $('#txtEmail').val('');
    $('#txtemailp').val('');
    $('#txtCUSP').val('');
    
    //----- Datos Scundarios
    $('#txtNroCuenta').val('');
    $('#txtNroCuentaCTS').val('');

    document.getElementById('cboBanco').selectedIndex = 0;
    document.getElementById('cboBancoCTS').selectedIndex = 0;
    document.getElementById('cboRegPensionario').selectedIndex = 0;
    document.getElementById('cboRegPensionario').value = "99"; //@001 I/F
    document.getElementById('cboECivil').selectedIndex = 0;


    //inputs
    $('#txtNumHijos').val('');
    $('#txtAlergias').val('');
    $('#txtCodSAP').val('');
    $('#txtSAPDeudor').val('');
    $('#txtFecIngreso').val('');
    $('#txtFecIniContrato').val('');
    $('#txtFecFinContrato').val('');
    $('#txtBruto').val('');
    

    document.getElementById('cboTipoContrato').selectedIndex = 0;
    document.getElementById('cboCargo').selectedIndex = 0;
    $("#chkAsigFunciones").prop("checked", false).trigger("change");
    document.getElementById('cboArea').selectedIndex = 0;
    document.getElementById('cboCatAuxiliar').selectedIndex = 0;
    document.getElementById('cboCatAuxiliar2').selectedIndex = 0;
    document.getElementById('cboJefe').selectedIndex = 0;
    document.getElementById('cboCoodinador').selectedIndex = 0;
    document.getElementById('cboGerente').selectedIndex = 0;

    document.getElementById('cboSeguroMedico').selectedIndex = 0;
    $('#rbsujeto').prop('checked', true);
    //----- Datos Trab / Pensionista

    $('#txtMovilidad').val('');
    $('#txtValeAlimento').val('');
    $('#txtOtros').val('');

    $('#ckCelular').attr('checked', false);
    $('#ckLaptop').attr('checked', false);

    $('#txtObservaciones').val('');

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

var formatFecha = {
    format1: function (fecha) {

        if (fecha.indexOf(' ') != -1) {
            var arr1 = fecha.split(' ');
            var arr = arr1[0].split('/');
            return arr[2] + '-' + arr[1] + '-' + arr[0];
        } else {
            var arr = fecha.split('/');
            return arr[2] + '-' + arr[1] + '-' + arr[0];
        }

    },
    format2: function (fecha) {
        if (fecha.indexOf(' ') != -1) {
            var arr1 = fecha.split(' ');
            var arr = arr1[0].split('/');
            return arr[0] + '-' + arr[1] + '-' + arr[2];
        } else {
            var arr = fecha.split('/');
            return arr[0] + '-' + arr[1] + '-' + arr[2];
        }


    },
    format3: function (fecha) {
        if (fecha.indexOf(' ') != -1) {
            var arr1 = fecha.split(' ');
            var arr = arr1[0].split('/');
            return arr[0] + '/' + arr[1] + '/' + arr[2];
        } else {
            var arr = fecha.split('/');
            return arr[0] + '/' + arr[1] + '/' + arr[2];
        }
    }
}

//FECHAS

String.prototype.toDateFormat = function () {

    if (this) {
        var dte = eval("new " + this.replace(/\//g, '') + ";");

        dte.setMinutes(dte.getMinutes() - dte.getTimezoneOffset());
        //  dateFormat(dte, "yyyy-MM-dd HH:mm:ss");
        var ret = dateDemo(dte);
        //return dte;
        return ret;
    } else {
        return '';
    }
}

function dateDemo(fecha) {
    var Dia = fecha.getUTCDate();
    var Mes = (fecha.getUTCMonth() + 1);
    var Anio = fecha.getUTCFullYear();

    Dia = Dia.toString().padLeft("0", 2);
    Mes = Mes.toString().padLeft("0", 2);

    var Hora = fecha.getUTCHours();
    Hora = Hora.toString().padLeft("0", 2);

    var Min = fecha.getUTCMinutes();
    Min = Min.toString().padLeft("0", 2);


    var fechaWPP = Dia + "/" + Mes + "/" + Anio + " " + Hora + ":" + Min;


    return fechaWPP;
}



String.prototype.padLeft = function (paddingChar, length) {

    var s = new String(this);

    if ((this.length < length) && (paddingChar.toString().length > 0)) {
        for (var i = 0; i < (length - this.length); i++)
            s = paddingChar.toString().charAt(0).concat(s);
    }

    return s;
}

function fechaValida(Fecha) {
    var FechaDis = Fecha.split('-');
    var dia = FechaDis[2];
    var mes = FechaDis[1];
    var anio = FechaDis[0];
    mes = mes - 1; //los meses empiezan por 0

    var fecha = new Date(anio, mes, dia);
    if (dia != fecha.getDate() || mes != fecha.getMonth() || anio != fecha.getFullYear()) {

        return false;

    }
    return true;

}