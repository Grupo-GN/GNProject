
function Get_Planilla_List() {
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "cReporteGeneral.aspx/Get_Planilla_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboPlanilla').html('');
            for (var i = 0; i <= lengthd; i++) {
                if (NivelAcceso_Proc != "04") {
                    $('<option value="' + Data[i].Planilla_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboPlanilla');
                }
                else {
                    if (Data[i].Planilla_Id == Planilla_Id_Proc) {
                        $('<option value="' + Data[i].Planilla_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboPlanilla');
                        break;
                    }
                }
            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#divError').html(XmlHttpError.responseText);
   },
        async: false
    });

};

function Get_Periodo_Activo_By_CA(Planilla_Id) {
    var params = {
        Planilla_Id: Planilla_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "cReporteGeneral.aspx/Get_Periodo_Activo_By_CA",
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
       $('#divError').html(XmlHttpError.responseText);
   },
        async: false
    });

};

function Get_Localidad_List() {
    var Personal_Id = Personal_Proc;
    var params = {
        Personal_Id: Personal_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "cReporteGeneral.aspx/Get_Localidad_List_New",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboLocalidad').html('');
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Area_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboLocalidad');
            }
            if (NivelAcceso_Proc != "04") {
                $('<option value="">-TODOS-</option>').appendTo('#cboLocalidad');
                $('#cboLocalidad').val('');
            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#divError').html(XmlHttpError.responseText);
   },
        async: false
    });
};

function Get_Categoria_Auxiliar_List() {
    var Personal_Id = Personal_Proc;
    var params = {
        Personal_Id: Personal_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "cReporteGeneral.aspx/Get_Categoria_Auxiliar_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboCategoriaAux').html('');
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Categoria_Auxiliar_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboCategoriaAux');
            }
            if (NivelAcceso_Proc != "04") {
                $('<option value="">-TODOS-</option>').appendTo('#cboCategoriaAux');
                $('#cboCategoriaAux').val('');
            }
            
        },
        error:
   function (XmlHttpError, error, description) {
       $('#divError').html(XmlHttpError.responseText);
   },
        async: false
    });
};

function Get_Categoria_Auxiliar2_List(Cat_Aux) {
    var Personal_Id = Personal_Proc;
    var params = {
        Cat_Aux: Cat_Aux
        , Personal_Id: Personal_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "cReporteGeneral.aspx/Get_Categoria_Auxiliar2_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboCategoriaAux2').html('');
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Categoria_Auxiliar2_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboCategoriaAux2');
            }
            if (NivelAcceso_Proc != "04") {
                $('<option value="">-TODOS-</option>').appendTo('#cboCategoriaAux2');
                $('#cboCategoriaAux2').val('');
            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#divError').html(XmlHttpError.responseText);
   },
        async: false
    });

};

function Get_Categoria_List() {
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "cReporteGeneral.aspx/Get_Categoria_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboCategoria').html('');
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Categoria2_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboCategoria');
            }
            $('<option value="" selected>-TODOS-</option>').appendTo('#cboCategoria');
            if (NivelAcceso_Proc != "04") {
                $('#cboCategoria').val('');
            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#divError').html(XmlHttpError.responseText);
   },
        async: false
    });
};

function Get_PeriodoCA_By_Planilla(Periodo_Id) {
    var params = {
        Periodo_Id: Periodo_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "cReporteGeneral.aspx/Get_PeriodoCA_By_Planilla",
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

function Get_Personal_By_Filtros(Periodo_Id, Localidad_Id, CategoriaAux, CategoriaAux2, Categoria) {
    var Personal_Id = Personal_Proc;
    var params = {
        Periodo_Id: Periodo_Id,
        Localidad_Id: Localidad_Id,
        CategoriaAux: CategoriaAux,
        CategoriaAux2: CategoriaAux2,
        Categoria: Categoria
        , Personal_Id: Personal_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "cReporteGeneral.aspx/Get_Personal_By_Filtros",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboPersonal').html('');
            PersonalSelec = [];
            PersonalSelecbk=[];
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Personal_Id + '">' + Data[i].PersonalName + '</option>').appendTo('#cboPersonal');
                PersonalSelec.push(Data[i].Personal_Id);
                PersonalSelecbk.push(Data[i].Personal_Id);
            }
            if (NivelAcceso_Proc != "04") {
                $('<option value="">-TODOS-</option>').appendTo('#cboPersonal');
                $('#cboPersonal').val('');
            } else {
                $('<option value="--">-SELECCIONAR-</option>').appendTo('#cboPersonal');
                $('#cboPersonal').val('--');
            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#divError').html(XmlHttpError.responseText);
   },
        async: false
    });

};

function Get_ReporteGeneral_By_Personal(Planilla_Id, Periodo_Id, Localidad_Id, Personal_Id, FechaIni, FechaFin) {

    var params = {
        Planilla_Id: Planilla_Id,
        Periodo_Id: Periodo_Id,
        Localidad_Id: Localidad_Id,
        Personal_Id: Personal_Id,
        FechaIni: FechaIni,
        FechaFin: FechaFin
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "cReporteGeneral.aspx/Get_ReporteGeneral_By_Personal",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            var PersonalProc = '';

            var idBodyTabla = "tbodyReporte";
            if (NivelAcceso_Proc == "04") {
                idBodyTabla = "tbodyReportePersonal";
            }

            $('#' + idBodyTabla).html('');
            for (var i = 0; i <= lengthd; i++) {
                var minTarde = Data[i].MinTarde == '' ? '0' : Data[i].MinTarde;
                var html = '<tr>';
                if (Data[i].TRow == 'f') {
                    html += '<td>' + Data[i].Fecha + '</td>';
                    html += '<td>' + Data[i].Dia + '</td>';
                    html += '<td>' + Data[i].Localidad + '</td>';
                    html += '<td>' + Data[i].DNI + '</td>';
                    html += '<td>' + Data[i].Personal + '</td>';
                    html += '<td>' + Data[i].HIH.substring(0, 5) + '</td>';
                    html += '<td>' + Data[i].HFH.substring(0, 5) + '</td>';
                    html += '<td>' + Data[i].HIM.substring(0, 5) + '</td>';
                    html += '<td>' + Data[i].HSM.substring(0, 5) + '</td>';
                    if (NivelAcceso_Proc != "04") {
                        //                html += '<td>' + Data[i].TH + '</td>';
                        html += '<td>' + Data[i].HET.substring(0, 5) + '</td>';
                        html += '<td>' + Data[i].HES.substring(0, 5) + '</td>';
                        html += '<td>' + Data[i].HEA.substring(0, 5) + '</td>';
                        html += '<td>' + Data[i].HED.substring(0, 5) + '</td>';
                    }
                    html += '<td>' + Data[i].Falta + '</td>';
                    html += '<td>' + minTarde + ' Min.' + '</td>';
                    html += '<td>' + Data[i].CantDiasPer_DesMed + '</td>';
                    html += '<td>' + Data[i].CantDiasPer_PerDia + '</td>';
                    html += '<td>' + Data[i].CantDiasPer_Vac + '</td>';
                    html += '<td>' + Data[i].dominical + '</td>';
                    html += '<td>' + Data[i].asist + '</td>';
                    html += '<td>' + Data[i].comp + '</td>';
                    html += '<td>' + Data[i].Obser + '</td>';
                    html += '<td>' + Data[i].Upda + '</td>';
//                    html += '<td>' + Data[i].CateAux + '</td>';

                } else {

                    html += '<td style="font-size:12px;color:Red;font-weight: bold;" colspan="2">' + Data[i].Localidad + '</td>';
                    html += '<td style="font-size:12px;color:Red;font-weight: bold;" colspan="2">' + Data[i].DNI + '</td>';
                    html += '<td style="font-size:12px;color:Red;font-weight: bold;">' + Data[i].Personal + '</td>';
                    html += '<td></td>';
                    html += '<td></td>';
                    html += '<td></td>';
                    html += '<td></td>';
                    if (NivelAcceso_Proc != "04") {
                        //                html += '<td>' + Data[i].TH + '</td>';
                        html += '<td style="font-size:12px;color:Red;font-weight: bold;">' + Data[i].HET + '</td>';
                        html += '<td style="font-size:12px;color:Red;font-weight: bold;">' + Data[i].HES + '</td>';
                        html += '<td style="font-size:12px;color:Red;font-weight: bold;">' + Data[i].HEA + '</td>';
                        html += '<td style="font-size:12px;color:Red;font-weight: bold;">' + Data[i].HED + '</td>';
                    }
                    html += '<td style="font-size:12px;color:Red;font-weight: bold;">' + Data[i].Falta + '</td>';
                    html += '<td style="font-size:12px;color:Red;font-weight: bold;">' + Data[i].MinTarde + ' Min.' + '</td>';
                    html += '<td style="font-size:12px;color:Red;font-weight: bold;">' + Data[i].CantDiasPer_DesMed + ' Día(s)</td>';
                    html += '<td style="font-size:12px;color:Red;font-weight: bold;">' + Data[i].CantDiasPer_PerDia + ' Día(s)</td>';
                    html += '<td style="font-size:12px;color:Red;font-weight: bold;">' + Data[i].CantDiasPer_Vac + ' Día(s)</td>';
                    html += '<td></td>';
                    html += '<td></td>';
//                    html += '<td></td>';

                }
                html += '</tr>';


                $(html).appendTo('#' + idBodyTabla);
            }

        },
        error:
   function (XmlHttpError, error, description) {
       $('#divError').html(XmlHttpError.responseText);
   },
        async: false
    });

    Change_Estilos();

};

/*============================================================*/
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

function Get_Planilla_Find() {
    return $('#cboPlanilla').val();
};
function Get_Periodo_Find() {
    return $('#cboPeriodo').val();
};
function Get_Localidad_Find() {
    return $('#cboLocalidad').val();
};
function Get_CategoriaAux_Find() {
    return $('#cboCategoriaAux').val();
};

function Get_CategoriaAux2_Find() {
    return $('#cboCategoriaAux2').val();
};
function Get_Categoria_Find() {
    return $('#cboCategoria').val();
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
        for (var i = 0; i < (length - this.length); i++)
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

//STYLOS
function Change_Estilos() {
    var idTabla = "tablReporte";
    if (NivelAcceso_Proc == "04") {
        idTabla = "tblReportePersonal";
    }

    $('#' + idTabla).css({
        'width': '100%'
    , 'border-collapse': 'collapse'
    , 'border': '1px solid #2C6B8D'
    , 'max-width': '100%'
    });

    $('#' + idTabla + ' thead tr th').each(function (index) {
        $(this).css({
            'background-color': '#2C6B8D'
            , 'height': '28px'
            , 'font-family': 'AENOR Fontana ND'
            , 'text-transform:': 'uppercase'
            , 'color': '#FFFFFF'
            , 'font-size': '1em'
            , 'font-weight': 'bold'
	        , 'padding': '0px 7px'
	        , 'margin': '20px 0px 0px'
	        , 'text-align': ' left'
	        , 'text-align': 'center'
        });
    });

};
