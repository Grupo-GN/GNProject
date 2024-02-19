function Get_DatosUsuario_Logeo(Personal_Id) {
    var params = {
        Personal_Id: Personal_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "Helpert.aspx/Get_DatosUsuario_Logeo",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var PersonalLogin = response.d;
            if (PersonalLogin) {
                Session.set('UsuarioSistema', PersonalLogin);
                $('#lblUsuarioGlobal').html(PersonalLogin.PersonalNombres);
            } else {
                setTimeout("location.href='Views/Login/Login.aspx'", 250);
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: false
    });
};
function Get_ValidarDatosUsuario_Logeo(Personal_Id) {
    var params = {
        Personal_Id: Personal_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "Helpert.aspx/Get_ValidarDatosUsuario_Logeo",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var PersonalLogin = response.d;
            if (window.location.href.indexOf('Matenimientos/CambiarClave.aspx') == -1) {
                if (PersonalLogin.split('#')[0] == 'true') {
                    alert(PersonalLogin.split('#')[1]);
                    setTimeout("location.href='../Matenimientos/CambiarClave.aspx'", 250);
                }
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: true
    });
};




//funcion nueva
function RR() {
    if ($.browser.msie && $.browser.version.substr(0, 1) < 7) {
        $('li').has('ul')
            .mouseover(function () {
                $(this).children('ul').css('visibility', 'visible');
            })
            .mouseout(function () {
                $(this).children('ul').css('visibility', 'hidden');
            })
    }
}

// Utilities functions
function SelectAllCheckBoxes(CheckBoxControl, GridName) {
    if (CheckBoxControl.checked == true) {
        var i;
        for (i = 0; i < document.forms[0].elements.length; i++) {
            if ((document.forms[0].elements[i].type == 'checkbox') &&
                (document.forms[0].elements[i].name.indexOf(GridName) > -1)) {
                document.forms[0].elements[i].checked = true;
            }
        }
    }
    else {
        var i;
        for (i = 0; i < document.forms[0].elements.length; i++) {
            if ((document.forms[0].elements[i].type == 'checkbox') &&
                (document.forms[0].elements[i].name.indexOf(GridName) > -1)) {
                document.forms[0].elements[i].checked = false;
            }
        }
    }
}
