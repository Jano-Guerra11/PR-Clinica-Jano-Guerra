<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuAdministrador.aspx.cs" Inherits="Vistas.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Menu administrador</title>
    <link rel="stylesheet" href="/CSS/estilo.css">
    
</head>
<body style="height: 436px">
    <form id="form1" runat="server" class="auto-style11">
        <div class="usuario">
            <asp:Label ID="lblUsuario" runat="server"></asp:Label>
        </div>
        <table class="Tabla_Menu">
            <tr>
                <td class="row_menu_titulo"><strong class="titulo_menu">MENU</strong></td>
            </tr>
            <tr>
                <td class="row_menu">
                    <asp:HyperLink class="menu_link" ID="hlAbmlPacientes" runat="server" NavigateUrl="~/ABMLPaciente.aspx">Pacientes</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="row_menu">
                    <asp:HyperLink class="menu_link" ID="hlMedicos" runat="server" NavigateUrl="~/ABMLMedico.aspx">Medicos</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="row_menu">
                    <asp:HyperLink class="menu_link" ID="hlAsignacionTurnos" runat="server" NavigateUrl="~/AsignacionDeTurnos.aspx">Asignacion de turnos</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="row_menu">
                    <asp:HyperLink class="menu_link" ID="hlInformes" runat="server">Informes</asp:HyperLink>
                </td>
            </tr>
        </table>
        <asp:LinkButton class="cerrarSesion" ID="lbCerrarSesion" runat="server" OnClick="lbCerrarSesion_Click">Cerrar Sesion</asp:LinkButton>
    </form>
</body>
</html>
