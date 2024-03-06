/// <reference path="../Matenimientos/Scripts/ScriptMJG.js" />
/// <reference path="../Matenimientos/Scripts/ScriptMJG.js" />
function Get_LISTARREPORTEDIARIO1(Planilla_Id, Periodo_Id, Localidad_Id, Personal_Id) {


    var params = {
        Planilla_Id: Planilla_Id,
        Periodo_Id: Periodo_Id,
        Localidad_Id: Localidad_Id,
        Personal_Id: Personal_Id
    };


    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "CaReporteDiario.aspx/ListaReporteDiario",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#tbodyNovedades').html('');
           
            for (var i = 0; i <= lengthd; i++) {
                var acu_falta = 0;
                var Acu_Tarde = 0;
                var Acu_Asis = 0;
                var acu_dom = 0;
                var asistencia = 0;
                var html = '<tr>';
                var PersonalCodigo = Data[i].Personal_Id;
                html += '<td style="display:none;">' + Data[i].Asistencia_Id + '</td>';
                html += '<td style="display:none;">' + Data[i].Personal_Id + '</td>';
                html += '<td style="display:none;">' + Data[i].Periodo + '</td>';
                html += '<td>' + Data[i].NroDoc + '</td>';
                html += '<td style="width:10%;" >' + Data[i].Personal + '</td>';
                html += '<td>' + Data[i].Area + '</td>';
                html += '<td>' + Data[i].CateAux2 + '</td>';
                html += '<td>' + Data[i].Localidad + '</td>';
                html += '<td  style="width:80px;">' + Data[i].Planilla + '</td>';
                html += '<td>' + Data[i].sueldo + '</td>';

                switch (Data[i].D1) { // dia 1
                     
                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D1 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D1 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D1 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D1 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D1 + '</td>';

                        break;
                   
                }

                switch (Data[i].D2) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D2 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D2 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D2 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D2 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D2 + '</td>';

                        break;

                }

                switch (Data[i].D3) {//dia 3

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D3 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D3 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D3 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D3 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D3 + '</td>';

                        break;

                }
                switch (Data[i].D4) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D4 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D4 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D4 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D4 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D4 + '</td>';

                        break;

                }
                switch (Data[i].D5) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D5 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D5 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D5 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D5 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D5 + '</td>';

                        break;

                }
                switch (Data[i].D6) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D6 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D6 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D6 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D6 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D6 + '</td>';

                        break;

                }

                switch (Data[i].D7) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D7 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D7 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D7 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D7 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D7 + '</td>';

                        break;

                }

                switch (Data[i].D8) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D8 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D8 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D8 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D8 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D8 + '</td>';

                        break;

                }
                switch (Data[i].D9) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D9 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D9 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D9 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D9 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D9 + '</td>';

                        break;

                }
                
                switch (Data[i].D10) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D10 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D10 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D10 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D10 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D10 + '</td>';

                        break;

                }
                switch (Data[i].D11) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D11 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D11 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D11 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D11 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D11 + '</td>';

                        break;

                }
                switch (Data[i].D12) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D12 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D12 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D12 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D12 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D12 + '</td>';

                        break;

                }
                switch (Data[i].D13) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D13 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D13 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D13 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D13 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D13 + '</td>';

                        break;

                }
                switch (Data[i].D14) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D14 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D14 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D14 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D14 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D14 + '</td>';

                        break;

                }
                switch (Data[i].D15) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D15 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D15 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D15 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D15 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D15 + '</td>';

                        break;

                }
                switch (Data[i].D16) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D16 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D16 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D16 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D16 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D16 + '</td>';

                        break;

                }
                switch (Data[i].D17) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D17 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D17 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D17 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D17 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D17 + '</td>';

                        break;

                }
                switch (Data[i].D18) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D18 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D18 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D18 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D18 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D18 + '</td>';

                        break;

                }
                switch (Data[i].D19) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D19 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D19 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D19 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D19 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D19 + '</td>';

                        break;

                }
                switch (Data[i].D20) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D20 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D20 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D20 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D20 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D20 + '</td>';

                        break;

                }
                switch (Data[i].D21) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D21 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D21 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D21 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D21 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D21 + '</td>';

                        break;

                }
                switch (Data[i].D22) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D22 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D22 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D22 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D22 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D22 + '</td>';

                        break;

                }
                switch (Data[i].D23) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D23 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D23 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D23 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D23 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D23 + '</td>';

                        break;

                }
                switch (Data[i].D24) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D24 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D24 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D24 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D24 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D24 + '</td>';

                        break;

                }
                switch (Data[i].D25) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D25 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D25 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D25 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D25 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D25 + '</td>';

                        break;

                }
                switch (Data[i].D26) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D26 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D26 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D26 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D26 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D26 + '</td>';

                        break;
                }
                switch (Data[i].D27) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D27 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D27 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D27 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D27 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D27 + '</td>';

                        break;

                }
                switch (Data[i].D28) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D28 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D28 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D28 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D28 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D28 + '</td>';

                        break;

                }
                switch (Data[i].D29) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D29 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D29 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D29 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D29 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D29 + '</td>';

                        break;


                }
                switch (Data[i].D30) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D30 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D30 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D30 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D30 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D30 + '</td>';

                        break;

                }
                switch (Data[i].D31) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D31 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D31 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D31 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D31 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D31 + '</td>';

                        break;

                }


              

              
                html += '<td style="text-align:center;">' + Data[i].TotHE + '</td>';

                html += '<td style="text-align:center;">' + Data[i].TotHESimpl + '</td>';
                html += '<td style="text-align:center;">' + Data[i].TotHEAdi + '</td>';
                html += '<td style="text-align:center;">' + Data[i].TotHEDob + '</td>';
                html += '<td style="text-align:center;">' + Data[i].DiasPer + '</td>';
                html += '<td style="text-align:center;">' + Data[i].HorasPer + '</td>';

                //html += '<td style="text-align:center;"><input type="text" id="s' + PersonalCodigo + '" class="txt" value="' + Data[i].TotHESimpl + '" style="width:43px;" /></td>';
                //html += '<td style="text-align:center;"><input type="text" id="a' + PersonalCodigo + '" class="txt" value="' + Data[i].TotHEAdi + '" style="width:43px;" /></td>';
                //html += '<td style="text-align:center;"><input type="text" id="d' + PersonalCodigo + '" class="txt" value="' + Data[i].TotHEDob + '" style="width:43px;" /></td>';
                //html += '<td style="text-align:center;"><input type="text" id="dp' + PersonalCodigo + '" class="txt" value="' + Data[i].DiasPer + '" style="width:35px;" /></td>';
                //html += '<td style="text-align:center;"><input type="text" id="hp' + PersonalCodigo + '" class="txt" value="' + Data[i].HorasPer + '" style="width:35px;" /></td>';

                html += '<td>' + Acu_Asis + '</td>';
                html += '<td style="text-align:center;">' + Data[i].DiasPer_DesMed + '</td>';

                //html += '<td style="text-align:center;"><input type="text" id="per_desmed' + PersonalCodigo + '" class="txt" value="' + Data[i].DiasPer_DesMed + '" style="width:35px;" /></td>';
                html += '<td>' + acu_dom + '</td>';
              
                asistencia = ((parseInt(Acu_Asis) + parseInt(acu_dom) + parseInt(Acu_Tarde) + parseInt(Data[i].DiasPer_Vac) + parseInt(Data[i].DiasPer_DesMed)));
                html += '<td>' +asistencia  + '</td>';
                html += '<td style="text-align:center;">' + Data[i].DiasPer_Vac + '</td>';
                html += '<td>' + acu_falta + '</td>';
                html += '<td>' + Acu_Tarde + '</td>';
                if (parseInt(asistencia) > parseInt(acu_falta)) {
                    html += '<td>' + (parseInt(asistencia) - parseInt(acu_falta)) + '</td>';
                } else {
                    html += '<td>' + (parseInt(asistencia) + parseInt(acu_falta)) + '</td>';
                }
              
                html += '<td>' + (parseInt(asistencia) + parseInt(acu_falta)) + '</td>';

                //html += '<td style="text-align:center;"><input type="text" id="f' + PersonalCodigo + '" class="txt" value="' + Data[i].Faltas + '" style="width:25px;" /></td>';
                //html += '<td style="text-align:center;"><input type="text" id="t' + PersonalCodigo + '" class="txt" value="' + Data[i].MinTarde + '" style="width:35px;" /></td>';
                ////html += '<td style="text-align:center;"><input type="text" id="dp' + PersonalCodigo + '" class="txt" value="' + Data[i].DiasPer + '" style="width:35px;" /></td>';
                // html += '<td style="text-align:center;"><input type="text" id="per_perdia' + PersonalCodigo + '" class="txt" value="' + Data[i].DiasPer_PerDia + '" style="width:35px;" /></td>';
                
               
                //html += '<td style="text-align:center;">' + Data[i].TotHESimpleFijos + '</td>';
                //html += '<td style="text-align:center;">' + Data[i].TotHEAdiFijos + '</td>';
                //html += '<td style="text-align:center;">' + Data[i].TotHEDobFijos + '</td>';
                //html += '<td style="text-align:center;">' + Data[i].FaltasFijos + '</td>';
                //html += '<td style="text-align:center;">' + Data[i].MinTardeFijos + '</td>';
              
                html += '</tr>';

                $(html).appendTo('#tbodyNovedades');
            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: false
    });
};

function Get_LISTARREPORTEDIARIO2(Planilla_Id, Periodo_Id, Localidad_Id, Personal_Id,FechaIni, FechaFin) {


    var params = {
        Planilla_Id: Planilla_Id,
        Periodo_Id: Periodo_Id,
        Localidad_Id: Localidad_Id,
        Personal_Id: Personal_Id,
        FechaIni: FechaIni,
        FechaFin: FechaFin
    };


    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "CaReporteDiario.aspx/ListaReporteDiario2",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#tbodyNovedades').html('');

            for (var i = 0; i <= lengthd; i++) {
                var acu_falta = 0;
                var Acu_Tarde = 0;
                var Acu_Asis = 0;
                var acu_dom = 0;
                var asistencia = 0;
                var html = '<tr>';
                var PersonalCodigo = Data[i].Personal_Id;
                html += '<td style="display:none;">' + Data[i].Asistencia_Id + '</td>';
                html += '<td style="display:none;">' + Data[i].Personal_Id + '</td>';
                html += '<td style="display:none;">' + Data[i].Periodo + '</td>';
                html += '<td>' + Data[i].NroDoc + '</td>';
                html += '<td style="width:10%;" >' + Data[i].Personal + '</td>';
                html += '<td>' + Data[i].Area + '</td>';
                html += '<td>' + Data[i].CateAux2 + '</td>';
                html += '<td>' + Data[i].Localidad + '</td>';
                html += '<td  style="width:80px;">' + Data[i].Planilla + '</td>';
                html += '<td>' + Data[i].sueldo + '</td>';

                switch (Data[i].D1) { // dia 1

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D1 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D1 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D1 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D1 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D1 + '</td>';

                        break;

                }

                switch (Data[i].D2) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D2 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D2 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D2 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D2 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D2 + '</td>';

                        break;

                }

                switch (Data[i].D3) {//dia 3

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D3 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D3 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D3 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D3 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D3 + '</td>';

                        break;

                }
                switch (Data[i].D4) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D4 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D4 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D4 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D4 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D4 + '</td>';

                        break;

                }
                switch (Data[i].D5) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D5 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D5 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D5 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D5 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D5 + '</td>';

                        break;

                }
                switch (Data[i].D6) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D6 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D6 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D6 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D6 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D6 + '</td>';

                        break;

                }

                switch (Data[i].D7) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D7 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D7 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D7 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D7 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D7 + '</td>';

                        break;

                }

                switch (Data[i].D8) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D8 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D8 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D8 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D8 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D8 + '</td>';

                        break;

                }
                switch (Data[i].D9) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D9 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D9 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D9 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D9 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D9 + '</td>';

                        break;

                }

                switch (Data[i].D10) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D10 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D10 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D10 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D10 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D10 + '</td>';

                        break;

                }
                switch (Data[i].D11) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D11 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D11 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D11 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D11 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D11 + '</td>';

                        break;

                }
                switch (Data[i].D12) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D12 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D12 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D12 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D12 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D12 + '</td>';

                        break;

                }
                switch (Data[i].D13) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D13 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D13 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D13 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D13 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D13 + '</td>';

                        break;

                }
                switch (Data[i].D14) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D14 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D14 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D14 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D14 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D14 + '</td>';

                        break;

                }
                switch (Data[i].D15) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D15 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D15 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D15 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D15 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D15 + '</td>';

                        break;

                }
                switch (Data[i].D16) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D16 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D16 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D16 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D16 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D16 + '</td>';

                        break;

                }
                switch (Data[i].D17) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D17 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D17 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D17 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D17 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D17 + '</td>';

                        break;

                }
                switch (Data[i].D18) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D18 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D18 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D18 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D18 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D18 + '</td>';

                        break;

                }
                switch (Data[i].D19) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D19 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D19 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D19 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D19 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D19 + '</td>';

                        break;

                }
                switch (Data[i].D20) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D20 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D20 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D20 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D20 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D20 + '</td>';

                        break;

                }
                switch (Data[i].D21) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D21 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D21 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D21 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D21 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D21 + '</td>';

                        break;

                }
                switch (Data[i].D22) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D22 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D22 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D22 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D22 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D22 + '</td>';

                        break;

                }
                switch (Data[i].D23) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D23 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D23 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D23 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D23 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D23 + '</td>';

                        break;

                }
                switch (Data[i].D24) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D24 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D24 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D24 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D24 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D24 + '</td>';

                        break;

                }
                switch (Data[i].D25) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D25 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D25 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D25 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D25 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D25 + '</td>';

                        break;

                }
                switch (Data[i].D26) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D26 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D26 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D26 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D26 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D26 + '</td>';

                        break;
                }
                switch (Data[i].D27) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D27 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D27 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D27 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D27 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D27 + '</td>';

                        break;

                }
                switch (Data[i].D28) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D28 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D28 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D28 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D28 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D28 + '</td>';

                        break;

                }
                switch (Data[i].D29) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D29 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D29 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D29 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D29 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D29 + '</td>';

                        break;


                }
                switch (Data[i].D30) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D30 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D30 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D30 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D30 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D30 + '</td>';

                        break;

                }
                switch (Data[i].D31) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D31 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
                        // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D31 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D31 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D31 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D31 + '</td>';

                        break;

                }





                html += '<td style="text-align:center;">' + Data[i].TotHE + '</td>';

                html += '<td style="text-align:center;">' + Data[i].TotHESimpl + '</td>';
                html += '<td style="text-align:center;">' + Data[i].TotHEAdi + '</td>';
                html += '<td style="text-align:center;">' + Data[i].TotHEDob + '</td>';
                html += '<td style="text-align:center;">' + Data[i].DiasPer + '</td>';
                html += '<td style="text-align:center;">' + Data[i].HorasPer + '</td>';

                
                html += '<td>' + Acu_Asis + '</td>';
                html += '<td style="text-align:center;">' + Data[i].DiasPer_DesMed + '</td>';
                 html += '<td>' + acu_dom + '</td>';

                asistencia = ((parseInt(Acu_Asis) + parseInt(acu_dom) + parseInt(Acu_Tarde) + parseInt(Data[i].DiasPer_Vac) + parseInt(Data[i].DiasPer_DesMed)));
                html += '<td>' + asistencia + '</td>';
                html += '<td style="text-align:center;">' + Data[i].DiasPer_Vac + '</td>';
                html += '<td>' + acu_falta + '</td>';
                html += '<td>' + Acu_Tarde + '</td>';
                if (parseInt(asistencia) > parseInt(acu_falta)) {
                    html += '<td>' + (parseInt(asistencia) - parseInt(acu_falta)) + '</td>';
                } else {
                    html += '<td>' + (parseInt(asistencia) + parseInt(acu_falta)) + '</td>';
                }

                html += '<td>' + (parseInt(asistencia) + parseInt(acu_falta)) + '</td>';
 

                html += '</tr>';

                $(html).appendTo('#tbodyNovedades');
            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: false
    });
};

function Get_LISTARREPORTEDIARIO(Planilla_Id, Periodo_Id, Localidad_Id, Personal_Id,Treporte) {


    var params = {
        Planilla_Id: Planilla_Id,
        Periodo_Id: Periodo_Id,
        Localidad_Id: Localidad_Id,
        Personal_Id: Personal_Id
    };


    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "CaReporteDiario.aspx/ListaReporteDiario",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#tbodyNovedades').html('');
           
            for (var i = 0; i <= lengthd; i++) {
                var acu_falta = 0;
                var Acu_Tarde = 0;
                var Acu_Asis = 0;
                var acu_dom = 0;
                var asistencia = 0;
                var html = '<tr>';
                var PersonalCodigo = Data[i].Personal_Id;
                html += '<td style="display:none;">' + Data[i].Asistencia_Id + '</td>';
                html += '<td style="display:none;">' + Data[i].Personal_Id + '</td>';
                html += '<td style="display:none;">' + Data[i].Periodo + '</td>';
                html += '<td>' + Data[i].NroDoc + '</td>';
                html += '<td style="width:10%;" >' + Data[i].Personal + '</td>';
                html += '<td>' + Data[i].Area + '</td>';
                html += '<td>' + Data[i].CateAux2 + '</td>';
                html += '<td>' + Data[i].Localidad + '</td>';
                html += '<td  style="width:80px;">' + Data[i].Planilla + '</td>';
                html += '<td>' + Data[i].sueldo + '</td>';
                if (Treporte=='30'){

                    switch (Data[i].D1) { // dia 1
                     
                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D1 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D1 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D1 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D1 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D1 + '</td>';

                            break;
                   
                    }
                    switch (Data[i].D2) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D2 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D2 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D2 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D2 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D2 + '</td>';

                            break;

                    }
                    switch (Data[i].D3) {//dia 3

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D3 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D3 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D3 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D3 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D3 + '</td>';

                            break;

                    }
                    switch (Data[i].D4) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D4 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D4 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D4 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D4 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D4 + '</td>';

                            break;

                    }
                    switch (Data[i].D5) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D5 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D5 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D5 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D5 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D5 + '</td>';

                            break;

                    }
                    switch (Data[i].D6) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D6 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D6 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D6 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D6 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D6 + '</td>';

                            break;

                    }
                    switch (Data[i].D7) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D7 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D7 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D7 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D7 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D7 + '</td>';

                            break;

                    }
                    switch (Data[i].D8) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D8 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D8 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D8 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D8 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D8 + '</td>';

                            break;

                    }
                    switch (Data[i].D9) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D9 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D9 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D9 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D9 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D9 + '</td>';

                            break;

                    }               
                    switch (Data[i].D10) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D10 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D10 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D10 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D10 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D10 + '</td>';

                            break;

                    }
                    switch (Data[i].D11) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D11 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D11 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D11 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D11 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D11 + '</td>';

                            break;

                    }
                    switch (Data[i].D12) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D12 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D12 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D12 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D12 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D12 + '</td>';

                            break;

                    }
                    switch (Data[i].D13) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D13 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D13 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D13 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D13 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D13 + '</td>';

                            break;

                    }
                    switch (Data[i].D14) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D14 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D14 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D14 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D14 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D14 + '</td>';

                            break;

                    }
                    switch (Data[i].D15) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D15 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D15 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D15 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D15 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D15 + '</td>';

                            break;

                    }
                    switch (Data[i].D16) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D16 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D16 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D16 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D16 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D16 + '</td>';

                            break;

                    }
                    switch (Data[i].D17) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D17 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D17 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D17 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D17 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D17 + '</td>';

                            break;

                    }
                    switch (Data[i].D18) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D18 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D18 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D18 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D18 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D18 + '</td>';

                            break;

                    }
                    switch (Data[i].D19) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D19 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D19 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D19 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D19 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D19 + '</td>';

                            break;

                    }
                    switch (Data[i].D20) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D20 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D20 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D20 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D20 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D20 + '</td>';

                            break;

                    }
                    switch (Data[i].D21) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D21 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D21 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D21 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D21 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D21 + '</td>';

                            break;

                    }
                    switch (Data[i].D22) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D22 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D22 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D22 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D22 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D22 + '</td>';

                            break;

                    }
                    switch (Data[i].D23) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D23 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D23 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D23 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D23 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D23 + '</td>';

                            break;

                    }
                    switch (Data[i].D24) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D24 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D24 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D24 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D24 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D24 + '</td>';

                            break;

                    }
                    switch (Data[i].D25) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D25 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D25 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D25 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D25 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D25 + '</td>';

                            break;

                    }
                    switch (Data[i].D26) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D26 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D26 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D26 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D26 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D26 + '</td>';

                            break;
                    }
                    switch (Data[i].D27) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D27 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D27 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D27 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D27 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D27 + '</td>';

                            break;

                    }
                    switch (Data[i].D28) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D28 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D28 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D28 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D28 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D28 + '</td>';

                            break;

                    }
                    switch (Data[i].D29) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D29 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D29 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D29 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D29 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D29 + '</td>';

                            break;


                    }
                    switch (Data[i].D30) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D30 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D30 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D30 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D30 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D30 + '</td>';

                            break;

                    }
                    switch (Data[i].D31) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D31 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D31 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D31 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D31 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D31 + '</td>';

                            break;

                    }
                }

                if (Treporte == '15') {

                    switch (Data[i].D1) { // dia 1
                     
                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D1 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D1 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D1 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D1 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D1 + '</td>';

                            break;
                   
                    }
                    switch (Data[i].D2) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D2 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D2 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D2 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D2 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D2 + '</td>';

                            break;

                    }
                    switch (Data[i].D3) {//dia 3

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D3 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D3 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D3 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D3 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D3 + '</td>';

                            break;

                    }
                    switch (Data[i].D4) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D4 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D4 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D4 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D4 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D4 + '</td>';

                            break;

                    }
                    switch (Data[i].D5) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D5 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D5 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D5 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D5 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D5 + '</td>';

                            break;

                    }
                    switch (Data[i].D6) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D6 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D6 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D6 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D6 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D6 + '</td>';

                            break;

                    }
                    switch (Data[i].D7) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D7 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D7 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D7 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D7 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D7 + '</td>';

                            break;

                    }
                    switch (Data[i].D8) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D8 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D8 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D8 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D8 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D8 + '</td>';

                            break;

                    }
                    switch (Data[i].D9) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D9 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D9 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D9 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D9 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D9 + '</td>';

                            break;

                    }               
                    switch (Data[i].D10) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D10 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D10 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D10 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D10 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D10 + '</td>';

                            break;

                    }
                    switch (Data[i].D11) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D11 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D11 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D11 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D11 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D11 + '</td>';

                            break;

                    }
                    switch (Data[i].D12) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D12 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D12 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D12 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D12 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D12 + '</td>';

                            break;

                    }
                    switch (Data[i].D13) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D13 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D13 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D13 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D13 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D13 + '</td>';

                            break;

                    }
                    switch (Data[i].D14) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D14 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D14 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D14 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D14 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D14 + '</td>';

                            break;

                    }
                    switch (Data[i].D15) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D15 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D15 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D15 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D15 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D15 + '</td>';

                            break;

                    }
                    Data[i].D16='0';
                    Data[i].D17='0';
                    Data[i].D18='0';
                    Data[i].D19='0';
                    Data[i].D20='0';
                    Data[i].D21='0';
                    Data[i].D22='0';
                    Data[i].D23='0';
                    Data[i].D24='0';
                    Data[i].D25='0';
                    Data[i].D26='0';
                    Data[i].D27='0';
                    Data[i].D28='0';
                    Data[i].D29='0';
                    Data[i].D30='0';
                    Data[i].D31='0';
                    switch (Data[i].D16) {//dia 2
                        
                                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D16 + '</td>';
                acu_falta = acu_falta + 1;
                break
                // NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D16 + '</td>';
            Acu_Tarde = Acu_Tarde + 1;
            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D16 + '</td>';
    Acu_Asis = Acu_Asis + 1;
    break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D16 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D16 + '</td>';

                        break;

} 
                switch (Data[i].D17) {//dia 2
					
                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D17 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D17 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D17 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D17 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D17 + '</td>';

                        break;

}
                switch (Data[i].D18) {//dia 2
					
                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D18 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D18 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D18 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D18 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D18 + '</td>';

                        break;

}
                switch (Data[i].D19) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D19 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D19 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D19 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D19 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D19 + '</td>';

                        break;

}
                switch (Data[i].D20) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D20 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D20 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D20 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D20 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D20 + '</td>';

                        break;

}
                switch (Data[i].D21) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D21 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D21 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D21 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D21 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D21 + '</td>';

                        break;

}
                switch (Data[i].D22) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D22 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D22 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D22 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D22 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D22 + '</td>';

                        break;

}
                switch (Data[i].D23) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D23 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D23 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D23 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D23 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D23 + '</td>';

                        break;

}
                switch (Data[i].D24) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D24 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D24 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D24 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D24 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D24 + '</td>';

                        break;

}
                switch (Data[i].D25) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D25 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D25 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D25 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D25 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D25 + '</td>';

                        break;

}
                switch (Data[i].D26) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D26 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D26 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D26 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D26 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D26 + '</td>';

                        break;
}
                switch (Data[i].D27) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D27 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D27 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D27 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D27 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D27 + '</td>';

                        break;

}
                switch (Data[i].D28) {//dia 2
                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D28 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D28 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D28 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D28 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D28 + '</td>';

                        break;

}
                switch (Data[i].D29) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D29 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D29 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D29 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D29 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D29 + '</td>';

                        break;


}
                switch (Data[i].D30) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D30 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D30 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D30 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D30 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D30 + '</td>';

                        break;

}
                switch (Data[i].D31) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D31 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D31 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D31 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D31 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D31 + '</td>';

                        break;

}
}
                if (Treporte=='16'){
    Data[i].D1='0'; 
    Data[i].D2 = '0';
    Data[i].D3 = '0';
    Data[i].D4 = '0';
    Data[i].D5 = '0';
    Data[i].D6 = '0';
    Data[i].D7 = '0';
    Data[i].D8 = '0';
    Data[i].D9 = '0';
    Data[i].D10 = '0';
    Data[i].D11 = '0';
    Data[i].D12 = '0';
    Data[i].D13 = '0';
    Data[i].D14 = '0';
    Data[i].D15 = '0';

                switch (Data[i].D1) { // dia 1
              
                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D1 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D1 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D1 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D1 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D1 + '</td>';

                        break;
                   
}
                switch (Data[i].D2) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D2 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D2 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D2 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D2 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D2 + '</td>';

                        break;

}
                switch (Data[i].D3) {//dia 3

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D3 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D3 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D3 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D3 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D3 + '</td>';

                        break;

}
                switch (Data[i].D4) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D4 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D4 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D4 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D4 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D4 + '</td>';

                        break;

}
                switch (Data[i].D5) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D5 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D5 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D5 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D5 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D5 + '</td>';

                        break;

}
                switch (Data[i].D6) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D6 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D6 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D6 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D6 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D6 + '</td>';

                        break;

}
                switch (Data[i].D7) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D7 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D7 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D7 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D7 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D7 + '</td>';

                        break;

}
                switch (Data[i].D8) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D8 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D8 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D8 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D8 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D8 + '</td>';

                        break;

}
                switch (Data[i].D9) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D9 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D9 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D9 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D9 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D9 + '</td>';

                        break;

}               
                switch (Data[i].D10) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D10 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D10 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D10 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D10 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D10 + '</td>';

                        break;

}
                switch (Data[i].D11) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D11 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D11 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D11 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D11 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D11 + '</td>';

                        break;

}
                switch (Data[i].D12) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D12 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D12 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D12 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D12 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D12 + '</td>';

                        break;

}
                switch (Data[i].D13) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D13 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D13 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D13 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D13 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D13 + '</td>';

                        break;

}
                switch (Data[i].D14) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D14 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D14 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D14 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D14 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D14 + '</td>';

                        break;

}
                switch (Data[i].D15) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D15 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D15 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D15 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D15 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D15 + '</td>';

                        break;

}
                switch (Data[i].D16) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D16 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D16 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D16 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D16 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D16 + '</td>';

                        break;

}
                switch (Data[i].D17) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D17 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D17 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D17 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D17 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D17 + '</td>';

                        break;

}
                switch (Data[i].D18) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D18 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D18 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D18 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D18 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D18 + '</td>';

                        break;

}
                switch (Data[i].D19) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D19 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D19 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D19 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D19 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D19 + '</td>';

                        break;

}
                switch (Data[i].D20) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D20 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D20 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D20 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D20 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D20 + '</td>';

                        break;

}
                switch (Data[i].D21) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D21 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D21 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D21 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D21 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D21 + '</td>';

                        break;

}
                switch (Data[i].D22) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D22 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D22 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D22 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D22 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D22 + '</td>';

                        break;

}
                switch (Data[i].D23) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D23 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D23 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D23 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D23 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D23 + '</td>';

                        break;

}
                switch (Data[i].D24) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D24 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D24 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D24 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D24 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D24 + '</td>';

                        break;

}
                switch (Data[i].D25) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D25 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D25 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D25 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D25 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D25 + '</td>';

                        break;

}
                switch (Data[i].D26) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D26 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D26 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D26 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D26 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D26 + '</td>';

                        break;
}
                switch (Data[i].D27) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D27 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D27 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D27 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D27 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D27 + '</td>';

                        break;

}
                switch (Data[i].D28) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D28 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D28 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D28 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D28 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D28 + '</td>';

                        break;

}
                switch (Data[i].D29) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D29 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D29 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D29 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D29 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D29 + '</td>';

                        break;


}
                switch (Data[i].D30) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D30 + '</td>';
                        acu_falta = acu_falta + 1;
                        break;
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D30 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D30 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D30 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D30 + '</td>';

                        break;

}
                switch (Data[i].D31) {//dia 2

                    case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #FAA491;">' + Data[i].D31 + '</td>';
                        acu_falta = acu_falta + 1;
                        break
// NOTA: el "break" olvidado debería estar aquí
                    case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                        html += '<td style="background: #FAF891;">' + Data[i].D31 + '</td>';
                        Acu_Tarde = Acu_Tarde + 1;
                        break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                    case '1':
                        html += '<td>' + Data[i].D31 + '</td>';
                        Acu_Asis = Acu_Asis + 1;
                        break;
                    case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: orange;width:8px;">' + Data[i].D31 + '</td>';
                        acu_dom = acu_dom + 1;
                        break;
                    case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                        html += '<td style="background: #CDFAFC;">' + Data[i].D31 + '</td>';

                        break;

}
}
                //semana 1
                if (Treporte == '1') {
                  
                    Data[i].D8 = '0';
                    Data[i].D9 = '0';
                    Data[i].D10 = '0';
                    Data[i].D11 = '0';
                    Data[i].D12 = '0';
                    Data[i].D13 = '0';
                    Data[i].D14 = '0';
                    Data[i].D15 = '0';

                    Data[i].D16 = '0';
                    Data[i].D17 = '0';
                    Data[i].D18 = '0';
                    Data[i].D19 = '0';
                    Data[i].D20 = '0';
                    Data[i].D21 = '0';
                    Data[i].D22 = '0';
                    Data[i].D23 = '0';
                    Data[i].D24 = '0';
                    Data[i].D25 = '0';
                    Data[i].D26 = '0';
                    Data[i].D27 = '0';
                    Data[i].D28 = '0';
                    Data[i].D29 = '0';
                    Data[i].D30 = '0';
                    Data[i].D31 = '0';

                    switch (Data[i].D1) { // dia 1

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D1 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D1 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D1 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D1 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D1 + '</td>';

                            break;

                    }
                    switch (Data[i].D2) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D2 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D2 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D2 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D2 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D2 + '</td>';

                            break;

                    }
                    switch (Data[i].D3) {//dia 3

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D3 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D3 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D3 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D3 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D3 + '</td>';

                            break;

                    }
                    switch (Data[i].D4) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D4 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D4 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D4 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D4 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D4 + '</td>';

                            break;

                    }
                    switch (Data[i].D5) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D5 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D5 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D5 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D5 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D5 + '</td>';

                            break;

                    }
                    switch (Data[i].D6) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D6 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D6 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D6 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D6 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D6 + '</td>';

                            break;

                    }
                    switch (Data[i].D7) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D7 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D7 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D7 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D7 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D7 + '</td>';

                            break;

                    }
                    switch (Data[i].D8) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D8 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D8 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D8 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D8 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D8 + '</td>';

                            break;

                    }
                    switch (Data[i].D9) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D9 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D9 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D9 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D9 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D9 + '</td>';

                            break;

                    }
                    switch (Data[i].D10) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D10 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D10 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D10 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D10 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D10 + '</td>';

                            break;

                    }
                    switch (Data[i].D11) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D11 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D11 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D11 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D11 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D11 + '</td>';

                            break;

                    }
                    switch (Data[i].D12) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D12 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D12 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D12 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D12 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D12 + '</td>';

                            break;

                    }
                    switch (Data[i].D13) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D13 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D13 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D13 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D13 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D13 + '</td>';

                            break;

                    }
                    switch (Data[i].D14) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D14 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D14 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D14 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D14 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D14 + '</td>';

                            break;

                    }
                    switch (Data[i].D15) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D15 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D15 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D15 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D15 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D15 + '</td>';

                            break;

                    }
                    switch (Data[i].D16) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D16 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D16 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D16 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D16 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D16 + '</td>';

                            break;

                    }
                    switch (Data[i].D17) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D17 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D17 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D17 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D17 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D17 + '</td>';

                            break;

                    }
                    switch (Data[i].D18) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D18 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D18 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D18 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D18 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D18 + '</td>';

                            break;

                    }
                    switch (Data[i].D19) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D19 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D19 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D19 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D19 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D19 + '</td>';

                            break;

                    }
                    switch (Data[i].D20) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D20 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D20 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D20 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D20 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D20 + '</td>';

                            break;

                    }
                    switch (Data[i].D21) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D21 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D21 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D21 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D21 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D21 + '</td>';

                            break;

                    }
                    switch (Data[i].D22) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D22 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D22 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D22 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D22 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D22 + '</td>';

                            break;

                    }
                    switch (Data[i].D23) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D23 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D23 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D23 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D23 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D23 + '</td>';

                            break;

                    }
                    switch (Data[i].D24) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D24 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D24 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D24 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D24 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D24 + '</td>';

                            break;

                    }
                    switch (Data[i].D25) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D25 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D25 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D25 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D25 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D25 + '</td>';

                            break;

                    }
                    switch (Data[i].D26) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D26 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D26 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D26 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D26 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D26 + '</td>';

                            break;
                    }
                    switch (Data[i].D27) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D27 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D27 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D27 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D27 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D27 + '</td>';

                            break;

                    }
                    switch (Data[i].D28) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D28 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D28 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D28 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D28 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D28 + '</td>';

                            break;

                    }
                    switch (Data[i].D29) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D29 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D29 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D29 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D29 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D29 + '</td>';

                            break;


                    }
                    switch (Data[i].D30) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D30 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D30 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D30 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D30 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D30 + '</td>';

                            break;

                    }
                    switch (Data[i].D31) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D31 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D31 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D31 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D31 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D31 + '</td>';

                            break;

                    }
                }
                //semana 2
                if (Treporte == '2') {
                    Data[i].D1 = '0';
                    Data[i].D2 = '0';
                    Data[i].D3 = '0';
                    Data[i].D4 = '0';
                    Data[i].D5 = '0';
                    Data[i].D6 = '0';
                    Data[i].D7 = '0';
                    Data[i].D15 = '0';

                    Data[i].D16 = '0';
                    Data[i].D17 = '0';
                    Data[i].D18 = '0';
                    Data[i].D19 = '0';
                    Data[i].D20 = '0';
                    Data[i].D21 = '0';
                    Data[i].D22 = '0';
                    Data[i].D23 = '0';
                    Data[i].D24 = '0';
                    Data[i].D25 = '0';
                    Data[i].D26 = '0';
                    Data[i].D27 = '0';
                    Data[i].D28 = '0';
                    Data[i].D29 = '0';
                    Data[i].D30 = '0';
                    Data[i].D31 = '0';

                    switch (Data[i].D1) { // dia 1

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D1 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D1 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D1 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D1 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D1 + '</td>';

                            break;

                    }
                    switch (Data[i].D2) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D2 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D2 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D2 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D2 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D2 + '</td>';

                            break;

                    }
                    switch (Data[i].D3) {//dia 3

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D3 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D3 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D3 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D3 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D3 + '</td>';

                            break;

                    }
                    switch (Data[i].D4) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D4 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D4 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D4 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D4 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D4 + '</td>';

                            break;

                    }
                    switch (Data[i].D5) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D5 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D5 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D5 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D5 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D5 + '</td>';

                            break;

                    }
                    switch (Data[i].D6) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D6 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D6 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D6 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D6 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D6 + '</td>';

                            break;

                    }
                    switch (Data[i].D7) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D7 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D7 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D7 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D7 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D7 + '</td>';

                            break;

                    }
                    switch (Data[i].D8) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D8 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D8 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D8 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D8 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D8 + '</td>';

                            break;

                    }
                    switch (Data[i].D9) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D9 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D9 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D9 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D9 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D9 + '</td>';

                            break;

                    }
                    switch (Data[i].D10) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D10 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D10 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D10 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D10 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D10 + '</td>';

                            break;

                    }
                    switch (Data[i].D11) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D11 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D11 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D11 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D11 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D11 + '</td>';

                            break;

                    }
                    switch (Data[i].D12) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D12 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D12 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D12 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D12 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D12 + '</td>';

                            break;

                    }
                    switch (Data[i].D13) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D13 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D13 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D13 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D13 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D13 + '</td>';

                            break;

                    }
                    switch (Data[i].D14) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D14 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D14 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D14 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D14 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D14 + '</td>';

                            break;

                    }
                    switch (Data[i].D15) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D15 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D15 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D15 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D15 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D15 + '</td>';

                            break;

                    }
                    switch (Data[i].D16) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D16 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D16 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D16 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D16 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D16 + '</td>';

                            break;

                    }
                    switch (Data[i].D17) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D17 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D17 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D17 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D17 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D17 + '</td>';

                            break;

                    }
                    switch (Data[i].D18) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D18 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D18 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D18 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D18 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D18 + '</td>';

                            break;

                    }
                    switch (Data[i].D19) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D19 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D19 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D19 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D19 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D19 + '</td>';

                            break;

                    }
                    switch (Data[i].D20) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D20 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D20 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D20 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D20 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D20 + '</td>';

                            break;

                    }
                    switch (Data[i].D21) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D21 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D21 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D21 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D21 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D21 + '</td>';

                            break;

                    }
                    switch (Data[i].D22) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D22 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D22 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D22 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D22 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D22 + '</td>';

                            break;

                    }
                    switch (Data[i].D23) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D23 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D23 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D23 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D23 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D23 + '</td>';

                            break;

                    }
                    switch (Data[i].D24) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D24 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D24 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D24 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D24 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D24 + '</td>';

                            break;

                    }
                    switch (Data[i].D25) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D25 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D25 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D25 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D25 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D25 + '</td>';

                            break;

                    }
                    switch (Data[i].D26) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D26 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D26 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D26 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D26 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D26 + '</td>';

                            break;
                    }
                    switch (Data[i].D27) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D27 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D27 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D27 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D27 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D27 + '</td>';

                            break;

                    }
                    switch (Data[i].D28) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D28 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D28 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D28 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D28 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D28 + '</td>';

                            break;

                    }
                    switch (Data[i].D29) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D29 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D29 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D29 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D29 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D29 + '</td>';

                            break;


                    }
                    switch (Data[i].D30) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D30 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D30 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D30 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D30 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D30 + '</td>';

                            break;

                    }
                    switch (Data[i].D31) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D31 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D31 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D31 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D31 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D31 + '</td>';

                            break;

                    }
                }
                //semana 3

                if (Treporte == '3') {
                    Data[i].D1 = '0';
                    Data[i].D2 = '0';
                    Data[i].D3 = '0';
                    Data[i].D4 = '0';
                    Data[i].D5 = '0';
                    Data[i].D6 = '0';
                    Data[i].D7 = '0';
                    Data[i].D8 = '0';
                    Data[i].D9 = '0';
                    Data[i].D10 = '0';
                    Data[i].D11 = '0';
                    Data[i].D12 = '0';
                    Data[i].D13 = '0';
                    Data[i].D14 = '0';
                    
                    Data[i].D22 = '0';
                    Data[i].D23 = '0';
                    Data[i].D24 = '0';
                    Data[i].D25 = '0';
                    Data[i].D26 = '0';
                    Data[i].D27 = '0';
                    Data[i].D28 = '0';
                    Data[i].D29 = '0';
                    Data[i].D30 = '0';
                    Data[i].D31 = '0';

                    switch (Data[i].D1) { // dia 1

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D1 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D1 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D1 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D1 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D1 + '</td>';

                            break;

                    }
                    switch (Data[i].D2) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D2 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D2 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D2 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D2 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D2 + '</td>';

                            break;

                    }
                    switch (Data[i].D3) {//dia 3

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D3 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D3 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D3 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D3 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D3 + '</td>';

                            break;

                    }
                    switch (Data[i].D4) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D4 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D4 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D4 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D4 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D4 + '</td>';

                            break;

                    }
                    switch (Data[i].D5) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D5 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D5 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D5 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D5 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D5 + '</td>';

                            break;

                    }
                    switch (Data[i].D6) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D6 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D6 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D6 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D6 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D6 + '</td>';

                            break;

                    }
                    switch (Data[i].D7) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D7 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D7 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D7 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D7 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D7 + '</td>';

                            break;

                    }
                    switch (Data[i].D8) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D8 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D8 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D8 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D8 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D8 + '</td>';

                            break;

                    }
                    switch (Data[i].D9) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D9 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D9 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D9 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D9 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D9 + '</td>';

                            break;

                    }
                    switch (Data[i].D10) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D10 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D10 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D10 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D10 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D10 + '</td>';

                            break;

                    }
                    switch (Data[i].D11) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D11 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D11 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D11 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D11 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D11 + '</td>';

                            break;

                    }
                    switch (Data[i].D12) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D12 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D12 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D12 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D12 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D12 + '</td>';

                            break;

                    }
                    switch (Data[i].D13) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D13 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D13 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D13 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D13 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D13 + '</td>';

                            break;

                    }
                    switch (Data[i].D14) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D14 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D14 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D14 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D14 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D14 + '</td>';

                            break;

                    }
                    switch (Data[i].D15) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D15 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D15 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D15 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D15 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D15 + '</td>';

                            break;

                    }
                    switch (Data[i].D16) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D16 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D16 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D16 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D16 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D16 + '</td>';

                            break;

                    }
                    switch (Data[i].D17) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D17 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D17 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D17 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D17 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D17 + '</td>';

                            break;

                    }
                    switch (Data[i].D18) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D18 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D18 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D18 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D18 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D18 + '</td>';

                            break;

                    }
                    switch (Data[i].D19) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D19 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D19 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D19 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D19 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D19 + '</td>';

                            break;

                    }
                    switch (Data[i].D20) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D20 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D20 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D20 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D20 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D20 + '</td>';

                            break;

                    }
                    switch (Data[i].D21) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D21 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D21 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D21 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D21 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D21 + '</td>';

                            break;

                    }
                    switch (Data[i].D22) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D22 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D22 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D22 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D22 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D22 + '</td>';

                            break;

                    }
                    switch (Data[i].D23) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D23 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D23 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D23 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D23 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D23 + '</td>';

                            break;

                    }
                    switch (Data[i].D24) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D24 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D24 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D24 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D24 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D24 + '</td>';

                            break;

                    }
                    switch (Data[i].D25) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D25 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D25 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D25 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D25 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D25 + '</td>';

                            break;

                    }
                    switch (Data[i].D26) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D26 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D26 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D26 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D26 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D26 + '</td>';

                            break;
                    }
                    switch (Data[i].D27) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D27 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D27 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D27 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D27 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D27 + '</td>';

                            break;

                    }
                    switch (Data[i].D28) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D28 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D28 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D28 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D28 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D28 + '</td>';

                            break;

                    }
                    switch (Data[i].D29) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D29 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D29 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D29 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D29 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D29 + '</td>';

                            break;


                    }
                    switch (Data[i].D30) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D30 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D30 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D30 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D30 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D30 + '</td>';

                            break;

                    }
                    switch (Data[i].D31) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D31 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D31 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D31 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D31 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D31 + '</td>';

                            break;

                    }
                }

                //semana 4

                if (Treporte == '4') {
                    Data[i].D1 = '0';
                    Data[i].D2 = '0';
                    Data[i].D3 = '0';
                    Data[i].D4 = '0';
                    Data[i].D5 = '0';
                    Data[i].D6 = '0';
                    Data[i].D7 = '0';
                    Data[i].D8 = '0';
                    Data[i].D9 = '0';
                    Data[i].D10 = '0';
                    Data[i].D11 = '0';
                    Data[i].D12 = '0';
                    Data[i].D13 = '0';
                    Data[i].D14 = '0';
                    Data[i].D15 = '0';

                    Data[i].D16 = '0';
                    Data[i].D17 = '0';
                    Data[i].D18 = '0';
                    Data[i].D19 = '0';
                    Data[i].D20 = '0';
                    
                    Data[i].D29 = '0';
                    Data[i].D30 = '0';
                    Data[i].D31 = '0';

                    switch (Data[i].D1) { // dia 1

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D1 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D1 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D1 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D1 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D1 + '</td>';

                            break;

                    }
                    switch (Data[i].D2) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D2 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D2 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D2 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D2 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D2 + '</td>';

                            break;

                    }
                    switch (Data[i].D3) {//dia 3

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D3 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D3 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D3 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D3 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D3 + '</td>';

                            break;

                    }
                    switch (Data[i].D4) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D4 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D4 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D4 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D4 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D4 + '</td>';

                            break;

                    }
                    switch (Data[i].D5) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D5 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D5 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D5 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D5 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D5 + '</td>';

                            break;

                    }
                    switch (Data[i].D6) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D6 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D6 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D6 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D6 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D6 + '</td>';

                            break;

                    }
                    switch (Data[i].D7) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D7 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D7 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D7 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D7 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D7 + '</td>';

                            break;

                    }
                    switch (Data[i].D8) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D8 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D8 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D8 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D8 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D8 + '</td>';

                            break;

                    }
                    switch (Data[i].D9) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D9 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D9 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D9 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D9 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D9 + '</td>';

                            break;

                    }
                    switch (Data[i].D10) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D10 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D10 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D10 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D10 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D10 + '</td>';

                            break;

                    }
                    switch (Data[i].D11) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D11 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D11 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D11 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D11 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D11 + '</td>';

                            break;

                    }
                    switch (Data[i].D12) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D12 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D12 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D12 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D12 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D12 + '</td>';

                            break;

                    }
                    switch (Data[i].D13) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D13 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D13 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D13 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D13 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D13 + '</td>';

                            break;

                    }
                    switch (Data[i].D14) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D14 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D14 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D14 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D14 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D14 + '</td>';

                            break;

                    }
                    switch (Data[i].D15) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D15 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D15 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D15 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D15 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D15 + '</td>';

                            break;

                    }
                    switch (Data[i].D16) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D16 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D16 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D16 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D16 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D16 + '</td>';

                            break;

                    }
                    switch (Data[i].D17) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D17 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D17 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D17 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D17 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D17 + '</td>';

                            break;

                    }
                    switch (Data[i].D18) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D18 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D18 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D18 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D18 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D18 + '</td>';

                            break;

                    }
                    switch (Data[i].D19) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D19 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D19 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D19 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D19 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D19 + '</td>';

                            break;

                    }
                    switch (Data[i].D20) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D20 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D20 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D20 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D20 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D20 + '</td>';

                            break;

                    }
                    switch (Data[i].D21) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D21 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D21 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D21 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D21 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D21 + '</td>';

                            break;

                    }
                    switch (Data[i].D22) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D22 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D22 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D22 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D22 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D22 + '</td>';

                            break;

                    }
                    switch (Data[i].D23) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D23 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D23 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D23 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D23 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D23 + '</td>';

                            break;

                    }
                    switch (Data[i].D24) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D24 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D24 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D24 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D24 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D24 + '</td>';

                            break;

                    }
                    switch (Data[i].D25) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D25 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D25 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D25 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D25 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D25 + '</td>';

                            break;

                    }
                    switch (Data[i].D26) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D26 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D26 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D26 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D26 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D26 + '</td>';

                            break;
                    }
                    switch (Data[i].D27) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D27 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D27 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D27 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D27 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D27 + '</td>';

                            break;

                    }
                    switch (Data[i].D28) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D28 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D28 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D28 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D28 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D28 + '</td>';

                            break;

                    }
                    switch (Data[i].D29) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D29 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D29 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D29 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D29 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D29 + '</td>';

                            break;


                    }
                    switch (Data[i].D30) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D30 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D30 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D30 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D30 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D30 + '</td>';

                            break;

                    }
                    switch (Data[i].D31) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D31 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D31 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D31 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D31 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D31 + '</td>';

                            break;

                    }
                }
                // semana 5

                if (Treporte == '5') {
                    Data[i].D1 = '0';
                    Data[i].D2 = '0';
                    Data[i].D3 = '0';
                    Data[i].D4 = '0';
                    Data[i].D5 = '0';
                    Data[i].D6 = '0';
                    Data[i].D7 = '0';
                    Data[i].D8 = '0';
                    Data[i].D9 = '0';
                    Data[i].D10 = '0';
                    Data[i].D11 = '0';
                    Data[i].D12 = '0';
                    Data[i].D13 = '0';
                    Data[i].D14 = '0';
                    Data[i].D15 = '0';

                    Data[i].D16 = '0';
                    Data[i].D17 = '0';
                    Data[i].D18 = '0';
                    Data[i].D19 = '0';
                    Data[i].D20 = '0';
                    Data[i].D21 = '0';
                    Data[i].D22 = '0';
                    Data[i].D23 = '0';
                    Data[i].D24 = '0';
                    Data[i].D25 = '0';
                    Data[i].D26 = '0';
                    Data[i].D27 = '0';
                    Data[i].D28 = '0';
                   

                    switch (Data[i].D1) { // dia 1

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D1 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D1 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D1 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D1 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D1 + '</td>';

                            break;

                    }
                    switch (Data[i].D2) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D2 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D2 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D2 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D2 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D2 + '</td>';

                            break;

                    }
                    switch (Data[i].D3) {//dia 3

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D3 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D3 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D3 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D3 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D3 + '</td>';

                            break;

                    }
                    switch (Data[i].D4) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D4 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D4 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D4 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D4 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D4 + '</td>';

                            break;

                    }
                    switch (Data[i].D5) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D5 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D5 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D5 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D5 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D5 + '</td>';

                            break;

                    }
                    switch (Data[i].D6) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D6 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D6 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D6 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D6 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D6 + '</td>';

                            break;

                    }
                    switch (Data[i].D7) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D7 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D7 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D7 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D7 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D7 + '</td>';

                            break;

                    }
                    switch (Data[i].D8) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D8 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D8 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D8 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D8 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D8 + '</td>';

                            break;

                    }
                    switch (Data[i].D9) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D9 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D9 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D9 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D9 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D9 + '</td>';

                            break;

                    }
                    switch (Data[i].D10) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D10 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D10 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D10 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D10 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D10 + '</td>';

                            break;

                    }
                    switch (Data[i].D11) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D11 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D11 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D11 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D11 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D11 + '</td>';

                            break;

                    }
                    switch (Data[i].D12) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D12 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D12 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D12 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D12 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D12 + '</td>';

                            break;

                    }
                    switch (Data[i].D13) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D13 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D13 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D13 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D13 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D13 + '</td>';

                            break;

                    }
                    switch (Data[i].D14) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D14 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D14 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D14 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D14 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D14 + '</td>';

                            break;

                    }
                    switch (Data[i].D15) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D15 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D15 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D15 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D15 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D15 + '</td>';

                            break;

                    }
                    switch (Data[i].D16) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D16 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D16 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D16 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D16 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D16 + '</td>';

                            break;

                    }
                    switch (Data[i].D17) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D17 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D17 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D17 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D17 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D17 + '</td>';

                            break;

                    }
                    switch (Data[i].D18) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D18 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D18 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D18 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D18 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D18 + '</td>';

                            break;

                    }
                    switch (Data[i].D19) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D19 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D19 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D19 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D19 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D19 + '</td>';

                            break;

                    }
                    switch (Data[i].D20) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D20 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D20 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D20 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D20 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D20 + '</td>';

                            break;

                    }
                    switch (Data[i].D21) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D21 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D21 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D21 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D21 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D21 + '</td>';

                            break;

                    }
                    switch (Data[i].D22) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D22 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D22 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D22 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D22 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D22 + '</td>';

                            break;

                    }
                    switch (Data[i].D23) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D23 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D23 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D23 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D23 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D23 + '</td>';

                            break;

                    }
                    switch (Data[i].D24) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D24 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D24 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D24 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D24 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D24 + '</td>';

                            break;

                    }
                    switch (Data[i].D25) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D25 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D25 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D25 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D25 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D25 + '</td>';

                            break;

                    }
                    switch (Data[i].D26) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D26 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D26 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D26 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D26 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D26 + '</td>';

                            break;
                    }
                    switch (Data[i].D27) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D27 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D27 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D27 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D27 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D27 + '</td>';

                            break;

                    }
                    switch (Data[i].D28) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D28 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D28 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D28 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D28 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D28 + '</td>';

                            break;

                    }
                    switch (Data[i].D29) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D29 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D29 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D29 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D29 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D29 + '</td>';

                            break;


                    }
                    switch (Data[i].D30) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D30 + '</td>';
                            acu_falta = acu_falta + 1;
                            break;
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D30 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D30 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D30 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D30 + '</td>';

                            break;

                    }
                    switch (Data[i].D31) {//dia 2

                        case 'F': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #FAA491;">' + Data[i].D31 + '</td>';
                            acu_falta = acu_falta + 1;
                            break
                            // NOTA: el "break" olvidado debería estar aquí
                        case 'T': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
                            html += '<td style="background: #FAF891;">' + Data[i].D31 + '</td>';
                            Acu_Tarde = Acu_Tarde + 1;
                            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
                        case '1':
                            html += '<td>' + Data[i].D31 + '</td>';
                            Acu_Asis = Acu_Asis + 1;
                            break;
                        case 'D': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: orange;width:8px;">' + Data[i].D31 + '</td>';
                            acu_dom = acu_dom + 1;
                            break;
                        case '0': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
                            html += '<td style="background: #CDFAFC;">' + Data[i].D31 + '</td>';

                            break;

                    }
                }


              
                html += '<td style="text-align:center;">' + Data[i].TotHE + '</td>';

                html += '<td style="text-align:center;">' + Data[i].TotHESimpl + '</td>';
                html += '<td style="text-align:center;">' + Data[i].TotHEAdi + '</td>';
                html += '<td style="text-align:center;">' + Data[i].TotHEDob + '</td>';
                html += '<td style="text-align:center;">' + Data[i].DiasPer + '</td>';
                html += '<td style="text-align:center;">' + Data[i].HorasPer + '</td>';

                html += '<td>' + Acu_Asis + '</td>';
                html += '<td style="text-align:center;">' + Data[i].DiasPer_DesMed + '</td>';
 
                html += '<td>' + acu_dom + '</td>';
              
                asistencia = ((parseInt(Acu_Asis) + parseInt(acu_dom) + parseInt(Acu_Tarde) + parseInt(Data[i].DiasPer_Vac) + parseInt(Data[i].DiasPer_DesMed)));
                html += '<td>' +asistencia  + '</td>';
                html += '<td style="text-align:center;">' + Data[i].DiasPer_Vac + '</td>';
                html += '<td>' + acu_falta + '</td>';
                html += '<td>' + Acu_Tarde + '</td>';
                if (parseInt(asistencia) > parseInt(acu_falta)) {
                    html += '<td>' + (parseInt(asistencia) - parseInt(acu_falta)) + '</td>';
} else {
                    html += '<td>' + (parseInt(asistencia) + parseInt(acu_falta)) + '</td>';
}
              
                html += '<td>' + (parseInt(asistencia) + parseInt(acu_falta)) + '</td>';
 
              
                html += '</tr>';

                $(html).appendTo('#tbodyNovedades');
}
},
error:
   function (XmlHttpError, error, description) {
    $('#dialog-form').html(XmlHttpError.responseText);
},
async: false
});
};


//lista nuevo


function Get_Planilla_List() {
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "cReporteGeneral.aspx/Get_Planilla_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboPlanilla').html('');
            for (var i = 0; i <= lengthd; i++) {
                if (NivelAcceso_Proc != "04") {
                    $('<option value="' + Data[i].Planilla_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboPlanilla');
                }
                else {
                    if (Data[i].Planilla_Id == Planilla_Id_Proc) {
                        $('<option value="' + Data[i].Planilla_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboPlanilla');
                        break;
                    }
                }
            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#divError').html(XmlHttpError.responseText);
   },
        async: false
    });

};

function Get_Periodo_Activo_By_CA(Planilla_Id) {
    var params = {
        Planilla_Id: Planilla_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "cReporteGeneral.aspx/Get_Periodo_Activo_By_CA",
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
        url: "cReporteGeneral.aspx/Get_Localidad_List_New",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboLocalidad').html('');
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Area_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboLocalidad');
            }
            if (NivelAcceso_Proc != "04") {
                $('<option value="">-TODOS-</option>').appendTo('#cboLocalidad');
                $('#cboLocalidad').val('');
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
    var Personal_Id = Personal_Proc;
    var params = {
        Personal_Id: Personal_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "cReporteGeneral.aspx/Get_Categoria_Auxiliar_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboCategoriaAux').html('');
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Categoria_Auxiliar_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboCategoriaAux');
            }
            if (NivelAcceso_Proc != "04") {
                $('<option value="">-TODOS-</option>').appendTo('#cboCategoriaAux');
                $('#cboCategoriaAux').val('');
            }

        },
        error:
   function (XmlHttpError, error, description) {
       $('#divError').html(XmlHttpError.responseText);
   },
        async: false
    });
};

function Get_Categoria_Auxiliar2_List(Cat_Aux) {
    var Personal_Id = Personal_Proc;
    var params = {
        Cat_Aux: Cat_Aux
        , Personal_Id: Personal_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "cReporteGeneral.aspx/Get_Categoria_Auxiliar2_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboCategoriaAux2').html('');
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Categoria_Auxiliar2_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboCategoriaAux2');
            }
            if (NivelAcceso_Proc != "04") {
                $('<option value="">-TODOS-</option>').appendTo('#cboCategoriaAux2');
                $('#cboCategoriaAux2').val('');
            }
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
        url: "cReporteGeneral.aspx/Get_Categoria_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboCategoria').html('');
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Categoria2_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboCategoria');
            }
            $('<option value="" selected>-TODOS-</option>').appendTo('#cboCategoria');
            if (NivelAcceso_Proc != "04") {
                $('#cboCategoria').val('');
            }
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
        url: "cReporteGeneral.aspx/Get_PeriodoCA_By_Planilla",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            for (var i = 0; i <= lengthd; i++) {

                $("#txtFechaInicio").datepicker("setDate", formatFecha.dmy(Data[0].Date_Inicio.toDateFormat()));
                $("#txtFechaFinal").datepicker("setDate", formatFecha.dmy(Data[0].Date_Fin.toDateFormat()));


            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#divError').html(XmlHttpError.responseText);
   },
        async: false
    });

};

function Get_Personal_By_Filtros(Periodo_Id, Localidad_Id, CategoriaAux, CategoriaAux2, Categoria) {
    var Personal_Id = Personal_Proc;
    var params = {
        Periodo_Id: Periodo_Id,
        Localidad_Id: Localidad_Id,
        CategoriaAux: CategoriaAux,
        CategoriaAux2: CategoriaAux2,
        Categoria: Categoria
        , Personal_Id: Personal_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "cReporteGeneral.aspx/Get_Personal_By_Filtros",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboPersonal').html('');
            PersonalSelec = [];
            PersonalSelecbk=[];
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Personal_Id + '">' + Data[i].PersonalName + '</option>').appendTo('#cboPersonal');
                PersonalSelec.push(Data[i].Personal_Id);
                PersonalSelecbk.push(Data[i].Personal_Id);
            }
            if (NivelAcceso_Proc != "04") {
                $('<option value="">-TODOS-</option>').appendTo('#cboPersonal');
                $('#cboPersonal').val('');
            } else {
                $('<option value="--">-SELECCIONAR-</option>').appendTo('#cboPersonal');
                $('#cboPersonal').val('--');
            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#divError').html(XmlHttpError.responseText);
   },
        async: false
    });

};

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


function CrearCuadroFechas() {
    $('#txtFechaInicio').datepicker({
        monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
		    'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
        monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun',
		        'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
        dayNames: ['Domingo', 'Lunes', 'Martes', 'Mi&eacute;rcoles', 'Jueves', 'Viernes', 'S&aacute;bado'],
        dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mi&eacute;', 'Juv', 'Vie', 'S&aacute;b'],
        dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'S&aacute;'],
        dateFormat: 'dd/mm/yy',
        isRTL: false

    });

    $('#txtFechaFinal').datepicker({
        monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
		    'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
        monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun',
		        'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
        dayNames: ['Domingo', 'Lunes', 'Martes', 'Mi&eacute;rcoles', 'Jueves', 'Viernes', 'S&aacute;bado'],
        dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mi&eacute;', 'Juv', 'Vie', 'S&aacute;b'],
        dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'S&aacute;'],
        dateFormat: 'dd/mm/yy',
        isRTL: false
    });
};


String.prototype.toDateFormat = function () {

    if (this) {
        var dte = eval("new " + this.replace(/\//g, '') + ";");

        dte.setMinutes(dte.getMinutes() - dte.getTimezoneOffset());
        //  dateFormat(dte, "yyyy-MM-dd HH:mm:ss");
        var ret = dateTransform(dte);
        //return dte;
        return ret;
    } else {
        return '';
    }
};

function dateTransform(fecha) {
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
        for (var i = 0; i < (length - this.length) ; i++)
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
                arr = arr1.split('/');
                return arr[2] + '/' + arr[1] + '/' + arr[0];
            } else if (fecha.indexOf('-') != -1) {
                arr = arr1.split('-');
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
    }

};

function Get_semana_List() {
    $.ajax({
        type: "POST",
        data: JSON.stringify(),
        dataType: "json",
        url: "CaReporteDiario.aspx/ListaSemana",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            $('#cbosemana').html('');
            var lengthDatos = Data.length - 1;
            $('<option value="">-SELECCIONAR-</option>').appendTo('#cbosemana');
            $("#cbosemana > option[value='']").attr("selected", true);
            for (var i = 0; i <= lengthDatos; i++) {
                var html = '<option value="' + Data[i].id + '">' + Data[i].semana + '</option>';
                $(html).appendTo('#cbosemana');
            }

        },
        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: true
    });
}


