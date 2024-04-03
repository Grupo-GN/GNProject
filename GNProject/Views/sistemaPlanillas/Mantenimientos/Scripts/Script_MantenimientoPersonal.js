/*
    @001 FPS 15/08/2019 - Optimización
    @002 FPS 14/07/2022 - Se agrega bancos de empresa
    @003 FPS 09/12/2022 - Se agrega clave y nivel acceso para tabla UsuarioPlanilla
*/

//FILTRO BUSCAR POR
function ListaColumnPersonal() {
    var pagePath = window.location.pathname; 
    var urlajax = pagePath + '/ListaColumnPersonal';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboBusquedaEn').html('');
            $('<option value="Todos">Todos</option>').appendTo('#cboBusquedaEn');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][1] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboBusquedaEn');
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });

}

//LISTAR PERSONAL

function Lista_Personal_x_Filtro_Columna(Compania_Id, Periodo_Id, NomColumna, Param, inicio) {

    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/Lista_Personal_x_Filtro_Columna';

    var params = {
        Compania_Id: Compania_Id,
        Periodo_Id: Periodo_Id,
        NomColumna: NomColumna,
        Param: Param,
        inicio: inicio
    };
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        data: JSON.stringify(params),
        dataType: "json",
        success: function(response) {
            //var Datos = response.d;
            var objResponse = response.d;
            var Datos = objResponse.oBandeja; //@001 I/F
            var qt_registros = objResponse.qt_registros; //@001 I/F
            var lengthD = Datos.length - 1;
            $('#tbodyPersonal').html('');
            for (var i = 0; i <= lengthD; i++) {
                var StyleTR = '';
                var Estado = Datos[i].Estado_Id;
                if (Estado == '01') {
                    Estado = 'ACTIVO';
                    StyleTR = '';
                } else {
                    Estado = 'INACTIVO';
                    StyleTR = 'style="color:Red;"';
                }
                var html = '<tr>';

                html += '<td><input type="button" class="linkEditar" id="lnk' + Datos[i].Personal_Id + '" title="" /></td>';
                html += '<td><input type="button" class="linkEliminar" id="lnk' + Datos[i].Personal_Id + '" title="" /></td>';
                html += '<td ' + StyleTR + '>' + Datos[i].Personal_Id + '</td>';
                html += '<td ' + StyleTR + '>' + Datos[i].Apellido_Paterno + '</td>';
                html += '<td ' + StyleTR + '>' + Datos[i].Apellido_Materno + '</td>';
                html += '<td ' + StyleTR + '>' + Datos[i].Nombres + '</td>';
                html += '<td ' + StyleTR + '>' + Datos[i].TDocumento + '</td>';
                html += '<td ' + StyleTR + '>' + Datos[i].Nro_Doc + '</td>';
                html += '<td ' + StyleTR + '>' + Datos[i].F_Ingreso + '</td>';
                html += '<td ' + StyleTR + '>' + Datos[i].F_Ini_Contrato + '</td>';
                html += '<td ' + StyleTR + '>' + Datos[i].F_Fin_Contrato + '</td>';
                html += '<td ' + StyleTR + '>' + Datos[i].F_Cese + '</td>';
                html += '<td ' + StyleTR + '>' + Datos[i].Proyecto + '</td>';
                html += '<td ' + StyleTR + '>' + Datos[i].Nro_cta + '</td>';
                html += '<td ' + StyleTR + '>' + Datos[i].Nro_cta_cts + '</td>';
                html += '<td ' + StyleTR + '>' + Datos[i].Telefono + '</td>';
                html += '</tr>';
                $(html).appendTo('#tbodyPersonal');
            }
            //Lista_Personal_x_Filtro_Columna_MaxRows(Compania_Id, Periodo_Id, NomColumna, Param); //@001 I/F
            $('#txtnRegistros').val(qt_registros); //@001 I/F
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: true
    });

}

//@001 I
//function Lista_Personal_x_Filtro_Columna_MaxRows(Compania_Id, Periodo_Id, NomColumna, Param) {

//    var pagePath = window.location.pathname;
//    var urlajax = pagePath + '/Lista_Personal_x_Filtro_Columna_MaxRows';

//    var params = {
//        Compania_Id: Compania_Id,
//        Periodo_Id: Periodo_Id,
//        NomColumna: NomColumna,
//        Param: Param,
//        inicio: inicio
//    };
//    $.ajax({
//        type: "POST",
//        url: urlajax,
//        contentType: "application/json; chartseft:utf-8",
//        data: JSON.stringify(params),
//        dataType: "json",
//        success: function(response) {
//            var Datos = response.d;
//            $('#txtnRegistros').val(Datos);


//        },
//        error:
//         function(XmlHttpError, error, description) {
//             $("#divError").html(XmlHttpError.responseText);
//         },
//        async: true
//    });

//}
//@001 F

//CARGAR DATOS POR PERSONAL
function Lista_Personal(Personal_Id,Periodo_Id) {

    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/Lista_Personal'; 
    
    var params = {
        Personal_Id: Personal_Id,
        Periodo_Id: Periodo_Id
    };
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        data: JSON.stringify(params),
        dataType: "json",
        success: function (response) {
            Personal = [];
            Personal = response.d;
            if (PDatosP == 0) { CargarDatosPrincipales_Personal(); PDatosP = 1; };
            if (PDatosS == 0) { CargarDatosSecundarios_Personal(); PDatosS = 1 };
            if (PTabPensio == 0) { CargarDatosTrabPensionista_Personal(); PTabPensio = 1 };
            //@001 I
            //if (PCuartaMF == 0) { CargarCombosCuartaMF(); PCuartaMF = 1 };
            //if (POtrosD == 0) { CargarComboOtrosDatos(); POtrosD = 1 };
            if (PCuartaMF == 0) { CargarDatosCuartaMF_Personal(); PCuartaMF = 1 }
            if (POtrosD == 0) { CargarDatosOtrosDatos_Personal(); POtrosD = 1 };
            //@001 F
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });


}
//NUEVO PERSONAL
function Insert_Personal() {

    var Compania_Id = $('#cboCompania').val();
    var Planilla_Id = $('#cboTipoPlanilla').val();
    var Apellido_Paterno = $('#txtApePaterno').val();
    var Apellido_Materno = $('#txtApeMaterno').val();
    var Nombres = $('#txtNombre').val();
    var Sexo_Id = $('#cboSexo').val();
    var Fecha_Nacimiento = formatFecha.format1($('#txtFecNacim').val());
    var E_Civil_Id = $('#cboEstadoCivil').val();

    var Fecha_Ini_AporteAFP;
    if (!$('#txtFecIniAportacion').val()) {
        Fecha_Ini_AporteAFP = '1900-01-01';
    } else { 
        Fecha_Ini_AporteAFP = formatFecha.format1($('#txtFecIniAportacion').val());
    }

    var Tipo_Doc_Id = $('#cboTipoDoc').val();
    var Nro_Doc = $('#txtNroDoc').val();
    var Categoria_Id = $('#cboCategoria').val();
    var Categoria2_Id = $('#cboCategoria2').val();
    var Cargo_Id = $('#cboCargo').val();
    var co_rol = $('#cboRol').val();
    var Situacion_Id = $('#cboSituacion').val();
    var Afp_Id = $('#cboRegPensionario').val();
    var Afp_cod_afiliacion = $('#txtCUSPP').val();
    var Seguro_cod = $('#txtCodSegSocial').val();
    var Ccosto_Id = $('#cboCCosto').val();
    var Dpto = $('#cboDep').val();
    var Prov = $('#cboProv').val();
    var Dist = $('#cboDist').val();
    var Direccion = $('#txtNomVia').val();
    var Telefono = $('#txtTelf').val();
    var Telefono2 = $('#txtTelf2').val();
    var Telefono3 = $('#txtTelf3').val();
    var Nro_Hijos = $('#txtNumHijos').val();
    var Tip_cta_Id = $('#cboTipoCuenta').val();
    var Nro_cta = $('#txtNroCuenta').val();
    var Nro_cta_interbancaria = $('#txtNroCuentaInterbancaria').val();
    var Moneda_cta_Id = $('#cboMonedaCuenta').val();
    var Banco_cta_Id = $('#cboBancoCuenta').val();
    var Nro_cta_cts = $('#txtNroCuentaCTS').val();
    var Tip_cta_cts_Id = $('#cboTipoCuentaCTS').val();
    var Moneda_cta_cts_Id = $('#cboMonedaCuentaCTS').val();
    var Banco_cta_cts_Id = $('#cboBancoCuentaCTS').val();
    //@002 I
    var Banco_pago_cia_Id = $('#cboBancoPago_Cia').val();
    var Banco_pago_cts_cia_Id = $('#cboBancoPagoCTS_Cia').val();
    //@002 F
    var Proyecto_Id = $('#cboProyecto').val();
    var Tgasto_Id = '';
    var Usuario = '';
    var Pase = '';
    var LAdministrador =0;
    var Estado_Id = $('#cboEstado').val();
    var Area_Id = $('#cboArea').val();
    var Cod_Antiguo = '';
    var Email = $('#txtEmail').val();
    var Nacionalidad_Id = $('#cboNacionalidad').val();
    var Domiciliado = Boolean($('#ckDomiciliado').attr('checked'));
    var Tipo_Via_Id = $('#cboTipoVia').val();
    var Numero_Via = $('#txtNumVia').val();
    var Interior_Via = $('#txtInteriorVia').val();
    var Tipo_Zona_Id = $('#cboTipoZona').val();
    var Nombre_Zona = $('#txtNomZona').val();
    var Referencia = $('#txtReferencia').val();
    var Tipo_Trabajador_Id = $('#cboTipoTrabajador').val();
    var Regimen_Laboral_Id = $('#cboRegLaboral').val();
    var Nivel_Educativo_Id = $('#cboNivelEduca').val();
    var Discapacidad = Boolean($('#ckDiscapacitado').attr('checked'));
    var SCTR_Salud_Id = $('#cboSCTRSalud').val();
    var SCTR_Pension_Id = $('#cboSCTRPension').val();
    var Tipo_Contrato_Id = $('#cboTipoContrato').val();
    var Jornada_Atipica = Boolean($('#ckJorAtipica').attr('checked'));
    var Jornada_Maxima = Boolean($('#ckJorMaxima').attr('checked'));
    var Horario_Nocturno = Boolean($('#ckHorarioNoctu').attr('checked'));
    var Sindicalizado = Boolean($('#ckSindicalizado').attr('checked'));
    var EPS_Id = $('#cboEPS').val();
    var Ingresos_5ta_Inafectos = Boolean($('#ckIng5taInaf').attr('checked'));
    var Situacion_Especial_Id = $('#cboSituacionEspec').val();
    var RUC = $('#txtRUC').val();
    var Seguro_Medico_Id = $('#cboSeguroMed').val();
    var Madre_Resp_Fam = Boolean($('#ckMadreconResFam').attr('checked'));
    var Tipo_Centro_Form_Prof_Id = $('#cboTipoCenFProf').val();
    var RUC_Destaque = $('#txtRUCDest').val();
    //////var Foto image(16)
    var Foto_NombreArchivo = '';
    var Nro_Calzado = $('#txtNroCalzado').val();
    var Talla_Ropa_Id = $('#cboTallaRopa').val();
    var Grupo_Sanguineo_Id = $('#cboGrupoSanguineo').val();
    var Estatura = $('#txtEstatura').val() == '' ? '0.00': $('#txtEstatura').val();
    var Peso = $('#txtPeso').val() == '' ? '0.00' : $('#txtPeso').val();
    var Complexion_Fisica_Id = $('#cboCompexion').val();
    var Brevete_Nro = $('#txtNroBrevete').val();
    var Brevete_Categoria_Id = $('#cboCategoriaBrevete').val();
    var Brevete_Vigencia = $('#txtVigencia').val()==''?'1900-01-01':$('#txtVigencia').val();
    var Alergias = $('#txtAlergias').val();
    var Codigo_Auxiliar = $('#txtCodAuxiliar').val();
    var Seccion_Id = '';
    var Contrasenia = $("#txtContrasenia").val(); //@003 I/F
    var NivelAcceso = $("#cboNivelAcceso").val(); //@003 I/F

    /*Datos para la tabla Personal_Activo*/

    var Periodo_Id = Get_Periodo();
    var Fecha_ingreso = formatFecha.format1($('#txtFecIngreso').val());
    var fechacese;
    if ($('#txtFecCese').val() != '' && $('#txtFecCese').val() != '01/01/1900') {
        fechacese = formatFecha.format1($('#txtFecCese').val());
    } else {
        fechacese = '1900-01-01';    
    }
    var Fecha_cese = fechacese
    var Fecha_ini_contrato = formatFecha.format1($('#txtFecIniContrato').val());
    var Fecha_fin_contrato = formatFecha.format1($('#txtFecFinContrato').val());
    var Pry_Operacion_Id = '';
    var Pry_Categoria_Id = '';
    var Flag_Distribuido ='';
    var Observaciones = '';
    var Motivo_Fin_Per_Lab_Id = $('#cboMotivoCese').val();
    var Tipo_Mod_Formativa_Id = $('#cboTipoModFormat').val();
    var Nro_CITT = $('#txtNroCITT').val();
    var Cod_Contrato = '';
    var Fecha_Impresion_Contrato ='1900-01-01';
    var EPSPLAN_ID = '00';
    /*var Cantidad_Titular = $('#txtCodAuxiliar').val();
    var Cantidad_Dependientes = $('#txtCodAuxiliar').val();
    var Cantidad_Hmayores = $('#txtCodAuxiliar').val();*/
    var Categoria_Auxiliar_Id = $('#cboCatAuxiliar').val();
    var Categoria_Auxiliar2_Id = $('#cboCatAuxiliar2').val();
    var Personal_Anexo_Id = $('#cboAnexo').val();
    var Personal_Anexo2_Id = $('#cboAnexo2').val();

    var emailp = $('#txtemailp').val();
    var Co_Trabajador_Id = $('#txtCodigoInterno').val();

    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/Insert_Personal';
    
    var params = {
            Compania_Id:Compania_Id
        ,  Planilla_Id: Planilla_Id
        ,  Apellido_Paterno: Apellido_Paterno.toUpperCase()
        ,  Apellido_Materno: Apellido_Materno.toUpperCase()
        ,  Nombres: Nombres.toUpperCase()
        ,  Sexo_Id:Sexo_Id
        ,  Fecha_Nacimiento:Fecha_Nacimiento
        ,  E_Civil_Id:E_Civil_Id
        ,  Fecha_Ini_AporteAFP:Fecha_Ini_AporteAFP
        ,  Tipo_Doc_Id:Tipo_Doc_Id
        ,  Nro_Doc:Nro_Doc
        ,  Categoria_Id:Categoria_Id
        ,  Categoria2_Id:Categoria2_Id
        , Cargo_Id: Cargo_Id
        ,  Situacion_Id:Situacion_Id
        ,  Afp_Id:Afp_Id
        ,  Afp_cod_afiliacion:Afp_cod_afiliacion
        ,  Seguro_cod:Seguro_cod
        ,  Ccosto_Id:Ccosto_Id
        ,  Dpto:Dpto
        ,  Prov:Prov
        ,  Dist:Dist
        ,  Direccion:Direccion
        ,  Telefono:Telefono
        ,  Telefono2:Telefono2
        ,  Telefono3:Telefono3
        ,  Nro_Hijos:parseInt(Nro_Hijos)
        ,  Tip_cta_Id:Tip_cta_Id
        ,  Nro_cta: Nro_cta
        ,  Moneda_cta_Id:Moneda_cta_Id
        ,  Banco_cta_Id:Banco_cta_Id
        ,  Nro_cta_cts: Nro_cta_cts
        ,  Tip_cta_cts_Id:Tip_cta_cts_Id
        ,  Moneda_cta_cts_Id:Moneda_cta_cts_Id
        ,  Banco_cta_cts_Id:Banco_cta_cts_Id
        ,  Proyecto_Id:Proyecto_Id
        ,  Tgasto_Id:Tgasto_Id
        , Usuario: Usuario
        , Pase: Pase
        , LAdministrador:parseInt(LAdministrador)
        ,  Estado_Id:Estado_Id
        ,  Area_Id:Area_Id
        , Cod_Antiguo: Cod_Antiguo
        ,  Email:Email
        ,  Nacionalidad_Id:Nacionalidad_Id
        ,  Domiciliado:Domiciliado
        ,  Tipo_Via_Id:Tipo_Via_Id
        ,  Numero_Via:Numero_Via
        ,  Interior_Via:Interior_Via
        ,  Tipo_Zona_Id:Tipo_Zona_Id
        ,  Nombre_Zona:Nombre_Zona
        ,  Referencia:Referencia
        ,  Tipo_Trabajador_Id:Tipo_Trabajador_Id
        ,  Regimen_Laboral_Id:Regimen_Laboral_Id
        ,  Nivel_Educativo_Id:Nivel_Educativo_Id
        ,  Discapacidad:Discapacidad
        ,  SCTR_Salud_Id:SCTR_Salud_Id
        ,  SCTR_Pension_Id:SCTR_Pension_Id
        ,  Tipo_Contrato_Id:Tipo_Contrato_Id
        ,  Jornada_Atipica:Jornada_Atipica
        ,  Jornada_Maxima:Jornada_Maxima
        ,  Horario_Nocturno:Horario_Nocturno
        ,  Sindicalizado:Sindicalizado
        ,  EPS_Id:EPS_Id
        ,  Ingresos_5ta_Inafectos:Ingresos_5ta_Inafectos
        ,  Situacion_Especial_Id:Situacion_Especial_Id
        ,  RUC:RUC
        ,  Seguro_Medico_Id:Seguro_Medico_Id
        ,  Madre_Resp_Fam:Madre_Resp_Fam
        ,  Tipo_Centro_Form_Prof_Id:Tipo_Centro_Form_Prof_Id
        ,  RUC_Destaque:RUC_Destaque
           
        ,  Foto_NombreArchivo:Foto_NombreArchivo
        ,  Nro_Calzado:Nro_Calzado
        ,  Talla_Ropa_Id:Talla_Ropa_Id
        ,  Grupo_Sanguineo_Id:Grupo_Sanguineo_Id
        ,  Estatura:parseFloat(Estatura)
        ,  Peso:parseFloat(Peso)
        ,  Complexion_Fisica_Id:Complexion_Fisica_Id
        ,  Brevete_Nro:Brevete_Nro
        ,  Brevete_Categoria_Id:Brevete_Categoria_Id
        ,  Brevete_Vigencia:Brevete_Vigencia
        ,  Alergias:Alergias
        ,  Codigo_Auxiliar:Codigo_Auxiliar
        , Seccion_Id: Seccion_Id
        , Co_Trabajador_Id: Co_Trabajador_Id
        /*Datos para la tabla Personal_Activo*/
        ,  Periodo_Id:Periodo_Id
        ,  Fecha_ingreso:Fecha_ingreso
        ,  Fecha_cese:Fecha_cese
        ,  Fecha_ini_contrato:Fecha_ini_contrato
        ,  Fecha_fin_contrato:Fecha_fin_contrato
        ,  Pry_Operacion_Id:Pry_Operacion_Id
        ,  Pry_Categoria_Id:Pry_Categoria_Id
        ,  Flag_Distribuido:Flag_Distribuido
        ,  Observaciones:Observaciones
        ,  Motivo_Fin_Per_Lab_Id:Motivo_Fin_Per_Lab_Id
        ,  Tipo_Mod_Formativa_Id:Tipo_Mod_Formativa_Id
        ,  Nro_CITT:Nro_CITT
        ,  Cod_Contrato:Cod_Contrato
        ,  Fecha_Impresion_Contrato:'1900-01-01'
        ,  EPSPLAN_ID:EPSPLAN_ID
        ,  Cantidad_Titular:0
        ,  Cantidad_Dependientes:0
        ,  Cantidad_Hmayores:0
        ,  Categoria_Auxiliar_Id:Categoria_Auxiliar_Id
        ,  Categoria_Auxiliar2_Id:Categoria_Auxiliar2_Id
        ,  Personal_Anexo_Id:Personal_Anexo_Id
        ,  Personal_Anexo2_Id:Personal_Anexo2_Id
        , Nro_cta_interbancaria: Nro_cta_interbancaria
        , co_rol: co_rol
        , emailp: emailp
        //@002 I
        , Banco_pago_cia_Id: Banco_pago_cia_Id
        , Banco_pago_cts_cia_Id: Banco_pago_cts_cia_Id
        //@002 F
        //@003 I
        , Password: Contrasenia
        , NivelAcceso: NivelAcceso
        //@003 F
    };


    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            if (lengthD > 0 && Datos[1].toString() != '-1') {
                alert('Personal Registrado Correctamente');
                Personal = [];
                Personal_IdProceso = '';
                PDatosP = 0;
                PDatosS = 0;
                PTabPensio = 0;
                PCuartaMF = 0;
                POtrosD = 0;
                PROCESO = '';
                if (disNew) { window.clearInterval(disNew); }

                window.clearInterval(disGrabar);
                window.clearInterval(disCancel);
                window.clearInterval(disUpdate);
                window.clearInterval(disDelete);

                Disable_btnNew(false);

                disGrabar = window.setInterval(function() {
                    Disable_btnGrabar(true);
                }, 100);

                disCancel = window.setInterval(function() {
                    Disable_btnCancelar(true);
                }, 100);

                disUpdate = window.setInterval(function() {
                    Disable_btnActualizar(true);
                }, 100);

                disDelete = window.setInterval(function() {
                    Disable_btnEliminar(true);
                }, 100);
                Personal_IdProceso = '';
                Personal = [];
                PROCESO = '';
                $('#TabContainer').tabs({ disabled: [1, 2, 3, 4, 5] });
                $('#TabContainer').tabs({ active: 0 });

                $('#cboBusquedaEn').val('Personal_Id');
                $('#txtBuscar').val(Datos[1]);
                inicio = 0;
                if (pagePath.indexOf('MaestroPersonal.aspx') != -1) {
                    Lista_Personal_x_Filtro_Columna(Get_Compania(), null, Get_ColumnaBusqueda(), Get_TextoBusqueda(), inicio);
                } else {
                    Lista_Personal_x_Filtro_Columna(Get_Compania(), Get_Periodo(), Get_ColumnaBusqueda(), Get_TextoBusqueda(), inicio);
                }
                               
            } else if (lengthD > 0 && Datos[1].toString() == '-1') {
                Set_Error('.::Error, ' + Datos[2].toString(), null, 0);
            }
        },
        error: function(XmlHttpError, error, description) {
            $("#divError").html(XmlHttpError.responseText);
            },
        async: false
    });
 
    
}


//ACTUALIZAR PERSONAL
function Update_Personal() {
    var Personal_Id = Personal_IdProceso;
    var Compania_Id = $('#cboCompania').val();
    var Planilla_Id = $('#cboTipoPlanilla').val();
    var Apellido_Paterno = $('#txtApePaterno').val();
    var Apellido_Materno = $('#txtApeMaterno').val();
    var Nombres = $('#txtNombre').val();
    var Sexo_Id = $('#cboSexo').val();
    var Fecha_Nacimiento = formatFecha.format1($('#txtFecNacim').val());
    var E_Civil_Id = $('#cboEstadoCivil').val();

    var Fecha_Ini_AporteAFP;
    if (!$('#txtFecIniAportacion').val()) {
        Fecha_Ini_AporteAFP = '1900-01-01';
    } else {
        Fecha_Ini_AporteAFP = formatFecha.format1($('#txtFecIniAportacion').val());
    }

    var Tipo_Doc_Id = $('#cboTipoDoc').val();
    var Nro_Doc = $('#txtNroDoc').val();
    var Categoria_Id = $('#cboCategoria').val();
    var Categoria2_Id = $('#cboCategoria2').val();
    var Cargo_Id = $('#cboCargo').val();
    var co_rol = $('#cboRol').val();
    var Situacion_Id = $('#cboSituacion').val();
    var Afp_Id = $('#cboRegPensionario').val();
    var Afp_cod_afiliacion = $('#txtCUSPP').val();
    var Seguro_cod = $('#txtCodSegSocial').val();
    var Ccosto_Id = $('#cboCCosto').val();
    var Dpto = $('#cboDep').val();
    var Prov = $('#cboProv').val();
    var Dist = $('#cboDist').val();
    var Direccion = $('#txtNomVia').val();
    var Telefono = $('#txtTelf').val();
    var Telefono2 = $('#txtTelf2').val();
    var Telefono3 = $('#txtTelf3').val();
    var Nro_Hijos = $('#txtNumHijos').val();
    var Tip_cta_Id = $('#cboTipoCuenta').val();
    var Nro_cta = $('#txtNroCuenta').val();
    var Nro_cta_interbancaria = $('#txtNroCuentaInterbancaria').val();
    var Moneda_cta_Id = $('#cboMonedaCuenta').val();
    var Banco_cta_Id = $('#cboBancoCuenta').val();
    var Nro_cta_cts = $('#txtNroCuentaCTS').val();
    var Tip_cta_cts_Id = $('#cboTipoCuentaCTS').val();
    var Moneda_cta_cts_Id = $('#cboMonedaCuentaCTS').val();
    var Banco_cta_cts_Id = $('#cboBancoCuentaCTS').val();
    //@002 I
    var Banco_pago_cia_Id = $('#cboBancoPago_Cia').val();
    var Banco_pago_cts_cia_Id = $('#cboBancoPagoCTS_Cia').val();
    //@002 F
    var Proyecto_Id = $('#cboProyecto').val();
    var Tgasto_Id = '';
    var Usuario = '';
    var Pase = '';
    var LAdministrador = 0;
    var Estado_Id = $('#cboEstado').val();
    var Area_Id = $('#cboArea').val();
    var Cod_Antiguo = '';
    var Email = $('#txtEmail').val();
    var Nacionalidad_Id = $('#cboNacionalidad').val();
    var Domiciliado = Boolean($('#ckDomiciliado').attr('checked'));
    var Tipo_Via_Id = $('#cboTipoVia').val();
    var Numero_Via = $('#txtNumVia').val();
    var Interior_Via = $('#txtInteriorVia').val();
    var Tipo_Zona_Id = $('#cboTipoZona').val();
    var Nombre_Zona = $('#txtNomZona').val();
    var Referencia = $('#txtReferencia').val();
    var Tipo_Trabajador_Id = $('#cboTipoTrabajador').val();
    var Regimen_Laboral_Id = $('#cboRegLaboral').val();
    var Nivel_Educativo_Id = $('#cboNivelEduca').val();
    var Discapacidad = Boolean($('#ckDiscapacitado').attr('checked'));
    var SCTR_Salud_Id = $('#cboSCTRSalud').val();
    var SCTR_Pension_Id = $('#cboSCTRPension').val();
    var Tipo_Contrato_Id = $('#cboTipoContrato').val();
    var Jornada_Atipica = Boolean($('#ckJorAtipica').attr('checked'));
    var Jornada_Maxima = Boolean($('#ckJorMaxima').attr('checked'));
    var Horario_Nocturno = Boolean($('#ckHorarioNoctu').attr('checked'));
    var Sindicalizado = Boolean($('#ckSindicalizado').attr('checked'));
    var EPS_Id = $('#cboEPS').val();
    var Ingresos_5ta_Inafectos = Boolean($('#ckIng5taInaf').attr('checked'));
    var Situacion_Especial_Id = $('#cboSituacionEspec').val();
    var RUC = $('#txtRUC').val();
    var Seguro_Medico_Id = $('#cboSeguroMed').val();
    var Madre_Resp_Fam = Boolean($('#ckMadreconResFam').attr('checked'));
    var Tipo_Centro_Form_Prof_Id = $('#cboTipoCenFProf').val();
    var RUC_Destaque = $('#txtRUCDest').val();
    //////var Foto image(16)
    var Foto_NombreArchivo = '';
    var Nro_Calzado = $('#txtNroCalzado').val();
    var Talla_Ropa_Id = $('#cboTallaRopa').val();
    var Grupo_Sanguineo_Id = $('#cboGrupoSanguineo').val();
    var Estatura = $('#txtEstatura').val() == '' ? '0.00' : $('#txtEstatura').val();
    var Peso = $('#txtPeso').val() == '' ? '0.00' : $('#txtPeso').val();
    var Complexion_Fisica_Id = $('#cboCompexion').val();
    var Brevete_Nro = $('#txtNroBrevete').val();
    var Brevete_Categoria_Id = $('#cboCategoriaBrevete').val();
    var Brevete_Vigencia = $('#txtVigencia').val() == '' ? '1900-01-01' : $('#txtVigencia').val();
    var Alergias = $('#txtAlergias').val();
    var Codigo_Auxiliar = $('#txtCodAuxiliar').val();
    var Seccion_Id = '';
    var Contrasenia = $("#txtContrasenia").val(); //@003 I/F
    var NivelAcceso = $("#cboNivelAcceso").val(); //@003 I/F

    /*Datos para la tabla Personal_Activo*/

    var Periodo_Id = Get_Periodo();
    var Fecha_ingreso = formatFecha.format1($('#txtFecIngreso').val());
    var fechacese;
    if ($('#txtFecCese').val() != '' && $('#txtFecCese').val() != '01/01/1900') {
        fechacese = formatFecha.format1($('#txtFecCese').val());
    } else {
        fechacese = '1900-01-01';
    }
    var Fecha_cese = fechacese
    var Fecha_ini_contrato = formatFecha.format1($('#txtFecIniContrato').val());
    var Fecha_fin_contrato = formatFecha.format1($('#txtFecFinContrato').val());
    var Pry_Operacion_Id = '';
    var Pry_Categoria_Id = '';
    var Flag_Distribuido = '';
    var Observaciones = '';
    var Motivo_Fin_Per_Lab_Id = $('#cboMotivoCese').val();
    var Tipo_Mod_Formativa_Id = $('#cboTipoModFormat').val();
    var Nro_CITT = $('#txtNroCITT').val();
    var Cod_Contrato = '';
    var Fecha_Impresion_Contrato = '1900-01-01';
    var EPSPLAN_ID = '00';
    /*var Cantidad_Titular = $('#txtCodAuxiliar').val();
    var Cantidad_Dependientes = $('#txtCodAuxiliar').val();
    var Cantidad_Hmayores = $('#txtCodAuxiliar').val();*/
    var Categoria_Auxiliar_Id = $('#cboCatAuxiliar').val();
    var Categoria_Auxiliar2_Id = $('#cboCatAuxiliar2').val();
    var Personal_Anexo_Id = $('#cboAnexo').val();
    var Personal_Anexo2_Id = $('#cboAnexo2').val();
    var emailp = $('#txtemailp').val();
    var Co_Trabajador_Id = $('#txtCodigoInterno').val();

    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/Update_Personal';

    var params = {
            Personal_Id: Personal_Id    
        , Compania_Id: Compania_Id
        , Planilla_Id: Planilla_Id
        , Apellido_Paterno: Apellido_Paterno.toUpperCase()
        , Apellido_Materno: Apellido_Materno.toUpperCase()
        , Nombres: Nombres.toUpperCase()
        , Sexo_Id: Sexo_Id
        , Fecha_Nacimiento: Fecha_Nacimiento
        , E_Civil_Id: E_Civil_Id
        , Fecha_Ini_AporteAFP: Fecha_Ini_AporteAFP
        , Tipo_Doc_Id: Tipo_Doc_Id
        , Nro_Doc: Nro_Doc
        , Categoria_Id: Categoria_Id
        , Categoria2_Id: Categoria2_Id
        , Cargo_Id: Cargo_Id
        , Situacion_Id: Situacion_Id
        , Afp_Id: Afp_Id
        , Afp_cod_afiliacion: Afp_cod_afiliacion
        , Seguro_cod: Seguro_cod
        , Ccosto_Id: Ccosto_Id
        , Dpto: Dpto
        , Prov: Prov
        , Dist: Dist
        , Direccion: Direccion
        , Telefono: Telefono
        , Telefono2: Telefono2
        , Telefono3: Telefono3
        , Nro_Hijos: parseInt(Nro_Hijos)
        , Tip_cta_Id: Tip_cta_Id
        , Nro_cta: Nro_cta
        , Moneda_cta_Id: Moneda_cta_Id
        , Banco_cta_Id: Banco_cta_Id
        , Nro_cta_cts: Nro_cta_cts
        , Tip_cta_cts_Id: Tip_cta_cts_Id
        , Moneda_cta_cts_Id: Moneda_cta_cts_Id
        , Banco_cta_cts_Id: Banco_cta_cts_Id
        , Proyecto_Id: Proyecto_Id
        , Tgasto_Id: Tgasto_Id
        , Usuario: Usuario
        , Pase: Pase
        , LAdministrador: parseInt(LAdministrador)
        , Estado_Id: Estado_Id
        , Area_Id: Area_Id
        , Cod_Antiguo: Cod_Antiguo
        , Email: Email
        , Nacionalidad_Id: Nacionalidad_Id
        , Domiciliado: Domiciliado
        , Tipo_Via_Id: Tipo_Via_Id
        , Numero_Via: Numero_Via
        , Interior_Via: Interior_Via
        , Tipo_Zona_Id: Tipo_Zona_Id
        , Nombre_Zona: Nombre_Zona
        , Referencia: Referencia
        , Tipo_Trabajador_Id: Tipo_Trabajador_Id
        , Regimen_Laboral_Id: Regimen_Laboral_Id
        , Nivel_Educativo_Id: Nivel_Educativo_Id
        , Discapacidad: Discapacidad
        , SCTR_Salud_Id: SCTR_Salud_Id
        , SCTR_Pension_Id: SCTR_Pension_Id
        , Tipo_Contrato_Id: Tipo_Contrato_Id
        , Jornada_Atipica: Jornada_Atipica
        , Jornada_Maxima: Jornada_Maxima
        , Horario_Nocturno: Horario_Nocturno
        , Sindicalizado: Sindicalizado
        , EPS_Id: EPS_Id
        , Ingresos_5ta_Inafectos: Ingresos_5ta_Inafectos
        , Situacion_Especial_Id: Situacion_Especial_Id
        , RUC: RUC
        , Seguro_Medico_Id: Seguro_Medico_Id
        , Madre_Resp_Fam: Madre_Resp_Fam
        , Tipo_Centro_Form_Prof_Id: Tipo_Centro_Form_Prof_Id
        , RUC_Destaque: RUC_Destaque

        , Foto_NombreArchivo: Foto_NombreArchivo
        , Nro_Calzado: Nro_Calzado
        , Talla_Ropa_Id: Talla_Ropa_Id
        , Grupo_Sanguineo_Id: Grupo_Sanguineo_Id
        , Estatura: parseFloat(Estatura)
        , Peso: parseFloat(Peso)
        , Complexion_Fisica_Id: Complexion_Fisica_Id
        , Brevete_Nro: Brevete_Nro
        , Brevete_Categoria_Id: Brevete_Categoria_Id
        , Brevete_Vigencia: Brevete_Vigencia
        , Alergias: Alergias
        , Codigo_Auxiliar: Codigo_Auxiliar
        , Seccion_Id: Seccion_Id
        , Co_Trabajador_Id: Co_Trabajador_Id
/*Datos para la tabla Personal_Activo*/
        , Periodo_Id: Periodo_Id
        , Fecha_ingreso: Fecha_ingreso
        , Fecha_cese: Fecha_cese
        , Fecha_ini_contrato: Fecha_ini_contrato
        , Fecha_fin_contrato: Fecha_fin_contrato
        , Pry_Operacion_Id: Pry_Operacion_Id
        , Pry_Categoria_Id: Pry_Categoria_Id
        , Flag_Distribuido: Flag_Distribuido
        , Observaciones: Observaciones
        , Motivo_Fin_Per_Lab_Id: Motivo_Fin_Per_Lab_Id
        , Tipo_Mod_Formativa_Id: Tipo_Mod_Formativa_Id
        , Nro_CITT: Nro_CITT
        , Cod_Contrato: Cod_Contrato
        , Fecha_Impresion_Contrato: '1900-01-01'
        , EPSPLAN_ID: EPSPLAN_ID
        , Cantidad_Titular: 0
        , Cantidad_Dependientes: 0
        , Cantidad_Hmayores: 0
        , Categoria_Auxiliar_Id: Categoria_Auxiliar_Id
        , Categoria_Auxiliar2_Id: Categoria_Auxiliar2_Id
        , Personal_Anexo_Id: Personal_Anexo_Id
        , Personal_Anexo2_Id: Personal_Anexo2_Id
        , UsuarioSess: SessionUsuarioAcceso
        , Nro_cta_interbancaria: Nro_cta_interbancaria
        , co_rol: co_rol
        , emailp: emailp
        //@002 I
        , Banco_pago_cia_Id: Banco_pago_cia_Id
        , Banco_pago_cts_cia_Id: Banco_pago_cts_cia_Id
        //@002 F
        //@003 I
        , Password: Contrasenia
        , NivelAcceso: NivelAcceso
        //@003 F
    };


    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            if (lengthD > 0 && Datos[1].toString() != '-1') {
                alert('Personal Actualizado Correctamente');
                Personal = [];
                Personal_IdProceso = '';
                PDatosP = 0;
                PDatosS = 0;
                PTabPensio = 0;
                PCuartaMF = 0;
                POtrosD = 0;
                PROCESO = '';
                if (disNew) {
                window.clearInterval(disNew);
                }
                
                window.clearInterval(disGrabar);
                window.clearInterval(disCancel);
                window.clearInterval(disUpdate);
                window.clearInterval(disDelete);

                Disable_btnNew(false);

                disGrabar = window.setInterval(function() {
                    Disable_btnGrabar(true);
                }, 100);

                disCancel = window.setInterval(function() {
                    Disable_btnCancelar(true);
                }, 100);

                disUpdate = window.setInterval(function() {
                    Disable_btnActualizar(true);
                }, 100);

                disDelete = window.setInterval(function() {
                    Disable_btnEliminar(true);
                }, 100);
                Personal_IdProceso = '';
                Personal = [];
                PROCESO = '';
                $('#TabContainer').tabs({ disabled: [1, 2, 3, 4, 5] });
                $('#TabContainer').tabs({ active: 0 });

                $('#cboBusquedaEn').val('Personal_Id');
                $('#txtBuscar').val(Datos[1]);
                inicio = 0;
                if (pagePath.indexOf('MaestroPersonal.aspx') != -1) {
                    Lista_Personal_x_Filtro_Columna(Get_Compania(), null, Get_ColumnaBusqueda(), Get_TextoBusqueda(), inicio);
                } else {
                    Lista_Personal_x_Filtro_Columna(Get_Compania(), Get_Periodo(), Get_ColumnaBusqueda(), Get_TextoBusqueda(), inicio);
                }
            } else if (lengthD > 0 && Datos[1].toString() == '-1') {
                Set_Error('.::Error, ' + Datos[2].toString(), null, 0);
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

//ELIMINAR PERSONAL
function Delete_Personal(Personal_Id) {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/Delete_Personal';

    var params = {
    Personal_Id: Personal_Id
    }
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            if (lengthD > 0 && parseInt(Datos[1].toString()) > 0) {
                alert('Personal Eliminado Correctamente');
                Personal = [];
                Personal_IdProceso = '';
                PDatosP = 0;
                PDatosS = 0;
                PTabPensio = 0;
                PCuartaMF = 0;
                POtrosD = 0;
                PROCESO = '';
                if (disNew) {
                    window.clearInterval(disNew);
                    }
                
                window.clearInterval(disGrabar);
                window.clearInterval(disCancel);
                window.clearInterval(disUpdate);
                window.clearInterval(disDelete);

                Disable_btnNew(false);

                disGrabar = window.setInterval(function() {
                    Disable_btnGrabar(true);
                }, 100);

                disCancel = window.setInterval(function() {
                    Disable_btnCancelar(true);
                }, 100);

                disUpdate = window.setInterval(function() {
                    Disable_btnActualizar(true);
                }, 100);

                disDelete = window.setInterval(function() {
                    Disable_btnEliminar(true);
                }, 100);
                Personal_IdProceso = '';
                Personal = [];
                PROCESO = '';
                $('#TabContainer').tabs({ disabled: [1, 2, 3, 4, 5] });
                $('#TabContainer').tabs({ active: 0 });
                inicio = 0;
                if (pagePath.indexOf('MaestroPersonal.aspx') != -1) {
                    Lista_Personal_x_Filtro_Columna(Get_Compania(), null, Get_ColumnaBusqueda(), Get_TextoBusqueda(), inicio);
                } else {
                    Lista_Personal_x_Filtro_Columna(Get_Compania(), Get_Periodo(), Get_ColumnaBusqueda(), Get_TextoBusqueda(), inicio);
                }
            } else if (lengthD > 0 && parseInt(Datos[1].toString()) < 0) {
                alert('.::Error, ' + Datos[2].toString());
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}


function CargarDatosPrincipales_Personal() { 
    if (Personal.length > 0) {
        //----- Datos Principales

        $('#txtPersonal_Id').val(Personal[0][0]);
        $('#txtNombre').val(Personal[0][8]);
        $('#txtApePaterno').val(Personal[0][6]);
        $('#txtApeMaterno').val(Personal[0][7]);
        var FechaNacimiento = formatFecha.format3(Personal[0][10].toDateFormat());
        $('#txtFecNacim').datepicker("setDate", FechaNacimiento);
        $('#txtNroDoc').val(Personal[0][14]);
        $('#txtTelf').val(Personal[0][27]);
        $('#txtTelf2').val(Personal[0][28]);
        $('#txtTelf3').val(Personal[0][29]);
        $('#ckDomiciliado').attr('checked', Boolean(Personal[0][50]));
        $('#txtEmail').val(Personal[0][47]);
        $('#txtemailp').val(Personal[0][102]);
        $('#txtNomVia').val(Personal[0][26]);
        $('#txtNumVia').val(Personal[0][51]);
        $('#txtInteriorVia').val(Personal[0][52]);
        $('#txtNomZona').val(Personal[0][54]);
        $('#txtReferencia').val(Personal[0][55]);
        $('#txtCodigoInterno').val(Personal[0][103]);

        //COMBOS
        $('#cboTipoDoc').val(Personal[0][13]);
        $('#cboNacionalidad').val(Personal[0][48]);
        $('#cboSexo').val(Personal[0][9]);
        $('#cboTipoVia').val(Personal[0][50]);
        $('#cboTipoZona').val(Personal[0][53]);
        $('#cboDep').val(Personal[0][23]);
        ListaProvincia(Personal[0][23]);
        $('#cboProv').val(Personal[0][24]);
        ListaDistrito($('#cboDep').val(), $('#cboProv').val());
        $('#cboDist').val(Personal[0][25]);
    }
}


function CargarDatosSecundarios_Personal() {
    if (Personal.length > 0) {
        //----- Datos Scundarios
        $('#cboCompania').val(Personal[0][2]);
        ListaTipoPlanilla($('#cboCompania').val());
        $('#cboTipoPlanilla').val(Personal[0][3]);
        $('#cboArea').val(Personal[0][45]);
        $('#cboCCosto').val(Personal[0][22]);
        $('#cboCategoria').val(Personal[0][15]);
        $('#cboCategoria2').val(Personal[0][16]);
        $('#cboProyecto').val(Personal[0][39]);
        $('#cboSituacion').val(Personal[0][18]);
        $('#cboEstadoCivil').val(Personal[0][11]);
        $('#cboEstado').val(Personal[0][44]);
        $('#cboMotivoCese').val(Personal[0][96]);
        $('#cboCatAuxiliar').val(Personal[0][92]);
        ListaCatAuxiliar2($('#cboCatAuxiliar').val());
        $('#cboCatAuxiliar2').val(Personal[0][93]);
        $('#cboAnexo').val(Personal[0][94]);
        $('#cboAnexo2').val(Personal[0][95]);
        $('#cboTipoCuenta').val(Personal[0][31]);
        $('#cboTipoCuentaCTS').val(Personal[0][36]);
        $('#cboBancoCuenta').val(Personal[0][34]);
        $('#cboBancoCuentaCTS').val(Personal[0][38]);
        $('#cboMonedaCuenta').val(Personal[0][33]);
        $('#cboMonedaCuentaCTS').val(Personal[0][37]);
        
        //inputs
        $('#txtCodSegSocial').val(Personal[0][21]);
        $('#txtNumHijos').val(Personal[0][30]);
        var FechaIngreso = formatFecha.format3(Personal[0][88].toDateFormat());
        $('#txtFecIngreso').datepicker("setDate", FechaIngreso);

        var FechaIniContrato = formatFecha.format3(Personal[0][90].toDateFormat());
        $('#txtFecIniContrato').datepicker("setDate", FechaIniContrato);

        var FechaFinContrato = formatFecha.format3(Personal[0][91].toDateFormat());
        $('#txtFecFinContrato').datepicker("setDate", FechaFinContrato);

        var FechaCese = formatFecha.format3(Personal[0][89].toDateFormat());
        if (FechaCese != '01/01/1900') {
            $('#txtFecCese').datepicker("setDate", FechaCese);
        } else {
        $('#txtFecCese').val('');
        }

        $('#txtNroCuenta').val(Personal[0][32]);
        $('#txtNroCuentaCTS').val(Personal[0][35]);
        $('#txtNroCuentaInterbancaria').val(Personal[0][100]);
        //@002 I
        $('#cboBancoPago_Cia').val($.trim(Personal[0][104]) == "" ? "" :  Personal[0][104]);
        $('#cboBancoPagoCTS_Cia').val($.trim(Personal[0][105]) == "" ? "" : Personal[0][105]);
        //@002 F
    }
}


function CargarDatosTrabPensionista_Personal() {
    if (Personal.length > 0) {
        //----- Datos Trab / Pensionista

        $('#cboTipoTrabajador').val(Personal[0][56]);
        $('#cboTipoPensionista').val(Personal[0][56]);
        $('#cboRegLaboral').val(Personal[0][57]);
        $('#cboNivelEduca').val(Personal[0][58]);
        $('#cboCargo').val(Personal[0][17]);
        $('#cboRegPensionario').val(Personal[0][19]);
        $('#cboRegPensionista').val(Personal[0][19]);
        $('#cboSCTRSalud').val(Personal[0][60]);
        $('#cboSCTRPension').val(Personal[0][61]);
        $('#cboTipoContrato').val(Personal[0][62]);
        $('#cboEPS').val(Personal[0][67]);
        $('#cboSituacionEspec').val(Personal[0][69]);


        $('#ckDiscapacitado').attr('checked', Boolean(Personal[0][59]));
        $('#ckJorAtipica').attr('checked', Boolean(Personal[0][63]));
        $('#ckHorarioNoctu').attr('checked', Boolean(Personal[0][65]));
        $('#ckSindicalizado').attr('checked', Boolean(Personal[0][66]));
        $('#ckIng5taInaf').attr('checked', Boolean(Personal[0][68]));

        $('#ckJorMaxima').attr('checked', Boolean(Personal[0][64]));
        
        var FechaIniAportacion = formatFecha.format3(Personal[0][12].toDateFormat());
        $('#txtFecIniAportacion').datepicker("setDate", FechaIniAportacion);
        $('#txtFecIniAporacion2').val(FechaIniAportacion);


        $('#txtCUSPP').val(Personal[0][20]);
        $('#txtCUSPP2').val(Personal[0][20]);
        $('#cboRol').val(Personal[0][101]);
        $("#txtContrasenia").val(Personal[0][106]); //@003 I/F
        $("#cboNivelAcceso").val(Personal[0][107]); //@003 I/F
    } 
}
function CargarDatosCuartaMF_Personal() {
    if (Personal.length > 0) {
        //----- 4ta / M.F. / Ter.
        $('#cboSeguroMed').val(Personal[0][71]);
        $('#cboNivelEduca2').val(Personal[0][58]);
        $('#cboCargo2').val(Personal[0][17]);
        $('#cboTipoCenFProf').val(Personal[0][73]);
        //$('#cboTipoModFormat').val(Personal[0][97]);
        $('#cboSCTRSalud2').val(Personal[0][60]);
        $('#cboSCTRPension2').val(Personal[0][61]);

        $('#ckMadreconResFam').attr('checked', Boolean(Personal[0][72]));
        $('#ckDiscapacidad2').attr('checked', Boolean(Personal[0][59]));
        $('#ckHorarioNoctu2').attr('checked', Boolean(Personal[0][65]));       

        $('#txtRUC').val(Personal[0][70]);
        $('#txtRUCDest').val(Personal[0][74]);
        $('#txtNroCITT').val(Personal[0][98]);
    }
}
function CargarDatosOtrosDatos_Personal() { //@001 I/F
    if (Personal.length > 0) {
        //----- Otros Datos
        //$('#cboCompexion').val($.trim(Personal[0][81])); //@001 I/F
        $('#cboGrupoSanguineo').val($.trim(Personal[0][78])); //@001 I/F
        //$('#cboTallaRopa').val($.trim(Personal[0][77])); //@001 I/F
        $('#cboCategoriaBrevete').val($.trim(Personal[0][83])); //@001 I/F
        $('#txtEstatura').val(Personal[0][79]);
        $('#txtPeso').val(Personal[0][80]);
        $('#txtAlergias').val(Personal[0][85]);
        $('#txtNroCalzado').val(Personal[0][76]);
        $('#txtNroBrevete').val(Personal[0][82]);
        
        var FechaVigencia = formatFecha.format3(Personal[0][84].toDateFormat());
        $('#txtVigencia').datepicker("setDate", FechaVigencia);

        $('#txtCodAuxiliar').val(Personal[0][86]);
        
    } 
}

//CARGAR TODOS LOS COMBOS


////-- Datos Principales

function ListaTipoDoc() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaTipoDoc';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboTipoDoc').html('');
            $('<option value="">-Seleccione-</option>').appendTo('#cboTipoDoc');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboTipoDoc');
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function ListaNacionalidad() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaNacionalidad';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboNacionalidad').html('');
            $('<option value="">-Seleccione-</option>').appendTo('#cboNacionalidad');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboNacionalidad');
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function ListaTipoSexo() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaTipoSexo';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboSexo').html('');
            $('<option value="">-Seleccione-</option>').appendTo('#cboSexo');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboSexo');
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function ListaTipoVia() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaTipoVia';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboTipoVia').html('');            
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboTipoVia');
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function ListaTipoZona() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaTipoZona';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboTipoZona').html('');            
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboTipoZona');
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function ListaDepartamento() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaDepartamento';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboDep').html('');
            $('<option value="">-Seleccione-</option>').appendTo('#cboDep');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboDep');
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function ListaProvincia(Departamento_Id) {
    //@001 I
    if (Departamento_Id == "") {
        $('#cboProv').html('');
        $('<option value="">-Seleccione-</option>').appendTo('#cboProv');
    }
    else {
        //@001 F
        var pagePath = window.location.pathname;
        var urlajax = pagePath + '/ListaProvincia';
        var params = {
            Departamento_Id: Departamento_Id
        };
        $.ajax({
            type: "POST",
            data: JSON.stringify(params),
            url: urlajax,
            contentType: "application/json; chartseft:utf-8",
            dataType: "json",
            success: function (response) {
                var Datos = response.d;
                var lengthD = Datos.length - 1;

                $('#cboProv').html('');
                $('<option value="">-Seleccione-</option>').appendTo('#cboProv');
                for (var i = 0; i <= lengthD; i++) {
                    var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                    $(html).appendTo('#cboProv');
                }
            },
            error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
            async: false
        });
    } //@001 I/F
}

function ListaDistrito(Departamento_Id, Provincia_Id) {
    //@001 I
    if (Provincia_Id == "") {
        $('#cboDist').html('');
        $('<option value="">-Seleccione-</option>').appendTo('#cboDist');
    }
    else { //@001 F
        var pagePath = window.location.pathname;
        var urlajax = pagePath + '/ListaDistrito';
        var params = {
            Departamento_Id: Departamento_Id,
            Provincia_Id: Provincia_Id
        };
        $.ajax({
            type: "POST",
            data: JSON.stringify(params),
            url: urlajax,
            contentType: "application/json; chartseft:utf-8",
            dataType: "json",
            success: function (response) {
                var Datos = response.d;
                var lengthD = Datos.length - 1;

                $('#cboDist').html('');
                $('<option value="">-Seleccione-</option>').appendTo('#cboDist');
                for (var i = 0; i <= lengthD; i++) {
                    var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                    $(html).appendTo('#cboDist');
                }
            },
            error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
            async: false
        });
    } //@001 I/F
}

function CargarCombosDatosPrincipales() { 
ListaTipoDoc();
ListaNacionalidad();
ListaTipoSexo();
ListaTipoVia();
ListaTipoZona();
ListaDepartamento();
var Departamento=$('#cboDep').val();
ListaProvincia(Departamento);
var Provincia=$('#cboDep').val();
ListaDistrito(Departamento,Provincia);
}


//Datos Secundarios

function ListaCompania() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaCompania';

    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboCompania').html('');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboCompania');
            }
            var EmpresaCab = document.getElementById('ctl00_ucFiltros1_cboEmpresa').value;
            
            $('#cboCompania').val(EmpresaCab);

        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function ListaTipoPlanilla(Compania_Id) {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaTipoPlanilla';
	var params = {
	    Compania_Id: Compania_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboTipoPlanilla').html('');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboTipoPlanilla');
            }
            var PlanillaCab = document.getElementById('planillaSession').value;
            $('#cboTipoPlanilla').val(PlanillaCab)
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function ListaArea() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaArea';

    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboArea').html('');
            $('<option value="">-Seleccione-</option>').appendTo('#cboArea');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboArea');
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function ListaCCosto() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaCCosto';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboCCosto').html('');
            $('<option value="">-Seleccione-</option>').appendTo('#cboCCosto');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboCCosto');
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function ListaCategoria() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaCategoria';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboCategoria').html('');
            $('<option value="">-Seleccione-</option>').appendTo('#cboCategoria');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboCategoria');
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function ListaCategoria2() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaCategoria2';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboCategoria2').html('');            
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboCategoria2');
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
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
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboProyecto').html('');
            $('<option value="">-Seleccione-</option>').appendTo('#cboProyecto');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboProyecto');
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function ListaSituacion() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaSituacion';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboSituacion').html('');
            $('<option value="">-Seleccione-</option>').appendTo('#cboSituacion');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboSituacion');
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function ListaEstadoCivil() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaEstadoCivil';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboEstadoCivil').html('');
            $('<option value="">-Seleccione-</option>').appendTo('#cboEstadoCivil');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboEstadoCivil');
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
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
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboCatAuxiliar').html('');
            $('<option value="">-Seleccione-</option>').appendTo('#cboCatAuxiliar');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboCatAuxiliar');
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function ListaCatAuxiliar2(Categoria_Auxiliar_Id) {
    //@001 I
    if (Categoria_Auxiliar_Id == "") {
        $('#cboCatAuxiliar2').html('');
        $('<option value="">-Seleccione-</option>').appendTo('#cboCatAuxiliar2');
    }
    else {//@001 F
        var pagePath = window.location.pathname;
        var urlajax = pagePath + '/ListaCatAuxiliar2';

        var params = {
            Categoria_Auxiliar_Id: Categoria_Auxiliar_Id
        };
        $.ajax({
            type: "POST",
            data: JSON.stringify(params),
            url: urlajax,
            contentType: "application/json; chartseft:utf-8",
            dataType: "json",
            success: function (response) {
                var Datos = response.d;
                var lengthD = Datos.length - 1;

                $('#cboCatAuxiliar2').html('');
                $('<option value="">-Seleccione-</option>').appendTo('#cboCatAuxiliar2');
                for (var i = 0; i <= lengthD; i++) {
                    var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                    $(html).appendTo('#cboCatAuxiliar2');
                }
            },
            error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
            async: false
        });
    } //@001 I/F
}

function ListaAnexo() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaAnexo';	
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboAnexo').html('');            
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboAnexo');
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function ListaAnexo2() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaAnexo2';	
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboAnexo2').html('');            
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboAnexo2');
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function ListaEstados() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaEstados';	
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboEstado').html('');            
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboEstado');
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function ListaMotivoCese() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaMotivoCese';	
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboMotivoCese').html('');
            $('<option value="">-Seleccione-</option>').appendTo('#cboMotivoCese');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboMotivoCese');
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function ListaTipoCuenta() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaTipoCuenta';	
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboTipoCuenta').html('');
			$('#cboTipoCuentaCTS').html('');            
			
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboTipoCuenta');
				$(html).appendTo('#cboTipoCuentaCTS');
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function ListaBancos() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaBancos';	
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboBancoCuenta').html('');
			$('#cboBancoCuentaCTS').html('');            
			
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboBancoCuenta');
				$(html).appendTo('#cboBancoCuentaCTS');
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

//@002 I
function ListaBancos_Cia() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaBancos_Cia';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboBancoPago_Cia').html('');
            $('#cboBancoPagoCTS_Cia').html('');

            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboBancoPago_Cia');
                $(html).appendTo('#cboBancoPagoCTS_Cia');
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: false
    });
}
//@002 F

function ListaMonedaCta() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaMonedaCta';	
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboMonedaCuenta').html('');
			$('#cboMonedaCuentaCTS').html('');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboMonedaCuenta');
				$(html).appendTo('#cboMonedaCuentaCTS');
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function CargarCombosDatosSecundarios(){
ListaCompania();
var companiaId=$('#cboCompania').val();
ListaTipoPlanilla(companiaId);
ListaArea();
ListaCCosto();
ListaCategoria();
ListaCategoria2();
ListaProyecto();
ListaSituacion();
ListaEstadoCivil();
ListaCatAuxiliar();
var cateAux=$('#cboCatAuxiliar').val();
ListaCatAuxiliar2(cateAux);
ListaAnexo();
ListaAnexo2();
ListaEstados();
ListaMotivoCese();
ListaTipoCuenta();
ListaBancos();
ListaBancos_Cia(); //@002 I/F
ListaMonedaCta();

}

//--- 4. TRAB / PENSIONARIO
function ListaTipoTrabajador() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaTipoTrabajador';	
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboTipoTrabajador').html('');
			$('#cboTipoPensionista').html('');
			
			$('<option value="">-Seleccione-</option>').appendTo('#cboTipoTrabajador');			
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboTipoTrabajador');
				$(html).appendTo('#cboTipoPensionista');
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function ListaRegLaboral() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaRegLaboral';	
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboRegLaboral').html('');	
			$('<option value="">-Seleccione-</option>').appendTo('#cboRegLaboral');			
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboRegLaboral');
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function ListaNivelEducativo() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaNivelEducativo';	
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboNivelEduca').html('');   
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboNivelEduca');               
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function ListaCargo() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaCargo';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboCargo').html('');    
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboCargo');             
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function ListaRegimenPensionario() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaRegimenPensionario';	
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboRegPensionario').html('');				
			$('#cboRegPensionista').html('');							
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboRegPensionario');
				$(html).appendTo('#cboRegPensionista');
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function ListaSCTRSalud() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaSCTRSalud';	
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboSCTRSalud').html('');						
						
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboSCTRSalud');				
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function ListaSCTRPension() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaSCTRPension';	
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboSCTRPension').html('');		
			
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboSCTRPension');				
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function ListaTipoContrato() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaTipoContrato';	
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboTipoContrato').html('');					
						
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboTipoContrato');
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function ListaEPS() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaEPS';	
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboEPS').html('');		
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboEPS');
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function ListaSituacionEspecial() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaSituacionEspecial';	
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboSituacionEspec').html('');		
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboSituacionEspec');
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function CargarCombosTrabPensionario(){
ListaTipoTrabajador();
ListaRegLaboral();
ListaNivelEducativo();
ListaCargo();
ListaRegimenPensionario();
ListaSCTRSalud();
ListaSCTRPension();
ListaTipoContrato();
ListaEPS();
ListaSituacionEspecial();
}
//---- 4ta / M.F. / Ter.
function ListaSeguroMedico() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaSeguroMedico';	
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboSeguroMed').html('');					
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboSeguroMed');
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function ListaCentroFormacionProf() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaCentroFormacionProf';	
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboTipoCenFProf').html('');					
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboTipoCenFProf');
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function ListaModFormativa() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaModFormativa';	
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboTipoModFormat').html('');		
			
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboTipoModFormat');
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function ListaNivelEducativo_MF() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaNivelEducativo';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#cboNivelEduca2').html('');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboNivelEduca2');
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function ListaCargo_MF() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaCargo';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            //4ta / M.F /Ter.
            $('#cboCargo2').html('');

            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';              
                $(html).appendTo('#cboCargo2');

            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function ListaSCTRSalud_MF() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaSCTRSalud';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
           $('#cboSCTRSalud2').html('');

            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';

                $(html).appendTo('#cboSCTRSalud2');
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}


function ListaSCTRPension_MF() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaSCTRPension';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#cboSCTRPension2').html('');

            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';              
                $(html).appendTo('#cboSCTRPension2');
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}


function CargarCombosCuartaMF(){
ListaSeguroMedico();
ListaCentroFormacionProf();
ListaModFormativa();
ListaNivelEducativo_MF();
ListaCargo_MF();
ListaSCTRSalud_MF();
ListaSCTRPension_MF();
}

//---- Otros Datos
function ListaComplexionFisica() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaComplexionFisica';	
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboCompexion').html('');		
			$('<option value="">-Seleccione-</option>').appendTo('#cboCompexion');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboCompexion');
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function ListaGrupoSanguineo() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaGrupoSanguineo';	
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboGrupoSanguineo').html('');		
			$('<option value="">-Seleccione-</option>').appendTo('#cboGrupoSanguineo');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboGrupoSanguineo');
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function ListaTallaRopa() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaTallaRopa';	
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboTallaRopa').html('');		
			$('<option value="">-Seleccione-</option>').appendTo('#cboTallaRopa');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboTallaRopa');
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function ListaBreveteCategoria() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaBreveteCategoria';	
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboCategoriaBrevete').html('');		
			$('<option value="">-Seleccione-</option>').appendTo('#cboCategoriaBrevete');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboCategoriaBrevete');
            }
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}



function CargarComboOtrosDatos(){
ListaComplexionFisica();
ListaGrupoSanguineo();
ListaTallaRopa();
ListaBreveteCategoria();
ListaColumnPersonal();
}







//FECHAS

String.prototype.toDateFormat = function() {

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



String.prototype.padLeft = function(paddingChar, length) {

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
  
    var fecha = new Date(anio,mes,dia);
    if (dia != fecha.getDate() || mes != fecha.getMonth() || anio != fecha.getFullYear()) {
       
        return false;

    }
    return true;
 
}


//FORMATOS

var formatFecha = {
    format1: function(fecha) {

        if (fecha.indexOf(' ') != -1) {
            var arr1 = fecha.split(' ');
            var arr = arr1[0].split('/');
            return arr[2] + '-' + arr[1] + '-' + arr[0];
        } else {
            var arr = fecha.split('/');
            return arr[2] + '-' + arr[1] + '-' + arr[0];
        }

    },
    format2: function(fecha) {
        if (fecha.indexOf(' ') != -1) {
            var arr1 = fecha.split(' ');
            var arr = arr1[0].split('/');
            return arr[0] + '-' + arr[1] + '-' + arr[2];
        } else {
            var arr = fecha.split('/');
            return arr[0] + '-' + arr[1] + '-' + arr[2];
        }


    },
    format3: function(fecha) {
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

//@001 I
function fc_FillComboArray(idCombo, Datos, textInicial) {
    var lengthD = Datos.length - 1;
    $("#" + idCombo).html("");
    if (textInicial != "") {
        $('<option value="">' + textInicial + '</option>').appendTo("#" + idCombo);
    }
    for (var i = 0; i <= lengthD; i++) {
        var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
        $(html).appendTo("#" + idCombo);
    }
}
//@001 F