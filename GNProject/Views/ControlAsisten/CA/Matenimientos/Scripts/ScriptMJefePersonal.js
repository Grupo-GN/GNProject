function Get_Localidad_List() {
    var params = {
        Personal_Id: Personal_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MJefePersonal.aspx/Get_Localidad_List_New",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            $('#cboLocalidad').html('');
            var lengthDatos = Data.length - 1;
            for (var i = 0; i <= lengthDatos; i++) {
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
function Get_Categoria_Auxiliar_List() {
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "MJefePersonal.aspx/Get_Categoria_Auxiliar_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            $('#cboArea').html('');
            var lengthDatos = Data.length - 1;
            for (var i = 0; i <= lengthDatos; i++) {
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
        async: false
    });
}
function Get_Categoria_Auxiliar2_List() {
    var Cat_Aux = $('#cboArea').val();
    var params = {
        Cat_Aux: Cat_Aux
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MJefePersonal.aspx/Get_Categoria_Auxiliar2_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            $('#cboSeccion').html('');
            var lengthDatos = Data.length - 1;
            for (var i = 0; i <= lengthDatos; i++) {
                var html = '<option value="' + Data[i].Categoria_Auxiliar2_Id + '">' + Data[i].Descripcion + '</option>';
                $(html).appendTo('#cboSeccion');
            }
            $('<option value="">-TODOS-</option>').appendTo('#cboSeccion');
            $("#cboSeccion > option[value='']").attr("selected", true);
        },
        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: true
    });
}
function Get_Gerentes() {
    var params = {
        pr1: Personal_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MJefePersonal.aspx/Get_Gerentes",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            $('#cbogerente').html('');
            var lengthDatos = Data.length - 1;
            for (var i = 0; i <= lengthDatos; i++) {
                var html = '<option value="' + Data[i].a + '">' + Data[i].Gerente + '</option>';
                $(html).appendTo('#cbogerente');
            }
            //$("#cbogerente > option[value='x0']").attr("selected", true);
            $('<option value="">-SELECCIONAR-</option>').appendTo('#cbogerente');
            $("#cbogerente > option[value='']").attr("selected", true);
        },
        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: false
    });
}
function Get_Jefes() {
    var a =$('#cbogerente').val();
    var params = {
        pr1: Personal_Id,
        gere:a
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MJefePersonal.aspx/Get_Jef",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var datos = response.d;
            $('#cbojefe').html('');
            var lengthDatos = datos.length - 1;
            for (var i = 0; i <= lengthDatos; i++) {
                var html = '<option value="' + datos[i].a + '">' + datos[i].c + '</option>';
                $(html).appendTo('#cbojefe');
            }
            //$("#cbojefe > option[value='x0']").attr("selected", true);
        },
        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: false
    });
}
function getPersonal() {
    //var a = $('#cboLocalidad').val(), b = $('#cboArea').val(), c = $('#cboSeccion').val(), d = $('#txtFind').val();
    //var a = $('#cbogerente').val(), b = $('#cbojefe').val(),d = $('#txtFind').val();
    var a = 'x0', b = 'x0', d = $('#txtFind').val(), e = $('#cboLocalidad').val(), f = $('#cboArea').val(), g = $('#cboSeccion').val();
    if (e==null) {
        return;
    } 
    if (f==null) {
        return;
    } 
    if (g==null) {
        return;
    }
    var params = {
        pr1: a,
        pr2: b,
        pr3: '',//c,
        pr4: d,
        local:e,
        area:f,
        seccion:g
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MJefePersonal.aspx/getPersonal",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            $('#tbodydata').html('');
            var lengthDatos = Data.length - 1;
            for (var i = 0; i <= lengthDatos; i++) {
                var html = '<tr>';
                html += '<td style="text-align:center;"><input type="checkbox" value="' + Data[i].id + '" /></td>';
                html += '<td>' + Data[i].planilla + '</td>';
                html += '<td>' + Data[i].loc + '</td>';
                html += '<td>' + Data[i].personal + '</td>';
                html += '<td>' + Data[i].cate1 + '</td>';
                html += '<td>' + Data[i].cate2 + '</td>';
                html += '<td>' + Data[i].gere + '</td>';
                html += '<td>' + Data[i].jefe + '</td>';
                html += '</tr>';
                $(html).appendTo('#tbodydata');
            }
            document.getElementById("txtnRegistros").value = lengthDatos;
           
        },
        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: true
    });
}



function AsignarJefe() {
    var perso = [];
    $('#tbodydata input[type="checkbox"]').each(function () {
        if ($(this).prop('checked') == true) {            
            perso.push($(this).val());
        }
    });
    if (perso.length == 0) {
        alert('Seleccione algun personal.');
        return false;
    }
    var a = $('#cbojefe').val();
    var b = $('#cbogerente').val();
    var params = {
        jefeid: a,
        gereid: b,
        personal: perso
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        //url: "MJefePersonal.aspx/AsignarJefe",
        url: "MJefePersonal.aspx/AsignarPersonal",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var data = response.d;
            var tru = data.split('#')[0];
            var mens = data.split('#')[1];
            var Data = response.d;
            if (Data == true)
            {
                alert("ACTUALIZO CORRECTAMENTE");
                alert(mens);
                getPersonal();
            }
            if (Data == false)
            { alert("¡NO SE HA GUARDADO!, INTENTELO NUEVAMENTE"); alert(mens); }

            //if (tru == 'true') {
            //    alert(mens);
            //    getPersonal();
            //} else {
            //    alert(mens);
            //}
        },
        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: true
    });
}
function AsignarGerente() {
    var perso = [];
    $('#tbodydata input[type="checkbox"]').each(function () {
        if ($(this).prop('checked') == true) {
            perso.push($(this).val());
        }
    });
    if (perso.length == 0) {
        alert('Seleccione algun personal.');
        return false;
    }
    var a = $('#cbogerente').val();
    var params = {
        gereid: a,
        personal: perso
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MJefePersonal.aspx/AsignarGerente",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var data = response.d;
            var tru = data.split('#')[0];
            var mens = data.split('#')[1];
            if (tru == 'true') {
                alert(mens);
                getPersonal();
            } else {
                alert(mens);
            }
        },
        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: true
    });
}

var Personal_Id = Session.get('UsuarioSistema').Personal_Id;
$(document).ready(function () {
    Get_Localidad_List();
    Get_Categoria_Auxiliar_List();
    Get_Categoria_Auxiliar2_List();
    $('#cboArea').change(Get_Categoria_Auxiliar2_List);
    Get_Gerentes();
    //Get_Jefes();
  
    $('#cbogerente').change(Get_Jefes);
    //$('#cbojefe').change(getPersonal);
    $('#cboLocalidad').change(getPersonal);
    $('#cboArea').change(getPersonal);
    $('#cboSeccion').change(getPersonal);
    $('#txtFind').keyup(getPersonal);
    document.getElementById("cboLocalidad").selectedIndex = 1;
    //getPersonal();

    setTimeout(getPersonal, 2000);
    //$("#cboLocalidad").prop('selectedIndex', 1);
    $('#cboLocalidad :nth-child(1)').prop('selected', true).trigger('change');
 
    $('#chkAll').change(function () {
        $('#tbodydata input[type="checkbox"]').prop('checked', $(this).prop('checked'));
    });
    $('#BtnListar').click(function () {
        getPersonal();
        cargarPagina(pagina_actual, pagina_ultima);
    });

    document.getElementById('BtnListar').addEventListener('click', getPersonal, true);

    $('#btnAply2').click(function () {
        if (confirm('¿Está seguro de continuar?')) {
            AsignarJefe();
            getPersonal();
        }
    });
    $('#btnAply1').click(function () {
        if (confirm('¿Está seguro de continuar?')) {
            AsignarGerente();
        }
    });


    //saber cuantas paginas vamos a mostrar
    pagina_ultima = Math.round(total_registros / resultados_por_pagina) + 1;
    $("#cargar_primera_pagina").click(function () {
        cargarPagina(1, pagina_ultima);
    });
    $("#cargar_anterior_pagina").click(function () {
        cargarPagina(pagina_actual - 1, pagina_ultima);
    });
    $("#cargar_siguiente_pagina").click(function () {
        cargarPagina(pagina_actual + 1, pagina_ultima);
    });
    $("#cargar_ultima_pagina").click(function () {
        cargarPagina(pagina_ultima, pagina_ultima);
    });
});

var resultados_por_pagina = 15;
var pagina_actual = 1;
var pagina_ultima = 0;
var total_registros = parseInt($('#txtnRegistros').val());

var cargarPagina = function (intPaginaP, pagina_ultima) {
    //evaluar si la pagina a cargar es mayor que el numero de paginas o es menor que 1
    if (intPaginaP < 1) { intPaginaP = 1; }
    if (intPaginaP > pagina_ultima) { intPaginaP = pagina_ultima; }
    //ocultar todas las lineas
    $("#tblAH>tbody>tr").addClass("linea-oculta");
    var primer_registro = (intPaginaP - 1) * resultados_por_pagina;
    for (var i = primer_registro; i < (primer_registro + resultados_por_pagina) ; i++) {
        $("#tblAH>tbody>tr").eq(i).removeClass("linea-oculta");
    }
    //indicar en qué pagina estamos
    pagina_actual = intPaginaP;
    $("#indicador_paginas").html("Página: " + pagina_actual + " / " + pagina_ultima);
}