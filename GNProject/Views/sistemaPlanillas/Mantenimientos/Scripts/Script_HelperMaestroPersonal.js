// FILTRO CABECERA
/*
 * @001 FPS 09/12/2022 - Se agrega clave y nivel acceso para tabla UsuarioPlanilla
*/

function Get_Compania() {
    var cboCompa = document.getElementById('empresaSession').value;
    return cboCompa;
}

function Get_Periodo() {
    var cbo = document.getElementById('periodoSession').value;
    return cbo;
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

//OTROS FILTROS

function Get_ColumnaBusqueda() {
    var cbo = document.getElementById('cboBusquedaEn');
    return cbo.value;
}


function Get_TextoBusqueda() {
    var objetoRet = document.getElementById('txtBuscar');
    return objetoRet.value;
}

function Set_Error(Mensaje, objFocus,IndiceActive) {
    $('#lblError').html(Mensaje);
    if (objFocus) {
        $('#' + objFocus).focus();
        var active = $('#TabContainer').tabs('option', 'active');
        if (parseInt(active) != parseInt(IndiceActive)) {
            $('#TabContainer').tabs({ active: IndiceActive });
        }
        
    }
}

//VALIDAR PARA GRAGAR O ACTUALIZAR


function Valida_Datos() {
    Set_Error('', null, 0);
    //DATOS PRINCIPALES


   /* if (!$('#txtPersonal_Id').val()) {
        Set_Error(
        return false;
    }*/

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

    if (!$.trim($('#txtFecNacim').val())) {
        Set_Error('.::Error, Fecha de Nacimiento no definido', 'txtFecNacim', 1);
        return false;
    }
    
  
    var fechas =formatFecha.format1($.trim($('#txtFecNacim').val()));
    if (!fechaValida(fechas)) {
        Set_Error('.::Error, Fecha de Nacimiento invalida', 'txtFecNacim', 1);
            return false;
        }

        if (!$.trim($('#txtNroDoc').val())) {
        Set_Error('.::Error, Numero de documento no definido', 'txtNroDoc', 1);
        return false;
    }


   /* $('#txtTelf').val(Personal[0][27]);
    $('#txtTelf2').val(Personal[0][28]);
    $('#txtTelf3').val(Personal[0][29]);
    $('#ckDomiciliado').attr('checked', Boolean(Personal[0][50]));
    $('#txtEmail').val(Personal[0][47]);
    $('#txtNomVia').val(Personal[0][26]);
    $('#txtNumVia').val(Personal[0][51]);
    $('#txtInteriorVia').val(Personal[0][52]);
    $('#txtNomZona').val(Personal[0][54]);
    $('#txtReferencia').val(Personal[0][55]);*/

    //COMBOS

    if (!$('#cboTipoDoc').val()) {
        Set_Error('.::Error, Tipo de documento no definido', 'cboTipoDoc', 1);
        return false;
    }
    if (!$('#cboNacionalidad').val()) {
        Set_Error('.::Error, Nacionalidad no definido', 'cboNacionalidad', 1);
        return false;
    }
    if (!$('#cboSexo').val()) {
        Set_Error('.::Error, Sexo no definido', 'cboNacionalidad', 1);
        return false;
    }
    if (!$('#cboTipoVia').val()) {
        Set_Error('.::Error, Tipo via no definido', 'cboTipoVia', 1);
        return false;
    }
    if (!$('#cboTipoZona').val()) {
        Set_Error('.::Error, Tipo zona no definido', 'cboTipoZona', 1);
        return false;
    }
    if (!$('#cboDep').val()) {
        Set_Error('.::Error, Departamento no definido', 'cboDep', 1);
        return false;
    }
    if (!$('#cboProv').val()) {
        Set_Error('.::Error, Provincia no definido', 'cboProv', 1);
        return false;
    }
    if (!$('#cboDist').val()) {
        Set_Error('.::Error, Distrito no definido', 'cboProv', 1);
        return false;
    }

    //----- Datos Scundarios

    if (!$('#cboCompania').val()) {
        Set_Error('.::Error, Compañia no definida', 'cboCompania', 2);
        return false;
    }
    if (!$('#cboTipoPlanilla').val()) {
        Set_Error('.::Error, Planilla no definida', 'cboTipoPlanilla', 2);
        return false;
    }
    if (!$('#cboArea').val()) {
        Set_Error('.::Error, Area no definida', 'cboArea', 2);
        return false;
    }
    if (!$('#cboCCosto').val()) {
        Set_Error('.::Error, Centro de costo no definida', 'cboCCosto', 2);
        return false;
    }
    if (!$('#cboCategoria').val()) {
        Set_Error('.::Error, Categoria no definido', 'cboCategoria', 2);
        return false;
    }
    if (!$('#cboCategoria2').val()) {
        Set_Error('.::Error, Categoria 2 no definido', 'cboCategoria2', 2);
        return false;
    }

    if (!$('#cboProyecto').val()) {
        Set_Error('.::Error, Proyecto no definido', 'cboProyecto', 2);
        return false;
    }
    if (!$('#cboSituacion').val()) {
        Set_Error('.::Error, Situacion no definida', 'cboSituacion', 2);
        return false;
    }
    if (!$('#cboEstadoCivil').val()) {
        Set_Error('.::Error, Estado civil no definido', 'cboEstadoCivil', 2);
        return false;
    }
    if (!$('#cboEstadoCivil').val()) {
        Set_Error('.::Error, Estado civil no definido', 'cboEstadoCivil', 2);
        return false;
    }

    if (!$('#cboEstado').val()) {
        Set_Error('.::Error, Estado no definido', 'cboEstado', 2);
        return false;
    }

    var objFechaCese = $.trim($('#txtFecCese').val());

    if (objFechaCese != '01/01/1900' && objFechaCese != '') {
       
        var fechaCese = formatFecha.format1($.trim($('#txtFecCese').val()));
        if (!fechaValida(fechaCese)) {
            Set_Error('.::Error, Fecha de Cese invalida', 'txtFecCese', 2);            
            return false;
        }
        if ($('#cboEstado').val() == '01' && ($('#cboMotivoCese').val() == '' || $('#cboMotivoCese').val() == '')) {
            Set_Error('.::Error, Debe seleccionar algún Motivo de Cese', 'cboMotivoCese', 2);
            return false;
        }
        if ($('#cboEstado').val() == '02' && ($('#cboMotivoCese').val() == '00' || $('#cboMotivoCese').val() == '')) {
            Set_Error('.::Error, Motivo de Cese no definido', 'cboMotivoCese', 2);
            return false;
        }
        if ($('#cboEstado').val() == '01' && ($('#cboMotivoCese').val() != '00' && $('#cboMotivoCese').val() != '')) {
            var continuaCambioEstado = confirm('A definido la fecha y motivo de cese, por lo cual el estado del personal sera inactivo, ¿Continuar?');
            if (!continuaCambioEstado) {
                return false;
            } else {
                $('#cboEstado').val('02');
            }
        }
        
    }
    if (objFechaCese == '01/01/1900' || objFechaCese == '') {      
        if ($('#cboEstado').val() == '02' && ($('#cboMotivoCese').val() != '00' && $('#cboMotivoCese').val() != '')) {
            Set_Error('.::Error, Fecha de Cese no definida', 'txtFecCese', 2);
            return false;
        }
        if ($('#cboEstado').val() == '01' && ($('#cboMotivoCese').val() != '00' && $('#cboMotivoCese').val() != '')) {
            Set_Error('.::Error, Fecha de Cese no definida', 'txtFecCese', 2);
            return false;
        }
    }

    if (!$('#cboCatAuxiliar').val()) {
        Set_Error('.::Error, Categoria Auxiliar no definida', 'cboCatAuxiliar', 2);
        return false;
    }
    if (!$('#cboCatAuxiliar2').val()) {
        Set_Error('.::Error, Categoria Auxiliar 2 no definida', 'cboCatAuxiliar2', 2);
        return false;
    }
    if (!$('#cboAnexo').val()) {
        Set_Error('.::Error, Anexo no definido', 'cboAnexo', 2);
        return false;
    }
    if (!$('#cboAnexo2').val()) {
        Set_Error('.::Error, Anexo 2 no definido', 'cboAnexo2', 2);
        return false;
    }
    if (!$('#cboTipoCuenta').val()) {
        Set_Error('.::Error, Tipo de cuenta no definido', 'cboTipoCuenta', 2);
        return false;
    }
    if (!$('#cboTipoCuentaCTS').val()) {
        Set_Error('.::Error, Tipo de cuenta CTS no definido', 'cboTipoCuentaCTS', 2);
        return false;
    }

    if (!$('#cboBancoCuenta').val()) {
        Set_Error('.::Error, Banco de cuenta no definido', 'cboBancoCuenta', 2);
        return false;
    }
    if (!$('#cboBancoCuentaCTS').val()) {
        Set_Error('.::Error, Banco de cuenta CTS no definido', 'cboBancoCuentaCTS', 2);
        return false;
    }
    if (!$('#cboMonedaCuenta').val()) {
        Set_Error('.::Error, Moneda de cuenta no definido', 'cboMonedaCuenta', 2);
        return false;
    }
    if (!$('#cboMonedaCuentaCTS').val()) {
        Set_Error('.::Error, Moneda de cuenta CTS no definido', 'cboMonedaCuentaCTS', 2);
        return false;
    }


    //inputs
    //$('#txtCodSegSocial').val(Personal[0][21]);

    //$('#txtNumHijos').val(Personal[0][30]);
    
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


    //----- Datos Trab / Pensionista

  
    if (!$('#cboTipoTrabajador').val()) {
        Set_Error('.::Error, Tipo de trabajador no definido', 'cboTipoTrabajador', 3);
        return false;
    }
    //@001 I
    if ($("#txtContrasenia").val() == "") {
        Set_Error('.::Error, Contraseña no definido', 'txtContrasenia', 3);
        return false;
    }
    if ($("#cboNivelAcceso").val() == "") {
        Set_Error('.::Error, Nivel de Acceso no definido', 'cboNivelAcceso', 3);
        return false;
    }
    //@001 F
    if (!$('#cboTipoPensionista').val()) {
        Set_Error('.::Error, Tipo de pensionista no definido', 'cboTipoPensionista', 3);
        return false;
    }
    if (!$('#cboRegLaboral').val()) {
        Set_Error('.::Error, Regimen laboral no definido', 'cboRegLaboral', 3);
        return false;
    }
    if (!$('#cboNivelEduca').val()) {
        Set_Error('.::Error, Nivel educativo no definido', 'cboNivelEduca', 3);
        return false;
    }
    if (!$('#cboNivelEduca').val()) {
        Set_Error('.::Error, Nivel educativo no definido', 'cboNivelEduca', 3);
        return false;
    }
    if (!$('#cboCargo').val()) {
        Set_Error('.::Error, Cargo no definido', 'cboCargo', 3);
        return false;
    }
    if (!$('#cboRegPensionario').val()) {
        Set_Error('.::Error, Regimen pensionario no definido', 'cboRegPensionario', 3);
        return false;
    }
    if (!$('#cboRegPensionista').val()) {
        Set_Error('.::Error, Regimen pensionista no definido', 'cboRegPensionista', 3);
        return false;
    }
    if (!$('#cboSCTRSalud').val()) {
        Set_Error('.::Error, SCTR Salud no definido', 'cboSCTRSalud', 3);
        return false;
    }
    if (!$('#cboSCTRPension').val()) {
        Set_Error('.::Error, SCTR Pension no definido', 'cboSCTRPension', 3);
        return false;
    }


    if (!$('#cboTipoContrato').val()) {
        Set_Error('.::Error, Tipo de contrato no definido', 'cboTipoContrato', 3);
        return false;
    }

    if (!$('#cboEPS').val()) {
        Set_Error('.::Error, EPS no definido', 'cboTipoContrato', 3);
        return false;
    }

    if (!$('#cboSituacionEspec').val()) {
        Set_Error('.::Error, Situacion especial no definida', 'cboTipoContrato', 3);
        return false;        
    }
    if ($('#txtFecIniAportacion').val()) {
        var fechaIniAport = formatFecha.format1($.trim($('#txtFecIniAportacion').val()));
        if (!fechaValida(fechaIniAport)) {
            Set_Error('.::Error, Fecha de inicio de portacion invalida', 'txtFecIniAportacion', 3);
            return false;
        }     
        
    }
    

    return true;
}

function clearDocumento() {

    //----- Datos Principales

    $('#txtPersonal_Id').val('');
    $('#txtNombre').val('');
    $('#txtApePaterno').val('');
    $('#txtApeMaterno').val('');

    $('#txtFecNacim').val('');
    $('#txtNroDoc').val('');
    $('#txtTelf').val('');
    $('#txtTelf2').val('');
    $('#txtTelf3').val('');
    $('#ckDomiciliado').attr('checked', false);
    $('#txtEmail').val('');
    $('#txtemailp').val('');
    $('#txtCodigoInterno').val('');

    $('#txtNomVia').val('');
    $('#txtNumVia').val('');
    $('#txtInteriorVia').val('');
    $('#txtNomZona').val('');
    $('#txtReferencia').val('');

    //COMBOS
    $('#cboTipoDoc').val('');
    $('#cboNacionalidad').val('');
    $('#cboSexo').val('');
    document.getElementById('cboTipoVia').selectedIndex = 0;
    document.getElementById('cboTipoZona').selectedIndex = 0;  

    $('#cboDep').val('');
    ListaProvincia('');
    $('#cboProv').val('');
    ListaDistrito('', '');
    $('#cboDist').val('');

    //----- Datos Scundarios
    $('#cboCompania').val(Get_Compania());
    ListaTipoPlanilla(Get_Compania());
    $('#cboTipoPlanilla').val($('#ctl00_ucFiltros1_cboPlanilla').val());
    $('#cboArea').val('');
    $('#cboCCosto').val('');
    $('#cboCategoria').val('');
    document.getElementById('cboCategoria2').selectedIndex = 0; 
    
    $('#cboProyecto').val('');
    $('#cboSituacion').val('');
    $('#cboEstadoCivil').val('');
    $('#cboEstado').val('01');
    $('#cboMotivoCese').val('');
    $('#cboCatAuxiliar').val('');
    ListaCatAuxiliar2($('#cboCatAuxiliar').val());
    $('#cboCatAuxiliar2').val('');
    document.getElementById('cboAnexo').selectedIndex = 0;
    document.getElementById('cboAnexo2').selectedIndex = 0;
    document.getElementById('cboTipoCuenta').selectedIndex = 0;
    document.getElementById('cboTipoCuentaCTS').selectedIndex = 0;
    document.getElementById('cboBancoCuenta').selectedIndex = 0;
    document.getElementById('cboBancoCuentaCTS').selectedIndex = 0;
    document.getElementById('cboMonedaCuenta').selectedIndex = 0;
    document.getElementById('cboMonedaCuentaCTS').selectedIndex = 0;

    //inputs
    $('#txtCodSegSocial').val('');
    $('#txtNumHijos').val('');
    $('#txtFecIngreso').val('');
    $('#txtFecIniContrato').val('');
    $('#txtFecFinContrato').val('');
    $('#txtFecCese').val(''); 
    $('#txtNroCuenta').val('');
    $('#txtNroCuentaCTS').val('');
    $('#txtNroCuentaInterbancaria').val('');

    //----- Datos Trab / Pensionista

    document.getElementById('cboTipoTrabajador').selectedIndex = 0;
    document.getElementById('cboTipoPensionista').selectedIndex = 0;
    document.getElementById('cboRegLaboral').selectedIndex = 0;
    document.getElementById('cboNivelEduca').selectedIndex = 0;
    document.getElementById('cboCargo').selectedIndex = 0;
    document.getElementById('cboRol').selectedIndex = 0;
    //@001 I
    $("#txtContrasenia").val("");
    document.getElementById("cboNivelAcceso").selectedIndex = 0;
    //@001 F
    document.getElementById('cboRegPensionario').selectedIndex = 0;
    document.getElementById('cboSCTRSalud').selectedIndex = 0;
    document.getElementById('cboSCTRPension').selectedIndex = 0;
    document.getElementById('cboTipoContrato').selectedIndex = 0;
    document.getElementById('cboEPS').selectedIndex = 0;
    document.getElementById('cboSituacionEspec').selectedIndex = 0;
    $('#ckDiscapacitado').attr('checked', false);
    $('#ckJorAtipica').attr('checked', false);
    $('#ckHorarioNoctu').attr('checked', false);
    $('#ckSindicalizado').attr('checked', false);
    $('#ckIng5taInaf').attr('checked', false);
    $('#ckJorMaxima').attr('checked', false);  
    $('#txtFecIniAportacion').val('');
    $('#txtFecIniAporacion2').val('');
    $('#txtCUSPP').val('');
    $('#txtCUSPP2').val('');


    //----- 4ta / M.F. / Ter.
    document.getElementById('cboSeguroMed').selectedIndex = 0;
    document.getElementById('cboNivelEduca2').selectedIndex = 0;
    document.getElementById('cboCargo2').selectedIndex = 0;
    document.getElementById('cboTipoCenFProf').selectedIndex = 0;
    document.getElementById('cboTipoModFormat').selectedIndex = 0;
    document.getElementById('cboSCTRSalud2').selectedIndex = 0;
    document.getElementById('cboSCTRPension2').selectedIndex = 0;


    $('#ckMadreconResFam').attr('checked', false);
    $('#ckDiscapacidad2').attr('checked', false);
    $('#ckHorarioNoctu2').attr('checked', false);

    $('#txtRUC').val('');
    $('#txtRUCDest').val('');
    $('#txtNroCITT').val('');


    //----- Otros Datos
    document.getElementById('cboCompexion').selectedIndex = 0;
    document.getElementById('cboGrupoSanguineo').selectedIndex = 0;
    document.getElementById('cboTallaRopa').selectedIndex = 0;
    document.getElementById('cboCategoriaBrevete').selectedIndex = 0;

    $('#txtEstatura').val('0.00');
    $('#txtPeso').val('0.00');
    $('#txtAlergias').val('');
    $('#txtNroCalzado').val('');
    $('#txtNroBrevete').val('');
    $('#txtVigencia').val('');
    $('#txtCodAuxiliar').val('');
}


function CargarDatos() {
   
        if (DatosP == 0) { CargarCombosDatosPrincipales(); DatosP = 1 };
        if (DatosS == 0) { CargarCombosDatosSecundarios(); DatosS = 1 };
        if (TabPensio == 0) { CargarCombosTrabPensionario(); TabPensio = 1 };
        if (CuartaMF == 0) { CargarCombosCuartaMF(); CuartaMF = 1 };
        if (OtrosD == 0) { CargarComboOtrosDatos(); OtrosD = 1 };
    
}