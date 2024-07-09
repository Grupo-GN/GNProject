<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmDocumentoElectronicoRpt.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.RRHH.FrmDocumentoElectronicoRpt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf8" />
	<style type="text/css">
	body{font-family: Helvetica,Arial,sans-serif;font-size: 12px;}
	#main{
		width:500px;
		height: 100px;
		margin:auto;
		border-radius: 5px;|
		-webkit-box-shadow: -1px 7px 21px -6px rgba(213,231,245,0.35);
        -moz-box-shadow: -1px 7px 21px -6px rgba(213,231,245,0.35);
        box-shadow: -1px 7px 21px -6px rgba(232,236,249,0.35);
        background: #E8ECF9
	}
	#main div{
		float:left;
		margin-top: 20px;
		width: 400px;
		margin-left: 50px;

	}
	button{display:block;width:68px;height: 24px;border-radius: 5px;border:1px solid #688BFF;background: #91AAFD;color:#ffffff;float:left;
	</style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
	<div id="cuerpo">
		&nbsp;<asp:Label ID="lblMensaje" runat="server" Text="Label"></asp:Label>
	</div>
	<div id="pie">
		<button type="button" onclick="window.close();">Aceptar</button>
	</div>
</div>
    </form>
</body>
</html>
