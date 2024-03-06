
var cargarPagina = function (intPaginaP, pagina_ultima) {
	//evaluar si la pagina a cargar es mayor que el numero de paginas o es menor que 1
	if(intPaginaP < 1){intPaginaP = 1;}
	if(intPaginaP > pagina_ultima){intPaginaP = pagina_ultima;}
	//ocultar todas las lineas
	$("#tblAH>tbody>tr").addClass("linea-oculta");
	var primer_registro = (intPaginaP - 1) * resultados_por_pagina;
	for (var i = primer_registro; i < (primer_registro + resultados_por_pagina); i++){
		$("#tblAH>tbody>tr").eq(i).removeClass("linea-oculta");
	}
	//indicar en qué pagina estamos
	pagina_actual = intPaginaP;
	$("#indicador_paginas").html("Página: " + pagina_actual + " / " + pagina_ultima);
}



var cargarPaginaNueva = function (intPaginaP, pagina_ultima, tbody, resultados_por_pagina) {
    //evaluar si la pagina a cargar es mayor que el numero de paginas o es menor que 1
    if (intPaginaP < 1) { intPaginaP = 1; }
    if (intPaginaP > pagina_ultima) { intPaginaP = pagina_ultima; }
    //ocultar todas las lineas
    $("#" + tbody + ">tbody>tr").addClass("linea-oculta");
    var primer_registro = (intPaginaP - 1) * resultados_por_pagina;
    for (var i = primer_registro; i < (primer_registro + resultados_por_pagina) ; i++) {
        $("#" + tbody + ">tbody>tr").eq(i).removeClass("linea-oculta");
    }
    //indicar en qué pagina estamos
    pagina_actual = intPaginaP;
    $("#indicador_paginas").html("Página: " + pagina_actual + " / " + pagina_ultima);
}