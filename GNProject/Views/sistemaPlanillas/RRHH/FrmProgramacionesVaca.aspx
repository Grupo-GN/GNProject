<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmProgramacionesVaca.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.RRHH.FrmProgramacionesVaca" %>

asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />
     <fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px;border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black;min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; border-top: solid 1px black;">
        <br />
         <label class="miTitulo">PROGRAMACIÓN DE VACACIONES</label>
         <br />
         <table style="width:100%;border-collapse:collapse;">
            <tr>
                <td><label class="miLabel">Planilla</label></td>
                <td><asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList></td>
                <td></td>                
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>

        </table>
     
     
     </fieldset>

</asp:Content>

