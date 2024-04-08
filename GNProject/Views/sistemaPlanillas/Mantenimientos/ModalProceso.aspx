<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModalProceso.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Mantenimientos.ModalProceso" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />
<base target="_self"/>
 <title>Mant. Procesos</title>
  <style type="text/css">
    .titulo
    {
        background: #C0C0C0;
        font-weight:bold ;
        
        border-bottom-width:1px;
    	border-bottom-color:Black;
    	border-bottom-style:solid;  
    }
    .borde
    {
    	border-width:1px;
    	border-color:Black;
    	border-style:solid;
    }
    .derecha
    {
     text-align:right;
    }
            .style5
          {
              text-align: right;
              width: 104px;
          }
    </style>
    
<script src="../JQuery/jquery-1.8.2.js" type="text/javascript"></script>
<script src="../JQuery/jquery-1.8.2.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        function CerrarConEvento() {
            window.returnValue = true;
            self.close();
        }
        function CerrarSinEvento() {
            window.returnValue = false;
            self.close();
        }

        $(document).ready(function() {

            $('#<%=lblError.ClientID %>').html(' - ');
            $('#<%=btnGrabar.ClientID %>').click(function() {
                var descripcion = $('#<%=txtDescripcion.ClientID %>');
                if (descripcion.val() == "" || descripcion.val() == null) {
                    $('#<%=lblError.ClientID %>').html('ERROR... Debe digitar la descripcion')
                    descripcion.focus();
                    return false
                } else {
                    if (confirm('Desea Guardar los Datos????') == true) {
                        $('#<%=lblError.ClientID %>').html('');
                        return true
                    } else {
                        return false
                    }
                }
            });

            $('#<%=btnCancelar.ClientID %>').click(function() {
                CerrarSinEvento();
            });

        });
    </script>
 
</head>
<body style="margin:0; padding:0;">
    <form id="form1" runat="server">
    
   <table class="borde" width="330px">
   <tr>
    <td align="center" class="titulo" colspan="2">
       <asp:Label ID="Label7" runat="server" Text="Mantenimiento de Procesos"
       Font-Bold="True" Font-Size="Large" ></asp:Label>
   </td>
   </tr>
             <tr>
                <td class="style5">
                    <asp:Label ID="Label3" runat="server" Text="Proceso_Id : " CssClass="miLabel"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtProcesoId" runat="server"
                     Enabled="False" Width="60px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                 <td class="style5">
                   <asp:Label ID="Label4" runat="server" Text="Descripcion : " CssClass="miLabel"></asp:Label></td>
                <td style="width:215px;">
                    <asp:TextBox ID="txtDescripcion" runat="server" Width="200px" CssClass="txt"></asp:TextBox>
                </td>
            </tr>
              <tr>
                 <td class="style5">
                   <asp:Label ID="Label2" runat="server" Text="Estado : " CssClass="miLabel"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="cboEstado" runat="server" CssClass="ddl" Width="90px">
                    </asp:DropDownList>
                </td>
            </tr>
    <tr>
    <td colspan="2">
    
       <table width="100%">
          <tr>
            <td style="height:3px;" colspan="2">
                <asp:Label ID="lblError" runat="server" Font-Bold="True" 
                     Font-Size="X-Small" ForeColor="#990000"></asp:Label>
            </td>
            </tr>
            <tr>
            <td colspan="2" align="right" width:100%;">
                <asp:Button ID="btnGrabar" runat="server" Text="Grabar" CssClass="submit" 
                    onclick="btnGrabar_Click" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="submit" 
                  CausesValidation="False"/>
            </td>
            </tr>
  </table>
    
    </td>
    </tr>
           
    </table>
    
    </form>
</body>
</html>
