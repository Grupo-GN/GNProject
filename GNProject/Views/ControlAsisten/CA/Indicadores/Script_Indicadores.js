/// <reference path="../caReporteGeneral/cReporteGeneral.aspx" />

function Get_Planilla_List() {
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "../caReporteGeneral/cReporteGeneral.aspx/Get_Planilla_List",
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


function Get_Planilla_List1() {
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "../caReporteGeneral/cReporteGeneral.aspx/Get_Planilla_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
         
            $('#cboPlanilla1').html('');
            $('#cboPlanilla2').html('');
            for (var i = 0; i <= lengthd; i++) {
                if (NivelAcceso_Proc != "04") {
                   
                    $('<option value="' + Data[i].Planilla_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboPlanilla1');
                    $('<option value="' + Data[i].Planilla_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboPlanilla2');
                }
                else {
                    if (Data[i].Planilla_Id == Planilla_Id_Proc) {
                  
                        $('<option value="' + Data[i].Planilla_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboPlanilla1');
                        $('<option value="' + Data[i].Planilla_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboPlanilla2');
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
        url: "../caReporteGeneral/cReporteGeneral.aspx/Get_Periodo_Activo_By_CA",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboPeriodo').html('');
            $('#cboPeriodo1').html('');
            $('#cboPeriodo2').html('');
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Periodo_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboPeriodo');
                $('<option value="' + Data[i].Periodo_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboPeriodo1');
                $('<option value="' + Data[i].Periodo_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboPeriodo2');
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
        url: "../caReporteGeneral/cReporteGeneral.aspx/Get_Localidad_List_New",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboLocalidad').html('');
            $('#cboLocalidad1').html('');
            $('#cboLocalidad2').html('');
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Area_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboLocalidad');
                $('<option value="' + Data[i].Area_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboLocalidad1');
                $('<option value="' + Data[i].Area_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboLocalidad2');
            }
            if (NivelAcceso_Proc != "04") {
                $('<option value="">-TODOS-</option>').appendTo('#cboLocalidad');
                $('#cboLocalidad').val('');

                $('<option value="">-TODOS-</option>').appendTo('#cboLocalidad1');
                $('#cboLocalidad1').val('');

                $('<option value="">-TODOS-</option>').appendTo('#cboLocalidad2');
                $('#cboLocalidad2').val('');

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
        url: "../caReporteGeneral/cReporteGeneral.aspx/Get_Categoria_Auxiliar_List",
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
        url: "../caReporteGeneral/cReporteGeneral.aspx/Get_Categoria_Auxiliar2_List",
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
        url: "../caReporteGeneral/cReporteGeneral.aspx/Get_Categoria_List",
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

function Get_PeriodoCA_By_Planilla1(Periodo_Id) {
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
                $("#txtFechaInicio1").datepicker("setDate", formatFecha.dmy(Data[0].Date_Inicio.toDateFormat()));
                $("#txtFechaFinal1").datepicker("setDate", formatFecha.dmy(Data[0].Date_Fin.toDateFormat()));

            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#divError').html(XmlHttpError.responseText);
   },
        async: false
    });

};

function Get_PeriodoCA_By_Planilla2(Periodo_Id) {
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
                $("#txtFechaInicio2").datepicker("setDate", formatFecha.dmy(Data[0].Date_Inicio.toDateFormat()));
                $("#txtFechaFinal2").datepicker("setDate", formatFecha.dmy(Data[0].Date_Fin.toDateFormat()));

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
        url: "../caReporteGeneral/cReporteGeneral.aspx/Get_Personal_By_Filtros",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboPersonal').html('');
            PersonalSelec = [];
            PersonalSelecbk = [];
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

function Get_Planilla_Find() {
    return $('#cboPlanilla').val();
};
function Get_Periodo_Find() {
    return $('#cboPeriodo').val();
};
function Get_Localidad_Find() {
    return $('#cboLocalidad').val();
};
//-----------------------------
function Get_Planilla_Find1() {
    return $('#cboPlanilla1').val();
};
function Get_Periodo_Find1() {
    return $('#cboPeriodo1').val();
};
function Get_Localidad_Find1() {
    return $('#cboLocalidad1').val();
};
function Get_Planilla_Find2() {
    return $('#cboPlanilla2').val();
};
function Get_Periodo_Find2() {
    return $('#cboPeriodo2').val();
};
function Get_Localidad_Find2() {
    return $('#cboLocalidad2').val();
};
//----------------------------------
function Get_CategoriaAux_Find() {
    return $('#cboCategoriaAux').val();
};

function Get_CategoriaAux2_Find() {
    return $('#cboCategoriaAux2').val();
};
function Get_Categoria_Find() {
    return $('#cboCategoria').val();
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

    $('#txtFechaInicio1').datepicker({
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

    $('#txtFechaFinal1').datepicker({
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
    $('#txtFechaInicio2').datepicker({
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

    $('#txtFechaFinal2').datepicker({
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

 


function showGraph(Personal_Id, Fecha_Inicio, Fecha_Fin, Flat, planilla_id) {
    var selectedText = $("#cboPersonal option:selected").html();
    var params = {
        Personal_Id: Personal_Id,
        Fecha_Inicio: Fecha_Inicio,
        Fecha_Fin: Fecha_Fin,
        Flat: Flat,
        planilla_id: planilla_id
        
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "IndicadoresGen.aspx/Lista_General",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            
            var name = [];
            var marks = [];
            var titulo = '';
           
            for (var i = 0; i <= lengthd; i++) {
                name.push('D'+Data[i].dia);
                marks.push(Data[i].cantidad);
            }

            if (Flat == 'F') {
                titulo = 'FALTAS';
                var chartdatafaltas = {
                    labels: name,
                    datasets: [
                        {
                            label: 'INDICADORES DE ' + titulo + ' X TRABAJADOR ' + selectedText,
                            backgroundColor: '#49e2ff',
                            backgroundColor: ["#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"],
                            borderColor: '#46d5f1',
                            hoverBackgroundColor: '#CCCCCC',
                            hoverBorderColor: '#666666',
                            data: marks
                        }
                    ]
                };
            }
            if (Flat == 'T') {
                titulo = 'TARDANZAS';
                var chartdatatardanzas = {
                    labels: name,
                    datasets: [
                        {
                            label: 'INDICADORES DE ' + titulo + ' X TRABAJADOR ' + selectedText,
                            //backgroundColor: '#F3631A',
                            backgroundColor: ["#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"],
                            borderColor: '#F3861A',
                            hoverBackgroundColor: '#CCCCCC',
                            hoverBorderColor: '#666666',
                            data: marks
                        }
                    ]
                };
            }

            if (Flat == 'S') {
                titulo = 'SIN MARCAS';
                var chartdatasm = {
                    labels: name,
                    datasets: [
                        {
                            label: 'INDICADORES DE ' + titulo + ' X TRABAJADOR ' + selectedText,
                            //backgroundColor: '#31F31A',
                            backgroundColor: ["#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"],
                            borderColor: '#40D12E',
                            hoverBackgroundColor: '#CCCCCC',
                            hoverBorderColor: '#666666',
                            data: marks
                        }
                    ]
                };
            }
            if (Flat == 'A') {
                titulo = 'ASISTENCIAS';
                var chartdataasis = {
                    labels: name,
                    datasets: [
                        {
                            label: 'INDICADORES DE ' + titulo + ' X TRABAJADOR ' + selectedText,
                            //backgroundColor: '#224EF2',
                            backgroundColor: ["#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"],
                            borderColor: '#6782E6',
                            hoverBackgroundColor: '#CCCCCC',
                            hoverBorderColor: '#666666',
                            data: marks
                        }
                    ]
                };
            }

            if (Flat == 'H') {
                titulo = 'Horas Extras';
                var chartdataasis = {
                    labels: name,
                    datasets: [
                        {
                            label: 'INDICADORES DE ' + titulo + ' X TRABAJADOR ' + selectedText,
                            //backgroundColor: '#224EF2',
                            backgroundColor: ["#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"],
                            borderColor: '#6782E6',
                            hoverBackgroundColor: '#CCCCCC',
                            hoverBorderColor: '#666666',
                            data: marks
                        }
                    ]
                };
            }

            if (Flat == 'C') {
                titulo = 'Compensaciones';
                var chartdataasis = {
                    labels: name,
                    datasets: [
                        {
                            label: 'INDICADORES DE ' + titulo + ' X TRABAJADOR ' + selectedText,
                            //backgroundColor: '#224EF2',
                            backgroundColor: ["#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"],
                            borderColor: '#6782E6',
                            hoverBackgroundColor: '#CCCCCC',
                            hoverBorderColor: '#666666',
                            data: marks
                        }
                    ]
                };
            }
            if (Flat == 'P') {
                titulo = 'Permisos';
                var chartdataasis = {
                    labels: name,
                    datasets: [
                        {
                            label: 'INDICADORES DE ' + titulo + ' X TRABAJADOR ' + selectedText,
                            //backgroundColor: '#224EF2',
                            backgroundColor: ["#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"],
                            borderColor: '#6782E6',
                            hoverBackgroundColor: '#CCCCCC',
                            hoverBorderColor: '#666666',
                            data: marks
                        }
                    ]
                };
            }

            if (Flat=='F') {
                var graphTarget = $("#graphCanvas");

                var barGraph = new Chart(graphTarget, {
                    type: 'bar',
                    data: chartdatafaltas
                });
            }
            if (Flat=='T') {
                var graphTarget = $("#graphCanvas1");

                var barGraph = new Chart(graphTarget, {
                    type: 'bar',
                    data: chartdatatardanzas
                });
            }
            if (Flat == 'S') {
                var graphTarget = $("#graphCanvas2");

                var barGraph = new Chart(graphTarget, {
                    type: 'bar',
                    data: chartdatasm
                });
            }
            if (Flat == 'A') {
                var graphTarget = $("#graphCanvas3");

                var barGraph = new Chart(graphTarget, {
                    type: 'bar',
                    data: chartdataasis
                });
            }
            
            if (Flat == 'H') {
                var graphTarget = $("#graphCanvas01");

                var barGraph = new Chart(graphTarget, {
                    type: 'bar',
                    data: chartdataasis
                });
            }

            if (Flat == 'C') {
                var graphTarget = $("#graphCanvas02");

                var barGraph = new Chart(graphTarget, {
                    type: 'bar',
                    data: chartdataasis
                });
            }
            if (Flat == 'P') {
                var graphTarget = $("#graphCanvas03");

                var barGraph = new Chart(graphTarget, {
                    type: 'bar',
                    data: chartdataasis
                });
            }
            
        },
        error:
   function (XmlHttpError, error, description) {
       $('#divError').html(XmlHttpError.responseText);
   },
        async: false
    });

};


function showGraphLocalidad(Periodo_id,Personal_Id, Fecha_Inicio, Fecha_Fin, Flat) {
    var selectedText = ''; //$("#cboPersonal option:selected").html();
    var params = {
        Periodo_id:Periodo_id,
        Personal_Id: Personal_Id,
        Fecha_Inicio: Fecha_Inicio,
        Fecha_Fin: Fecha_Fin,
        Flat: Flat
        

    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "IndicadoresGen.aspx/Lista_Localidad",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;

            var name = [];
            var marks = [];
            var titulo = '';

            for (var i = 0; i <= lengthd; i++) {
                name.push(Data[i].Localidad);
                marks.push(Data[i].cantidad);
            }

            if (Flat == 'F') {
                titulo = 'FALTAS';
                var chartdatafaltas = {
                    labels: name,
                    datasets: [
                        {
                            label: 'INDICADORES DE ' + titulo + ' X LOCALIDAD ' ,
                           
                            backgroundColor: ["#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"],
                            borderColor: '#46d5f1',
                            hoverBackgroundColor: '#CCCCCC',
                            hoverBorderColor: '#666666',
                            data: marks
                        }
                    ]
                };
            }
            if (Flat == 'T') {
                titulo = 'TARDANZAS';
                var chartdatatardanzas = {
                    labels: name,
                    datasets: [
                        {
                            label: 'INDICADORES DE ' + titulo + ' X LOCALIDAD ',
                            
                            backgroundColor: ["#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"],
                            borderColor: '#F3861A',
                            hoverBackgroundColor: '#CCCCCC',
                            hoverBorderColor: '#666666',
                            data: marks
                        }
                    ]
                };
            }

            if (Flat == 'S') {
                titulo = 'SIN MARCAS';
                var chartdatasm = {
                    labels: name,
                    datasets: [
                        {
                            label: 'INDICADORES DE ' + titulo + ' X LOCALIDAD ',
                          
                            backgroundColor: ["#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"],
                            borderColor: '#40D12E',
                            hoverBackgroundColor: '#CCCCCC',
                            hoverBorderColor: '#666666',
                            data: marks
                        }
                    ]
                };
            }
            if (Flat == 'A') {
                titulo = 'ASISTENCIAS';
                var chartdataasis = {
                    labels: name,
                    datasets: [
                        {
                            label: 'INDICADORES DE ' + titulo + ' X LOCALIDAD ',
                            
                            backgroundColor: ["#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"],
                            borderColor: '#6782E6',
                            hoverBackgroundColor: '#CCCCCC',
                            hoverBorderColor: '#666666',
                            data: marks
                        }
                    ]
                };
            }

            if (Flat == 'H') {
                titulo = 'HORAS EXTRAS';
                var chartdataasis = {
                    labels: name,
                    datasets: [
                        {
                            label: 'INDICADORES DE ' + titulo + ' X LOCALIDAD ',
                            backgroundColor: ["#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"],
                            borderColor: '#6782E6',
                            hoverBackgroundColor: '#CCCCCC',
                            hoverBorderColor: '#666666',
                            data: marks
                        }
                    ]
                };
            }

            if (Flat == 'C') {
                titulo = 'COMPENSACIONES';
                var chartdataasis = {
                    labels: name,
                    datasets: [
                        {
                            label: 'INDICADORES DE ' + titulo + ' X LOCALIDAD ',

                            backgroundColor: ["#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"],
                            borderColor: '#6782E6',
                            hoverBackgroundColor: '#CCCCCC',
                            hoverBorderColor: '#666666',
                            data: marks
                        }
                    ]
                };
            }

            if (Flat == 'P') {
                titulo = 'PERMISOS';
                var chartdataasis = {
                    labels: name,
                    datasets: [
                        {
                            label: 'INDICADORES DE ' + titulo + ' X LOCALIDAD ',

                            backgroundColor: ["#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"],
                            borderColor: '#6782E6',
                            hoverBackgroundColor: '#CCCCCC',
                            hoverBorderColor: '#666666',
                            data: marks
                        }
                    ]
                };
            }

            var options = {
                title: {
                    display: true,
                    text: 'INDICADORES DE ' + titulo + ' X LOCALIDAD ',
                    position: 'top'
                },
                rotation: -0.7 * Math.PI
            };

            if (Flat == 'F') {
                var graphTarget = $("#graphCanvas4");

                var barGraph = new Chart(graphTarget, {
                    type: 'doughnut',
                    data: chartdatafaltas,
                    options: options

                });
            }
            if (Flat == 'T') {
                var graphTarget = $("#graphCanvas5");

                var barGraph = new Chart(graphTarget, {
                    type: 'doughnut',
                    data: chartdatatardanzas,
                    options: options
                });
            }
            if (Flat == 'S') {
                var graphTarget = $("#graphCanvas6");

                var barGraph = new Chart(graphTarget, {
                    type: 'doughnut',
                    data: chartdatasm,
                    options: options
                });
            }
            if (Flat == 'A') {
                var graphTarget = $("#graphCanvas7");

                var barGraph = new Chart(graphTarget, {
                    type: 'doughnut',
                    data: chartdataasis,
                    options: options
                });
            }

            if (Flat == 'H') {
                var graphTarget = $("#graphCanvas04");

                var barGraph = new Chart(graphTarget, {
                    type: 'doughnut',
                    data: chartdataasis,
                    options: options
                });
            }

            if (Flat == 'C') {
                var graphTarget = $("#graphCanvas05");

                var barGraph = new Chart(graphTarget, {
                    type: 'doughnut',
                    data: chartdataasis,
                    options: options
                });
            }

            if (Flat == 'P') {
                var graphTarget = $("#graphCanvas06");

                var barGraph = new Chart(graphTarget, {
                    type: 'doughnut',
                    data: chartdataasis,
                    options: options
                });
            }


        },
        error:
   function (XmlHttpError, error, description) {
       $('#divError').html(XmlHttpError.responseText);
   },
        async: false
    });

};


function showGraphArea(Periodo_id, Personal_Id, Fecha_Inicio, Fecha_Fin, Flat) {
    var selectedText = ''; //$("#cboPersonal option:selected").html();
    var params = {
        Periodo_id: Periodo_id,
        Personal_Id: Personal_Id,
        Fecha_Inicio: Fecha_Inicio,
        Fecha_Fin: Fecha_Fin,
        Flat: Flat


    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "IndicadoresGen.aspx/Lista_Area",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;

            var name = [];
            var marks = [];
            var titulo = '';

            for (var i = 0; i <= lengthd; i++) {
                name.push(Data[i].Area);
                marks.push(Data[i].cantidad);
            }

            if (Flat == 'F') {
                titulo = 'FALTAS';
                var chartdatafaltas = {
                    labels: name,
                    datasets: [
                        {
                            label: 'INDICADORES DE ' + titulo + ' X LOCALIDAD ',

                            backgroundColor: ["#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#49e2ff", "#8e5ea2", "#3cba9f",
                                "#e8c3b9", "#c45850", "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#49e2ff", "#8e5ea2",
                                "#3cba9f", "#e8c3b9", "#c45850", "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#49e2ff",
                                "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"],
                            borderColor: '#46d5f1',
                            hoverBackgroundColor: '#CCCCCC',
                            hoverBorderColor: '#666666',
                            data: marks
                        }
                    ]
                };
            }
            if (Flat == 'T') {
                titulo = 'TARDANZAS';
                var chartdatatardanzas = {
                    labels: name,
                    datasets: [
                        {
                            label: 'INDICADORES DE ' + titulo + ' X LOCALIDAD ',

                            backgroundColor: ["#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850","#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850","#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850","#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                           "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#F3631A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"],
                            borderColor: '#F3861A',
                            hoverBackgroundColor: '#CCCCCC',
                            hoverBorderColor: '#666666',
                            data: marks
                        }
                    ]
                };
            }

            if (Flat == 'S') {
                titulo = 'SIN MARCAS';
                var chartdatasm = {
                    labels: name,
                    datasets: [
                        {
                            label: 'INDICADORES DE ' + titulo + ' X LOCALIDAD ',

                            backgroundColor: ["#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"
                            , "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"
                            , "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"
                            , "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"
                            , "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"
                            , "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"
                            , "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#31F31A", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"],
                            borderColor: '#40D12E',
                            hoverBackgroundColor: '#CCCCCC',
                            hoverBorderColor: '#666666',
                            data: marks
                        }
                    ]
                };
            }
            if (Flat == 'A') {
                titulo = 'ASISTENCIAS';
                var chartdataasis = {
                    labels: name,
                    datasets: [
                        {
                            label: 'INDICADORES DE ' + titulo + ' X LOCALIDAD ',

                            backgroundColor: ["#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"
                            , "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"
                            , "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"
                            , "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"
                            , "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"
                            , "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"
                            , "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"],
                            borderColor: '#6782E6',
                            hoverBackgroundColor: '#CCCCCC',
                            hoverBorderColor: '#666666',
                            data: marks
                        }
                    ]
                };
            }


            if (Flat == 'H') {
                titulo = 'HORAS EXTRAS';
                var chartdatafaltas = {
                    labels: name,
                    datasets: [
                        {
                            label: 'INDICADORES DE ' + titulo + ' X LOCALIDAD ',

                            backgroundColor: ["#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#49e2ff", "#8e5ea2", "#3cba9f",
                                "#e8c3b9", "#c45850", "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#49e2ff", "#8e5ea2",
                                "#3cba9f", "#e8c3b9", "#c45850", "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#49e2ff",
                                "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850",
                            "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#49e2ff", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"],
                            borderColor: '#46d5f1',
                            hoverBackgroundColor: '#CCCCCC',
                            hoverBorderColor: '#666666',
                            data: marks
                        }
                    ]
                };
            }


            if (Flat == 'C') {
                titulo = 'COMPENSACIONES';
                var chartdataasis = {
                    labels: name,
                    datasets: [
                        {
                            label: 'INDICADORES DE ' + titulo + ' X LOCALIDAD ',

                            backgroundColor: ["#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"
                            , "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"
                            , "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"
                            , "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"
                            , "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"
                            , "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"
                            , "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"],
                            borderColor: '#6782E6',
                            hoverBackgroundColor: '#CCCCCC',
                            hoverBorderColor: '#666666',
                            data: marks
                        }
                    ]
                };
            }



            if (Flat == 'P') {
                titulo = 'PERMISOS';
                var chartdataasis = {
                    labels: name,
                    datasets: [
                        {
                            label: 'INDICADORES DE ' + titulo + ' X LOCALIDAD ',

                            backgroundColor: ["#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"
                            , "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"
                            , "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"
                            , "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"
                            , "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"
                            , "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"
                            , "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#224EF2", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"],
                            borderColor: '#6782E6',
                            hoverBackgroundColor: '#CCCCCC',
                            hoverBorderColor: '#666666',
                            data: marks
                        }
                    ]
                };
            }



            var options = {
                title: {
                    display: true,
                    text: 'INDICADORES DE ' + titulo + ' X ÁREA ',
                    position: 'top'
                },
                rotation: -0.7 * Math.PI
            };

            if (Flat == 'F') {
                var graphTarget = $("#graphCanvas8");

                var barGraph = new Chart(graphTarget, {
                    type: 'pie',
                    data: chartdatafaltas,
                    options: options

                });
            }
            if (Flat == 'T') {
                var graphTarget = $("#graphCanvas9");

                var barGraph = new Chart(graphTarget, {
                    type: 'pie',
                    data: chartdatatardanzas,
                    options: options
                });
            }
            if (Flat == 'S') {
                var graphTarget = $("#graphCanvas10");

                var barGraph = new Chart(graphTarget, {
                    type: 'pie',
                    data: chartdatasm,
                    options: options
                });
            }
            if (Flat == 'A') {
                var graphTarget = $("#graphCanvas11");

                var barGraph = new Chart(graphTarget, {
                    type: 'pie',
                    data: chartdataasis,
                    options: options
                });
            }

            if (Flat == 'H') {
                var graphTarget = $("#graphCanvas08");

                var barGraph = new Chart(graphTarget, {
                    type: 'pie',
                    data: chartdatafaltas,
                    options: options
                });
            }

            if (Flat == 'C') {
                var graphTarget = $("#graphCanvas09");

                var barGraph = new Chart(graphTarget, {
                    type: 'pie',
                    data: chartdataasis,
                    options: options
                });
            }


            if (Flat == 'P') {
                var graphTarget = $("#graphCanvas010");

                var barGraph = new Chart(graphTarget, {
                    type: 'pie',
                    data: chartdataasis,
                    options: options
                });
            }




        },
        error:
   function (XmlHttpError, error, description) {
       $('#divError').html(XmlHttpError.responseText);
   },
        async: false
    });

};




