var tableToExcel = (function () {
    var uri = 'data:application/vnd.ms-excel;base64,'
    , template = '<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40"><head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head><body><table>{table}</table></body></html>'
    , base64 = function (s) { return window.btoa(unescape(encodeURIComponent(s))) }
    , format = function (s, c) { return s.replace(/{(\w+)}/g, function (m, p) { return c[p]; }) }
    return function (table, name) {
        if (!table.nodeType) table = document.getElementById(table)
        var html = acuteHTML(table.innerHTML);          
        var ctx = { worksheet: name || 'Worksheet', table: html }
        window.location.href = uri + base64(format(template, ctx))
    }
})()

function acuteHTML(html) {
    while (html.indexOf('á')!=-1) {
        html = html.replace('á', '&aacute;');
    }
    while (html.indexOf('é') != -1) {
        html = html.replace('é', '&eacute;');
    }
    while (html.indexOf('í') != -1) {
        html = html.replace('í', '&iacute;');
    }
    while (html.indexOf('ó') != -1) {
        html = html.replace('ó', '&oacute;');
    }
    while (html.indexOf('ú') != -1) {
        html = html.replace('ú', '&uacute;');
    }
    while (html.indexOf('Á') != -1) {
        html = html.replace('Á', '&Aacute;');
    }
    while (html.indexOf('É') != -1) {
        html = html.replace('É', '&Eacute;');
    }
    while (html.indexOf('Í') != -1) {
        html = html.replace('Í', '&Iacute;');
    }
    while (html.indexOf('Ó') != -1) {
        html = html.replace('Ó', '&Oacute;');
    }
    while (html.indexOf('Ú') != -1) {
        html = html.replace('Ú', '&Uacute;');
    }
    while (html.indexOf('ñ') != -1) {
        html = html.replace('ñ', '&ntilde;');
    }
    while (html.indexOf('Ñ') != -1) {
        html = html.replace('Ñ', '&Ntilde;');
    }
	while (html.indexOf('°') != -1) {
        html = html.replace('°', '&deg;');
    }
    return html;
};