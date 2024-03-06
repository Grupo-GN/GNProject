 
function Get_Planilla_List() {

    $.ajax({
        type: "POST",
        dataType: "json",
        url: "sPasarPlanilla.aspx/Get_Planilla_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboPlanilla').html('');
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Planilla_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboPlanilla');
            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: false
        //async: false
    });

};

//function Get_Localidad_List() {
//    $.ajax({
//        type: "POST",
//        dataType: "json",
//        url: "sPasarPlanilla.aspx/Get_Localidad_List",
//        contentType: "application/json; chartseft:utf-8",
//        success: function (response) {
//            var Data = response.d;
//            var lengthd = Data.length - 1;
//            $('#cboLocalidad').html('');
//            $('<option value="">-TODOS-</option>').appendTo('#cboLocalidad');
//            for (var i = 0; i <= lengthd; i++) {
//                $('<option value="' + Data[i].Area_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboLocalidad');
//            }
//        },
//        error:
//   function (XmlHttpError, error, description) {
//       $('#dialog-form').html(XmlHttpError.responseText);
//   },
//        async: false
//    });
//};

function Get_Localidad_List() {

    $.ajax({
        type: "POST",
        data: JSON.stringify(),
        dataType: "json",
        url: "sPasarPlanilla.aspx/Get_Localidad_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            $('#cboLocalidad').html('');

            var lengtDatos = Data.length - 1;
            $('<option value="">-TODOS-</option>').appendTo('#cboLocalidad');
            for (var i = 0; i <= lengtDatos; i++) {

                var html = '<option value="' + Data[i].Area_Id + '">' + Data[i].Descripcion + '</option>';
                $(html).appendTo('#cboLocalidad');

            }

        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}


function Get_Categoria_List() {
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "sPasarPlanilla.aspx/Get_Categoria_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboCategoria').html('');
            $('<option value="">-TODOS-</option>').appendTo('#cboCategoria');
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Categoria2_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboCategoria');
            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: false
       
    });
};


function Get_Periodo_List(Planilla_Id) {

    var params = {
        Planilla_Id: Planilla_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sPasarPlanilla.aspx/Get_Periodo_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboPeriodo').html('');
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Periodo_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboPeriodo');
            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: false
       
    });
};

function pasaModal() {

    $("#dialog-form").dialog({
        height: 520, width: 637, modal: true, autoOpen: true,
        appendTo: "form", title: "MANTENIMIENTO DE PARAMETROS X CONCEPTO",
        show: { effect: "fade", duration: 800 },
        hide: { effect: "fold", duration: 800 }
    });
}

function closeModalDiv() {
    $('#dialog-form').dialog('close');
}




function Get_CategoriaAux_List() {
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "sPasarPlanilla.aspx/Get_CategoriaAux_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboCatAux').html('');
            $('<option value="">-TODOS-</option>').appendTo('#cboCatAux');
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Categoria_Auxiliar_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboCatAux');
            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: false
     
    });
};


function Get_Personal_List(Periodo_Id, Localidad_Id, CateAux, Categoria) {

    var params = {
        Periodo_Id: Periodo_Id,
        Localidad_Id: Localidad_Id,
        CateAux: CateAux,
        Categoria: Categoria
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sPasarPlanilla.aspx/Get_Personal_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            PersonalArr = [];
            $('#cboPersonal').html('');
            $('<option value="">-TODOS-</option>').appendTo('#cboPersonal');
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Personal_Id + '">' + Data[i].Personal + '</option>').appendTo('#cboPersonal');
                PersonalArr.push(Data[i].Personal_Id);
            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: false
      
    });
};

function Get_Variables(flat) {
  
    var acuHL='';
    var params = {
        flat: flat
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",

        url: "sPasarPlanilla.aspx/Get_Variables",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
           var Proceso = response.d;
            
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var Resultado = Proceso.split('#')[0];
                    var mensaje = Proceso.split('#')[1];
                    if (Resultado != '') {
                        //alert(mensaje);
                        acuHL = mensaje;
                      
                    } else {
                        //alert(mensaje);
                    }
                }
            }
            return acuHL;
        },
        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: true
    });
    return acuHL;
}

//listar parametros

function Get_Parametros_List(semana) {

    $.ajax({
        type: "POST",
        dataType: "json",
        url: "sPasarPlanilla.aspx/ListaParametroConcepto2",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            $('#tbodyParametros').html('');

            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {
                var html = '<tr>';
                if (Data[i].semana == semana) {

                    html += '<td style="text-align:center;"><input type="checkbox" value="' + Data[i].abrev + '" /></td>';
                    html += '<td style="display:none;">' + Data[i].Concepto_Id + '</td>';
                    html += '<td>' + Data[i].abrev + '</td>';
                    html += '<td>' + Data[i].Concepto + '</td>';
                    html += '<td>' + Data[i].Parametro + '</td>';
                    if (Data[i].Estado == '01') {
                        //html += '<td>' + Data[i].C_estado + '</td>'; 
                        html += '<td>' + 'ACTIVO' + '</td>';
                    } else {
                        html += '<td>' + 'INACTIVO' + '</td>';
                    }

                    switch(semana){
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
                    }

                    

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

function Get_NovedadesPasarPlanilla(Planilla_Id, Periodo_Id, Localidad_Id, Personal_Id) {

    var flat = Get_Variables('2');

    var params = {
        Planilla_Id: Planilla_Id,
        Periodo_Id: Periodo_Id,
        Localidad_Id: Localidad_Id,
        Flat:flat,
        Personal_Id: Personal_Id
    };


    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sPasarPlanilla.aspx/Get_NovedadesPasarPlanilla",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#tbodyNovedades').html('');
            for (var i = 0; i <= lengthd; i++) {
                var PersonalCodigo = Data[i].Personal_Id;
                var html = '<tr>';
                html += '<td><input type="checkbox" id="chk' + PersonalCodigo + '" class="chkPasar"/></td>';
                html += '<td>' + Data[i].Planilla + '</td>';
                html += '<td>' + Data[i].Localidad + '</td>';
                html += '<td>' + Data[i].PersonalNom + '</td>';
                html += '<td style="text-align:center;">' + Data[i].TotHE + '</td>';
                html += '<td style="text-align:center;"><input type="text" id="s' + PersonalCodigo + '" class="txt" value="' + Data[i].TotHESimples + '" style="width:43px;" /></td>';
                html += '<td style="text-align:center;"><input type="text" id="a' + PersonalCodigo + '" class="txt" value="' + Data[i].TotHEAdi + '" style="width:43px;" /></td>';
                html += '<td style="text-align:center;"><input type="text" id="d' + PersonalCodigo + '" class="txt" value="' + Data[i].TotHEDob + '" style="width:43px;" /></td>';
                html += '<td style="text-align:center;"><input type="text" id="f' + PersonalCodigo + '" class="txt" value="' + Data[i].Faltas + '" style="width:25px;" /></td>';
                html += '<td style="text-align:center;"><input type="text" id="t' + PersonalCodigo + '" class="txt" value="' + Data[i].MinTarde + '" style="width:35px;" /></td>';
                //html += '<td style="text-align:center;"><input type="text" id="dp' + PersonalCodigo + '" class="txt" value="' + Data[i].DiasPer + '" style="width:35px;" /></td>';
                html += '<td style="text-align:center;"><input type="text" id="per_desmed' + PersonalCodigo + '" class="txt" value="' + Data[i].DiasPer_DesMed + '" style="width:35px;" /></td>';
                html += '<td style="text-align:center;"><input type="text" id="per_perdia' + PersonalCodigo + '" class="txt" value="' + Data[i].DiasPer_PerDia + '" style="width:35px;" /></td>';
                html += '<td style="text-align:center;">' + Data[i].DiasPer_Vac + '</td>';
                html += '<td style="text-align:center;"><input type="text" id="hp' + PersonalCodigo + '" class="txt" value="' + Data[i].HorasPer + '" style="width:35px;" /></td>';
                html += '<td style="text-align:center;"><input type="text" id="do' + PersonalCodigo + '" class="txt" value="' + Data[i].Dominical + '" style="width:35px;" /></td>';
                html += '<td style="text-align:center;">' + Data[i].TotHESimpleFijos + '</td>';
                html += '<td style="text-align:center;">' + Data[i].TotHEAdiFijos + '</td>';
                html += '<td style="text-align:center;">' + Data[i].TotHEDobFijos + '</td>';
                html += '<td style="text-align:center;">' + Data[i].FaltasFijos + '</td>';
                html += '<td style="text-align:center;">' + Data[i].MinTardeFijos + '</td>';
                html += '<td>' + Data[i].Periodo + '</td>';
                html += '<td>' + Data[i].Area + '</td>';
                html += '<td>' + Data[i].CateAux + '</td>';
                html += '</tr>';

                $(html).appendTo('#tbodyNovedades');
            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: false
    });
};

function Get_NovedadesPasarPlanilla2(Planilla_Id, Periodo_Id, Localidad_Id, Personal_Id, FechaIni, FechaFin) {

    var flat = Get_Variables('2');

    var params = {
        Planilla_Id: Planilla_Id,
        Periodo_Id: Periodo_Id,
        Localidad_Id: Localidad_Id,
        Flat: flat,
        Personal_Id: Personal_Id,
        FechaIni:FechaIni, 
        FechaFin:FechaFin
    };


    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sPasarPlanilla.aspx/Get_NovedadesPasarPlanilla2",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#tbodyNovedades').html('');
            for (var i = 0; i <= lengthd; i++) {
                var PersonalCodigo = Data[i].Personal_Id;
                var html = '<tr>';
                html += '<td><input type="checkbox" id="chk' + PersonalCodigo + '" class="chkPasar"/></td>';
                html += '<td>' + Data[i].Planilla + '</td>';
                html += '<td>' + Data[i].Localidad + '</td>';
                html += '<td>' + Data[i].PersonalNom + '</td>';
                html += '<td style="text-align:center;">' + Data[i].TotHE + '</td>';
                html += '<td style="text-align:center;"><input type="text" id="s' + PersonalCodigo + '" class="txt" value="' + Data[i].TotHESimples + '" style="width:43px;" /></td>';
                html += '<td style="text-align:center;"><input type="text" id="a' + PersonalCodigo + '" class="txt" value="' + Data[i].TotHEAdi + '" style="width:43px;" /></td>';
                html += '<td style="text-align:center;"><input type="text" id="d' + PersonalCodigo + '" class="txt" value="' + Data[i].TotHEDob + '" style="width:43px;" /></td>';
                html += '<td style="text-align:center;"><input type="text" id="f' + PersonalCodigo + '" class="txt" value="' + Data[i].Faltas + '" style="width:25px;" /></td>';
                html += '<td style="text-align:center;"><input type="text" id="t' + PersonalCodigo + '" class="txt" value="' + Data[i].MinTarde + '" style="width:35px;" /></td>';
                //html += '<td style="text-align:center;"><input type="text" id="dp' + PersonalCodigo + '" class="txt" value="' + Data[i].DiasPer + '" style="width:35px;" /></td>';
                html += '<td style="text-align:center;"><input type="text" id="per_desmed' + PersonalCodigo + '" class="txt" value="' + Data[i].DiasPer_DesMed + '" style="width:35px;" /></td>';
                html += '<td style="text-align:center;"><input type="text" id="per_perdia' + PersonalCodigo + '" class="txt" value="' + Data[i].DiasPer_PerDia + '" style="width:35px;" /></td>';
                html += '<td style="text-align:center;">' + Data[i].DiasPer_Vac + '</td>';
                html += '<td style="text-align:center;"><input type="text" id="hp' + PersonalCodigo + '" class="txt" value="' + Data[i].HorasPer + '" style="width:35px;" /></td>';
                html += '<td style="text-align:center;"><input type="text" id="ps' + PersonalCodigo + '" class="txt" value="' + Data[i].PERSINGOCE + '" style="width:35px;" /></td>';

                html += '<td style="text-align:center;"><input type="text" id="do' + PersonalCodigo + '" class="txt" value="' + Data[i].Dominical + '" style="width:35px;" /></td>';
                html += '<td style="text-align:center;"><input type="text" id="as' + PersonalCodigo + '" class="txt" value="' + Data[i].asist + '" style="width:35px;" /></td>';
                html += '<td style="text-align:center;"><input type="text" id="cp' + PersonalCodigo + '" class="txt" value="' + Data[i].comp + '" style="width:35px;" /></td>';

                html += '<td style="text-align:center;">' + Data[i].TotHESimpleFijos + '</td>';
                html += '<td style="text-align:center;">' + Data[i].TotHEAdiFijos + '</td>';
                html += '<td style="text-align:center;">' + Data[i].TotHEDobFijos + '</td>';
                html += '<td style="text-align:center;">' + Data[i].FaltasFijos + '</td>';
                html += '<td style="text-align:center;">' + Data[i].MinTardeFijos + '</td>';
                html += '<td>' + Data[i].Periodo + '</td>';
                html += '<td>' + Data[i].Area + '</td>';
                html += '<td>' + Data[i].CateAux + '</td>';
                html += '</tr>';

                $(html).appendTo('#tbodyNovedades');
            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: false
    });
};



function ActualizarConceptoPlanilla(Planilla_Id, Periodo_Id, Concepto_Id, Personal_Id, Valor) {

    var params = {
        Planilla_Id: Planilla_Id,
        Periodo_Id: Periodo_Id,
        Concepto_Id: Concepto_Id,
        Personal_Id: Personal_Id,
        Valor: Valor
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sPasarPlanilla.aspx/ActualizarConceptoPlanilla",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                var procbol = Proceso.split('#')[0];
                var mensaje = Proceso.split('#')[1];
                if (procbol == 'true') {
                    Correctos += 1;
                } else {
                    Errores += 1;
                }

            } else {
                Errores += 1;
            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: false
    });
};





function Get_Planilla_Find() {
    return $('#cboPlanilla').val();
};

function Get_Periodo_Find() {
    return $('#cboPeriodo').val();
};

function Get_Localidad_Find() {
    return $('#cboLocalidad').val();
};

function Get_CateAux_Find() {
    return $('#cboCatAux').val();
};

function Get_Categoria_Find() {
    return $('#cboCategoria').val();
};

function Menu_RecursosHumanos() {
    $('#nav').html('');

    /*---------AYUDA---------*/
    var acc_ayuda = '<li ><a href="#">RRHH</a>';
    acc_ayuda += '<ul class="subs">';
    acc_ayuda += '<li><a href="#">Procesos</a>';
    acc_ayuda += '<ul>';
    acc_ayuda += '<li><a href="sPasarPlanilla.aspx">Pasar Novedades a Planilla</a></li>';
    acc_ayuda += '<li><a href="../Justificacion/JustificacionRRHH.aspx">Permisos y Justificaciones</a></li>';
    acc_ayuda += '</ul>';
    acc_ayuda += '</li>';
    acc_ayuda += '</ul>';
    acc_ayuda += '</li>';
    $(acc_ayuda).appendTo("#nav");
    /*---------END AYUDA---------*/

    var acc_salir = '<li ><a href="../Justificacion/Acceso.aspx">SALIR</a>';
    acc_salir += '</li>';
    $(acc_salir).appendTo("#nav");
};

function Get_PeriodoCA_By_Planilla(Periodo_Id) {
    var params = {
        Periodo_Id: Periodo_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "../caReporteGeneral/cReporteGeneral.aspx/Get_PeriodoCA_By_Planilla",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            for (var i = 0; i <= lengthd; i++) {

                $("#txtFechaInicio").datepicker("setDate", formatFecha.dmy(Data[0].Date_Inicio.toDateFormat()));
                $("#txtFechaFinal").datepicker("setDate", formatFecha.dmy(Data[0].Date_Fin.toDateFormat()));


            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#divError').html(XmlHttpError.responseText);
   },
        async: false
     
    });

};

function CrearCuadroFechas() {
    $('#txtFechaInicio').datepicker({
        monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
		    'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
        monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun',
		        'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
        dayNames: ['Domingo', 'Lunes', 'Martes', 'Mi&eacute;rcoles', 'Jueves', 'Viernes', 'S&aacute;bado'],
        dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mi&eacute;', 'Juv', 'Vie', 'S&aacute;b'],
        dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'S&aacute;'],
        dateFormat: 'dd/mm/yy',
        isRTL: false

    });

    $('#txtFechaFinal').datepicker({
        monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
		    'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
        monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun',
		        'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
        dayNames: ['Domingo', 'Lunes', 'Martes', 'Mi&eacute;rcoles', 'Jueves', 'Viernes', 'S&aacute;bado'],
        dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mi&eacute;', 'Juv', 'Vie', 'S&aacute;b'],
        dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'S&aacute;'],
        dateFormat: 'dd/mm/yy',
        isRTL: false
    });
};

String.prototype.toDateFormat = function () {

    if (this) {
        var dte = eval("new " + this.replace(/\//g, '') + ";");

        dte.setMinutes(dte.getMinutes() - dte.getTimezoneOffset());
        //  dateFormat(dte, "yyyy-MM-dd HH:mm:ss");
        var ret = dateTransform(dte);
        //return dte;
        return ret;
    } else {
        return '';
    }
};

function dateTransform(fecha) {
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
};

String.prototype.padLeft = function (paddingChar, length) {

    var s = new String(this);

    if ((this.length < length) && (paddingChar.toString().length > 0)) {
        for (var i = 0; i < (length - this.length) ; i++)
            s = paddingChar.toString().charAt(0).concat(s);
    }

    return s;
};

var formatFecha = {
    ymd: function (fecha) {
        if (fecha.indexOf(' ') != -1) {
            var arr1 = fecha.split(' ');
            var arr = [];
            if (fecha.indexOf('/') != -1) {
                arr = arr1[0].split('/');
                return arr[2] + '/' + arr[1] + '/' + arr[0];
            } else if (fecha.indexOf('-') != -1) {
                arr = arr1[0].split('-');
                return arr[2] + '-' + arr[1] + '-' + arr[0];
            }

        } else {
            var arr = [];
            if (fecha.indexOf('/') != -1) {
                arr = arr1.split('/');
                return arr[2] + '/' + arr[1] + '/' + arr[0];
            } else if (fecha.indexOf('-') != -1) {
                arr = arr1.split('-');
                return arr[2] + '-' + arr[1] + '-' + arr[0];
            }
        }

    },
    dmy: function (fecha) {
        if (fecha.indexOf(' ') != -1) {
            var arr1 = fecha.split(' ');
            var arr = [];
            if (fecha.indexOf('/') != -1) {
                arr = arr1[0].split('/');
                return arr[0] + '/' + arr[1] + '/' + arr[2];
            } else if (fecha.indexOf('-') != -1) {
                arr = arr1[0].split('-');
                return arr[0] + '-' + arr[1] + '-' + arr[2];
            }

        } else {
            var arr = [];
            if (fecha.indexOf('/') != -1) {
                arr = arr1.split('/');
                return arr[0] + '/' + arr[1] + '/' + arr[2];
            } else if (fecha.indexOf('-') != -1) {
                arr = arr1.split('-');
                return arr[0] + '-' + arr[1] + '-' + arr[2];
            }
        }
    }

};


function Get_semana_List() {
    $.ajax({
        type: "POST",
        data: JSON.stringify(),
        dataType: "json",
        url: "sPasarPlanilla.aspx/ListaSemana",
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


//DATOS AGREGADOS


function pasaModal01() {
    var cant = $('#tbodyNovedades input:checkbox:checked').length;
    if (cant == 0) {
        alert('.::Error > No a seleccionado a ningun personal.');
        return false;
    }

    $("#dialog-form01").dialog({
        height: 520, width: 800, modal: true, autoOpen: true,
        appendTo: "form", title: "REPLICAR DATOS EN TABLA",
        show: { effect: "fade", duration: 800 },
        hide: { effect: "fold", duration: 800 }
    });
}

function closeModalDiv01() {
    $('#dialog-form01').dialog('close');

}

function Limpiardatos01() {
    $('#txthesimple').val('00:00');
    $('#txtheadi').val('00:00');
    $('#txthedoble').val('00:00');
     $('#txtfalta').val('0');
     $('#txttarde').val('0');
     $('#txtdesmedico').val('0');
      $('#txtpermpersonal').val('0');
    $('#txthoraspermiso').val('0.00');
   $('#txtdominical').val('0');
   $('#txtasistencia').val('0');
   $('#txtcompensa').val('0');


}

function replicardatos() {
   
    if (confirm('¿Esta seguro de continuar?')) {

        var cant = $('#tbodyNovedades input:checkbox:checked').length;
        if (cant == 0) {
            alert('.::Error > No a seleccionado a ningun personal.');
            return false;
        }

        $('#lblError').html(' ');
        Errores = 0;
        Correctos = 0;
        var mostr = true;
        $('#tbodyNovedades input:checkbox:checked').each(function () {
            var personal_id = this.id.substring(3);
            var hesimp = $('#txthesimple').val();
            var headi = $('#txtheadi').val();
            var hedob = $('#txthedoble').val();
            var hefalt = $('#txtfalta').val();
            var hetar = $('#txttarde').val();
            var per_desmed = $('#txtdesmedico').val();
            var per_perdia = $('#txtpermpersonal').val();
            var horaspermiso = $('#txthoraspermiso').val();
            var domingo = $('#txtdominical').val();
            var asist = $('#txtasistencia').val();
            var comp = $('#txtcompensa').val();



            if (!esNumero(hesimp)) {
                alert('.::Error > No es un numero valido.');
                $('#txthesimple').focus();
                $('#txthesimple').css('background-color', '#FFC5C5');
                mostr = false;
                return false;
            } else {
                hesimp = hesimp.replace(':', '.');
                mostr = true;
            }

            if (!esNumero(headi)) {
                alert('.::Error > No es un numero valido.');
                $('#txtheadi').focus();
                $('#txtheadi').css('background-color', '#FFC5C5');
                mostr = false;
                return false;
            } else {
                headi = headi.replace(':', '.');
                mostr = true;
            }

            if (!esNumero(hedob)) {
                alert('.::Error > No es un numero valido.');
                $('#txthedoble').focus();
                $('#txthedoble').css('background-color', '#FFC5C5');
                mostr = false;
                return false;
            } else {
                hedob = hedob.replace(':', '.');
                mostr = true;
            }

            if (!esNumero(hefalt)) {
                alert('.::Error > No es un numero valido.');
                $('#txtfalta').focus();
                $('#txtfalta').css('background-color', '#FFC5C5');
                mostr = false;
                return false;
            } else {
                hefalt = hefalt.replace(':', '.');
                mostr = true;
            }

            if (!esNumero(hetar)) {
                alert('.::Error > No es un numero valido.');
                $('#txttarde').focus();
                $('#txttarde').css('background-color', '#FFC5C5');
                mostr = false;
                return false;
            } else {
                hetar = hetar.replace(':', '.');
                mostr = true;
            }


            if (!esNumero(per_desmed)) {
                alert('.::Error > No es un numero valido.');
                $('#txtdesmedico').focus();
                $('#txtdesmedico').css('background-color', '#FFC5C5');
                mostr = false;
                return false;
            } else {
                per_desmed = per_desmed.replace(':', '.');
                mostr = true;
            }

            if (!esNumero(per_perdia)) {
                alert('.::Error > No es un numero valido.');
                $('#txtpermpersonal').focus();
                $('#txtpermpersonal').css('background-color', '#FFC5C5');
                mostr = false;
                return false;
            } else {
                per_perdia = per_perdia.replace(':', '.');
                mostr = true;
            }

            if (!esNumero(horaspermiso)) {
                alert('.::Error > No es un numero valido.');
                $('#txthoraspermiso').focus();
                $('#txthoraspermiso').css('background-color', '#FFC5C5');
                mostr = false;
                return false;
            } else {
                horaspermiso = horaspermiso.replace(':', '.');
                mostr = true;
            }

            if (!esNumero(domingo)) {
                alert('.::Error > No es un numero valido.');
                $('#txtdominical').focus();
                $('#txtdominical').css('background-color', '#FFC5C5');
                mostr = false;
                return false;
            } else {
                //domingo = domingo.replace(':', '.');
                mostr = true;
            }

            if (!esNumero(asist)) {
                alert('.::Error > No es un numero valido.');
                $('#txtasistencia').focus();
                $('#txtasistencia').css('background-color', '#FFC5C5');
                mostr = false;
                return false;
            } else {
                //asist = asist.replace(':', '.');
                mostr = true;
            }

            if (!esNumero(comp)) {
                alert('.::Error > No es un numero valido.');
                $('#txtcompensa').focus();
                $('#txtcompensa').css('background-color', '#FFC5C5');
                mostr = false;
                return false;
            } else {
                //comp = comp.replace('.', '.');
                mostr = true;
            }


            var b = '00.00'
            var c = '0.00';
            var d = '0';

            if (hesimp !== b) {
                $('#s' + personal_id).val($('#txthesimple').val());
            }
            if (headi !== b) {
                $('#a' + personal_id).val($('#txtheadi').val());
            }
            if (hedob !== b) {
                $('#d' + personal_id).val($('#txthedoble').val());
            }

            if (hefalt !== d) {
                $('#f' + personal_id).val($('#txtfalta').val());
            }
            if (hetar !== d) {
                $('#t' + personal_id).val($('#txttarde').val());
            }
            if (per_desmed !== d) {
                $('#per_desmed' + personal_id).val($('#txtdesmedico').val());
            }
            if (per_perdia !== d) {
                $('#per_perdia' + personal_id).val($('#txtpermpersonal').val());
            }

            if (horaspermiso !== c) {
                $('#hp' + personal_id).val($('#txthoraspermiso').val());
            }

            if (domingo !== d) {
                $('#do' + personal_id).val($('#txtdominical').val());
            }
            if (asist !== d) {
                $('#as' + personal_id).val($('#txtasistencia').val());
            }
            if (comp !== d) {
                $('#cp' + personal_id).val($('#txtcompensa').val());
            }
           

        });
        if (mostr) {
            alert('DATOS REPLICADOS EN LA TABLA CORRECTAMENTE');
        }


    }
    closeModalDiv01();
}




