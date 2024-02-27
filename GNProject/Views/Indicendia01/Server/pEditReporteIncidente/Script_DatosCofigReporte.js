//INTENSIDAD-------------------------
function Get_Intensidad_List() {
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "sEditReporteIncidente.aspx/Get_Intensidad_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#cboIntensidad').html('');
            $('<option value="">-Seleccione-</option>').appendTo('#cboIntensidad');
            for (var i = 0; i <= lengthD; i++) {
                $('<option value="' + Datos[i].Intensidad_Id + '">' + Datos[i].Descripcion + '</option>').appendTo('#cboIntensidad');
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });

};

//SEVERIDAD-------------------------

function Get_Severidad_List() {

    $.ajax({
        type: "POST",
        dataType: "json",
        url: "sEditReporteIncidente.aspx/Get_Severidad_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#cboSeveridad').html('');
            $('<option value="">-Seleccione-</option>').appendTo('#cboSeveridad');
            for (var i = 0; i <= lengthD; i++) {
                $('<option value="' + Datos[i].Severidad_Id + '">' + Datos[i].Descripcion + '</option>').appendTo('#cboSeveridad');
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });

};

//TIPO-------------------------

function Get_Tipo_List() {

    $.ajax({
        type: "POST",
        dataType: "json",
        url: "sEditReporteIncidente.aspx/Get_Tipo_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#cboTipo').html('');
            $('<option value="">-Seleccione-</option>').appendTo('#cboTipo');
            for (var i = 0; i <= lengthD; i++) {
                $('<option value="' + Datos[i].Tipo_Id + '">' + Datos[i].Descripcion + '</option>').appendTo('#cboTipo');
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });

};

//ORIGEN-------------------------

function Get_Origen_List() {

    $.ajax({
        type: "POST",
        dataType: "json",
        url: "sEditReporteIncidente.aspx/Get_Origen_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#cboOrigen').html('');
            $('<option value="">-Seleccione-</option>').appendTo('#cboOrigen');
            for (var i = 0; i <= lengthD; i++) {
                $('<option value="' + Datos[i].Origen_Id + '">' + Datos[i].Descripcion + '</option>').appendTo('#cboOrigen');
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });

};

//CATEGORIA AUXILIAR 1
function Get_Categoria_Auxiliar_Combo() {
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "sEditReporteIncidente.aspx/Get_Categoria_Auxiliar_Combo",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#cboCategoriaAuxiliar').html('');
            for (var i = 0; i <= lengthD; i++) {
                $('<option value="' + Datos[i].Categoria_Auxiliar_Id + '">' + Datos[i].Descripcion + '</option>').appendTo('#cboCategoriaAuxiliar');
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });

};

function Get_Categoria_Auxiliar2_Combo() {
    var Categoria_Auxiliar_id = $('#cboCategoriaAuxiliar').val() == null ? '' : $('#cboCategoriaAuxiliar').val();
    var params = {
        Categoria_Auxiliar_id: Categoria_Auxiliar_id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sEditReporteIncidente.aspx/Get_Categoria_Auxiliar2_Combo",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#cboCategoriaAuxiliar2').html('');
            $('<option value=""> - NO ESPECIFICAR - </option>').appendTo('#cboCategoriaAuxiliar2');
            for (var i = 0; i <= lengthD; i++) {
                $('<option value="' + Datos[i].Categoria_Auxiliar2_Id + '">' + Datos[i].Descripcion + '</option>').appendTo('#cboCategoriaAuxiliar2');
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });

};


//Get DataList

function Get_DataList_Responsable(Nombres, Usuario, Area_Id) {
    var params = {
        Nombres: Nombres,
        Usuario: Usuario,
        Area_Id: Area_Id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sEditReporteIncidente.aspx/Get_DataList_Responsable",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#cboResponsable').html('');
            $('<option value="">-SELECCIONE-</option>').appendTo('#cboResponsable');
            for (var i = 0; i <= lengthD; i++) {
                $('<option value="' + Datos[i].Personal_Id + '">' + Datos[i].Apellido_Paterno + ' ' + Datos[i].Apellido_Materno + ',' + Datos[i].Nombres + '</option>').appendTo('#cboResponsable');
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });
};




function Get_Localidad_Combo() {
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "sEditReporteIncidente.aspx/Get_Localidad_Combo",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#cboLocalidad').html('');
            for (var i = 0; i <= lengthD; i++) {
                $('<option value="' + Datos[i].Area_Id + '">' + Datos[i].Descripcion + '</option>').appendTo('#cboLocalidad');
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });


};



//TIPO DE INCIDENTE
function Get_TipoIncidente_List() {
    
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "sEditReporteIncidente.aspx/Get_TipoIncidente_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#cboTipoInc').html('');
            $('<option value="">-SELECCIONE-</option>').appendTo('#cboTipoInc');
            for (var i = 0; i <= lengthD; i++) {
                $('<option value="' + Datos[i].TipoI_Id + '">' + Datos[i].Descripcion + '</option>').appendTo('#cboTipoInc');
            }
      
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });

};


//TIPO DE AFECTOS 
function Get_AfectadoInc_List() {

    $.ajax({
        type: "POST",
        dataType: "json",
        url: "sEditReporteIncidente.aspx/Get_AfectadoInc_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#cboAfectadoInc').html('');
            $('<option value="">-SELECCIONE-</option>').appendTo('#cboAfectadoInc');
            for (var i = 0; i <= lengthD; i++) {
                $('<option value="' + Datos[i].Afec_Id + '">' + Datos[i].Descripcion + '</option>').appendTo('#cboAfectadoInc');
            }
  
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });

};


//CAUSAS BASICAS 
function Get_CausasTipo_Report(Tipo) {
    var params = {
        Tipo: Tipo
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sEditReporteIncidente.aspx/Get_CausasTipo_Report",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            if (Tipo == '01') {
                $('#cboCausasBasicas').html('');
                $('<option value="">-SELECCIONE-</option>').appendTo('#cboCausasBasicas');
                for (var i = 0; i <= lengthD; i++) {
                    var causaid = Datos[i].Causa_Id;
                    $('<option value="' + causaid + '">' + Datos[i].Causa_Name + '</option>').appendTo('#cboCausasBasicas');
                }
            } else if (Tipo == '02') {
                $('#cboCausasInmediatas').html('');
                $('<option value="">-SELECCIONE-</option>').appendTo('#cboCausasInmediatas');
                for (var i = 0; i <= lengthD; i++) {
                    $('<option value="' + Datos[i].Causa_Id + '">' + Datos[i].Causa_Name + '</option>').appendTo('#cboCausasInmediatas');
                }

            }


        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });

};



//--hora y min


function CargarHorasMin() {
    var htmlH = '<option value="00">00</option>';
    htmlH += '<option value="01">01</option>';
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

    
    /* '<option value="">00 am</option>';
     htmlH += '<option value="">01 am</option>';
    htmlH += '<option value="">02 am</option>';
    htmlH += '<option value="">03 am</option>';
    htmlH += '<option value="">04 am</option>';
    htmlH += '<option value="">05 am</option>';
    htmlH += '<option value="">06 am</option>';
    htmlH += '<option value="">07 am</option>';
    htmlH += '<option value="">08 am</option>';
    htmlH += '<option value="">09 am</option>';
    htmlH += '<option value="">10 am</option>';
    htmlH += '<option value="">11 am</option>';
    htmlH += '<option value="">12 am</option>';
   htmlH += '<option value="">--</option>';
    htmlH += '<option value="">01 pm</option>';
    htmlH += '<option value="">02 pm</option>';
    htmlH += '<option value="">03 pm</option>';
    htmlH += '<option value="">04 pm</option>';
    htmlH += '<option value="">05 pm</option>';
    htmlH += '<option value="">06 pm</option>';
    htmlH += '<option value="">07 pm</option>';
    htmlH += '<option value="">08 pm</option>';
    htmlH += '<option value="">09 pm</option>';
    htmlH += '<option value="">10 pm</option>';
    htmlH += '<option value="">11 pm</option>';*/


    $(htmlH).appendTo('#cboHoraInc');

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

    $(htmlM).appendTo('#cboMinInc');

};