/*nuevas funciones*/
function Get_Planilla_ListN() {

    $.ajax({
        type: "POST",
        dataType: "json",
        url: "JustificacionJefes.aspx/Get_Planilla_List",
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
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: false
    });

};

function Get_Localidad_ListN() {
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "JustificacionJefes.aspx/Get_Localidad_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboLocalidad').html('');
            $('<option value="">-TODOS-</option>').appendTo('#cboLocalidad');
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Area_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboLocalidad');
            }
            $('#cboLocalidad').val('');
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: false
    });
};


function Get_Categoria_ListN() {
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "JustificacionJefes.aspx/Get_Categoria_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboCategoria').html('');
            $('<option value="">-TODOS-</option>').appendTo('#cboCategoria');
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Categoria2_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboCategoria');
            }
            $('#cboCategoria').val('');
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: false
    });
};

function Get_DatosPersonalN(Personal_Id) {

    var params = {
        Personal_Id: Personal_Id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "JustificacionJefes.aspx/Get_DatosPersonal",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            if (Data.length > 0) {
                $('#lblJefe').html(Data[0].PersonalNom);
            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

};

function Get_Personal_ListN(Planilla_Id, Periodo, Localidad_Id, Categoria_Id, Jefe_Id) {
    var params = {
        Planilla_Id: Planilla_Id,
        Periodo: Periodo,
        Localidad_Id: Localidad_Id,
        Categoria_Id: Categoria_Id,
        Jefe_Id: Jefe_Id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "JustificacionJefes.aspx/Get_Personal_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboPersonal').html('');
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Personal_Id + '">' + Data[i].Personal + '</option>').appendTo('#cboPersonal');
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#dialog-form").html(XmlHttpError.responseText);
                },
        async: false
    });
};

function Get_Planilla_FindN() {
    return $('#cboPlanilla').val() == null ? '' : $('#cboPlanilla').val();
};

function Get_Localidad_FindN() {
    return $('#cboLocalidad').val() == null ? '' : $('#cboLocalidad').val();
};
function Get_Categoria_FindN() {
    return $('#cboCategoria').val() == null ? '' : $('#cboCategoria').val();
};
function Get_Personal_FindN() {
    return $('#cboPersonal').val() == null ? '' : $('#cboPersonal').val();
};

function Get_Periodo_Activo_AsistenciaN() {

    $.ajax({
        type: "POST",
        dataType: "json",
        url: "JustificacionJefes.aspx/Get_Periodo_Activo_Asistencia",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            if (Data) {
                $('#lblPeriodo2').html(Data.Periodo);
                FechaIniPer = formatFecha.ymd(Data.Date_Inicio.toDateFormat());
                FechaFinPer = formatFecha.ymd(Data.Date_Fin.toDateFormat());
                Periodo_Des = Data.Periodo;
            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: false
    });

};


/*fin nuevas funciones*/
function Get_Periodo_Activo_Asistencia() {

    $.ajax({
        type: "POST",
        dataType: "json",
        url: "GenerarJustificacion.aspx/Get_Periodo_Activo_Asistencia",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            if (Data) {
                $('#lblPeriodo').html(Data.Periodo);
                FechaIniPer = formatFecha.ymd(Data.Date_Inicio.toDateFormat());
                FechaFinPer = formatFecha.ymd(Data.Date_Fin.toDateFormat());
                Get_Periodo_Planilla(Data.Periodo, Personal_IdG);
            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: false
    });

};

function Get_Periodo_Planilla(Periodo, Personal_Id) {

    var params = {
        Periodo: Periodo,
        Personal_Id: Personal_Id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "GenerarJustificacion.aspx/Get_Periodo_Planilla",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            if (Data) {
                Periodo_IdG = Data;
            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
   async: false
    });

};



function Get_DatosPersonal(Personal_Id, Periodo_Id) {
 
    var params = {
        Personal_Id: Personal_Id,
        Periodo_Id: Periodo_Id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "GenerarJustificacion.aspx/Get_DatosPersonal",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            if (Data.length >0) {
                $('#lblNomPersonal').html(Data[0].PersonalNom);
                $('#lblNomLocalidad').html(Data[0].Localidad);
                $('#lblNomCargo').html(Data[0].Cargo);
            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

};




    function Get_Marcaciones_Malas_Personal (Personal_Id, FechaIni, FechaFin) {
        var params = {
            Personal_Id: Personal_Id,
            FechaIni: FechaIni,
            FechaFin: FechaFin
        };

        $.ajax({
            type: "POST",
            data: JSON.stringify(params),
            dataType: "json",
            url: "GenerarJustificacion.aspx/Get_Marcaciones_Malas_Personal",
            contentType: "application/json; chartseft:utf-8",
            success: function (response) {
                var Data = response.d;
                var lengthD = Data.length - 1;
                $('#tbodyMMPersonal').html('');
                for (var i = 0; i <= lengthD; i++) {
                    var FaltaDes = Data[i].Falta == 'True' ? 'Falta' : '';
                    var MinTardanza = parseInt(Data[i].MinTard) > 0 ? Data[i].MinTard + ' Min.' : '';
                    var html = '<tr>';
                    html += '<td style="text-align:center;"><input type="button" class="buttonEditMarc" id="' + Data[i].Asistencia_Id + '" title="Justificar Marcación" /></td>';
                    html += '<td>' + Data[i].Solicitado + '</td>';
                    html += '<td>' + Data[i].Estado + '</td>';
                    html += '<td>' + Data[i].Realizado + '</td>';
                    html += '<td>' + Data[i].Tipo + '</td>';
                    html += '<td>' + Data[i].Dia + '</td>';
                    html += '<td style="text-align:center;">' + formatFecha.dmy(Data[i].FechaMarc) + '</td>';
                    html += '<td style="text-align:center;">' + Data[i].HIH + '</td>';
                    html += '<td style="text-align:center;">' + Data[i].HFH + '</td>';
                    html += '<td style="text-align:center;">' + Data[i].HIM + '</td>';
                    html += '<td style="text-align:center;">' + Data[i].HSM + '</td>';
                    html += '<td style="text-align:center;">' + Data[i].THO + '</td>';
                    html += '<td style="text-align:center;">' + MinTardanza + '</td>';
                    html += '<td style="text-align:center;">' + FaltaDes + '</td>';
                    html += '<td>' + Data[i].OBS + '</td>';
                    html += '</tr>';
                    $(html).appendTo('#tbodyMMPersonal');
                }
            },
            error:
               function (XmlHttpError, error, description) {
                   $('#dialog-form').html(XmlHttpError.responseText);
               },
            async: true
        });
    };


    function Get_Marcaciones_Correctas_Personal(Personal_Id, FechaIni, FechaFin) {
        var params = {
            Personal_Id: Personal_Id,
            FechaIni: FechaIni,
            FechaFin: FechaFin
        };

        $.ajax({
            type: "POST",
            data: JSON.stringify(params),
            dataType: "json",
            url: "GenerarJustificacion.aspx/Get_Marcaciones_Correctas_Personal",
            contentType: "application/json; chartseft:utf-8",
            success: function (response) {
                var Data = response.d;
                var lengthD = Data.length - 1;
                $('#tbodyMCorr').html('');
                for (var i = 0; i <= lengthD; i++) {
                    var FaltaDes = Data[i].Falta == 'True' ? 'Falta' : '';
                    var MinTardanza = parseInt(Data[i].MinTard) > 0 ? Data[i].MinTard + ' Min.' : '';
                    var html = '<tr>';
                    html += '<td style="text-align:center;"><input type="button" class="buttonEditMarc" id="' + Data[i].Asistencia_Id + '" title="Justificar Marcación" /></td>';   
                    html += '<td>' + Data[i].Solicitado + '</td>';
                    html += '<td>' + Data[i].Estado + '</td>';
                    html += '<td>' + Data[i].Realizado + '</td>';   
                    html += '<td>' + Data[i].Dia + '</td>';
                    html += '<td style="text-align:center;">' + formatFecha.dmy(Data[i].FechaMarc) + '</td>';
                    html += '<td style="text-align:center;">' + Data[i].HIH + '</td>';
                    html += '<td style="text-align:center;">' + Data[i].HFH + '</td>';
                    html += '<td style="text-align:center;">' + Data[i].HIM + '</td>';
                    html += '<td style="text-align:center;">' + Data[i].HSM + '</td>';
                    html += '<td style="text-align:center;">' + Data[i].THO + '</td>';
                    html += '<td style="text-align:center;">' + MinTardanza + '</td>';
                    html += '<td style="text-align:center;">' + FaltaDes + '</td>';
                    html += '<td>' + Data[i].OBS + '</td>';
                    html += '</tr>';
                    $(html).appendTo('#tbodyMCorr');
                }
            },
            error:
               function (XmlHttpError, error, description) {
                   $('#dialog-form').html(XmlHttpError.responseText);
               },
            async: true
        });
    };


    function Get_Justificacion_Find(Asistencia_Id) {
        var params = {
            Asistencia_Id: Asistencia_Id
        };

        $.ajax({
            type: "POST",
            data: JSON.stringify(params),
            dataType: "json",
            url: "GenerarJustificacion.aspx/Get_Justificacion_Find",
            contentType: "application/json; chartseft:utf-8",
            success: function (response) {
                var Data = response.d;
                if (Data) {

                    $('#lblInfoIngreso').html('');
                    $('#tdInfIng2').css('background-color', 'transparent');

                    $('#lblInfoSalida').html('');
                    $('#tdInfSal2').css('background-color', 'transparent');


                    $('#lblFechaJusti').html(formatFecha.ymd(Data.Fecha.toDateFormat()));
                    FechaProc = formatFecha.ymd(Data.Fecha.toDateFormat());
                    
                    if (Data.HIP) {
                        var b = Data.HIP.substring(0, 2);
                        var c = Data.HIP.substring(3, 5);
                        $('#cboHoraIng').val(b);
                        $('#cboMinIng').val(c);

                        var horaReal = Data.HIR;
                        if (horaReal != '') {
                            horaReal = Data.HIR.split(' ')[1].substring(0, 5);
                        }

                        switch (Data.HIE) {
                            case '06': $('#lblInfoIngreso').html('CANCELADO > H. Real: ' + horaReal); $('#tdInfIng2').css('background-color', '#FF8181'); break;
                            case '05': $('#lblInfoIngreso').html('PENDIENTE > H. Real: ' + horaReal); $('#tdInfIng2').css('background-color', '#93E4B2'); break;
                            case '04': $('#lblInfoIngreso').html('DESAPROBADO JEFE > H. Real: ' + horaReal); $('#tdInfIng2').css('background-color', '#FF8181'); break;
                            case '03': $('#lblInfoIngreso').html('APROBADO JEFE - PENDIENTE RRHH > H. Real: ' + horaReal); $('#tdInfIng2').css('background-color', '#93E4B2'); break;
                            case '02': $('#lblInfoIngreso').html('DESAPROBADO RRHH > H. Real: ' + horaReal); $('#tdInfIng2').css('background-color', '#FF8181'); break;
                            case '01': $('#lblInfoIngreso').html('APROBADO RRHH > H. Real: ' + horaReal); $('#tdInfIng2').css('background-color', '#93E4B2'); break;
                        }


                    } else if (Data.HIR) {
                        var a = Data.HIR.split(' ')[1];
                        var b = a.substring(0, 2);
                        var c = a.substring(3, 5);
                        $('#cboHoraIng').val(b);
                        $('#cboMinIng').val(c);
                    } else {
                        $('#cboHoraIng').val('');
                        $('#cboMinIng').val('');
                    }

                    if (Data.HSP) {
                        var b = Data.HSP.substring(0, 2);
                        var c = Data.HSP.substring(3, 5);
                        $('#cboHoraSal').val(b);
                        $('#cboMinSal').val(c);


                        var horaRealSa = Data.HSR;
                        if (horaRealSa != '') {
                            horaRealSa = Data.HSR.split(' ')[1].substring(0, 5);
                        }

                        switch (Data.HSE) {
                            case '06': $('#lblInfoSalida').html('CANCELADO > H. Real: ' + horaRealSa); $('#tdInfSal2').css('background-color', '#FF8181'); break;
                            case '05': $('#lblInfoSalida').html('PENDIENTE > H. Real: ' + horaRealSa); $('#tdInfSal2').css('background-color', '#93E4B2'); break;
                            case '04': $('#lblInfoSalida').html('DESAPROBADO JEFE > H. Real: ' + horaRealSa); $('#tdInfSal2').css('background-color', '#FF8181'); break;
                            case '03': $('#lblInfoSalida').html('APROBADO JEFE - PENDIENTE RRHH > H. Real: ' + horaRealSa); $('#tdInfSal2').css('background-color', '#93E4B2'); break;
                            case '02': $('#lblInfoSalida').html('DESAPROBADO RRHH > H. Real: ' + horaRealSa); $('#tdInfSal2').css('background-color', '#FF8181'); break;
                            case '01': $('#lblInfoSalida').html('APROBADO RRHH > H. Real: ' + horaRealSa); $('#tdInfSal2').css('background-color', '#93E4B2'); break;
                        }


                    } else if (Data.HSR) {
                        var a = Data.HSR.split(' ')[1];
                        var b = a.substring(0, 2);
                        var c = a.substring(3, 5);
                        $('#cboHoraSal').val(b);
                        $('#cboMinSal').val(c);
                    } else {
                        $('#cboHoraSal').val('');
                        $('#cboMinSal').val('');
                    }

                    Mostivos = [];

                    Mostivos.push(Data.MI);
                    Mostivos.push(Data.MS);

                    $('#txtMotivos').val(Data.MI);

                    opend_DialogJustificacion();
                }
            },
            error:
               function (XmlHttpError, error, description) {
                   $('#dialog-form').html(XmlHttpError.responseText);
               },
            async: false
        });



    };



    function Get_Files_Jusitificacion(Asistencia_Id) {
        var params = {
            Asistencia_Id: Asistencia_Id
        };

        $.ajax({
            type: "POST",
            data: JSON.stringify(params),
            dataType: "json",
            url: "GenerarJustificacion.aspx/Get_Files_Jusitificacion",
            contentType: "application/json; chartseft:utf-8",
            success: function (response) {
                var Data = response.d;
                FileArr = [];
                FileArr = Data;              
                if ($('#cboTipoJust').val() == '01') {
                    $('#aVerAchivo').prop('href', FileArr[0]);
                } else {
                    $('#aVerAchivo').prop('href', FileArr[1]);
                }
            },
            error:
               function (XmlHttpError, error, description) {
                   $('#dialog-form').html(XmlHttpError.responseText);
               },
            async: false
        });
    }






    function Get_AM_Justificacion(Fecha, Tipo, Personal_Id, NewHora, TipoRegistro, Motivo, PersoModif) {
        var params = {
            Fecha: Fecha,
            Tipo: Tipo,
            Personal_Id: Personal_Id,
            NewHora: NewHora,
            TipoRegistro: TipoRegistro,
            Motivo: Motivo,
            PersoModif: PersoModif
        };

        $.ajax({
            type: "POST",
            data: JSON.stringify(params),
            dataType: "json",
            url: "GenerarJustificacion.aspx/Get_AM_Justificacion",
            contentType: "application/json; chartseft:utf-8",
            success: function (response) {
                var Proceso = response.d;
                if (Proceso) {
                    if (Proceso.indexOf('#') != -1) {
                        var Resultado = Proceso.split('#')[0];
                        var mensaje = Proceso.split('#')[1];
                        if (Resultado == 'true') {
                            alert(mensaje);
                            $('#dialog-Justificacion').dialog('close');
                            Get_Marcaciones_Malas_Personal(Personal_IdG, FechaIniPer, FechaFinPer);
                        } else {
                            alert(mensaje);
                        }
                    }
                }
            },
            error:
                function (XmlHttpError, error, description) {
                    $("#dialog-form").html(XmlHttpError.responseText);
                },
            async: false
        });
    };







function opend_DialogJustificacion() {
    $('#dialog-Justificacion').dialog({
        autoOpen: true,
        modal: true,
        width: 710,
        height: 330,
        show: { effect: "fade", duration: 800 },
        hide: { effect: "explode", duration: 800 }
    });

}




//--hora y min


function CargarHorasMin() {
    var htmlH = '<option value="01">01</option>';
    htmlH += '<option value="02">02</option>';
    htmlH += '<option value="03">03</option>';
    htmlH += '<option value="04">04</option>';
    htmlH += '<option value="05">05</option>';
    htmlH += '<option value="06">06</option>';
    htmlH += '<option value="07">07</option>';
    htmlH += '<option value="08">08</option>';
    htmlH += '<option value="09">09</option>';
    htmlH += '<option value="10">10</option>';
    htmlH += '<option value="11">11</option>';
    htmlH += '<option value="12">12</option>';
    htmlH += '<option value="13">13</option>';
    htmlH += '<option value="14">14</option>';
    htmlH += '<option value="15">15</option>';
    htmlH += '<option value="16">16</option>';
    htmlH += '<option value="17">17</option>';
    htmlH += '<option value="18">18</option>';
    htmlH += '<option value="19">19</option>';
    htmlH += '<option value="20">20</option>';
    htmlH += '<option value="21">21</option>';
    htmlH += '<option value="22">22</option>';
    htmlH += '<option value="23">23</option>';
    htmlH += '<option value="00">00</option>';

    $('#cboHoraIng').html('');
    $('#cboHoraSal').html('');

    $('#cboHIP').html('');
    $('#cboHFP').html('');

    $(htmlH).appendTo('#cboHoraIng');
    $(htmlH).appendTo('#cboHoraSal');

    $(htmlH).appendTo('#cboHIP');
    $(htmlH).appendTo('#cboHFP');


    var htmlM = '<option value="00">00</option>';
    htmlM += '<option value="01">01</option>';
    htmlM += '<option value="02">02</option>';
    htmlM += '<option value="03">03</option>';
    htmlM += '<option value="04">04</option>';
    htmlM += '<option value="05">05</option>';
    htmlM += '<option value="06">06</option>';
    htmlM += '<option value="07">07</option>';
    htmlM += '<option value="08">08</option>';
    htmlM += '<option value="09">09</option>';
    htmlM += '<option value="10">10</option>';
    htmlM += '<option value="11">11</option>';
    htmlM += '<option value="12">12</option>';
    htmlM += '<option value="13">13</option>';
    htmlM += '<option value="14">14</option>';
    htmlM += '<option value="15">15</option>';
    htmlM += '<option value="16">16</option>';
    htmlM += '<option value="17">17</option>';
    htmlM += '<option value="18">18</option>';
    htmlM += '<option value="19">19</option>';
    htmlM += '<option value="20">20</option>';
    htmlM += '<option value="21">21</option>';
    htmlM += '<option value="22">22</option>';
    htmlM += '<option value="23">23</option>';
    htmlM += '<option value="24">24</option>';
    htmlM += '<option value="25">25</option>';
    htmlM += '<option value="26">26</option>';
    htmlM += '<option value="27">27</option>';
    htmlM += '<option value="28">28</option>';
    htmlM += '<option value="29">29</option>';
    htmlM += '<option value="30">30</option>';
    htmlM += '<option value="31">31</option>';
    htmlM += '<option value="32">32</option>';
    htmlM += '<option value="33">33</option>';
    htmlM += '<option value="34">34</option>';
    htmlM += '<option value="35">35</option>';
    htmlM += '<option value="36">36</option>';
    htmlM += '<option value="37">37</option>';
    htmlM += '<option value="38">38</option>';
    htmlM += '<option value="39">39</option>';
    htmlM += '<option value="40">40</option>';
    htmlM += '<option value="41">41</option>';
    htmlM += '<option value="42">42</option>';
    htmlM += '<option value="43">43</option>';
    htmlM += '<option value="44">44</option>';
    htmlM += '<option value="45">45</option>';
    htmlM += '<option value="46">46</option>';
    htmlM += '<option value="47">47</option>';
    htmlM += '<option value="48">48</option>';
    htmlM += '<option value="49">49</option>';
    htmlM += '<option value="50">50</option>';
    htmlM += '<option value="51">51</option>';
    htmlM += '<option value="52">52</option>';
    htmlM += '<option value="53">53</option>';
    htmlM += '<option value="54">54</option>';
    htmlM += '<option value="55">55</option>';
    htmlM += '<option value="56">56</option>';
    htmlM += '<option value="57">57</option>';
    htmlM += '<option value="58">58</option>';
    htmlM += '<option value="59">59</option>';

    $('#cboMinIng').html('');
    $('#cboMinSal').html('');

    $('#cboMIP').html('');
    $('#cboMFP').html('');

    $(htmlM).appendTo('#cboMinIng');
    $(htmlM).appendTo('#cboMinSal');

    $(htmlM).appendTo('#cboMIP');
    $(htmlM).appendTo('#cboMFP');

};





String.prototype.toDateFormat = function () {
    if (this) {
        var dte = eval("new " + this.replace(/\//g, '') + ";");

        dte.setMinutes(dte.getMinutes() - dte.getTimezoneOffset());
        //  dateFormat(dte, "yyyy-MM-dd HH:mm:ss");
        var ret = dateDemo(dte);
        //return dte;
        return ret;
    } else {
        return '';
    }
};

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
var DateDiff = {

    inDays: function (d1, d2) {
        var t2 = d2; //.getTime();
        var t1 = d1; //.getTime();

        return parseInt(((t2 - t1) / (24 * 3600 * 1000)) + 1);
    },

    inWeeks: function (d1, d2) {
        var t2 = d2.getTime();
        var t1 = d1.getTime();
        return parseInt((t2 - t1) / (24 * 3600 * 1000 * 7));
    },

    inMonths: function (d1, d2) {
        var d1Y = d1.getFullYear();
        var d2Y = d2.getFullYear();
        var d1M = d1.getMonth();
        var d2M = d2.getMonth();

        return (d2M + 12 * d2Y) - (d1M + 12 * d1Y);
    },

    inYears: function (d1, d2) {
        return d2.getFullYear() - d1.getFullYear();
    }
};




function uploadFile() {

        var archivos = document.getElementById("fileToUpload");
        var archivo = archivos.files;
  
        for (var i = 0; i < archivo.length; i=i+2) {

            var xhr = new XMLHttpRequest();
            var fd = new FormData();

            fd.append('file', archivo[i]);
            fd.append('perso', Personal_IdG);
            fd.append('fecha', formatFecha.ymdEN(FechaProc));
            fd.append('tipo', $('#cboTipoJust').val());

            xhr.open('POST', 'AjaxUploadFile.ashx/ProcessRequest', false);
            xhr.onload = function (e) {
                if (this.status == 200) {
                    var rsc = this.responseText;
                    if (rsc == '1') {
                        alert('Archivo Guardado correctamente.');
                    } else {
                        alert(this.responseText);
                    }
                } else {
                    alert(this.responseText);
                }
            };

            xhr.onreadystatechange = function (oEvent) {
                if (xhr.readyState === 4) {
                    if (xhr.status === 200) {
                      
                    } else {
                        alert("Error : "+ xhr.statusText);
                    }
                }
            };

            xhr.send(fd);
            
        }

        document.getElementById("fileToUpload").value = null;
        Get_Files_Jusitificacion(Asistencia_Proc);
}
