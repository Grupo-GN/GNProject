$(document).ready(function () {

});
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
        },
        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: true
    });
}