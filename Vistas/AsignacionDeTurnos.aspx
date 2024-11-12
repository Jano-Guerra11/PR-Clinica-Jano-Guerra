<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignacionDeTurnos.aspx.cs" Inherits="Vistas.AsignacionDeTurnos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        .auto-style2 {
            width: 90%;
            margin-left: 61px;
            margin-right: 0px;
        }
        .auto-style3 {
            font-size: x-large;
        }
        .auto-style4 {
            text-align: left;
        }
        .auto-style5 {
            text-align: center;
        }
        .auto-style6 {
            width: 100%;
            margin-top: 34px;
        }
        .auto-style7 {
            width: 233px;
        }
        .auto-style8 {
            width: 233px;
            height: 30px;
        }
        .auto-style9 {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style4">
            <div class="auto-style5">
                <strong><span class="auto-style3">Asignacion De Turnos</span><br class="auto-style3" />
                </strong>
            </div>
        <table class="auto-style2">
            <tr>
                <td>ESPECIALIDAD:          <td>
                    <asp:DropDownList ID="ddlEspecialidad" runat="server" Height="17px" Width="266px" AutoPostBack="True" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged">
                        <asp:ListItem>-- Seleccione Especialidad --</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>MEDICO:</td>
                <td>
                    <asp:DropDownList ID="ddlMedicos" runat="server" Height="16px" Width="258px" AutoPostBack="True" OnSelectedIndexChanged="ddlMedicos_SelectedIndexChanged">
                        <asp:ListItem>-- Seleccione Medico --</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>DIA:</td>
                <td>
                    <asp:DropDownList ID="ddlDias" runat="server" Width="222px" Height="21px" OnSelectedIndexChanged="ddlDias_SelectedIndexChanged">
                        <asp:ListItem Value="0">-- Seleccione Dia --</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="lblDias" runat="server"></asp:Label>
                </td>
                <td>HORARIO:</td>
                <td>
                    <asp:DropDownList ID="ddlHorariosDelDia" runat="server" Height="30px" Width="254px">
                        <asp:ListItem>-- Seleccione Hora --</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>DNI PACIENTE:</td>
                <td>
                    <asp:TextBox ID="txtDniPaciente" runat="server" Height="19px" Width="190px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnAgregar" runat="server" Height="37px" Text="Agregar Turno" Width="100px" ValidationGroup="1" />
                </td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td></td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        </div>
        <table class="auto-style6">
            <tr>
                <td class="auto-style7">Nombre<br />
                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                </td>
                <td>Apellido<br />
                    <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar DNI" />
                </td>
                <td class="auto-style9">
                    <asp:Label ID="lblDni" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:GridView ID="grdTurnos" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
