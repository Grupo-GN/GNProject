//funcion listar turnos

function Get_Parametros_List(inicio) {
    var params = {
        inicio: inicio
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MParametros.aspx/Get_Parametros_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            $('#tbodyParametros').html('');

            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {
                var html = '<tr>';
                html += '<td class="tbodyLink"><input id="btnEdit' + Data[i].Parametro_Id + '" type="button"  value=""  class="ElLinkEditar" title="Editar Parametro" /></td>';
                html += '<td>' + Data[i].Descripcion + '</td>';
                html += '<td>' + Data[i].Variable + '</td>';
                html += '<td>' + Data[i].Valor + '</td>';
                html += '<td>' + Data[i].Tipo + '</td>';
                html += '<td>' + Data[i].C_abrev + '</td>';
                if (Data[i].C_estado == '01') {
                    //html += '<td>' + Data[i].C_estado + '</td>';
                    html += '<td>' + 'ACTIVO' + '</td>';
                } else {
                    html += '<td>' + 'INACTIVO' + '</td>';
                }
               
                html += '</tr>';

                $(html).appendTo('#tbodyParametros');
            }

        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}

//funcion buscar y cargar turnos por codigo
function Get_Parametros_Find(codigo) {
    var params = {
        codigo: codigo
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MParametros.aspx/Get_Parametros_Find",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            if (Data) {
                $('#txtCodigo').val(Data.Parametro_Id);
                $('#txtDescripcion').val(Data.Descripcion);
                $('#txtVariable').val(Data.Variable);
                $('#txtValor').val(Data.Valor);
                $('#txtTipo').val(Data.Tipo);
                $('#txtabrev').val(Data.C_abrev);
                
                $('#cboestado').val(Data.C_estado);

            }

        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}


/////////////////////////////////////////////////////////////////////////////////////////



/////////////////////////////////////////////////////////////////////////////////////////









//Get_Carac_Update(Carac_Id,Carac_Nombre,Carac_Opcion,Estado)
//actualizar turno
function Get_Parametros_Update(codigo, descripcion, variable, valor, tipo ,  abrev,   estado) {
    var params = {
        codigo: codigo,
        descripcion: descripcion,
        variable: variable,
        valor: valor,
        tipo: tipo,
        abrev:abrev,
        estado:estado
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MParametros.aspx/Get_Parametros_Update",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            alert('Modificado Correctamente')
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });
}






//Get_Carac_MaxRegistro(Carac_Nombre,Carac_Opcion,Estado)
function Get_Parametros_MaxRegistro() {

    $.ajax({
        type: "POST",
        dataType: "json",
        url: "MParametros.aspx/Get_Parametros_MaxRegistro",
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
function Get_Parametros_Add(descripcion, variable, valor, tipo,  abrev,   estado) {
    param =
         {
             descripcion: descripcion,
             variable: variable,
             valor: valor,
             tipo: tipo ,
             abrev: abrev,
             estado: estado
         };
    $.ajax({
        type: "POST",
        data: JSON.stringify(param),
        dataType: "json",
        url: "MParametros.aspx/Get_Parametros_Add",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            alert('Inserto Correctamenta')
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });
}