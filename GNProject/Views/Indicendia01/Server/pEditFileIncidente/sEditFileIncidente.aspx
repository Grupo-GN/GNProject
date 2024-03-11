<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sEditFileIncidente.aspx.cs" Inherits="GNProject.Views.Indicendia01.Server.pEditFileIncidente.sEditFileIncidente" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ARCHIVOS POR INCIDENCIA</title>
    <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">

    <table class="tableDialog">
        <tr>
            <td style="width:50%;vertical-align:top;"><div style="width:100%;vertical-align:top;">
            <table>
                <tr>
                    <td><asp:FileUpload ID="fileInc" runat="server" />   </td>
                </tr>
                <tr>                    
                    <td><asp:Button ID="btnSubirFile" runat="server" Text="Subir" CssClass="submit" 
                            onclick="btnSubirFile_Click" /></td>
                </tr>
            </table>
                
            </div></td>
            <td style="width:50%;vertical-align:top;">
            <div style="width:100%;vertical-align:top;">
                <table class="table">
                    <thead>
                        <tr>
                            <th></th>
                            <th>Archivo</th>
                            <th>Ver</th>
                        </tr>
                    </thead>
                    <tbody id="tbodyFiles"></tbody>
                </table>
            </div>
            
            </td>
        </tr>
    </table>
 
         
    
    </form>
</body>
</html>

<script src="../../jquery1.10/jquery-1.10.2.min.js" type="text/javascript"></script>
<script src="Script_EditFileIncidente.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {
        var Incidencia_Id = getParameterByName("i");
        Get_Files_List(Incidencia_Id);
        //window.setInterval(function () { Get_Files_List(Cogido_Gen); }, 1000);

        $('#tbodyFiles').on('click', '.buttonDelete', function () {
            Get_Delte_DataFile(this.id, Incidencia_Id);
        });
    });

</script>
