function GenerarReportedeIndicesMultiples() {
    var Dime = [];
    var Sum = [];
    var FechaIni = $('#txtFechaInicio').val();
    var FechaFin = $('#txtFechaFinal').val();
    $('#lbDimenProcesar li').each(function () {
        Dime.push(this.id);
    });

    $('#lbSumProcesar li').each(function () {
        Sum.push(this.id);
    });

    if (Dime.length == 0) {
        alert('No a seleccionado ninguna dimensión');
        return false;
    }
    if (Sum.length == 0) {
        alert('No a seleccionado ningun campo a calcular.');
        return false;
    }

    if (!FechaIni) {
        alert('Fecha Inicio no definida.');
        return false;
    }
    if (!FechaFin) {
        alert('Fecha Final no definida.');
        return false;
    }


    Get_IndicesMultiplesControlAsistencia(Dime, Sum, formatFecha.ymd(FechaIni), formatFecha.ymd(FechaFin));
}



function Get_IndicesMultiplesControlAsistencia(Dimensiones, Sumas, FechaInicio, FechaFinal) {

    var ReportePointChart = [];


    var params = {
        Dimensiones: Dimensiones,
        Sumas: Sumas,
        FechaInicio: FechaInicio,
        FechaFinal: FechaFinal
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "cIndicadoresMultiples.aspx/Get_IndicesMultiplesControlAsistencia",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            var lencol = 0;
            $('#theadReport').html('');
            $('#tbodyReport').html('');
            if (lengthd >= 0) {
                lencol = Object.keys(Data[0]).length - 1;
            }

            if (lengthd >= 0) {

                var htmlhed = '<tr>';
                for (var ch = 0; ch <= lencol; ch++) {
                    htmlhed += '<th>' + Data[0][ch] + '</th>';
                    var indexsum = ch - Dimensiones.length;
                    Sumas[indexsum] = Data[0][ch];

                }
                htmlhed += '</tr>';
                $(htmlhed).appendTo('#theadReport');


            }
            for (var i = 1; i <= lengthd; i++) {
                var html = '<tr>';
                for (var cb = 0; cb <= lencol; cb++) {
                    html += '<td>' + Data[i][cb] + '</td>';
                 
                    var colSP = cb - Dimensiones.length;
                    if (cb >= Dimensiones.length) {
                        var point = Sumas[colSP] + '#' + Data[i][cb];
                        ReportePointChart.AddPoints(Data[i][0], point);
                    }
                }
                html += '</tr>';

                $(html).appendTo('#tbodyReport');

            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#divError').html(XmlHttpError.responseText);
   },
        async: false
    });

    var dataPoints = [];
    for (var p = 0; p <= ReportePointChart.length - 1; p++) {
        
        var IndexSL = -1;
        for (var e = 0; e <= dataPoints.length - 1; e++) {
           
            if (dataPoints[e].name == ReportePointChart[p].TSuma) {               
                        IndexSL = e;
                
            }
        }

        if (IndexSL == -1) {
            dataPoints.push({
                type: "stackedBar100",
                showInLegend: "true",
                name: ReportePointChart[p].TSuma,
                dataPoints: [{ y: parseFloat(ReportePointChart[p].Point), label: ReportePointChart[p].DName }]
            });
           
        } else {
            var pointExite = [];
            pointExite = dataPoints[IndexSL].dataPoints;
            pointExite.push({ y: parseFloat(ReportePointChart[p].Point), label: ReportePointChart[p].DName });  
            dataPoints[IndexSL].dataPoints = pointExite;
            
        }


    }
    

    var chart = new CanvasJS.Chart("chartContainer",
    {
        title: {
            text: "Indices Multiples"
        },
         
        data: dataPoints
    });
    

    chart.render();










};


/* AGREGAR DATOS AL ARRAY */

Array.prototype.AddPoints = function (Dimen, Suma) {

    var IndexSpli = Suma.indexOf('#');
    if (IndexSpli != -1) {

        var TSuma = Suma.split('#')[0];
        var Point = Suma.split('#')[1];
        if (Point.indexOf(':') != -1) {
            Point = Point.replace(':', '.');
        }
        if (!isNaN(Point)) {

            var IndexDimension = -1;

            for (var i = 0; i <= this.length - 1; i++) {
                if (this[i].DName == Dimen && this[i].TSuma == TSuma) {

                    IndexDimension = i;
                }
            }

            if (IndexDimension == -1) {
                this.push({ DName: Dimen, TSuma: TSuma, Point: Point });               
            } else {

                var EnterosAnt = 0;
                var DecimalesAnt = 0;

                var EnterosActual = 0;
                var DecimalesActual = 0;

                var SumarPuntos = this[IndexDimension].Point;

                if (SumarPuntos.toString().indexOf('.') != -1) {
                    EnterosAnt = parseInt(SumarPuntos.split('.')[0]);
                    DecimalesAnt = parseInt(SumarPuntos.split('.')[1]);
                } else {
                    EnterosAnt = parseInt(SumarPuntos);
                    DecimalesAnt = 0;
                }


                if (Point.toString().indexOf('.') != -1) {
                    EnterosActual = parseInt(Point.toString().split('.')[0]);
                    DecimalesActual = parseInt(Point.toString().split('.')[1]);
                } else {
                    EnterosActual = parseInt(Point);
                    DecimalesActual = 0;
                }


                var EnterosPoint = 0;
                var DecimalesPoint = 0;


                EnterosPoint = parseInt(EnterosAnt) + parseInt(EnterosActual);
                DecimalesPoint = parseInt(DecimalesAnt) + parseInt(DecimalesActual);
                
                if (DecimalesPoint >= 60) {
                    EnterosPoint += Math.round((DecimalesPoint / 60));
                    DecimalesPoint = (DecimalesPoint % 60);
                }

               if (Point.indexOf('.') != -1) {
                    this[IndexDimension].Point = EnterosPoint + '.' + DecimalesPoint;

                } else {
                    this[IndexDimension].Point = EnterosPoint;
                }
              
            }
        }

    }
};




/*-------------*/


function Get_Dimensiones() {

    $.ajax({
        type: "POST",
        dataType: "json",
        url: "cIndicadoresMultiples.aspx/Get_Dimensiones",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#lbDimen').html('');
            for (var i = 0; i <= lengthd; i++) {
                $('<li id="' + Data[i].Dimen_Id + '">' + Data[i].Descripcion + '</li>').appendTo('#lbDimen');
            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#divError').html(XmlHttpError.responseText);
   },
        async: false
    });

};

function Get_SumaCamposCA() {

    $.ajax({
        type: "POST",
        dataType: "json",
        url: "cIndicadoresMultiples.aspx/Get_SumaCamposCA",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#lbSum').html('');
            for (var i = 0; i <= lengthd; i++) {
                $('<li id="' + Data[i].Sum_Id + '">' + Data[i].Descripcion + '</li>').appendTo('#lbSum');
            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#divError').html(XmlHttpError.responseText);
   },
        async: false
    });

};




function CargarDimensionesFiltros() {
    $('#lbFiltrosDim').html('');
    $('#tbodyFiltrosDim').html('');
    for (var i = 0; i <= DimenSelec.length - 1; i++) {
        $('<li><input type="checkbox" id="' + DimenSelec[i].cod + '" /><label>' + DimenSelec[i].Desc + '</label></li>').appendTo('#lbFiltrosDim');
    }
};



function CargarFiltro_By_Dimension(Dimen_Id) {
    var params = {};
    var html = '';
    //PLANILLA
    if (Dimen_Id == 'D1') {
        html = '';
        html += '<tr id="trD1">';
        html += '<td><label class="miLabel">Planilla : </label><select class="cbo" id="cboPlanilla"></select></td>';
        html += '<tr>';
        html += '</tr>';
        $(html).appendTo('#tbodyFiltrosDim');

        $.ajax({
        type: "POST",
        dataType: "json",
        url: "cIndicadoresMultiples.aspx/Get_Planilla_List",
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
           $('#divError').html(XmlHttpError.responseText);
       },
            async: false
       });

    }
    //ANIOS
    if (Dimen_Id == 'D2') {
        html = '';
        html += '<tr id="trD2">';
        html += '<td><label class="miLabel">Año : </label><select class="cbo" id="cboAnio"></select></td>';
        html += '<tr>';
        html += '</tr>';
        $(html).appendTo('#tbodyFiltrosDim');

        $.ajax({
            type: "POST",
            dataType: "json",
            url: "cIndicadoresMultiples.aspx/Get_Anios",
            contentType: "application/json; chartseft:utf-8",
            success: function (response) {
                var Data = response.d;
                var lengthd = Data.length - 1;
                $('#cboAnio').html('');
                for (var i = 0; i <= lengthd; i++) {
                    $('<option value="' + Data[i] + '">' + Data[i] + '</option>').appendTo('#cboAnio');
                }
            },
            error:
       function (XmlHttpError, error, description) {
           $('#divError').html(XmlHttpError.responseText);
       },
            async: false
        });

    }

};


function RemoveFiltro(Dimen_Id) {
    $('#tr' + Dimen_Id).remove();
};




















function open_DialogDimensiones() {
    $('#dialog-Dimensiones').dialog({
        autoOpen: true,
        modal: true,
        width: 580,
        height: 400,
        show: { effect: "fade", duration: 800 },
        hide: { effect: "explode", duration: 800 }
    });

};

function open_DialogSuma() {
    $('#dialog-Sum').dialog({
        autoOpen: true,
        modal: true,
        width: 700,
        height: 400,
        show: { effect: "fade", duration: 800 },
        hide: { effect: "explode", duration: 800 }
    });

};
function open_DialogFiltrosDimen() {
    $('#dialog-FiltrosDimen').dialog({
        autoOpen: true,
        modal: true,
        width: 700,
        height: 400,
        show: { effect: "fade", duration: 800 },
        hide: { effect: "explode", duration: 800 }
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
        isRTL: false,
        onClose: function (selectedDate) {
            $("#txtFechaFinal").datepicker("option", "minDate", selectedDate);
        }

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
        isRTL: false,
        onClose: function (selectedDate) {
            $("#txtFechaInicio").datepicker("option", "maxDate", selectedDate);
        }
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
                arr = fecha.split('/');
                return arr[2] + '/' + arr[1] + '/' + arr[0];
            } else if (fecha.indexOf('-') != -1) {
                arr = fecha.split('-');
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
