<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sFileOsigermin.aspx.cs" Inherits="GNProject.Views.Indicendia01.Server.pSendOsigermin.sFileOsigermin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Subir File Osigermin</title>
    <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function cerrarme() {
            window.opener.CargarDatosOsigermin_Incidencia();
            window.opener.focus()
            self.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:FileUpload ID="fileOsiger" runat="server" />
    <asp:Button ID="Button1" runat="server" Text="Subir" CssClass="buttonHer" onclick="Button1_Click" /><br /><br /><br />


    <input type="button" value="salir" onclick="cerrarme()" class="submit" />
    </div>
    
    </form>
</body>
</html>