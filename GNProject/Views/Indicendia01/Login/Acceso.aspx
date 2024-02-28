<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Acceso.aspx.cs" Inherits="GNProject.Views.Indicendia01.Login.Acceso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../css/login.css" rel="stylesheet" type="text/css" />
    
	<div id="block">
		<label id="user" for="name">p</label>
		<input type="text" name="name" id="name" placeholder="Username" required/>
		<label id="pass" for="password">k</label>
		<input type="password" name="password" id="password" placeholder="Password" required />
		<input type="button" id="submit" name="submit" value="a" />
	</div>   
    <div id="option"> 
	<p id="pIngreso"></p> 
	<a href="#">Olvid</a>
</div>
<script type="text/javascript" src="../jquery1.10/jquery-1.10.2.min.js"></script>
    <script src="Script_Acceso.js" type="text/javascript"></script>
    <script src="../jsSession/session.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {
        Session.set('Usuario', null);
        $('#submit').click(function () {
            $('#pIngreso').html('');
            var usuario = $('#name').val();
            var contraseña = $('#password').val();
            if (!usuario) {
                $('#pIngreso').html('Campo Requerido.');
                $('#name').focus();
                return false;
            }
            if (!contraseña) {
                $('#pIngreso').html('Campo Requerido.');
                $('#password').focus();
                return false;
            }
            Get_AccesoSistema(usuario, contraseña);
        });
    });


</script>

</asp:Content>
