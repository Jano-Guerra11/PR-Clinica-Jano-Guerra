<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambioContraseñaMedico.aspx.cs" Inherits="Vistas.CambioContraseñaMedico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        .auto-style2 {
            width: 30%;
            margin-left: 528px;
            }
        .auto-style7 {
            font-size: x-large;
            text-align: center;
            height: 51px;
            width: 238px;
        }
        .auto-style3 {
            font-size: x-large;
            text-align: center;
            height: 51px;
            width: 1531px;
        }
        .auto-style8 {
            text-align: center;
            width: 238px;
        }
        .auto-style4 {
            text-align: center;
            width: 1531px;
        }
        .auto-style9 {
            text-align: center;
            height: 40px;
            width: 238px;
        }
        .auto-style6 {
            text-align: center;
            height: 40px;
            width: 1531px;
        }
        .auto-style10 {
            text-align: center;
            height: 37px;
            width: 238px;
        }
        .auto-style11 {
            text-align: center;
            height: 37px;
            width: 1531px;
        }
        .auto-style12 {
            font-size: large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <table class="auto-style2">
            <tr>
                <td class="auto-style7">Cambiar Contraseña</td>
                <td class="auto-style3">
                    <asp:Label ID="lblUsuario" runat="server" CssClass="auto-style12"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">Ingrese su Legajo</td>
                <td class="auto-style4">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:TextBox ID="txtLegajo" runat="server" Height="23px" Width="160px"></asp:TextBox>
                &nbsp;</td>
                <td class="auto-style6">
                    <asp:CustomValidator ID="cvLegajo" runat="server" ControlToValidate="txtLegajo" ForeColor="Red" ValidationGroup="Cambio">Incorrecto</asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">Ingrese la contraseña actual </td>
                <td class="auto-style4">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:TextBox ID="txtContraseña" runat="server" Height="24px" Width="161px"></asp:TextBox>
                </td>
                <td class="auto-style6">
                    <asp:CustomValidator ID="cvContraseña" runat="server" ControlToValidate="txtContraseña" ErrorMessage="CustomValidator" ForeColor="Red" ValidationGroup="Cambio">Incorrecta</asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">
                    Ingrese la nueva contraseña</td>
                <td class="auto-style6">
                    <asp:CompareValidator ID="cmpvIguales" runat="server" ControlToCompare="txtContraseña" ControlToValidate="txtContraseña1" ForeColor="Red">La contraseña es igual a la anterior</asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:TextBox ID="txtContraseña1" runat="server" Height="24px" Width="151px"></asp:TextBox>
                </td>
                <td class="auto-style6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style10">
                    Ingrese denuevo</td>
                <td class="auto-style11">
                    <asp:CompareValidator ID="cmpVNueva" runat="server" ControlToCompare="txtContraseña2" ControlToValidate="txtContraseña1" ForeColor="Red" ValidationGroup="Cambio">Las contraseñas no son iguales</asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:TextBox ID="txtContraseña2" runat="server" Height="25px" Width="145px"></asp:TextBox>
                </td>
                <td class="auto-style6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:Button ID="btnIngresar" runat="server" Height="28px" Text="Ingresar" Width="74px" OnClick="btnIngresar_Click" ValidationGroup="Cambio" />
                </td>
                <td class="auto-style6">
                    &nbsp;</td>
            </tr>
        </table>
        </div>
    </form>
</body>
</html>
