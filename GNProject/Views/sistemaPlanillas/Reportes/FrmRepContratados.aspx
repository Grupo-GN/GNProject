<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmRepContratados.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Reportes.FrmRepContratados" %>

<%@ Register assembly="CrystalDecisions.Web" namespace="CrystalDecisions.Web" tagprefix="CR" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
        AutoDataBind="true" />
    </form>
</body>
</html>
