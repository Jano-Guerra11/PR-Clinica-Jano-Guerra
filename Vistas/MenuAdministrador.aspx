<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuAdministrador.aspx.cs" Inherits="Vistas.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
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
        .auto-style11 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style11">
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
                    <asp:LinkButton ID="lbMedico" runat="server">Medicos</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">
                    <asp:LinkButton ID="lbAsignacionDeTurnos" runat="server">Asignacion de Turnos</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">
                    <asp:LinkButton ID="lbInformes" runat="server">Informes</asp:LinkButton>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
