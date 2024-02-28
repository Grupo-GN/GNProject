//funcion listar Feriados

function Get_Planillas_List(inicio) {
    var params = {
        inicio: inicio
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MAsignarHorarioMasivo.aspx/Get_Planillas_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            $('#cboPlanilla').html('');

            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {

                var html = '<option value="' + Data[i].Planilla_Id + '">' + Data[i].Descripcion + '</option>';
                $(html).appendTo('#cboPlanilla');

            }

        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}

//funcion listar localidades

function Get_Localidades_List() {
    var Personal_Id = Personal_Proc;
    var params = {
        Personal_Id: Personal_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MAsignarHorarioMasivo.aspx/Get_Localidades_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            $('#cboLocalidad').html('');

            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {

                var html = '<option value="' + Data[i].Area_Id + '">' + Data[i].Descripcion + '</option>';

                $(html).appendTo('#cboLocalidad');

            }
            $('<option value="">-TODOS-</option>').appendTo('#cboLocalidad');
            $("#cboLocalidad > option[value='']").attr("selected", true);
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}

//funcion listar periodos

function Get_Periodos_List(Planilla) {
    var params = {
        Planilla: Planilla
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MAsignarHorarioMasivo.aspx/Get_Periodos_List",
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
        async: true
    });

}

//funcion listar areas

function Get_Areas_List(inicio) {
    var params = {
        inicio: inicio
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MAsignarHorarioMasivo.aspx/Get_Areas_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            $('#cboArea').html('');

            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {

                var html = '<option value="' + Data[i].Categoria_Auxiliar_Id + '">' + Data[i].Descripcion + '</option>';
                $(html).appendTo('#cboArea');

            }
            $('<option value="">-TODOS-</option>').appendTo('#cboArea');
            $("#cboArea > option[value='']").attr("selected", true);
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}


//funcion listar tabla filtros

function Get_AsignarHorarioMasivo_List(Periodo_id, seccion, area_id, inicio) {
    var params = {
        Periodo_id: Periodo_id,
        seccion: seccion,       
        area_id: area_id,
        inicio: inicio,
        Jefe_Id: Personal_Proc
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MAsignarHorarioMasivo.aspx/Get_AsignarHorarioMasivo_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            $('#tbodyAsignarHorarioMasivo').html('');

            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {
                var html = '<tr>';
                html += '<td class="tbodyLink"><input id="ckSeleccion' + Data[i].Personal_Id + '" class="ckSelect" type="checkbox"  value=""  title="Editar AsignarHorarioMasivo" /></td>';
                html += '<td>' + Data[i].Localidad + '</td>';
                html += '<td>' + Data[i].Seccion + '</td>';
                html += '<td>' + Data[i].Area + '</td>';
                html += '<td>' + Data[i].Nombres + '</td>';
                html += '<td>' + Data[i].Horario + '</td>';
                html += '</tr>';

                $(html).appendTo('#tbodyAsignarHorarioMasivo');
            }
            document.getElementById("txtnRegistros").value = lengtDatos;
            //$('#txtnRegistros').val() = lengtDatos;

        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}

function Get_AsignarHorarioMasivo_ListAdmin(Periodo_id, seccion, area_id, inicio) {
    var params = {
        Periodo_id: Periodo_id,
        seccion: seccion,
        area_id: area_id,
        inicio: inicio,
        Jefe_Id: Personal_Proc
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MAsignarHorarioMasivo.aspx/Get_AsignarHorarioMasivo_ListAdmin",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            $('#tbodyAsignarHorarioMasivo').html('');

            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {
                var html = '<tr>';
                html += '<td class="tbodyLink"><input id="ckSeleccion' + Data[i].Personal_Id + '" class="ckSelect" type="checkbox"  value=""  title="Editar AsignarHorarioMasivo" /></td>';
                html += '<td>' + Data[i].Localidad + '</td>';
                html += '<td>' + Data[i].Seccion + '</td>';
                html += '<td>' + Data[i].Area + '</td>';
                html += '<td>' + Data[i].Nombres + '</td>';
                html += '<td>' + Data[i].Horario + '</td>';
                html += '</tr>';

                $(html).appendTo('#tbodyAsignarHorarioMasivo');
            }
            document.getElementById("txtnRegistros").value = lengtDatos;
            //$('#txtnRegistros').val() = lengtDatos;
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}

var cargarPagina = function (intPaginaP, pagina_ultima, resultados_por_pagina) {
    //evaluar si la pagina a cargar es mayor que el numero de paginas o es menor que 1
    if (intPaginaP < 1) { intPaginaP = 1; }
    if (intPaginaP > pagina_ultima) { intPaginaP = pagina_ultima; }
    //ocultar todas las lineas
    $("#tblCarac>tbody>tr").addClass("linea-oculta");
    var primer_registro = (intPaginaP - 1) * resultados_por_pagina;
    for (var i = primer_registro; i < (primer_registro + resultados_por_pagina) ; i++) {
        $("#tblCarac>tbody>tr").eq(i).removeClass("linea-oculta");
    }
    //indicar en qué pagina estamos
    pagina_actual = intPaginaP;
    $("#indicador_paginas").html("Página: " + pagina_actual + " / " + pagina_ultima);
}

//funcion buscar y cargar turnos por codigo
function Get_AsignarHorarioMasivo_Find(codigo) {
    var params = {
        codigo: codigo
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MAsignarHorarioMasivo.aspx/Get_AsignarHorarioMasivo_Find",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            if (Data) {
                $('#txtLocalidad').val(Data.Localidad);
                $('#txtSeccion').val(Data.Seccion);
                $('#txtNombres').val(Data.Nombres);
                $('#txtHorarios').val(Data.Horario);
            }

        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}


//Get_Carac_Update(Carac_Id,Carac_Nombre,Carac_Opcion,Estado)
//actualizar turno
function Get_AsignarHorarioMasivo_Update(idHorario, idcknum) {
    var params = {
        idHorario: idHorario,
        idcknum: idcknum,
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MAsignarHorarioMasivo.aspx/Get_AsignarHorarioMasivo_Update",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });
}



//Get_Carac_MaxRegistro(Carac_Nombre,Carac_Opcion,Estado)
function Get_AsignarHorarioMasivo_MaxRegistro() {

    $.ajax({
        type: "POST",
        dataType: "json",
        url: "MAsignarHorarioMasivo.aspx/Get_AsignarHorarioMasivo_MaxRegistro",
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

function Get_Horarios_List(inicio) {
    var params = {
        inicio: inicio
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MAsignarHorarioMasivo.aspx/Get_Horarios_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            $('#cboHorario').html('');

            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {

                var html = '<option value="' + Data[i].Horario_Id + '">' + Data[i].Nombre + '</option>';
                $(html).appendTo('#cboHorario');

            }

        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}



//funcion listar detalle horarios

function Get_DetalleHorarios_List(Horario_Id) {
    var params = {
        Horario_Id: Horario_Id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MAsignarHorarioMasivo.aspx/Get_DetalleHorarios_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            $('#tbodyHDetalle').html('');
            $('<tr><td colspan="5"></td></tr>').appendTo('#tbodyHDetalle');

            var htmltd1 = '<tr>';
            htmltd1 += '<td style="text-align:left"><label class="miLabel" style="width:50%;">dia</label></td>';
            htmltd1 += '<td style="text-align:left; "><label class="miLabel" style="width:50%;">H. Inicio</label></td>';
            htmltd1 += '<td style="text-align:left; "><label class="miLabel" style="width:50%;">H. Ini Refrig.</label></td>';
            htmltd1 += '<td style="text-align:left; "><label class="miLabel" style="width:50%;">H. Fin Refrig.</label></td>';
            htmltd1 += '<td style="text-align:left; "><label class="miLabel" style="width:50%;">H. Fin</label></td>';
            htmltd1 += '</tr>';
            $(htmltd1).appendTo('#tbodyHDetalle');


            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {
                var diaNom = Set_NombreDias(Data[i].Dia);

                var html = '<tr>';
                html += '<td style="text-align:left"><label class="miLabel" style="width:50%;">' + diaNom + '</label></td>';
                html += '<td style="text-align:left;"><input type="text" class="txt"style="width:180px;"  value="' + Data[i].HoraInicio.toHoMin() + '" /></td></td>';
                html += '<td style="text-align:left;"><input type="text" class="txt"style="width:180px;"  value="' + Data[i].HoraInicioRefrigerio.toHoMin() + '" /></td></td>';
                html += '<td style="text-align:left;"><input type="text" class="txt"style="width:180px;"  value="' + Data[i].HoraFinRefrigerio.toHoMin() + '" /></td></td>';
                html += '<td style="text-align:left;"><input type="text" class="txt"style="width:180px;"  value="' + Data[i].HoraFin.toHoMin() + '" /></td></td>';

                html += '</tr>';
                $(html).appendTo('#tbodyHDetalle');
            }

        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form2').html(XmlHttpError.responseText);
   },
        async: true
    });

}


function Set_NombreDias(NroDias) {
    var Nomnre = '';
    var nr = parseInt(NroDias);
    switch (nr) {
        case 1: Nomnre = 'Lunes'; break;
        case 2: Nomnre = 'Martes'; break;
        case 3: Nomnre = 'Miercoles'; break;
        case 4: Nomnre = 'Jueves'; break;
        case 5: Nomnre = 'Viernes'; break;
        case 6: Nomnre = 'Sabado'; break;
        case 7: Nomnre = 'Domingo'; break;

    }
    return Nomnre;

}

function SetData(){
    var Periodo_id = $('#cboPeriodo').val();
    var seccion = $('#cboArea').val();
    var area_id = $('#cboLocalidad').val();
    var inicio = 0;
               

    if (Rol == '01') {

        Get_AsignarHorarioMasivo_ListAdmin(Periodo_id, seccion, area_id, inicio);


    } else {
        Get_AsignarHorarioMasivo_List(Periodo_id, seccion, area_id, inicio);

    }

}



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












































/////////////////////////////////////////////////////////////////////


//funciones de fechas
String.prototype.toDatelong = function () {
    var dte = eval("new " + this.replace(/\//g, '') + ";");

    dte.setMinutes(dte.getMinutes() - dte.getTimezoneOffset());

    var ret = dateDemo(dte);

    return ret;
}

String.prototype.toHoMin = function () {
    var dte = eval("new " + this.replace(/\//g, '') + ";");

    dte.setMinutes(dte.getMinutes() - dte.getTimezoneOffset());

    var ret = get_HorMin(dte);

    return ret;
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

function get_HorMin(fecha) {

    var Dia = fecha.getUTCDate();
    var Mes = (fecha.getUTCMonth() + 1);
    var Anio = fecha.getUTCFullYear();

    Dia = Dia.toString().padLeft("0", 2);
    Mes = Mes.toString().padLeft("0", 2);

    var Hora = fecha.getUTCHours();
    Hora = Hora.toString().padLeft("0", 2);

    var Min = fecha.getUTCMinutes();
    Min = Min.toString().padLeft("0", 2);

    var fechaWPP = Hora + ":" + Min;

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

///////////////////////////////////////////////////////////////////////////////////////



//
function Get_DetalleHorarios_Add(HoraInicio, HoraInicioRefrigerio, HoraFinRefrigerio, HoraFin) {
    param =
         {
             HoraInicio: HoraInicio,
             HoraInicioRefrigerio: HoraInicioRefrigerio,
             HoraFinRefrigerio: HoraFinRefrigerio,
             HoraFin: HoraFin
         };
    $.ajax({
        type: "POST",
        data: JSON.stringify(param),
        dataType: "json",
        url: "MAsignarHorarioMasivo.aspx/Get_DetalleHorarios_Add",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            alert('Inserto Correctamenta')
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form2').html(XmlHttpError.responseText);
   },
        async: true
    });
}



///Script Para ELIMINAR VEHICULO
function Get_AsignarHorarioMasivo_UpdateHorario( Personal_Id,  newHorario_Id) {
    var params = {
        Personal_Id: Personal_Id,
        newHorario_Id: newHorario_Id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MAsignarHorarioMasivo.aspx/Get_AsignarHorarioMasivo_UpdateHorario",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
        },
        error:
   function (XmlHttpError, error, description) {
       $('#DivPersons').html(XmlHttpError.responseText);
   },
        async: true
    });
}