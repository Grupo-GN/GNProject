function fnClickPostBack(sender, e) {
    __doPostBack(sender, e);
}

/*Mueve el Scroll de la Cabecera*/
function Onscrollfunction(DataDiv, HeaderDiv) {
    var div = document.getElementById(DataDiv);
    var div2 = document.getElementById(HeaderDiv);
    //****** Scrolling HeaderDiv along with DataDiv ******
    div2.scrollLeft = div.scrollLeft;
    return false;
}

/*Cambiar de Index a un TabContainer*/
function fc_SetActiveTabIndex(tabContainer_ClientID, tabNumber) {
    //$find('<%=TabContainer1.ClientID%>').set_activeTabIndex(0);
    var tabContainer = $find(tabContainer_ClientID);
    tabContainer.set_activeTabIndex(tabNumber);
}

//Validaciones
function SoloNumeros(e) {
    var key;
    if (window.event) // IE
    {
        key = e.keyCode;
    }
    else if (e.which) // Netscape/Firefox/Opera
    {
        key = e.which;
    }
    if (key < 48 || key > 57) {
        return false;
    }
    return true;
}

function SoloDecimales(e) {
    var key;
    if (window.event) // IE
    {
        key = e.keyCode;
    }
    else if (e.which) // Netscape/Firefox/Opera
    {
        key = e.which;
    }
    if (key > 31 && (key < 48 || key > 57) && key != 46) {
        return false;
    }
    var parts = e.srcElement.value.split('.');
    if (parts.length > 2) return false;
    if (key == 46) return (parts.length == 1);
    /*parts[0].length => Cantidad de caracteres ántes del punto*/
    /*parts[1].length => Cantidad de caracteres después del punto*/
    /*if (parts[0].length >= 5) return false;*/
    if (parts.length == 2 && parts[1].length >= 4) return false;
    return true;
}


function ValidaFecha(oSrc, args) {
    var iDay, iMonth, iYear;
    var arrValues;
    arrValues = args.Value.split("/");
    iMonth = arrValues[1];
    iDay = arrValues[0];
    iYear = arrValues[2];

    var testDate = new Date(iYear, iMonth - 1, iDay);
    if ((testDate.getDate() != iDay) ||
      (testDate.getMonth() != iMonth - 1) ||
      (testDate.getFullYear() != iYear)) {
        args.IsValid = false;
        return;
    }

    return true;
}

function fc_Trim(pstrInput) {
/*************************************************************************************
Modulo 		:    
Descripción :    Función que quita los espacios en blanco del parametro string
Inputs		:
Autor 		:	 Frank Pumaylle Saire
Fecha/hora	:    31/06/2012 11:00
Empresa		:    
Notas		:    
*************************************************************************************/
    var i;
    var vstrTemp = '';
    var j = 0;
    var cadena = pstrInput;

    for (i = 0; i < cadena.length; ) {
        if (cadena.charAt(i) == " ")
            cadena = cadena.substring(i + 1, cadena.length);
        else
            break;
    }

    for (i = cadena.length - 1; i >= 0; i = cadena.length - 1) {
        if (cadena.charAt(i) == " ")
            cadena = cadena.substring(0, i);
        else
            break;
    }
    /*if (pstrInput=='' || pstrInput.length <1){return ''} 

	for (i=0;i<pstrInput.length;i++)
    {
    vstrTemp = pstrInput.substr(i,1);
    if(vstrTemp==' '){j++}
    else{break}
    }
	
	if (j==pstrInput.length){return ''}
    if (j>0){vstrOut = pstrInput.substring(j, pstrInput.length-1)}
    j=0;
    for (i=vstrOut.length-1;i>=0;i--)
    {
    vstrTemp = vstrOut.substr(i,1);
    if(vstrTemp==' '){j++}
    else{break}
    }
    if (j>0){vstrOut = vstrOut.substring(0, vstrOut.length - j++)}
    */
    return cadena;
}

function fc_ValidaLongitudRuc(strNameObj) {
    /*************************************************************************************
    Descripcion : Valida que la longitud del Ruc sea 11 digitos
    Autor		: Frank Pumaylle Saire
    Fecha/hora	: 31/06/2012 11:00
    Empresa		: 
    *************************************************************************************/

    Obj = document.all[strNameObj];
    var cad = Obj.value;

    if (cad != "") {
        if (cad.length < 11) {
            alert("La longitud del Nro Ruc es menor a 11");
            Obj.value = "";
            Obj.focus();
        }
    }
}

function fc_ValidaLongitudDNI(strNameObj) {
    /*************************************************************************************
    Descripcion : Valida que la longitud del Ruc sea 11 digitos
    Autor		: Frank Pumaylle Saire
    Fecha/hora	: 31/06/2012 11:00
    Empresa		: 
    *************************************************************************************/

    Obj = document.all[strNameObj];
    var cad = Obj.value;

    if (cad != "") {
        if (cad.length < 8 | cad.length > 8) {
            alert("Longitud del Nro DNI erronea");
            Obj.value = "";
            Obj.focus();
        }

    }
}

/*Mueve el Scroll de la Cabecera*/
function Onscrollfunction(DataDiv, HeaderDiv) {
    var div = document.getElementById(DataDiv);
    var div2 = document.getElementById(HeaderDiv);
    //****** Scrolling HeaderDiv along with DataDiv ******
    div2.scrollLeft = div.scrollLeft;
    return false;
}

/*Selecciona todos los CheckBox de un GridView*/
function SelectAllCheckBoxes(CheckBoxControl, GridName) {
    if (CheckBoxControl.checked == true) {
        var i;
        /*Agregado por FPS*/
        var filas = 0;
        /*----------------*/
        for (i = 0; i < document.forms[0].elements.length; i++) {
            if ((document.forms[0].elements[i].type == 'checkbox') &&
            (document.forms[0].elements[i].name.indexOf(GridName) > -1)) {
                document.forms[0].elements[i].checked = true;
                /*Agregado por FPS*/
                filas = filas + 1;
                /*----------------*/
            }
        }
        /*Agregado por FPS*/
        if (filas == 0) {
            alert('No Se Encontro Ningún Registro.');
            CheckBoxControl.checked = false;
        }
        /*----------------*/
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