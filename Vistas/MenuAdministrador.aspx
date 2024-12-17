<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuAdministrador.aspx.cs" Inherits="Vistas.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Menu administrador</title>
    <link rel="stylesheet" href="/CSS/estilo.css">
    
    <style type="text/css">
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
        <div class="usuario">
            <asp:Label ID="lblUsuario" runat="server"></asp:Label>
        </div>
        <table class="auto-style2">
            <tr>
                <td class="auto-style3"><strong>MENU</strong></td>
            </tr>
            <tr>
                <td class="auto-style10">
                    <asp:HyperLink ID="hlAbmlPacientes" runat="server" NavigateUrl="~/ABMLPaciente.aspx">Pacientes</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">
                    <asp:HyperLink ID="hlMedicos" runat="server" NavigateUrl="~/ABMLMedico.aspx">Medicos</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">
                    <asp:HyperLink ID="hlAsignacionTurnos" runat="server" NavigateUrl="~/AsignacionDeTurnos.aspx">Asignacion de turnos</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">
                    <asp:HyperLink ID="hlInformes" runat="server">Informes</asp:HyperLink>
                </td>
            </tr>
        </table>
        <asp:LinkButton ID="lbCerrarSesion" runat="server" OnClick="lbCerrarSesion_Click">Cerrar Sesion</asp:LinkButton>
    </form>
</body>
</html>
