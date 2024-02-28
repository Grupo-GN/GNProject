function Get_Planilla_List() {

    $.ajax({
        type: "POST",
        dataType: "json",
        url: "cVerBoletas.aspx/Get_Planilla_List",
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

};

function Get_Periodos_Planilla(Planilla_Id) {
    var params = {
        Planilla_Id: Planilla_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "cVerBoletas.aspx/Get_Periodos_Planilla",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboPeriodo').html('');
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Periodo_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboPeriodo');
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
        url: "cVerBoletas.aspx/Get_Localidad_List_New",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboLocalidad').html('');
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Area_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboLocalidad');
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
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "cVerBoletas.aspx/Get_Categoria_Auxiliar_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboCategoriaAux').html('');
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Categoria_Auxiliar_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboCategoriaAux');
            }
            $('<option value="">-TODOS-</option>').appendTo('#cboCategoriaAux');
        },
        error:
   function (XmlHttpError, error, description) {
       $('#divError').html(XmlHttpError.responseText);
   },
        async: false
    });
};



function Get_Categoria_Auxiliar2_List(Cat_Aux) {
    var params = {
        Cat_Aux: Cat_Aux
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "cVerBoletas.aspx/Get_Categoria_Auxiliar2_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboCategoriaAux2').html('');
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Categoria_Auxiliar2_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboCategoriaAux2');
            }
            $('<option value="">-TODOS-</option>').appendTo('#cboCategoriaAux2');
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
        url: "cVerBoletas.aspx/Get_Categoria_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboCategoria').html('');
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Categoria2_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboCategoria');
            }
            $('<option value="">-TODOS-</option>').appendTo('#cboCategoria');
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
        url: "cVerBoletas.aspx/Get_PeriodoCA_By_Planilla",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            for (var i = 0; i <= lengthd; i++) {

                $("#txtFechaInicio").datepicker("option", "minDate", formatFecha.dmy(Data[0].Date_Inicio.toDateFormat()));
                $("#txtFechaFinal").datepicker("option", "minDate", formatFecha.dmy(Data[0].Date_Inicio.toDateFormat()));

                $("#txtFechaInicio").datepicker("option", "maxDate", formatFecha.dmy(Data[0].Date_Fin.toDateFormat()));
                $("#txtFechaFinal").datepicker("option", "maxDate", formatFecha.dmy(Data[0].Date_Fin.toDateFormat()));
            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#divError').html(XmlHttpError.responseText);
   },
        async: false
    });

};


function Get_Personal_All_By_Periodo(Periodo_Id, Localidad_Id, CategoriaAux, CategoriaAux2, Categoria, PersonalFind) {
    var params = {
        Periodo_Id: Periodo_Id,
        Localidad_Id: Localidad_Id,
        CategoriaAux: CategoriaAux,
        CategoriaAux2: CategoriaAux2,
        Categoria: Categoria,
        PersonalFind: PersonalFind
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "cVerBoletas.aspx/Get_Personal_All_By_Periodo",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#tbodyPersonal').html('');
            for (var i = 0; i <= lengthd; i++) {
                var htmlcombo = '<a href="../../ConsultaPersonal/cpViewBoleta/pViewBoleta.aspx?perso=' + Data[i].Personal_Id + '&per=' + Periodo_Id + '&pro=01&cant=1" target="_blank">REMUNERACIONES</a>&nbsp;|&nbsp;';
                htmlcombo += '<a href="../../ConsultaPersonal/cpViewBoleta/pViewBoleta.aspx?perso=' + Data[i].Personal_Id + '&per=' + Periodo_Id + '&pro=03&cant=1" target="_blank">VACACIONES</a>&nbsp;|&nbsp;';
                htmlcombo += '<a href="../../ConsultaPersonal/cpViewBoleta/pViewBoleta.aspx?perso=' + Data[i].Personal_Id + '&per=' + Periodo_Id + '&pro=03&cant=1" target="_blank">GRATIFICACION</a>&nbsp;|&nbsp;';
                htmlcombo += '<a href="../../ConsultaPersonal/cpViewBoleta/pViewBoleta.aspx?perso=' + Data[i].Personal_Id + '&per=' + Periodo_Id + '&pro=07&cant=1" target="_blank">UTILIDADES</a>';
                var html = '<tr>';
                html += '<td style="text-align:center;" ><input type="checkbox" id="' + Data[i].Personal_Id + '" class="chkProBoleta" /></td>';
                html += '<td>' + Data[i].PersonalName + '</td>';
                //html += '<td><a href="../../ConsultaPersonal/cpViewBoleta/pViewBoleta.aspx?perso=' + Data[i].Personal_Id + '&per=' + Periodo_Id + '&pro=01&cant=1" target="_blank">VER</a></td>';
                html += '<td>' + htmlcombo + '</td>';
                //html += '<td><a href="../../ConsultaPersonal/cpDownloadBoleta/pDownloadBoleta.aspx?perso=' + Data[i].Personal_Id + '&per=' + Periodo_Id + '&pro=01&cant=1" target="_blank">DESCARGAR PDF</a></td>';
                html += '<td>' + htmlcombo + '</td>';
                html += '</tr>';
                $(html).appendTo('#tbodyPersonal');
            }

        },
        error:
   function (XmlHttpError, error, description) {
       $('#divError').html(XmlHttpError.responseText);
   },
        async: false
    });

};




function Get_Informar_PersonalBoleta_Masivo(Personal, Periodo, Asunto, Comentarios) {
    var params = {
        Personal: Personal,
        Periodo: Periodo,
        Asunto: Asunto,
        Comentarios: Comentarios
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "cVerBoletas.aspx/Get_Informar_PersonalBoleta_Masivo",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            alert(Data);
            $('#dialog-SendEmail').dialog('close');
        },
        error:
   function (XmlHttpError, error, description) {
       $('#divError').html(XmlHttpError.responseText);
   },
        async: false
    });

};



function opend_DialogSendMail() {
    $('#txtAsusto').val('');
    $('#txtComentarios').val('');

    $('#dialog-SendEmail').dialog({
        autoOpen: true,
        modal: true,
        width: 520,
        height: 260,
        show: { effect: "fade", duration: 800 },
        hide: { effect: "explode", duration: 800 }
    });

}

function Get_Planilla_Find() {
    return $('#cboPlanilla').val();
};
function Get_Periodo_Find() {
    return $('#cboPeriodo').val();
};
function Get_Localidad_Find() {
    return $('#cboLocalidad').val();
};
function Get_CategoriaAux_Find() {
    return $('#cboCategoriaAux').val();
};

function Get_CategoriaAux2_Find() {
    return $('#cboCategoriaAux2').val();
};
function Get_Categoria_Find() {
    return $('#cboCategoria').val();
};
function Get_Personal_Find() {
    return $('#txtPersonalFind').val();
};