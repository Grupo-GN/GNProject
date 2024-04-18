<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmAperturaCierrePeriodo.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Procesos.FrmAperturaCierrePeriodo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />

    <link href="../Styles/nuevoEstiloPlanilla.css" rel="stylesheet" type="text/css" />

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
<asp:Label ID="Label1" runat="server" Text="APERTURA CIERRE DE PERIODOS - PLANILLA " CssClass="miTitulo" ></asp:Label> 

<br />
<br />

<fieldset style="overflow:auto; border-style: outset; border-width: thin; height:90%; min-height:410px;  width: 97%; background-color:White;">
      <br />
      
      <fieldset>
      <legend>
       <center>
        <asp:Label ID="lblPlanilla" runat="server" Text="Label" CssClass="miTituloOnTab">
       </asp:Label>
       </center>
        </legend>
       
       <br />
       
        <asp:HiddenField ID="hdPeriodoApertura" runat="server" />
        <asp:HiddenField ID="hdPeriodoCierre" runat="server" />

        <div style="text-align: center;">
            <table width="100%">
                <tr>
                    <td>
                        <asp:Button ID="btnApertura" runat="server" Text="" CssClass="miBotonGrande" 
                            Width="500px" onclick="btnApertura_Click"
                            OnClientClick="return confirm('¿Está seguro de realizar Apertura para el Periodo?');" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnCierre" runat="server" Text="" CssClass="miBotonGrande" Width="500px" 
                            onclick="btnCierre_Click" 
                            OnClientClick="return confirm('Está seguro de Cerrar el Periodo, tenga en cuenta que debe haber completado todas las tareas en el Periodo');" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <asp:Button ID="btnActualizarAcum" runat="server" Text="" CssClass="miBotonGrande" 
                            Width="500px" onclick="btnActualizarAcum_Click" 
                            OnClientClick="return confirm('Está seguro de Actualizar Información del Periodo, esta tarea vuelve a Recoger Información del Periodo Anterior');" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnLimpiarPeriodo" runat="server" Text="" CssClass="miBotonGrande" 
                            Width="500px" onclick="btnLimpiarPeriodo_Click"
                             />
                    </td>
                </tr>
                <tr>
                    <td><asp:Button ID="btnConfigAsientos" runat="server" Text="" CssClass="miBotonGrande" 
                            Width="500px" OnClick="btnConfigAsientos_Click" /></td>
                </tr>
            </table>
        </div>
        
        
         <br />
        </fieldset>
       
        
</fieldset>

<br />
        
    </ContentTemplate>
</asp:UpdatePanel>

<asp:UpdateProgress ID="UpdateProgress1" runat="server" 
    DisplayAfter="1">                                        
    <ProgressTemplate>
        <div class="UpdateProgressModalBackground"></div>
        <center>                                            
            <div class="UpdateProgressPanel">
            Cargando...<br /><br />
            <asp:Image ID="Image2" runat="server" 
            alt="Procesando" ImageUrl="~/Views/sistemaPlanillas/css/ajax-loader.gif" /> 
            </div> 
        </center>
    </ProgressTemplate>                                        
</asp:UpdateProgress>

</asp:Content>

