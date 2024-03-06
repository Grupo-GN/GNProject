function Get_Planillas_List() {
    $.ajax({
        type: "POST",
        data: JSON.stringify(),
        dataType: "json",
        url: "CAAsignarCodigo.aspx/Get_Planillas_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            $('#cboPlanilla').html('');
            var lengthDatos = Data.length - 1;
            for (var i = 0; i <= lengthDatos; i++) {
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

//public static ArrayList Get_Localidades_List()
function Get_Localidades_List() { 

 $.ajax({
        type: "POST",
        data: JSON.stringify(),
        dataType: "json",
        url: "CAAsignarCodigo.aspx/Get_Localidades_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            $('#cboLocal').html('');

            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {

                var html = '<option value="' + Data[i].Area_Id + '">' + Data[i].Descripcion + '</option>';
                $(html).appendTo('#cboLocal');

            }
            $('<option value="">--TODOS--</option>').appendTo('#cboLocal');
            $('<option value="">-SELECCIONAR-</option>').appendTo('#cboLocal');
            $("#cboLocal > option[value='']").attr("selected", true);
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}

//funcion listar periodos

function List_Periodo(Plantilla) {
    var params = {
        Plantilla: Plantilla
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "CAAsignarCodigo.aspx/List_Periodo",
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

//funcion listar areas
function Get_Areas_List() {
     $.ajax({
        type: "POST",
        data: JSON.stringify(),
        dataType: "json",
        url: "CAAsignarCodigo.aspx/Get_Areas_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            $('#cboSeccion').html('');

            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {

                var html = '<option value="' + Data[i].Categoria_Auxiliar_Id + '">' + Data[i].Descripcion + '</option>';
                $(html).appendTo('#cboSeccion');

            }
            $('<option value="">--TODOS--</option>').appendTo('#cboSeccion');
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

//public static ArrayList CargarPersonal(string seccion, string Localidad, string Periodo_id)
function CargarPersonal(seccion, Localidad, Periodo_id) {
    var params = {
    seccion:seccion,
     Localidad:Localidad,
     Periodo_id: Periodo_id
 };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "CAAsignarCodigo.aspx/CargarPersonal",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
    $('#tbodyAH').html('');

    var lengtDatos = Data.length - 1;


    for (var i = 0; i <= lengtDatos; i++) {
        var html = '<tr>';
        html += '<td ><input id="btnGrab' + Data[i].codigo + Data[i].Personal_Id + '" type="button"  value=""  class="buttonGrabar" title="Grabar Codigo" /></td>';
        html += '<td ><input id="btnEdit' + Data[i].codigo + '" type="button"  value=""  class="buttonEdit"  title="Editar Codigo" /></td>';
        html += '<td>' + Data[i].Localidad + '</td>';
        html += '<td>' + Data[i].Seccion + '</td>';
        html += '<td>' + Data[i].Nombres + '</td>';
        html += '<td><input type="text" id="txtC' + Data[i].codigo + '" value="' + Data[i].codigo + '" disabled="disabled"/></td>';
        html += '</tr>';

        $(html).appendTo('#tbodyAH');
        }
    },
    error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
             },
        async: true
    });

}

//public static bool AsignarCodigo_Save(string Personal_Id,string CodigoActual, string co_trabajador_id)
function AsignarCodigo_Save(Personal_Id, CodigoActual, co_trabajador_id) {
    var params = {
        Personal_Id: Personal_Id,
        CodigoActual: CodigoActual,
        co_trabajador_id: co_trabajador_id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "CAAsignarCodigo.aspx/AsignarCodigo_Save",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            if (Data == true)
            { alert("ACTUALIZO CORRECTAMENTE"); }
            if (Data == false)
            { alert("¡NO SE HA GUARDADO!, INTENTELO NUEVAMENTE"); }

        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}