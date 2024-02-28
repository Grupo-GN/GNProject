function Get_Planillas_List() {
    $.ajax({
        type: "POST",
        data: JSON.stringify(),
        dataType: "json",
        url: "CAGenerarFaltas.aspx/Get_Planillas_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            $('#cboPlanilla').html('');
            var lengthDatos = Data.length - 1;
            for (var i = 0; i <= lengthDatos; i++) {
                var html = '<option value="' + Data[i].Planilla_Id + '">' + Data[i].Descripcion + '</option>';
                $(html).appendTo('#cboPlanilla');
            }
            $('#cboPlanilla').val('01');
        },
        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: true
    });
}


function Get_Localidades_List() {

    $.ajax({
        type: "POST",
        data: JSON.stringify(),
        dataType: "json",
        url: "CAGenerarFaltas.aspx/Get_Localidades_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            $('#cboLocal').html('');

            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {

                var html = '<option value="' + Data[i].Area_Id + '">' + Data[i].Descripcion + '</option>';
                $(html).appendTo('#cboLocal');

            }
            $('<option value="">-TODOS-</option>').appendTo('#cboLocal');
            $('#cboLocal').val('');

        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}

function List_Periodo(Plantilla) {
    var params = {
        Plantilla: Plantilla
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "CAGenerarFaltas.aspx/List_Periodo",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            $('#cboPeriodo').html('');

            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {

                var html = '<option value="' + Data[i].Periodo_Id + '">' + Data[i].Descripcion + '</option>';
                $(html).appendTo('#cboPeriodo');

            }

        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: false
    });

}

function Get_PeriodoCA_By_Planilla(Periodo_Id) {
    var params = {
        Periodo_Id: Periodo_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "CAGenerarFaltas.aspx/Get_PeriodoCA_By_Planilla",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            for (var i = 0; i <= lengthd; i++) {

                $("#dtpfi").datepicker("setDate", formatFecha.dmy(Data[0].Date_Inicio.toDateFormat()));
                $("#dtpff").datepicker("setDate", formatFecha.dmy(Data[0].Date_Fin.toDateFormat()));


            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#divError').html(XmlHttpError.responseText);
   },
        async: false
    });

};

// public ArrayList listaPersonalSinMarcaciones(string Planilla_Id,string Periodo_Id,string Area_Id,DateTime vi_fecha_inicio  
//            ,DateTime vi_fecha_fin )
function listaPersonalSinMarcaciones(Periodo_Id, Area_Id, vi_fecha_inicio, vi_fecha_fin, Planilla_Id) {
    var params = {
        Periodo_Id: Periodo_Id,
        Area_Id:Area_Id,
        vi_fecha_inicio: formatOFecha.ymdEN(vi_fecha_inicio),
        vi_fecha_fin: formatOFecha.ymdEN(vi_fecha_fin),
        Planilla_Id: Planilla_Id

    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "CAGenerarFaltas.aspx/listaPersonalSinMarcaciones2",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            $('#tbodyAH').html('');

            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {
                //$('#txtnRegistros').val() = i.toString();
                var html = '<tr>';
                html += '<td>' + Data[i].Personal_Id + '</td>';
                html += '<td>' + Data[i].Localidad + '</td>';
                html += '<td>' + Data[i].Seccion + '</td>';
                html += '<td>' + Data[i].Nombre + '</td>';
                html += '</tr>';
                $(html).appendTo('#tbodyAH');

            }
            $('#txtnRegistros').text = lengtDatos;
            document.getElementById("txtnRegistros").value = lengtDatos;
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: false
    });

};

function listaPersonalSinMarcacionesN(Periodo_Id, Area_Id, vi_fecha_inicio, vi_fecha_fin) {
    var params = {
        Periodo_Id: Periodo_Id,
        Area_Id: Area_Id,
        vi_fecha_inicio: formatOFecha.ymdEN(vi_fecha_inicio),
        vi_fecha_fin: formatOFecha.ymdEN(vi_fecha_fin)
        

    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "CAGenerarFaltas.aspx/listaPersonalSinMarcaciones",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            $('#tbodyAH').html('');

            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {
                //$('#txtnRegistros').val() = i.toString();
                var html = '<tr>';
                html += '<td>' + Data[i].Personal_Id + '</td>';
                html += '<td>' + Data[i].Localidad + '</td>';
                html += '<td>' + Data[i].Seccion + '</td>';
                html += '<td>' + Data[i].Nombre + '</td>';
                html += '</tr>';
                $(html).appendTo('#tbodyAH');

            }
            $('#txtnRegistros').text = lengtDatos;
            document.getElementById("txtnRegistros").value = lengtDatos;
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: false
    });

};


var formatOFecha = {
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
    },
    ymdEN: function (fecha) {
        if (fecha.indexOf(' ') != -1) {
            var arr1 = fecha.split(' ');
            var arr = [];
            if (fecha.indexOf('/') != -1) {
                arr = arr1[0].split('/');
                return arr[2] + '-' + arr[1] + '-' + arr[0];
            } else if (fecha.indexOf('-') != -1) {
                arr = arr1[0].split('-');
                return arr[2] + '-' + arr[1] + '-' + arr[0];
            }

        } else {
            var arr = [];
            if (fecha.indexOf('/') != -1) {
                arr = fecha.split('/');
                return arr[2] + '-' + arr[1] + '-' + arr[0];
            } else if (fecha.indexOf('-') != -1) {
                arr = fecha.split('-');
                return arr[2] + '-' + arr[1] + '-' + arr[0];
            }
        }

    }

};


function GenerarFaltas(Planilla_Id, Periodo_Id, Area_Id, vi_fecha_inicio, vi_fecha_fin) {
    var Planilla = Planilla_Id;
    var Periodo = Periodo_Id;
    var Area = Area_Id;
    var FechaIni = vi_fecha_inicio;
    var FechaFin = vi_fecha_fin;

    if (!Planilla) {
        alert('Planilla no definida.');
        return false;
    }
    if (!Periodo) {
        alert('Periodo no definido.');
        return false;
    }
    //if (!Area) {
    //    alert('Area no definida.');
    //    return false;
    //}
    if (!FechaIni) {
        alert('Fecha Inicio no definida.');
        return false;
    }
    if (!FechaFin) {
        alert('Fecha Final no definida.');
        return false;
    }

    Set_GenerarFaltas(Planilla, Periodo, Area, formatOFecha.ymd(FechaIni), formatOFecha.ymd(FechaFin));
}



function Set_GenerarFaltas(Planilla, Periodo, Area, FechaInicio, FechaFinal) {

    var params = {
        Planilla_Id: Planilla,
        Periodo_Id: Periodo,
        Area_Id: Area,
        FechaInicio: FechaInicio,
        FechaFinal: FechaFinal
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "CAGenerarFaltas.aspx/Set_GenerarFaltas",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            alert(Data);

        },
        error:
            function (XmlHttpError, error, description) {
                $('#dialog-form').html(XmlHttpError.responseText);
            },
        async: false
    });
};

//nuevos datos

$.fn.pageMe = function (opts) {
    var $this = this,
        defaults = {
            perPage: 7,
            showPrevNext: false,
            hidePageNumbers: false
        },
        settings = $.extend(defaults, opts);

    var listElement = $this;
    var perPage = settings.perPage;
    var children = listElement.children();
    var pager = $('.pager');

    if (typeof settings.childSelector != "undefined") {
        children = listElement.find(settings.childSelector);
    }

    if (typeof settings.pagerSelector != "undefined") {
        pager = $(settings.pagerSelector);
    }

    var numItems = children.size();
    var numPages = Math.ceil(numItems / perPage);

    pager.data("curr", 0);

    if (settings.showPrevNext) {
        $('<li><a href="#" class="prev_link">«</a></li>').appendTo(pager);
    }

    var curr = 0;
    while (numPages > curr && (settings.hidePageNumbers == false)) {
        $('<li><a href="#" class="page_link">' + (curr + 1) + '</a></li>').appendTo(pager);
        curr++;
    }

    if (settings.showPrevNext) {
        $('<li><a href="#" class="next_link">»</a></li>').appendTo(pager);
    }

    pager.find('.page_link:first').addClass('active');
    pager.find('.prev_link').hide();
    if (numPages <= 1) {
        pager.find('.next_link').hide();
    }
    pager.children().eq(1).addClass("active");

    children.hide();
    children.slice(0, perPage).show();

    pager.find('li .page_link').click(function () {
        var clickedPage = $(this).html().valueOf() - 1;
        goTo(clickedPage, perPage);
        return false;
    });
    pager.find('li .prev_link').click(function () {
        previous();
        return false;
    });
    pager.find('li .next_link').click(function () {
        next();
        return false;
    });

    function previous() {
        var goToPage = parseInt(pager.data("curr")) - 1;
        goTo(goToPage);
    }

    function next() {
        goToPage = parseInt(pager.data("curr")) + 1;
        goTo(goToPage);
    }

    function goTo(page) {
        var startAt = page * perPage,
            endOn = startAt + perPage;

        children.css('display', 'none').slice(startAt, endOn).show();

        if (page >= 1) {
            pager.find('.prev_link').show();
        }
        else {
            pager.find('.prev_link').hide();
        }

        if (page < (numPages - 1)) {
            pager.find('.next_link').show();
        }
        else {
            pager.find('.next_link').hide();
        }

        pager.data("curr", page);
        pager.children().removeClass("active");
        pager.children().eq(page + 1).addClass("active");

    }
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