<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuMedicos.aspx.cs" Inherits="Vistas.MenuMedicos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
   <link rel="stylesheet" href="/CSS/estilo.css">
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <div class="usuario">
            <asp:Label ID="lblUsuario" runat="server"></asp:Label>
        </div>
        <table class="Tabla_Menu">
            <tr>
                <td class="row_menu_titulo"><strong class="titulo_menu">MENU</strong></td>
            </tr>
            <tr>
                <td class="row_menu">
                    <asp:HyperLink class="menu_link" ID="hlTurnos" runat="server" NavigateUrl="~/TurnosMedico.aspx">Turnos y Pacientes</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="row_menu">
                    <asp:HyperLink class="menu_link" ID="hlCambiarContraseña" runat="server" NavigateUrl="~/CambioContraseñaMedico.aspx">Cambiar Contraseña</asp:HyperLink>
                </td>
            </tr>
            </table>
        </div>
        <asp:LinkButton class="cerrarSesion" ID="lbCerrarSesion" runat="server" OnClick="lbCerrarSesion_Click">Cerrar Sesion</asp:LinkButton>
    </form>
</body>
</html>
