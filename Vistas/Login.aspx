<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Vistas.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <link rel="stylesheet" href="CSS/estilo.css">
    <style type="text/css">
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
        .auto-style10 {
            text-align: center;
            width: 238px;
            height: 23px;
        }
        .auto-style11 {
            text-align: center;
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="cont_Titulo">
            <strong class="Titulo">CLINICA GUERRA</strong></div>
        <div class="cont_Tabla">

        <table class="Tabla_Login">
            <tr>
                <td class="celda"><h1 class="subTitulo">Iniciar Sesion</h1></td>
                <td class="celda">&nbsp;</td>
            </tr>
            <tr>
                <td class="celda">Legajo</td>
                <td class="celda">&nbsp;</td>
            </tr>
            <tr>
                <td class="celda">
                    <asp:TextBox class="textBox" ID="txtDni" runat="server" Height="23px" Width="160px"></asp:TextBox>
                &nbsp;<br />
                    <asp:CustomValidator ID="cvLegajo" runat="server" ControlToValidate="txtDni" ForeColor="Red" OnServerValidate="cvInicioSesion_ServerValidate" ValidationGroup="logeo"></asp:CustomValidator>
                </td>
                <td class="celda">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="celda">Contraseña</td>
                <td class="celda"></td>
            </tr>
            <tr>
                <td class="celda">
                    <asp:TextBox class="textBox" ID="txtContraseña" runat="server" Height="24px" Width="161px" TextMode="Password"></asp:TextBox>
                    <br />
                    <asp:CustomValidator ID="cvContrasena" runat="server" ControlToValidate="txtContraseña" ForeColor="Red" OnServerValidate="cvContrasena_ServerValidate" ValidationGroup="logeo"></asp:CustomValidator>
                    <br />
                    <asp:Button class="boton" ID="btnMostrar" runat="server" Height="30px" OnClick="btnMostrar_Click" Text="Mostrar" />
                </td>
                <td class="celda">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="celda">
                    <asp:CheckBox class="checkBox" ID="cbRecordarme" runat="server" Text="Recordar inicio" />
                </td>
                <td class="celda">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="celda">
                    <asp:Button class="boton" ID="btnIngresar" runat="server" Height="28px" Text="Ingresar" Width="74px" OnClick="btnIngresar_Click" ValidationGroup="logeo" />
                </td>
                <td class="celda">
                    </td>
            </tr>
        </table>
        </div>
        <br />
        <br />
        <br />
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
    </form>
</body>
</html>
