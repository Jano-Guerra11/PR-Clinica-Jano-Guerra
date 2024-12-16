<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="informes.aspx.cs" Inherits="Vistas.informes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 258px;
        }
        .auto-style3 {
            width: 258px;
            height: 23px;
        }
        .auto-style4 {
            height: 23px;
        }
        .auto-style5 {
            text-align: left;
        }
        .auto-style6 {
            font-size: x-large;
        }
        .auto-style7 {
            height: 23px;
            width: 231px;
        }
        .auto-style8 {
            width: 231px;
        }
        .auto-style9 {
            font-size: medium;
        }
        .auto-style10 {
            font-size: medium;
            width: 262px;
        }
        .auto-style11 {
            font-size: large;
        }
        .auto-style12 {
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style5">
            <asp:Label ID="lblUsuario" runat="server"></asp:Label>
            <br />
            <br />
            <strong><span class="auto-style6">Turnos</span></strong><br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style3">Cantidad de TURNOS este mes</td>
                    <td class="auto-style7">
                        <asp:Label ID="lblTurnos" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        &nbsp;CANTIDADES&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">Turnos PRESENTES</td>
                    <td class="auto-style7">
                        <asp:Label ID="lblTurnosPresentes" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:Label ID="lblCantidadPresentes" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Turnos AUSENTES</td>
                    <td class="auto-style8">
                        <asp:Label ID="lblTurnosAusentes" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblCantidadAusentes" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Turnos INDEFINIDOS</td>
                    <td class="auto-style8">
                        <asp:Label ID="lblTurnosIndefinidos" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblCantidadIndefinidos" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <strong><span class="auto-style6">Medicos</span></strong><br />
            Turnos asignados de cada medico<br />
            <asp:GridView ID="grdTurnosMedicos" runat="server">
            </asp:GridView>
            <br />
            <strong><span class="auto-style6">Especialidades<br />
            <br />
            </span></strong><span class="auto-style9">especialidades ordenadas por nivel de solicitud<br />
            <asp:GridView ID="grdEspecialidades" runat="server">
            </asp:GridView>
            <br />
            </span> <strong><span class="auto-style6">Pacientes<br />
            </span></strong>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style10">Paciente con mas asistencia en la clinica:</td>
                    <strong>
                    <td>
                        <asp:Label ID="lblPacienteMasFrecuente" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            </strong> </div>
        <p class="auto-style11">
            <span class="auto-style12">Historial de paciente:</span>
        </p>
        <p class="auto-style11">
            ingrese el dni del paciente&nbsp;
            <asp:TextBox ID="txtDniPaciente" runat="server"></asp:TextBox>
&nbsp;&nbsp;
            <asp:Button ID="btnBuscarHistorial" runat="server" OnClick="btnBuscarHistorial_Click" Text="Buscar Historial" />
        </p>
        <p class="auto-style11">
            paciente:
            <asp:Label ID="lblPacienteSeleccionado" runat="server"></asp:Label>
        </p>
        <p class="auto-style11">
            <asp:GridView ID="grdHistorialPaciente" runat="server" >
            </asp:GridView>
        </p>
    </form>
</body>
</html>
