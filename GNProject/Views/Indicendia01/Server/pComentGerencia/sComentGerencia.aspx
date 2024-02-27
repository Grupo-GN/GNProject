<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sComentGerencia.aspx.cs" Inherits="GNProject.Views.Indicendia01.Server.pComentGerencia.sComentGerencia" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />
</head>
<body>
<label class="miLabel">Mi Comentario:</label><br />
<textarea class="txt" rows="3" cols="50" maxlength="500" id="txtComentario"></textarea>
<label class="labelError">&nbsp;&nbsp;</label><br />
<input type="button" class="submit" id="btnGuardar" value="Comentar" /> <input type="button" class="submit" id="btnClear" value="Limpiar" />
    
    <script src="../../jquery1.10/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="Script_ComentGerencia.js" type="text/javascript"></script>
    <script type="text/javascript">
        var Incidencia_Id = getParameterByName('inc');
        var Gerente_Id = getParameterByName('ger');
        var tevent = getParameterByName('ev');

        $(document).ready(function () {

            Get_Comentario_Historico(Incidencia_Id, Gerente_Id, tevent);
            $('#btnGuardar').click(function () {
                var comentario = $('#txtComentario').val();
                if (!comentario) {
                    alert('Comentario no definido');
                    return false;
                }
                Get_Add_Personal(Incidencia_Id, Gerente_Id, tevent, comentario.toUpperCase());
                window.close();
            });

            $('#btnClear').click(function () {
                $('#txtComentario').val('');
                $('#txtComentario').focus();
            });
        });
    </script>
</body>
</html>
