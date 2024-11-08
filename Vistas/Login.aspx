<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Vistas.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: xx-large;
            text-align: center;
        }
        .auto-style2 {
            width: 30%;
            margin-left: 528px;
            margin-right: 0px;
        }
        .auto-style3 {
            font-size: x-large;
            text-align: center;
            height: 51px;
        }
        .auto-style4 {
            text-align: center;
        }
        .auto-style6 {
            text-align: center;
            height: 40px;
        }
        .auto-style7 {
            font-size: x-large;
            text-align: center;
            height: 51px;
            width: 238px;
        }
        .auto-style8 {
            text-align: center;
            width: 238px;
        }
        .auto-style9 {
            text-align: center;
            height: 40px;
            width: 238px;
        }
        #form1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <strong>CLINICA GUERRA</strong></div>
        <table class="auto-style2">
            <tr>
                <td class="auto-style7"><strong>Iniciar Sesion</strong></td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">Legajo</td>
                <td class="auto-style4">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:TextBox ID="txtDni" runat="server" Height="23px" Width="160px"></asp:TextBox>
                &nbsp;</td>
                <td class="auto-style6">
                    <asp:CustomValidator ID="cvLegajo" runat="server" ControlToValidate="txtDni" ForeColor="Red" OnServerValidate="cvInicioSesion_ServerValidate" ValidationGroup="logeo"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">Contraseña</td>
                <td class="auto-style4">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:TextBox ID="txtContraseña" runat="server" Height="24px" Width="161px"></asp:TextBox>
                </td>
                <td class="auto-style6">
                    <asp:CustomValidator ID="cvContrasena" runat="server" ControlToValidate="txtContraseña" ForeColor="Red" OnServerValidate="cvContrasena_ServerValidate" ValidationGroup="logeo"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:CheckBox ID="cbRecordarme" runat="server" Text="Recordar inicio" />
                </td>
                <td class="auto-style6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:Button ID="btnIngresar" runat="server" Height="28px" Text="Ingresar" Width="74px" OnClick="btnIngresar_Click" ValidationGroup="logeo" />
                </td>
                <td class="auto-style6">
                    </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
    </form>
</body>
</html>
