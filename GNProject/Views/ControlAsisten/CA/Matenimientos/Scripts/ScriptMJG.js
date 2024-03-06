function Get_Categoria_Auxiliar_List() {
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "MJG.aspx/Get_Categoria_Auxiliar_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            $('#cboArea').html('');
            var lengthDatos = Data.length - 1;
            for (var i = 0; i <= lengthDatos; i++) {
                var html = '<option value="' + Data[i].Categoria_Auxiliar_Id + '">' + Data[i].Descripcion + '</option>';
                $(html).appendTo('#cboArea');
            }
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
        url: "MJG.aspx/Get_Categoria_Auxiliar2_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            $('#cboSeccion').html('');
            var lengthDatos = Data.length - 1;
            for (var i = 0; i <= lengthDatos; i++) {
                var html = '<option value="' + Data[i].Categoria_Auxiliar2_Id + '">' + Data[i].Descripcion + '</option>';
                $(html).appendTo('#cboSeccion');
            }
            $('<option value="">-SELECCIONAR-</option>').appendTo('#cboSeccion');
            $("#cboSeccion > option[value='']").attr("selected", true);
        },
        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: true
    });
}
function getGerentesJefesByLocalidad() {
    var a = $('#cboSeccion').val();
    if (a == null) { return ; }
    var params = {
        pr1: a
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MJG.aspx/getGerentesJefesByLocalidad",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var data = response.d;
            $('#tbodydata').html('');
            var lengthDatos = data.length - 1;
            for (var i = 0; i <= lengthDatos; i++) {
                var html = '<tr>';
                html += '<td>' + data[i].b + '</td>';
                html += '<td>' + data[i].d + '</td>';
                html += '<td>' + data[i].f + '</td>';
                html += '<td style="text-align:center;"><input type="button" id="' + data[i].a + data[i].g + data[i].h + '" value="Procesar Asignación" style="width:150px;" class="submit"></td>';
                html += '</tr>';
                $(html).appendTo('#tbodydata');
            }
        },
        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: true
    });
}
//Filtro 2
function Get_Localidad2_List() {
    var params = {
        Personal_Id: Personal_Id
    };
    comboloc = '';
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MJG.aspx/Get_Localidad_List_New",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            $('#cboLocalidad2').html('');
            var lengthDatos = Data.length - 1;
            for (var i = 0; i <= lengthDatos; i++) {
                var html = '<option value="' + Data[i].Area_Id + '">' + Data[i].Descripcion + '</option>';
                $(html).appendTo('#cboLocalidad2');
                $(html).appendTo('#cboloc2');                
            }
        },
        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: true
    });
}
function Get_Categoria_Auxiliar2a_List() {
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "MJG.aspx/Get_Categoria_Auxiliar_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            $('#cboArea2').html('');
            var lengthDatos = Data.length - 1;
            for (var i = 0; i <= lengthDatos; i++) {
                var html = '<option value="' + Data[i].Categoria_Auxiliar_Id + '">' + Data[i].Descripcion + '</option>';
                $(html).appendTo('#cboArea2');
            }
            $('<option value="">-TODOS-</option>').appendTo('#cboArea2');
            $("#cboArea2 > option[value='']").attr("selected", true);
        },
        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: false
    });
}
function Get_Categoria_Auxiliar22_List() {
    var Cat_Aux = $('#cboArea2').val();
    var params = {
        Cat_Aux: Cat_Aux
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MJG.aspx/Get_Categoria_Auxiliar2_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            $('#cboSeccion2').html('');
            var lengthDatos = Data.length - 1;
            for (var i = 0; i <= lengthDatos; i++) {
                var html = '<option value="' + Data[i].Categoria_Auxiliar2_Id + '">' + Data[i].Descripcion + '</option>';
                $(html).appendTo('#cboSeccion2');
            }
            $('<option value="">-TODOS-</option>').appendTo('#cboSeccion2');
            $("#cboSeccion2 > option[value='']").attr("selected", true);
        },
        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: true
    });
}
function getPersonalAdd() {
    var a = $('#cboLocalidad2').val(), b = $('#cboArea2').val(), c = $('#cboSeccion2').val(), d = $('#txtFind').val();
    var params = {
        pr1: a,
        pr2: b,
        pr3: c,
        pr4: d
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MJG.aspx/getPersonalAdd",
        contentType: "application/json; chartseft:utf-8",
        beforesend: function () {
            $('#tbodydata2').html('');
        },
        success: function (response) {
            var data = response.d;
            $('#tbodydata2').html('');
            var lengthDatos = data.length - 1;
            for (var i = 0; i <= lengthDatos; i++) {
                var html = '<tr>';
                html += '<td>' + data[i].f + '</td>';
                html += '<td>' + data[i].d + '</td>';
                html += '<td>' + data[i].e + '</td>';
                html += '<td>' + data[i].c + '</td>';
                html += '<td>' + data[i].b + '</td>';
                html += '<td><select id="cboTipo' + data[i].a + '" class="cbo"><option value="01">Gerente</option><option value="02">Jefe</option></select></td>';
                html += '<td><input type="button" value="Add" class="submit" id="' + data[i].a + '"></td>';
                html += '</tr>';
                $(html).appendTo('#tbodydata2');
            }
        },
        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: true
    });
}
var select = {
    pr1: '',
    pr2: '',
    pr3: '',
    pr4: '',
    pr5: '',
    pr6: ''
};
function addPersonalGJ(id, pr) {
    var a = $('#cboloc2').val(), b = $('#cboArea').val(), c = $('#cboSeccion').val(), d = $('#cboTipo' + id).val(), e = id, f = pr;
    select.pr1 = a;
    select.pr2 = b;
    select.pr3 = c;
    select.pr4 = d;
    if (d == '01') {
        select.pr5 = e;
    } else { select.pr6 = e; }
    alert('Seleccionado correctamente');
    var cadena = '';
    if (select.pr5 != '') { cadena += ' Gerente : ' + select.pr5; }
    if (select.pr6 != '') { cadena += ' Jefe : ' + select.pr6; }
    $('#lblLog').html(cadena);
}
function SaveConfig() {
    if (select.pr5 == '' || select.pr6 == '') {
        return false;
    }
    var params = {
        pr1: select.pr1,
        pr2: select.pr2,
        pr3: select.pr3,
        pr4: select.pr4,
        pr5: select.pr5,
        pr6: select.pr6
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MJG.aspx/addPersonalGJ",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var data = response.d;
            var len = data.split('#').length;
            if (len > 2) {
                if (confirm(data.split('#')[1])) {
                    addPersonalGJ(id, '02')
                }
            } else {
                if (data.split('#')[0] == 'true') {
                    alert(data.split('#')[1]);
                    getGerentesJefesByLocalidad();
                    $('#dialogadd').dialog('close');
                } else {
                    alert(data.split('#')[1]);
                }
            }
        },
        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: false
    });
}
function Procesar(id) {
    var a = id;
    var params = {
        pr1: a
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MJG.aspx/Procesar",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var data = response.d;
            if (data.split('#')[0] == 'true') {
                alert(data.split('#')[1]);
            } else {
                alert(data.split('#')[1]);
            }
        },
        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: false
    });
}
var proces = '';
var Personal_Id = '000000';   //Session.get('UsuarioSistema').Personal_Id;
var comboloc = '';
$(document).ready(function () {

    Get_Categoria_Auxiliar_List();
    Get_Categoria_Auxiliar2_List();
    $('#cboArea').change(Get_Categoria_Auxiliar2_List);
    //$('#cboSeccion').change(getGerentesJefesByLocalidad);
    //getGerentesJefesByLocalidad();
    $("#cboSeccion").prop('selectedIndex', 0);
    $('#cboSeccion').change(function () {
        getGerentesJefesByLocalidad();
    });
    getGerentesJefesByLocalidad();

   

    //2
    Get_Localidad2_List();
    Get_Categoria_Auxiliar2a_List();
    Get_Categoria_Auxiliar22_List();
    $('#cboLocalidad2').change(getPersonalAdd);
    $('#cboArea2').change(function () {
        Get_Categoria_Auxiliar22_List();
        getPersonalAdd();
    });
    $('#cboSeccion2').change(getPersonalAdd);


    $('#btnAddGer').click(function () {
        $('#cboLocalidad2').val('01');
        $('#cboArea2').val('1              ');
        proces = '01';
        getPersonalAdd();
        pasaModal();
    });
    $('#btnAddJef').click(function () {
        $('#cboLocalidad2').val('01');
        $('#cboArea2').val('1              ');
        proces = '02';
        getPersonalAdd();
        pasaModal();
    });
    $('#tbodydata2').on('click', 'input[type="button"]', function () {
        //if (confirm('¿Está seguro de continuar?')) {
            addPersonalGJ(this.id, '01');
        //}
    });

    $('#tbodydata').on('click', 'input[type="button"]', function () {
        if (confirm('¿Está seguro de continuar?')) {
            Procesar(this.id);
        }
    });
    $('#btnSave').click(function () {
        if (confirm('¿Está seguro de continuar?')) {
            SaveConfig();
        }
    });
});

function pasaModal() {

    $('#dialogadd').dialog({
        height: 440, width: 950, modal: true, autoOpen: true,
        appendTo: "form", title: "ASIGNAR GERENTE/JEFE",
        show: { effect: "fade", duration: 800 },
        hide: { effect: "fold", duration: 800 }
    });
}