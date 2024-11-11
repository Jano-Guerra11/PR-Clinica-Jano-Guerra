<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuMedicos.aspx.cs" Inherits="Vistas.MenuMedicos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style11 {
            text-align: center;
        }
        .auto-style2 {
            width: 30%;
            margin-left: 517px;
            margin-right: 0px;
        }
        .auto-style3 {
            font-size: x-large;
            text-align: center;
            height: 51px;
        }
        .auto-style10 {
            text-align: center;
            height: 50px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <div class="auto-style11">
            <asp:Label ID="lblUsuario" runat="server"></asp:Label>
        </div>
        <table class="auto-style2">
            <tr>
                <td class="auto-style3"><strong>MENU</strong></td>
            </tr>
            <tr>
                <td class="auto-style10">
                    <asp:HyperLink ID="hlTurnos" runat="server" NavigateUrl="~/TurnosMedico.aspx">Turnos y Pacientes</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">
                    <asp:HyperLink ID="hlCambiarContraseña" runat="server" NavigateUrl="~/CambioContraseñaMedico.aspx">Cambiar Contraseña</asp:HyperLink>
                </td>
            </tr>
            </table>
        </div>
        <asp:LinkButton ID="lbCerrarSesion" runat="server" OnClick="lbCerrarSesion_Click">Cerrar Sesion</asp:LinkButton>
    </form>
</body>
</html>
