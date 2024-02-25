<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GNProject.Views.Login.Login" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login-GN</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>

    <!-- Custom CSS -->
    <link href="~/Assets/Css/login.css" rel='stylesheet' type='text/css' />
    <!--<link href="css/font-awesome.css" rel="stylesheet"/> --%>
    <!-- jQuery -->
    <script src="../../Scripts/jquery/jquery-1.10.2.min.js" type="text/javascript"></script>

</head>


<body id="login">
    <div class="container">
        <div class="login-logo">
            <a href="index.html">
                <img src="images/logo.png" alt="" /></a>
        </div>
        <h2 class="form-heading">login</h2>
        <div class="app-cam">
            <form  action="" method="" runat="server">
                <input type="text" class="text" value="RUC" id="txtruc" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'RUC';}" name="Ruc" />
                <input required type="text" class="text" value="Username" id="txtUsuario1" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Username';}" runat="server" />
                <input required type="password" value="Password" id="txtContraseña1" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Password';}" runat="server" />
                <asp:Button ID="btnIngresar1" runat="server" Text="Ingresar" CssClass="submit" OnClick="btnIngresar1_Click" />
                   <%-- <p><a href="#">Forgot Password ?</a></p>--%>
                    <label style="color: Red;" id="lblError1" runat="server">&nbsp;</label>
                <div style="display: none;" id="Presenta" class="box login">
                    <input type="button" value="Siguiente" class="btnLogin" style="width: 150px;" id="btnSiguiente" />
                </div>

            </form>
        </div>
    </div>
</body>
</html>
<script src="../../Scripts/MasterPage/Log_Script.js" type="text/javascript"></script>

<script type="text/javascript">
    $(document).ready(function () {
        function comprueba() {
            var data = getDatoEmpresa1($("#txtruc").val(), '1');
            if (data != '') {
                $("txtUsuario1").prop('disabled', true);
                $("txtContraseña1").prop('disabled', true);
            } else {
                $("txtUsuario1").prop('disabled', false);
                $("txtContraseña1").prop('disabled', false);
            }


        }

        $('#btnSiguiente').trigger('click');

        $("#btnSiguiente").on('click', function () {
            comprueba();
        })

    });



</script>
