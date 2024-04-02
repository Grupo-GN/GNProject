//LISTAR PERSONAL

function Lista_Personal_Faltante_Periodo(Periodo, Personal) {

    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/Lista_Personal_Faltante_Periodo';

    var params = {
    Periodo: Periodo,
    Personal: Personal
    };
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        data: JSON.stringify(params),
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#tbodyAgregaPer').html('');
            for (var i = 0; i <= lengthD; i++) {
                
                var html = '<tr>';

                html += '<td><label class="miLabel" id="sel'+Datos[i][0]+'" style="cursor:pointer;"  >SELECT</label></td>';                
                html += '<td >' + Datos[i][0] + '</td>';
                html += '<td >' + Datos[i][1] + '</td>';

                html += '</tr>';
                $(html).appendTo('#tbodyAgregaPer');
            }
           
        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });

}

function Agrega_Personal_al_Periodo(Periodo, Personal) {

    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/Agrega_Personal_al_Periodo';

    var params = {
        Periodo: Periodo,
        Personal: Personal
    };
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        data: JSON.stringify(params),
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            if (Datos > 0) {
                alert('Personal agregado correctamente');
                $('#dialog-PersonalOut').dialog('close');
                Lista_Personal_x_Filtro_Columna(Get_Compania(), Get_Periodo(), Get_ColumnaBusqueda(), Get_TextoBusqueda(), inicio);
            }

        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });

}


function Elimina_Personal_de_Periodo(Periodo, Personal) {

    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/Elimina_Personal_de_Periodo';

    var params = {
        Periodo: Periodo,
        Personal: Personal
    };
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        data: JSON.stringify(params),
        dataType: "json",
        success: function(response) {
            var Datos = response.d;
            if (Datos > 0) {
                alert('Personal excluido con éxito.');
                Lista_Personal_x_Filtro_Columna(Get_Compania(), Get_Periodo(), Get_ColumnaBusqueda(), Get_TextoBusqueda(), inicio);
            }

        },
        error:
         function(XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });

}